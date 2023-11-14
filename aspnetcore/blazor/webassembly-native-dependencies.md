---
title: ASP.NET Core Blazor WebAssembly native dependencies
author: guardrex
description: Learn how to build Blazor WebAssembly apps with native dependencies built to run on WebAssembly in the browser.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/webassembly-native-dependencies
---
# ASP.NET Core Blazor WebAssembly native dependencies

[!INCLUDE[](~/includes/not-latest-version.md)]

Blazor WebAssembly apps can use native dependencies built to run on WebAssembly. You can statically link native dependencies into the .NET WebAssembly runtime using the **.NET WebAssembly build tools**, the same tools used to [ahead-of-time (AOT) compile](xref:blazor/host-and-deploy/webassembly#ahead-of-time-aot-compilation) a Blazor app to WebAssembly and to [relink the runtime to remove unused features](xref:blazor/host-and-deploy/webassembly#runtime-relinking).

*This article only applies to Blazor WebAssembly.*

## .NET WebAssembly build tools

The .NET WebAssembly build tools are based on [Emscripten](https://emscripten.org/), a compiler toolchain for the web platform. For more information on the build tools, including installation, see <xref:blazor/tooling#net-webassembly-build-tools>.

Add native dependencies to a Blazor WebAssembly app by adding `NativeFileReference` items in the app's project file. When the project is built, each `NativeFileReference` is passed to Emscripten by the .NET WebAssembly build tools so that they are compiled and linked into the runtime. Next, [`p/invoke`](/dotnet/standard/native-interop/pinvoke) into the native code from the app's .NET code.

Generally, any portable native code can be used as a native dependency with Blazor WebAssembly. You can add native dependencies to C/C++ code or code previously compiled using Emscripten:

* Object files (`.o`)
* Archive files (`.a`)
* Bitcode (`.bc`)
* Standalone WebAssembly modules (`.wasm`)

Prebuilt dependencies typically must be built using the same version of Emscripten used to build the .NET WebAssembly runtime.

> [!NOTE]
> For [Mono](https://github.com/mono/mono)/WebAssembly MSBuild properties and targets, see [`WasmApp.targets` (dotnet/runtime GitHub repository)](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/build/WasmApp.targets). Official documentation for common MSBuild properties is planned per [Document blazor msbuild configuration options (dotnet/docs #27395)](https://github.com/dotnet/docs/issues/27395).

## Use native code

Add a simple native C function to a Blazor WebAssembly app:

1. Create a new Blazor WebAssembly project.
1. Add a `Test.c` file to the project.
1. Add a C function for computing factorials.

   `Test.c`:

   ```c
   int fact(int n)
   {
       if (n == 0) return 1;
       return n * fact(n - 1);
   }
   ```

1. Add a `NativeFileReference` for `Test.c` in the app's project file:

   ```xml
   <ItemGroup>
     <NativeFileReference Include="Test.c" />
   </ItemGroup>
   ```

1. In a Razor component, add a <xref:System.Runtime.InteropServices.DllImportAttribute> for the `fact` function in the generated `Test` library and call the `fact` method from .NET code in the component.

   `Pages/NativeCTest.razor`:

   ```razor
   @page "/native-c-test"
   @using System.Runtime.InteropServices

   <PageTitle>Native C</PageTitle>

   <h1>Native C Test</h1>

   <p>
       @@fact(3) result: @fact(3)
   </p>

   @code {
       [DllImport("Test")]
       static extern int fact(int n);
   }
   ```

When you build the app with the .NET WebAssembly build tools installed, the native C code is compiled and linked into the .NET WebAssembly runtime (`dotnet.wasm`). After the app is built, run the app to see the rendered factorial value.

## C++ managed method callbacks

Label managed methods that are passed to C++ with the `[UnmanagedCallersOnly]` attribute.

The method marked with the `[UnmanagedCallersOnly]` attribute must be `static`. To call an instance method in a Razor component, pass a `GCHandle` for the instance to C++ and then pass it back to native. Alternatively, use some other method to identify the instance of the component.

The method marked with `[DllImport]` must use a C# 9.0 function pointer rather than a delegate type for the callback argument.

> [!NOTE]
> For C# function pointer types in `[DllImport]` methods, use `IntPtr` in the method signature on the managed side instead of `delegate *unmanaged<int, void>`. For more information, see [[WASM] callback from native code to .NET: Parsing function pointer types in signatures is not supported (dotnet/runtime #56145)](https://github.com/dotnet/runtime/issues/56145).

## Package native dependencies in a NuGet package

NuGet packages can contain native dependencies for use on WebAssembly. These libraries and their native functionality are then available to any Blazor WebAssembly app. The files for the native dependencies should be built for WebAssembly and packaged in the `browser-wasm` [architecture-specific folder](/nuget/create-packages/supporting-multiple-target-frameworks#architecture-specific-folders). WebAssembly-specific dependencies aren't referenced automatically and must be referenced manually as `NativeFileReference`s. Package authors can choose to add the native references by including a `.props` file in the package with the references.

## SkiaSharp example library use

[SkiaSharp](https://github.com/mono/SkiaSharp) is a cross-platform 2D graphics library for .NET based on the native [Skia graphics library](https://skia.org/) with support for Blazor WebAssembly.

To use SkiaSharp in a Blazor WebAssembly app:

1. Add a package reference to the [`SkiaSharp.Views.Blazor`](https://www.nuget.org/packages/SkiaSharp.Views.Blazor) package in a Blazor WebAssembly project. Use Visual Studio's process for adding packages to an app (**Manage NuGet Packages** with **Include prerelease** selected) or execute the [`dotnet add package`](/dotnet/core/tools/dotnet-add-package) command in a command shell:

   ```dotnetcli
   dotnet add package –-prerelease SkiaSharp.Views.Blazor
   ```

   [!INCLUDE[](~/includes/package-reference.md)]

1. Add a `SKCanvasView` component to the app with the following:

   * `SkiaSharp` and `SkiaSharp.Views.Blazor` namespaces.
   * Logic to draw in the SkiaSharp Canvas View component (`SKCanvasView`).

   `Pages/NativeDependencyExample.razor`:

   ```razor
   @page "/native-dependency-example"
   @using SkiaSharp
   @using SkiaSharp.Views.Blazor

   <PageTitle>Native dependency</PageTitle>

   <h1>Native dependency example with SkiaSharp</h1>

   <SKCanvasView OnPaintSurface="@OnPaintSurface" />

   @code {
       private void OnPaintSurface(SKPaintSurfaceEventArgs e)
       {
           var canvas = e.Surface.Canvas;

           canvas.Clear(SKColors.White);

           using var paint = new SKPaint
           {
               Color = SKColors.Black,
               IsAntialias = true,
               TextSize = 24
           };

           canvas.DrawText("SkiaSharp", 0, 24, paint);
       }
   }
   ```

1. Build the app, which might take several minutes. Run the app and navigate to the `NativeDependencyExample` component at `/native-dependency-example`.

## Additional resources

* [.NET WebAssembly build tools](xref:blazor/tooling#net-webassembly-build-tools)
