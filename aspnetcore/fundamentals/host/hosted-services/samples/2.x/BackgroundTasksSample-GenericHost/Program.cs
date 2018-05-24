using System;
using System.Threading;
using System.Threading.Tasks;
using BackgroundTasksSample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureLogging((hostContext, config) =>
                {
                    config.AddConsole();
                    config.AddDebug();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.AddEnvironmentVariables();
                    config.AddJsonFile("appsettings.json", optional: true);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    config.AddCommandLine(args);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging();

                    #region snippet1
                    services.AddHostedService<TimedHostedService>();
                    #endregion

                    #region snippet2
                    services.AddHostedService<ConsumeScopedServiceHostedService>();
                    services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                    #endregion

                    #region snippet3
                    services.AddHostedService<QueuedHostedService>();
                    services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                    #endregion
                })
                .UseConsoleLifetime()
                .Build();

            using (host)
            {
                // Start the host
                await host.StartAsync();

                // Monitor for new background queue work items
                StartMonitorLoop(host);

                // Wait for the host to shutdown
                await host.WaitForShutdownAsync();
            }
        }

        private static void StartMonitorLoop(IHost host)
        {
            var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            var backgroundTaskQueue = host.Services.GetRequiredService<IBackgroundTaskQueue>();
            var backgroundTaskLogger = loggerFactory.CreateLogger<IBackgroundTaskQueue>();
            var applicationLifetime = host.Services.GetRequiredService<IApplicationLifetime>();

            // Run a console user input loop in a background thread
            Task.Run(() => MonitorLoop(backgroundTaskQueue, backgroundTaskLogger, applicationLifetime.ApplicationStopping));
        }

        private static void MonitorLoop(IBackgroundTaskQueue backgroundTaskQueue, ILogger backgroundTaskLogger, CancellationToken cancellationToken)
        {
            Console.WriteLine();
            Console.WriteLine("Tap W to add a work item to the background queue ...");
            Console.WriteLine();

            while (!cancellationToken.IsCancellationRequested)
            {
                var keyStroke = Console.ReadKey();

                if (keyStroke.Key == ConsoleKey.W)
                {
                    // Enqueue a background work item
                    backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
                    {
                        var guid = Guid.NewGuid().ToString();

                        for (int delayLoop = 0; delayLoop < 3; delayLoop++)
                        {
                            backgroundTaskLogger.LogInformation(
                                $"Queued Background Task {guid} is running. {delayLoop}/3");
                            await Task.Delay(TimeSpan.FromSeconds(5), token);
                        }

                        backgroundTaskLogger.LogInformation(
                            $"Queued Background Task {guid} is complete. 3/3");
                    });
                }
            }
        }
    }
}
