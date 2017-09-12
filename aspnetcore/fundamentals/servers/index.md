---
title: Web server implementations in ASP.NET Core
author: tdykstra
description: Introduces web servers Kestrel and WebListener for ASP.NET Core. Provides guidance on how to choose one and when to use one with a reverse proxy server.
keywords: ASP.NET Core, IServer, web server, Kestrel, WebListener, reverse proxy
ms.author: tdykstra
manager: wpickett
ms.date: 08/03/2017
ms.topic: article
ms.assetid: dba74f39-58cd-4dee-a061-6d15f7346959
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/servers/index
---
# Web server implementations in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Steve Smith](https://ardalis.com/), [Stephen Halter](https://twitter.com/halter73), and [Chris Ross](https://github.com/Tratcher)

An ASP.NET Core application runs with an in-process HTTP server implementation. The server implementation listens for HTTP requests and surfaces them to the application as sets of [request features](https://docs.microsoft.com/aspnet/core/fundamentals/request-features) composed into an `HttpContext`.

ASP.NET Core ships two server implementations:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

* [Kestrel](kestrel.md) is a cross-platform HTTP server based on [libuv](https://github.com/libuv/libuv), a cross-platform asynchronous I/O library.

* [HTTP.sys](httpsys.md) is a Windows-only HTTP server based on the [Http.Sys kernel driver](https://msdn.microsoft.com/library/windows/desktop/aa364510.aspx).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

* [Kestrel](kestrel.md) is a cross-platform HTTP server based on [libuv](https://github.com/libuv/libuv), a cross-platform asynchronous I/O library.

* [WebListener](weblistener.md) is a Windows-only HTTP server based on the [Http.Sys kernel driver](https://msdn.microsoft.com/library/windows/desktop/aa364510.aspx).

---

## Kestrel

Kestrel is the web server that is included by default in ASP.NET Core new-project templates. 

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

You can use Kestrel by itself or with a *reverse proxy server*, such as IIS, Nginx, or Apache. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.

![Kestrel communicates directly with the Internet without a reverse proxy server](kestrel/_static/kestrel-to-internet2.png)

![Kestrel communicates indirectly with the Internet through a reverse proxy server, such as IIS, Nginx, or Apache](kestrel/_static/kestrel-to-internet.png)

Either configuration &mdash; with or without a reverse proxy server &mdash; can also be used if Kestrel is exposed only to an internal network.

For information about when to use Kestrel with a reverse proxy, see [Introduction to Kestrel](kestrel.md).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

If your application accepts requests only from an internal network, you can use Kestrel by itself.

![Kestrel communicates directly with your internal network](kestrel/_static/kestrel-to-internal.png)

If you expose your application to the Internet, you must use IIS, Nginx, or Apache as a *reverse proxy server*. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling, as shown in the following diagram.

![Kestrel communicates indirectly with the Internet through a reverse proxy server, such as IIS, Nginx, or Apache](kestrel/_static/kestrel-to-internet.png)

The most important reason for using a reverse proxy for edge deployments (exposed to traffic from the Internet) is security. The 1.x versions of Kestrel don't have a full complement of defenses against attacks. This includes, but isn't limited to, appropriate timeouts, size limits, and concurrent connection limits.

For information about when to use Kestrel with a reverse proxy, see [Introduction to Kestrel](kestrel.md).

---

You can't use IIS, Nginx, or Apache without Kestrel or a [custom server implementation](#custom-servers). ASP.NET Core was designed to run in its own process so that it can behave consistently across platforms. IIS, Nginx, and Apache dictate their own startup process and environment; to use them directly, ASP.NET Core would have to adapt to the needs of each one. Using a web server implementation such as Kestrel gives ASP.NET Core control over the startup process and environment. So rather than trying to adapt ASP.NET Core to IIS, Nginx, or Apache, you just set up those web servers to proxy requests to Kestrel. This arrangement allows your `Program.Main` and `Startup` classes to be essentially the same no matter where you deploy.

### IIS with Kestrel

When you use IIS or IIS Express as a reverse proxy for ASP.NET Core, the ASP.NET Core application runs in a process separate from the IIS worker process. In the IIS process, a special IIS module runs to coordinate the reverse proxy relationship.  This is the *ASP.NET Core Module*. The primary functions of the ASP.NET Core Module are to start the ASP.NET Core application, restart it when it crashes, and forward HTTP traffic to it. For more information, see [ASP.NET Core Module](aspnet-core-module.md). 

### Nginx with Kestrel

For information about how to use Nginx on Linux as a reverse proxy server for Kestrel, see [Publish to a Linux Production Environment](../../publishing/linuxproduction.md).

### Apache with Kestrel

For information about how to use Apache on Linux as a reverse proxy server for Kestrel, see [Using Apache Web Server as a reverse proxy](../../publishing/apache-proxy.md).

## HTTP.sys

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

If you run your ASP.NET Core app on Windows, HTTP.sys is an alternative to Kestrel. You can use HTTP.sys for scenarios where you expose your app to the Internet and you need HTTP.sys features that Kestrel doesn't support. 

![HTTP.sys communicates directly with the Internet](httpsys/_static/httpsys-to-internet.png)

HTTP.sys can also be used for applications that are exposed only to an internal network. 

![HTTP.sys communicates directly with your internal network](httpsys/_static/httpsys-to-internal.png)

For internal network scenarios, Kestrel is generally recommended for best performance; but in some scenarios, you might want to use a feature that only HTTP.sys offers. For information about HTTP.sys features, see [HTTP.sys](httpsys.md).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

HTTP.sys is named WebListener in ASP.NET Core 1.x. If you run your ASP.NET Core app on Windows, WebListener is an alternative that you can use for scenarios where you want to expose your app to the Internet but you can't use IIS.

![Weblistener communicates directly with the Internet](weblistener/_static/weblistener-to-internet.png)

WebListener can also be used in place of Kestrel for applications that are exposed only to an internal network, if you need WebListener features that Kestrel doesn't support. 

![Weblistener communicates directly with your internal network](weblistener/_static/weblistener-to-internal.png)

For internal network scenarios, Kestrel is generally recommended for best performance, but in some scenarios you might want to use a feature that only WebListener offers. For information about WebListener features, see [WebListener](weblistener.md).

---

## Notes about ASP.NET Core server infrastructure

The [`IApplicationBuilder`](https://docs.microsoft.com/aspnet/core/api) available in the `Startup` class `Configure` method exposes the `ServerFeatures` property of type [`IFeatureCollection`](https://docs.microsoft.com/aspnet/core/api). Kestrel and WebListener both expose only a single feature, [`IServerAddressesFeature`](https://docs.microsoft.com/aspnet/core/api), but different server implementations may expose additional functionality.

`IServerAddressesFeature` can be used to find out which port the server implementation has bound to at runtime.

## Custom servers

If the built-in servers don't meet your needs, you can create a custom server implementation. The [Open Web Interface for .NET (OWIN) guide](../owin.md) demonstrates how to write a [Nowin](https://github.com/Bobris/Nowin)-based [IServer](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.server.iserver) implementation. You're free to implement just the feature interfaces your application needs, though at a minimum you must support [IHttpRequestFeature](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.http.features.ihttprequestfeature) and [IHttpResponseFeature](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.http.features.ihttpresponsefeature).

## Next steps

For more information, see the following resources:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

- [Kestrel](kestrel.md)
- [Kestrel with IIS](aspnet-core-module.md)
- [Kestrel with Nginx](../../publishing/linuxproduction.md)
- [Kestrel with Apache](../../publishing/apache-proxy.md)
- [HTTP.sys](httpsys.md)

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

- [Kestrel](kestrel.md)
- [Kestrel with IIS](aspnet-core-module.md)
- [Kestrel with Nginx](../../publishing/linuxproduction.md)
- [Kestrel with Apache](../../publishing/apache-proxy.md)
- [WebListener](weblistener.md)

---
