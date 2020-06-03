---
title: ASP.NET Core Blazor state management
author: guardrex
description: Learn how to persist state in Blazor Server apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/19/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/state-management
---
# ASP.NET Core Blazor state management

By [Steve Sanderson](https://github.com/SteveSandersonMS)

Blazor Server is a stateful app framework. Most of the time, the app maintains an ongoing connection to the server. The user's state is held in the server's memory in a *circuit*. 

Examples of state held for a user's circuit include:

* The rendered UI: The hierarchy of component instances and their most recent render output.
* The values of any fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit.

> [!NOTE]
> This article addresses state persistence in Blazor Server apps. Blazor WebAssembly apps can take advantage of [client-side state persistence in the browser](#client-side-in-the-browser) but require custom solutions or 3rd party packages beyond the scope of this article.

## Blazor circuits

If a user experiences a temporary network connection loss, Blazor attempts to reconnect the user to their original circuit so they can continue to use the app. However, reconnecting a user to their original circuit in the server's memory isn't always possible:

* The server can't retain a disconnected circuit forever. The server must release a disconnected circuit after a timeout or when the server is under memory pressure.
* In multiserver, load-balanced deployment environments, any server processing requests may become unavailable at any given time. Individual servers may fail or be automatically removed when no longer required to handle the overall volume of requests. The original server may not be available when the user attempts to reconnect.
* The user might close and re-open their browser or reload the page, which removes any state held in the browser's memory. For example, values set through JavaScript interop calls are lost.

When a user can't be reconnected to their original circuit, the user receives a new circuit with an empty state. This is equivalent to closing and re-opening a desktop app.

## Preserve state across circuits

In some scenarios, preserving state across circuits is desirable. An app can retain important data for a user if:

* The web server becomes unavailable.
* The user's browser is forced to start a new circuit with a new web server.

In general, maintaining state across circuits applies to scenarios where users are actively creating data, not simply reading data that already exists.

To preserve state beyond a single circuit, *don't merely store the data in the server's memory*. The app must persist the data to some other storage location. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users have expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multistep webform: It's time-consuming for a user to re-enter data for several completed steps of a multistep process if their state is lost. A user loses state in this scenario if they navigate away from the multistep form and return to the form later.
* Shopping cart: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

It's usually not necessary to preserve easily-recreated state, such as the username entered into a sign-in dialog that hasn't been submitted.

> [!IMPORTANT]
> An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist something similar to UI state, such as the expanded nodes of a TreeView, the app must have custom code to model the behavior as serializable app state.

## Where to persist state

Three common locations exist for persisting state in a Blazor Server app. Each approach is best suited to different scenarios and has different caveats:

* [Server-side in a database](#server-side-in-a-database)
* [URL](#url)
* [Client-side in the browser](#client-side-in-the-browser)

### Server-side in a database

For permanent data persistence or for any data that must span multiple users or devices, an independent server-side database is almost certainly the best choice. Options include:

* Relational SQL database
* Key-value store
* Blob store
* Table store

After data is saved in the database, a new circuit can be started by a user at any time. The user's data is retained and available in any new circuit.

For more information on Azure data storage options, see the [Azure Storage Documentation](/azure/storage/) and [Azure Databases](https://azure.microsoft.com/product-categories/databases/).

### URL

For transient data representing navigation state, model the data as a part of the URL. Examples of state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained:

* If the user manually reloads the page.
* If the web server becomes unavailable, and the user is forced to reload the page in order to connect to a different server.

For information on defining URL patterns with the `@page` directive, see <xref:blazor/routing>.

### Client-side in the browser

For transient data that the user is actively creating, a common backing store is the browser's `localStorage` and `sessionStorage` collections. The app isn't required to manage or clear the stored state if the circuit is abandoned, which is an advantage over server-side storage.

> [!NOTE]
> "Client-side" in this section refers to client-side scenarios in the browser, not the [Blazor WebAssembly hosting model](xref:blazor/hosting-models#blazor-webassembly). `localStorage` and `sessionStorage` can be used in Blazor WebAssembly apps but only by writing custom code or using a 3rd party package.

`localStorage` and `sessionStorage` differ as follows:

* `localStorage` is scoped to the user's browser. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the user's browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

Caveats for using browser storage:

* Similar to the use of a server-side database, loading and saving data are asynchronous.
* Unlike a server-side database, storage isn't available during prerendering because the requested page doesn't exist in the browser during the prerendering stage.
* Storage of a few kilobytes of data is reasonable to persist for Blazor Server apps. Beyond a few kilobytes, you must consider the performance implications because the data is loaded and saved across the network.
* Users may view or tamper with the data. ASP.NET Core [Data Protection](xref:security/data-protection/introduction) can mitigate the risk.

## Third-party browser storage solutions

Third-party NuGet packages provide APIs for working with `localStorage` and `sessionStorage`.

It's worth considering choosing a package that transparently uses ASP.NET Core's [Data Protection](xref:security/data-protection/introduction). ASP.NET Core Data Protection encrypts stored data and reduces the potential risk of tampering with stored data. If JSON-serialized data is stored in plaintext, users can see the data using browser developer tools and also modify the stored data. Securing data isn't always a problem because the data might be trivial in nature. For example, reading or modifying the stored color of a UI element isn't a significant security risk to the user or the organization. Avoid allowing users to inspect or tamper with *sensitive data*.

## Protected Browser Storage experimental package

An example of a NuGet package that provides [Data Protection](xref:security/data-protection/introduction) for `localStorage` and `sessionStorage` is [Microsoft.AspNetCore.ProtectedBrowserStorage](https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage).

> [!WARNING]
> `Microsoft.AspNetCore.ProtectedBrowserStorage` is an unsupported experimental package unsuitable for production use at this time.

### Installation

To install the `Microsoft.AspNetCore.ProtectedBrowserStorage` package:

1. In the Blazor Server app project, add a package reference to [Microsoft.AspNetCore.ProtectedBrowserStorage](https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage).
1. In the top-level HTML (for example, in the *Pages/_Host.cshtml* file in the default project template), add the following `<script>` tag:

   ```html
   <script src="_content/Microsoft.AspNetCore.ProtectedBrowserStorage/protectedBrowserStorage.js"></script>
   ```

1. In the `Startup.ConfigureServices` method, call `AddProtectedBrowserStorage` to add `localStorage` and `sessionStorage` services to the service collection:

   ```csharp
   services.AddProtectedBrowserStorage();
   ```

### Save and load data within a component

In any component that requires loading or saving data to browser storage, use [`@inject`](xref:mvc/views/razor#inject) to inject an instance of either of the following:

* `ProtectedLocalStorage`
* `ProtectedSessionStorage`

The choice depends on which backing store you wish to use. In the following example, `sessionStorage` is used:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

The `@using` statement can be placed into an *_Imports.razor* file instead of in the component. Use of the *_Imports.razor* file makes the namespace available to larger segments of the app or the whole app.

To persist the `currentCount` value in the `Counter` component of the project template, modify the `IncrementCount` method to use `ProtectedSessionStore.SetAsync`:

```csharp
private async Task IncrementCount()
{
    currentCount++;
    await ProtectedSessionStore.SetAsync("count", currentCount);
}
```

In larger, more realistic apps, storage of individual fields is an unlikely scenario. Apps are more likely to store entire model objects that include complex state. `ProtectedSessionStore` automatically serializes and deserializes JSON data.

In the preceding code example, the `currentCount` data is stored as `sessionStorage['count']` in the user's browser. The data isn't stored in plaintext but rather is protected using ASP.NET Core's [Data Protection](xref:security/data-protection/introduction). The encrypted data can be seen if `sessionStorage['count']` is evaluated in the browser's developer console.

To recover the `currentCount` data if the user returns to the `Counter` component later (including if they're on an entirely new circuit), use `ProtectedSessionStore.GetAsync`:

```csharp
protected override async Task OnInitializedAsync()
{
    currentCount = await ProtectedSessionStore.GetAsync<int>("count");
}
```

If the component's parameters include navigation state, call `ProtectedSessionStore.GetAsync` and assign the result in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>, not <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is only called one time when the component is first instantiated. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> isn't called again later if the user navigates to a different URL while remaining on the same page. For more information, see <xref:blazor/lifecycle>.

> [!WARNING]
> The examples in this section only work if the server doesn't have prerendering enabled. With prerendering enabled, an error is generated similar to:
>
> > JavaScript interop calls cannot be issued at this time. This is because the component is being prerendered.
>
> Either disable prerendering or add additional code to work with prerendering. To learn more about writing code that works with prerendering, see the [Handle prerendering](#handle-prerendering) section.

### Handle the loading state

Since browser storage is asynchronous (accessed over a network connection), there's always a period of time before the data is loaded and available for use by a component. For the best results, render a loading-state message while loading is in progress instead of displaying blank or default data.

One approach is to track whether the data is `null` (still loading) or not. In the default `Counter` component, the count is held in an `int`. Make `currentCount` nullable by adding a question mark (`?`) to the type (`int`):

```csharp
private int? currentCount;
```

Instead of unconditionally displaying the count and **Increment** button, choose to display these elements only if the data is loaded:

```razor
@if (currentCount.HasValue)
{
    <p>Current count: <strong>@currentCount</strong></p>

    <button @onclick="IncrementCount">Increment</button>
}
else
{
    <p>Loading...</p>
}
```

### Handle prerendering

During prerendering:

* An interactive connection to the user's browser doesn't exist.
* The browser doesn't yet have a page in which it can run JavaScript code.

`localStorage` or `sessionStorage` aren't available during prerendering. If the component attempts to interact with storage, an error is generated similar to:

> JavaScript interop calls cannot be issued at this time. This is because the component is being prerendered.

One way to resolve the error is to disable prerendering. This is usually the best choice if the app makes heavy use of browser-based storage. Prerendering adds complexity and doesn't benefit the app because the app can't prerender any useful content until `localStorage` or `sessionStorage` are available.

To disable prerendering, open the *Pages/_Host.cshtml* file and change the `render-mode` of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>.

Prerendering might be useful for other pages that don't use `localStorage` or `sessionStorage`. To keep prerendering enabled, defer the loading operation until the browser is connected to the circuit. The following is an example for storing a counter value:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedLocalStorage ProtectedLocalStore

... rendering code goes here ...

@code {
    private int? currentCount;
    private bool isConnected = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            // When execution reaches this point, the first *interactive* render
            // is complete. The component has an active connection to the browser.
            isConnected = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        currentCount = await ProtectedLocalStore.GetAsync<int>("prerenderedCount");
    }

    private async Task IncrementCount()
    {
        currentCount++;
        await ProtectedSessionStore.SetAsync("count", currentCount);
    }
}
```

### Factor out the state preservation to a common location

If many components rely on browser-based storage, re-implementing state provider code many times creates code duplication. One option for avoiding code duplication is to create a *state provider parent component* that encapsulates the state provider logic. Child components can work with persisted data without regard to the state persistence mechanism.

In the following example of a `CounterStateProvider` component, counter data is persisted:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (hasLoaded)
{
    <CascadingValue Value="@this">
        @ChildContent
    </CascadingValue>
}
else
{
    <p>Loading...</p>
}

@code {
    private bool hasLoaded;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public int CurrentCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CurrentCount = await ProtectedSessionStore.GetAsync<int>("count");
        hasLoaded = true;
    }

    public async Task SaveChangesAsync()
    {
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

The `CounterStateProvider` component handles the loading phase by not rendering its child content until loading is complete.

To use the `CounterStateProvider` component, wrap an instance of the component around any other component that requires access to the counter state. To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> in the `App` component (*App.razor*):

```razor
<CounterStateProvider>
    <Router AppAssembly="typeof(Startup).Assembly">
        ...
    </Router>
</CounterStateProvider>
```

Wrapped components receive and can modify the persisted counter state. The following `Counter` component implements the pattern:

```razor
@page "/counter"

<p>Current count: <strong>@CounterStateProvider.CurrentCount</strong></p>

<button @onclick="IncrementCount">Increment</button>

@code {
    [CascadingParameter]
    private CounterStateProvider CounterStateProvider { get; set; }

    private async Task IncrementCount()
    {
        CounterStateProvider.CurrentCount++;
        await CounterStateProvider.SaveChangesAsync();
    }
}
```

The preceding component isn't required to interact with `ProtectedBrowserStorage`, nor does it deal with a "loading" phase.

To deal with prerendering as described earlier, `CounterStateProvider` can be amended so that all of the components that consume the counter data automatically work with prerendering. See the [Handle prerendering](#handle-prerendering) section for details.

In general, *state provider parent component* pattern is recommended:

* To consume state in many other components.
* If there's just one top-level state object to persist.

To persist many different state objects and consume different subsets of objects in different places, it's better to avoid handling the loading and saving of state globally.
