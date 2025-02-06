---
title: IHttpContextAccessor/HttpContext in ASP.NET Core SignalR
author: guardrex
description: Learn about IHttpContextAccessor and HttpContext in ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/30/2025
uid: signalr/httpcontext
---
# `IHttpContextAccessor`/`HttpContext` in ASP.NET Core SignalR

[!INCLUDE[](~/includes/not-latest-version-without-not-supported-content.md)]

<xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext> generally should be avoided with SignalR because a valid <xref:Microsoft.AspNetCore.Http.HttpContext> isn't always available. In most cases, the context doesn't exist (`null`).

Even when an <xref:Microsoft.AspNetCore.Http.HttpContext> instance is available, the context is dependent on the transport:

* WebSockets receives a single context as the result of the initial handshake.
* Long polling receives a new context per client "poll" request.
* A SignalR service receives a mocked/faked/shim context.

When working within a SignalR hub, you can access the <xref:Microsoft.AspNetCore.Http.HttpContext> directly using the <xref:Microsoft.AspNetCore.SignalR.GetHttpContextExtensions.GetHttpContext%2A?displayProperty=nameWithType> method. This method returns the <xref:Microsoft.AspNetCore.Http.HttpContext> for the current connection or `null` if the connection isn't associated with an HTTP request. This is particularly useful for retrieving HTTP connection information, such as headers and query strings, directly within the hub. We recommend calling this method over <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> for accessing <xref:Microsoft.AspNetCore.Http.HttpContext> in the hub. For more information, see <xref:signalr/hubs#the-context-object>.

For guidance on <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor>/<xref:Microsoft.AspNetCore.Http.HttpContext> in ASP.NET Core Blazor apps, see <xref:blazor/components/httpcontext>.
