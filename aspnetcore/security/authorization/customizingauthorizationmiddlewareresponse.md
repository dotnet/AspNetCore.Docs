---
title: Customize the behavior of AuthorizationMiddleware
author: pranavkm
ms.author: prkrishn
description: This article explains how to customize the result handling of AuthorizationMiddleware.
monikerRange: '>= aspnetcore-5.0'
uid: security/authorization/authorizationmiddlewareresulthandler
---
# Customize the behavior of AuthorizationMiddleware

Applications can register a `Microsoft.AspNetCore.Authorization.IAuthorizationMiddlewareResultHandler` to customize the way the middleware handles the authorization results. Applications can use the customized middleware to:

* Return customized responses.
* Enhance the default challenge or forbid responses.

The following code shows an example of an authorization handler that returns a custom response for certain kinds of authorization failures:

[!code-csharp[](customizingauthorizationmiddlewareresponse/sample/AuthorizationMiddlewareResultHandlerSample/MyAuthorizationMiddlewareResultHandler.cs)]

Register `MyAuthorizationMiddlewareResultHandler` in `Startup.ConfigureServices`:

[!code-csharp[](customizingauthorizationmiddlewareresponse/sample/AuthorizationMiddlewareResultHandlerSample/Startup.cs?name=snippet)]

<!-- <xref:Microsoft.AspNetCore.Authorization.IAuthorizationMiddlewareResultHandler /> -->