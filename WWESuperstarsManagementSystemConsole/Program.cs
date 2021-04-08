using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using WWESuperstarsManagementSystemLibrary.BLL.API.Implementations;
using WWESuperstarsManagementSystemLibrary.BLL.API.Interfaces;
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
                    services.AddTransient(nameof(WWESuperstarsManagementSystemConsole), "View", "Views");

                    services.AddScoped(typeof(IGenericApi<,>), typeof(GenericApi<,>));
                    services.AddScoped(nameof(WWESuperstarsManagementSystemLibrary), "Api", "API");
                });
        }
    }
}
