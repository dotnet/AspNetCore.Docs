---
title: Enforce HTTPS in an ASP.NET Core
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
# Enforce HTTPS in an ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

- Require HTTPS for all requests.
- Redirect all HTTP requests to HTTPS.

> [!WARNING]
> Do **not** use `RequireHttpsAttribute` on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
>* Not listen on HTTP.
>* Close the connection with status code 400 (Bad Request) and not serve the request.

<a name="require"></a>
## Require HTTPS

::: moniker range=">= aspnetcore-2.1"
We recommend all ASP.NET Core web apps call `UseHttpsRedirection` to redirect all HTTP requests to HTTPS. If `UseHsts` is called in the app, it must be called before `UseHttpsRedirection`.

The following code calls `UseHttpsRedirection` in the `Startup` class:

[!code-csharp[sample](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=13)]


The following code:

[!code-csharp[sample](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=14-99)]

* Sets `RedirectStatusCode`.
* Sets the HTTPS port to 5001.

::: moniker-end


::: moniker range="< aspnetcore-2.1"

The [RequireHttpsAttribute](/dotnet/api/Microsoft.AspNetCore.Mvc.RequireHttpsAttribute) is used to require HTTPS. `[RequireHttpsAttribute]` can decorate controllers or methods, or can be applied globally. To apply the attribute globally, add the following code to `ConfigureServices` in `Startup`:

[!code-csharp[](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet2&highlight=4-999)]

The preceding highlighted code requires all requests use `HTTPS`; therefore, HTTP requests are ignored. The following highlighted code redirects all HTTP requests to HTTPS:

[!code-csharp[](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet_AddRedirectToHttps&highlight=7-999)]

For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).

Requiring HTTPS globally (`options.Filters.Add(new RequireHttpsAttribute());`) is a security best practice. Applying the
`[RequireHttps]` attribute to all controllers/Razor Pages isn't considered as secure as requiring HTTPS globally. You can't guarantee the `[RequireHttps]` attribute is applied when new controllers and Razor Pages are added.

::: moniker-end

::: moniker range=">= aspnetcore-2.1"
<a name="hsts"></a>
## HTTP Strict Transport Security Protocol (HSTS)

Per [OWASP](https://www.owasp.org/index.php/About_The_Open_Web_Application_Security_Project), [HTTP Strict Transport Security (HSTS)](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet) is an opt-in security enhancement that is specified by a web application through the use of a special response header. Once a supported browser receives this header that browser will prevent any communications from being sent over HTTP to the specified domain and will instead send all communications over HTTPS. It also prevents HTTPS click through prompts on browsers.

ASP.NET Core 2.1 or later implements HSTS with the `UseHsts` extension method. The following code calls `UseHsts` when the app isn't in [development mode](xref:fundamentals/environments):

[!code-csharp[sample](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=10)]

`UseHsts` is not recommend in development because the HSTS header is highly cachable by browsers. By default, UseHsts excludes the local loopback address.

The following code:

[!code-csharp[sample](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=5-12)]

* Sets the preload parameter of the Strict-Transport-Security header. Preload is not part of the [RFC HSTS specification](https://tools.ietf.org/html/rfc6797), but is supported by web browsers to preload HSTS sites on fresh install. See [https://hstspreload.org/](https://hstspreload.org/) for more information.
* Enables [includeSubDomain](https://tools.ietf.org/html/rfc6797#section-6.1.2), which applies the HSTS policy to Host subdomains. 
* Explicitly sets the max-age parameter of the Strict-Transport-Security header to to 60 days. If not set, defaults to 30 days. See the [max-age directive](https://tools.ietf.org/html/rfc6797#section-6.1.1) for more information.
* Adds `example.com` to the list of hosts to exclude.

`UseHsts` excludes the following loopback hosts:

* `localhost` : The IPv4 loopback address.
* `127.0.0.1` : The IPv4 loopback address.
* `[::1]` : The IPv6 loopback address.

The preceding example shows how to add additional hosts.
::: moniker-end


::: moniker range=">= aspnetcore-2.1"
<a name="https"></a>
## Opt-out of HTTPS on project creation

The ASP.NET Core 2.1 and later web application templates (from Visual Studio or the dotnet command line) enable [HTTPS redirection](#require) and [HSTS](#hsts). For deployments that don't require HTTPS, you can opt-out of HTTPS. For example, some backend services where HTTPS is being handled externally at the edge, using HTTPS at each node is not needed.

To opt-out of HTTPS:

# [Visual Studio](#tab/visual-studio) 

Uncheck the **Configure for HTTPS** checkbox.

![Entity diagram](enforcing-ssl/_static/out.png)


#	[.NET Core CLI](#tab/netcore-cli) 

Use the `--no-https` option. For example

```cli
dotnet new razor --no-https
```

------

::: moniker-end

::: moniker range=">= aspnetcore-2.1"
## How to setup a developer certificate for Docker

See [this GitHub issue](https://github.com/aspnet/Docs/issues/6199).

::: moniker-end
