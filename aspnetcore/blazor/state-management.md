---
title: ASP.NET Core Blazor state management
author: guardrex
description: Learn how to persist user data (state) in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/state-management
zone_pivot_groups: blazor-hosting-models
---
# ASP.NET Core Blazor state management

This article describes common approaches for maintaining a user's data (state) while they use an app and across browser sessions.

:::moniker range=">= aspnetcore-6.0"

:::zone pivot="server"

Blazor Server is a stateful app framework. Most of the time, the app maintains a connection to the server. The user's state is held in the server's memory in a *circuit*. 

Examples of user state held in a circuit include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit.

User state might also be found in JavaScript variables in the browser's memory set via [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

If a user experiences a temporary network connection loss, Blazor attempts to reconnect the user to their original circuit with their original state. However, reconnecting a user to their original circuit in the server's memory isn't always possible:

* The server can't retain a disconnected circuit forever. The server must release a disconnected circuit after a timeout or when the server is under memory pressure.
* In multi-server, load-balanced deployment environments, individual servers may fail or be automatically removed when no longer required to handle the overall volume of requests. The original server processing requests for a user may become unavailable when the user attempts to reconnect.
* The user might close and re-open their browser or reload the page, which removes any state held in the browser's memory. For example, JavaScript variable values set through JavaScript interop calls are lost.

When a user can't be reconnected to their original circuit, the user receives a new circuit with an empty state. This is equivalent to closing and re-opening a desktop app.

## Persist state across circuits

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

