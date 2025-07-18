---
title: Enable ASP.NET Core Blazor Server support with Yarp in incremental migration
author: twsouthwick
description: Learn how to enable ASP.NET Core Blazor Server support with Yarp in incremental migration.
monikerRange: '>= aspnetcore-6.0 < aspnetcore-8.0'
ms.author: tasou
ms.custom: "mvc"
ms.date: 07/17/2025
uid: migration/fx-to-core/inc/blazor
---
# Enable ASP.NET Core Blazor Server support with Yarp in incremental migration

When adding Yarp to a Blazor Server app, both attempt to act as fallback routes for the app's request routing. Either Blazor or Yarp handles routing arbitrarily, which means that scenarios such as deep linking in Blazor may fail. This will be fixed in the .NET 8 release later this year. For migration to ASP.NET Core in .NET 6 and .NET 7, map Blazor's endpoints to achieve correct request routing by following the guidance in this article.

Add the following route builder extensions class to the project.

`BlazorEndpointRouteBuilderExtensions.cs`:

[!code-csharp[](samples/blazor-with-yarp/BlazorEndpointRouteBuilderExtensions.cs)]

In the preceding code:

* <xref:Microsoft.AspNetCore.Builder.EndpointBuilder.DisplayName?displayProperty=nameWithType> defaults to `Fallback {route}`. The line that changes it to `Blazor {route}` (`b.DisplayName = $"Blazor {route}";`) identifies the Blazor route as explicitly registered.
* For the line that sets the route order (`((RouteEndpointBuilder)b).Order = -1;`), `{page}` has a route order of `0` by default. Setting the Blazor route order to `-1` ensures the order is changed to give the Blazor route precedence.

Update the app registration for using Blazor in `Program.cs`:

```diff
- app.MapFallbackToPage("/_Host");
+ app.MapBlazorPages("/_Host");
```

At this point, the app should route requests correctly for Blazor and Yarp, including deep linking to pages.
