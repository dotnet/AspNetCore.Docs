---
title: Call .NET methods from JavaScript functions in ASP.NET Core Blazor
author: guardrex
description: Learn how to invoke .NET methods from JavaScript functions in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, devx-track-js 
ms.date: 05/17/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, JS, Promise]
uid: blazor/js-interop/call-dotnet-from-javascript
---
# Call .NET methods from JavaScript functions in ASP.NET Core Blazor

This article covers invoking .NET methods from JavaScript (JS). For information on how to call JS functions from .NET, see <xref:blazor/js-interop/call-javascript-from-dotnet>.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Location of JavaScipt

Load JavaScript (JS) code using any of approaches described by the [JS interop overview article](xref:blazor/js-interop/index#location-of-javascipt):

* [Load a script in `<head>` markup](xref:blazor/js-interop/index#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](xref:blazor/js-interop/index#load-a-script-in-body-markup)
* [Load a script from an external JS file (`.js`)](xref:blazor/js-interop/index#load-a-script-from-an-external-js-file-js)
* [Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)

::: moniker range=">= aspnetcore-5.0"

For information on isolating scripts in [JS modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules), see <xref:blazor/js-interop/index#javascript-isolation-in-javascript-modules>.

::: moniker-end

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

## Static .NET method call

To invoke a static .NET method from JavaScript (JS), use the `DotNet.invokeMethod` or `DotNet.invokeMethodAsync` functions. Pass in the identifier of the static method you wish to call, the name of the assembly containing the function, and any arguments. The asynchronous version is preferred to support Blazor Server scenarios. The .NET method must be public, static, and have the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute). Calling open generic methods isn't currently supported.

The `ReturnArrayAsync` C# method in the following `CallDotNetExample1` component returns an `int` array. The [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) is applied to the method, which makes the method invokable by JS.

`Pages/CallDotNetExample1.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample1.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample1.razor?highlight=1)]

::: moniker-end

JS served to the client invokes the C# .NET method.

In the preceding example, the `<button>` element's `onclick` HTML attribute is JS's [`onclick`](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick) JS event handler assignment for processing JS [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) events, not Blazor's `@onclick` directive attribute. The `returnArrayAsyncJs` JS method is assigned as the handler.

The following JS method `returnArrayAsyncJs`, calls the `ReturnArrayAsync` .NET method and logs the result to the browser's web developer tools console. `BlazorSample` in the call to `invokeMethodAsync` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.returnArrayAsyncJs = () => {
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

By default, the method identifier for the JS call is the .NET method name, but you can specify a different identifier using the [`[JSInvokable]` attribute](xref:Microsoft.JSInterop.JSInvokableAttribute) constructor. In the following example, `DifferentMethodName` is the assigned method identifier for the `ReturnArrayAsync` method:

```csharp
[JSInvokable("DifferentMethodName")]
public static Task<int[]> ReturnArrayAsync()
{
    return Task.FromResult(new int[] { 1, 2, 3 });
}
```

In the call to `invokeMethodAsync`, call `DifferentMethodName` to execute the `ReturnArrayAsync` .NET method:

```javascript
window.returnArrayAsyncJs = () => {
  DotNet.invokeMethodAsync('BlazorSample', 'DifferentMethodName')
    .then(data => {
      console.log(data);
    });
};
```

## Instance .NET method call

To invoke a .NET instance method from JavaScript (JS):

* Pass the .NET instance by reference to JS:
  * Make a static call to <xref:Microsoft.JSInterop.DotNetObjectReference.Create%2A?displayProperty=nameWithType>.
  * Wrap the instance in a <xref:Microsoft.JSInterop.DotNetObjectReference> instance and call <xref:Microsoft.JSInterop.DotNetObjectReference.Create%2A> on the <xref:Microsoft.JSInterop.DotNetObjectReference> instance. Dispose of <xref:Microsoft.JSInterop.DotNetObjectReference> objects. (An example of .NET object reference disposal appears later in this section.)
* Invoke .NET instance methods on the instance using the `invokeMethod` or `invokeMethodAsync` JS functions. The .NET instance can also be passed as an argument when invoking other .NET methods from JS.

When the **`Trigger .NET instance method`** button is selected in the following `CallDotNetExample2` component, `JsInteropClasses3.CallHelloHelperSayHello` is called with the value of `name`.

`Pages/CallDotNetExample2.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample2.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample2.razor?highlight=1)]

::: moniker-end

The following `HelloHelper` class has a JS invokable .NET method named `GetHelloMessage`. When `HelloHelper` is created, the name (`name`) is used to return a message from `GetHelloMessage`.

