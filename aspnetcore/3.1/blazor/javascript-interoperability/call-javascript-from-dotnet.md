---
title: Call JavaScript functions from .NET methods in ASP.NET Core Blazor
author: guardrex
description: Learn how to invoke JavaScript functions from .NET methods in Blazor apps.
monikerRange: '>= aspnetcore-3.1 < aspnetcore-5.0'
ms.author: riande
ms.custom: mvc, devx-track-js
ms.date: 05/12/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR, JS, Promise]
uid: blazor/js-interop/call-javascript-from-dotnet
---
# Call JavaScript functions from .NET methods in ASP.NET Core Blazor

This article covers invoking JavaScript (JS) functions from .NET. For information on how to call .NET methods from JS, see <xref:blazor/js-interop/call-dotnet-from-javascript>.

To call into JS from .NET, inject the <xref:Microsoft.JSInterop.IJSRuntime> abstraction and call one of the following methods:

* <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A?displayProperty=nameWithType>
* <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>

For the preceding .NET methods that invoke JS functions:

* The function identifier (`String`) is relative to the global scope (`window`). To call `window.someScope.someFunction`, the identifier is `someScope.someFunction`. There's no need to register the function before it's called.
* Pass any number of JSON-serializable arguments in `Object[]` to a JS function.
* The cancellation token (`CancellationToken`) propagates a notification that operations should be canceled.
* `TimeSpan` represents a time limit for a JS operation.
* The `TValue` return type must also be JSON serializable. `TValue` should match the .NET type that best maps to the JSON type returned.
* A [JS Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) is returned for `InvokeAsync` methods. `InvokeAsync` unwraps the [Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) and returns the value awaited by the [Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise).

For Blazor Server apps with prerendering enabled, calling into JS isn't possible during initial prerendering. JS interop calls must be deferred until after the connection with the browser is established. For more information, see the [Detect when a Blazor Server app is prerendering](#detect-when-a-blazor-server-app-is-prerendering) section.

The following example is based on [`TextDecoder`](https://developer.mozilla.org/docs/Web/API/TextDecoder), a JS-based decoder. The example demonstrates how to invoke a JS function from a C# method that offloads a requirement from developer code to an existing JS API. The JS function accepts a byte array from a C# method, decodes the array, and returns the text to the component for display.

Add the following JS code inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  window.convertArray = (win1251Array) => {
    var win1251decoder = new TextDecoder('windows-1251');
    var bytes = new Uint8Array(win1251Array);
    var decodedArray = win1251decoder.decode(bytes);
    console.log(decodedArray);
    return decodedArray;
  };
</script>
```

The following `CallJsExample1` component:

* Invokes the `convertArray` JS function with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A> when selecting a button (**`Convert Array`**).
* After the JS function is called, the passed array is converted into a string. The string is returned to the component for display (`text`).

`Pages/CallJsExample1.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample1.razor?highlight=2,34)]

## Invoke JavaScript functions without reading a returned value (`InvokeVoidAsync`)

Use <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A> when:

* .NET isn't required to read the result of a JS call.
* JS functions return [void(0)/void 0](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Operators/void) or [undefined](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/undefined).

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server), provide a `displayTickerAlert1` JS function. The function is called with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A> and doesn't return a value:

```html
<script>
  window.displayTickerAlert1 = (symbol, price) => {
    alert(`${symbol}: $${price}!`);
  };
</script>
```

### Component (`.razor`) example (`InvokeVoidAsync`)

`TickerChanged` calls the `handleTickerChanged1` method in the following `CallJsExample2` component.

`Pages/CallJsExample2.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample2.razor?highlight=2,25)]

### Class (`.cs`) example (`InvokeVoidAsync`)

`JsInteropClasses1.cs`:

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/JsInteropClasses1.cs?highlight=2,6,10,15)]

`TickerChanged` calls the `handleTickerChanged1` method in the following `CallJsExample3` component.

`Pages/CallJsExample3.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample3.razor?highlight=2-3,20,24,32,35)]

## Invoke JavaScript functions and read a returned value (`InvokeAsync`)

Use <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A> when .NET should read the result of a JS call.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server), provide a `displayTickerAlert2` JS function. The following example returns a string for display by the caller:

```html
<script>
  window.displayTickerAlert2 = (symbol, price) => {
    if (price < 20) {
      alert(`${symbol}: $${price}!`);
      return "User alerted in the browser.";
    } else {
      return "User NOT alerted.";
    }
  };
</script>
```

### Component (`.razor`) example (`InvokeAsync`)

`TickerChanged` calls the `handleTickerChanged2` method and displays the returned string in the following `CallJsExample4` component.

