using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace BackgroundTasksSample.Services
{
    #region snippet1
    internal interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    internal class ScopedProcessingService(
        ILogger<ScopedProcessingService> logger) : IScopedProcessingService
    {
        private int executionCount = 0;

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                logger.LogInformation(
                    "Scoped Processing Service is working. Count: {Count}", executionCount);

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
    #endregion
}
