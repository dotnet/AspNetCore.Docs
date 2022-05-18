---
title: Handle errors in ASP.NET Core Blazor apps
author: guardrex
description: Discover how ASP.NET Core Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/handle-errors
---
# Handle errors in ASP.NET Core Blazor apps

This article describes how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.

:::moniker range=">= aspnetcore-6.0"

## Detailed errors during development

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

In a Blazor Server app, customize the experience in the `Pages/_Layout.cshtml` file:

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

In a Blazor WebAssembly app, customize the experience in the `wwwroot/index.html` file:

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

The `blazor-error-ui` element is normally hidden due to the presence of the `display: none` style of the `blazor-error-ui` CSS class in the site's stylesheet (`wwwroot/css/site.css` for Blazor Server or `wwwroot/css/app.css` for Blazor WebAssembly). When an error occurs, the framework applies `display: block` to the element.

## Detailed circuit errors

*This section applies to Blazor Server apps.*

Client-side errors don't include the call stack and don't provide detail on the cause of the error, but server logs do contain such information. For development purposes, sensitive circuit error information can be made available to the client by enabling detailed errors.

Set <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> to `true`. For more information and an example, see <xref:blazor/fundamentals/signalr#circuit-handler-options-for-blazor-server-apps>.

An alternative to setting <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> is to set the `DetailedErrors` configuration key to `true` in the app's Development environment settings file (`appsettings.Development.json`).  Additionally, set [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) (`Microsoft.AspNetCore.SignalR`) to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel) for detailed SignalR logging.

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

The <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> configuration key can also be set to `true` using the `ASPNETCORE_DETAILEDERRORS` environment variable with a value of `true` on Development/Staging environment servers or on your local system.

> [!WARNING]
> Always avoid exposing error information to clients on the Internet, which is a security risk.

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Blazor Server unhandled exceptions

*This section applies to Blazor Server apps.*

Blazor Server is a stateful framework. While users interact with an app, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, the user creates multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes. The crashed app must be restarted, but other apps aren't affected.

The framework terminates a circuit when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues in an undefined state.

## Error boundaries

Blazor is a single-page application (SPA) client-side framework. The browser serves as the app's host and thus acts as the processing pipeline for individual Razor components based on URI requests for navigation and static assets. Unlike ASP.NET Core apps that run on the server with a middleware processing pipeline, there is no middleware pipeline that processes requests for Razor components that can be leveraged for global error handling. However, an app can use an error processing component as a cascading value to process errors in a centralized way.

*Error boundaries* provide a convenient approach for handling exceptions. The <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component:

* Renders its child content when an error hasn't occurred.
* Renders error UI when an unhandled exception is thrown.

To define an error boundary, use the <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component to wrap existing content. For example, an error boundary can be added around the body content of the app's main layout.

`Shared/MainLayout.razor`:

```razor
<div class="main">
    <div class="content px-4">
        <ErrorBoundary>
            @Body
        </ErrorBoundary>
    </div>
</div>
```

The app continues to function normally, but the error boundary handles unhandled exceptions.

Consider the following example, where the `Counter` component throws an exception if the count increments past five.

In `Pages/Counter.razor`:

```csharp
private void IncrementCount()
{
    currentCount++;

    if (currentCount > 5)
    {
        throw new InvalidOperationException("Current count is too big!");
    }
}
```

If the unhandled exception is thrown for a `currentCount` over five:

* The exception is handled by the error boundary.
* Error UI is rendered (`An error has occurred!`).

By default, the <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component renders an empty `<div>` element with the `blazor-error-boundary` CSS class for its error content. The colors, text, and icon for the default UI are defined using CSS in the app's stylesheet in the `wwwroot` folder, so you're free to customize the error UI.

You can also change the default error content by setting the `ErrorContent` property:

```razor
<ErrorBoundary>
    <ChildContent>
        @Body
    </ChildContent>
    <ErrorContent>
        <p class="errorUI">Nothing to see here right now. Sorry!</p>
    </ErrorContent>
</ErrorBoundary>
```

Because the error boundary is defined in the layout in the preceding examples, the error UI is seen regardless of which page the user navigated to. We recommend narrowly scoping error boundaries in most scenarios. If you do broadly scope an error boundary, you can reset it to a non-error state on subsequent page navigation events by calling the error boundary's <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.Recover%2A> method:

