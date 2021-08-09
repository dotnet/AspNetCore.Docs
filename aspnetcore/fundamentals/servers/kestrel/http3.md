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

[HTTP/3](https://quicwg.org/base-drafts/draft-ietf-quic-http.html) is available for ASP.NET Core apps when the following requirements are met:

## Requirements

HTTP/3 is not supported everywhere. The requirements are different depending on the operating system that Kestrel is running on.

Kestrel enables HTTP/3 only on environments that support it. That means it's possible to configure a port to support all HTTP protocols. For example, `HttpProtocols.Http1AndHttp2AndHttp3`, and Kestrel's HTTP/3 is available on environments where it's supported.

### Windows
* Windows 11 Build 22000 or later.
* Transport Layer Security (TLS) 1.3 enabled. It is enabled by default.

The preceding Windows 11 Build versions may require the use of a [Windows Insider](https://insider.windows.com) build.

### Linux

On Linux, `libmsquic` is published via Microsoft official Linux package repository `packages.microsoft.com`. In order to consume it, it must be added manually. See [Linux Software Repository for Microsoft Products](/windows-server/administration/linux-package-repository-for-microsoft-software). After adding `libmsquic`, it can be installed via the package manager of your distro, for example, for Ubuntu:
```
apt install libmsquic
```

### macOS

HTTP/3 is not currently supported on macOS and may be available in a future release.

## Alt-svc

Http/3 is discovered as an upgrade from HTTP/1.1 or HTTP/2 via the alt-svc header. That means the first request will normally use HTTP/1.1 or HTTP/2 before switching to HTTP/3.

## Get started

HTTP/3 is configured on app start-up. The following code:

* Configures the `WebHost` to `UseQuic`.
* Sets `EnableAltSvc` to `true` on Kestrel options.
* Configures port 5001 to use `HttpProtocols.Http1AndHttp2AndHttp3`.

This sample code is specific to .Net 6 Preview 7, and will change in .Net 6 RC 1.

[!code-csharp[](samples/6.x/Http3Sample/Program.cs?name=snippet_UseHttp3&highlight=8)]

For more information on building the host, see the **Set up a host** and **Default builder settings** sections of <xref:fundamentals/host/generic-host#set-up-a-host>.

## Localhost testing
* Browsers do not enable HTTP/3 on localhost/loopback connections: to test with a browser, run the client and server on separate machines.
* HttpClient can be used for localhost/loopback testing.
