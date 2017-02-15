using System.Linq;

namespace NLayer.NET.DBL
{
    /// <summary>
    /// Provides ability to specify ordering.
    /// </summary>
    /// <typeparam name="TSource">Type of ordered collection.</typeparam>
    public interface ISortCriteria<TSource>
    {
        /// <summary>
        /// Applies first orderind to collection.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        IOrderedQueryable<TSource> Apply(IQueryable<TSource> source);        
    }
}
