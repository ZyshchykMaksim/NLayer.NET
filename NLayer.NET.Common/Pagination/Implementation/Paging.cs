using System.Collections.Generic;
using System.Linq;

namespace NLayer.NET.Common.Pagination.Implementation
{
    /// <summary>
    /// Declares methods to appy pagination to query.
    /// </summary>
    public class Paging : IPaging
    {
        /// <summary>
        /// Index of first element in results.
        /// </summary>
        public int StartIndex { get; set; }

        public int PageSize { get; set; }

        public Paging()
        {
            StartIndex = PagingDefaults.DefaultStartIndex;
            PageSize = PagingDefaults.DefaultPageSize;
        }

        /// <summary>
        /// Applies pagination to source.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public IPaginatedList<T> Apply<T>(IEnumerable<T> source)
        {
            var totalRecords = source.AsQueryable().Count();
            var totalPages = totalRecords / PageSize;

            if (totalPages * PageSize < totalRecords)
            {
                totalPages++;
            }

            if (StartIndex != 0)
            {
                source = source.AsQueryable().Skip(StartIndex);
            }

            source = source.AsQueryable().Take(PageSize);

            return new PaginatedList<T>(source.ToList(), totalPages, totalRecords);
        }
    }
}
