---
title: Use HTTP/3 with the ASP.NET Core Kestrel web server
author: wtgodbe
description: Learn about using HTTP/3 with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-6.0'
ms.author: wigodbe
ms.custom: mvc
ms.date: 08/06/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/servers/kestrel/http3
---

# Use HTTP/3 with the ASP.NET Core Kestrel web server

[HTTP/3](https://quicwg.org/base-drafts/draft-ietf-quic-http.html) is the third and upcoming major version of HTTP. HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a new transport technology developed alongside HTTP/3 called [QUIC](https://datatracker.ietf.org/doc/html/draft-ietf-quic-transport-34).

HTTP/3 and QUIC have a number of benefits compared to HTTP/1.1 and HTTP/2:

* Faster response time of the first request. QUIC and HTTP/3 negotiates the connection in fewer round-trips between the client and the server. The first request reachs the server faster.
* Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection affects all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
* Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Currently HTTP/1.1 and HTTP/2 connections fail with an error when switching networks. An app or web browsers must retry any failed HTTP requests. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. Kestrel doesn't support network transitions in .NET 6. It may be available in a future release.

> [!IMPORTANT]
> HTTP/3 is available in .NET 6 as a *preview feature* because the HTTP/3 specification isn't finalized and behavioral or performance issues may exist in HTTP/3 with .NET 6.
> 
> For more information on preview features, see [the preview features specification](https://github.com/dotnet/designs/blob/main/accepted/2021/preview-features/preview-features.md#are-preview-features-supported).
>
> Apps configured to take advantage of HTTP/3 should be designed to also support HTTP/1.1 and HTTP/2. If issues are identified in HTTP/3, we recommended disabling HTTP/3 until the issues are resolved in a future release of ASP.NET Core. Significant issues are reported at the [Announcements GitHub repository](https://github.com/aspnet/Announcements/issues).

## HTTP/3 requirements

HTTP/3 support is in preview, therefore it's not enabled by default.

Because not all routers, firewalls, and proxies properly support HTTP/3, we recommend configuring HTTP/3 together with HTTP/1.1 and HTTP/2. This can be done by specifying `HttpProtocols.Http1AndHttp2AndHttp3` as an endpoint's supported protocols.

HTTP/3 uses QUIC as its transport protocol. The .NET implementation of HTTP/3 uses [MsQuic](https://github.com/microsoft/msquic) to provide QUIC functionality. MSQuic is included in specific builds of windows and as a library for Linux. If the platform that Kestrel is running on doesn't have all the requirements for HTTP/3 then it's disabled.

For example, `HttpProtocols.Http1AndHttp2AndHttp3` allows Kestrel to enable HTTP/3 on environments where it is supported, with fallbacks for HTTP/1.1 and HTTP/2.

### Windows

* Windows 11 Build 22000 or later.
* TLS 1.3 or later connection.

The preceding Windows 11 Build versions may require the use of a [Windows Insider](https://insider.windows.com) build.

### Linux

On Linux, `libmsquic` is published via Microsoft official Linux package repository `packages.microsoft.com`. In order to consume it, it must be added manually. See [Linux Software Repository for Microsoft Products](/windows-server/administration/linux-package-repository-for-microsoft-software). After adding `libmsquic`, it can be installed via the package manager of your distro, for example, for Ubuntu:

```cmd
apt install libmsquic
```

### macOS

HTTP/3 isn't currently supported on macOS and may be available in a future release.

## Alt-svc

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the `alt-svc` header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3. Kestrel automatically adds the `alt-svc` header if HTTP/3 is enabled.

## Get started

HTTP/3 is configured on app start-up. The following code configures port 5001 to use `HttpProtocols.Http1AndHttp2AndHttp3`.

[!code-csharp[](samples/6.x/Http3Sample/Program.cs?name=snippet_UseHttp3&highlight=8)]

For more information on building the host, see the **Set up a host** and **Default builder settings** sections of <xref:fundamentals/host/generic-host#set-up-a-host>.

## Localhost testing

* Browsers do not enable HTTP/3 on localhost/loopback connections: to test with a browser, run the client and server on separate machines.
* `HttpClient` can be used for localhost/loopback testing in .NET 6 or later. Extra configured is required when using `HttpClient` to make an HTTP/3 request:
  * Set `HttpRequestMessage.Version` to 3.0, or
  * Set `HttpRequestMessage.VersionPolicy` to `HttpVersionPolicy.RequestVersionOrHigher`.
