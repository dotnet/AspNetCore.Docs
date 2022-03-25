---
title: ASP.NET Core Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/layouts
---
# ASP.NET Core Blazor layouts

This article explains how to create reusable layout components for Blazor apps.

:::moniker range=">= aspnetcore-6.0"

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall presentation. Placing a copy of the markup for these elements into all of the components of an app isn't efficient. Every time that one of these elements is updated, every component that uses the element must be updated. This approach is costly to maintain and can lead to inconsistent content if an update is missed. *Layouts* solve these problems.

A Blazor layout is a Razor component that shares markup with components that reference it. Layouts can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other features of components.

## Layout components

### Create a layout component

To create a layout component:

* Create a Razor component defined by a Razor template or C# code. Layout components based on a Razor template use the `.razor` file extension just like ordinary Razor components. Because layout components are shared across an app's components, they're usually placed in the app's `Shared` folder. However, layouts can be placed in any location accessible to the components that use it. For example, a layout can be placed in the same folder as the components that use it.
* Inherit the component from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>. The <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property (<xref:Microsoft.AspNetCore.Components.RenderFragment> type) for the rendered content inside the layout.
* Use the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

The following `DoctorWhoLayout` component shows the Razor template of a layout component. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar (`<nav>...</nav>`) and the footer (`<footer>...</footer>`).

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout.razor?highlight=1,13)]

### `MainLayout` component

In an app created from a [Blazor project template](xref:blazor/project-structure), the `MainLayout` component is the app's [default layout](#apply-a-default-layout-to-an-app).

`Shared/MainLayout.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/layouts/MainLayout.razor)]

[Blazor's CSS isolation feature](xref:blazor/components/css-isolation) applies isolated CSS styles to the `MainLayout` component. By convention, the styles are provided by the accompanying stylesheet of the same name, `Shared/MainLayout.razor.css`. The ASP.NET Core framework implementation of the stylesheet is available for inspection in the [ASP.NET Core reference source (dotnet/aspnetcore GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/MainLayout.razor.css).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Apply a layout

### Apply a layout to a component

Use the [`@layout`](xref:mvc/views/razor#layout) Razor directive to apply a layout to a routable Razor component that has an [`@page`](xref:mvc/views/razor#page) directive. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute> and applies the attribute to the component class.

The content of the following `Episodes` component is inserted into the `DoctorWhoLayout` at the position of `@Body`.

`Pages/Episodes.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/layouts/Episodes.razor?highlight=2)]

The following rendered HTML markup is produced by the preceding `DoctorWhoLayout` and `Episodes` component. Extraneous markup doesn't appear in order to focus on the content provided by the two components involved:

* The **Doctor Who&trade; Episode Database** heading (`<h1>...</h1>`) in the header (`<header>...</header>`), navigation bar (`<nav>...</nav>`), and trademark information element (`<div>...</div>`) in the footer (`<footer>...</footer>`) come from the `DoctorWhoLayout` component.
* The **Episodes** heading (`<h2>...</h2>`) and episode list (`<ul>...</ul>`) come from the `Episodes` component.

```html
<body>
    <div id="app">
        <header>
            <h1>Doctor Who&trade; Episode Database</h1>
        </header>

        <nav>
            <a href="main-list">Main Episode List</a>
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

Specifying the layout directly in a component overrides a *default layout*:

* Set by an `@layout` directive imported from an `_Imports` component (`_Imports.razor`), as described in the following [Apply a layout to a folder of components](#apply-a-layout-to-a-folder-of-components) section.
* Set as the app's default layout, as described in the [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section later in this article.

### Apply a layout to a folder of components

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout DoctorWhoLayout` ensures that all of the components in a folder use the `DoctorWhoLayout` component. There's no need to repeatedly add `@layout DoctorWhoLayout` to all of the Razor components (`.razor`) within the folder and subfolders.

`_Imports.razor`:

```razor
@layout DoctorWhoLayout
...
```

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's [default app layout](#apply-a-default-layout-to-an-app), which is described in the following section.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts. To control the default app layout, specify the layout in the `Router` component. For more information, see the following [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section.

