using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NLayer.NET.Core.DB;
using NLayer.NET.Common.Pagination;

namespace NLayer.NET.DBL.Repositories.Implementation
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<T>();
        }

        #region IRepository<T> Members


        /// <summary>
        /// Applies search with specified criteria and paging.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="paging"></param>
        /// <returns></returns>
        public virtual IPaginatedList<T> Search(SearchQuery<T> searchQuery, IPaging paging)
        {
            var result = this.BuildQuery(searchQuery);

            return paging.Apply(result);
        }

        /// <summary>
        /// Applies search with specified criteria.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Search(SearchQuery<T> searchQuery)
        {
            return this.BuildQuery(searchQuery).ToList();
        }

        /// <summary>
        /// Applies search with specified criteria.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public IQueryable<T> QueryableSearch(SearchQuery<T> searchQuery)
        {
            return this.BuildQuery(searchQuery);
        }

        /// <summary>
        /// Applies search with specified criteria.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> BuildQuery(SearchQuery<T> searchQuery)
        {
            IQueryable<T> collection = _dbSet;

            if (searchQuery == null)
            {
                return collection;
            }

            return searchQuery.Apply(collection);
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        /// <summary>
        /// Get find entities
        /// </summary>
        /// <param name="where">The conditions.</param>
        /// <returns>return entities</returns>
        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objs = _dbSet.Where<T>(where).AsEnumerable();

            foreach (var obj in objs)
                _dbSet.Remove(obj);
        }

        /// <summary>
        /// Deletes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void DeleteRange(ICollection<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertRange(ICollection<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }        

        #endregion
    }
}