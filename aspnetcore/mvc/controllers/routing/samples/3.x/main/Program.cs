using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebMvcRouting
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
                   // webBuilder.UseStartup<Startup>();
                   // webBuilder.UseStartup<StartupMap>();
                   // webBuilder.UseStartup<StartupDefaultMVC>();
                    //    webBuilder.UseStartup<StartupAPI>();
                    // webBuilder.UseStartup<StartupSlugifyParamTransformer>();
                    webBuilder.UseStartup<StartupApiViews>();
                });
    }
}