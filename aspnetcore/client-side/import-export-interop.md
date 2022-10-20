---
title: Run .NET from JavaScript using `[JSImport]`/`[JSExport]` interop
author: pavelsavara
description: Learn how to run .NET from JavaScript using `[JSImport]`/`[JSExport]` interop.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 10/20/2022
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

## .NET SDK and WebAssembly workloads

Install the latest version of the [.NET SDK](https://dotnet.microsoft.com/download/dotnet/).

Install the `wasm-tools` workload, which brings in the related MSBuild targets. Note: You only need the `wasm-experimental` workload if you want to use the project templates.

```dotnetcli
dotnet workload install wasm-tools
```

Optionally, install the `wasm-experimental` workload, which contains experimental project templates for getting started with .NET on WebAssembly in a browser app (WebAssembly Browser App) or in a Node.js-based console app (WebAssembly Console App). This workload isn't required if you plan to integrate `[JSImport]`/`[JSExport]` interop into an existing JS app.

```dotnetcli
dotnet workload install wasm-experimental
```

For more information, see the [Experimental workload and project templates](#experimental-workload-and-project-templates) section.

## App configuration

To configure the app's project file (`.csproj`):

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
  
  > [!NOTE]
  > The framework may support library projects without an entry point in a future release of .NET.

* Enable the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property, which permits the code generator in the Roslyn compiler to use pointers for JS interop:

  ```xml
  <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
  ```

  > [!WARNING]
  > The JS interop API requires enabling <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks>. Be careful when implementing your own unsafe code in .NET apps, which can introduce security and stability risks. For more information, see [Unsafe code, pointer types, and function pointers](/dotnet/csharp/language-reference/unsafe-code).

  In apps generated from the `wasmbrowser` or `wasmconsole` templates, the <xref:Microsoft.Build.Tasks.Csc.AllowUnsafeBlocks> property is set in the project file (`.csproj`).

* For the .NET 7 release, you must specify `WasmMainJSPath` to point to a file on disk. This file is published with the app, but use of the file isn't required if you're integrating .NET into an existing JS app. We might make this property optional in the future. For more information, see [Smooth out support for running .NET from JS via WebAssembly (dotnet/runtime #77191)](https://github.com/dotnet/runtime/issues/77191).

  In the following example, the JS file on disk is `main.js`, but any JS filename is permissable:

  ```xml
  <WasmMainJSPath>main.js</WasmMainJSPath>
  ```

* During preview, set the C# language version:

  ```xml
  <LangVersion>preview</LangVersion>
  ```

* Deploy JS files (`.js`) and CSS files (`.css`):

  ```xml
  <ItemGroup>
    <WasmExtraFilesToDeploy Include="index.html" />
    <WasmExtraFilesToDeploy Include="*.js" />
    <WasmExtraFilesToDeploy Include="*.css" />
  </ItemGroup>
  ```

Example .NET 7 preview release project file (`.csproj`) after configuration:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net7.0</TargetFramework>
    <RuntimeIdentifier>browser-wasm</RuntimeIdentifier>
    <OutputType>Exe</OutputType>
    <AllowUnsafeBlocks>true</AllowUnsafeBlocks>
    <WasmMainJSPath>main.js</WasmMainJSPath>
    <LangVersion>preview</LangVersion>
    <Nullable>enable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <WasmExtraFilesToDeploy Include="index.html" />
    <WasmExtraFilesToDeploy Include="*.js" />
    <WasmExtraFilesToDeploy Include="*.css" />
  </ItemGroup>

</Project>
```

## .NET JavaScript interop on :::no-loc text="WASM":::

APIs in the following example are imported from `dotnet.js`. These APIs enable you to set up named modules that can be imported into your C# code and call into methods exposed by your .NET code, including `Program.Main`.

> [!IMPORTANT]
> "Import" and "export" throughout this article are defined from the perspective of .NET:
>
> * An app imports JS methods so that they can be called from .NET.
> * The app exports .NET methods so that they can be called from JS.

Function calls in the following example:

* `dotnet.create()` sets up the .NET WebAssembly runtime.
* `setModuleImports` creates the `window.location.href` function, which returns the current page address (URL). The import designates a module name, which must match the name used with the `JSImportAttribute` (explained later in this article). The following example uses the module name `main.js`, which is merely a convention for the example based on the filename `main.js`. The `window.location.href` function is imported into C# and called by the C# method `GetHRef`. The `GetHRef` method is shown later in this section.
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

document.getElementById("out").innerHTML = `${text}`;
await runMainAndExit(config.mainAssemblyName, ["dotnet", "is", "great!"]);
```

> [!NOTE]
> You can inspect the .NET host builder APIs at the [`dotnet/runtime` GitHub repository](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/runtime/). The runtime configuration is in the [`dotnet.d.ts` file](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/runtime/dotnet.d.ts).
>
> The preceding link to the .NET reference source loads the repository's default branch (`main`), which represents the current development for the next release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list.

To import a JS function so it can be called from C#, use the new `JSImportAttribute` on a matching method signature. The first parameter to the `JSImportAttribute` is the name of the JS function to import and the second parameter is the name of the module.

In the following example, the `window.location.href` function is called from the `main.js` module when `GetHRef` method is called. In an app generated from either the `wasmbrowser` or `wasmconsole` templates, `GetHRef` is in `Program.cs` with the partial class namespace `MyClass`:

```csharp
[JSImport("window.location.href", "main.js")]
internal static partial string GetHRef();
```

In the imported method signature, you can use .NET types for parameters and return values, which are marshalled automatically by the runtime. Use `JSMarshalAsAttribute<T>` to control how the imported method parameters are marshalled. For example, you might choose to marshal a `long` as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>. You can pass <xref:System.Action>/<xref:System.Func%601> callbacks as parameters, which are marshalled as callable JS functions. You can pass both JS and managed object references, and they are marshaled as proxy objects, keeping the object alive across the boundary until the proxy is garbage collected. You can also import and export asynchronous methods with a <xref:System.Threading.Tasks.Task> result, which are marshaled as [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise). Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods.

<!--
    NOTE

    I'll leave it in this plain format for reviews, which is easier to inspect.
    Before merging, I'll make the table WCAG compliant. 

-->

The following table indicates the supported type mappings.

| .NET                        | JavaScript   | `Nullable` | `Task`➔`Promise` | `JSMarshalAs` optional | :::no-loc text="Array of"::: |
| --------------------------- | ------------ | :--------: | :---------------: | :--------------------: | :-----: |
| `Boolean`                   | `Boolean`    | ✅        | ✅                | ✅                    | |
| `Byte`                      | `Number`     | ✅        | ✅                | ✅                    | ✅ |
| `Char`                      | `String`     | ✅        | ✅                | ✅                    | |
| `Int16`                     | `Number`     | ✅        | ✅                | ✅                    | |
| `Int32`                     | `Number`     | ✅        | ✅                | ✅                    | ✅ |
| `Int64`                     | `Number`     | ✅        | ✅                |                        | |
| `Int64`                     | `BigInt`     | ✅        | ✅                |                        | |
| `Single`                    | `Number`     | ✅        | ✅                | ✅                    | |
| `Double`                    | `Number`     | ✅        | ✅                | ✅                    | ✅ |
| `IntPtr`                    | `Number`     | ✅        | ✅                | ✅                    | |
| `DateTime`                  | `Date`       | ✅        | ✅                |                        | |
| `DateTimeOffset`            | `Date`       | ✅        | ✅                |                        | |
| `Exception`                 | `Error`      |            | ✅                | ✅                    | |
| `JSObject`                  | `Object`     |            | ✅                | ✅                    | ✅ |
| `String`                    | `String`     |            | ✅                | ✅                    | ✅ |
| `Object`                    | `Any`        |            | ✅                |                       | ✅ |
| `Span<Byte>`                | `MemoryView` |            |                   |                        | |
| `Span<Int32>`               | `MemoryView` |            |                   |                        | |
| `Span<Double>`              | `MemoryView` |            |                   |                        | |
| `ArraySegment<Byte>`        | `MemoryView` |            |                   |                        | |
| `ArraySegment<Int32>`       | `MemoryView` |            |                   |                        | |
| `ArraySegment<Double>`      | `MemoryView` |            |                   |                        | |
| `Task`                      | `Promise`    |            |                   | ✅                    | |
| `Action`                    | `Function`   |            |                   |                        | |
| `Action<T1>`                | `Function`   |            |                   |                        | |
| `Action<T1, T2>`            | `Function`   |            |                   |                        | |
| `Action<T1, T2, T3>`        | `Function`   |            |                   |                        | |
| `Func<TResult>`             | `Function`   |            |                   |                        | |
| `Func<T1, TResult>`         | `Function`   |            |                   |                        | |
| `Func<T1, T2, TResult>`     | `Function`   |            |                   |                        | |
| `Func<T1, T2, T3, TResult>` | `Function`   |            |                   |                        | |

The following conditions apply to type mapping and marshalled values:

* The :::no-loc text="Array of"::: column indicates if the .NET type can be marshalled as a JS [`Array`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Array). Example: C# `int[]` (`Int32`) mapped to JS `Array` of `Number`s.
* When passing a JS value to C# with a value of the wrong type, the framework throws an exception in most cases. The framework doesn't perform compile-time type checking in JS.
* `JSObject`, `Exception`, `Task` and `ArraySegment` create `GCHandle` and a proxy. You can trigger disposal in developer code or allow [.NET garbage collection (GC)](/dotnet/standard/garbage-collection/) to dispose of the objects later. These types carry significant performance overhead.
* `MemoryView`
  * `MemoryView` is a .NET type, not a native JS type. It's API is described in the [`dotnet.d.ts` file (`dotnet/runtime` GitHub repository)&dagger;](https://github.com/dotnet/runtime/blob/main/src/mono/wasm/runtime/dotnet.d.ts).
  * Bytes aren't copied during marshalling.
  * `MemoryView` created for a `Span` is only valid for the duration of the interop call.
  * `MemoryView` created for an `ArraySegment` survives after the interop call and is useful for sharing a buffer.
  * `MemoryView` doesn't have an analogous JS type, so marshalling a JS object to a .NET `MemoryView` isn't possible.
* It's not possible to export a .NET method that returns a `Span`. The `Span` is allocated on the call stack and has GC implications. When calling from JS to .NET, there's no C# stack after the call.
* For an exported method that returns an `ArraySegment`, calling `dispose()` in `try-finally` block disposes the proxy and unpins the underlying C# byte array. We recommend calling `dispose()` on the object in developer JS code. If developer code doesn't dispose of the object, the JS GC eventually disposes the object. You can also marshal a byte array (`byte[]`) instead of an `ArraySegment`, which copies the bytes.

&dagger;The link to the `dotnet.d.ts` file in the .NET reference source loads the repository's default branch (`main`), which represents the current development for the next release of .NET. To select a tag for a specific release, use the **Switch branches or tags** dropdown list.

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

The `dotnet.js` file is used to create and start the .NET WebAssembly runtime. `dotnet.js` is generated as part of the build output of the app and found in the `AppBundle` folder:

> :::no-loc text="bin/{BUILD CONFIGURATION}/{TARGET FRAMEWORK}/browser-wasm/AppBundle":::

The `{BUILD CONFIGURATION}` placeholder is the build configuration, and the `{TARGET FRAMEWORK}` placeholder is the target framework.

To integrate with an existing app, copy the contents of the `AppBundle` folder so that it can be served along with the rest of the app. For production deployments, publish the app with the `dotnet publish -c Release` command in a command shell and deploy the `AppBundle` folder with the app.

In the following example, the app contains an HTML file (`.htm`/`.html`) that loads a JS file (`.js`), which imports `dotnet.js` and starts the .NET runtime:

```javascript
import { dotnet } from './dotnet.js'

await dotnet.run();
```

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
