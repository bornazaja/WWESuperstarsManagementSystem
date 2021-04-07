using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Implementations
{
    public class CountryPropertyProvider : ICountryPropertyProvider
    {
        public IEnumerable<string> GetModelPropertiesToInclude()
        {
            return new List<string>();
        }

        public IEnumerable<PropertyInfoDto> GetReadDtoPropertiesToDisplay()
        {
            return new List<PropertyInfoDto>
            {
                new PropertyInfoDto { DisplayName = "ID Country", PropertyName = "IDCountry" },
                new PropertyInfoDto { DisplayName = "Name", PropertyName = "Name" }
            };
        }
    }
}
