---
title: Response Compression Middleware for ASP.NET Core
author: guardrex
description: Learn about response compression and how to use Response Compression Middleware in ASP.NET Core apps.
keywords: ASP.NET Core,performance,response compression,gzip,accept-encoding,middleware
ms.author: riande
manager: wpickett
ms.date: 08/20/2017
ms.topic: article
ms.assetid: de621887-c5c9-4ac8-9efd-f5cc0457a134
ms.technology: aspnet
ms.prod: asp.net-core
uid: performance/response-compression
---
# Response Compression Middleware for ASP.NET Core

By [Luke Latham](https://github.com/GuardRex)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/samples)

Network bandwidth is a limited resource. Reducing the size of the response usually increases the responsiveness of an app, often dramatically. One way to reduce payload sizes is to compress an app's responses.

## When to use Response Compression Middleware
Use server-based response compression technologies in IIS, Apache, or Nginx where the performance of the middleware probably won't match that of the server modules. Use Response Compression Middleware when you're unable to use:
* [IIS Dynamic Compression module](https://www.iis.net/overview/reliability/dynamiccachingandcompression)
* [Apache mod_deflate module](http://httpd.apache.org/docs/current/mod/mod_deflate.html)
* [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/)
* [HTTP.sys server](xref:fundamentals/servers/httpsys) (formerly called [WebListener](xref:fundamentals/servers/weblistener))
* [Kestrel](xref:fundamentals/servers/kestrel)

## Response compression
Usually, any response not natively compressed can benefit from response compression. Responses not natively compressed typically include: CSS, JavaScript, HTML, XML, and JSON. You shouldn't compress natively compressed assets, such as PNG files. If you attempt to further compress a natively compressed response, any small additional reduction in size and transmission time will likely be overshadowed by the time it took to process the compression. Don't compress files smaller than about 150-1000 bytes (depending on the file's content and the efficiency of compression). The overhead of compressing small files may produce a compressed file larger than the uncompressed file.

When a client can process compressed content, the client must inform the server of its capabilities by sending the `Accept-Encoding` header with the request. When a server sends compressed content, it must include information in the `Content-Encoding` header on how the compressed response is encoded. Content encoding designations supported by the middleware are shown in the following table.

| `Accept-Encoding` header values | Middleware Supported | Description                                                 |
| :-----------------------------: | :------------------: | ----------------------------------------------------------- |
| `br`                            | No                   | Brotli Compressed Data Format                               |
| `compress`                      | No                   | UNIX "compress" data format                                 |
| `deflate`                       | No                   | "deflate" compressed data inside the "zlib" data format     |
| `exi`                           | No                   | W3C Efficient XML Interchange                               |
| `gzip`                          | Yes (default)        | gzip file format                                            |
| `identity`                      | Yes                  | "No encoding" identifier: The response must not be encoded. |
| `pack200-gzip`                  | No                   | Network Transfer Format for Java Archives                   |
| `*`                             | Yes                  | Any available content encoding not explicitly requested     |

For more information, see the [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry).

The middleware allows you to add additional compression providers for custom `Accept-Encoding` header values. For more information, see [Custom Providers](#custom-providers) below.

The middleware is capable of reacting to quality value (qvalue, `q`) weighting when sent by the client to prioritize compression schemes. For more information, see [RFC 7231: Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4).

Compression algorithms are subject to a tradeoff between compression speed and the effectiveness of the compression. *Effectiveness* in this context refers to the size of the output after compression. The smallest size is achieved by the most *optimal* compression.

The headers involved in requesting, sending, caching, and receiving compressed content are described in the table below.

| Header             | Role |
| ------------------ | ---- |
| `Accept-Encoding`  | Sent from the client to the server to indicate the content encoding schemes acceptable to the client. |
| `Content-Encoding` | Sent from the server to the client to indicate the encoding of the content in the payload. |
| `Content-Length`   | When compression occurs, the `Content-Length` header is removed, since the body content changes when the response is compressed. |
| `Content-MD5`      | When compression occurs, the `Content-MD5` header is removed, since the body content has changed and the hash is no longer valid. |
| `Content-Type`     | Specifies the MIME type of the content. Every response should specify its `Content-Type`. The middleware checks this value to determine if the response should be compressed. The middleware specifies a set of [default MIME types](#mime-types) that it can encode, but you can replace or add MIME types. |
| `Vary`             | When sent by the server with a value of `Accept-Encoding` to clients and proxies, the `Vary` header indicates to the client or proxy that it should cache (vary) responses based on the value of the `Accept-Encoding` header of the request. The result of returning content with the `Vary: Accept-Encoding` header is that both compressed and uncompressed responses are cached separately. |

You can explore the features of the Response Compression Middleware with the [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/samples). The sample illustrates:
* The compression of app responses using gzip and custom compression providers.
* How to add a MIME type to the default list of MIME types for compression.

## Package
To include the middleware in your project, add a reference to the [`Microsoft.AspNetCore.ResponseCompression`](https://www.nuget.org/packages/Microsoft.AspNetCore.ResponseCompression/) package or use the [`Microsoft.AspNetCore.All`](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) package. This feature is available for apps that target ASP.NET Core 1.1 or later.

## Configuration
The following code shows how to enable the Response Compression Middleware with the with the default gzip compression and for default MIME types.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](response-compression/samples/2.x/StartupBasic.cs?name=snippet1&highlight=4,8)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](response-compression/samples/1.x/StartupBasic.cs?name=snippet1&highlight=3,8)]

---

> [!NOTE]
> Use a tool like [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/) to set the `Accept-Encoding` request header and study the response headers, size, and body.

Submit a request to the sample app without the `Accept-Encoding` header and observe that the response is uncompressed. The `Content-Encoding` and `Vary` headers aren't present on the response.

![Fiddler window showing result of a request without the Accept-Encoding header. The response is not compressed.](response-compression/_static/request-uncompressed.png)

Submit a request to the sample app with the `Accept-Encoding: gzip` header and observe that the response is compressed. The `Content-Encoding` and `Vary` headers are present on the response.

![Fiddler window showing result of a request with the Accept-Encoding header and a value of gzip. The Vary and Content-Encoding headers are added to the response. The response is compressed.](response-compression/_static/request-compressed.png)

## Providers
### GzipCompressionProvider
Use the `GzipCompressionProvider` to compress responses with gzip. This is the default compression provider if none are specified. You can set the compression level with the `GzipCompressionProviderOptions`. 

The gzip compression provider defaults to the fastest compression level (`CompressionLevel.Fastest`), which might not produce the most efficient compression. If the most efficient compression is desired, you can configure the middleware for optimal compression.

| Compression Level                | Description                                                                                                   |
| -------------------------------- | ------------------------------------------------------------------------------------------------------------- |
| `CompressionLevel.Fastest`       | Compression should complete as quickly as possible, even if the resulting output is not optimally compressed. |
| `CompressionLevel.NoCompression` | No compression should be performed.                                                                           |
| `CompressionLevel.Optimal`       | Responses should be optimally compressed, even if the compression takes more time to complete.                |


# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](response-compression/samples/2.x/Program.cs?name=snippet1&highlight=3,8-11)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](response-compression/samples/1.x/Startup.cs?name=snippet2&highlight=5,10-13)]

---

## MIME types
The middleware specifies a default set of MIME types for compression:
* `text/plain`
* `text/css`
* `application/javascript`
* `text/html`
* `application/xml`
* `text/xml`
* `application/json`
* `text/json`

You can replace or append MIME types with the Response Compression Middleware options. Note that wildcard MIME types, such as `text/*` aren't supported. The sample app adds a MIME type for `image/svg+xml` and compresses and serves the ASP.NET Core banner image (*banner.svg*).

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](response-compression/samples/2.x/Program.cs?name=snippet1&highlight=5)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](response-compression/samples/1.x/Startup.cs?name=snippet2&highlight=7)]

---

### Custom providers
You can create custom compression implementations with `ICompressionProvider`. The `EncodingName` represents the content encoding that this `ICompressionProvider` produces. The middleware uses this information to choose the provider based on the list specified in the `Accept-Encoding` header of the request.

Using the sample app, the client submits a request with the `Accept-Encoding: mycustomcompression` header. The middleware uses the custom compression implementation and returns the response with a `Content-Encoding: mycustomcompression` header. The client must be able to decompress the custom encoding in order for a custom compression implementation to work.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](response-compression/samples/2.x/Program.cs?name=snippet1&highlight=4)]

