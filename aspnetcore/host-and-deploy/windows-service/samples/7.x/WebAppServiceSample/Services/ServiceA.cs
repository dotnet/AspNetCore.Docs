using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SampleApp.Services
{
    public class ServiceA : BackgroundService
    {
        public ServiceA(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<ServiceA>();
        }

        public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("ServiceA is starting.");

            stoppingToken.Register(() => Logger.LogInformation("ServiceA is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("ServiceA is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Logger.LogInformation("ServiceA has stopped.");
        }
    }
}
