---
title: Call .NET methods from JavaScript functions in ASP.NET Core Blazor
author: guardrex
description: Learn how to invoke .NET methods from JavaScript functions in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc 
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, JS, Promise]
uid: blazor/js-interop/call-dotnet-from-javascript
---
# Call .NET methods from JavaScript functions in ASP.NET Core Blazor

This article explains how to invoke .NET methods from JavaScript (JS).

:::moniker range=">= aspnetcore-6.0"

For information on how to call JS functions from .NET, see <xref:blazor/js-interop/call-javascript-from-dotnet>.

## Invoke a static .NET method

To invoke a static .NET method from JavaScript (JS), use the JS functions `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`. Pass in the name of the assembly containing the method, the identifier of the static .NET method, and any arguments.

In the following example:

* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.
* The `{ARGUMENTS}` placeholder are optional, comma-separated arguments to pass to the method, each of which must be JSON-serializable.

```javascript
DotNet.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}', {ARGUMENTS});
```

`DotNet.invokeMethod` returns the result of the operation. `DotNet.invokeMethodAsync` returns a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) representing the result of the operation.

The asynchronous function (`invokeMethodAsync`) is preferred over the synchronous version (`invokeMethod`) to support Blazor Server scenarios.

The .NET method must be public, static, and have the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute).

In the following example:

* The `{<T>}` placeholder indicates the return type, which is only required for methods that return a value.
* The `{.NET METHOD ID}` placeholder is the method identifier.

```razor
@code {
    [JSInvokable]
    public static Task{<T>} {.NET METHOD ID}()
    {
        ...
    }
}
```

> [!NOTE]
> Calling open generic methods isn't supported with static .NET methods but is supported with instance methods. For more information, see the [Call .NET generic class methods](#call-net-generic-class-methods) section.

In the following `CallDotNetExample1` component, the `ReturnArrayAsync` C# method returns an `int` array. The [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) is applied to the method, which makes the method invokable by JS.

`Pages/CallDotNetExample1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample1.razor?highlight=12-16)]

The `<button>` element's `onclick` HTML attribute is JavaScript's [`onclick`](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick) event handler assignment for processing [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) events, not Blazor's `@onclick` directive attribute. The `returnArrayAsync` JS function is assigned as the handler.

The following `returnArrayAsync` JS function, calls the `ReturnArrayAsync` .NET method of the preceding `CallDotNetExample1` component and logs the result to the browser's web developer tools console. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<script>
  window.returnArrayAsync = () => {
    DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
      .then(data => {
        console.log(data);
      });
    };
</script>
```

When the **`Trigger .NET static method`** button is selected, the browser's developer tools console output displays the array data. The format of the output differs slightly among browsers. The following output shows the format used by Microsoft Edge:

```console
Array(3) [ 1, 2, 3 ]
```

By default, the .NET method identifier for the JS call is the .NET method name, but you can specify a different identifier using the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) constructor. In the following example, `DifferentMethodName` is the assigned method identifier for the `ReturnArrayAsync` method:

```csharp
[JSInvokable("DifferentMethodName")]
```

In the call to `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`, call `DifferentMethodName` to execute the `ReturnArrayAsync` .NET method:

* `DotNet.invokeMethod('BlazorSample', 'DifferentMethodName');`
* `DotNet.invokeMethodAsync('BlazorSample', 'DifferentMethodName');`

> [!NOTE]
> The `ReturnArrayAsync` method example in this section returns the result of a <xref:System.Threading.Tasks.Task> without the use of explicit C# [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords. Coding methods with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) is typical of methods that use the [`await`](/dotnet/csharp/language-reference/operators/await) keyword to return the value of asynchronous operations.
>
> `ReturnArrayAsync` method composed with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords:
>
> ```csharp
> [JSInvokable]
> public static async Task<int[]> ReturnArrayAsync()
> {
>     return await Task.FromResult(new int[] { 1, 2, 3 });
> }
> ```
>
> For more information, see [Asynchronous programming with async and await](/dotnet/csharp/programming-guide/concepts/async/) in the C# guide.

## Invoke an instance .NET method

To invoke an instance .NET method from JavaScript (JS):

* Pass the .NET instance by reference to JS by wrapping the instance in a <xref:Microsoft.JSInterop.DotNetObjectReference> and calling <xref:Microsoft.JSInterop.DotNetObjectReference.Create%2A> on it.
* Invoke a .NET instance method from JS using `invokeMethod` or `invokeMethodAsync` from the passed <xref:Microsoft.JSInterop.DotNetObjectReference>. The .NET instance can also be passed as an argument when invoking other .NET methods from JS.
* Dispose of the <xref:Microsoft.JSInterop.DotNetObjectReference>.

The following sections of this article demonstrate various approaches for invoking an instance .NET method:

