---
title: "Breaking change: Blazor: Changes to routing logic in Blazor apps"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: Changes to routing logic in Blazor apps"
ms.author: scaddie
ms.date: 12/14/2020
ms.custom: https://github.com/aspnet/Announcements/issues/445
---
# Blazor: Route precedence logic changed in Blazor apps

A bug in the Blazor routing implementation affected how the precedence of routes was determined. This bug affects catch-all routes or routes with optional parameters within your Blazor app.

## Version introduced

5.0.1

## Old behavior

With the erroneous behavior, routes with lower precedence are considered and matched over routes with higher precedence. For example, the `{*slug}` route is matched before `/customer/{id}`.

## New behavior

The current behavior more closely matches the routing behavior defined in ASP.NET Core apps. The framework determines the route precedence for each segment first. The route's length is used only as a second criteria to break ties.

## Reason for change

The original behavior is considered a bug in the implementation. As a goal, the routing system in Blazor apps should behave the same way as the routing system in the rest of ASP.NET Core.

## Recommended action

If upgrading from previous versions of Blazor to 5.x, use the `PreferExactMatches` attribute on the `Router` component. This attribute can be used to opt in to the correct behavior. For example:

```razor
<Router AppAssembly="@typeof(Program).Assembly" PreferExactMatches="true">
```

When `PreferExactMatches` is set to `true`, route matching prefers exact matches over wildcards.

## Affected APIs

None

<!--

## Category

ASP.NET Core

## Affected APIs

Not detectable via API analysis

-->
