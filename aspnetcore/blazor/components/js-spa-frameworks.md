---
title: Use Razor components in JavaScript apps and SPA frameworks
author: guardrex
description: Learn how to create and use Razor components in JavaScript apps and SPA frameworks.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/25/2023
uid: blazor/components/js-spa-frameworks
---
# Use Razor components in JavaScript apps and SPA frameworks

[!INCLUDE[](~/includes/not-latest-version.md)]

This article covers how to render Razor components from JavaScript, use Blazor custom elements, and generate Angular and React components.

## Render Razor components from JavaScript

Razor components can be dynamically-rendered from JavaScript (JS) for existing JS apps.

The example in this section renders the following Razor component into a page via JS.

`Quote.razor`:

```razor
<div class="m-5 p-5">
    <h2>Quote</h2>
    <p>@Text</p>
</div>

@code {
    [Parameter]
    public string? Text { get; set; }
}
```

In the `Program` file, add the [namespace for the location of the component](xref:blazor/components/index#component-name-class-name-and-namespace).

Call <xref:Microsoft.AspNetCore.Components.Web.JSComponentConfigurationExtensions.RegisterForJavaScript%2A> on the app's root component collection to register the a Razor component as a root component for JS rendering.

<xref:Microsoft.AspNetCore.Components.Web.JSComponentConfigurationExtensions.RegisterForJavaScript%2A> includes an overload that accepts the name of a JS function that executes initialization logic (`javaScriptInitializer`). The JS function is called once per component registration immediately after the Blazor app starts and before any components are rendered. This function can be used for integration with JS technologies, such as HTML custom elements or a JS-based SPA framework.

One or more initializer functions can be created and called by different component registrations. The typical use case is to reuse the same initializer function for multiple components, which is expected if the initializer function is configuring integration with custom elements or another JS-based SPA framework.

> [!IMPORTANT]
> Don't confuse the `javaScriptInitializer` parameter of <xref:Microsoft.AspNetCore.Components.Web.JSComponentConfigurationExtensions.RegisterForJavaScript%2A> with [JavaScript initializers](xref:blazor/fundamentals/startup#javascript-initializers). The name of the parameter and the JS initializers feature is coincidental.

The following example demonstrates the dynamic registration of the preceding `Quote` component with "`quote`" as the identifier.

:::moniker range=">= aspnetcore-8.0"

* In a Blazor Web App app, modify the call to `AddInteractiveServerComponents` in the server-side `Program` file:

  ```csharp
  builder.Services.AddRazorComponents()
      .AddInteractiveServerComponents(options =>
      {
          options.RootComponents.RegisterForJavaScript<Quote>(identifier: "quote",
            javaScriptInitializer: "initializeComponent");
      });
  ```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

* In a Blazor Server app, modify the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A> in the `Program` file:

  ```csharp
  builder.Services.AddServerSideBlazor(options =>
  {
      options.RootComponents.RegisterForJavaScript<Quote>(identifier: "quote", 
          javaScriptInitializer: "initializeComponent");
  });
  ```

:::moniker-end

* In a Blazor WebAssembly app, call <xref:Microsoft.AspNetCore.Components.Web.JSComponentConfigurationExtensions.RegisterForJavaScript%2A> on <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> in the client-side `Program` file:

  ```csharp
  builder.RootComponents.RegisterForJavaScript<Quote>(identifier: "quote", 
      javaScriptInitializer: "initializeComponent");
  ```

Attach the initializer function with `name` and `parameters` function parameters to the `window` object. For demonstration purposes, the following `initializeComponent` function logs the name and parameters of the registered component.

`wwwroot/js/jsComponentInitializers.js`:

```javascript
window.initializeComponent = (name, parameters) => {
  console.log({ name: name, parameters: parameters });
}
```

Render the component from JS into a container element using the registered identifier, passing component parameters as needed. 

In the following example:

* The `Quote` component (`quote` identifier) is rendered into the `quoteContainer` element when the `showQuote` function is called.
* A quote string is passed to the component's `Text` parameter.

`wwwroot/js/scripts.js`:

```javascript
async function showQuote() {
  let targetElement = document.getElementById('quoteContainer');
  await Blazor.rootComponents.add(targetElement, 'quote', 
  {
    text: "Crow: I have my doubts that this movie is actually 'starring' " +
      "anybody. More like, 'camera is generally pointed at.'"
  });
}
```

Load Blazor (`blazor.server.js` or `blazor.webassembly.js`) with the preceding scripts into the JS app:

```html
<script src="_framework/blazor.{server|webassembly}.js"></script>
<script src="js/jsComponentInitializers.js"></script>
<script src="js/scripts.js"></script>
```

In HTML, place the target container element (`quoteContainer`). For the demonstration in this section, a button triggers rendering the `Quote` component by calling the `showQuote` JS function:

```html
<button onclick="showQuote()">Show Quote</button>

<div id="quoteContainer"></div>
```

On initialization before any components are rendered, the browser's developer tools console logs the `Quote` component's identifier (`name`) and parameters (`parameters`) when `initializeComponent` is called:

```console
Object { name: "quote", parameters: (1) […] }
  name: "quote"
  parameters: Array [ {…} ]
    0: Object { name: "Text", type: "string" }
    length: 1
```

When the **:::no-loc text="Show Quote":::** button is selected, the `Quote` component is rendered with the quote stored in `Text` displayed:

![Quote rendered in the browser](~/blazor/components/index/_static/quote.png)

Quote &copy;1988-1999 Satellite of Love LLC: [*Mystery Science Theater 3000*](https://mst3k.com/) ([Trace Beaulieu (Crow)](https://www.imdb.com/name/nm0064546/))

> [!NOTE]
> `rootComponents.add` returns an instance of the component. Call `dispose` on the instance to release it:
>
> ```javascript
> const rootComponent = await window.Blazor.rootComponents.add(...);
>
> ...
>
> rootComponent.dispose();
> ```

The preceding example dynamically renders the root component when the `showQuote()` JS function is called. To render a root component into a container element when Blazor starts, use a [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers) to render the component, as the following example demonstrates.

The following example builds on the preceding example, using the `Quote` component, the root component registration in the `Program` file, and the initialization of `jsComponentInitializers.js`. The `showQuote()` function (and the `script.js` file) aren't used.

In HTML, place the target container element, `quoteContainer2` for this example:

```html
<div id="quoteContainer2"></div>
```

Using a [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers), add the root component to the target container element.

`wwwroot/{PACKAGE ID/ASSEMBLY NAME}.lib.module.js`:

```javascript
export function afterStarted(blazor) {
  let targetElement = document.getElementById('quoteContainer2');
  blazor.rootComponents.add(targetElement, 'quote',
    {
      text: "Crow: I have my doubts that this movie is actually 'starring' " +
          "anybody. More like, 'camera is generally pointed at.'"
    });
}
```

> [!NOTE]
> For the call to `rootComponents.add`, use the `blazor` parameter (lowercase `b`) provided by `afterStarted`. Although the registration is valid when using the `Blazor` object (uppercase `B`), the preferred approach is to use the parameter.

For an advanced example with additional features, see the example in the `BasicTestApp` of the ASP.NET Core reference source (`dotnet/aspnetcore` GitHub repository):

* [`JavaScriptRootComponents.razor`](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/JavaScriptRootComponents.razor)
* [`wwwroot/js/jsRootComponentInitializers.js`](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/wwwroot/js/jsRootComponentInitializers.js)
* [`wwwroot/index.html`](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/wwwroot/index.html)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Blazor custom elements

:::moniker range=">= aspnetcore-7.0"

Use Blazor custom elements to dynamically render Razor components from other SPA frameworks, such as Angular or React.

Blazor custom elements:

* Use standard HTML interfaces to implement custom HTML elements.
* Eliminate the need to manually manage the state and lifecycle of root Razor components using JavaScript APIs.
* Are useful for gradually introducing Razor components into existing projects written in other SPA frameworks.

Custom elements don't support [child content](xref:blazor/components/index#child-content-render-fragments) or [templated components](xref:blazor/components/templated-components).

### Element name

Per the [HTML specification](https://html.spec.whatwg.org/multipage/custom-elements.html#custom-elements-core-concepts), custom element tag names must adopt kebab case:

<span aria-hidden="true">❌</span><span class="visually-hidden">Invalid:</span> `mycounter`  
<span aria-hidden="true">❌</span><span class="visually-hidden">Invalid:</span> `MY-COUNTER`  
<span aria-hidden="true">❌</span><span class="visually-hidden">Invalid:</span> `MyCounter`  
<span aria-hidden="true">✔️</span><span class="visually-hidden">Valid:</span> `my-counter`  
<span aria-hidden="true">✔️</span><span class="visually-hidden">Valid:</span> `my-cool-counter`

### Package

Add a package reference for [`Microsoft.AspNetCore.Components.CustomElements`](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.CustomElements) to the app's project file.

[!INCLUDE[](~/includes/package-reference.md)]

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

### Blazor Web App registration

Take the following steps to register a root component as a custom element in a Blazor Web App.

Add the <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName> namespace to the top of the server-side `Program` file:

```csharp
using Microsoft.AspNetCore.Components.Web;
```

Add a namespace for the app's components. In the following example, the app's namespace is `BlazorSample` and the components are located in the `Components/Pages` folder:

```csharp
using BlazorSample.Components.Pages;
```

Modify the call to `AddInteractiveServerComponents` to specify the custom element with `RegisterCustomElement` on the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.RootComponents> circuit option. The following example registers the `Counter` component with the custom HTML element `my-counter`:



```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.RootComponents.RegisterCustomElement<Counter>("my-counter");
    });
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

### Blazor Server registration

Take the following steps to register a root component as a custom element in a Blazor Server app.

Add the <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName> namespace to the top of the `Program` file:

```csharp
using Microsoft.AspNetCore.Components.Web;
```

Add a namespace for the app's components. In the following example, the app's namespace is `BlazorSample` and the components are located in the `Pages` folder:

```csharp
using BlazorSample.Pages;
```

Modify the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A>. Specify the custom element with `RegisterCustomElement` on the <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.RootComponents> circuit option. The following example registers the `Counter` component with the custom HTML element `my-counter`:

```csharp
builder.Services.AddServerSideBlazor(options =>
{
    options.RootComponents.RegisterCustomElement<Counter>("my-counter");
});
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

### Blazor WebAssembly registration

Take the following steps to register a root component as a custom element in a Blazor WebAssembly app.

Add the <xref:Microsoft.AspNetCore.Components.Web?displayProperty=fullName> namespace to the top of the `Program` file:

```csharp
using Microsoft.AspNetCore.Components.Web;
```

Add a namespace for the app's components. In the following example, the app's namespace is `BlazorSample` and the components are located in the `Pages` folder:

```csharp
using BlazorSample.Pages;
```

Call `RegisterCustomElement` on <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents>. The following example registers the `Counter` component with the custom HTML element `my-counter`:

```csharp
builder.RootComponents.RegisterCustomElement<Counter>("my-counter");
```

### Use the registered custom element

Use the custom element with any web framework. For example, the preceding `my-counter` custom HTML element that renders the app's `Counter` component is used in a React app with the following markup:

```html
<my-counter></my-counter>
```

For a complete example of how to create custom elements with Blazor, see the [`CustomElementsComponent` component](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/CustomElementsComponent.razor) in the reference source.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

### Pass parameters

Pass parameters to your Blazor component either as HTML attributes or as JavaScript properties on the DOM element.

The following `Counter` component uses an `IncrementAmount` parameter to set the increment amount of the **:::no-loc text="Click me":::** button.

`Counter.razor`:

```razor
@page "/counter"

<h1>Counter</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    [Parameter]
    public int IncrementAmount { get; set; } = 1;

    private void IncrementCount()
    {
        currentCount += IncrementAmount;
    }
}
```

Render the `Counter` component with the custom element and pass a value to the `IncrementAmount` parameter as an HTML attribute. The attribute name adopts kebab-case syntax (`increment-amount`, not `IncrementAmount`):

```html
<my-counter increment-amount="10"></my-counter>
```

Alternatively, you can set the parameter's value as a JavaScript property on the element object. The property name adopts camel case syntax (`incrementAmount`, not `IncrementAmount`):

```javascript
const elem = document.querySelector("my-counter");
elem.incrementAmount = 10;
```

You can update parameter values at any time using either attribute or property syntax.

Supported parameter types:

* Using JavaScript property syntax, you can pass objects of any JSON-serializable type.
* Using HTML attributes, you are limited to passing objects of string, boolean, or numerical types.

:::moniker-end

:::moniker range="< aspnetcore-7.0"

*Experimental* support is available for building custom elements using the [`Microsoft.AspNetCore.Components.CustomElements` NuGet package](https://www.nuget.org/packages/microsoft.aspnetcore.components.customelements). Custom elements use standard HTML interfaces to implement custom HTML elements.

> [!WARNING]
> Experimental features are provided for the purpose of exploring feature viability and may not ship in a stable version.

Register a root component as a custom element:

* In a Blazor Server app, modify the call to `AddInteractiveServerComponents` in the `Program` file:

  ```csharp
  builder.Services.AddServerSideBlazor(options =>
  {
      options.RootComponents.RegisterAsCustomElement<Counter>("my-counter");
  });
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Components.Pages;`) in the the `Program` file.

* In a Blazor WebAssembly app, call `RegisterAsCustomElement` on <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> in the `Program` file:

  ```csharp
  builder.RootComponents.RegisterAsCustomElement<Counter>("my-counter");
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Components.Pages;`) in the the `Program` file.

Include the following `<script>` tag in the app's HTML ***before*** the Blazor script tag:

```html
<script src="/_content/Microsoft.AspNetCore.Components.CustomElements/BlazorCustomElements.js"></script>
```

Use the custom element with any web framework. For example, the preceding counter custom element is used in a React app with the following markup:

```html
<my-counter increment-amount={incrementAmount}></my-counter>
```

> [!WARNING]
> The custom elements feature is currently **experimental, unsupported, and subject to change or be removed at any time**. We welcome your feedback on how well this particular approach meets your requirements.

:::moniker-end

## Generate Angular and React components

Generate framework-specific JavaScript (JS) components from Razor components for web frameworks, such as Angular or React. This capability isn't included with .NET, but is enabled by the support for rendering Razor components from JS. The [JS component generation sample on GitHub](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/JSComponentGeneration) demonstrates how to generate Angular and React components from Razor components. See the GitHub sample app's `README.md` file for additional information.

> [!WARNING]
> The Angular and React component features are currently **experimental, unsupported, and subject to change or be removed at any time**. We welcome your feedback on how well this particular approach meets your requirements.
