---
title: Razor Components layouts
author: guardrex
description: Learn how to create reusable layout components for Razor Components apps.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 02/15/2019
uid: razor-components/layouts
---
# Razor Components layouts

By [Rainer Stropek](https://www.timecockpit.com)

Apps typically contain more than one component. Layout elements, such as menus, copyright messages, and logos, must be present on all components. Copying the code of these layout elements into all of the components of an app isn't an efficient approach. Such duplication is hard to maintain and probably leads to inconsistent content over time. *Layouts* solve this problem.

Technically, a layout is just another component. A layout is defined in a Razor template or in C# code and can contain [data binding](xref:razor-components/components#data-binding), [dependency injection](xref:razor-components/dependency-injection), and other ordinary features of components.

Two additional aspects turn a *component* into a *layout*

* The layout component must inherit from `LayoutComponentBase`. `LayoutComponentBase` defines a `Body` property that contains the content to be rendered inside the layout.
* The layout component uses the `Body` property to specify where the body content should be rendered using the Razor syntax `@Body`. During rendering, `@Body` is replaced by the content of the layout.

The following code sample shows the Razor template of a layout component. Note the use of `LayoutComponentBase` and `@Body`:

[!code-cshtml[](layouts/sample_snapshot/3.x/MasterLayout.cshtml?highlight=1,13)]

## Use a layout in a component

Use the Razor directive `@layout` to apply a layout to a component. The compiler converts this directive into a `LayoutAttribute`, which is applied to the component class.

The following code sample demonstrates the concept. The content of this component is inserted into the *MasterLayout* at the position of `@Body`:

```cshtml
@layout MasterLayout
@page "/master-list"

<h2>Master Episode List</h2>
```

## Centralized layout selection

Every folder of a an app can optionally contain a template file named *_ViewImports.cshtml*. The compiler includes the directives specified in the view imports file in all of the Razor templates in the same folder and recursively in all of its subfolders. Therefore, a *_ViewImports.cshtml* file containing `@layout MasterLayout` ensures that all of the components in a folder use the *MasterLayout* layout. There's no need to repeatedly add `@layout` to all of the *.cshtml* files.

Note that the default template uses the *_ViewImports.cshtml* mechanism for layout selection. A newly created app contains the *_ViewImports.cshtml* file in the *Pages* folder.

## Nested layouts

Apps can consist of nested layouts. A component can reference a layout which in turn references another layout. For example, nesting layouts can be used to reflect a multi-level menu structure.

The following code samples show how to use nested layouts. The *EpisodesComponent.cshtml* file is the component to display. Note that the component references the layout `MasterListLayout`.

*EpisodesComponent.cshtml*:

```cshtml
@layout MasterListLayout
@page "/master-list/episodes"

<h1>Episodes</h1>
```

The *MasterListLayout.cshtml* file provides the `MasterListLayout`. The layout references another layout, `MasterLayout`, where it's going to be embedded.

*MasterListLayout.cshtml*:

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

*MasterLayout.cshtml*:

```cshtml
@inherits LayoutComponentBase

<header>...</header>
<nav>...</nav>

@Body
```
