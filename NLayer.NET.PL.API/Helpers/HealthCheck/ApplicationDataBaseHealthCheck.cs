using System;
using NLayer.DAL;
using NLayer.HealthCheck;
using NLayer.HealthCheck.Models.Enums;
using NLayer.HealthCheck.Models.Exceptions;

namespace NLayer.PL.API.Helpers.HealthCheck
{
    /// <summary>
    /// IdentityDatabaseHealthCheck (checks that connection to the database is alive).
    /// </summary>
    /// <seealso cref="IHealthCheck" />
    public class ApplicationDatabaseHealthCheck : IHealthCheck
    {
        #region Implementation of IHealthCheck

        /// <summary>
        /// Description.
        /// </summary>
        public string Description => "Checks that connection to the database is alive.";

        /// <summary>
        /// Indicates how critical this Health Check for overall system status.
        /// </summary>
        public CriticalMarking CriticalMarking => CriticalMarking.High;

        /// <summary>
        /// Health Check logic.
        /// </summary>
        public void Check()
        {
            try
            {
                using (var dbContext = new AppDbContext())
                {
                    dbContext.Database.CommandTimeout = 3;
                    dbContext.Database.Connection.Open();
                    dbContext.Database.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new HealthCheckFailedException("Unable establish connection to the database.", ex);
            }
        }

        #endregion
    }
}