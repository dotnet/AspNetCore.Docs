//#define MAIN2
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

// Replace with the following code to test other XML files
//   config.AddXmlFile("MyXMLFile3.xml", optional: true, reloadOnChange: true)
//   Test preceding with Pages/XML/Index with path /xml

#if MAIN2
namespace ConfigSample
{
    #region snippet
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();

                    var env = hostingContext.HostingEnvironment;

                    config.AddXmlFile("MyXMLFile.xml", optional: true, reloadOnChange: true)
                          .AddXmlFile($"MyXMLFile.{env.EnvironmentName}.xml",
                                         optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    #endregion
}
#endif