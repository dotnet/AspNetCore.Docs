#define MyMain  // MyMain for everything except the doc section "Call services from main"
#if MyMain
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DependencyInjectionSample
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
                    //                   webBuilder.UseStartup<Startup>();
                         webBuilder.UseStartup<Startup2>();
                    // run https://localhost:44313/Index5  Index has run time error
                    //webBuilder.UseStartup<DependencyInjectionSample5.Startup>(); 

                });
    }
}
#else

using DependencyInjectionSample.Interfaces;
using DependencyInjectionSample2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

#region snippet
public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var serviceScope = host.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            try
            {
                var myDependency = services.GetRequiredService<IMyDependency>();
                myDependency.WriteMessage("Call services from main");
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred.");
            }
        }

        host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
#endregion
#endif
