---
title: Enforcing HTTPS in an ASP.NET Core app
author: rick-anderson
description: Shows how to require HTTPS/TLS in a ASP.NET Core web app.
manager: wpickett
ms.author: riande
ms.date: 2/9/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/enforcing-ssl
---
# Enforcing HTTPS in an ASP.NET Core app

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

- Require HTTPS for all requests.
- Redirect all HTTP requests to HTTPS.

> [!WARNING]
> Do **not** use `RequireHttpsAttribute` on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
>* Not listen on HTTP.
>* Close the connection with status code 400 (Bad Request) and not serve the request.

## Require HTTPS

The [RequireHttpsAttribute](/dotnet/api/Microsoft.AspNetCore.Mvc.RequireHttpsAttribute) is used to require HTTPS. `[RequireHttpsAttribute]` can decorate controllers or methods, or can be applied globally. To apply the attribute globally, add the following code to `ConfigureServices` in `Startup`:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet2&highlight=4-999)]

The preceding highlighted code requires all requests use `HTTPS`; therefore, HTTP requests are ignored. The following highlighted code redirects all HTTP requests to HTTPS:

[!code-csharp[Main](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet_AddRedirectToHttps&highlight=7-999)]

For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).

Requiring HTTPS globally (`options.Filters.Add(new RequireHttpsAttribute());`) is a security best practice. Applying the
`[RequireHttps]` attribute to all controllers/Razor Pages isn't considered as secure as requiring HTTPS globally. You can't guarantee the `[RequireHttps]` attribute is applied when new controllers and Razor Pages are added.