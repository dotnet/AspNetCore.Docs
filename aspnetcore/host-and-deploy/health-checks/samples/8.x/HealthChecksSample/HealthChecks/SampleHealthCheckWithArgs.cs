using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksSample.HealthChecks;

// <snippet_Class>
public class SampleHealthCheckWithArgs : IHealthCheck
{
    private readonly int _arg1;
    private readonly string _arg2;

    // <snippet_ctor>
    public SampleHealthCheckWithArgs(int arg1, string arg2)
        => (_arg1, _arg2) = (arg1, arg2);
    // </snippet_ctor>

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // ...

        return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
    }
}
// </snippet_Class>