* [Pass a `DotNetObjectReference` to an individual JavaScript function](#pass-a-dotnetobjectreference-to-an-individual-javascript-function)
* [Pass a `DotNetObjectReference` to a class with multiple JavaScript functions](#pass-a-dotnetobjectreference-to-a-class-with-multiple-javascript-functions)
* [Call .NET generic class methods](#call-net-generic-class-methods)
* [Class instance examples](#class-instance-examples)
* [Component instance .NET method helper class](#component-instance-net-method-helper-class)

## Pass a `DotNetObjectReference` to an individual JavaScript function

The example in this section demonstrates how to pass a <xref:Microsoft.JSInterop.DotNetObjectReference> to an individual JavaScript (JS) function.

The following `sayHello1` JS function receives a <xref:Microsoft.JSInterop.DotNetObjectReference> and calls `invokeMethodAsync` to call the `GetHelloMethod` .NET method of a component.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

For the following `CallDotNetExample2` component:

* The component has a JS-invokable .NET method named `GetHelloMessage`.
* When the **`Trigger .NET instance method`** button is selected, the JS function `sayHello1` is called with the <xref:Microsoft.JSInterop.DotNetObjectReference>.
* `sayHello1`:
  * Calls `GetHelloMessage` and receives the message result.
  * Returns the message result to the calling `TriggerDotNetInstanceMethod` method.
* The returned message from `sayHello1` in `result` is displayed to the user.
* To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

`Pages/CallDotNetExample2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample2.razor?highlight=30-31,34-35)]

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

To pass arguments to an instance method:

1. Add parameters to the .NET method invocation. In the following example, a name is passed to the method. Add additional parameters to the list as needed.

   ```html
   <script>
     window.sayHello2 = (dotNetHelper, name) => {
       return dotNetHelper.invokeMethodAsync('GetHelloMessage', name);
     };
   </script>
   ```

   In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

1. Provide the parameter list to the .NET method.

   `Pages/CallDotNetExample3.razor`:

   [!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample3.razor?highlight=31,35)]

   In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

## Pass a `DotNetObjectReference` to a class with multiple JavaScript functions

The example in this section demonstrates how to pass a <xref:Microsoft.JSInterop.DotNetObjectReference> to a JavaScript (JS) class with multiple functions.

Create and pass a <xref:Microsoft.JSInterop.DotNetObjectReference> from the [`OnAfterRenderAsync` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) to a JS class for multiple functions to use. Make sure that the .NET code disposes of the <xref:Microsoft.JSInterop.DotNetObjectReference>, as the following example shows.

In the following `CallDotNetExampleOneHelper` component, the `Trigger JS function` buttons call JS functions by setting the [JS `onclick` property](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick), ***not*** Blazor's `@onclick` directive attribute.

`Pages/CallDotNetExampleOneHelper.razor`:

```csharp
@page "/call-dotnet-example-one-helper"
@implements IDisposable
@inject IJSRuntime JS

<PageTitle>Call .NET Example</PageTitle>

<h1>Pass <code>DotNetObjectReference</code> to a JavaScript class</h1>

<p>
    <label>
        Message: <input @bind="name" />
    </label>
</p>

<p>
    <button onclick="GreetingHelpers.sayHello()">
        Trigger JS function <code>sayHello</code>
    </button>
</p>

<p>
    <button onclick="GreetingHelpers.welcomeVisitor()">
        Trigger JS function <code>welcomeVisitor</code>
    </button>
</p>

@code {
    private string? name;
    private DotNetObjectReference<CallDotNetExampleOneHelper>? dotNetHelper;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            dotNetHelper = DotNetObjectReference.Create(this);
            await JS.InvokeVoidAsync("GreetingHelpers.setDotNetHelper", 
                dotNetHelper);
        }
    }

    [JSInvokable]
    public string GetHelloMessage() => $"Hello, {name}!";

    [JSInvokable]
    public string GetWelcomeMessage() => $"Welcome, {name}!";

    public void Dispose()
    {
        dotNetHelper?.Dispose();
    }
}
```

In the preceding example:

* The variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.
* The component must explicitly dispose of the <xref:Microsoft.JSInterop.DotNetObjectReference> to permit garbage collection and prevent a memory leak.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<script>
  class GreetingHelpers {
    static dotNetHelper;

    static setDotNetHelper(value) {
      GreetingHelpers.dotNetHelper = value;
    }

    static async sayHello() {
      const msg = 
        await GreetingHelpers.dotNetHelper.invokeMethodAsync('GetHelloMessage');
      alert(`Message from .NET: "${msg}"`);
    }

    static async welcomeVisitor() {
      const msg = 
        await GreetingHelpers.dotNetHelper.invokeMethodAsync('GetWelcomeMessage');
      alert(`Message from .NET: "${msg}"`);
    }
  }
    
  window.GreetingHelpers = GreetingHelpers;
</script>
```

In the preceding example:

* The `GreetingHelpers` class is added to the `window` object to globally define the class, which permits Blazor to locate the class for JS interop.
* The variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

## Call .NET generic class methods

JavaScript (JS) functions can call [.NET generic class](/dotnet/csharp/programming-guide/generics/generic-classes) methods, where a JS function calls a .NET method of a generic class.

In the following generic type class (`GenericType<TValue>`):

* The class has a single type parameter (`TValue`) with a single generic `Value` property.
* The class has two non-generic methods marked with the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute), each with a generic type parameter named `newValue`:
  * `Update` synchronously updates the value of `Value` from `newValue`.
  * `UpdateAsync` asynchronously updates the value of `Value` from `newValue` after creating an awaitable task with <xref:System.Threading.Tasks.Task.Yield%2A?displayProperty=nameWithType> that asynchronously yields back to the current context when awaited.
* Each of the class methods write the type of `TValue` and the value of `Value` to the console. Writing to the console is only for demonstration purposes. Production apps usually avoid writing to the console in favor of app *logging*. For more information, see <xref:blazor/fundamentals/logging> and <xref:fundamentals/logging/index>.

> [!NOTE]
> *Open generic types and methods* don't specify types for type placeholders. Conversely, *closed generics* supply types for all type placeholders. The examples in this section demonstrate closed generics, but invoking JS interop *instance methods* with open generics ***is supported***. Use of open generics is ***not*** supported for [static .NET method invocations](#invoke-a-static-net-method), which were described earlier in this article.

For more information, see the following articles:

* [Generic classes and methods (C# documentation)](/dotnet/csharp/fundamentals/types/generics)
* [Generic Classes (C# Programming Guide)](/dotnet/csharp/programming-guide/generics/generic-classes)
* [Generics in .NET (.NET documentation)](/dotnet/standard/generics/)

`GenericType.cs`:

```csharp
using Microsoft.JSInterop;

public class GenericType<TValue>
{
    public TValue? Value { get; set; }

    [JSInvokable]
    public void Update(TValue newValue)
    {
        Value = newValue;

        Console.WriteLine($"Update: GenericType<{typeof(TValue)}>: {Value}");
    }

    [JSInvokable]
    public async void UpdateAsync(TValue newValue)
    {
        await Task.Yield();
        Value = newValue;

        Console.WriteLine($"UpdateAsync: GenericType<{typeof(TValue)}>: {Value}");
    }
}
```

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server), add the following `<script>` block.

In the `invokeMethodsAsync` function:

* The generic type class's `Update` and `UpdateAsync` methods are called with arguments representing strings and numbers.
* Blazor WebAssembly apps support calling .NET methods synchronously with `invokeMethod`. `syncInterop` receives a boolean value indicating if the JS interop is occurring in a Blazor WebAssembly app. When `syncInterop` is `true`, `invokeMethod` is safely called. If the value of `syncInterop` is `false`, only the asynchronous function `invokeMethodAsync` is called because the JS interop is executing in a Blazor Server app.
* For demonstration purposes, the <xref:Microsoft.JSInterop.DotNetObjectReference> function call (`invokeMethod` or `invokeMethodAsync`), the .NET method called (`Update` or `UpdateAsync`), and the argument are written to the console. The arguments use a random number to permit matching the JS function call to the .NET method invocation (also written to the console on the .NET side). Production code usually doesn't write to the console, either on the client or the server. Production apps usually rely upon app *logging*. For more information, see <xref:blazor/fundamentals/logging> and <xref:fundamentals/logging/index>.

```html
<script>
  const randomInt = () => Math.floor(Math.random() * 99999);

  window.invokeMethodsAsync = async (syncInterop, dotNetHelper1, dotNetHelper2) => {
    var n = randomInt();
    console.log(`JS: invokeMethodAsync:Update('string ${n}')`);
    await dotNetHelper1.invokeMethodAsync('Update', `string ${n}`);

    n = randomInt();
    console.log(`JS: invokeMethodAsync:UpdateAsync('string ${n}')`);
    await dotNetHelper1.invokeMethodAsync('UpdateAsync', `string ${n}`);

    if (syncInterop) {
      n = randomInt();
      console.log(`JS: invokeMethod:Update('string ${n}')`);
      dotNetHelper1.invokeMethod('Update', `string ${n}`);
    }

    n = randomInt();
    console.log(`JS: invokeMethodAsync:Update(${n})`);
    await dotNetHelper2.invokeMethodAsync('Update', n);

    n = randomInt();
    console.log(`JS: invokeMethodAsync:UpdateAsync(${n})`);
    await dotNetHelper2.invokeMethodAsync('UpdateAsync', n);

    if (syncInterop) {
      n = randomInt();
      console.log(`JS: invokeMethod:Update(${n})`);
      dotNetHelper2.invokeMethod('Update', n);
    }
  };
</script>
```

In the following `GenericsExample` component:

* The JS function `invokeMethodsAsync` is called when the **`Invoke Interop`** button is selected.
* A pair of <xref:Microsoft.JSInterop.DotNetObjectReference> types are created and passed to the JS function for instances of the `GenericType` as a `string` and an `int`.

`Pages/GenericsExample.razor`:

```razor
@page "/generics-example"
@using System.Runtime.InteropServices
@inject IJSRuntime JSRuntime

<p>
    <button @onclick="InvokeInterop">Invoke Interop</button>
</p>

<ul>
    <li>genericType1: @genericType1?.Value</li>
    <li>genericType2: @genericType2?.Value</li>
</ul>

@code {
    private GenericType<string> genericType1 = new() { Value = "string 0" };
    private GenericType<int> genericType2 = new() { Value = 0 };

    public async Task InvokeInterop()
    {
        var syncInterop = 
            RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"));

        await JSRuntime.InvokeVoidAsync(
            "invokeMethodsAsync",
            syncInterop,
            DotNetObjectReference.Create(genericType1),
            DotNetObjectReference.Create(genericType2));
    }
}
```

The following demonstrates typical output of the preceding example when the **`Invoke Interop`** button is selected in a Blazor WebAssembly app:

> JS: invokeMethodAsync:Update('string 37802')
> .NET: Update: GenericType<System.String>: string 37802
> JS: invokeMethodAsync:UpdateAsync('string 53051')
> JS: invokeMethod:Update('string 26784')
> .NET: Update: GenericType<System.String>: string 26784
> JS: invokeMethodAsync:Update(14107)
> .NET: Update: GenericType<System.Int32>: 14107
> JS: invokeMethodAsync:UpdateAsync(48995)
> JS: invokeMethod:Update(12872)
> .NET: Update: GenericType<System.Int32>: 12872
> .NET: UpdateAsync: GenericType<System.String>: string 53051
> .NET: UpdateAsync: GenericType<System.Int32>: 48995

If the preceding example is implemented in a Blazor Server app, the synchronous calls with `invokeMethod` are avoided. The asynchronous function (`invokeMethodAsync`) is preferred over the synchronous version (`invokeMethod`) in Blazor Server scenarios.

Typical output of a Blazor Server app:

> JS: invokeMethodAsync:Update('string 34809')
> .NET: Update: GenericType<System.String>: string 34809
> JS: invokeMethodAsync:UpdateAsync('string 93059')
> JS: invokeMethodAsync:Update(41997)
> .NET: Update: GenericType<System.Int32>: 41997
> JS: invokeMethodAsync:UpdateAsync(24652)
> .NET: UpdateAsync: GenericType<System.String>: string 93059
> .NET: UpdateAsync: GenericType<System.Int32>: 24652

The preceding output examples demonstrate that asynchronous methods execute and complete in an *arbitrary order* depending on several factors, including thread scheduling and the speed of method execution. It isn't possible to reliably predict the order of completion for asynchronous method calls.

## Class instance examples

The following `sayHello1` JS function:

* Calls the `GetHelloMessage` .NET method on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>.
* Returns the message from `GetHelloMessage` to the `sayHello1` caller.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

The following `HelloHelper` class has a JS-invokable .NET method named `GetHelloMessage`. When `HelloHelper` is created, the name in the `Name` property is used to return a message from `GetHelloMessage`.

`HelloHelper.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/HelloHelper.cs?highlight=5,12-13)]

The `CallHelloHelperGetHelloMessage` method in the following `JsInteropClasses3` class invokes the JS function `sayHello1` with a new instance of `HelloHelper`.

`JsInteropClasses3.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/JsInteropClasses3.cs?highlight=13-18)]

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

When the **`Trigger .NET instance method`** button is selected in the following `CallDotNetExample4` component, `JsInteropClasses3.CallHelloHelperGetHelloMessage` is called with the value of `name`.

`Pages/CallDotNetExample4.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample4.razor?highlight=28-32)]

The following image shows the rendered component with the name `Amy Pond` in the `Name` field. After the button is selected, `Hello, Amy Pond!` is displayed in the UI:

![Rendered 'CallDotNetExample4' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-4.png)

The preceding pattern shown in the `JsInteropClasses3` class can also be implemented entirely in a component.

`Pages/CallDotNetExample5.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample5.razor)]

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

The output displayed by the `CallDotNetExample5` component is `Hello, Amy Pond!` when the name `Amy Pond` is provided in the `Name` field.

In the preceding `CallDotNetExample5` component, the .NET object reference is disposed. If a class or component doesn't dispose the <xref:Microsoft.JSInterop.DotNetObjectReference>, dispose it from the client by calling `dispose` on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>:

```javascript
window.jsFunction = (dotNetHelper) => {
  dotNetHelper.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}');
  dotNetHelper.dispose();
}
```

In the preceding example:

* The variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.
* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.

## Component instance .NET method helper class

A helper class can invoke a .NET instance method as an <xref:System.Action>. Helper classes are useful in the following scenarios:

* When several components of the same type are rendered on the same page.
* In a Blazor Server apps, where multiple users concurrently use the same component.

In the following example:

* The `CallDotNetExample6` component contains several `ListItem` components, which is a shared component in the app's `Shared` folder.
* Each `ListItem` component is composed of a message and a button.
* When a `ListItem` component button is selected, that `ListItem`'s `UpdateMessage` method changes the list item text and hides the button.

The following `MessageUpdateInvokeHelper` class maintains a JS-invokable .NET method, `UpdateMessageCaller`, to invoke the <xref:System.Action> specified when the class is instantiated. `BlazorSample` is the app's assembly name.

`MessageUpdateInvokeHelper.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/MessageUpdateInvokeHelper.cs?highlight=7,12-16)]

The following `updateMessageCaller` JS function invokes the `UpdateMessageCaller` .NET method. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server):

```html
<script>
  window.updateMessageCaller = (dotNetHelper) => {
    dotNetHelper.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller');
    dotNetHelper.dispose();
  }
</script>
```

In the preceding example, the variable name `dotNetHelper` is arbitrary and can be changed to any preferred name.

The following `ListItem` component is a shared component that can be used any number of times in a parent component and creates list items (`<li>...</li>`) for an HTML list (`<ul>...</ul>` or `<ol>...</ol>`). Each `ListItem` component instance establishes an instance of `MessageUpdateInvokeHelper` with an <xref:System.Action> set to its `UpdateMessage` method.

When a `ListItem` component's **`InteropCall`** button is selected, `updateMessageCaller` is invoked with a created <xref:Microsoft.JSInterop.DotNetObjectReference> for the `MessageUpdateInvokeHelper` instance. This permits the framework to call `UpdateMessageCaller` on that `ListItem`'s `MessageUpdateInvokeHelper` instance. The passed <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in JS (`dotNetHelper.dispose()`).

`Shared/ListItem.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/call-dotnet-from-js/ListItem.razor)]

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

