#define Scopes // FilterFunction // MinLevel // FilterCode // FilterFunction
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using MyMain;


#if FilterCode
#region snippet_FilterInCode
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(log =>
                   log.AddFilter("System", LogLevel.Debug)
                      .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Information)
                      .AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Trace))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
#endregion

#elif FilterFunction
#region snippet_FilterFunction
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logBuilder =>
            {
                logBuilder.AddFilter((provider, category, logLevel) =>
                {
                    if (provider.Contains("ConsoleLoggerProvider")
                        && category.Contains("Controller")
                        && logLevel >= LogLevel.Information
                        )
                    {
                        return true;
                    }
                    else if (provider.Contains("ConsoleLoggerProvider")
                        && category.Contains("Microsoft")
                        && logLevel >= LogLevel.Information
                        )
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                });
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
#endregion

#elif MinLevel
#region snippet_MinLevel
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning))
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
#endregion

#elif Scopes
#region snippet_MinLevel
public class Scopes
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.ClearProviders();
                logging.AddConsole(options => options.IncludeScopes = true);
                logging.AddDebug();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
#endregion

#endif
