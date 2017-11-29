using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB.EF
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(DbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        #region IRepository<T> Members

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void AddRange(ICollection<T> entities)
        {
            dbSet.AddRange(entities);
        }

        /// <summary>
        /// Removes the specified entity by key.
        /// </summary>
        /// <param name="key">The key.</param>
        public void Remove(object key)
        {
            Remove(Find(key));
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Remove(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        /// <summary>
        /// Removes the specified range of entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void RemoveRange(ICollection<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Attaches the specified entity (in common used for stub updates).
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Attach(T entity)
        {
            dbSet.Attach(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="updateWholeEntity">if set to <c>true</c> updates whole
        /// entity otherwise updates only modified fields.</param>
        /// <param name="rowVersion">The row version.</param>
        public void Update(T entity, bool updateWholeEntity = false, byte[] rowVersion = null)
        {
            if (updateWholeEntity)
            {
                context.Entry(entity).State = EntityState.Modified;
            }

            if (rowVersion != null)
            {
                context.Entry(entity).OriginalValues["RowVersion"] = rowVersion;
            }
        }

        /// <summary>
        /// Finds the entity of type T by specified key or null if no such entity corresponding to the key
        /// </summary>
        /// <param name="key">Entity key</param>
        /// <returns>
        /// The entity or null if not found
        /// </returns>
        public T Find(object key)
        {
            return dbSet.Find(key);
        }

        /// <summary>
        /// Finds the entity of type T by specified key or null if no such entity corresponding to the key (async version)
        /// </summary>
        /// <param name="key">Entity key</param>
        /// <returns>
        /// The entity or null if not found
        /// </returns>
        public Task<T> FindAsync(object key)
        {
            return dbSet.FindAsync(key);
        }

        /// <summary>
        /// Provides a point to query entities.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>The point to query entities.</returns>
        public IQueryable<T> Query()
        {
            return dbSet;
        }

        #endregion
    }
}