`Pages/CallJsExample4.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample4.razor?highlight=2,31-34)]

### Class (`.cs`) example (`InvokeAsync`)

`JsInteropClasses2.cs`:

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/JsInteropClasses2.cs?highlight=2,6,10,15)]

`TickerChanged` calls the `handleTickerChanged2` method and displays the returned string in the following `CallJsExample5` component.

`Pages/CallJsExample5.razor`:

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample5.razor?highlight=2-3,25,30,38-40,43)]

## Dynamic content generation scenarios

For dynamic content generation with [BuildRenderTree](xref:blazor/advanced-scenarios#manual-rendertreebuilder-logic), use the `[Inject]` attribute:

```razor
[Inject]
IJSRuntime JS { get; set; }
```

## Detect when a Blazor Server app is prerendering

[!INCLUDE[](../includes/prerendering.md)]

## Location of JavaScipt

Load JavaScript (JS) code using any of approaches described by the [JavaScript (JS) interoperability (interop) overview article](xref:blazor/js-interop/index#location-of-javascipt):

* [Load a script in `<head>` markup](xref:blazor/js-interop/index#load-a-script-in-head-markup) (*Not generally recommended*)
* [Load a script in `<body>` markup](xref:blazor/js-interop/index#load-a-script-in-body-markup)
* [Load a script from an external JS file (`.js`)](xref:blazor/js-interop/index#load-a-script-from-an-external-js-file-js)
* [Inject a script after Blazor starts](xref:blazor/js-interop/index#inject-a-script-after-blazor-starts)

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

## Capture references to elements

Some JavaScript (JS) interop scenarios require references to HTML elements. For example, a UI library may require an element reference for initialization, or you might need to call command-like APIs on an element, such as `click` or `play`.

Capture references to HTML elements in a component using the following approach:

* Add an `@ref` attribute to the HTML element.
* Define a field of type <xref:Microsoft.AspNetCore.Components.ElementReference> whose name matches the value of the `@ref` attribute.

The following example shows capturing a reference to the `username` `<input>` element:

```razor
<input @ref="username" ... />

@code {
    private ElementReference username;
}
```

> [!WARNING]
> Only use an element reference to mutate the contents of an empty element that doesn't interact with Blazor. This scenario is useful when a third-party API supplies content to the element. Because Blazor doesn't interact with the element, there's no possibility of a conflict between Blazor's representation of the element and the Document Object Model (DOM).
>
> In the following example, it's *dangerous* to mutate the contents of the unordered list (`ul`) because Blazor interacts with the DOM to populate this element's list items (`<li>`) from the `Todos` object:
>
> ```razor
> <ul @ref="MyList">
>     @foreach (var item in Todos)
>     {
>         <li>@item.Text</li>
>     }
> </ul>
> ```
>
> If JS interop mutates the contents of element `MyList` and Blazor attempts to apply diffs to the element, the diffs won't match the DOM.
>
> For more information, see <xref:blazor/js-interop/index#interaction-with-the-document-object-model-dom>.

An <xref:Microsoft.AspNetCore.Components.ElementReference> is passed through to JS code via JS interop. The JS code receives an `HTMLElement` instance, which it can use with normal DOM APIs. For example, the following code defines a .NET extension method (`TriggerClickEvent`) that enables sending a mouse click to an element.

The JS function `clickElement` creates a [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) event on the passed HTML element (`element`):

```javascript
window.interopFunctions = {
  clickElement : function (element) {
    element.click();
  }
}
```

To call a JS function that doesn't return a value, use <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>. The following code triggers a client-side [`click`](https://developer.mozilla.org/docs/Web/API/Element/click_event) event by calling the preceding JS function with the captured <xref:Microsoft.AspNetCore.Components.ElementReference>:

```razor
@inject IJSRuntime JS

<button @ref="exampleButton">Example Button</button>

<button @onclick="TriggerClick">
    Trigger click event on <code>Example Button</code>
</button>

@code {
    private ElementReference exampleButton;

    public async Task TriggerClick()
    {
        await JS.InvokeVoidAsync(
            "interopFunctions.clickElement", exampleButton);
    }
}
```

To use an extension method, create a static extension method that receives the <xref:Microsoft.JSInterop.IJSRuntime> instance:

```csharp
public static async Task TriggerClickEvent(this ElementReference elementRef, 
    IJSRuntime js)
{
    await js.InvokeVoidAsync("interopFunctions.clickElement", elementRef);
}
```

The `clickElement` method is called directly on the object. The following example assumes that the `TriggerClickEvent` method is available from the `JsInteropClasses` namespace:

```razor
@inject IJSRuntime JS
@using JsInteropClasses

<button @ref="exampleButton">Example Button</button>

<button @onclick="TriggerClick">
    Trigger click event on <code>Example Button</code>
</button>

