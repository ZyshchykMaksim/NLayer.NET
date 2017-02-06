using System.Threading.Tasks;

namespace NLayer.NET.DBL.Infrastructure
{
    public interface IUnitOfWork<TDbContext>
    {
        /// <summary>
        /// Creates the generic repository.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IRepository<T> CreateGenericRepository<T>() where T : class, new();

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