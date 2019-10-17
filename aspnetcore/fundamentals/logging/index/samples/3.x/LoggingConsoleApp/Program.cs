using Microsoft.Extensions.Logging;

namespace LoggingConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region snippet_LoggerFactory
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    .AddEventLog();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Example log message");
            #endregion
        }
    }
}