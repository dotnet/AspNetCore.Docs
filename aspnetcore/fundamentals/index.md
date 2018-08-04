---
title: ASP.NET Core fundamentals
author: rick-anderson
description: Discover the foundational concepts for building ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 08/06/2018
uid: fundamentals/index
---
# ASP.NET Core fundamentals

An ASP.NET Core app is a console app that creates a web server in its `Main` method:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](../getting-started/sample/aspnetcoreapp/Program2x.cs)]

The `Main` method invokes `WebHost.CreateDefaultBuilder`, which follows the builder pattern to create a web host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is automatically allocated. ASP.NET Core's web host attempts to run on IIS, if available. Other web servers, such as [HTTP.sys](xref:fundamentals/servers/httpsys), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`IWebHostBuilder`, the return type of the `WebHost.CreateDefaultBuilder` invocation, provides many optional methods. Some of these methods include `UseHttpSys` for hosting the app in HTTP.sys and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that hosts the app and begins listening for HTTP requests.

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](../getting-started/sample/aspnetcoreapp/Program.cs)]

The `Main` method uses `WebHostBuilder`, which follows the builder pattern to create a web host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is used. Other web servers, such as [WebListener](xref:fundamentals/servers/weblistener), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`WebHostBuilder` provides many optional methods, including `UseIISIntegration` for hosting in IIS and IIS Express and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that hosts the app and begins listening for HTTP requests.

::: moniker-end

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](../getting-started/sample/aspnetcoreapp/Program2x.cs?highlight=10&range=6-17)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

::: moniker-end

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

