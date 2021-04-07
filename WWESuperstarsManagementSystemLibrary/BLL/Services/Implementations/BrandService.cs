using AutoMapper;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.UoW;
using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Implementations
{
    public class BrandService : GenericService<Brand, BrandSaveDto, BrandReadDto>, IBrandService
    {
        public BrandService(IGenericRepository<Brand> genericRepository, IUnitOfWork unitOfWork, IMapper mapper) : base(genericRepository, unitOfWork, mapper)
        {
        }
    }
}
