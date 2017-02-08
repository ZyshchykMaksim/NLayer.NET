using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LinqKit;

namespace NLayer.NET.DBL.Infrastructure
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

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

        /// <summary>
        /// Provides a point to query entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public virtual List<T> Find(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null, int? startIndex = null, int? limit = null)
        {
            var query = Query(filter, orderBy, includeProperties, startIndex, limit);

            return query.ToList();
        }

        /// <summary>
        /// Provides a point to query entities (async).
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="orderBy">The order by.</param>
        /// <param name="includeProperties">The include properties.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        public virtual Task<List<T>> FindAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null, int? startIndex = null, int? limit = null)
        {
            var query = Query(filter, orderBy, includeProperties, startIndex, limit);
            return query.ToListAsync();
        }

        protected virtual IQueryable<T> Query(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includeProperties = null, int? startIndex = null, int? limit = null)
        {
            IQueryable<T> query = _dbSet.AsExpandable();

            if (includeProperties != null)
            {
                includeProperties.ForEach(i => { query = query.Include(i); });
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (startIndex != null)
            {
                query = query.Skip(startIndex.Value);
            }

            if (limit != null)
            {
                query = query.Take(limit.Value);
            }

            return query;
        }

        #endregion
    }
}