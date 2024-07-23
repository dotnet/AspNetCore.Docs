---
title: JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly
author: pavelsavara
description: Learn how to run .NET from JavaScript with [JSImport]/[JSExport] interop.
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/23/2024
uid: client-side/dotnet-interop-wasm
---
# JavaScript `[JSImport]`/`[JSExport]` interop in .NET WebAssembly

Learn how to interact with JavaScript (JS) from client-side WebAssembly (WASM) components by using the System.Runtime.InteropServices.JavaScript API within .NET 7 or later. This API is colloquially referred to as JSImport/JSExport interop, so named for the two most common attributes used to define desired interop. 

This approach is applicable when running a .NET WebAssembly module in a JavaScript host such as a browser. These scenarios include either Blazor WebAssembly client-side components as detailed in [JavaScript interop with ASP.NET Core Blazor](../blazor/js-interop/import-export-interop), non-Blazor .NET WebAssembly apps detailed in [Run .NET from JavaScript](dotnet-interop.md), and other .NET WebAssembly platforms which support JSImport/JSExport. See the respective articles for examples specialized for these platforms.

## Prerequisites 

[.NET SDK (latest version)](https://dotnet.microsoft.com/download/dotnet/)

A project using either one of the following project types:

* A WebAssembly Browser App project created according to <xref:client-side/dotnet-interop>.
* A Blazor client-side project created according to <xref:blazor/js-interop/import-export-interop>.

This isn't an exhaustive list, as other commercial and open-source platforms exist that enable compiling .NET code to WebAssembly and support code using `System.Runtime.InteropServices.JavaScript`.

# JS Interop using `[JSImport]`/`[JSExport]`

The JSImport attribute is applied to a .NET method to indicate that a corresponding JavaScript method should be called when the .NET method is called. This allows .NET developers to define "imports" that enable .NET code to call into JavaScript. Additionally, .NET Actions can be passed as parameters and JavaScript can invoke these .NET actions to support callback or event subscription patterns.

The JSExport attribute is applied to a .NET method to expose it to JavaScript code. This allows JavaScript code to initiate calls to the .NET method.

## Importing JS methods

This example imports an existing static JS method into C#. JSImport is limited to importing static methods or instance methods of objects accessible globally. For example, `.log()` strictly speaking is an instance method of the `console` object, but can be accessed using static semantics since the instance is a globally accessible singleton.

```csharp
public partial class GlobalInterop
{
    // mapping existing console.log to a C# method
    [JSImport("globalThis.console.log")]
    public static partial void ConsoleLog(string text);
}

//... called from Program.cs Main() of a WASM project:
GlobalInterop.ConsoleLog("Hello World");// Output would appear in the browser console
```

The following demonstrates importing a static method declared in JavaScript.

Declaring a custom JS static method:

```javascript
globalThis.callAlert = function (text) {
  globalThis.window.alert(text);
}
```

Mapping to a C# method proxy:

```csharp
using System.Runtime.InteropServices.JavaScript;

public partial class GlobalInterop
{
	[JSImport("globalThis.callAlert")]
	public static partial void CallAlert(string text);
}

//... called from WASM Program.cs Main():
GlobalInterop.CallAlert("Hello World");
```

Note that the C# class declaring the JSImport method does not have an implementation. At compile time a source generated partial class will contain the .NET code which implements the marshalling of the call and types to invoke the corresponding JavaScript. In Visual Studio, using the Go To Definition or Go To Implementation options will respectively navigate to either the source generated partial class or the developer defined partial class.

In this example, the intermediate `globalThis.callAlert` JavaScript declaration was used to wrap existing JavaScript. This article informally refers to the intermediate JavaScript declaration as a JS shim. In this case it can "shim" or fill the gap between the .NET implementation and existing JS capabilities/libraries. In many cases, such as this trivial example, the JS shim is not necessary and methods could be imported directly as is done in the ConsoleLog example. As demonstrated later, sometimes a JS shim can serve to encapsulate additional logic, manually map types, reduce the number of objects or calls crossing the interop boundary, and/or manually map static calls to instance methods.

## Loading JavaScript declarations

JavaScript declarations which are intended to be imported with JSImport would typically be loaded in the context of the same webpage or JavaScript host which loaded the .NET WebAssembly. This could be accomplished by:
- A `<script>...</script>` tag declaring traditional JavaScript inline
- A `<script src='./some.js'>` tag loading a traditional external *.js file
- Loading a JavaScript ES6 module using `<script type='module' src="./moduleName.js"></script>` tag on the page
- Loading a JavaScript ES6 module *.js file by using `JSHost.ImportAsync(...)` from the .NET WebAssembly

Examples in this article use `JSHost.ImportAsync(...)`. When calling `JShost.ImportAsync(...)`, the client-side .NET WebAssembly will request the file using the `moduleUrl` parameter, and thus expects the file to be accessible as a static web asset much the same way as a `<script>` tag would retrieve a file with a `src` URL. For example, if using the following C# code within a WebAssembly Browser App project, then the *.js file would be placed inside the project under `/wwwroot/scripts/ExampleShim.js`:

```csharp
await JSHost.ImportAsync("ExampleShim", "/scripts/ExampleShim.js");
```

Note that depending on the platform loading the WebAssembly, a dot prefixed URL such as `./scripts/` might refer to an incorrect subdirectory such as `/_framework/scripts/` because the WebAssembly package is initialized by framework scripts under `/_framework/`. In that case prefixing the URL with `../scripts/` would refer to the correct path, or prefixing `/scripts/` would work only if the site is hosted at the root of the domain. A generic approach would typically involve configuring the correct base path for the given environment with an HTML `<base>` tag and using the `/scripts/` prefix to refer to the path relative to the base path. Tilde notation `~/` prefixes are not supported by `ImportAsync()`.

> [!IMPORTANT] 
> If JavaScript is loaded from an ES6 module, then JSImport attributes must include the module name as the second parameter. For example, `[JSImport("globalThis.callAlert", "ExampleShim")]` would indicate the imported method was declared in an ES6 module named "ExampleShim".

## Type mappings

Parameters and returns types in the .NET method signature will automatically be converted to/from appropriate JS types at runtime if a unique mapping is supported. This may result in values being converted by value, or references being wrapped in a proxy type. This process is known as type marshalling. Use <xref:System.Runtime.InteropServices.JavaScript.JSMarshalAsAttribute%601> to control how the imported method parameters and return types are marshalled. 

Some types do not have a default type mapping. For example, a `long` can be marshalled as <xref:System.Runtime.InteropServices.JavaScript.JSType.Number?displayProperty=nameWithType> or <xref:System.Runtime.InteropServices.JavaScript.JSType.BigInt?displayProperty=nameWithType> and thus the `[JSMarsalAsAttibute]` is required or a compile time error will be generated. 

Of note is support for the following type mapping scenarios:
- An <xref:System.Action> or <xref:System.Func%601> can be passed as parameters and are marshalled as callable JS functions. This allows .NET code to provide listeners to be invoked in response to JS callbacks or events.
- JS references and .NET managed object references can be passed in either direction, are marshaled as proxy objects, and are kept alive across the boundary until the proxy is garbage collected.
- Asynchronous JS methods or [JS promises](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) are marshalled with a <xref:System.Threading.Tasks.Task> result and vice versa. 

Most of the marshalled types work in both directions, as parameters and as return values, on both imported and exported methods. 

The following table details supported type mappings:

:::moniker range=">= aspnetcore-8.0"

[!INCLUDE[](~/blazor/includes/js-interop/8.0/import-export-interop-mappings.md)]

:::moniker-end

:::moniker range="< aspnetcore-8.0"

[!INCLUDE[](~/blazor/includes/js-interop/7.0/import-export-interop-mappings.md)]

:::moniker-end

Note, some combinations of type mappings that require nested generic types in `JSMarshalAs` are not currently supported. For example, attempting to materialize an array from a JS promise such as `[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]` will generate a compile time error. An appropriate workaround will vary depending on the scenario, but this specific scenario explored in the [Type Mapping Limitations](#type-mapping-limitations)] section.

## JS Primitives

Demonstrates JSImport leveraging type mappings of several primitive JS types, and use of JSMarshalAs where explicit mappings are required at compile time.

`PrimitivesShim.js`:

```javascript
let PrimitivesShim = {};
(function (PrimitivesShim) {

    globalThis.counter = 0;

    // Takes no parameters and returns nothing
    PrimitivesShim.IncrementCounter = function () {
        globalThis.counter += 1;
    };

    // Returns an int
    PrimitivesShim.GetCounter = () => globalThis.counter;
    // Identical with more verbose syntax:
    //Primitives.GetCounter = function () { return counter; };

    // Takes a parameter and returns nothing. JS doesn't restrict the parameter type, but we can restrict it in the .NET proxy if desired.
    PrimitivesShim.LogValue = (value) => { console.log(value); };

    // Called for various .NET types to demonstrate mapping to JS primitive types
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

    // The JS shim function name doesn't necessarily have to match the C# method name
    [JSImport("PrimitivesShim.LogValue", "PrimitivesShim")]
    public static partial void LogInt(int value);

    // A second mapping to the same JS function with compatible type
    [JSImport("PrimitivesShim.LogValue", "PrimitivesShim")]
    public static partial void LogString(string value);

    // Accept any type as parameter. .NET types will be mapped to JS types where possible,
    // or otherwise be marshalled as an untyped object reference to the .NET object proxy.
    // The JS implementation logs to browser console the JS type and value to demonstrate results of marshalling.
    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndType([JSMarshalAs<JSType.Any>] object value);

    // Some types have multiple mappings, and need explicit marshalling to the desired JS type.
    // A long/Int64 can be mapped as either a Number or BigInt.
    // Passing a long value to the above method will generate an error "ToJS for System.Int64 is not implemented." at runtime.
    // If the parameter declaration `Method(JSMarshalAs<JSType.Any>] long value)` is used, then a compile time error is generated: "Type long is not supported by source-generated JavaScript interop...."
    // Instead, map the long parameter explicitly to either a JSType.Number or JSType.BigInt.
    // Note there could potentially be runtime overflow errors in JS if the C# value is too large.
    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndTypeForNumber([JSMarshalAs<JSType.Number>] long value);

    [JSImport("PrimitivesShim.LogValueAndType", "PrimitivesShim")]
    public static partial void LogValueAndTypeForBigInt([JSMarshalAs<JSType.BigInt>] long value);
}

public static class PrimitivesUsage
{
    public static async Task Run()
    {
        // Ensure JS ES6 module loaded
        await JSHost.ImportAsync("PrimitivesShim", "/PrimitivesShim.js");

        // Call a proxy to a static JS method, console.log("")
        PrimitivesInterop.ConsoleLog("Printed from JSImport of console.log()");

        // Basic examples of JS interop with an integer:       
        PrimitivesInterop.IncrementCounter();
        int counterValue = PrimitivesInterop.GetCounter();
        PrimitivesInterop.LogInt(counterValue);
        PrimitivesInterop.LogString("I'm a string from .NET in your browser!");

        // Mapping some other .NET types to JS primitives:        
        PrimitivesInterop.LogValueAndType(true);
        PrimitivesInterop.LogValueAndType(0x3A);// byte literal
        PrimitivesInterop.LogValueAndType('C');
        PrimitivesInterop.LogValueAndType((Int16)12);
        // Note: JavaScript Number has a lower max value and can generate overflow errors
        PrimitivesInterop.LogValueAndTypeForNumber(9007199254740990L);// Int64/Long 
        PrimitivesInterop.LogValueAndTypeForBigInt(1234567890123456789L);// Int64/Long, JS BigInt supports larger numbers
        PrimitivesInterop.LogValueAndType(3.14f);// single floating point literal
        PrimitivesInterop.LogValueAndType(3.14d);// double floating point literal
        PrimitivesInterop.LogValueAndType("A string");
    }
}
// The example displays the following output in the browser's debug console:
//       Printed from JSImport of console.log()
//       1
//       I'm a string from .NET in your browser!
//       boolean true
//       number 58
//       number 67
//       number 12
//       number 9007199254740990
//       bigint 1234567890123456789n
//       number 3.140000104904175
//       number 3.14
//       string A string
```

## JS Date

Demonstrates JSImport of methods which have a JS Date object as its return or parameter. Dates are marshalled across interop by-value, meaning they are copied in much the same way as JS primitives.

Be aware that a [JS Date](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date) is time-zone agnostic. A .NET DateTime will be adjusted relative to its DateTimeKind when marshalled, but time zone information will not be preserved. Consider initializing DateTime's with a DateTimeKind.Utc or DateTimeKind.Local consistent with the value it represents.

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
    [return: JSMarshalAs<JSType.Date>] // Explicit JSMarshalAs for a return type.
    public static partial DateTime IncrementDay([JSMarshalAs<JSType.Date>] DateTime date);
    
    [JSImport("DateShim.LogValueAndType", "DateShim")]
    public static partial void LogValueAndType([JSMarshalAs<JSType.Date>] DateTime value);

}

