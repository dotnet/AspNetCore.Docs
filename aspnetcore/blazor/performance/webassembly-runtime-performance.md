---
title: ASP.NET Core Blazor WebAssembly runtime performance
author: guardrex
description: Learn about ASP.NET Core Blazor WebAssembly runtime performance.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/11/2025
uid: blazor/performance/webassembly-runtime-performance
---
# ASP.NET Core Blazor WebAssembly runtime performance

<!-- UPDATE 10.0 - Activate ...

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article provides guidance on Blazor WebAssembly runtime performance.

## Potentially reduced performance with Microsoft Edge enhanced security

The Microsoft Edge browser's WebAssembly (Wasm) interpreter running in [enhanced security mode](/DeployEdge/microsoft-edge-security-browse-safer) might not yield the same performance as when Blazor is running without enhanced security. If enhanced security mode is enabled and an app's performance is degraded, we recommend adding the site as an [exception](/DeployEdge/microsoft-edge-security-browse-safer#enhanced-security-sites) to opt out of enhanced security mode.

:::moniker range=">= aspnetcore-8.0"

## Trim .NET IL after ahead-of-time (AOT) compilation

The `WasmStripILAfterAOT` MSBuild option enables removing the .NET Intermediate Language (IL) for compiled methods after performing AOT compilation to WebAssembly, which reduces the size of the `_framework` folder.

In the app's project file:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
  <WasmStripILAfterAOT>true</WasmStripILAfterAOT>
</PropertyGroup>
```

This setting trims away the IL code for most compiled methods, including methods from libraries and methods in the app. Not all compiled methods can be trimmed, as some are still required by the .NET interpreter at runtime.

To report a problem with the trimming option, [open an issue on the `dotnet/runtime` GitHub repository](https://github.com/dotnet/runtime/issues).

Disable the trimming property if it prevents your app from running normally:

```xml
<WasmStripILAfterAOT>false</WasmStripILAfterAOT>
```

:::moniker-end

## Heap size for some mobile device browsers

When building a Blazor app that runs on the client and targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. For more information, see <xref:blazor/host-and-deploy/webassembly/index#decrease-maximum-heap-size-for-some-mobile-device-browsers>.

## Runtime relinking

One of the largest parts of a Blazor WebAssembly app is the WebAssembly-based .NET runtime (`dotnet.wasm`) that the browser must download when the app is first accessed by a user's browser. Relinking the .NET WebAssembly runtime trims unused runtime code and thus improves download speed.

Runtime relinking requires installation of the .NET WebAssembly build tools. For more information, see <xref:blazor/tooling#net-webassembly-build-tools>.

With the .NET WebAssembly build tools installed, runtime relinking is performed automatically when an app is **published** in the `Release` configuration. The size reduction is particularly dramatic when disabling globalization. For more information, see <xref:blazor/globalization-localization#invariant-globalization>.

> [!IMPORTANT]
> Runtime relinking trims class instance JavaScript-invokable .NET methods unless they're protected. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#avoid-trimming-javascript-invokable-net-methods>.

## Single Instruction, Multiple Data (SIMD)

:::moniker range=">= aspnetcore-8.0"

Blazor uses [WebAssembly Single Instruction, Multiple Data (SIMD)](https://wikipedia.org/wiki/Single_instruction,_multiple_data) to improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction.

To disable SIMD, for example when targeting old browsers or browsers on mobile devices that don't support SIMD, set the `<WasmEnableSIMD>` property to `false` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>false</WasmEnableSIMD>
</PropertyGroup>
```

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://aka.ms/dotnet-wasm-features#simd---single-instruction-multiple-data) and note that the guidance isn't versioned and applies to the latest public release.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Blazor uses [WebAssembly Single Instruction, Multiple Data (SIMD)](https://wikipedia.org/wiki/Single_instruction,_multiple_data) to improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction.

To enable SIMD, add the `<WasmEnableSIMD>` property set to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>true</WasmEnableSIMD>
</PropertyGroup>
```

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://aka.ms/dotnet-wasm-features#simd---single-instruction-multiple-data) and note that the guidance isn't versioned and applies to the latest public release.

:::moniker-end

## Additional resources

* <xref:blazor/performance/webassembly-browser-developer-tools>
* <xref:blazor/performance/webassembly-event-pipe>
* [What diagnostic tools are available in .NET Core?](/dotnet/core/diagnostics/)
* [.NET diagnostic tools](/dotnet/core/diagnostics/tools-overview)
