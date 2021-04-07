using System.Collections.Generic;
using WWESuperstarsManagementSystemLibrary.Common.Queries;

namespace WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        void Add(TModel model);
        void Update(int id, TModel model);
        void Delete(int id);
        TModel GetByID(int id, string[] propertiesToInclude);
        IEnumerable<TModel> GetAll(string[] propertiesToInclude);
        PagedList<TModel> GetAll(QueryCriteria queryCriteria, string[] propertiesToInclude);
        int Count();
    }
}
