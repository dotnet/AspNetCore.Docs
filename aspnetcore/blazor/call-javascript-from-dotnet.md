---
title: Call JavaScript functions from .NET methods in ASP.NET Core Blazor
author: guardrex
description: Learn how to invoke JavaScript functions from .NET methods in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc, devx-track-js
ms.date: 05/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/call-javascript-from-dotnet
---
# Call JavaScript functions from .NET methods in ASP.NET Core Blazor

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JavaScript functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

This article covers invoking JS functions from .NET. For information on how to call .NET methods from JavaScript, see <xref:blazor/call-dotnet-from-javascript>.

To call into JS from .NET, inject the <xref:Microsoft.JSInterop.IJSRuntime> abstraction. To issue JS interop calls, inject the <xref:Microsoft.JSInterop.IJSRuntime> abstraction in your component. <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> takes an identifier for the JS function that you wish to invoke along with any number of JSON-serializable arguments. The function identifier is relative to the global scope (`window`). If you wish to call `window.someScope.someFunction`, the identifier is `someScope.someFunction`. There's no need to register the function before it's called. The return type `T` must also be JSON serializable. `T` should match the .NET type that best maps to the JSON type returned.

JS functions that return a [Promise](https://developer.mozilla.org/docs/Web/JavaScript/Reference/Global_Objects/Promise) are called with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>. `InvokeAsync` unwraps the Promise and returns the value awaited by the Promise.

For Blazor Server apps with prerendering enabled, calling into JS isn't possible during the initial prerendering. JS interop calls must be deferred until after the connection with the browser is established. For more information, see the [Detect when a Blazor Server app is prerendering](#detect-when-a-blazor-server-app-is-prerendering) section.

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

The following `CallJsExample` component:

* Invokes the `convertArray` JS function using `JS` when a component button (**`Convert Array`**) is selected by calling <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A>.
* After the JS function is called, the passed array is converted into a string. The string is returned to the component for display.

`Pages/CallJsExample1.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample1.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample1.razor?highlight=1)]

::: moniker-end

## Location of JavaScipt

<!-- From JNC: If the script depends on Blazor and you can't change the app to explicitly start Blazor and then invoke the script in the callback, then putting it afterwards is the best option. Normally people run into this because they are using JS interop. -->

JavaScript (JS) code can be loaded:

* From an external JS file (`.js`). Place a `<script>` tag before the closing `</body>` tag after the Blazor script reference. The Blazor script in a Blazor WebAssembly app is `blazor.webassembly.js`. The Blazor script in a Blazor Server app is `blazor.server.js`.

  Placing external scripts inside the closing `</body>` tag is the best approach for including external scripts, especially for scripts that participate in JS interop.

  In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server):

  ```html
  <body>
      ...

      <script src="_framework/blazor.{webassembly|server}.js"></script>
      <script src="{SCRIPT FILE (.js)}"></script>
  </body>
  ```

  The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app or `server` for a Blazor Server app. The `{SCRIPT FILE (.js)}` placeholder is the path and script file name.

* Inside the `<head>` element of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server).

  ```html
  <head>
      ...

      <script>
        window.jsMethod = (methodParameter) => {
          ...
        };
      </script>
  </head>
  ```

  > [!WARNING]
  > Loading JS from the `<head>`:
  >
  > * Prevents JS interop from functioning if the script depends on Blazor and you're unable to explicitly start Blazor and then invoke the script in the callback. Placing scripts inside the closing `</body>` tag, not in the `<head>`, is the best general approach for including scripts with JS interop functions. For more information, see the preceding bullet item on including JS from an external file.
  > * May slow down page parsing and thus may delay the page becoming interactive for the user.

* Via an injected script in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server) when the app is initialized.

  Add `autostart="false"` to the `<script>` tag that loads the Blazor script:

  ```html
  <script autostart="false" src="_framework/blazor.{webassembly|server}.js"></script>
  ```

  The `{webassembly|server}` placeholder in the preceding markup is either `webassembly` for a Blazor WebAssembly app or `server` for a Blazor Server app.

  The following example injects a `<script>` tag into the `<head>` elements that references a custom JS file (`custom.js`). The following `<script>` tag is placed inside the closing `</body>` tag after the `<script>` tag that loads the Blazor script:

  ```html
  <script>
    Blazor.start().then(function () {
      var customScript = document.createElement('script');
      customScript.setAttribute('src', 'custom.js');
      document.head.appendChild(customScript);
    });
  </script>
  ```

  > [!NOTE]
  > Because the preceding script is loaded after page load and Blazor initialization, parsing the script shouldn't reduce page responsiveness on load for users.

> [!WARNING]
> Don't place a `<script>` tag in a component file (`.razor`) because the `<script>` tag can't be updated dynamically.

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

## Dispatch calls to JavaScript with `IJSRuntime`

<xref:Microsoft.JSInterop.IJSRuntime> represents an instance of a JavaScript (JS) runtime for performing JS interop operations with <xref:Microsoft.JSInterop.JSRuntimeExtensions> methods.

### Invoke JavaScript functions without reading a returned value (`InvokeVoidAsync`)

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

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

#### Component (`.razor`) example (`InvokeVoidAsync`)

`Pages/CallJsExample2.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample2.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample2.razor?highlight=1)]

