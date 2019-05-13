---
title: Enforce HTTPS in ASP.NET Core
author: rick-anderson
description: Learn how to require HTTPS/TLS in a ASP.NET Core web app.
ms.author: riande
ms.custom: mvc
ms.date: 12/01/2018
uid: security/enforcing-ssl
---
# Enforce HTTPS in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

* Require HTTPS for all requests.
* Redirect all HTTP requests to HTTPS.

No API can prevent a client from sending sensitive data on the first request.

> [!WARNING]
> Do **not** use [RequireHttpsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.requirehttpsattribute) on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
> * Not listen on HTTP.
> * Close the connection with status code 400 (Bad Request) and not serve the request.

## Require HTTPS

::: moniker range=">= aspnetcore-2.1"

We recommend that production ASP.NET Core web apps call:

* HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection*>) to redirect HTTP requests to HTTPS.
* HSTS Middleware ([UseHsts](#http-strict-transport-security-protocol-hsts)) to send HTTP Strict Transport Security Protocol (HSTS) headers to clients.

> [!NOTE]
> Apps deployed in a reverse proxy configuration allow the proxy to handle connection security (HTTPS). If the proxy also handles HTTPS redirection, there's no need to use HTTPS Redirection Middleware. If the proxy server also handles writing HSTS headers (for example, [native HSTS support in IIS 10.0 (1709) or later](/iis/get-started/whats-new-in-iis-10-version-1709/iis-10-version-1709-hsts#iis-100-version-1709-native-hsts-support)), HSTS Middleware isn't required by the app. For more information, see [Opt-out of HTTPS/HSTS on project creation](#opt-out-of-httpshsts-on-project-creation).

### UseHttpsRedirection

The following code calls `UseHttpsRedirection` in the `Startup` class:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=13)]

The preceding highlighted code:

* Uses the default [HttpsRedirectionOptions.RedirectStatusCode](/dotnet/api/microsoft.aspnetcore.httpspolicy.httpsredirectionoptions.redirectstatuscode) ([Status307TemporaryRedirect](/dotnet/api/microsoft.aspnetcore.http.statuscodes.status307temporaryredirect)).
* Uses the default [HttpsRedirectionOptions.HttpsPort](/dotnet/api/microsoft.aspnetcore.httpspolicy.httpsredirectionoptions.httpsport) (null) unless overridden by the `ASPNETCORE_HTTPS_PORT` environment variable or [IServerAddressesFeature](/dotnet/api/microsoft.aspnetcore.hosting.server.features.iserveraddressesfeature).

We recommend using temporary redirects rather than permanent redirects. Link caching can cause unstable behavior in development environments. If you prefer to send a permanent redirect status code when the app is in a non-Development environment, see the [Configure permanent redirects in production](#configure-permanent-redirects-in-production) section. We recommend using [HSTS](#http-strict-transport-security-protocol-hsts) to signal to clients that only secure resource requests should be sent to the app (only in production).

### Port configuration

A port must be available for the middleware to redirect an insecure request to HTTPS. If no port is available:

* Redirection to HTTPS doesn't occur.
* The middleware logs the warning "Failed to determine the https port for redirect."

Specify the HTTPS port using any of the following approaches:

* Set [HttpsRedirectionOptions.HttpsPort](#options).
* Set the `ASPNETCORE_HTTPS_PORT` environment variable or [https_port Web Host configuration setting](xref:fundamentals/host/web-host#https-port):

  **Key**: `https_port`  
  **Type**: *string*  
  **Default**: A default value isn't set.  
  **Set using**: `UseSetting`  
  **Environment variable**: `<PREFIX_>HTTPS_PORT` (The prefix is `ASPNETCORE_` when using the [Web Host](xref:fundamentals/host/web-host).)

  When configuring an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> in `Program`:

  [!code-csharp[](enforcing-ssl/sample-snapshot/Program.cs?name=snippet_Program&highlight=10)]
* Indicate a port with the secure scheme using the `ASPNETCORE_URLS` environment variable. The environment variable configures the server. The middleware indirectly discovers the HTTPS port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>. This approach doesn't work in reverse proxy deployments.
* In development, set an HTTPS URL in *launchsettings.json*. Enable HTTPS when IIS Express is used.
* Configure an HTTPS URL endpoint for a public-facing edge deployment of [Kestrel](xref:fundamentals/servers/kestrel) server or [HTTP.sys](xref:fundamentals/servers/httpsys) server. Only **one HTTPS port** is used by the app. The middleware discovers the port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>.

> [!NOTE]
> When an app is run in a reverse proxy configuration, <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature> isn't available. Set the port using one of the other approaches described in this section.

When Kestrel or HTTP.sys is used as a public-facing edge server, Kestrel or HTTP.sys must be configured to listen on both:

* The secure port where the client is redirected (typically, 443 in production and 5001 in development).
* The insecure port (typically, 80 in production and 5000 in development).

The insecure port must be accessible by the client in order for the app to receive an insecure request and redirect the client to the secure port.

For more information, see [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel#endpoint-configuration) or <xref:fundamentals/servers/httpsys>.

### Deployment scenarios

Any firewall between the client and server must also have communication ports open for traffic.

If requests are forwarded in a reverse proxy configuration, use [Forwarded Headers Middleware](xref:host-and-deploy/proxy-load-balancer) before calling HTTPS Redirection Middleware. Forwarded Headers Middleware updates the `Request.Scheme`, using the `X-Forwarded-Proto` header. The middleware permits redirect URIs and other security policies to work correctly. When Forwarded Headers Middleware isn't used, the backend app might not receive the correct scheme and end up in a redirect loop. A common end user error message is that too many redirects have occurred.

When deploying to Azure App Service, follow the guidance in [Tutorial: Bind an existing custom SSL certificate to Azure Web Apps](/azure/app-service/app-service-web-tutorial-custom-ssl).

### Options

The following highlighted code calls [AddHttpsRedirection](/dotnet/api/microsoft.aspnetcore.builder.httpsredirectionservicesextensions.addhttpsredirection) to configure middleware options:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=14-99)]

Calling `AddHttpsRedirection` is only necessary to change the values of `HttpsPort` or `RedirectStatusCode`.

The preceding highlighted code:

* Sets [HttpsRedirectionOptions.RedirectStatusCode](xref:Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions.RedirectStatusCode*) to <xref:Microsoft.AspNetCore.Http.StatusCodes.Status307TemporaryRedirect>, which is the default value. Use the fields of the <xref:Microsoft.AspNetCore.Http.StatusCodes> class for assignments to `RedirectStatusCode`.
* Sets the HTTPS port to 5001. The default value is 443.

#### Configure permanent redirects in production

The middleware defaults to sending a [Status307TemporaryRedirect](/dotnet/api/microsoft.aspnetcore.http.statuscodes.status307temporaryredirect) with all redirects. If you prefer to send a permanent redirect status code when the app is in a non-Development environment, wrap the middleware options configuration in a conditional check for a non-Development environment.

When configuring an `IWebHostBuilder` in *Startup.cs*:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // IHostingEnvironment (stored in _env) is injected into the Startup class.
    if (!_env.IsDevelopment())
    {
        services.AddHttpsRedirection(options =>
        {
            options.RedirectStatusCode = StatusCodes.Status308PermanentRedirect;
            options.HttpsPort = 443;
        });
    }
}
```

## HTTPS Redirection Middleware alternative approach

An alternative to using HTTPS Redirection Middleware (`UseHttpsRedirection`) is to use URL Rewriting Middleware (`AddRedirectToHttps`). `AddRedirectToHttps` can also set the status code and port when the redirect is executed. For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).

When redirecting to HTTPS without the requirement for additional redirect rules, we recommend using HTTPS Redirection Middleware (`UseHttpsRedirection`) described in this topic.

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

## HTTP Strict Transport Security Protocol (HSTS)

Per [OWASP](https://www.owasp.org/index.php/About_The_Open_Web_Application_Security_Project), [HTTP Strict Transport Security (HSTS)](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet) is an opt-in security enhancement that's specified by a web app through the use of a response header. When a [browser that supports HSTS](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet#Browser_Support) receives this header:

* The browser stores configuration for the domain that prevents sending any communication over HTTP. The browser forces all communication over HTTPS.
* The browser prevents the user from using untrusted or invalid certificates. The browser disables prompts that allow a user to temporarily trust such a certificate.

Because HSTS is enforced by the client it has some limitations:

* The client must support HSTS.
* HSTS requires at least one successful HTTPS request to establish the HSTS policy.
* The application must check every HTTP request and redirect or reject the HTTP request.

ASP.NET Core 2.1 or later implements HSTS with the `UseHsts` extension method. The following code calls `UseHsts` when the app isn't in [development mode](xref:fundamentals/environments):

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet1&highlight=10)]

`UseHsts` isn't recommended in development because the HSTS settings are highly cacheable by browsers. By default, `UseHsts` excludes the local loopback address.

For production environments implementing HTTPS for the first time, set the initial [HstsOptions.MaxAge](xref:Microsoft.AspNetCore.HttpsPolicy.HstsOptions.MaxAge*) to a small value using one of the <xref:System.TimeSpan> methods. Set the value from hours to no more than a single day in case you need to revert the HTTPS infrastructure to HTTP. After you're confident in the sustainability of the HTTPS configuration, increase the HSTS max-age value; a commonly used value is one year.

The following code:

[!code-csharp[](enforcing-ssl/sample/Startup.cs?name=snippet2&highlight=5-12)]

* Sets the preload parameter of the Strict-Transport-Security header. Preload isn't part of the [RFC HSTS specification](https://tools.ietf.org/html/rfc6797), but is supported by web browsers to preload HSTS sites on fresh install. See [https://hstspreload.org/](https://hstspreload.org/) for more information.
* Enables [includeSubDomain](https://tools.ietf.org/html/rfc6797#section-6.1.2), which applies the HSTS policy to Host subdomains.
* Explicitly sets the max-age parameter of the Strict-Transport-Security header to 60 days. If not set, defaults to 30 days. See the [max-age directive](https://tools.ietf.org/html/rfc6797#section-6.1.1) for more information.
* Adds `example.com` to the list of hosts to exclude.

`UseHsts` excludes the following loopback hosts:

* `localhost` : The IPv4 loopback address.
* `127.0.0.1` : The IPv4 loopback address.
* `[::1]` : The IPv6 loopback address.

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

## Opt-out of HTTPS/HSTS on project creation

In some backend service scenarios where connection security is handled at the public-facing edge of the network, configuring connection security at each node isn't required. Web apps generated from the templates in Visual Studio or from the [dotnet new](/dotnet/core/tools/dotnet-new) command enable [HTTPS redirection](#require-https) and [HSTS](#http-strict-transport-security-protocol-hsts). For deployments that don't require these scenarios, you can opt-out of HTTPS/HSTS when the app is created from the template.

To opt-out of HTTPS/HSTS:

# [Visual Studio](#tab/visual-studio) 

Uncheck the **Configure for HTTPS** check box.

![New ASP.NET Core Web Application dialog showing the Configure for HTTPS check box unselected.](enforcing-ssl/_static/out.png)

# [.NET Core CLI](#tab/netcore-cli) 

Use the `--no-https` option. For example

```console
dotnet new webapp --no-https
```

---

::: moniker-end

::: moniker range=">= aspnetcore-2.1"

## Trust the ASP.NET Core HTTPS development certificate on Windows and macOS

.NET Core SDK includes a HTTPS development certificate. The certificate is installed as part of the first-run experience. For example, `dotnet --info` produces output similar to the following:

```text
ASP.NET Core
------------
Successfully installed the ASP.NET Core HTTPS Development Certificate.
To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only).
For establishing trust on other platforms refer to the platform specific documentation.
For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
```

Installing the .NET Core SDK installs the ASP.NET Core HTTPS development certificate to the local user certificate store. The certificate has been installed, but it's not trusted. To trust the certificate perform the one-time step to run the dotnet `dev-certs` tool:

```console
dotnet dev-certs https --trust
```

The following command provides help on the `dev-certs` tool:

```console
dotnet dev-certs https --help
```

## How to set up a developer certificate for Docker

See [this GitHub issue](https://github.com/aspnet/AspNetCore.Docs/issues/6199).

::: moniker-end

<a name="wsl"></a>

## Trust HTTPS certificate from Windows Subsystem for Linux

The Windows Subsystem for Linux (WSL) generates a HTTPS self-signed cert. To configure the Windows certificate store to trust the WSL certificate:

* Run the following command to export the Windows generated certificate:
  `dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p <cryptic-password>`
* In a WSL window, run the following command:
  `ASPNETCORE_Kestrel__Certificates__Default__Password="<cryptic-password>" ASPNETCORE_Kestrel__Certificates__Default__Path=/mnt/c/Users/user-name/.aspnet/https/aspnetapp.pfx dotnet watch run`

  The preceding command sets the environment variables so linux uses the Windows trusted certificate.



## Additional information

* <xref:host-and-deploy/proxy-load-balancer>
* [Host ASP.NET Core on Linux with Apache: HTTPS configuration](xref:host-and-deploy/linux-apache#https-configuration)
* [Host ASP.NET Core on Linux with Nginx: HTTPS configuration](xref:host-and-deploy/linux-nginx#https-configuration)
* [How to Set Up SSL on IIS](/iis/manage/configuring-security/how-to-set-up-ssl-on-iis)
* [OWASP HSTS browser support](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet#Browser_Support)
