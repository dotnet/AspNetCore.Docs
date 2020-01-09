---
title: ASP.NET Core Blazor JavaScript interop
author: guardrex
description: Learn how to invoke JavaScript functions from .NET and .NET methods from JavaScript in Blazor apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
no-loc: [Blazor]
uid: blazor/javascript-interop
---
# ASP.NET Core Blazor JavaScript interop

By [Javier Calvarro Nelson](https://github.com/javiercn), [Daniel Roth](https://github.com/danroth27), and [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazorwasm-preview-notice.md)]

A Blazor app can invoke JavaScript functions from .NET and .NET methods from JavaScript code.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

## Invoke JavaScript functions from .NET methods

There are times when .NET code is required to call a JavaScript function. For example, a JavaScript call can expose browser capabilities or functionality from a JavaScript library to the app. This scenario is called *JavaScript interoperability* (*JS interop*).

To call into JavaScript from .NET, use the `IJSRuntime` abstraction. To issue JS interop calls, inject the `IJSRuntime` abstraction in your component. The `InvokeAsync<T>` method takes an identifier for the JavaScript function that you wish to invoke along with any number of JSON-serializable arguments. The function identifier is relative to the global scope (`window`). If you wish to call `window.someScope.someFunction`, the identifier is `someScope.someFunction`. There's no need to register the function before it's called. The return type `T` must also be JSON serializable. `T` should match the .NET type that best maps to the JSON type returned.

For Blazor Server apps with prerendering enabled, calling into JavaScript isn't possible during the initial prerendering. JavaScript interop calls must be deferred until after the connection with the browser is established. For more information, see the [Detect when a Blazor app is prerendering](#detect-when-a-blazor-app-is-prerendering) section.

The following example is based on [TextDecoder](https://developer.mozilla.org/docs/Web/API/TextDecoder), an experimental JavaScript-based decoder. The example demonstrates how to invoke a JavaScript function from a C# method. The JavaScript function accepts a byte array from a C# method, decodes the array, and returns the text to the component for display.

Inside the `<head>` element of *wwwroot/index.html* (Blazor WebAssembly) or *Pages/_Host.cshtml* (Blazor Server), provide a JavaScript function that uses `TextDecoder` to decode a passed array and return the decoded value:

[!code-html[](javascript-interop/samples_snapshot/index-script-convertarray.html)]

JavaScript code, such as the code shown in the preceding example, can also be loaded from a JavaScript file (*.js*) with a reference to the script file:

```html
<script src="exampleJsInterop.js"></script>
```

The following component:

* Invokes the `convertArray` JavaScript function using `JSRuntime` when a component button (**Convert Array**) is selected.
* After the JavaScript function is called, the passed array is converted into a string. The string is returned to the component for display.

[!code-razor[](javascript-interop/samples_snapshot/call-js-example.razor?highlight=2,34-35)]

## Use of IJSRuntime

To use the `IJSRuntime` abstraction, adopt any of the following approaches:

* Inject the `IJSRuntime` abstraction into the Razor component (*.razor*):

  [!code-razor[](javascript-interop/samples_snapshot/inject-abstraction.razor?highlight=1)]

  Inside the `<head>` element of *wwwroot/index.html* (Blazor WebAssembly) or *Pages/_Host.cshtml* (Blazor Server), provide a `handleTickerChanged` JavaScript function. The function is called with `IJSRuntime.InvokeVoidAsync` and doesn't return a value:

  [!code-html[](javascript-interop/samples_snapshot/index-script-handleTickerChanged1.html)]

* Inject the `IJSRuntime` abstraction into a class (*.cs*):

  [!code-csharp[](javascript-interop/samples_snapshot/inject-abstraction-class.cs?highlight=5)]

  Inside the `<head>` element of *wwwroot/index.html* (Blazor WebAssembly) or *Pages/_Host.cshtml* (Blazor Server), provide a `handleTickerChanged` JavaScript function. The function is called with `JSRuntime.InvokeAsync` and returns a value:

  [!code-html[](javascript-interop/samples_snapshot/index-script-handleTickerChanged2.html)]

* For dynamic content generation with [BuildRenderTree](xref:blazor/components#manual-rendertreebuilder-logic), use the `[Inject]` attribute:

  ```razor
  [Inject]
  IJSRuntime JSRuntime { get; set; }
  ```

In the client-side sample app that accompanies this topic, two JavaScript functions are available to the app that interact with the DOM to receive user input and display a welcome message:

* `showPrompt` &ndash; Produces a prompt to accept user input (the user's name) and returns the name to the caller.
* `displayWelcome` &ndash; Assigns a welcome message from the caller to a DOM object with an `id` of `welcome`.

*wwwroot/exampleJsInterop.js*:

[!code-javascript[](./common/samples/3.x/BlazorWebAssemblySample/wwwroot/exampleJsInterop.js?highlight=2-7)]

Place the `<script>` tag that references the JavaScript file in the *wwwroot/index.html* file (Blazor WebAssembly) or *Pages/_Host.cshtml* file (Blazor Server).

*wwwroot/index.html* (Blazor WebAssembly):

[!code-html[](./common/samples/3.x/BlazorWebAssemblySample/wwwroot/index.html?highlight=15)]

*Pages/_Host.cshtml* (Blazor Server):

[!code-cshtml[](./common/samples/3.x/BlazorServerSample/Pages/_Host.cshtml?highlight=21)]

Don't place a `<script>` tag in a component file because the `<script>` tag can't be updated dynamically.

.NET methods interop with the JavaScript functions in the *exampleJsInterop.js* file by calling `IJSRuntime.InvokeAsync<T>`.

The `IJSRuntime` abstraction is asynchronous to allow for Blazor Server scenarios. If the app is a Blazor WebAssembly app and you want to invoke a JavaScript function synchronously, downcast to `IJSInProcessRuntime` and call `Invoke<T>` instead. We recommend that most JS interop libraries use the async APIs to ensure that the libraries are available in all scenarios.

The sample app includes a component to demonstrate JS interop. The component:

* Receives user input via a JavaScript prompt.
* Returns the text to the component for processing.
* Calls a second JavaScript function that interacts with the DOM to display a welcome message.

*Pages/JSInterop.razor*:

```razor
@page "/JSInterop"
@using BlazorSample.JsInteropClasses
@inject IJSRuntime JSRuntime

<h1>JavaScript Interop</h1>

<h2>Invoke JavaScript functions from .NET methods</h2>

<button type="button" class="btn btn-primary" @onclick="TriggerJsPrompt">
    Trigger JavaScript Prompt
</button>

<h3 id="welcome" style="color:green;font-style:italic"></h3>

@code {
    public async Task TriggerJsPrompt()
    {
        // showPrompt is implemented in wwwroot/exampleJsInterop.js
        var name = await JSRuntime.InvokeAsync<string>(
                "exampleJsFunctions.showPrompt",
                "What's your name?");
        // displayWelcome is implemented in wwwroot/exampleJsInterop.js
        await JSRuntime.InvokeVoidAsync(
                "exampleJsFunctions.displayWelcome",
                $"Hello {name}! Welcome to Blazor!");
    }
}
```

1. When `TriggerJsPrompt` is executed by selecting the component's **Trigger JavaScript Prompt** button, the JavaScript `showPrompt` function provided in the *wwwroot/exampleJsInterop.js* file is called.
1. The `showPrompt` function accepts user input (the user's name), which is HTML-encoded and returned to the component. The component stores the user's name in a local variable, `name`.
1. The string stored in `name` is incorporated into a welcome message, which is passed to a JavaScript function, `displayWelcome`, which renders the welcome message into a heading tag.

## Call a void JavaScript function

JavaScript functions that return [void(0)/void 0](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Operators/void) or [undefined](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/undefined) are called with `IJSRuntime.InvokeVoidAsync`.

## Detect when a Blazor app is prerendering
 
[!INCLUDE[](~/includes/blazor-prerendering.md)]

## Capture references to elements

Some JS interop scenarios require references to HTML elements. For example, a UI library may require an element reference for initialization, or you might need to call command-like APIs on an element, such as `focus` or `play`.

Capture references to HTML elements in a component using the following approach:

* Add an `@ref` attribute to the HTML element.
* Define a field of type `ElementReference` whose name matches the value of the `@ref` attribute.

The following example shows capturing a reference to the `username` `<input>` element:

```razor
<input @ref="username" ... />

@code {
    ElementReference username;
}
```

> [!WARNING]
> Only use an element reference to mutate the contents of an empty element that doesn't interact with Blazor. This scenario is useful when a 3rd party API supplies content to the element. Because Blazor doesn't interact with the element, there's no possibility of a conflict between Blazor's representation of the element and the DOM.
>
> In the following example, it's *dangerous* to mutate the contents of the unordered list (`ul`) because Blazor interacts with the DOM to populate this element's list items (`<li>`):
>
> ```razor
> <ul ref="MyList">
>     @foreach (var item in Todos)
>     {
>         <li>@item.Text</li>
>     }
> </ul>
> ```
>
> If JS interop mutates the contents of element `MyList` and Blazor attempts to apply diffs to the element, the diffs won't match the DOM.

As far as .NET code is concerned, an `ElementReference` is an opaque handle. The *only* thing you can do with `ElementReference` is pass it through to JavaScript code via JS interop. When you do so, the JavaScript-side code receives an `HTMLElement` instance, which it can use with normal DOM APIs.

For example, the following code defines a .NET extension method that enables setting the focus on an element:

*exampleJsInterop.js*:

```javascript
window.exampleJsFunctions = {
  focusElement : function (element) {
    element.focus();
  }
}
```

To call a JavaScript function that doesn't return a value, use `IJSRuntime.InvokeVoidAsync`. The following code sets the focus on the username input by calling the preceding JavaScript function with the captured `ElementReference`:

[!code-razor[](javascript-interop/samples_snapshot/component1.razor?highlight=1,3,11-12)]

To use an extension method, create a static extension method that receives the `IJSRuntime` instance:

```csharp
public static async Task Focus(this ElementReference elementRef, IJSRuntime jsRuntime)
{
    await jsRuntime.InvokeVoidAsync(
        "exampleJsFunctions.focusElement", elementRef);
}
```

The `Focus` method is called directly on the object. The following example assumes that the `Focus` method is available from the `JsInteropClasses` namespace:

[!code-razor[](javascript-interop/samples_snapshot/component2.razor?highlight=1-4,12)]

> [!IMPORTANT]
> The `username` variable is only populated after the component is rendered. If an unpopulated `ElementReference` is passed to JavaScript code, the JavaScript code receives a value of `null`. To manipulate element references after the component has finished rendering (to set the initial focus on an element) use the [OnAfterRenderAsync or OnAfterRender component lifecycle methods](xref:blazor/lifecycle#after-component-render).

When working with generic types and returning a value, use [ValueTask\<T>](xref:System.Threading.Tasks.ValueTask`1):

```csharp
public static ValueTask<T> GenericMethod<T>(this ElementReference elementRef, 
    IJSRuntime jsRuntime)
{
    return jsRuntime.InvokeAsync<T>(
        "exampleJsFunctions.doSomethingGeneric", elementRef);
}
```

`GenericMethod` is called directly on the object with a type. The following example assumes that the `GenericMethod` is available from the `JsInteropClasses` namespace:

[!code-razor[](javascript-interop/samples_snapshot/component3.razor?highlight=17)]

## Invoke .NET methods from JavaScript functions

### Static .NET method call

To invoke a static .NET method from JavaScript, use the `DotNet.invokeMethod` or `DotNet.invokeMethodAsync` functions. Pass in the identifier of the static method you wish to call, the name of the assembly containing the function, and any arguments. The asynchronous version is preferred to support Blazor Server scenarios. To invoke a .NET method from JavaScript, the .NET method must be public, static, and have the `[JSInvokable]` attribute. By default, the method identifier is the method name, but you can specify a different identifier using the `JSInvokableAttribute` constructor. Calling open generic methods isn't currently supported.

The sample app includes a C# method to return an array of `int`s. The `JSInvokable` attribute is applied to the method.

*Pages/JsInterop.razor*:

```razor
<button type="button" class="btn btn-primary"
        onclick="exampleJsFunctions.returnArrayAsyncJs()">
    Trigger .NET static method ReturnArrayAsync
</button>

@code {
    [JSInvokable]
    public static Task<int[]> ReturnArrayAsync()
    {
        return Task.FromResult(new int[] { 1, 2, 3 });
    }
}
```

JavaScript served to the client invokes the C# .NET method.

*wwwroot/exampleJsInterop.js*:

[!code-javascript[](./common/samples/3.x/BlazorWebAssemblySample/wwwroot/exampleJsInterop.js?highlight=8-14)]

When the **Trigger .NET static method ReturnArrayAsync** button is selected, examine the console output in the browser's web developer tools.

The console output is:

```console
Array(4) [ 1, 2, 3, 4 ]
```

The fourth array value is pushed to the array (`data.push(4);`) returned by `ReturnArrayAsync`.

### Instance method call

You can also call .NET instance methods from JavaScript. To invoke a .NET instance method from JavaScript:

* Pass the .NET instance to JavaScript by wrapping it in a `DotNetObjectReference` instance. The .NET instance is passed by reference to JavaScript.
* Invoke .NET instance methods on the instance using the `invokeMethod` or `invokeMethodAsync` functions. The .NET instance can also be passed as an argument when invoking other .NET methods from JavaScript.

> [!NOTE]
> The sample app logs messages to the client-side console. For the following examples demonstrated by the sample app, examine the browser's console output in the browser's developer tools.

When the **Trigger .NET instance method HelloHelper.SayHello** button is selected, `ExampleJsInterop.CallHelloHelperSayHello` is called and passes a name, `Blazor`, to the method.

*Pages/JsInterop.razor*:

```razor
<button type="button" class="btn btn-primary" @onclick="TriggerNetInstanceMethod">
    Trigger .NET instance method HelloHelper.SayHello
</button>

@code {
    public async Task TriggerNetInstanceMethod()
    {
        var exampleJsInterop = new ExampleJsInterop(JSRuntime);
        await exampleJsInterop.CallHelloHelperSayHello("Blazor");
    }
}
```

`CallHelloHelperSayHello` invokes the JavaScript function `sayHello` with a new instance of `HelloHelper`.

*JsInteropClasses/ExampleJsInterop.cs*:

[!code-csharp[](./common/samples/3.x/BlazorWebAssemblySample/JsInteropClasses/ExampleJsInterop.cs?name=snippet1&highlight=10-16)]

*wwwroot/exampleJsInterop.js*:

[!code-javascript[](./common/samples/3.x/BlazorWebAssemblySample/wwwroot/exampleJsInterop.js?highlight=15-18)]

The name is passed to `HelloHelper`'s constructor, which sets the `HelloHelper.Name` property. When the JavaScript function `sayHello` is executed, `HelloHelper.SayHello` returns the `Hello, {Name}!` message, which is written to the console by the JavaScript function.

*JsInteropClasses/HelloHelper.cs*:

[!code-csharp[](./common/samples/3.x/BlazorWebAssemblySample/JsInteropClasses/HelloHelper.cs?name=snippet1&highlight=5,10-11)]

Console output in the browser's web developer tools:

```console
Hello, Blazor!
```

## Share interop code in a class library

JS interop code can be included in a class library, which allows you to share the code in a NuGet package.

The class library handles embedding JavaScript resources in the built assembly. The JavaScript files are placed in the *wwwroot* folder. The tooling takes care of embedding the resources when the library is built.

The built NuGet package is referenced in the app's project file the same way that any NuGet package is referenced. After the package is restored, app code can call into JavaScript as if it were C#.

For more information, see <xref:blazor/class-libraries>.

## Harden JS interop calls

JS interop may fail due to networking errors and should be treated as unreliable. By default, a Blazor Server app times out JS interop calls on the server after one minute. If an app can tolerate a more aggressive timeout, such as 10 seconds, set the timeout using one of the following approaches:

* Globally in `Startup.ConfigureServices`, specify the timeout:

  ```csharp
  services.AddServerSideBlazor(
      options => options.JSInteropDefaultCallTimeout = TimeSpan.FromSeconds({SECONDS}));
  ```

* Per-invocation in component code, a single call can specify the timeout:

  ```csharp
  var result = await JSRuntime.InvokeAsync<string>("MyJSOperation", 
      TimeSpan.FromSeconds({SECONDS}), new[] { "Arg1" });
  ```

For more information on resource exhaustion, see <xref:security/blazor/server>.

## Additional resources

* [InteropComponent.razor example (dotnet/AspNetCore GitHub repository, 3.0 release branch)](https://github.com/dotnet/AspNetCore/blob/release/3.0/src/Components/test/testassets/BasicTestApp/InteropComponent.razor)
