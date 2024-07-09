### Improved Activities for SignalR

SignalR now has an ActivitySource named "Microsoft.AspNetCore.SignalR.Server" that emits events for hub method calls. Additionally, every method is its own activity so anything that emits an activity during the hub method call will be under the hub method activity, and all the hub method activities do not have a parent so will not be bundled under the long running SignalR connection.

The following image was made using the Aspire dashboard and the OpenTelemetry packages:

```xml
<PackageReference Include="OpenTelemetry.Exporter.OpenTelemetryProtocol" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Extensions.Hosting" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Instrumentation.AspNetCore" Version="1.9.0" />
```

as well as the following code in startup:

```csharp
// Set OTEL_EXPORTER_OTLP_ENDPOINT environment variable depending on where your OTEL endpoint is
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        if (builder.Environment.IsDevelopment())
        {
            // We want to view all traces in development
            tracing.SetSampler(new AlwaysOnSampler());
        }

        tracing.AddAspNetCoreInstrumentation();
        tracing.AddSource("Microsoft.AspNetCore.SignalR.Server");
    });

builder.Services.ConfigureOpenTelemetryTracerProvider(tracing => tracing.AddOtlpExporter());
```

:::image type="content" source="~/release-notes/aspnetcore-9/_static/signalr-activites-events.png" alt-text="Activity list for SignalR Hub method call events":::
