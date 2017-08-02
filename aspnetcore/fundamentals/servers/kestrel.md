---
title: Kestrel web server implementation in ASP.NET Core
author: tdykstra
description: Introduces Kestrel, the cross-platform web server for ASP.NET Core based on libuv.
keywords: ASP.NET Core, Kestrel, libuv, url prefixes
ms.author: tdykstra
manager: wpickett
ms.date: 10/27/2016
ms.topic: article
ms.assetid: 560bd66f-7dd0-4e68-b5fb-f31477e4b785
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/servers/kestrel
ms.custom: H1Hack27Feb2017
---
# Introduction to Kestrel web server implementation in ASP.NET Core

By [Tom Dykstra](http://github.com/tdykstra), [Chris Ross](https://github.com/Tratcher), and [Stephen Halter](https://twitter.com/halter73)

Kestrel is a cross-platform [web server for ASP.NET Core](index.md) based on [libuv](https://github.com/libuv/libuv), a cross-platform asynchronous I/O library. Kestrel is the web server that is included by default in ASP.NET Core project templates. 

Kestrel supports the following features:

  * HTTPS
  * Opaque upgrade used to enable [WebSockets](https://github.com/aspnet/websockets)
  * Unix sockets for high performance behind Nginx 

Kestrel is supported on all platforms and versions that .NET Core supports.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample2)

---

## When to use Kestrel with a reverse proxy

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

If your application accepts requests only from an internal network, you can use Kestrel by itself.

![Kestrel to internal network](kestrel/_static/kestrel-to-internal.png)

If you expose your application to the Internet, you must use IIS, Nginx, or Apache as a *reverse proxy server*. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.

![Kestrel to Internet with reverse proxy](kestrel/_static/kestrel-to-internet.png)

Another scenario that requires a reverse proxy is when you have multiple applications that share the same port running on a single server. That doesn't work with Kestrel directly because Kestrel doesn't support sharing a port between multiple processes. When you configure Kestrel to listen on a port, it handles all traffic for that port regardless of host header. A reverse proxy that can share ports must then forward to Kestrel on a unique port.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

You can use Kestrel by itself or with a *reverse proxy server*, such as IIS, Nginx, or Apache. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.

![Kestrel without reverse proxy](kestrel/_static/kestrel-to-internal.png)

![Kestrel to Internet with reverse proxy](kestrel/_static/kestrel-to-internet.png)

A scenario that requires a reverse proxy is when you have multiple applications that share the same port running on a single server. That doesn't work with Kestrel directly because Kestrel doesn't support sharing a port between multiple processes. When you configure Kestrel to listen on a port, it handles all traffic for that port regardless of host header. A reverse proxy that can share ports must then forward to Kestrel on a unique port.

---

Even if a reverse proxy server isn't required, using one can simplify load balancing and SSL set-up -- only your reverse proxy server requires an SSL certificate, and that server can communicate with your application servers on the internal network using plain HTTP.

## How to use Kestrel in ASP.NET Core apps

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Install the [Microsoft.AspNetCore.Server.Kestrel](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.Kestrel/) NuGet package.

Call the [`UseKestrel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.webhostbuilderkestrelextensions#Microsoft_AspNetCore_Hosting_WebHostBuilderKestrelExtensions_UseKestrel_Microsoft_AspNetCore_Hosting_IWebHostBuilder_) extension method on `WebHostBuilder` in your `Main` method, specifying any [Kestrel options](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.server.kestrel.kestrelserveroptions) that you need, as shown in the next section.

[!code-csharp[](kestrel/sample/Program.cs?name=snippet_Main&highlight=13-19)]

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

ASP.NET Core project templates use Kestrel by default. 

The [Microsoft.AspNetCore.Server.Kestrel](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.Kestrel/) package is included in the [ASP.NET Core metapackage](xref:metapackage).

The `CreateDefaultBuilder` method calls the [`UseKestrel`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.webhostbuilderkestrelextensions#Microsoft_AspNetCore_Hosting_WebHostBuilderKestrelExtensions_UseKestrel_Microsoft_AspNetCore_Hosting_IWebHostBuilder_) extension method behind the scenes.

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_DefaultBuilder&highlight=7)]

To configure Kestrel settings, use the [KestrelServerOptions](https://github.com/aspnet/KestrelHttpServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.Kestrel.Core/KestrelServerOptions.cs) class. If you use `CreateDefaultBuilder`, you can configure options in *Startup.cs* in the `ConfigureServices` method:

[!code-csharp[](kestrel/sample2/Startup.cs?name=snippet_KestrelOptions&highlight=3-4)]

If you don't use `CreateDefaultBuilder`, you can configure options in *Program.cs* when you call `UseKestrel`:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Main&highlight=13-20)]

---

### Kestrel options

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

For information about Kestrel options, see [KestrelServerOptions class](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.server.kestrel.kestrelserveroptions).

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

The Kestrel web server has constraint configuration options that are especially useful in Internet-facing deployments. Here are some of the limits you can set:

- Maximum client connections
- Maximum request body size
- Minimum request body data rate

You set these constraints and others in the The `Limits` property of the [KestrelServerOptions](https://github.com/aspnet/KestrelHttpServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.Kestrel.Core/KestrelServerOptions.cs) class. The `Limits` property holds an instance of the [KestrelServerLimits](https://github.com/aspnet/KestrelHttpServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.Kestrel.Core/KestrelServerLimits.cs) class. 

**Maximum client connections**

The maximum number of concurrent open HTTP/S connections can be set for the entire application with the following code:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Limits&highlight=3-4)]

There is a separate limit for connections that have been upgraded from HTTP to another protocol (for example, on a WebSockets request).  After a connection is upgraded, it’s not counted against the `MaxConcurrentConnections` limit anymore.

**Maximum request body size**

The default maximum request body size is 30,000,000 bytes, which is approximately 28.6MB. To configure the constraint for the entire application:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Limits&highlight=5)]

This will affect every request.  The recommended way to override the limit in an ASP.NET Core MVC app is to use the [RequestSizeLimit](https://github.com/aspnet/Mvc/blob/rel/2.0.0/src/Microsoft.AspNetCore.Mvc.Core/RequestSizeLimitAttribute.cs) attribute on an action method.

You can also override the setting on a specific request as shown here:

[!code-csharp[](kestrel/sample2/Startup.cs?name=snippet_Limits&highlight=3-4)]
 
You can only configure the limit on a request if the application hasn’t started reading yet; otherwise an exception is thrown. There’s an `IsReadOnly` property that tells you if the request body is in read-only state, meaning it’s too late to configure the limit.

**Minimum request body data rate**

To configure a default minimum request rate:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Limits&highlight=6-7)]

To configure per request:

[!code-csharp[](kestrel/sample2/Startup.cs?name=snippet_Limits&highlight=5-6)]

Kestrel checks every second if data is coming in at the specified rate in bytes/second. If the rate drops below the minimum, the connection is timed out. The grace period is the amount of time that Kestrel gives the client to get its send rate up to the minimum; the rate is not checked during that time. The grace period is to avoid dropping connections that are initially sending data at a slow rate due to TCP slow-start.

For information about other Kestrel options, see [KestrelServerOptions](https://github.com/aspnet/KestrelHttpServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.Kestrel.Core/KestrelServerOptions.cs) and [KestrelServerLimits](https://github.com/aspnet/KestrelHttpServer/blob/rel/2.0.0/src/Microsoft.AspNetCore.Server.Kestrel.Core/KestrelServerLimits.cs). 

---

### Endpoint configuration

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

By default ASP.NET Core binds to `http://localhost:5000`. You can configure URL prefixes and ports for Kestrel to listen on by using the `UseUrls` extension method, the `urls` command-line argument, or the ASP.NET Core configuration system. For more information about these methods, see [Hosting](../../fundamentals/hosting.md). For information about how URL binding works when you use IIS as a reverse proxy, see [ASP.NET Core Module](aspnet-core-module.md). 

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

By default ASP.NET Core binds to `http://localhost:5000`. You configure URL prefixes and ports for Kestrel to listen on by using extension methods on `KestrelServerOptions`.

**Bind to a TCP socket**

The `Listen` method binds to a TCP socket, and an options lambda lets you configure an SSL certificate:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Main&highlight=13-20)]

**Bind to a Unix socket**

You can listen on a Unix socket for improved performance with Nginx:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_UnixSocket)]

