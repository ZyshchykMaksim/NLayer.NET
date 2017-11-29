using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLayer.DAL.Entities;

namespace NLayer.DAL
{
    /// <summary>
    /// It will create the database if none exists as per the configuration. 
    /// However, if you change the model class and then run the application with this initializer, then it will throw an exception.
    /// <see cref="http://www.entityframeworktutorial.net/code-first/database-initialization-strategy-in-code-first.aspx"/>
    /// </summary>
    public class AppDbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            var manager = new UserManager<User>(new UserStore<User>(context));
            manager.PasswordValidator = new MinimumLengthValidator(4);
            User admin = new User()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com"
            };

            IdentityResult result = manager.Create(admin, "localhost");
            if (result.Succeeded)
            {
                IdentityRole admins = new IdentityRole("Admins");
                context.Roles.Add(admins);
                context.SaveChanges();

                manager.AddToRole(admin.Id, admins.Name);
            }
            context.ExternalDatas.Add(new ExternalData() { Ditails = "TODO" });
            base.Seed(context);
        }
    }
}
