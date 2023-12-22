---
title: Run .NET from JavaScript
author: pavelsavara
description: Learn how to run .NET from JavaScript.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/10/2022
uid: client-side/dotnet-interop
---
# Run .NET from JavaScript

This article explains how to run .NET from JavaScript (JS) using JS `[JSImport]`/`[JSExport]` interop.

For additional guidance, see the [Configuring and hosting .NET WebAssembly applications](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md) guidance in the .NET Runtime (`dotnet/runtime`) GitHub repository. We plan to update this article to include new information in the cross-linked guidance in the latter part of 2023 or early 2024.

Existing JS apps can use the expanded client-side WebAssembly support in .NET 7 or later to reuse .NET libraries from JS or to build novel .NET-based apps and frameworks.

> [!NOTE]
> This article focuses on running .NET from JS apps without any dependency on [Blazor](xref:blazor/index). For guidance on using `[JSImport]`/`[JSExport]` interop in Blazor WebAssembly apps, see <xref:blazor/js-interop/import-export-interop>.

These approaches are appropriate when you only expect to run on WebAssembly (:::no-loc text="WASM":::). Libraries can make a runtime check to determine if the app is running on :::no-loc text="WASM"::: by calling <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType>.

## Prerequisites

[!INCLUDE[](~/includes/7.0-SDK.md)]

