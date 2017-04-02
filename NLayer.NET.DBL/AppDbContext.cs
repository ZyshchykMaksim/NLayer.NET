using System;
using System.Data.Entity;
using NLayer.NET.DBL.DB;
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
    }
}
