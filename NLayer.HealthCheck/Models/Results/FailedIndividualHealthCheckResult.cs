using System;
using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck.Models.Results
{
    /// <summary>
    /// FailedIndividualHealthCheckResult.
    /// </summary>
    /// <seealso cref="BaseIndividualHealthCheckResult" />
    internal class FailedIndividualHealthCheckResult : BaseIndividualHealthCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailedIndividualHealthCheckResult"/> class.
        /// </summary>
        /// <param name="healthCheckName">Name of the health check.</param>
        /// <param name="healthCheckDescription">The health check description.</param>
        /// <param name="failedReason">The failed reason.</param>
        /// <param name="criticalMarking">The critical marking.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        internal FailedIndividualHealthCheckResult(
            string healthCheckName, 
            string healthCheckDescription, 
            string failedReason,
            CriticalMarking criticalMarking, 
            TimeSpan elapsedTime
        ) : base(healthCheckName, healthCheckDescription, false, criticalMarking, elapsedTime)
        {
            FailedReason = failedReason;
        }

        /// <summary>
        /// Failed reason.
        /// </summary>
        public string FailedReason { get; private set; }
    }
}