The following `CallDotNetExample6` parent component includes four list items, each an instance of the `ListItem` component.

`Pages/CallDotNetExample6.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample6.razor?highlight=6-9)]

The following image shows the rendered `CallDotNetExample6` parent component after the second **`InteropCall`** button is selected:

* The second `ListItem` component has displayed the `UpdateMessage Called!` message.
* The **`InteropCall`** button for the second `ListItem` component isn't visible because the button's CSS `display` property is set to `none`.

![Rendered 'CallDotNetExample6' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-6.png)

## Location of JavaScript

Load JavaScript (JS) code using any of approaches described by the [JS interop overview article](xref:blazor/js-interop/index#location-of-javascript):

* [Load a script in `<head>` markup](xref:blazor/js-interop/index#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](xref:blazor/js-interop/index#load-a-script-in-body-markup)
* [Load a script from an external JS file (`.js`)](xref:blazor/js-interop/index#load-a-script-from-an-external-js-file-js)
* [Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)

For information on isolating scripts in [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules), see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript method calls from C# when the return type has circular references.

## Byte array support

Blazor supports optimized byte array JS interop that avoids encoding/decoding byte arrays into Base64. The following example uses JS interop to pass a byte array to .NET.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Layout.cshtml` (Blazor Server), provide a `sendByteArray` JS function. The function is called by a button in the component and doesn't return a value:

