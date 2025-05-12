---
title: Prerender ASP.NET Core Razor components
author: guardrex
description: Learn about Razor component prerendering in ASP.NET Core Blazor apps.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/components/prerender
---
# Prerender ASP.NET Core Razor components

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

<!--
    NOTE: The console output block quotes in this topic use a double-space 
    at the ends of lines to generate a bare return in block quote output.
-->

This article explains Razor component prerendering scenarios for server-rendered components in Blazor Web Apps.

*Prerendering* is the process of initially rendering page content on the server without enabling event handlers for rendered controls. The server outputs the HTML UI of the page as soon as possible in response to the initial request, which makes the app feel more responsive to users. Prerendering can also improve [Search Engine Optimization (SEO)](https://developer.mozilla.org/docs/Glossary/SEO) by rendering content for the initial HTTP response that search engines use to calculate page rank.

## Persist prerendered state

Without persisting prerendered state, state used during prerendering is lost and must be recreated when the app is fully loaded. If any state is created asynchronously, the UI may flicker as the prerendered UI is replaced when the component is rerendered.

Consider the following `PrerenderedCounter1` counter component. The component sets an initial random counter value during prerendering in [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). After the SignalR connection to the client is established, the component rerenders, and the initial count value is replaced when `OnInitialized` executes a second time.

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

<!-- UPDATE 10.0 - HOLD until https://github.com/dotnet/aspnetcore/issues/61456 
     is resolved

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

* Properties annotated with the `[SupplyParameterFromPersistentComponentState]` attribute are serialized and deserialized during prerendering.
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
* The `AddPersistentService` method is used to register the service for persistence. The render mode is required because the render mode can't be inferred from the service type. Use any of the following values:
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
builder.Services.AddPersistentService<CounterService>(RenderMode.InteractiveAuto);
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

When the `Routes` component doesn't define a render mode, the app is using per-page/component interactivity and navigation. Using per-page/component navigation, internal&dagger; navigation is handled by [enhanced routing](xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling) after the app becomes interactive. &dagger;*Internal* in this context means that the URL destination of the navigation event is a Blazor endpoint inside the app.

The <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service only works on the initial page load and not across internal enhanced page navigation events.

If the app performs a full (non-enhanced) navigation to a page utilizing persistent component state, the persisted state is made available for the app to use when it becomes interactive.

If an interactive circuit has already been established and an enhanced navigation is performed to a page utilizing persistent component state, the state *isn't made available in the existing circuit for the component to use*. There's no prerendering for the internal page request, and the <xref:Microsoft.AspNetCore.Components.PersistentComponentState> service isn't aware that an enhanced navigation has occurred. There's no mechanism to deliver state updates to components that are already running on an existing circuit. The reason for this is that Blazor only supports passing state from the server to the client at the time the runtime initializes, not after the runtime has started.

Additional work on the Blazor framework to address this scenario is under consideration for .NET 10 (November, 2025). For more information and community discussion of *unsupported workarounds*&Dagger;, see [Support persistent component state across enhanced page navigations (`dotnet/aspnetcore` #51584)](https://github.com/dotnet/aspnetcore/issues/51584). &Dagger;Unsupported workarounds aren't sanctioned by Microsoft for use in Blazor apps. *Use third-party packages, approaches, and code at your own risk.*

Disabling enhanced navigation, which reduces performance but also avoids the problem of loading state with <xref:Microsoft.AspNetCore.Components.PersistentComponentState> for internal page requests, is covered in <xref:blazor/fundamentals/routing#enhanced-navigation-and-form-handling>.

<!-- UPDATE 10.0 The PU is probably going to address this
                 via the issue mentioned above. If so, 
                 the PU issue link above and the NOTEs for
                 the article examples will be versioned out 
                 for 10.0. -->

## Prerendering guidance

Prerendering guidance is organized in the Blazor documentation by subject matter. The following links cover all of the prerendering guidance throughout the documentation set by subject:

* Fundamentals
  * [Overview: Client and server rendering concepts](xref:blazor/fundamentals/index#client-and-server-rendering-concepts)
  * Routing
    * [Static versus interactive routing](xref:blazor/fundamentals/routing#static-versus-interactive-routing)
    * [Route to components from multiple assemblies: Interactive routing](xref:blazor/fundamentals/routing#interactive-routing)
    * <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> is executed *twice* when prerendering: [Handle asynchronous navigation events with `OnNavigateAsync`](xref:blazor/fundamentals/routing#handle-asynchronous-navigation-events-with-onnavigateasync)
  * Startup
    * [Control headers in C# code](xref:blazor/fundamentals/startup#control-headers-in-c-code)
    * [Client-side loading indicators](xref:blazor/fundamentals/startup#client-side-loading-indicators)
  * [Environments: Read the environment client-side in a Blazor Web App](xref:blazor/fundamentals/environments#read-the-environment-client-side-in-a-blazor-web-app)
  * [Handle Errors: Prerendering](xref:blazor/fundamentals/handle-errors#prerendering)
  * SignalR
    * [Client-side rendering](xref:blazor/fundamentals/signalr#client-side-rendering)
    * [Prerendered state size and SignalR message size limit](xref:blazor/fundamentals/signalr#prerendered-state-size-and-signalr-message-size-limit)

* Components
  * [Control `<head>` content during prerendering](xref:blazor/components/control-head-content#control-head-content-during-prerendering)
  * Render modes
    * [Prerendering](xref:blazor/components/render-modes#prerendering)
    * [Detect rendering location, interactivity, and assigned render mode at runtime](xref:blazor/components/render-modes#detect-rendering-location-interactivity-and-assigned-render-mode-at-runtime)
    * [Client-side services fail to resolve during prerendering](xref:blazor/components/render-modes#client-side-services-fail-to-resolve-during-prerendering)
    * [Custom shorthand render modes](xref:blazor/components/render-modes#custom-shorthand-render-modes)
  * Razor component lifecycle subjects that pertain to prerendering
    * [Component initialization (`OnInitialized{Async}`)](xref:blazor/components/lifecycle#component-initialization-oninitializedasync)
    * [After component render (`OnAfterRender{Async}`)](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync)
    * [Stateful reconnection after prerendering](xref:blazor/components/lifecycle#stateful-reconnection-after-prerendering)
    * [Prerendering with JavaScript interop](xref:blazor/components/lifecycle#prerendering-with-javascript-interop): This section also appears in the two JS interop articles on calling JavaScript from .NET and calling .NET from JavaScript.
    * [Handle incomplete asynchronous actions at render](xref:blazor/components/lifecycle#handle-incomplete-asynchronous-actions-at-render): Guidance for delayed rendering due to long-running lifecycle tasks during prerendering on the server.
  * [`QuickGrid` component sample app](xref:blazor/components/quickgrid#sample-app): The [**QuickGrid for Blazor** sample app](https://aspnet.github.io/quickgridsamples/) is hosted on GitHub Pages. The site loads fast thanks to static prerendering using the community-maintained [`BlazorWasmPrerendering.Build` GitHub project](https://github.com/jsakamoto/BlazorWasmPreRendering.Build).
  * [Prerendering when integrating components into Razor Pages and MVC apps](xref:blazor/components/integration)

* [Call a web API: Prerendered data](xref:blazor/call-web-api#prerendered-data)

* [File uploads: Upload files to a server with client-side rendering (CSR)](xref:blazor/file-uploads#upload-files-to-a-server-with-client-side-rendering-csr)

* [Globalization and localization: Location override using "Sensors" pane in developer tools](xref:blazor/globalization-localization#location-override-using-sensors-pane-in-developer-tools)

* Authentication and authorization
  * [Server-side threat mitigation: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)
  * Blazor server-side security overview
    * [Manage authentication state in Blazor Web Apps](xref:blazor/security/index#manage-authentication-state-in-blazor-web-apps)
    * [Unauthorized content display while prerendering with a custom `AuthenticationStateProvider`](xref:blazor/security/index#unauthorized-content-display-while-prerendering-with-a-custom-authenticationstateprovider)
  * [Blazor server-side additional scenarios: Reading tokens from `HttpContext`](xref:blazor/security/additional-scenarios#reading-tokens-from-httpcontext)
  * [Blazor WebAssembly overview: Prerendering support](xref:blazor/security/webassembly/index#prerendering-support)
  * Blazor WebAssembly additional scenarios
    * [Rendered component authentication with prerendering](xref:blazor/security/webassembly/additional-scenarios#prerendering-with-authentication)
    * [Secure a SignalR hub](xref:blazor/security/webassembly/additional-scenarios#secure-a-signalr-hub)
  * [Interactive server-side rendering: Cross-site scripting (XSS)](xref:blazor/security/interactive-server-side-rendering#cross-site-scripting-xss)

* [State management: Handle prerendering](xref:blazor/state-management#handle-prerendering): Besides the *Handle prerendering* section, several of the article's other sections include remarks on prerendering.

For .NET 7 or earlier, see [Blazor WebAssembly security additional scenarios: Prerendering with authentication](xref:blazor/security/webassembly/additional-scenarios?view=aspnetcore-7.0&preserve-view=true#prerendering-with-authentication). After viewing the content in this section, reset the documentation article version selector dropdown to the latest .NET release version to ensure that documentation pages load for the latest release on subsequent visits.
