---
title: ASP.NET Core Blazor JavaScript interoperability (JS interop)
author: guardrex
description: Learn how to interact with JavaScript in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/js-interop/index
---
# ASP.NET Core Blazor JavaScript interoperability (JS interop)

[!INCLUDE[](~/includes/not-latest-version.md)]

A Blazor app can invoke JavaScript (JS) functions from .NET methods and .NET methods from JS functions. These scenarios are called *JavaScript interoperability* (*JS interop*).

Further JS interop guidance is provided in the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

:::moniker range=">= aspnetcore-7.0"

> [!NOTE]
> JavaScript `[JSImport]`/`[JSExport]` interop API is available for client-side components in ASP.NET Core in .NET 7 or later.
>
> For more information, see <xref:blazor/js-interop/import-export-interop>.

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

## Compression for interactive server components with untrusted data

<!-- DOC AUTHOR NOTE: This content is also in an INCLUDE file at
     blazor/includes/compression-with-untrusted-data.md because the
     text is used in a warning format in two articles. -->

With compression, which is enabled by default, avoid creating secure (authenticated/authorized) interactive server-side components that render data from untrusted sources. Untrusted sources include route parameters, query strings, data from JS interop, and any other source of data that a third-party user can control (databases, external services). For more information, see <xref:blazor/fundamentals/signalr#websocket-compression-for-interactive-server-components> and <xref:blazor/security/server/interactive-server-side-rendering?view=aspnetcore-9.0#interactive-server-components-with-websocket-compression-enabled>.

:::moniker-end

## JavaScript interop abstractions and features package

