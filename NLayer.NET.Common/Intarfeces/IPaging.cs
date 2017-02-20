using System.Collections.Generic;

namespace NLayer.NET.Common.Intarfeces
{
    /// <summary>
    /// Declares methods to appy pagination to query.
    /// </summary>
    public interface IPaging
    {
        /// <summary>
        /// Applies pagination to source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        IPaginatedList<T> Apply<T>(IEnumerable<T> source);
    }
}
