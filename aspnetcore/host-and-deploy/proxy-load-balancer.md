---
title: Configure ASP.NET Core to work with proxy servers and load balancers
author: rick-anderson
description: Learn about configuration for apps hosted behind proxy servers and load balancers, which often obscure important request information.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 1/07/2022
uid: host-and-deploy/proxy-load-balancer
---
# Configure ASP.NET Core to work with proxy servers and load balancers

By [Chris Ross](https://github.com/Tratcher)

:::moniker range=">= aspnetcore-6.0"

In the recommended configuration for ASP.NET Core, the app is hosted using <xref:host-and-deploy/aspnet-core-module>, Nginx, or Apache. Proxy servers, load balancers, and other network appliances often obscure information about the request before it reaches the app:

* When HTTPS requests are proxied over HTTP, the original scheme (HTTPS) is lost and must be forwarded in a header.
* Because an app receives a request from the proxy and not its true source on the Internet or corporate network, the originating client IP address must also be forwarded in a header.

This information may be important in request processing, for example in redirects, authentication, link generation, policy evaluation, and client geolocation.

Apps intended to run on web farm should read <xref:host-and-deploy/web-farm>.

## Forwarded headers

By convention, proxies forward information in HTTP headers.

| Header | Description |
| ------ | ----------- |
| [`X-Forwarded-For`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-For) (XFF) | Holds information about the client that initiated the request and subsequent proxies in a chain of proxies. This parameter may contain IP addresses and, optionally, port numbers. In a chain of proxy servers, the first parameter indicates the client where the request was first made. Subsequent proxy identifiers follow. The last proxy in the chain isn't in the list of parameters. The last proxy's IP address, and optionally a port number, are available as the remote IP address at the transport layer. |
| [`X-Forwarded-Proto`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Proto) (XFP)| The value of the originating scheme, HTTP or HTTPS. The value may also be a list of schemes if the request has traversed multiple proxies. |
| [`X-Forwarded-Host`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Host) (XFH) | The original value of the Host header field. Usually, proxies don't modify the Host header. See [Microsoft Security Advisory CVE-2018-0787](https://github.com/aspnet/Announcements/issues/295) for information on an elevation-of-privileges vulnerability that affects systems where the proxy doesn't validate or restrict Host headers to known good values. |

The [Forwarded Headers Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/ForwardedHeadersOptions.cs), <xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersMiddleware>, reads these headers and fills in the associated fields on <xref:Microsoft.AspNetCore.Http.HttpContext>.

The middleware updates:

* [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress): Set using the `X-Forwarded-For` header value. Additional settings influence how the middleware sets `RemoteIpAddress`. For details, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options). The consumed values are removed from `X-Forwarded-For`, and the old values are persisted in `X-Original-For`. The same pattern is applied to the other headers, `Host` and `Proto`.
* [HttpContext.Request.Scheme](xref:Microsoft.AspNetCore.Http.HttpRequest.Scheme): Set using the [`X-Forwarded-Proto`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Proto) header value.
* [HttpContext.Request.Host](xref:Microsoft.AspNetCore.Http.HttpRequest.Host): Set using the `X-Forwarded-Host` header value.

For more information on the preceding, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/21615).