**Bind to a file descriptor**

You can bind to a file descriptor:

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_FileDescriptor)]

If you need to bind to a file descriptor and you use systemd socket activation, call the `UseSystemd` extension method to get file descriptor information from environment variables. This method no-ops if the requisite environment variable has not been set.

[!code-csharp[](kestrel/sample2/Program.cs?name=snippet_Systemd)]

**UseUrls method**

You can also configure endpoints by using the `UseUrls` method or the  `urls` command-line argument. These methods are useful if you want code that works also with servers other than Kestrel. However, you can't use SSL with these methods.

If you use both the `Listen` method and `UseUrls`, the `Listen` endpoints override the `UseUrls` endpoints.

**Endpoint configuration for IIS**

If you use IIS, the URL bindings for IIS override anything that you set by calling either `Listen` or `UseUrls`. For information about how URL binding works when you use IIS, see [ASP.NET Core Module](aspnet-core-module.md).

---

### URL prefixes

If you call `UseUrls` or use the  `urls` command-line argument, the URL prefixes can be in any of the following formats. 

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

* IPv4 address with port number

  ```
  http://65.55.39.10:80/
  https://65.55.39.10:443/
  ```

  0.0.0.0 is a special case that binds to all IPv4 addresses.


* IPv6 address with port number

  ```
  http://[0:0:0:0:0:ffff:4137:270a]:80/ 
  https://[0:0:0:0:0:ffff:4137:270a]:443/ 
  ```

  [::] is the IPv6 equivalent of IPv4 0.0.0.0.


