using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB
{
    /// <summary>
    /// Represents Business Transaction.
    /// Maintains a list of objects affected by a business transaction
    /// and coordinates the writing out of changes and the resolution of concurrency problems.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> CreateRepository<T>() where T : class;

        /// <summary>
        /// Saves Business Transaction.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves Business Transaction asynchronous.
        /// </summary>
        Task SaveAsync();
    }
}
