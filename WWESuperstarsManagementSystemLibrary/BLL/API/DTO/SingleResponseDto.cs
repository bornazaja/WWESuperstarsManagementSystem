using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public class SingleResponseDto<T> : ResponseBaseDto
    {
        public T Data { get; set; }
        public IEnumerable<PropertyInfoDto> PropertyInfoListOfDto { get; set; }
    }
}
