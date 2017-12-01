using System.Data.Entity;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using NLayer.BLL.Services.Implementation;
using NLayer.Configuration;
using NLayer.DataAccess.DB;
using NLayer.DataAccess.DB.EF;
using NLayer.DataAccess.DB.EF.Extensions;
using NLayer.DAL;
using NLayer.DAL.Entities;
using NLayer.Logging;
using NLayer.Logging.NLog;
using NLayer.PL.API;
using NLayer.PL.API.Middlewares;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace NLayer.PL.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<AppDbContext>().As<DbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope(); ;

            builder.RegisterType<LogFactory>().As<ILogFactory>();
            builder.RegisterType<ConfigReader>().As<IConfigReader>().SingleInstance();


            builder.Register(c => new UserStore<User>(c.Resolve<AppDbContext>())).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerLifetimeScope();

            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerLifetimeScope();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerLifetimeScope();

            builder.RegisterType<TicketDataFormat>().As<ISecureDataFormat<AuthenticationTicket>>();
            builder.RegisterType<TicketSerializer>().As<IDataSerializer<AuthenticationTicket>>();

            builder.RegisterAssemblyTypes(typeof(ExternalDataService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<LoggingMiddleware>();

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
