---
title: Web server implementations in ASP.NET Core
author: rick-anderson
description: Discover the web servers Kestrel and HTTP.sys for ASP.NET Core. Learn how to choose a server and when to use a reverse proxy server.
ms.author: tdykstra
ms.custom: mvc
ms.date: 03/13/2018
uid: fundamentals/servers/index
---
# Web server implementations in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Steve Smith](https://ardalis.com/), [Stephen Halter](https://twitter.com/halter73), and [Chris Ross](https://github.com/Tratcher)

An ASP.NET Core app runs with an in-process HTTP server implementation. The server implementation listens for HTTP requests and surfaces them to the app as sets of [request features](xref:fundamentals/request-features) composed into an [HttpContext](/dotnet/api/system.web.httpcontext).

ASP.NET Core ships two server implementations:

* [Kestrel](xref:fundamentals/servers/kestrel) is the default, cross-platform HTTP server for ASP.NET Core.
* [HTTP.sys](xref:fundamentals/servers/httpsys) is a Windows-only HTTP server based on the [HTTP.sys kernel driver and HTTP Server API](https://msdn.microsoft.com/library/windows/desktop/aa364510.aspx). (HTTP.sys is called [WebListener](xref:fundamentals/servers/weblistener) in ASP.NET Core 1.x.)

## Kestrel

Kestrel is the default web server included in ASP.NET Core project templates.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Kestrel can be used by itself or with a *reverse proxy server*, such as IIS, Nginx, or Apache. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling.

![Kestrel communicates directly with the Internet without a reverse proxy server](kestrel/_static/kestrel-to-internet2.png)

![Kestrel communicates indirectly with the Internet through a reverse proxy server, such as IIS, Nginx, or Apache](kestrel/_static/kestrel-to-internet.png)

Either configuration&mdash;with or without a reverse proxy server&mdash;is a valid and supported hosting configuration for ASP.NET Core 2.0 or later apps. For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

If the app only accepts requests from an internal network, Kestrel can be used by itself.

![Kestrel communicates directly with the internal network](kestrel/_static/kestrel-to-internal.png)

If the app is exposed to the Internet, Kestrel must use IIS, Nginx, or Apache as a *reverse proxy server*. A reverse proxy server receives HTTP requests from the Internet and forwards them to Kestrel after some preliminary handling, as shown in the following diagram:

![Kestrel communicates indirectly with the Internet through a reverse proxy server, such as IIS, Nginx, or Apache](kestrel/_static/kestrel-to-internet.png)

The most important reason for using a reverse proxy for edge deployments (exposed to traffic from the Internet) is security. The 1.x versions of Kestrel don't have important security features to defend against attacks from the Internet. This includes, but isn't limited to, appropriate timeouts, request size limits, and concurrent connection limits.

For more information, see [When to use Kestrel with a reverse proxy](xref:fundamentals/servers/kestrel#when-to-use-kestrel-with-a-reverse-proxy).

---

IIS, Nginx, and Apache can't be used without Kestrel or a [custom server implementation](#custom-servers). ASP.NET Core was designed to run in its own process so that it can behave consistently across platforms. IIS, Nginx, and Apache dictate their own startup procedure and environment. To use these server technologies directly, ASP.NET Core would need to adapt to the requirements of each server. Using a web server implementation, such as Kestrel, ASP.NET Core has control over the startup process and environment when hosted on different server technologies.

### IIS with Kestrel

When using [IIS](/iis/get-started/introduction-to-iis/introduction-to-iis-architecture) or [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) as a reverse proxy for ASP.NET Core, the ASP.NET Core app runs in a process separate from the IIS worker process. In the IIS process, the [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module) coordinates the reverse proxy relationship. The primary functions of the ASP.NET Core Module are to start the ASP.NET Core app, restart the app when it crashes, and forward HTTP traffic to the app. For more information, see [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module). 

### Nginx with Kestrel

For information on how to use Nginx on Linux as a reverse proxy server for Kestrel, see [Host on Linux with Nginx](xref:host-and-deploy/linux-nginx).

### Apache with Kestrel

For information on how to use Apache on Linux as a reverse proxy server for Kestrel, see [Host on Linux with Apache](xref:host-and-deploy/linux-apache).

## HTTP.sys

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

If ASP.NET Core apps are run on Windows, HTTP.sys is an alternative to Kestrel. Kestrel is generally recommended for best performance. HTTP.sys can be used in scenarios where the app is exposed to the Internet and required features are supported by HTTP.sys but not Kestrel. For information on HTTP.sys features, see [HTTP.sys](xref:fundamentals/servers/httpsys).

![HTTP.sys communicates directly with the Internet](httpsys/_static/httpsys-to-internet.png)

HTTP.sys can also be used for apps that are only exposed to an internal network. 

![HTTP.sys communicates directly with the internal network](httpsys/_static/httpsys-to-internal.png)

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

HTTP.sys is named [WebListener](xref:fundamentals/servers/weblistener) in ASP.NET Core 1.x. If ASP.NET Core apps are run on Windows, WebListener is an alternative for scenarios where IIS isn't available to host apps.

![Weblistener communicates directly with the Internet](weblistener/_static/weblistener-to-internet.png)

WebListener can also be used in place of Kestrel for apps that are only exposed to an internal network, if required features are supported by WebListener but not Kestrel. For information on WebListener features, see [WebListener](xref:fundamentals/servers/weblistener).

![Weblistener communicates directly with the internal network](weblistener/_static/weblistener-to-internal.png)

---

## ASP.NET Core server infrastructure

The [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) available in the `Startup.Configure` method exposes the [ServerFeatures](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder.serverfeatures) property of type [IFeatureCollection](/dotnet/api/microsoft.aspnetcore.http.features.ifeaturecollection). Kestrel and HTTP.sys (WebListener in ASP.NET Core 1.x) only expose a single feature each, [IServerAddressesFeature](/dotnet/api/microsoft.aspnetcore.hosting.server.features.iserveraddressesfeature), but different server implementations may expose additional functionality.

`IServerAddressesFeature` can be used to find out which port the server implementation has bound at runtime.

## Custom servers

If the built-in servers don't meet the app's requirements, a custom server implementation can be created. The [Open Web Interface for .NET (OWIN) guide](xref:fundamentals/owin) demonstrates how to write a [Nowin](https://github.com/Bobris/Nowin)-based [IServer](/dotnet/api/microsoft.aspnetcore.hosting.server.iserver) implementation. Only the feature interfaces that the app uses require implementation, though at a minimum [IHttpRequestFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttprequestfeature) and [IHttpResponseFeature](/dotnet/api/microsoft.aspnetcore.http.features.ihttpresponsefeature) must be supported.

## Server startup

When using [Visual Studio](https://www.visualstudio.com/vs/), [Visual Studio for Mac](https://www.visualstudio.com/vs/mac/), or [Visual Studio Code](https://code.visualstudio.com/), the server is launched when the app is started by the Integrated Development Environment (IDE). In Visual Studio on Windows, launch profiles can be used to start the app and server with either [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview)/[ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module) or the console. In Visual Studio Code, the app and server are started by [Omnisharp](https://github.com/OmniSharp/omnisharp-vscode), which activates the CoreCLR debugger. Using Visual Studio for Mac, the app and server are started by the [Mono Soft-Mode Debugger](http://www.mono-project.com/docs/advanced/runtime/docs/soft-debugger/).

When launching an app from a command prompt in the project's folder, [dotnet run](/dotnet/core/tools/dotnet-run) launches the app and server (Kestrel and HTTP.sys only). The configuration is specified by the `-c|--configuration` option, which is set to either `Debug` (default) or `Release`. If launch profiles are present in a *launchSettings.json* file, use the `--launch-profile <NAME>` option to set the launch profile (for example, `Development` or `Production`). For more information, see the [dotnet run](/dotnet/core/tools/dotnet-run) and [.NET Core distribution packaging](/dotnet/core/build/distribution-packaging) topics.

## Additional resources

* [Kestrel](xref:fundamentals/servers/kestrel)
* [Kestrel with IIS](xref:fundamentals/servers/aspnet-core-module)
* [Host on Linux with Nginx](xref:host-and-deploy/linux-nginx)
* [Host on Linux with Apache](xref:host-and-deploy/linux-apache)
* [HTTP.sys](xref:fundamentals/servers/httpsys) (for ASP.NET Core 1.x, see [WebListener](xref:fundamentals/servers/weblistener))
