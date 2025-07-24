using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksSample.HealthCheckPublishers;

// <snippet_Class>
public class SampleHealthCheckPublisher : IHealthCheckPublisher
{
    public Task PublishAsync(HealthReport report, CancellationToken cancellationToken)
    {
        if (report.Status == HealthStatus.Healthy)
        {
            // ...
        }
        else
        {
            // ...
        }

        return Task.CompletedTask;
    }
}
// </snippet_Class>
