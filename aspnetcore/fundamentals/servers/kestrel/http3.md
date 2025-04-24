---
title: Use HTTP/3 with the ASP.NET Core Kestrel web server
author: wtgodbe
description: Learn about using HTTP/3 with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-6.0'
ms.author: wigodbe
ms.custom: mvc, linux-related-content
ms.date: 08/24/2023
uid: fundamentals/servers/kestrel/http3
---

# Use HTTP/3 with the ASP.NET Core Kestrel web server

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

[HTTP/3](https://datatracker.ietf.org/doc/rfc9114/) is an approved standard and the third major version of HTTP. This article discusses the requirements for HTTP/3. HTTP/3 is fully supported in ASP.NET Core 7.0 and later.

> [!IMPORTANT]
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2.

## HTTP/3 benefits

HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a transport technology developed alongside HTTP/3 called [QUIC](https://www.rfc-editor.org/rfc/rfc9000.html).

HTTP/3 and QUIC have a number of benefits compared to HTTP/1.1 and HTTP/2:

* Faster response time of the first request. QUIC and HTTP/3 negotiates the connection in fewer round-trips between the client and the server. The first request reaches the server faster.
* Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
* Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Currently, HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browsers must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. Kestrel doesn't support network transitions yet. It may be available in a future release.

## HTTP/3 requirements

HTTP/3 uses QUIC as its transport protocol. The ASP.NET Core implementation of HTTP/3 depends on [MsQuic](https://github.com/microsoft/msquic) to provide QUIC functionality. As a result, ASP.NET Core support of HTTP/3 depends on MsQuic platform requirements. For more information on how to install **MsQuic**, see [QUIC Platform dependencies](/dotnet/fundamentals/networking/quic/quic-overview#platform-dependencies). If the platform that Kestrel is running on doesn't have all the requirements for HTTP/3, then it's disabled, and Kestrel will fall back to other HTTP protocols.

## Getting started

HTTP/3 is not enabled by default. Add configuration to `Program.cs` to enable HTTP/3.

:::code language="csharp" source="samples/6.x/KestrelSample/Snippets/Program.cs" id="snippet_Http3" highlight="7-8":::

The preceding code configures port 5001 to:

* Use HTTP/3 alongside HTTP/1.1 and HTTP/2 by specifying `HttpProtocols.Http1AndHttp2AndHttp3`.
* Enable HTTPS with `UseHttps`. HTTP/3 requires HTTPS.

Because not all routers, firewalls, and proxies properly support HTTP/3, HTTP/3 should be configured together with HTTP/1.1 and HTTP/2. This can be done by specifying [`HttpProtocols.Http1AndHttp2AndHttp3`](xref:Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1AndHttp2AndHttp3) as an endpoint's supported protocols.

For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

## Alt-svc

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the [`alt-svc`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Alt-Svc) header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3. Kestrel automatically adds the `alt-svc` header if HTTP/3 is enabled.

## Localhost testing

* Browsers don't allow self-signed certificates on HTTP/3, such as the Kestrel development certificate.
* `HttpClient` can be used for localhost/loopback testing in .NET 6 or later. Extra configuration is required when using `HttpClient` to make an HTTP/3 request:

  * Set [`HttpRequestMessage.Version`](xref:System.Net.Http.HttpRequestMessage.Version) to 3.0, or
  * Set [`HttpRequestMessage.VersionPolicy`](xref:System.Net.Http.HttpRequestMessage.VersionPolicy) to [`HttpVersionPolicy.RequestVersionOrHigher`](xref:System.Net.Http.HttpVersionPolicy.RequestVersionOrHigher).

For more information on how to use HTTP/3 with `HttpClient`, see [HTTP/3 with .NET](/dotnet/core/extensions/httpclient-http3).

:::moniker-end

[!INCLUDE[](~/fundamentals/servers/kestrel/includes/http3-6-7.md)]
