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
    /// ITransactionalUnitOfWork.
    /// </summary>
    public interface ITransactionalUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Begins a transaction on the underlying store connection using the specified isolation level. 
        /// </summary>
        /// <param name="isolationLevel">The database isolation level with which the underlying store transaction will be created.</param>
        /// <returns>
        /// A <see cref="T:System.Data.Entity.DbContextTransaction"/> object wrapping access to the underlying store's transaction object. 
        /// </returns>
        DbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
    }
}
