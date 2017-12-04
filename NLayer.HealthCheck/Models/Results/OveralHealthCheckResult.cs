using System;
using System.Collections.Generic;
using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck.Models.Results
{
    /// <summary>
    /// OveralHealthCheckResult.
    /// </summary>
    public class OveralHealthCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OveralHealthCheckResult" /> class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="results">The individual health check results.</param>
        internal OveralHealthCheckResult(
            HealthCheckStatus status,
            IList<BaseIndividualHealthCheckResult> results
        )
        {
            Status = status;
            Results = results;
            Version = "1.0";
            Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// Overal health check status.
        /// </summary>
        public HealthCheckStatus Status { get; private set; }

        /// <summary>
        /// Individual health check results.
        /// </summary>
        public IList<BaseIndividualHealthCheckResult> Results { get; private set; }

        /// <summary>
        /// Version.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Timestamp.
        /// </summary>
        public DateTime Timestamp { get; private set; }
    }
}
