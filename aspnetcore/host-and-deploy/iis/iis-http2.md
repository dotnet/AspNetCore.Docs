---
title: Using HTTP/2 with IIS
author: rick-anderson
description: Learn how to use HTTP/2 features with IIS.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
ms.custom: mvc
ms.date: 01/13/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: host-and-deploy/iis/iis-http2
---
# Using HTTP/2 with IIS

By [Justin Kotalik](https://github.com/jkotalik)

[HTTP/2](https://httpwg.org/specs/rfc7540.html) is supported with ASP.NET Core in the following IIS deployment scenarios:

* In-process
  * Windows Server 2016/Windows 10 or later; IIS 10 or later
  * TLS 1.2 or later connection
* Out-of-process
  * Windows Server 2016/Windows 10 or later; IIS 10 or later
  * Public-facing edge server connections use HTTP/2, but the reverse proxy connection to the [Kestrel server](xref:fundamentals/servers/kestrel) uses HTTP/1.1.
  * TLS 1.2 or later connection

For an in-process deployment when an HTTP/2 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/2`. For an out-of-process deployment when an HTTP/2 connection is established, [`HttpRequest.Protocol`](xref:Microsoft.AspNetCore.Http.HttpRequest.Protocol*) reports `HTTP/1.1`.

For more information on the in-process and out-of-process hosting models, see <xref:host-and-deploy/aspnet-core-module>.

HTTP/2 is enabled by default. Connections fall back to HTTP/1.1 if an HTTP/2 connection isn't established. For more information on HTTP/2 configuration with IIS deployments, see [HTTP/2 on IIS](/iis/get-started/whats-new-in-iis-10/http2-on-iis).

## Advanced HTTP/2 features to support gRPC

Additional HTTP/2 features in IIS support gRPC, including support for response trailers and sending reset frames.

Requirements to run gRPC on IIS:

* Must use in-process hosting.
* Windows 10 Version 2004, OS Build 20300.1000 or later
* TLS 1.2 or later connection

### Trailers

HTTP Trailers are similar to HTTP Headers, except they are sent after the response body is sent. For IIS, only HTTP/2 response trailers are supported.

```csharp
if (httpContext.Response.SupportsTrailers())
{
    // Write body
    httpContext.Response.WriteAsync("Hello world");

    httpContext.Response.AppendTrailer("trailername", "TrailerValue");
}
```

In the preceding example code:

* `SupportsTrailers` ensures that trailers are supported for the response.
* `AppendTrailer` appends the trailer.

### Reset

Reset allows for the server to reset a HTTP/2 request with a specified error code. A reset request is considered aborted.

```csharp
var resetFeature = httpContext.Features.Get<IHttpResetFeature>();
resetFeature.Reset(errorCode: 2);
```

`Reset` in the preceding code example specifies the `INTERNAL_ERROR` error code. For more information about HTTP/2 error codes, visit the [HTTP/2 specification error code section](https://tools.ietf.org/html/rfc7540#page-50).