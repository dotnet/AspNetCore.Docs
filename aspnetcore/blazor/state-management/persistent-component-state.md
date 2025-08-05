---
title: ASP.NET Core Blazor persistent component state
author: guardrex
description: Learn how to persist user data (state) in Blazor apps using Blazor's Persistent Component State service.
monikerRange: '>= aspnetcore-8.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/04/2025
uid: blazor/state-management/persistent-component-state
---
# ASP.NET Core Blazor prerendered state persistence

Without persisting component state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is created asynchronously, the UI may flicker as the prerendered UI is replaced when the component is rerendered.

Consider the following `PrerenderedCounter1` counter component. The component sets an initial random counter value during prerendering in [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). When the component then renders interactively, the initial count value is replaced when `OnInitialized` executes a second time.

`PrerenderedCounter1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PrerenderedCounter1.razor":::

Run the app and inspect logging from the component. The following is example output.

> [!NOTE]
> If the app adopts [interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) and the page is reached via an internal [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling), prerendering doesn't occur. Therefore, you must perform a full page reload for the `PrerenderedCounter1` component to see the following output. For more information, see the [Interactive routing and prerendering](#interactive-routing-and-prerendering) section.

> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter1[0]":::  
> :::no-loc text="      currentCount set to 41":::  
> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter1[0]":::  
> :::no-loc text="      currentCount set to 92":::

The first logged count occurs during prerendering. The count is set again after prerendering when the component is rerendered. There's also a flicker in the UI when the count updates from 41 to 92.

To retain the initial value of the counter during prerendering, Blazor supports persisting state in a prerendered page using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service (and for components embedded into pages or views of Razor Pages or MVC apps, the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper)).

:::moniker range=">= aspnetcore-10.0"

<!-- UPDATE 10.0 - API cross-links -->

To preserve prerendered state, use the `[SupplyParameterFromPersistentComponentState]` attribute to persist state in properties. Properties with this attribute are automatically persisted using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service during prerendering. The state is retrieved when the component renders interactively or the service is instantiated.

By default, properties are serialized using the <xref:System.Text.Json?displayProperty=fullName> serializer with default settings. Serialization isn't trimmer safe and requires preservation of the types used. For more information, see <xref:blazor/host-and-deploy/configure-trimmer>.

The following counter component persists counter state during prerendering and retrieves the state to initialize the component:

* The `[SupplyParameterFromPersistentComponentState]` attribute is applied to the `CounterState` type (`State`).
* The counter's state is assigned when `null` in `OnInitialized` and restored automatically when the component renders interactively.

`PrerenderedCounter2.razor`:

```razor
@page "/prerendered-counter-2"
@inject ILogger<PrerenderedCounter2> Logger

<PageTitle>Prerendered Counter 2</PageTitle>

<h1>Prerendered Counter 2</h1>

<p role="status">Current count: @State?.CurrentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    [SupplyParameterFromPersistentComponentState]
    public CounterState? State { get; set; }

    protected override void OnInitialized()
    {
        if (State is null)
        {
            State = new() { CurrentCount = Random.Shared.Next(100) };
            Logger.LogInformation("CurrentCount set to {Count}", 
                State.CurrentCount);
        }
        else
        {
            Logger.LogInformation("CurrentCount restored to {Count}", 
                State.CurrentCount);
        }
    }

    private void IncrementCount()
    {
        if (State is not null)
        {
            State.CurrentCount++;
        }
    }

    public class CounterState
    {
        public int CurrentCount { get; set; }
    }
}
```

<!-- UPDATE 10.0 - HOLD https://github.com/dotnet/aspnetcore/issues/61456 
     was resolved for Preview 7

```razor
@page "/prerendered-counter-2"
@inject ILogger<PrerenderedCounter2> Logger

<PageTitle>Prerendered Counter 2</PageTitle>

<h1>Prerendered Counter 2</h1>