public static class DateUsage
{
    public static async Task Run()
    {
        // Ensure JS ES6 module loaded
        await JSHost.ImportAsync("DateShim", "/DateShim.js");

        // Basic examples of interop with a C# DateTime and JS Date:
        DateTime date = new DateTime(1968, 12, 21, 12, 51, 0, DateTimeKind.Utc);            
        DateInterop.LogValueAndType(date);
        date = DateInterop.IncrementDay(date);        
        DateInterop.LogValueAndType(date);
    }
}
// The example displays the following output in the browser's debug console:
//     Date: Sat Dec 21 1968 07:51:00 GMT-0500 (Eastern Standard Time)
//     Date: Sun Dec 22 1968 07:51:00 GMT-0500 (Eastern Standard Time)  
```

## JS Object References

Whenever a JS method returns an object reference, it is represented in .NET with the JSObject type. The original JS object continues its lifetime within the JS boundary, while .NET code can access and modify it by reference through the JSObject. While the type itself exposes a limited API, the ability to hold a JS object reference as well as return or pass it across the interop boundary enables a great deal of capabilities.

The JSObject provides methods to access properties, but does not provide direct access to instance methods. As the `Summarize()` method demonstrates below, instance methods can be accessed indirectly by implementing a static method that takes the instance to be acted on as a parameter.

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
                return `The question is "${this.question}" and the answer is ${this.answer}.`;
            }
        };
    };
    
    JSObjectShim.IncrementAnswer = function (object) {
        object.answer += 1;
        // We don't return the modified object, since the reference is modified.
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
        // Note: We did not retrieve an updated object, and will see the change reflected in our existing instance.
        JSObjectInterop.ConsoleLog(jsObject);

        // JSObject exposes several methods for interacting with properties:
        jsObject.SetProperty("question", "What is the answer?");
        JSObjectInterop.ConsoleLog(jsObject);

        // We can't directly JSImport an instance method on the jsObject, but we can
        // pass the object reference and have the JS shim call the instance method.
        string summary = JSObjectInterop.Summarize(jsObject);
        Console.WriteLine("Summary: " + summary);

    }
}
// The example displays the following output in the browser's debug console:
//     {name: 'Example JS Object', answer: 41, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}
//     {name: 'Example JS Object', answer: 42, question: null, Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}
//     {name: 'Example JS Object', answer: 42, question: 'What is the answer?', Symbol(wasm cs_owned_js_handle): 5, summarize: ƒ}
//     Summary: The question is "What is the answer?" and the answer is 42.
```

