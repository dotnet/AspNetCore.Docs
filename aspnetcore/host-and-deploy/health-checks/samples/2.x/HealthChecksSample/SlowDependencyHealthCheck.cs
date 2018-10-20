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
        private readonly int _delaySeconds = 15;
        private readonly Task _task;

        public SlowDependencyHealthCheck()
        {
            _task = Task.Delay(_delaySeconds * 1000);
        }

        public string Name => "slow_dependency_check";

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_task.IsCompleted)
            {
                return Task.FromResult(
                    HealthCheckResult.Passed("The dependency is ready."));
            }

            return Task.FromResult(
                HealthCheckResult.Failed("The dependency is still initializing."));
        }
    }
    #endregion
}
