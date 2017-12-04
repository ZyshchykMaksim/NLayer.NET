using System;
using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck.Models.Results
{
    /// <summary>
    /// Individual Health Check result.
    /// </summary>
    public abstract class BaseIndividualHealthCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIndividualHealthCheckResult"/> class.
        /// </summary>
        /// <param name="healthCheckName">Name of the health check.</param>
        /// <param name="healthCheckDescription">The health check description.</param>
        /// <param name="isSucceed">if set to <c>true</c> [is succeed].</param>
        /// <param name="criticalMarking">The critical marking.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        protected internal BaseIndividualHealthCheckResult(
            string healthCheckName, 
            string healthCheckDescription,
            bool isSucceed,
            CriticalMarking criticalMarking,
            TimeSpan elapsedTime
        )
        {
            HealthCheckName = healthCheckName;
            HealthCheckDescription = healthCheckDescription;
            IsSucceed = isSucceed;
            CriticalMarking = criticalMarking;
            ElapsedTime = elapsedTime;
        }

        /// <summary>
        /// Health check name.
        /// </summary>
        public string HealthCheckName { get; private set; }

        /// <summary>
        /// Health check description.
        /// </summary>
        public string HealthCheckDescription { get; private set; }

        /// <summary>
        /// Indicates if Health Check completed successfuly.
        /// </summary>
        public bool IsSucceed { get; private set; }

        /// <summary>
        /// Indicates how critical this Health Check for overal system status.
        /// </summary>
        public CriticalMarking CriticalMarking { get; private set; }

        /// <summary>
        /// Elapsed time.
        /// </summary>
        public TimeSpan ElapsedTime { get; private set; }
    }
}
