using System;
using System.Data.Entity;

namespace NLayer.NET.DBL.DB
{
    public abstract class DbContextBase : DbContext
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
