---
title: ASP.NET Core Blazor WebAssembly Event Pipe performance profiling and diagnostic counters
author: guardrex
description: Learn about Event Pipe performance profiling and diagnostic counters in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/29/2025
uid: blazor/performance/event-pipe-profiling
---
# ASP.NET Core Blazor WebAssembly Event Pipe performance profiling and diagnostic counters

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes Event Pipe performance profiling tools and diagnostic counters for Blazor WebAssembly apps.

## Prerequisite

Install the [.NET WebAssembly build tools](xref:blazor/tooling/webassembly#net-webassembly-build-tools):

```dotnetcli
dotnet workload install wasm-tools
```

## EventPipe profiler

[EventPipe](/dotnet/core/diagnostics/eventpipe) is a runtime component used to collect tracing data, similar to [ETW](/windows/win32/etw/event-tracing-portal) and [perf_events](https://wikipedia.org/wiki/Perf_%28Linux%29).

* Manual testing
  * Browser developer tools: Download the `.nettrace` output file, open the file in Visual Studio, and find the expected method calls.
  * [`dotnet-trace`](/dotnet/core/diagnostics/dotnet-trace): Open the `.nettrace` output file in Visual Studio and find the expected method calls.
* Web-based testing
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected method calls.

Built-in performance counters are available to track:

* [Ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation)
* Code interpolation

## GC (Garbage Collector) dumps

* Manual testing
  * Browser developer tools: Download the `.json` output file, open the file in Visual Studio, and find the expected classes.
  * [`dotnet-gcdump` (`collect`/convert` options)](/dotnet/core/diagnostics/dotnet-gcdump): To view the captured GC dump files, see [View the GC dump captured from dotnet-gcdump](/dotnet/core/diagnostics/dotnet-gcdump#view-the-gc-dump-captured-from-dotnet-gcdump).
* Web-based testing
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected classes.

## Counters trace

* Manual testing
  * Browser developer tools: Download the `.json` output file, open the file in Visual Studio, and find the expected counters.
  * [`dotnet-counters collect`](/dotnet/core/diagnostics/dotnet-counters): Open the `.csv`/`.json` output file in Visual Studio and find the expected counters.
* Web-based testing
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected counters.

## .NET Core Diagnostics Client Library example

Parse and validate NetTrace (`.nettrace`) messages using the .NET Core Diagnostics Client Library:

* [`dotnet/diagnostics` GitHub repository](https://github.com/dotnet/diagnostics)
* [`Microsoft.Diagnostics.NETCore.Client` NuGet package](https://www.nuget.org/packages/Microsoft.Diagnostics.NETCore.Client)

For more information, see the [.NET Core diagnostics documentation](/dotnet/core/diagnostics/) and the [`IpcMessage` API (reference source)](https://github.com/dotnet/diagnostics/blob/main/src/Microsoft.Diagnostics.NETCore.Client/DiagnosticsIpc/IpcMessage.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The following example:

* Collects a GC (Garbage Collector) dump of the live .NET process.
* Collects performance counters for 60 seconds.
* Collects CPU counters for 60 seconds.

The MSBuild properties in the following table enable profiler integration.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<WasmPerfTracing>` | `false` | `true` | Controls diagnostic server tracing.
`<WasmPerfInstrumentation>` | `false` | `true` | Controls CPU sampling instrumentation for diagnostic server. Not necessary for memory dump or counters. **Makes the app execute slower. Only set this to `true` for performance profiling.
`<MetricsSupport>` | `false` | `true` | Controls `System.Diagnostics.Metrics` support. For more information, see the [`System.Diagnostics.Metrics` namespace](/dotnet/api/system.diagnostics.metrics).
`<EventSourceSupport>` | `false`| `true` | Controls `EventPipe` support. For more information, see [Diagnostics and instrumentation: Observability and telemetry](/dotnet/core/deploying/native-aot/diagnostics#observability-and-telemetry).

Enabling profilers has negative size and performance impact, so don't publish an app for production with profilers enabled. In the following example, a condition is set on a property group section that only enables profiling when the app is built with `/p:ProfilingEnabled=true` (.NET CLI) or `<ProfilingEnabled>true</ProfilingEnabled>` in a Visual Studio publish profile.

In the app's project file (`.csproj`):

```xml
<PropertyGroup Condition="'$(ProfilingEnabled)' == 'true'">
  <WasmPerfTracing>true</WasmPerfTracing>
  <WasmPerfInstrumentation>true</WasmPerfInstrumentation>
  <MetricsSupport>true</MetricsSupport>
  <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

The [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

Browser developer tools console calls in the following example that trigger profiling:

* `collectGcDump`: Collect a GC (Garbage Collector) dump.
* `collectPerfCounters(durationSeconds)`: Collect general performance counters.
* `collectCpuSamples(durationSeconds)`: Collect CPU performance counters.

```javascript
globalThis.getDotnetRuntime(0).collectGcDump();
globalThis.getDotnetRuntime(0).collectPerfCounters({durationSeconds: 60});
globalThis.getDotnetRuntime(0).collectCpuSamples({durationSeconds: 60});
```

## Additional resources

* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
