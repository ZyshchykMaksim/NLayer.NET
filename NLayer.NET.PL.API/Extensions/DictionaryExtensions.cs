using System;
using System.Collections.Generic;
using System.Linq;

namespace NLayer.PL.API.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Convert dictionary in list strings
        /// </summary>
        /// <param name="dictionary">The dictionary</param>
        /// <typeparam name="TKey">The key</typeparam>
        /// <typeparam name="TValue">The value</typeparam>
        /// <returns></returns>
        public static string ConvertToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null || dictionary.Count <= 0) return String.Empty;
            return string.Join(Environment.NewLine, dictionary.Select(kv => kv.Key + ":" + kv.Value).ToArray());
        }
    }
}