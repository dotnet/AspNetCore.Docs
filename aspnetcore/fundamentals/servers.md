---
title: Servers | Microsoft Docs
author: ardalis
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: dba74f39-58cd-4dee-a061-6d15f7346959
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/servers
---
# Servers

By [Steve Smith](http://ardalis.com) and [Stephen Halter](https://twitter.com/halter73)

ASP.NET Core is completely decoupled from the web server environment that hosts the application. ASP.NET Core supports hosting in IIS and IIS Express, and self-hosting scenarios using the Kestrel and WebListener HTTP servers. Additionally, developers and third party software vendors can create custom servers to host their ASP.NET Core apps.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/servers/sample)

## Servers and WebHostBuilderExtensions

ASP.NET Core was designed to decouple web applications from the underlying HTTP server. Traditionally, ASP.NET apps have been windows-only hosted on Internet Information Server (IIS). The recommended way to run ASP.NET Core applications on Windows is still using IIS, but as a reverse-proxy server. The ASP.NET Core Module in IIS manages and proxies requests to the Kestrel HTTP server hosted out-of-process. ASP.NET Core ships with two different HTTP servers:

* Microsoft.AspNetCore.Server.Kestrel (AKA Kestrel, cross-platform)
* Microsoft.AspNetCore.Server.WebListener (AKA WebListener, Windows-only)

ASP.NET Core does not directly listen for requests, but instead relies on the HTTP server implementation to surface the request to the application as a set of [feature interfaces](request-features.md) composed into an HttpContext. While WebListener is Windows-only, Kestrel is designed to run cross-platform. You can configure your application to be hosted by any of these servers via extension methods on `WebHostBuilder`.

The default web host for ASP.NET apps developed using Visual Studio is IIS Express functioning as a reverse proxy server for Kestrel. The "Microsoft.AspNetCore.Server.Kestrel" and "Microsoft.AspNetCore.Server.IISIntegration" dependencies are included in *project.json* by default, even with the Empty web site template. Visual Studio provides support for multiple profiles. In addition to the default profile for running in IIS Express, the templates include a second profile that executes the app directly relying on Kestrel for self-hosting. You can manage these profiles and their settings in the **Debug** tab of your web application project's Properties menu or from the *launchSettings.json* file.

![image](servers/_static/serverdemo-properties.png)

> [!NOTE]
> The ASP.NET Core Module for IIS supports proxying requests to Kestrel but **not** WebListener.

The sample project's *project.json* file includes the dependencies and tools required to support each server:

project.json (truncated)

[!code-json[Main](servers/sample/ServersDemo/src/ServersDemo/project.json?highlight=5-7,16,20&range=1-18,43-46)]

`UseKestrel` and `UseWebListener` both have an overload taking an options configuration callback that can be used for server-specific configuration. For instance, WebListener exposes `AuthenticationManager` that can be used to configure the server's authentication. Configuration can easily be driven by JSON text files, environment variables, command line arguments and more with the help of ASP.NET Core's [Configuration](configuration.md) facilities.

Kestrel is selected by default in the sample project in the `Program.Main` method which is the entry point for the application. The sample is programmed so WebListener can be selected instead by passing `--server WebListener` as a command line argument. The sample explicitly reads the `--server` command line argument to determine whether to call `UseKestrel` or `UseWebListener`. The `--server` command line flag is **not** interpreted by the ASP.NET Core framework to have any special meaning.

> [!NOTE]
> `builder.UseUrls("http://localhost")` configures Kestrel and WebListener to only listen to local requests. Replace "localhost" with "*" to also listen to external requests.

Program.cs

[!code-csharp[Main](servers/sample/ServersDemo/src/ServersDemo/Program.cs?range=17-68&highlight=5,12,18,22,28,34-40,46-51)]

## Supported Features by Server

ASP.NET defines a number of [Request Features](request-features.md). The following table lists the WebListener and Kestrel support for request features.