```html
<script>
  window.sendByteArray = () => {
    const data = new Uint8Array([0x45,0x76,0x65,0x72,0x79,0x74,0x68,0x69,
      0x6e,0x67,0x27,0x73,0x20,0x73,0x68,0x69,0x6e,0x79,0x2c,
      0x20,0x43,0x61,0x70,0x74,0x69,0x61,0x6e,0x2e,0x20,0x4e,
      0x6f,0x74,0x20,0x74,0x6f,0x20,0x66,0x72,0x65,0x74,0x2e]);
    DotNet.invokeMethodAsync('BlazorSample', 'ReceiveByteArray', data)
      .then(str => {
        alert(str);
      });
  };
</script>
```

`Pages/CallDotNetExample7.razor`:

```razor
@page "/call-dotnet-example-7"
@using System.Text

<h1>Call .NET Example 7</h1>

<p>
    <button onclick="sendByteArray()">Send Bytes</button>
</p>

<p>
    Quote &copy;2005 <a href="https://www.uphe.com">Universal Pictures</a>:
    <a href="https://www.uphe.com/movies/serenity-2005">Serenity</a><br>
    <a href="https://www.imdb.com/name/nm0821612/">Jewel Staite on IMDB</a>
</p>

@code {
    [JSInvokable]
    public static Task<string> ReceiveByteArray(byte[] receivedBytes)
    {
        return Task.FromResult(
            Encoding.UTF8.GetString(receivedBytes, 0, receivedBytes.Length));
    }
}
```

For information on using a byte array when calling JavaScript from .NET, see <xref:blazor/js-interop/call-javascript-from-dotnet#byte-array-support>.

## Stream from JavaScript to .NET

