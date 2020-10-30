---
title: ASP.NET Core Blazor lifecycle
author: guardrex
description: Learn how to use Razor component lifecycle methods in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/14/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/lifecycle
---
# ASP.NET Core Blazor lifecycle

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

The Blazor framework includes synchronous and asynchronous lifecycle methods. Override lifecycle methods to perform additional operations on components during component initialization and rendering.

The following diagrams illustrate the Blazor lifecycle. Lifecycle methods are defined with examples in the following sections of this article.

Component lifecycle events:

1. If the component is rendering for the first time on a request:
   * Create the component's instance.
   * Perform property injection. Run [`SetParametersAsync`](#before-parameters-are-set).
   * Call [`OnInitialized{Async}`](#component-initialization-methods). If a <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rendered. If a <xref:System.Threading.Tasks.Task> isn't returned, render the component.
1. Call [`OnParametersSet{Async}`](#after-parameters-are-set). If a <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rendered. If a <xref:System.Threading.Tasks.Task> isn't returned, render the component.

![Component lifecycle events of a Razor component in Blazor](lifecycle/_static/lifecycle1.png)

Document Object Model (DOM) event processing:

1. The event handler is run.
1. If a <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rendered. If a <xref:System.Threading.Tasks.Task> isn't returned, the component is rendered.

![Document Object Model (DOM) event processing](lifecycle/_static/lifecycle2.png)

The `Render` lifecycle:

1. If this isn't the component's first render or [`ShouldRender`](#suppress-ui-refreshing) is evaluated as `false`, don't perform further operations on the component.
1. Build the render tree diff (difference) and render the component.
1. Await the DOM to update.
1. Call [`OnAfterRender{Async}`](#after-component-render).

![Render lifecycle](lifecycle/_static/lifecycle3.png)

Developer calls to [`StateHasChanged`](#state-changes) result in a render.

## Lifecycle methods

### Before parameters are set

<xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets parameters supplied by the component's parent in the render tree:

```csharp
public override async Task SetParametersAsync(ParameterView parameters)
{
    await ...

    await base.SetParametersAsync(parameters);
}
```

<xref:Microsoft.AspNetCore.Components.ParameterView> contains the set of parameter values for the component each time <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> is called.

The default implementation of <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets the value of each property with the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) or [`[CascadingParameter]`](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) attribute that has a corresponding value in the <xref:Microsoft.AspNetCore.Components.ParameterView>. Parameters that don't have a corresponding value in <xref:Microsoft.AspNetCore.Components.ParameterView> are left unchanged.

If [`base.SetParametersAync`](xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A) isn't invoked, the custom code can interpret the incoming parameters value in any way required. For example, there's no requirement to assign the incoming parameters to the properties on the class.

If any event handlers are set up, unhook them on disposal. For more information, see the [Component disposal with `IDisposable`](#component-disposal-with-idisposable) section.

### Component initialization methods

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> are invoked when the component is initialized after having received its initial parameters from its parent component in <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A>. 

Use <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> when the component performs an asynchronous operation and should refresh when the operation is completed.

For a synchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

```csharp
protected override void OnInitialized()
{
    ...
}
```

To perform an asynchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> and use the [`await`](/dotnet/csharp/language-reference/operators/await) operator on the operation:

```csharp
protected override async Task OnInitializedAsync()
{
    await ...
}
```

Blazor Server apps that [prerender their content](xref:blazor/fundamentals/additional-scenarios#render-mode) call <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> **_twice_**:

* Once when the component is initially rendered statically as part of the page.
* A second time when the browser establishes a connection back to the server.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> from running twice, see the [Stateful reconnection after prerendering](#stateful-reconnection-after-prerendering) section.

While a Blazor Server app is prerendering, certain actions, such as calling into JavaScript, aren't possible because a connection with the browser hasn't been established. Components may need to render differently when prerendered. For more information, see the [Detect when the app is prerendering](#detect-when-the-app-is-prerendering) section.

If any event handlers are set up, unhook them on disposal. For more information, see the [Component disposal with `IDisposable`](#component-disposal-with-idisposable) section.

### After parameters are set

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet%2A> are called:

* After the component is initialized in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
* When the parent component re-renders and supplies:
  * Only known primitive immutable types of which at least one parameter has changed.
  * Any complex-typed parameters. The framework can't know whether the values of a complex-typed parameter have mutated internally, so it treats the parameter set as changed.

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

> [!NOTE]
> Asynchronous work when applying parameters and property values must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> lifecycle event.

```csharp
protected override void OnParametersSet()
{
    ...
}
```

If any event handlers are set up, unhook them on disposal. For more information, see the [Component disposal with `IDisposable`](#component-disposal-with-idisposable) section.

### After component render

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps using the rendered content, such as activating third-party JavaScript libraries that operate on the rendered DOM elements.

The `firstRender` parameter for <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A>:

* Is set to `true` the first time that the component instance is rendered.
* Can be used to ensure that initialization work is only performed once.

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await ...
    }
}
```

> [!NOTE]
> Asynchronous work immediately after rendering must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> lifecycle event.
>
> Even if you return a <xref:System.Threading.Tasks.Task> from <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>, the framework doesn't schedule a further render cycle for your component once that task completes. This is to avoid an infinite render loop. It's different from the other lifecycle methods, which schedule a further render cycle once the returned task completes.

```csharp
protected override void OnAfterRender(bool firstRender)
{
    if (firstRender)
    {
        ...
    }
}
```

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> *aren't called during the prerendering process on the server*. The methods are called when the component is rendered interactively after prerendering is finished. When the app prerenders:

1. The component executes on the server to produce some static HTML markup in the HTTP response. During this phase, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> aren't called.
1. When `blazor.server.js` or `blazor.webassembly.js` start up in the browser, the component is restarted in an interactive rendering mode. After a component is restarted, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> **are** called because the app isn't inside the prerendering phase any longer.

If any event handlers are set up, unhook them on disposal. For more information, see the [Component disposal with `IDisposable`](#component-disposal-with-idisposable) section.

### Suppress UI refreshing

Override <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> to suppress UI refreshing. If the implementation returns `true`, the UI is refreshed:

```csharp
protected override bool ShouldRender()
{
    var renderUI = true;

    return renderUI;
}
```

<xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> is called each time the component is rendered.

Even if <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender%2A> is overridden, the component is always initially rendered.

For more information, see <xref:blazor/webassembly-performance-best-practices#avoid-unnecessary-rendering-of-component-subtrees>.

## State changes

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> notifies the component that its state has changed. When applicable, calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> causes the component to be rerendered.

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called automatically for <xref:Microsoft.AspNetCore.Components.EventCallback> methods. For more information, see <xref:blazor/components/event-handling#eventcallback>.

## Handle incomplete async actions at render

Asynchronous actions performed in lifecycle events might not have completed before the component is rendered. Objects might be `null` or incompletely populated with data while the lifecycle method is executing. Provide rendering logic to confirm that objects are initialized. Render placeholder UI elements (for example, a loading message) while objects are `null`.

In the `FetchData` component of the Blazor templates, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is overridden to asychronously receive forecast data (`forecasts`). When `forecasts` is `null`, a loading message is displayed to the user. After the `Task` returned by <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> completes, the component is rerendered with the updated state.

`Pages/FetchData.razor` in the Blazor Server template:

[!code-razor[](lifecycle/samples_snapshot/FetchData.razor?highlight=9,21,25)]

## Handle errors

For information on handling errors during lifecycle method execution, see <xref:blazor/fundamentals/handle-errors#lifecycle-methods>.

## Stateful reconnection after prerendering

In a Blazor Server app when <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode> is <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered>, the component is initially rendered statically as part of the page. Once the browser establishes a connection back to the server, the component is rendered *again*, and the component is now interactive. If the [`OnInitialized{Async}`](#component-initialization-methods) lifecycle method for initializing the component is present, the method is executed *twice*:

* When the component is prerendered statically.
* After the server connection has been established.

This can result in a noticeable change in the data displayed in the UI when the component is finally rendered.

To avoid the double-rendering scenario in a Blazor Server app:

* Pass in an identifier that can be used to cache the state during prerendering and to retrieve the state after the app restarts.
* Use the identifier during prerendering to save component state.
* Use the identifier after prerendering to retrieve the cached state.

The following code demonstrates an updated `WeatherForecastService` in a template-based Blazor Server app that avoids the double rendering:

```csharp
public class WeatherForecastService
{
    private static readonly string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild",
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public WeatherForecastService(IMemoryCache memoryCache)
    {
        MemoryCache = memoryCache;
    }
    
    public IMemoryCache MemoryCache { get; }

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return MemoryCache.GetOrCreateAsync(startDate, async e =>
        {
            e.SetOptions(new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = 
                    TimeSpan.FromSeconds(30)
            });

            var rng = new Random();

            await Task.Delay(TimeSpan.FromSeconds(10));

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            }).ToArray();
        });
    }
}
```

For more information on the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode>, see <xref:blazor/fundamentals/additional-scenarios#render-mode>.

## Detect when the app is prerendering

[!INCLUDE[](~/includes/blazor-prerendering.md)]

## Component disposal with IDisposable

If a component implements <xref:System.IDisposable>, the [`Dispose` method](/dotnet/standard/garbage-collection/implementing-dispose) is called when the component is removed from the UI. Disposal can occur at any time, including during [component initialization](#component-initialization-methods). The following component uses `@implements IDisposable` and the `Dispose` method:

```razor
@using System
@implements IDisposable

...

@code {
    public void Dispose()
    {
        ...
    }
}
```

> [!NOTE]
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in `Dispose` isn't supported. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

Unsubscribe event handlers from .NET events. The following [Blazor form](xref:blazor/forms-validation) examples show how to unhook an event handler in the `Dispose` method:

* Private field and lambda approach

  [!code-razor[](lifecycle/samples_snapshot/event-handler-disposal-1.razor?highlight=23,28)]

* Private method approach

  [!code-razor[](lifecycle/samples_snapshot/event-handler-disposal-2.razor?highlight=16,26)]

## Cancelable background work

Components often perform long-running background work, such as making network calls (<xref:System.Net.Http.HttpClient>) and interacting with databases. It's desirable to stop the background work to conserve system resources in several situations. For example, background asynchronous operations don't automatically stop when a user navigates away from a component.

Other reasons why background work items might require cancellation include:

* An executing background task was started with faulty input data or processing parameters.
* The current set of executing background work items must be replaced with a new set of work items.
* The priority of currently executing tasks must be changed.
* The app has to be shut down in order to redeploy it to the server.
* Server resources become limited, necessitating the rescheduling of background work items.

To implement a cancelable background work pattern in a component:

* Use a <xref:System.Threading.CancellationTokenSource> and <xref:System.Threading.CancellationToken>.
* On [disposal of the component](#component-disposal-with-idisposable) and at any point cancellation is desired by manually cancelling the token, call [`CancellationTokenSource.Cancel`](xref:System.Threading.CancellationTokenSource.Cancel%2A) to signal that the background work should be cancelled.
* After the asynchronous call returns, call <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> on the token.

In the following example:

* `await Task.Delay(5000, cts.Token);` represents long-running asynchronous background work.
* `BackgroundResourceMethod` represents a long-running background method that shouldn't start if the `Resource` is disposed before the method is called.

```razor
@implements IDisposable
@using System.Threading

<button @onclick="LongRunningWork">Trigger long running work</button>

@code {
    private Resource resource = new Resource();
    private CancellationTokenSource cts = new CancellationTokenSource();

    protected async Task LongRunningWork()
    {
        await Task.Delay(5000, cts.Token);

        cts.Token.ThrowIfCancellationRequested();
        resource.BackgroundResourceMethod();
    }

    public void Dispose()
    {
        cts.Cancel();
        cts.Dispose();
        resource.Dispose();
    }

    private class Resource : IDisposable
    {
        private bool disposed;

        public void BackgroundResourceMethod()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(nameof(Resource));
            }
            
            ...
        }
        
        public void Dispose()
        {
            disposed = true;
        }
    }
}
```