`HelloHelper.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/HelloHelper.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/HelloHelper.cs?highlight=1)]

::: moniker-end

The `CallHelloHelperSayHello` method in the following `JsInteropClasses3` class invokes the JS function `sayHelloJs` with a new instance of `HelloHelper`.

`JsInteropClasses3.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/JsInteropClasses3.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/JsInteropClasses3.cs?highlight=1)]

::: moniker-end

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.sayHelloJs = (dotNetHelper) => {
    return dotNetHelper.invokeMethodAsync('GetHelloMessage');
  };
</script>
```

The name is passed to `HelloHelper`'s constructor, which sets the `HelloHelper.Name` property. When the JS function `sayHelloJs` is executed, `HelloHelper.GetHelloMessage` returns the `Hello, {Name}!` message with the name appearing in place of the `{Name}` placeholder.

The following image shows the rendered component with the name `Amy Pond` in the `Name` field. After the button is selected, `Hello, Amy Pond!` is displayed in the UI:

![Component example 1](call-dotnet-from-javascript/_static/component-example-1.png)

The preceding pattern shown in the `JsInteropClasses3` class can also be implemented in a component.

`Pages/CallDotNetExample3.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample3.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample3.razor?highlight=1)]

::: moniker-end

To avoid a memory leak and allow garbage collection, the .NET object reference created by <xref:Microsoft.JSInterop.DotNetObjectReference> is disposed in the `Dispose` method.

In the preceding `CallDotNetExample3` component, the .NET object reference is disposed. If a class or component doesn't dispose the <xref:Microsoft.JSInterop.DotNetObjectReference>, dispose it from the client by calling `dispose`:

```javascript
window.jsFunction = (dotnetHelper) => {
  dotnetHelper.invokeMethodAsync('BlazorSample', 'DotNetMethod');
  dotnetHelper.dispose();
}
```

## Component instance .NET method call

*This section only applies to Blazor WebAssembly apps.*

To invoke a component's .NET methods:

* Use the `invokeMethod` or `invokeMethodAsync` function to make a static method call to the component.
* The component's static method wraps the call to its instance method as an invoked <xref:System.Action>.

> [!IMPORTANT]
> In Blazor Server apps, where several users might be concurrently using the same component, use a helper class to invoke instance methods. For more information, see the [Component instance method helper class](#component-instance-net-method-helper-class) section.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly):

```html
<script>
  window.updateMessageCallerJs1 = () => {
    DotNet.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller');
  };
</script>
```

In the preceding example, `BlazorSample` is the app's assembly name.

`Pages/CallDotNetExample4.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample4.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample4.razor?highlight=1)]

::: moniker-end

In the preceding example, the `<button>` element's `onclick` HTML attribute is JS's [`onclick`](https://developer.mozilla.org/docs/Web/API/GlobalEventHandlers/onclick) JS event handler assignment for processing JS [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) events, not Blazor's `@onclick` directive attribute. The `updateMessageCallerJs1` JS method is assigned as the handler.

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

To pass arguments to the instance method:

1. Add parameters to the JS method invocation. In the following example, a name is passed to the method. Additional parameters can be added to the list as needed.

   ```html
   <script>
     window.updateMessageCallerJs2 = (name) => {
       DotNet.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller2', name);
     };
   </script>
   ```

   In the preceding example, `BlazorSample` is the app's assembly name.

1. Provide the correct types to the <xref:System.Action> for the parameters. Provide the parameter list to the C# methods. Invoke the <xref:System.Action> (`UpdateMessage`) with the parameters (`action.Invoke(name)`).

   `Pages/CallDotNetExample5.razor`:

   ::: moniker range=">= aspnetcore-5.0"

   [!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample5.razor?highlight=1)]

   ::: moniker-end

   ::: moniker range="< aspnetcore-5.0"

   [!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample5.razor?highlight=1)]

   ::: moniker-end

  The value of `message` is displayed when the **`Call component instance .NET method`** button is selected:

  > `Sarah Jane, UpdateMessage Called!`

  [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

## Component instance .NET method helper class

*This section applies to both Blazor WebAssembly and Blazor Server apps but is especially important for JS interop in Blazor Server apps.*

A helper class can invoke a .NET instance method as an <xref:System.Action>. Helper classes are useful when:

* Several components of the same type are rendered on the same page.
* A Blazor Server app is used, where multiple users might be using a component concurrently.

In the following example:

* The `CallDotNetExample6` component contains several `ListItem` components, which is a shared component in the app's `Shared` folder.
* Each `ListItem` component is composed of a message and a button.
* When a `ListItem` component button is selected, that `ListItem`'s `UpdateMessage` method changes the list item text and hides the button.

`MessageUpdateInvokeHelper.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/MessageUpdateInvokeHelper.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/MessageUpdateInvokeHelper.cs?highlight=1)]