|Feature|WebListener|Kestrel|
|--- |--- |--- |
|IHttpRequestFeature|Yes|Yes|
|IHttpResponseFeature|Yes|Yes|
|IHttpAuthenticationFeature|Yes|No|
|IHttpUpgradeFeature|Yes (with limits)|Yes|
|IHttpBufferingFeature|Yes|No|
|IHttpConnectionFeature|Yes|Yes|
|IHttpRequestLifetimeFeature|Yes|Yes|
|IHttpSendFileFeature|Yes|No|
|IHttpWebSocketFeature|No*|No*|
|IHttpRequestIdentifierFeature|Yes|No|
|ITlsConnectionFeature|Yes|Yes|
|ITlsTokenBindingFeature|Yes|No|

### ServerFeatures Collection

The `IApplicationBuilder` available in the `Startup`'s `Configure` method exposes the `ServerFeatures` property of type `IFeatureCollection`. Kestrel and WebListener both expose only a single feature, `IServerAddressesFeature`, but different server implementations may expose additional functionality.

### Port 0 binding with Kestrel

Kestrel supports dynamically binding to an unspecified, available port by specifying port number 0 in `UseUrls`, e.g. `builder.UseUrls("http://127.0.0.1:0")`. The `IServerAddressesFeature` can be used to determine which available port Kestrel actually bound to.

[!code-csharp[Main](servers/sample/ServersDemo/src/ServersDemo/Startup.cs?highlight=5&range=25-44)]

> [!NOTE]
> Binding to `http://localhost:0` is not supported. You must either bind to `http://127.0.0.1:0`, `http://[::1]:0` or both individually.

## IIS and IIS Express

IIS is the most feature rich server, and includes IIS management functionality and access to other IIS modules. Hosting ASP.NET Core no longer uses the `System.Web` infrastructure used by prior versions of ASP.NET.

IIS Express can be launched by Visual Studio using the default profile defined by the ASP.NET Core templates. [Publishing and Deployment](../publishing/index.md) provides guidelines for publishing to IIS.

### ASP.NET Core Module

In ASP.NET Core on Windows, the web application is hosted by an external process outside of IIS. The ASP.NET Core Module is an IIS 7.5+ module which is responsible for process management of HTTP listeners and used to proxy requests to the processes that it manages.

<a name=kestrel></a>

## Kestrel

Kestrel is a cross-platform web server based on [libuv](https://github.com/libuv/libuv), a cross-platform asynchronous I/O library. You add support for Kestrel by including `Microsoft.AspNetCore.Server.Kestrel` in your project's dependencies listed in *project.json* and calling `UseKestrel`.

Learn more about working with Kestrel to create [Your First ASP.NET Core Application on a Mac Using Visual Studio Code](../tutorials/your-first-mac-aspnet.md).

<a name=weblistener></a>

## WebListener

WebListener is a Windows-only HTTP server for ASP.NET Core. It runs directly on the [Http.Sys kernel driver](http://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture), and has very little overhead. WebListener cannot be used with the ASP.NET Core Module for IIS. It can only be used independently.

You can add support for WebListener to your ASP.NET application by adding the `Microsoft.AspNetCore.Server.WebListener` dependency in *project.json* and calling `UseWebListener`

> [!NOTE]
> Kestrel is designed to be run behind a proxy (for example IIS or Nginx) and should not be deployed directly facing the Internet.

## Choosing a server

If you intend to deploy your application on a Windows server, you should run IIS as a reverse proxy server that manages and proxies requests to Kestrel. If deploying on Linux, you should run a comparable reverse proxy server such as [Apache](../publishing/apache-proxy.md) or [Nginx](../publishing/linuxproduction.md) to proxy requests to Kestrel.

## Custom Servers

You can create your own server in which to host ASP.NET apps, or use other open source servers. When implementing your own server, you're free to implement just the feature interfaces your application needs, though at a minimum you must support `IHttpRequestFeature` and `IHttpResponseFeature`.

Since Kestrel is open source, it makes an excellent starting point if you need to implement your own custom server. Like all of ASP.NET Core, you're welcome to [contribute](https://github.com/aspnet/KestrelHttpServer/blob/dev/CONTRIBUTING.md) any improvements you make back to the project.

Kestrel currently supports a limited number of feature interfaces, but additional features will be added in the future.

The [Using ASP.NET Hosting on an OWIN-based server](owin.md#hosting-on-owin) guide demonstrates how to write a [Nowin](https://github.com/Bobris/Nowin) based `IServer`.

## Additional Reading

* [Request Features](request-features.md)
