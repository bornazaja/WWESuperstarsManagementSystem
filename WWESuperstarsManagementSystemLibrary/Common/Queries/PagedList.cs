using System.Collections.Generic;

namespace WWESuperstarsManagementSystemLibrary.Common.Queries
{
    public class PagedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public IEnumerable<T> Subset { get; set; }
    }
}