::: moniker-end

In the preceding example, `BlazorSample` is the app's assembly name.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.updateMessageCallerJs3 = (dotnetHelper) => {
    dotnetHelper.invokeMethodAsync('BlazorSample', 'UpdateMessageCaller3');
    dotnetHelper.dispose();
  }
</script>
```

In the preceding example, `BlazorSample` is the app's assembly name.

`Shared/ListItem.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/call-dotnet-from-js/ListItem.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/call-dotnet-from-js/ListItem.razor?highlight=1)]

::: moniker-end

[`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) is called to update the UI when `message` is set in `UpdateMessage`. If `StateHasChanged` isn't called, Blazor has no way of knowing that the UI should be updated when the <xref:System.Action> is invoked.

`Pages/CallDotNetExample6.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample6.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-dotnet-from-js/CallDotNetExample6.razor?highlight=1)]

::: moniker-end

The following image shows the rendered component where the second `ListItem` component has displayed the `UpdateMessage Called!` message following its **`InteropCall`** button selection:

![Component example 2](call-dotnet-from-javascript/_static/component-example-2.png)

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript method calls from C# when the return type has circular references.

For more information, see the following issues:

* [Circular references are not supported, take two (dotnet/aspnetcore #20525)](https://github.com/dotnet/aspnetcore/issues/20525)
* [Proposal: Add mechanism to handle circular references when serializing (dotnet/runtime #30820)](https://github.com/dotnet/runtime/issues/30820)

## Size limits on JavaScript interop calls

*This section only applies to Blazor Server apps. In Blazor WebAssembly, the framework doesn't impose a limit on the size of JavaScript (JS) interop inputs and outputs.*

In Blazor Server, JS interop calls are limited in size by the maximum incoming SignalR message size permitted for hub methods, which is enforced by <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> (default: 32 KB). JS to .NET SignalR messages larger than <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> throw an error. The framework doesn't impose a limit on the size of a SignalR message from the hub to a client.

When SignalR logging isn't set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), a message size error only appears in the browser's developer tools console:

> Error: Connection disconnected with error 'Error: Server returned an error on close: Connection closed with an error.'.

When [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) is set to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel), server-side logging surfaces an <xref:System.IO.InvalidDataException> for a message size error.

`appsettings.Development.json`:

```json
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.AspNetCore.SignalR": "Debug"
    }
  }
}
```

> System.IO.InvalidDataException: The maximum message size of 32768B was exceeded. The message size can be configured in AddHubOptions.

Increase the limit by setting <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> in `Startup.ConfigureServices`. The following example sets the maximum receive message size to 64 KB (64 * 1024):

```csharp
services.AddServerSideBlazor()
   .AddHubOptions(options => options.MaximumReceiveMessageSize = 64 * 1024);
```

Increasing the SignalR incoming message size limit comes at the cost of requiring more server resources, and it exposes the server to increased risks from a malicious user. Additionally, reading a large amount of content in to memory as strings or byte arrays can also result in allocations that work poorly with the garbage collector, resulting in additional performance penalties.

One option for reading large payloads is to send the content in smaller chunks and process the payload as a <xref:System.IO.Stream>. This can be used when reading large JSON payloads or if data is available in JS as raw bytes. For an example that demonstrates sending large binary payloads in Blazor Server that uses techniques similar to the `InputFile` component, see the [Binary Submit sample app](https://github.com/aspnet/samples/tree/master/samples/aspnetcore/blazor/BinarySubmit).

Consider the following guidance when developing code that transfers a large amount of data between JS and Blazor:

* Slice the data into smaller pieces, and send the data segments sequentially until all of the data is received by the server.
* Don't allocate large objects in JS and C# code.
* Don't block the main UI thread for long periods when sending or receiving data.
* Free any memory consumed when the process is completed or cancelled.
* Enforce the following additional requirements for security purposes:
  * Declare the maximum file or data size that can be passed.
  * Declare the minimum upload rate from the client to the server.
* After the data is received by the server, the data can be:
  * Temporarily stored in a memory buffer until all of the segments are collected.
  * Consumed immediately. For example, the data can be stored immediately in a database or written to disk as each segment is received.

## JavaScript modules

For JS isolation, JS interop works with the browser's default support for [EcmaScript modules (ESM)](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

## Additional resources

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
