---
title: "Breaking change: Blazor: ProtectedBrowserStorage feature moved to shared framework"
description: "Learn about the breaking change in ASP.NET Core 5.0 titled Blazor: ProtectedBrowserStorage feature moved to shared framework"
ms.author: scaddie
ms.date: 10/01/2020
ms.custom: https://github.com/aspnet/Announcements/issues/436
---
# Blazor: ProtectedBrowserStorage feature moved to shared framework

As part of the ASP.NET Core 5.0 RC2 release, the `ProtectedBrowserStorage` feature moved to the ASP.NET Core shared framework.

## Version introduced

5.0 RC2

## Old behavior

In ASP.NET Core 5.0 Preview 8, the feature is available as a part of the [Microsoft.AspNetCore.Components.Web.Extensions](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.Web.Extensions) package but was only usable in Blazor WebAssembly.

In ASP.NET Core 5.0 RC1, the feature is available as part of the [Microsoft.AspNetCore.Components.ProtectedBrowserStorage](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.ProtectedBrowserStorage) package, which references the `Microsoft.AspNetCore.App` shared framework.

## New behavior

In ASP.NET Core 5.0 RC2, a NuGet package reference is no longer needed to reference and use the feature.

## Reason for change

The move to the shared framework is a better fit for the user experience customers expect.

## Recommended action

If upgrading from ASP.NET Core 5.0 RC1, complete the following steps:

1. Remove the `Microsoft.AspNetCore.Components.ProtectedBrowserStorage` package reference from the project.
1. Replace `using Microsoft.AspNetCore.Components.ProtectedBrowserStorage;` with `using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;`.
1. Remove the call to `AddProtectedBrowserStorage` from your `Startup` class.

If upgrading from ASP.NET Core 5.0 Preview 8, complete the following steps:

1. Remove the `Microsoft.AspNetCore.Components.Web.Extensions` package reference from the project.
1. Replace `using Microsoft.AspNetCore.Components.Web.Extensions;` with `using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;`.
1. Remove the call to `AddProtectedBrowserStorage` from your `Startup` class.

## Affected APIs

None

<!--

### Category

ASP.NET Core

### Affected APIs

Not detectable via API analysis

-->