::: moniker-end

#### Class (`.cs`) example (`InvokeVoidAsync`)

The JS function is called with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A> and doesn't return a value/

`JsInteropClasses1.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/JsInteropClasses1.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/JsInteropClasses1.cs?highlight=1)]

::: moniker-end

`Pages/CallJsExample3.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample3.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample3.razor?highlight=1)]

::: moniker-end

### Invoke JavaScript functions and read a returned value (`InvokeAsync`)

Use <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A> when .NET should read the result of a JS call.

Inside the closing `</body>` tag of `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server), provide a `displayTickerAlert2` JS function. The following example returns a string for use by the caller:

```html
<script>
  window.displayTickerAlert2 = (symbol, price) => {
    if (price < 20) {
      alert(`${symbol}: $${price}!`);
      return "Alert!";
    } else {
      return "No Alert";
    }
  };
</script>
```

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

#### Component (`.razor`) example (`InvokeAsync`)

`Pages/CallJsExample4.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample4.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample4.razor?highlight=1)]

::: moniker-end

#### Class (`.cs`) example (`InvokeAsync`)

The JS function is called with <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A> and returns a value.

`JsInteropClasses2.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/JsInteropClasses2.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/JsInteropClasses2.cs?highlight=1)]

::: moniker-end

`TickerChanged` calls the `handleTickerChanged2` method and displays the returned string in the following `CallJsExample3` component.

`Pages/CallJsExample5.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample5.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample5.razor?highlight=1)]

::: moniker-end

### Dynamic content generation scenarios

