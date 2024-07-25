---
title: JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly
author: pavelsavara
description: Learn how to run .NET from JavaScript with [JSImport]/[JSExport] interop.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/25/2024
uid: client-side/dotnet-interop/index
---
# JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Aaron Shumaker](https://github.com/SerratedSharp)

This article explains how to interact with JavaScript (JS) in client-side WebAssembly using JS `[JSImport]`/`[JSExport]` interop (<xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> API).

`[JSImport]`/`[JSExport]` interop is applicable when running a .NET WebAssembly module in a JS host:

* <xref:client-side/dotnet-interop/wasm-browser-app>
* <xref:blazor/js-interop/import-export-interop>
* Other .NET WebAssembly platforms that support `[JSImport]`/`[JSExport]` interop

## Prerequisites

[.NET SDK (latest version)](https://dotnet.microsoft.com/download/dotnet/)

Any of the following project types:

* A WebAssembly Browser App project created according to <xref:client-side/dotnet-interop/wasm-browser-app>.
* A Blazor client-side project created according to <xref:blazor/js-interop/import-export-interop>.
* A project created for a commercial or open-source platform that supports `[JSImport]`/`[JSExport]` interop (<xref:System.Runtime.InteropServices.JavaScript?displayProperty=fullName> API).

## JS interop using `[JSImport]`/`[JSExport]` attributes

The `[JSImport]` attribute is applied to a .NET method to indicate that a corresponding JS method should be called when the .NET method is called. This allows .NET developers to define "imports" that enable .NET code to call into JS. Additionally, an <xref:System.Action> can be passed as a parameter, and JS can invoke the action to support a callback or event subscription pattern.

The `[JSExport]` attribute is applied to a .NET method to expose it to JS code. This allows JS code to initiate calls to the .NET method.

## Importing JS methods

The following example imports an existing static JS method (`console.log`) into C#. `[JSImport]` is limited to importing static methods or instance methods of globally-accessible objects. For example, `log` is an instance method of the `console` object, but it can be accessed using static semantics because the instance is a globally-accessible singleton. The `console.log` method is mapped to a C# proxy method, `ConsoleLog`, which accepts a string for the log message:

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

The following demonstrates importing a static method declared in JS.

The following custom static method (`globalThis.callAlert`) spawns an [alert dialog (`window.alert`)](https://developer.mozilla.org/docs/Web/API/Window/alert) with the message passed in `text`:

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
> If JS is loaded from an ES6 module, then `[JSImport]` attributes must include the module name as the second parameter. For example, `[JSImport("globalThis.callAlert", "ExampleShim")]` indicates the imported method was declared in an ES6 module named "`ExampleShim`."

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

```javascript
let PrimitivesShim = {};

(function (PrimitivesShim) {

  globalThis.counter = 0;

  // Takes no parameters and returns nothing.
  PrimitivesShim.IncrementCounter = function () {
    globalThis.counter += 1;
  };

  // Returns an int.
  PrimitivesShim.GetCounter = () => globalThis.counter;
  // Identical result with more verbose syntax:
  // Primitives.GetCounter = function () { return counter; };

  // Takes a parameter and returns nothing. JS doesn't restrict the parameter type, 
  // but we can restrict it in the .NET proxy, if desired.
  PrimitivesShim.LogValue = (value) => { console.log(value); };

  // Called for various .NET types to demonstrate mapping to JS primitive types.
  PrimitivesShim.LogValueAndType = (value) => { console.log(typeof value, value); };

})(PrimitivesShim);

export { PrimitivesShim };
```

`PrimitivesShim.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class PrimitivesInterop
{
    // Importing an existing JS method.
    [JSImport("globalThis.console.log")]
    public static partial void ConsoleLog([JSMarshalAs<JSType.Any>] object value);

    // Importing static methods from a JS module.
    [JSImport("PrimitivesShim.IncrementCounter", "PrimitivesShim")]
    public static partial void IncrementCounter();

    [JSImport("PrimitivesShim.GetCounter", "PrimitivesShim")]
    public static partial int GetCounter();

    // The JS shim method name isn't required to match the C# method name.
    [JSImport("PrimitivesShim.LogValue", "PrimitivesShim")]
    public static partial void LogInt(int value);

    // A second mapping to the same JS method with compatible type.
    [JSImport("PrimitivesShim.LogValue", "PrimitivesShim")]
    public static partial void LogString(string value);

    // Accept any type as parameter. .NET types are mapped to JS types where 
    // possible. Otherwise, they're marshalled as an untyped object reference 
    // to the .NET object proxy. The JS implementation logs to browser console 
    // the JS type and value to demonstrate results of marshalling.
    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndType([JSMarshalAs<JSType.Any>] object value);

    // Some types have multiple mappings and require explicit marshalling to the 
    // desired JS type. A long/Int64 can be mapped as either a Number or BigInt.
    // Passing a long value to the above method generates an error at runtime:
    // "ToJS for System.Int64 is not implemented."
    // If the parameter declaration `Method(JSMarshalAs<JSType.Any>] long value)` 
    // is used, a compile-time error is generated:
    // "Type long is not supported by source-generated JS interop...."
    // Instead, explicitly map the long parameter to either a JSType.Number or 
    // JSType.BigInt. Note that runtime overflow errors are possible in JS if the 
    // C# value is too large.
    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndTypeForNumber([JSMarshalAs<JSType.Number>] long value);

    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndTypeForBigInt([JSMarshalAs<JSType.BigInt>] long value);
}

public static class PrimitivesUsage
{
    public static async Task Run()
    {
        // Ensure JS ES6 module loaded.
        await JSHost.ImportAsync("PrimitivesShim", "/PrimitivesShim.js");

        // Call a proxy to a static JS method, console.log().
        PrimitivesInterop.ConsoleLog("Printed from JSImport of console.log()");

        // Basic examples of JS interop with an integer.
        PrimitivesInterop.IncrementCounter();
        int counterValue = PrimitivesInterop.GetCounter();
        PrimitivesInterop.LogInt(counterValue);
        PrimitivesInterop.LogString("I'm a string from .NET in your browser!");

        // Mapping some other .NET types to JS primitives.
        PrimitivesInterop.LogValueAndType(true);
        PrimitivesInterop.LogValueAndType(0x3A); // Byte literal
        PrimitivesInterop.LogValueAndType('C');
        PrimitivesInterop.LogValueAndType((Int16)12);
        // JS Number has a lower max value and can generate overflow errors.
        PrimitivesInterop.LogValueAndTypeForNumber(9007199254740990L); // Int64/Long
        // Next line: Int64/Long, JS BigInt supports larger numbers.
        PrimitivesInterop.LogValueAndTypeForBigInt(1234567890123456789L);// 
        PrimitivesInterop.LogValueAndType(3.14f); // Single floating point literal
        PrimitivesInterop.LogValueAndType(3.14d); // Double floating point literal
        PrimitivesInterop.LogValueAndType("A string");
    }
}
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

```javascript
let DateShim = {};

(function (DateShim) {

  DateShim.IncrementDay = function (date) {
    date.setDate(date.getDate() + 1);
    return date;
  };

  DateShim.LogValueAndType = (value) => {
    if (value instanceof Date) 
      console.log("Date:", value)
    else
      console.log("Not a Date:", value)
  };

})(DateShim);

export { DateShim };
```

`DateShim.cs`:

```csharp
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class DateInterop
{
    [JSImport("DateShim.IncrementDay", "DateShim")]
    [return: JSMarshalAs<JSType.Date>] // Explicit JSMarshalAs for a return type
    public static partial DateTime IncrementDay(
        [JSMarshalAs<JSType.Date>] DateTime date);

    [JSImport("DateShim.LogValueAndType", "DateShim")]
    public static partial void LogValueAndType(
        [JSMarshalAs<JSType.Date>] DateTime value);
}

public static class DateUsage
{
    public static async Task Run()
    {
        // Ensure JS ES6 module loaded.
        await JSHost.ImportAsync("DateShim", "/DateShim.js");

        // Basic examples of interop with a C# DateTime and JS Date.
        DateTime date = new DateTime(1968, 12, 21, 12, 51, 0, DateTimeKind.Utc);
        DateInterop.LogValueAndType(date);
        date = DateInterop.IncrementDay(date);
        DateInterop.LogValueAndType(date);
    }
}
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Date: Sat Dec 21 1968 07:51:00 GMT-0500 (Eastern Standard Time)":::  
> :::no-loc text="Date: Sun Dec 22 1968 07:51:00 GMT-0500 (Eastern Standard Time)":::

## JS object references

Whenever a JS method returns an object reference, it's represented in .NET as a <xref:System.Runtime.InteropServices.JavaScript.JSObject>. The original JS object continues its lifetime within the JS boundary, while .NET code can access and modify it by reference through the <xref:System.Runtime.InteropServices.JavaScript.JSObject>. While the type itself exposes a limited API, the ability to hold a JS object reference and return or pass it across the interop boundary enables support for several interop scenarios.

The <xref:System.Runtime.InteropServices.JavaScript.JSObject> provides methods to access properties, but it doesn't provide direct access to instance methods. As the following `Summarize` method demonstrates, instance methods can be accessed indirectly by implementing a static method that takes the instance as a parameter.

`JSObjectShim.js`:

```javascript
let JSObjectShim = {};

(function (JSObjectShim) {

  JSObjectShim.CreateObject = function () {
    return {
      name: "Example JS Object",
      answer: 41,
      question: null,
      summarize: function () {
        return `Question: "${this.question}" Answer: ${this.answer}`;
      }
    };
  };

  JSObjectShim.IncrementAnswer = function (object) {
    object.answer += 1;
    // Don't return the modified object, since the reference is modified.
  };

  // Proxy an instance method call.
  JSObjectShim.Summarize = function (object) {
    return object.summarize();
  };

})(JSObjectShim);

export { JSObjectShim };
```

`JSObjectShim.cs`:

```csharp
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class JSObjectInterop
{
    [JSImport("JSObjectShim.CreateObject", "JSObjectShim")]
    public static partial JSObject CreateObject();

    [JSImport("JSObjectShim.IncrementAnswer", "JSObjectShim")]
    public static partial void IncrementAnswer(JSObject jsObject);

    [JSImport("JSObjectShim.Summarize", "JSObjectShim")]
    public static partial string Summarize(JSObject jsObject);

    [JSImport("globalThis.console.log")]
    public static partial void ConsoleLog([JSMarshalAs<JSType.Any>] object value);
}

public static class JSObjectUsage
{
    public static async Task Run()
    {
        await JSHost.ImportAsync("JSObjectShim", "/JSObjectShim.js");

        JSObject jsObject = JSObjectInterop.CreateObject();
        JSObjectInterop.ConsoleLog(jsObject);
        JSObjectInterop.IncrementAnswer(jsObject);
        // An updated object isn't retrieved. The change is reflected in the 
        // existing instance.
        JSObjectInterop.ConsoleLog(jsObject);

        // JSObject exposes several methods for interacting with properties.
        jsObject.SetProperty("question", "What is the answer?");
        JSObjectInterop.ConsoleLog(jsObject);

        // We can't directly JSImport an instance method on the jsObject, but we 
        // can pass the object reference and have the JS shim call the instance 
        // method.
        string summary = JSObjectInterop.Summarize(jsObject);
        Console.WriteLine("Summary: " + summary);
    }
}
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="{name: 'Example JS Object', answer: 41, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="{name: 'Example JS Object', answer: 42, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="{name: 'Example JS Object', answer: 42, question: 'What is the answer?', Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}":::  
> :::no-loc text="Summary: Question: "What is the answer?" Answer: 42":::

## Asynchronous interop

Many JS APIs are asynchronous and signal completion through either a callback, a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), or an async method. Ignoring asynchronous capabilities is often not an option, as subsequent code may depend upon the completion of the asynchronous operation and must be awaited.

JS methods using the `async` keyword or returning a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) can be awaited in C# by a method returning a <xref:System.Threading.Tasks.Task>. As demonstrated below, the `async` keyword isn't used on the C# method with the `[JSImport]` attribute because it doesn't use the `await` keyword within it. However, consuming code calling the method would typically use the `await` keyword and be marked as `async`, as demonstrated in the `PromisesUsage` example.

JS with a callback, such as a `setTimeout`, can be wrapped in a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) before returning from JS. Wrapping a callback in a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), as demonstrated in the function assigned to `Wait2Seconds`, is only appropriate when the callback is called exactly once. Otherwise, a C# <xref:System.Action> can be passed to listen for a callback that may be called zero or many times, which is demonstrated in the [Subscribing to JS events](#subscribing-to-js-events) section.

`PromisesShim.js`:

```javascript
let PromisesShim = {};

(function (PromisesShim) {

  PromisesShim.Wait2Seconds = function () {
    // This also demonstrates wrapping a callback-based API in a promise to 
    // make it awaitable.
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(); // Resolve promise after 2 seconds
      }, 2000);
    });
  };

  // Return a value via resolve in a promise.
  PromisesShim.WaitGetString = function () {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve("String From Resolve"); // Return a string via promise
      }, 500);
    });
  };

  PromisesShim.WaitGetDate = function () {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(new Date('1988-11-24')) // Return a date via promise
      }, 500);
    });
  };

  // Demonstrates an awaitable fetch.
  PromisesShim.FetchCurrentUrl = function () {
    // This method returns the promise returned by .then(*.text())
    // and .NET awaits the returned promise.
    return fetch(globalThis.window.location, { method: 'GET' })
      .then(response => response.text());
  };

  // .NET can await JS methods using the async/await JS syntax.
  PromisesShim.AsyncFunction = async function () {
    await PromisesShim.Wait2Seconds();
  };

  // A Promise.reject can be used to signal failure and is bubbled to .NET code 
  // as a JSException.
  PromisesShim.ConditionalSuccess = function (shouldSucceed) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        if (shouldSucceed)
          resolve(); // Success
        else
          reject("Reject: ShouldSucceed == false"); // Failure
      }, 500);
    });
  };

})(PromisesShim);

