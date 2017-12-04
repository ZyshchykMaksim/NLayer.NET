using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NLayer.HealthCheck.Models.Enums;
using NLayer.HealthCheck.Models.Results;
using NLayer.Logging;

namespace NLayer.HealthCheck
{
    /// <summary>
    /// HealthChecker.
    /// </summary>
    /// <seealso cref="IHealthChecker" />
    public sealed class HealthChecker : IHealthChecker
    {
        private readonly ILog<HealthChecker> logger;
        private readonly TimeSpan timeout;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthChecker" /> class.
        /// </summary>
        /// <param name="logFactory">The logger.</param>
        public HealthChecker(ILogFactory logFactory)
        {
            logger = logFactory.CreateLogger<HealthChecker>();
            this.timeout = TimeSpan.FromSeconds(5);
        }

        /// <summary>
        /// Checks the specified health check tasks.
        /// </summary>
        /// <param name="healthChecks">The health checks.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">At least one HealthCheck should be provided.</exception>
        public OveralHealthCheckResult Check(IList<IHealthCheck> healthChecks)
        {
            if (healthChecks == null || !healthChecks.Any())
            {
                throw new InvalidOperationException("At least one HealthCheck should be provided.");
            }

            var individualResults = healthChecks
                .AsParallel()
                .AsUnordered()
                .Select(IndividualHealthCheck)
                .OrderBy(r => r.HealthCheckName)
                .ToList();

            var overalStatus = individualResults.Any(e => !e.IsSucceed) ?
                individualResults.Any(e => !e.IsSucceed && e.CriticalMarking == CriticalMarking.High) ?
                    HealthCheckStatus.Error :
                    HealthCheckStatus.Warning :
                HealthCheckStatus.Healthy;

            return new OveralHealthCheckResult(overalStatus, individualResults);
        }

        private BaseIndividualHealthCheckResult IndividualHealthCheck(IHealthCheck healthCheck)
        {
            var healthCheckName = healthCheck.GetType().Name;

            var sw = Stopwatch.StartNew();

            var task = Task.Run<BaseIndividualHealthCheckResult>(
                () =>
                {
                    try
                    {
                        healthCheck.Check();
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"Health check { healthCheckName} ({ healthCheck.Description}) error.", ex);

                        return new FailedIndividualHealthCheckResult(
                            healthCheckName,
                            healthCheck.Description,
                            ex.Message,
                            healthCheck.CriticalMarking,
                            sw.Elapsed
                        );
                    }
                    finally
                    {
                        sw.Stop();
                    }

                    return new SuccessfulIndividualHealthCheckResult(
                        healthCheckName,
                        healthCheck.Description,
                        healthCheck.CriticalMarking,
                        sw.Elapsed
                    );
                }
            );

            var isTaskCompletedInTime = Task.WaitAll(new Task[] { task }, timeout);

            if (!isTaskCompletedInTime)
            {
                logger.Error($"Health check {healthCheckName} ({healthCheck.Description}) timed out.");

                return new FailedIndividualHealthCheckResult(
                    healthCheckName,
                    healthCheck.Description,
                    "Health check timed out.",
                    healthCheck.CriticalMarking,
                    sw.Elapsed
                );
            }

            return task.Result;
        }
    }
}
