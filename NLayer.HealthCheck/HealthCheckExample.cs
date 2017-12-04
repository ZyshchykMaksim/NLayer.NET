using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck
{
    /// <summary>
    /// HealthCheckExample.
    /// </summary>
    /// <seealso cref="IHealthCheck" />
    public class HealthCheckExample : IHealthCheck
    {
        /// <summary>
        /// Description.
        /// </summary>
        public string Description => "Just an example Health Check.";

        /// <summary>
        /// Indicates how critical this Health Check for overal system status.
        /// </summary>
        public CriticalMarking CriticalMarking => CriticalMarking.Low;

        /// <summary>
        /// Health Check logic.
        /// </summary>
        public void Check()
        {
            // Proceed with individual health check and throw 
            // HealthCheckFailedException or HealthCheckWarningException in case
            // of negative result depending on conditions
        }
    }
}
