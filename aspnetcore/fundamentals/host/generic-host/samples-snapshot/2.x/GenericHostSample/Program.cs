using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GenericHostSample
{
    public class Program
    {
        #region snippet_HostBuilder
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .Build();

            await host.RunAsync();
        }
        #endregion

        public static async Task Main1(string[] args)
        {
            #region snippet_ConfigureHostConfiguration
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("hostsettings.json", optional: true);
                    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);
                })
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main2(string[] args)
        {
            #region snippet_ConfigureAppConfiguration
            var host = new HostBuilder()
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.SetBasePath(Directory.GetCurrentDirectory());
                    configApp.AddJsonFile("appsettings.json", optional: true);
                    configApp.AddJsonFile(
                        $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", 
                        optional: true);
                    configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                    configApp.AddCommandLine(args);
                })
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main3(string[] args)
        {
            #region snippet_ConfigureServices
            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    if (hostContext.HostingEnvironment.IsDevelopment())
                    {
                        // Development service configuration
                    }
                    else
                    {
                        // Non-development service configuration
                    }

                    services.AddHostedService<LifetimeEventsHostedService>();
                    services.AddHostedService<TimedHostedService>();
                })
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main4(string[] args)
        {
            #region snippet_ConfigureLogging
            var host = new HostBuilder()
                .ConfigureLogging((hostContext, configLogging) =>
                {
                    configLogging.AddConsole();
                    configLogging.AddDebug();
                })
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main5(string[] args)
        {
            #region snippet_UseConsoleLifetime
            var host = new HostBuilder()
                .UseConsoleLifetime()
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main6(string[] args)
        {
            #region snippet_UseContentRoot
            var host = new HostBuilder()
                .UseContentRoot("c:\\<content-root>")
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main7(string[] args)
        {
            #region snippet_UseEnvironment
            var host = new HostBuilder()
                .UseEnvironment(EnvironmentName.Development)
            #endregion
                .Build();

            await host.RunAsync();
        }

        public static async Task Main8(string[] args)
        {
            #region snippet_ContainerConfiguration
            var host = new HostBuilder()
                .UseServiceProviderFactory<ServiceContainer>(new ServiceContainerFactory())
                .ConfigureContainer<ServiceContainer>((hostContext, container) =>
                {
                })
            #endregion
                .Build();

            await host.RunAsync();
        }
    }
}
