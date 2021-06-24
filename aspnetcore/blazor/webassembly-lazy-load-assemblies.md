---
title: Lazy load assemblies in ASP.NET Core Blazor WebAssembly
author: guardrex
description: Discover how to lazy load assemblies in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/24/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/webassembly-lazy-load-assemblies
---
# Lazy load assemblies in ASP.NET Core Blazor WebAssembly

Blazor WebAssembly app startup performance can be improved by deferring the loading of some app assemblies until they're required, which is called *lazy loading*.

> [!NOTE]
> Assembly lazy loading doesn't benefit Blazor Server apps because Blazor Server app assemblies aren't downloaded to the client.

## Project file

Mark assemblies for lazy loading in the app's project file (`.csproj`) using the `BlazorWebAssemblyLazyLoad` item. Use the assembly name with the `.dll` extension. The Blazor framework prevents the assemblies from loading at app launch. The following example marks the `GrantImaharaRobotControls.dll` assembly for lazy loading. If an assembly that's marked for lazy loading has dependencies, they must also be marked for lazy loading.

```xml
<ItemGroup>
  <BlazorWebAssemblyLazyLoad Include="GrantImaharaRobotControls.dll" />
</ItemGroup>
```

## `Router` component

Blazor's <xref:Microsoft.AspNetCore.Components.Routing.Router> component designates the assemblies that Blazor searches for routable components. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component is also responsible for rendering the component for the route where the user navigates. The <xref:Microsoft.AspNetCore.Components.Routing.Router> component supports an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> feature that can be used in conjunction with lazy loading.

In the app's <xref:Microsoft.AspNetCore.Components.Routing.Router> component, which appears in the `App.razor` file:

* Add an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> handler is invoked when the user:
  * Visits a route for the first time by navigating to it directly in their browser.
  * Navigates to a new route using a link or a <xref:Microsoft.AspNetCore.Components.NavigationManager.NavigateTo%2A?displayProperty=nameWithType> invocation.
* If lazy-loaded assemblies contain routable components, add a [List](xref:System.Collections.Generic.List%601)\<<xref:System.Reflection.Assembly>> (for example, named `lazyLoadedAssemblies`) to the component. The assemblies are passed back to the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> collection in case the assemblies contain routable components. The framework searches the assemblies for routes and updates the route collection if new routes are found.

```razor
...
@using System.Reflection

<Router AppAssembly="@typeof(Program).Assembly" 
    AdditionalAssemblies="@lazyLoadedAssemblies" OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private List<Assembly> lazyLoadedAssemblies = new List<Assembly>();

    private async Task OnNavigateAsync(NavigationContext args)
    {
    }
}
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

If the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback throws an unhandled exception, the [Blazor error UI](xref:blazor/fundamentals/handle-errors#detailed-errors-during-development) is invoked.

### Assembly load logic in `OnNavigateAsync`

<xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> has a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> parameter that provides information about the current asynchronous navigation event, including the target path (<xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.Path>) and the cancellation token (<xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken>):

* The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.Path> property is the user's destination path relative to the app's base path, such as `/robot`.
* The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> can be used to observe the cancellation of the asynchronous task. <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> automatically cancels the currently running navigation task when the user navigates to a different page.

Inside `OnNavigateAsync`, implement logic to determine the assemblies to load. Options include:

* Conditional checks inside the `OnNavigateAsync` method.
* A lookup table that maps routes to assembly names, either injected into the component or implemented within the [`@code`](xref:mvc/views/razor#code) block.

<xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> is a framework-provided singleton service for loading assemblies. Inject <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> into the <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The assembly loader service is in the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services?displayProperty=fullName> namespace:

```razor
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@inject LazyAssemblyLoader assemblyLoader
```

The <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> provides the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader.LoadAssembliesAsync%2A> method that:

* Uses [JS interop](xref:blazor/js-interop/call-dotnet-from-javascript) to fetch assemblies via a network call.
* Loads assemblies into the runtime executing on WebAssembly in the browser.

The framework's lazy loading implementation supports lazy loading with prerendering in a hosted Blazor solution. During prerendering, all assemblies, including those marked for lazy loading, are assumed to be loaded. Manually register <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> in the **`Server`** project's `Startup.ConfigureServices` method (`Startup.cs`):

```csharp
services.AddScoped<LazyAssemblyLoader>();
```

### User interaction with `<Navigating>` content

While loading assemblies, which can take several seconds, the <xref:Microsoft.AspNetCore.Components.Routing.Router> component can indicate to the user that a page transition is occurring:

* Add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Components.Routing?displayProperty=fullName> namespace.
* Add a `<Navigating>` tag to the component with markup to display during page transition events.

```razor
...
@using Microsoft.AspNetCore.Components.Routing

<Router ...>
    <Navigating>
        <div style="...">
            <p>Loading the requested page&hellip;</p>
        </div>
    </Navigating>
