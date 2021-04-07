using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace WWESuperstarsManagementSystemLibrary.Common.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddToScopeMultipleInterfacesAndImplementations(this IServiceCollection services, string endClass, string namespaceStr)
        {
            Assembly.Load(nameof(WWESuperstarsManagementSystemLibrary))
                .GetTypes()
                .Where(type => type.Namespace.Contains(namespaceStr) && type.IsClass)
                .Where(type => type.Name.EndsWith(endClass) && !type.Name.StartsWith("Genereic"))
                .ToList()
                .ForEach(type => services.AddScoped(type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}"), type));
        }
    }
}