* Host name with port number

  ```
  http://contoso.com:80/
  http://*:80/
  https://contoso.com:443/
  https://*:443/
  ```

  Host names, *, and +, are not special. Anything that is not a recognized IP address or "localhost" will bind to all IPv4 and IPv6 IPs. If you need to bind different host names to different ASP.NET Core applications on the same port, use [WebListener](weblistener.md) or a reverse proxy server such as IIS, Nginx, or Apache.

* "Localhost" name with port number or loopback IP with port number

  ```
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ```

  When `localhost` is specified, Kestrel tries to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 is not supported), Kestrel logs a warning. 

* Unix socket

  ```
  http://unix:/run/dan-live.sock  
  ```

If you specify port number 0, Kestrel dynamically binds to an available port. Binding to port 0 is allowed for any host name or IP except for `localhost` name.

When you specify port 0, you can use  [`IServerAddressesFeature`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.server.features.iserveraddressesfeature) to determine which port Kestrel actually bound to at runtime. The following example gets the bound port and displays it on the console.

[!code-csharp[](kestrel/sample/Startup.cs?name=snippet_Configure)]

### URL prefixes for SSL

Be sure to include URL prefixes with `https:` if you call the `UseHttps` extension method, as shown below.

```csharp
var host = new WebHostBuilder() 
    .UseKestrel(options => 
    { 
        options.UseHttps("testCert.pfx", "testPassword"); 
    }) 
   .UseUrls("http://localhost:5000", "https://localhost:5001") 
   .UseContentRoot(Directory.GetCurrentDirectory()) 
   .UseStartup<Startup>() 
   .Build(); 
```

> [!NOTE]
> HTTPS and HTTP cannot be hosted on the same port.


# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample2)

---

## Next steps

For more information, see the following resources:

* [Sample app for this article](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)
* [Kestrel source code](https://github.com/aspnet/KestrelHttpServer)

  The tutorial uses Kestrel by itself locally, then deploys the app to Azure where it runs under Windows using IIS as a reverse proxy server.
