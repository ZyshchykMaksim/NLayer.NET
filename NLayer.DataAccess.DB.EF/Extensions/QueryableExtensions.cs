using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace NLayer.DataAccess.DB.EF.Extensions
{
    /// <summary>
    /// QueryableExtensions.
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Gets the paged result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static PagedResult<T> GetPagedResult<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var total = target.LongCount();

            if (startIndex != null)
            {
                target = target.Skip(() => startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(() => limit.Value);
            }

            return new PagedResult<T>()
            {
                Results = target.ToList(),
                Total = total
            };
        }

        /// <summary>
        /// Gets the paged result asynchronous.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="limit">The limit.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static async Task<PagedResult<T>> GetPagedResultAsync<T>(
            this IQueryable<T> target,
            int? startIndex = null,
            int? limit = null
        ) where T : class, new()
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            var total = await target.LongCountAsync();

            if (startIndex != null)
            {
                target = target.Skip(() => startIndex.Value);
            }

            if (limit != null)
            {
                target = target.Take(() => limit.Value);
            }

            return new PagedResult<T>()
            {
                Results = await target.ToListAsync(),
                Total = total
            };
        }
    }
}
