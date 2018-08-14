using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConfigurationSample.EFConfigurationProvider;

namespace ConfigurationSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        #region snippet1
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("starship.json", optional: false, reloadOnChange: false);
                    config.AddXmlFile("tvshow.xml", optional: false, reloadOnChange: false);
                    config.AddEFConfiguration(options => options.UseInMemoryDatabase("InMemoryDb"));
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>();
        #endregion
    }
}
