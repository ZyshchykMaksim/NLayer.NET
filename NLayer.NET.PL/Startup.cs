using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.Mvc;
using CommonServiceLocator;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using NLayer.DataAccess.DB;
using NLayer.DataAccess.DB.EF;
using NLayer.DataAccess.DB.EF.Extensions;
using NLayer.Logging;
using NLayer.Logging.NLog;
using NLayer.NET.BLL.Services.Implementation;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;

using Owin;

[assembly: OwinStartupAttribute(typeof(NLayer.NET.PL.Startup))]
namespace NLayer.NET.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<AppDbContext>().Named<DbContext>("AppDbContext").AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope(); ;
            builder.RegisterType<LogFactory>().As<ILogFactory>();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerLifetimeScope();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerLifetimeScope();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ExternalDataService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