```razor
...

<ErrorBoundary @ref="errorBoundary">
    @Body
</ErrorBoundary>

...

@code {
    private ErrorBoundary? errorBoundary;

    protected override void OnParametersSet()
    {
        errorBoundary?.Recover();
    }
}
```

## Alternative global exception handling

An alternative to using [Error boundaries](#error-boundaries) (<xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary>) is to pass a custom error component as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

The following `Error` component example merely logs errors, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. 

`Shared/Error.razor`:

```razor
@using Microsoft.Extensions.Logging
@inject ILogger<Error> Logger

<CascadingValue Value="this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", 
            ex.GetType(), ex.Message);
    }
}
```

In the `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

`App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

To process errors in a component:

* Designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) in the [`@code`](xref:mvc/views/razor#code) block. In an example `Counter` component in an app based on a Blazor project template, add the following `Error` property:

  ```csharp
  [CascadingParameter]
  public Error? Error { get; set; }
  ```

* Call an error processing method in any `catch` block with an appropriate exception type. The example `Error` component only offers a single `ProcessError` method, but the error processing component can provide any number of error processing methods to address alternative error processing requirements throughout the app. In the following `Counter` component example, an exception is thrown and trapped when the count is greater than five:

  ```razor
  @code {
      private int currentCount = 0;

      [CascadingParameter]
      public Error? Error { get; set; }

      private void IncrementCount()
      {
          try
          {
              currentCount++;

              if (currentCount > 5)
              {
                  throw new InvalidOperationException("Current count is over five!");
              }
          }
          catch (Exception ex)
          {
              Error?.ProcessError(ex);
          }
      }
  }
  ```

Using the preceding `Error` component with the preceding changes made to a `Counter` component, the browser's developer tools console indicates the trapped, logged error:

```console
fail: BlazorSample.Shared.Error[0]
Error:ProcessError - Type: System.InvalidOperationException Message: Current count is over five!
```

If the `ProcessError` method directly participates in rendering, such as showing a custom error message bar or changing the CSS styles of the rendered elements, call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) at the end of the `ProcessErrors` method to rerender the UI.

Because the approaches in this section handle errors with a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, a Blazor Server app's SignalR connection between the client and server isn't broken when an error occurs and the circuit remains alive. Other unhandled exceptions remain fatal to a circuit. For more information, see the preceding section on [how a Blazor Server app reacts to unhandled exceptions](#blazor-server-unhandled-exceptions).

## Log errors with a persistent provider

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a location on the server (or backend web API for Blazor WebAssembly apps) with a provider that manages log size and log rotation. Alternatively, the app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)](/azure/azure-monitor/app/app-insights-overview).

