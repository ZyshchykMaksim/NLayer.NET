using System;
using System.Threading.Tasks;
using NLayer.NET.DBL.DB;
using NLayer.NET.DBL.Repositories;

namespace NLayer.NET.DBL
{
    public interface IUnitOfWork<TDbContext> : IDisposable
    {
        /// <summary>
        /// Creates the repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> CreateRepository<T>() where T : EntityBase;

        /// <summary>
        /// Creates the cached repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> CreateCachedRepository<T>() where T : EntityBase;

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