export { PromisesShim };
```

Don't use the `async` keyword in the C# method signature. Returning <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task%601> is sufficient.

When calling asynchronous JS methods, we often want to wait until the JS method completes execution. If loading a resource or making a request, we likely want the following code to assume the action is completed.

If the JS shim returns a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise), then C# can treat it as an awaitable <xref:System.Threading.Tasks.Task>/<xref:System.Threading.Tasks.Task%601>.

`PromisesShim.cs`:

```csharp
using System;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class PromisesInterop
{
    // For a promise with void return type, declare a Task return type:
    [JSImport("PromisesShim.Wait2Seconds", "PromisesShim")]
    public static partial Task Wait2Seconds();

    [JSImport("PromisesShim.WaitGetString", "PromisesShim")]
    public static partial Task<string> WaitGetString();

    // Some return types require a [return: JSMarshalAs...] declaring the
    // Promise's return type corresponding to Task<T>.
    [JSImport("PromisesShim.WaitGetDate", "PromisesShim")]
    [return: JSMarshalAs<JSType.Promise<JSType.Date>>()]
    public static partial Task<DateTime> WaitGetDate();

    [JSImport("PromisesShim.FetchCurrentUrl", "PromisesShim")]
    public static partial Task<string> FetchCurrentUrl();

    [JSImport("PromisesShim.AsyncFunction", "PromisesShim")]
    public static partial Task AsyncFunction();

    [JSImport("PromisesShim.ConditionalSuccess", "PromisesShim")]
    public static partial Task ConditionalSuccess(bool shouldSucceed);
}