Forwarded Headers Middleware [default settings](#forwarded-headers-middleware-options) can be configured. For the default settings:

* There is only ***one proxy*** between the app and the source of the requests.
* Only loopback addresses are configured for known proxies and known networks.
* The forwarded headers are named [`X-Forwarded-For`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-For) and [`X-Forwarded-Proto`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Proto).
* The  `ForwardedHeaders` value is `ForwardedHeaders.None`, the desired forwarders must be set here to enable the middleware.

Not all network appliances add the `X-Forwarded-For` and `X-Forwarded-Proto` headers without additional configuration. Consult your appliance manufacturer's guidance if proxied requests don't contain these headers when they reach the app. If the appliance uses different header names than `X-Forwarded-For` and `X-Forwarded-Proto`, set the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> options to match the header names used by the appliance. For more information, see [Forwarded Headers Middleware options](#forwarded-headers-middleware-options) and [Configuration for a proxy that uses different header names](#configuration-for-a-proxy-that-uses-different-header-names).

## IIS/IIS Express and ASP.NET Core Module

Forwarded Headers Middleware is enabled by default by [IIS Integration Middleware](xref:host-and-deploy/iis/index#enable-the-iisintegration-components) when the app is hosted [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model) behind IIS and the <xref:host-and-deploy/aspnet-core-module>. Forwarded Headers Middleware is activated to run first in the middleware pipeline with a restricted configuration specific to the ASP.NET Core Module. The restricted configuration is due to trust concerns with forwarded headers, for example, [IP spoofing](https://www.iplocation.net/ip-spoofing). The middleware is configured to forward the [`X-Forwarded-For`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-For) and [`X-Forwarded-Proto`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Proto) headers and is restricted to a single localhost proxy. If additional configuration is required, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options).

## Other proxy server and load balancer scenarios

Outside of using [IIS Integration](xref:host-and-deploy/iis/index#enable-the-iisintegration-components) when hosting [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model), [Forwarded Headers Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/ForwardedHeadersOptions.cs) isn't enabled by default. Forwarded Headers Middleware must be enabled for an app to process forwarded headers with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>. After enabling the middleware if no <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> are specified to the middleware, the default [ForwardedHeadersOptions.ForwardedHeaders](xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders) are [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders).

Configure the middleware with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the [`X-Forwarded-For`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-For) and [`X-Forwarded-Proto`](https://developer.mozilla.org/docs/Web/HTTP/Headers/X-Forwarded-Proto) headers.

<a name="fhmo"></a>

### Forwarded Headers Middleware order

[Forwarded Headers Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/ForwardedHeadersOptions.cs) should run before other middleware. This ordering ensures that the middleware relying on forwarded headers information can consume the header values for processing. Forwarded Headers Middleware can run after diagnostics and error handling, but it must be run before calling <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet1&highlight=6-10,17,23)]

Alternatively, call `UseForwardedHeaders` before diagnostics:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet2&highlight=6-10,14)]

> [!NOTE]
> If no <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> are specified or applied directly to the extension method with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>, the default headers to forward are [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders). The <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders> property must be configured with the headers to forward.

## Nginx configuration

To forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers, see <xref:host-and-deploy/linux-nginx#configure-nginx>. For more information, see [NGINX: Using the Forwarded header](https://www.nginx.com/resources/wiki/start/topics/examples/forwarded/).

## Apache configuration

`X-Forwarded-For` is added automatically. For more information, see [Apache Module mod_proxy: Reverse Proxy Request Headers](https://httpd.apache.org/docs/2.4/mod/mod_proxy.html#x-headers). For information on how to forward the `X-Forwarded-Proto` header, see <xref:host-and-deploy/linux-apache#configure-apache>.

## Forwarded Headers Middleware options

<xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> control the behavior of the [Forwarded Headers Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/ForwardedHeadersOptions.cs). The following example changes the default values:

* Limits the number of entries in the forwarded headers to `2`.
* Adds a known proxy address of `127.0.10.1`.
* Changes the forwarded header name from the default `X-Forwarded-For` to `X-Forwarded-For-My-Custom-Header-Name`.

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_fmho&highlight=6-11)]

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.AllowedHosts> | Restricts hosts by the `X-Forwarded-Host` header to the values provided.<ul><li>Values are compared using ordinal-ignore-case.</li><li>Port numbers must be excluded.</li><li>If the list is empty, all hosts are allowed.</li><li>A top-level wildcard `*` allows all non-empty hosts.</li><li>Subdomain wildcards are permitted but don't match the root domain. For example, `*.contoso.com` matches the subdomain `foo.contoso.com` but not the root domain `contoso.com`.</li><li>Unicode host names are allowed but are converted to [Punycode](https://tools.ietf.org/html/rfc3492) for matching.</li><li>[IPv6 addresses](https://tools.ietf.org/html/rfc4291) must include bounding brackets and be in [conventional form](https://tools.ietf.org/html/rfc4291#section-2.2) (for example, `[ABCD:EF01:2345:6789:ABCD:EF01:2345:6789]`). IPv6 addresses aren't special-cased to check for logical equality between different formats, and no canonicalization is performed.</li><li>Failure to restrict the allowed hosts may allow an attacker to spoof links generated by the service.</li></ul>The default value is an empty `IList<string>`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedForHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedForHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-For` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-For`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders> | Identifies which forwarders should be processed. See the [ForwardedHeaders Enum](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders) for the list of fields that apply. Typical values assigned to this property are `ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto`.<br><br>The default value is [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders). |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHostHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedHostHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedHostHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-Host` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-Host`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedProtoHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedProtoHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-Proto` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-Proto`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardLimit> | Limits the number of entries in the headers that are processed. Set to `null` to disable the limit, but this should only be done if `KnownProxies` or `KnownNetworks` are configured. Setting a non-`null` value is a precaution (but not a guarantee) to guard against misconfigured proxies and malicious requests arriving from side-channels on the network.<br><br>Forwarded Headers Middleware processes headers in reverse order from right to left. If the default value (`1`) is used, only the rightmost value from the headers is processed unless the value of `ForwardLimit` is increased.<br><br>The default is `1`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> | Address ranges of known networks to accept forwarded headers from. Provide IP ranges using Classless Interdomain Routing (CIDR) notation.<br><br>If the server is using dual-mode sockets, IPv4 addresses are supplied in an IPv6 format (for example, `10.0.0.1` in IPv4 represented in IPv6 as `::ffff:10.0.0.1`). See [IPAddress.MapToIPv6](xref:System.Net.IPAddress.MapToIPv6*). Determine if this format is required by looking at the [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress*).<br><br>The default is an `IList`\<<xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork>> containing a single entry for `IPAddress.Loopback`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies> | Addresses of known proxies to accept forwarded headers from. Use `KnownProxies` to specify exact IP address matches.<br><br>If the server is using dual-mode sockets, IPv4 addresses are supplied in an IPv6 format (for example, `10.0.0.1` in IPv4 represented in IPv6 as `::ffff:10.0.0.1`). See [IPAddress.MapToIPv6](xref:System.Net.IPAddress.MapToIPv6*). Determine if this format is required by looking at the [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress*).<br><br>The default is an `IList`\<<xref:System.Net.IPAddress>> containing a single entry for `IPAddress.IPv6Loopback`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalForHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalForHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalForHeaderName).<br><br>The default is `X-Original-For`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalHostHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalHostHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalHostHeaderName).<br><br>The default is `X-Original-Host`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalProtoHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalProtoHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalProtoHeaderName).<br><br>The default is `X-Original-Proto`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.RequireHeaderSymmetry> | Require the number of header values to be in sync between the [ForwardedHeadersOptions.ForwardedHeaders](xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders) being processed.<br><br>The default in ASP.NET Core 1.x is `true`. The default in ASP.NET Core 2.0 or later is `false`. |

