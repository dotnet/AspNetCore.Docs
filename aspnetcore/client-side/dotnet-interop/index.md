---
title: JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly
author: pavelsavara
description: Learn how to run .NET from JavaScript with [JSImport]/[JSExport] interop.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/08/2024
uid: client-side/dotnet-interop/index
---
# JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Aaron Shumaker](https://github.com/SerratedSharp)

This article explains how to interact with JavaScript (JS) in client-side WebAssembly using JS `[JSImport]`/`[JSExport]` interop (<xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> API).

`[JSImport]`/`[JSExport]` interop is applicable when running a .NET WebAssembly module in a JS host in the following scenarios:

* <xref:client-side/dotnet-interop/wasm-browser-app>.
* <xref:blazor/js-interop/import-export-interop>.
* Other .NET WebAssembly platforms that support `[JSImport]`/`[JSExport]` interop.

## Prerequisites

[.NET SDK (latest version)](https://dotnet.microsoft.com/download/dotnet/)

Any of the following project types:

* A WebAssembly Browser App project created according to <xref:client-side/dotnet-interop/wasm-browser-app>.
* A Blazor client-side project created according to <xref:blazor/js-interop/import-export-interop>.
* A project created for a commercial or open-source platform that supports `[JSImport]`/`[JSExport]` interop (<xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> API).

:::moniker range=">= aspnetcore-8.0"

## Sample app

[View or download sample code](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps)): Select an 8.0 or later version folder that matches the version of .NET that you're adopting. Within the version folder, access the sample named `WASMBrowserAppImportExportInterop`.

:::moniker-end

## JS interop using `[JSImport]`/`[JSExport]` attributes

The `[JSImport]` attribute is applied to a .NET method to indicate that a corresponding JS method should be called when the .NET method is called. This allows .NET developers to define "imports" that enable .NET code to call into JS. Additionally, an <xref:System.Action> can be passed as a parameter, and JS can invoke the action to support a callback or event subscription pattern.

The `[JSExport]` attribute is applied to a .NET method to expose it to JS code. This allows JS code to initiate calls to the .NET method.

## Importing JS methods

The following example imports a standard built-in JS method (`console.log`) into C#. `[JSImport]` is limited to importing methods of globally-accessible objects. For example, `log` is a method defined on the `console` object, which is defined on the globally-accessible object `globalThis`. The `console.log` method is mapped to a C# proxy method, `ConsoleLog`, which accepts a string for the log message:

```csharp
public partial class GlobalInterop
{
    [JSImport("globalThis.console.log")]
    public static partial void ConsoleLog(string text);
}
```

In `Program.Main`, `ConsoleLog` is called with the message to log:

```csharp
GlobalInterop.ConsoleLog("Hello World!");
```

The output appears in the browser's console.

The following demonstrates importing a method declared in JS.

