---
title: ASP.NET Core Blazor state management using protected browser storage
author: guardrex
description: Learn how to persist user data (state) in Blazor apps using browser storage.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 08/05/2025
uid: blazor/state-management/protected-browser-storage
---
# ASP.NET Core Blazor protected browser storage

For transient data that the user is actively creating, a commonly used storage location is the browser's [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage) collections:

* `localStorage` is scoped to the browser's instance. If the user reloads the page or closes and reopens the browser, the state persists. If the user opens multiple browser tabs, the state is shared across the tabs. Data persists in `localStorage` until explicitly cleared. The `localStorage` data for a document loaded in a "private browsing" or "incognito" session is cleared when the last "private" tab is closed.
* `sessionStorage` is scoped to the browser tab. If the user reloads the tab, the state persists. If the user closes the tab or the browser, the state is lost. If the user opens multiple browser tabs, each tab has its own independent version of the data.

Generally, `sessionStorage` is safer to use. `sessionStorage` avoids the risk that a user opens multiple tabs and encounters the following:

* Bugs in state storage across tabs.
* Confusing behavior when a tab overwrites the state of other tabs.

`localStorage` is the better choice if the app must persist state across closing and reopening the browser.

Caveats for using browser storage:

* Similar to the use of a server-side database, loading and saving data are asynchronous.
* The requested page doesn't exist in the browser during prerendering, so local storage isn't available during prerendering.
* Storage of a few kilobytes of data is reasonable to persist for server-side Blazor apps. Beyond a few kilobytes, you must consider the performance implications because the data is loaded and saved across the network.
* Users may view or tamper with the data. [ASP.NET Core Data Protection](xref:security/data-protection/introduction) can mitigate the risk. For example, [ASP.NET Core Protected Browser Storage](#aspnet-core-protected-browser-storage) uses ASP.NET Core Data Protection.

Third-party NuGet packages provide APIs for working with `localStorage` and `sessionStorage`. It's worth considering choosing a package that transparently uses [ASP.NET Core Data Protection](xref:security/data-protection/introduction). Data Protection encrypts stored data and reduces the potential risk of tampering with stored data. If JSON-serialized data is stored in plain text, users can see the data using browser developer tools and also modify the stored data. Securing trivial data isn't a problem. For example, reading or modifying the stored color of a UI element isn't a significant security risk to the user or the organization. Avoid allowing users to inspect or tamper with *sensitive data*.

## ASP.NET Core Protected Browser Storage

ASP.NET Core Protected Browser Storage leverages [ASP.NET Core Data Protection](xref:security/data-protection/introduction) for [`localStorage`](https://developer.mozilla.org/docs/Web/API/Window/localStorage) and [`sessionStorage`](https://developer.mozilla.org/docs/Web/API/Window/sessionStorage).

:::moniker range=">= aspnetcore-5.0"

> [!NOTE]
> Protected Browser Storage relies on ASP.NET Core Data Protection and is only supported for server-side Blazor apps.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

> [!WARNING]
> `Microsoft.AspNetCore.ProtectedBrowserStorage` is an unsupported, experimental package that isn't intended for production use.
>
> The package is only available for use in ASP.NET Core 3.1 apps.

## Configuration

1. Add a package reference to [`Microsoft.AspNetCore.ProtectedBrowserStorage`](https://www.nuget.org/packages/Microsoft.AspNetCore.ProtectedBrowserStorage).

   [!INCLUDE[](~/includes/package-reference.md)]

1. In the `_Host.cshtml` file, add the following script inside the closing `</body>` tag:

   ```cshtml
   <script src="_content/Microsoft.AspNetCore.ProtectedBrowserStorage/protectedBrowserStorage.js"></script>
   ```

1. In `Startup.ConfigureServices`, call `AddProtectedBrowserStorage` to add `localStorage` and `sessionStorage` services to the service collection:

   ```csharp
   services.AddProtectedBrowserStorage();
   ```

:::moniker-end

## Save and load data within a component

In any component that requires loading or saving data to browser storage, use the [`@inject`](xref:mvc/views/razor#inject) directive to inject an instance of either of the following:

* `ProtectedLocalStorage`
* `ProtectedSessionStorage`

The choice depends on which browser storage location you wish to use. In the following example, `sessionStorage` is used:

:::moniker range=">= aspnetcore-5.0"

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore
```

:::moniker-end

The `@using` directive can be placed in the app's `_Imports.razor` file instead of in the component. Use of the `_Imports.razor` file makes the namespace available to larger segments of the app or the whole app.

To persist the `currentCount` value in the `Counter` component of an app based on the [Blazor project template](xref:blazor/project-structure), modify the `IncrementCount` method to use `ProtectedSessionStore.SetAsync`:

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

:::moniker range=">= aspnetcore-5.0"

```csharp
protected override async Task OnInitializedAsync()
{
    var result = await ProtectedSessionStore.GetAsync<int>("count");
    currentCount = result.Success ? result.Value : 0;
}
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```csharp
protected override async Task OnInitializedAsync()
{
    currentCount = await ProtectedSessionStore.GetAsync<int>("count");
}
```

:::moniker-end

If the component's parameters include navigation state, call `ProtectedSessionStore.GetAsync` and assign a non-`null` result in <xref:Microsoft.AspNetCore.Components.ComponentBase.OnParametersSetAsync%2A>, not <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A>. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> is only called once when the component is first instantiated. <xref:Microsoft.AspNetCore.Components.ComponentBase.OnInitializedAsync%2A> isn't called again later if the user navigates to a different URL while remaining on the same page. For more information, see <xref:blazor/components/lifecycle>.

> [!WARNING]
> The examples in this section only work if the server doesn't have prerendering enabled. With prerendering enabled, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.
>
> Either disable prerendering or add additional code to work with prerendering. To learn more about writing code that works with prerendering, see the [Handle prerendering](#handle-prerendering) section.

## Handle the loading state

Since browser storage is accessed asynchronously over a network connection, there's always a period of time before the data is loaded and available to a component. For the best results, render a message while loading is in progress instead of displaying blank or default data.

:::moniker range=">= aspnetcore-6.0"

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

:::moniker-end

## Handle prerendering

During prerendering:

* An interactive connection to the user's browser doesn't exist.
* The browser doesn't yet have a page in which it can run JavaScript code.

`localStorage` or `sessionStorage` aren't available during prerendering. If the component attempts to interact with storage, an error is generated explaining that JavaScript interop calls cannot be issued because the component is being prerendered.

One way to resolve the error is to disable prerendering. This is usually the best choice if the app makes heavy use of browser-based storage. Prerendering adds complexity and doesn't benefit the app because the app can't prerender any useful content until `localStorage` or `sessionStorage` are available.

:::moniker range=">= aspnetcore-8.0"

To disable prerendering, indicate the render mode with the `prerender` parameter set to `false` at the highest-level component in the app's component hierarchy that isn't a root component.

> [!NOTE]
> Making a root component interactive, such as the `App` component, isn't supported. Therefore, prerendering can't be disabled directly by the `App` component.

For apps based on the Blazor Web App project template, prerendering is typically disabled where the `Routes` component is used in the `App` component (`Components/App.razor`):

```razor
<Routes @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

Also, disable prerendering for the `HeadOutlet` component:

```razor
<HeadOutlet @rendermode="new InteractiveServerRenderMode(prerender: false)" />
```

For more information, see <xref:blazor/components/prerender#disable-prerendering>.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To disable prerendering, open the `_Host.cshtml` file and change the `render-mode` attribute of the [Component Tag Helper](xref:mvc/views/tag-helpers/builtin-th/component-tag-helper) to <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server>:

```cshtml
<component type="typeof(App)" render-mode="Server" />
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

When prerendering is disabled, [prerendering of `<head>` content](xref:blazor/components/control-head-content) is disabled.

:::moniker-end

Prerendering might be useful for other pages that don't use `localStorage` or `sessionStorage`. To retain prerendering, defer the loading operation until the browser is connected to the circuit. The following is an example for storing a counter value:

:::moniker range=">= aspnetcore-5.0"

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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

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
    private int currentCount = 0;
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

:::moniker-end

## Factor out state preservation to a common provider

If many components rely on browser-based storage, implementing state provider code many times creates code duplication. One option for avoiding code duplication is to create a *state provider parent component* that encapsulates the state provider logic. Child components can work with persisted data without regard to the state persistence mechanism.

In the following example of a `CounterStateProvider` component, counter data is persisted to `sessionStorage`, and it handles the loading phase by not rendering its child content until state loading is complete.

The `CounterStateProvider` component deals with prerendering by not loading state until after component rendering in the [`OnAfterRenderAsync` lifecycle method](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync), which doesn't execute during prerendering.

The approach in this section isn't capable of triggering rerendering of multiple subscribed components on the same page. If one subscribed component changes the state, it rerenders and can display the updated state, but a different component on the same page displaying that state displays stale data until its own next rerender. Therefore, the approach described in this section is best suited to using state in a single component on the page.

`CounterStateProvider.razor`:

:::moniker range=">= aspnetcore-5.0"

```razor
@using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (isLoaded)
{
    <CascadingValue Value="this">
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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isLoaded = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        var result = await ProtectedSessionStore.GetAsync<int>("count");
        CurrentCount = result.Success ? result.Value : 0;
        isLoaded = true;
    }

    public async Task IncrementCount()
    {
        CurrentCount++;
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-5.0"

```razor
@using Microsoft.AspNetCore.ProtectedBrowserStorage
@inject ProtectedSessionStorage ProtectedSessionStore

@if (isLoaded)
{
    <CascadingValue Value="this">
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

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            isLoaded = true;
            await LoadStateAsync();
            StateHasChanged();
        }
    }

    private async Task LoadStateAsync()
    {
        CurrentCount = await ProtectedSessionStore.GetAsync<int>("count");
        isLoaded = true;
    }

    public async Task IncrementCount()
    {
        CurrentCount++;
        await ProtectedSessionStore.SetAsync("count", CurrentCount);
    }
}
```

:::moniker-end

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

:::moniker range=">= aspnetcore-8.0"

To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> (`<Router>...</Router>`) in the `Routes` component with global interactive server-side rendering (interactive SSR).

In the `App` component (`Components/App.razor`):

```razor
<Routes @rendermode="InteractiveServer" />
```

In the `Routes` component (`Components/Routes.razor`):

:::moniker-end

:::moniker range="< aspnetcore-8.0"

To use the `CounterStateProvider` component, wrap an instance of the component around any other component that requires access to the counter state. To make the state accessible to all components in an app, wrap the `CounterStateProvider` component around the <xref:Microsoft.AspNetCore.Components.Routing.Router> in the `App` component (`App.razor`):

:::moniker-end

```razor
<CounterStateProvider>
    <Router ...>
        ...
    </Router>
</CounterStateProvider>
```

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

:::moniker-end

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
            await CounterStateProvider.IncrementCount();
        }
    }
}
```

The preceding component isn't required to interact with `ProtectedBrowserStorage`, nor does it deal with a "loading" phase.

In general, the *state provider parent component* pattern is recommended:

* To consume state across many components.
* If there's just one top-level state object to persist.

To persist many different state objects and consume different subsets of objects in different places, it's better to avoid persisting state globally.
