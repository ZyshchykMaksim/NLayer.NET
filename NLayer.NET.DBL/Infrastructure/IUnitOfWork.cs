using System;
using System.Threading.Tasks;

namespace NLayer.NET.DBL.Infrastructure
{
    public interface IUnitOfWork<TDbContext>: IDisposable
    {
        /// <summary>
        /// Creates the generic repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IGenericRepository<T> CreateGenericRepository<T>() where T : class, new();

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