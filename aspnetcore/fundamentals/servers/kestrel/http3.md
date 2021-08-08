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

Kestrel will enable HTTP/3 only on environments that support it. That means it is possible to configure a port to support all HTTP protocols, e.g. `HttpProtocols.Http1AndHttp2AndHttp3`, and Kestrel's HTTP/3 support will light up on environments where it is available.

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

## Get started

HTTP/3 is configured on app start-up. The following code:

* Configures the `WebHost` to `UseQuic`.
* Sets `EnableAltSvc` to `true` on Kestrel options.
* Configures port 5001 to use `HttpProtocols.Http1AndHttp2AndHttp3`.

[!code-csharp[](samples/6.x/Http3Sample/Program.cs?name=snippet_UseHttp3&highlight=8)]

For more information on building the host, see the *Set up a host* and *Default builder settings* sections of <xref:fundamentals/host/generic-host#set-up-a-host>.
