---
title: Handle errors in ASP.NET Core Blazor apps
author: guardrex
description: Discover how ASP.NET Core Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/fundamentals/handle-errors
---
# Handle errors in ASP.NET Core Blazor apps

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how Blazor manages unhandled exceptions and how to develop apps that detect and handle errors.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net31-or-later.md)]

## Detailed errors during development

When a Blazor app isn't functioning properly during development, receiving detailed error information from the app assists in troubleshooting and fixing the issue. When an error occurs, Blazor apps display a light yellow bar at the bottom of the screen:

* During development, the bar directs you to the browser console, where you can see the exception.
* In production, the bar notifies the user that an error has occurred and recommends refreshing the browser.

The UI for this error handling experience is part of the [Blazor project templates](xref:blazor/project-structure).

:::moniker range=">= aspnetcore-8.0"

In a Blazor Web App, customize the experience in the `MainLayout` component. Because the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) (for example, `<environment include="Production">...</environment>`) isn't supported in Razor components, the following example injects <xref:Microsoft.Extensions.Hosting.IHostEnvironment> to configure error messages for different environments.

At the top of `Components/Layout/MainLayout.razor`:

```razor
@inject IHostEnvironment HostEnvironment
```

Create or modify the Blazor error UI markup:

```razor
<div id="blazor-error-ui">
    @if (HostEnvironment.IsProduction())
    {
        <span>An error has occurred.</span>
    }
    else
    {
        <span>An unhandled exception occurred.</span>
    }
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

In a Blazor Server app, customize the experience in the `Pages/_Host.cshtml` file. The following example uses the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) to configure error messages for different environments.

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

In a Blazor Server app, customize the experience in the `Pages/_Layout.cshtml` file. The following example uses the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) to configure error messages for different environments.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In a Blazor Server app, customize the experience in the `Pages/_Host.cshtml` file. The following example uses the [Environment Tag Helper](xref:mvc/views/tag-helpers/builtin-th/environment-tag-helper) to configure error messages for different environments.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

Create or modify the Blazor error UI markup:

```cshtml
<div id="blazor-error-ui">
    <environment include="Staging,Production">
        An error has occurred.
    </environment>
    <environment include="Development">
        An unhandled exception occurred.
    </environment>
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

:::moniker-end

In a Blazor WebAssembly app, customize the experience in the `wwwroot/index.html` file:

```html
<div id="blazor-error-ui">
    An unhandled error has occurred.
    <a href="" class="reload">Reload</a>
    <a class="dismiss">🗙</a>
</div>
```

:::moniker range=">= aspnetcore-8.0"

The `blazor-error-ui` element is normally hidden due to the presence of the `display: none` style of the `blazor-error-ui` CSS class in the app's auto-generated stylesheet. When an error occurs, the framework applies `display: block` to the element.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The `blazor-error-ui` element is normally hidden due to the presence of the `display: none` style of the `blazor-error-ui` CSS class in the site's stylesheet in the `wwwroot/css` folder. When an error occurs, the framework applies `display: block` to the element.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Handle caught exceptions outside of a Razor component's lifecycle

