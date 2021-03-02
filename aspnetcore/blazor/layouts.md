---
title: ASP.NET Core Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/02/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/layouts
---
# ASP.NET Core Blazor layouts

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall presentation and rendered by many components. Placing a copy of the markup for these elements into all of the components of an app isn't an efficient approach. Every time that an element requires an update, every component that uses the element must be updated. Such duplication is difficult to maintain and can lead to inconsistent content over time. *Layouts* solve this problem.

A Blazor layout is a Razor component that shares markup with components that reference it. Layouts can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other features of components.

## Layout components

### Create a layout component

To create a layout component:

* Create a Razor component defined by a Razor template or C# code.
* Inherit the component from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>. The <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property (<xref:Microsoft.AspNetCore.Components.RenderFragment> type) for the rendered content inside the layout.
* Use the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

Because layout components are shared across an app's components, they're usually placed in the app's `Shared` folder. However, layouts can be placed in any location accessible to the components that use it. For example, a layout can be placed in the same folder as the components that use it.

The following `DoctorWhoLayout` component shows the Razor template of a layout component. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar (`<nav>...</nav>`) and the footer (`<footer>...</footer>`).

`Shared/DoctorWhoLayout.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout.razor?highlight=1,13)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout.razor?highlight=1,13)]

::: moniker-end

### `MainLayout` component

In an app created from a [Blazor project template](xref:blazor/project-structure), the `MainLayout` component is the app's [default layout](#apply-a-default-layout-to-an-app).

`Shared/MainLayout.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/layouts/MainLayout.razor)]

[Blazor's CSS isolation feature](xref:blazor/components/css-isolation) applies isolated CSS styles to the `MainLayout` component. The styles are provided by the accompanying stylesheet, `Shared/MainLayout.razor.css`. The ASP.NET Core implementation of the stylesheet is available for inspection in the [ASP.NET Core reference source (dotnet/aspnetcore GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/MainLayout.razor.css).

[!INCLUDE[](~/blazor/includes/aspnetcore-repo-ref-source-links.md)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/layouts/MainLayout.razor)]

::: moniker-end

## Apply a layout

### Apply a default layout to an app

Specify the default app layout in the in the `App` component's <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The following example from an app based on a [Blazor project template](xref:blazor/project-structure) sets the default layout to the `MainLayout` component.

`App.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/layouts/App1.razor?highlight=3)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/layouts/App1.razor?highlight=3)]

::: moniker-end

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the router is a useful practice because it can be overridden on a per-component or per-folder basis. We recommend using the `Router` component to set the app's default layout because it's the most general and flexible approach for using layouts.

### Apply a layout to a folder of components

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout DoctorWhoLayout` ensures that all of the components in a folder use the `DoctorWhoLayout` component. There's no need to repeatedly add `@layout DoctorWhoLayout` to all of the Razor components (`.razor`) within the folder and subfolders.

`_Imports.razor`:

```razor
@layout DoctorWhoLayout
...
```

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's *default layout*.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts. To control the default app layout, specify the layout in the `Router` component. For more information, see the [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section.

> [!NOTE]
> The [`@layout`](xref:mvc/views/razor#layout) Razor directive only applies a layout to routable Razor components with [`@page`](xref:mvc/views/razor#page) directives.

### Apply a layout to arbitrary content (`LayoutView` component)

To set a layout for arbitrary Razor template content, specify the layout with a <xref:Microsoft.AspNetCore.Components.LayoutView> component. The following example sets a layout component named `ErrorLayout` for the `MainLayout` component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template (`<NotFound>...</NotFound>`).

`App.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/layouts/App2.razor?name=snippet&highlight=6,9)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/layouts/App2.razor?name=snippet&highlight=6,9)]

::: moniker-end

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

### Apply a layout to a component

Use the [`@layout`](xref:mvc/views/razor#layout) Razor directive to apply a layout to a routable Razor component that has an [`@page`](xref:mvc/views/razor#page) directive. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute>, which is applied to the component class.

Specifying the layout directly in a component overrides a *default layout*:

* Set as the app's default layout, as described in the [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section of this article.
* Set by an `@layout` directive imported from an `_Imports` component (`_Imports.razor`), as described in the [Apply a layout to a folder of components](#apply-a-layout-to-a-folder-of-components) section of this article.

The content of the following `Episodes` component is inserted into the `DoctorWhoLayout` at the position of `@Body`.

`Pages/Episodes.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/layouts/Episodes.razor?highlight=2)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Pages/layouts/Episodes.razor?highlight=2)]

