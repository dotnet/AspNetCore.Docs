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

[HTTP/3](https://quicwg.org/base-drafts/draft-ietf-quic-http.html) is available for ASP.NET Core apps if the following base requirements are met:

### Windows
Prerequisites:
- Latest [Windows Insider Builds](https://insider.windows.com/en-us/), Insiders Fast build. This is required for SChannel support for QUIC.
  - To confirm you have a new enough build, run winver on command line and confirm you version is greater than Version 2004 (OS Build 20145.1000).
- Turned on TLS 1.3
  - It is turned on by default.

During the build, the `msquic.dll` is automatically downloaded and placed in correct directories in order to be picked up by the runtime. It is also published as part of the runtime for Windows.

### Linux

On Linux, `libmsquic` is published via Microsoft official Linux package repository `packages.microsoft.com`. In order to consume it, you have to add it manually, see https://docs.microsoft.com/en-us/windows-server/administration/linux-package-repository-for-microsoft-software. After that, you should be able to install it via the package manager of your distro, e.g. for Ubuntu:
```
apt install libmsquic
```

### macOS

HTTP/3 will be supported on macOS in a future release.
