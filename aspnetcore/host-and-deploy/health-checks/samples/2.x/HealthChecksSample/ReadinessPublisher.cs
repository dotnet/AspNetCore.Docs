using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace SampleApp
{
    #region snippet_ReadinessPublisher
    public class ReadinessPublisher : IHealthCheckPublisher
    {
        private readonly ILogger _logger;

        public ReadinessPublisher(ILogger<ReadinessPublisher> logger)
        {
            _logger = logger;
        }

        public Task PublishAsync(HealthReport report, 
            CancellationToken cancellationToken)
        {
            if (report.Status == HealthStatus.Healthy)
            {
                _logger.LogInformation("{timestamp} Readiness Probe Status: {result}", 
                    DateTime.UtcNow, report.Status);
            }
            else
            {
                _logger.LogError("{timestamp} Readiness Probe Status: {result}", 
                    DateTime.UtcNow, report.Status);
            }

            cancellationToken.ThrowIfCancellationRequested();

            return Task.CompletedTask;
        }
    }
    #endregion
}
