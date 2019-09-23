using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    public class QueuedHostedService : BackgroundService
    {
        private CancellationTokenSource _shutdown = 
            new CancellationTokenSource();
        private Task _backgroundTask;
        private readonly ILogger<QueuedHostedService> _logger;

        public QueuedHostedService(IBackgroundTaskQueue taskQueue, 
            ILogger<QueuedHostedService> logger)
        {
            TaskQueue = taskQueue;
            _logger = logger;
        }

        public IBackgroundTaskQueue TaskQueue { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                $"Queued Hosted Service is running.{Environment.NewLine}" +
                $"{Environment.NewLine}Tap W to add a work item to the " +
                $"background queue.{Environment.NewLine}");

            _backgroundTask = Task.Run(async () =>
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        await BackgroundProcessing();
                    }
                }, stoppingToken);

            await _backgroundTask;
        }

        private async Task BackgroundProcessing()
        {
            while (!_shutdown.IsCancellationRequested)
            {
                var workItem = 
                    await TaskQueue.DequeueAsync(_shutdown.Token);

                try
                {
                    await workItem(_shutdown.Token);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, 
                        $"Error occurred executing {nameof(workItem)}.");
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Queued Hosted Service is stopping.");

            _shutdown.Cancel();

            await Task.WhenAny(_backgroundTask, 
                    Task.Delay(Timeout.Infinite, stoppingToken));
        }
    }
    #endregion
}
