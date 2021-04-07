using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.API.DTO
{
    public class SaveResponseDto<T> : ResponseBaseDto
    {
        public T Data { get; set; }
        public IEnumerable<ValidationResultDto> ValidationResults { get; set; }
        public IEnumerable<PropertyInfoDto> PropertyInfoListOfDto { get; set; }
    }
}
