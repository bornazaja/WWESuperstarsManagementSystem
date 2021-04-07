using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces
{
    public interface IPropertyProvider
    {
        IEnumerable<string> GetModelPropertiesToInclude();
        IEnumerable<PropertyInfoDto> GetReadDtoPropertiesToDisplay();
    }
}