## Asynchronous Interop

Many JavaScript APIs are asynchronous and signal completion through either a callback, promise, or async method. Ignoring asynchronous capabilities is often not an option, as subsequent code may depend upon the completion of the asynchronous operation, and thus must be awaited.

JS methods using the `async` keyword or returning a promise can be awaited in C# by a method returning a Task. Note as demonstrated below, the `async` keyword is not used on the C# method with the JSImport attribute, because it does not use the `await` keyword within it. However, consuming code calling the method would typically use the `await` keyword and be marked as `async` as demonstrated in the `PromisesUsage` example.

JavaScript with a callback, such as a `setTimeout()`, can be wrapped in a Promise before returning from JavaScript. Wrapping a callback in a promise as demonstrated in `Wait2Seconds()` is only appropriate when the callback is called exactly once. Otherwise, a C# Action can be passed to listen for a callback that may be called zero or many times, which is demonstrated in the [Subscribing to JS Events](#Subscribing-to-JS-Events) section.

`PromisesShim.js`:

```javascript
let PromisesShim = {};
(function (PromisesShim) {

    PromisesShim.Wait2Seconds = function () {
        // This also demonstrates wrapping a callback-based API in a promise to make it awaitable.
        return new Promise((resolve, reject) => {
            setTimeout(() => {                
                resolve();// resolve promise after 2 seconds
            }, 2000);
        });
    };
    
    // Returning a value via resolve() in a promise
    PromisesShim.WaitGetString = function () {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve("String From Resolve");// return a string via promise
            }, 500);
        });
    };

    PromisesShim.WaitGetDate = function () {        
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve(new Date('1988-11-24'))// return a date via promise
            }, 500);
        });
    };

    // awaitable fetch()
    PromisesShim.FetchCurrentUrl = function () {
        // This method returns the promise returned by .then(*.text())
        // and .NET in turn awaits the returned promise.
        return fetch(globalThis.window.location, { method: 'GET' })
            .then(response => response.text());
    };

    // .NET can await JS functions using the async/await JS syntax:
    PromisesShim.AsyncFunction = async function () {
        await PromisesShim.Wait2Seconds();
    };

    // A Promise.reject() can be used to signal failure, 
    // and will be bubbled to .NET code as a JSException.
    PromisesShim.ConditionalSuccess = function (shouldSucceed) {        
       
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                if (shouldSucceed)                
                    resolve();// success
                else                     
                    reject("Reject: ShouldSucceed == false");// failure
            }, 500);

        });

    };
    
})(PromisesShim);

export { PromisesShim };
```

