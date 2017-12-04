using NLayer.HealthCheck.Models.Enums;

namespace NLayer.HealthCheck
{
    /// <summary>
    /// Individual Health Check.
    /// </summary>
    public interface IHealthCheck
    {
        /// <summary>
        /// Description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Indicates how critical this Health Check for overal system status.
        /// </summary>
        CriticalMarking CriticalMarking { get; }

        /// <summary>
        /// Health Check logic.
        /// </summary>
        void Check();
    }
}
