using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SampleApp
{
    // Simulates a health check for an hosted service that takes 15 seconds to initialize at app startup.
    //
    // StartupHostedServiceHealthCheck is part of the Liveness Probe Startup sample.

    // <snippet1>
    public class StartupHostedServiceHealthCheck : IHealthCheck
    {
        private volatile bool _startupTaskCompleted = false;

        public string Name => "slow_dependency_check";

        public bool StartupTaskCompleted
        {
            get => _startupTaskCompleted;
            set => _startupTaskCompleted = value;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (StartupTaskCompleted)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("The startup task is finished."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The startup task is still running."));
        }
    }
    // </snippet1>
}