Blazor supports streaming data directly from JavaScript to .NET. Streams are requested using the `Microsoft.JSInterop.IJSStreamReference` interface.

`Microsoft.JSInterop.IJSStreamReference.OpenReadStreamAsync` returns a <xref:System.IO.Stream> and uses the following parameters:

* `maxAllowedSize`: Maximum number of bytes permitted for the read operation from JavaScript, which defaults to 512,000 bytes if not specified.
* `cancellationToken`: A <xref:System.Threading.CancellationToken> for cancelling the read.

In JavaScript:

```javascript
function streamToDotNet() {
  return new Uint8Array(10000000);
}
```

In C# code:

```csharp
var dataReference = 
    await JS.InvokeAsync<IJSStreamReference>("streamToDotNet");
using var dataReferenceStream = 
    await dataReference.OpenReadStreamAsync(maxAllowedSize: 10_000_000);

var outputPath = Path.Combine(Path.GetTempPath(), "file.txt");
using var outputFileStream = File.OpenWrite(outputPath);
await dataReferenceStream.CopyToAsync(outputFileStream);
```

In the preceding example:

* `JS` is an injected <xref:Microsoft.JSInterop.IJSRuntime> instance.
* The `dataReferenceStream` is written to disk (`file.txt`) at the current user's temporary folder path (<xref:System.IO.Path.GetTempPath%2A>).

<xref:blazor/js-interop/call-javascript-from-dotnet#stream-from-net-to-javascript> covers the reverse operation, streaming from .NET to JavaScript using a <xref:Microsoft.JSInterop.DotNetStreamReference>.

<xref:blazor/file-uploads> covers how to upload a file in Blazor.

## Size limits on JavaScript interop calls

[!INCLUDE[](~/blazor/includes/js-interop/6.0/size-limits.md)]

## Additional resources

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
* [Interaction with the Document Object Model (DOM)](xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

For information on how to call JS functions from .NET, see <xref:blazor/js-interop/call-javascript-from-dotnet>.

## Invoke a static .NET method

To invoke a static .NET method from JavaScript (JS), use the JS functions `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`. Pass in the name of the assembly containing the method, the identifier of the static .NET method, and any arguments.

In the following example:

* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.
* The `{ARGUMENTS}` placeholder are optional, comma-separated arguments to pass to the method, each of which must be JSON-serializable.

```javascript
DotNet.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}', {ARGUMENTS});
```

`DotNet.invokeMethod` returns the result of the operation. `DotNet.invokeMethodAsync` returns a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) representing the result of the operation.

The asynchronous function (`invokeMethodAsync`) is preferred over the synchronous version (`invokeMethod`) to support Blazor Server scenarios.

The .NET method must be public, static, and have the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute).

In the following example:

* The `{<T>}` placeholder indicates the return type, which is only required for methods that return a value.
* The `{.NET METHOD ID}` placeholder is the method identifier.

```razor
@code {
    [JSInvokable]
    public static Task{<T>} {.NET METHOD ID}()
    {
        ...
    }
}
```

> [!NOTE]
> Calling open generic methods isn't supported with static .NET methods but is supported with [instance methods](#invoke-an-instance-net-method), which are described later in this article.

In the following `CallDotNetExample1` component, the `ReturnArrayAsync` C# method returns an `int` array. The [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) is applied to the method, which makes the method invokable by JS.

`Pages/CallDotNetExample1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample1.razor?highlight=12-16)]

The `<button>` element's `onclick` HTML attribute is JavaScript's [`onclick`](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick) event handler assignment for processing [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) events, not Blazor's `@onclick` directive attribute. The `returnArrayAsync` JS function is assigned as the handler.

The following `returnArrayAsync` JS function, calls the `ReturnArrayAsync` .NET method of the preceding `CallDotNetExample1` component and logs the result to the browser's web developer tools console. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.returnArrayAsync = () => {
    DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
      .then(data => {
        console.log(data);
      });
    };
</script>
```

When the **`Trigger .NET static method`** button is selected, the browser's developer tools console output displays the array data. The format of the output differs slightly among browsers. The following output shows the format used by Microsoft Edge:

```console
Array(3) [ 1, 2, 3 ]
```

By default, the .NET method identifier for the JS call is the .NET method name, but you can specify a different identifier using the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) constructor. In the following example, `DifferentMethodName` is the assigned method identifier for the `ReturnArrayAsync` method:

```csharp
[JSInvokable("DifferentMethodName")]
```

In the call to `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`, call `DifferentMethodName` to execute the `ReturnArrayAsync` .NET method:

* `DotNet.invokeMethod('BlazorSample', 'DifferentMethodName');`
* `DotNet.invokeMethodAsync('BlazorSample', 'DifferentMethodName');`

> [!NOTE]
> The `ReturnArrayAsync` method example in this section returns the result of a <xref:System.Threading.Tasks.Task> without the use of explicit C# [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords. Coding methods with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) is typical of methods that use the [`await`](/dotnet/csharp/language-reference/operators/await) keyword to return the value of asynchronous operations.
>
> `ReturnArrayAsync` method composed with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords:
>
> ```csharp
> [JSInvokable]
> public static async Task<int[]> ReturnArrayAsync()
> {
>     return await Task.FromResult(new int[] { 1, 2, 3 });
> }
> ```
>
> For more information, see [Asynchronous programming with async and await](/dotnet/csharp/programming-guide/concepts/async/) in the C# guide.

## Invoke an instance .NET method

To invoke an instance .NET method from JavaScript (JS):

* Pass the .NET instance by reference to JS by wrapping the instance in a <xref:Microsoft.JSInterop.DotNetObjectReference> and calling <xref:Microsoft.JSInterop.DotNetObjectReference.Create%2A> on it.
* Invoke a .NET instance method from JS using `invokeMethod` or `invokeMethodAsync` from the passed <xref:Microsoft.JSInterop.DotNetObjectReference>. The .NET instance can also be passed as an argument when invoking other .NET methods from JS.
* Dispose of the <xref:Microsoft.JSInterop.DotNetObjectReference>.

The following sections of this article demonstrate various approaches for invoking an instance .NET method:

