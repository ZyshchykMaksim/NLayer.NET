using System.Collections;
using System.Collections.Generic;

namespace NLayer.NET.Common.Pagination.Implementation
{
    /// <summary>
    /// Presents collection to which paging was applied.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T> : IPaginatedList<T>
    {
        private readonly List<T> _items;

        /// <summary>
        /// Number of pages for original collection.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Number of total records in original collection. 
        /// </summary>
        public int TotalRecords { get; private set; }

        public PaginatedList(List<T> items, int totalPages, int totalRecords)
        {
            _items = items;
            TotalPages = totalPages;
            TotalRecords = totalRecords;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
