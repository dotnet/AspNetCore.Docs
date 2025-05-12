---
title: ASP.NET Core Blazor WebAssembly Event Pipe diagnostics
author: guardrex
description: Learn about Event Pipe diagnostics and how to get a Garbage Collector heap dump in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/02/2025
uid: blazor/performance/webassembly-event-pipe
---
# ASP.NET Core Blazor WebAssembly Event Pipe diagnostics

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes Event Pipe diagnostic tools, counters, and how to get a Garbage Collector heap dump in Blazor WebAssembly apps.

## Prerequisite

Install the [.NET WebAssembly build tools](xref:blazor/tooling/webassembly#net-webassembly-build-tools):

```dotnetcli
dotnet workload install wasm-tools
```

## .NET Core Diagnostics Client Library example

Parse and validate NetTrace (`.nettrace`) messages using the .NET Core Diagnostics Client Library:

* [`dotnet/diagnostics` GitHub repository](https://github.com/dotnet/diagnostics)
* [`Microsoft.Diagnostics.NETCore.Client` NuGet package](https://www.nuget.org/packages/Microsoft.Diagnostics.NETCore.Client)

For more information, see the [.NET Core diagnostics documentation](/dotnet/core/diagnostics/) and the [`IpcMessage` API (reference source)](https://github.com/dotnet/diagnostics/blob/main/src/Microsoft.Diagnostics.NETCore.Client/DiagnosticsIpc/IpcMessage.cs).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

The MSBuild properties in the following table enable profiler integration.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<WasmPerfTracing>` | `false` | `true` | Enables diagnostic server.
`<WasmPerfInstrumentation>` | `false` | `true` | Enables instrumentation necessary for sampling profiler.
`<MetricsSupport>` | `false` | `true` | Controls `System.Diagnostics.Metrics` support. For more information, see the [`System.Diagnostics.Metrics` namespace](/dotnet/api/system.diagnostics.metrics).
`<EventSourceSupport>` | `false`| `true` | Controls `EventPipe` support. For more information, see [Diagnostics and instrumentation: Observability and telemetry](/dotnet/core/deploying/native-aot/diagnostics#observability-and-telemetry).

Enabling profilers has negative size and performance impact, so don't publish an app for production with profilers enabled. In the following example, a condition is set on a property group section that only enables profiling when the app is built with `/p:BlazorSampleProfilingEnabled=true` (.NET CLI) or `<BlazorSampleProfilingEnabled>true</BlazorSampleProfilingEnabled>` in a Visual Studio publish profile, where "`BlazorSampleProfilingEnabled`" is a custom symbol name that you choose and doesn't conflict with other symbol names.

In the app's project file (`.csproj`):

```xml
<PropertyGroup Condition="'$(BlazorSampleProfilingEnabled)' == 'true'">
  <WasmPerfTracing>true</WasmPerfTracing>
  <MetricsSupport>true</MetricsSupport>
  <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

Alternatively, enable features when the app is built with the .NET CLI. The following options passed to the `dotnet build` command mirror the preceding MS Build property configuration:

```dotnetcli
/p:WasmPerfTracing=true /p:WasmPerfInstrumentation=all /p:MetricsSupport=true /p:EventSourceSupport=true
```

The [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

## EventPipe profiler

[EventPipe](/dotnet/core/diagnostics/eventpipe) is a runtime component used to collect tracing data, similar to [ETW](/windows/win32/etw/event-tracing-portal) and [perf_events](https://wikipedia.org/wiki/Perf_%28Linux%29).

Use the `<WasmPerfInstrumentation>` property to enable CPU sampling instrumentation for diagnostic server. This setting isn't necessary for memory dump or counters. **Makes the app execute slower. Only enable this for performance profiling.**

Enabling profilers has negative size and performance impact, so don't publish an app for production with profilers enabled. In the following example, a condition is set on a property group section that only enables profiling when the app is built with `/p:BlazorSampleProfilingEnabled=true` (.NET CLI) or `<BlazorSampleProfilingEnabled>true</BlazorSampleProfilingEnabled>` in a Visual Studio publish profile, where "`BlazorSampleProfilingEnabled`" is a custom symbol name that you choose and doesn't conflict with other symbol names.

```xml
<PropertyGroup Condition="'$(BlazorSampleProfilingEnabled)' == 'true'">
  <WasmPerfInstrumentation>all</WasmPerfInstrumentation>
</PropertyGroup>
```

Collect CPU counters for 60 seconds with `collectCpuSamples(durationSeconds)`:

```javascript
globalThis.getDotnetRuntime(0).collectCpuSamples({durationSeconds: 60});
```

To view the trace, see [Use EventPipe to trace your .NET application](/dotnet/core/diagnostics/eventpipe#use-eventpipe-to-trace-your-net-application).

## GC (Garbage Collector) dumps

The [`dotnet-gcdump` (`collect`/convert` options)](/dotnet/core/diagnostics/dotnet-gcdump) global tool collects GC (Garbage Collector) dumps of live .NET processes using [EventPipe](/dotnet/core/diagnostics/eventpipe).

Collect a GC (Garbage Collector) dump of the live .NET process with `collectGcDump`:

```javascript
globalThis.getDotnetRuntime(0).collectGcDump();
```

To view the captured GC dump, see [View the GC dump captured from dotnet-gcdump](/dotnet/core/diagnostics/dotnet-gcdump#view-the-gc-dump-captured-from-dotnet-gcdump).

## Counters trace

[`dotnet-counters collect`](/dotnet/core/diagnostics/dotnet-counters) is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation.

Collect diagnostic counters for 60 seconds with `collectPerfCounters(durationSeconds)`:

```javascript
globalThis.getDotnetRuntime(0).collectPerfCounters({durationSeconds: 60});
```

To view the trace, see [Use EventPipe to trace your .NET application](/dotnet/core/diagnostics/eventpipe#use-eventpipe-to-trace-your-net-application).

## Additional resources

* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
