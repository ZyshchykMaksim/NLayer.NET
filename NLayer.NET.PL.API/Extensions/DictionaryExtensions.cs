using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayer.NET.PL.API.Extensions
{
    public static class DictionaryExtensions
    {
        public static string ToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return "{" + string.Join(",", dictionary.Select(kv => kv.Key + "=" + kv.Value).ToArray()) + "}";
        }
    }
}