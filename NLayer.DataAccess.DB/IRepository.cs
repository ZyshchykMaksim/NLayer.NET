using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB
{
    /// <summary>
    /// Generic storage for persisted domain entities.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange(ICollection<T> entities);

        /// <summary>
        /// Removes the specified entity by key.
        /// </summary>
        /// <param name="key">The key.</param>
        void Remove(object key);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(T entity);

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange(ICollection<T> entities);

        /// <summary>
        /// Attaches the specified entity (in common used for stub updates).
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Attach(T entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="updateWholeEntity">if set to <c>true</c> updates whole
        /// entity otherwise updates only modified fields.</param>
        /// <param name="rowVersion">The row version.</param>
        void Update(T entity, bool updateWholeEntity = false, byte[] rowVersion = null);

        /// <summary>
        /// Finds the entity of type T by specified key or null if no such entity corresponding to the key
        /// </summary>
        /// <param name="key">Entity key</param>
        /// <returns>
        /// The entity or null if not found
        /// </returns>
        T Find(object key);

        /// <summary>
        /// Finds the entity of type T by specified key or null if no such entity corresponding to the key (async version)
        /// </summary>
        /// <param name="key">Entity key</param>
        /// <returns>
        /// The entity or null if not found
        /// </returns>
        Task<T> FindAsync(object key);

        /// <summary>
        /// Provides a point to query entities.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>The point to query entities.</returns>
        IQueryable<T> Query();
    }
}
