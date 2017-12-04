using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NLayer.PL.API.Middlewares;
using Module = Autofac.Module;

namespace NLayer.PL.API.IoC.Autofac.Modules
{
    /// <summary>
    /// Adds components in the container. 
    /// </summary>
    public class ApplicationModule : Module
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
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterType<LoggingMiddleware>();
        }

        #endregion
    }
}