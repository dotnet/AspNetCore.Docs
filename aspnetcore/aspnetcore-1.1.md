---
title: What's new in ASP.NET Core 1.1 | Microsoft Docs
author: rick-anderson
description: What's new in ASP.NET Core 1.1
keywords: ASP.NET Core, bower
ms.author: riande
manager: wpickett
ms.date: 02/14/2017
ms.topic: article
ms.assetid: 062f8353-d1bc-4e99-a821-c1d1bb162c47
ms.technology: aspnet
ms.prod: aspnet-core
uid: aspnetcore-1.1
---

# What's new in ASP.NET Core 1.1

ASP.NET Core 1.1 includes the following new features:

- [URL Rewriting Middleware](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting)
- [Response Caching Middleware](https://docs.microsoft.com/en-us/aspnet/core/performance/caching/middleware)
- [View Components as Tag Helpers](xref:mvc/views/view-components#invoking-a-view-component-as-a-tag-helper)
- [Middleware as MVC filters](xref:mvc/controllers/filters#using-middleware-in-the-filter-pipeline)
- [Cookie-based TempData provider](xref:fundamentals/app-state#cookie-based-tempData-provider )
- [Azure App Service logging provider](xref:fundamentals/logging#appservice)
- [Azure Key Vault configuration provider](xref:security/key-vault-configuration)
- [Azure and Redis Storage Data Protection Key Repositories](xref:security/data-protection/implementation/key-storage-providers#azure-and-redis)
- [WebListener Server for Windows](xref:fundamentals/servers/weblistener)
- [WebSockets support](#websockets-support)

## Choosing between versions 1.0 and 1.1 of ASP.NET Core

ASP.NET Core 1.1 has more features than 1.0. In general, we recommend you use the latest version.

## WebSockets support

A new middleware component provides WebSockets support in ASP.NET Core 1.1. Install the [Microsoft.AspNetCore.WebSockets](https://www.nuget.org/packages/Microsoft.AspNetCore.WebSockets/) package, and add code to the `Configure` method of the `Startup` class:

```
app.UseWebSockets();
```

Your project will then have access to a `WebSockets` property on the `HttpContext` object.  You can write your own middleware for the pipeline to interpret and interact with the requests handed to your application by a websocket.  You could add this middleware to your configured pipeline with code like the following:

```
app.Use(async (context, next) =>
{
  if (context.WebSockets.IsWebSocketRequest)
  {
    var webSocket = await context.WebSockets.AcceptWebSocketAsync();
    await DoSomethingCool(context, webSocket);
  }
  else
  {
    await next();
  }
});
```

The websocket object has `SendAsync` and `ReceiveAsync` methods.  For samples, see the  [WebSockets repository](https://github.com/aspnet/WebSockets/tree/dev/samples).

## Additional Information

- [ASP.NET Core 1.1.0 Release Notes](https://github.com/aspnet/Home/releases/tag/1.1.0)
