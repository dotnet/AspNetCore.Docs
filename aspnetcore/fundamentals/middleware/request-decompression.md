---
title: Request decompression in ASP.NET Core
author: david-acker
description: Learn how to use the request decompression middleware in ASP.NET Core
monikerRange: '>= aspnetcore-7.0'
ms.author: riande
ms.date: 8/17/2022
uid: fundamentals/middleware/request-decompression
---
# Request decompression in ASP.NET Core

By [David Acker](https://github.com/david-acker)

Request decompression middleware:

* Enables API endpoints to accept requests with compressed content.
* Uses the [`Content-Encoding`](https://developer.mozilla.org/docs/Web/HTTP/Headers/Content-Encoding) HTTP header to automatically identify and decompress requests which contain compressed content.
* Eliminates the need to write code to handle compressed requests.

When the `Content-Encoding` header value on a request matches one of the available decompression providers, the middleware:

* Uses the matching provider to wrap the <xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType> in an appropriate decompression stream.
* Removes the `Content-Encoding` header, indicating that the request body is no longer compressed.

Requests that don't include a `Content-Encoding` header are ignored by the request decompression middleware.

Decompression:

* Occurs when the body of the request is read. That is, decompression occurs at the endpoint on model binding. The request body isn't decompressed eagerly.
* When attempting to read the decompressed request body with invalid compressed data for the specified `Content-Encoding`, an exception is thrown. Brotli can throw <xref:System.InvalidOperationException?displayProperty=fullName>: :::no-loc text="Decoder ran into invalid data."::: Deflate and GZip can throw <xref:System.IO.InvalidDataException?displayProperty=fullName>: :::no-loc text="The archive entry was compressed using an unsupported compression method.":::

If the middleware encounters a request with compressed content but is unable to decompress it, the request is passed to the next delegate in the pipeline. For example, a request with an unsupported `Content-Encoding` header value or multiple `Content-Encoding` header values is passed to the next delegate in the pipeline.

## Configuration

The following code shows how to enable request decompression for the [default](#default) `Content-Encoding` types:

[!code-csharp[](samples/request-decompression/7.x/Program.cs?name=snippet_WithDefaultProviders&highlight=3,7)]

<a name="default"></a>

## Default decompression providers

The `Content-Encoding` header values that the request decompression middleware supports by default are listed in the following table:

| [`Content-Encoding`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding) header values | Description |
| --------- | --------- |
| `br`      | [Brotli compressed data format](https://tools.ietf.org/html/rfc7932) |
| `deflate` | [DEFLATE compressed data format](https://tools.ietf.org/html/rfc1951) |
| `gzip`    | [Gzip file format](https://tools.ietf.org/html/rfc1952) |

## Custom decompression providers

Support for custom encodings can be added by creating custom decompression provider classes that implement <xref:Microsoft.AspNetCore.RequestDecompression.IDecompressionProvider>:

[!code-csharp[](samples/request-decompression/7.x/CustomDecompressionProvider.cs?name=snippet_CustomDecompressionProvider)]

Custom decompression providers are registered with <xref:Microsoft.AspNetCore.RequestDecompression.RequestDecompressionOptions> along with their corresponding `Content-Encoding` header values:

[!code-csharp[](samples/request-decompression/7.x/Program.cs?name=snippet_WithCustomProvider&highlight=3-6,10)]

## Request size limits

In order to guard against [zip bombs or decompression bombs](https://en.wikipedia.org/wiki/Zip_bomb):

* The maximum size of the decompressed request body is limited to the request body size limit enforced by the endpoint or server.
* If the number of bytes read from the decompressed request body stream exceeds the limit, an [InvalidOperationException](xref:System.InvalidOperationException) is thrown to prevent additional bytes from being read from the stream.

In order of precedence, the maximum request size for an endpoint is set by:

1. <xref:Microsoft.AspNetCore.Http.Metadata.IRequestSizeLimitMetadata.MaxRequestBodySize?displayProperty=nameWithType>, such as <xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute> or <xref:Microsoft.AspNetCore.Mvc.DisableRequestSizeLimitAttribute> for MVC endpoints.
2. The global server size limit <xref:Microsoft.AspNetCore.Http.Features.IHttpMaxRequestBodySizeFeature.MaxRequestBodySize?displayProperty=nameWithType>. `MaxRequestBodySize` can be overridden per request with <xref:Microsoft.AspNetCore.Http.Features.IHttpMaxRequestBodySizeFeature.MaxRequestBodySize?displayProperty=nameWithType>, but defaults to the limit configured for the web server implementation.

| Web server implementation | `MaxRequestBodySize` configuration |
| --------- | --------- |
| [HTTP.sys](xref:fundamentals/servers/httpsys) | <xref:Microsoft.AspNetCore.Server.HttpSys.HttpSysOptions.MaxRequestBodySize?displayProperty=nameWithType> |
| [IIS](xref:host-and-deploy/iis/index) | <xref:Microsoft.AspNetCore.Builder.IISServerOptions.MaxRequestBodySize?displayProperty=nameWithType> |
| [Kestrel](xref:fundamentals/servers/kestrel) | <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize?displayProperty=nameWithType> |


> [!WARNING]
> Disabling the request body size limit poses a security risk in regards to uncontrolled resource consumption, particularly if the request body is being buffered. Ensure that safeguards are in place to mitigate the risk of [denial-of-service](https://www.cisa.gov/uscert/ncas/tips/ST04-015) (DoS) attacks.

## Additional Resources

* <xref:fundamentals/middleware/index>
* [Mozilla Developer Network: Content-Encoding](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding)
* [Brotli Compressed Data Format](https://www.rfc-editor.org/rfc/rfc7932)
* [DEFLATE Compressed Data Format Specification version 1.3](https://www.rfc-editor.org/rfc/rfc1951)
* [GZIP file format specification version 4.3](https://www.rfc-editor.org/rfc/rfc1952)
