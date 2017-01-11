---
title: Response Compression Middleware | Microsoft Docs
author: guardrex
description: An introduction to response compression with instructions on how to use Response Compression Middleware in ASP.NET Core applications.
keywords: ASP.NET Core, performance, response compression, gzip, middleware
ms.author: riande
manager: wpickett
ms.date: 1/8/2017
ms.topic: article
ms.assetid: de621887-c5c9-4ac8-9efd-f5cc0457a134
ms.technology: aspnet
ms.prod: aspnet-core
uid: performance/response-compression
---
# Response Compression Middleware

By [Luke Latham](https://github.com/GuardRex)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample/FullSample)

Everyone enjoys interacting with responsive web applications. To make your applications as fast as possible, you should reduce response payload sizes as much as possible. One way to reduce payload sizes is to compress your applications' responses. When you cannot use response compression technology built into a server hosting an ASP.NET Core application, you can use Response Compression Middleware.

Usually, any response not natively compressed can benefit from response compression. Files and responses not usually natively compressed include: CSS, JavaScript, HTML, XML, and JSON. You shouldn't compress natively compressed assets, such as PNG files, which are already compressed.

When requesting and returning compressed content, the client must inform the server of its capability to decompress content, and the server must include information on how the response is encoded. The standard content coding designations are shown below showing which ones are supported by Response Caching Middleware.

Content Coding | Supported | Description
| :---: | :---: | ---
`br` |  No | Brotli Compressed Data Format
`compress` | No | UNIX "compress" data format
`deflate` |  No | "deflate" compressed data inside the "zlib" data format 
`exi` | No | W3C Efficient XML Interchange
`gzip` | Yes (default) | GZip file format
`identity` | Yes | "No encoding" identifier: The response must not be encoded.
`pack200-gzip` | No | Network Transfer Format for Java Archives
`*` | Yes | Any available content coding not explicitly requested
custom | Yes | Developer provides the compression implementation. The client must be able to decompress the payload.

For more information, see the [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry).

The middleware is capable of reacting to quality weighting (`qvalue`) factors when sent by the client. For more information, see [RFC 7231: Accept-Encoding](https://tools.ietf.org/html/rfc7231#section-5.3.4).

Compression algorithms usually have a tradeoff between the speed that they can compress a response and the effectiveness of their compression. The middleware defaults to the fastest compression level, which might not produce the most efficient compression. If the most efficient compression is desired, the middleware can be configured for optimal compression.

The headers involved in requesting, sending, caching, and receiving compressed content are described below.

Header | Role
--- | ---
`Accept-Encoding` | Sent by the client to the server to indicate which types of content encoding are acceptable.
`Content-Type` | Specifies the MIME type of the content. Since only configured MIME types are configured on the server for encoding, this information is used by the server to determine if a response can be compressed. The middleware includes a set of default MIME types that it will encode, but you can replace or add MIME types for compressioni see.
`Content-Encoding` | Sent by the server to the client to indicate the encoding of the content in the payload.
`Vary: Accept-Encoding` | Sent by the server to clients and proxys to indicate that they should cache responses based on the `Accept-Encoding` header of the request. The result of returning content with this header is that both compressed and uncompressed responses will be cached.

## Response compression sample application
You can explore the features of the Response Compression Middleware with the [response compression sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample/FullSample). The sample illustrates the compression of application responses using GZip and custom compression providers.

## When to use Response Compression Middleware
Use Response Compression Middleware when you are unable to use the [Dynamic Compression module](https://www.iis.net/overview/reliability/dynamiccachingandcompression) in IIS on Windows Server, the [Apache mod_deflate module]() on Apache Server, [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/), or your application is hosted on [WebListener server](xref:fundamentals/servers/weblistener). The main reasons to use the server-based response compression technologies in IIS, Apache, or Nginx is that the performance of the middleware probably won't match that of the modules. 

## Package
To include the middleware in your project, add a reference to the `Microsoft.AspNetCore.ResponseCompression` package. The middleware is available for projects that target .NETFramework 4.5.1 or .NETStandard 1.3 or higher.

## Configuration
### Using defaults
if you plan to implement the middleware with default GZip compression and for default MIME types (see below), you can add the middleware to your service collection and processing pipeline.

[!code-csharp[Main](response-compression/sample/DefaultsSample/Startup.cs?name=snippet1&highlight=19,24)]

### Providers
Use the `GzipCompressionProvider` to compress responses with GZip. This is the default compression provider if none are specified. 

[!code-csharp[Main](response-compression/sample/FullSample/Startup.cs?name=snippet2&highlight=27)]

You can set the compression level with the `GzipCompressionProviderOptions`.

`Level` | Description
--- | ---
`CompressionLevel.Fastest` (default) | Compression should complete as quickly as possible, even if the resulting output is not optimally compressed.
`CompressionLevel.NoCompression` | No compression should be performed.
`CompressionLevel.Optimal` | Responses should be optimally compressed, even if the operation takes a longer time to complete.

[!code-csharp[Main](response-compression/sample/FullSample/Startup.cs?name=snippet2&highlight=31-34)]

You can create a custom compression implementation with `ICompressionProvider`. The `encodingName` will reflect the `Accept-Encoding` header value that triggers the `CreateStream()` method.

[!code-csharp[Main](response-compression/sample/FullSample/Startup.cs?name=snippet2&highlight=28)]

[!code-csharp[Main](response-compression/sample/FullSample/CustomCompressionProvider.cs?name=snippet1)]

### MimeTypes
The middleware includes a default set of MIME types for compression:
* `text/plain`
* `text/css`
* `application/javascript`
* `text/html`
* `application/xml`
* `text/xml`
* `application/json`
* `text/json`
You can replace or append MIME types with the Response Compression Middleware options. Note that wildcard MIME types, such as `text/*` are not supported.

[!code-csharp[Main](response-compression/sample/FullSample/Startup.cs?name=snippet2&highlight=29)]

### Compression with secure protocol
Compressed responses over secure protocols can be controlled via the `EnableForHttps` option; however, it's unsafe, not recommended, and disabled by default. For more information, see [CRIME: Information Leakage Attack against SSL/TLS](https://blog.qualys.com/ssllabs/2012/09/14/crime-information-leakage-attack-against-ssltls)

## Middleware ordering
The position of this middleware relative to other middleware in the pipeline is important. Any terminal middleware placed before this middleware will prevent the Response Compression Middleware from compressing the response. For example, if you place Static File Middleware before this middleware, your static files will not be compressed by the middleware. If you place Static File Middleware after this middleware, your static files will be compressed.

## Adding the Vary header
When compressing responses based on the `Accept-Encoding` header, there are potentially two versions of the response: a compressed version and an uncompressed version. In order to instruct client and proxy caches that both versions exist and should be stored, you should always supply a `Vary` header with an `Accept-Encoding` value. This will result in storage of both versions of the response on client and proxy caches. The sample application accomplishes this with a method; however, the middleware will be upgraded soon to provide this feature ([Basic Middleware #187](https://github.com/aspnet/BasicMiddleware/issues/187)).

[!code-csharp[Main](response-compression/sample/FullSample/Startup.cs?name=snippet1)]

## Disabling or removing IIS Dynamic Compression
If you have an active IIS Dynamic Compression Module configured at the server level that you would like to disable for an application, you can do so with an addition to your **web.config** file. Either leave the module in place and deactivate it for dymanic compression or remove the module from the application. To merely deactivate the module for dynamic compression, add a `<urlCompression>` element to your **web.config** file.
```xml
<configuration>
  <system.webServer>
    <urlCompression doDynamicCompression="false"/>
  </system.webServer>
</configuration>
```
If you opt to remove the module via **web.config**, you must unlock it first. Click on the IIS server in the IIS Manager **Connections** sidebar. Open the **Modules**. Click on the **DynamicCompressionModule** in the list. In the **Action** panel on the right, click **Unlock**. At this point, you will be able to add the following to your **web.config** file to remove the module for the application. Doing this won't affect the module's use in other applications on the server.
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
Use a tool like [Fiddler](http://www.telerik.com/fiddler), [Firebug](http://getfirebug.com/), or [Postman](https://www.getpostman.com/), all of which allow you to explicitly set the `Accept-Encoding` request header and study the response headers, size, and body. The Response Compression Middleware will compress responses that meet the following conditions:
* The `Accept-Encoding` header is present with a value of `gzip`, `*`, or custom coding that matches a custom compression provider that you've established. The value must not be `identity` or have a quality (qvalue) setting of 0 (zero).
* The MIME type (`Content-Type`) must be set and must match the Response Caching Middleware options configuration.
* The request must not include the `Content-Range` header.
* The request must use insecure protocol, unless secure protocol is configured in the Response Compression Middleware options.
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
  * [RFC 7231 Section 3.1.2.1: Content Coding](https://tools.ietf.org/html/rfc7231#section-3.1.2.1)
  * [RFC 7230 Section 4.2.3: Gzip Coding](https://tools.ietf.org/html/rfc7230#section-4.2.3)
  * [GZIP file format specification version 4.3](http://www.ietf.org/rfc/rfc1952.txt)
