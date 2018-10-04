using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SampleApp
{
    // Simulates a health check for an app dependency that takes 15 seconds to initialize.
    //
    // SlowDependencyHealthCheck is part of the Liveness Probe Startup sample.

    #region snippet1
    public class SlowDependencyHealthCheck : IHealthCheck
    {
        private readonly Task _task;

        public SlowDependencyHealthCheck()
        {
            _task = Task.Delay(15 * 1000);
        }

        public string Name => "slow_dependency_check";

        public Task<HealthCheckResult> CheckHealthAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_task.IsCompleted)
            {
                return Task.FromResult(
                    HealthCheckResult.Healthy("The dependency is ready."));
            }

            return Task.FromResult(
                HealthCheckResult.Unhealthy("The dependency is still initializing."));
        }
    }
    #endregion
}
