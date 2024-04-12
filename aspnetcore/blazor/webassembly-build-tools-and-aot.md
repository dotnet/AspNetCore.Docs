---
title: ASP.NET Core Blazor WebAssembly build tools and ahead-of-time (AOT) compilation
author: guardrex
description: Learn about the WebAssembly build tools and how to compile a Blazor WebAssembly app ahead of deployment with ahead-of-time (AOT) compilation.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/12/2024
uid: blazor/tooling/webassembly
---
# ASP.NET Core Blazor WebAssembly build tools and ahead-of-time (AOT) compilation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes the build tools for standalone Blazor WebAssembly apps and how to compile an app ahead of deployment with ahead-of-time (AOT) compilation.

Although the article primarily focuses on standalone Blazor WebAssembly apps, the section on [heap size for some mobile device browsers](#heap-size-for-some-mobile-device-browsers) also applies to the client-side project (`.Client`) of a Blazor Web App.

## .NET WebAssembly build tools

The .NET WebAssembly build tools are based on [Emscripten](https://emscripten.org/), a compiler toolchain for the web platform. To install the build tools, use ***either*** of the following approaches:

* For the **ASP.NET and web development** workload in the Visual Studio installer, select the **.NET WebAssembly build tools** option from the list of optional components.
* Execute `dotnet workload install wasm-tools` in an administrative command shell.

> [!NOTE]
> .NET WebAssembly build tools for .NET 6 projects
>
> The `wasm-tools` workload installs the build tools for the latest release. However, the current version of the build tools are incompatible with existing projects built with .NET 6. Projects using the build tools that must support both .NET 6 and a later release must use multi-targeting.
>
> Use the `wasm-tools-net6` workload for .NET 6 projects when developing apps with the .NET 7 SDK. To install the `wasm-tools-net6` workload, execute the following command from an administrative command shell:
>
> ```dotnetcli
> dotnet workload install wasm-tools-net6
> ```

## Ahead-of-time (AOT) compilation

Blazor WebAssembly supports ahead-of-time (AOT) compilation, where you can compile your .NET code directly into WebAssembly. AOT compilation results in runtime performance improvements at the expense of a larger app size.

:::moniker range=">= aspnetcore-8.0"

Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET [Intermediate Language (IL)](/dotnet/standard/glossary#il) interpreter implemented in WebAssembly with partial [just-in-time (JIT)](/dotnet/standard/glossary#jit) runtime support, informally referred to as the *Jiterpreter*. Because the .NET IL code is interpreted, apps typically run slower than they would on a server-side .NET JIT runtime without any IL interpretation. AOT compilation addresses this performance issue by compiling an app's .NET code directly into WebAssembly for native WebAssembly execution by the browser. The AOT performance improvement can yield dramatic improvements for apps that execute CPU-intensive tasks. The drawback to using AOT compilation is that AOT-compiled apps are generally larger than their IL-interpreted counterparts, so they usually take longer to download to the client when first requested.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Without enabling AOT compilation, Blazor WebAssembly apps run on the browser using a .NET [Intermediate Language (IL)](/dotnet/standard/glossary#il) interpreter implemented in WebAssembly. Because the .NET code is interpreted, apps typically run slower than they would on a server-side .NET [just-in-time (JIT)](/dotnet/standard/glossary#jit) runtime. AOT compilation addresses this performance issue by compiling an app's .NET code directly into WebAssembly for native WebAssembly execution by the browser. The AOT performance improvement can yield dramatic improvements for apps that execute CPU-intensive tasks. The drawback to using AOT compilation is that AOT-compiled apps are generally larger than their IL-interpreted counterparts, so they usually take longer to download to the client when first requested.

:::moniker-end

For guidance on installing the .NET WebAssembly build tools, see <xref:blazor/tooling/webassembly>.

To enable WebAssembly AOT compilation, add the `<RunAOTCompilation>` property set to `true` to the Blazor WebAssembly app's project file:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

To compile the app to WebAssembly, publish the app. Publishing the `Release` configuration ensures the .NET Intermediate Language (IL) linking is also run to reduce the size of the published app:

```dotnetcli
dotnet publish -c Release
```

WebAssembly AOT compilation is only performed when the project is published. AOT compilation isn't used when the project is run during development (`Development` environment) because AOT compilation usually takes several minutes on small projects and potentially much longer for larger projects. Reducing the build time for AOT compilation is under development for future releases of ASP.NET Core.

The size of an AOT-compiled Blazor WebAssembly app is generally larger than the size of the app if compiled into .NET IL:

* Although the size difference depends on the app, most AOT-compiled apps are about twice the size of their IL-compiled versions. This means that using AOT compilation trades off load-time performance for runtime performance. Whether this tradeoff is worth using AOT compilation depends on your app. Blazor WebAssembly apps that are CPU intensive generally benefit the most from AOT compilation.

* The larger size of an AOT-compiled app is due to two conditions:

  * More code is required to represent high-level .NET IL instructions in native WebAssembly.
  * AOT does ***not*** trim out managed DLLs when the app is published. Blazor requires the DLLs for [reflection metadata](/dotnet/csharp/advanced-topics/reflection-and-attributes/) and to support certain .NET runtime features. Requiring the DLLs on the client increases the download size but provides a more compatible .NET experience.

> [!NOTE]
> For [Mono](https://github.com/mono/mono)/WebAssembly MSBuild properties and targets, see [`WasmApp.Common.targets` (`dotnet/runtime` GitHub repository)](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/build/WasmApp.Common.targets). Official documentation for common MSBuild properties is planned per [Document blazor msbuild configuration options (`dotnet/docs` #27395)](https://github.com/dotnet/docs/issues/27395).

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

When building a Blazor app that runs on the client and targets mobile device browsers, especially Safari on iOS, decreasing the maximum memory for the app with the MSBuild property `EmccMaximumHeapSize` may be required. For more information, see <xref:blazor/host-and-deploy/webassembly#decrease-maximum-heap-size-for-some-mobile-device-browsers>.

## Runtime relinking

One of the largest parts of a Blazor WebAssembly app is the WebAssembly-based .NET runtime (`dotnet.wasm`) that the browser must download when the app is first accessed by a user's browser. Relinking the .NET WebAssembly runtime trims unused runtime code and thus improves download speed.

Runtime relinking requires installation of the .NET WebAssembly build tools. For more information, see <xref:blazor/tooling#net-webassembly-build-tools>.

With the .NET WebAssembly build tools installed, runtime relinking is performed automatically when an app is **published** in the `Release` configuration. The size reduction is particularly dramatic when disabling globalization. For more information, see <xref:blazor/globalization-localization#invariant-globalization>.

> [!IMPORTANT]
> Runtime relinking trims class instance JavaScript-invokable .NET methods unless they're protected. For more information, see <xref:blazor/js-interop/call-dotnet-from-javascript#avoid-trimming-javascript-invokable-net-methods>.

## Single Instruction, Multiple Data (SIMD)

:::moniker range=">= aspnetcore-8.0"

[WebAssembly Single Instruction, Multiple Data (SIMD)](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) can improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction. SIMD is enabled by default.

To disable SIMD, for example when targeting old browsers or browsers on mobile devices that don't support SIMD, set the `<WasmEnableSIMD>` property to `false` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>false</WasmEnableSIMD>
</PropertyGroup>
```

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://aka.ms/dotnet-wasm-features#simd---single-instruction-multiple-data) and note that the guidance isn't versioned and applies to the latest public release.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

[WebAssembly Single Instruction, Multiple Data (SIMD)](https://github.com/WebAssembly/simd/blob/master/proposals/simd/SIMD.md) can improve the throughput of vectorized computations by performing an operation on multiple pieces of data in parallel using a single instruction. SIMD is disabled by default.

To enable SIMD, add the `<WasmEnableSIMD>` property set to `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableSIMD>true</WasmEnableSIMD>
</PropertyGroup>
```

For more information, see [Configuring and hosting .NET WebAssembly applications: SIMD - Single instruction, multiple data](https://aka.ms/dotnet-wasm-features#simd---single-instruction-multiple-data) and note that the guidance isn't versioned and applies to the latest public release.

:::moniker-end

## Exception handling

:::moniker range=">= aspnetcore-8.0"

Exception handling is enabled by default. To disable exception handling, add the `<WasmEnableExceptionHandling>` property with a value of `false` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableExceptionHandling>false</WasmEnableExceptionHandling>
</PropertyGroup>
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To enable WebAssembly exception handling, add the `<WasmEnableExceptionHandling>` property with a value of `true` in the app's project file (`.csproj`):

```xml
<PropertyGroup>
  <WasmEnableExceptionHandling>true</WasmEnableExceptionHandling>
</PropertyGroup>
```

:::moniker-end

## Additional resources

* <xref:blazor/webassembly-native-dependencies>
* [Webcil packaging format for .NET assemblies](xref:blazor/host-and-deploy/webassembly#webcil-packaging-format-for-net-assemblies)
