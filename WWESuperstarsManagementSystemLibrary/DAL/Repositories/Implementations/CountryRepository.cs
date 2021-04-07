using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.DAL.Repositories.Implementations
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(WWESuperstarsManagementSystemContext context) : base(context)
        {
        }
    }
}
