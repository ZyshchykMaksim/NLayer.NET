using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using NLayer.Configuration;
using NLayer.HealthCheck;
using NLayer.Logging;
using NLayer.Logging.NLog;

namespace NLayer.PL.API.IoC.Autofac.Modules
{
    /// <summary>
    /// Adds components in the container. 
    /// </summary>
    public class InfrastructureModule : Module
    {
        #region Overrides of Module

        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LogFactory>()
                .As<ILogFactory>();

            builder.RegisterType<ConfigReader>()
                .As<IConfigReader>()
                .SingleInstance();

            builder.RegisterType<HealthChecker>()
                .As<IHealthChecker>()
                .SingleInstance();
        }

        #endregion
    }
}