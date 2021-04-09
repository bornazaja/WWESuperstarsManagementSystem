using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public class PagedResponseDto<T> : ResponseBaseDto
    {
        public PagedList<T> PagedList { get; set; }
        public IEnumerable<PropertyInfoDto> PropertyInfoListOfDto { get; set; }
    }
}
