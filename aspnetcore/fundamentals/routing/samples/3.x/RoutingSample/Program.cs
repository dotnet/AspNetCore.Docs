using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Modify which startup class is used to run the various samples.
                    // webBuilder.UseStartup<Startup>();
                    // webBuilder.UseStartup<AuthorizationStartup>();
                    // webBuilder.UseStartup<EndpointInspectorStartup>();
                    // webBuilder.UseStartup<IntegratedMiddlewareStartup>();
                    // webBuilder.UseStartup<MiddlewareFlowStartup>();
                    // webBuilder.UseStartup<TerminalMiddlewareStartup>();
                    // webBuilder.UseStartup<StartupDelay>();
                    // webBuilder.UseStartup<StartupSW>();
                    //  webBuilder.UseStartup<StartupConstraint>();
                    //webBuilder.UseStartup<StartupUnsupported>();
                    webBuilder.UseStartup<StartupMVC>();
                });
    }
}