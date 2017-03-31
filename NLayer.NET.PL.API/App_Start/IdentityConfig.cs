using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using NLayer.NET.DBL.Entities;
using NLayer.NET.PL.API.Models;

namespace NLayer.NET.PL.API
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public sealed class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> store) : base(store)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<User>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
        }
    }
}
