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

## Introduction
Response compression definition and purpose

What to compress
Compress non-natively compressed files (e.g., HTML)
Don't compress natively compressed files (e.g., PNG)

Content Coding (`br`, `compress`, `deflate`, `exi`, `gzip`, `identity`, `pack200-gzip`, `*`, custom coding) & qvalue weights [Note: These will likely be in a table. I plan to denote the ones that the middleware supports OOB: `gzip`, `identity`, `*`, and custom coding.]

Compression level: tradeoff between speed and compression

Describe (*not in great detail*) the role of headers relevant to RC: `Accept-Encoding`, `Content-Type`, `Content-Encoding`, `Vary: Accept-Encoding`

## Response Compression Middleware
Link `FullSample` (explicitly sets GZip and Custom providers & adds a MimeType)

### When to use Response Compression Middleware
Not behind IIS/NGINX/Apache
How to disable IIS compression with `web.config`
```xml
<configuration>
  <system.webServer>
    <urlCompression doDynamicCompression="false"/>
  </system.webServer>
</configuration>
```
or 
```xml
<configuration>
  <system.webServer> 
    <modules> 
      <remove name="DynamicCompressionModule" /> 
    </modules> 
  </system.webServer> 
</configuration>
```

### Compression occurs based on
`Accept-Encoding` header (`gzip`, `*`, or custom coding; not `identity`; q!=0)
MimeType (`Content-Type`) set & matches RC options configuration (or defaults)
No `Content-Range` header on request
Not HTTPS (unless configured in RC options)
Not if provider isn't flushable (e.g., .NET Framework 4.5.1 GZipStream) Team member should confirm and elaborate.

### Package
`Microsoft.AspNetCore.ResponseCompression`

### Service configuration
#### `Providers` (`CompressionProviderCollection`)
* GzipCompressionProvider` (default)<br>`GzipCompressionProviderOptions`: `Level`: `CompressionLevel.Fastest` (default), `CompressionLevel.Optimal`, `CompressionLevel.NoCompression`
* CustomCompressionProvider`
#### `MimeTypes` (`IEnumerable<string>`)
`ResponseCompressionDefaults.MimeTypes`: `text/plain`, `text/css`, `application/javascript`, `text/html`, `application/xml`, `text/xml`, `application/json`, `text/json`
#### Wildcards not supported
#### `EnableForHttps` (`bool`) `false` (default) or `true`<br>Advise against enabling for HTTPS if app is public-facing. [CRIME](https://en.wikipedia.org/wiki/CRIME) + review by [@]blowdart :dart:
### Configuration
`UseResponseCompression()`

Location of RC middleware relative to terminal middlewares is important

### Add `Vary: Accept-Encoding` header manually (https://github.com/aspnet/BasicMiddleware/issues/187)
  
## Additional Resources
  * [Application Startup](xref:fundamentals/startup)
  * [Middleware](xref:fundamentals/middleware)
  * [Apache Module mod_deflate](http://httpd.apache.org/docs/current/mod/mod_deflate.html)
  * [NGINX Compression and Decompression](https://www.nginx.com/resources/admin-guide/compression-and-decompression/)
  * [IIS HTTP Compression `<httpCompression>`](https://www.iis.net/configreference/system.webserver/httpcompression)
  * [Mozilla Developer Network: Accept-Encoding](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Accept-Encoding)
  * [IANA Official Content Coding List](http://www.iana.org/assignments/http-parameters/http-parameters.xml#http-content-coding-registry)
