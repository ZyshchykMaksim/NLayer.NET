using System;
using System.Data.Entity;
using NLayer.NET.DBL.Entities;
using NLayer.NET.DBL.Infrastructure;

namespace NLayer.NET.DBL
{
    public class AppDbContext : DbContextBase
    {
        public DbSet<User> Users { get; set; }

        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        public AppDbContext() : base("DefaultConnection") { }
        
        /// <summary>
        /// Save changes
        /// </summary>
        public virtual void Save()
        {
            base.SaveChanges();
        }
    }
}
