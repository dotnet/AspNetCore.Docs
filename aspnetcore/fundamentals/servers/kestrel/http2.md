---
title: Use HTTP/2 with the ASP.NET Core Kestrel web server
author: tdykstra
description: Learn about using HTTP/2 with Kestrel, the cross-platform web server for ASP.NET Core.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/15/2022
uid: fundamentals/servers/kestrel/http2
---

# Use HTTP/2 with the ASP.NET Core Kestrel web server

:::moniker range=">= aspnetcore-8.0"

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is available for ASP.NET Core apps if the following base requirements are met:

* Operating system
  * Windows Server 2016/Windows 10 or later&Dagger;
  * Linux with OpenSSL 1.0.2 or later (for example, Ubuntu 16.04 or later)
  * macOS 10.15 or later
* Target framework: .NET Core 2.2 or later
* [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) connection
* TLS 1.2 or later connection

&Dagger;Kestrel has limited support for HTTP/2 on Windows Server 2012 R2 and Windows 8.1. Support is limited because the list of supported TLS cipher suites available on these operating systems is limited. A certificate generated using an Elliptic Curve Digital Signature Algorithm (ECDSA) may be required to secure TLS connections.

If an HTTP/2 connection is established, [HttpRequest.Protocol](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol%2A) reports `HTTP/2`.

Starting with .NET Core 3.0, HTTP/2 is enabled by default. For more information on configuration, see the [Kestrel HTTP/2 limits](xref:fundamentals/servers/kestrel/options#http2-limits) and [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) sections.

## Advanced HTTP/2 features

Additional HTTP/2 features in Kestrel support gRPC, including support for response trailers and sending reset frames.

### Trailers

[!INCLUDE[](~/includes/trailers.md)]

### Reset

[!INCLUDE[](~/includes/reset.md)]

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is available for ASP.NET Core apps if the following base requirements are met:

* Operating system&dagger;
  * Windows Server 2016/Windows 10 or later&Dagger;
  * Linux with OpenSSL 1.0.2 or later (for example, Ubuntu 16.04 or later)
* Target framework: .NET Core 2.2 or later
* [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) connection
* TLS 1.2 or later connection

&dagger;HTTP/2 will be supported on macOS in a future release.
&Dagger;Kestrel has limited support for HTTP/2 on Windows Server 2012 R2 and Windows 8.1. Support is limited because the list of supported TLS cipher suites available on these operating systems is limited. A certificate generated using an Elliptic Curve Digital Signature Algorithm (ECDSA) may be required to secure TLS connections.

If an HTTP/2 connection is established, [HttpRequest.Protocol](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol%2A) reports `HTTP/2`.

Starting with .NET Core 3.0, HTTP/2 is enabled by default. For more information on configuration, see the [Kestrel HTTP/2 limits](xref:fundamentals/servers/kestrel/options#http2-limits) and [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) sections.

## Advanced HTTP/2 features

Additional HTTP/2 features in Kestrel support gRPC, including support for response trailers and sending reset frames.

### Trailers

[!INCLUDE[](~/includes/trailers.md)]

### Reset

[!INCLUDE[](~/includes/reset.md)]

:::moniker-end

:::moniker range="< aspnetcore-7.0"

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is available for ASP.NET Core apps if the following base requirements are met:

* Operating system&dagger;
  * Windows Server 2016/Windows 10 or later&Dagger;
  * Linux with OpenSSL 1.0.2 or later (for example, Ubuntu 16.04 or later)
* Target framework: .NET Core 2.2 or later
* [Application-Layer Protocol Negotiation (ALPN)](https://tools.ietf.org/html/rfc7301#section-3) connection
* TLS 1.2 or later connection

&dagger;HTTP/2 will be supported on macOS in a future release.
&Dagger;Kestrel has limited support for HTTP/2 on Windows Server 2012 R2 and Windows 8.1. Support is limited because the list of supported TLS cipher suites available on these operating systems is limited. A certificate generated using an Elliptic Curve Digital Signature Algorithm (ECDSA) may be required to secure TLS connections.

If an HTTP/2 connection is established, [HttpRequest.Protocol](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol%2A) reports `HTTP/2`.

Starting with .NET Core 3.0, HTTP/2 is enabled by default. For more information on configuration, see the [Kestrel HTTP/2 limits](xref:fundamentals/servers/kestrel/options#http2-limits) and [ListenOptions.Protocols](xref:fundamentals/servers/kestrel/endpoints#listenoptionsprotocols) sections.

## Advanced HTTP/2 features

Additional HTTP/2 features in Kestrel support gRPC, including support for response trailers and sending reset frames.

### Trailers

[!INCLUDE[](~/includes/trailers.md)]

### Reset

[!INCLUDE[](~/includes/reset.md)]

:::moniker-end
