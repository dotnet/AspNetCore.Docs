---
title: Response Compression Middleware | Microsoft Docs
author: guardrex
description: An introduction to response compression with instructions on how to use Response Compression Middleware in ASP.NET Core applications.
keywords: ASP.NET Core, performance, response compression, gzip, accept-encoding, middleware
ms.author: riande
manager: wpickett
ms.date: 1/12/2017
ms.topic: article
ms.assetid: de621887-c5c9-4ac8-9efd-f5cc0457a134
ms.technology: aspnet
ms.prod: aspnet-core
uid: performance/response-compression
---
# Response Compression Middleware

By [Luke Latham](https://github.com/GuardRex)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample)

This document introduces response compression and explains how to use ASP.NET Core Response Compression Middleware. A response compression sample application demonstrates the middleware and response compression concepts.

## Response Compression
The time it takes to send content over a network, especially the Internet, is often the largest share of the total time it takes to satisfy a client's request. The transmission time frequently exceeds the processing time taken on the client and the server. If you can reduce response payload sizes and thus send less data to clients, you can usually increase the responsiveness of your application, sometimes dramatically. One way to reduce payload sizes is to compress an application's responses. Servers, such as Windows Server, Apache, and Nginx, offer response compression features. When you cannot use a server-based compression technology, you can use ASP.NET Core Response Compression Middleware to compress responses.

Usually, any response not natively compressed can benefit from response compression. Responses not natively compressed typically include: CSS, JavaScript, HTML, XML, and JSON. You shouldn't compress natively compressed assets, such as PNG files, which are already compressed. If you attempt to further compress a natively compressed response, any small additional reduction in size and transmission time will likely be overshadowed by the time it took to process the compression.

When a client can process compressed content, the client must inform the server of its capabilities by sending the `Accept-Encoding` header with the request. When a server sends compressed content, it must include information in the `Content-Encoding` header on how the compressed response is encoded. Content encoding designations are shown below indicating which ones are supported by the middleware.

Content Encoding | Supported | Description
:---: | :---: | ---
`br` |  No | Brotli Compressed Data Format
`compress` | No | UNIX "compress" data format
custom | Yes | Developer provides the compression implementation. The client must be able to decompress the payload.
`deflate` |  No | "deflate" compressed data inside the "zlib" data format 
`exi` | No | W3C Efficient XML Interchange
`gzip` | Yes (default) | GZip file format
`identity` | Yes | "No encoding" identifier: The response must not be encoded.
`pack200-gzip` | No | Network Transfer Format for Java Archives
`*` | Yes | Any available content encoding not explicitly requested

For more information, see the [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry).

The middleware is capable of reacting to quality value (qvalue, `q`) weighting when sent by the client. For more information, see [RFC 7231: Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4).

Most compression algorithms are subject to a tradeoff between compression speed and the effectiveness of the compression. *Effectiveness* in this context means the smallest possible size, which is also referred to as the most *optimal* compression. The middleware defaults to the fastest compression level, which might not produce the most efficient compression. If the most efficient compression is desired, the middleware can be configured for optimal compression.

The headers involved in requesting, sending, caching, and receiving compressed content are described below.

Header | Role
--- | ---
`Accept-Encoding` | Sent by the client to the server to indicate which types of content encoding are acceptable.
`Content-Encoding` | Sent from the server to the client to indicate the encoding of the content in the payload.
`Content-Length` | When compression occurs, the the `Content-Length` header is removed, since the body content changes when the response is compressed.
`Content-MD5` | When compression occurs, the `Content-MD5` header is removed, since the body content has changed and the hash is no longer valid.
`Content-Type` | Specifies the MIME type of the content. MIME types are specified on the server for encodable content, so this information is used by the server to determine if a response can be compressed. The middleware includes a set of [default MIME types](#mime-types) that it will encode, but you can replace or add MIME types.
`Vary` | When sent by the server with a value of `Accept-Encoding` to clients and proxies, it indicates that they should cache (vary) responses based on the value of the `Accept-Encoding` header of the request. The result of returning content with the `Vary: Accept-Encoding` header is that both compressed and uncompressed responses will be cached separately.

## When to use Response Compression Middleware
Use Response Compression Middleware when you're unable to use the [Dynamic Compression module](https://www.iis.net/overview/reliability/dynamiccachingandcompression) in IIS on Windows Server, the [Apache mod_deflate module](http://httpd.apache.org/docs/current/mod/mod_deflate.html), [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/), or your application is hosted on [WebListener server](xref:fundamentals/servers/weblistener). The main reason to use the server-based response compression technologies in IIS, Apache, or Nginx is that the performance of the middleware probably won't match that of the server modules. 

## Package
To include the middleware in your project, add a reference to the `Microsoft.AspNetCore.ResponseCompression` package. The middleware is available for projects that target .NET Framework 4.5.1 or .NET Standard 1.3 or higher.

## Configuration
You can explore the features of the Response Compression Middleware with the [response compression sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample). The sample illustrates the compression of application responses using GZip and custom compression providers. It also shows you how to add a MIME type to the default list of MIME types for compression.

### Using defaults
If you plan to implement the middleware with default GZip compression and for default MIME types, you can add the middleware to your service collection and processing pipeline. No additional configuration is required. 

[!code-csharp[Main](response-compression/sample/StartupBasic.cs?name=snippet1&highlight=3,8)]

Submit a request to the sample application without the `Accept-Encoding` header and observe that the response is uncompressed. The `Content-Encoding` and `Vary` headers are not present on the response.

![Fiddler window showing result of a request without the Accept-Encoding header. The response is not compressed.](response-compression/_static/request-uncompressed.png)

Submit a request to the sample application with the `Accept-Encoding: gzip` header and observe that the response is compressed. The `Content-Encoding` and `Vary` headers are present on the response.

![Fiddler window showing result of a request with the Accept-Encoding header and a value of gzip. The Vary and Content-Encoding headers are added to the response. The response is compressed.](response-compression/_static/request-compressed.png)

### Providers
#### GzipCompressionProvider
Use the `GzipCompressionProvider` to compress responses with GZip. This is the default compression provider if none are specified. You can set the compression level with the `GzipCompressionProviderOptions`. The default is for the fastest compression.

Compression Level | Description
--- | ---
`CompressionLevel.Fastest` (default) | Compression should complete as quickly as possible, even if the resulting output is not optimally compressed.
`CompressionLevel.NoCompression` | No compression should be performed.
`CompressionLevel.Optimal` | Responses should be optimally compressed, even if the compression takes more time to complete.

[!code-csharp[Main](response-compression/sample/Startup.cs?name=snippet2&highlight=5,9-12)]

#### Custom Providers
You can create custom compression implementations with `ICompressionProvider`. The `EncodingName` represents the content encoding that this `ICompressionProvider` produces. The middleware will use this information to choose the provider based on the list specified in the `Accept-Encoding` header of the request.

Using the sample application, the client would submit a request with the `Accept-Encoding: custom` header. The middleware will use the custom compression implementation and return the response with a `Content-Encoding: custom` header. The client must be able to decompress the custom encoding in order for a custom compression implementation to work.

[!code-csharp[Main](response-compression/sample/Startup.cs?name=snippet2&highlight=6)]

[!code-csharp[Main](response-compression/sample/CustomCompressionProvider.cs?name=snippet1)]

Submit a request to the sample application with the `Accept-Encoding: custom` header and observe the response headers. The `Vary` and `Content-Encoding` headers are present on the response. The response body (not shown) isn't compressed by the sample, as there is no compression implementation in the `CustomCompressionProvider` class of the sample. However, the sample shows where you would implement such a compression algorithm.

![Fiddler window showing result of a request with the Accept-Encoding header and a value of custom. The Vary and Content-Encoding headers are added to the response.](response-compression/_static/request-custom-compression.png)

### MIME types
The middleware specifies a default set of MIME types for compression:
* `text/plain`
* `text/css`
* `application/javascript`
* `text/html`
* `application/xml`
* `text/xml`
* `application/json`
* `text/json`

You can replace or append MIME types with the Response Compression Middleware options. Note that wildcard MIME types, such as `text/*` are not supported. The sample application adds a MIME type for `image/svg+xml` and will compress and serve the ASP.NET Core banner image (*banner.svg*).

[!code-csharp[Main](response-compression/sample/Startup.cs?name=snippet2&highlight=7)]

### Compression with secure protocol
Compressed responses over secure connections can be controlled with the `EnableForHttps` option, which is disabled by default. Using compression with dynamically generated pages can lead to security problems such as the [CRIME](https://en.wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://en.wikipedia.org/wiki/BREACH_(security_exploit)) attacks.

## Adding the Vary header
When compressing responses based on the `Accept-Encoding` header, there are potentially multiple compressed versions of the response and an uncompressed version. In order to instruct client and proxy caches that multiple versions exist and should be stored, you should always supply a `Vary` header with an `Accept-Encoding` value. The sample application adds a `Vary` header using a method; however, the middleware will be upgraded soon to provide this feature ([Basic Middleware #187](https://github.com/aspnet/BasicMiddleware/issues/187)).

[!code-csharp[Main](response-compression/sample/Startup.cs?name=snippet1)]

## Disabling or removing IIS Dynamic Compression
If you have an active IIS Dynamic Compression Module configured at the server level that you would like to disable for an application, you can do so with an addition to your *web.config* file. Either leave the module in place and deactivate it for dynamic compression or remove the module from the application.

To merely deactivate dynamic compression module, add a `<urlCompression>` element to your *web.config* file. There is no need to include an attribute and value for `doStaticCompression="false"`, since the IIS Static Compression Module doesn't work with ASP.NET Core applications in a reverse-proxy setup.
```xml
<configuration>
  <system.webServer>
    <urlCompression doDynamicCompression="false"/>
  </system.webServer>
</configuration>
```
If you opt to remove the module via *web.config*, you must unlock it first. Click on the IIS server in the IIS Manager **Connections** sidebar. Open the **Modules** in the IIS area. Click on the **DynamicCompressionModule** in the list. In the **Action** panel on the right, click **Unlock**. At this point, you will be able to add the section shown below to your *web.config* file to remove the module from the application. Doing this won't affect your use of the module in other applications on the server.
```xml
<configuration>
  <system.webServer> 
    <modules> 
      <remove name="DynamicCompressionModule" /> 
    </modules> 
  </system.webServer> 
</configuration>
```

## Troubleshooting
Use a tool like [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/), all of which allow you to set the `Accept-Encoding` request header and study the response headers, size, and body. The Response Compression Middleware will compress responses that meet the following conditions:
* The `Accept-Encoding` header is present with a value of `gzip`, `*`, or custom encoding that matches a custom compression provider that you've established. The value must not be `identity` or have a quality value (qvalue, `q`) setting of 0 (zero).
* The MIME type (`Content-Type`) must be set and must match a MIME type configured on the ResponseCompressionOptions.
* The request must not include the `Content-Range` header.
* The request must use *insecure protocol*, unless secure protocol is configured in the Response Compression Middleware options. *Note the danger [described above](#compression-with-secure-protocol) when enabling secure content compression.*
* The provider must not use `GZipStream` on .NET Framework 4.5.1, which isn't flushable.

## Additional Resources
* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware)
* [Apache Module mod_deflate](http://httpd.apache.org/docs/current/mod/mod_deflate.html)
* [IIS HTTP Compression `<httpCompression>`](https://www.iis.net/configreference/system.webserver/httpcompression)
* [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/)
* [Mozilla Developer Network: Accept-Encoding](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Encoding)
* [RFC 7231: Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4)
* [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry)
* [RFC 7231 Section 3.1.2.1: Content Codings](https://tools.ietf.org/html/rfc7231#section-3.1.2.1)
* [RFC 7230 Section 4.2.3: Gzip Coding](https://tools.ietf.org/html/rfc7230#section-4.2.3)
* [GZIP file format specification version 4.3](http://www.ietf.org/rfc/rfc1952.txt)