Use `ComponentBase.DispatchExceptionAsync` in a Razor component to process exceptions thrown outside of the component's lifecycle call stack. This permits the component's code to treat exceptions as though they're lifecycle method exceptions. Thereafter, Blazor's error handling mechanisms, such as [error boundaries](xref:blazor/fundamentals/handle-errors#error-boundaries), can process the exceptions.

> [!NOTE]
> `ComponentBase.DispatchExceptionAsync` is used in Razor component files (`.razor`) that inherit from <xref:Microsoft.AspNetCore.Components.ComponentBase>. When creating components that [implement <xref:Microsoft.AspNetCore.Components.IComponent> directly](xref:blazor/components/index#component-classes), use `RenderHandle.DispatchExceptionAsync`.

To handle caught exceptions outside of a Razor component's lifecycle, pass the exception to `DispatchExceptionAsync` and await the result:

```csharp
try
{
    ...
}
catch (Exception ex)
{
    await DispatchExceptionAsync(ex);
}
```

A common scenario is if a component wants to start an asynchronous operation but doesn't await a <xref:System.Threading.Tasks.Task>. If the operation fails, you may still want the component to treat the failure as a component lifecycle exception for the following example goals:

* Put the component into a faulted state, for example, to trigger an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries).
* Terminate the circuit if there's no error boundary.
* Trigger the same logging that occurs for lifecycle exceptions.

In the following example, the user selects the **Send report** button to trigger a background method, `ReportSender.SendAsync`, that sends a report. In most cases, a component awaits the <xref:System.Threading.Tasks.Task> of an asynchronous call and updates the UI to indicate the operation completed. In the following example, the `SendReport` method doesn't await a <xref:System.Threading.Tasks.Task> and doesn't report the result to the user. Because the component intentionally discards the <xref:System.Threading.Tasks.Task> in `SendReport`, any asynchronous failures occur off of the normal lifecycle call stack, hence aren't seen by Blazor:

```razor
<button @onclick="SendReport">Send report</button>

@code {
    private void SendReport()
    {
        _ = ReportSender.SendAsync();
    }
}
```

To treat failures like lifecycle method exceptions, explicitly dispatch exceptions back to the component with `DispatchExceptionAsync`, as the following example demonstrates: 

```razor
<button @onclick="SendReport">Send report</button>

@code {
    private void SendReport()
    {
        _ = SendReportAsync();
    }

    private async Task SendReportAsync()
    {
        try
        {
            await ReportSender.SendAsync();
        }
        catch (Exception ex)
        {
            await DispatchExceptionAsync(ex);
        }
    }
}
```

For a working demonstration of `DispatchExceptionAsync`, implement the timer notification example in [Invoke component methods externally to update state](xref:blazor/components/sync-context#invoke-component-methods-externally-to-update-state). In a Blazor app, add the following files from the timer notification example and register the services in the `Program` file as the section explains:

* `TimerService.cs`
* `NotifierService.cs`
* `ReceiveNotifications.razor`

The example uses a timer outside of a Razor component's lifecycle, where an unhandled exception normally isn't processed by Blazor's error handling mechanisms, such as an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries).

First, change the code in `TimerService.cs` to create an artificial exception outside of the component's lifecycle. In the `while` loop of `TimerService.cs`, throw an exception when the `elapsedCount` reaches a value of two:

```csharp
if (elapsedCount == 2)
{
    throw new Exception("I threw an exception! Somebody help me!");
}
```

Place an [error boundary](xref:blazor/fundamentals/handle-errors#error-boundaries) in the app's main layout. Replace the `<article>...</article>` markup with the following markup.

`Components/Layout/MainLayout.razor`:

```razor
<article class="content px-4">
    <ErrorBoundary>
        <ChildContent>
            @Body
        </ChildContent>
        <ErrorContent>
            <p class="alert alert-danger" role="alert">
                Oh, dear! Oh, my! - George Takei
            </p>
        </ErrorContent>
    </ErrorBoundary>
</article>
```

If you run the app at this point, the exception is thrown when the elapsed count reaches a value of two. However, the UI doesn't change. The error boundary doesn't show the error content.

Change the `OnNotify` method of the `ReceiveNotification` component (`ReceiveNotification.razor`):

* Wrap the call to <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> in a `try-catch` block.
* Pass any <xref:System.Exception> to `DispatchExceptionAsync` and await the result.

```csharp
public async Task OnNotify(string key, int value)
{
    try
    {
        await InvokeAsync(() =>
        {
            lastNotification = (key, value);
            StateHasChanged();
        });
    }
    catch (Exception ex)
    {
        await DispatchExceptionAsync(ex);
    }
}
```

When the timer service executes and reaches a count of two, the exception is dispatched to the Razor component, which in turn triggers the error boundary to display the error content of the `<ErrorBoundary>` in the `MainLayout` component:

> :::no-loc text="Oh, dear! Oh, my! - George Takei":::

:::moniker-end

## Detailed circuit errors

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps operating over a circuit.*

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to Blazor Server apps.*

:::moniker-end

Client-side errors don't include the call stack and don't provide detail on the cause of the error, but server logs do contain such information. For development purposes, sensitive circuit error information can be made available to the client by enabling detailed errors.

Set <xref:Microsoft.AspNetCore.Components.Server.CircuitOptions.DetailedErrors?displayProperty=nameWithType> to `true`. For more information and an example, see <xref:blazor/fundamentals/signalr#server-side-circuit-handler-options>.

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

:::moniker range=">= aspnetcore-8.0"

## Detailed errors for Razor component server-side rendering

*This section applies to Blazor Web Apps.*

Use the `DetailedErrors` option to control producing detailed information on errors for Razor component server-side rendering. The default value is `false`.

The following example enables detailed errors:

```csharp
builder.Services.AddRazorComponents(options => options.DetailedErrors = true);
```

<!-- UPDATE 8.0 We need to flesh out this warning with the consequences
                of enabling detailed errors in production. -->

> [!WARNING]
> Only enable detailed errors in the Development environment.

:::moniker-end

## Manage unhandled exceptions in developer code

For an app to continue after an error, the app must have error handling logic. Later sections of this article describe potential sources of unhandled exceptions.

In production, don't render framework exception messages or stack traces in the UI. Rendering exception messages or stack traces could:

* Disclose sensitive information to end users.
* Help a malicious user discover weaknesses in an app that can compromise the security of the app, server, or network.

## Unhandled exceptions for circuits

:::moniker range=">= aspnetcore-8.0"

*This section applies to Blazor Web Apps operating over a circuit.*

:::moniker-end

:::moniker range="< aspnetcore-8.0"

*This section applies to Blazor Server apps.*

:::moniker-end

Razor components with server interactivity enabled are stateful on the server. While users interact with the component on the server, they maintain a connection to the server known as a *circuit*. The circuit holds active component instances, plus many other aspects of state, such as:

* The most recent rendered output of components.
* The current set of event-handling delegates that could be triggered by client-side events.

If a user opens the app in multiple browser tabs, the user creates multiple independent circuits.

Blazor treats most unhandled exceptions as fatal to the circuit where they occur. If a circuit is terminated due to an unhandled exception, the user can only continue to interact with the app by reloading the page to create a new circuit. Circuits outside of the one that's terminated, which are circuits for other users or other browser tabs, aren't affected. This scenario is similar to a desktop app that crashes. The crashed app must be restarted, but other apps aren't affected.

The framework terminates a circuit when an unhandled exception occurs for the following reasons:

* An unhandled exception often leaves the circuit in an undefined state.
* The app's normal operation can't be guaranteed after an unhandled exception.
* Security vulnerabilities may appear in the app if the circuit continues in an undefined state.

## Global exception handling

:::moniker range=">= aspnetcore-6.0"

For global exception handling, see the following sections:

* [Error boundaries](#error-boundaries)
* [Alternative global exception handling](#alternative-global-exception-handling)

## Error boundaries

*Error boundaries* provide a convenient approach for handling exceptions. The <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component:

* Renders its child content when an error hasn't occurred.
* Renders error UI when an unhandled exception is thrown.

To define an error boundary, use the <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component to wrap existing content. The app continues to function normally, but the error boundary handles unhandled exceptions.

```razor
<ErrorBoundary>
    ...
</ErrorBoundary>
```

To implement an error boundary in a global fashion, add the boundary around the body content of the app's main layout.

In `MainLayout.razor`:

```razor
<article class="content px-4">
    <ErrorBoundary>
        @Body
    </ErrorBoundary>
</article>
```

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

In Blazor Web Apps with the error boundary only applied to a noninteractive `MainLayout` component, the boundary is only active during the Static Server rendering phase. The boundary doesn't activate just because a component further down the component hierarchy is interactive. To enable interactivity broadly for the `MainLayout` component and the rest of the components further down the component hierarchy, enable interactivity with server rendering at the top of the `Routes` component (`Components/Routes.razor`):

```razor
@rendermode RenderMode.InteractiveServer
```

If you prefer not to enable server interactivity across the entire app from the `Routes` component, place the error boundary further down the component hierarchy. For example, place the error boundary around markup in individual components that enable interactivity, not in the app's main layout. The important concepts to keep in mind are that wherever the error boundary is placed:

* If the error boundary isn't interactive, it's only capable of activating on the server during static rendering. For example, the boundary can activate when an error is thrown in a component lifecycle method.
* If the error boundary is interactive, it's capable of activating for Interactive Server-rendered components that it wraps.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Consider the following example, where the `Counter` component throws an exception if the count increments past five.

In `Counter.razor`:

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

* The error is logged normally (`System.InvalidOperationException: Current count is too big!`).
* The exception is handled by the error boundary.
* Error UI is rendered by the error boundary with the following default error message: `An error has occurred.`

By default, the <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> component renders an empty `<div>` element with the `blazor-error-boundary` CSS class for its error content. The colors, text, and icon for the default UI are defined using CSS in the app's stylesheet in the `wwwroot` folder, so you're free to customize the error UI.

Change the default error content by setting the <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.ErrorContent> property:

```razor
<ErrorBoundary>
    <ChildContent>
        @Body
    </ChildContent>
    <ErrorContent>
        <p class="errorUI">😈 A rotten gremlin got us. Sorry!</p>
    </ErrorContent>
</ErrorBoundary>
```

Because the error boundary is defined in the layout in the preceding examples, the error UI is seen regardless of which page the user navigates to after the error occurs. We recommend narrowly scoping error boundaries in most scenarios. If you broadly scope an error boundary, you can reset it to a non-error state on subsequent page navigation events by calling the error boundary's <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.Recover%2A> method.

In `MainLayout.razor`:

* Add a field for the <xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary> to [capture a reference](xref:blazor/components/index#capture-references-to-components) to it with the [`@ref`](xref:mvc/views/razor#ref) attribute directive.
* In the [`OnParameterSet` lifecycle method](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync), trigger a recovery on the error boundary with <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.Recover%2A>.

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

To avoid the infinite loop where recovering merely rerenders a component that throws the error again, don't call <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.Recover%2A> from rendering logic. Only call <xref:Microsoft.AspNetCore.Components.ErrorBoundaryBase.Recover%2A> when:

* The user performs a UI gesture, such as selecting a button to indicate that they want to retry a procedure or when the user navigates to a new component.
* Additional logic also clears the exception. When the component is rerendered, the error doesn't reoccur.

## Alternative global exception handling

An alternative to using [Error boundaries](#error-boundaries) (<xref:Microsoft.AspNetCore.Components.Web.ErrorBoundary>) is to pass a custom error component as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

The following `Error` component example merely logs errors, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. 

`Error.razor`:

```razor
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

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

<!-- UPDATE 8.0 Confirm that we want to do this in the App component
     and not in the Routes component wrapping the Router -->

In the `App` component, wrap the `Routes` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

In `App.razor`:

```razor
<Error>
    <Routes />
</Error>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

In the `App` component, wrap the `Router` component with the `Error` component. This permits the `Error` component to cascade down to any component of the app where the `Error` component is received as a [`CascadingParameter`](xref:blazor/components/cascading-values-and-parameters#cascadingparameter-attribute).

In `App.razor`:

```razor
<Error>
    <Router ...>
        ...
    </Router>
</Error>
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

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

Because the approaches in this section handle errors with a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, an app's SignalR connection between the client and server isn't broken when an error occurs and the circuit remains alive. Other unhandled exceptions remain fatal to a circuit. For more information, see the section on [how a circuit reacts to unhandled exceptions](#unhandled-exceptions-for-circuits).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

An app can use an error processing component as a cascading value to process errors in a centralized way.

The following `Error` component passes itself as a [`CascadingValue`](xref:blazor/components/cascading-values-and-parameters#cascadingvalue-component) to child components. The following example merely logs the error, but methods of the component can process errors in any way required by the app, including through the use of multiple error processing methods. An advantage of using a component over using an [injected service](xref:blazor/fundamentals/dependency-injection) or a custom logger implementation is that a cascaded component can render content and apply CSS styles when an error occurs.

`Error.razor`:

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

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

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

Because the approaches in this section handle errors with a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, a Blazor app's SignalR connection between the client and server isn't broken when an error occurs and the circuit remains alive. Any unhandled exception is fatal to a circuit. For more information, see the section on [how a circuit reacts to unhandled exceptions](#unhandled-exceptions-for-circuits).

:::moniker-end

## Log errors with a persistent provider

:::moniker range=">= aspnetcore-6.0"

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a location on the server (or backend web API for client-side apps) with a provider that manages log size and log rotation. Alternatively, the app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)](/azure/azure-monitor/app/app-insights-overview).

> [!NOTE]
> Native [Application Insights](/azure/azure-monitor/app/app-insights-overview) features to support client-side apps and native Blazor framework support for [Google Analytics](https://analytics.google.com/analytics/web/) might become available in future releases of these technologies. For more information, see [Support App Insights in Blazor WASM Client Side (microsoft/ApplicationInsights-dotnet #2143)](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2143) and [Web analytics and diagnostics (includes links to community implementations) (dotnet/aspnetcore #5461)](https://github.com/dotnet/aspnetcore/issues/5461). In the meantime, a client-side app can use the [Application Insights JavaScript SDK](/azure/azure-monitor/app/javascript) with [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to log errors directly to Application Insights from a client-side app.

During development in a Blazor app operating over a circuit, the app usually sends the full details of exceptions to the browser's console to aid in debugging. In production, detailed errors aren't sent to clients, but an exception's full details are logged on the server.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&Dagger;
* <xref:web-api/index>

&Dagger;Applies to server-side Blazor apps and other server-side ASP.NET Core apps that are web API backend apps for Blazor. Client-side apps can trap and send error information on the client to a web API, which logs the error information to a persistent logging provider.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

If an unhandled exception occurs, the exception is logged to <xref:Microsoft.Extensions.Logging.ILogger> instances configured in the service container. By default, Blazor apps log to console output with the Console Logging Provider. Consider logging to a more permanent location on the server by sending error information to a backend web API that uses a logging provider with log size management and log rotation. Alternatively, the backend web API app can use an Application Performance Management (APM) service, such as [Azure Application Insights (Azure Monitor)&dagger;](/azure/azure-monitor/app/app-insights-overview), to record error information that it receives from clients.

You must decide which incidents to log and the level of severity of logged incidents. Hostile users might be able to trigger errors deliberately. For example, don't log an incident from an error where an unknown `ProductId` is supplied in the URL of a component that displays product details. Not all errors should be treated as incidents for logging.

For more information, see the following articles:

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&Dagger;
* <xref:web-api/index>

&dagger;Native [Application Insights](/azure/azure-monitor/app/app-insights-overview) features to support client-side apps and native Blazor framework support for [Google Analytics](https://analytics.google.com/analytics/web/) might become available in future releases of these technologies. For more information, see [Support App Insights in Blazor WASM Client Side (microsoft/ApplicationInsights-dotnet #2143)](https://github.com/microsoft/ApplicationInsights-dotnet/issues/2143) and [Web analytics and diagnostics (includes links to community implementations) (dotnet/aspnetcore #5461)](https://github.com/dotnet/aspnetcore/issues/5461). In the meantime, a client-side app can use the [Application Insights JavaScript SDK](/azure/azure-monitor/app/javascript) with [JS interop](xref:blazor/js-interop/call-javascript-from-dotnet) to log errors directly to Application Insights from a client-side app.

&Dagger;Applies to server-side ASP.NET Core apps that are web API backend apps for Blazor apps. Client-side apps trap and send error information to a web API, which logs the error information to a persistent logging provider.

:::moniker-end

## Places where errors may occur

Framework and app code may trigger unhandled exceptions in any of the following locations, which are described further in the following sections of this article:

:::moniker range=">= aspnetcore-6.0"

* [Component instantiation](#component-instantiation)
* [Lifecycle methods](#lifecycle-methods)
* [Rendering logic](#rendering-logic)
* [Event handlers](#event-handlers)
* [Component disposal](#component-disposal)
* [JavaScript interop](#javascript-interop)
* [Prerendering](#prerendering)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* [Component instantiation](#component-instantiation)
* [Lifecycle methods](#lifecycle-methods)
* [Rendering logic](#rendering-logic)
* [Event handlers](#event-handlers)
* [Component disposal](#component-disposal)
* [JavaScript interop](#javascript-interop)
* [Prerendering](#prerendering)

:::moniker-end

### Component instantiation

When Blazor creates an instance of a component:

* The component's constructor is invoked.
* The constructors of DI services supplied to the component's constructor via the [`@inject`](xref:mvc/views/razor#inject) directive or the [`[Inject]` attribute](xref:blazor/fundamentals/dependency-injection#request-a-service-in-a-component) are invoked.

An error in an executed constructor or a setter for any `[Inject]` property results in an unhandled exception and stops the framework from instantiating the component. If the app is operating over a circuit, the circuit fails. If constructor logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

### Lifecycle methods

During the lifetime of a component, Blazor invokes [lifecycle methods](xref:blazor/components/lifecycle). If any lifecycle method throws an exception, synchronously or asynchronously, the exception is fatal to a circuit. For components to deal with errors in lifecycle methods, add error handling logic.

In the following example where <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> calls a method to obtain a product:

* An exception thrown in the `ProductRepository.GetProductByIdAsync` method is handled by a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement.
* When the `catch` block is executed:
  * `loadFailed` is set to `true`, which is used to display an error message to the user.
  * The error is logged.

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor" highlight="11,27-39":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor" highlight="11,27-39":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor" highlight="11,27-39":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_Server/Pages/handle-errors/ProductDetails.razor" highlight="11,27-39":::

:::moniker-end

### Rendering logic

The declarative markup in a Razor component file (`.razor`) is compiled into a C# method called <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A>. When a component renders, <xref:Microsoft.AspNetCore.Components.ComponentBase.BuildRenderTree%2A> executes and builds up a data structure describing the elements, text, and child components of the rendered component.

Rendering logic can throw an exception. An example of this scenario occurs when `@someObject.PropertyName` is evaluated but `@someObject` is `null`. For Blazor apps operating over a circuit, an unhandled exception thrown by rendering logic is fatal to the app's circuit.

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
* In a Blazor app operating over a circuit, the exception is fatal to the app's circuit.

### Component disposal

A component may be removed from the UI, for example, because the user has navigated to another page. When a component that implements <xref:System.IDisposable?displayProperty=fullName> is removed from the UI, the framework calls the component's <xref:System.IDisposable.Dispose%2A> method.

If the component's `Dispose` method throws an unhandled exception in a Blazor app operating over a circuit, the exception is fatal to the app's circuit.

If disposal logic may throw exceptions, the app should trap the exceptions using a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging.

For more information on component disposal, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

### JavaScript interop

<xref:Microsoft.JSInterop.IJSRuntime> is registered by the Blazor framework. <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A?displayProperty=nameWithType> allows .NET code to make asynchronous calls to the JavaScript (JS) runtime in the user's browser.

The following conditions apply to error handling with <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A>:

* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails synchronously, a .NET exception occurs. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the supplied arguments can't be serialized. Developer code must catch the exception. If app code in an event handler or component lifecycle method doesn't handle an exception in a Blazor app operating over a circuit, the resulting exception is fatal to the app's circuit.
* If a call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> fails asynchronously, the .NET <xref:System.Threading.Tasks.Task> fails. A call to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> may fail, for example, because the JS-side code throws an exception or returns a `Promise` that completed as `rejected`. Developer code must catch the exception. If using the [`await`](/dotnet/csharp/language-reference/keywords/await) operator, consider wrapping the method call in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement with error handling and logging. Otherwise in a Blazor app operating over a circuit, the failing code results in an unhandled exception that's fatal to the app's circuit.
* By default, calls to <xref:Microsoft.JSInterop.IJSRuntime.InvokeAsync%2A> must complete within a certain period or else the call times out. The default timeout period is one minute. The timeout protects the code against a loss in network connectivity or JS code that never sends back a completion message. If the call times out, the resulting <xref:System.Threading.Tasks> fails with an <xref:System.OperationCanceledException>. Trap and process the exception with logging.

Similarly, JS code may initiate calls to .NET methods indicated by the [`[JSInvokable]` attribute](xref:blazor/js-interop/call-dotnet-from-javascript). If these .NET methods throw an unhandled exception:

* In a Blazor app operating over a circuit, the exception is ***not*** treated as fatal to the app's circuit.
* The JS-side `Promise` is rejected.

You have the option of using error handling code on either the .NET side or the JS side of the method call.

For more information, see the following articles:

* <xref:blazor/js-interop/call-javascript-from-dotnet>
* <xref:blazor/js-interop/call-dotnet-from-javascript>

:::moniker range=">= aspnetcore-6.0"

### Prerendering

Razor components are prerendered by default so that their rendered HTML markup is returned as part of the user's initial HTTP request.

In a Blazor app operating over a circuit, prerendering works by:

* Creating a new circuit for all of the prerendered components that are part of the same page.
* Generating the initial HTML.
* Treating the circuit as `disconnected` until the user's browser establishes a SignalR connection back to the same server. When the connection is established, interactivity on the circuit is resumed and the components' HTML markup is updated.

For prerendered client-side components, prerendering works by:

* Generating initial HTML on the server for all of the prerendered components that are part of the same page.
* Making the component interactive on the client after the browser has loaded the app's compiled code and the .NET runtime (if not already loaded) in the background.

If a component throws an unhandled exception during prerendering, for example, during a lifecycle method or in rendering logic:

* In a Blazor app operating over a circuit, the exception is fatal to the circuit. For prerendered client-side components, the exception prevents rendering the component.
* The exception is thrown up the call stack from the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>.

Under normal circumstances when prerendering fails, continuing to build and render the component doesn't make sense because a working component can't be rendered.

To tolerate errors that may occur during prerendering, error handling logic must be placed inside a component that may throw exceptions. Use [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statements with error handling and logging. Instead of wrapping the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper> in a [`try-catch`](/dotnet/csharp/language-reference/keywords/try-catch) statement, place error handling logic in the component rendered by the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>.

:::moniker-end

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

In these scenarios, the Blazor fails and usually attempts to:

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

Incorrect manual render tree builder logic can cause arbitrary undefined behavior, including crashes, app or server hangs, and security vulnerabilities.

Consider manual render tree builder logic on the same level of complexity and with the same level of *danger* as writing assembly code or [Microsoft Intermediate Language (MSIL)](/dotnet/standard/managed-code) instructions by hand.

## Additional resources

* <xref:blazor/fundamentals/logging>
* <xref:fundamentals/error-handling>&dagger;
* <xref:web-api/index>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

&dagger;Applies to backend ASP.NET Core web API apps that client-side Blazor apps use for logging.