## Scenarios and use cases

### When it isn't possible to add forwarded headers and all requests are secure

In some cases, it might not be possible to add forwarded headers to the requests proxied to the app. If the proxy is enforcing that all public external requests are HTTPS, the scheme can be manually set before using any type of middleware:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_https&highlight=14-18)]

This code can be disabled with an environment variable or other configuration setting in a development or staging environment:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_https2&highlight=14-21)]

### Work with path base and proxies that change the request path

Some proxies pass the path intact but with an app base path that should be removed so that routing works properly. [UsePathBaseExtensions.UsePathBase](xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase*) middleware splits the path into [HttpRequest.Path](xref:Microsoft.AspNetCore.Http.HttpRequest.Path) and the app base path into [HttpRequest.PathBase](xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase).

If `/foo` is the app base path for a proxy path passed as `/foo/api/1`, the middleware sets `Request.PathBase` to `/foo` and `Request.Path` to `/api/1` with the following command:

```csharp
app.UsePathBase("/foo");
// ...
app.UseRouting();
```

> [!NOTE]
> When using <xref:Microsoft.AspNetCore.Builder.WebApplication> (see <xref:migration/50-to-60#new-hosting-model>), [`app.UseRouting`](xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A) must be called after `UsePathBase` so that the routing middleware can observe the modified path before matching routes. Otherwise, routes are matched before the path is rewritten by `UsePathBase` as described in the [Middleware Ordering](xref:fundamentals/middleware/index#order) and [Routing](xref:fundamentals/routing) articles.

The original path and path base are reapplied when the middleware is called again in reverse. For more information on middleware order processing, see <xref:fundamentals/middleware/index>.

If the proxy trims the path (for example, forwarding `/foo/api/1` to `/api/1`), fix redirects and links by setting the request's [PathBase](xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase) property:

```csharp
app.Use((context, next) =>
{
    context.Request.PathBase = new PathString("/foo");
    return next(context);
});
```

If the proxy is adding path data, discard part of the path to fix redirects and links by using <xref:Microsoft.AspNetCore.Http.PathString.StartsWithSegments*> and assigning to the <xref:Microsoft.AspNetCore.Http.HttpRequest.Path> property:

```csharp
app.Use((context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/foo", out var remainder))
    {
        context.Request.Path = remainder;
    }

    return next(context);
});
```

### Configuration for a proxy that uses different header names

If the proxy doesn't use headers named `X-Forwarded-For` and `X-Forwarded-Proto` to forward the proxy address/port and originating scheme information, set the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> options to match the header names used by the proxy:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_dh&highlight=4-8)]

## Forward the scheme for Linux and non-IIS reverse proxies

Apps that call <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection*> and <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts*> put a site into an infinite loop if deployed to an Azure Linux App Service, Azure Linux virtual machine (VM), or behind any other reverse proxy besides IIS. TLS is terminated by the reverse proxy, and Kestrel isn't made aware of the correct request scheme. OAuth and OIDC also fail in this configuration because they generate incorrect redirects. <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions.UseIISIntegration*> adds and configures Forwarded Headers Middleware when running behind IIS, but there's no matching automatic configuration for Linux (Apache or Nginx integration).

To forward the scheme from the proxy in non-IIS scenarios, enable the Forwarded Headers Middleware by setting `ASPNETCORE_FORWARDEDHEADERS_ENABLED` to `true`. Warning: This flag uses settings designed for cloud environments and doesn't enable features such as the [`KnownProxies option`](#forwarded-headers-middleware-options) to restrict which IPs forwarders are accepted from.

## Certificate forwarding

### Azure

To configure Azure App Service for certificate forwarding, see [Configure TLS mutual authentication for Azure App Service](/azure/app-service/app-service-web-configure-tls-mutual-auth). The following guidance pertains to configuring the ASP.NET Core app.

* Configure [Certificate Forwarding Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/CertificateForwardingMiddleware.cs) to specify the header name that Azure uses. Add the following code to configure the header from which the middleware builds a certificate.
* Call <xref:Microsoft.AspNetCore.Builder.CertificateForwardingBuilderExtensions.UseCertificateForwarding%2A> before the call to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>.

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_az&highlight=4-5,9,17,21)]

