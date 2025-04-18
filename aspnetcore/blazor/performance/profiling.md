---
title: ASP.NET Core Blazor WebAssembly performance profiling and diagnostic counters
author: guardrex
description: Learn about performance profiling and diagnostic counters in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/16/2025
uid: blazor/performance/profiling
---
# ASP.NET Core Blazor WebAssembly performance profiling and diagnostic counters

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes performance profiling tools and diagnostic counters for Blazor WebAssembly apps.

## Prerequisite

Install the [.NET WebAssembly build tools](xref:blazor/tooling/webassembly#net-webassembly-build-tools):

```dotnetcli
dotnet workload install wasm-tools
```

## Browser developer tools

App code can be manually profiled using the performance profiler in a browser's developer tools console.

Built-in performance counters are available to track:

* [Ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation)
* Code interpolation
* [JIT (Just-In-Time) interpolation](https://developer.mozilla.org/docs/Glossary/Just_In_Time_Compilation) 
* Call specification (":::no-loc text="callspec":::", sequence and timing of function calls) and instrumentation

Enable integration with the browser's developer tools profiler using the `<WasmProfilers>` property in the app's project file (`.csproj`). Include the following additional properties:

* `<WasmProfilers>`: The "`browser`" profiler enables integration with the profiler in the browser's developer tools.
* `<RunAOTCompilation>`: Run AOT compilation. Default: `false`
* `<RunAOTCompilationAfterBuild>`: Run AOT compilation after build. By default, it is run only for publish. Default: `false`
* `<WasmNativeStrip>`: Set to `false` to prevent stripping the native executable. Default: `true`
* `<WasmNativeDebugSymbols>`: Build with native debug symbols. Default: `true`
* `<WasmBuildNative>`: Build the native executable. Default: `false`

```xml
<PropertyGroup>
  <WasmProfilers>browser;</WasmProfilers>
  <RunAOTCompilation>true</RunAOTCompilation>
  <RunAOTCompilationAfterBuild>true</RunAOTCompilationAfterBuild>
  <WasmNativeStrip>false</WasmNativeStrip>
  <WasmNativeDebugSymbols>true</WasmNativeDebugSymbols>
  <WasmBuildNative>true</WasmBuildNative>
</PropertyGroup>
```

Add Blazor start configuration in `wwwroot/index.html`, using the [fingerprinted location of the Blazor WebAssembly script](xref:blazor/fundamentals/static-files#fingerprint-client-side-static-assets-in-standalone-blazor-webassembly-apps). In the following example, the `sampleIntervalMs` option is set to 10 seconds, which is the default setting if `sampleIntervalMs` isn't specified:

```html
<script src="_framework/blazor.webassembly#[.{fingerprint}].js" 
    autostart="false"></script>
<script>
  Blazor.start({
    configureRuntime: function (builder) {
      builder.withConfig({
        browserProfilerOptions: {
          sampleIntervalMs: 10,
        }
      });
    }
  });
</script>
```

## Call specification (:::no-loc text="callspec":::)

If you want to filter profiled methods, you can use call specification (:::no-loc text="callspec":::). For more information, see [Trace MonoVM profiler events during startup](https://github.com/dotnet/runtime/blob/main/docs/design/mono/diagnostics-tracing.md#trace-monovm-profiler-events-during-startup).

Add `callspec` to the `browser` WebAssembly profiler in the `<WasmProfilers>` element. In the following example, the `{APP NAMESPACE}` placeholder is the app's namespace:

```xml
<WasmProfilers>browser:callspec=N:{APP NAMESPACE};</WasmProfilers>
```

Configure `callSpec` in `browserProfilerOptions`. Replace the `{APP NAMESPACE}` placeholder in the following example with the app's namespace:

```html
<script src="_framework/blazor.webassembly#[.{fingerprint}].js" 
    autostart="false"></script>
<script>
  Blazor.start({
    configureRuntime: function (builder) {
      builder.withConfig({
        browserProfilerOptions: {
          callSpec: "N:{APP NAMESPACE}",
        }
      });
    }
  });
</script>
```

## Log profiling for memory troubleshooting

Enable integration with the log profiler using the `<WasmProfilers>` and `<WasmBuildNative>` properties in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmProfilers>log;</WasmProfilers>
  <WasmBuildNative>true</WasmBuildNative>
</PropertyGroup>
```

To trigger a heap shot, add the following, where the `{APP NAMESPACE}` placeholder is the app's namespace:

```csharp
namespace {APP NAMESPACE};

public class Profiling
{
    [JSExport]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void TakeHeapshot() { }
}
```

Invoke `TakeHeapshot` to create a memory heap shot and flush the contents of the profile to the file system. Download the resulting `.mpld` file to analyze the data.

## EventPipe profiler

[EventPipe](/dotnet/core/diagnostics/eventpipe) is a runtime component used to collect tracing data, similar to [ETW](/windows/win32/etw/event-tracing-portal) and [perf_events](https://wikipedia.org/wiki/Perf_%28Linux%29).

* Manual testing
  * Browser developer tools: Download the `.json` output file, open the file in Visual Studio, and find expected calls.
  * [`dotnet-trace`](/dotnet/core/diagnostics/dotnet-trace): Open the `.nettrace` output file in Visual Studio and find the expected method calls.
* Web-based testing
  * Use the JavaScript API to obtain a [promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) of NetTrace (`.nettrace`) bytes.
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected method calls.

Built-in performance counters are available to track:

* [Ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation)
* Code interpolation
* JIT (Just-In-Time) interpolation

## GC (Garbage Collector) dumps

* Manual testing
  * Browser developer tools: Download the `.json` output file, open the file in Visual Studio, and find expected calls.
  * [`dotnet-gcdump` (`collect`/convert` options)](/dotnet/core/diagnostics/dotnet-gcdump): To view the captured GC dump files, see [View the GC dump captured from dotnet-gcdump](/dotnet/core/diagnostics/dotnet-gcdump#view-the-gc-dump-captured-from-dotnet-gcdump).
* Web-based testing
  * Use the JavaScript API to obtain a [promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) of NetTrace (`.nettrace`) bytes.
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected classes.

## Counters trace

* Manual testing
  * Browser developer tools: Download the `.json` output file, open the file in Visual Studio, and find expected calls.
  * [`dotnet-counters collect`](/dotnet/core/diagnostics/dotnet-counters): Open the `.csv`/`.json` output file in Visual Studio and find the expected counters/values.
* Web-based testing
  * Use the JavaScript API to obtain a [promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) of NetTrace (`.nettrace`) bytes.
  * Upload the file via HTTP.
  * Parse and validate that the trace contains the expected counters/values.

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

In the project file (`.csproj`), the following properties enable integration with the browser's profiler:

* `<WasmProfilers>`: The "`browser`" profiler enables integration with the profiler in the browser's developer tools.
* `<WasmPerfTracing>`: Enables diagnostic server.
* `<WasmPerfInstrumentation>`: Enables performance instrumentation for the sampling CPU profiler.
* `<MetricsSupport>`: Enables metrics. For more information, see the [`System.Diagnostics.Metrics` namespace](/dotnet/api/system.diagnostics.metrics).
* `<EventSourceSupport>`: Enables system events. For more information, see [Diagnostics and instrumentation: Observability and telemetry](/dotnet/core/deploying/native-aot/diagnostics#observability-and-telemetry).

```xml
<PropertyGroup>
  <WasmProfilers>browser;</WasmProfilers>
  <WasmPerfTracing>true</WasmPerfTracing>
  <WasmPerfInstrumentation>true</WasmPerfInstrumentation>
  <MetricsSupport>true</MetricsSupport>
  <EventSourceSupport>true</EventSourceSupport>
</PropertyGroup>
```

The [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

Browser developer tools console calls in the following example that trigger profiling:

* `collectGcDump`: Collect a GC (Garbage Collector) dump.
* `collectPerfCounters(durationSeconds)`: Collect performance counters.
* `collectCpuSamples(durationSeconds)`: Collect performance counters.

```javascript
globalThis.getDotnetRuntime(0).collectGcDump();
globalThis.getDotnetRuntime(0).collectPerfCounters({durationSeconds: 60});
globalThis.getDotnetRuntime(0).collectCpuSamples({durationSeconds: 60});
```

## Additional resources

* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
