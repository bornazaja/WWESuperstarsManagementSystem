using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WWESuperstarsManagementSystemLibrary.Common.Helpers;
using WWESuperstarsManagementSystemLibrary.Common.Predicates;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.DAL.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> IncludeProperties<T>(this IQueryable<T> query, string[] propertiesToInclude) where T : class
        {
            if (propertiesToInclude.Count() > 0)
            {
                foreach (var propertyToInclude in propertiesToInclude)
                {
                    query = query.Include(propertyToInclude);
                }
            }

            return query;
        }

        public static IQueryable<T> Search<T>(this IQueryable<T> query, SearchCriteria searchCriteria)
        {
            var predicate = PredicateBuilder.False<T>();

            if (searchCriteria.PropertiesToSearch.Count() > 0 && !string.IsNullOrEmpty(searchCriteria.Term))
            {
                foreach (var property in searchCriteria.PropertiesToSearch)
                {
                    predicate = predicate.Or(SearchExpressionHelper.BuildPredicate<T>(property, SearchOperation.Contains, searchCriteria.Term));
                }

                return query.Where(predicate);
            }

            return query;
        }

        public static IQueryable<T> Where<T>(this IQueryable<T> query, string propertyName, SearchOperation searchOperation, string value)
        {
            return query.Where(SearchExpressionHelper.BuildPredicate<T>(propertyName, searchOperation, value));
        }

        public static IQueryable<T> OrderByAscOrDesc<T>(this IQueryable<T> query, SortCriteria sortCriteria)
        {
            if (string.IsNullOrEmpty(sortCriteria.PropertyName))
            {
                return query;
            }

            if (sortCriteria.SortDirection == SortDirection.Ascending)
            {
                return CallOrderedQueryable(query, "OrderBy", sortCriteria.PropertyName);
            }
            else
            {
                return CallOrderedQueryable(query, "OrderByDescending", sortCriteria.PropertyName);
            }
        }

        private static IOrderedQueryable<T> CallOrderedQueryable<T>(IQueryable<T> query, string methodName, string propertyName)
        {
            return (IOrderedQueryable<T>)query.Provider.CreateQuery(SortExpressionHelper.BuildPredicate(query, methodName, propertyName));
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, PageCriteria pageCriteria)
        {
            List<T> subset = query.Skip(pageCriteria.PageIndex * pageCriteria.PageSize).Take(pageCriteria.PageSize).ToList();
            int count = query.Count();

            PagedList<T> pagedList = new PagedList<T>();
            pagedList.PageIndex = pageCriteria.PageIndex;
            pagedList.PageSize = pageCriteria.PageSize;
            pagedList.TotalCount = count;
            pagedList.TotalPages = (int)Math.Ceiling(pagedList.TotalCount / (double)pageCriteria.PageSize);
            pagedList.HasPrevious = pageCriteria.PageIndex > 0 ? true : false;
            pagedList.HasNext = pageCriteria.PageIndex + 1 < pagedList.TotalPages ? true : false;
            pagedList.Subset = subset;

            return pagedList;
        }
    }
}
