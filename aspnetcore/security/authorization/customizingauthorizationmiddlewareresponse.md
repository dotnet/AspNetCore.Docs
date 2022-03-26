---
title: Customize the behavior of AuthorizationMiddleware
author: rick-anderson
description: This article explains how to customize the result handling of AuthorizationMiddleware.
ms.author: riande
monikerRange: '>= aspnetcore-5.0'
ms.date: 03/24/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/authorization/authorizationmiddlewareresulthandler
---
# Customize the behavior of `AuthorizationMiddleware`

:::moniker range=">= aspnetcore-6.0"
  
Apps can register an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationMiddlewareResultHandler> to customize how <xref:Microsoft.AspNetCore.Authorization.AuthorizationMiddleware> handles authorization results. Apps can use `IAuthorizationMiddlewareResultHandler` to:

* Return customized responses.
* Enhance the default challenge or forbid responses.

The following code shows an example implementation of `IAuthorizationMiddlewareResultHandler` that returns a custom response for specific authorization failures:

:::code language="csharp" source="customizingauthorizationmiddlewareresponse/samples_snapshot/6.x/SampleAuthorizationMiddlewareResultHandler.cs":::

Register this implementation of `IAuthorizationMiddlewareResultHandler` in `Program.cs`:

:::code language="csharp" source="customizingauthorizationmiddlewareresponse/samples_snapshot/6.x/Program.cs" id="snippet_Register":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Apps can register an <xref:Microsoft.AspNetCore.Authorization.IAuthorizationMiddlewareResultHandler> to customize how <xref:Microsoft.AspNetCore.Authorization.AuthorizationMiddleware> handles authorization results. Apps can use the `IAuthorizationMiddlewareResultHandler` to:

* Return customized responses.
* Enhance the default challenge or forbid responses.

The following code shows an example implementation of `IAuthorizationMiddlewareResultHandler` that returns a custom response for specific authorization failures:

:::code language="csharp" source="customizingauthorizationmiddlewareresponse/samples_snapshot/5.x/MyAuthorizationMiddlewareResultHandler.cs":::

Register `MyAuthorizationMiddlewareResultHandler` in `Startup.ConfigureServices`:

:::code language="csharp" source="customizingauthorizationmiddlewareresponse/samples_snapshot/5.x/Startup.cs" id="snippet_ConfigureServices":::

:::moniker-end