</Router>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

### Handle cancellations in `OnNavigateAsync`

The <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> object passed to the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback contains a <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext.CancellationToken> that's set when a new navigation event occurs. The <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback must throw when this cancellation token is set to avoid continuing to run the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback on a outdated navigation.

If a user navigates to Route A and then immediately to Route B, the app shouldn't continue running the <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback for Route A:

```razor
@inject HttpClient Http
@inject ProductCatalog Products

<Router AppAssembly="@typeof(Program).Assembly" 
    OnNavigateAsync="@OnNavigateAsync">
    ...
</Router>

@code {
    private async Task OnNavigateAsync(NavigationContext context)
    {
        if (context.Path == "/about") 
        {
            var stats = new Stats = { Page = "/about" };
            await Http.PostAsJsonAsync("api/visited", stats, context.CancellationToken);
        }
        else if (context.Path == "/store")
        {
            var productIds = [345, 789, 135, 689];

            foreach (var productId in productIds) 
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                Products.Prefetch(productId);
            }
        }
    }
}
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

> [!NOTE]
> Not throwing if the cancellation token in <xref:Microsoft.AspNetCore.Components.Routing.NavigationContext> is canceled can result in unintended behavior, such as rendering a component from a previous navigation.

### `OnNavigateAsync` events and renamed assembly files

The resource loader relies on the assembly names that are defined in the `blazor.boot.json` file. If [assemblies are renamed](xref:blazor/host-and-deploy/webassembly#change-the-filename-extension-of-dll-files), the assembly names used in an <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback and the assembly names in the `blazor.boot.json` file are out of sync.

To rectify this:

* Check to see if the app is running in the `Production` environment when determining which assembly names to use.
* Store the renamed assembly names in a separate file and read from that file to determine what assembly name to use in the <xref:Microsoft.AspNetCore.Components.WebAssembly.Services.LazyAssemblyLoader> service and <xref:Microsoft.AspNetCore.Components.Routing.Router.OnNavigateAsync> callback methods.

### Complete example

The following complete <xref:Microsoft.AspNetCore.Components.Routing.Router> component demonstrates loading the `GrantImaharaRobotControls.dll` assembly when the user navigates to `/robot`. During page transitions, a styled message is displayed to the user.

`App.razor`:

::: moniker range=">= aspnetcore-5.0"

```razor
@using System.Reflection
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@using Microsoft.Extensions.Logging
@inject LazyAssemblyLoader assemblyLoader
@inject ILogger<App> Logger

<Router AppAssembly="@typeof(Program).Assembly"
        AdditionalAssemblies="@lazyLoadedAssemblies" 
        OnNavigateAsync="@OnNavigateAsync">
    <Navigating>
        <div style="padding:20px;background-color:blue;color:white">
            <p>Loading the requested page&hellip;</p>
        </div>
    </Navigating>
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>

@code {
    private List<Assembly> lazyLoadedAssemblies = new();

    private async Task OnNavigateAsync(NavigationContext args)
    {
        try
        {
            if (args.Path.EndsWith("/robot"))
            {
                var assemblies = await assemblyLoader.LoadAssembliesAsync(
                    new List<string>() { "GrantImaharaRobotControls.dll" });
                lazyLoadedAssemblies.AddRange(assemblies);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error: {Message}", ex.Message);
        }
    }
}
```

::: moniker-end

::: moniker range="< aspnetcore-5.0"

```razor
@using System.Reflection
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@using Microsoft.Extensions.Logging
@inject LazyAssemblyLoader assemblyLoader
@inject ILogger<App> Logger

<Router AppAssembly="@typeof(Program).Assembly"
        AdditionalAssemblies="@lazyLoadedAssemblies" 
        OnNavigateAsync="@OnNavigateAsync">
    <Navigating>
        <div style="padding:20px;background-color:blue;color:white">
            <p>Loading the requested page&hellip;</p>
        </div>
    </Navigating>
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>

@code {
    private List<Assembly> lazyLoadedAssemblies = new List<Assembly>();

    private async Task OnNavigateAsync(NavigationContext args)
    {
        try
        {
            if (args.Path.EndsWith("/robot"))
            {
                var assemblies = await assemblyLoader.LoadAssembliesAsync(
                    new List<string>() { "GrantImaharaRobotControls.dll" });
                lazyLoadedAssemblies.AddRange(assemblies);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError("Error: {Message}", ex.Message);
        }
    }
}
```

::: moniker-end

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

## Troubleshoot

* If unexpected rendering occurs, such as rendering a component from a previous navigation, confirm that the code throws if the cancellation token is set.
* If assemblies configured for lazy loading unexpectedly load at app start, check that the assembly is marked for lazy loading in the project file.

## Additional resources

* <xref:blazor/webassembly-performance-best-practices>
