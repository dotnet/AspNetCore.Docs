using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample.Services
{
    #region snippet_Monitor
    public class MonitorLoop
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly ILogger _logger;
        private readonly CancellationToken _cancellationToken;

        public MonitorLoop(IBackgroundTaskQueue taskQueue, 
            ILogger<MonitorLoop> logger, 
            IHostApplicationLifetime applicationLifetime)
        {
            _taskQueue = taskQueue;
            _logger = logger;
            _cancellationToken = applicationLifetime.ApplicationStopping;
        }

        public void StartMonitorLoop()
        {
            _logger.LogInformation("Monitor Loop is starting.");

            // Run a console user input loop in a background thread
            Task.Run(() => Monitor());
        }

        public void Monitor()
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                var keyStroke = Console.ReadKey();

                if (keyStroke.Key == ConsoleKey.W)
                {
                    // Enqueue a background work item
                    _taskQueue.QueueBackgroundWorkItem(async token =>
                    {
                        var guid = Guid.NewGuid().ToString();

                        for (int delayLoop = 0; delayLoop < 3; delayLoop++)
                        {
                            _logger.LogInformation(
                                "Queued Background Task {Guid} is running. {DelayLoop}/3", guid, delayLoop);
                            await Task.Delay(TimeSpan.FromSeconds(5), token);
                        }

                        _logger.LogInformation(
                            "Queued Background Task {Guid} is complete. 3/3", guid);
                    });
                }
            }
        }
    }
    #endregion
}
