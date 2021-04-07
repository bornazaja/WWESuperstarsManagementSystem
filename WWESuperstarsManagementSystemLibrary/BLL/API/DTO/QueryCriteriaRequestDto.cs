using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public class QueryCriteriaRequestDto
    {
        public string PropertiesToSearch { get; set; }
        public string SearchTerm { get; set; }
        public string PropertyNameToSort { get; set; }
        public SortDirection SortDirection { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