The following custom JS method (`globalThis.callAlert`) spawns an [alert dialog (`window.alert`)](https://developer.mozilla.org/docs/Web/API/Window/alert) with the message passed in `text`:

```javascript
globalThis.callAlert = function (text) {
  globalThis.window.alert(text);
}
```

The `globalThis.callAlert` method is mapped to a C# proxy method (`CallAlert`), which accepts a string for the message:

```csharp
using System.Runtime.InteropServices.JavaScript;

public partial class GlobalInterop
{
	[JSImport("globalThis.callAlert")]
	public static partial void CallAlert(string text);
}
```

In `Program.Main`, `CallAlert` is called, passing the text for the alert dialog message:

```csharp
GlobalInterop.CallAlert("Hello World");
```

The C# class declaring the `[JSImport]` method doesn't have an implementation. At compile time, a source-generated partial class contains the .NET code that implements the marshalling of the call and types to invoke the corresponding JS method. In Visual Studio, using the **Go To Definition** or **Go To Implementation** options respectively navigates to either the source-generated partial class or the developer-defined partial class.

In the preceding example, the intermediate `globalThis.callAlert` JS declaration is used to wrap existing JS code. This article informally refers to the intermediate JS declaration as a *JS shim*. JS shims fill the gap between the .NET implementation and existing JS capabilities/libraries. In many cases, such as the preceding trivial example, the JS shim isn't necessary, and methods could be imported directly, as demonstrated in the earlier `ConsoleLog` example. As this article demonstrates in the upcoming sections, a JS shim can:

* Encapsulate additional logic.
* Manually map types.
* Reduce the number of objects or calls crossing the interop boundary.
* Manually map static calls to instance methods.

## Loading JavaScript declarations

JS declarations which are intended to be imported with `[JSImport]` are typically loaded in the context of the same page or JS host that loaded .NET WebAssembly. This can be accomplished with:

* A `<script>...</script>` block declaring inline JS.
* A script source (`src`) declaration (`<script src="./some.js"></script>`) that loads an external JS file (`.js`).
* A JS ES6 module (`<script type='module' src="./moduleName.js"></script>`).
* A JS ES6 module loaded using <xref:System.Runtime.InteropServices.JavaScript.JSHost.ImportAsync%2A?displayProperty=nameWithType> from .NET WebAssembly.

Examples in this article use <xref:System.Runtime.InteropServices.JavaScript.JSHost.ImportAsync%2A?displayProperty=nameWithType>. When calling <xref:System.Runtime.InteropServices.JavaScript.JSHost.ImportAsync%2A>, client-side .NET WebAssembly requests the file using the `moduleUrl` parameter, and thus it expects the file to be accessible as a static web asset, much the same way as a `<script>` tag retrieves a file with a `src` URL. For example, the following C# code within a WebAssembly Browser App project maintains the JS file (`.js`) at the path `/wwwroot/scripts/ExampleShim.js`:

```csharp
await JSHost.ImportAsync("ExampleShim", "/scripts/ExampleShim.js");
```

Depending on the platform that's loading WebAssembly, a dot-prefixed URL, such as `./scripts/`, might refer to an incorrect subdirectory, such as `/_framework/scripts/`, because the WebAssembly package is initialized by framework scripts under `/_framework/`. In that case, prefixing the URL with `../scripts/` refers to the correct path. Prefixing with `/scripts/` works if the site is hosted at the root of the domain. A typical approach involves configuring the correct base path for the given environment with an HTML `<base>` tag and using the `/scripts/` prefix to refer to the path relative to the base path. Tilde notation `~/` prefixes aren't supported by <xref:System.Runtime.InteropServices.JavaScript.JSHost.ImportAsync%2A?displayProperty=nameWithType>.

> [!IMPORTANT] 
> If JS is loaded from a JavaScript module, then `[JSImport]` attributes must include the module name as the second parameter. For example, `[JSImport("globalThis.callAlert", "ExampleShim")]` indicates the imported method was declared in a JavaScript module named "`ExampleShim`."

## Type mappings

Parameters and return types in the .NET method signature are automatically converted to or from appropriate JS types at runtime if a unique mapping is supported. This may result in values converted by value or references wrapped in a proxy type. This process is known as *type marshalling*. Use <xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601> to control how the imported method parameters and return types are marshalled. 

Some types don't have a default type mapping. For example, a `long` can be marshalled as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType>, so the <xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601> is required to avoid a compile-time error. 

The following type mapping scenarios are supported:

* Passing <xref:System.Action> or <xref:System.Func%601> as parameters, which are are marshalled as callable JS methods. This allows .NET code to invoke listeners in response to JS callbacks or events.
* Passing JS references and .NET managed object references in either direction, which as marshaled as proxy objects and kept alive across the interop boundary until the proxy is garbage collected.
* Marshalling asynchronous JS methods or a [JS `Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) with a <xref:System.Threading.Tasks.Task> result, and vice versa. 

Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods. 

The following table indicates the supported type mappings.

| .NET | JavaScript | `Nullable` | `Task` <span aria-hidden="true">➔</span><span class="visually-hidden">to</span> `Promise` | `JSMarshalAs` optional | `Array of` |
| --- | --- | :---: | :---: | :---: | :---: |
| `Boolean` | `Boolean` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `Byte` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `Char` | `String` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `Int16` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `Int32` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `Int64` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Int64` | `BigInt` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Single` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `Double` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `IntPtr` | `Number` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `DateTime` | `Date` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `DateTimeOffset` | `Date` | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Exception` | `Error` | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `JSObject` | `Object` | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `String` | `String` | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `Object` | `Any` | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> |
| `Span<Byte>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Span<Int32>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Span<Double>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `ArraySegment<Byte>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `ArraySegment<Int32>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `ArraySegment<Double>` | `MemoryView` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Task` | `Promise` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span aria-hidden="true">✅</span><span class="visually-hidden">Supported</span> | <span class="visually-hidden">Not supported</span> |
| `Action` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Action<T1>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Action<T1, T2>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Action<T1, T2, T3>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Func<TResult>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Func<T1, TResult>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Func<T1, T2, TResult>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |
| `Func<T1, T2, T3, TResult>` | `Function` | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> | <span class="visually-hidden">Not supported</span> |

The following conditions apply to type mapping and marshalled values:

* The `Array of` column indicates if the .NET type can be marshalled as a JS [`Array`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Array). Example: C# `int[]` (`Int32`) mapped to JS `Array` of `Number`s.
* When passing a JS value to C# with a value of the wrong type, the framework throws an exception in most cases. The framework doesn't perform compile-time type checking in JS.
* `JSObject`, `Exception`, `Task` and `ArraySegment` create `GCHandle` and a proxy. You can trigger disposal in developer code or allow [.NET garbage collection (GC)](/dotnet/standard/garbage-collection/) to dispose of the objects later. These types carry significant performance overhead.
* `Array`: Marshaling an array creates a copy of the array in JS or .NET.
* `MemoryView`
  * `MemoryView` is a JS class for the .NET WebAssembly runtime to marshal `Span` and `ArraySegment`.
  * Unlike marshaling an array, marshaling a `Span` or `ArraySegment` doesn't create a copy of the underlying memory.
  * `MemoryView` can only be properly instantiated by the .NET WebAssembly runtime. Therefore, it isn't possible to import a JS method as a .NET method that has a parameter of `Span` or `ArraySegment`.
  * `MemoryView` created for a `Span` is only valid for the duration of the interop call. As `Span` is allocated on the call stack, which doesn't persist after the interop call, it isn't possible to export a .NET method that returns a `Span`.
  * `MemoryView` created for an `ArraySegment` survives after the interop call and is useful for sharing a buffer. Calling `dispose()` on a `MemoryView` created for an `ArraySegment` disposes the proxy and unpins the underlying .NET array. We recommend calling `dispose()` in a `try-finally` block for `MemoryView`.

Some combinations of type mappings that require nested generic types in [`JSMarshalAs`](xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601) aren't currently supported. For example, attempting to materialize an array from a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) such as `[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]` generates a compile-time error. An appropriate workaround varies depending on the scenario, but this specific scenario is further explored in the [Type mapping limitations](#type-mapping-limitations) section.

## JS primitives

The following example demonstrates `[JSImport]` leveraging type mappings of several primitive JS types and the use of [`JSMarshalAs`](xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601), where explicit mappings are required at compile time.

`PrimitivesShim.js`:

:::code language="javascript" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/wwwroot/PrimitivesShim.js":::

`PrimitivesInterop.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/PrimitivesInterop.cs":::

In `Program.Main`:

```csharp
await PrimitivesUsage.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Printed from JSImport of console.log()":::  
> :::no-loc text="1":::  
> :::no-loc text="I'm a string from .NET in your browser!":::  
> :::no-loc text="boolean true":::  
> :::no-loc text="number 58":::  
> :::no-loc text="number 67":::  
> :::no-loc text="number 12":::  
> :::no-loc text="number 9007199254740990":::  
> :::no-loc text="bigint 1234567890123456789n":::  
> :::no-loc text="number 3.140000104904175":::  
> :::no-loc text="number 3.14":::  
> :::no-loc text="string A string":::

## JS `Date` objects

The example in this section demonstrates importing methods which have a [JS `Date`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Date) object as its return or parameter. Dates are marshalled across interop by-value, meaning they are copied in much the same way as JS primitives.

A `Date` object is timezone agnostic. A .NET <xref:System.DateTime> is adjusted relative to its <xref:System.DateTimeKind> when marshalled to a `Date`, but timezone information isn't preserved. Consider initializing a <xref:System.DateTime> with a <xref:System.DateTimeKind.Utc?displayProperty=nameWithType> or <xref:System.DateTimeKind.Local?displayProperty=nameWithType> consistent with the value it represents.

`DateShim.js`:

:::code language="javascript" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/wwwroot/DateShim.js":::

`DateInterop.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/DateInterop.cs":::

In `Program.Main`:

```csharp
await DateUsage.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Date: Sat Dec 21 1968 07:51:00 GMT-0500 (Eastern Standard Time)":::  
> :::no-loc text="Date: Sun Dec 22 1968 07:51:00 GMT-0500 (Eastern Standard Time)":::

The preceding timezone information (`GMT-0500 (Eastern Standard Time)`) depends on local timezone of your computer/browser.

## JS object references

Whenever a JS method returns an object reference, it's represented in .NET as a <xref:System.Runtime.InteropServices.JavaScript.JSObject>. The original JS object continues its lifetime within the JS boundary, while .NET code can access and modify it by reference through the <xref:System.Runtime.InteropServices.JavaScript.JSObject>. While the type itself exposes a limited API, the ability to hold a JS object reference and return or pass it across the interop boundary enables support for several interop scenarios.

The <xref:System.Runtime.InteropServices.JavaScript.JSObject> provides methods to access properties, but it doesn't provide direct access to instance methods. As the following `Summarize` method demonstrates, instance methods can be accessed indirectly by implementing a static method that takes the instance as a parameter.

`JSObjectShim.js`:

:::code language="javascript" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/wwwroot/JSObjectShim.js":::

`JSObjectInterop.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/JSObjectInterop.cs":::

In `Program.Main`:

```csharp
await JSObjectUsage.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="{name: 'Example JS Object', answer: 41, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="{name: 'Example JS Object', answer: 42, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="{name: 'Example JS Object', answer: 42, question: 'What is the answer?', Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="Summary: Question: \"What is the answer?\" Answer: 42":::

## Asynchronous interop

Many JS APIs are asynchronous and signal completion through either a callback, a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), or an async method. Ignoring asynchronous capabilities is often not an option, as subsequent code may depend upon the completion of the asynchronous operation and must be awaited.

JS methods using the `async` keyword or returning a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) can be awaited in C# by a method returning a <xref:System.Threading.Tasks.Task>. As demonstrated below, the `async` keyword isn't used on the C# method with the `[JSImport]` attribute because it doesn't use the `await` keyword within it. However, consuming code calling the method would typically use the `await` keyword and be marked as `async`, as demonstrated in the `PromisesUsage` example.

JS with a callback, such as a `setTimeout`, can be wrapped in a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) before returning from JS. Wrapping a callback in a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), as demonstrated in the function assigned to `Wait2Seconds`, is only appropriate when the callback is called exactly once. Otherwise, a C# <xref:System.Action> can be passed to listen for a callback that may be called zero or many times, which is demonstrated in the [Subscribing to JS events](#subscribing-to-js-events) section.

