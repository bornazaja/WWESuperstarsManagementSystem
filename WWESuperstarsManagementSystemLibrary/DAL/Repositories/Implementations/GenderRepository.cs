using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.DAL.Repositories.Implementations
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(WWESuperstarsManagementSystemContext context) : base(context)
        {
        }
    }
}
