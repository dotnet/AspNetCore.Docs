---
title: Enforcing TLS in an ASP.NET Core app
author: rick-anderson
description: Shows how to require HTTPS/TSL in a ASP.NET Core web app.
manager: wpickett
ms.author: riande
ms.date: 2/9/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/enforcing-ssl
---
# Enforcing HTTPS/TLS in an ASP.NET Core app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

- Require TLS for all requests (HTTPS requests only).
- Redirect all HTTP requests to HTTPS.

> [!WARNING]
> Do **not** use [RequireHttpsAttribute](/dotnet/api/Microsoft.AspNetCore.Mvc.RequireHttpsAttribute) on Web APIs that receive sensitive information. `RequireHttpsAttribute` does transparent redirection from HTTP to HTTPS, so the client never knows the information was sent insecurely over HTTP. Web APIs should close the connection with status code 400 (Bad Request) and not serve the request.

<a name="require-ssl"></a>
## Require TLS

The [RequireHttpsAttribute](/dotnet/api/Microsoft.AspNetCore.Mvc.RequireHttpsAttribute) is used to require TLS. `[RequireHttpsAttribute]` can decorate controllers or methods, or can be applied globally. To apply the attribute globally, add the following code to `ConfigureServices` in `Startup`:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet2&highlight=4-999)]

The preceding highlighted code requires all requests use `HTTPS`; therefore HTTP requests are ignored. The following highlighted code redirects all HTTP requests to HTTPS:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet_AddRedirectToHttps&highlight=7-999)]

 For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).

Requiring HTTPS globally (`options.Filters.Add(new RequireHttpsAttribute());`) is a security best practice. Applying the 
`[RequireHttps]` attribute to all controller isn't considered as secure as requiring HTTPS globally. You can't guarantee that when new controllers and Razor Pages are added, the `[RequireHttps]` attribute is applied.
