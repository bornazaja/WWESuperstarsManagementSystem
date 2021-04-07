using AutoMapper;
using System;
using WWESuperstarsManagementSystemLibrary.BLL.API.DTO;
using WWESuperstarsManagementSystemLibrary.BLL.DTO;
using WWESuperstarsManagementSystemLibrary.Common.Constants;
using WWESuperstarsManagementSystemLibrary.Common.Queries;
using WWESuperstarsManagementSystemLibrary.DAL.Models;

namespace WWESuperstarsManagementSystemAPI.Mapping
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap(typeof(PagedList<>), typeof(PagedList<>));

            CreateMap<BrandSaveDto, Brand>();
            CreateMap<Brand, BrandReadDto>();

            CreateMap<CitySaveDto, City>();
            CreateMap<City, CityReadDto>()
                .ForMember(dto => dto.Country, cfg => cfg.MapFrom(model => model.Country.Name));

            CreateMap<CountrySaveDto, Country>();
            CreateMap<Country, CountryReadDto>();

            CreateMap<GenderSaveDto, Gender>();
            CreateMap<Gender, GenderReadDto>();

            CreateMap<SuperstarSaveDto, Superstar>();
            CreateMap<Superstar, SuperstarReadDto>()
                .ForMember(dto => dto.Gender, cfg => cfg.MapFrom(model => model.Gender.Name))
                .ForMember(dto => dto.Brand, cfg => cfg.MapFrom(model => model.Brand.Name))
                .ForMember(dto => dto.City, cfg => cfg.MapFrom(model => model.City.Name))
                .ForMember(dto => dto.Country, cfg => cfg.MapFrom(model => model.City.Country.Name));

            CreateMap<QueryCriteriaRequestDto, QueryCriteria>()
                .ForPath(target => target.SearchCriteria.PropertiesToSearch, cfg => cfg.MapFrom(source => source.PropertiesToSearch.Split(ArrayConstants.Separator, StringSplitOptions.RemoveEmptyEntries)))
                .ForPath(target => target.SearchCriteria.Term, cfg => cfg.MapFrom(source => source.SearchTerm))
                .ForPath(target => target.SortCriteria.PropertyName, cfg => cfg.MapFrom(source => source.PropertyNameToSort))
                .ForPath(target => target.SortCriteria.SortDirection, cfg => cfg.MapFrom(source => source.SortDirection))
                .ForPath(target => target.PageCriteria.PageIndex, cfg => cfg.MapFrom(source => source.PageIndex))
                .ForPath(target => target.PageCriteria.PageSize, cfg => cfg.MapFrom(source => source.PageSize));
        }
    }
}
