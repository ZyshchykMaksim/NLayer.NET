using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Services.Implementation;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;
using NLayer.NET.DBL.Repositories;
using NLayer.NET.DBL.Repositories.Implementation;
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

            builder.RegisterType<AppDbContext>().As<DbContext>().AsSelf().InstancePerRequest();

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<LogFactory>().As<ILogFactory>();

            builder.RegisterType<ApplicationUserStore>().As<IUserStore<User>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ExternalDataService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();

            ConfigureAuth(app);
        }
    }
}
