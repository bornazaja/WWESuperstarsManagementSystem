using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace WWESuperstarsManagementSystemLibrary.Common.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddScoped(this IServiceCollection services, string assemblyStr, string lastPartOfClassName, string namespacePart)
        {
            PrepareToAddServices(assemblyStr, lastPartOfClassName, namespacePart, (serviceType, implementationType) => services.AddScoped(serviceType, implementationType));
        }

        public static void AddTransient(this IServiceCollection services, string assemblyStr, string lastPartOfClassName, string namespacePart)
        {
            PrepareToAddServices(assemblyStr, lastPartOfClassName, namespacePart, (serviceType, implementationType) => services.AddTransient(serviceType, implementationType));
        }

        private static void PrepareToAddServices(string assemblyStr, string lastPartOfClassName, string namespacePart, Action<Type, Type> action)
        {
            Assembly.Load(assemblyStr)
                .GetTypes()
                .Where(type => type.Namespace.Contains(namespacePart) && type.IsClass)
                .Where(type => type.Name.EndsWith(lastPartOfClassName) && !type.Name.StartsWith("Generic"))
                .ToList()
                .ForEach(type => action.Invoke(type.GetInterfaces().FirstOrDefault(i => i.Name == $"I{type.Name}"), type));
        }
    }
}
