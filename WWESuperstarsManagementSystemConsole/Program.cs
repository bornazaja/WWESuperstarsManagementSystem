using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemConsole.Views.Implementations;
using WWESuperstarsManagementSystemConsole.Views.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.API.Implementations;
using WWESuperstarsManagementSystemLibrary.BLL.API.Interfaces;
using WWESuperstarsManagementSystemLibrary.BLL.Providers.PropertyProvider.Factory;
using WWESuperstarsManagementSystemLibrary.Common.Extensions;

namespace WWESuperstarsManagementSystemConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait();
        }

        static async Task MainAsync(string[] args)
        {
            var host = CreateHostBulder(args).Build();
            await host.Services.GetRequiredService<IApplication>().RunAsync();
        }

        static IHostBuilder CreateHostBulder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IApplication, Application>();
                    services.AddTransient<IRootView, RootView>();
                    services.AddTransient<IBrandView, BrandView>();
                    services.AddTransient<ICityView, CityView>();
                    services.AddTransient<ICountryView, CountryView>();
                    services.AddTransient<IGenderView, GenderView>();
                    services.AddTransient<ISuperstarView, SuperstarView>();
                    services.AddTransient<IPropertyProviderFactory, PropertyProviderFactory>();

                    services.AddScoped(typeof(IGenericApi<,>), typeof(GenericApi<,>));
                    services.AddToScopeMultipleInterfacesAndImplementations("Api", "API");
                });
        }
    }
}