`PromisesShim.js`:

:::code language="javascript" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/wwwroot/PromisesShim.js":::

Don't use the `async` keyword in the C# method signature. Returning <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> is sufficient.

When calling asynchronous JS methods, we often want to wait until the JS method completes execution. If loading a resource or making a request, we likely want the following code to assume the action is completed.

If the JS shim returns a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), then C# can treat it as an awaitable <xref:System.Threading.Tasks.Task>/<xref:System.Threading.Tasks.Task%601>.

`PromisesInterop.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/PromisesInterop.cs":::

In `Program.Main`:

```csharp
await PromisesUsage.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Waited 2.0s.":::  
> :::no-loc text="Waited .5s for WaitGetString: 'String From Resolve'":::  
> :::no-loc text="Waited .5s for WaitGetDate: '11/24/1988 12:00:00 AM'":::  
> :::no-loc text="responseText.Length: 582":::  
> :::no-loc text="Waited 2.0s for AsyncFunction.":::  
> :::no-loc text="JS Exception Caught: 'Reject: ShouldSucceed == false'":::

## Type mapping limitations

Some type mappings requiring nested generic types in the [`JSMarshalAs`](xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601) definition aren't currently supported. For example, returning a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) for an array such as `[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]` generates a compile-time error. An appropriate workaround varies depending on the scenario, but one option is to represent the array as a <xref:System.Runtime.InteropServices.JavaScript.JSObject> reference. This may be sufficient if accessing individual elements within .NET isn't necessary and the reference can be passed to other JS methods that act on the array. Alternatively, a dedicated method can take the <xref:System.Runtime.InteropServices.JavaScript.JSObject> reference as a parameter and return the materialized array, as demonstrated by the following `UnwrapJSObjectAsIntArray` example. In this case, the JS method has no type checking, and the developer has the responsibility to ensure a <xref:System.Runtime.InteropServices.JavaScript.JSObject> wrapping the appropriate array type is passed.

