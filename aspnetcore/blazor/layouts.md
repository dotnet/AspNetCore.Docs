---
title: ASP.NET Core Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/26/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/layouts
---
# ASP.NET Core Blazor layouts

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall layout and used by every component in the app. Copying the code of these elements into all of the components of an app isn't an efficient approach. Every time one of the elements requires an update, every component must be updated. Such duplication is difficult to maintain and can lead to inconsistent content over time. *Layouts* solve this problem.

A layout is a routable Razor component that can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other features of components.

To create a layout component:

<!-- 
Clarify C# component scenario created from ComponentBase. [`@page`](xref:mvc/views/razor#page) directive for Razor template-based components.
-->

* Create a routable Razor component defined by a Razor template or C# code.
* Inherit the component from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>. The <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property for the rendered content inside the layout.
* Use the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

Because layout components are shared across an app's components, they're usually placed in the app's `Shared` folder. However, layouts can be placed in any location accessible to the components that use it.

The following `EpisodeLayout` example shows the Razor template of a layout component. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar and the footer.

`Shared/EpisodeLayout.razor`:

```razor
@inherits LayoutComponentBase

<header>
    <h1>Doctor Who&trade; Episode Database</h1>
</header>

<nav>
    <a href="masterlist">Master Episode List</a>
    <a href="search">Search</a>
    <a href="new">Add Episode</a>
</nav>

@Body

<footer>
    @TrademarkMessage
</footer>

@code {
    public string TrademarkMessage { get; set; } = 
        "Doctor Who is a registered trademark of the BBC. " +
        "https://www.doctorwho.tv/";
}
```

## `MainLayout` component

In an app based on one of the Blazor project templates, the `MainLayout` component is in the app's `Shared` folder.

`Shared/MainLayout.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](./common/samples/5.x/BlazorWebAssemblySample/Shared/MainLayout.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](./common/samples/3.x/BlazorWebAssemblySample/Shared/MainLayout.razor)]

::: moniker-end

## Default layout

Specify the default app layout in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component in the `App` component. The following example sets the default layout to the `MainLayout` component.

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <p>Sorry, there's nothing at this address.</p>
    </NotFound>
</Router>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

To supply a default layout for <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, specify a <xref:Microsoft.AspNetCore.Components.LayoutView> for <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content (`<NotFound>...</NotFound>`).

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(MainLayout)">
            <h1>Page not found</h1>
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the router is a useful practice because it can be overridden on a per-component or per-folder basis. Prefer using the router to set the app's default layout because it's the most general and flexible approach for using layouts.

## Specify a layout in a component

Use the [`@layout`](xref:mvc/views/razor#layout) Razor directive to apply a layout to a routable Razor component that also has an [`@page`](xref:mvc/views/razor#page) directive. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute>, which is applied to the component class.

The content of the following `MasterList` component is inserted into the `MasterLayout` at the position of `@Body`.

`Pages/MasterList.razor`:

```razor
@page "/masterlist"
@layout MasterLayout

<h1>Master Episode List</h1>
```

Specifying the layout directly in a component overrides a *default layout* set in the router or an `@layout` directive imported from an `_Imports` component (`_Imports.razor`).

## Centralized layout selection

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout CoolLayout` ensures that all of the components in a folder use `CoolLayout`. There's no need to repeatedly add `@layout CoolLayout` to all of the components (`.razor`) within the folder and subfolders. `@using` directives are also applied to components in the same way.

The following `_Imports.razor` file imports:

* `CoolLayout`.
* All Razor components in the same folder and any subfolders.
* The `BlazorSample.Data` namespace.

`_Imports.razor`:

```razor
@layout CoolLayout
@using Microsoft.AspNetCore.Components
@using BlazorSample.Data
```

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's *default layout*.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts. To control the default app layout, specify the layout in the `Router` component. For more information, see the [Default layout](#default-layout) section.

> [!NOTE]
> The [`@layout`](xref:mvc/views/razor#layout) Razor directive only applies a layout to routable Razor components with [`@page`](xref:mvc/views/razor#page) directives.

## Nested layouts

Nested layouts are supported. A component can reference a layout that in turn references another layout. For example, nesting layouts are used to create a multi-level menu structure.

The following example shows how to use nested layouts. The `EpisodesComponent.razor` file is the component to display. The component references the `MasterListLayout`.

`Pages/EpisodesComponent.razor`:

```razor
@page "/masterlist/episodes"
@layout MasterListLayout

<h1>Episodes</h1>
```

The `MasterListLayout` component references another layout, `MasterLayout`, where it's rendered. `EpisodesComponent` is rendered where `@Body` appears.

`Shared/MasterListLayout.razor`:

```razor
@layout MasterLayout
@inherits LayoutComponentBase

<nav>
    <!-- Menu structure of master list -->
    ...
</nav>

@Body
```

Finally, `MasterLayout` contains the top-level layout elements, such as the header, main menu, and footer. `MasterListLayout` with its `EpisodesComponent` is rendered where `@Body` appears.

`Shared/MasterLayout.razor`:

```razor
@layout MasterLayout
@inherits LayoutComponentBase

<nav>
    <!-- Menu structure of master list -->
    ...
</nav>

@Body
```

## Share a Razor Pages layout with integrated components

When routable components are integrated into a Razor Pages app, the app's shared layout can be used with the components. For more information, see <xref:blazor/components/prerendering-and-integration>.

## Additional resources

* <xref:mvc/views/layout>
