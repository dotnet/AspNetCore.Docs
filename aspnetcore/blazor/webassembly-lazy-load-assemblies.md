---
title: Lazy load assemblies in ASP.NET Core Blazor WebAssembly
author: guardrex
description: Discover how to lazy load assemblies in ASP.NET Core Blazor WebAssembly apps.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/15/2020
no-loc: [Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/webassembly-lazy-load-assemblies
---
# Lazy load assemblies in ASP.NET Core Blazor WebAssembly

By [Safia Abdalla](https://safia.rocks) and [Luke Latham](https://github.com/guardrex)

Blazor WebAssembly app startup performance can be improved by dynamically loading assets at runtime when the assets are required, which is called *lazy loading*. For example, assemblies that are only used to render a single component can be set up to load only if the user navigates to that component. After loading, the assemblies are cached client-side and don't require reloading while the app is running.

> [!NOTE]
> Assembly lazy loading doesn't benefit Blazor Server apps because assemblies aren't downloaded to the client in a Blazor Server app.

## Project file

Mark assemblies for lazy loading in the app's project file (`.csproj`) using the `BlazorWebAssemblyLazyLoad` item. The Blazor framework prevents the assemblies from loading at app launch. The following example marks a large custom assembly (`IonControlAdmin.dll`) for lazy loading. Add a separate `BlazorWebAssemblyLazyLoad` item for each assembly.

```xml
<ItemGroup>
  <BlazorWebAssemblyLazyLoad Include="IonControlAdmin.dll" />
</ItemGroup>
```

Only assemblies that are used by the app can be lazily loaded. The linker strips unused assemblies from published output.

## `Router` component

Code in the `Router` component determines when the assemblies marked for lazy loading are loaded.

In the app's `Router` component (`App.razor`):

* Add an `OnNavigateAsync` callback. The `OnNavigateAsync` handler is invoked when the user visits a route for the first time or navigates to a new route.
* Add a [List](xref:System.Collections.Generic.List%601)\<<xref:System.Reflection.Assembly>> (for example, named `lazyLoadedAssemblies`) to the component. The assemblies are passed back to the <xref:Microsoft.AspNetCore.Components.Routing.Router.AdditionalAssemblies> collection in case the assemblies contain routable components. The framework searches the assemblies for routes and updates the route collection if any new routes are found.

```razor
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

### Assembly load logic in `OnNavigateAsync`

`OnNavigateAsync` has a `NavigationContext` parameter that provides information about the current asynchronous navigation event, including the target path (`Path`) and the cancellation token (`CancellationToken`):

* The `Path` property is the user's destination path relative to the app's base path, such as `/admin/ioncontrol`.
* The `CancellationToken` can be used to observe the cancellation of the asynchronous task. `OnNavigateAsync` automatically cancels the currently running navigation task when the user navigates away from a page.

Inside `OnNavigateAsync`, implement logic to determine the assemblies to load. Options include:

* Conditional checks inside the `OnNavigateAsync` method.
* A lookup table that maps routes to assembly names, either injected into the component or implemented within the [`@code`](xref:mvc/views/razor#code) block.

`LazyAssemblyLoader` is a framework-provided singleton service for loading assemblies. Inject `LazyAssemblyLoader` into the `Router` component:

```razor
...
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@inject LazyAssemblyLoader assemblyLoader

...
```

The `LazyAssemblyLoader` provides the `LoadAssembliesAsync` method that:

* Uses JS interop to fetch assemblies via a network call.
* Loads assemblies into the runtime executing on WASM in the browser.

> [!NOTE]
> The framework's lazy loading implementation supports prerendering on the server. During prerendering, all assemblies, including those marked for lazy loading, are assumed to be loaded.

### User interaction with `<Navigating>` content

While loading assemblies, which can take several seconds, the `Router` component can indicate to the user that a page transition is occurring:

* Add an [`@using`](xref:mvc/views/razor#using) directive for the <xref:Microsoft.AspNetCore.Components.Routing?displayProperty=fullName> namespace.
* Add a `<Navigating>` tag to the component with markup to display during page transition events.

```razor
...
@using Microsoft.AspNetCore.Components.Routing
...

<Router ...>
    <Navigating>
        <div style="...">
            <p>Loading the requested page&hellip;</p>
        </div>
    </Navigating>
</Router>

...
```

### Complete example

The following complete `Router` component demonstrates loading the `IonControlAdmin.dll` assembly when the user navigates to `/admin/ioncontrol`. During page transitions, a styled message is displayed to the user.

```razor
@using System.Reflection
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.WebAssembly.Services
@inject LazyAssemblyLoader assemblyLoader

<Router AppAssembly="@typeof(Program).Assembly" 
    AdditionalAssemblies="@lazyLoadedAssemblies" OnNavigateAsync="@OnNavigateAsync">
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
            if (args.Path.EndsWith("/admin/ioncontrol"))
            {
                var assemblies = await assemblyLoader.LoadAssembliesAsync(
                    new List<string>() { "IonControlAdmin.dll" });
                lazyLoadedAssemblies.AddRange(assemblies);
            }
        }
        catch (Exception ex)
        {
            ...
        }
    }
}
```

## Additional resources

* <xref:blazor/webassembly-performance-best-practices>