`PromisesShim.cs`:

```csharp
using System;
using System.Diagnostics;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;

public partial class PromisesInterop
{
    // Do not use the async keyword in the C# method signature. Returning Task or Task<T> is sufficient.

    // When calling asynchronous JS methods, we often want to wait until the JS method completes execution.
    // For example, if loading a resource or making a request, we likely want the following code to be able to assume the action is completed.

    // If the JS method or shim returns a promise, then C# can treat it as an awaitable Task.

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

        await PromisesInterop.Wait2Seconds();// await promise
        Console.WriteLine($"Waited {sw.Elapsed.TotalSeconds:#.0} seconds.");

        sw.Restart();
        string str = await PromisesInterop.WaitGetString();// await promise with string return
        Console.WriteLine($"Waited {sw.Elapsed.TotalSeconds:#.0} seconds for WaitGetString: '{str}'");

        sw.Restart();
        DateTime date = await PromisesInterop.WaitGetDate();// await promise with string return
        Console.WriteLine($"Waited {sw.Elapsed.TotalSeconds:#.0} seconds for WaitGetDate: '{date}'");

        string responseText = await PromisesInterop.FetchCurrentUrl();// await a JS fetch        
        Console.WriteLine($"responseText.Length: {responseText.Length}");
                
        sw.Restart();

        await PromisesInterop.AsyncFunction();// await an async JS method
        Console.WriteLine($"Waited {sw.Elapsed.TotalSeconds:#.0} seconds for AsyncFunction.");

        try {
            // Handle a promise rejection
            await PromisesInterop.ConditionalSuccess(shouldSucceed: false);// await an async JS method            
        }
        catch(JSException ex) // Catch JavaScript exception
        {
            Console.WriteLine($"JavaScript Exception Caught: '{ex.Message}'");
        }       
        
    }
    // The example displays the following output in the browser's debug console:
    // Waited 2.0 seconds.
    // Waited .5 seconds for WaitGetString: 'String From Resolve'
    // Waited .5 seconds for WaitGetDate: '11/24/1988 12:00:00 AM'
    // responseText.Length: 582
    // Waited 2.0 seconds for AsyncFunction.
    // JavaScript Exception Caught: 'Reject: ShouldSucceed == false'

}
```

