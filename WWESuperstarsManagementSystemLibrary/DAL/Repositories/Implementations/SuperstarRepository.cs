using Microsoft.EntityFrameworkCore;
using WWESuperstarsManagementSystemLibrary.DAL.Models;
using WWESuperstarsManagementSystemLibrary.DAL.Repositories.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.DAL.Repositories.Implementations
{
    public class SuperstarRepository : GenericRepository<Superstar>, ISuperstarRepository
    {
        public SuperstarRepository(WWESuperstarsManagementSystemContext context) : base(context)
        {
        }
    }
}