```javascript
export function waitGetIntArrayAsObject() {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve([1, 2, 3, 4, 5]); // Return an array from the Promise
    }, 500);
  });
}

export function unwrapJSObjectAsIntArray(jsObject) {
  return jsObject;
}
```

```csharp
// Not supported, generates compile-time error.
// [JSImport("waitGetArray", "PromisesShim")]
// [return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]
// public static partial Task<int[]> WaitGetIntArray();

// Workaround, take the return the call and pass it to UnwrapJSObjectAsIntArray.
// Return a JSObject reference to a JS number array.
[JSImport("waitGetIntArrayAsObject", "PromisesShim")]
[return: JSMarshalAs<JSType.Promise<JSType.Object>>()]
public static partial Task<JSObject> WaitGetIntArrayAsObject();

// Takes a JSObject reference to a JS number array, and returns the array as a C# 
// int array.
[JSImport("unwrapJSObjectAsIntArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Array<JSType.Number>>()]
public static partial int[] UnwrapJSObjectAsIntArray(JSObject intArray);
//...
```

In `Program.Main`:

```csharp
JSObject arrayAsJSObject = await PromisesInterop.WaitGetIntArrayAsObject();
int[] intArray = PromisesInterop.UnwrapJSObjectAsIntArray(arrayAsJSObject);
```

