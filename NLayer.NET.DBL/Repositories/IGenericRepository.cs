using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NLayer.NET.Core.DB;
using NLayer.NET.Common.Pagination;

namespace NLayer.NET.DBL.Repositories
{
    /// <summary>
    /// Generic storage for persisted domain entities.
    /// </summary>
    public interface IGenericRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Applies search with specified criteria.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        IEnumerable<T> Search(SearchQuery<T> searchQuery);

        /// <summary>
        /// Applies queryable search with specified criteria.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        IQueryable<T> QueryableSearch(SearchQuery<T> searchQuery);

        /// <summary>
        /// Applies search with specified criteria and paging.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="paging"></param>
        /// <returns></returns>
        IPaginatedList<T> Search(SearchQuery<T> searchQuery, IPaging paging);

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
    }
}