> [!NOTE]
> The [`@layout`](xref:mvc/views/razor#layout) Razor directive only applies a layout to routable Razor components with an [`@page`](xref:mvc/views/razor#page) directive.

### Apply a default layout to an app

Specify the default app layout in the `App` component's <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The following example from an app based on a [Blazor project template](xref:blazor/project-structure) sets the default layout to the `MainLayout` component.

`App.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/layouts/App1.razor?highlight=3)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the `Router` component is a useful practice because you can override the layout on a per-component or per-folder basis, as described in the preceding sections of this article. We recommend using the `Router` component to set the app's default layout because it's the most general and flexible approach for using layouts.

### Apply a layout to arbitrary content (`LayoutView` component)

To set a layout for arbitrary Razor template content, specify the layout with a <xref:Microsoft.AspNetCore.Components.LayoutView> component. You can use a <xref:Microsoft.AspNetCore.Components.LayoutView> in any Razor component. The following example sets a layout component named `ErrorLayout` for the `MainLayout` component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template (`<NotFound>...</NotFound>`).

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(ErrorLayout)">
            <h1>Page not found</h1>
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

## Nested layouts

A component can reference a layout that in turn references another layout. For example, nested layouts are used to create a multi-level menu structures.

The following example shows how to use nested layouts. The `Episodes` component shown in the [Apply a layout to a component](#apply-a-layout-to-a-component) section is the component to display. The component references the `DoctorWhoLayout` component.

The following `DoctorWhoLayout` component is a modified version of the example shown earlier in this article. The header and footer elements are removed, and the layout references another layout, `ProductionsLayout`. The `Episodes` component is rendered where `@Body` appears in the `DoctorWhoLayout`.

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout2.razor?highlight=2,12)]

The `ProductionsLayout` component contains the top-level layout elements, where the header (`<header>...</header>`) and footer (`<footer>...</footer>`) elements now reside. The `DoctorWhoLayout` with the `Episodes` component is rendered where `@Body` appears.

`Shared/ProductionsLayout.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/layouts/ProductionsLayout.razor?highlight=13)]

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
            <a href="main-production-list">Main Production List</a>
            <a href="production-search">Search</a>
            <a href="new-production">Add Production</a>
        </nav>

        <h1>Doctor Who&trade; Episode Database</h1>

        <nav>
            <a href="episode-main-list">Main Episode List</a>
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

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall presentation. Placing a copy of the markup for these elements into all of the components of an app isn't efficient. Every time that one of these elements is updated, every component that uses the element must be updated. This approach is costly to maintain and can lead to inconsistent content if an update is missed. *Layouts* solve these problems.

A Blazor layout is a Razor component that shares markup with components that reference it. Layouts can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other features of components.

## Layout components

### Create a layout component

To create a layout component:

* Create a Razor component defined by a Razor template or C# code. Layout components based on a Razor template use the `.razor` file extension just like ordinary Razor components. Because layout components are shared across an app's components, they're usually placed in the app's `Shared` folder. However, layouts can be placed in any location accessible to the components that use it. For example, a layout can be placed in the same folder as the components that use it.
* Inherit the component from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>. The <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property (<xref:Microsoft.AspNetCore.Components.RenderFragment> type) for the rendered content inside the layout.
* Use the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

The following `DoctorWhoLayout` component shows the Razor template of a layout component. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar (`<nav>...</nav>`) and the footer (`<footer>...</footer>`).

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout.razor?highlight=1,13)]

### `MainLayout` component

In an app created from a [Blazor project template](xref:blazor/project-structure), the `MainLayout` component is the app's [default layout](#apply-a-default-layout-to-an-app).

`Shared/MainLayout.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/layouts/MainLayout.razor)]

[Blazor's CSS isolation feature](xref:blazor/components/css-isolation) applies isolated CSS styles to the `MainLayout` component. By convention, the styles are provided by the accompanying stylesheet of the same name, `Shared/MainLayout.razor.css`. The ASP.NET Core framework implementation of the stylesheet is available for inspection in the [ASP.NET Core reference source (dotnet/aspnetcore GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/ProjectTemplates/Web.ProjectTemplates/content/ComponentsWebAssembly-CSharp/Client/Shared/MainLayout.razor.css).

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Apply a layout

### Apply a layout to a component

Use the [`@layout`](xref:mvc/views/razor#layout) Razor directive to apply a layout to a routable Razor component that has an [`@page`](xref:mvc/views/razor#page) directive. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute> and applies the attribute to the component class.

The content of the following `Episodes` component is inserted into the `DoctorWhoLayout` at the position of `@Body`.

`Pages/Episodes.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/layouts/Episodes.razor?highlight=2)]

The following rendered HTML markup is produced by the preceding `DoctorWhoLayout` and `Episodes` component. Extraneous markup doesn't appear in order to focus on the content provided by the two components involved:

* The **Doctor Who&trade; Episode Database** heading (`<h1>...</h1>`) in the header (`<header>...</header>`), navigation bar (`<nav>...</nav>`), and trademark information element (`<div>...</div>`) in the footer (`<footer>...</footer>`) come from the `DoctorWhoLayout` component.
* The **Episodes** heading (`<h2>...</h2>`) and episode list (`<ul>...</ul>`) come from the `Episodes` component.

