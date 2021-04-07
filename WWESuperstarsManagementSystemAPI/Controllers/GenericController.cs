using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Factory;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.Validation.Validators.Interfaces;
using WWESuperstarsManagementSystemLibrary.Common.Extensions;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TModel, TSaveDto, TReadDto, TPropertyProvider> : ControllerBase where TModel : class where TSaveDto : class where TReadDto : class where TPropertyProvider : class
    {
        private IGenericService<TModel, TSaveDto, TReadDto> _genericService;
        private IMapper _mapper;
        private IValidator _validator;
        private IPropertyProvider _propertyProvider;
        protected readonly string[] _propertiesToInclude;
        protected readonly IEnumerable<PropertyInfoDto> _propertyInfoList;

        public GenericController(IGenericService<TModel, TSaveDto, TReadDto> genericService, IMapper mapper, IValidator validator, IPropertyProviderFactory propertyProviderFactory)
        {
            _genericService = genericService;
            _mapper = mapper;
            _validator = validator;
            _propertyProvider = propertyProviderFactory.Create(typeof(TPropertyProvider));
            _propertiesToInclude = _propertyProvider.GetModelPropertiesToInclude().ToArray();
            _propertyInfoList = _propertyProvider.GetReadDtoPropertiesToDisplay();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TSaveDto saveDto)
        {
            try
            {
                IEnumerable<ValidationResultDto> validationResults = _validator.Validate(saveDto);

                if (validationResults.IsEmpty())
                {
                    TReadDto readDto = _genericService.Add(saveDto, _propertiesToInclude);
                    return Ok(new SaveResponseDto<TReadDto> { IsSuccessful = true, Message = "Data is successfully saved.", Data = readDto, ValidationResults = validationResults, PropertyInfoListOfDto = _propertyInfoList });
                }
                else
                {
                    return BadRequest(new SaveResponseDto<TReadDto> { IsSuccessful = false, Message = "Invalid data.", Data = null, ValidationResults = validationResults, PropertyInfoListOfDto = null });
                }
            }
            catch (Exception)
            {
                return BadRequest(new SaveResponseDto<TReadDto> { IsSuccessful = false, Message = "An error occurred while saving data.", Data = null, ValidationResults = new List<ValidationResultDto>(), PropertyInfoListOfDto = null });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TSaveDto saveDto)
        {
            try
            {
                IEnumerable<ValidationResultDto> validationResults = _validator.Validate(saveDto);

                if (validationResults.IsEmpty())
                {
                    TReadDto readDto = _genericService.Update(id, saveDto, _propertiesToInclude);
                    return Ok(new SaveResponseDto<TReadDto> { IsSuccessful = true, Message = "Data is successfully saved.", Data = readDto, ValidationResults = validationResults, PropertyInfoListOfDto = _propertyInfoList });
                }
                else
                {
                    return BadRequest(new SaveResponseDto<TReadDto> { IsSuccessful = false, Message = "Invalid data.", Data = null, ValidationResults = validationResults, PropertyInfoListOfDto = null });
                }
            }
            catch (Exception)
            {

                return BadRequest(new SaveResponseDto<TReadDto> { IsSuccessful = false, Message = "An error occurred while updating data.", Data = null, ValidationResults = new List<ValidationResultDto>(), PropertyInfoListOfDto = null });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _genericService.Delete(id);
                return Ok(new SingleResponseDto<int> { IsSuccessful = true, Message = "Data is successfully deleted.", Data = id, PropertyInfoListOfDto = null });
            }
            catch (Exception)
            {
                return BadRequest(new SingleResponseDto<int> { IsSuccessful = false, Message = "An error occurred while deleting data.", Data = int.MinValue, PropertyInfoListOfDto = null });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                TReadDto readDto = _genericService.GetByID(id, _propertiesToInclude);
                return Ok(new SingleResponseDto<TReadDto> { IsSuccessful = true, Message = "Data is successfully retrived.", Data = readDto, PropertyInfoListOfDto = _propertyInfoList });
            }
            catch (Exception)
            {
                return BadRequest(new SingleResponseDto<TReadDto> { IsSuccessful = false, Message = "An error occurred while retriving data.", Data = null, PropertyInfoListOfDto = null });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                IEnumerable<TReadDto> readDtoList = _genericService.GetAll(_propertiesToInclude);
                return Ok(new ListResponseDto<TReadDto> { IsSuccessful = true, Message = "Data is successfully retrived.", List = readDtoList, PropertyInfoListOfDto = _propertyInfoList });
            }
            catch (Exception)
            {
                return BadRequest(new ListResponseDto<TReadDto> { IsSuccessful = false, Message = "An error occurred while retriving data.", List = null, PropertyInfoListOfDto = null });
            }
        }

        [HttpGet("pagedlist")]
        public IActionResult GetAll([FromQuery] QueryCriteriaRequestDto queryCriteriaRequestDto)
        {
            try
            {
                QueryCriteria queryCriteria = _mapper.Map<QueryCriteriaRequestDto, QueryCriteria>(queryCriteriaRequestDto);
                PagedList<TReadDto> readDtoPagedList = _genericService.GetAll(queryCriteria, _propertiesToInclude);
                return Ok(new PagedResponseDto<TReadDto> { IsSuccessful = true, Message = "Data is successfully retrived.", PagedList = readDtoPagedList, PropertyInfoListOfDto = _propertyInfoList });
            }
            catch (Exception)
            {
                return BadRequest(new PagedResponseDto<TReadDto> { IsSuccessful = false, Message = "An error occurred while retriving data.", PagedList = null, PropertyInfoListOfDto = null });
            }
        }

        [HttpGet("count")]
        public IActionResult Count()
        {
            try
            {
                int count = _genericService.Count();
                return Ok(new SingleResponseDto<int> { IsSuccessful = true, Message = "Data is successfully retrived.", Data = count, PropertyInfoListOfDto = null });
            }
            catch (Exception)
            {
                return BadRequest(new SingleResponseDto<int> { IsSuccessful = false, Message = "An error occurred while retriving total count of records.", Data = int.MinValue, PropertyInfoListOfDto = null });
            }
        }
    }
}
