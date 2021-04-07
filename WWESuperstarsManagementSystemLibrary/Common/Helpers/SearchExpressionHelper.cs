using System;
using System.Linq;
using System.Linq.Expressions;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.Common.Helpers
{
    public static class SearchExpressionHelper
    {
        public static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, SearchOperation searchOperation, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.Property);
            var body = MakeComparison(left, searchOperation, value);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static Expression MakeComparison(Expression left, SearchOperation searchOperation, string value)
        {
            switch (searchOperation)
            {
                case SearchOperation.Equal:
                    return MakeBinary(ExpressionType.Equal, left, value);
                case SearchOperation.NotEqual:
                    return MakeBinary(ExpressionType.NotEqual, left, value);
                case SearchOperation.GreatherThen:
                    return MakeBinary(ExpressionType.GreaterThan, left, value);
                case SearchOperation.GreatherThenOrEqualTo:
                    return MakeBinary(ExpressionType.GreaterThanOrEqual, left, value);
                case SearchOperation.LessThan:
                    return MakeBinary(ExpressionType.LessThan, left, value);
                case SearchOperation.LessThanOrEqualTo:
                    return MakeBinary(ExpressionType.LessThanOrEqual, left, value);
                case SearchOperation.Contains:
                case SearchOperation.StartsWith:
                case SearchOperation.EndsWith:
                    return Expression.Call(MakeString(left), searchOperation.ToString(), Type.EmptyTypes, Expression.Constant(value, typeof(string)));
                default:
                    throw new NotSupportedException($"This search operation ({searchOperation}) does not extists.");
            }
        }

        private static Expression MakeString(Expression source)
        {
            return source.Type == typeof(string) ? source : Expression.Call(source, "ToString", Type.EmptyTypes);
        }

        private static Expression MakeBinary(ExpressionType type, Expression left, string value)
        {
            object typedValue = value;

            if (left.Type != typeof(string))
            {
                if (string.IsNullOrEmpty(value))
                {
                    typedValue = null;

                    if (Nullable.GetUnderlyingType(left.Type) == null)
                    {
                        left = Expression.Convert(left, typeof(Nullable<>).MakeGenericType(left.Type));
                    }
                }
                else
                {
                    var valueType = Nullable.GetUnderlyingType(left.Type) ?? left.Type;

                    if (valueType.IsEnum)
                    {
                        typedValue = Enum.Parse(valueType, value);
                    }
                    else
                    {
                        if (valueType == typeof(Guid))
                        {
                            typedValue = Guid.Parse(value);
                        }
                        else
                        {
                            typedValue = Convert.ChangeType(value, valueType);
                        }
                    }
                }
            }

            var right = Expression.Constant(typedValue, left.Type);
            return Expression.MakeBinary(type, left, right);
        }
    }
}
