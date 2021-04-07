using AutoMapper;
using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.UoW;
using WWESuperstarsManagementSystemLibrary.Common.Extensions;
using WWESuperstarsManagementSystemLibrary.Common.Queries;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Implementations
{
    public class GenericService<TModel, TSaveDto, TReadDto> : IGenericService<TModel, TSaveDto, TReadDto> where TModel : class where TSaveDto : class where TReadDto : class
    {
        private IGenericRepository<TModel> _genericRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        protected readonly string _idPropertyName;

        public GenericService(IGenericRepository<TModel> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _idPropertyName = $"ID{typeof(TModel).Name}";
        }

        public TReadDto Add(TSaveDto saveDto, string[] propertiesToInclude)
        {
            TModel model = _mapper.Map<TSaveDto, TModel>(saveDto);
            _genericRepository.Add(model);
            _unitOfWork.Complete();

            int id = (int)model.GetPropertyValue(_idPropertyName);
            TModel found = _genericRepository.GetByID(id, propertiesToInclude);
            return _mapper.Map<TModel, TReadDto>(found);
        }

        public int Count()
        {
            return _genericRepository.Count();
        }

        public void Delete(int id)
        {
            _genericRepository.Delete(id);
            _unitOfWork.Complete();
        }

        public PagedList<TReadDto> GetAll(QueryCriteria queryCriteria, string[] propertiesToInclude)
        {
            PagedList<TModel> modelPagedList = _genericRepository.GetAll(queryCriteria, propertiesToInclude);
            return _mapper.Map<PagedList<TModel>, PagedList<TReadDto>>(modelPagedList);
        }

        public IEnumerable<TReadDto> GetAll(string[] propertiesToInclude)
        {
            IEnumerable<TModel> modelList = _genericRepository.GetAll(propertiesToInclude);
            return _mapper.Map<IEnumerable<TModel>, List<TReadDto>>(modelList);
        }

        public TReadDto GetByID(int id, string[] propertiesToInclude)
        {
            TModel model = _genericRepository.GetByID(id, propertiesToInclude);
            return _mapper.Map<TModel, TReadDto>(model);
        }

        public TReadDto Update(int id, TSaveDto saveDto, string[] propertiesToInclude)
        {
            TModel model = _mapper.Map<TSaveDto, TModel>(saveDto);
            _genericRepository.Update(id, model);
            _unitOfWork.Complete();

            TModel found = _genericRepository.GetByID(id, propertiesToInclude);
            return _mapper.Map<TModel, TReadDto>(found);
        }
    }
}
