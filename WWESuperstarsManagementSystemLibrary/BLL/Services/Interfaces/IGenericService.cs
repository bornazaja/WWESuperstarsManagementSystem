using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.BLL.Services.Interfaces
{
    public interface IGenericService<TModel, TSaveDto, TReadDto> where TModel : class where TSaveDto : class where TReadDto : class
    {
        TReadDto Add(TSaveDto saveDto, string[] propertiesToInclude);
        TReadDto Update(int id, TSaveDto saveDto, string[] propertiesToInclude);
        void Delete(int id);
        TReadDto GetByID(int id, string[] propertiesToInclude);
        IEnumerable<TReadDto> GetAll(string[] propertiesToInclude);
        PagedList<TReadDto> GetAll(QueryCriteria queryCriteria, string[] propertiesToInclude);
        int Count();
    }
}