@code {
    private ElementReference exampleButton;

    public async Task TriggerClick()
    {
        await exampleButton.TriggerClickEvent(JS);
    }
}
```

> [!IMPORTANT]
> The `exampleButton` variable is only populated after the component is rendered. If an unpopulated <xref:Microsoft.AspNetCore.Components.ElementReference> is passed to JS code, the JS code receives a value of `null`. To manipulate element references after the component has finished rendering, use the [`OnAfterRenderAsync` or `OnAfterRender` component lifecycle methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

When working with generic types and returning a value, use <xref:System.Threading.Tasks.ValueTask%601>:

```csharp
public static ValueTask<T> GenericMethod<T>(this ElementReference elementRef, 
    IJSRuntime js)
{
    return js.InvokeAsync<T>("{JAVASCRIPT FUNCTION}", elementRef);
}
```

The `{JAVASCRIPT FUNCTION}` placeholder is the JS function identifier.

`GenericMethod` is called directly on the object with a type. The following example assumes that the `GenericMethod` is available from the `JsInteropClasses` namespace:

```razor
@inject IJSRuntime JS
@using JsInteropClasses

<input @ref="username" />

<button @onclick="OnClickMethod">Do something generic</button>

<p>
    returnValue: @returnValue
</p>

@code {
    private ElementReference username;
    private string returnValue;

    private async Task OnClickMethod()
    {
        returnValue = await username.GenericMethod<string>(JS);
    }
}
```

## Reference elements across components

An <xref:Microsoft.AspNetCore.Components.ElementReference> can't be passed between components because:

* The instance is only guaranteed to exist after the component is rendered, which is during or after a component's <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A>/<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> method executes.
* An <xref:Microsoft.AspNetCore.Components.ElementReference> is a [`struct`](/csharp/language-reference/builtin-types/struct), which can't be passed as a [component parameter](xref:blazor/components/index#component-parameters).

For a parent component to make an element reference available to other components, the parent component can:

* Allow child components to register callbacks.
* Invoke the registered callbacks during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> event with the passed element reference. Indirectly, this approach allows child components to interact with the parent's element reference.

Add the following style to the `<head>` of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<style>
    .red { color: red }
</style>
```

Add the following script inside closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

```html
<script>
  function setElementClass(element, className) {
    var myElement = element;
    myElement.classList.add(className);
  }
</script>
```

`Pages/CallJsExample7.razor` (parent component):

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/CallJsExample7.razor?highlight=5,9)]

`Pages/CallJsExample7.razor.cs`:

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/CallJsExample7.razor.cs)]

In the preceding example, the namespace of the app is `BlazorSample` with components in the `Pages` folder. If testing the code locally, update the namespace.

`Shared/SurveyPrompt.razor` (child component):

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor?highlight=1)]

`Shared/SurveyPrompt.razor.cs`:

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor.cs)]

In the preceding example, the namespace of the app is `BlazorSample` with shared components in the `Shared` folder. If testing the code locally, update the namespace.

## Harden JavaScript interop calls

*This section primarily applies to Blazor Server apps, but Blazor WebAssembly apps may also set JS interop timeouts if conditions warrant it.*

In Blazor Server apps, JavaScript (JS) interop may fail due to networking errors and should be treated as unreliable. By default, Blazor Server apps use a one minute timeout for JS interop calls. If an app can tolerate a more aggressive timeout, set the timeout using one of the following approaches.

Set a global timeout in the `Startup.ConfigureServices` method of `Startup.cs` with <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout?displayProperty=nameWithType>:

```csharp
services.AddServerSideBlazor(
    options => options.JSInteropDefaultCallTimeout = {TIMEOUT});
```

The `{TIMEOUT}` placeholder is a <xref:System.TimeSpan> (for example, `TimeSpan.FromSeconds(80)`).

Set a per-invocation timeout in component code. The specified timeout overrides the global timeout set by <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout>:

```csharp
var result = await JS.InvokeAsync<string>("{ID}", {TIMEOUT}, new[] { "Arg1" });
```

In the preceding example:

* The `{TIMEOUT}` placeholder is a <xref:System.TimeSpan> (for example, `TimeSpan.FromSeconds(80)`).
* The `{ID}` placeholder is the identifier for the function to invoke. For example, the value `someScope.someFunction` invokes the function `window.someScope.someFunction`.

Although a common cause of JS interop failures are network failures in Blazor Server apps, per-invocation timeouts can be set for JS interop calls in Blazor WebAssembly apps. Although no SignalR circuit exists in a Blazor WebAssembly app, JS interop calls might fail for other reasons that apply in Blazor WebAssembly apps.

For more information on resource exhaustion, see <xref:blazor/security/server/threat-mitigation>.

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript method calls from C# when the return type has circular references.

## Size limits on JavaScript interop calls

[!INCLUDE[](../includes/js-interop/size-limits.md)]

## Catch JavaScript exceptions

To catch JS exceptions, wrap the JS interop in a [`try`-`catch` block](/dotnet/csharp/fundamentals/exceptions/exception-handling) and catch a <xref:Microsoft.JSInterop.JSException>.

In the following example, the `nonFunction` JS function doesn't exist. When the function isn't found, the <xref:Microsoft.JSInterop.JSException> is trapped with a <xref:System.Exception.Message> that indicates the following error:

> `Could not find 'nonFunction' ('nonFunction' was undefined).`

`Pages/CallJsExample11.razor`:

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample11.razor?highlight=28)]

## Additional resources

* <xref:blazor/js-interop/call-dotnet-from-javascript>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
