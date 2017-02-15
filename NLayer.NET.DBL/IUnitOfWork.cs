using System;
using System.Threading.Tasks;
using NLayer.NET.Core.DB;
using NLayer.NET.DBL.Repositories.Implementation;

namespace NLayer.NET.DBL
{
    public interface IUnitOfWork<TDbContext> : IDisposable
    {
        /// <summary>
        /// Creates the generic repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> CreateGenericRepository<T>() where T : EntityBase;

        /// <summary>
        /// Saves current state.
        /// </summary>
        void Save();

        /// <summary>
        /// Saves current state asynchronous.
        /// </summary>
        Task SaveAsync();
    }
}