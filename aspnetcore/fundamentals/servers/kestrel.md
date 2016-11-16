---
title: Kestrel server
author: tdykstra
ms.author: tdykstra
manager: wpickett
ms.date: 10/27/2016
ms.topic: article
ms.assetid: 560bd66f-7dd0-4e68-b5fb-f31477e4b785
ms.prod: aspnet-core
uid: fundamentals/servers/kestrel
---
# Kestrel server for ASP.NET Core

By [Tom Dykstra](http://github.com/tdykstra), [Chris Ross](https://github.com/Tratcher), and [Stephen Halter](https://twitter.com/halter73)

Kestrel is a cross-platform [web server for ASP.NET Core](overview.md) based on [libuv](https://github.com/libuv/libuv), a cross-platform asynchronous I/O library. Kestrel is the web server that is included by default in ASP.NET Core new project templates. 

Kestrel supports the following features:

  * HTTPS
  * Opaque upgrade used to enable [WebSockets](https://github.com/aspnet/websockets)
  * Unix sockets for high performance behind Nginx 

Kestrel is supported on all platforms and versions that .NET Core supports.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)

## When to use Kestrel with a reverse proxy

If your application accepts requests only from an internal network, you can use Kestrel by itself.

![Kestrel to internal network](kestrel/_static/kestrel-to-internal.png)

If you expose your application to the Internet, you must use IIS, Nginx, or Apache as a *reverse proxy server*. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.

![Kestrel to Internet](kestrel/_static/kestrel-to-internet.png)

A reverse proxy is required for edge deployments (exposed to traffic from the Internet) for security reasons. Kestrel is relatively new and does not yet have a full complement of defenses against attacks. This includes but isn't limited to appropriate timeouts, size limits, and concurrent connection limits.

Another scenario that requires a reverse proxy is when you have multiple applications that share the same port running on a single server. That doesn't work with Kestrel directly because Kestrel doesn't support sharing a port between multiple processes. When you configure Kestrel to listen on a port, it handles all traffic for that port regardless of host header. A reverse proxy that can share ports must then forward to Kestrel on a unique port.

Even if a reverse proxy server isn't required, using one can simplify load balancing and SSL set-up -- only your reverse proxy server requires an SSL certificate, and that server can communicate with your application servers on the internal network using plain HTTP.

## How to use Kestrel in ASP.NET Core apps

Install the [Microsoft.AspNetCore.Server.Kestrel](https://www.nuget.org/packages/Microsoft.AspNetCore.Server.Kestrel/) NuGet package.

Call the [`UseKestrel`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/WebHostBuilderKestrelExtensions/index.html#Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel.md) extension method on `WebHostBuilder` in your `Main` method, specifying any [Kestrel options](https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Server/Kestrel/KestrelServerOptions/) that you need, as shown in the following example:

[!code-csharp[](kestrel/sample/Program.cs?name=snippet_Main&highlight=13-19)]

### URL prefixes

By default ASP.NET Core binds to `http://localhost:5000`. You can configure URL prefixes and ports for Kestrel to listen on by using the `UseUrls` extension method, the `urls` command-line argument, or the ASP.NET Core configuration system. For more information about these methods, see [Hosting](../../fundamentals/hosting.md). For information about how URL binding works when you use IIS as a reverse proxy, see [ASP.NET Core Module](aspnet-core-module.md). 

URL prefixes for Kestrel can be in any of the following formats. 

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
  ````

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

When you specify port 0, you can use  [`IServerAddressesFeature`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/Server/Features/IServerAddressesFeature/index.html#Microsoft.AspNetCore.Hosting.Server.Features.IServerAddressesFeature.md) to determine which port Kestrel actually bound to at runtime. The following example gets the bound port and displays it on the console.

[!code-csharp[](kestrel/sample/Startup.cs?name=snippet_Configure)]

### URL prefixes for SSL

Be sure to include URL prefixes with `https:` if you call the `UseSSL` extension method, as shown below.

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

## Next steps

For more information, see the following resources:

* [Sample app for this article](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)
* [Kestrel source code](https://github.com/aspnet/KestrelHttpServer)
* [Your First ASP.NET Core Application on a Mac Using Visual Studio Code.](../../tutorials/your-first-mac-aspnet.md)

  The tutorial uses Kestrel by itself locally, then deploys the app to Azure where it runs under Windows using IIS as a reverse proxy server.