To preserve state across circuits, the app must persist the data to some other storage location than the server's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-server)
* [URL](#url-server)
* [Browser storage](#browser-storage-server)
* [In-memory state container service](#in-memory-state-container-service-server)

<h2 id="server-side-storage-server">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use server-side storage. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new circuit.

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-server">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained:

* If the user manually reloads the page.
* If the web server becomes unavailable, and the user is forced to reload the page in order to connect to a different server.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-server">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

Caveats for using browser storage:

* Similar to the use of a server-side database, loading and saving data are asynchronous.
* Unlike a server-side database, storage isn't available during prerendering because the requested page doesn't exist in the browser during the prerendering stage.
* Storage of a few kilobytes of data is reasonable to persist for Blazor Server apps. Beyond a few kilobytes, you must consider the performance implications because the data is loaded and saved across the network.
* Users may view or tamper with the data. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) can mitigate the risk. For example, [ASP.NET Core Protected Browser Storage](#aspnet-core-protected-browser-storage) uses ASP.NET Core Data Protection.

Third-party NuGet packages provide APIs for working with `localStorage` and `sessionStorage`. It's worth considering choosing a package that transparently uses [ASP.NET Core Data Protection](xref:security/data-protection/introduction). Data Protection encrypts stored data and reduces the potential risk of tampering with stored data. If JSON-serialized data is stored in plain text, users can see the data using browser developer tools and also modify the stored data. Securing data isn't always a problem because the data might be trivial in nature. For example, reading or modifying the stored color of a UI element isn't a significant security risk to the user or the organization. Avoid allowing users to inspect or tamper with *sensitive data*.

## ASP.NET Core Protected Browser Storage

ASP.NET Core Protected Browser Storage leverages [ASP.NET Core Data Protection](xref:security/data-protection/introduction) for [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage).

> [!NOTE]
> Protected Browser Storage relies on ASP.NET Core Data Protection and is only supported for Blazor Server apps.

### Save and load data within a component

In any component that requires loading or saving data to browser storage, use the [`@inject`](xref:mvc/views/razor#inject) directive to inject an instance of either of the following:

* `ProtectedLocalStorage`
* `ProtectedSessionStorage`

The choice depends on which browser storage location you wish to use. In the following example, `sessionStorage` is used:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

The `@using` directive can be placed in the app's `_Imports.razor` file instead of in the component. Use of the `_Imports.razor` file makes the namespace available to larger segments of the app or the whole app.

To persist the `currentCount` value in the `Counter` component of an app based on the [Blazor Server project template](xref:blazor/project-structure), modify the `IncrementCount` method to use `ProtectedSessionStore.SetAsync`:

```csharp
private async Task IncrementCount()
{
    currentCount++;
    await ProtectedSessionStore.SetAsync("count", currentCount);
}
```

In larger, more realistic apps, storage of individual fields is an unlikely scenario. Apps are more likely to store entire model objects that include complex state. `ProtectedSessionStore` automatically serializes and deserializes JSON data to store complex state objects.

In the preceding code example, the `currentCount` data is stored as `sessionStorage['count']` in the user's browser. The data isn't stored in plain text but rather is protected using ASP.NET Core Data Protection. The encrypted data can be inspected if `sessionStorage['count']` is evaluated in the browser's developer console.

To recover the `currentCount` data if the user returns to the `Counter` component later, including if the user is on a new circuit, use `ProtectedSessionStore.GetAsync`:

```csharp
protected override async Task OnInitializedAsync()
{
    var result = await ProtectedSessionStore.GetAsync<int>("count");
    currentCount = result.Success ? result.Value : 0;
}
```

If the component's parameters include navigation state, call `ProtectedSessionStore.GetAsync` and assign a non-`null` result in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>, not <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is only called once when the component is first instantiated. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> isn't called again later if the user navigates to a different URL while remaining on the same page. For more information, see <xref:blazor/components/lifecycle>.

> [!WARNING]
> The examples in this section only work if the server doesn't have prerendering enabled. With prerendering enabled, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.
>
> Either disable prerendering or add additional code to work with prerendering. To learn more about writing code that works with prerendering, see the [Handle prerendering](#handle-prerendering) section.

### Handle the loading state

Since browser storage is accessed asynchronously over a network connection, there's always a period of time before the data is loaded and available to a component. For the best results, render a loading-state message while loading is in progress instead of displaying blank or default data.

One approach is to track whether the data is `null`, which means that the data is still loading. In the default `Counter` component, the count is held in an `int`. [Make `currentCount` nullable](/dotnet/csharp/language-reference/builtin-types/nullable-value-types) by adding a question mark (`?`) to the type (`int`):

```csharp
private int? currentCount;
```

Instead of unconditionally displaying the count and **`Increment`** button, display these elements only if the data is loaded by checking <xref:System.Nullable%601.HasValue%2A>:

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

`localStorage` or `sessionStorage` aren't available during prerendering. If the component attempts to interact with storage, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.

One way to resolve the error is to disable prerendering. This is usually the best choice if the app makes heavy use of browser-based storage. Prerendering adds complexity and doesn't benefit the app because the app can't prerender any useful content until `localStorage` or `sessionStorage` are available.

To disable prerendering, open the `Pages/_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

```cshtml
<component type="typeof(App)" render-mode="Server" />
```

[Prerendering of `<head>` content](xref:blazor/components/control-head-content) is disabled in `Pages/_Layout.cshtml`:

```cshtml
<component type="typeof(HeadOutlet)" render-mode="Server" />
```

Prerendering might be useful for other pages that don't use `localStorage` or `sessionStorage`. To retain prerendering, defer the loading operation until the browser is connected to the circuit. The following is an example for storing a counter value:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedLocalStorage ProtectedLocalStore

@if (isConnected)
{
    <p>Current count: <strong>@currentCount</strong></p>
    <button @onclick="IncrementCount">Increment</button>
}
else
{
    <p>Loading...</p>
}

@code {
    private int currentCount;
    private bool isConnected;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isConnected = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        var result = await ProtectedLocalStore.GetAsync<int>("count");
        currentCount = result.Success ? result.Value : 0;
    }

    private async Task IncrementCount()
    {
        currentCount++;
        await ProtectedLocalStore.SetAsync("count", currentCount);
    }
}
```

### Factor out the state preservation to a common location

If many components rely on browser-based storage, re-implementing state provider code many times creates code duplication. One option for avoiding code duplication is to create a *state provider parent component* that encapsulates the state provider logic. Child components can work with persisted data without regard to the state persistence mechanism.

In the following example of a `CounterStateProvider` component, counter data is persisted to `sessionStorage`:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (isLoaded)
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
    private bool isLoaded;

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public int CurrentCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var result = await ProtectedSessionStore.GetAsync<int>("count");
        CurrentCount = result.Success ? result.Value : 0;
        isLoaded = true;
    }

    public async Task SaveChangesAsync()
    {
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

The `CounterStateProvider` component handles the loading phase by not rendering its child content until state loading is complete.

To use the `CounterStateProvider` component, wrap an instance of the component around any other component that requires access to the counter state. To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> in the `App` component (`App.razor`):

```razor
<CounterStateProvider>
    <Router AppAssembly="@typeof(Program).Assembly">
        ...
    </Router>
</CounterStateProvider>
```

Wrapped components receive and can modify the persisted counter state. The following `Counter` component implements the pattern:

```razor
@page "/counter"

<p>Current count: <strong>@CounterStateProvider?.CurrentCount</strong></p>
<button @onclick="IncrementCount">Increment</button>

@code {
    [CascadingParameter]
    private CounterStateProvider? CounterStateProvider { get; set; }

    private async Task IncrementCount()
    {
        if (CounterStateProvider is not null)
        {
            CounterStateProvider.CurrentCount++;
            await CounterStateProvider.SaveChangesAsync();
        }
    }
}
```

The preceding component isn't required to interact with `ProtectedBrowserStorage`, nor does it deal with a "loading" phase.

To deal with prerendering as described earlier, `CounterStateProvider` can be amended so that all of the components that consume the counter data automatically work with prerendering. For more information, see the [Handle prerendering](#handle-prerendering) section.

In general, the *state provider parent component* pattern is recommended:

* To consume state across many components.
* If there's just one top-level state object to persist.

To persist many different state objects and consume different subsets of objects in different places, it's better to avoid persisting state globally.

<h2 id="in-memory-state-container-service-server">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

:::zone-end

:::zone pivot="webassembly"

User state created in a Blazor WebAssembly app is held in the browser's memory.

Examples of user state held in browser memory include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances.
* Values set through [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

When a user closes and re-opens their browser or reloads the page, user state held in the browser's memory is lost.

> [!NOTE]
> [Protected Browser Storage](xref:blazor/state-management?pivots=server#aspnet-core-protected-browser-storage) (<xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage?displayProperty=fullName> namespace) relies on ASP.NET Core Data Protection and is only supported for Blazor Server apps.

## Persist state across browser sessions

Generally, maintain state across browser sessions where users are actively creating data, not simply reading data that already exists.

To preserve state across browser sessions, the app must persist the data to some other storage location than the browser's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-wasm)
* [URL](#url-wasm)
* [Browser storage](#browser-storage-wasm)
* [In-memory state container service](#in-memory-state-container-service-wasm)

<h2 id="server-side-storage-wasm">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use independent server-side storage accessed via a web API. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new browser session.

Because Blazor WebAssembly apps run entirely in the user's browser, they require additional measures to access secure external systems, such as storage services and databases. Blazor WebAssembly apps are secured in the same manner as single-page applications (SPAs). Typically, an app authenticates a user via [OAuth](https://oauth.net)/[OpenID Connect (OIDC)](https://openid.net/connect/) and then interacts with storage services and databases through web API calls to a server-side app. The server-side app mediates the transfer of data between the Blazor WebAssembly app and the storage service or database. The Blazor WebAssembly app maintains an ephemeral connection to the server-side app, while the server-side app has a persistent connection to storage.

For more information, see the following resources:

* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>
* Blazor *Security and Identity* articles

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-wasm">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained if the user manually reloads the page.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-wasm">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

> [!NOTE]
> `localStorage` and `sessionStorage` can be used in Blazor WebAssembly apps but only by writing custom code or using a third-party package.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

> [!WARNING]
> Users may view or tamper with the data stored in `localStorage` and `sessionStorage`.

<h2 id="in-memory-state-container-service-wasm">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

## Additional resources

* [Save app state before an authentication operation](xref:blazor/security/webassembly/additional-scenarios#save-app-state-before-an-authentication-operation)
* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>

:::zone-end

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::zone pivot="server"

Blazor Server is a stateful app framework. Most of the time, the app maintains a connection to the server. The user's state is held in the server's memory in a *circuit*. 

Examples of user state held in a circuit include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit.

User state might also be found in JavaScript variables in the browser's memory set via [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

If a user experiences a temporary network connection loss, Blazor attempts to reconnect the user to their original circuit with their original state. However, reconnecting a user to their original circuit in the server's memory isn't always possible:

* The server can't retain a disconnected circuit forever. The server must release a disconnected circuit after a timeout or when the server is under memory pressure.
* In multi-server, load-balanced deployment environments, individual servers may fail or be automatically removed when no longer required to handle the overall volume of requests. The original server processing requests for a user may become unavailable when the user attempts to reconnect.
* The user might close and re-open their browser or reload the page, which removes any state held in the browser's memory. For example, JavaScript variable values set through JavaScript interop calls are lost.

When a user can't be reconnected to their original circuit, the user receives a new circuit with an empty state. This is equivalent to closing and re-opening a desktop app.

## Persist state across circuits

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

To preserve state across circuits, the app must persist the data to some other storage location than the server's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-server)
* [URL](#url-server)
* [Browser storage](#browser-storage-server)
* [In-memory state container service](#in-memory-state-container-service-server)

<h2 id="server-side-storage-server">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use server-side storage. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new circuit.

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-server">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained:

* If the user manually reloads the page.
* If the web server becomes unavailable, and the user is forced to reload the page in order to connect to a different server.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-server">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

Caveats for using browser storage:

* Similar to the use of a server-side database, loading and saving data are asynchronous.
* Unlike a server-side database, storage isn't available during prerendering because the requested page doesn't exist in the browser during the prerendering stage.
* Storage of a few kilobytes of data is reasonable to persist for Blazor Server apps. Beyond a few kilobytes, you must consider the performance implications because the data is loaded and saved across the network.
* Users may view or tamper with the data. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) can mitigate the risk. For example, [ASP.NET Core Protected Browser Storage](#aspnet-core-protected-browser-storage) uses ASP.NET Core Data Protection.

Third-party NuGet packages provide APIs for working with `localStorage` and `sessionStorage`. It's worth considering choosing a package that transparently uses [ASP.NET Core Data Protection](xref:security/data-protection/introduction). Data Protection encrypts stored data and reduces the potential risk of tampering with stored data. If JSON-serialized data is stored in plain text, users can see the data using browser developer tools and also modify the stored data. Securing data isn't always a problem because the data might be trivial in nature. For example, reading or modifying the stored color of a UI element isn't a significant security risk to the user or the organization. Avoid allowing users to inspect or tamper with *sensitive data*.

## ASP.NET Core Protected Browser Storage

ASP.NET Core Protected Browser Storage leverages [ASP.NET Core Data Protection](xref:security/data-protection/introduction) for [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage).

> [!NOTE]
> Protected Browser Storage relies on ASP.NET Core Data Protection and is only supported for Blazor Server apps.

### Save and load data within a component

In any component that requires loading or saving data to browser storage, use the [`@inject`](xref:mvc/views/razor#inject) directive to inject an instance of either of the following:

* `ProtectedLocalStorage`
* `ProtectedSessionStorage`

The choice depends on which browser storage location you wish to use. In the following example, `sessionStorage` is used:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

The `@using` directive can be placed in the app's `_Imports.razor` file instead of in the component. Use of the `_Imports.razor` file makes the namespace available to larger segments of the app or the whole app.

To persist the `currentCount` value in the `Counter` component of an app based on the [Blazor Server project template](xref:blazor/project-structure), modify the `IncrementCount` method to use `ProtectedSessionStore.SetAsync`:

```csharp
private async Task IncrementCount()
{
    currentCount++;
    await ProtectedSessionStore.SetAsync("count", currentCount);
}
```

In larger, more realistic apps, storage of individual fields is an unlikely scenario. Apps are more likely to store entire model objects that include complex state. `ProtectedSessionStore` automatically serializes and deserializes JSON data to store complex state objects.

In the preceding code example, the `currentCount` data is stored as `sessionStorage['count']` in the user's browser. The data isn't stored in plain text but rather is protected using ASP.NET Core Data Protection. The encrypted data can be inspected if `sessionStorage['count']` is evaluated in the browser's developer console.

To recover the `currentCount` data if the user returns to the `Counter` component later, including if the user is on a new circuit, use `ProtectedSessionStore.GetAsync`:

```csharp
protected override async Task OnInitializedAsync()
{
    var result = await ProtectedSessionStore.GetAsync<int>("count");
    currentCount = result.Success ? result.Value : 0;
}
```

If the component's parameters include navigation state, call `ProtectedSessionStore.GetAsync` and assign a non-`null` result in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>, not <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is only called once when the component is first instantiated. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> isn't called again later if the user navigates to a different URL while remaining on the same page. For more information, see <xref:blazor/components/lifecycle>.

> [!WARNING]
> The examples in this section only work if the server doesn't have prerendering enabled. With prerendering enabled, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.
>
> Either disable prerendering or add additional code to work with prerendering. To learn more about writing code that works with prerendering, see the [Handle prerendering](#handle-prerendering) section.

### Handle the loading state

Since browser storage is accessed asynchronously over a network connection, there's always a period of time before the data is loaded and available to a component. For the best results, render a loading-state message while loading is in progress instead of displaying blank or default data.

One approach is to track whether the data is `null`, which means that the data is still loading. In the default `Counter` component, the count is held in an `int`. [Make `currentCount` nullable](/dotnet/csharp/language-reference/builtin-types/nullable-value-types) by adding a question mark (`?`) to the type (`int`):

```csharp
private int? currentCount;
```

Instead of unconditionally displaying the count and **`Increment`** button, display these elements only if the data is loaded by checking <xref:System.Nullable%601.HasValue%2A>:

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

`localStorage` or `sessionStorage` aren't available during prerendering. If the component attempts to interact with storage, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.

One way to resolve the error is to disable prerendering. This is usually the best choice if the app makes heavy use of browser-based storage. Prerendering adds complexity and doesn't benefit the app because the app can't prerender any useful content until `localStorage` or `sessionStorage` are available.

To disable prerendering, open the `Pages/_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

```cshtml
<component type="typeof(App)" render-mode="Server" />
```

Prerendering might be useful for other pages that don't use `localStorage` or `sessionStorage`. To retain prerendering, defer the loading operation until the browser is connected to the circuit. The following is an example for storing a counter value:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedLocalStorage ProtectedLocalStore

@if (isConnected)
{
    <p>Current count: <strong>@currentCount</strong></p>
    <button @onclick="IncrementCount">Increment</button>
}
else
{
    <p>Loading...</p>
}

@code {
    private int currentCount;
    private bool isConnected;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isConnected = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        var result = await ProtectedLocalStore.GetAsync<int>("count");
        currentCount = result.Success ? result.Value : 0;
    }

    private async Task IncrementCount()
    {
        currentCount++;
        await ProtectedLocalStore.SetAsync("count", currentCount);
    }
}
```

### Factor out the state preservation to a common location

If many components rely on browser-based storage, re-implementing state provider code many times creates code duplication. One option for avoiding code duplication is to create a *state provider parent component* that encapsulates the state provider logic. Child components can work with persisted data without regard to the state persistence mechanism.

In the following example of a `CounterStateProvider` component, counter data is persisted to `sessionStorage`:

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (isLoaded)
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
    private bool isLoaded;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public int CurrentCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var result = await ProtectedSessionStore.GetAsync<int>("count");
        CurrentCount = result.Success ? result.Value : 0;
        isLoaded = true;
    }

    public async Task SaveChangesAsync()
    {
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

The `CounterStateProvider` component handles the loading phase by not rendering its child content until state loading is complete.

To use the `CounterStateProvider` component, wrap an instance of the component around any other component that requires access to the counter state. To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> in the `App` component (`App.razor`):

```razor
<CounterStateProvider>
    <Router AppAssembly="@typeof(Program).Assembly">
        ...
    </Router>
</CounterStateProvider>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

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

To deal with prerendering as described earlier, `CounterStateProvider` can be amended so that all of the components that consume the counter data automatically work with prerendering. For more information, see the [Handle prerendering](#handle-prerendering) section.

In general, the *state provider parent component* pattern is recommended:

* To consume state across many components.
* If there's just one top-level state object to persist.

To persist many different state objects and consume different subsets of objects in different places, it's better to avoid persisting state globally.

<h2 id="in-memory-state-container-service-server">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

:::zone-end

:::zone pivot="webassembly"

User state created in a Blazor WebAssembly app is held in the browser's memory.

Examples of user state held in browser memory include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances.
* Values set through [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

When a user closes and re-opens their browser or reloads the page, user state held in the browser's memory is lost.

> [!NOTE]
> [Protected Browser Storage](xref:blazor/state-management?pivots=server#aspnet-core-protected-browser-storage) (<xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage?displayProperty=fullName> namespace) relies on ASP.NET Core Data Protection and is only supported for Blazor Server apps.

## Persist state across browser sessions

Generally, maintain state across browser sessions where users are actively creating data, not simply reading data that already exists.

To preserve state across browser sessions, the app must persist the data to some other storage location than the browser's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-wasm)
* [URL](#url-wasm)
* [Browser storage](#browser-storage-wasm)
* [In-memory state container service](#in-memory-state-container-service-wasm)

<h2 id="server-side-storage-wasm">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use independent server-side storage accessed via a web API. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new browser session.

Because Blazor WebAssembly apps run entirely in the user's browser, they require additional measures to access secure external systems, such as storage services and databases. Blazor WebAssembly apps are secured in the same manner as single-page applications (SPAs). Typically, an app authenticates a user via [OAuth](https://oauth.net)/[OpenID Connect (OIDC)](https://openid.net/connect/) and then interacts with storage services and databases through web API calls to a server-side app. The server-side app mediates the transfer of data between the Blazor WebAssembly app and the storage service or database. The Blazor WebAssembly app maintains an ephemeral connection to the server-side app, while the server-side app has a persistent connection to storage.

For more information, see the following resources:

* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>
* Blazor *Security and Identity* articles

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-wasm">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained if the user manually reloads the page.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-wasm">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

> [!NOTE]
> `localStorage` and `sessionStorage` can be used in Blazor WebAssembly apps but only by writing custom code or using a third-party package.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

> [!WARNING]
> Users may view or tamper with the data stored in `localStorage` and `sessionStorage`.

<h2 id="in-memory-state-container-service-wasm">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

## Additional resources

* [Save app state before an authentication operation](xref:blazor/security/webassembly/additional-scenarios#save-app-state-before-an-authentication-operation)
* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>

:::zone-end

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::zone pivot="server"

Blazor Server is a stateful app framework. Most of the time, the app maintains a connection to the server. The user's state is held in the server's memory in a *circuit*. 

Examples of user state held in a circuit include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances that are scoped to the circuit.

User state might also be found in JavaScript variables in the browser's memory set via [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

If a user experiences a temporary network connection loss, Blazor attempts to reconnect the user to their original circuit with their original state. However, reconnecting a user to their original circuit in the server's memory isn't always possible:

* The server can't retain a disconnected circuit forever. The server must release a disconnected circuit after a timeout or when the server is under memory pressure.
* In multi-server, load-balanced deployment environments, individual servers may fail or be automatically removed when no longer required to handle the overall volume of requests. The original server processing requests for a user may become unavailable when the user attempts to reconnect.
* The user might close and re-open their browser or reload the page, which removes any state held in the browser's memory. For example, JavaScript variable values set through JavaScript interop calls are lost.

When a user can't be reconnected to their original circuit, the user receives a new circuit with an empty state. This is equivalent to closing and re-opening a desktop app.

## Persist state across circuits

Generally, maintain state across circuits where users are actively creating data, not simply reading data that already exists.

To preserve state across circuits, the app must persist the data to some other storage location than the server's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-server)
* [URL](#url-server)
* [Browser storage](#browser-storage-server)
* [In-memory state container service](#in-memory-state-container-service-server)

<h2 id="server-side-storage-server">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use server-side storage. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new circuit.

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-server">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained:

* If the user manually reloads the page.
* If the web server becomes unavailable, and the user is forced to reload the page in order to connect to a different server.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-server">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

Caveats for using browser storage:

* Similar to the use of a server-side database, loading and saving data are asynchronous.
* Unlike a server-side database, storage isn't available during prerendering because the requested page doesn't exist in the browser during the prerendering stage.
* Storage of a few kilobytes of data is reasonable to persist for Blazor Server apps. Beyond a few kilobytes, you must consider the performance implications because the data is loaded and saved across the network.
* Users may view or tamper with the data. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) can mitigate the risk. For example, [ASP.NET Core Protected Browser Storage](#protected-browser-storage-experimental-nuget-package) uses ASP.NET Core Data Protection.

Third-party NuGet packages provide APIs for working with `localStorage` and `sessionStorage`. It's worth considering choosing a package that transparently uses [ASP.NET Core Data Protection](xref:security/data-protection/introduction). Data Protection encrypts stored data and reduces the potential risk of tampering with stored data. If JSON-serialized data is stored in plain text, users can see the data using browser developer tools and also modify the stored data. Securing data isn't always a problem because the data might be trivial in nature. For example, reading or modifying the stored color of a UI element isn't a significant security risk to the user or the organization. Avoid allowing users to inspect or tamper with *sensitive data*.

## Protected Browser Storage experimental NuGet package

ASP.NET Core Protected Browser Storage leverages [ASP.NET Core Data Protection](xref:security/data-protection/introduction) for [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage).

> [!WARNING]
> `Microsoft.AspNetCore.ProtectedBrowserStorage` is an unsupported, experimental package that isn't intended for production use.
>
> The package is only available for use in ASP.NET Core 3.1 Blazor Server apps.

### Configuration

1. Add a package reference to [`Microsoft.AspNetCore.ProtectedBrowserStorage`](https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage).

   [!INCLUDE[](~/includes/package-reference.md)]

1. In the `Pages/_Host.cshtml` file, add the following script inside the closing `</body>` tag:

   ```cshtml
   <script src="_content/Microsoft.AspNetCore.ProtectedBrowserStorage/protectedBrowserStorage.js"></script>
   ```

1. In `Startup.ConfigureServices`, call `AddProtectedBrowserStorage` to add `localStorage` and `sessionStorage` services to the service collection:

   ```csharp
   services.AddProtectedBrowserStorage();
   ```

### Save and load data within a component

In any component that requires loading or saving data to browser storage, use the [`@inject`](xref:mvc/views/razor#inject) directive to inject an instance of either of the following:

* `ProtectedLocalStorage`
* `ProtectedSessionStorage`

The choice depends on which browser storage location you wish to use. In the following example, `sessionStorage` is used:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

The `@using` statement can be placed into an `_Imports.razor` file instead of in the component. Use of the `_Imports.razor` file makes the namespace available to larger segments of the app or the whole app.

To persist the `currentCount` value in the `Counter` component of an app based on the [Blazor Server project template](xref:blazor/project-structure), modify the `IncrementCount` method to use `ProtectedSessionStore.SetAsync`:

```csharp
private async Task IncrementCount()
{
    currentCount++;
    await ProtectedSessionStore.SetAsync("count", currentCount);
}
```

In larger, more realistic apps, storage of individual fields is an unlikely scenario. Apps are more likely to store entire model objects that include complex state. `ProtectedSessionStore` automatically serializes and deserializes JSON data.

In the preceding code example, the `currentCount` data is stored as `sessionStorage['count']` in the user's browser. The data isn't stored in plain text but rather is protected using ASP.NET Core Data Protection. The encrypted data can be inspected if `sessionStorage['count']` is evaluated in the browser's developer console.

To recover the `currentCount` data if the user returns to the `Counter` component later, including if they're on an entirely new circuit, use `ProtectedSessionStore.GetAsync`:

```csharp
protected override async Task OnInitializedAsync()
{
    currentCount = await ProtectedSessionStore.GetAsync<int>("count");
}
```

If the component's parameters include navigation state, call `ProtectedSessionStore.GetAsync` and assign the result in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>, not <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is only called once when the component is first instantiated. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> isn't called again later if the user navigates to a different URL while remaining on the same page. For more information, see <xref:blazor/components/lifecycle>.

> [!WARNING]
> The examples in this section only work if the server doesn't have prerendering enabled. With prerendering enabled, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.
>
> Either disable prerendering or add additional code to work with prerendering. To learn more about writing code that works with prerendering, see the [Handle prerendering](#handle-prerendering) section.

### Handle the loading state

Since browser storage is accessed asynchronously over a network connection, there's always a period of time before the data is loaded and available to a component. For the best results, render a loading-state message while loading is in progress instead of displaying blank or default data.

One approach is to track whether the data is `null`, which means that the data is still loading. In the default `Counter` component, the count is held in an `int`. [Make `currentCount` nullable](/dotnet/csharp/language-reference/builtin-types/nullable-value-types) by adding a question mark (`?`) to the type (`int`):

```csharp
private int? currentCount;
```

Instead of unconditionally displaying the count and **`Increment`** button, choose to display these elements only if the data is loaded:

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

`localStorage` or `sessionStorage` aren't available during prerendering. If the component attempts to interact with storage, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.

One way to resolve the error is to disable prerendering. This is usually the best choice if the app makes heavy use of browser-based storage. Prerendering adds complexity and doesn't benefit the app because the app can't prerender any useful content until `localStorage` or `sessionStorage` are available.

To disable prerendering, open the `Pages/_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

```cshtml
<component type="typeof(App)" render-mode="Server" />
```

Prerendering might be useful for other pages that don't use `localStorage` or `sessionStorage`. To retain prerendering, defer the loading operation until the browser is connected to the circuit. The following is an example for storing a counter value:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedLocalStorage ProtectedLocalStore

@if (isConnected)
{
    <p>Current count: <strong>@currentCount</strong></p>
    <button @onclick="IncrementCount">Increment</button>
}
else
{
    <p>Loading...</p>
}

@code {
    private int? currentCount;
    private bool isConnected = false;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isConnected = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        currentCount = await ProtectedLocalStore.GetAsync<int>("count");
    }

    private async Task IncrementCount()
    {
        currentCount++;
        await ProtectedLocalStore.SetAsync("count", currentCount);
    }
}
```

### Factor out the state preservation to a common location

If many components rely on browser-based storage, re-implementing state provider code many times creates code duplication. One option for avoiding code duplication is to create a *state provider parent component* that encapsulates the state provider logic. Child components can work with persisted data without regard to the state persistence mechanism.

In the following example of a `CounterStateProvider` component, counter data is persisted to `sessionStorage`:

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (isLoaded)
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
    private bool isLoaded;

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public int CurrentCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CurrentCount = await ProtectedSessionStore.GetAsync<int>("count");
        isLoaded = true;
    }

    public async Task SaveChangesAsync()
    {
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

The `CounterStateProvider` component handles the loading phase by not rendering its child content until state loading is complete.

To use the `CounterStateProvider` component, wrap an instance of the component around any other component that requires access to the counter state. To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> in the `App` component (`App.razor`):

```razor
<CounterStateProvider>
    <Router AppAssembly="@typeof(Program).Assembly">
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

To deal with prerendering as described earlier, `CounterStateProvider` can be amended so that all of the components that consume the counter data automatically work with prerendering. For more information, see the [Handle prerendering](#handle-prerendering) section.

In general, *state provider parent component* pattern is recommended:

* To consume state across many components.
* If there's just one top-level state object to persist.

To persist many different state objects and consume different subsets of objects in different places, it's better to avoid persisting state globally.

<h2 id="in-memory-state-container-service-server">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

:::zone-end

:::zone pivot="webassembly"

User state created in a Blazor WebAssembly app is held in the browser's memory.

Examples of user state held in browser memory include:

* The hierarchy of component instances and their most recent render output in the rendered UI.
* The values of fields and properties in component instances.
* Data held in [dependency injection (DI)](xref:fundamentals/dependency-injection) service instances.
* Values set through [JavaScript interop](xref:blazor/js-interop/call-javascript-from-dotnet) calls.

When a user closes and re-opens their browser or reloads the page, user state held in the browser's memory is lost.

> [!NOTE]
> [Protected Browser Storage](xref:blazor/state-management?pivots=server#protected-browser-storage-experimental-nuget-package) (<xref:Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage?displayProperty=fullName> namespace) relies on ASP.NET Core Data Protection and is only supported for Blazor Server apps.

## Persist state across browser sessions

Generally, maintain state across browser sessions where users are actively creating data, not simply reading data that already exists.

To preserve state across browser sessions, the app must persist the data to some other storage location than the browser's memory. State persistence isn't automatic. You must take steps when developing the app to implement stateful data persistence.

Data persistence is typically only required for high-value state that users expended effort to create. In the following examples, persisting state either saves time or aids in commercial activities:

* Multi-step web forms: It's time-consuming for a user to re-enter data for several completed steps of a multi-step web form if their state is lost. A user loses state in this scenario if they navigate away from the form and return later.
* Shopping carts: Any commercially important component of an app that represents potential revenue can be maintained. A user who loses their state, and thus their shopping cart, may purchase fewer products or services when they return to the site later.

An app can only persist *app state*. UIs can't be persisted, such as component instances and their render trees. Components and render trees aren't generally serializable. To persist UI state, such as the expanded nodes of a tree view control, the app must use custom code to model the behavior of the UI state as serializable app state.

## Where to persist state

Common locations exist for persisting state:

* [Server-side storage](#server-side-storage-wasm)
* [URL](#url-wasm)
* [Browser storage](#browser-storage-wasm)
* [In-memory state container service](#in-memory-state-container-service-wasm)

<h2 id="server-side-storage-wasm">Server-side storage</h2>

For permanent data persistence that spans multiple users and devices, the app can use independent server-side storage accessed via a web API. Options include:

* Blob storage
* Key-value storage
* Relational database
* Table storage

After data is saved, the user's state is retained and available in any new browser session.

Because Blazor WebAssembly apps run entirely in the user's browser, they require additional measures to access secure external systems, such as storage services and databases. Blazor WebAssembly apps are secured in the same manner as single-page applications (SPAs). Typically, an app authenticates a user via [OAuth](https://oauth.net)/[OpenID Connect (OIDC)](https://openid.net/connect/) and then interacts with storage services and databases through web API calls to a server-side app. The server-side app mediates the transfer of data between the Blazor WebAssembly app and the storage service or database. The Blazor WebAssembly app maintains an ephemeral connection to the server-side app, while the server-side app has a persistent connection to storage.

For more information, see the following resources:

* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>
* Blazor *Security and Identity* articles

For more information on Azure data storage options, see the following:

* [Azure Databases](https://azure.microsoft.com/product-categories/databases/)
* [Azure Storage Documentation](/azure/storage/)

<h2 id="url-wasm">URL</h2>

For transient data representing navigation state, model the data as a part of the URL. Examples of user state modeled in the URL include:

* The ID of a viewed entity.
* The current page number in a paged grid.

The contents of the browser's address bar are retained if the user manually reloads the page.

For information on defining URL patterns with the [`@page`](xref:mvc/views/razor#page) directive, see <xref:blazor/fundamentals/routing>.

<h2 id="browser-storage-wasm">Browser storage</h2>

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's window. If the user reloads the page or closes and re-opens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

> [!NOTE]
> `localStorage` and `sessionStorage` can be used in Blazor WebAssembly apps but only by writing custom code or using a third-party package.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and re-opening the browser.

> [!WARNING]
> Users may view or tamper with the data stored in `localStorage` and `sessionStorage`.

<h2 id="in-memory-state-container-service-wasm">In-memory state container service</h2>

[!INCLUDE[](~/blazor/includes/state-container.md)]

## Additional resources

* [Save app state before an authentication operation](xref:blazor/security/webassembly/additional-scenarios#save-app-state-before-an-authentication-operation)
* <xref:blazor/call-web-api>
* <xref:blazor/security/webassembly/index>

:::zone-end

:::moniker-end