public static class PromisesUsage
{
    public static async Task Run()
    {
        await JSHost.ImportAsync("PromisesShim", "/PromisesShim.js");

        Stopwatch sw = new Stopwatch();
        sw.Start();

        await PromisesInterop.Wait2Seconds(); // Await Promise
        Console.WriteLine($"Waited {sw.Elapsed.TotalSeconds:#.0}s.");

        sw.Restart();
        string str = 
            await PromisesInterop.WaitGetString(); // Await promise (string return)
        Console.WriteLine(
            $"Waited {sw.Elapsed.TotalSeconds:#.0}s for WaitGetString: '{str}'");

        sw.Restart();
        // Await promise with string return.
        DateTime date = await PromisesInterop.WaitGetDate();
        Console.WriteLine(
            $"Waited {sw.Elapsed.TotalSeconds:#.0}s for WaitGetDate: '{date}'");

        // Await a JS fetch.
        string responseText = await PromisesInterop.FetchCurrentUrl();
        Console.WriteLine($"responseText.Length: {responseText.Length}");

        sw.Restart();

        await PromisesInterop.AsyncFunction(); // Await an async JS method
        Console.WriteLine(
            $"Waited {sw.Elapsed.TotalSeconds:#.0}s for AsyncFunction.");

        try {
            // Handle a promise rejection. Await an async JS method.
            await PromisesInterop.ConditionalSuccess(shouldSucceed: false);
        }
        catch(JSException ex) // Catch JS exception
        {
            Console.WriteLine($"JS Exception Caught: '{ex.Message}'");
        }
    }
}
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="Waited 2.0s.":::  
> :::no-loc text="Waited .5s for WaitGetString: 'String From Resolve'":::  
> :::no-loc text="Waited .5s for WaitGetDate: '11/24/1988 12:00:00 AM'":::  
> :::no-loc text="responseText.Length: 582":::  
> :::no-loc text="Waited 2.0s for AsyncFunction.":::  
> :::no-loc text="JS Exception Caught: 'Reject: ShouldSucceed == false'":::