For dynamic content generation with [BuildRenderTree](xref:blazor/advanced-scenarios#manual-rendertreebuilder-logic), use the `[Inject]` attribute:

```razor
[Inject]
IJSRuntime JS { get; set; }
```

## Detect when a Blazor Server app is prerendering

[!INCLUDE[](~/blazor/includes/prerendering.md)]

::: moniker range=">= aspnetcore-5.0"

## JavaScript isolation in JavaScript modules

Blazor enables JavaScript (JS) isolation in standard [JavaScript modules](https://developer.mozilla.org/docs/Web/JavaScript/Guide/Modules) ([ECMAScript specification](https://tc39.es/ecma262/#sec-modules)).

JS isolation provides the following benefits:

* Imported JS no longer pollutes the global namespace.
* Consumers of a library and components aren't required to import the related JS.

For example, the following JS module exports a JS function for showing a [browser window prompt](https://developer.mozilla.org/docs/Web/API/Window/prompt). Place the following JS code in an external JS file.

`wwwroot/scripts.js`:

```javascript
export function showPrompt(message) {
  return prompt(message, 'Type anything here');
}
```

Add the preceding JS module to an app or class library as a static web asset in the `wwwroot` folder and then import the module into the .NET code by calling <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> on the <xref:Microsoft.JSInterop.IJSRuntime> instance.

<xref:Microsoft.JSInterop.IJSRuntime> imports the module as a `IJSObjectReference`, which represents a reference to a JS object from .NET code. Use the `IJSObjectReference` to invoke exported JS functions from the module:

`Pages/CallJsExample6.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample6.razor?highlight=1)]

In the preceding example:

* By convention, the `import` identifier is a special identifier used specifically for importing a JS module.
* Specify the module's external JS file using its stable static web asset path: `./{PATH AND FILENAME}`, where:
  * The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
  * The `{PATH AND FILENAME}` placeholder is the path and file name under `wwwroot`.

Dynamically importing a module requires a network request, so it can only be achieved asynchronously by calling <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>.

`IJSInProcessObjectReference` represents a reference to a JS object whose functions can be invoked synchronously.

> [!NOTE]
> When the external JS file is supplied by a [Razor class library](xref:blazor/components/class-libraries), specify the module's JS file using its stable static web asset path: `./_content/{LIBRARY NAME}/{PATH AND FILENAME}`:
>
> * The path segment for the current directory (`./`) is required in order to create the correct static asset path to the JS file.
> * The `{LIBRARY NAME}` placeholder is the library name. In the following example, the library name is `ComponentLibrary`.
> * The `{PATH AND FILENAME}` placeholder is the path and file name under `wwwroot`. In the following example, the external JS file (`script.js`) is placed in the class library's `wwwroot` folder.
>
> ```csharp
> var module = await js.InvokeAsync<IJSObjectReference>(
>     "import", "./_content/ComponentLibrary/scripts.js");
> ```
>
> For more information, see <xref:blazor/components/class-libraries>.

::: moniker-end

## Capture references to elements

Some JavaScript (JS) interop scenarios require references to HTML elements. For example, a UI library may require an element reference for initialization, or you might need to call command-like APIs on an element, such as `focus` or `play`.

Capture references to HTML elements in a component using the following approach:

* Add an `@ref` attribute to the HTML element.
* Define a field of type <xref:Microsoft.AspNetCore.Components.ElementReference> whose name matches the value of the `@ref` attribute.

The following example shows capturing a reference to the `username` `<input>` element:

```razor
<input @ref="username" ... />

@code {
    ElementReference username;
}
```

> [!WARNING]
> Only use an element reference to mutate the contents of an empty element that doesn't interact with Blazor. This scenario is useful when a third-party API supplies content to the element. Because Blazor doesn't interact with the element, there's no possibility of a conflict between Blazor's representation of the element and the Document Object Model (DOM).
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

An <xref:Microsoft.AspNetCore.Components.ElementReference> is passed through to JS code via JS interop. The JS code receives an `HTMLElement` instance, which it can use with normal DOM APIs. For example, the following code defines a .NET extension method that enables sending a mouse click to an element:

```javascript
window.interopFunctions = {
  clickElement : function (element) {
    element.click();
  }
}
```

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

::: moniker range=">= aspnetcore-5.0"

> [!NOTE]
> Use [`FocusAsync`](xref:blazor/components/event-handling#focus-an-element) in C# code to focus an element, which is built-into the Blazor framework and works with element references.

::: moniker-end

To call a JS function that doesn't return a value, use <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>. The following code triggers a client-side `Click` event by calling the preceding JS function with the captured <xref:Microsoft.AspNetCore.Components.ElementReference>:

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
> The `exampleButton` variable is only populated after the component is rendered. If an unpopulated <xref:Microsoft.AspNetCore.Components.ElementReference> is passed to JS code, the JS code receives a value of `null`. To manipulate element references after the component has finished rendering use the [`OnAfterRenderAsync` or `OnAfterRender` component lifecycle methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

When working with generic types and returning a value, use <xref:System.Threading.Tasks.ValueTask%601>:

```csharp
public static ValueTask<T> GenericMethod<T>(this ElementReference elementRef, 
    IJSRuntime js)
{
    return js.InvokeAsync<T>("exampleJsFunctions.doSomethingGeneric", elementRef);
}
```

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

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

`Pages/CallJsExample7.razor` (parent component):

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample7.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample7.razor?highlight=1)]

::: moniker-end

`Pages/CallJsExample7.razor.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample7.razor.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample7.razor.cs?highlight=1)]

::: moniker-end

In the preceding example, the namespace of the app is `BlazorSample` with components in the `Pages` folder. If testing the code locally, update the namespace to the local app's namespace.

`Shared/SurveyPrompt.razor` (child component):

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor?highlight=1)]