## Subscribing to JS events

.NET code can subscribe to and handle JS events by passing a C# Action to a JS method to act as a handler. The JS shim code handles subscribing to the event.

One nuance of `removeEventListener()` is it requires a reference to the function previously passed to `addEventListener()`. When a C# Action is passed across the interop boundary, it gets wrapped in a JS proxy object. The consequence of this is when passing the same C# Action to both `addEventListener` and `removeEventListener`, two different JS proxy objects wrapping the Action will be generated. These references are different, thus `removeEventListener` will not be able to find the event listener to remove. To address this problem, the following examples wrap the C# Action in a JS function, then return that reference as a JSObject from the subscribe call to be passed later to the unsubscribe call. Because it is returned and passed as a JSObject, the same reference is used for both calls, and the event listener can be removed.

`EventShim.js`:

```javascript
let EventsShim = {};
(function (EventsShim) {

  EventsShim.SubscribeEventById = function (elementId, eventName, listenerFunc) {
    const elementObj = document.getElementById(elementId);

    // Need to wrap the Managed C# action in JS func (only because it is being returned)
    let handler = function (event) {            
      listenerFunc(event.type, event.target.id);// decompose object to primitives
    }.bind(elementObj);        

    elementObj.addEventListener(eventName, handler, false);        
    return handler;// return JSObject reference so it can be used for removeEventListener later
  }

  // Param listenerHandler must be the JSObject reference returned from the prior SubscribeEvent call
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
    // It's not strictly required to wrap the C# action listenerFunc in a JS function.
    elementObj.addEventListener(eventName, listenerFunc, false);
    // However, if you need to return the wrapped proxy object you will get an error when it tries to wrap the existing proxy in an additional proxy:
    return listenerFunc; // Error: "JSObject proxy of ManagedObject proxy is not supported."
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
    public static partial JSObject SubscriveEventById(string elementId, 
        string eventName, 
        [JSMarshalAs<JSType.Function<JSType.String, JSType.String>>] 
        Action<string, string> listenerFunc);

    [JSImport("EventsShim.UnsubscribeEventById", "EventsShim")]
    public static partial void UnsubscriveEventById(string elementId, 
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
            Console.WriteLine($"In C# event listener: Event {eventName} from ID {elementId}");
        
        JSObject listenerHandler1 = EventsInterop.SubscriveEventById("btn1", "click", listenerFunc);
        JSObject listenerHandler2 = EventsInterop.SubscriveEventById("btn2", "click", listenerFunc);
        Console.WriteLine("Subscribed to btn1 & 2.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.TriggerClick("btn2");

        EventsInterop.UnsubscriveEventById("btn2", "click", listenerHandler2);
        Console.WriteLine("Unsubscribed btn2.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.TriggerClick("btn2");// Doesn't trigger because unsubscribed
        EventsInterop.UnsubscriveEventById("btn1", "click", listenerHandler1);
        // Pitfall: Using a different handler for unsubscribe will silently fail.
        // EventsInterop.UnsubscriveEventById("btn1", "click", listenerHandler2);         

        // With JSObject as event target and event object
        Action<JSObject> listenerFuncForElement = (eventObj) =>
        {
            string eventType = eventObj.GetPropertyAsString("type");
            JSObject target = eventObj.GetPropertyAsJSObject("target");
            Console.WriteLine($"In C# event listener: Event {eventType} from ID {target.GetPropertyAsString("id")}");
        };

        JSObject htmlElement = EventsInterop.GetElementById("btn1");
        JSObject listenerHandler3 = EventsInterop.SubscribeEvent(htmlElement, "click", listenerFuncForElement);
        Console.WriteLine("Subscribed to btn1.");
        EventsInterop.TriggerClick("btn1");
        EventsInterop.UnsubscribeEvent(htmlElement, "click", listenerHandler3);
        Console.WriteLine("Unsubscribed btn1.");
        EventsInterop.TriggerClick("btn1");

    }
    // The example displays the following output in the browser's debug console:
    // Subscribed to btn1 & 2.
    // In C# event listener: Event click from ID btn1
    // In C# event listener: Event click from ID btn2
    // Unsubscribed btn2.
    // In C# event listener: Event click from ID btn1    
    // Subscribed to btn1.
    // In C# event listener: Event click from ID btn1    
    // Unsubscribed btn1.
}
```

