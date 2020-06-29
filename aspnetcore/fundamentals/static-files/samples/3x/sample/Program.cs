using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace sample
{
    #region snippet_Main
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
                    //webBuilder.UseStartup<Startup>();
                    // webBuilder.UseStartup<StartupRose>();
                    // webBuilder.UseStartup<StartupAddHeader>();
                    //webBuilder.UseStartup<StartupBrowse>();
                    //webBuilder.UseStartup<StartupEmpty>();
                    //webBuilder.UseStartup<StartupEmpty2>();
                    //webBuilder.UseStartup<StartupEmpty3>();
                    //webBuilder.UseStartup<StartupDefault>();
                    // webBuilder.UseStartup<StartupDefault2>();
                    webBuilder.UseStartup<StartupUseFileServer>();
                    //webBuilder.UseStartup<StartupFileExtensionContentTypeProvider>();
                    //webBuilder.UseStartup<StartupServeUnknownFileTypes>();

                    //webBuilder.UseStartup<StartupEmpty3>();


                });
    }
    #endregion
}
