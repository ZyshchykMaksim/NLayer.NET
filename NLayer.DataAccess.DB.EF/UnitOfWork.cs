using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB.EF
{
    /// <summary>
    /// Entity Framework UnitOfWork implementation.
    /// </summary>
    public class UnitOfWork : ITransactionalUnitOfWork
    {
        private readonly DbContext dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UnitOfWork(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Implementation of ITransactionalUnitOfWork

        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> CreateRepository<T>() where T : class
        {
            return new Repository<T>(this.dbContext);
        }

        /// <summary>
        /// Saves Business Transaction.
        /// </summary>
        public void Save()
        {
            dbContext.SaveChanges();
        }

        /// <summary>
        /// Saves Business Transaction asynchronous.
        /// </summary>
        public Task SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Begins a transaction on the underlying store connection using the specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">The database isolation level with which the underlying store transaction will be created.</param>
        /// <returns>
        /// A <see cref="T:System.Data.Entity.DbContextTransaction" /> object wrapping access to the underlying store's transaction object.
        /// </returns>
        public DbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return dbContext.Database.BeginTransaction(isolationLevel);
        }

        #endregion
    }
}
