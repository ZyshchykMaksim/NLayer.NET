using System.Collections.Generic;

namespace NLayer.NET.Common.Pagination
{
    public interface IPaginatedList<out T> : IEnumerable<T>
    {
        /// <summary>
        /// Count of total pages in results.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Count of records in results.
        /// </summary>
        int TotalRecords { get; }
    }
}
