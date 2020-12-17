---
uid: identity/overview/features-api/account-confirmation-and-password-recovery-with-aspnet-identity
title: "Account Confirmation & Password Recovery - ASP.NET Identity (C#) - ASP.NET 4.x"
author: HaoK
description: "Before doing this tutorial you should first complete Create a secure ASP.NET MVC 5 web app with log in, email confirmation and password reset. This tutorial..."
ms.author: riande
ms.date: 01/23/2019
ms.assetid: 8d54180d-f826-4df7-b503-7debf5ed9fb3
ms.custom: seoapril2019
msc.legacyurl: /identity/overview/features-api/account-confirmation-and-password-recovery-with-aspnet-identity
msc.type: authoredcontent
---
# Account confirmation and password recovery with ASP.NET Identity (C#)

> Before doing this tutorial you should first complete [Create a secure ASP.NET MVC 5 web app with log in, email confirmation and password reset](../../../mvc/overview/security/create-an-aspnet-mvc-5----
title: Enforce HTTPS in ASP.NET Core
author: rick-anderson
description: Learn how to require HTTPS/TLS in a ASP.NET Core web app.
ms.author: riande
ms.custom: mvc
ms.date: 12/06/2019
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: security/enforcing-ssl
---
# Enforce HTTPS in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

This document shows how to:

* Require HTTPS for all requests.
* Redirect all HTTP requests to HTTPS.

No API can prevent a client from sending sensitive data on the first request.

::: moniker range=">= aspnetcore-3.0"

> [!WARNING]
> ## API projects
>
> Do **not** use [RequireHttpsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.requirehttpsattribute) on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
> * Not listen on HTTP.
> * Close the connection with status code 400 (Bad Request) and not serve the request.
>
> ## HSTS and API projects
>
> The default API projects don't include [HSTS](#hsts) because HSTS is generally a browser only instruction. Other callers, such as phone or desktop apps, do **not** obey the instruction. Even within browsers, a single authenticated call to an API over HTTP has risks on insecure networks. The secure approach is to configure API projects to only listen to and respond over HTTPS.

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

> [!WARNING]
> ## API projects
>
> Do **not** use [RequireHttpsAttribute](/dotnet/api/microsoft.aspnetcore.mvc.requirehttpsattribute) on Web APIs that receive sensitive information. `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS. API clients may not understand or obey redirects from HTTP to HTTPS. Such clients may send information over HTTP. Web APIs should either:
>
> * Not listen on HTTP.
> * Close the connection with status code 400 (Bad Request) and not serve the request.

::: moniker-end

## Require HTTPS

We recommend that production ASP.NET Core web apps use:

* HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection*>) to redirect HTTP requests to HTTPS.
* HSTS Middleware ([UseHsts](#http-strict-transport-security-protocol-hsts)) to send HTTP Strict Transport Security Protocol (HSTS) headers to clients.

> [!NOTE]
> Apps deployed in a reverse proxy configuration allow the proxy to handle connection security (HTTPS). If the proxy also handles HTTPS redirection, there's no need to use HTTPS Redirection Middleware. If the proxy server also handles writing HSTS headers (for example, [native HSTS support in IIS 10.0 (1709) or later](/iis/get-started/whats-new-in-iis-10-version-1709/iis-10-version-1709-hsts#iis-100-version-1709-native-hsts-support)), HSTS Middleware isn't required by the app. For more information, see [Opt-out of HTTPS/HSTS on project creation](#opt-out-of-httpshsts-on-project-creation).

### UseHttpsRedirection

The following code calls `UseHttpsRedirection` in the `Startup` class:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](enforcing-ssl/sample-snapshot/3.x/Startup.cs?name=snippet1&highlight=14)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](enforcing-ssl/sample-snapshot/2.x/Startup.cs?name=snippet1&highlight=13)]

::: moniker-end

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

::: moniker range=">= aspnetcore-3.0"

* Set the `https_port` [host setting](../fundamentals/host/generic-host.md#https_port):

  * In host configuration.
  * By setting the `ASPNETCORE_HTTPS_PORT` environment variable.
  * By adding a top-level entry in *appsettings.json*:

    [!code-json[](enforcing-ssl/sample-snapshot/3.x/appsettings.json?highlight=2)]

* Indicate a port with the secure scheme using the [ASPNETCORE_URLS environment variable](../fundamentals/host/generic-host.md#urls). The environment variable configures the server. The middleware indirectly discovers the HTTPS port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>. This approach doesn't work in reverse proxy deployments.

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

* Set the `https_port` [host setting](xref:fundamentals/host/web-host#https-port):

  * In host configuration.
  * By setting the `ASPNETCORE_HTTPS_PORT` environment variable.
  * By adding a top-level entry in *appsettings.json*:

    [!code-json[](enforcing-ssl/sample-snapshot/2.x/appsettings.json?highlight=2)]

* Indicate a port with the secure scheme using the [ASPNETCORE_URLS environment variable](xref:fundamentals/host/web-host#server-urls). The environment variable configures the server. The middleware indirectly discovers the HTTPS port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>. This approach doesn't work in reverse proxy deployments.

::: moniker-end

* In development, set an HTTPS URL in *launchsettings.json*. Enable HTTPS when IIS Express is used.

* Configure an HTTPS URL endpoint for a public-facing edge deployment of [Kestrel](xref:fundamentals/servers/kestrel) server or [HTTP.sys](xref:fundamentals/servers/httpsys) server. Only **one HTTPS port** is used by the app. The middleware discovers the port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>.

> [!NOTE]
> When an app is run in a reverse proxy configuration, <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature> isn't available. Set the port using one of the other approaches described in this section.

### Edge deployments 

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


::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](enforcing-ssl/sample-snapshot/3.x/Startup.cs?name=snippet2&highlight=14-18)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](enforcing-ssl/sample-snapshot/2.x/Startup.cs?name=snippet2&highlight=14-18)]

::: moniker-end


Calling `AddHttpsRedirection` is only necessary to change the values of `HttpsPort` or `RedirectStatusCode`.

The preceding highlighted code:

* Sets [HttpsRedirectionOptions.RedirectStatusCode](xref:Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions.RedirectStatusCode*) to <xref:Microsoft.AspNetCore.Http.StatusCodes.Status307TemporaryRedirect>, which is the default value. Use the fields of the <xref:Microsoft.AspNetCore.Http.StatusCodes> class for assignments to `RedirectStatusCode`.
* Sets the HTTPS port to 5001.

#### Configure permanent redirects in production

The middleware defaults to sending a [Status307TemporaryRedirect](/dotnet/api/microsoft.aspnetcore.http.statuscodes.status307temporaryredirect) with all redirects. If you prefer to send a permanent redirect status code when the app is in a non-Development environment, wrap the middleware options configuration in a conditional check for a non-Development environment.

::: moniker range=">= aspnetcore-3.0"

When configuring services in *Startup.cs*:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // IWebHostEnvironment (stored in _env) is injected into the Startup class.
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

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

When configuring services in *Startup.cs*:

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

::: moniker-end


## HTTPS Redirection Middleware alternative approach

An alternative to using HTTPS Redirection Middleware (`UseHttpsRedirection`) is to use URL Rewriting Middleware (`AddRedirectToHttps`). `AddRedirectToHttps` can also set the status code and port when the redirect is executed. For more information, see [URL Rewriting Middleware](xref:fundamentals/url-rewriting).

When redirecting to HTTPS without the requirement for additional redirect rules, we recommend using HTTPS Redirection Middleware (`UseHttpsRedirection`) described in this topic.

<a name="hsts"></a>

## HTTP Strict Transport Security Protocol (HSTS)

Per [OWASP](https://www.owasp.org/index.php/About_The_Open_Web_Application_Security_Project), [HTTP Strict Transport Security (HSTS)](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html) is an opt-in security enhancement that's specified by a web app through the use of a response header. When a [browser that supports HSTS](https://cheatsheetseries.owasp.org/cheatsheets/Transport_Layer_Protection_Cheat_Sheet.html#browser-support) receives this header:

* The browser stores configuration for the domain that prevents sending any communication over HTTP. The browser forces all communication over HTTPS.
* The browser prevents the user from using untrusted or invalid certificates. The browser disables prompts that allow a user to temporarily trust such a certificate.

Because HSTS is enforced by the client, it has some limitations:

* The client must support HSTS.
* HSTS requires at least one successful HTTPS request to establish the HSTS policy.
* The application must check every HTTP request and redirect or reject the HTTP request.

ASP.NET Core 2.1 and later implements HSTS with the `UseHsts` extension method. The following code calls `UseHsts` when the app isn't in [development mode](xref:fundamentals/environments):

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](enforcing-ssl/sample-snapshot/3.x/Startup.cs?name=snippet1&highlight=11)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](enforcing-ssl/sample-snapshot/2.x/Startup.cs?name=snippet1&highlight=10)]

::: moniker-end

`UseHsts` isn't recommended in development because the HSTS settings are highly cacheable by browsers. By default, `UseHsts` excludes the local loopback address.

For production environments that are implementing HTTPS for the first time, set the initial [HstsOptions.MaxAge](xref:Microsoft.AspNetCore.HttpsPolicy.HstsOptions.MaxAge*) to a small value using one of the <xref:System.TimeSpan> methods. Set the value from hours to no more than a single day in case you need to revert the HTTPS infrastructure to HTTP. After you're confident in the sustainability of the HTTPS configuration, increase the HSTS `max-age` value; a commonly used value is one year.

The following code:


::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](enforcing-ssl/sample-snapshot/3.x/Startup.cs?name=snippet2&highlight=5-12)]

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

[!code-csharp[](enforcing-ssl/sample-snapshot/2.x/Startup.cs?name=snippet2&highlight=5-12)]

::: moniker-end


* Sets the preload parameter of the `Strict-Transport-Security` header. Preload isn't part of the [RFC HSTS specification](https://tools.ietf.org/html/rfc6797), but is supported by web browsers to preload HSTS sites on fresh install. For more information, see [https://hstspreload.org/](https://hstspreload.org/).
* Enables [includeSubDomain](https://tools.ietf.org/html/rfc6797#section-6.1.2), which applies the HSTS policy to Host subdomains.
* Explicitly sets the `max-age` parameter of the `Strict-Transport-Security` header to 60 days. If not set, defaults to 30 days. For more information, see the [max-age directive](https://tools.ietf.org/html/rfc6797#section-6.1.1).
* Adds `example.com` to the list of hosts to exclude.

`UseHsts` excludes the following loopback hosts:

* `localhost` : The IPv4 loopback address.
* `127.0.0.1` : The IPv4 loopback address.
* `[::1]` : The IPv6 loopback address.

## Opt-out of HTTPS/HSTS on project creation

In some backend service scenarios where connection security is handled at the public-facing edge of the network, configuring connection security at each node isn't required. Web apps that are generated from the templates in Visual Studio or from the [dotnet new](/dotnet/core/tools/dotnet-new) command enable [HTTPS redirection](#require-https) and [HSTS](#http-strict-transport-security-protocol-hsts). For deployments that don't require these scenarios, you can opt-out of HTTPS/HSTS when the app is created from the template.

To opt-out of HTTPS/HSTS:

# [Visual Studio](#tab/visual-studio) 

Uncheck the **Configure for HTTPS** check box.

::: moniker range=">= aspnetcore-3.0"

![New ASP.NET Core Web Application dialog showing the Configure for HTTPS check box unselected.](enforcing-ssl/_static/out-vs2019.png)

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

![New ASP.NET Core Web Application dialog showing the Configure for HTTPS check box unselected.](enforcing-ssl/_static/out.png)

::: moniker-end


# [.NET Core CLI](#tab/netcore-cli) 

Use the `--no-https` option. For example

```dotnetcli
dotnet new webapp --no-https
```

---

<a name="trust"></a>

## Trust the ASP.NET Core HTTPS development certificate on Windows and macOS

The .NET Core SDK includes an HTTPS development certificate. The certificate is installed as part of the first-run experience. For example, `dotnet --info` produces a variation of the following output:

```
ASP.NET Core
------------
Successfully installed the ASP.NET Core HTTPS Development Certificate.
To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only).
For establishing trust on other platforms refer to the platform specific documentation.
For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
```

Installing the .NET Core SDK installs the ASP.NET Core HTTPS development certificate to the local user certificate store. The certificate has been installed, but it's not trusted. To trust the certificate, perform the one-time step to run the dotnet `dev-certs` tool:

```dotnetcli
dotnet dev-certs https --trust
```

The following command provides help on the `dev-certs` tool:

```dotnetcli
dotnet dev-certs https --help
```

## How to set up a developer certificate for Docker

See [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/6199).

<a name="ssl-linux"></a>

## Trust HTTPS certificate on Linux

<!-- Instructions to be updated by engineering team after 5.0 RTM. -->

For instructions on Linux, refer to the distribution documentation.

<a name="wsl"></a>

## Trust HTTPS certificate from Windows Subsystem for Linux

The Windows Subsystem for Linux (WSL) generates an HTTPS self-signed cert. To configure the Windows certificate store to trust the WSL certificate:

* Run the following command to export the WSL-generated certificate:

  ```
  dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p <cryptic-password>
  ```
* In a WSL window, run the following command:

  ```
    ASPNETCORE_Kestrel__Certificates__Default__Password="<cryptic-password>" 
    ASPNETCORE_Kestrel__Certificates__Default__Path=/mnt/c/Users/user-name/.aspnet/https/aspnetapp.pfx
    dotnet watch run
  ```

  The preceding command sets the environment variables so Linux uses the Windows trusted certificate.

## Troubleshoot certificate problems

This section provides help when the ASP.NET Core HTTPS development certificate has been [installed and trusted](#trust), but you still have browser warnings that the certificate is not trusted. The ASP.NET Core HTTPS development certificate is used by [Kestrel](xref:fundamentals/servers/kestrel).

To repair the IIS Express certificate, see [this Stackoverflow](https://stackoverflow.com/a/20048613/502537) issue.

### All platforms - certificate not trusted

Run the following commands:

```dotnetcli
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Close any browser instances open. Open a new browser window to app. Certificate trust is cached by browsers.

