
# Distributed tracing

As an ASP.NET Core component, YARP can easily integrate into different tracing systems the same as any other ASP.NET Core application.

.NET has built-in configurable support for distributed tracing that YARP takes advantage of to enable such scenarios out-of-the-box.

## Using Open Telemetry

YARP supports distributed tracing using Open Telemetry (OTEL). When a request comes in, and there is a listener for Activities, then ASP.NET Core will propagate the [Trace Context](https://www.w3.org/TR/trace-context) trace-id, or create one if necessary, and create new spans/activities for the work performed.
In addition YARP can create activities for:

- Forwarding Requests
- Active health checks for clusters

These will only be created if there is a listener for the [`ActivitySource`](https://learn.microsoft.com/dotnet/core/diagnostics/distributed-tracing-instrumentation-walkthroughs#activitysource) named `Yarp.ReverseProxy`.

### Example: Application Insights

For example, to monitor the traces with Application Insights, the proxy application needs to use the [Open Telemetry](https://github.com/open-telemetry/opentelemetry-dotnet/blob/main/src/OpenTelemetry/README.md) and [Azure Monitor](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/README.md) SDKs.

`application.csproj`:

``` xml
<ItemGroup>
  <PackageReference Include="Azure.Monitor.OpenTelemetry.AspNetCore" Version="1.0.0-beta.3" />
</ItemGroup>
```

`Program.cs`:

``` c#
using Azure.Monitor.OpenTelemetry.AspNetCore;
using OpenTelemetry.Trace;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddOpenTelemetry()
    // Use helper to configure Azure Monitor defaults
    .UseAzureMonitor(o =>
    {
        o.ConnectionString = builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
    })
    .WithTracing(t =>
    {
        // Listen to the YARP tracing activities
        t.AddSource("Yarp.ReverseProxy");
    });

var app = builder.Build();

app.MapReverseProxy();

app.Run();

```

### Example: OpenTelemetry hosting

``` xml
  <ItemGroup>
    <PackageReference Include="OpenTelemetry.Exporter.Console" Version="1.7.0" />
    <PackageReference Include="OpenTelemetry.Exporter.OpenTelemetryProtocol" Version="1.7.0" />
    <PackageReference Include="OpenTelemetry.Extensions.Hosting" Version="1.7.0" />
    <PackageReference Include="OpenTelemetry.Instrumentation.AspNetCore" Version="1.7.0" />
    <PackageReference Include="OpenTelemetry.Instrumentation.Http" Version="1.7.0" />
    <PackageReference Include="OpenTelemetry.Instrumentation.Runtime" Version="1.7.0" />
  </ItemGroup>
```

``` csharp
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// configure OTel and OTLP
const string serviceName = "yarpProxy";

builder.Logging.AddOpenTelemetry(options =>
{
    options
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName))
        .AddOtlpExporter();
});

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(serviceName))
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddSource("Yarp.ReverseProxy") 
        .AddOtlpExporter()
    );

// build and start app
var app = builder.Build();
app.MapReverseProxy();
app.Run();
```

Note that the `AddHttpClientInstrumentation()` call is required along with the `AddSource("Yarp.ReverseProxy")` call to make the request spans emit.

See [ASP.NET Documentation on Observability with OpenTelemetry](https://learn.microsoft.com/dotnet/core/diagnostics/observability-with-otel).


Provided that the traces are being logged to the same store for the proxy and destination servers, then the tracing analysis tools can correlate the requests and provide gant charts etc covering the end-to-end processing of the requests as they transition across the servers.

The same pattern can be used with the built-in OTEL exporters for Jaeger and Zipkin, or with many of the [APM vendors](https://opentelemetry.io/ecosystem/vendors/) who are adopting OTEL.

## Using custom tracing headers

When using a propagation mechanism that is not built into .NET (e.g. [B3 propagation]), you should implement a custom [`DistributedContextPropagator`] for that scheme.

YARP will remove any header in [`DistributedContextPropagator.Fields`] so that the propagator may re-add them to the request during the `Inject` call.

## Pass-through proxy

If you do not wish the proxy to actively participate in the trace, and wish to keep all the tracing headers as-is, you may do so by setting `SocketsHttpHandler.ActivityHeadersPropagator` to `null`.

```c#
services.AddReverseProxy()
    .ConfigureHttpClient((context, handler) => handler.ActivityHeadersPropagator = null);
```

[B3 propagation]: https://github.com/openzipkin/b3-propagation
[`DistributedContextPropagator`]: https://docs.microsoft.com/dotnet/api/system.diagnostics.distributedcontextpropagator
[`DistributedContextPropagator.Fields`]: https://docs.microsoft.com/dotnet/api/system.diagnostics.distributedcontextpropagator.fields