## Performance considerations

Marshalling of calls and the overhead of tracking objects across the interop boundary is more expensive than native .NET operations but should still demonstrate acceptable performance for a typical web app with moderate demand.

Object proxies, such as <xref:System.Runtime.InteropServices.JavaScript.JSObject>, which maintain references across the interop boundary, have additional memory overhead and impact how garbage collection affects these objects. Additionally, available memory might be exhausted without triggering garbage collection in some scenarios because memory pressure from JS and .NET isn't shared. This risk is significant when an excessive number of large objects are referenced across the interop boundary by relatively small JS objects, or vice versa where large .NET objects are referenced by JS proxies. In such cases, we recommend following deterministic disposal patterns with `using` scopes leveraging the <xref:System.IDisposable> interface on JS objects.

The following benchmarks, which leverage earlier example code, demonstrate that interop operations are roughly an order of magnitude slower than those that remain within the .NET boundary, but the interop operations remain relatively fast. Additionally, consider that a user's device capabilities impact performance.

`JSObjectBenchmark.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/JSObjectBenchmark.cs":::

In `Program.Main`:

```csharp
JSObjectBenchmark.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="JS interop elapsed time: .2536 seconds at .000254 ms per operation":::  
> :::no-loc text=".NET elapsed time: .0210 seconds at .000021 ms per operation":::  
> :::no-loc text="Begin Object Creation":::  
> :::no-loc text="JS interop elapsed time: 2.1686 seconds at .002169 ms per operation":::  
> :::no-loc text=".NET elapsed time: .1089 seconds at .000109 ms per operation":::

## Subscribing to JS events

.NET code can subscribe to JS events and handle JS events by passing a C# <xref:System.Action> to a JS function to act as a handler. The JS shim code handles subscribing to the event.

> [!WARNING]
> Interacting with individual properties of the DOM via JS interop, as the guidance in this section demonstrates, is relatively slow and may lead to the creation of many proxies that create high garbage collection pressure. The following pattern isn't generally recommended. Use the following pattern for no more than a few elements. For more information, see the [Performance considerations](#performance-considerations) section.

A nuance of `removeEventListener` is that it requires a reference to the function previously passed to `addEventListener`. When a C# <xref:System.Action> is passed across the interop boundary, it's wrapped in a JS proxy object. Therefore, passing the same C# <xref:System.Action> to both `addEventListener` and `removeEventListener` results in generating two different JS proxy objects wrapping the <xref:System.Action>. These references are different, thus `removeEventListener` isn't able to find the event listener to remove. To address this problem, the following examples wrap the C# <xref:System.Action> in a JS function and return the reference as a <xref:System.Runtime.InteropServices.JavaScript.JSObject> from the subscribe call to pass later to the unsubscribe call. Because the C# <xref:System.Action> is returned and passed as a <xref:System.Runtime.InteropServices.JavaScript.JSObject>, the same reference is used for both calls, and the event listener can be removed.

`EventsShim.js`:

:::code language="javascript" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/wwwroot/EventsShim.js":::

`EventsInterop.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/WASMBrowserAppImportExportInterop/EventsInterop.cs":::

In `Program.Main`:

```csharp
await EventsUsage.Run();
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Subscribed to btn1 & 2.":::  
> :::no-loc text="In C# event listener: Event click from ID btn1":::  
> :::no-loc text="In C# event listener: Event click from ID btn2":::  
> :::no-loc text="Unsubscribed btn2.":::  
> :::no-loc text="In C# event listener: Event click from ID btn1":::  
> :::no-loc text="Subscribed to btn1.":::  
> :::no-loc text="In C# event listener: Event click from ID btn1":::  
> :::no-loc text="Unsubscribed btn1.":::

## JS `[JSImport]`/`[JSExport]` interop scenarios

The following articles focus on running a .NET WebAssembly module in a JS host, such as a browser:

* <xref:client-side/dotnet-interop/wasm-browser-app>
* <xref:blazor/js-interop/import-export-interop>
