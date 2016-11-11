---
author: tdykstra
ms.author: tdykstra
manager: wpickett
ms.date: 10/27/2016
ms.topic: article
ms.assetid: 560bd66f-7dd0-4e68-b5fb-f31477e4b785
ms.prod: aspnet-core
uid: fundamentals/servers/kestrel
---



Kestrel supports the following features:

  * HTTPS
  * Opaque upgrade used to enable [WebSockets](https://github.com/aspnet/websockets)
  * Unix sockets for high performance behind Nginx 

Kestrel is supported on all platforms and versions that .NET Core supports.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)

## When to use Kestrel with a reverse proxy

If your application accepts requests only from an internal network, you can use Kestrel by itself.


If you expose your application to the Internet, we recommend that you use IIS, Nginx, or Apache as a *reverse proxy server*. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.


The most important reason for using a reverse proxy for edge deployments (exposed to traffic from the Internet) is security. Kestrel is relatively new and does not yet have a full complement of defenses against attacks. This includes but isn't limited to appropriate timeouts, size limits, and concurrent connection limits.

Another scenario that requires a reverse proxy is when you have multiple applications that share the same port running on a single server. That doesn't work with Kestrel directly because Kestrel doesn't support host-header routing. When you configure Kestrel to listen on a port, it handles all traffic for that port regardless of host header.


## How to use Kestrel in ASP.NET Core apps


Call the [`UseKestrel`](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Hosting/WebHostBuilderKestrelExtensions/index.html#Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel.md) extension method on `WebHostBuilder` in your `Main` method, specifying any [Kestrel options](https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Server/Kestrel/KestrelServerOptions/) that you need, as shown in the following example:


### URL prefixes


URL prefixes for Kestrel can be in any of the following formats. 

* IP address with port number

  ````none
  http://65.55.39.10:80/
  https://65.55.39.10:443/
  ````

  Address 0.0.0.0 is a special case that binds to all IP addresses.


* IPV6 address with port number

  ````none
  http://[0:0:0:0:0:ffff:4137:270a]:80/ 
  https://[0:0:0:0:0:ffff:4137:270a]:443/ 
  ````

* Host name with port number

  ````none 
  http://contoso.com:80/
  http://*:80/
  https://contoso.com:443/
  https://*:443/
  ````


* "Localhost" host name or IP, with port number

  ````none
  http://localhost:5000/
  http://127.0.0.1:5000/
  http://[::1]:5000/
  ````

  When `localhost` is specified, Kestrel tries to bind to both IPv4 and IPv6 loopback interfaces. If the requested port is in use by another service on either loopback interface, Kestrel fails to start. If either loopback interface is unavailable for any other reason (most commonly because IPv6 is not supported), Kestrel logs a warning. 


  ````none
  http://127.0.0.1:0/
  http://[::1]:0/
  ````




### Url prefixes for SSL

Be sure to include URL prefixes with `https:` if you call the `UseSSL` extension method, as shown below.

````csharp
var host = new WebHostBuilder() 
    .UseKestrel(options => 
    { 
        options.NoDelay = true; 
        options.UseHttps("testCert.pfx", "testPassword"); 
        options.UseConnectionLogging(); 
    }) 
   .UseUrls("http://localhost:5000", "https://localhost:5001") 
   .UseContentRoot(Directory.GetCurrentDirectory()) 
   .UseStartup<Startup>() 
   .Build(); 
````

## Next steps

For more information, see the following resources:

* [Sample app for this article](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/kestrel/sample)
* [Kestrel source code](https://github.com/aspnet/KestrelHttpServer)
* [Your First ASP.NET Core Application on a Mac Using Visual Studio Code.](../../tutorials/your-first-mac-aspnet.md)

  The tutorial uses Kestrel by itself locally, then deploys the app to Azure where it runs under Windows using IIS as a reverse proxy server.
