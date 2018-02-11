using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    internal class ScopedHostedService : IHostedService
    {
        public ScopedHostedService(IServiceProvider services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceProvider Services { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.UtcNow} - Scoped Hosted Service is starting.");

            using (var scope = Services.CreateScope())
            {
                var scopedProcessingService = 
                    scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                scopedProcessingService.DoWork();
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"{DateTime.UtcNow} - Scoped Hosted Service is stopping.");

            return Task.CompletedTask;
        }
    }
    #endregion
}
