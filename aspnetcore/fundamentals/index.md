---
title: ASP.NET Core fundamentals
author: rick-anderson
description: Discover the foundational concepts for building ASP.NET Core applications.
keywords: ASP.NET Core,fundamentals,overview
ms.author: riande
manager: wpickett
ms.date: 09/30/2017
ms.topic: get-started-article
ms.assetid: a19b7836-63e4-44e8-8250-50d426dd1070
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/index
ms.custom: H1Hack27Feb2017
---

# ASP.NET Core fundamentals

An ASP.NET Core application is a console app that creates a web server in its `Main` method:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs)]

The `Main` method invokes `WebHost.CreateDefaultBuilder`, which follows the builder pattern to create a web application host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is automatically allocated. ASP.NET Core's web host attempts to run on IIS, if available. Other web servers, such as [HTTP.sys](xref:fundamentals/servers/httpsys), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`IWebHostBuilder`, the return type of the `WebHost.CreateDefaultBuilder` invocation, provides many optional methods. Some of these methods include `UseHttpSys` for hosting the app in HTTP.sys and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that hosts the app and begins listening for HTTP requests.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

The `Main` method uses `WebHostBuilder`, which follows the builder pattern to create a web application host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is used. Other web servers, such as [WebListener](xref:fundamentals/servers/weblistener), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`WebHostBuilder` provides many optional methods, including `UseIISIntegration` for hosting in IIS and IIS Express and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that hosts the app and begins listening for HTTP requests.

---

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs?highlight=10&range=6-17)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

---

The `Startup` class is where you define the request handling pipeline and where any services needed by the app are configured. The `Startup` class must be public and contain the following methods:

```csharp
public class Startup
{
    // This method gets called by the runtime. Use this method
    // to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // This method gets called by the runtime. Use this method
    // to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
    }
}
```

