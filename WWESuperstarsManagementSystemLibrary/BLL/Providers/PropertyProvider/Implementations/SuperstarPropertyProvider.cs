using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Implementations
{
    public class SuperstarPropertyProvider : ISuperstarPropertyProvider
    {
        public IEnumerable<string> GetModelPropertiesToInclude()
        {
            return new List<string> { "Gender", "Brand", "City.Country" };
        }

        public IEnumerable<PropertyInfoDto> GetReadDtoPropertiesToDisplay()
        {
            return new List<PropertyInfoDto>
            {
                new PropertyInfoDto { DisplayName = "ID Superstar", PropertyName = "IDSuperstar" },
                new PropertyInfoDto { DisplayName = "Name", PropertyName = "Name" },
                new PropertyInfoDto { DisplayName = "Height (cm)", PropertyName = "HeightCm" },
                new PropertyInfoDto { DisplayName = "Weight (kg)", PropertyName = "WeightKg" },
                new PropertyInfoDto { DisplayName = "Gender", PropertyName = "Gender" },
                new PropertyInfoDto { DisplayName = "Brand", PropertyName = "Brand" },
                new PropertyInfoDto { DisplayName = "City", PropertyName = "City" },
                new PropertyInfoDto { DisplayName = "Country", PropertyName = "Country" },
            };
        }
    }
}
