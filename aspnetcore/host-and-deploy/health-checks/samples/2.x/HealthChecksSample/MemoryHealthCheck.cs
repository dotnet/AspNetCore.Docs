using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SampleApp
{
    // This is an example of a custom health check that implements IHealthCheck. See CustomWriterStartup to see how this health check is registered.
    //
    // This example reports degraded status if the application is using more than 1 GB of memory.

    #region snippet1
    public class MemoryHealthCheck : IHealthCheck
    {
        public string Name => "memory_check";

        public Task<HealthCheckResult> CheckHealthAsync(
            CancellationToken cancellationToken = default(CancellationToken))
        {
            // Include GC information in the reported diagnostics.
            var allocated = GC.GetTotalMemory(forceFullCollection: false);
            var data = new Dictionary<string, object>()
            {
                { "AllocatedBytes", allocated },
                { "Gen0Collections", GC.CollectionCount(0) },
                { "Gen1Collections", GC.CollectionCount(1) },
                { "Gen2Collections", GC.CollectionCount(2) },
            };

            // Report degraded status if the allocated memory is >= 1 GB (in bytes).
            var status = allocated >= 1024 * 1024 * 1024 ? 
                HealthCheckStatus.Degraded : HealthCheckStatus.Healthy;

            return Task.FromResult(new HealthCheckResult(
                status,
                exception: null,
                description: "Reports degraded status if allocated bytes " +
                    ">= 1 GB (1,073,741,824 bytes).",
                data: data));
        }
    }
    #endregion
}