`ConfigureServices` defines the [Services](#dependency-injection-services) used by your app (for example, ASP.NET Core MVC, Entity Framework Core, Identity). `Configure` defines the [middleware](xref:fundamentals/middleware) for the request pipeline.

For more information, see [Application startup](xref:fundamentals/startup).

## Content root

The content root is the base path to any content used by the app, such as views, [Razor Pages](xref:mvc/razor-pages/index), and static assets. By default, the content root is the same as application base path for the executable hosting the app.

## Web root

The web root of an app is the directory in the project containing public, static resources, such as CSS, JavaScript, and image files.

## Dependency Injection (Services)

A service is a component that's intended for common consumption in an app. Services are made available through [dependency injection (DI)](xref:fundamentals/dependency-injection). ASP.NET Core includes a native **I**nversion **o**f **C**ontrol (IoC) container that supports [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) by default. You can replace the default native container if you wish. In addition to its loose coupling benefit, DI makes services available throughout your app (for example, [logging](xref:fundamentals/logging/index)).

For more information, see [Dependency injection](xref:fundamentals/dependency-injection).

## Middleware

In ASP.NET Core, you compose your request pipeline using [middleware](xref:fundamentals/middleware). ASP.NET Core middleware performs asynchronous logic on an `HttpContext` and then either invokes the next middleware in the sequence or terminates the request directly. A middleware component called "XYZ" is added by invoking an `UseXYZ` extension method in the `Configure` method.

ASP.NET Core comes with a rich set of built-in middleware:

* [Static files](xref:fundamentals/static-files)
* [Routing](xref:fundamentals/routing)
* [Authentication](xref:security/authentication/index)
* [Response Compression Middleware](xref:performance/response-compression)
* [URL Rewriting Middleware](xref:fundamentals/url-rewriting)

[OWIN](http://owin.org)-based middleware is available for ASP.NET Core apps, and you can write your own custom middleware.

For more information, see [Middleware](xref:fundamentals/middleware) and [Open Web Interface for .NET (OWIN)](xref:fundamentals/owin).

## Environments

Environments, such as "Development" and "Production", are a first-class notion in ASP.NET Core and can be set using environment variables.

For more information, see [Working with Multiple Environments](xref:fundamentals/environments).

## Configuration

ASP.NET Core uses a configuration model based on name-value pairs. The configuration model isn't based on `System.Configuration` or *web.config*. Configuration obtains settings from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

For more information, see [Configuration](xref:fundamentals/configuration).

## Logging

ASP.NET Core supports a logging API that works with a variety of logging providers. Built-in providers support sending logs to one or more destinations. Third-party logging frameworks can be used.

[Logging](xref:fundamentals/logging/index)

## Error handling

ASP.NET Core has built-in features for handling errors in apps, including a developer exception page, custom error pages, static status code pages, and startup exception handling.

For more information, see [Error Handling](xref:fundamentals/error-handling).

## Routing

ASP.NET Core offers features for routing of app requests to route handlers.

For more information, see [Routing](xref:fundamentals/routing).

## File providers

ASP.NET Core abstracts file system access through the use of File Providers, which offers a common interface for working with files across platforms.

For more information, see [File Providers](xref:fundamentals/file-providers).

## Static files

Static files middleware serves static files, such as HTML, CSS, image, and JavaScript.

For more information, see [Working with static files](xref:fundamentals/static-files).

## Hosting

ASP.NET Core apps configure and launch a *host*, which is responsible for app startup and lifetime management.

For more information, see [Hosting](xref:fundamentals/hosting).

## Session and application state

Session state is a feature in ASP.NET Core that you can use to save and store user data while the user browses your web app.

For more information, see [Session and application state](xref:fundamentals/app-state).

## Servers

The ASP.NET Core hosting model doesn't directly listen for requests. The hosting model relies on an HTTP server implementation to forward the request to the app. The forwarded request is wrapped as a set of feature objects that can be accessed through interfaces. ASP.NET Core includes a managed, cross-platform web server, called [Kestrel](xref:fundamentals/servers/kestrel). Kestrel is often run behind a production web server, such as [IIS](https://www.iis.net/) or [nginx](http://nginx.org). Kestrel can be run as an edge server.

For more information, see [Servers](xref:fundamentals/servers/index) and the following topics:

* [Kestrel](xref:fundamentals/servers/kestrel)
* [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module)
* [HTTP.sys](xref:fundamentals/servers/httpsys) (formerly called [WebListener](xref:fundamentals/servers/weblistener))

## Globalization and localization

Creating a multilingual website with ASP.NET Core allows your site to reach a wider audience. ASP.NET Core provides services and middleware for localizing into different languages and cultures.

For more information, see [Globalization and localization](xref:fundamentals/localization).

## Request features

Web server implementation details related to HTTP requests and responses are defined in interfaces. These interfaces are used by server implementations and middleware to create and modify the app's hosting pipeline.

For more information, see [Request Features](xref:fundamentals/request-features).

## Open Web Interface for .NET (OWIN)

ASP.NET Core supports the Open Web Interface for .NET (OWIN). OWIN allows web apps to be decoupled from web servers.

For more information, see [Open Web Interface for .NET (OWIN)](xref:fundamentals/owin).

## WebSockets

[WebSocket](https://wikipedia.org/wiki/WebSocket) is a protocol that enables two-way persistent communication channels over TCP connections. It's used for apps such as chat, stock tickers, games, and anywhere you desire real-time functionality in a web app. ASP.NET Core supports web socket features.

For more information, see [WebSockets](xref:fundamentals/websockets).

## Microsoft.AspNetCore.All metapackage

The [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) metapackage for ASP.NET Core includes:

* All supported packages by the ASP.NET Core team.
* All supported packages by the Entity Framework Core. 
* Internal and 3rd-party dependencies used by ASP.NET Core and Entity Framework Core.

For more information, see [Microsoft.AspNetCore.All metapackage](xref:fundamentals/metapackage).

## .NET Core vs. .NET Framework runtime

An ASP.NET Core app can target the .NET Core or .NET Framework runtime.

For more information, see [Choosing between .NET Core and .NET Framework](/dotnet/articles/standard/choosing-core-framework-server).

## Choose between ASP.NET Core and ASP.NET

For more information on choosing between ASP.NET Core and ASP.NET, see [Choose between ASP.NET Core and ASP.NET](xref:fundamentals/choose-between-aspnet-and-aspnetcore).