```html
<body>
    <div id="app">
        <header>
            <h1>Doctor Who&trade; Episode Database</h1>
        </header>

        <nav>
            <a href="main-list">Main Episode List</a>
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

Specifying the layout directly in a component overrides a *default layout*:

* Set by an `@layout` directive imported from an `_Imports` component (`_Imports.razor`), as described in the following [Apply a layout to a folder of components](#apply-a-layout-to-a-folder-of-components) section.
* Set as the app's default layout, as described in the [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section later in this article.

### Apply a layout to a folder of components

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout DoctorWhoLayout` ensures that all of the components in a folder use the `DoctorWhoLayout` component. There's no need to repeatedly add `@layout DoctorWhoLayout` to all of the Razor components (`.razor`) within the folder and subfolders.

`_Imports.razor`:

```razor
@layout DoctorWhoLayout
...
```

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's [default app layout](#apply-a-default-layout-to-an-app), which is described in the following section.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts. To control the default app layout, specify the layout in the `Router` component. For more information, see the following [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section.

> [!NOTE]
> The [`@layout`](xref:mvc/views/razor#layout) Razor directive only applies a layout to routable Razor components with an [`@page`](xref:mvc/views/razor#page) directive.

### Apply a default layout to an app

Specify the default app layout in the `App` component's <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The following example from an app based on a [Blazor project template](xref:blazor/project-structure) sets the default layout to the `MainLayout` component.

`App.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/layouts/App1.razor?highlight=3)]

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the `Router` component is a useful practice because you can override the layout on a per-component or per-folder basis, as described in the preceding sections of this article. We recommend using the `Router` component to set the app's default layout because it's the most general and flexible approach for using layouts.

### Apply a layout to arbitrary content (`LayoutView` component)

To set a layout for arbitrary Razor template content, specify the layout with a <xref:Microsoft.AspNetCore.Components.LayoutView> component. You can use a <xref:Microsoft.AspNetCore.Components.LayoutView> in any Razor component. The following example sets a layout component named `ErrorLayout` for the `MainLayout` component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template (`<NotFound>...</NotFound>`).

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(ErrorLayout)">
            <h1>Page not found</h1>
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

[!INCLUDE[](~/blazor/includes/prefer-exact-matches.md)]

## Nested layouts

A component can reference a layout that in turn references another layout. For example, nested layouts are used to create a multi-level menu structures.

The following example shows how to use nested layouts. The `Episodes` component shown in the [Apply a layout to a component](#apply-a-layout-to-a-component) section is the component to display. The component references the `DoctorWhoLayout` component.

The following `DoctorWhoLayout` component is a modified version of the example shown earlier in this article. The header and footer elements are removed, and the layout references another layout, `ProductionsLayout`. The `Episodes` component is rendered where `@Body` appears in the `DoctorWhoLayout`.

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout2.razor?highlight=2,12)]

The `ProductionsLayout` component contains the top-level layout elements, where the header (`<header>...</header>`) and footer (`<footer>...</footer>`) elements now reside. The `DoctorWhoLayout` with the `Episodes` component is rendered where `@Body` appears.

`Shared/ProductionsLayout.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/layouts/ProductionsLayout.razor?highlight=13)]

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
            <a href="main-production-list">Main Production List</a>
            <a href="production-search">Search</a>
            <a href="new-production">Add Production</a>
        </nav>

        <h1>Doctor Who&trade; Episode Database</h1>

        <nav>
            <a href="episode-main-list">Main Episode List</a>
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

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall presentation. Placing a copy of the markup for these elements into all of the components of an app isn't efficient. Every time that one of these elements is updated, every component that uses the element must be updated. This approach is costly to maintain and can lead to inconsistent content if an update is missed. *Layouts* solve these problems.

A Blazor layout is a Razor component that shares markup with components that reference it. Layouts can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other features of components.

## Layout components

### Create a layout component

To create a layout component:

* Create a Razor component defined by a Razor template or C# code. Layout components based on a Razor template use the `.razor` file extension just like ordinary Razor components. Because layout components are shared across an app's components, they're usually placed in the app's `Shared` folder. However, layouts can be placed in any location accessible to the components that use it. For example, a layout can be placed in the same folder as the components that use it.
* Inherit the component from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>. The <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property (<xref:Microsoft.AspNetCore.Components.RenderFragment> type) for the rendered content inside the layout.
* Use the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

The following `DoctorWhoLayout` component shows the Razor template of a layout component. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar (`<nav>...</nav>`) and the footer (`<footer>...</footer>`).

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout.razor?highlight=1,13)]

### `MainLayout` component

In an app created from a [Blazor project template](xref:blazor/project-structure), the `MainLayout` component is the app's [default layout](#apply-a-default-layout-to-an-app).

