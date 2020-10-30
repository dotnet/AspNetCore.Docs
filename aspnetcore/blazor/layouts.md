---
title: ASP.NET Core Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 06/23/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/layouts
---
# ASP.NET Core Blazor layouts

By [Rainer Stropek](https://www.timecockpit.com) and [Luke Latham](https://github.com/guardrex)

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall layout and used by every component in the app. Copying the code of these elements into all of the components of an app isn't an efficient approach. Every time one of the elements requires an update, every component must be updated. Such duplication is difficult to maintain and can lead to inconsistent content over time. *Layouts* solve this problem.

Technically, a layout is just another component. A layout is defined in a Razor template or in C# code and can use [data binding](xref:blazor/components/data-binding), [dependency injection](xref:blazor/fundamentals/dependency-injection), and other component scenarios.

To turn a *component* into a *layout*, the component:

* Inherits from <xref:Microsoft.AspNetCore.Components.LayoutComponentBase>, which defines a <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property for the rendered content inside the layout.
* Uses the Razor syntax `@Body` to specify the location in the layout markup where the content is rendered.

The following code sample shows the Razor template of a layout component, `MainLayout.razor`. The layout inherits <xref:Microsoft.AspNetCore.Components.LayoutComponentBase> and sets the `@Body` between the navigation bar and the footer:

[!code-razor[](layouts/sample_snapshot/3.x/MainLayout.razor?highlight=1,13)]

## `MainLayout` component

In an app based on one of the Blazor project templates, the `MainLayout` component (`MainLayout.razor`) is in the app's `Shared` folder:

[!code-razor[](./common/samples/3.x/BlazorWebAssemblySample/Shared/MainLayout.razor)]

## Default layout

Specify the default app layout in the <xref:Microsoft.AspNetCore.Components.Routing.Router> component in the app's `App.razor` file. The following <xref:Microsoft.AspNetCore.Components.Routing.Router> component, which is provided by the default Blazor templates, sets the default layout to the `MainLayout` component:

[!code-razor[](layouts/sample_snapshot/3.x/App1.razor?highlight=3)]

To supply a default layout for <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content, specify a <xref:Microsoft.AspNetCore.Components.LayoutView> for <xref:Microsoft.AspNetCore.Components.Routing.Router.NotFound> content:

[!code-razor[](layouts/sample_snapshot/3.x/App2.razor?highlight=6-9)]

For more information on the <xref:Microsoft.AspNetCore.Components.Routing.Router> component, see <xref:blazor/fundamentals/routing>.

Specifying the layout as a default layout in the router is a useful practice because it can be overridden on a per-component or per-folder basis. Prefer using the router to set the app's default layout because it's the most general technique.

## Specify a layout in a component

Use the Razor directive `@layout` to apply a layout to a component. The compiler converts `@layout` into a <xref:Microsoft.AspNetCore.Components.LayoutAttribute>, which is applied to the component class.

The content of the following `MasterList` component is inserted into the `MasterLayout` at the position of `@Body`:

[!code-razor[](layouts/sample_snapshot/3.x/MasterList.razor?highlight=1)]

Specifying the layout directly in a component overrides a *default layout* set in the router or an `@layout` directive imported from `_Imports.razor`.

## Centralized layout selection

Every folder of an app can optionally contain a template file named `_Imports.razor`. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, an `_Imports.razor` file containing `@layout MyCoolLayout` ensures that all of the components in a folder use `MyCoolLayout`. There's no need to repeatedly add `@layout MyCoolLayout` to all of the `.razor` files within the folder and subfolders. `@using` directives are also applied to components in the same way.

The following `_Imports.razor` file imports:

* `MyCoolLayout`.
* All Razor components in the same folder and any subfolders.
* The `BlazorApp1.Data` namespace.
 
[!code-razor[](layouts/sample_snapshot/3.x/_Imports.razor)]

The `_Imports.razor` file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

Specifying a layout in `_Imports.razor` overrides a layout specified as the router's *default layout*.

> [!WARNING]
> Do **not** add a Razor `@layout` directive to the root `_Imports.razor` file, which results in an infinite loop of layouts in the app. To control the default app layout, specify the layout in the `Router` component. For more information, see the [Default layout](#default-layout) section.

## Nested layouts

Apps can consist of nested layouts. A component can reference a layout which in turn references another layout. For example, nesting layouts are used to create a multi-level menu structure.

The following example shows how to use nested layouts. The `EpisodesComponent.razor` file is the component to display. The component references the `MasterListLayout`:

[!code-razor[](layouts/sample_snapshot/3.x/EpisodesComponent.razor?highlight=1)]

The `MasterListLayout.razor` file provides the `MasterListLayout`. The layout references another layout, `MasterLayout`, where it's rendered. `EpisodesComponent` is rendered where `@Body` appears:

[!code-razor[](layouts/sample_snapshot/3.x/MasterListLayout.razor?highlight=1,9)]

Finally, `MasterLayout` in `MasterLayout.razor` contains the top-level layout elements, such as the header, main menu, and footer. `MasterListLayout` with the `EpisodesComponent` is rendered where `@Body` appears:

[!code-razor[](layouts/sample_snapshot/3.x/MasterLayout.razor?highlight=6)]

## Share a Razor Pages layout with integrated components

When routable components are integrated into a Razor Pages app, the app's shared layout can be used with the components. For more information, see <xref:blazor/components/integrate-components-into-razor-pages-and-mvc-apps>.

## Additional resources

* <xref:mvc/views/layout>