::: moniker-end

`Shared/SurveyPrompt.razor.cs`:

::: moniker range=">= aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor.cs?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-csharp[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/SurveyPrompt.razor.cs?highlight=1)]

::: moniker-end

In the preceding example, the namespace of the app is `BlazorSample` with shared components in the `Shared` folder. If testing the code locally, update the namespace to the local app's namespace.

## Harden JavaScript interop calls

In Blazor Server apps, JavaScript (JS) interop may fail due to networking errors and should be treated as unreliable. By default, Blazor Server apps use a one minute timeout for JS interop calls. If an app can tolerate a more aggressive timeout, set the timeout using one of the following approaches.

Set a global timeout in the `Startup.ConfigureServices` method of `Startup.cs` with <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout?displayProperty=nameWithType>:

```csharp
services.AddServerSideBlazor(
    options => options.JSInteropDefaultCallTimeout = {TIMEOUT});
```

In the preceding example, the `{TIMEOUT}` placeholder is a <xref:System.TimeSpan> (for example, `TimeSpan.FromSeconds(80)`).

Set a per-invocation timeout in component code. The specified timeout overrides the global timeout set by <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.JSInteropDefaultCallTimeout>:

```csharp
var result = await JS.InvokeAsync<string>("{ID}", {TIMEOUT}, new[] { "Arg1" });
```

In the preceding example:

* The `{TIMEOUT}` placeholder is a <xref:System.TimeSpan> (for example, `TimeSpan.FromSeconds(80)`).
* The `{ID}` placeholder is the identifier for the function to invoke. For example, the value `someScope.someFunction` invokes the function `window.someScope.someFunction`.

> [!NOTE]
> Although a common cause of JS interop failures are network failures in Blazor Server apps, per-invocation timeouts can be set for JS interop calls in Blazor WebAssembly apps. Although no SignalR circuit exists in a Blazor WebAssembly app, JS interop calls might fail for other reasons that apply in Blazor WebAssembly apps.

For more information on resource exhaustion, see <xref:blazor/security/server/threat-mitigation>.

## Share interop code in a class library

[!INCLUDE[](~/blazor/includes/share-interop-code.md)]

## Avoid circular object references

Objects that contain circular references can't be serialized on the client for either:

* .NET method calls.
* JavaScript (JS) method calls from C# when the return type has circular references.

