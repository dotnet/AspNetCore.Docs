---
title: "Breaking change: Blazor enhanced navigation no longer preloads resources"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where Blazor's ResourcePreloader no longer emits preload link hints for pages reached through enhanced navigation."
ms.date: 06/04/2026
---
# Blazor enhanced navigation no longer preloads resources

Blazor no longer emits `<link rel="modulepreload">` or `<link rel="preload">` resource hints for pages reached through enhanced navigation. Resource preloading still works for the initial page load and for normal (non-enhanced) navigation.

## Version introduced

.NET 11

## Previous behavior

Previously, Blazor's `ResourcePreloader` emitted preload `<link>` elements for resources used by the destination page on every server-rendered request, including requests served as an enhanced navigation.

When an enhanced navigation occurred, the new preload elements were merged into the existing DOM. The merge often added and removed `<link>` elements in a different order from the prior page, which caused some browsers to issue more preload requests than needed. The Blazor WebAssembly runtime also doesn't restart on an enhanced navigation, so preload hints emitted for it after the first page were redundant.

## New behavior

Starting in ASP.NET Core 11, `ResourcePreloader` only emits preload elements when the response isn't an enhanced navigation. Pages reached by enhanced navigation no longer receive the implicit preload hints that the framework added before.

The previous behavior on the initial page load (the first request, before any enhanced navigation occurs) is unchanged. Pages that the user navigates to without enhanced navigation (for example, full-page reloads or external navigations) also still receive preload hints.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

The implicit preload hints during enhanced navigation produced redundant browser preload requests because the WebAssembly runtime doesn't restart and the DOM-merge step often produced an unstable order of `<link>` elements. Removing the hints for enhanced navigation gives more predictable network behavior. For more information, see [dotnet/aspnetcore#63544](https://github.com/dotnet/aspnetcore/pull/63544).

## Recommended action

If you relied on the implicit preload hints during enhanced navigation, add explicit `<link rel="preload">` or `<link rel="modulepreload">` tags in your `<HeadContent>` for the specific resources you want to preload:

```razor
<HeadContent>
    <link rel="modulepreload" href="_content/MyLib/big-module.js" />
</HeadContent>
```

Alternatively, opt the relevant links out of enhanced navigation if preloading is more important to you than the snappier in-place navigation. For more information, see [enhanced navigation and form handling](/aspnet/core/blazor/fundamentals/routing#enhanced-navigation-and-form-handling).

## Affected APIs

None. No public API surface changed. The change affects the implicit resource preloading performed by Blazor server-side rendering.
