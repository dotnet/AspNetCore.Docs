### Improved Activities for SignalR

SignalR now has an ActivitySource named `Microsoft.AspNetCore.SignalR.Server` that emits events for hub method calls:

* Every method is its own activity, so anything that emits an activity during the hub method call is under the hub method activity.
* Hub method activities don't have a parent. This means they are not bundled under the long-running SignalR connection.

The following example uses the [.NET Aspire dashboard](/dotnet/aspire/fundamentals/dashboard/overview?tabs=bash#using-the-dashboard-with-net-aspire-projects) and the [OpenTelemetry](https://www.nuget.org/packages/OpenTelemetry.Extensions.Hosting) packages:

```xml
<PackageReference Include="OpenTelemetry.Exporter.OpenTelemetryProtocol" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Extensions.Hosting" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Instrumentation.AspNetCore" Version="1.9.0" />
```

Add the following startup code to the `Program.cs` file:

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

The following is example output from the Aspire Dashboard:

:::image type="content" source="~/release-notes/aspnetcore-9/_static/signalr-activites-events.png" alt-text="Activity list for SignalR Hub method call events":::
