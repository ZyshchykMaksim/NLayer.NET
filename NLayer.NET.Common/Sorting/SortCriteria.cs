using System;
using System.Linq;
using System.Linq.Expressions;

namespace NLayer.NET.Common.Sorting
{
    /// <summary>
    /// Provides ability to specify ordering.
    /// </summary>
    /// <typeparam name="TSource">Type of ordered collection.</typeparam>
    /// <typeparam name="TKey">Type of field for ordering.</typeparam>
    public class SortCriteria<TSource, TKey> : ISortCriteria<TSource>
    {
        /// <summary>
        /// Sorting direction.
        /// </summary>
        public SortDirection Direction { get; set; }

        /// <summary>
        /// Expression to specify field for ordering.
        /// </summary>
        public Expression<Func<TSource, TKey>> SortExpression { get; set; }

        public SortCriteria()
        {
            Direction = SortDirection.Ascending;
        }

        public SortCriteria(Expression<Func<TSource, TKey>> sortExpression)
        {
            Direction = SortDirection.Ascending;
            SortExpression = sortExpression;
        }

        /// <summary>
        /// Applies first orderind to collection.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual IOrderedQueryable<TSource> Apply(IQueryable<TSource> source)
        {
            if (SortExpression == null)
            {
                return source.OrderBy(x => x);
            }

            switch (Direction)
            {
                case SortDirection.Ascending:
                    return source.OrderBy(SortExpression);

                case SortDirection.Descending:
                    return source.OrderByDescending(SortExpression);
                default:
                    throw new NotSupportedException();
            }
        }        
    }
}
