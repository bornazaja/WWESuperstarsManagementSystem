using System.Collections.Generic;
using System.Linq;

namespace WWESuperstarsManagementSystemLibrary.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> list)
        {
            return list.Count() == 0;
        }

        public static bool IsNotNullAndNotEmpty<T>(this IEnumerable <T> list)
        {
            return list != null && !list.IsEmpty();
        }
    }
}
