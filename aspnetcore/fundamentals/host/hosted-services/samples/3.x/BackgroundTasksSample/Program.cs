using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BackgroundTasksSample.Services;

namespace BackgroundTasksSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    #region snippet3
                    services.AddSingleton<MonitorLoop>();
                    services.AddHostedService<QueuedHostedService>();
                    services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                    #endregion

                    #region snippet1
                    services.AddHostedService<TimedHostedService>();
                    #endregion

                    #region snippet2
                    services.AddHostedService<ConsumeScopedServiceHostedService>();
                    services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                    #endregion
                })
                .Build())
            {
                // Start the host
                await host.StartAsync();

                // Monitor for new background queue work items
                #region snippet4
                var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
                monitorLoop.StartMonitorLoop();
                #endregion

                // Wait for the host to shutdown
                await host.WaitForShutdownAsync();
            }
        }
    }
}