`Shared/MainLayout.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/layouts/MainLayout.razor)]

## Apply a layout

### Apply a layout to a component

Use the [`@layout`](xref:mvc/views/razor#layout) Razor directive to apply a layout to a routable Razor component that has an [`@page`](xref:mvc/views/razor#page) directive. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute> and applies the attribute to the component class.

The content of the following `Episodes` component is inserted into the `DoctorWhoLayout` at the position of `@Body`.

`Pages/Episodes.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/layouts/Episodes.razor?highlight=2)]

The following rendered HTML markup is produced by the preceding `DoctorWhoLayout` and `Episodes` component. Extraneous markup doesn't appear in order to focus on the content provided by the two components involved:

* The **Doctor Who&trade; Episode Database** heading (`<h1>...</h1>`) in the header (`<header>...</header>`), navigation bar (`<nav>...</nav>`), and trademark information element (`<div>...</div>`) in the footer (`<footer>...</footer>`) come from the `DoctorWhoLayout` component.
* The **Episodes** heading (`<h2>...</h2>`) and episode list (`<ul>...</ul>`) come from the `Episodes` component.

```html
<body>
    <div id="app">
        <header>
            <h1>Doctor Who&trade; Episode Database</h1>
        </header>

        <nav>
            <a href="main-list">Main Episode List</a>
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

Specifying the layout directly in a component overrides a *default layout*:

* Set by an `@layout` directive imported from an `_Imports` component (`_Imports.razor`), as described in the following [Apply a layout to a folder of components](#apply-a-layout-to-a-folder-of-components) section.
* Set as the app's default layout, as described in the [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section later in this article.

### Apply a layout to a folder of components

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout DoctorWhoLayout` ensures that all of the components in a folder use the `DoctorWhoLayout` component. There's no need to repeatedly add `@layout DoctorWhoLayout` to all of the Razor components (`.razor`) within the folder and subfolders.

`_Imports.razor`:

```razor
@layout DoctorWhoLayout
...
```

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's [default app layout](#apply-a-default-layout-to-an-app), which is described in the following section.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts. To control the default app layout, specify the layout in the `Router` component. For more information, see the following [Apply a default layout to an app](#apply-a-default-layout-to-an-app) section.

The [`@layout`](xref:mvc/views/razor#layout) Razor directive only applies a layout to routable Razor components with an [`@page`](xref:mvc/views/razor#page) directive.

### Apply a default layout to an app

Specify the default app layout in the `App` component's <xref:Microsoft.AspNetCore.Components.Routing.Router> component. The following example from an app based on a [Blazor project template](xref:blazor/project-structure) sets the default layout to the `MainLayout` component.

`App.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/layouts/App1.razor?highlight=3)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the `Router` component is a useful practice because you can override the layout on a per-component or per-folder basis, as described in the preceding sections of this article. We recommend using the `Router` component to set the app's default layout because it's the most general and flexible approach for using layouts.

### Apply a layout to arbitrary content (`LayoutView` component)

To set a layout for arbitrary Razor template content, specify the layout with a <xref:Microsoft.AspNetCore.Components.LayoutView> component. You can use a <xref:Microsoft.AspNetCore.Components.LayoutView> in any Razor component. The following example sets a layout component named `ErrorLayout` for the `MainLayout` component's <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> template (`<NotFound>...</NotFound>`).

`App.razor`:

```razor
<Router AppAssembly="@typeof(Program).Assembly">
    <Found Context="routeData">
        <RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />
    </Found>
    <NotFound>
        <LayoutView Layout="@typeof(ErrorLayout)">
            <h1>Page not found</h1>
            <p>Sorry, there's nothing at this address.</p>
        </LayoutView>
    </NotFound>
</Router>
```

## Nested layouts

A component can reference a layout that in turn references another layout. For example, nested layouts are used to create a multi-level menu structures.

The following example shows how to use nested layouts. The `Episodes` component shown in the [Apply a layout to a component](#apply-a-layout-to-a-component) section is the component to display. The component references the `DoctorWhoLayout` component.

The following `DoctorWhoLayout` component is a modified version of the example shown earlier in this article. The header and footer elements are removed, and the layout references another layout, `ProductionsLayout`. The `Episodes` component is rendered where `@Body` appears in the `DoctorWhoLayout`.

`Shared/DoctorWhoLayout.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/layouts/DoctorWhoLayout2.razor?highlight=2,12)]

The `ProductionsLayout` component contains the top-level layout elements, where the header (`<header>...</header>`) and footer (`<footer>...</footer>`) elements now reside. The `DoctorWhoLayout` with the `Episodes` component is rendered where `@Body` appears.

`Shared/ProductionsLayout.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/layouts/ProductionsLayout.razor?highlight=13)]

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
            <a href="main-production-list">Main Production List</a>
            <a href="production-search">Search</a>
            <a href="new-production">Add Production</a>
        </nav>

        <h1>Doctor Who&trade; Episode Database</h1>

        <nav>
            <a href="episode-main-list">Main Episode List</a>
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

:::moniker-end
