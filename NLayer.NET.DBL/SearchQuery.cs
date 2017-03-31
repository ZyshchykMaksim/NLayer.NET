using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NLayer.NET.Common.Sorting;

namespace NLayer.NET.DBL
{
    public class SearchQuery<T>
    {
        protected List<Expression<Func<T, bool>>> Filters { get; set; }

        protected List<Expression<Func<T, object>>> IncludeProperties { get; set; }

        protected List<ISortCriteria<T>> SortCriterias { get; set; }

        public SearchQuery()
        {
            Filters = new List<Expression<Func<T, bool>>>();
            IncludeProperties = new List<Expression<Func<T, object>>>();
            SortCriterias = new List<ISortCriteria<T>>();
        }

        /// <summary>
        /// Includes new filter.
        /// </summary>
        /// <param name="filter"></param>
        public void AddFilter(Expression<Func<T, Boolean>> filter)
        {
            Filters.Add(filter);
        }

        /// <summary>
        /// Specifies property to attach to required entity.
        /// </summary>
        /// <param name="property"></param>
        public void IncludeProperty(Expression<Func<T, object>> property)
        {
            IncludeProperties.Add(property);
        }

        /// <summary>
        /// Includes new sort criteria.
        /// </summary>
        /// <param name="sortCriteria"></param>
        public void AddSortCriteria(ISortCriteria<T> sortCriteria)
        {
            SortCriterias.Add(sortCriteria);
        }

        /// <summary>
        /// Applies search query to specified collection.
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Apply(IQueryable<T> source)
        {
            source = ApplyFilters(source);
            source = ApplyIncludeProperties(source);
            source = ApplySortCriterias(source);

            return source;
        }

        /// <summary>
        /// Applies sort criterias specified in search query to result.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> ApplySortCriterias(IQueryable<T> collection)
        {
            if (!this.SortCriterias.Any())
            {
                return collection;
            }

            ISortCriteria<T> sortCriteria = this.SortCriterias.First();
            IOrderedQueryable<T> orderedCollection = sortCriteria.Apply(collection);

            for (var i = 1; i < this.SortCriterias.Count; i++)
            {
                ISortCriteria<T> sc = this.SortCriterias[i];
                orderedCollection = sc.Apply(orderedCollection);
            }

            collection = orderedCollection;

            return collection;
        }

        /// <summary>
        /// Applies specified filters to collection
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> ApplyFilters(IQueryable<T> collection)
        {
            if (this.Filters == null || this.Filters.Count == 0)
            {
                return collection;
            }

            this.Filters.ForEach(f => collection = collection.Where(f));

            return collection;
        }

        /// <summary>
        /// Includes required additional properties.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> ApplyIncludeProperties(IQueryable<T> collection)
        {
            if (this.IncludeProperties == null || !this.IncludeProperties.Any())
            {
                return collection;
            }

            this.IncludeProperties.ForEach(i => collection = collection.Include(i));

            return collection;
        }
    }
}
