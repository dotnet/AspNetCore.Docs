---
title: "Breaking change: Blazor: Insignificant whitespace trimmed from components at compile time"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: Insignificant whitespace trimmed from components at compile time"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/426
---
# Blazor: Insignificant whitespace trimmed from components at compile time

Starting with ASP.NET Core 5.0, the Razor compiler omits insignificant whitespace in Razor components (*.razor* files) at compile time. For discussion, see issue [dotnet/aspnetcore#23568](https://github.com/dotnet/aspnetcore/issues/23568).

## Version introduced

5.0

## Old behavior

In 3.x versions of Blazor Server and Blazor WebAssembly, whitespace is honored in a component's source code. Whitespace-only text nodes render in the browser's Document Object Model (DOM) even when there's no visual effect.

Consider the following Razor component code:

```razor
<ul>
    @foreach (var item in Items)
    {
        <li>
            @item.Text
        </li>
    }
</ul>
```

The preceding example renders two whitespace nodes:

* Outside of the `@foreach` code block.
* Around the `<li>` element.
* Around the `@item.Text` output.

A list containing 100 items results in 402 whitespace nodes. That's over half of all nodes rendered, even though none of the whitespace nodes visually affect the rendered output.

When rendering static HTML for components, whitespace inside a tag wasn't preserved. For example, view the source of the following component:

```razor
<foo        bar="baz"     />
```

Whitespace isn't preserved. The pre-rendered output is:

```razor
<foo bar="baz" />
```

## New behavior

Unless the `@preservewhitespace` directive is used with value `true`, whitespace nodes are removed if they:

* Are leading or trailing within an element.
* Are leading or trailing within a `RenderFragment` parameter. For example, child content being passed to another component.
* Precede or follow a C# code block such as `@if` and `@foreach`.

## Reason for change

A goal for Blazor in ASP.NET Core 5.0 is to improve the performance of rendering and diffing. Insignificant whitespace tree nodes consumed up to 40 percent of the rendering time in benchmarks.

## Recommended action

In most cases, the visual layout of the rendered component is unaffected. However, the whitespace removal might affect the rendered output when using a CSS rule like `white-space: pre`. To disable this performance optimization and preserve the whitespace, take one of the following actions:

* Add the `@preservewhitespace true` directive at the top of the *.razor* file to apply the preference to a specific component.
* Add the `@preservewhitespace true` directive inside an *_Imports.razor* file to apply the preference to an entire subdirectory or the entire project.

In most cases, no action is required, as applications will typically continue to behave normally (but faster). If the whitespace stripping causes any problems for a particular component, use `@preservewhitespace true` in that component to disable this optimization.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
