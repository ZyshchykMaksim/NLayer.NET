using System;
using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck.Models.Results
{
    /// <summary>
    /// SuccessfulIndividualHealthCheckResult.
    /// </summary>
    /// <seealso cref="BaseIndividualHealthCheckResult" />
    internal class SuccessfulIndividualHealthCheckResult : BaseIndividualHealthCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessfulIndividualHealthCheckResult"/> class.
        /// </summary>
        /// <param name="healthCheckName">Name of the health check.</param>
        /// <param name="healthCheckDescription">The health check description.</param>
        /// <param name="criticalMarking">The critical marking.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        internal SuccessfulIndividualHealthCheckResult(
            string healthCheckName,
            string healthCheckDescription,
            CriticalMarking criticalMarking,
            TimeSpan elapsedTime
        ) : base(healthCheckName, healthCheckDescription, true, criticalMarking, elapsedTime)
        {
        }
    }
}
