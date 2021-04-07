using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Implementations
{
    public class CityPropertyProvider : ICityPropertyProvider
    {
        public IEnumerable<string> GetModelPropertiesToInclude()
        {
            return new List<string> { "Country" };
        }

        public IEnumerable<PropertyInfoDto> GetReadDtoPropertiesToDisplay()
        {
            return new List<PropertyInfoDto>
            {
                new PropertyInfoDto { DisplayName = "ID City", PropertyName = "IDCity" },
                new PropertyInfoDto { DisplayName = "Name", PropertyName = "Name" },
                new PropertyInfoDto { DisplayName = "Country", PropertyName = "Country" }
            };
        }
    }
}