`ConfigureServices` defines the [Services](#dependency-injection-services) used by your app (for example, ASP.NET Core MVC, Entity Framework Core, Identity). `Configure` defines the [middleware](xref:fundamentals/middleware/index) for the request pipeline.

For more information, see <xref:fundamentals/startup>.

## Content root

The content root is the base path to any content used by the app, such as views, [Razor Pages](xref:razor-pages/index), and static assets. By default, the content root is the same as app base path for the executable hosting the app.

## Web root

The web root of an app is the directory in the project containing public, static resources, such as CSS, JavaScript, and image files.

## Dependency injection (services)

A service is a component that's intended for common consumption in an app. Services are made available through [dependency injection (DI)](xref:fundamentals/dependency-injection). ASP.NET Core includes a native Inversion of Control (IoC) container that supports [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) by default. You can replace the default native container if you wish. In addition to its loose coupling benefit, DI makes services available throughout your app (for example, [logging](xref:fundamentals/logging/index)).

For more information, see <xref:fundamentals/dependency-injection>.

## Middleware

In ASP.NET Core, you compose your request pipeline using [middleware](xref:fundamentals/middleware/index). ASP.NET Core middleware performs asynchronous logic on an [HttpContext](/dotnet/api/microsoft.aspnetcore.http.httpcontext) and then either invokes the next middleware in the sequence or terminates the request directly. A middleware component called "XYZ" is added by invoking an `UseXYZ` extension method in the `Configure` method. You can write your own custom middleware.

ASP.NET Core includes a rich set of built-in middleware, including:

* [Static files](xref:fundamentals/static-files)
* [Routing](xref:fundamentals/routing)
* [Authentication](xref:security/authentication/index)
* [Response Compression Middleware](xref:performance/response-compression)
* [URL Rewriting Middleware](xref:fundamentals/url-rewriting)

For more information, see <xref:fundamentals/middleware/index>.

## Static files

Static Files Middleware serves static files, such as HTML, CSS, image, and JavaScript.

For more information, see <xref:fundamentals/static-files>.

## Routing

ASP.NET Core offers scenarios for routing of app requests to route handlers.

For more information, see <xref:fundamentals/routing>.

## Environments

Environments, such as *Development* and *Production*, are a first-class notion in ASP.NET Core and can be set using environment variables and command-line tools.

For more information, see <xref:fundamentals/environments>.

## Configuration and options

ASP.NET Core app configuration uses a configuration model based on name-value pairs. Configuration obtains settings from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

The [host](#host), which is responsible app startup and lifetime management, has its own configuration. Configuration data used for host configuration flows into the global configuration model used by the app.

For more information, see:

* <xref:fundamentals/configuration/index>
* <xref:fundamentals/configuration/options>
* <xref:fundamentals/host/index>

## Logging

ASP.NET Core supports a logging API that works with a variety of logging providers. Built-in providers support sending logs to one or more destinations. Third-party logging frameworks can be used.

For more information, see <xref:fundamentals/logging/index>.

## Handle errors

ASP.NET Core has built-in scenarios for handling errors in apps, including a developer exception page, custom error pages, static status code pages, and startup exception handling.

For more information, see <xref:fundamentals/error-handling>.

## Host

ASP.NET Core apps configure and launch a *host*, which is responsible for app startup and lifetime management.

The app has its own configuration. Host configuration flows into the global configuration model used by the app. For more information on app configuration, <xref:fundamentals/configuration/index>.

For more information, see <xref:fundamentals/host/index>.

## Background tasks

Background tasks are implemented as *hosted services*. A hosted service is a class with background task logic that implements the [IHostedService](/dotnet/api/microsoft.extensions.hosting.ihostedservice) interface.

For more information, see <xref:fundamentals/host/hosted-services>.

## Servers

The ASP.NET Core hosting model doesn't directly listen for requests. The hosting model relies on an HTTP server implementation to forward requests to the app. A forwarded request is wrapped as a set of objects that can be accessed through interfaces. ASP.NET Core includes a managed, cross-platform web server, called [Kestrel](xref:fundamentals/servers/kestrel). Kestrel is often run in a reverse proxy configuration behind a production web server, such as [IIS](https://www.iis.net/) or [Nginx](http://nginx.org). Kestrel can be run as an edge server.

For more information, see <xref:fundamentals/servers/index> and the following topics:

* <xref:fundamentals/servers/kestrel>
* <xref:fundamentals/servers/aspnet-core-module>
* <xref:fundamentals/servers/httpsys> (HTTP.sys is formerly called [WebListener](xref:fundamentals/servers/weblistener))

## Session and app state

ASP.NET Core offers several approaches to preserve session and app state while a user browses a web app.

For more information, see <xref:fundamentals/app-state>.

## File Providers

ASP.NET Core abstracts file system access through the use of File Providers, which offers a common interface for working with files across platforms.

For more information, see <xref:fundamentals/file-providers>.

## Repository pattern

The *repository pattern* is a design pattern that isolates data access behind interface abstractions.

For more information, see <xref:fundamentals/repository-pattern>.

## Globalization and localization

Creating a multilingual website with ASP.NET Core allows your site to reach a wider audience. ASP.NET Core provides services and middleware for localizing content into different languages and cultures.

For more information, see <xref:fundamentals/localization>.

::: moniker range=">= aspnetcore-2.1"

## Initiate HTTP requests

For information on using [IHttpClientFactory](/dotnet/api/system.net.http.ihttpclientfactory) to access [HttpClient](/dotnet/api/system.net.http.httpclient) instances to make HTTP requests, see <xref:fundamentals/http-requests>.

::: moniker-end

## Request Features

Web server implementation details related to HTTP requests and responses are defined in interfaces. These interfaces are used by server implementations and middleware to create and modify the app's hosting pipeline.

For more information, see <xref:fundamentals/request-features>.

## Access HttpContext

Access the [HttpContext](/dotnet/api/microsoft.aspnetcore.http.httpcontext) through the [IHttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.ihttpcontextaccessor) interface and its default implementation [HttpContextAccessor](/dotnet/api/microsoft.aspnetcore.http.httpcontextaccessor).

For more information, see <xref:fundamentals/httpcontext>.

## Open Web Interface for .NET (OWIN)

ASP.NET Core supports the Open Web Interface for .NET (OWIN). OWIN allows web apps to be decoupled from web servers.

For more information, see <xref:fundamentals/owin>.

## WebSockets

[WebSocket](https://wikipedia.org/wiki/WebSocket) is a protocol that enables two-way persistent communication channels over TCP connections. It's used for apps such as chat, stock tickers, games, and anywhere you desire real-time functionality in a web app. ASP.NET Core supports web socket features.

For more information, see <xref:fundamentals/websockets>.

::: moniker range=">= aspnetcore-2.1"

## Microsoft.AspNetCore.App metapackage

The [Microsoft.AspNetCore.App](https://www.nuget.org/packages/Microsoft.AspNetCore.App/) metapackage simplifies package management. For more information, see <xref:fundamentals/metapackage-app>.

::: moniker-end

::: moniker range="= aspnetcore-2.0"

## Microsoft.AspNetCore.All metapackage

The [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All) metapackage for ASP.NET Core includes:

* All supported packages from the ASP.NET Core team.
* All supported packages from [Entity Framework Core](/ef/core/).
* Internal and 3rd-party dependencies used by ASP.NET Core and Entity Framework Core.

For more information, see <xref:fundamentals/metapackage>.

::: moniker-end

## .NET Core vs. .NET Framework runtime

An ASP.NET Core app can target the .NET Core or .NET Framework runtime.

For more information, see [Choosing between .NET Core and .NET Framework](/dotnet/articles/standard/choosing-core-framework-server).

## Choose between ASP.NET Core and ASP.NET

For more information on choosing between ASP.NET Core and ASP.NET, see <xref:fundamentals/choose-between-aspnet-and-aspnetcore>.