[!code-csharp[Main](response-compression/samples/2.x/CustomCompressionProvider.cs?name=snippet1)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](response-compression/samples/1.x/Startup.cs?name=snippet2&highlight=6)]

[!code-csharp[Main](response-compression/samples/1.x/CustomCompressionProvider.cs?name=snippet1)]

---

Submit a request to the sample app with the `Accept-Encoding: mycustomcompression` header and observe the response headers. The `Vary` and `Content-Encoding` headers are present on the response. The response body (not shown) isn't compressed by the sample. There isn't a compression implementation in the `CustomCompressionProvider` class of the sample. However, the sample shows where you would implement such a compression algorithm.

![Fiddler window showing result of a request with the Accept-Encoding header and a value of mycustomcompression. The Vary and Content-Encoding headers are added to the response.](response-compression/_static/request-custom-compression.png)

## Compression with secure protocol
Compressed responses over secure connections can be controlled with the `EnableForHttps` option, which is disabled by default. Using compression with dynamically generated pages can lead to security problems such as the [CRIME](https://wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://wikipedia.org/wiki/BREACH_(security_exploit)) attacks.

## Adding the Vary header
When compressing responses based on the `Accept-Encoding` header, there are potentially multiple compressed versions of the response and an uncompressed version. In order to instruct client and proxy caches that multiple versions exist and should be stored, the `Vary` header is added with an `Accept-Encoding` value. In ASP.NET Core 1.x, adding the `Vary` header to the response is accomplished manually. In ASP.NET Core 2.x, the middleware adds the `Vary` header automatically when the response is compressed.

**ASP.NET Core 1.x only**

[!code-csharp[Main](response-compression/samples/1.x/Startup.cs?name=snippet1)]

## Middlware issue when behind an Nginx reverse-proxy
When a request is proxied by Nginx, the `Accept-Encoding` header is removed. This prevents the middleware from compressing the response. For more information, see [NGINX: Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/). This issue is tracked by [Figure out pass-through compression for nginx (BasicMiddleware #123)](https://github.com/aspnet/BasicMiddleware/issues/123).

## Working with IIS dynamic compression
If you have an active IIS Dynamic Compression Module configured at the server level that you would like to disable for an app, you can do so with an addition to your *web.config* file. For more information, see [Disabling IIS modules](xref:hosting/iis-modules#disabling-iis-modules).

## Troubleshooting
Use a tool like [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/), which allow you to set the `Accept-Encoding` request header and study the response headers, size, and body. The Response Compression Middleware compresses responses that meet the following conditions:
* The `Accept-Encoding` header is present with a value of `gzip`, `*`, or custom encoding that matches a custom compression provider that you've established. The value must not be `identity` or have a quality value (qvalue, `q`) setting of 0 (zero).
* The MIME type (`Content-Type`) must be set and must match a MIME type configured on the `ResponseCompressionOptions`.
* The request must not include the `Content-Range` header.
* The request must use insecure protocol (http), unless secure protocol (https) is configured in the Response Compression Middleware options. *Note the danger [described above](#compression-with-secure-protocol) when enabling secure content compression.*

## Additional resources
* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware)
* [Mozilla Developer Network: Accept-Encoding](https://developer.mozilla.org/docs/Web/HTTP/Headers/Accept-Encoding)
* [RFC 7231 Section 3.1.2.1: Content Codings](https://tools.ietf.org/html/rfc7231#section-3.1.2.1)
* [RFC 7230 Section 4.2.3: Gzip Coding](https://tools.ietf.org/html/rfc7230#section-4.2.3)
* [GZIP file format specification version 4.3](http://www.ietf.org/rfc/rfc1952.txt)
