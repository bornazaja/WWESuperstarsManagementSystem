using WWESuperstarsManagementSystemLibrary.DAL.Models;

namespace WWESuperstarsManagementSystemLibrary.BLL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private WWESuperstarsManagementSystemContext _context;

        public UnitOfWork(WWESuperstarsManagementSystemContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