* [Component instance examples](#component-instance-examples)
* [Class instance examples](#class-instance-examples)
* [Component instance .NET method helper class](#component-instance-net-method-helper-class)

## Component instance examples

The following `sayHello1` JS function receives a <xref:Microsoft.JSInterop.DotNetObjectReference> and calls `invokeMethodAsync` to call the `GetHelloMethod` .NET method of a component.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

For the following `CallDotNetExample2` component:

* The component has a JS-invokable .NET method named `GetHelloMessage`.
* When the **`Trigger .NET instance method`** button is selected, the JS function `sayHello1` is called with the <xref:Microsoft.JSInterop.DotNetObjectReference>.
* `sayHello1`:
  * Calls `GetHelloMessage` and receives the message result.
  * Returns the message result to the calling `TriggerDotNetInstanceMethod` method.
* The returned message from `sayHello1` in `result` is displayed to the user.
* To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

`Pages/CallDotNetExample2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample2.razor?highlight=30-31,34-35)]

To pass arguments to an instance method:

1. Add parameters to the .NET method invocation. In the following example, a name is passed to the method. Add additional parameters to the list as needed.

   ```html
   <script>
     window.sayHello2 = (dotNetHelper, name) => {
       return dotNetHelper.invokeMethodAsync('GetHelloMessage', name);
     };
   </script>
   ```

1. Provide the parameter list to the .NET method.

   `Pages/CallDotNetExample3.razor`:

   [!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample3.razor?highlight=31,35)]

## Class instance examples

The following `sayHello1` JS function:

* Calls the `GetHelloMessage` .NET method on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>.
* Returns the message from `GetHelloMessage` to the `sayHello1` caller.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

The following `HelloHelper` class has a JS-invokable .NET method named `GetHelloMessage`. When `HelloHelper` is created, the name in the `Name` property is used to return a message from `GetHelloMessage`.

`HelloHelper.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/HelloHelper.cs?highlight=5,12-13)]

The `CallHelloHelperGetHelloMessage` method in the following `JsInteropClasses3` class invokes the JS function `sayHello1` with a new instance of `HelloHelper`.

`JsInteropClasses3.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/JsInteropClasses3.cs?highlight=15-20)]

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

When the **`Trigger .NET instance method`** button is selected in the following `CallDotNetExample4` component, `JsInteropClasses3.CallHelloHelperGetHelloMessage` is called with the value of `name`.

`Pages/CallDotNetExample4.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample4.razor?highlight=28-32)]

The following image shows the rendered component with the name `Amy Pond` in the `Name` field. After the button is selected, `Hello, Amy Pond!` is displayed in the UI:

![Rendered 'CallDotNetExample4' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-4.png)

The preceding pattern shown in the `JsInteropClasses3` class can also be implemented entirely in a component.

`Pages/CallDotNetExample5.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample5.razor)]

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

The output displayed by the `CallDotNetExample5` component is `Hello, Amy Pond!` when the name `Amy Pond` is provided in the `Name` field.

In the preceding `CallDotNetExample5` component, the .NET object reference is disposed. If a class or component doesn't dispose the <xref:Microsoft.JSInterop.DotNetObjectReference>, dispose it from the client by calling `dispose` on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>:

```javascript
window.jsFunction = (dotNetHelper) => {
  dotNetHelper.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}');
  dotNetHelper.dispose();
}
```

In the preceding example:

* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.

## Component instance .NET method helper class

A helper class can invoke a .NET instance method as an <xref:System.Action>. Helper classes are useful in the following scenarios:

* When several components of the same type are rendered on the same page.
* In a Blazor Server apps, where multiple users concurrently use the same component.

In the following example:

* The `CallDotNetExample6` component contains several `ListItem` components, which is a shared component in the app's `Shared` folder.
* Each `ListItem` component is composed of a message and a button.
* When a `ListItem` component button is selected, that `ListItem`'s `UpdateMessage` method changes the list item text and hides the button.

The following `MessageUpdateInvokeHelper` class maintains a JS-invokable .NET method, `UpdateMessageCaller`, to invoke the <xref:System.Action> specified when the class is instantiated. `BlazorSample` is the app's assembly name.

`MessageUpdateInvokeHelper.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/MessageUpdateInvokeHelper.cs?highlight=8,13-17)]

The following `updateMessageCaller` JS function invokes the `UpdateMessageCaller` .NET method. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.updateMessageCaller = (dotNetHelper) => {
    dotNetHelper.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller');
    dotNetHelper.dispose();
  }
</script>
```

The following `ListItem` component is a shared component that can be used any number of times in a parent component and creates list items (`<li>...</li>`) for an HTML list (`<ul>...</ul>` or `<ol>...</ol>`). Each `ListItem` component instance establishes an instance of `MessageUpdateInvokeHelper` with an <xref:System.Action> set to its `UpdateMessage` method.

When a `ListItem` component's **`InteropCall`** button is selected, `updateMessageCaller` is invoked with a created <xref:Microsoft.JSInterop.DotNetObjectReference> for the `MessageUpdateInvokeHelper` instance. This permits the framework to call `UpdateMessageCaller` on that `ListItem`'s `MessageUpdateInvokeHelper` instance. The passed <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in JS (`dotNetHelper.dispose()`).

`Shared/ListItem.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/call-dotnet-from-js/ListItem.razor?highlight=1,5,11,15,18-22,24)]

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

The following `CallDotNetExample6` parent component includes four list items, each an instance of the `ListItem` component.

