using System.Web;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using NLayer.BLL.Services.Implementation;
using NLayer.DAL;
using NLayer.DAL.Entities;
using Owin;

namespace NLayer.PL.IoC.Autofac.Modules
{
    /// <summary>
    /// Adds components in the container.
    /// </summary>
    public class BusinessLogicModule : Module
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessLogicModule" /> class.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        public BusinessLogicModule(IAppBuilder appBuilder)
        {
            AppBuilder = appBuilder;
        }

        /// <summary>
        /// The application builder.
        /// </summary>
        public IAppBuilder AppBuilder { get; private set; }

        #region Overrides of Module

        /// <summary>Override to add registrations to the container.</summary>
        /// <remarks>
        /// Note that the ContainerBuilder parameter is unique to this module.
        /// </remarks>
        /// <param name="builder">The builder through which components can be
        /// registered.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UserStore<User>(c.Resolve<AppDbContext>()))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserStore>()
                .As<IUserStore<User>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationSignInManager>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoleStore<IdentityRole>>()
                .As<IRoleStore<IdentityRole, string>>();
            
            builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
                .InstancePerLifetimeScope();

            builder.Register<IDataProtectionProvider>(c => AppBuilder.GetDataProtectionProvider())
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketDataFormat>()
                .As<ISecureDataFormat<AuthenticationTicket>>();

            builder.RegisterType<TicketSerializer>()
                .As<IDataSerializer<AuthenticationTicket>>();

            builder.RegisterAssemblyTypes(typeof(ExternalDataService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        #endregion
    }
}