using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace StaticFilesSample
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
                     webBuilder.UseStartup<StartupRose>();
                    // webBuilder.UseStartup<StartupAddHeader>();
                    // webBuilder.UseStartup<StartupBrowse>();
                    // webBuilder.UseStartup<StartupEmpty>();
                    // webBuilder.UseStartup<StartupEmpty2>();
                    // webBuilder.UseStartup<StartupEmpty3>();
                    // webBuilder.UseStartup<StartupDefault>();
                    // webBuilder.UseStartup<StartupDefault2>();
                    // webBuilder.UseStartup<StartupFileServer>();
                    // webBuilder.UseStartup<StartupFileExtensionContentTypeProvider>();
                    // webBuilder.UseStartup<StartupServeUnknownFileTypes>();
                });
    }
}