For more information, see [Circular references are not supported, take two (dotnet/aspnetcore #20525)](https://github.com/dotnet/aspnetcore/issues/20525).

::: moniker range=">= aspnetcore-5.0"

## JavaScript libraries that render UI

Sometimes you may wish to use JavaScript (JS) libraries that produce visible user interface elements within the browser Document Object Model (DOM). At first glance, this might seem difficult because Blazor's diffing system relies on having control over the tree of DOM elements and runs into errors if some external code mutates the DOM tree and invalidates its mechanism for applying diffs. This isn't a Blazor-specific limitation. The same challenge occurs with any diff-based UI framework.

Fortunately, it's straightforward to embed externally-generated UI within a Razor component UI reliably. The recommended technique is to have the component's code (`.razor` file) produce an empty element. As far as Blazor's diffing system is concerned, the element is always empty, so the renderer does not recurse into the element and instead leaves its contents alone. This makes it safe to populate the element with arbitrary externally-managed content.

The following example demonstrates the concept. Within the `if` statement when `firstRender` is `true`, do something with `unmanagedElement`. For example, call an external JS library to populate the element. Blazor leaves the element's contents alone until this component is removed. When the component is removed, the component's entire DOM subtree is also removed.

```razor
<h1>Hello! This is a Blazor component rendered at @DateTime.Now</h1>

<div @ref="unmanagedElement"></div>

@code {
    private HtmlElement unmanagedElement;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            ...
        }
    }
}
```

Consider the following example that renders an interactive map using [open-source Mapbox APIs](https://www.mapbox.com/).

The following JS module is placed into the app or made available from a Razor class library.

> [!NOTE]
> To create the [Mapbox](https://www.mapbox.com/) map, obtain an access token from [Mapbox Sign in](https://account.mapbox.com) and provide it where the `{ACCESS TOKEN}` appears in the following code.

`wwwroot/mapComponent.js`:

```javascript
import 'https://api.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.js';

mapboxgl.accessToken = '{ACCESS TOKEN}';

export function addMapToElement(element) {
  return new mapboxgl.Map({
    container: element,
    style: 'mapbox://styles/mapbox/streets-v11',
    center: [-74.5, 40],
    zoom: 9
  });
}

export function setMapCenter(map, latitude, longitude) {
  map.setCenter([longitude, latitude]);
}
```

To produce correct styling, add the following stylesheet tag to the host HTML page.

In `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server), add the following `<link>` element to the `<head>` tags:

```html
<link href="https://api.mapbox.com/mapbox-gl-js/v1.12.0/mapbox-gl.css" 
    rel="stylesheet" />
```

`Pages/CallJsExample8.razor`:

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample8.razor?highlight=1)]

The preceding example produces an interactive map UI. The user:

* Can drag to scroll or zoom.
* Select buttons to jump to predefined locations.

![Mapbox street map of Tokyo, Japan with buttons to select Bristol, United Kingdom and Tokyo, Japan](call-javascript-from-dotnet/_static/mapbox-example.png)

In the preceding example:

* The `<div>` with `@ref="mapElement"` is left empty as far as Blazor is concerned. It's therefore safe for `mapbox-gl.js` to populate it and modify its contents over time. You can use this technique with any JS library that renders UI. You could even embed components from a third-party JS SPA framework inside Blazor components, as long as they don't try to reach out and modify other parts of the page. It is *not* safe for external JS code to modify elements that Blazor does not regard as empty.
* When using this approach, bear in mind the rules about how Blazor retains or destroys DOM elements. The component safely handles button click events and updates the existing map instance because DOM elements are retained where possible by default. If you were rendering a list of map elements from inside a `@foreach` loop, you want to use `@key` to ensure the preservation of component instances. Otherwise, changes in the list data could cause component instances to retain the state of previous instances in an undesirable manner. For more information, see [using @key to preserve elements and components](xref:blazor/components/index#use-key-to-control-the-preservation-of-elements-and-components).
* The example encapsulates JS logic and dependencies within an ES6 module and loads the module dynamically using the `import` identifier. For more information, see [JavaScript isolation in JavaScript modules](#javascript-isolation-in-javascript-modules).

::: moniker-end

## Size limits on JavaScript interop calls

In Blazor WebAssembly, the framework doesn't impose a limit on the size of JavaScript (JS) interop inputs and outputs.

In Blazor Server, JS interop calls are limited in size by the maximum incoming SignalR message size permitted for hub methods, which is enforced by <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> (default: 32 KB). JS to .NET SignalR messages larger than <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> throw an error. The framework doesn't impose a limit on the size of a SignalR message from the hub to a client. For more information, see <xref:blazor/call-dotnet-from-javascript#size-limits-on-javascript-interop-calls>.

## Unmarshalled JavaScript interop

Blazor WebAssembly components may experience poor performance when .NET objects are serialized for JavaScript (JS) interop and either of the following are true:

* A high volume of .NET objects are rapidly serialized. Example: JS interop calls are made on the basis of moving an input device, such as spinning a mouse wheel.
* Large .NET objects or many .NET objects must be serialized for JS interop. Example: JS interop calls require serializing dozens of files.

<xref:Microsoft.JSInterop.IJSUnmarshalledObjectReference> represents a reference to an JS object whose functions can be invoked without the overhead of serializing .NET data.

In the following example:

* A [struct](/dotnet/csharp/language-reference/builtin-types/struct) containing a string and an integer is passed unserialized to JS.
* JS functions process the data and return either a boolean or string to the caller.
* A JS string isn't directly convertible into a .NET `string` object. The `unmarshalledFunctionReturnString` function calls `BINDING.js_string_to_mono_string` to manage the conversion of a JS string.

> [!NOTE]
> The following examples aren't typical use cases for this scenario because the [struct](/dotnet/csharp/language-reference/builtin-types/struct) passed to JS doesn't result in poor component performance. The example uses a small object merely to demonstrate the concepts for passing unserialized .NET data.

Place the following `<script>` block in `wwwroot/index.html` (Blazor WebAssembly) or `Pages/_Host.cshtml` (Blazor Server). Alternatively, you can place the JS in an external JS file referenced inside the closing `</body>` tag with `<script src="{SCRIPT FILE NAME (.js)}></script>`, where the `{SCRIPT FILE NAME (.js)}` placeholder is the path to the script.

```javascript
<script>
  window.returnJSObjectReference = () => {
    return {
      unmarshalledFunctionReturnBoolean: function (fields) {
        const name = Blazor.platform.readStringField(fields, 0);
        const year = Blazor.platform.readInt32Field(fields, 8);
    
        return name === "Brigadier Alistair Gordon Lethbridge-Stewart" &&
            year === 1968;
      },
      unmarshalledFunctionReturnString: function (fields) {
        const name = Blazor.platform.readStringField(fields, 0);
        const year = Blazor.platform.readInt32Field(fields, 8);

        return BINDING.js_string_to_mono_string(`Hello, ${name} (${year})!`);
      }
    };
  }
</script>
```

> [!WARNING]
> The `js_string_to_mono_string` function name, behavior, and existence is subject to change in a future release of .NET. For example:
>
> * The function is likely to be renamed.
> * The function itself might be removed in favor of automatic conversion of strings by the framework.

[!INCLUDE[](~/blazor/includes/use-js-modules.md)]

`Pages/CallJsExample9.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample9.razor?highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/call-js-from-dotnet/CallJsExample9.razor?highlight=1)]

::: moniker-end

If an `IJSUnmarshalledObjectReference` instance isn't disposed in C# code, it can be disposed in JS. The following `dispose` function disposes the object reference when called from JS:

```javascript
window.exampleJSObjectReferenceNotDisposedInCSharp = () => {
  return {
    dispose: function () {
      DotNet.disposeJSObjectReference(this);
    },

    ...
  };
}
```

Array types can be converted from JS objects into .NET objects using `js_typed_array_to_array`, but the JS array must be a typed array. Arrays from JS can be read in C# code as a .NET object array (`object[]`).

Other data types, such as string arrays, can be converted but require creating a new Mono array object (`mono_obj_array_new`) and setting its value (`mono_obj_array_set`).

> [!WARNING]
> JS functions provided by the Blazor framework, such as `js_typed_array_to_array`, `mono_obj_array_new`, and `mono_obj_array_set`, are subject to name changes, behavioral changes, or removal in future releases of .NET.

## Additional resources

* <xref:blazor/call-dotnet-from-javascript>
* [`InteropComponent.razor` example (dotnet/AspNetCore GitHub repository `main` branch)](https://github.com/dotnet/AspNetCore/blob/main/src/Components/test/testassets/BasicTestApp/InteropComponent.razor): The `main` branch represents the product unit's current development for the next release of ASP.NET Core. To select the branch for a different release (for example, `release/5.0`), use the **Switch branches or tags** dropdown list to select the branch.
