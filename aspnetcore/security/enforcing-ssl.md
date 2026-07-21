---
title: Enforce HTTPS in ASP.NET Core
author: tdykstra
description: Learn how to require HTTPS/TLS in an ASP.NET Core web app, and find troubleshooting steps for untrusted certificate issues.
ms.author: tdykstra
monikerRange: '>= aspnetcore-3.0'
ms.custom: mvc, linux-related-content
ms.date: 05/13/2026
uid: security/enforcing-ssl

# customer intent: As an ASP.NET Core web app developer, I want to force incoming requests to use HTTPS/TLS, so I can avoid insecure interaction with my apps.
---
# Enforce HTTPS in ASP.NET Core

By [David Galvan](https://www.linkedin.com/in/dave-galvan/) and [Rick Anderson](https://twitter.com/RickAndMSFT)

To enforce incoming requests to your ASP.NET Core apps to use HTTPS/TLS, you can:

* Require HTTPS for all requests.
* Redirect all HTTP requests to HTTPS.

No API can prevent a client from sending sensitive data on the first request.

This article describes how to configure your ASP.NET Core apps to require HTTPS/TLS or redirect HTTP requests to HTTPS/TLS for secure interaction. Troubleshooting steps are provided for various platforms to resolve untrusted certificate issues.

:::moniker range=">= aspnetcore-9.0"

## API projects

Projects that use Web APIs should either:

* Not listen on HTTP.
* Close the connection with status code 400 (Bad Request) and not serve the request.

To disable HTTP redirection in an API, set the `ASPNETCORE_URLS` environment variable or use the `--urls` command line flag. For more information, see <xref:fundamentals/environments> and [8 ways to set the URLs for an ASP.NET Core app](https://andrewlock.net/8-ways-to-set-the-urls-for-an-aspnetcore-app/) by Andrew Lock.

> [!WARNING]
> Do **not** use <xref:Microsoft.AspNetCore.Mvc.RequireHttpsAttribute> on Web APIs that receive sensitive information.
> `RequireHttpsAttribute` uses HTTP status codes to redirect browsers from HTTP to HTTPS.
> API clients might not understand or obey redirects from HTTP to HTTPS, and they might send information over HTTP.

### HSTS and API projects

The secure approach for [HTTP Strict Transport Security (HSTS) protocol](#hsts) is to configure API projects to only listen to and respond over HTTPS.

> [!WARNING]
> The default API projects don't include [HSTS](https://developer.mozilla.org/docs/Web/HTTP/Headers/Strict-Transport-Security) because it's generally a browser only instruction. Other callers, such as phone or desktop apps, do **not** obey the instruction. Even within browsers, a single authenticated call to an API over HTTP has risks on insecure networks.

### HTTP redirect to HTTPS (ERR_INVALID_REDIRECT on CORS preflight request)

When a request to an endpoint using HTTP is redirected to HTTPS with the <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A> method, the redirection fails with the `ERR_INVALID_REDIRECT` error on the CORS preflight request.

API projects can reject HTTP requests rather than use the `UseHttpsRedirection` method to redirect requests to HTTPS.

## Require HTTPS

For production ASP.NET Core web apps, the following approach is recommended:

* To redirect HTTP requests to HTTPS, use HTTPS redirection middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>).

* To send HSTS headers to clients, use HSTS middleware via the [UseHsts](#hsts) method.

> [!NOTE]
> Apps deployed in a reverse proxy configuration allow the proxy to handle connection security (HTTPS). If the proxy also handles HTTPS redirection, there's no need to use HTTPS redirection middleware. If the proxy server also handles writing HSTS headers (for example, [native HSTS support in Internet Information Services (IIS) 10.0 version 1709 or later](/iis/get-started/whats-new-in-iis-10-version-1709/iis-10-version-1709-hsts#iis-100-version-1709-native-hsts-support)), then the app doesn't require HSTS middleware. For more information, see [Opt-out of HTTPS/HSTS on project creation](#opt-out-of-httpshsts-on-project-creation).

### UseHttpsRedirection

The following code calls the <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A> method in the _Program.cs_ file:

[!code-csharp[](enforcing-ssl/sample-snapshot/6.x/Program.cs?highlight=13)]

The preceding highlighted code:

* Uses the default <xref:Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions.RedirectStatusCode?displayProperty=nameWithType> property with the <xref:Microsoft.AspNetCore.Http.StatusCodes.Status307TemporaryRedirect> code.
* Uses the default <xref:Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions.HttpsPort?displayProperty=nameWithType> property (passing null), unless overridden by the `ASPNETCORE_HTTPS_PORT` environment variable or <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>.

The recommended approach is to use temporary redirects rather than permanent redirects. Link caching can cause unstable behavior in development environments. If you prefer to send a permanent redirect status code when the app is in a non-`Development` environment, see the [Configure permanent redirects in production](#configure-permanent-redirects-in-production) section. Use [HSTS](#hsts) to signal to clients that only secure resource requests should be sent to the app (only in production).

### Port configuration

A port must be available for the middleware to redirect an insecure request to HTTPS. If no port is available:

* Redirection to HTTPS doesn't occur.
* The middleware logs the warning _Failed to determine the https port for redirect_.

Specify the HTTPS port by using any of the following approaches:

* Set [HttpsRedirectionOptions.HttpsPort](#options).
* Set the `https_port` [host setting](xref:fundamentals/host/generic-host#https-port):
   * In host configuration.
   * By setting the `ASPNETCORE_HTTPS_PORT` environment variable.
   * By adding a top-level entry in the _appsettings.json_ file:

      [!code-json[](enforcing-ssl/sample-snapshot/6.x/appsettings.json?highlight=2)]

* Indicate a port with the secure scheme by using the [ASPNETCORE_URLS environment variable](xref:fundamentals/host/generic-host#server-urls). The environment variable configures the server. The middleware indirectly discovers the HTTPS port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>. This approach doesn't work in reverse proxy deployments.
* The ASP.NET Core web templates set an HTTPS URL in the _Properties/launchsettings.json_ file for both Kestrel and IIS Express. The _launchsettings.json_ file is used on the local machine only.
* Configure an HTTPS URL endpoint for a public-facing edge deployment of [Kestrel](xref:fundamentals/servers/kestrel) server or [HTTP.sys](xref:fundamentals/servers/httpsys) server. Only **one HTTPS port** is used by the app. The middleware discovers the port via <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature>.

> [!NOTE]
> When an app runs in a reverse proxy configuration, <xref:Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature> isn't available. Set the port by using one of the other approaches described in this section.

### Edge deployments

When [Kestrel](xref:fundamentals/servers/kestrel) or [HTTP.sys](xref:fundamentals/servers/httpsys) is used as a public-facing edge server, Kestrel or HTTP.sys must be configured to listen on both:

* The secure port where the client is redirected (typically, 443 in production and 5001 in development).
* The insecure port (typically, 80 in production and 5000 in development).

The insecure port must be accessible by the client for the app to receive an insecure request and redirect the client to the secure port.

For more information, see [Kestrel endpoint configuration](xref:fundamentals/servers/kestrel/endpoints) or <xref:fundamentals/servers/httpsys>.

### Deployment scenarios

Any firewall between the client and server must also have communication ports open for traffic.

If requests are forwarded in a reverse proxy configuration, use [forwarded headers middleware](xref:host-and-deploy/proxy-load-balancer) before calling HTTPS redirection middleware. Forwarded headers middleware updates the `Request.Scheme` by using the `X-Forwarded-Proto` header. The middleware permits redirect URIs and other security policies to work correctly. When forwarded headers middleware isn't used, the back-end app might not receive the correct scheme and get caught in a redirect loop. A common end user error message is there are too many redirects.

When deploying to Azure App Service, follow the guidance in [Enable HTTPS for a custom domain in Azure App Service](/azure/app-service/configure-ssl-bindings).

### Options

The following highlighted code calls the <xref:Microsoft.AspNetCore.Builder.HttpsRedirectionServicesExtensions.AddHttpsRedirection%2A> method to configure middleware options:

[!code-csharp[](enforcing-ssl/sample-snapshot/6.x/Program2.cs?highlight=16-20)]

Calling `AddHttpsRedirection` is only necessary to change the values of `HttpsPort` or `RedirectStatusCode`.

The preceding highlighted code:

* Sets the <xref:Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionOptions.RedirectStatusCode%2A?displayProperty=nameWithType> property to the <xref:Microsoft.AspNetCore.Http.StatusCodes.Status307TemporaryRedirect> code, which is the default value. Use the fields of the <xref:Microsoft.AspNetCore.Http.StatusCodes> class for assignments to `RedirectStatusCode`.
* Sets the HTTPS port to 5001.

#### Configure permanent redirects in production

The middleware defaults to sending a <xref:Microsoft.AspNetCore.Http.StatusCodes.Status307TemporaryRedirect> code with all redirects. If you prefer to send a permanent redirect status code when the app is in a non-`Development` environment, wrap the middleware options configuration in a conditional check for a non-`Development` environment.

The following code shows configuration of services in the _Program.cs_ file:

[!code-csharp[](enforcing-ssl/sample-snapshot/6.x/Program3.cs?highlight=7-14)]

## HTTPS redirection middleware alternative approach

An alternative to using HTTPS redirection middleware (with the `UseHttpsRedirection` method) is to use URL rewriting middleware (via the `AddRedirectToHttps` method). `AddRedirectToHttps` can also set the status code and port when the redirect is executed. For more information, see [URL rewriting middleware](xref:fundamentals/url-rewriting).

When the app redirects to HTTPS without the requirement for other redirect rules, the recommendation is to use HTTPS redirection middleware (`UseHttpsRedirection`) as described in this article.

<a name="hsts"></a>

## HTTP Strict Transport Security (HSTS) protocol

Per [OWASP](https://owasp.org/about/), [HSTS](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html) is an opt-in security enhancement specified by a web app via a response header. When a [browser that supports HSTS](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html#browser-support) receives this header:

* The browser stores configuration for the domain that prevents sending any communication over HTTP. The browser forces all communication over HTTPS.
* The browser prevents the user from using untrusted or invalid certificates. The browser disables prompts that allow a user to temporarily trust such a certificate.

Because the client enforces [HSTS](https://developer.mozilla.org/docs/Web/HTTP/Reference/Headers/Strict-Transport-Security), there are some limitations:

* The client must support HSTS.
* HSTS requires at least one successful HTTPS request to establish the HSTS policy.
* The application must check every HTTP request and redirect or reject the HTTP request.

ASP.NET Core implements HSTS with the <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A> extension method. The following code calls `UseHsts` when the app isn't in [development mode](xref:fundamentals/environments):

[!code-csharp[](enforcing-ssl/sample-snapshot/6.x/Program.cs?highlight=10)]

`UseHsts` isn't recommended in development because the HSTS settings are highly cacheable by browsers. By default, `UseHsts` excludes the local loopback address.

For production environments that are implementing HTTPS for the first time, set the initial <xref:Microsoft.AspNetCore.HttpsPolicy.HstsOptions.MaxAge%2A?displayProperty=nameWithType> property value to a small amount by using one of the <xref:System.TimeSpan> methods. Set the value from hours to no more than a single day, in case you need to revert the HTTPS infrastructure to HTTP. After you're confident in the sustainability of the HTTPS configuration, increase the HSTS `max-age` value (commonly, one year).

The following highlighted code:

[!code-csharp[](enforcing-ssl/sample-snapshot/6.x/Program2.cs?highlight=7-14)]

* Sets the preload parameter of the `Strict-Transport-Security` header. Preload isn't part of the [RFC 6797 HSTS specification](https://datatracker.ietf.org/doc/html/rfc6797). Web browsers support preload of HSTS sites on fresh install. For more information, see [https://hstspreload.org/](https://hstspreload.org/).
* Enables the `includeSubDomain` directive, which applies the HSTS policy to host subdomains. For more information, see [RFC 6797 HSTS specification (Section 6.1.2)](https://datatracker.ietf.org/doc/html/rfc6797#section-6.1.2).
* Explicitly sets the `max-age` parameter of the `Strict-Transport-Security` header to 60 days. If not set, it defaults to 30 days. For more information, see the `max-age` directive in [RFC 6797 HSTS specification (Section 6.1.1)](https://datatracker.ietf.org/doc/html/rfc6797#section-6.1.1).
* Adds `example.com` to the list of hosts to exclude.

`UseHsts` excludes the following loopback hosts:

* `localhost`: The IPv4 loopback address.
* `127.0.0.1`: The IPv4 loopback address.
* `[::1]`: The IPv6 loopback address.

## Opt out of HTTPS/HSTS on project creation

In some back-end service scenarios where connection security is handled at the public-facing edge of the network, configuring connection security at each node isn't required. Web apps that are generated from the templates in Visual Studio or from the [dotnet new](/dotnet/core/tools/dotnet-new) command enable [HTTPS redirection](#require-https) and [HSTS](#hsts). For deployments that don't require these scenarios, you can opt out of HTTPS/HSTS when the app is created from the template.

To opt out of HTTPS/HSTS:

# [Visual Studio](#tab/visual-studio) 

When you create a new ASP.NET Core web app, unselect the **Configure for HTTPS** option:

:::image type="content" source="enforcing-ssl/_static/out-vs2022.png" border="false" alt-text="Screenshot that shows the 'Create a new ASP.NET Core web application' dialog in Visual Studio, and 'Configure for HTTPS' unselected.":::

# [.NET CLI](#tab/net-cli) 

Use the `--no-https` option with the `dotnet new webapp` command, for example:

```dotnetcli
dotnet new webapp --no-https
```

---

<a name="trust"></a>

## Trust the ASP.NET Core HTTPS development certificate

The .NET SDK includes an HTTPS development certificate. The certificate is installed as part of the first-run experience. For example, the `dotnet --info` command produces a variation of the following output:

```cli
ASP.NET Core
------------
Successfully installed the ASP.NET Core HTTPS Development Certificate.
To trust the certificate run 'dotnet dev-certs https --trust' (Windows and macOS only).
For establishing trust on other platforms refer to the platform specific documentation.
For more information on configuring HTTPS see https://go.microsoft.com/fwlink/?linkid=848054.
```

Installing the .NET SDK installs the ASP.NET Core HTTPS development certificate to the local user certificate store. The certificate is installed, but it isn't trusted. To trust the certificate, perform the one-time step to run the `dotnet dev-certs` tool:

```dotnetcli
dotnet dev-certs https --trust
```

The following command provides help on the `dotnet dev-certs` tool:

```dotnetcli
dotnet dev-certs https --help
```

> [!WARNING]
> Don't create a development certificate in an environment planned for redistribution, such as a container image or virtual machine. This scenario can lead to spoofing and elevation of privilege. To help prevent this situation, set the `DOTNET_GENERATE_ASPNET_CERTIFICATE` environment variable to `false` before calling the .NET CLI for the first time. This approach skips the automatic generation of the ASP.NET Core development certificate during the CLI's first-run experience.

## Set up developer certificate for Docker

To configure the developer certificate for Docker, see [GitHub dotnet/aspnetcore.docs issue #6199](https://github.com/dotnet/AspNetCore.Docs/issues/6199) - _How to set up the dev certificate when using Docker in development_.

## Linux-specific considerations

Linux distributions differ substantially in how they mark certificates as trusted.

The `dotnet dev-certs` tool is expected to be broadly applicable, but official support is available for Ubuntu and Fedora only. The support specifically aims to ensure trust in Firefox and Chromium-based browsers (Microsoft Edge, Chrome, and Chromium).

### Dependencies

* To establish OpenSSL trust, the `openssl` tool must be on the path.
* To establish browser trust (for example in Microsoft Edge or Firefox), the `certutil` tool must be on the path.

### OpenSSL trust

When an ASP.NET Core development certificate is trusted, the certificate is exported to a folder in the current user's home directory. To have [OpenSSL](https://www.openssl.org/) (and clients that consume it) pick up this folder, you need to set the `SSL_CERT_DIR` environment variable. You can set the variable in a single session by running a command like `export SSL_CERT_DIR=$HOME/.aspnet/dev-certs/trust:/usr/lib/ssl/certs` (the exact value is in the output when `--verbose` is passed) or by adding it your (distro- and shell-specific) configuration file (for example _.profile_).

This approach is required to make tools like `curl` trust the development certificate. Alternatively, you can pass `-CAfile` or `-CApath` to each individual `curl` invocation.

> [!NOTE]
> Requires 1.1.1h or later or 3.0.0 or later, depending on which major version you're using.

If OpenSSL trust gets into a bad state (for example if `dotnet dev-certs https --clean` fails to remove it), you can frequently resolve the situation by using the [c_rehash](https://docs.openssl.org/master/man1/openssl-rehash/) tool.

### Overrides

If you're using another browser with its own Network Security Services (NSS) store, you can use the `DOTNET_DEV_CERTS_NSSDB_PATHS` environment variable to specify a colon-delimited list of NSS directories (for example, the directory containing `cert9.db`). You can then add the development certificate location to the list in the variable.

If you store the certificates you want OpenSSL to trust in a specific directory, you can use the `DOTNET_DEV_CERTS_OPENSSL_CERTIFICATE_DIRECTORY` environment variable to indicate the certificate location.

> [!WARNING]
> If you set either variable, be sure to set the same values each time trust is updated. If the values change, the tool doesn't know about certificates in the former locations (for example, during certificate cleanup).

### Using sudo

As on other platforms, development certificates are stored and trusted separately for each user. 

If you run `dotnet dev-certs` as a different user (for example, by using `sudo`), then _that_ specific user (for example `root`) trusts the development certificate.

### Trust HTTPS certificate on Linux with linux-dev-certs

[linux-dev-certs](https://github.com/tmds/linux-dev-certs) is an open-source, community-supported, .NET global tool that provides a convenient way to create and trust a developer certificate on Linux. Microsoft doesn't maintain or support the tool.

The following commands install the tool and create a trusted developer certificate:

```cli
dotnet tool update -g linux-dev-certs
dotnet linux-dev-certs install
```

For more information or to report issues, see the [linux-dev-certs GitHub repository](https://github.com/tmds/linux-dev-certs).

#### SUSE Linux Enterprise Server (SLES Linux)

If your configuration includes SUSE Linux Enterprise Server, see [GitHub dotnet/aspnetcore.docs issue #28292](https://github.com/dotnet/AspNetCore.Docs/issues/28292) - _Trust HTTPS certificate on SLES_.

<!-- Instructions for development purposes only --

> [!WARNING]
> The following instructions are intended for development purposes only.
> Do not use the certificates generated in these instructions for a production environment.

These instructions use Mozilla's *legacy* tool [certutil](https://firefox-source-docs.mozilla.org/security/nss/legacy/tools/nss_tools_certutil/index.html). Instructions may be updated as modern utilities and practices are discovered.

> [!CAUTION]
> Improper use of TLS certificates could lead to spoofing.

> [!TIP]
> Instructions for valid production certificates can be found in the RHEL Documentation.
> [RHEL8 TLS Certificates](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/8/html-single/securing_networks/index#creating-and-managing-tls-keys-and-certificates_securing-networks)
> [RHEL9 TLS Certificates](https://access.redhat.com/documentation/en-us/red_hat_enterprise_linux/9/html-single/securing_networks/index#creating-and-managing-tls-keys-and-certificates_securing-networks)
> [RHEL9 Certificate System](https://access.redhat.com/documentation/en-us/red_hat_certificate_system/9)

### Install Dependencies

```sh
dnf install nss-tools
```

### Export The ASP.NET Core Development Certificate

> [!IMPORTANT]
> Replace `${ProjectDirectory}` with your projects directory.
> Replace `${CertificateName}` with a name you'll be able to identify in the future.

```sh
cd ${ProjectDirectory}
dotnet dev-certs https -ep ${ProjectDirectory}/${CertificateName}.crt --format PEM
```

> [!CAUTION]
> If using git, add your certificate to your `${ProjectDirectory}/.gitignore` or `${ProjectDirectory}/.git/info/exclude`.
> View the [git documentation](https://git-scm.com/docs/gitignore) for information about these files.

> [!TIP]
> You can move your exported certificate outside of your Git repository and replace the occurrences of `${ProjectDirectory}`, in the following instructions, with the new location.

### Import The ASP.NET Core Development Certificate

> [!IMPORTANT]
> Replace `${UserProfile}` with the profile you intend to use.
> Do not replace `$HOME`, it is the environment variable to your user directory.

#### Chromium-based Browsers

```sh
certutil -d sql:$HOME/.pki/nssdb -A -t "P,," -n ${CertificateName} -i ${ProjectDirectory}/${CertificateName}.crt
```

#### Mozilla Firefox

```sh
certutil -d sql:$HOME/.mozilla/firefox/${UserProfile}/ -A -t "C,," -n ${CertificateName} -i ${ProjectDirectory}/${CertificateName}.crt
```

#### Create An Alias To Test With Curl

> [!IMPORTANT]
>
> Don't delete the exported certificate if you plan to test with curl.
> You'll need to create an alias referencing it in your `$SHELL`'s profile

```sh
alias curl="curl --cacert ${ProjectDirectory}/${CertificateName}.crt"
```

### Cleaning up the Development Certificates

```sh
certutil -d sql:$HOME/.pki/nssdb -D -n ${CertificateName}
certutil -d sql:$HOME/.mozilla/firefox/${UserProfile}/ -D -n ${CertificateName}
rm ${ProjectDirectory}/${CertificateName}.crt
dotnet dev-certs https --clean
```

>[!NOTE]
> Remove the curl alias you created earlier

-->

## Troubleshoot certificate problems (certificate not trusted)

Sometimes when an ASP.NET Core HTTPS development certificate is [installed and trusted](#trust), the browser warns that the certificate is untrusted. The following sections provide help for troubleshooting this issue.

The ASP.NET Core HTTPS development certificate is used by [Kestrel](xref:fundamentals/servers/kestrel).

To repair the IIS Express certificate, see [Stack Overflow issue #20036984 / answer #20048613](https://stackoverflow.com/questions/20036984/how-do-i-restore-a-missing-iis-express-ssl-certificate/20048613#20048613) - _How do I restore a missing IIS Express SSL Certificate?_

### All platforms - certificate not trusted

For all platforms, try to resolve the untrusted certificate issues with the following steps:

1. Run the following commands:

   ```dotnetcli
   dotnet dev-certs https --clean
   dotnet dev-certs https --trust
   ```

1. Close any open browser instances, and open the app in a new browser window.

   The browser cache stores whether a certificate is trusted. The close/open process helps to refresh the browser cache settings for certificates.

The `dotnet dev-certs https` commands usually solve most browser trust issues. If the `dotnet dev-certs https --clean` command fails and the browser still doesn't trust the certificate, try the platform-specific suggestions in the following sections.

### Docker - certificate not trusted

If you're using Docker, try to resolve the issue with the following steps:

1. Delete the _C:\Users\{USER}\AppData\Roaming\ASP.NET\Https_ folder.

1. Clean the solution. Delete the _bin_ and _obj_ folders.

1. Restart the development tool. For example, Visual Studio or Visual Studio Code.

### Windows - certificate not trusted

If you're working in Windows, complete the following troubleshooting steps:

1. Check the certificates in the certificate store. Look for a `localhost` certificate with the `ASP.NET Core HTTPS development certificate` friendly name in two folders:

   * _Current User > Personal > Certificates_
   * _Current User > Trusted root certification authorities > Certificates_

1. Remove all certificates from both Personal and Trusted root certification authorities.

   > [!IMPORTANT]
   > Do **not** remove the IIS Express localhost certificate.

1. Run the following commands:

   ```dotnetcli
   dotnet dev-certs https --clean
   dotnet dev-certs https --trust
   ```

1. Close any open browser instances, and open the app in a new browser window.

### OS X - certificate not trusted

If you're working with OS X, try to resolve the issue with the following steps:

1. Open KeyChain Access, and then select the System keychain.

1. Check for the presence of a localhost certificate.

1. Confirm the certificate shows the plus (`+`) symbol on the icon, which indicates the certificate is trusted for all users.

1. Remove the certificate from the system keychain.

1. Run the following commands:

   ```dotnetcli
   dotnet dev-certs https --clean
   dotnet dev-certs https --trust
   ```

1. Close any open browser instances, and open the app in a new browser window.

For more information about troubleshooting certificate issues with Visual Studio, see [GitHub dotnet/aspnetcore issue #16892)](https://github.com/dotnet/AspNetCore/issues/16892) - _HTTPS Error using IIS Express_.

### Linux - certificate not trusted

If you're running Linux, follow these steps to troubleshoot the untrusted certificate:

1. Confirm the certificate you're investigating is the user HTTPS developer certificate planned for use by the Kestrel server.

1. Check the current user default HTTPS developer Kestrel certificate at the following location:

   ```cmd
   ls -la ~/.dotnet/corefx/cryptography/x509stores/my
   ```

   The HTTPS developer Kestrel certificate file is the SHA1 thumbprint. When the file is deleted with the `dotnet dev-certs https --clean` command, the file is regenerated when needed with a different thumbprint.

1. Verify the thumbprint of the exported certificate matches by running the following command:

   ```cmd
   openssl x509 -noout -fingerprint -sha1 -inform pem -in /usr/local/share/ca-certificates/aspnet/https.crt
   ```

   If the certificate thumbprint doesn't match, investigate the following conditions:

   * Check if the certificate is old.

   * Check if the certificate is an exported developer certificate for the root user.

      * If it is, export the certificate.

1. Check the root user certificate in the following folder:

   ```cmd
   ls -la /root/.dotnet/corefx/cryptography/x509stores/my
   ```

### IIS Express SSL certificate used with Visual Studio

To fix problems with the IIS Express certificate, select **Repair** in the Visual Studio installer. For more information, see [GitHub dotnet/aspnetcore issue #16892)](https://github.com/dotnet/AspNetCore/issues/16892) - _HTTPS Error using IIS Express_.

### Group policy prevents trusting self-signed certificates

In some cases, group policy can prevent self-signed certificates from being trusted. For more information, see [GitHub dotnet/aspnetcore issue #21173](https://github.com/dotnet/aspnetcore/issues/21173) - _Error trusting HTTPS developer certificate_.

## Related content

* <xref:host-and-deploy/proxy-load-balancer>
* [Host ASP.NET Core on Linux with Nginx: HTTPS configuration](xref:host-and-deploy/linux-nginx#https-configuration)
* [Set up SSL on IIS 7 or later](/iis/manage/configuring-security/how-to-set-up-ssl-on-iis)
* <xref:fundamentals/servers/kestrel/endpoints>
* [OWASP HSTS browser support](https://cheatsheetseries.owasp.org/cheatsheets/HTTP_Strict_Transport_Security_Cheat_Sheet.html#browser-support)

:::moniker-end

[!INCLUDE[](~//security/enforcing-ssl/includes/enforcing-ssl6.md)]
[!INCLUDE[](~//security/enforcing-ssl/includes/enforcing-ssl7.md)]
[!INCLUDE[](~//security/enforcing-ssl/includes/enforcing-ssl8.md)]
