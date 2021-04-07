using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WWESuperstarsManagementSystemLibrary.Common.Extensions;
using WWESuperstarsManagementSystemLibrary.Common.Queries;
using WWESuperstarsManagementSystemLibrary.DAL.Extensions;
using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.DAL.Repositories.Implementations
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        protected readonly WWESuperstarsManagementSystemContext _context;
        protected readonly string _idPropertyName;

        public GenericRepository(WWESuperstarsManagementSystemContext context)
        {
            _context = context;
            _idPropertyName = $"ID{typeof(TModel).Name}";
        }

        public void Add(TModel model)
        {
            _context.Set<TModel>().Add(model);
        }

        public int Count()
        {
            return _context.Set<TModel>().Count();
        }

        public void Delete(int id)
        {
            TModel model = _context.Set<TModel>().Find(id);
            _context.Set<TModel>().Remove(model);
        }

        public PagedList<TModel> GetAll(QueryCriteria queryCriteria, string[] propertiesToInclude)
        {
            return _context.Set<TModel>().IncludeProperties(propertiesToInclude)
                    .Search(queryCriteria.SearchCriteria)
                    .OrderByAscOrDesc(queryCriteria.SortCriteria)
                    .ToPagedList(queryCriteria.PageCriteria);
        }

        public IEnumerable<TModel> GetAll(string[] propertiesToInclude)
        {
            return _context.Set<TModel>().IncludeProperties(propertiesToInclude).ToList();
        }

        public TModel GetByID(int id, string[] propertiesToInclude)
        {
            return _context.Set<TModel>().IncludeProperties(propertiesToInclude).Where(_idPropertyName, SearchOperation.Equal, id.ToString()).First();
        }

        public void Update(int id, TModel model)
        {
            model.SetPropertyValue(_idPropertyName, id);
            TModel foundModel = _context.Set<TModel>().Find(id);
            _context.Entry(foundModel).CurrentValues.SetValues(model);
        }
    }
}
