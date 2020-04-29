#define FilterFunction
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

namespace MyMain
{
#if FilterFunction
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

#elif MinLevel

#endif
}