> [!NOTE]
> Native [Application Insights](/azure/azure-monitor/app/app-insights-overview) features to support Blazor WebAssembly apps and native Blazor framework support for [Google Analytics](https://analytics.google.com/analytics/web/) might become available in future releases of these technologies. For more information, see [Support App Insights in Blazor WASM Client Side (microsoft/ApplicationInsights-dotnet #2143)](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2143) and [Web analytics and diagnostics (includes links to community implementations) (dotnet/aspnetcore #5461)](https://github.com/dotnet/aspnetcore/issues/5461). In the meantime, a client-side Blazor WebAssembly app can use the [Application Insights JavaScript SDK](/azure/azure-monitor/app/javascript) with [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to log errors directly to Application Insights from a client-side app.

During development in a Blazor Server app, the app usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors aren't sent to clients, but an exception's full details are logged on the server.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&Dagger;
* <xref:web-api/index>

&Dagger;Applies to Blazor Server apps and other server-side ASP.NET Core apps that are web API backend apps for Blazor. Blazor WebAssembly apps can trap and send error information on the client to a web API, which logs the error information to a persistent logging provider.

## Places where errors may occur

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

* [Component instantiation](#component-instantiation)
* [Lifecycle methods](#lifecycle-methods)
* [Rendering logic](#rendering-logic)
* [Event handlers](#event-handlers)
* [Component disposal](#component-disposal)
* [JavaScript interop](#javascript-interop)
* [Prerendering](#prerendering)

### Component instantiation

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

An error in an executed constructor or a setter for any `[Inject]` property results in an unhandled exception and stops the framework from instantiating the component. If the app is a Blazor Server app, the circuit fails. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to a Blazor Server circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](~/blazor/samples/6.0/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor?highlight=11,27-39)]

### Rendering logic

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. For Blazor Server apps, an unhandled exception thrown by rendering logic is fatal to the app's circuit.

To prevent a <xref:System.NullReferenceException> in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

```razor
@if (person.Address != null)
{
    <div>@person.Address.Line1</div>
    <div>@person.Address.Line2</div>
    <div>@person.Address.City</div>
    <div>@person.Address.Country</div>
}
```

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated, as the following example shows:

```razor
@code {
    private Person person = new();

    ...
}
```

### Event handlers

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If the app calls code that could fail for external reasons, trap exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If an event handler throws an unhandled exception (for example, a database query fails) that isn't trapped and handled by developer code:

* The framework logs the exception.
* In a Blazor Server app, the exception is fatal to the app's circuit.

### Component disposal

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If the component's `Dispose` method throws an unhandled exception in a Blazor Server app, the exception is fatal to the app's circuit.

If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception in a Blazor Server app, the resulting exception is fatal to the app's circuit.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise in a Blazor Server app, the failing code results in an unhandled exception that's fatal to the app's circuit.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception:

* In a Blazor Server app, the exception is ***not*** treated as fatal to the app's circuit.
* The JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

### Prerendering

Razor components can be prerendered using the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) so that their rendered HTML markup is returned as part of the user's initial HTTP request.

In Blazor Server, prerendering works by:

* Creating a new circuit for all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server. When the connection is established, interactivity on the circuit is resumed and the components' HTML markup is updated.

In prerendered Blazor WebAssembly, prerendering works by:

* Generating initial HTML on the server for all of the prerendered components that are part of the same page.
* Making the component interactive on the client after the browser has loaded the app's compiled code and the .NET runtime (if not already loaded) in the background.

If a component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* In Blazor Sever apps, the exception is fatal to the circuit. In prerendered Blazor WebAssembly apps, the exception prevents rendering the component.
* The exception is thrown up the call stack from the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, place error handling logic in the component rendered by the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>.

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

In these scenarios, the Blazor WebAssembly thread or Blazor Server circuit fails and usually attempts to:

* Consume as much CPU time as permitted by the operating system, indefinitely.
* Consume an unlimited amount of memory. Consuming unlimited memory is equivalent to the scenario where an unterminated loop adds entries to a collection on every iteration.

To avoid infinite recursion patterns, ensure that recursive rendering code contains suitable stopping conditions.

### Custom render tree logic

Most Razor components are implemented as Razor component files (`.razor`) and are compiled by the framework to produce logic that operates on a <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to render their output. However, a developer may manually implement <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic using procedural C# code. For more information, see <xref:blazor/advanced-scenarios#manually-build-a-render-tree-rendertreebuilder>.

> [!WARNING]
> Use of manual render tree builder logic is considered an advanced and unsafe scenario, not recommended for general component development.

If <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> code is written, the developer must guarantee the correctness of the code. For example, the developer must ensure that:

* Calls to <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenElement%2A> and <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseElement%2A> are correctly balanced.
* Attributes are only added in the correct places.

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, app (Blazor WebAssembly) or server (Blazor Server) hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or [Microsoft Intermediate Language (MSIL)](/dotnet/standard/managed-code) instructions by hand.

## Additional resources

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;
* <xref:web-api/index>

&dagger;Applies to backend ASP.NET Core web API apps that client-side Blazor WebAssembly apps use for logging.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Detailed errors during development for Blazor WebAssembly apps

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

In a Blazor WebAssembly app, customize the experience in the `wwwroot/index.html` file:

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

The `blazor-error-ui` element is normally hidden due to the presence of the `display: none` style of the `blazor-error-ui` CSS class in the app's stylesheet (`wwwroot/css/app.css`). When an error occurs, the framework applies `display: block` to the element.

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Global exception handling

Blazor is a single-page application (SPA) client-side framework. The browser serves as the app's host and thus acts as the processing pipeline for individual Razor components based on URI requests for navigation and static assets. Unlike ASP.NET Core apps that run on the server with a middleware processing pipeline, there is no middleware pipeline that processes requests for Razor components that can be leveraged for global error handling. However, an app can use an error processing component as a cascading value to process errors in a centralized way.

The following `Error` component passes itself as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. The following example merely logs the error, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

`Shared/Error.razor`:

```razor
@using Microsoft.Extensions.Logging
@inject ILogger<Error> Logger

<CascadingValue Value="this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", 
            ex.GetType(), ex.Message);
    }
}
```

In the `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

`App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

To process errors in a component:

* Designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) in the [`@code`](xref:mvc/views/razor#code) block:

  ```razor
  [CascadingParameter]
  public Error Error { get; set; }
  ```

* Call an error processing method in any `catch` block with an appropriate exception type. The example `Error` component only offers a single `ProcessError` method, but the error processing component can provide any number of error processing methods to address alternative error processing requirements throughout the app.

  ```csharp
  try
  {
      ...
  }
  catch (Exception ex)
  {
      Error.ProcessError(ex);
  }
  ```

Using the preceding example `Error` component and `ProcessError` method, the browser's developer tools console indicates the trapped, logged error:

> fail: BlazorSample.Shared.Error[0]
> Error:ProcessError - Type: System.NullReferenceException Message: Object reference not set to an instance of an object.

If the `ProcessError` method directly participates in rendering, such as showing a custom error message bar or changing the CSS styles of the rendered elements, call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) at the end of the `ProcessErrors` method to rerender the UI.

Because the approaches in this section handle errors with a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, a Blazor Server app's SignalR connection between the client and server isn't broken when an error occurs and the circuit remains alive. Any unhandled exception is fatal to a circuit. For more information, see the preceding section on [how a Blazor Server app reacts to unhandled exceptions](#how-a-blazor-server-app-reacts-to-unhandled-exceptions).

## Log errors with a persistent provider (Blazor WebAssembly)

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location on the server by sending error information to a backend web API that uses a logging provider with log size management and log rotation. Alternatively, the backend web API app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)&dagger;](/azure/azure-monitor/app/app-insights-overview), to record error information that it receives from clients.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&Dagger;
* <xref:web-api/index>

&dagger;Native [Application Insights](/azure/azure-monitor/app/app-insights-overview) features to support Blazor WebAssembly apps and native Blazor framework support for [Google Analytics](https://analytics.google.com/analytics/web/) might become available in future releases of these technologies. For more information, see [Support App Insights in Blazor WASM Client Side (microsoft/ApplicationInsights-dotnet #2143)](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2143) and [Web analytics and diagnostics (includes links to community implementations) (dotnet/aspnetcore #5461)](https://github.com/dotnet/aspnetcore/issues/5461). In the meantime, a client-side Blazor WebAssembly app can use the [Application Insights JavaScript SDK](/azure/azure-monitor/app/javascript) with [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to log errors directly to Application Insights from a client-side app.

&Dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps. Client-side apps trap and send error information to a web API, which logs the error information to a persistent logging provider.

## Places where errors may occur in Blazor WebAssembly apps

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

* [Component instantiation](#component-instantiation-blazor-webassembly)
* [Lifecycle methods](#lifecycle-methods-blazor-webassembly)
* [Rendering logic](#rendering-logic-blazor-webassembly)
* [Event handlers](#event-handlers-blazor-webassembly)
* [Component disposal](#component-disposal-blazor-webassembly)
* [JavaScript interop](#javascript-interop-blazor-webassembly)

### Component instantiation (Blazor WebAssembly)

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

An error in an executed constructor or a setter for any `[Inject]` property results in an unhandled exception and stops the framework from instantiating the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods (Blazor WebAssembly)

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/handle-errors/ProductDetails.razor?highlight=11,27-39)]

### Rendering logic (Blazor WebAssembly)

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`.

To prevent a <xref:System.NullReferenceException> in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

```razor
@if (person.Address != null)
{
    <div>@person.Address.Line1</div>
    <div>@person.Address.Line2</div>
    <div>@person.Address.City</div>
    <div>@person.Address.Country</div>
}
```

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated, as the following example shows:

```razor
@code {
    private Person person = new();

    ...
}
```

### Event handlers (Blazor WebAssembly)

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If the app calls code that could fail for external reasons, trap exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception.

### Component disposal (Blazor WebAssembly)

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop (Blazor WebAssembly)

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception, the JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

## Detailed errors during development for Blazor Server apps

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

In a Blazor Server app, customize the experience in the `Pages/_Host.cshtml` file:

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

The `blazor-error-ui` element is normally hidden due to the presence of the `display: none` style of the `blazor-error-ui` CSS class in the site's stylesheet (`wwwroot/css/site.css`). When an error occurs, the framework applies `display: block` to the element.

## Blazor Server detailed circuit errors

Client-side errors don't include the call stack and don't provide detail on the cause of the error, but server logs do contain such information. For development purposes, sensitive circuit error information can be made available to the client by enabling detailed errors.

Set <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> to `true`. For more information and an example, see <xref:blazor/fundamentals/signalr#circuit-handler-options-for-blazor-server-apps>.

An alternative to setting <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> is to set the `DetailedErrors` configuration key to `true` in the app's Development environment settings file (`appsettings.Development.json`).  Additionally, set [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) (`Microsoft.AspNetCore.SignalR`) to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel) for detailed SignalR logging.

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

The <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> configuration key can also be set to `true` using the `ASPNETCORE_DETAILEDERRORS` environment variable with a value of `true` on Development/Staging environment servers or on your local system.

> [!WARNING]
> Always avoid exposing error information to clients on the Internet, which is a security risk.

## How a Blazor Server app reacts to unhandled exceptions

Blazor Server is a stateful framework. While users interact with an app, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, the user creates multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes. The crashed app must be restarted, but other apps aren't affected.

The framework terminates a circuit when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues in an undefined state.

## Log errors with a persistent provider (Blazor Server)

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location on the server with a provider that manages log size and log rotation. Alternatively, the app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)](/azure/azure-monitor/app/app-insights-overview).

During development, a Blazor Server app usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors aren't sent to clients, but an exception's full details are logged on the server.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;

&dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps.

## Places where errors may occur in Blazor Server apps

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

* [Component instantiation](#component-instantiation-blazor-server)
* [Lifecycle methods](#lifecycle-methods-blazor-server)
* [Rendering logic](#rendering-logic-blazor-server)
* [Event handlers](#event-handlers-blazor-server)
* [Component disposal](#component-disposal-blazor-server)
* [JavaScript interop](#javascript-interop-blazor-server)
* [Prerendering](#prerendering-blazor-server)

### Component instantiation (Blazor Server)

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of any non-singleton DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

A Blazor Server circuit fails when any executed constructor or a setter for any `[Inject]` property throws an unhandled exception. The exception is fatal because the framework can't instantiate the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods (Blazor Server)

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to a Blazor Server circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](~/blazor/samples/5.0/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor?highlight=11,27-39)]

### Rendering logic (Blazor Server)

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. An unhandled exception thrown by rendering logic is fatal to a Blazor Server circuit.

To prevent a <xref:System.NullReferenceException> in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

```razor
@if (person.Address != null)
{
    <div>@person.Address.Line1</div>
    <div>@person.Address.Line2</div>
    <div>@person.Address.City</div>
    <div>@person.Address.Country</div>
}
```

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated, as the following example shows:

```razor
@code {
    private Person person = new();

    ...
}
```

### Event handlers (Blazor Server)

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If an event handler throws an unhandled exception (for example, a database query fails), the exception is fatal to a Blazor Server circuit. If the app calls code that could fail for external reasons, trap exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception and terminates the circuit.

### Component disposal (Blazor Server)

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If the component's `Dispose` method throws an unhandled exception, the exception is fatal to a Blazor Server circuit. If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop (Blazor Server)

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception, the resulting exception is fatal to a Blazor Server circuit.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise, the failing code results in an unhandled exception that's fatal to a Blazor Server circuit.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception:

* The exception isn't treated as fatal to a Blazor Server circuit.
* The JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

### Prerendering (Blazor Server)

Razor components can be prerendered using the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) so that their rendered HTML markup is returned as part of the user's initial HTTP request. This works by:

* Creating a new circuit for all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server. When the connection is established, interactivity on the circuit is resumed and the components' HTML markup is updated.

If any component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* The exception is fatal to the circuit.
* The exception is thrown up the call stack from the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper. Therefore, the entire HTTP request fails unless the exception is explicitly caught by developer code.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, place error handling logic in the component rendered by the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper.

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

In these scenarios, the Blazor WebAssembly thread or Blazor Server circuit fails and usually attempts to:

* Consume as much CPU time as permitted by the operating system, indefinitely.
* Consume an unlimited amount of memory. Consuming unlimited memory is equivalent to the scenario where an unterminated loop adds entries to a collection on every iteration.

To avoid infinite recursion patterns, ensure that recursive rendering code contains suitable stopping conditions.

### Custom render tree logic

Most Razor components are implemented as Razor component files (`.razor`) and are compiled by the framework to produce logic that operates on a <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to render their output. However, a developer may manually implement <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic using procedural C# code. For more information, see <xref:blazor/advanced-scenarios#manually-build-a-render-tree-rendertreebuilder>.

> [!WARNING]
> Use of manual render tree builder logic is considered an advanced and unsafe scenario, not recommended for general component development.

If <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> code is written, the developer must guarantee the correctness of the code. For example, the developer must ensure that:

* Calls to <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenElement%2A> and <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseElement%2A> are correctly balanced.
* Attributes are only added in the correct places.

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, app (Blazor WebAssembly) or server (Blazor Server) hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or [Microsoft Intermediate Language (MSIL)](/dotnet/standard/managed-code) instructions by hand.

## Additional resources

### Blazor WebAssembly

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;
* <xref:web-api/index>

&dagger;Applies to backend ASP.NET Core web API apps that client-side Blazor WebAssembly apps use for logging.

### Blazor Server

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;

&dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Detailed errors during development for Blazor WebAssembly apps

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

In a Blazor WebAssembly app, customize the experience in the `wwwroot/index.html` file:

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

The `blazor-error-ui` element is normally hidden due the presence of the `display: none` style of the `blazor-error-ui` CSS class in the app's stylesheet (`wwwroot/css/app.css`). When an error occurs, the framework applies `display: block` to the element.

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Global exception handling

Blazor is a single-page application (SPA) client-side framework. The browser serves as the app's host and thus acts as the processing pipeline for individual Razor components based on URI requests for navigation and static assets. Unlike ASP.NET Core apps that run on the server with a middleware processing pipeline, there is no middleware pipeline that processes requests for Razor components that can be leveraged for global error handling. However, an app can use an error processing component as a cascading value to process errors in a centralized way.

The following `Error` component passes itself as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. The following example merely logs the error, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

`Shared/Error.razor`:

```razor
@using Microsoft.Extensions.Logging
@inject ILogger<Error> Logger

<CascadingValue Value="this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", 
            ex.GetType(), ex.Message);
    }
}
```

In the `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

`App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

To process errors in a component:

* Designate the `Error` component as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute) in the [`@code`](xref:mvc/views/razor#code) block:

  ```razor
  [CascadingParameter]
  public Error Error { get; set; }
  ```

* Call an error processing method in any `catch` block with an appropriate exception type. The example `Error` component only offers a single `ProcessError` method, but the error processing component can provide any number of error processing methods to address alternative error processing requirements throughout the app.

  ```csharp
  try
  {
      ...
  }
  catch (Exception ex)
  {
      Error.ProcessError(ex);
  }
  ```

Using the preceding example `Error` component and `ProcessError` method, the browser's developer tools console indicates the trapped, logged error:

> fail: BlazorSample.Shared.Error[0]
> Error:ProcessError - Type: System.NullReferenceException Message: Object reference not set to an instance of an object.

If the `ProcessError` method directly participates in rendering, such as showing a custom error message bar or changing the CSS styles of the rendered elements, call [`StateHasChanged`](xref:blazor/components/lifecycle#state-changes-statehaschanged) at the end of the `ProcessErrors` method to rerender the UI.

Because the approaches in this section handle errors with a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, a Blazor Server app's SignalR connection between the client and server isn't broken when an error occurs and the circuit remains alive. Any unhandled exception is fatal to a circuit. For more information, see the preceding section on [how a Blazor Server app reacts to unhandled exceptions](#how-a-blazor-server-app-reacts-to-unhandled-exceptions).

## Log errors with a persistent provider (Blazor WebAssembly)

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location on the server by sending error information to a backend web API that uses a logging provider with log size management and log rotation. Alternatively, the backend web API app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)&dagger;](/azure/azure-monitor/app/app-insights-overview), to record error information that it receives from clients.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&Dagger;
* <xref:web-api/index>

&dagger;Native [Application Insights](/azure/azure-monitor/app/app-insights-overview) features to support Blazor WebAssembly apps and native Blazor framework support for [Google Analytics](https://analytics.google.com/analytics/web/) might become available in future releases of these technologies. For more information, see [Support App Insights in Blazor WASM Client Side (microsoft/ApplicationInsights-dotnet #2143)](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2143) and [Web analytics and diagnostics (includes links to community implementations) (dotnet/aspnetcore #5461)](https://github.com/dotnet/aspnetcore/issues/5461). In the meantime, a client-side Blazor WebAssembly app can use the [Application Insights JavaScript SDK](/azure/azure-monitor/app/javascript) with [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to log errors directly to Application Insights from a client-side app.

&Dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps. Client-side apps trap and send error information to a web API, which logs the error information to a persistent logging provider.

## Places where errors may occur in Blazor WebAssembly apps

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

* [Component instantiation](#component-instantiation-blazor-webassembly)
* [Lifecycle methods](#lifecycle-methods-blazor-webassembly)
* [Rendering logic](#rendering-logic-blazor-webassembly)
* [Event handlers](#event-handlers-blazor-webassembly)
* [Component disposal](#component-disposal-blazor-webassembly)
* [JavaScript interop](#javascript-interop-blazor-webassembly)

### Component instantiation (Blazor WebAssembly)

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of any non-singleton DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

An error in an executed constructor or a setter for any `[Inject]` property results in an unhandled exception and stops the framework from instantiating the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods (Blazor WebAssembly)

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/handle-errors/ProductDetails.razor?highlight=11,27-39)]

### Rendering logic (Blazor WebAssembly)

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`.

To prevent a <xref:System.NullReferenceException> in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

```razor
@if (person.Address != null)
{
    <div>@person.Address.Line1</div>
    <div>@person.Address.Line2</div>
    <div>@person.Address.City</div>
    <div>@person.Address.Country</div>
}
```

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated, as the following example shows:

```razor
@code {
    private Person person = new Person();

    ...
}
```

### Event handlers (Blazor WebAssembly)

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If the app calls code that could fail for external reasons, trap exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception.

### Component disposal (Blazor WebAssembly)

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop (Blazor WebAssembly)

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception, the JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

## Detailed errors during development for Blazor Server apps

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

In a Blazor Server app, customize the experience in the `Pages/_Host.cshtml` file:

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

The `blazor-error-ui` element is normally hidden due the presence of the `display: none` style of the `blazor-error-ui` CSS class in the site's stylesheet (`wwwroot/css/site.css`). When an error occurs, the framework applies `display: block` to the element.

## Blazor Server detailed circuit errors

Client-side errors don't include the call stack and don't provide detail on the cause of the error, but server logs do contain such information. For development purposes, sensitive circuit error information can be made available to the client by enabling detailed errors.

Set <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> to `true`. For more information and an example, see <xref:blazor/fundamentals/signalr#circuit-handler-options-for-blazor-server-apps>.

An alternative to setting <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> is to set the `DetailedErrors` configuration key to `true` in the app's Development environment settings file (`appsettings.Development.json`).  Additionally, set [SignalR server-side logging](xref:signalr/diagnostics#server-side-logging) (`Microsoft.AspNetCore.SignalR`) to [Debug](xref:Microsoft.Extensions.Logging.LogLevel) or [Trace](xref:Microsoft.Extensions.Logging.LogLevel) for detailed SignalR logging.

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

The <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors> configuration key can also be set to `true` using the `ASPNETCORE_DETAILEDERRORS` environment variable with a value of `true` on Development/Staging environment servers or on your local system.

> [!WARNING]
> Always avoid exposing error information to clients on the Internet, which is a security risk.

## How a Blazor Server app reacts to unhandled exceptions

Blazor Server is a stateful framework. While users interact with an app, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, the user creates multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes. The crashed app must be restarted, but other apps aren't affected.

The framework terminates a circuit when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues in an undefined state.

## Log errors with a persistent provider (Blazor Server)

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location on the server with a provider that manages log size and log rotation. Alternatively, the app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)](/azure/azure-monitor/app/app-insights-overview).

During development, a Blazor Server app usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors aren't sent to clients, but an exception's full details are logged on the server.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;

&dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps.

## Places where errors may occur in Blazor Server apps

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

* [Component instantiation](#component-instantiation-blazor-server)
* [Lifecycle methods](#lifecycle-methods-blazor-server)
* [Rendering logic](#rendering-logic-blazor-server)
* [Event handlers](#event-handlers-blazor-server)
* [Component disposal](#component-disposal-blazor-server)
* [JavaScript interop](#javascript-interop-blazor-server)
* [Prerendering](#prerendering-blazor-server)

### Component instantiation (Blazor Server)

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of any non-singleton DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

A Blazor Server circuit fails when any executed constructor or a setter for any `[Inject]` property throws an unhandled exception. The exception is fatal because the framework can't instantiate the component. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods (Blazor Server)

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to a Blazor Server circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

[!code-razor[](~/blazor/samples/3.1/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor?highlight=11,27-39)]

### Rendering logic (Blazor Server)

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. An unhandled exception thrown by rendering logic is fatal to a Blazor Server circuit.

To prevent a <xref:System.NullReferenceException> in rendering logic, check for a `null` object before accessing its members. In the following example, `person.Address` properties aren't accessed if `person.Address` is `null`:

```razor
@if (person.Address != null)
{
    <div>@person.Address.Line1</div>
    <div>@person.Address.Line2</div>
    <div>@person.Address.City</div>
    <div>@person.Address.Country</div>
}
```

The preceding code assumes that `person` isn't `null`. Often, the structure of the code guarantees that an object exists at the time the component is rendered. In those cases, it isn't necessary to check for `null` in rendering logic. In the prior example, `person` might be guaranteed to exist because `person` is created when the component is instantiated, as the following example shows:

```razor
@code {
    private Person person = new Person();

    ...
}
```

### Event handlers (Blazor Server)

Client-side code triggers invocations of C# code when event handlers are created using:

* `@onclick`
* `@onchange`
* Other `@on...` attributes
* `@bind`

Event handler code might throw an unhandled exception in these scenarios.

If an event handler throws an unhandled exception (for example, a database query fails), the exception is fatal to a Blazor Server circuit. If the app calls code that could fail for external reasons, trap exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

If user code doesn't trap and handle the exception, the framework logs the exception and terminates the circuit.

### Component disposal (Blazor Server)

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If the component's `Dispose` method throws an unhandled exception, the exception is fatal to a Blazor Server circuit. If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop (Blazor Server)

<xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception, the resulting exception is fatal to a Blazor Server circuit.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JavaScript-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise, the failing code results in an unhandled exception that's fatal to a Blazor Server circuit.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JavaScript code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JavaScript code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception:

* The exception isn't treated as fatal to a Blazor Server circuit.
* The JavaScript-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JavaScript side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

### Prerendering (Blazor Server)

Razor components can be prerendered using the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) so that their rendered HTML markup is returned as part of the user's initial HTTP request. This works by:

* Creating a new circuit for all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server. When the connection is established, interactivity on the circuit is resumed and the components' HTML markup is updated.

If any component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* The exception is fatal to the circuit.
* The exception is thrown up the call stack from the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper. Therefore, the entire HTTP request fails unless the exception is explicitly caught by developer code.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, place error handling logic in the component rendered by the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> Tag Helper.

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

In these scenarios, the Blazor WebAssembly thread or Blazor Server circuit fails and usually attempts to:

* Consume as much CPU time as permitted by the operating system, indefinitely.
* Consume an unlimited amount of memory. Consuming unlimited memory is equivalent to the scenario where an unterminated loop adds entries to a collection on every iteration.

To avoid infinite recursion patterns, ensure that recursive rendering code contains suitable stopping conditions.

### Custom render tree logic

Most Razor components are implemented as Razor component files (`.razor`) and are compiled by the framework to produce logic that operates on a <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> to render their output. However, a developer may manually implement <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> logic using procedural C# code. For more information, see <xref:blazor/advanced-scenarios#manually-build-a-render-tree-rendertreebuilder>.

> [!WARNING]
> Use of manual render tree builder logic is considered an advanced and unsafe scenario, not recommended for general component development.

If <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder> code is written, the developer must guarantee the correctness of the code. For example, the developer must ensure that:

* Calls to <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.OpenElement%2A> and <xref:Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder.CloseElement%2A> are correctly balanced.
* Attributes are only added in the correct places.

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, app (Blazor WebAssembly) or server (Blazor Server) hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or [Microsoft Intermediate Language (MSIL)](/dotnet/standard/managed-code) instructions by hand.

## Additional resources

### Blazor WebAssembly

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;
* <xref:web-api/index>

&dagger;Applies to backend ASP.NET Core web API apps that client-side Blazor WebAssembly apps use for logging.

### Blazor Server

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;

&dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps.

:::moniker-end
