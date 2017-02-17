using System;
using System.Runtime.Caching;

namespace NLayer.NET.DBL.Cache
{
    /// <summary>
    /// Cached data source
    /// </summary>
    public class CachedDataSource
    {
        private readonly ObjectCache cacheProvider;

        public CachedDataSource(ObjectCache cacheProvider)
        {
            if (cacheProvider == null)
            {
                throw new ArgumentNullException("cacheProvider");
            }

            this.cacheProvider = cacheProvider;
        }

        /// <summary>
        /// Retrive data from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="fallbackFunction"></param>
        /// <param name="cachePolicy"></param>
        /// <returns></returns>
        public T RetrieveCachedData<T>(string cacheKey, Func<T> fallbackFunction, CacheItemPolicy cachePolicy) where T : class
        {
            var data = cacheProvider.Get(cacheKey) as T;
            if (data != null)
            {
                return data;
            }

            data = fallbackFunction();

            if (data != null)
            {
                cacheProvider.Add(new CacheItem(cacheKey, data), cachePolicy);
            }

            return data;
        }

        public void RemoveCachedData(string cacheKey)
        {
            cacheProvider.Remove(cacheKey);
        }
    }
}
