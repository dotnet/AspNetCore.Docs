---
title: ASP.NET Core Blazor WebAssembly browser developer tools diagnostics
author: guardrex
description: Learn about browser developer tools diagnostics in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/02/2025
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

Built-in diagnostic features are available to track:

* [Ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly#ahead-of-time-aot-compilation)
* Call specification (":::no-loc text="callspec":::", sequence and timing of function calls) and instrumentation

The MSBuild properties in the following table enable profiler integration.

Property | Default | Set value to&hellip; | Description
--- | :---: | :---: | ---
`<WasmProfilers>` | No value | `browser` | Mono profilers to use. Potential values are "`browser`" and "`log`". To use both, separate the values with a semicolon. The `browser` profiler enables integration with the browser's developer tools profiler.
`<WasmNativeStrip>` | `true` | `false` | Controls stripping the native executable.
`<WasmNativeDebugSymbols>` | `true` | `true` | Controls building with native debug symbols.

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

Setting WebAssembly profilers with `<WasmProfilers>browser;</WasmProfilers>` doesn't require AOT.

The browser developer tools profiler can be used with AOT (`<RunAOTCompilation>`/`<RunAOTCompilationAfterBuild>` set to `true`) and without WebAssembly profilers (`<WasmProfilers>browser;</WasmProfilers>` removed from the preceding property group).

To see AOT method names in the developer tools console, install [DWARF chrome extension](https://chromewebstore.google.com/detail/cc++-devtools-support-dwa/pdcpmagijalfljmkmjngeonclgbbannb).

## Set the sample interval

Configure the sample interval in the app's project file. In the following example, the `{INTERVAL}` placeholder represents the time in milliseconds. The default setting if `sampleIntervalMs` isn't specified is 10 ms.

```xml
<PropertyGroup>
  <WasmProfilers>browser:interval={INTERVAL};</WasmProfilers>
</PropertyGroup>
```

## Call specification (:::no-loc text="callspec":::)

If you want to filter profiled methods, you can use call specification (:::no-loc text="callspec":::). For more information, see [Trace MonoVM profiler events during startup](https://github.com/dotnet/runtime/blob/main/docs/design/mono/diagnostics-tracing.md#trace-monovm-profiler-events-during-startup).

Add `callspec` to the `browser` WebAssembly profiler in the `<WasmProfilers>` element. In the following example, the `{APP NAMESPACE}` placeholder is the app's namespace:

```xml
<WasmProfilers>browser:callspec=N:{APP NAMESPACE};</WasmProfilers>
```

## .NET Core Diagnostics Client Library example

In the project file (`.csproj`), use the `<WasmProfilers>` property set to `browser` to enable integration with the Mono profiler. Currently, only "`browser`" is supported. The `browser` profiler enables integration with the browser's developer tools profiler.

```xml
<PropertyGroup>
  <WasmProfilers>browser</WasmProfilers>
</PropertyGroup>
```

The [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

## Additional resources

* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
