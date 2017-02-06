using System;
using System.Data.Entity;
using NLayer.NET.DBL.Entities;

namespace NLayer.NET.DBL
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        public AppDbContext() : base("name=DefaultConnection") { }

        public AppDbContext(string connectionString) : base(connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Invalid connection string");
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public virtual void Save()
        {
            base.SaveChanges();
        }
    }
}
