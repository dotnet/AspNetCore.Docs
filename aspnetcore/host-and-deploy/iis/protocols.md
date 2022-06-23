---
title: Use ASP.NET Core with HTTP/2 on IIS
author: rick-anderson
description: Learn how to use HTTP/2 features with IIS.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2020
uid: host-and-deploy/iis/protocols
---

# Use ASP.NET Core with HTTP/2 on IIS

By [Justin Kotalik](https://github.com/jkotalik)

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is supported with ASP.NET Core in the following IIS deployment scenarios:

* Windows Server 2016 or later / Windows 10 or later
* IIS 10 or later
* TLS 1.2 or later connection
* When [hosting out-of-process](xref:host-and-deploy/iis/index#out-of-process-hosting-model): Public-facing edge server connections use HTTP/2, but the reverse proxy connection to the [Kestrel server](xref:fundamentals/servers/kestrel) uses HTTP/1.1.

For an in-process deployment when an HTTP/2 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/2`. For an out-of-process deployment when an HTTP/2 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/1.1`.

For more information on the in-process and out-of-process hosting models, see <xref:host-and-deploy/aspnet-core-module>.

HTTP/2 is enabled by default for HTTPS/TLS connections. Connections fall back to HTTP/1.1 if an HTTP/2 connection isn't established. For more information on HTTP/2 configuration with IIS deployments, see [HTTP/2 on IIS](/iis/get-started/whats-new-in-iis-10/http2-on-iis).

## Advanced HTTP/2 features to support gRPC

Additional HTTP/2 features in IIS support gRPC, including support for response trailers and sending reset frames.

Requirements to run gRPC on IIS:

* In-process hosting.
* Windows 11 Build 22000 or later, Windows Server 2022 Build 20348 or later.
* TLS 1.2 or later connection.

### Trailers

[!INCLUDE[](~/includes/trailers.md)]

### Reset

[!INCLUDE[](~/includes/reset.md)]
