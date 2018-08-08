---
title: Enforce HTTPS in ASP.NET Core
author: rick-anderson
description: Shows how to require HTTPS/TLS in a ASP.NET Core web app.
ms.author: riande
ms.date: 2/9/2018
uid: security/enforcing-ssl
---
# Enforce HTTPS in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

* Require HTTPS for all requests.
* Redirect all HTTP requests to HTTPS.

> [!WARNING]
> Do **not** use [RequireHttpsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.requirehttpsattribute) on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
> * Not listen on HTTP.
> * Close the connection with status code 400 (Bad Request) and not serve the request.

<a name="require"></a>
## Require HTTPS

::: moniker range=">= aspnetcore-2.1"

We recommend all ASP.NET Core web apps call HTTPS Redirection Middleware ([UseHttpsRedirection](/dotnet/api/microsoft.aspnetcore.builder.httpspolicybuilderextensions.usehttpsredirection)) to redirect all HTTP requests to HTTPS.

The following code calls `UseHttpsRedirection` in the `Startup` class:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=13)]

The preceding highlighted code:

* Uses the default [HttpsRedirectionOptions.RedirectStatusCode](/dotnet/api/microsoft.aspnetcore.httpspolicy.httpsredirectionoptions.redirectstatuscode) (`Status307TemporaryRedirect`). Production apps should call [UseHsts](#hsts).
* Uses the default [HttpsRedirectionOptions.HttpsPort](/dotnet/api/microsoft.aspnetcore.httpspolicy.httpsredirectionoptions.httpsport) (443).

The following code calls [AddHttpsRedirection](/dotnet/api/microsoft.aspnetcore.builder.httpsredirectionservicesextensions.addhttpsredirection) to configure middleware options:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=14-99)]

The preceding highlighted code:

* Sets [HttpsRedirectionOptions.RedirectStatusCode](/dotnet/api/microsoft.aspnetcore.httpspolicy.httpsredirectionoptions.redirectstatuscode) to `Status307TemporaryRedirect`, which is the default value. Production apps should call [UseHsts](#hsts).
* Sets the HTTPS port to 5001. The default value is 443.

The following mechanisms set the port automatically:

* The middleware can discover the ports via [IServerAddressesFeature](/dotnet/api/microsoft.aspnetcore.hosting.server.features.iserveraddressesfeature) when the following conditions apply:
  - Kestrel or HTTP.sys is used directly with HTTPS endpoints (also applies to running the app with Visual Studio Code's debugger).
  - Only **one HTTPS port** is used by the app.
* Visual Studio is used:
  - IIS Express has HTTPS enabled.
  - *launchSettings.json* sets the `sslPort` for IIS Express.

> [!NOTE]
> When an app is run behind a reverse proxy (for example, IIS, IIS Express), `IServerAddressesFeature` isn't available. The port must be manually configured. When the port isn't set, requests aren't redirected.

The port can be configured by setting the [https_port Web Host configuration setting](xref:fundamentals/host/web-host#https-port):

**Key**: https_port
**Type**: *string*
**Default**: A default value isn't set.
**Set using**: `UseSetting`
**Environment variable**: `<PREFIX_>HTTPS_PORT` (The prefix is `ASPNETCORE_` when using the Web Host.)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("https_port", "8080")
```

> [!NOTE]
> The port can be configured indirectly by setting the URL with the `ASPNETCORE_URLS` environment variable. The environment variable configures the server, and then the middleware indirectly discovers the HTTPS port via `IServerAddressesFeature`.

If no port is set:

* Requests aren't redirected.
* The middleware logs a warning.

> [!NOTE]
> An alternative to using HTTPS Redirection Middleware (`UseHttpsRedirection`) is to use URL Rewriting Middleware (`AddRedirectToHttps`). `AddRedirectToHttps` can also set the status code and port when the redirect is executed. For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).
>
> When redirecting to HTTPS without the requirement for additional redirect rules, we recommend using HTTPS Redirection Middleware (`UseHttpsRedirection`) described in this topic.

::: moniker-end

::: moniker range="< aspnetcore-2.1"

The [RequireHttpsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.requirehttpsattribute) is used to require HTTPS. `[RequireHttpsAttribute]` can decorate controllers or methods, or can be applied globally. To apply the attribute globally, add the following code to `ConfigureServices` in `Startup`:

[!code-csharp[](~/security/authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet2&highlight=4-999)]

The preceding highlighted code requires all requests use `HTTPS`; therefore, HTTP requests are ignored. The following highlighted code redirects all HTTP requests to HTTPS:

[!code-csharp[](authentication/accconfirm/sample/WebApp1/Startup.cs?name=snippet_AddRedirectToHttps&highlight=7-999)]

For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting). The middleware also permits the app to set the status code or the status code and the port when the redirect is executed.

Requiring HTTPS globally (`options.Filters.Add(new RequireHttpsAttribute());`) is a security best practice. Applying the
`[RequireHttps]` attribute to all controllers/Razor Pages isn't considered as secure as requiring HTTPS globally. You can't guarantee the `[RequireHttps]` attribute is applied when new controllers and Razor Pages are added.

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

<a name="hsts"></a>
## HTTP Strict Transport Security Protocol (HSTS)

Per [OWASP](https://www.owasp.org/index.php/About_The_Open_Web_Application_Security_Project), [HTTP Strict Transport Security (HSTS)](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet) is an opt-in security enhancement that's specified by a web app through the use of a response header. When a browser that supports HSTS receives this header:

* The browser stores configuration for the domain that prevents sending any communication over HTTP. The browser forces all communication over HTTPS. 
* The browser prevents the user from using untrusted or invalid certificates. The browser disables prompts that allow a user to temporarily trust such a certificate.

ASP.NET Core 2.1 or later implements HSTS with the `UseHsts` extension method. The following code calls `UseHsts` when the app isn't in [development mode](xref:fundamentals/environments):

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=10)]

`UseHsts` isn't recommended in development because the HSTS header is highly cacheable by browsers. By default, `UseHsts` excludes the local loopback address.

For production environments implementing HTTPS for the first time, set the initial HSTS value to a small value. Set the value from hours to no more than a single day in case you need to revert the HTTPS infrastructure to HTTP. After you're confident in the sustainability of the HTTPS configuration, increase the HSTS max-age value; a commonly used value is one year. 

The following code:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=5-12)]

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

The ASP.NET Core 2.1 or later web application templates (from Visual Studio or the dotnet command line) enable [HTTPS redirection](#require) and [HSTS](#hsts). For deployments that don't require HTTPS, you can opt-out of HTTPS. For example, some backend services where HTTPS is being handled externally at the edge, using HTTPS at each node is not needed.

To opt-out of HTTPS:

# [Visual Studio](#tab/visual-studio) 

Uncheck the **Configure for HTTPS** checkbox.

![Entity diagram](enforcing-ssl/_static/out.png)

#	[.NET Core CLI](#tab/netcore-cli) 

Use the `--no-https` option. For example

```console
dotnet new webapp --no-https
```

[!INCLUDE[](~/includes/webapp-alias-notice.md)]

---

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

## How to setup a developer certificate for Docker

See [this GitHub issue](https://github.com/aspnet/Docs/issues/6199).

::: moniker-end
