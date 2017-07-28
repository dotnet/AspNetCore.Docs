---
title: Enforcing SSL in an ASP.NET Core app
author: rick-anderson
description: Shows how to require SSL in a ASP.NET Core web app
keywords: ASP.NET Core, SSL, HTTPS, RequireHttpsAttribute, IIS Express
ms.author: riande
manager: wpickett
ms.date: 07/19/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/enforcing-ssl
---
# Enforcing SSL in an ASP.NET Core app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

- Require SSL for all requests (HTTPS requests only).
- Redirect all HTTP requests to HTTPS.

## Require SSL

The [RequireHttpsAttribute](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.requirehttpsattribute) is used to require SSL. You can decorate controllers or methods with this attribute or you can apply it globally as shown below:

Add the following code to `ConfigureServices` in `Startup`:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet2&highlight=4-)]

The highlighted code above requires all requests use `HTTPS`, therefore HTTP requests are ignored. The following highlighted code redirects all HTTP requests to HTTPS:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet_AddRedirectToHttps&highlight=7-)]

See [URL Rewriting Middleware](xref:fundamentals/url-rewriting) for more information.

Requiring HTTPS globally (`options.Filters.Add(new RequireHttpsAttribute());`) is a security best practice. Applying the 
`[RequireHttps]` attribute to all controller is not considered as secure as requiring HTTPS globally. You can't guarantee new controllers added to your app will remember to apply the `[RequireHttps]` attribute.

## Set up IIS Express for SSL/HTTPS

See [Setting up HTTPS for development in ASP.NET Core](xref:security/https#iisxpress).
