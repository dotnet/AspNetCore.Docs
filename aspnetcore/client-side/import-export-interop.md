---
title: Run .NET from JavaScript using `[JSImport]`/`[JSExport]` interop
author: pavelsavara
description: Learn how to run .NET from JavaScript using `[JSImport]`/`[JSExport]` interop.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/18/2022
uid: client-side/import-export-interop
---
# Run .NET from JavaScript using `[JSImport]`/`[JSExport]` interop

This article explains how to run .NET from JavaScript (JS) using `[JSImport]`/`[JSExport]` interop.

Existing JS apps can use the expanded client-side WebAssembly support in .NET 7 to reuse .NET libraries from JS or to build novel .NET-based apps and frameworks.

> [!NOTE]
> This article focuses on running .NET from JS apps without any dependency on [Blazor](xref:blazor/index). 

<!--

    HOLD: ADD TO NOTE AFTER BLAZOR ARTICLE IS MERGED ...

    For guidance on using `[JSImport]`/`[JSExport]` interop in Blazor WebAssembly apps, see <xref:blazor/js-interop/import-export-interop>.

-->

These approaches are appropriate when you only expect to run on WebAssembly (:::no-loc text="WASM":::). Libraries can make a runtime check to determine if the app is running on :::no-loc text="WASM"::: by calling <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType>.

## Prerequisites

[!INCLUDE[](~/includes/7.0-SDK.md)]

## Namespace

The JS interop API described in this article is controlled by attributes in the <xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> namespace.

## Enable unsafe blocks

Enable the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property in app's project file, which permits the code generator in the Roslyn compiler to use pointers for JS interop:

```xml
<PropertyGroup>
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
</PropertyGroup>
```

> [!WARNING]
> The JS interop API requires enabling <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks>. Be careful when implementing your own unsafe code in .NET apps, which can introduce security and stability risks. For more information, see [Unsafe code, pointer types, and function pointers](/dotnet/csharp/language-reference/unsafe-code).

In apps generated from the `wasmbrowser` or `wasmconsole` templates, the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property is set in the project file (`.csproj`).

## .NET JavaScript interop on :::no-loc text="WASM":::

The [JS ES6 module](xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules) in `main.js` in a project created from the `wasmbrowser` project template demonstrates JS interop. The relevant APIs are imported from `dotnet.js`. These APIs enable you to set up named modules that can be imported into your C# code and call into methods exposed by your .NET code, including `Program.Main`.

Function calls in the following example:

* `dotnet.withDiagnosticTracing(false).withApplicationArgumentsFromQuery().create()` sets up the .NET WebAssembly runtime without diagnostic tracing and with query string arguments.
* `setModuleImports` creates the `window.location.href` function, which returns the current page address (URL). The import designates a module name that matches the JS file name, `main.js`. The `window.location.href` function is imported into C# and called by the C# method `GetHRef`. The `GetHRef` method is shown later in this section.
* `exports.MyClass.Greeting()` calls into .NET (`MyClass.Greeting`) from JS. The `Greeting` C# method returns a string that includes the result of calling the `window.location.href` function. The `Greeting` method is shown later in this section.
* `runMainAndExit` runs `Program.Main`.

<!--

    NOTE: THE FOLLOWING CODE IS CHANGING FOR RELEASE:

    https://github.com/dotnet/runtime/blob/release/7.0/src/mono/wasm/templates/templates/browser/main.js

    For example, the runMainAndExit() is changing to dotnet.run().

    This is tracked on the 7.0 doc tracking issue at https://github.com/dotnet/AspNetCore.Docs/issues/26364.
    
-->

`main.js` of an app created from the `wasmbrowser` project template:

```javascript
import { dotnet } from './dotnet.js'

const is_browser = typeof window != "undefined";
if (!is_browser) throw new Error(`Expected to be running in a browser`);

const { setModuleImports, getAssemblyExports, getConfig, runMainAndExit } = 
  await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

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

document.getElementById("out").innerHTML = `${text}`;
await runMainAndExit(config.mainAssemblyName, ["dotnet", "is", "great!"]);
```

To import a JS function so it can be called from C#, use the new `JSImportAttribute` on a matching method signature. The first parameter to the `JSImportAttribute` is the name of the JS function to import and the second parameter is the name of the module.

In the following example, the `window.location.href` function is called from the `main.js` module when `GetHRef` method is called. In an app generated from either the `wasmbrowser` or `wasmconsole` templates, `GetHRef` is in `Program.cs` with the partial class namespace `MyClass`:

```csharp
[JSImport("window.location.href", "main.js")]
internal static partial string GetHRef();
```

