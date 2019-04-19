---
title: Blazor layouts
author: guardrex
description: Learn how to create reusable layout components for Blazor apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/18/2019
uid: blazor/layouts
---
# Blazor layouts

By [Rainer Stropek](https://www.timecockpit.com)

Apps typically contain more than one component. Layout elements, such as menus, copyright messages, and logos, must be present on all components. Copying the code of these layout elements into all of the components of an app isn't an efficient approach. Such duplication is hard to maintain and probably leads to inconsistent content over time. *Layouts* solve this problem.

Technically, a layout is just another component. A layout is defined in a Razor template or in C# code and can contain [data binding](xref:blazor/components#data-binding), [dependency injection](xref:blazor/dependency-injection), and other ordinary features of components.

Two additional aspects turn a *component* into a *layout*

* The layout component must inherit from `LayoutComponentBase`. `LayoutComponentBase` defines a `Body` property that contains the content to be rendered inside the layout.
* The layout component uses the `Body` property to specify where the body content should be rendered using the Razor syntax `@Body`. During rendering, `@Body` is replaced by the content of the layout.

The following code sample shows the Razor template of a layout component. Note the use of `LayoutComponentBase` and `@Body`:

[!code-cshtml[](layouts/sample_snapshot/3.x/MasterLayout.razor)]

## Use a layout in a component

Use the Razor directive `@layout` to apply a layout to a component. The compiler converts this directive into a `LayoutAttribute`, which is applied to the component class.

The following code sample demonstrates the concept. The content of this component is inserted into the *MasterLayout* at the position of `@Body`:

```cshtml
@layout MasterLayout
@page "/master-list"

<h2>Master Episode List</h2>
```

## Centralized layout selection

Every folder of a an app can optionally contain a template file named *_Imports.razor*. The compiler includes the directives specified in the view imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, a *_Imports.razor* file containing `@layout MainLayout` ensures that all of the components in a folder use the *MainLayout* layout. There's no need to repeatedly add `@layout` to all of the *.razor* files. `@using` directives are also applied to components in the same folder or any sub folders.

For example, the following *_Imports.razor* file imports:

* `MainLayout`.
* All Razor components in a the same folder and any sub folders.
* The `BlazorApp1.Data` namespace.
 
```cshtml
@layout MainLayout
@using Microsoft.AspNetCore.Components.
@using BlazorApp1.Data
```

Use of the *_Imports.razor* file is similar to how you can use *_ViewImports.cshtml* with Razor views and pages, but applied specifically to Razor component files.

Note that the default template uses the *_Imports.razor* mechanism for layout selection. A newly created app contains the *_Imports.razor* file in the *Pages* folder.

## Nested layouts

Apps can consist of nested layouts. A component can reference a layout which in turn references another layout. For example, nesting layouts can be used to reflect a multi-level menu structure.

The following code samples show how to use nested layouts. The *EpisodesComponent.razor* file is the component to display. Note that the component references the layout `MasterListLayout`.

*EpisodesComponent.razor*:

```cshtml
@layout MasterListLayout
@page "/master-list/episodes"

<h1>Episodes</h1>
```

The *MasterListLayout.razor* file provides the `MasterListLayout`. The layout references another layout, `MasterLayout`, where it's going to be embedded.

*MasterListLayout.razor*:

```cshtml
@layout MasterLayout
@inherits LayoutComponentBase

<nav>
    <!-- Menu structure of master list -->
    ...
</nav>

@Body
```

Finally, `MasterLayout` contains the top-level layout elements, such as the header, footer, and main menu.

*MasterLayout.razor*:

```cshtml
@inherits LayoutComponentBase

<header>...</header>
<nav>...</nav>

@Body
```
