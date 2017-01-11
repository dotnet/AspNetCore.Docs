---
title: Response Compression | Microsoft Docs
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
# Response Compression

By [Luke Latham](https://github.com/GuardRex)

[View or download sample code (Full Sample)](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample/FullSample)

Response compression definition and purpose

What to compress
Compress non-natively compressed files (e.g., HTML)
Don't compress natively compressed files (e.g., PNG)

Content Coding (`br`, `compress`, `deflate`, `exi`, `gzip`, `identity`, `pack200-gzip`, `*`, custom coding) & qvalue weights [Note: These will likely be in a table. I plan to denote the ones that the middleware supports OOB: `gzip`, `identity`, `*`, and custom coding.]

Compression level: tradeoff between speed and compression

Describe (*not in great detail*) the role of headers relevant to RC: `Accept-Encoding`, `Content-Type`, `Content-Encoding`, `Vary: Accept-Encoding`

## Response compression sample application
You can explore the features of the Response Compression Middleware with the [response compression sample application](https://github.com/aspnet/Docs/tree/master/aspnetcore/performance/response-compression/sample/FullSample). The sample illustrates the compression of application responses using GZip and custom compression providers.

## When to use Response Compression Middleware
Use Response Compression Middleware when you are unable to use the [Dynamic Compression module](https://www.iis.net/overview/reliability/dynamiccachingandcompression) in IIS on Windows Server, the [Apache mod_deflate module]() on Apache Server, [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/), or your application is hosted on [WebListener server](xref:fundamentals/servers/weblistener). The main reasons to use the server-based response compression technologies in IIS, Apache, or Nginx is that the performance of the middleware probably won't match that of the modules. 

## Response compression conditions
The Response Compression Middleware will compress responses that meet the following conditions:
* The `Accept-Encoding` header is present with a value of `gzip`, `*`, or custom coding that matches a custom compression provider that you've established. The value must not be `identity` or have a quality (qvalue) setting of 0 (zero).
* The MIME type (`Content-Type`) must be set and must match the Response Caching Middleware options configuration.
* The request must not include the `Content-Range` header.
* The request must use insecure protocol, unless secure protocol is configured in the Response Compression Middleware options.
* The provider must be flushable. For example, `GZipStream` on .NET Framework 4.5.1, which isn't flushable, is not in use.

## Package
To include the middleware in your project, add a reference to the `Microsoft.AspNetCore.ResponseCompression` package. The middleware is available for projects that target .NETFramework 4.5.1 or .NETStandard 1.3 or higher.

## Service configuration
### Providers
Use the `GzipCompressionProvider` to compress responses with GZip. This is the default compression provider if none are specified. You can set the compression level with the `GzipCompressionProviderOptions`

`Level` | 
--- | ---
`CompressionLevel.Fastest` (default) | Compression should complete as quickly as possible, even if the resulting output is not optimally compressed.
`CompressionLevel.NoCompression` | No compression should be performed.
`CompressionLevel.Optimal` | Responses should be optimally compressed, even if the operation takes a longer time to complete.

Use an instance of the `ICompressionProvider` for your custom compression providers.

### MimeTypes
`ResponseCompressionDefaults.MimeTypes`: `text/plain`, `text/css`, `application/javascript`, `text/html`, `application/xml`, `text/xml`, `application/json`, `text/json`
### Wildcards not supported
### `EnableForHttps` (`bool`) `false` (default) or `true`<br>Advise against enabling for HTTPS if app is public-facing. [CRIME](https://en.wikipedia.org/wiki/CRIME) + review by [@]blowdart :dart:
## Configuration
`UseResponseCompression()`

Location of RC middleware relative to terminal middlewares is important

## Add `Vary: Accept-Encoding` header manually (https://github.com/aspnet/BasicMiddleware/issues/187)

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
  
## Additional Resources
  * [Application Startup](xref:fundamentals/startup)
  * [Middleware](xref:fundamentals/middleware)
  * [Apache Module mod_deflate](http://httpd.apache.org/docs/current/mod/mod_deflate.html)
  * [IIS HTTP Compression `<httpCompression>`](https://www.iis.net/configreference/system.webserver/httpcompression)
  * [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/)
  * [Mozilla Developer Network: Accept-Encoding](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Encoding)
  * [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry)
