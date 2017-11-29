using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLayer.NET.DBL.Entities;

namespace NLayer.NET.DBL
{
    public class AppDbContext : DbContextBase
    {
        public DbSet<ExternalData> ExternalDatas { get; set; }

        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        public AppDbContext() : base("DefaultConnection") { }


        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public virtual void Save()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }
    }
}
