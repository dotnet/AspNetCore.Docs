---
title: ASP.NET Core Razor component lifecycle
author: guardrex
description: Learn about the ASP.NET Core Razor component lifecycle and how to use lifecycle events.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/lifecycle
---
# ASP.NET Core Razor component lifecycle

This article explains the ASP.NET Core Razor component lifecycle and how to use lifecycle events.

:::moniker range=">= aspnetcore-6.0"

The Razor component processes Razor component lifecycle events in a set of synchronous and asynchronous lifecycle methods. The lifecycle methods can be overridden to perform additional operations in components during component initialization and rendering.

## Lifecycle events

The following diagrams illustrate Razor component lifecycle events. The C# methods associated with the lifecycle events are defined with examples in the following sections of this article.

Component lifecycle events:

1. If the component is rendering for the first time on a request:
   * Create the component's instance.
   * Perform property injection. Run [`SetParametersAsync`](#when-parameters-are-set-setparametersasync).
   * Call [`OnInitialized{Async}`](#component-initialization-oninitializedasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Call [`OnParametersSet{Async}`](#after-parameters-are-set-onparameterssetasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Component lifecycle events of a Razor component in Blazor](~/blazor/components/lifecycle/_static/lifecycle1.png)

Document Object Model (DOM) event processing:

1. The event handler is run.
1. If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Document Object Model (DOM) event processing](~/blazor/components/lifecycle/_static/lifecycle2.png)

The `Render` lifecycle:

1. Avoid further rendering operations on the component:
   * After the first render.
   * When [`ShouldRender`](xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender) is `false`.
1. Build the render tree diff (difference) and render the component.
1. Await the DOM to update.
1. Call [`OnAfterRender{Async}`](#after-component-render-onafterrenderasync).

![Render lifecycle](~/blazor/components/lifecycle/_static/lifecycle3.png)

Developer calls to [`StateHasChanged`](#state-changes-statehaschanged) result in a render. For more information, see <xref:blazor/components/rendering>.

## When parameters are set (`SetParametersAsync`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets parameters supplied by the component's parent in the render tree or from route parameters.

The method's <xref:Microsoft.AspNetCore.Components.ParameterView> parameter contains the set of [component parameter](xref:blazor/components/index#component-parameters) values for the component each time <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> is called. By overriding the <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method, developer code can interact directly with <xref:Microsoft.AspNetCore.Components.ParameterView>'s parameters.

The default implementation of <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets the value of each property with the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) or [`[CascadingParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) that has a corresponding value in the <xref:Microsoft.AspNetCore.Components.ParameterView>. Parameters that don't have a corresponding value in <xref:Microsoft.AspNetCore.Components.ParameterView> are left unchanged.

If [`base.SetParametersAsync`](xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A) isn't invoked, developer code can interpret the incoming parameters' values in any way required. For example, there's no requirement to assign the incoming parameters to the properties of the class.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

In the following example, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A?displayProperty=nameWithType> assigns the `Param` parameter's value to `value` if parsing a route parameter for `Param` is successful. When `value` isn't `null`, the value is displayed by the component.

Although [route parameter matching is case insensitive](xref:blazor/fundamentals/routing#route-parameters), <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> only matches case sensitive parameter names in the route template. The following example requires the use of `/{Param?}` in the route template in order to get the value with <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A>, not `/{param?}`. If `/{param?}` is used in this scenario, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> returns `false` and `message` isn't set to either `message` string.

`Pages/SetParamsAsync.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/SetParamsAsync.razor)]

## Component initialization (`OnInitialized{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> are invoked when the component is initialized after having received its initial parameters in <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A>.

For a synchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

`Pages/OnInit.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/OnInit.razor?highlight=8)]

To perform an asynchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> and use the [`await`](/dotnet/csharp/language-reference/operators/await) operator:

```csharp
protected override async Task OnInitializedAsync()
{
    await ...
}
```

Blazor apps that prerender their content on the server call <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> *twice*:

* Once when the component is initially rendered statically as part of the page.
* A second time when the browser renders the component.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> from running twice when prerendering, see the [Stateful reconnection after prerendering](#stateful-reconnection-after-prerendering) section. Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

While a Blazor app is prerendering, certain actions, such as calling into JavaScript (JS interop), aren't possible. Components may need to render differently when prerendered. For more information, see the [Detect when the app is prerendering](#detect-when-the-app-is-prerendering) section.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## After parameters are set (`OnParametersSet{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> are called:

* After the component is initialized in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
* When the parent component rerenders and supplies:
  * Known primitive immutable types when at least one parameter has changed.
  * Complex-typed parameters. The framework can't know whether the values of a complex-typed parameter have mutated internally, so the framework always treats the parameter set as changed when one or more complex-typed parameters are present.

For the following example component, navigate to the component's page at a URL:

* With a start date that's received by `StartDate`: `/on-parameters-set/2021-03-19`
* Without a start date, where `StartDate` is assigned a value of the current local time: `/on-parameters-set`

`Pages/OnParamsSet.razor`:

> [!NOTE]
> In a component route, it isn't possible to both constrain a <xref:System.DateTime> parameter with the [route constraint `datetime`](xref:blazor/fundamentals/routing#route-constraints) and [make the parameter optional](xref:blazor/fundamentals/routing#route-parameters). Therefore, the following `OnParamsSet` component uses two [`@page`](xref:mvc/views/razor#page) directives to handle routing with and without a supplied date segment in the URL.

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/OnParamsSet.razor)]

Asynchronous work when applying parameters and property values must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> lifecycle event:

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

For more information on route parameters and constraints, see <xref:blazor/fundamentals/routing>.

## After component render (`OnAfterRender{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps with the rendered content, such as JS interop calls that interact with the rendered DOM elements.

The `firstRender` parameter for <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>:

* Is set to `true` the first time that the component instance is rendered.
* Can be used to ensure that initialization work is only performed once.

`Pages/AfterRender.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/AfterRender.razor)]

Asynchronous work immediately after rendering must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> lifecycle event:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await ...
    }
}
```

Even if you return a <xref:System.Threading.Tasks.Task> from <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>, the framework doesn't schedule a further render cycle for your component once that task completes. This is to avoid an infinite render loop. This is different from the other lifecycle methods, which schedule a further render cycle once a returned <xref:System.Threading.Tasks.Task> completes.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> *aren't called during the prerendering process on the server*. The methods are called when the component is rendered interactively after prerendering. When the app prerenders:

1. The component executes on the server to produce some static HTML markup in the HTTP response. During this phase, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> aren't called.
1. When the Blazor script (`blazor.webassembly.js` or `blazor.server.js`) start in the browser, the component is restarted in an interactive rendering mode. After a component is restarted, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> **are** called because the app isn't in the prerendering phase any longer.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## State changes (`StateHasChanged`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> notifies the component that its state has changed. When applicable, calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> causes the component to be rerendered.

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called automatically for <xref:Microsoft.AspNetCore.Components.EventCallback> methods. For more information on event callbacks, see <xref:blazor/components/event-handling#eventcallback>.

For more information on component rendering and when to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>, including when to invoke it with <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType>, see <xref:blazor/components/rendering>.

## Handle incomplete async actions at render

Asynchronous actions performed in lifecycle events might not have completed before the component is rendered. Objects might be `null` or incompletely populated with data while the lifecycle method is executing. Provide rendering logic to confirm that objects are initialized. Render placeholder UI elements (for example, a loading message) while objects are `null`.

In the `FetchData` component of the Blazor templates, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is overridden to asynchronously receive forecast data (`forecasts`). When `forecasts` is `null`, a loading message is displayed to the user. After the `Task` returned by <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> completes, the component is rerendered with the updated state.

`Pages/FetchData.razor` in the Blazor Server template:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_Server/Pages/lifecycle/FetchData.razor?highlight=9,21,25)]

## Handle errors

For information on handling errors during lifecycle method execution, see <xref:blazor/fundamentals/handle-errors>.

## Stateful reconnection after prerendering

In a Blazor Server app when <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode> is <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered>, the component is initially rendered statically as part of the page. Once the browser establishes a SignalR connection back to the server, the component is rendered *again* and interactive. If the [`OnInitialized{Async}`](#component-initialization-oninitializedasync) lifecycle method for initializing the component is present, the method is executed *twice*:

* When the component is prerendered statically.
* After the server connection has been established.

This can result in a noticeable change in the data displayed in the UI when the component is finally rendered. To avoid this double-rendering behavior in a Blazor Server app, pass in an identifier to cache the state during prerendering and to retrieve the state after prerendering.

The following code demonstrates an updated `WeatherForecastService` in a template-based Blazor Server app that avoids the double rendering. In the following example, the awaited <xref:System.Threading.Tasks.Task.Delay%2A> (`await Task.Delay(...)`) simulates a short delay before returning data from the `GetForecastAsync` method.

`WeatherForecastService.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_Server/lifecycle/WeatherForecastService.cs)]

For more information on the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode>, see <xref:blazor/fundamentals/signalr#render-mode-blazor-server>.

Although the content in this section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

## Detect when the app is prerendering

[!INCLUDE[](~/blazor/includes/prerendering.md)]

## Component disposal with `IDisposable` and `IAsyncDisposable`

If a component implements <xref:System.IDisposable>, <xref:System.IAsyncDisposable>, or both, the framework calls for unmanaged resource disposal when the component is removed from the UI. Disposal can occur at any time, including during [component initialization](#component-initialization-oninitializedasync).

Components shouldn't need to implement <xref:System.IDisposable> and <xref:System.IAsyncDisposable> simultaneously. If both are implemented, the framework only executes the asynchronous overload.

Developer code must ensure that <xref:System.IAsyncDisposable> implementations don't take a long time to complete.

### Synchronous `IDisposable`

For synchronous disposal tasks, use <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IDisposable

...

@code {
    ...

    public void Dispose()
    {
        obj?.Dispose();
    }
}
```

If a single object requires disposal, a lambda can be used to dispose of the object when <xref:System.IDisposable.Dispose%2A> is called. The following example appears in the <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system> article and demonstrates the use of a lambda expression for the disposal of a <xref:System.Timers.Timer>.

`Pages/CounterWithTimerDisposal1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor?highlight=3,11,28)]

> [!NOTE]
> In the preceding example, the call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is wrapped by a call to <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> because the callback is invoked outside of Blazor's synchronization context. For more information, see <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system>.

If the object is created in a lifecycle method, such as [`OnInitialized`/`OnInitializedAsync`](#component-initialization-oninitializedasync), check for `null` before calling `Dispose`.

`Pages/CounterWithTimerDisposal2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor?highlight=15,29)]

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Asynchronous `IAsyncDisposable`

For asynchronous disposal tasks, use <xref:System.IAsyncDisposable.DisposeAsync%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IAsyncDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IAsyncDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IAsyncDisposable

...

@code {
    ...

    public async ValueTask DisposeAsync()
    {
        if (obj is not null)
        {
            await obj.DisposeAsync();
        }
    }
}
```

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Assignment of `null` to disposed objects

Usually, there's no need to assign `null` to disposed objects after calling <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>. Rare cases for assigning `null` include the following:

* If the object's type is poorly implemented and doesn't tolerate repeat calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>, assign `null` after disposal to gracefully skip further calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>.
* If a long-lived process continues to hold a reference to a disposed object, assigning `null` allows the [garbage collector](/dotnet/standard/garbage-collection/fundamentals) to free the object in spite of the long-lived process holding a reference to it.

These are unusual scenarios. For objects that are implemented correctly and behave normally, there's no point in assigning `null` to disposed objects. In the rare cases where an object must be assigned `null`, we recommend documenting the reason and seeking a solution that prevents the need to assign `null`.

### `StateHasChanged`

> [!NOTE]
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in `Dispose` isn't supported. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

### Event handlers

Always unsubscribe event handlers from .NET events. The following [Blazor form](xref:blazor/forms-validation) examples show how to unsubscribe an event handler in the `Dispose` method:

* Private field and lambda approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      ...

      private EventHandler<FieldChangedEventArgs>? fieldChanged;

      protected override void OnInitialized()
      {
          editContext = new(model);

          fieldChanged = (_, __) =>
          {
              ...
          };

          editContext.OnFieldChanged += fieldChanged;
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= fieldChanged;
      }
  }
  ```

* Private method approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      ...

      protected override void OnInitialized()
      {
          editContext = new(model);
          editContext.OnFieldChanged += HandleFieldChanged;
      }

      private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
      {
          ...
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= HandleFieldChanged;
      }
  }
  ```
  
For more information, see the [Component disposal with `IDisposable` and `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

