---
title: ASP.NET Core Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/14/2019
uid: blazor/layouts
---
# ASP.NET Core Blazor layouts

By [Rainer Stropek](https://www.timecockpit.com)

Some app elements, such as menus, copyright messages, and company logos, are usually part of app's overall layout and used by every component in the app. Copying the code of these elements into all of the components of an app isn't an efficient approach&mdash;every time one of the elements requires an update, every component must be updated. Such duplication is difficult to maintain and can lead to inconsistent content over time. *Layouts* solve this problem.

Technically, a layout is just another component. A layout is defined in a Razor template or in C# code and can use [data binding](xref:blazor/components#data-binding), [dependency injection](xref:blazor/dependency-injection), and other component scenarios.

To turn a *component* into a *layout*, the component:

* Inherits from `LayoutComponentBase`, which defines a `Body` property that contains the content to be rendered inside the layout.
* Uses the Razor syntax `@Body` to specify the location in the markup where the content should be rendered.

The following code sample shows the Razor template of a layout component, *MainLayout.razor*. The layout inherits `LayoutComponentBase` and sets the `@Body` between the navigation bar and the footer:

[!code-cshtml[](layouts/sample_snapshot/3.x/MainLayout.razor?highlight=1,13)]

## Specify a layout in a component

Use the Razor directive `@layout` to apply a layout to a component. The compiler converts `@layout` into a `LayoutAttribute`, which is applied to the component class.

The content of the following component, *MasterList.razor*, is inserted into the *MainLayout* at the position of `@Body`.

[!code-cshtml[](layouts/sample_snapshot/3.x/MasterList.razor?highlight=1)]

## Centralized layout selection

Every folder of an app can optionally contain a template file named *_Imports.razor*. The compiler includes the directives specified in the imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, a *_Imports.razor* file containing `@layout MainLayout` ensures that all of the components in a folder use *MainLayout*. There's no need to repeatedly add `@layout MainLayout` to all of the *.razor* files within the folder and subfolders. `@using` directives are also applied to components in the same way.

The following *_Imports.razor* file imports:

* `MainLayout`.
* All Razor components in a the same folder and any subfolders.
* The `BlazorApp1.Data` namespace.
 
[!code-cshtml[](layouts/sample_snapshot/3.x/_Imports.razor)]

The *_Imports.razor* file is similar to the [_ViewImports.cshtml file for Razor views and pages](xref:mvc/views/layout#importing-shared-directives) but applied specifically to Razor component files.

The Blazor templates use *_Imports.razor* files for layout selection. An app created from a Blazor template contains the *_Imports.razor* file in the root of the project and in the *Pages* folder.

## Nested layouts

Apps can consist of nested layouts. A component can reference a layout which in turn references another layout. For example, nesting layouts can be used to create a multi-level menu structure.

The following example shows how to use nested layouts. The *EpisodesComponent.razor* file is the component to display. The component references the `MasterListLayout`:

[!code-cshtml[](layouts/sample_snapshot/3.x/EpisodesComponent.razor?highlight=1)]

The *MasterListLayout.razor* file provides the `MasterListLayout`. The layout references another layout, `MasterLayout`, where it's rendered. `EpisodesComponent` is rendered where `@Body` appears:

[!code-cshtml[](layouts/sample_snapshot/3.x/MasterListLayout.razor?highlight=1,9)]

Finally, `MasterLayout` in *MasterLayout.razor* contains the top-level layout elements, such as the header, main menu, and footer. *MasterListLayout* with *EpisodesComponent* are rendered where `@Body` appears:

[!code-cshtml[](layouts/sample_snapshot/3.x/MasterLayout.razor?highlight=6)]

## Additional resources

* <xref:mvc/views/layout>