### Other web proxies

If a proxy is used that isn't IIS or Azure App Service's Application Request Routing (ARR), configure the proxy to forward the certificate that it received in an HTTP header.

* Configure [Certificate Forwarding Middleware](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HttpOverrides/src/CertificateForwardingMiddleware.cs) to specify the header name. Add the following code to configure the header from which the middleware builds a certificate.
* Call <xref:Microsoft.AspNetCore.Builder.CertificateForwardingBuilderExtensions.UseCertificateForwarding%2A> before the call to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>.

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_owp&highlight=4-5,9,17,21)]

If the proxy isn't base64-encoding the certificate, as is the case with Nginx, set the `HeaderConverter` option. Consider the following example:
[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_owp2&highlight=4-13,17,25)]

## Troubleshoot

When headers aren't forwarded as expected, enable `debug` level [logging](xref:fundamentals/logging/index) and HTTP request logging. <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A> must be called after <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders%2A>:

<!-- COMMENTED OUT DELETE after review
 If the logs don't provide sufficient information to troubleshoot the problem, enumerate the request headers received by the server. Use inline middleware to write request headers to an app response or log the headers.

To write the headers to the app's response, place the following terminal inline middleware after the call to <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_trb3&highlight=16-42)]

You can write to logs instead of the response body. Writing to logs allows the site to function normally while debugging.

To write logs rather than to the response body, place the following inline middleware immediately after the call to <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>:
END of COMMENTED OUT -->

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_trb22&highlight=8-11,21-31)]

When processed, `X-Forwarded-{For|Proto|Host}` values are moved to `X-Original-{For|Proto|Host}`. If there are multiple values in a given header, Forwarded Headers Middleware processes headers in reverse order from right to left. The default `ForwardLimit` is `1` (one), so only the rightmost value from the headers is processed unless the value of `ForwardLimit` is increased.

The request's original remote IP must match an entry in the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies> or <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> lists before forwarded headers are processed. This limits header spoofing by not accepting forwarders from untrusted proxies. When an unknown proxy is detected, logging indicates the address of the proxy:

```console
September 20th 2018, 15:49:44.168 Unknown proxy: 10.0.0.100:54321
```

In the preceding example, 10.0.0.100 is a proxy server. If the server is a trusted proxy, add the server's IP address to `KnownProxies`, or add a trusted network to `KnownNetworks`. For more information, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options) section.

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/Program.cs?name=snippet_kp&highlight=11)]

To display the logs, add `"Microsoft.AspNetCore.HttpLogging": "Information"` to the `appsettings.Development.json` file:

[!code-json[](~/host-and-deploy/proxy-load-balancer/6.1samples/WebPS/appsettings.Development.json?highlight=7)]

