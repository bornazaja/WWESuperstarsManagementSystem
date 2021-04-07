using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public class ListResponseDto<T> : ResponseBaseDto
    {
        public IEnumerable<T> List { get; set; }
        public IEnumerable<PropertyInfoDto> PropertyInfoListOfDto { get; set; }
    }
}
