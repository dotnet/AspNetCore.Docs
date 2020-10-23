using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SampleApp
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
                    //  webBuilder.UseStartup<Startup>();
                    // webBuilder.UseStartup<Startup1>();

                    // webBuilder.UseStartup<Startup2>(); 
                    webBuilder.UseStartup<Startup3>();
                  //  webBuilder.UseStartup<StartupNO>();

                   // webBuilder.UseStartup<StartupAll>();
                    //webBuilder.UseStartup<Startup3>();


                });
    }
}