# Type mapping limitations

Some type mappings requiring nested generic types in the `JSMarshalAs` definition are not currently supported. For example, returning a JS promise for an array such as `[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]` will generate a compile time error. An appropriate workaround will vary depending on the scenario, but one option is to represent the array as a JSObject reference. This may be sufficient if accessing individual elements within .NET is not necessary, and the reference can be passed to other JS methods which act on the array. Alternatively, a dedicated method can take the JSObject reference as a parameter and return the materialized array as demonstrated by UnwrapJSObjectAsIntArray. Note in this case the JS method has no type checking, and it's the developer's responsibility to ensure a JSObject wrapping the appropriate array type is passed.

```javascript
PromisesShim.WaitGetIntArrayAsObject = function () {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      resolve([1, 2, 3, 4, 5] ); // return an array from the Promise
    }, 500);
  });
};

PromisesShim.UnwrapJSObjectAsIntArray = function (jsObject) {
  return jsObject;
};
```

```csharp
// Not supported, generates compile time error.
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Promise<JSType.Array<JSType.Number>>>()]
public static partial Task<int[]> WaitGetIntArray();

// Workaround, take the return from this call and pass it to UnwrapJSObjectAsIntArray
// Return a JSObject reference to a JS number array
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Promise<JSType.Object>>()]
public static partial Task<JSObject> WaitGetIntArrayAsObject();

// Takes a JSOBject reference to a JS number array, and returns the array as a C# int array.
[JSImport("PromisesShim.WaitGetArray", "PromisesShim")]
[return: JSMarshalAs<JSType.Array<JSType.Number>>()]
public static partial int[] UnwrapJSObjectAsIntArray(JSObject intArray);
//...

// Usage from Program.cs Main():
JSObject arrayAsJSObject = await PromisesInterop.WaitGetIntArrayAsObject();          
int[] intArray = PromisesInterop.UnwrapJSObjectAsIntArray(arrayAsJSObject);
```

