using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreModuleDemo
{
    /// <summary>
    /// Executing the "dotnet run" command in the application folder will run this app.
    /// You can also run "dotnet publish" and specify the publish directory as the physical path of a site in IIS Manager.
    /// </summary>
    public class Program
    {
        // The default listening address is http://localhost:5000 if none is specified.
        // You can use the --urls command-line flag to change the listening address when
        // running without IIS. Example:
        // > dotnet run --urls http://localhost:8080

        // Use the following code to configure URLs in code:
        // builder.UseUrls("http://localhost:8080");
        // Put it after UseConfiguration(config) to take precedence over 
        // command-line configuration. IIS config will take precedence over
        // UseUrls.
        #region snippet_Main
        public static int Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5001")
                .UseIISIntegration()
                .UseKestrel(options =>
                {
                    if (config["threadCount"] != null)
                    {
                        options.ThreadCount = int.Parse(config["threadCount"]);
                    }
                });

            var host = builder.Build();
            host.Run();

            return 0;
        }
        #endregion
    }
}
