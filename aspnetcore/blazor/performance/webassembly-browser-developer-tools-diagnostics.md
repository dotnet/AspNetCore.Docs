---
title: ASP.NET Core Blazor WebAssembly browser developer tools diagnostics
author: guardrex
description: Learn about browser developer tools diagnostics in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/30/2025
uid: blazor/performance/webassembly-browser-developer-tools
---
# ASP.NET Core Blazor WebAssembly browser developer tools diagnostics

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article describes browser developer tools diagnostic tools in Blazor WebAssembly apps.

## Prerequisite

Install the [.NET WebAssembly build tools](xref:blazor/tooling/webassembly#net-webassembly-build-tools):

```dotnetcli
dotnet workload install wasm-tools
```

## Browser developer tools

App code can be manually profiled using the diagnostic profiler in a browser's developer tools console.

Built-in diagnostic counters are available to track:

* [Ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation)
* Code interpolation
* Call specification (":::no-loc text="callspec":::", sequence and timing of function calls) and instrumentation

The MSBuild properties in the following table enable profiler integration.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<WasmProfilers>` | No value | `browser` | Mono profilers to use. Potential values are "`browser`" and "`log`". To use both, separate the values with a semicolon. The `browser` profiler enables integration with the browser's developer tools profiler.
`<RunAOTCompilation>`| `false` | `true` | Controls AOT compilation.
`<RunAOTCompilationAfterBuild>` | `false` | `true` | Controls AOT compilation after build. By default, it's run only for publish.
`<WasmNativeStrip>` | `true` | `false` | Controls stripping the native executable.
`<WasmNativeDebugSymbols>` | `true` | `true` | Controls building with native debug symbols.
`<WasmBuildNative>` | `false` | `true` | Controls building the native executable.

Enabling profilers has negative size and performance impact, so don't publish an app for production with profilers enabled. In the following example, a condition is set on a property group section that only enables profiling when the app is built with `/p:BlazorSampleProfilingEnabled=true` (.NET CLI) or `<BlazorSampleProfilingEnabled>true</BlazorSampleProfilingEnabled>` in a Visual Studio publish profile, where "`BlazorSampleProfilingEnabled`" is a custom symbol name that you choose and doesn't conflict with other symbol names.

In the app's project file (`.csproj`):

```xml
<PropertyGroup Condition="'$(BlazorSampleProfilingEnabled)' == 'true'">
  <WasmProfilers>browser;</WasmProfilers>
  <WasmNativeStrip>false</WasmNativeStrip>
  <WasmNativeDebugSymbols>true</WasmNativeDebugSymbols>
</PropertyGroup>
```

Alternatively, enable features when the app is built with the .NET CLI. The following options passed to the `dotnet build` command mirror the preceding MS Build property configuration:

```dotnetcli
/p:WasmProfilers=browser /p:WasmNativeStrip=false /p:WasmNativeDebugSymbols=true
```

Setting WebAssembly profilers with `<WasmProfilers>browser;</WasmProfilers>` doesn't require AOT (`<RunAOTCompilation>`/`<RunAOTCompilationAfterBuild>` set to `false` or removed from the preceding property group).

The browser developer tools profiler can be used with AOT (`<RunAOTCompilation>`/`<RunAOTCompilationAfterBuild>` set to `true`) and without WebAssembly profilers (`<WasmProfilers>browser;</WasmProfilers>` removed from the preceding property group).

To see AOT method names in the developer tools console, install [DWARF chrome extension](https://chromewebstore.google.com/detail/cc++-devtools-support-dwa/pdcpmagijalfljmkmjngeonclgbbannb).

## Set the sample interval

Configure the sample interval in the app's project file. In the following example, the `{INTERVAL}` placeholder represents the time in milliseconds. The default setting if `sampleIntervalMs` isn't specified is 10 ms.

```xml
<PropertyGroup>
  <WasmProfilers>browser:sampleIntervalMs={INTERVAL};</WasmProfilers>
</PropertyGroup>
```

Alternatively, add the following Blazor start configuration in `wwwroot/index.html` and add `autostart="false"` to the Blazor `<script>` tag. The `{INTERVAL}` placeholder represents the time in milliseconds:

```html
<script src="_framework/blazor.webassembly#[.{fingerprint}].js" 
    autostart="false"></script>
<script>
  Blazor.start({
    configureRuntime: function (builder) {
      builder.withConfig({
        browserProfilerOptions: {
          sampleIntervalMs: {INTERVAL},
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

Alternatively, configure `callSpec` in `browserProfilerOptions`. Replace the `{APP NAMESPACE}` placeholder in the following example with the app's namespace:

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

In the project file (`.csproj`), the properties in the following table enable integration with the browser's profiler.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<WasmProfilers>` | No value | `browser` | Mono profilers to use. Potential values are "`browser`" and "`log`". To use both, separate the values with a semicolon. The `browser` profiler enables integration with the browser's developer tools profiler.
`<WasmPerfTracing>` | `false` | `true` | Controls diagnostic server tracing.
`<WasmPerfInstrumentation>` | `false` | `true` | Controls CPU sampling instrumentation for diagnostic server.
`<MetricsSupport>` | `false` | `true` | Controls `System.Diagnostics.Metrics` support. For more information, see the [`System.Diagnostics.Metrics` namespace](/dotnet/api/system.diagnostics.metrics).
`<EventSourceSupport>` | `false`| `true` | Controls `EventPipe` support. For more information, see [Diagnostics and instrumentation: Observability and telemetry](/dotnet/core/deploying/native-aot/diagnostics#observability-and-telemetry).

```xml
<PropertyGroup>
  <WasmProfilers>browser</WasmProfilers>
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