## Subscribing to JS events

.NET code can subscribe to JS events and handle JS events by passing a C# <xref:System.Action> to a JS function to act as a handler. The JS shim code handles subscribing to the event.

A nuance of `removeEventListener` is that it requires a reference to the function previously passed to `addEventListener`. When a C# <xref:System.Action> is passed across the interop boundary, it's wrapped in a JS proxy object. Therefore, passing the same C# <xref:System.Action> to both `addEventListener` and `removeEventListener` results in generating two different JS proxy objects wrapping the <xref:System.Action>. These references are different, thus `removeEventListener` isn't able to find the event listener to remove. To address this problem, the following examples wrap the C# <xref:System.Action> in a JS function and return the reference as a <xref:System.Runtime.InteropServices.JavaScript.JSObject> from the subscribe call to pass later to the unsubscribe call. Because the C# <xref:System.Action> is returned and passed as a <xref:System.Runtime.InteropServices.JavaScript.JSObject>, the same reference is used for both calls, and the event listener can be removed.

`EventShim.js`:

```javascript
let EventsShim = {};

(function (EventsShim) {

  EventsShim.SubscribeEventById = function (elementId, eventName, listenerFunc) {
    const elementObj = document.getElementById(elementId);

    // Need to wrap the Managed C# action in JS func (only because it is being 
    // returned).
    let handler = function (event) {
      listenerFunc(event.type, event.target.id); // Decompose object to primitives
    }.bind(elementObj);

    elementObj.addEventListener(eventName, handler, false);
    // Return JSObject reference so it can be used for removeEventListener later.
    return handler;
  }

  // Param listenerHandler must be the JSObject reference returned from the prior 
  // SubscribeEvent call.
  EventsShim.UnsubscribeEventById = function (elementId, eventName, listenerHandler) {
    const elementObj = document.getElementById(elementId);
    elementObj.removeEventListener(eventName, listenerHandler, false);
  }

  EventsShim.TriggerClick = function (elementId) {
    const elementObj = document.getElementById(elementId);
    elementObj.click();
  }

  EventsShim.GetElementById = function (elementId) {
    return document.getElementById(elementId);
  }

  EventsShim.SubscribeEvent = function (elementObj, eventName, listenerFunc) {
    let handler = function (e) {
      listenerFunc(e);
    }.bind(elementObj);

    elementObj.addEventListener(eventName, handler, false);
    return handler;
  }

  EventsShim.UnsubscribeEvent = function (elementObj, eventName, listenerHandler) {
    return elementObj.removeEventListener(eventName, listenerHandler, false);
  }

  EventsShim.SubscribeEventFailure = function (elementObj, eventName, listenerFunc) {
    // It's not strictly required to wrap the C# action listenerFunc in a JS 
    // function.
    elementObj.addEventListener(eventName, listenerFunc, false);
    // If you need to return the wrapped proxy object, you will receive an error 
    // when it tries to wrap the existing proxy in an additional proxy:
    // Error: "JSObject proxy of ManagedObject proxy is not supported."
    return listenerFunc;
  }

})(EventsShim);

export { EventsShim };
```