<p role="status">Current count: @CurrentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    [SupplyParameterFromPersistentComponentState]
    public int? CurrentCount { get; set; }

    protected override void OnInitialized()
    {
        if (CurrentCount is null)
        {
            CurrentCount = Random.Shared.Next(100);
            Logger.LogInformation("CurrentCount set to {Count}", CurrentCount);
        }
        else
        {
            Logger.LogInformation("CurrentCount restored to {Count}", CurrentCount);
        }
    }

    private void IncrementCount() => CurrentCount++;
}
```
-->

When the component executes, `CurrentCount` is only set once during prerendering. The value is restored when the component is rerendered. The following is example output.

> [!NOTE]
> If the app adopts [interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) and the page is reached via an internal [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling), prerendering doesn't occur. Therefore, you must perform a full page reload for the component to see the following output. For more information, see the [Interactive routing and prerendering](#interactive-routing-and-prerendering) section.

> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter2[0]":::  
> :::no-loc text="      CurrentCount set to 96":::  
> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter2[0]":::  
> :::no-loc text="      CurrentCount restored to 96":::

In the following example that serializes state for multiple components of the same type:

* Properties annotated with the `[SupplyParameterFromPersistentComponentState]` attribute are serialized during prerendering.
* The [`@key` directive attribute](xref:blazor/components/key#use-of-the-key-directive-attribute) is used to ensure that the state is correctly associated with the component instance.
* The `Element` property is initialized in the [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync) to avoid null reference exceptions, similarly to how null references are avoided for query parameters and form data.

`PersistentChild.razor`:

```razor
<div>
    <p>Current count: @Element.CurrentCount</p>
    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</div>

@code {
    [SupplyParameterFromPersistentComponentState]
    public State Element { get; set; }

    protected override void OnInitialized()
    {
        Element ??= new State();
    }

    private void IncrementCount()
    {
        Element.CurrentCount++;
    }

    private class State
    {
        public int CurrentCount { get; set; }
    }
}
```

`Parent.razor`:

```razor
@page "/parent"

@foreach (var element in elements)
{
    <PersistentChild @key="element.Name" />
}
```

In the following example that serializes state for a dependency injection service:

* Properties annotated with the `[SupplyParameterFromPersistentComponentState]` attribute are serialized during prerendering and deserialized when the app becomes interactive.
* The <xref:Microsoft.Extensions.DependencyInjection.RazorComponentsRazorComponentBuilderExtensions.RegisterPersistentService%2A> extension method is used to register the service for persistence. The render mode is required because the render mode can't be inferred from the service type. Use any of the following values:
  * `RenderMode.Server`: The service is available for the Interactive Server render mode.
  * `RenderMode.Webassembly`: The service is available for the Interactive Webassembly render mode.
  * `RenderMode.InteractiveAuto`: The service is available for both the Interactive Server and Interactive Webassembly render modes if a component renders in either of those modes.
* The service is resolved during the initialization of an interactive render mode, and the properties annotated with the `[SupplyParameterFromPersistentComponentState]` attribute are deserialized.

> [!NOTE]
> Only persisting scoped services is supported.

<!-- UPDATE 10.0 - Flesh out with a fully-working example. -->

`CounterService.cs`:

```csharp
public class CounterService
{
    [SupplyParameterFromPersistentComponentState]
    public int CurrentCount { get; set; }

    public void IncrementCount()
    {
        CurrentCount++;
    }
}
```

In `Program.cs`:

```csharp
builder.Services.RegisterPersistentService<CounterService>(
    RenderMode.InteractiveAuto);
```

Serialized properties are identified from the actual service instance:

* This approach allows marking an abstraction as a persistent service.
* Enables actual implementations to be internal or different types.
* Supports shared code in different assemblies.
* Results in each instance exposing the same properties.

As an alternative to using the declarative model for persisting state with the `[SupplyParameterFromPersistentComponentState]` attribute, you can use the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service directly, which offers greater flexibility for complex state persistence scenarios. Call <xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A?displayProperty=nameWithType> to register a callback to persist the component state during prerendering. The state is retrieved when the component renders interactively. Make the call at the end of initialization code in order to avoid a potential race condition during app shutdown.

The following counter component example persists counter state during prerendering and retrieves the state to initialize the component.

`PrerenderedCounter3.razor`:

```razor
@page "/prerendered-counter-3"
@implements IDisposable
@inject ILogger<PrerenderedCounter3> Logger
@inject PersistentComponentState ApplicationState

<PageTitle>Prerendered Counter 3</PageTitle>

<h1>Prerendered Counter 3</h1>