In the imported method signature, you can use .NET types for parameters and return values, which are marshalled automatically by the runtime. Use `JSMarshalAsAttribute<T>` to control how the imported method parameters are marshalled. For example, you might choose to marshal a `long` as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>. You can pass <xref:System.Action>/<xref:System.Func%601> callbacks as parameters, which are marshalled as callable JS functions. You can pass both JS and managed object references, and they are marshaled as proxy objects, keeping the object alive across the boundary until the proxy is garbage collected. You can also import and export asynchronous methods with a <xref:System.Threading.Tasks.Task> result, which are marshaled as [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods.

To export a .NET method so it can be called from JS, use the `JSExportAttribute`.

In the following example, the `Greeting` method returns a string that includes the result of calling the `GetHRef` method. As shown earlier, the `GetHref` C# method calls into JS for the `window.location.href` function from the `main.js` module. `window.location.href` returns the current page address (URL). In an app generated from either the `wasmbrowser` or `wasmconsole` templates, `Greeting` is in the `Program.cs` file with the partial class namespace `MyClass`:

```csharp
[JSExport]
internal static string Greeting()
{
    var text = $"Hello, World! Greetings from {GetHRef()}";
    Console.WriteLine(text);
    return text;
}
```

In the `index.html` file of an app generated from the `wasmbrowser` template, the `main.js` and `dotnet.js` modules are preloaded. The `<script>` tag for `main.js` appears inside the closing `</body>` tag, resulting the following:

* `main.js` is loaded.
* `dotnet.js` is imported by `main.js`.
* The .NET runtime is started by calling `runMainAndExit()` in `main.js`.

<!--

    NOTE: In the preceding list, change runMainAndExit() to dotnet.run() for release.

-->

```html
<html>

<head>
    ...
    <link rel="modulepreload" href="./main.js" />
    <link rel="modulepreload" href="./dotnet.js" />
</head>

<body>
    ...
    <script type='module' src="./main.js"></script>
</body>

</html>
```

In addition to preloading, it's possible to prefetch the largest binary files. In a production app, measure the impact of preloading and prefetching optimizations. For more information, see [Use .NET from any JavaScript app in .NET 7: Optimize the app](https://devblogs.microsoft.com/dotnet/use-net-7-from-any-javascript-app-in-net-7/#optimize-the-app).

## Additional example

For an additional example of the JS interop techniques described in this article, see the *Port of famous Todo-MVC to .NET on WASM* sample app:

* [Reference source (`pavelsavara/dotnet-wasm-todo-mvc` GitHub repository)](https://github.com/pavelsavara/dotnet-wasm-todo-mvc)
* [Live demonstration](https://pavelsavara.github.io/dotnet-wasm-todo-mvc/)

> [!NOTE]
> The [`pavelsavara/dotnet-wasm-todo-mvc` GitHub repository](https://github.com/pavelsavara/dotnet-wasm-todo-mvc) isn't owned, maintained, or supported by the .NET foundation or Microsoft.
>
> The *Port of famous Todo-MVC to .NET on WASM* sample app uses:
>
> * [TodoMVC](https://todomvc.com/)
> * [Playwright for .NET](https://playwright.dev/dotnet/)
>
> The preceding frameworks aren't owned, maintained, or supported by the .NET foundation or Microsoft.

## Experimental workload and project templates

To demonstrate the JS interop functionality and obtain JS interop project templates, install the `wasm-experimental` workload:

```dotnetcli
dotnet workload install wasm-experimental
```

The `wasm-experimental` workload contains two project templates: `wasmbrowser` and `wasmconsole`. These templates are experimental at this time, which means the developer workflow for the templates hasn't been fully designed. For example, these templates don't run in Visual Studio at this time. The .NET and JS APIs used in the templates are supported in .NET 7 and provide a foundation for using .NET on :::no-loc text="WASM"::: from JS.

The templates can be examined in reference source:

[`templates` assets in the `dotnet/runtime` GitHub repository](https://github.com/dotnet/runtime/tree/main/src/mono/wasm/templates/templates).

> [!NOTE]
> The preceding link to the .NET reference source loads the repository's default branch (`main`), which represents the current development for the next release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list.

### Browser app

You can create a browser app by running the following command:

```dotnetcli
dotnet new wasmbrowser
```

The `wasmbrowser` template creates a web app that demonstrates using .NET and JS together in a browser.

Build the app from Visual Studio or by using the .NET CLI passing the [`-c/--configuration`](/dotnet/core/tools/dotnet-build#options) build configuration option:

```dotnetcli
dotnet build -c {BUILD CONFIGURATION}
```

In the preceding command, the `{BUILD CONFIGURATION}` placeholder is the build configuration: `Debug`, `Release`, or a custom configuration.

The built app is in the `bin/$(Configuration)/net7.0/browser-wasm/AppBundle` directory.

Build and run the app from Visual Studio or by using the .NET CLI passing the [`-c/--configuration`](/dotnet/core/tools/dotnet-run#options) build configuration option:

```dotnetcli
dotnet run -c {BUILD CONFIGURATION}
```

Alternatively, start any static file server from the `AppBundle` directory:

```dotnetcli
dotnet serve -d:bin/$(Configuration)/net7.0/browser-wasm/AppBundle
```

### Node.js console app

You can create a console app by running the following command:

```dotnetcli
dotnet new wasmconsole
```

The `wasmconsole` template creates a app that runs under :::no-loc text="WASM"::: as a [Node.js](https://nodejs.org/) or [V8](https://developers.google.com/apps-script/guides/v8-runtime) console app.

Build the app from Visual Studio or by using the .NET CLI passing the [`-c/--configuration`](/dotnet/core/tools/dotnet-build#options) build configuration option:

```dotnetcli
dotnet build -c {BUILD CONFIGURATION}
```

In the preceding command, the `{BUILD CONFIGURATION}` placeholder is the build configuration: `Debug`, `Release`, or a custom configuration.

The built app is in the `bin/$(Configuration)/net7.0/browser-wasm/AppBundle` directory.

Build and run the app from Visual Studio or by using the .NET CLI passing the [`-c/--configuration`](/dotnet/core/tools/dotnet-run#options) build configuration option::

```dotnetcli
dotnet run -c {BUILD CONFIGURATION}
```

Alternatively, start any static file server from the `AppBundle` directory:

```
node bin/$(Configuration)/net7.0/browser-wasm/AppBundle/main.mjs
```

## Additional resources

<!--

    HOLD: ADD AFTER BLAZOR ARTICLE IS MERGED ...

    * <xref:blazor/js-interop/import-export-interop>

-->

* [Use .NET from any JavaScript app in .NET 7](https://devblogs.microsoft.com/dotnet/use-net-7-from-any-javascript-app-in-net-7/)
