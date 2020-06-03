---
title: Handle errors in ASP.NET Core Blazor apps
author: guardrex
description: Discover how ASP.NET Core Blazor how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/23/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/handle-errors
---
# Handle errors in ASP.NET Core Blazor apps

By [Steve Sanderson](https://github.com/SteveSandersonMS)

This article describes how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.

## Detailed errors during development

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a gold bar at the bottom of the screen:

* During development, the gold bar directs you to the browser console, where you can see the exception.
* In production, the gold bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the Blazor project templates.

In a Blazor WebAssembly app, customize the experience in the *wwwroot/index.html* file:

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

In a Blazor Server app, customize the experience in the *Pages/_Host.cshtml* file:

```cshtml
<div id="blazor-error-ui">
    <environment include="Staging,Production">
        An error has occurred. This application may no longer respond until reloaded.
    </environment>
    <environment include="Development">
        An unhandled exception has occurred. See browser dev tools for details.
    </environment>
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

The `blazor-error-ui` element is hidden by the styles included in the Blazor templates (*wwwroot/css/site.css*) and then shown when an error occurs:

```css
#blazor-error-ui {
    background: lightyellow;
    bottom: 0;
    box-shadow: 0 -1px 2px rgba(0, 0, 0, 0.2);
    display: none;
    left: 0;
    padding: 0.6rem 1.25rem 0.7rem 1.25rem;
    position: fixed;
    width: 100%;
    z-index: 1000;
}

#blazor-error-ui .dismiss {
    cursor: pointer;
    position: absolute;
    right: 0.75rem;
    top: 0.5rem;
}
```

## How a Blazor Server app reacts to unhandled exceptions

Blazor Server is a stateful framework. While users interact with an app, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, they have multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes. The crashed app must be restarted, but other apps aren't affected.

A circuit is terminated when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues.

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Log errors with a persistent provider

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location with a provider that manages log size and log rotation. For more information, see <xref:fundamentals/logging/index>.

During development, Blazor usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors in the browser's console are disabled by default, which means that errors aren't sent to clients but the exception's full details are still logged server-side. For more information, see <xref:fundamentals/error-handling>.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as high-severity incidents for logging.

For more information, see <xref:fundamentals/logging/index#create-logs-in-blazor>.

## Places where errors may occur

Framework and app code may trigger unhandled exceptions in any of the following locations:

* [Component instantiation](#component-instantiation)
* [Lifecycle methods](#lifecycle-methods)
* [Rendering logic](#rendering-logic)
* [Event handlers](#event-handlers)
* [Component disposal](#component-disposal)
* [JavaScript interop](#javascript-interop)
* [Blazor Server rerendering](#blazor-server-prerendering)

The preceding unhandled exceptions are described in the following sections of this article.

### Component instantiation

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of any non-singleton DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]`](xref:blazor/dependency-injection#request-a-service-in-a-component) attribute are invoked.

A Blazor Server circuit fails when any executed constructor or a setter for any `[Inject]` property throws an unhandled exception. The exception is fatal because the framework can't instantiate the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods

During the lifetime of a component, Blazor invokes the following [lifecycle methods](xref:blazor/lifecycle):

* <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> / <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>
* <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet%2A> / <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>
* <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A>
* <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> / <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>

If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to a Blazor Server circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](handle-errors/samples_snapshot/3.x/product-details.razor?highlight=11,27-39)]

### Rendering logic

The declarative markup in a `.razor` component file is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. An unhandled exception thrown by rendering logic is fatal to a Blazor Server circuit.

To prevent a null reference exception in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

[!code-razor[](handle-errors/samples_snapshot/3.x/person-example.razor?highlight=1)]

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated.

### Event handlers

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If an event handler throws an unhandled exception (for example, a database query fails), the exception is fatal to a Blazor Server circuit. If the app calls code that could fail for external reasons, trap exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception and terminates the circuit.

### Component disposal

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If the component's `Dispose` method throws an unhandled exception, the exception is fatal to a Blazor Server circuit. If disposal logic may throw exceptions, the app should trap the exceptions using a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/lifecycle#component-disposal-with-idisposable>.

### JavaScript interop

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception, the resulting exception is fatal to a Blazor Server circuit.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [await](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise, the failing code results in an unhandled exception that's fatal to a Blazor Server circuit.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]`](xref:Microsoft.JSInterop.JSInvokableAttribute)](xref:blazor/call-dotnet-from-javascript) attribute. If these .NET methods throw an unhandled exception:

* The exception isn't treated as fatal to a Blazor Server circuit.
* The JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/call-javascript-from-dotnet>
* <xref:blazor/call-dotnet-from-javascript>

### Blazor Server prerendering

Blazor components can be prerendered using the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) so that their rendered HTML markup is returned as part of the user's initial HTTP request. This works by:

* Creating a new circuit for all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server. When the connection is established, interactivity on the circuit is resumed and the components' HTML markup is updated.

If any component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* The exception is fatal to the circuit.
* The exception is thrown up the call stack from the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper. Therefore, the entire HTTP request fails unless the exception is explicitly caught by developer code.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper in a [try-catch](/dotnet/csharp/language-reference/keywords/try-catch) statement, place error handling logic in the component rendered by the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper.

## Advanced scenarios

### Recursive rendering

Components can be nested recursively. This is useful for representing recursive data structures. For example, a `TreeNode` component can render more `TreeNode` components for each of the node's children.

When rendering recursively, avoid coding patterns that result in infinite recursion:

* Don't recursively render a data structure that contains a cycle. For example, don't render a tree node whose children includes itself.
* Don't create a chain of layouts that contain a cycle. For example, don't create a layout whose layout is itself.
* Don't allow an end user to violate recursion invariants (rules) through malicious data entry or JavaScript interop calls.

Infinite loops during rendering:

* Causes the rendering process to continue forever.
* Is equivalent to creating an unterminated loop.

In these scenarios, an affected Blazor Server circuit fails, and the thread usually attempts to:

* Consume as much CPU time as permitted by the operating system, indefinitely.
* Consume an unlimited amount of server memory. Consuming unlimited memory is equivalent to the scenario where an unterminated loop adds entries to a collection on every iteration.

To avoid infinite recursion patterns, ensure that recursive rendering code contains suitable stopping conditions.

### Custom render tree logic

Most Blazor components are implemented as *.razor* files and are compiled to produce logic that operates on a <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to render their output. A developer may manually implement <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic using procedural C# code. For more information, see <xref:blazor/advanced-scenarios#manual-rendertreebuilder-logic>.

> [!WARNING]
> Use of manual render tree builder logic is considered an advanced and unsafe scenario, not recommended for general component development.

If <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> code is written, the developer must guarantee the correctness of the code. For example, the developer must ensure that:

* Calls to <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenElement%2A> and <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseElement%2A> are correctly balanced.
* Attributes are only added in the correct places.

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, server hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or MSIL instructions by hand.
