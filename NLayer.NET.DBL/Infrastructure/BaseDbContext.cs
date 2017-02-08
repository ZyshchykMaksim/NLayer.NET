using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.DBL.Infrastructure
{
    public abstract class BaseDbContext : DbContext
    {
        protected BaseDbContext(string connectionString) : base(connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Invalid connection string");
        }

        protected new virtual IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
    }
}
