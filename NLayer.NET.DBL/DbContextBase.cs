using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NLayer.DAL.Entities;

namespace NLayer.DAL
{
    public abstract class DbContextBase : IdentityDbContext<User>
    {
        protected DbContextBase(string connectionString) : base(connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Invalid connection string");
        }

        protected new virtual IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }
    }
}