### Anonymous functions, methods, and expressions

When [anonymous functions](/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions), methods, or expressions, are used, it isn't necessary to implement <xref:System.IDisposable> and unsubscribe delegates. However, failing to unsubscribe a delegate is a problem **when the object exposing the event outlives the lifetime of the component registering the delegate**. When this occurs, a memory leak results because the registered delegate keeps the original object alive. Therefore, only use the following approaches when you know that the event delegate disposes quickly. When in doubt about the lifetime of objects that require disposal, subscribe a delegate method and properly dispose the delegate as the earlier examples show.

* Anonymous lambda method approach (explicit disposal not required):

  ```csharp
  private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
  {
      formInvalid = !editContext.Validate();
      StateHasChanged();
  }

  protected override void OnInitialized()
  {
      editContext = new(starship);
      editContext.OnFieldChanged += (s, e) => HandleFieldChanged((editContext)s, e);
  }
  ```

* Anonymous lambda expression approach (explicit disposal not required):

  ```csharp
  private ValidationMessageStore? messageStore;

  [CascadingParameter]
  private EditContext? CurrentEditContext { get; set; }

  protected override void OnInitialized()
  {
      ...

      messageStore = new(CurrentEditContext);

      CurrentEditContext.OnValidationRequested += (s, e) => messageStore.Clear();
      CurrentEditContext.OnFieldChanged += (s, e) => 
          messageStore.Clear(e.FieldIdentifier);
  }
  ```

  The full example of the preceding code with anonymous lambda expressions appears in the <xref:blazor/forms-validation#validator-components> article.

For more information, see [Cleaning up unmanaged resources](/dotnet/standard/garbage-collection/unmanaged) and the topics that follow it on implementing the `Dispose` and `DisposeAsync` methods.

## Cancelable background work

Components often perform long-running background work, such as making network calls (<xref:System.Net.Http.HttpClient>) and interacting with databases. It's desirable to stop the background work to conserve system resources in several situations. For example, background asynchronous operations don't automatically stop when a user navigates away from a component.

Other reasons why background work items might require cancellation include:

* An executing background task was started with faulty input data or processing parameters.
* The current set of executing background work items must be replaced with a new set of work items.
* The priority of currently executing tasks must be changed.
* The app must be shut down for server redeployment.
* Server resources become limited, necessitating the rescheduling of background work items.

To implement a cancelable background work pattern in a component:

