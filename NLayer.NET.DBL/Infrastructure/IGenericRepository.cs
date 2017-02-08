using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayer.NET.DBL.Infrastructure
{
    /// <summary>
    /// Generic storage for persisted domain entities.
    /// </summary>
    public interface IGenericRepository<T> where T : EntityBase
    {

        /// <summary>
        /// Gets all entities of type T
        /// </summary>
        /// <returns>return entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get find entities
        /// </summary>
        /// <param name="where">The conditions.</param>
        /// <returns>return entities</returns>
        T Get(Expression<Func<T, bool>> where);

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Insert(T entity);

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void InsertRange(ICollection<T> entities);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete(T entity);
        
        /// <summary>
        /// Deletes the specified of entities.
        /// </summary>
        /// <param name="where">The conditions.</param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Deletes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void DeleteRange(ICollection<T> entities);

        /// <summary>
        /// Provides a point to query entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        List<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null, int? startIndex = null, int? limit = null);

        /// <summary>
        /// Provides a point to query entities (async).
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null, int? startIndex = null, int? limit = null);
    }
}