<p role="status">Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount;
    private PersistingComponentStateSubscription persistingSubscription;

    protected override void OnInitialized()
    {
        if (!ApplicationState.TryTakeFromJson<int>(
            nameof(currentCount), out var restoredCount))
        {
            currentCount = Random.Shared.Next(100);
            Logger.LogInformation("currentCount set to {Count}", currentCount);
        }
        else
        {
            currentCount = restoredCount!;
            Logger.LogInformation("currentCount restored to {Count}", currentCount);
        }

        // Call at the end to avoid a potential race condition at app shutdown
        persistingSubscription = ApplicationState.RegisterOnPersisting(PersistCount);
    }

    private Task PersistCount()
    {
        ApplicationState.PersistAsJson(nameof(currentCount), currentCount);

        return Task.CompletedTask;
    }

    private void IncrementCount() => currentCount++;

    void IDisposable.Dispose() => persistingSubscription.Dispose();
}
```

When the component executes, `currentCount` is only set once during prerendering. The value is restored when the component is rerendered. The following is example output.

> [!NOTE]
> If the app adopts [interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) and the page is reached via an internal [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling), prerendering doesn't occur. Therefore, you must perform a full page reload for the component to see the following output. For more information, see the [Interactive routing and prerendering](#interactive-routing-and-prerendering) section.

> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter3[0]":::  
> :::no-loc text="      currentCount set to 96":::  
> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter3[0]":::  
> :::no-loc text="      currentCount restored to 96":::

:::moniker-end

:::moniker range="< aspnetcore-10.0"

To preserve prerendered state, decide what state to persist using the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service. <xref:Microsoft.AspNetCore.Components.PersistentComponentState.RegisterOnPersisting%2A?displayProperty=nameWithType> registers a callback to persist the component state during prerendering. The state is retrieved when the component renders interactively. Make the call at the end of initialization code in order to avoid a potential race condition during app shutdown.

The following counter component example persists counter state during prerendering and retrieves the state to initialize the component.

`PrerenderedCounter2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PrerenderedCounter2.razor":::

When the component executes, `currentCount` is only set once during prerendering. The value is restored when the component is rerendered. The following is example output.

> [!NOTE]
> If the app adopts [interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing) and the page is reached via an internal [enhanced navigation](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling), prerendering doesn't occur. Therefore, you must perform a full page reload for the component to see the following output. For more information, see the [Interactive routing and prerendering](#interactive-routing-and-prerendering) section.

> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter2[0]":::  
> :::no-loc text="      currentCount set to 96":::  
> :::no-loc text="info: BlazorSample.Components.Pages.PrerenderedCounter2[0]":::  
> :::no-loc text="      currentCount restored to 96":::

:::moniker-end

By initializing components with the same state used during prerendering, any expensive initialization steps are only executed once. The rendered UI also matches the prerendered UI, so no flicker occurs in the browser.

The persisted prerendered state is transferred to the client, where it's used to restore the component state. During client-side rendering (CSR, `InteractiveWebAssembly`), the data is exposed to the browser and must not contain sensitive, private information. During interactive server-side rendering (interactive SSR, `InteractiveServer`), [ASP.NET Core Data Protection](xref:security/data-protection/introduction) ensures that the data is transferred securely. The `InteractiveAuto` render mode combines WebAssembly and Server interactivity, so it's necessary to consider data exposure to the browser, as in the CSR case.

## Components embedded into pages and views (Razor Pages/MVC)

For components embedded into a page or view of a Razor Pages or MVC app, you must add the [Persist Component State Tag Helper](xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper) with the `<persist-component-state />` HTML tag inside the closing `</body>` tag of the app's layout. **This is only required for Razor Pages and MVC apps.** For more information, see <xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper>.

`Pages/Shared/_Layout.cshtml`:

```cshtml
<body>
    ...

    <persist-component-state />
</body>
```

## Interactive routing and prerendering

When the `Routes` component doesn't define a render mode, the app is using per-page/component interactivity and navigation. Using per-page/component navigation, internal navigation is handled by [enhanced routing](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) after the app becomes interactive. "Internal navigation" in this context means that the URL destination of the navigation event is a Blazor endpoint inside the app.

<!-- UPDATE 10.0 - Persistent component state across enhanced nav
                   is arriving for Preview 7. The remarks in this
                   section will be updated/versioned on the upcoming 
                   docs Preview 7 PR. I'll go ahead and remove the 
                   PU issue cross-link on PR #35873. -->

The <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service only works on the initial page load and not across internal enhanced page navigation events.

If the app performs a full (non-enhanced) navigation to a page utilizing persistent component state, the persisted state is made available for the app to use when it becomes interactive.

If an interactive circuit has already been established and an enhanced navigation is performed to a page utilizing persistent component state, the state *isn't made available in the existing circuit for the component to use*. There's no prerendering for the internal page request, and the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service isn't aware that an enhanced navigation has occurred. There's no mechanism to deliver state updates to components that are already running on an existing circuit. The reason for this is that Blazor only supports passing state from the server to the client at the time the runtime initializes, not after the runtime has started.

Disabling enhanced navigation, which reduces performance but also avoids the problem of loading state with <xref:Microsoft.AspNetCore.Components.PersistentComponentState> for internal page requests, is covered in <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.
