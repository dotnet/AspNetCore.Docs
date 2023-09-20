---

title: ASP.NET Core Request Delegate Generator (RDG) for native AOT"
description: Get an 
author: rick-anderson
ms.author: riande
content_well_notification: AI-contribution
monikerRange: '>= aspnetcore-8.0'
ms.topic: article
ms.prod: aspnet-core
ms.date: 9/21/2023
uid: fundamentals/aot/rdg
---
# Turn Map methods into request delegates with the ASP.NET Core Request Delegate Generator

?view=aspnetcore-7.0

The ASP.NET Core Request Delegate Generator (RDG) is a tool that generates request delegates for ASP.NET Core apps. The RDG is used by the native ahead-of-time (AOT) compiler to generate request delegates for the app's `Map` methods. The RDG:

* Is a [source generator](/dotnet/csharp/roslyn-sdk/source-generators-overview).
* Turns `Map` methods into [request delegates](/dotnet/api/microsoft.aspnetcore.http.requestdelegate?view=aspnetcore-7.0) associated with specific routes. `Map` methods include the methods in the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions> such as <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPost%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPatch%2A>,  <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPut%2A>, and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapDelete%2A>.

When publishing with native AOT is ***not*** enabled:

* `Map` methods associated with a specific route are compiled in memory into a request delegate when the app starts.
* The request delegate is generated at runtime.

When publishing with native AOT is enabled:

* `Map` methods associated with a specific route are compiled when the app is compiled. The RDG generates the request delegate for the route and the request delegate is compiled into the app's native image.
* Eliminates the need to generate the request delegate at runtime.
* Ensures:
  * The types used in the app's APIs are rooted in the app code in a way that is statically analyzable by the native AOT tool-chain.
  * The required code is not trimmed away.
