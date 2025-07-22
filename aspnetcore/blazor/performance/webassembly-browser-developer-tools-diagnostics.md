---
title: ASP.NET Core Blazor WebAssembly browser developer tools diagnostics
author: guardrex
description: Learn about browser developer tools diagnostics in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 05/13/2025
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
`<WasmNativeStrip>` | `true` | `false` | Enables stripping the native executable.
`<WasmNativeDebugSymbols>` | `true` | `true` | Enables building with native debug symbols.

Setting the [`Timing-Allow-Origin` HTTP header](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Timing-Allow-Origin) allows for more precise time measurements.

Enabling profilers has negative size and performance impacts, so don't publish an app for production with profilers enabled. In the following example, a condition is set on a property group section that only enables profiling when the app is built with `/p:BlazorSampleProfilingEnabled=true` (.NET CLI) or `<BlazorSampleProfilingEnabled>true</BlazorSampleProfilingEnabled>` in a Visual Studio publish profile, where "`BlazorSampleProfilingEnabled`" is a custom symbol name that you choose and doesn't conflict with other symbol names.

In the app's project file (`.csproj`):

```xml
<PropertyGroup Condition="'$(BlazorSampleProfilingEnabled)' == 'true'">
  <WasmProfilers>browser;</WasmProfilers>
  <WasmNativeStrip>false</WasmNativeStrip>
  <WasmNativeDebugSymbols>true</WasmNativeDebugSymbols>
  <!-- disable debugger -->
  <WasmDebugLevel>0</WasmDebugLevel>
</PropertyGroup>
```

Alternatively, enable features when the app is built with the .NET CLI. The following options passed to the `dotnet build` command mirror the preceding MSBuild property configuration:

```dotnetcli
/p:WasmProfilers=browser /p:WasmNativeStrip=false /p:WasmNativeDebugSymbols=true
```

Setting WebAssembly profilers with `<WasmProfilers>` doesn't require [ahead-of-time (AOT) compilation](xref:blazor/tooling/webassembly).

The browser developer tools profiler can be used with AOT (`<RunAOTCompilation>`/`<RunAOTCompilationAfterBuild>` set to `true`) and without WebAssembly profilers (`<WasmProfilers>` removed).

To see AOT method names in the developer tools console, install [DWARF chrome extension](https://chromewebstore.google.com/detail/cc++-devtools-support-dwa/pdcpmagijalfljmkmjngeonclgbbannb).

## Set the sample interval

Configure the sample interval in the app's project file. In the following example, the `{INTERVAL}` placeholder represents the time in milliseconds. The default setting if `sampleIntervalMs` isn't specified is 10 ms.

```xml
<PropertyGroup>
  <WasmProfilers>browser:interval={INTERVAL};</WasmProfilers>
</PropertyGroup>
```

## Call specification (:::no-loc text="callspec":::)

If you want to filter profiled methods, use call specification (:::no-loc text="callspec":::).

Add `callspec` with a filter to the `browser` WebAssembly profiler in the `<WasmProfilers>` element:

```xml
<WasmProfilers>browser:callspec={FILTER};</WasmProfilers>
```

Permissiable `{FILTER}` placeholder values are shown in the following table.

Filter | Description
--- | ---
`all` | All assemblies
`program` | Entry point assembly
`{ASSEMBLY}` | Specifies an assembly (`{ASSEMBLY}`)
`M:Type:{METHOD}` | Specifies a method (`{METHOD}`)
`N:{NAMESPACE}` | Specifies a namespace (`{NAMESPACE}`)
`T:{TYPE}` | Specifies a type (`{TYPE}`)
`+EXPR` | Includes expression
`-EXPR` | Excludes expression

In the following example, profiled methods are filtered to the app's namespace `SampleApp` and sampling interval is 50ms.

```xml
<WasmProfilers>browser:callspec=N:SampleApp,interval=50</WasmProfilers>
```

## Additional resources

* [What diagnostic tools are available in .NET?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
