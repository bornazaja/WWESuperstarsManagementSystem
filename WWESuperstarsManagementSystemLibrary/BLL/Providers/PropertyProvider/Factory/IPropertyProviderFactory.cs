using System;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Factory
{
    public interface IPropertyProviderFactory
    {
        IPropertyProvider Create(Type type);
    }
}
