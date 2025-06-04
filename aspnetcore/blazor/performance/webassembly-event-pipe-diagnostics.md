---
title: ASP.NET Core Blazor WebAssembly Event Pipe diagnostics
author: guardrex
description: Learn about Event Pipe diagnostics and how to get a Garbage Collector heap dump in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 05/02/2025
uid: blazor/performance/webassembly-event-pipe
---
# ASP.NET Core Blazor WebAssembly Event Pipe diagnostics

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes diagnostic tools and how to use them in Blazor WebAssembly apps.

## Scenario : I want to understand how my WebAssembly application uses memory and troubleshoot memory leaks

In the app's project file (`.csproj`) add following properties for the duration of the investigation:

```xml
<!-- do not use this in production, it has negative performance impact -->
<PropertyGroup>
  <EnableDiagnostics>true</EnableDiagnostics>
</PropertyGroup>
```

Build your application with `wasm-tools` workload.

Open the application in the browser and walk thru problematic pages or components.

Take managed memory dump by calling `collectGcDump` JavaScript API.

```javascript
globalThis.getDotnetRuntime(0).collectGcDump();
```

This API could be called from browser dev tools console or could be called from JavaScript code of your application.

This will download `.nettrace` file from the browser into local folder.

Convert the dump to `.gcdump` format using `dotnet-gcdump` tool.

To view the converted `.gcdump` file, use Visual Studio or in PrefView.

See also [View the GC dump captured from dotnet-gcdump](/dotnet/core/diagnostics/dotnet-gcdump#view-the-gc-dump-captured-from-dotnet-gcdump) for more info.

## Scenario : I want to understand how my WebAssembly application uses CPU and find slow or hot methods

In the app's project file (`.csproj`) add following properties for the duration of the investigation:

```xml
<!-- do not use this in production, it has negative performance impact -->
<PropertyGroup>
  <EnableDiagnostics>true</EnableDiagnostics>
  <WasmPerformanceInstrumentation>all</WasmPerformanceInstrumentation>
</PropertyGroup>
```

Build your application with `wasm-tools` workload.

Open the application in the browser and navigate to problematic pages or components.

Start colllecting CPU samples for 60 seconds by calling `collectCpuSamples` JavaScript API.

```javascript
globalThis.getDotnetRuntime(0).collectCpuSamples({durationSeconds: 60});
```

This API could be called from browser dev tools console or could be called from JavaScript code of your application.

Start using the application to run problematic code.

After predefined time, browser will download `.nettrace` file into local folder.

To view the `.nettrace` file, use Visual Studio or in PrefView.

See also [Use EventPipe to trace your .NET application](/dotnet/core/diagnostics/eventpipe#use-eventpipe-to-trace-your-net-application).

The [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

## Scenario : I want to observe metrics emmited by my WebAssembly application

In the app's project file (`.csproj`) add following properties for the duration of the investigation:

```xml
<!-- do not use this in production, it has negative performance impact -->
<PropertyGroup>
  <EnableDiagnostics>true</EnableDiagnostics>
  <MetricsSupport>true</MetricsSupport>
  <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

Build your application with `wasm-tools` workload.

Open the application in the browser and navigate to problematic pages or components.

Start colllecting metrics for 60 seconds by calling `collectMetrics` JavaScript API.

```javascript
globalThis.getDotnetRuntime(0).collectMetrics({durationSeconds: 60});
```

This API could be called from browser dev tools console or could be called from JavaScript code of your application.

After predefined time, browser will download `.nettrace` file into local folder.

To view the `.nettrace` file, use Visual Studio or in PrefView.

See also [Use EventPipe to trace your .NET application](/dotnet/core/diagnostics/eventpipe#use-eventpipe-to-trace-your-net-application).

## Prerequisite for all scenarios

Install the [.NET WebAssembly build tools](xref:blazor/tooling/webassembly#net-webassembly-build-tools):

```dotnetcli
dotnet workload install wasm-tools
```

## The MSBuild properties in the following table enable diagnostic integration.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<EnableDiagnostics>` | `false` | `true` | Enables support for WebAssembly performance tracing.
`<WasmPerformanceInstrumentation>` | No value | See table&dagger; | Enables instrumentation necessary for the sampling profiler. The property follows the :::no-loc text="callspec"::: syntax. &dagger;For permissible values, see the following table.
`<MetricsSupport>` | `false` | `true` | Enables `System.Diagnostics.Metrics` support. For more information, see the [`System.Diagnostics.Metrics` namespace](/dotnet/api/system.diagnostics.metrics).
`<EventSourceSupport>` | `false`| `true` | Enables `EventPipe` support. For more information, see [Diagnostics and instrumentation: Observability and telemetry](/dotnet/core/deploying/native-aot/diagnostics#observability-and-telemetry).

The following table describes permissable `<WasmPerformanceInstrumentation>` values.

`<WasmPerformanceInstrumentation>` value | Description
--- | ---
`all` | All assemblies
`program` | Entry point assembly
`{ASSEMBLY}` | Specifies an assembly (`{ASSEMBLY}`)
`M:Type:{METHOD}` | Specifies a method (`{METHOD}`)
`N:{NAMESPACE}` | Specifies a namespace (`{NAMESPACE}`)
`T:{TYPE}` | Specifies a type (`{TYPE}`)
`+EXPR` | Includes expression
`-EXPR` | Excludes expression

Your code should yield to main browser loop often to allow the trace to be collected. When executing long running loops, the internal diagnostic buffers could overflow.

**Enabling profilers and diagnostic tools has negative size and performance impacts, so don't publish an app for production with profilers enabled.**

## Additional resources

* [EventPipe](/dotnet/core/diagnostics/eventpipe) is a runtime component used to collect tracing data, similar to [ETW](/windows/win32/etw/event-tracing-portal) and [perf_events](https://wikipedia.org/wiki/Perf_%28Linux%29).
* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
* [`dotnet/diagnostics` GitHub repository](https://github.com/dotnet/diagnostics)
* [`Microsoft.Diagnostics.NETCore.Client` NuGet package](https://www.nuget.org/packages/Microsoft.Diagnostics.NETCore.Client)
