using HealthChecksSample.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthChecksSample.Extensions;

// <snippet_Class>
public static class SampleHealthCheckBuilderExtensions
{
    private const string DefaultName = "Sample";

    public static IHealthChecksBuilder AddSampleHealthCheck(
        this IHealthChecksBuilder healthChecksBuilder,
        int arg1,
        string arg2,
        string? name = null,
        HealthStatus? failureStatus = null,
        IEnumerable<string>? tags = default)
    {
        return healthChecksBuilder.Add(
            new HealthCheckRegistration(
                name ?? DefaultName,
                _ => new SampleHealthCheckWithArgs(arg1, arg2),
                failureStatus,
                tags));
    }
}
// </snippet_Class>