* Use a <xref:System.Threading.CancellationTokenSource> and <xref:System.Threading.CancellationToken>.
* On [disposal of the component](#component-disposal-with-idisposable-and-iasyncdisposable) and at any point cancellation is desired by manually canceling the token, call [`CancellationTokenSource.Cancel`](xref:System.Threading.CancellationTokenSource.Cancel%2A) to signal that the background work should be cancelled.
* After the asynchronous call returns, call <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> on the token.

In the following example:

* `await Task.Delay(5000, cts.Token);` represents long-running asynchronous background work.
* `BackgroundResourceMethod` represents a long-running background method that shouldn't start if the `Resource` is disposed before the method is called.

`Pages/BackgroundWork.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/lifecycle/BackgroundWork.razor)]

## Blazor Server reconnection events

The component lifecycle events covered in this article operate separately from [Blazor Server's reconnection event handlers](xref:blazor/fundamentals/signalr#reflect-the-connection-state-in-the-ui-blazor-server). When a Blazor Server app loses its SignalR connection to the client, only UI updates are interrupted. UI updates are resumed when the connection is re-established. For more information on circuit handler events and configuration, see <xref:blazor/fundamentals/signalr>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

The Razor component processes Razor component lifecycle events in a set of synchronous and asynchronous lifecycle methods. The lifecycle methods can be overridden to perform additional operations in components during component initialization and rendering.

## Lifecycle events

The following diagrams illustrate Razor component lifecycle events. The C# methods associated with the lifecycle events are defined with examples in the following sections of this article.

Component lifecycle events:

1. If the component is rendering for the first time on a request:
   * Create the component's instance.
   * Perform property injection. Run [`SetParametersAsync`](#when-parameters-are-set-setparametersasync).
   * Call [`OnInitialized{Async}`](#component-initialization-oninitializedasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Call [`OnParametersSet{Async}`](#after-parameters-are-set-onparameterssetasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Component lifecycle events of a Razor component in Blazor](~/blazor/components/lifecycle/_static/lifecycle1.png)

Document Object Model (DOM) event processing:

1. The event handler is run.
1. If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Document Object Model (DOM) event processing](~/blazor/components/lifecycle/_static/lifecycle2.png)

The `Render` lifecycle:

1. Avoid further rendering operations on the component:
   * After the first render.
   * When [`ShouldRender`](xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender) is `false`.
1. Build the render tree diff (difference) and render the component.
1. Await the DOM to update.
1. Call [`OnAfterRender{Async}`](#after-component-render-onafterrenderasync).

![Render lifecycle](~/blazor/components/lifecycle/_static/lifecycle3.png)

Developer calls to [`StateHasChanged`](#state-changes-statehaschanged) result in a render. For more information, see <xref:blazor/components/rendering>.

## When parameters are set (`SetParametersAsync`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets parameters supplied by the component's parent in the render tree or from route parameters.

The method's <xref:Microsoft.AspNetCore.Components.ParameterView> parameter contains the set of [component parameter](xref:blazor/components/index#component-parameters) values for the component each time <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> is called. By overriding the <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method, developer code can interact directly with <xref:Microsoft.AspNetCore.Components.ParameterView>'s parameters.

The default implementation of <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets the value of each property with the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) or [`[CascadingParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) that has a corresponding value in the <xref:Microsoft.AspNetCore.Components.ParameterView>. Parameters that don't have a corresponding value in <xref:Microsoft.AspNetCore.Components.ParameterView> are left unchanged.

If [`base.SetParametersAsync`](xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A) isn't invoked, developer code can interpret the incoming parameters' values in any way required. For example, there's no requirement to assign the incoming parameters to the properties of the class.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

In the following example, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A?displayProperty=nameWithType> assigns the `Param` parameter's value to `value` if parsing a route parameter for `Param` is successful. When `value` isn't `null`, the value is displayed by the component.

Although [route parameter matching is case insensitive](xref:blazor/fundamentals/routing#route-parameters), <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> only matches case sensitive parameter names in the route template. The following example requires the use of `/{Param?}` in the route template in order to get the value with <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A>, not `/{param?}`. If `/{param?}` is used in this scenario, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> returns `false` and `message` isn't set to either `message` string.

`Pages/SetParamsAsync.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/SetParamsAsync.razor)]

## Component initialization (`OnInitialized{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> are invoked when the component is initialized after having received its initial parameters in <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A>.

For a synchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

`Pages/OnInit.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/OnInit.razor?highlight=8)]

To perform an asynchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> and use the [`await`](/dotnet/csharp/language-reference/operators/await) operator:

```csharp
protected override async Task OnInitializedAsync()
{
    await ...
}
```

Blazor apps that prerender their content on the server call <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> *twice*:

* Once when the component is initially rendered statically as part of the page.
* A second time when the browser renders the component.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> from running twice when prerendering, see the [Stateful reconnection after prerendering](#stateful-reconnection-after-prerendering) section. Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

While a Blazor app is prerendering, certain actions, such as calling into JavaScript (JS interop), aren't possible. Components may need to render differently when prerendered. For more information, see the [Detect when the app is prerendering](#detect-when-the-app-is-prerendering) section.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## After parameters are set (`OnParametersSet{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> are called:

* After the component is initialized in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
* When the parent component rerenders and supplies:
  * Known primitive immutable types when at least one parameter has changed.
  * Complex-typed parameters. The framework can't know whether the values of a complex-typed parameter have mutated internally, so the framework always treats the parameter set as changed when one or more complex-typed parameters are present.

For the following example component, navigate to the component's page at a URL:

* With a start date that's received by `StartDate`: `/on-parameters-set/2021-03-19`
* Without a start date, where `StartDate` is assigned a value of the current local time: `/on-parameters-set`

`Pages/OnParamsSet.razor`:

> [!NOTE]
> In a component route, it isn't possible to both constrain a <xref:System.DateTime> parameter with the [route constraint `datetime`](xref:blazor/fundamentals/routing#route-constraints) and [make the parameter optional](xref:blazor/fundamentals/routing#route-parameters). Therefore, the following `OnParamsSet` component uses two [`@page`](xref:mvc/views/razor#page) directives to handle routing with and without a supplied date segment in the URL.

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/OnParamsSet.razor)]

Asynchronous work when applying parameters and property values must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> lifecycle event:

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

For more information on route parameters and constraints, see <xref:blazor/fundamentals/routing>.

## After component render (`OnAfterRender{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps with the rendered content, such as JS interop calls that interact with the rendered DOM elements.

The `firstRender` parameter for <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>:

* Is set to `true` the first time that the component instance is rendered.
* Can be used to ensure that initialization work is only performed once.

`Pages/AfterRender.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/AfterRender.razor)]

Asynchronous work immediately after rendering must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> lifecycle event:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await ...
    }
}
```

Even if you return a <xref:System.Threading.Tasks.Task> from <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>, the framework doesn't schedule a further render cycle for your component once that task completes. This is to avoid an infinite render loop. This is different from the other lifecycle methods, which schedule a further render cycle once a returned <xref:System.Threading.Tasks.Task> completes.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> *aren't called during the prerendering process on the server*. The methods are called when the component is rendered interactively after prerendering. When the app prerenders:

1. The component executes on the server to produce some static HTML markup in the HTTP response. During this phase, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> aren't called.
1. When the Blazor script (`blazor.webassembly.js` or `blazor.server.js`) start in the browser, the component is restarted in an interactive rendering mode. After a component is restarted, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> **are** called because the app isn't in the prerendering phase any longer.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## State changes (`StateHasChanged`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> notifies the component that its state has changed. When applicable, calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> causes the component to be rerendered.

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called automatically for <xref:Microsoft.AspNetCore.Components.EventCallback> methods. For more information on event callbacks, see <xref:blazor/components/event-handling#eventcallback>.

For more information on component rendering and when to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>, including when to invoke it with <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType>, see <xref:blazor/components/rendering>.

## Handle incomplete async actions at render

Asynchronous actions performed in lifecycle events might not have completed before the component is rendered. Objects might be `null` or incompletely populated with data while the lifecycle method is executing. Provide rendering logic to confirm that objects are initialized. Render placeholder UI elements (for example, a loading message) while objects are `null`.

In the `FetchData` component of the Blazor templates, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is overridden to asynchronously receive forecast data (`forecasts`). When `forecasts` is `null`, a loading message is displayed to the user. After the `Task` returned by <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> completes, the component is rerendered with the updated state.

`Pages/FetchData.razor` in the Blazor Server template:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_Server/Pages/lifecycle/FetchData.razor?highlight=9,21,25)]

## Handle errors

For information on handling errors during lifecycle method execution, see <xref:blazor/fundamentals/handle-errors>.

## Stateful reconnection after prerendering

In a Blazor Server app when <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode> is <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered>, the component is initially rendered statically as part of the page. Once the browser establishes a SignalR connection back to the server, the component is rendered *again* and interactive. If the [`OnInitialized{Async}`](#component-initialization-oninitializedasync) lifecycle method for initializing the component is present, the method is executed *twice*:

* When the component is prerendered statically.
* After the server connection has been established.

This can result in a noticeable change in the data displayed in the UI when the component is finally rendered. To avoid this double-rendering behavior in a Blazor Server app, pass in an identifier to cache the state during prerendering and to retrieve the state after prerendering.

The following code demonstrates an updated `WeatherForecastService` in a template-based Blazor Server app that avoids the double rendering. In the following example, the awaited <xref:System.Threading.Tasks.Task.Delay%2A> (`await Task.Delay(...)`) simulates a short delay before returning data from the `GetForecastAsync` method.

`WeatherForecastService.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_Server/lifecycle/WeatherForecastService.cs)]

For more information on the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode>, see <xref:blazor/fundamentals/signalr#render-mode-blazor-server>.

Although the content in this section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

## Detect when the app is prerendering

[!INCLUDE[](~/blazor/includes/prerendering.md)]

## Component disposal with `IDisposable` and `IAsyncDisposable`

If a component implements <xref:System.IDisposable>, <xref:System.IAsyncDisposable>, or both, the framework calls for unmanaged resource disposal when the component is removed from the UI. Disposal can occur at any time, including during [component initialization](#component-initialization-oninitializedasync).

Components shouldn't need to implement <xref:System.IDisposable> and <xref:System.IAsyncDisposable> simultaneously. If both are implemented, the framework only executes the asynchronous overload.

Developer code must ensure that <xref:System.IAsyncDisposable> implementations don't take a long time to complete.

### Synchronous `IDisposable`

For synchronous disposal tasks, use <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IDisposable

...

@code {
    ...

    public void Dispose()
    {
        obj?.Dispose();
    }
}
```

If a single object requires disposal, a lambda can be used to dispose of the object when <xref:System.IDisposable.Dispose%2A> is called. The following example appears in the <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system> article and demonstrates the use of a lambda expression for the disposal of a <xref:System.Timers.Timer>.

`Pages/CounterWithTimerDisposal1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor?highlight=3,11,28)]

> [!NOTE]
> In the preceding example, the call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is wrapped by a call to <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> because the callback is invoked outside of Blazor's synchronization context. For more information, see <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system>.

If the object is created in a lifecycle method, such as [`OnInitialized`/`OnInitializedAsync`](#component-initialization-oninitializedasync), check for `null` before calling `Dispose`.

`Pages/CounterWithTimerDisposal2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor?highlight=15,29)]

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Asynchronous `IAsyncDisposable`

