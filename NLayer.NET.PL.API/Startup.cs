using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using Microsoft.Owin;
using NLayer.PL.API;
using NLayer.PL.API.IoC.Autofac.Modules;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NLayer.PL.API
{
    /// <summary>
    /// Startup.
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// Configuration application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterModule(new ApplicationModule());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new DataAccessModule());
            builder.RegisterModule(new BusinessLogicModule(app));

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