`Pages/CallDotNetExample6.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample6.razor?highlight=6-9)]

The following image shows the rendered `CallDotNetExample6` parent component after the second **`InteropCall`** button is selected:

* The second `ListItem` component has displayed the `UpdateMessage Called!` message.
* The **`InteropCall`** button for the second `ListItem` component isn't visible because the button's CSS `display` property is set to `none`.

![Rendered 'CallDotNetExample6' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-6.png)

## Location of JavaScript

Load JavaScript (JS) code using any of approaches described by the [JS interop overview article](xref:blazor/js-interop/index#location-of-javascript):

* [Load a script in `<head>` markup](xref:blazor/js-interop/index#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](xref:blazor/js-interop/index#load-a-script-in-body-markup)
* [Load a script from an external JavaScript file (`.js`) collocated with a component](xref:blazor/js-interop/index#load-a-script-from-an-external-javascript-file-js-collocated-with-a-component)
* [Load a script from an external JS file (`.js`)](xref:blazor/js-interop/index#load-a-script-from-an-external-js-file-js)
* [Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)

For information on isolating scripts in [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules), see the [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules) section.

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript method calls from C# when the return type has circular references.

## Size limits on JavaScript interop calls

[!INCLUDE[](~/blazor/includes/js-interop/5.0/size-limits.md)]

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules>.

## Additional resources

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
* [Interaction with the Document Object Model (DOM)](xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For information on how to call JS functions from .NET, see <xref:blazor/js-interop/call-javascript-from-dotnet>.

## Invoke a static .NET method

To invoke a static .NET method from JavaScript (JS), use the JS functions `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`. Pass in the name of the assembly containing the method, the identifier of the static .NET method, and any arguments.

In the following example:

* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.
* The `{ARGUMENTS}` placeholder are optional, comma-separated arguments to pass to the method, each of which must be JSON-serializable.

```javascript
DotNet.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}', {ARGUMENTS});
```

`DotNet.invokeMethod` returns the result of the operation. `DotNet.invokeMethodAsync` returns a [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) representing the result of the operation.

The asynchronous function (`invokeMethodAsync`) is preferred over the synchronous version (`invokeMethod`) to support Blazor Server scenarios.

The .NET method must be public, static, and have the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute).

In the following example:

* The `{<T>}` placeholder indicates the return type, which is only required for methods that return a value.
* The `{.NET METHOD ID}` placeholder is the method identifier.

```razor
@code {
    [JSInvokable]
    public static Task{<T>} {.NET METHOD ID}()
    {
        ...
    }
}
```

> [!NOTE]
> Calling open generic methods isn't supported with static .NET methods but is supported with [instance methods](#invoke-an-instance-net-method), which are described later in this article.

In the following `CallDotNetExample1` component, the `ReturnArrayAsync` C# method returns an `int` array. The [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) is applied to the method, which makes the method invokable by JS.

`Pages/CallDotNetExample1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample1.razor?highlight=12-16)]

The `<button>` element's `onclick` HTML attribute is JavaScript's [`onclick`](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick) event handler assignment for processing [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) events, not Blazor's `@onclick` directive attribute. The `returnArrayAsync` JS function is assigned as the handler.

The following `returnArrayAsync` JS function, calls the `ReturnArrayAsync` .NET method of the preceding `CallDotNetExample1` component and logs the result to the browser's web developer tools console. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.returnArrayAsync = () => {
    DotNet.invokeMethodAsync('BlazorSample', 'ReturnArrayAsync')
      .then(data => {
        console.log(data);
      });
    };
</script>
```

When the **`Trigger .NET static method`** button is selected, the browser's developer tools console output displays the array data. The format of the output differs slightly among browsers. The following output shows the format used by Microsoft Edge:

```console
Array(3) [ 1, 2, 3 ]
```

By default, the .NET method identifier for the JS call is the .NET method name, but you can specify a different identifier using the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) constructor. In the following example, `DifferentMethodName` is the assigned method identifier for the `ReturnArrayAsync` method:

```csharp
[JSInvokable("DifferentMethodName")]
```

In the call to `DotNet.invokeMethod` or `DotNet.invokeMethodAsync`, call `DifferentMethodName` to execute the `ReturnArrayAsync` .NET method:

* `DotNet.invokeMethod('BlazorSample', 'DifferentMethodName');`
* `DotNet.invokeMethodAsync('BlazorSample', 'DifferentMethodName');`

> [!NOTE]
> The `ReturnArrayAsync` method example in this section returns the result of a <xref:System.Threading.Tasks.Task> without the use of explicit C# [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords. Coding methods with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) is typical of methods that use the [`await`](/dotnet/csharp/language-reference/operators/await) keyword to return the value of asynchronous operations.
>
> `ReturnArrayAsync` method composed with [`async`](/dotnet/csharp/language-reference/keywords/async) and [`await`](/dotnet/csharp/language-reference/operators/await) keywords:
>
> ```csharp
> [JSInvokable]
> public static async Task<int[]> ReturnArrayAsync()
> {
>     return await Task.FromResult(new int[] { 1, 2, 3 });
> }
> ```
>
> For more information, see [Asynchronous programming with async and await](/dotnet/csharp/programming-guide/concepts/async/) in the C# guide.

## Invoke an instance .NET method

To invoke an instance .NET method from JavaScript (JS):

* Pass the .NET instance by reference to JS by wrapping the instance in a <xref:Microsoft.JSInterop.DotNetObjectReference> and calling <xref:Microsoft.JSInterop.DotNetObjectReference.Create%2A> on it.
* Invoke a .NET instance method from JS using `invokeMethod` or `invokeMethodAsync` from the passed <xref:Microsoft.JSInterop.DotNetObjectReference>. The .NET instance can also be passed as an argument when invoking other .NET methods from JS.
* Dispose of the <xref:Microsoft.JSInterop.DotNetObjectReference>.

The following sections of this article demonstrate various approaches for invoking an instance .NET method:

* [Component instance examples](#component-instance-examples)
* [Class instance examples](#class-instance-examples)
* [Component instance .NET method helper class](#component-instance-net-method-helper-class)

## Component instance examples

The following `sayHello1` JS function receives a <xref:Microsoft.JSInterop.DotNetObjectReference> and calls `invokeMethodAsync` to call the `GetHelloMethod` .NET method of a component.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

For the following `CallDotNetExample2` component:

* The component has a JS-invokable .NET method named `GetHelloMessage`.
* When the **`Trigger .NET instance method`** button is selected, the JS function `sayHello1` is called with the <xref:Microsoft.JSInterop.DotNetObjectReference>.
* `sayHello1`:
  * Calls `GetHelloMessage` and receives the message result.
  * Returns the message result to the calling `TriggerDotNetInstanceMethod` method.
* The returned message from `sayHello1` in `result` is displayed to the user.
* To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

`Pages/CallDotNetExample2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample2.razor?highlight=30-31,34-35)]

