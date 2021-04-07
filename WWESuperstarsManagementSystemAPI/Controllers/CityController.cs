using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Factory;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Implementations;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.Validators.Interfaces;
using WWESuperstarsManagementSystemLibrary.DAL.Models;

namespace WWESuperstarsManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : GenericController<City, CitySaveDto, CityReadDto, CityPropertyProvider>
    {
        public CityController(IGenericService<City, CitySaveDto, CityReadDto> genericService, IMapper mapper, IValidator validator, IPropertyProviderFactory propertyProviderFactory) : base(genericService, mapper, validator, propertyProviderFactory)
        {
        }
    }
}
