using System;

namespace WWESuperstarsManagementSystemLibrary.BLL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
