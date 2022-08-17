---
title: Request Decompression in ASP.NET Core
author: david-acker
description: Learn how to use the request decompression middleware in ASP.NET Core
monikerRange: '>= aspnetcore-7.0'
ms.author: david-acker
ms.date: 8/17/2022
uid: fundamentals/middleware/request-decompression
---
# Request Decompression in ASP.NET Core

By [David Acker](https://github.com/david-acker)

The request decompression middleware enables API endpoints to start accepting requests with compressed content, without requiring developers to manually handle compressed requests, by using the `Content-Encoding` HTTP header to automatically identify and decompress requests which contain compressed content.

When the `Content-Encoding` header value on a request matches one of the available decompression providers, the middleware will use the matching provider to wrap the <xref:Microsoft.AspNetCore.Http.HttpRequest.Body?displayProperty=nameWithType> in an appropriate decompression stream and remove the `Content-Encoding` header (indicating that the request body is no longer compressed). For requests with uncompressed content, which specify no `Content-Encoding` header, the middleware will simply pass the requests on unchanged.

> [!NOTE]
> * Decompression occurs when the body of the request is being read (e.g. at the endpoint, during model binding). The request body is not decompressed eagerly.
> * If the compressed data is invalid for the specified `Content-Encoding`, an exception will be thrown when attempting to read the decompressed request body.

In the event that the middleware encounters a request with compressed content but will not be able to decompress the request, such as the request having an unsupported `Content-Encoding` header value or multiple `Content-Encoding` header values, the middleware will pass the request on changed.

## Configuration

The following code shows how to enable request decompression for the default `Content-Encoding` types:

[!code-csharp[](samples/request-decompression/7.x/Program.cs?name=snippet_WithDefaultProviders&highlight=3,7)]

## Decompression Providers

### Default Providers

The `Content-Encoding` header values that the request decompression middleware supports by default are listed in the following table:

| [`Content-Encoding`](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding) header values | Description |
| --------- | --------- |
| `br`      | [Brotli compressed data format](https://tools.ietf.org/html/rfc7932) |
| `deflate` | [DEFLATE compressed data format](https://tools.ietf.org/html/rfc1951) |
| `gzip`    | [Gzip file format](https://tools.ietf.org/html/rfc1952) |

### Custom Providers

Support for custom or niche encodings can be added by creating custom decompression provider classes which implement <xref:Microsoft.AspNetCore.RequestDecompression.IDecompressionProvider>:

[!code-csharp[](samples/request-decompression/7.x/CustomDecompressionProvider.cs?name=snippet_CustomDecompressionProvider)]

These custom decompression providers can then be registered with <xref:Microsoft.AspNetCore.RequestDecompression.RequestDecompressionOptions> along with their corresponding `Content-Encoding` header values:

[!code-csharp[](samples/request-decompression/7.x/Program.cs?name=snippet_WithCustomProvider&highlight=3-6,10)]

## Request Size Limits

In order to guard against [zip bombs/decompression bombs](https://en.wikipedia.org/wiki/Zip_bomb), the maximum size of the decompressed request body is limited to the request body size limit enforced by the endpoint or server. If the number of bytes read from the decompressed request body stream exceeds this limit, an [InvalidOperationException](xref:System.InvalidOperationException) will be thrown to prevent additional bytes from being read from the stream.

If available, the size limit specified for the endpoint by <xref:Microsoft.AspNetCore.Http.Metadata.IRequestSizeLimitMetadata.MaxRequestBodySize?displayProperty=nameWithType>, such as <xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute> or <xref:Microsoft.AspNetCore.Mvc.DisableRequestSizeLimitAttribute> for MVC endpoints, will be used. Otherwise, the global server size limit specified by <xref:Microsoft.AspNetCore.Http.Features.IHttpMaxRequestBodySizeFeature.MaxRequestBodySize?displayProperty=nameWithType> will be used.

> [!WARNING]
> Disabling the request body size limit poses a security risk in regards to uncontrolled resource consumption, particularly if the request body is being buffered. Ensure that safeguards are in place to mitigate the risk of denial of service attacks.

## Additional Resources

* <xref:fundamentals/middleware/index>
* [Mozilla Developer Network: Content-Encoding](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Encoding)
* [Brotli Compressed Data Format](https://www.rfc-editor.org/rfc/rfc7932)
* [DEFLATE Compressed Data Format Specification version 1.3](https://www.rfc-editor.org/rfc/rfc1951)
* [GZIP file format specification version 4.3](https://www.rfc-editor.org/rfc/rfc1952)