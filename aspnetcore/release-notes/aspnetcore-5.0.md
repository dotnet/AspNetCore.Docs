---
title: What's new in ASP.NET Core 5.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 5.0.
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: aspnetcore-5.0
---
# What's new in ASP.NET Core 5.0

This article highlights the most significant changes in ASP.NET Core 5.0 with links to relevant documentation.

## Blazor

Blazor is a framework in ASP.NET Core for building interactive client-side web UI with .NET:

* Create rich interactive UIs using C# instead of JavaScript.
* Share server-side and client-side app logic written in .NET.
* Render the UI as HTML and CSS for wide browser support, including mobile browsers.

Blazor framework supported scenarios:

* Reusable UI components (Razor components)
* Client-side routing
* Component layouts
* Support for dependency injection
* Forms and validation
* Build component libraries with Razor class libraries
* JavaScript interop

For more information, see <xref:blazor/index>.

### Blazor Server

Blazor decouples component rendering logic from how UI updates are applied. Blazor Server provides support for hosting Razor components on the server in an ASP.NET Core app. UI updates are handled over a SignalR connection.

## gRPC

[gRPC](https://grpc.io/):

For more information, see <xref:grpc/index>.

## SignalR

See [Update SignalR code](xref:migration/22-to-30#signalr) for migration instructions. 

## Performance improvements

* HTTP/2:
  * Significant reductions in allocations in the HTTP/2 code path.
  * Support for [HPack dynamic compression](https://tools.ietf.org/html/rfc7541) of HTTP/2 response headers in [Kestrel](xref:fundamentals/servers/kestrel). For more information, see [Header table size](xref:fundamentals/servers/kestrel#header-table-size) and [HPACK: the silent killer (feature) of HTTP/2](https://blog.cloudflare.com/hpack-the-silent-killer-feature-of-http-2/).

## Containers

Prior to .NET 5, building and publishing a Dockerfile ASP.NET app required pulling the .NET Core SDK and the ASP.NET image. With this release, the SDK images size is reduced and the ASP.NET image is eliminated, only the small manifest needs to be pulled. For more information, see [this GitHub issue comment](https://github.com/dotnet/dotnet-docker/issues/1814#issuecomment-625294750).