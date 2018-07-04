#define TemplateCode // or ExpandDefault or FilterInCode or MinLevel or FilterFunction

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TodoApi
{
    public class Program
    {
#if TemplateCode
        #region snippet_TemplateCode
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        #endregion
#elif ExpandDefault
        #region snippet_ExpandDefault
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .UseStartup<Startup>()
                .Build();

            webHost.Run();
        }
        #endregion
#elif Scopes
        public static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
        #region snippet_Scopes
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole(options => options.IncludeScopes = true);
                    logging.AddDebug();
                })
        #endregion
                .UseStartup<Startup>()
                .Build();

            webHost.Run();
        }
#elif FilterInCode
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        #region snippet_FilterInCode
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                    logging.AddFilter("System", LogLevel.Debug)
                           .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace))
                .Build();
        #endregion
#elif MinLevel
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        #region snippet_MinLevel
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning))
                .Build();
        #endregion
#elif FilterFunction
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        #region snippet_FilterFunction
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logBuilder =>
                {
                    logBuilder.AddFilter((provider, category, logLevel) =>
                    {
                        if (provider == "Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider" && 
                            category == "TodoApi.Controllers.TodoController")
                        {
                            return false;
                        }
                        return true;
                    });
                })
                .Build();
        #endregion
#endif
    }
}