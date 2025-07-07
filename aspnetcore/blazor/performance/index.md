---
title: ASP.NET Core Blazor performance best practices
author: guardrex
description: Guidance on ASP.NET Core Blazor metrics and tracing, improving app performance, and avoiding common performance problems.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 07/07/2025
uid: blazor/performance/index
---
# ASP.NET Core Blazor performance best practices

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor is optimized for high performance in most realistic application UI scenarios. However, the best performance depends on developers adopting the correct patterns and features.

> [!NOTE]
> The code examples in this node of articles adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core in .NET 6 or later.

:::moniker range=">= aspnetcore-6.0"

## Ahead-of-time (AOT) compilation

Ahead-of-time (AOT) compilation compiles a Blazor app's .NET code directly into native WebAssembly for direct execution by the browser. AOT-compiled apps result in larger apps that take longer to download, but AOT-compiled apps usually provide better runtime performance, especially for apps that execute CPU-intensive tasks. For more information, see <xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation>.

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

## Metrics and tracing

Metrics and tracing capabilities help you monitor and diagnose app performance, track user interactions, and understand component behavior in production environments.

### Configuration

To enable Blazor metrics and tracing in your app, configure [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) with the following meters and activity sources in the app's `Program` file where services are registered:

```csharp
builder.Services.ConfigureOpenTelemetryMeterProvider(meterProvider =>
{
    meterProvider.AddMeter("Microsoft.AspNetCore.Components");
    meterProvider.AddMeter("Microsoft.AspNetCore.Components.Lifecycle");
    meterProvider.AddMeter("Microsoft.AspNetCore.Components.Server.Circuits");
});

builder.Services.ConfigureOpenTelemetryTracerProvider(tracerProvider =>
{
    tracerProvider.AddSource("Microsoft.AspNetCore.Components");
    tracerProvider.AddSource("Microsoft.AspNetCore.Components.Server.Circuits");
});
```

### Performance meters

For more information on the following performance meters, see <xref:log-mon/metrics/built-in>.

`Microsoft.AspNetCore.Components` meter:

* `aspnetcore.components.navigation`: Tracks the total number of route changes in the app.
* `aspnetcore.components.event_handler`: Measures the duration of processing browser events, including business logic.

`Microsoft.AspNetCore.Components.Lifecycle` meter:

* `aspnetcore.components.update_parameters`: Measures the duration of processing component parameters, including business logic.
* `aspnetcore.components.render_diff`: Tracks the duration of rendering batches.

`Microsoft.AspNetCore.Components.Server.Circuits` meter:

In server-side Blazor apps, additional circuit-specific metrics include:

* `aspnetcore.components.circuit.active`: Shows the number of active circuits currently in memory.
* `aspnetcore.components.circuit.connected`: Tracks the number of circuits connected to clients.
* `aspnetcore.components.circuit.duration`: Measures circuit lifetime duration and provides total circuit count.

### Blazor tracing

For more information on the following tracing activities, see <xref:log-mon/metrics/built-in>.

The new activity tracing capabilities use the `Microsoft.AspNetCore.Components` activity source and provide three main types of tracing activities: circuit lifecycle, navigation, and event handling.

Circuit lifecycle tracing:

`Microsoft.AspNetCore.Components.CircuitStart`: Traces circuit initialization with the format `Circuit {circuitId}`.

Tags:

* `aspnetcore.components.circuit.id`: Class name of the Razor component.
* `error.type`: Exception type full name (optional)

Links:

* HTTP trace
* SignalR trace

Usage: Links other Blazor traces of the same session/circuit to HTTP and SignalR contexts.

Navigation tracing:

`Microsoft.AspNetCore.Components.RouteChange`: Tracks route changes with the format `Route {route} -> {componentType}`.

Tags:

* `aspnetcore.components.route`: URL path pattern of the page.
* `aspnetcore.components.type`: Class name of the Razor component.
* `error.type`: Exception type full name (optional).

Links:

* HTTP trace
* SignalR trace
* Circuit trace

Usage: Which Blazor pages this session visited?

Event handling tracing:

`Microsoft.AspNetCore.Components.HandleEvent`: Traces event handling with the format `Event {attributeName} -> {componentType}.{methodName}`.

Tags:

* `aspnetcore.components.attribute.name`: Name of the HTML attribute that triggers the event (example: `onClick`).
* `aspnetcore.components.method`: C# method name of the handler.
* `aspnetcore.components.type`: Full name of target C# component that receives the event.
* `error.type`: Exception type full name (optional).

Links:

* HTTP trace
* SignalR trace
* Circuit trace
* Route trace

Usages:

* Click to which component caused exception and on which page?
* In which linked circuit and with what HTTP context it happened?

:::moniker-end