The [`@microsoft/dotnet-js-interop` package (`npmjs.com`)](https://www.npmjs.com/package/@microsoft/dotnet-js-interop) ([`Microsoft.JSInterop` NuGet package](https://www.nuget.org/packages/Microsoft.JSInterop)) provides abstractions and features for interop between .NET and JavaScript (JS) code. Reference source is available in the [`dotnet/aspnetcore` GitHub repository (`/src/JSInterop` folder)](https://github.com/dotnet/aspnetcore/tree/main/src/JSInterop). For more information, see the GitHub repository's `README.md` file.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

Additional resources for writing JS interop scripts in TypeScript:

* [TypeScript](https://www.typescriptlang.org/)
* [Tutorial: Create an ASP.NET Core app with TypeScript in Visual Studio](/visualstudio/javascript/tutorial-aspnet-with-typescript)
* [Manage npm packages in Visual Studio](/visualstudio/javascript/npm-package-management)

## Interaction with the DOM

Only mutate the DOM with JavaScript (JS) when the object doesn't interact with Blazor. Blazor maintains representations of the DOM and interacts directly with DOM objects. If an element rendered by Blazor is modified externally using JS directly or via JS Interop, the DOM may no longer match Blazor's internal representation, which can result in undefined behavior. Undefined behavior may merely interfere with the presentation of elements or their functions but may also introduce security risks to the app or server.

This guidance not only applies to your own JS interop code but also to any JS libraries that the app uses, including anything provided by a third-party framework, such as [Bootstrap JS](https://getbootstrap.com/) and [jQuery](https://jquery.com/).

In a few documentation examples, JS interop is used to mutate an element *purely for demonstration purposes* as part of an example. In those cases, a warning appears in the text.

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements>.

## JavaScript class with a field of type function

A JavaScript class with a field of type function is ***not*** supported by Blazor JS interop. Use Javascript functions in classes.

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> `GreetingHelpers.sayHello` in the following class as a field of type function isn't discovered by Blazor's JS interop and can't be executed from C# code:

```javascript
export class GreetingHelpers {
  sayHello = function() {
    ...
  }
}
```

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> `GreetingHelpers.sayHello` in the following class as a function is supported:

```javascript
export class GreetingHelpers {
  sayHello() {
    ...
  }
}
```

Arrow functions are also supported:

```javascript
export class GreetingHelpers {
  sayHello = () => {
    ...
  }
}
```

## Avoid inline event handlers

A JavaScript function can be invoked directly from an inline event handler. In the following example, `alertUser` is a JavaScript function called when the button is selected by the user:

```html
<button onclick="alertUser">Click Me!</button>
```

However, the use of inline event handlers is a *poor design choice* for calling JavaScript functions:

* Mixing HTML markup and JavaScript code often leads to unmaintainable code.
* Inline event handler execution may be blocked by a [Content Security Policy (CSP) (MDN documentation)](https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP).

We recommend avoiding inline event handlers in favor of approaches that assign handlers in JavaScript with [`addEventListener`](https://developer.mozilla.org/docs/Web/API/EventTarget/addEventListener), as the following example demonstrates:

`AlertUser.razor.js`:

```javascript
export function alertUser() {
  alert('The button was selected!');
}

export function addHandlers() {
  const btn = document.getElementById("btn");
  btn.addEventListener("click", alertUser);
}
```

`AlertUser.razor`:

```razor
@page "/alert-user"
@implements IAsyncDisposable
@inject IJSRuntime JS

<h1>Alert User</h1>

<p>
    <button id="btn">Click Me!</button>
</p>

@code {
    private IJSObjectReference? module;

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./Components/Pages/AlertUser.razor.js");

            await module.InvokeVoidAsync("addHandlers");
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```

For more information, see the following resources:

* <xref:blazor/js-interop/javascript-location>
* [Introduction to events (MDN documentation)](https://developer.mozilla.org/docs/Learn/JavaScript/Building_blocks/Events#inline_event_handlers_%E2%80%94_dont_use_these)

## Asynchronous JavaScript calls

JS interop calls are asynchronous by default, regardless of whether the called code is synchronous or asynchronous. Calls are asynchronous by default to ensure that components are compatible across server-side and client-side rendering models. When adopting server-side rendering, JS interop calls must be asynchronous because they're sent over a network connection. For apps that exclusively adopt client-side rendering, synchronous JS interop calls are supported.

:::moniker range=">= aspnetcore-5.0"

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-client-side-components>
* <xref:blazor/js-interop/call-dotnet-from-javascript#synchronous-js-interop-in-client-side-components>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-client-side-components>.

:::moniker-end

## Object serialization

Blazor uses <xref:System.Text.Json?displayProperty=fullName> for serialization with the following requirements and default behaviors:

* Types must have a default constructor, [`get`/`set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) must be public, and fields are never serialized.
* Global default serialization isn't customizable to avoid breaking existing component libraries, impacts on performance and security, and reductions in reliability.
* Serializing .NET member names results in lowercase JSON key names.
* JSON is deserialized as <xref:System.Text.Json.JsonElement> C# instances, which permit mixed casing. Internal casting for assignment to C# model properties works as expected in spite of any case differences between JSON key names and C# property names.
* Complex framework types, such as <xref:System.Collections.Generic.KeyValuePair>, might be [trimmed away by the IL Trimmer on publish](xref:blazor/host-and-deploy/configure-trimmer) and not present for JS interop. We recommend creating custom types for types that the IL Trimmer trims away by default.
* Blazor always relies on [reflection for JSON serialization](/dotnet/standard/serialization/system-text-json/reflection-vs-source-generation), including when using C# [source generation](/dotnet/csharp/roslyn-sdk/source-generators-overview). Setting `JsonSerializerIsReflectionEnabledByDefault` to `false` in the app's project file results in an error when serialization is attempted.

<xref:System.Text.Json.Serialization.JsonConverter> API is available for custom serialization. Properties can be annotated with a [`[JsonConverter]` attribute](xref:System.Text.Json.Serialization.JsonConverterAttribute) to override default serialization for an existing data type.

For more information, see the following resources in the .NET documentation:

* [JSON serialization and deserialization (marshalling and unmarshalling) in .NET](/dotnet/standard/serialization/system-text-json-overview)
* [How to customize property names and values with `System.Text.Json`](/dotnet/standard/serialization/system-text-json-customize-properties)
* [How to write custom converters for JSON serialization (marshalling) in .NET](/dotnet/standard/serialization/system-text-json-converters-how-to)

:::moniker range=">= aspnetcore-6.0"

Blazor supports optimized byte array JS interop that avoids encoding/decoding byte arrays into Base64. The app can apply custom serialization and pass the resulting bytes. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#byte-array-support>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-7.0"

Blazor supports unmarshalled JS interop when a high volume of .NET objects are rapidly serialized or when large .NET objects or many .NET objects must be serialized. For more information, see <xref:blazor/js-interop/call-javascript-from-dotnet#unmarshalled-javascript-interop>.

:::moniker-end

## DOM cleanup tasks during component disposal

Don't execute JS interop code for DOM cleanup tasks during component disposal. Instead, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JavaScript (JS) on the client for the following reasons:

* The component may have been removed from the DOM by the time your cleanup code executes in `Dispose{Async}`.
* During server-side rendering, the Blazor renderer may have been disposed by the framework by the time your cleanup code executes in `Dispose{Async}`.

The [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern allows you to run a function when an element is removed from the DOM.

In the following example, the `DOMCleanup` component:

* Contains a `<div>` with an `id` of `cleanupDiv`. The `<div>` element is removed from the DOM along with the rest of the component's DOM markup when the component is removed from the DOM.
* Loads the `DOMCleanup` JS class from the `DOMCleanup.razor.js` file and calls its `createObserver` function to set up the `MutationObserver` callback. These tasks are accomplished in the [`OnAfterRenderAsync` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

`DOMCleanup.razor`:

```razor
@page "/dom-cleanup"
@implements IAsyncDisposable
@inject IJSRuntime JS

<h1>DOM Cleanup Example</h1>

<div id="cleanupDiv"></div>

@code {
    private IJSObjectReference? module;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            module = await JS.InvokeAsync<IJSObjectReference>(
                "import", "./Components/Pages/DOMCleanup.razor.js");

            await module.InvokeVoidAsync("DOMCleanup.createObserver");
        }
    }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (module is not null)
        {
            await module.DisposeAsync();
        }
    }
}
```

In the following example, the `MutationObserver` callback is executed each time a DOM change occurs. Execute your cleanup code when the `if` statement confirms that the target element (`cleanupDiv`) was removed (`if (targetRemoved) { ... }`). It's important to disconnect and delete the `MutationObserver` to avoid a memory leak after your cleanup code executes.

`DOMCleanup.razor.js` placed side-by-side with the preceding `DOMCleanup` component:

```javascript
export class DOMCleanup {
  static observer;

  static createObserver() {
    const target = document.querySelector('#cleanupDiv');

    this.observer = new MutationObserver(function (mutations) {
      const targetRemoved = mutations.some(function (mutation) {
        const nodes = Array.from(mutation.removedNodes);
        return nodes.indexOf(target) !== -1;
      });

      if (targetRemoved) {
        // Cleanup resources here
        // ...

        // Disconnect and delete MutationObserver
        this.observer && this.observer.disconnect();
        delete this.observer;
      }
    });

    this.observer.observe(target.parentNode, { childList: true });
  }
}

window.DOMCleanup = DOMCleanup;
```

## JavaScript interop calls without a circuit

*This section only applies to server-side apps.*

JavaScript (JS) interop calls can't be issued after a SignalR circuit is disconnected. Without a circuit during component disposal or at any other time that a circuit doesn't exist, the following method calls fail and log a message that the circuit is disconnected as a <xref:Microsoft.JSInterop.JSDisconnectedException>:

* JS interop method calls
  * <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeAsync%2A?displayProperty=nameWithType>
  * <xref:Microsoft.JSInterop.JSRuntimeExtensions.InvokeVoidAsync%2A?displayProperty=nameWithType>)
* `Dispose`/`DisposeAsync` calls on any <xref:Microsoft.JSInterop.IJSObjectReference>.

In order to avoid logging <xref:Microsoft.JSInterop.JSDisconnectedException> or to log custom information, catch the exception in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.

For the following component disposal example:

* The component implements <xref:System.IAsyncDisposable>.
* `objInstance` is an <xref:Microsoft.JSInterop.IJSObjectReference>.
* <xref:Microsoft.JSInterop.JSDisconnectedException> is caught and not logged.
* Optionally, you can log custom information in the `catch` statement at whatever log level you prefer. The following example doesn't log custom information because it assumes the developer doesn't care about when or where circuits are disconnected during component disposal.

```csharp
async ValueTask IAsyncDisposable.DisposeAsync()
{
    try
    {
        if (objInstance is not null)
        {
            await objInstance.DisposeAsync();
        }
    }
    catch (JSDisconnectedException)
    {
    }
}
```

If you must clean up your own JS objects or execute other JS code on the client after a circuit is lost, use the [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern in JS on the client. The [`MutationObserver`](https://developer.mozilla.org/docs/Web/API/MutationObserver) pattern allows you to run a function when an element is removed from the DOM.

For more information, see the following articles:

* <xref:blazor/fundamentals/handle-errors#javascript-interop>: The *JavaScript interop* section discusses error handling in JS interop scenarios.
* <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>: The *Component disposal with `IDisposable` and `IAsyncDisposable`* section describes how to implement disposal patterns in Razor components.

## Cached JavaScript files

JavaScript (JS) files and other static assets aren't generally cached on clients during development in the [`Development` environment](xref:fundamentals/index#environments). During development, static asset requests include the [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) with a value of [`no-cache`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#cacheability) or [`max-age`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control#expiration) with a value of zero (`0`).

During production in the [`Production` environment](xref:fundamentals/index#environments), JS files are usually cached by clients.

To disable client-side caching in browsers, developers usually adopt one of the following approaches:

* Disable caching when the browser's developer tools console is open. Guidance can be found in the developer tools documentation of each browser maintainer:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* Perform a manual browser refresh of any webpage of the Blazor app to reload JS files from the server. ASP.NET Core's HTTP Caching Middleware always honors a valid no-cache [`Cache-Control` header](https://developer.mozilla.org/docs/Web/HTTP/Headers/Cache-Control) sent by a client.

For more information, see:

* <xref:blazor/fundamentals/environments>
* <xref:performance/caching/response>

## Size limits on JavaScript interop calls

*This section only applies to interactive components in server-side apps. For client-side components, the framework doesn't impose a limit on the size of JavaScript (JS) interop inputs and outputs.*

For interactive components in server-side apps, JS interop calls passing data from the client to the server are limited in size by the maximum incoming SignalR message size permitted for hub methods, which is enforced by <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize?displayProperty=nameWithType> (default: 32 KB). JS to .NET SignalR messages larger than <xref:Microsoft.AspNetCore.SignalR.HubOptions.MaximumReceiveMessageSize> throw an error. The framework doesn't impose a limit on the size of a SignalR message from the hub to a client. For more information on the size limit, error messages, and guidance on dealing with message size limits, see <xref:blazor/fundamentals/signalr#maximum-receive-message-size>.

:::moniker range=">= aspnetcore-6.0"

## Determine where the app is running

If it's relevant for the app to know where code is running for JS interop calls, use <xref:System.OperatingSystem.IsBrowser%2A?displayProperty=nameWithType> to determine if the component is executing in the context of browser on WebAssembly.

:::moniker-end