# Performance considerations

Marshalling of calls and the overhead of tracking objects across the interop boundary is more expensive than native .NET operations, but for moderate usage should still demonstrate acceptable performance for a typical web application.

Object proxies such as JSObject which maintain references across the interop boundary have additional memory overhead, and impact how garbage collection affects these objects. Additionally, since memory pressure from JavaScript and .NET is not shared, it is possible in some scenarios to exhaust available memory without a garbage collection being triggered. This risk is significant when an excessive number of large objects are referenced across interop by relatively small JSObject's, or vice versa where large .NET objects are referenced by JS proxies. In such cases it is advisable to follow deterministic disposal patterns with `using` scopes leveraging JSObject's `IDisposable` interface.

The below benchmarks (leveraging prior example code) demonstrate that interop operations are roughly an order of magnitude slower than those that remain within the .NET boundary, but are still relatively fast. Additionally, consider that a user's device capabilities will impact performance.

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
        Console.WriteLine($"JS interop elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per operation");

        var pocoObject = new PocoObject { Question = "What is the answer?", Answer = 41 };
        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            pocoObject.IncrementAnswer();
        }
        sw.Stop();
        Console.WriteLine($".NET elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per operation");

        Console.WriteLine($"Begin Object Creation");

        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            var jsObject2 = JSObjectInterop.CreateObject();
            JSObjectInterop.IncrementAnswer(jsObject2);
        }
        sw.Stop();
        Console.WriteLine($"JS interop elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per operation");

        sw.Restart();
        for (int i = 0; i < 1000000; i++)
        {
            var pocoObject2 = new PocoObject { Question = "What is the answer?", Answer = 0 };
            pocoObject2.IncrementAnswer();
        }
        sw.Stop();
        Console.WriteLine($".NET elapsed time: {sw.Elapsed.TotalSeconds:#.0000} seconds at {sw.Elapsed.TotalMilliseconds / 1000000d:#.000000} ms per operation");
    }
    
    public class PocoObject // Plain old CLR object
    {
        public string Question { get; set; }
        public int Answer { get; set; }

        public void IncrementAnswer() => Answer += 1;        
    }
}
// The example displays the following output in the browser's debug console:
// JS interop elapsed time: .2536 seconds at .000254 ms per operation
// .NET elapsed time: .0210 seconds at .000021 ms per operation
// Begin Object Creation
// JS interop elapsed time: 2.1686 seconds at .002169 ms per operation
// .NET elapsed time: .1089 seconds at .000109 ms per operation
```
