using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using NLayer.NET.BLL.Logger;
using NLayer.NET.BLL.Services.Implementation;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;
using NLayer.NET.DBL.Repositories;
using NLayer.NET.DBL.Repositories.Implementation;
using NLayer.NET.PL.API.Providers;
using Owin;

[assembly: OwinStartup(typeof(NLayer.NET.PL.API.Startup))]

namespace NLayer.NET.PL.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            var config = new HttpConfiguration();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterType<AppDbContext>().As<DbContext>().AsSelf().InstancePerRequest();

            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();

            builder.RegisterType<LogFactory>().As<ILogFactory>().InstancePerRequest();

            builder.Register(c => new UserStore<User>(c.Resolve<AppDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();

            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            builder.RegisterType<TicketDataFormat>().As<ISecureDataFormat<AuthenticationTicket>>();
            builder.RegisterType<TicketSerializer>().As<IDataSerializer<AuthenticationTicket>>();

            builder.RegisterAssemblyTypes(typeof(ExternalDataService).Assembly).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
