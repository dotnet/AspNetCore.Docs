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

[HTTP/3](https://quicwg.org/base-drafts/draft-ietf-quic-http.html) is the third and upcoming major version of HTTP. HTTP/3 uses the same semantics as HTTP/1.1 and HTTP/2: the same request methods, status codes, and message fields apply to all versions. The differences are in the underlying transport. Both HTTP/1.1 and HTTP/2 use TCP as their transport. HTTP/3 uses a new transport technology developed alongside HTTP/3 called QUIC.

HTTP/3 and QUIC have a number of benefits compared to older HTTP versions:

* Faster response time of the first request. QUIC and HTTP/3 negotiates the connection in fewer round-trips between the client and the server. The first request reachs the server faster.
* Improved experience when there is connection packet loss. HTTP/2 multiplexes multiple requests via one TCP connection. Packet loss on the connection would affect all requests. This problem is called "head-of-line blocking". Because QUIC provides native multiplexing, lost packets only impact the requests where data has been lost.
* Supports transitioning between networks. This feature is useful for mobile devices where it is common to switch between WIFI and cellular networks as a mobile device changes location. Today HTTP/1.1 and HTTP/2 connections will fail with an error and force an app or web browser to retry. HTTP/3 allows the app or web browser to seamlessly continue when a network changes. Kestrel doesn't support network transitions in .NET 6. We'll explore adding it in a future .NET release.

> [!IMPORTANT]
> HTTP/3 is shipping in .NET 6 as a preview feature. There may be behavioral or performance issues in the initial HTTP/3 release with .NET 6. Apps should be designed to support older HTTP versions so that if issues are identified in HTTP/3 it is possible to temporarily disable HTTP/3 until issues are resolved and the app is updated.

## HTTP/3 requirements

HTTP/3 isn't supported everywhere. The requirements are different depending on the operating system that Kestrel is running on.

When using HTTP/3, it is recommended to enable it alongside other HTTP version. Because Kestrel only enables HTTP/3 if an environment support it, a port configured to serve all HTTP protocols will automatically enable HTTP/3 if it is available. If HTTP/3 isn't available then the port continues to serve HTTP/1.1 and HTTP/2 requests.

For example, `HttpProtocols.Http1AndHttp2AndHttp3` allows Kestrel to enable HTTP/3 on environments where it is supported, along side HTTP/1.1 and HTTP/2.

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

HTTP/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the `alt-svc` header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3.

## Get started

HTTP/3 is configured on app start-up. The following code:

* Configures the `WebHost` to `UseQuic`.
* Sets `EnableAltSvc` to `true` on Kestrel options.
* Configures port 5001 to use `HttpProtocols.Http1AndHttp2AndHttp3`.

This sample code is specific to .NET 6 Preview 7, and will change in .NET 6 RC 1.

[!code-csharp[](samples/6.x/Http3Sample/Program.cs?name=snippet_UseHttp3&highlight=8)]

For more information on building the host, see the **Set up a host** and **Default builder settings** sections of <xref:fundamentals/host/generic-host#set-up-a-host>.

## Localhost testing

* Browsers do not enable HTTP/3 on localhost/loopback connections: to test with a browser, run the client and server on separate machines.
* `HttpClient` can be used for localhost/loopback testing in .NET 6 or later. Extra configured is required when using `HttpClient` to make a HTTP/3 request:
  * Set `HttpRequestMessage.Version` to 3.0, or
  * Set `HttpRequestMessage.VersionPolicy` to `HttpVersionPolicy.RequestVersionOrHigher`.
