using AutoMapper;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.UoW;
using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Implementations
{
    public class GenderService : GenericService<Gender, GenderSaveDto, GenderReadDto>, IGenderService
    {
        public GenderService(IGenericRepository<Gender> genericRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(genericRepository, unitOfWork, mapper)
        {
        }
    }
}