For asynchronous disposal tasks, use <xref:System.IAsyncDisposable.DisposeAsync%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IAsyncDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IAsyncDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IAsyncDisposable

...

@code {
    ...

    public async ValueTask DisposeAsync()
    {
        if (obj is not null)
        {
            await obj.DisposeAsync();
        }
    }
}
```

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Assignment of `null` to disposed objects

Usually, there's no need to assign `null` to disposed objects after calling <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>. Rare cases for assigning `null` include the following:

* If the object's type is poorly implemented and doesn't tolerate repeat calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>, assign `null` after disposal to gracefully skip further calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>.
* If a long-lived process continues to hold a reference to a disposed object, assigning `null` allows the [garbage collector](/dotnet/standard/garbage-collection/fundamentals) to free the object in spite of the long-lived process holding a reference to it.

These are unusual scenarios. For objects that are implemented correctly and behave normally, there's no point in assigning `null` to disposed objects. In the rare cases where an object must be assigned `null`, we recommend documenting the reason and seeking a solution that prevents the need to assign `null`.

### `StateHasChanged`

> [!NOTE]
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in `Dispose` isn't supported. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

### Event handlers

Always unsubscribe event handlers from .NET events. The following [Blazor form](xref:blazor/forms-validation) examples show how to unsubscribe an event handler in the `Dispose` method:

* Private field and lambda approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      // ...
      private EventHandler<FieldChangedEventArgs> fieldChanged;

      protected override void OnInitialized()
      {
          editContext = new(model);

          fieldChanged = (_, __) =>
          {
              // ...
          };

          editContext.OnFieldChanged += fieldChanged;
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= fieldChanged;
      }
  }
  ```

* Private method approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      // ...

      protected override void OnInitialized()
      {
          editContext = new(model);
          editContext.OnFieldChanged += HandleFieldChanged;
      }

      private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
      {
          // ...
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= HandleFieldChanged;
      }
  }
  ```
  
For more information, see the [Component disposal with `IDisposable` and `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

### Anonymous functions, methods, and expressions

When [anonymous functions](/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions), methods, or expressions, are used, it isn't necessary to implement <xref:System.IDisposable> and unsubscribe delegates. However, failing to unsubscribe a delegate is a problem **when the object exposing the event outlives the lifetime of the component registering the delegate**. When this occurs, a memory leak results because the registered delegate keeps the original object alive. Therefore, only use the following approaches when you know that the event delegate disposes quickly. When in doubt about the lifetime of objects that require disposal, subscribe a delegate method and properly dispose the delegate as the earlier examples show.

* Anonymous lambda method approach (explicit disposal not required):

  ```csharp
  private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
  {
      formInvalid = !editContext.Validate();
      StateHasChanged();
  }

  protected override void OnInitialized()
  {
      editContext = new(starship);
      editContext.OnFieldChanged += (s, e) => HandleFieldChanged((editContext)s, e);
  }
  ```

* Anonymous lambda expression approach (explicit disposal not required):

  ```csharp
  private ValidationMessageStore messageStore;

  [CascadingParameter]
  private EditContext CurrentEditContext { get; set; }

  protected override void OnInitialized()
  {
      ...

      messageStore = new(CurrentEditContext);

      CurrentEditContext.OnValidationRequested += (s, e) => messageStore.Clear();
      CurrentEditContext.OnFieldChanged += (s, e) => 
          messageStore.Clear(e.FieldIdentifier);
  }
  ```

  The full example of the preceding code with anonymous lambda expressions appears in the <xref:blazor/forms-validation#validator-components> article.

For more information, see [Cleaning up unmanaged resources](/dotnet/standard/garbage-collection/unmanaged) and the topics that follow it on implementing the `Dispose` and `DisposeAsync` methods.

## Cancelable background work

Components often perform long-running background work, such as making network calls (<xref:System.Net.Http.HttpClient>) and interacting with databases. It's desirable to stop the background work to conserve system resources in several situations. For example, background asynchronous operations don't automatically stop when a user navigates away from a component.

Other reasons why background work items might require cancellation include:

* An executing background task was started with faulty input data or processing parameters.
* The current set of executing background work items must be replaced with a new set of work items.
* The priority of currently executing tasks must be changed.
* The app must be shut down for server redeployment.
* Server resources become limited, necessitating the rescheduling of background work items.

To implement a cancelable background work pattern in a component:

