using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WWESuperstarsManagementSystemLibrary.Common.Helpers
{
    public static class SortExpressionHelper
    {
        public static Expression BuildPredicate<T>(IQueryable<T> query, string methodName, string propertyName, IComparer<object> comparer = null)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            var body = propertyName.Split('.').Aggregate<string, Expression>(parameter, Expression.PropertyOrField);

            if (comparer != null)
            {
                return Expression.Call(typeof(Queryable), methodName, new[] { typeof(T), body.Type }, query.Expression, Expression.Lambda(body, parameter), Expression.Constant(comparer));
            }
            else
            {
                return Expression.Call(typeof(Queryable), methodName, new[] { typeof(T), body.Type }, query.Expression, Expression.Lambda(body, parameter));
            }
        }
    }
}
