using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace LoggerMessageSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        #region snippet1
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    // Setting options.IncludeScopes is required in ASP.NET Core 2.0
                    // apps. Setting IncludeScopes via appsettings configuration files
                    // is a feature that's planned for the ASP.NET Core 2.1 release.
                    // See: https://github.com/aspnet/Logging/pull/706
                    logging.AddConsole(options => options.IncludeScopes = true);
                })
                .Build();
        #endregion
    }
}
