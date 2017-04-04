using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using NLayer.NET.DBL;
using NLayer.NET.DBL.Entities;
using NLayer.NET.PL.API.Configurations;
using NLayer.NET.PL.API.Models;
using PasswordValidator = Microsoft.AspNet.Identity.PasswordValidator;

namespace NLayer.NET.PL.API
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationUserManager : UserManager<User>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            // See in web.config
            IdentityConfiguration identityConfiguration = (IdentityConfiguration)ConfigurationManager.GetSection("identityConfiguration");

            var manager = new ApplicationUserManager(new UserStore<User>(context.Get<AppDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = identityConfiguration?.UserValidator?.AllowOnlyAlphanumericUserNames ?? UserValidatorElement.AllowOnlyAlphanumericUserNamesDefault,
                RequireUniqueEmail = identityConfiguration?.UserValidator?.RequireUniqueEmail ?? UserValidatorElement.RequireUniqueEmailDefault
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = identityConfiguration?.PasswordValidator?.RequiredLength ?? PasswordValidatorElement.RequiredLengthDefault,
                RequireNonLetterOrDigit = identityConfiguration?.PasswordValidator?.RequireNonLetterOrDigit ?? PasswordValidatorElement.RequireNonLetterOrDigitDefault,
                RequireDigit = identityConfiguration?.PasswordValidator?.RequireDigit ?? PasswordValidatorElement.RequireDigitDefault,
                RequireLowercase = identityConfiguration?.PasswordValidator?.RequireLowercase ?? PasswordValidatorElement.RequireLowercaseDefault,
                RequireUppercase = identityConfiguration?.PasswordValidator?.RequireUppercase ?? PasswordValidatorElement.RequireUppercaseDefault,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