> [!IMPORTANT]
> Only allow trusted proxies and networks to forward headers. Otherwise, [IP spoofing](https://www.iplocation.net/ip-spoofing) attacks are possible.

## Additional resources

* <xref:host-and-deploy/web-farm>
* [Microsoft Security Advisory CVE-2018-0787: ASP.NET Core Elevation Of Privilege Vulnerability](https://github.com/aspnet/Announcements/issues/295)
* [YARP: Yet Another Reverse Proxy](https://microsoft.github.io/reverse-proxy/index.html)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In the recommended configuration for ASP.NET Core, the app is hosted using IIS/ASP.NET Core Module, Nginx, or Apache. Proxy servers, load balancers, and other network appliances often obscure information about the request before it reaches the app:

* When HTTPS requests are proxied over HTTP, the original scheme (HTTPS) is lost and must be forwarded in a header.
* Because an app receives a request from the proxy and not its true source on the Internet or corporate network, the originating client IP address must also be forwarded in a header.

This information may be important in request processing, for example in redirects, authentication, link generation, policy evaluation, and client geolocation.

## Forwarded headers

By convention, proxies forward information in HTTP headers.

| Header | Description |
| ------ | ----------- |
| X-Forwarded-For | Holds information about the client that initiated the request and subsequent proxies in a chain of proxies. This parameter may contain IP addresses (and, optionally, port numbers). In a chain of proxy servers, the first parameter indicates the client where the request was first made. Subsequent proxy identifiers follow. The last proxy in the chain isn't in the list of parameters. The last proxy's IP address, and optionally a port number, are available as the remote IP address at the transport layer. |
| X-Forwarded-Proto | The value of the originating scheme (HTTP/HTTPS). The value may also be a list of schemes if the request has traversed multiple proxies. |
| X-Forwarded-Host | The original value of the Host header field. Usually, proxies don't modify the Host header. See [Microsoft Security Advisory CVE-2018-0787](https://github.com/aspnet/Announcements/issues/295) for information on an elevation-of-privileges vulnerability that affects systems where the proxy doesn't validate or restrict Host headers to known good values. |

The Forwarded Headers Middleware (<xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersMiddleware>), reads these headers and fills in the associated fields on <xref:Microsoft.AspNetCore.Http.HttpContext>.

The middleware updates:

* [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress): Set using the `X-Forwarded-For` header value. Additional settings influence how the middleware sets `RemoteIpAddress`. For details, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options). The consumed values are removed from `X-Forwarded-For`, and the old values are persisted in `X-Original-For`. The same pattern is applied to the other headers, `Host` and `Proto`.
* [HttpContext.Request.Scheme](xref:Microsoft.AspNetCore.Http.HttpRequest.Scheme): Set using the `X-Forwarded-Proto` header value.
* [HttpContext.Request.Host](xref:Microsoft.AspNetCore.Http.HttpRequest.Host): Set using the `X-Forwarded-Host` header value.

For more information on the preceding, see [this GitHub issue](https://github.com/dotnet/AspNetCore.Docs/issues/21615).

Forwarded Headers Middleware [default settings](#forwarded-headers-middleware-options) can be configured. For the default settings:

* There is only *one proxy* between the app and the source of the requests.
* Only loopback addresses are configured for known proxies and known networks.
* The forwarded headers are named `X-Forwarded-For` and `X-Forwarded-Proto`.
* The  `ForwardedHeaders` value is `ForwardedHeaders.None`, the desired forwarders must be set here to enable the middleware.

Not all network appliances add the `X-Forwarded-For` and `X-Forwarded-Proto` headers without additional configuration. Consult your appliance manufacturer's guidance if proxied requests don't contain these headers when they reach the app. If the appliance uses different header names than `X-Forwarded-For` and `X-Forwarded-Proto`, set the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> options to match the header names used by the appliance. For more information, see [Forwarded Headers Middleware options](#forwarded-headers-middleware-options) and [Configuration for a proxy that uses different header names](#configuration-for-a-proxy-that-uses-different-header-names).

## IIS/IIS Express and ASP.NET Core Module

Forwarded Headers Middleware is enabled by default by [IIS Integration Middleware](xref:host-and-deploy/iis/index#enable-the-iisintegration-components) when the app is hosted [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model) behind IIS and the ASP.NET Core Module. Forwarded Headers Middleware is activated to run first in the middleware pipeline with a restricted configuration specific to the ASP.NET Core Module due to trust concerns with forwarded headers (for example, [IP spoofing](https://www.iplocation.net/ip-spoofing)). The middleware is configured to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers and is restricted to a single localhost proxy. If additional configuration is required, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options).

## Other proxy server and load balancer scenarios

Outside of using [IIS Integration](xref:host-and-deploy/iis/index#enable-the-iisintegration-components) when hosting [out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model), Forwarded Headers Middleware isn't enabled by default. Forwarded Headers Middleware must be enabled for an app to process forwarded headers with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>. After enabling the middleware if no <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> are specified to the middleware, the default [ForwardedHeadersOptions.ForwardedHeaders](xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders) are [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders).

Configure the middleware with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> to forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers in `Startup.ConfigureServices`.

<a name="fhmo"></a>

### Forwarded Headers Middleware order

Forwarded Headers Middleware should run before other middleware. This ordering ensures that the middleware relying on forwarded headers information can consume the header values for processing. Forwarded Headers Middleware can run after diagnostics and error handling, but it must be run before calling `UseHsts`:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/3.1samples/Startup.cs?name=snippet&highlight=13-17,25,30)]

Alternatively, call `UseForwardedHeaders` before diagnostics:

[!code-csharp[](~/host-and-deploy/proxy-load-balancer/3.1samples/Startup2.cs?name=snippet)]

> [!NOTE]
> If no <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> are specified in `Startup.ConfigureServices` or directly to the extension method with <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*>, the default headers to forward are [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders). The <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders> property must be configured with the headers to forward.

## Nginx configuration

To forward the `X-Forwarded-For` and `X-Forwarded-Proto` headers, see <xref:host-and-deploy/linux-nginx#configure-nginx>. For more information, see [NGINX: Using the Forwarded header](https://www.nginx.com/resources/wiki/start/topics/examples/forwarded/).

## Apache configuration

`X-Forwarded-For` is added automatically (see [Apache Module mod_proxy: Reverse Proxy Request Headers](https://httpd.apache.org/docs/2.4/mod/mod_proxy.html#x-headers)). For information on how to forward the `X-Forwarded-Proto` header, see <xref:host-and-deploy/linux-apache#configure-apache>.

## Forwarded Headers Middleware options

<xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions> control the behavior of the Forwarded Headers Middleware. The following example changes the default values:

* Limit the number of entries in the forwarded headers to `2`.
* Add a known proxy address of `127.0.10.1`.
* Change the forwarded header name from the default `X-Forwarded-For` to `X-Forwarded-For-My-Custom-Header-Name`.

```csharp
services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardLimit = 2;
    options.KnownProxies.Add(IPAddress.Parse("127.0.10.1"));
    options.ForwardedForHeaderName = "X-Forwarded-For-My-Custom-Header-Name";
});
```

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.AllowedHosts> | Restricts hosts by the `X-Forwarded-Host` header to the values provided.<ul><li>Values are compared using ordinal-ignore-case.</li><li>Port numbers must be excluded.</li><li>If the list is empty, all hosts are allowed.</li><li>A top-level wildcard `*` allows all non-empty hosts.</li><li>Subdomain wildcards are permitted but don't match the root domain. For example, `*.contoso.com` matches the subdomain `foo.contoso.com` but not the root domain `contoso.com`.</li><li>Unicode host names are allowed but are converted to [Punycode](https://tools.ietf.org/html/rfc3492) for matching.</li><li>[IPv6 addresses](https://tools.ietf.org/html/rfc4291) must include bounding brackets and be in [conventional form](https://tools.ietf.org/html/rfc4291#section-2.2) (for example, `[ABCD:EF01:2345:6789:ABCD:EF01:2345:6789]`). IPv6 addresses aren't special-cased to check for logical equality between different formats, and no canonicalization is performed.</li><li>Failure to restrict the allowed hosts may allow an attacker to spoof links generated by the service.</li></ul>The default value is an empty `IList<string>`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedForHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedForHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-For` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-For`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders> | Identifies which forwarders should be processed. See the [ForwardedHeaders Enum](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders) for the list of fields that apply. Typical values assigned to this property are `ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto`.<br><br>The default value is [ForwardedHeaders.None](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders). |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHostHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedHostHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedHostHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-Host` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-Host`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XForwardedProtoHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XForwardedProtoHeaderName). This option is used when the proxy/forwarder doesn't use the `X-Forwarded-Proto` header but uses some other header to forward the information.<br><br>The default is `X-Forwarded-Proto`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardLimit> | Limits the number of entries in the headers that are processed. Set to `null` to disable the limit, but this should only be done if `KnownProxies` or `KnownNetworks` are configured. Setting a non-`null` value is a precaution (but not a guarantee) to guard against misconfigured proxies and malicious requests arriving from side-channels on the network.<br><br>Forwarded Headers Middleware processes headers in reverse order from right to left. If the default value (`1`) is used, only the rightmost value from the headers is processed unless the value of `ForwardLimit` is increased.<br><br>The default is `1`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownNetworks> | Address ranges of known networks to accept forwarded headers from. Provide IP ranges using Classless Interdomain Routing (CIDR) notation.<br><br>If the server is using dual-mode sockets, IPv4 addresses are supplied in an IPv6 format (for example, `10.0.0.1` in IPv4 represented in IPv6 as `::ffff:10.0.0.1`). See [IPAddress.MapToIPv6](xref:System.Net.IPAddress.MapToIPv6*). Determine if this format is required by looking at the [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress*).<br><br>The default is an `IList`\<<xref:Microsoft.AspNetCore.HttpOverrides.IPNetwork>> containing a single entry for `IPAddress.Loopback`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.KnownProxies> | Addresses of known proxies to accept forwarded headers from. Use `KnownProxies` to specify exact IP address matches.<br><br>If the server is using dual-mode sockets, IPv4 addresses are supplied in an IPv6 format (for example, `10.0.0.1` in IPv4 represented in IPv6 as `::ffff:10.0.0.1`). See [IPAddress.MapToIPv6](xref:System.Net.IPAddress.MapToIPv6*). Determine if this format is required by looking at the [HttpContext.Connection.RemoteIpAddress](xref:Microsoft.AspNetCore.Http.ConnectionInfo.RemoteIpAddress*).<br><br>The default is an `IList`\<<xref:System.Net.IPAddress>> containing a single entry for `IPAddress.IPv6Loopback`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalForHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalForHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalForHeaderName).<br><br>The default is `X-Original-For`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalHostHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalHostHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalHostHeaderName).<br><br>The default is `X-Original-Host`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.OriginalProtoHeaderName> | Use the header specified by this property instead of the one specified by [ForwardedHeadersDefaults.XOriginalProtoHeaderName](xref:Microsoft.AspNetCore.HttpOverrides.ForwardedHeadersDefaults.XOriginalProtoHeaderName).<br><br>The default is `X-Original-Proto`. |
| <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.RequireHeaderSymmetry> | Require the number of header values to be in sync between the [ForwardedHeadersOptions.ForwardedHeaders](xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedHeaders) being processed.<br><br>The default in ASP.NET Core 1.x is `true`. The default in ASP.NET Core 2.0 or later is `false`. |

## Scenarios and use cases

### When it isn't possible to add forwarded headers and all requests are secure

In some cases, it might not be possible to add forwarded headers to the requests proxied to the app. If the proxy is enforcing that all public external requests are HTTPS, the scheme can be manually set in `Startup.Configure` before using any type of middleware:

```csharp
app.Use((context, next) =>
{
    context.Request.Scheme = "https";
    return next();
});
```

This code can be disabled with an environment variable or other configuration setting in a development or staging environment.

### Deal with path base and proxies that change the request path

Some proxies pass the path intact but with an app base path that should be removed so that routing works properly. [UsePathBaseExtensions.UsePathBase](xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase*) middleware splits the path into [HttpRequest.Path](xref:Microsoft.AspNetCore.Http.HttpRequest.Path) and the app base path into [HttpRequest.PathBase](xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase).

If `/foo` is the app base path for a proxy path passed as `/foo/api/1`, the middleware sets `Request.PathBase` to `/foo` and `Request.Path` to `/api/1` with the following command:

```csharp
app.UsePathBase("/foo");
```

The original path and path base are reapplied when the middleware is called again in reverse. For more information on middleware order processing, see <xref:fundamentals/middleware/index>.

If the proxy trims the path (for example, forwarding `/foo/api/1` to `/api/1`), fix redirects and links by setting the request's [PathBase](xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase) property:

```csharp
app.Use((context, next) =>
{
    context.Request.PathBase = new PathString("/foo");
    return next();
});
```

If the proxy is adding path data, discard part of the path to fix redirects and links by using <xref:Microsoft.AspNetCore.Http.PathString.StartsWithSegments*> and assigning to the <xref:Microsoft.AspNetCore.Http.HttpRequest.Path> property:

```csharp
app.Use((context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/foo", out var remainder))
    {
        context.Request.Path = remainder;
    }

    return next();
});
```

### Configuration for a proxy that uses different header names

If the proxy doesn't use headers named `X-Forwarded-For` and `X-Forwarded-Proto` to forward the proxy address/port and originating scheme information, set the <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedForHeaderName> and <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersOptions.ForwardedProtoHeaderName> options to match the header names used by the proxy:

```csharp
services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedForHeaderName = "Header_Name_Used_By_Proxy_For_X-Forwarded-For_Header";
    options.ForwardedProtoHeaderName = "Header_Name_Used_By_Proxy_For_X-Forwarded-Proto_Header";
});
```

## Forward the scheme for Linux and non-IIS reverse proxies

Apps that call <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection*> and <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts*> put a site into an infinite loop if deployed to an Azure Linux App Service, Azure Linux virtual machine (VM), or behind any other reverse proxy besides IIS. TLS is terminated by the reverse proxy, and Kestrel isn't made aware of the correct request scheme. OAuth and OIDC also fail in this configuration because they generate incorrect redirects. <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions.UseIISIntegration*> adds and configures Forwarded Headers Middleware when running behind IIS, but there's no matching automatic configuration for Linux (Apache or Nginx integration).

To forward the scheme from the proxy in non-IIS scenarios, add and configure Forwarded Headers Middleware. In `Startup.ConfigureServices`, use the following code:

```csharp
// using Microsoft.AspNetCore.HttpOverrides;

if (string.Equals(
    Environment.GetEnvironmentVariable("ASPNETCORE_FORWARDEDHEADERS_ENABLED"), 
    "true", StringComparison.OrdinalIgnoreCase))
{
    services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | 
            ForwardedHeaders.XForwardedProto;
        // Only loopback proxies are allowed by default.
        // Clear that restriction because forwarders are enabled by explicit 
        // configuration.
        options.KnownNetworks.Clear();
        options.KnownProxies.Clear();
    });
}
```

## Certificate forwarding 

### Azure

To configure Azure App Service for certificate forwarding, see [Configure TLS mutual authentication for Azure App Service](/azure/app-service/app-service-web-configure-tls-mutual-auth). The following guidance pertains to configuring the ASP.NET Core app.

In `Startup.Configure`, add the following code before the call to `app.UseAuthentication();`:

```csharp
app.UseCertificateForwarding();
```


Configure Certificate Forwarding Middleware to specify the header name that Azure uses. In `Startup.ConfigureServices`, add the following code to configure the header from which the middleware builds a certificate:

```csharp
services.AddCertificateForwarding(options =>
    options.CertificateHeader = "X-ARR-ClientCert");
```

### Other web proxies

If a proxy is used that isn't IIS or Azure App Service's Application Request Routing (ARR), configure the proxy to forward the certificate that it received in an HTTP header. In `Startup.Configure`, add the following code before the call to `app.UseAuthentication();`:

```csharp
app.UseCertificateForwarding();
```

Configure the Certificate Forwarding Middleware to specify the header name. In `Startup.ConfigureServices`, add the following code to configure the header from which the middleware builds a certificate:

```csharp
services.AddCertificateForwarding(options =>
    options.CertificateHeader = "YOUR_CERTIFICATE_HEADER_NAME");
```

If the proxy isn't base64-encoding the certificate (as is the case with Nginx), set the `HeaderConverter` option. Consider the following example in `Startup.ConfigureServices`:

```csharp
services.AddCertificateForwarding(options =>
{
    options.CertificateHeader = "YOUR_CUSTOM_HEADER_NAME";
    options.HeaderConverter = (headerValue) => 
    {
        var clientCertificate = 
           /* some conversion logic to create an X509Certificate2 */
        return clientCertificate;
    }
});
```

## Troubleshoot

When headers aren't forwarded as expected, enable [logging](xref:fundamentals/logging/index). If the logs don't provide sufficient information to troubleshoot the problem, enumerate the request headers received by the server. Use inline middleware to write request headers to an app response or log the headers. 

To write the headers to the app's response, place the following terminal inline middleware immediately after the call to <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*> in `Startup.Configure`:

```csharp
app.Run(async (context) =>
{
    context.Response.ContentType = "text/plain";

    // Request method, scheme, and path
    await context.Response.WriteAsync(
        $"Request Method: {context.Request.Method}{Environment.NewLine}");
    await context.Response.WriteAsync(
        $"Request Scheme: {context.Request.Scheme}{Environment.NewLine}");
    await context.Response.WriteAsync(
        $"Request Path: {context.Request.Path}{Environment.NewLine}");

    // Headers
    await context.Response.WriteAsync($"Request Headers:{Environment.NewLine}");

    foreach (var header in context.Request.Headers)
    {
        await context.Response.WriteAsync($"{header.Key}: " +
            $"{header.Value}{Environment.NewLine}");
    }

    await context.Response.WriteAsync(Environment.NewLine);

    // Connection: RemoteIp
    await context.Response.WriteAsync(
        $"Request RemoteIp: {context.Connection.RemoteIpAddress}");
});
```

You can write to logs instead of the response body. Writing to logs allows the site to function normally while debugging.

To write logs rather than to the response body:

* Inject `ILogger<Startup>` into the `Startup` class as described in [Create logs in Startup](xref:fundamentals/logging/index#create-logs-in-startup).
* Place the following inline middleware immediately after the call to <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders*> in `Startup.Configure`.

```csharp
app.Use(async (context, next) =>
{
    // Request method, scheme, and path
    _logger.LogDebug("Request Method: {Method}", context.Request.Method);
    _logger.LogDebug("Request Scheme: {Scheme}", context.Request.Scheme);
    _logger.LogDebug("Request Path: {Path}", context.Request.Path);

    // Headers
    foreach (var header in context.Request.Headers)
    {
        _logger.LogDebug("Header: {Key}: {Value}", header.Key, header.Value);
    }

    // Connection: RemoteIp
    _logger.LogDebug("Request RemoteIp: {RemoteIpAddress}", 
        context.Connection.RemoteIpAddress);

    await next();
});
```

When processed, `X-Forwarded-{For|Proto|Host}` values are moved to `X-Original-{For|Proto|Host}`. If there are multiple values in a given header, Forwarded Headers Middleware processes headers in reverse order from right to left. The default `ForwardLimit` is `1` (one), so only the rightmost value from the headers is processed unless the value of `ForwardLimit` is increased.

The request's original remote IP must match an entry in the `KnownProxies` or `KnownNetworks` lists before forwarded headers are processed. This limits header spoofing by not accepting forwarders from untrusted proxies. When an unknown proxy is detected, logging indicates the address of the proxy:

```console
September 20th 2018, 15:49:44.168 Unknown proxy: 10.0.0.100:54321
```

In the preceding example, 10.0.0.100 is a proxy server. If the server is a trusted proxy, add the server's IP address to `KnownProxies` (or add a trusted network to `KnownNetworks`) in `Startup.ConfigureServices`. For more information, see the [Forwarded Headers Middleware options](#forwarded-headers-middleware-options) section.

```csharp
services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
});
```

> [!IMPORTANT]
> Only allow trusted proxies and networks to forward headers. Otherwise, [IP spoofing](https://www.iplocation.net/ip-spoofing) attacks are possible.

## Additional resources

* <xref:host-and-deploy/web-farm>
* [Microsoft Security Advisory CVE-2018-0787: ASP.NET Core Elevation Of Privilege Vulnerability](https://github.com/aspnet/Announcements/issues/295)
* [YARP: Yet Another Reverse Proxy](https://microsoft.github.io/reverse-proxy/index.html)

:::moniker-end
