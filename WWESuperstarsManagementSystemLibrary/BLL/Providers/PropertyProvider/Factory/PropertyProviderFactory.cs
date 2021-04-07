using System;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Interfaces;

namespace WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Factory
{
    public class PropertyProviderFactory : IPropertyProviderFactory
    {
        public IPropertyProvider Create(Type type)
        {
            return (IPropertyProvider)Activator.CreateInstance(type);
        }
    }
}
