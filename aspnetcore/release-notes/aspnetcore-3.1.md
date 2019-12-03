---
title: What's new in ASP.NET Core 3.1
author: rick-anderson
description: Learn about the new features in ASP.NET Core 3.1.
ms.author: riande
ms.custom: mvc
ms.date: 11/12/2019
no-loc: [Blazor, SignalR]
uid: aspnetcore-3.1
---
# What's new in ASP.NET Core 3.1

This article highlights the most significant changes in ASP.NET Core 3.1 with links to relevant documentation.

## Partial class support for Razor components

Razor components are now generated as partial classes. Code for a Razor component can be written using a code-behind file defined as a partial class rather than defining all the code for the component in a single file. For more information, see [Partial class support](xref:blazor/components#partial-class-support)

## Blazor Apps can pass parameters to top-level components

Blazor Server apps can now pass parameters to top-level components during the initial render. Previously you could only pass parameters to a top-level component with [RenderMode.Static](xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Static). With this release, both [RenderMode.Server](xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server) and [RenderModel.ServerPrerendered](xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered) are supported. Any specified parameter values are serialized as JSON and included in the initial response.

For example, you could prerender a `Counter` component with a specific current count like this:

```Razor
@(await Html.RenderComponentAsync<Counter>(RenderMode.ServerPrerendered,
                                           new { CurrentCount = 123 }))
```

For more information, see [Integrate components into Razor Pages and MVC apps](xref:blazor/components#integrate-components-into-razor-pages-and-mvc-apps)

## Support for shared queues in HTTP.sys

[HTTP.sys](xref:fundamentals/servers/httpsys) supports creating anonymous request queues. In ASP.NET Core 3.1, we’ve added to ability to create or attach to an existing named HTTP.sys request queue. Creating or attaching to an existing named HTTP.sys request queue enables scenarios where the HTTP.Sys controller process that owns the queue is independent of the listener process. This independence makes it possible to preserve existing connections and enqueued requests between listener process restarts:

[!code-csharp[](sample/Program.cs?name=snippet)]

<!-- TODO
## Breaking changes for SameSite cookies
-->

<!-- GuardRex owns the following: 
## Prevent default actions for events in Blazor apps

## Stop event propagation in Blazor apps

## Detailed errors during Blazor app development

-->