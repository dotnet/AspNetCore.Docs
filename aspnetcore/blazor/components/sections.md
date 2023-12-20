---
title: ASP.NET Core Blazor sections
author: guardrex
description: Learn how to control the content in a Razor component from a child Razor component.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/sections
---
# ASP.NET Core Blazor sections

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

This article explains how to control the content in a Razor component from a child Razor component.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net8-or-later.md)]

## Blazor sections

To control the content in a Razor component from a child Razor component, Blazor supports *sections* using the following built-in components:

* <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet>: Renders content provided by <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> components with matching <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> or <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> arguments. Two or more <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> components can't have the same <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> or <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A>.

* <xref:Microsoft.AspNetCore.Components.Sections.SectionContent>: Provides content as a <xref:Microsoft.AspNetCore.Components.RenderFragment> to <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> components with a matching <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> or <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A>. If several <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> components have the same <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> or <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A>, the matching <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> component renders the content of the last rendered <xref:Microsoft.AspNetCore.Components.Sections.SectionContent>.

Sections can be used in both [layouts](xref:blazor/components/layouts) and across nested parent-child components.

Although the argument passed to <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> can use any type of casing, the documentation adopts kebab casing (for example, `top-bar`), which is a common casing choice for HTML element IDs. <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> receives a static `object` field, and we always recommend Pascal casing for C# field names (for example, `TopbarSection`).

In the following example, the app's main layout component implements an increment counter button for the app's `Counter` component.

If the namespace for sections isn't in the `_Imports.razor` file, add it:

```razor
@using Microsoft.AspNetCore.Components.Sections
```

In the `MainLayout` component (`MainLayout.razor`), place a <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> component and pass a string to the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> parameter to indicate the section's name. The following example uses the section name `top-bar`:

```razor
<SectionOutlet SectionName="top-bar" />
```

In the `Counter` component (`Counter.razor`), create a <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component and pass the matching string (`top-bar`) to its <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A> parameter:

```razor
<SectionContent SectionName="top-bar">
    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</SectionContent>
```

When the `Counter` component is accessed at `/counter`, the `MainLayout` component renders the increment count button from the `Counter` component where the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> component is placed. When any other component is accessed, the increment count button isn't rendered.

Instead of using a named section, you can pass a static `object` with the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> parameter to identify the section. The following example also implements an increment counter button for the app's `Counter` component in the app's main layout.

If you don't want other <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> components to accidentally match the name of a <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet>, pass an object <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> parameter to identify the section. This can be useful when designing a [Razor class library (RCL)](xref:blazor/components/class-libraries). When a <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> in the RCL uses an object reference with <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> and the consumer places a <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component with a matching <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> object, an accidental match by name isn't possible when consumers of the RCL implement other <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> components.

The following example also implements an increment counter button for the app's `Counter` component in the app's main layout, using an object reference instead of a section name.

Add a `TopbarSection` static `object` to the `MainLayout` component in an `@code` block:

```razor
@code {
    internal static object TopbarSection = new();
}
```

In the `MainLayout` component's Razor markup, place a <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> component and pass `TopbarSection` to the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> parameter to indicate the section:

```razor
<SectionOutlet SectionId="TopbarSection" />
```

Add a <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component to the app's `Counter` component that renders an increment count button. Use the `MainLayout` component's `TopbarSection` section static `object` as the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> (`MainLayout.TopbarSection`).

In `Counter.razor`:

```razor
<SectionContent SectionId="MainLayout.TopbarSection">
    <button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
</SectionContent>
```

When the `Counter` component is accessed, the `MainLayout` component renders the increment count button where the <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> component is placed.

> [!NOTE]
> <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet> and <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> components can only set either <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionId%2A> or <xref:Microsoft.AspNetCore.Components.Sections.SectionOutlet.SectionName%2A>, not both.

## Section interaction with other Blazor features

A section interacts with other Blazor features in the following ways:

* [Cascading values](xref:blazor/components/cascading-values-and-parameters) flow into section content from where the content is defined by the <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component.
* Unhandled exceptions are handled by [error boundaries](xref:blazor/fundamentals/handle-errors#error-boundaries) defined around a <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component.
* A Razor component configured for [streaming rendering](xref:blazor/components/rendering#streaming-rendering) also configures section content provided by a <xref:Microsoft.AspNetCore.Components.Sections.SectionContent> component to use streaming rendering.