To pass arguments to an instance method:

1. Add parameters to the .NET method invocation. In the following example, a name is passed to the method. Add additional parameters to the list as needed.

   ```html
   <script>
     window.sayHello2 = (dotNetHelper, name) => {
       return dotNetHelper.invokeMethodAsync('GetHelloMessage', name);
     };
   </script>
   ```

1. Provide the parameter list to the .NET method.

   `Pages/CallDotNetExample3.razor`:

   [!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample3.razor?highlight=31,35)]

## Class instance examples

The following `sayHello1` JS function:

* Calls the `GetHelloMessage` .NET method on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>.
* Returns the message from `GetHelloMessage` to the `sayHello1` caller.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.sayHello1 = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

The following `HelloHelper` class has a JS-invokable .NET method named `GetHelloMessage`. When `HelloHelper` is created, the name in the `Name` property is used to return a message from `GetHelloMessage`.

`HelloHelper.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/HelloHelper.cs?highlight=5,12-13)]

The `CallHelloHelperGetHelloMessage` method in the following `JsInteropClasses3` class invokes the JS function `sayHello1` with a new instance of `HelloHelper`.

`JsInteropClasses3.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/JsInteropClasses3.cs?highlight=15-20)]

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

When the **`Trigger .NET instance method`** button is selected in the following `CallDotNetExample4` component, `JsInteropClasses3.CallHelloHelperGetHelloMessage` is called with the value of `name`.

`Pages/CallDotNetExample4.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample4.razor?highlight=28-32)]

The following image shows the rendered component with the name `Amy Pond` in the `Name` field. After the button is selected, `Hello, Amy Pond!` is displayed in the UI:

![Rendered 'CallDotNetExample4' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-4.png)

The preceding pattern shown in the `JsInteropClasses3` class can also be implemented entirely in a component.

`Pages/CallDotNetExample5.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample5.razor)]

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

The output displayed by the `CallDotNetExample5` component is `Hello, Amy Pond!` when the name `Amy Pond` is provided in the `Name` field.

In the preceding `CallDotNetExample5` component, the .NET object reference is disposed. If a class or component doesn't dispose the <xref:Microsoft.JSInterop.DotNetObjectReference>, dispose it from the client by calling `dispose` on the passed <xref:Microsoft.JSInterop.DotNetObjectReference>:

```javascript
window.jsFunction = (dotNetHelper) => {
  dotNetHelper.invokeMethodAsync('{ASSEMBLY NAME}', '{.NET METHOD ID}');
  dotNetHelper.dispose();
}
```

In the preceding example:

* The `{ASSEMBLY NAME}` placeholder is the app's assembly name.
* The `{.NET METHOD ID}` placeholder is the .NET method identifier.

## Component instance .NET method helper class

A helper class can invoke a .NET instance method as an <xref:System.Action>. Helper classes are useful in the following scenarios:

* When several components of the same type are rendered on the same page.
* In a Blazor Server apps, where multiple users concurrently use the same component.

In the following example:

* The `CallDotNetExample6` component contains several `ListItem` components, which is a shared component in the app's `Shared` folder.
* Each `ListItem` component is composed of a message and a button.
* When a `ListItem` component button is selected, that `ListItem`'s `UpdateMessage` method changes the list item text and hides the button.

The following `MessageUpdateInvokeHelper` class maintains a JS-invokable .NET method, `UpdateMessageCaller`, to invoke the <xref:System.Action> specified when the class is instantiated. `BlazorSample` is the app's assembly name.

`MessageUpdateInvokeHelper.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/MessageUpdateInvokeHelper.cs?highlight=8,13-17)]

The following `updateMessageCaller` JS function invokes the `UpdateMessageCaller` .NET method. `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.updateMessageCaller = (dotNetHelper) => {
    dotNetHelper.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller');
    dotNetHelper.dispose();
  }
</script>
```

The following `ListItem` component is a shared component that can be used any number of times in a parent component and creates list items (`<li>...</li>`) for an HTML list (`<ul>...</ul>` or `<ol>...</ol>`). Each `ListItem` component instance establishes an instance of `MessageUpdateInvokeHelper` with an <xref:System.Action> set to its `UpdateMessage` method.

When a `ListItem` component's **`InteropCall`** button is selected, `updateMessageCaller` is invoked with a created <xref:Microsoft.JSInterop.DotNetObjectReference> for the `MessageUpdateInvokeHelper` instance. This permits the framework to call `UpdateMessageCaller` on that `ListItem`'s `MessageUpdateInvokeHelper` instance. The passed <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in JS (`dotNetHelper.dispose()`).

`Shared/ListItem.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/call-dotnet-from-js/ListItem.razor?highlight=1,5,11,15,18-22,24)]

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

The following `CallDotNetExample6` parent component includes four list items, each an instance of the `ListItem` component.

`Pages/CallDotNetExample6.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample6.razor?highlight=6-9)]

The following image shows the rendered `CallDotNetExample6` parent component after the second **`InteropCall`** button is selected:

* The second `ListItem` component has displayed the `UpdateMessage Called!` message.
* The **`InteropCall`** button for the second `ListItem` component isn't visible because the button's CSS `display` property is set to `none`.

![Rendered 'CallDotNetExample6' component example](~/blazor/javascript-interoperability/call-dotnet-from-javascript/_static/component-example-6.png)

## Location of JavaScript

Load JavaScript (JS) code using any of approaches described by the [JS interop overview article](xref:blazor/js-interop/index#location-of-javascript):

* [Load a script in `<head>` markup](xref:blazor/js-interop/index#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](xref:blazor/js-interop/index#load-a-script-in-body-markup)
* [Load a script from an external JS file (`.js`)](xref:blazor/js-interop/index#load-a-script-from-an-external-js-file-js)
* [Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript method calls from C# when the return type has circular references.

## Size limits on JavaScript interop calls

[!INCLUDE[](~/blazor/includes/js-interop/3.1/size-limits.md)]

## Additional resources

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
* [Interaction with the Document Object Model (DOM)](xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom)

:::moniker-end
