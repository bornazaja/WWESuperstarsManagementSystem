using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.DAL.Models;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces
{
    public interface ICountryService : IGenericService<Country, CountrySaveDto, CountryReadDto>
    {
    }
}