The preceding commands solve most browser trust issues. If the browser is still not trusting the certificate, follow the platform-specific suggestions that follow.

### Docker - certificate not trusted

* Delete the *C:\Users\{USER}\AppData\Roaming\ASP.NET\Https* folder.
* Clean the solution. Delete the *bin* and *obj* folders.
* Restart the development tool. For example, Visual Studio, Visual Studio Code, or Visual Studio for Mac.

### Windows - certificate not trusted

* Check the certificates in the certificate store. There should be a `localhost` certificate with the `ASP.NET Core HTTPS development certificate` friendly name both under `Current User > Personal > Certificates` and `Current User > Trusted root certification authorities > Certificates`
* Remove all the found certificates from both Personal and Trusted root certification authorities. Do **not** remove the IIS Express localhost certificate.
* Run the following commands:

```dotnetcli
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Close any browser instances open. Open a new browser window to app.

### OS X - certificate not trusted

* Open KeyChain Access.
* Select the System keychain.
* Check for the presence of a localhost certificate.
* Check that it contains a `+` symbol on the icon to indicate it's trusted for all users.
* Remove the certificate from the system keychain.
* Run the following commands:

```dotnetcli
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Close any browser instances open. Open a new browser window to app.

See [HTTPS Error using IIS Express (dotnet/AspNetCore #16892)](https://github.com/dotnet/AspNetCore/issues/16892) for troubleshooting certificate issues with Visual Studio.

### IIS Express SSL certificate used with Visual Studio

To fix problems with the IIS Express certificate, select **Repair** from the Visual Studio installer. For more information, see [this GitHub issue](https://github.com/dotnet/aspnetcore/issues/16892).

<a name="trust-ff"></a>

### Firefox SEC_ERROR_INADEQUATE_KEY_USAGE certificate error

The Firefox browser uses it's own certificate store, and therefore doesn't trust the [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) or [Kestrel](xref:fundamentals/servers/kestrel) developer certificates.

To use Firefox with IIS Express or Kestrel, set  `security.enterprise_roots.enabled` = `true`

1. Enter `about:config` in the FireFox browser.
1. Select **Accept the Risk and Continue** if you accept the risk.
1. Select **Show All**
1. Set `security.enterprise_roots.enabled` = `true`
1. Exit and restart Firefox

For more information, see [Setting Up Certificate Authorities (CAs) in Firefox](https://support.mozilla.org/kb/setting-certificate-authorities-firefox).

## Additional information

* <xref:host-and-deploy/proxy-load-balancer>
* [Host ASP.NET Core on Linux with Apache: HTTPS configuration](xref:host-and-deploy/linux-apache#https-configuration)
* [Host ASP.NET Core on Linux with Nginx: HTTPS configuration](xref:host-and-deploy/linux-nginx#https-configuration)
* [How to Set Up SSL on IIS](/iis/manage/configuring-security/how-to-set-up-ssl-on-iis)
* [OWASP HSTS browser support](https://www.owasp.org/index.php/HTTP_Strict_Transport_Security_Cheat_Sheet#Browser_Support)
web-app-with-email-confirmation-and-password-reset.md). This tutorial contains more details and will show you how to set up email for local account confirmation and allow users to reset their forgotten password in ASP.NET Identity.

A local user account requires the user to create a password for the account, and that password is stored (securely) in the web app. ASP.NET Identity also supports social accounts, which don't require the user to create a password for the app. [Social accounts](../../../mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on.md) use a third party (such as Google, Twitter, Facebook, or Microsoft) to authenticate users. This topic covers the following:

- [Create an ASP.NET MVC app](#createMvc) and explore ASP.NET Identity features.
- [Build the Identity sample](#build)
- [Set up email confirmation](#email)

New users register their email alias, which creates a local account.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image1.png)

Selecting the Register button sends a confirmation email containing a validation token to their email address.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image2.png)

The user is sent an email with a confirmation token for their account.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image3.png)

Selecting the link confirms the account.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image4.png)

<a id="passwordReset"></a>

## Password recovery/reset

Local users who forget their password can have a security token sent to their email account, enabling them to reset their password.  
  
![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image5.png)  
  
The user will soon get an email with a link allowing them to reset their password.  
  
![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image6.png)  
Selecting the link will take them to the Reset page.  
  
![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image7.png)  
  
Selecting the **Reset** button will confirm the password has been reset.  
  
![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image8.png)

<a id="createMvc"></a>

## Create an ASP.NET web app

Start by installing and running [Visual Studio 2017](https://visualstudio.microsoft.com/).

1. Create a new ASP.NET Web project and select the MVC template. Web Forms also support ASP.NET Identity, so you could follow similar steps in a web forms app.
2. Change the authentication to **Individual User Accounts**.
3. Run the app, select the **Register** link and register a user. At this point, the only validation on the email is with the [[EmailAddress]](https://msdn.microsoft.com/library/system.componentmodel.dataannotations.emailaddressattribute(v=vs.110).aspx) attribute.
4. In Server Explorer, navigate to **Data Connections\DefaultConnection\Tables\AspNetUsers**, right-click and select **Open table definition**.

    The following image shows the `AspNetUsers` schema:

    ![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image9.png)
5. Right-click on the **AspNetUsers** table and select **Show Table Data**.  
  
    ![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image10.png)  
  
   At this point the email has not been confirmed.

The default data store for ASP.NET Identity is Entity Framework, but you can configure it to use other data stores and to add additional fields. See [Additional Resources](#addRes) section at the end of this tutorial.

The [OWIN startup class](../../../aspnet/overview/owin-and-katana/owin-startup-class-detection.md) ( *Startup.cs* ) is called when the app starts and invokes the `ConfigureAuth` method in *App\_Start\Startup.Auth.cs*, which configures the OWIN pipeline and initializes ASP.NET Identity. Examine the `ConfigureAuth` method. Each `CreatePerOwinContext` call registers a callback (saved in the `OwinContext`) that will be called once per request to create an instance of the specified type. You can set a break point in the constructor and `Create` method of each type (`ApplicationDbContext, ApplicationUserManager`) and verify they are called on each request. A instance of `ApplicationDbContext` and `ApplicationUserManager` is stored in the OWIN context, which can be accessed throughout the application. ASP.NET Identity hooks into the OWIN pipeline through cookie middleware. For more information, see [Per request lifetime management for UserManager class in ASP.NET Identity](https://blogs.msdn.com/b/webdev/archive/2014/02/12/per-request-lifetime-management-for-usermanager-class-in-asp-net-identity.aspx).

When you change your security profile, a new security stamp is generated and stored in the `SecurityStamp` field of the *AspNetUsers* table. Note, the `SecurityStamp` field is different from the security cookie. The security cookie is not stored in the `AspNetUsers` table (or anywhere else in the Identity DB). The security cookie token is self-signed using [DPAPI](https://msdn.microsoft.com/library/system.security.cryptography.protecteddata.aspx) and is created with the `UserId, SecurityStamp` and expiration time information.

The cookie middleware checks the cookie on each request. The `SecurityStampValidator` method in the `Startup` class hits the DB and checks security stamp periodically, as specified with the `validateInterval`. This only happens every 30 minutes (in our sample) unless you change your security profile. The 30 minute interval was chosen to minimize trips to the database. See my [two-factor authentication tutorial](index.md) for more details.

Per the comments in the code, the `UseCookieAuthentication` method supports cookie authentication. The `SecurityStamp` field and associated code provides an extra layer of security to your app, when you change your password, you will be logged out of the browser you logged in with. The `SecurityStampValidator.OnValidateIdentity` method enables the app to validate the security token when the user logs in, which is used when you change a password or use the external login. This is needed to ensure that any tokens (cookies) generated with the old password are invalidated. In the sample project, if you change the users password then a new token is generated for the user, any previous tokens are invalidated and the `SecurityStamp` field is updated.

The Identity system allow you to configure your app so when the users security profile changes (for example, when the user changes their password or changes associated login (such as from Facebook, Google, Microsoft account, etc.), the user is logged out of all browser instances. For example, the image below shows the [Single signout sample](https://github.com/aspnet/samples/tree/master/samples/aspnet/Identity/SingleSignOutSample) app, which allows the user to sign out of all browser instances (in this case, IE, Firefox and Chrome) by selecting one button. Alternatively, the sample allows you to only log out of a specific browser instance.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image11.png)

The [Single signout sample](https://github.com/aspnet/samples/tree/master/samples/aspnet/Identity/SingleSignOutSample) app shows how ASP.NET Identity allows you to regenerate the security token. This is needed to ensure that any tokens (cookies) generated with the old password are invalidated. This feature provides an extra layer of security to your application; when you change your password, you will be logged out where you have logged into this application.

The *App\_Start\IdentityConfig.cs* file contains the `ApplicationUserManager`, `EmailService` and `SmsService` classes. The `EmailService` and `SmsService` classes each implement the `IIdentityMessageService` interface, so you have common methods in each class to configure email and SMS. Although this tutorial only shows how to add email notification through [SendGrid](http://sendgrid.com/), you can send email using SMTP and other mechanisms.

The `Startup` class also contains boiler plate to add social logins (Facebook, Twitter, etc.), see my tutorial [MVC 5 App with Facebook, Twitter, LinkedIn and Google OAuth2 Sign-on](../../../mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on.md) for more info.

Examine the `ApplicationUserManager` class, which contains the users identity information and configures the following features:

- Password strength requirements.
- User lock out (attempts and time).
- Two-factor authentication (2FA). I'll cover 2FA and SMS in another tutorial.
- Hooking up the email and SMS services. (I'll cover SMS in another tutorial).

The `ApplicationUserManager` class derives from the generic `UserManager<ApplicationUser>` class. `ApplicationUser` derives from [IdentityUser](https://msdn.microsoft.com/library/microsoft.aspnet.identity.entityframework.identityuser.aspx). `IdentityUser` derives from the generic `IdentityUser` class:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample1.cs)]

The properties above coincide with the properties in the `AspNetUsers` table, shown above.

Generic arguments on `IUser` enable you to derive a class using different types for the primary key. See the [ChangePK](https://github.com/aspnet/samples/tree/master/samples/aspnet/Identity/ChangePK) sample which shows how to change the primary key from string to int or GUID.

### ApplicationUser

`ApplicationUser` (`public class ApplicationUserManager : UserManager<ApplicationUser>`) is defined in *Models\IdentityModels.cs* as:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample2.cs?highlight=8-9)]

The highlighted code above generates a [ClaimsIdentity](https://msdn.microsoft.com/library/system.security.claims.claimsidentity.aspx). ASP.NET Identity and OWIN Cookie Authentication are claims-based, therefore the framework requires the app to generate a `ClaimsIdentity` for the user. `ClaimsIdentity` has information about all the claims for the user, such as the user's name, age and what roles the user belongs to. You can also add more claims for the user at this stage.

The OWIN `AuthenticationManager.SignIn` method passes in the `ClaimsIdentity` and signs in the user:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample3.cs?highlight=4-6)]

[MVC 5 App with Facebook, Twitter, LinkedIn and Google OAuth2 Sign-on](../../../mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on.md) shows how you can add additional properties to the `ApplicationUser` class.

## Email confirmation

It's a good idea to confirm the email a new user register with to verify they are not impersonating someone else (that is, they haven't registered with someone else's email). Suppose you had a discussion forum, you would want to prevent `"bob@example.com"` from registering as `"joe@contoso.com"`. Without email confirmation, `"joe@contoso.com"` could get unwanted email from your app. Suppose Bob accidentally registered as `"bib@example.com"` and hadn't noticed it, he wouldn't be able to use password recover because the app doesn't have his correct email. Email confirmation provides only limited protection from bots and doesn't provide protection from determined spammers, they have many working email aliases they can use to register.In the sample below, the user won't be able to change their password until their account has been confirmed (by them selecting a confirmation link received on the email account they registered with.) You can apply this work flow to other scenarios, for example sending a link to confirm and reset the password on new accounts created by the administrator, sending the user an email when they have changed their profile and so on. You generally want to prevent new users from posting any data to your web site before they have been confirmed by email, a SMS text message or another mechanism. <a id="build"></a>

## Build a more complete sample

In this section, you'll use NuGet to download a more complete sample we will work with.

1. Create a new ***empty*** ASP.NET Web project.
2. In the Package Manager Console, enter the following commands: 

    [!code-console[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample4.cmd)]

   In this tutorial, we'll use [SendGrid](http://sendgrid.com/) to send email. The `Identity.Samples` package installs the code we will be working with.
3. Set the [project to use SSL](../../../mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on.md).
4. Test local account creation by running the app, selecting the **Register** link, and posting the registration form.
5. Select the demo email link, which simulates email confirmation.
6. Remove the demo email link confirmation code from the sample (The `ViewBag.Link` code in the account controller. See the `DisplayEmail` and `ForgotPasswordConfirmation` action methods and razor views ).

> [!WARNING]
> If you change any of the security settings in this sample, productions apps will need to undergo a security audit that explicitly calls the changes made.

## Examine the code in App\_Start\IdentityConfig.cs

The sample shows how to create an account and add it to the *Admin* role. You should replace the email in the sample with the email you will be using for the admin account. The easiest way right now to create an administrator account is programmatically in the `Seed` method. We hope to have a tool in the future that will allow you to create and administer users and roles. The sample code does let you create and manage users and roles, but you must first have an administrators account to run the roles and user admin pages. In this sample, the admin account is created when the DB is seeded.

Change the password and change the name to an account where you can receive email notifications.

> [!WARNING]
> Security - Never store sensitive data in your source code.

As mentioned previously, the `app.CreatePerOwinContext` call in the startup class adds callbacks to the `Create` method of the app DB content, user manager and role manger classes. The OWIN pipeline calls the `Create` method on these classes for each request and stores the context for each class. The account controller exposes the user manager from the HTTP context (which contains the OWIN context):

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample5.cs)]

When a user registers a local account, the `HTTP Post Register` method is called:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample6.cs)]

The code above uses the model data to create a new user account using the email and password entered. If the email alias is in the data store, account creation fails and the form is displayed again. The `GenerateEmailConfirmationTokenAsync` method creates a secure confirmation token and stores it in the ASP.NET Identity data store. The [Url.Action](https://msdn.microsoft.com/library/dd505232(v=vs.118).aspx) method creates a link containing the `UserId` and confirmation token. This link is then emailed to the user, the user can select on the link in their email app to confirm their account.

<a id="email"></a>

## Set up email confirmation

Go to the SendGrid sign up page and register for free account. Add code similar to the following to configure SendGrid:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample7.cs?highlight=5)]

> [!NOTE]
> Email clients frequently accept only text messages (no HTML). You should provide the message in text and HTML. In the SendGrid sample above, this is done with the `myMessage.Text` and `myMessage.Html` code shown above.

The following code shows how to send email using the [MailMessage](https://msdn.microsoft.com/library/system.net.mail.mailmessage.aspx) class where `message.Body` returns only the link.

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample8.cs)]

> [!WARNING]
> Security - Never store sensitive data in your source code. The account and credentials are stored in the appSetting. On Azure, you can securely store these values on the **[Configure](https://blogs.msdn.com/b/webdev/archive/2014/06/04/queuebackgroundworkitem-to-reliably-schedule-and-run-long-background-process-in-asp-net.aspx)** tab in the Azure portal. See [Best practices for deploying passwords and other sensitive data to ASP.NET and Azure](best-practices-for-deploying-passwords-and-other-sensitive-data-to-aspnet-and-azure.md).

Enter your SendGrid credentials, run the app, register with an email alias can select the confirm link in your email. To see how to do this with your [Outlook.com](http://outlook.com) email account, see John Atten's [C# SMTP Configuration for Outlook.Com SMTP Host](http://typecastexception.com/post/2013/12/20/C-SMTP-Configuration-for-OutlookCom-SMTP-Host.aspx) and his[ASP.NET Identity 2.0: Setting Up Account Validation and Two-Factor Authorization](http://typecastexception.com/post/2014/04/20/ASPNET-Identity-20-Setting-Up-Account-Validation-and-Two-Factor-Authorization.aspx) posts.

Once a user selects the **Register** button a confirmation email containing a validation token is sent to their email address.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image12.png)

The user is sent an email with a confirmation token for their account.

![](account-confirmation-and-password-recovery-with-aspnet-identity/_static/image13.png)

## Examine the code

The following code shows the `POST ForgotPassword` method.

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample9.cs)]

The method fails silently if the user email has not been confirmed. If an error was posted for an invalid email address, malicious users could use that information to find valid userId (email aliases) to attack.

The following code shows the `ConfirmEmail` method in the account controller that is called when the user selects the confirmation link in the email sent to them:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample10.cs)]

Once a forgotten password token has been used, it's invalidated. The following code change in the `Create` method (in the *App\_Start\IdentityConfig.cs* file) sets the tokens to expire in 3 hours.

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample11.cs?highlight=6-8)]

With the code above, the forgotten password and the email confirmation tokens will expire in 3 hours. The default `TokenLifespan` is one day.

The following code shows the email confirmation method:

[!code-csharp[Main](account-confirmation-and-password-recovery-with-aspnet-identity/samples/sample12.cs)]

 To make your app more secure, ASP.NET Identity supports Two-Factor authentication (2FA). See [ASP.NET Identity 2.0: Setting Up Account Validation and Two-Factor Authorization](http://typecastexception.com/post/2014/04/20/ASPNET-Identity-20-Setting-Up-Account-Validation-and-Two-Factor-Authorization.aspx) by John Atten. Although you can set account lockout on login password attempt failures, that approach makes your login susceptible to [DOS](http://en.wikipedia.org/wiki/Denial-of-service_attack) lockouts. We recommend you use account lockout only with 2FA.  
<a id="addRes"></a>

## Additional resources

- [Overview of Custom Storage Providers for ASP.NET Identity](../extensibility/overview-of-custom-storage-providers-for-aspnet-identity.md)
- [MVC 5 App with Facebook, Twitter, LinkedIn and Google OAuth2 Sign-on](../../../mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on.md) also shows how to add profile information to the users table.
- [ASP.NET MVC and Identity 2.0: Understanding the Basics](http://typecastexception.com/post/2014/04/20/ASPNET-MVC-and-Identity-20-Understanding-the-Basics.aspx) by John Atten.
- [Introduction to ASP.NET Identity](../getting-started/introduction-to-aspnet-identity.md)
- [Announcing RTM of ASP.NET Identity 2.0.0](https://blogs.msdn.com/b/webdev/archive/2014/03/20/test-announcing-rtm-of-asp-net-identity-2-0-0.aspx) by Pranav Rastogi.