* Use a <xref:System.Threading.CancellationTokenSource> and <xref:System.Threading.CancellationToken>.
* On [disposal of the component](#component-disposal-with-idisposable-and-iasyncdisposable) and at any point cancellation is desired by manually canceling the token, call [`CancellationTokenSource.Cancel`](xref:System.Threading.CancellationTokenSource.Cancel%2A) to signal that the background work should be cancelled.
* After the asynchronous call returns, call <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> on the token.

In the following example:

* `await Task.Delay(5000, cts.Token);` represents long-running asynchronous background work.
* `BackgroundResourceMethod` represents a long-running background method that shouldn't start if the `Resource` is disposed before the method is called.

`Pages/BackgroundWork.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/lifecycle/BackgroundWork.razor)]

## Blazor Server reconnection events

The component lifecycle events covered in this article operate separately from [Blazor Server's reconnection event handlers](xref:blazor/fundamentals/signalr#reflect-the-connection-state-in-the-ui-blazor-server). When a Blazor Server app loses its SignalR connection to the client, only UI updates are interrupted. UI updates are resumed when the connection is re-established. For more information on circuit handler events and configuration, see <xref:blazor/fundamentals/signalr>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

The Razor component processes Razor component lifecycle events in a set of synchronous and asynchronous lifecycle methods. The lifecycle methods can be overridden to perform additional operations in components during component initialization and rendering.

## Lifecycle events

The following diagrams illustrate Razor component lifecycle events. The C# methods associated with the lifecycle events are defined with examples in the following sections of this article.

Component lifecycle events:

1. If the component is rendering for the first time on a request:
   * Create the component's instance.
   * Perform property injection. Run [`SetParametersAsync`](#when-parameters-are-set-setparametersasync).
   * Call [`OnInitialized{Async}`](#component-initialization-oninitializedasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Call [`OnParametersSet{Async}`](#after-parameters-are-set-onparameterssetasync). If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Component lifecycle events of a Razor component in Blazor](~/blazor/components/lifecycle/_static/lifecycle1.png)

Document Object Model (DOM) event processing:

1. The event handler is run.
1. If an incomplete <xref:System.Threading.Tasks.Task> is returned, the <xref:System.Threading.Tasks.Task> is awaited and then the component is rerendered.
1. Render for all synchronous work and complete <xref:System.Threading.Tasks.Task>s.

![Document Object Model (DOM) event processing](~/blazor/components/lifecycle/_static/lifecycle2.png)

The `Render` lifecycle:

1. Avoid further rendering operations on the component:
   * After the first render.
   * When [`ShouldRender`](xref:blazor/components/rendering#suppress-ui-refreshing-shouldrender) is `false`.
1. Build the render tree diff (difference) and render the component.
1. Await the DOM to update.
1. Call [`OnAfterRender{Async}`](#after-component-render-onafterrenderasync).

![Render lifecycle](~/blazor/components/lifecycle/_static/lifecycle3.png)

Developer calls to [`StateHasChanged`](#state-changes-statehaschanged) result in a render. For more information, see <xref:blazor/components/rendering>.

## When parameters are set (`SetParametersAsync`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets parameters supplied by the component's parent in the render tree or from route parameters.

The method's <xref:Microsoft.AspNetCore.Components.ParameterView> parameter contains the set of [component parameter](xref:blazor/components/index#component-parameters) values for the component each time <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> is called. By overriding the <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> method, developer code can interact directly with <xref:Microsoft.AspNetCore.Components.ParameterView>'s parameters.

The default implementation of <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A> sets the value of each property with the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) or [`[CascadingParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) that has a corresponding value in the <xref:Microsoft.AspNetCore.Components.ParameterView>. Parameters that don't have a corresponding value in <xref:Microsoft.AspNetCore.Components.ParameterView> are left unchanged.

If [`base.SetParametersAsync`](xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A) isn't invoked, developer code can interpret the incoming parameters' values in any way required. For example, there's no requirement to assign the incoming parameters to the properties of the class.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

In the following example, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A?displayProperty=nameWithType> assigns the `Param` parameter's value to `value` if parsing a route parameter for `Param` is successful. When `value` isn't `null`, the value is displayed by the component.

Although [route parameter matching is case insensitive](xref:blazor/fundamentals/routing#route-parameters), <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> only matches case sensitive parameter names in the route template. The following example requires the use of `/{Param?}` in the route template in order to get the value with <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A>, not `/{param?}`. If `/{param?}` is used in this scenario, <xref:Microsoft.AspNetCore.Components.ParameterView.TryGetValue%2A> returns `false` and `message` isn't set to either `message` string.

`Pages/SetParamsAsync.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/SetParamsAsync.razor)]

## Component initialization (`OnInitialized{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> are invoked when the component is initialized after having received its initial parameters in <xref:Microsoft.AspNetCore.Components.ComponentBase.SetParametersAsync%2A>.

For a synchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A>:

`Pages/OnInit.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/OnInit.razor?highlight=8)]

To perform an asynchronous operation, override <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> and use the [`await`](/dotnet/csharp/language-reference/operators/await) operator:

```csharp
protected override async Task OnInitializedAsync()
{
    await ...
}
```

Blazor apps that prerender their content on the server call <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> *twice*:

* Once when the component is initially rendered statically as part of the page.
* A second time when the browser renders the component.

To prevent developer code in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> from running twice when prerendering, see the [Stateful reconnection after prerendering](#stateful-reconnection-after-prerendering) section. Although the content in the section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

While a Blazor app is prerendering, certain actions, such as calling into JavaScript (JS interop), aren't possible. Components may need to render differently when prerendered. For more information, see the [Detect when the app is prerendering](#detect-when-the-app-is-prerendering) section.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## After parameters are set (`OnParametersSet{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSet%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> are called:

* After the component is initialized in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitialized%2A> or <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>.
* When the parent component rerenders and supplies:
  * Known primitive immutable types when at least one parameter has changed.
  * Complex-typed parameters. The framework can't know whether the values of a complex-typed parameter have mutated internally, so the framework always treats the parameter set as changed when one or more complex-typed parameters are present.

For the following example component, navigate to the component's page at a URL:

* With a start date that's received by `StartDate`: `/on-parameters-set/2021-03-19`
* Without a start date, where `StartDate` is assigned a value of the current local time: `/on-parameters-set`

`Pages/OnParamsSet.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/OnParamsSet.razor)]

Asynchronous work when applying parameters and property values must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A> lifecycle event:

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

For more information on route parameters and constraints, see <xref:blazor/fundamentals/routing>.

## After component render (`OnAfterRender{Async}`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps with the rendered content, such as JS interop calls that interact with the rendered DOM elements.

The `firstRender` parameter for <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>:

* Is set to `true` the first time that the component instance is rendered.
* Can be used to ensure that initialization work is only performed once.

`Pages/AfterRender.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/AfterRender.razor)]

Asynchronous work immediately after rendering must occur during the <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> lifecycle event:

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender)
    {
        await ...
    }
}
```

Even if you return a <xref:System.Threading.Tasks.Task> from <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A>, the framework doesn't schedule a further render cycle for your component once that task completes. This is to avoid an infinite render loop. This is different from the other lifecycle methods, which schedule a further render cycle once a returned <xref:System.Threading.Tasks.Task> completes.

<xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> *aren't called during the prerendering process on the server*. The methods are called when the component is rendered interactively after prerendering. When the app prerenders:

1. The component executes on the server to produce some static HTML markup in the HTTP response. During this phase, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> aren't called.
1. When the Blazor script (`blazor.webassembly.js` or `blazor.server.js`) start in the browser, the component is restarted in an interactive rendering mode. After a component is restarted, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRender%2A> and <xref:Microsoft.AspNetCore.Components.ComponentBase.OnAfterRenderAsync%2A> **are** called because the app isn't in the prerendering phase any longer.

If event handlers are provided in developer code, unhook them on disposal. For more information, see the [Component disposal with `IDisposable` `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