`EventsShim.cs`:

```csharp
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class EventsInterop
{
    [JSImport("EventsShim.SubscribeEventById", "EventsShim")]
    public static partial JSObject SubscribeEventById(string elementId, 
        string eventName, 
        [JSMarshalAs<JSType.Function<JSType.String, JSType.String>>] 
        Action<string, string> listenerFunc);

    [JSImport("EventsShim.UnsubscribeEventById", "EventsShim")]
    public static partial void UnsubscribeEventById(string elementId, 
        string eventName, JSObject listenerHandler);

    [JSImport("EventsShim.TriggerClick", "EventsShim")]
    public static partial void TriggerClick(string elementId);

    [JSImport("EventsShim.GetElementById", "EventsShim")]
    public static partial JSObject GetElementById(string elementId);

    [JSImport("EventsShim.SubscribeEvent", "EventsShim")]
    public static partial JSObject SubscribeEvent(JSObject htmlElement, 
        string eventName, 
        [JSMarshalAs<JSType.Function<JSType.Object>>] 
        Action<JSObject> listenerFunc);

    [JSImport("EventsShim.UnsubscribeEvent", "EventsShim")]
    public static partial void UnsubscribeEvent(JSObject htmlElement, 
        string eventName, JSObject listenerHandler);
}

public static class EventsUsage
{
    public static async Task Run()
    {
        await JSHost.ImportAsync("EventsShim", "/EventsShim.js");

        Action<string, string> listenerFunc = (eventName, elementId) =>
            Console.WriteLine(
                $"In C# event listener: Event {eventName} from ID {elementId}");

        JSObject listenerHandler1 = 
            EventsInterop.SubscribeEventById("btn1", "click", listenerFunc);
        JSObject listenerHandler2 = 
            EventsInterop.SubscribeEventById("btn2", "click", listenerFunc);
        Console.WriteLine("Subscribed to btn1 & 2.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.TriggerClick("btn2");

        EventsInterop.UnsubscribeEventById("btn2", "click", listenerHandler2);
        Console.WriteLine("Unsubscribed btn2.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.TriggerClick("btn2"); // Doesn't trigger because unsubscribed
        EventsInterop.UnsubscribeEventById("btn1", "click", listenerHandler1);
        // Pitfall: Using a different handler for unsubscribe silently fails.
        // EventsInterop.UnsubscribeEventById("btn1", "click", listenerHandler2);

        // With JSObject as event target and event object.
        Action<JSObject> listenerFuncForElement = (eventObj) =>
        {
            string eventType = eventObj.GetPropertyAsString("type");
            JSObject target = eventObj.GetPropertyAsJSObject("target");
            Console.WriteLine(
                $"In C# event listener: Event {eventType} from " +
                $"ID {target.GetPropertyAsString("id")}");
        };

        JSObject htmlElement = EventsInterop.GetElementById("btn1");
        JSObject listenerHandler3 = EventsInterop.SubscribeEvent(
            htmlElement, "click", listenerFuncForElement);
        Console.WriteLine("Subscribed to btn1.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.UnsubscribeEvent(htmlElement, "click", listenerHandler3);
        Console.WriteLine("Unsubscribed btn1.");
        EventsInterop.TriggerClick("btn1");
    }
}
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

## Type mapping limitations

Some type mappings requiring nested generic types in the [`JSMarshalAs`](xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601) definition aren't currently supported. For example, returning a [`Promise`](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) for an array such as `[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]` generates a compile-time error. An appropriate workaround varies depending on the scenario, but one option is to represent the array as a <xref:System.Runtime.InteropServices.JavaScript.JSObject> reference. This may be sufficient if accessing individual elements within .NET isn't necessary and the reference can be passed to other JS methods that act on the array. Alternatively, a dedicated method can take the <xref:System.Runtime.InteropServices.JavaScript.JSObject> reference as a parameter and return the materialized array, as demonstrated by the following `UnwrapJSObjectAsIntArray` example. In this case, the JS method has no type checking, and the developer has the responsibility to ensure a <xref:System.Runtime.InteropServices.JavaScript.JSObject> wrapping the appropriate array type is passed.

```javascript
PromisesShim.WaitGetIntArrayAsObject = function () {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve([1, 2, 3, 4, 5] ); // Return an array from the Promise
    }, 500);
  });
};