::: moniker-end

The following rendered HTML markup is produced by the preceding `DoctorWhoLayout` and `Episodes` component. Extraneous markup doesn't appear in order to focus on the content provided by the two components involved:

* The **Doctor Who&trade; Episode Database** heading (`<h1>...</h1>`) in the header (`<header>...</header>`), navigation bar (`<nav>...</nav>`), and trademark information element (`<div>...</div>`) in the footer (`<footer>...</footer>`) come from the `DoctorWhoLayout` component.
* The **Episodes** heading (`<h2>...</h2>`) and episode list (`<ul>...</ul>`) come from the `Episodes` component.

```html
<body>
    <div id="app">
        <header>
            <h1>Doctor Who™ Episode Database</h1>
        </header>

        <nav>
            <a href="masterlist">Master Episode List</a>
            <a href="search">Search</a>
            <a href="new">Add Episode</a>
        </nav>

        <h2>Episodes</h2>

        <ul>
            <li>...</li>
            <li>...</li>
            <li>...</li>
        </ul>

        <footer>
            Doctor Who is a registered trademark of the BBC. 
            https://www.doctorwho.tv/
        </footer>
    </div>
</body>
```

## Nested layouts

A component can reference a layout that in turn references another layout. For example, nested layouts are used to create a multi-level menu structures.

The following example shows how to use nested layouts. The `Episodes` component shown in the [Apply a layout to a component](#apply-a-layout-to-a-component) section is the component to display. The component references the `DoctorWhoLayout` component.

The following `DoctorWhoLayout` component is a modified version of the example shown at the top of this article, where the header and footer elements are removed. The following revised `DoctorWhoLayout` component references another layout, `ProductionsLayout`, where it's rendered. The `Episodes` component is rendered where `@Body` appears.

`Shared/DoctorWhoLayout.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout2.razor?highlight=2,12)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout2.razor?highlight=2,12)]

::: moniker-end

The `ProductionsLayout` component contains the top-level layout elements, where the header (`<header>...</header>`) and footer (`<footer>...</footer>`) elements now reside. The `DoctorWhoLayout` with the `Episodes` component is rendered where `@Body` appears.

`Shared/ProductionsLayout.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/layouts/ProductionsLayout.razor?highlight=13)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/layouts/ProductionsLayout.razor?highlight=13)]

::: moniker-end

The following rendered HTML markup is produced by the preceding nested layout. Extraneous markup doesn't appear in order to focus on the nested content provided by the three components involved:

* The header (`<header>...</header>`), production navigation bar (`<nav>...</nav>`), and footer (`<footer>...</footer>`) elements and their content come from the `ProductionsLayout` component.
* The **Doctor Who&trade; Episode Database** heading (`<h1>...</h1>`), episode navigation bar (`<nav>...</nav>`), and trademark information element (`<div>...</div>`) come from the `DoctorWhoLayout` component.
* The **Episodes** heading (`<h2>...</h2>`) and episode list (`<ul>...</ul>`) come from the `Episodes` component.

```html
<body>
    <div id="app">
        <header>
            <h1>Productions</h1>
        </header>

        <nav>
            <a href="master-production-list">Master Production List</a>
            <a href="production-search">Search</a>
            <a href="new-production">Add Production</a>
        </nav>

        <h1>Doctor Who™ Episode Database</h1>

        <nav>
            <a href="episode-masterlist">Master Episode List</a>
            <a href="episode-search">Search</a>
            <a href="new-episode">Add Episode</a>
        </nav>

        <h2>Episodes</h2>

        <ul>
            <li>...</li>
            <li>...</li>
            <li>...</li>
        </ul>

        <div>
            Doctor Who is a registered trademark of the BBC. 
            https://www.doctorwho.tv/
        </div>

        <footer>
            Footer of Productions Layout
        </footer>
    </div>
</body>
```

## Share a Razor Pages layout with integrated components

When routable components are integrated into a Razor Pages app, the app's shared layout can be used with the components. For more information, see <xref:blazor/components/prerendering-and-integration>.

## Additional resources

* <xref:mvc/views/layout>
