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

[HTTP/3](https://datatracker.ietf.org/doc/rfc9114/) is an approved standard and the third major version of HTTP. This article discusses the requirements for HTTP/3. HTTP/3 is fully supported in .NET 7 or later.

> [!IMPORTANT]
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2.

## HTTP/3 benefits

`HTTP/3`:

* Is the latest version of the Hypertext Transfer Protocol.
* Builds on the strengths of `HTTP/2` while addressing some of its limitations, particularly in terms of performance, latency, reliability, and security.

+---------------+-------------------------+-------------------------+
| Feature | `HTTP/2` | `HTTP/3` |
+---------------+-------------------------+-------------------------+
| Transport | Uses [TCP](https://developer.mozilla.org/docs/Glossary/TCP) | Uses [QUIC](https://www.rfc-editor.org/rfc/rfc9000.html)  |
| Layer | | |
| Connection | Slower due to TCP + TLS | Faster with 0-RTT QUIC |
| Setup | handshake | handshakes |
| Head-of-Line | Affected by TCP-level | Eliminated with QUIC |
| Blocking | blocking | stream multiplexing |
| Encryption | TLS over TCP | TLS is built into QUIC |
+---------------+-------------------------+-------------------------+


The key differences from `HTTP/2` to `HTTP/3` are:

* **Transport Protocol**: `HTTP/3` uses QUIC instead of TCP. QUIC offers improved performance, lower latency, and better reliability, especially on mobile and lossy networks.
* **Head-of-Line Blocking**: `HTTP/2` can suffer from head-of-line blocking at the TCP level, where a delay in one stream can affect others. `HTTP/3`, with QUIC, provides independent streams, so packet loss in one stream doesn't stall others.
* **Connection Establishment**: `HTTP/3` with QUIC can establish connections faster, sometimes in zero round-trip time (0-RTT) for returning clients, as it combines transport and encryption handshakes.
* **Encryption**: `HTTP/3` mandates TLS 1.3 encryption, providing enhanced security by default, whereas it's optional in `HTTP/2`.
* **Multiplexing**: While both support multiplexing, `HTTP/3`'s implementation with QUIC is more efficient and avoids the TCP-level head-of-line blocking issues.
* **Connection Migration**: QUIC in `HTTP/3` allows connections to persist even when a client's IP address changes (like switching from Wi-Fi to cellular), improving mobile user experience.

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
