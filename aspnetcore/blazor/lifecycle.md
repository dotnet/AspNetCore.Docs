---
title: ASP.NET Core Blazor lifecycle
author: guardrex
description: Learn how to use Razor component lifecycle methods in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/18/2019
no-loc: [Blazor, SignalR]
uid: blazor/lifecycle
---
# ASP.NET Core Blazor lifecycle

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

The Blazor framework includes synchronous and asynchronous lifecycle methods. Override lifecycle methods to perform additional operations on components during component initialization and rendering.

## Lifecycle methods

### Component initialization methods

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync*> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized*> are invoked when the component is initialized after having received its initial parameters from its parent component. Use `OnInitializedAsync` when the component performs an asynchronous operation and should refresh when the operation is completed.

For a synchronous operation, override `OnInitialized`:

```csharp
protected override void OnInitialized()
{
    ...
}
```

To perform an asynchronous operation, override `OnInitializedAsync` and use the `await` keyword on the operation:

```csharp
protected override async Task OnInitializedAsync()
{
    await ...
}
```

Blazor Server apps that [prerender their content](xref:blazor/hosting-model-configuration#render-mode) call `OnInitializedAsync` **_twice_**:

* Once when the component is initially rendered statically as part of the page.
* A second time when the browser establishes a connection back to the server.

To prevent developer code in `OnInitializedAsync` from running twice, see the [Stateful reconnection after prerendering](#stateful-reconnection-after-prerendering) section.

While a Blazor Server app is prerendering, certain actions, such as calling into JavaScript, aren't possible because a connection with the browser hasn't been established. Components may need to render differently when prerendered. For more information, see the [Detect when the app is prerendering](#detect-when-the-app-is-prerendering) section.

### Before parameters are set

<xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync*> sets parameters supplied by the component's parent in the render tree:

```csharp
public override async Task SetParametersAsync(ParameterView parameters)
{
    await ...

    await base.SetParametersAsync(parameters);
}
```

<xref:Microsoft.AspNetCore.Components.ParameterView> contains the entire set of parameter values each time `SetParametersAsync` is called.

The default implementation of `SetParametersAsync` sets the value of each property with the `[Parameter]` or `[CascadingParameter]` attribute that has a corresponding value in the `ParameterView`. Parameters that don't have a corresponding value in `ParameterView` are left unchanged.

If `base.SetParametersAync` isn't invoked, the custom code can interpret the incoming parameters value in any way required. For example, there's no requirement to assign the incoming parameters to the properties on the class.

### After parameters are set

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync*> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet*> are called:

* When the component is initialized and has received its first set of parameters from its parent component.
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
> Asynchronous work when applying parameters and property values must occur during the `OnParametersSetAsync` lifecycle event.

```csharp
protected override void OnParametersSet()
{
    ...
}
```

### After component render

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync*> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender*> are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps using the rendered content, such as activating third-party JavaScript libraries that operate on the rendered DOM elements.

The `firstRender` parameter for `OnAfterRenderAsync` and `OnAfterRender`:

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
> Asynchronous work immediately after rendering must occur during the `OnAfterRenderAsync` lifecycle event.
>
> Even if you return a <xref:System.Threading.Tasks.Task> from `OnAfterRenderAsync`, the framework doesn't schedule a further render cycle for your component once that task completes. This is to avoid an infinite render loop. It's different from the other lifecycle methods, which schedule a further render cycle once the returned task completes.

```csharp
protected override void OnAfterRender(bool firstRender)
{
    if (firstRender)
    {
        ...
    }
}
```

`OnAfterRender` and `OnAfterRenderAsync` *aren't called when prerendering on the server.*

### Suppress UI refreshing

Override <xref:Microsoft.AspNetCore.Components.ComponentBase.ShouldRender*> to suppress UI refreshing. If the implementation returns `true`, the UI is refreshed:

```csharp
protected override bool ShouldRender()
{
    var renderUI = true;

    return renderUI;
}
```

`ShouldRender` is called each time the component is rendered.

Even if `ShouldRender` is overridden, the component is always initially rendered.

## State changes

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged*> notifies the component that its state has changed. When applicable, calling `StateHasChanged` causes the component to be rerendered.

## Handle incomplete async actions at render

Asynchronous actions performed in lifecycle events might not have completed before the component is rendered. Objects might be `null` or incompletely populated with data while the lifecycle method is executing. Provide rendering logic to confirm that objects are initialized. Render placeholder UI elements (for example, a loading message) while objects are `null`.

In the `FetchData` component of the Blazor templates, `OnInitializedAsync` is overridden to asychronously receive forecast data (`forecasts`). When `forecasts` is `null`, a loading message is displayed to the user. After the `Task` returned by `OnInitializedAsync` completes, the component is rerendered with the updated state.

*Pages/FetchData.razor* in the Blazor Server template:

[!code-razor[](lifecycle/samples_snapshot/3.x/FetchData.razor?highlight=9,21,25)]

## Component disposal with IDisposable

If a component implements <xref:System.IDisposable>, the [Dispose method](/dotnet/standard/garbage-collection/implementing-dispose) is called when the component is removed from the UI. The following component uses `@implements IDisposable` and the `Dispose` method:

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
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged*> in `Dispose` isn't supported. `StateHasChanged` might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

## Handle errors

For information on handling errors during lifecycle method execution, see <xref:blazor/handle-errors#lifecycle-methods>.

## Stateful reconnection after prerendering

In a Blazor Server app when `RenderMode` is `ServerPrerendered`, the component is initially rendered statically as part of the page. Once the browser establishes a connection back to the server, the component is rendered *again*, and the component is now interactive. If the [OnInitialized{Async}](xref:blazor/lifecycle#component-initialization-methods) lifecycle method for initializing the component is present, the method is executed *twice*:

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
    private static readonly string[] _summaries = new[]
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
                Summary = _summaries[rng.Next(_summaries.Length)]
            }).ToArray();
        });
    }
}
```

For more information on the `RenderMode`, see <xref:blazor/hosting-model-configuration#render-mode>.

## Detect when the app is prerendering

[!INCLUDE[](~/includes/blazor-prerendering.md)]
