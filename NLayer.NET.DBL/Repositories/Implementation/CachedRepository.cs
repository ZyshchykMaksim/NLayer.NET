using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using NLayer.NET.Core.DB;
using NLayer.NET.DBL.Cache;
using System.Runtime.Caching;

namespace NLayer.NET.DBL.Repositories.Implementation
{
    /// <summary>
    /// The cached repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CachedRepository<T> : GenericRepository<T> where T : EntityBase
    {
        private const int DefaultCacheIntervalInMinutes = 10;
        private const string CacheKeyTemplate = "{0}CollectionCache";

        private readonly int _cacheIntervalInMinutes;
        private readonly string _cacheKey;
        private readonly CachedDataSource _cachedDataSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CachedRepository(DbContext context, int cacheInterval = DefaultCacheIntervalInMinutes) :
            base(context)
        {
            _cacheIntervalInMinutes = cacheInterval;
            _cacheKey = string.Format(CacheKeyTemplate, typeof(T).Name);
            _cachedDataSource = new CachedDataSource(MemoryCache.Default);
        }

        #region IRepository<T> Members

        /// <summary>
        /// Generates query to cached data.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        protected override IQueryable<T> BuildQuery(SearchQuery<T> searchQuery)
        {
            IQueryable<T> collection = this.GetAll().AsQueryable();

            if (searchQuery == null)
            {
                return collection;
            }

            return searchQuery.Apply(collection);
        }

        /// <summary>
        /// Get find entities
        /// </summary>
        /// <param name="where">The conditions.</param>
        /// <returns>return entities</returns>
        public override T Get(Expression<Func<T, bool>> where)
        {
            return this.GetAll().AsQueryable().Where(where).FirstOrDefault<T>();
        }

        /// <summary>
        /// Get all entities.
        /// </summary>
        public override IEnumerable<T> GetAll()
        {
            return _cachedDataSource.RetrieveCachedData(
                _cacheKey,
                () => _dbSet.AsExpandable().ToList(),
                new CacheItemPolicy { AbsoluteExpiration = DateTime.UtcNow.AddMinutes(_cacheIntervalInMinutes) }
                );
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Delete(T entity)
        {
            base.Delete(entity);

            this.ClearCache();
        }

        /// <summary>
        /// Deletes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void DeleteRange(ICollection<T> entities)
        {
            base.DeleteRange(entities);

            this.ClearCache();
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Insert(T entity)
        {
            base.Insert(entity);

            this.ClearCache();
        }

        /// <summary>
        /// Inserts the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public override void InsertRange(ICollection<T> entities)
        {
            base.InsertRange(entities);

            this.ClearCache();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Update(T entity)
        {
            base.Update(entity);

            this.ClearCache();
        }        

        /// <summary>
        /// Removes cached collection.
        /// </summary>
        private void ClearCache()
        {
            _cachedDataSource.RemoveCachedData(this._cacheKey);
        }

        #endregion
    }
}