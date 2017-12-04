using System.Collections.Generic;
using NLayer.HealthCheck.Models.Results;

namespace NLayer.HealthCheck
{
    /// <summary>
    /// IHealthChecker.
    /// </summary>
    public interface IHealthChecker
    {
        /// <summary>
        /// Checks the specified health check tasks.
        /// </summary>
        /// <param name="healthChecks">The health checks.</param>
        /// <returns></returns>
        OveralHealthCheckResult Check(IList<IHealthCheck> healthChecks);
    }
}