## State changes (`StateHasChanged`)

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> notifies the component that its state has changed. When applicable, calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> causes the component to be rerendered.

<xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called automatically for <xref:Microsoft.AspNetCore.Components.EventCallback> methods. For more information on event callbacks, see <xref:blazor/components/event-handling#eventcallback>.

For more information on component rendering and when to call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>, including when to invoke it with <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType>, see <xref:blazor/components/rendering>.

## Handle incomplete async actions at render

Asynchronous actions performed in lifecycle events might not have completed before the component is rendered. Objects might be `null` or incompletely populated with data while the lifecycle method is executing. Provide rendering logic to confirm that objects are initialized. Render placeholder UI elements (for example, a loading message) while objects are `null`.

In the `FetchData` component of the Blazor templates, <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is overridden to asynchronously receive forecast data (`forecasts`). When `forecasts` is `null`, a loading message is displayed to the user. After the `Task` returned by <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> completes, the component is rerendered with the updated state.

`Pages/FetchData.razor` in the Blazor Server template:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_Server/Pages/lifecycle/FetchData.razor?highlight=9,21,25)]

## Handle errors

For information on handling errors during lifecycle method execution, see <xref:blazor/fundamentals/handle-errors>.

## Stateful reconnection after prerendering

In a Blazor Server app when <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode> is <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered>, the component is initially rendered statically as part of the page. Once the browser establishes a SignalR connection back to the server, the component is rendered *again* and interactive. If the [`OnInitialized{Async}`](#component-initialization-oninitializedasync) lifecycle method for initializing the component is present, the method is executed *twice*:

* When the component is prerendered statically.
* After the server connection has been established.

This can result in a noticeable change in the data displayed in the UI when the component is finally rendered. To avoid this double-rendering behavior in a Blazor Server app, pass in an identifier to cache the state during prerendering and to retrieve the state after prerendering.

The following code demonstrates an updated `WeatherForecastService` in a template-based Blazor Server app that avoids the double rendering. In the following example, the awaited <xref:System.Threading.Tasks.Task.Delay%2A> (`await Task.Delay(...)`) simulates a short delay before returning data from the `GetForecastAsync` method.

`WeatherForecastService.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_Server/lifecycle/WeatherForecastService.cs)]

For more information on the <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper.RenderMode>, see <xref:blazor/fundamentals/signalr#render-mode-blazor-server>.

Although the content in this section focuses on Blazor Server and stateful SignalR *reconnection*, the scenario for prerendering in hosted Blazor WebAssembly apps (<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.WebAssemblyPrerendered>) involves similar conditions and approaches to prevent executing developer code twice. To preserve state during the execution of initialization code while prerendering, see <xref:blazor/components/prerendering-and-integration#persist-prerendered-state>.

## Detect when the app is prerendering

[!INCLUDE[](~/blazor/includes/prerendering.md)]

## Component disposal with `IDisposable` and `IAsyncDisposable`

If a component implements <xref:System.IDisposable>, <xref:System.IAsyncDisposable>, or both, the framework calls for unmanaged resource disposal when the component is removed from the UI. Disposal can occur at any time, including during [component initialization](#component-initialization-oninitializedasync).

Components shouldn't need to implement <xref:System.IDisposable> and <xref:System.IAsyncDisposable> simultaneously. If both are implemented, the framework only executes the asynchronous overload.

Developer code must ensure that <xref:System.IAsyncDisposable> implementations don't take a long time to complete.

### Synchronous `IDisposable`

For synchronous disposal tasks, use <xref:System.IDisposable.Dispose%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IDisposable

...

@code {
    ...

    public void Dispose()
    {
        obj?.Dispose();
    }
}
```

If a single object requires disposal, a lambda can be used to dispose of the object when <xref:System.IDisposable.Dispose%2A> is called. The following example appears in the <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system> article and demonstrates the use of a lambda expression for the disposal of a <xref:System.Timers.Timer>.

`Pages/CounterWithTimerDisposal1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal1.razor?highlight=3,11,28)]

> [!NOTE]
> In the preceding example, the call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is wrapped by a call to <xref:Microsoft.AspNetCore.Components.ComponentBase.InvokeAsync%2A?displayProperty=nameWithType> because the callback is invoked outside of Blazor's synchronization context. For more information, see <xref:blazor/components/rendering#receiving-a-call-from-something-external-to-the-blazor-rendering-and-event-handling-system>.

If the object is created in a lifecycle method, such as [`OnInitialized`/`OnInitializedAsync`](#component-initialization-oninitializedasync), check for `null` before calling `Dispose`.

`Pages/CounterWithTimerDisposal2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/CounterWithTimerDisposal2.razor?highlight=15,29)]

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Asynchronous `IAsyncDisposable`

For asynchronous disposal tasks, use <xref:System.IAsyncDisposable.DisposeAsync%2A?displayProperty=nameWithType>.

The following component:

* Implements <xref:System.IAsyncDisposable> with the [`@implements`](xref:mvc/views/razor#implements) Razor directive.
* Disposes of `obj`, which is an unmanaged type that implements <xref:System.IAsyncDisposable>.
* A null check is performed because `obj` is created in a lifecycle method (not shown).

```razor
@implements IAsyncDisposable

...

@code {
    ...

    public async ValueTask DisposeAsync()
    {
        if (obj is not null)
        {
            await obj.DisposeAsync();
        }
    }
}
```

For more information, see:

* [Cleaning up unmanaged resources (.NET documentation)](/dotnet/standard/garbage-collection/unmanaged)
* [Null-conditional operators ?. and ?[]](/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-)

### Assignment of `null` to disposed objects

Usually, there's no need to assign `null` to disposed objects after calling <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>. Rare cases for assigning `null` include the following:

* If the object's type is poorly implemented and doesn't tolerate repeat calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>, assign `null` after disposal to gracefully skip further calls to <xref:System.IDisposable.Dispose%2A>/<xref:System.IAsyncDisposable.DisposeAsync%2A>.
* If a long-lived process continues to hold a reference to a disposed object, assigning `null` allows the [garbage collector](/dotnet/standard/garbage-collection/fundamentals) to free the object in spite of the long-lived process holding a reference to it.

These are unusual scenarios. For objects that are implemented correctly and behave normally, there's no point in assigning `null` to disposed objects. In the rare cases where an object must be assigned `null`, we recommend documenting the reason and seeking a solution that prevents the need to assign `null`.

### `StateHasChanged`

> [!NOTE]
> Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in `Dispose` isn't supported. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> might be invoked as part of tearing down the renderer, so requesting UI updates at that point isn't supported.

### Event handlers

Always unsubscribe event handlers from .NET events. The following [Blazor form](xref:blazor/forms-validation) examples show how to unsubscribe an event handler in the `Dispose` method:

* Private field and lambda approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      // ...
      private EventHandler<FieldChangedEventArgs> fieldChanged;

      protected override void OnInitialized()
      {
          editContext = new EditContext(model);

          fieldChanged = (_, __) =>
          {
              // ...
          };

          editContext.OnFieldChanged += fieldChanged;
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= fieldChanged;
      }
  }
  ```

* Private method approach

  ```razor
  @implements IDisposable

  <EditForm EditContext="@editContext">
      ...
      <button type="submit" disabled="@formInvalid">Submit</button>
  </EditForm>

  @code {
      // ...

      protected override void OnInitialized()
      {
          editContext = new EditContext(model);
          editContext.OnFieldChanged += HandleFieldChanged;
      }

      private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
      {
          // ...
      }

      public void Dispose()
      {
          editContext.OnFieldChanged -= HandleFieldChanged;
      }
  }
  ```
  
For more information, see the [Component disposal with `IDisposable` and `IAsyncDisposable`](#component-disposal-with-idisposable-and-iasyncdisposable) section.

### Anonymous functions, methods, and expressions

When [anonymous functions](/dotnet/csharp/programming-guide/statements-expressions-operators/anonymous-functions), methods, or expressions, are used, it isn't necessary to implement <xref:System.IDisposable> and unsubscribe delegates. However, failing to unsubscribe a delegate is a problem **when the object exposing the event outlives the lifetime of the component registering the delegate**. When this occurs, a memory leak results because the registered delegate keeps the original object alive. Therefore, only use the following approaches when you know that the event delegate disposes quickly. When in doubt about the lifetime of objects that require disposal, subscribe a delegate method and properly dispose the delegate as the earlier examples show.

* Anonymous lambda method approach (explicit disposal not required):

  ```csharp
  private void HandleFieldChanged(object sender, FieldChangedEventArgs e)
  {
      formInvalid = !editContext.Validate();
      StateHasChanged();
  }

  protected override void OnInitialized()
  {
      editContext = new EditContext(starship);
      editContext.OnFieldChanged += (s, e) => HandleFieldChanged((editContext)s, e);
  }
  ```

* Anonymous lambda expression approach (explicit disposal not required):

  ```csharp
  private ValidationMessageStore messageStore;

  [CascadingParameter]
  private EditContext CurrentEditContext { get; set; }

  protected override void OnInitialized()
  {
      ...

      messageStore = new ValidationMessageStore(CurrentEditContext);

      CurrentEditContext.OnValidationRequested += (s, e) => messageStore.Clear();
      CurrentEditContext.OnFieldChanged += (s, e) => 
          messageStore.Clear(e.FieldIdentifier);
  }
  ```

  The full example of the preceding code with anonymous lambda expressions appears in the <xref:blazor/forms-validation#validator-components> article.

For more information, see [Cleaning up unmanaged resources](/dotnet/standard/garbage-collection/unmanaged) and the topics that follow it on implementing the `Dispose` and `DisposeAsync` methods.

## Cancelable background work

Components often perform long-running background work, such as making network calls (<xref:System.Net.Http.HttpClient>) and interacting with databases. It's desirable to stop the background work to conserve system resources in several situations. For example, background asynchronous operations don't automatically stop when a user navigates away from a component.

Other reasons why background work items might require cancellation include:

* An executing background task was started with faulty input data or processing parameters.
* The current set of executing background work items must be replaced with a new set of work items.
* The priority of currently executing tasks must be changed.
* The app must be shut down for server redeployment.
* Server resources become limited, necessitating the rescheduling of background work items.

To implement a cancelable background work pattern in a component:

* Use a <xref:System.Threading.CancellationTokenSource> and <xref:System.Threading.CancellationToken>.
* On [disposal of the component](#component-disposal-with-idisposable-and-iasyncdisposable) and at any point cancellation is desired by manually canceling the token, call [`CancellationTokenSource.Cancel`](xref:System.Threading.CancellationTokenSource.Cancel%2A) to signal that the background work should be cancelled.
* After the asynchronous call returns, call <xref:System.Threading.CancellationToken.ThrowIfCancellationRequested%2A> on the token.

In the following example:

* `await Task.Delay(5000, cts.Token);` represents long-running asynchronous background work.
* `BackgroundResourceMethod` represents a long-running background method that shouldn't start if the `Resource` is disposed before the method is called.

`Pages/BackgroundWork.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/lifecycle/BackgroundWork.razor)]

## Blazor Server reconnection events

The component lifecycle events covered in this article operate separately from [Blazor Server's reconnection event handlers](xref:blazor/fundamentals/signalr#reflect-the-connection-state-in-the-ui-blazor-server). When a Blazor Server app loses its SignalR connection to the client, only UI updates are interrupted. UI updates are resumed when the connection is re-established. For more information on circuit handler events and configuration, see <xref:blazor/fundamentals/signalr>.

:::moniker-end