Install the latest version of the [.NET SDK](https://dotnet.microsoft.com/download/dotnet/).

Install the `wasm-tools` workload, which brings in the related MSBuild targets.

```dotnetcli
dotnet workload install wasm-tools
```

Optionally, install the `wasm-experimental` workload, which contains experimental project templates for getting started with .NET on WebAssembly in a browser app (WebAssembly Browser App) or in a Node.js-based console app (WebAssembly Console App). This workload isn't required if you plan to integrate JS `[JSImport]`/`[JSExport]` interop into an existing JS app.

```dotnetcli
dotnet workload install wasm-experimental
```

For more information, see the [Experimental workload and project templates](#experimental-workload-and-project-templates) section.

## Namespace

The JS interop API described in this article is controlled by attributes in the <xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> namespace.

## Project configuration

To configure a project (`.csproj`) to enable JS interop:

* Target `net7.0` or later:

  ```xml
  <TargetFramework>net7.0</TargetFramework>
  ```

* Specify `browser-wasm` for the runtime identifier:

  ```xml
  <RuntimeIdentifier>browser-wasm</RuntimeIdentifier>
  ```

* Specify an executable output type:

  ```xml
  <OutputType>Exe</OutputType>
  ```
  
* Enable the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property, which permits the code generator in the Roslyn compiler to use pointers for JS interop:

  ```xml
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
  ```

  > [!WARNING]
  > The JS interop API requires enabling <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks>. Be careful when implementing your own unsafe code in .NET apps, which can introduce security and stability risks. For more information, see [Unsafe code, pointer types, and function pointers](/dotnet/csharp/language-reference/unsafe-code).

* Specify `WasmMainJSPath` to point to a file on disk. This file is published with the app, but use of the file isn't required if you're integrating .NET into an existing JS app.

  In the following example, the JS file on disk is `main.js`, but any JS filename is permissable:

  ```xml
  <WasmMainJSPath>main.js</WasmMainJSPath>
  ```

Example project file (`.csproj`) after configuration:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <RuntimeIdentifier>browser-wasm</RuntimeIdentifier>
    <OutputType>Exe</OutputType>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <WasmMainJSPath>main.js</WasmMainJSPath>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

## JavaScript interop on :::no-loc text="WASM":::

APIs in the following example are imported from `dotnet.js`. These APIs enable you to set up named modules that can be imported into your C# code and call into methods exposed by your .NET code, including `Program.Main`.

> [!IMPORTANT]
> "Import" and "export" throughout this article are defined from the perspective of .NET:
>
> * An app imports JS methods so that they can be called from .NET.
> * The app exports .NET methods so that they can be called from JS.

In the following example:

* The `dotnet.js` file is used to create and start the .NET WebAssembly runtime. `dotnet.js` is generated as part of the build output of the app and found in the `AppBundle` folder:

  > :::no-loc text="bin/{BUILD CONFIGURATION}/{TARGET FRAMEWORK}/browser-wasm/AppBundle":::

  The `{BUILD CONFIGURATION}` placeholder is the build configuration (for example, `Debug`, `Release`), and the `{TARGET FRAMEWORK}` placeholder is the target framework (for example, `net7.0`).

  > [!IMPORTANT]
  > To integrate with an existing app, copy the contents of the `AppBundle` folder so that it can be served along with the rest of the app. For production deployments, publish the app with the `dotnet publish -c Release` command in a command shell and deploy the `AppBundle` folder with the app.

* `dotnet.create()` sets up the .NET WebAssembly runtime.

* `setModuleImports` associates a name with a module of JS functions for import into .NET. The JS module contains a `window.location.href` function, which returns the current page address (URL). The name of the module can be any string (it doesn't need to be a file name), but it must match the name used with the `JSImportAttribute` (explained later in this article). The `window.location.href` function is imported into C# and called by the C# method `GetHRef`. The `GetHRef` method is shown later in this section.

* `exports.MyClass.Greeting()` calls into .NET (`MyClass.Greeting`) from JS. The `Greeting` C# method returns a string that includes the result of calling the `window.location.href` function. The `Greeting` method is shown later in this section.

* `dotnet.run()` runs `Program.Main`.

JS module:

```javascript
import { dotnet } from './dotnet.js'

const is_browser = typeof window != "undefined";
if (!is_browser) throw new Error(`Expected to be running in a browser`);

const { setModuleImports, getAssemblyExports, getConfig } = 
  await dotnet.create();

setModuleImports("main.js", {
  window: {
    location: {
      href: () => globalThis.window.location.href
    }
  }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.MyClass.Greeting();
console.log(text);

document.getElementById("out").innerHTML = text;
await dotnet.run();
```

To import a JS function so it can be called from C#, use the new <xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute> on a matching method signature. The first parameter to the <xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute> is the name of the JS function to import and the second parameter is the name of the module.

In the following example, the `window.location.href` function is called from the `main.js` module when `GetHRef` method is called:

```csharp
[JSImport("window.location.href", "main.js")]
internal static partial string GetHRef();
```

In the imported method signature, you can use .NET types for parameters and return values, which are marshalled automatically by the runtime. Use <xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601> to control how the imported method parameters are marshalled. For example, you might choose to marshal a `long` as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>. You can pass <xref:System.Action>/<xref:System.Func%601> callbacks as parameters, which are marshalled as callable JS functions. You can pass both JS and managed object references, and they are marshaled as proxy objects, keeping the object alive across the boundary until the proxy is garbage collected. You can also import and export asynchronous methods with a <xref:System.Threading.Tasks.Task> result, which are marshaled as [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods.

[!INCLUDE[](~/blazor/includes/js-interop/7.0/import-export-interop-mappings.md)]

Functions accessible on the global namespace can be imported by using the [`globalThis`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/globalThis) prefix in the function name and by using the `[JSImport]` attribute without providing a module name. In the following example, [`console.log`](https://developer.mozilla.org/docs/Web/API/console/log) is prefixed with `globalThis`. The imported function is called by the C# `Log` method, which accepts a C# string message (`message`) and marshalls the C# string to a JS [`String`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/String) for `console.log`:

```csharp
[JSImport("globalThis.console.log")]
internal static partial void Log([JSMarshalAs<JSType.String>] string message);
```

To export a .NET method so it can be called from JS, use the <xref:System.Runtime.InteropServices.JavaScript.JSExportAttribute>.

In the following example, the `Greeting` method returns a string that includes the result of calling the `GetHRef` method. As shown earlier, the `GetHref` C# method calls into JS for the `window.location.href` function from the `main.js` module. `window.location.href` returns the current page address (URL):

```csharp
[JSExport]
internal static string Greeting()
{
    var text = $"Hello, World! Greetings from {GetHRef()}";
    Console.WriteLine(text);

    return text;
}
```

## Experimental workload and project templates

To demonstrate the JS interop functionality and obtain JS interop project templates, install the `wasm-experimental` workload:

```dotnetcli
dotnet workload install wasm-experimental
```

The `wasm-experimental` workload contains two project templates: `wasmbrowser` and `wasmconsole`. These templates are experimental at this time, which means the developer workflow for the templates is evolving. However, the .NET and JS APIs used in the templates are supported in .NET 7 and provide a foundation for using .NET on :::no-loc text="WASM"::: from JS.

### Browser app

You can create a browser app with the `wasmbrowser` template, which creates a web app that demonstrates using .NET and JS together in a browser:

```dotnetcli
dotnet new wasmbrowser
```

Build the app from Visual Studio or by using the .NET CLI:

```dotnetcli
dotnet build
```

The built app is in the `bin/{BUILD CONFIGURATION}/{TARGET FRAMEWORK}/browser-wasm/AppBundle` directory. The `{BUILD CONFIGURATION}` placeholder is the build configuration (for example, `Debug`, `Release`). The `{TARGET FRAMEWORK}` placeholder is the target framework moniker (for example, `net7.0`).

Build and run the app from Visual Studio or by using the .NET CLI:

```dotnetcli
dotnet run
```

Alternatively, start any static file server from the `AppBundle` directory:

```dotnetcli
dotnet serve -d:bin/$(Configuration)/{TARGET FRAMEWORK}/browser-wasm/AppBundle
```

In the preceding example, the `{TARGET FRAMEWORK}` placeholder is the target framework moniker (for example, `net7.0`).

### Node.js console app

You can create a console app with the `wasmconsole` template, which creates an app that runs under :::no-loc text="WASM"::: as a [Node.js](https://nodejs.org/) or [V8](https://developers.google.com/apps-script/guides/v8-runtime) console app:

```dotnetcli
dotnet new wasmconsole
```

Build the app from Visual Studio or by using the .NET CLI:

```dotnetcli
dotnet build
```

The built app is in the `bin/{BUILD CONFIGURATION}/{TARGET FRAMEWORK}/browser-wasm/AppBundle` directory. The `{BUILD CONFIGURATION}` placeholder is the build configuration (for example, `Debug`, `Release`). The `{TARGET FRAMEWORK}` placeholder is the target framework moniker (for example, `net7.0`).

Build and run the app from Visual Studio or by using the .NET CLI:

```dotnetcli
dotnet run
```

Alternatively, start any static file server from the `AppBundle` directory:

```
node bin/$(Configuration)/{TARGET FRAMEWORK}/browser-wasm/AppBundle/main.mjs
```

In the preceding example, the `{TARGET FRAMEWORK}` placeholder is the target framework moniker (for example, `net7.0`).

## Additional resources

* [Configuring and hosting .NET WebAssembly applications](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/features.md)
* API documentation
  * [`[JSImport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute)
  * [`[JSExport]` attribute](xref:System.Runtime.InteropServices.JavaScript.JSExportAttribute)
* <xref:blazor/js-interop/import-export-interop>
* In the `dotnet/runtime` GitHub repository:
  * [.NET WebAssembly runtime](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/runtime/)
  * [`dotnet.d.ts` file (.NET WebAssembly runtime configuration)](https://github.com/dotnet/runtime/blob/main/src/mono/browser/runtime/dotnet.d.ts)
* [Use .NET from any JavaScript app in .NET 7](https://devblogs.microsoft.com/dotnet/use-net-7-from-any-javascript-app-in-net-7/)