PromisesShim.UnwrapJSObjectAsIntArray = function (jsObject) {
  return jsObject;
};
```

```csharp
// Not supported, generates compile-time error.
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]
public static partial Task<int[]> WaitGetIntArray();

// Workaround, take the return the call and pass it to UnwrapJSObjectAsIntArray.
// Return a JSObject reference to a JS number array.
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Promise<JSType.Object>>()]
public static partial Task<JSObject> WaitGetIntArrayAsObject();

// Takes a JSObject reference to a JS number array, and returns the array as a C# 
// int array.
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
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

```csharp
using System;
using System.Diagnostics;

public static class JSObjectBenchmark
{
    public static void Run()
    {
        Stopwatch sw = new Stopwatch();
        var jsObject = JSObjectInterop.CreateObject();
        sw.Start();
        for (int i = 0; i < 1000000; i++)
        {
            JSObjectInterop.IncrementAnswer(jsObject);
        }
        sw.Stop();
        Console.WriteLine(
            $"JS interop elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds " +
            $"at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per " +
            "operation");

        var pocoObject = 
            new PocoObject { Question = "What is the answer?", Answer = 41 };
        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            pocoObject.IncrementAnswer();
        }
        sw.Stop();
        Console.WriteLine($".NET elapsed time: {sw.Elapsed.TotalSeconds:#.0000} " +
            $"seconds at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms " +
            "per operation");

        Console.WriteLine($"Begin Object Creation");

        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            var jsObject2 = JSObjectInterop.CreateObject();
            JSObjectInterop.IncrementAnswer(jsObject2);
        }
        sw.Stop();
        Console.WriteLine(
            $"JS interop elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds " +
            $"at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per " +
            "operation");

        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            var pocoObject2 = 
                new PocoObject { Question = "What is the answer?", Answer = 0 };
            pocoObject2.IncrementAnswer();
        }
        sw.Stop();
        Console.WriteLine(
            $".NET elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds at " +
            $"{sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per operation");
    }

    public class PocoObject // Plain old CLR object
    {
        public string Question { get; set; }
        public int Answer { get; set; }

        public void IncrementAnswer() => Answer += 1;
    }
}
```

The preceding example displays the following output in the browser's debug console:

> :::no-loc text="JS interop elapsed time: .2536 seconds at .000254 ms per operation":::  
> :::no-loc text=".NET elapsed time: .0210 seconds at .000021 ms per operation":::  
> :::no-loc text="Begin Object Creation":::  
> :::no-loc text="JS interop elapsed time: 2.1686 seconds at .002169 ms per operation":::  
> :::no-loc text=".NET elapsed time: .1089 seconds at .000109 ms per operation":::

## JS `[JSImport]`/`[JSExport]` interop scenarios

The following articles focus on running a .NET WebAssembly module in a JS host, such as a browser:

* <xref:client-side/dotnet-interop/wasm-browser-app>
* <xref:blazor/js-interop/import-export-interop>
