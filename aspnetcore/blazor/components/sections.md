---
title: ASP.NET Core Blazor sections
author: guardrex
description: Learn how to to control the content in a Razor component from a child Razor component.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/18/2023
uid: blazor/components/sections
---
# ASP.NET Core Blazor sections

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

To control the content in a Razor component from a child Razor component, Blazor supports *sections* using the following built-in components:

* `SectionOutlet`: Renders content provided by `SectionContent` components with matching `SectionName` or `SectionId` arguments. Two or more `SectionOutlet` components can't have the the same `SectionName` or `SectionId`.

* `SectionContent`: Provides content as a <xref:Microsoft.AspNetCore.Components.RenderFragment> to `SectionOutlet` components with a matching `SectionName` or `SectionId`. If several `SectionContent` components have the same `SectionName` or `SectionId`, the matching `SectionOutlet` component renders the content of the last rendered `SectionContent`.

Sections can be used in both [layouts](xref:blazor/components/layouts) and across nested parent-child components.

Although the argument passed to `SectionName` can use any type of casing, the documentation adopts kebab casing (for example, `top-bar`), which is a common casing choice for HTML element IDs. `SectionId` receives a static `object` field, and we always recommend Pascal casing for C# field names (for example, `TopbarSection`).

In the following example, the app's main layout component implements an increment counter button for the app's `Counter` component.

If the namespace for sections isn't in the `_Imports.razor` file, add it:

```razor
@using Microsoft.AspNetCore.Components.Sections
```

In the `MainLayout` component (`MainLayout.razor`), place a `SectionOutlet` component and pass a string to the `SectionName` parameter to indicate the section's name. The following example uses the section name `top-bar`:

```razor
<SectionOutlet SectionName="top-bar" />
```

In the `Counter` component (`Counter.razor`), create a `SectionContent` component and pass the matching string (`top-bar`) to its `SectionName` parameter:

```razor
<SectionContent SectionName="top-bar">
    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</SectionContent>
```

When the `Counter` component is accessed at `/counter`, the `MainLayout` component renders the increment count button from the `Counter` component where the `SectionOutlet` component is placed. When any other component is accessed, the increment count button isn't rendered.

Instead of using a named section, you can pass a static `object` with the `SectionId` parameter to identify the section. The following example also implements an increment counter button for the app's `Counter` component in the app's main layout.

If you don't want other `SectionContent` components to accidentally match the name of a `SectionOutlet`, pass an object `SectionId` parameter to identify the section. This can be useful when designing a [Razor class library (RCL)](xref:blazor/components/class-libraries). When a `SectionOutlet` in the RCL uses an object reference with `SectionId` and the consumer places a `SectionContent` component with a matching `SectionId` object, an accidental match by name isn't possible when consumers of the RCL implement other `SectionContent` components.

The following example also implements an increment counter button for the app's `Counter` component in the app's main layout, using an object reference instead of a section name.

Add a `TopbarSection` static `object` to the `MainLayout` component in an `@code` block:

```razor
@code {
    internal static object TopbarSection = new();
}
```

In the `MainLayout` component's Razor markup, place a `SectionOutlet` component and pass `TopbarSection` to the `SectionId` parameter to indicate the section:

```razor
<SectionOutlet SectionId="TopbarSection" />
```

Add a `SectionContent` component to the app's `Counter` component that renders an increment count button. Use the `MainLayout` component's `TopbarSection` section static `object` as the `SectionId` (`MainLayout.TopbarSection`).

In `Counter.razor`:

```razor
<SectionContent SectionId="MainLayout.TopbarSection">
    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</SectionContent>
```

When the `Counter` component is accessed, the `MainLayout` component renders the increment count button where the `SectionOutlet` component is placed.

> [!NOTE]
> `SectionOutlet` and `SectionContent` components can only set either `SectionId` or `SectionName`, not both.

## Section interaction with other Blazor features

A section interacts with other Blazor features in the following ways:

* [Cascading values](xref:blazor/components/cascading-values-and-parameters) flow into section content from where the content is defined by the `SectionContent` component.
* Unhandled exceptions are handled by [error boundaries](xref:blazor/fundamentals/handle-errors#error-boundaries) defined around a `SectionContent` component.
* A Razor component configured for [streaming rendering](xref:blazor/components/rendering#streaming-rendering) also configures section content provided by a `SectionContent` component to use streaming rendering.
