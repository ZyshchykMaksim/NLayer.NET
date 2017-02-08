using System;
using System.Threading.Tasks;
using NLayer.NET.Core.DB;

namespace NLayer.NET.Core.Intarfeces
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