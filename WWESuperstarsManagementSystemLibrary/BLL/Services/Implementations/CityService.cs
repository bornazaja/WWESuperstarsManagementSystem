using AutoMapper;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.UoW;
using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Implementations
{
    public class CityService : GenericService<City, CitySaveDto, CityReadDto>, ICityService
    {
        public CityService(IGenericRepository<City> genericRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(genericRepository, unitOfWork, mapper)
        {
        }
    }
}
