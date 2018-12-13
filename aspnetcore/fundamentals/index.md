---
title: ASP.NET Core fundamentals
author: rick-anderson
description: Discover the foundational concepts for building ASP.NET Core apps.
ms.author: riande
ms.custom: mvc
ms.date: 12/01/2018
uid: fundamentals/index
---
# ASP.NET Core fundamentals

An ASP.NET Core app is a console app that creates a web server in its `Program.Main` method. The `Main` method is the app's *managed entry point*:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](index/snapshots/2.x/Program.cs)]

The .NET Core Host:

* Loads the [.NET Core runtime](https://github.com/dotnet/coreclr).
* Uses the first command-line argument as the path to the managed binary that contains the entry point (`Main`) and begins code execution.

The `Main` method invokes [WebHost.CreateDefaultBuilder](xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder*), which follows the [builder pattern](https://wikipedia.org/wiki/Builder_pattern) to create a web host. The builder has methods that define a web server (for example, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel*>) and the startup class (<xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup*>). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is automatically allocated. ASP.NET Core's web host attempts to run on [Internet Information Services (IIS)](https://www.iis.net/), if available. Other web servers, such as [HTTP.sys](xref:fundamentals/servers/httpsys), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the [Startup](#startup) section.

<xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>, the return type of the `WebHost.CreateDefaultBuilder` invocation, provides many optional methods. Some of these methods include `UseHttpSys` for hosting the app in HTTP.sys and <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseContentRoot*> for specifying the root content directory. The <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder.Build*> and <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.Run*> methods build the <xref:Microsoft.AspNetCore.Hosting.IWebHost> object that hosts the app and begins listening for HTTP requests.

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](index/snapshots/1.x/Program.cs)]

The .NET Core Host:

* Loads the [.NET Core runtime](https://github.com/dotnet/coreclr).
* Uses the first command-line argument as the path to the managed binary that contains the entry point (`Main`) and begins code execution.

The `Main` method uses <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder>, which follows the [builder pattern](https://wikipedia.org/wiki/Builder_pattern) to create a web app host. The builder has methods that define the web server (for example, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderKestrelExtensions.UseKestrel*>) and the startup class (<xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup*>). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is used. Other web servers, such as [HTTP.sys](xref:fundamentals/servers/httpsys), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`WebHostBuilder` provides many optional methods, including <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderIISExtensions.UseIISIntegration*> for hosting in IIS and IIS Express and <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.UseContentRoot*> for specifying the root content directory. The <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder.Build*> and <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.Run*> methods build the <xref:Microsoft.AspNetCore.Hosting.IWebHost> object that hosts the app and begins listening for HTTP requests.

::: moniker-end

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](index/snapshots/2.x/Program.cs?highlight=10)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](index/snapshots/1.x/Program.cs?highlight=7)]

::: moniker-end

The `Startup` class is where you define the request handling pipeline and where any services needed by the app are configured. The `Startup` class must be public and contain the following methods:

::: moniker range=">= aspnetcore-2.0"

[!code-csharp[](index/snapshots/2.x/Startup.cs)]

::: moniker-end

::: moniker range="< aspnetcore-2.0"

[!code-csharp[](index/snapshots/1.x/Startup.cs)]

::: moniker-end

<xref:Microsoft.AspNetCore.Hosting.IStartup.ConfigureServices*> defines the [Services](#dependency-injection-services) used by your app (for example, ASP.NET Core MVC, Entity Framework Core, Identity). <xref:Microsoft.AspNetCore.Hosting.IStartup.Configure*> defines the [middleware](xref:fundamentals/middleware/index) called in the request pipeline.

For more information, see <xref:fundamentals/startup>.

## Content root

The content root is the base path to any content used by the app, such as [Razor Pages](xref:razor-pages/index), MVC views, and static assets. By default, the content root is the same location as the app base path for the executable hosting the app.

## Web root (webroot)

The webroot of an app is the directory in the project containing public, static resources, such as CSS, JavaScript, and image files. By default, *wwwroot* is the webroot.

For Razor (*.cshtml*) files, the tilde-slash  `~/` points to the webroot. Paths beginning with `~/` are referred to as virtual paths.

## Dependency injection (services)

A *service* is a component that's intended for common consumption in an app. Services are made available through [dependency injection (DI)](xref:fundamentals/dependency-injection). ASP.NET Core includes a native Inversion of Control (IoC) container that supports [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) by default. You can replace the default container if you wish. In addition to its [loose coupling benefit](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#encapsulation), DI makes services, such as [logging](xref:fundamentals/logging/index), available throughout your app.

For more information, see <xref:fundamentals/dependency-injection>.

## Middleware

In ASP.NET Core, you compose your request pipeline using [middleware](xref:fundamentals/middleware/index). ASP.NET Core middleware performs asynchronous operations on an `HttpContext` and then either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component called "XYZ" is added to the pipeline by invoking a `UseXYZ` extension method in the `Configure` method.

ASP.NET Core includes a rich set of built-in middleware, and you can write your own custom middleware. [Open Web Interface for .NET (OWIN)](xref:fundamentals/owin), which allows web apps to be decoupled from web servers, is supported in ASP.NET Core apps.

For more information, see <xref:fundamentals/middleware/index> and <xref:fundamentals/owin>.

::: moniker range=">= aspnetcore-2.1"

## Initiate HTTP requests

<xref:System.Net.Http.IHttpClientFactory> is available to access <xref:System.Net.Http.HttpClient> instances to make HTTP requests.

For more information, see <xref:fundamentals/http-requests>.

::: moniker-end

## Environments

Environments, such as *Development* and *Production*, are a first-class notion in ASP.NET Core and can be set using an environment variable, settings file, and command-line argument.

For more information, see <xref:fundamentals/environments>.

## Hosting

ASP.NET Core apps configure and launch a *host*, which is responsible for app startup and lifetime management.

For more information, see <xref:fundamentals/host/index>.

## Servers

The ASP.NET Core hosting model doesn't directly listen for requests. The hosting model relies on an HTTP server implementation to forward the request to the app.

::: moniker range=">= aspnetcore-2.2"

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* [Kestrel](xref:fundamentals/servers/kestrel) server is a managed, cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.
* IIS HTTP Server (`IISHttpServer`) is an [IIS in-process server](xref:host-and-deploy/aspnet-core-module#in-process-hosting-model).
* [HTTP.sys](xref:fundamentals/servers/httpsys) server is a web server for ASP.NET Core on Windows.

# [macOS](#tab/macos)

ASP.NET Core uses the [Kestrel](xref:fundamentals/servers/kestrel) server implementation. Kestrel is a managed, cross-platform web server. Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.

# [Linux](#tab/linux)

ASP.NET Core uses the [Kestrel](xref:fundamentals/servers/kestrel) server implementation. Kestrel is a managed, cross-platform web server. Kestrel is often run in a reverse proxy configuration with [Nginx](http://nginx.org) or [Apache](https://httpd.apache.org/). Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.

---

::: moniker-end

::: moniker range="< aspnetcore-2.2"

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* [Kestrel](xref:fundamentals/servers/kestrel) server is a managed, cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.
* [HTTP.sys](xref:fundamentals/servers/httpsys) server is a web server for ASP.NET Core on Windows.

# [macOS](#tab/macos)

ASP.NET Core uses the [Kestrel](xref:fundamentals/servers/kestrel) server implementation. Kestrel is a managed, cross-platform web server. Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.

# [Linux](#tab/linux)

ASP.NET Core uses the [Kestrel](xref:fundamentals/servers/kestrel) server implementation. Kestrel is a managed, cross-platform web server. Kestrel is often run in a reverse proxy configuration with [Nginx](http://nginx.org) or [Apache](https://httpd.apache.org/). Kestrel can also be run as a public-facing edge server exposed directly to the Internet in ASP.NET Core 2.0 or later.

---

::: moniker-end

For more information, see <xref:fundamentals/servers>.

## Configuration

ASP.NET Core uses a configuration model based on name-value pairs. The configuration model isn't based on <xref:System.Configuration> or *web.config*. Configuration obtains settings from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI), environment variables, and command-line arguments. You can also write your own custom configuration providers.

For more information, see <xref:fundamentals/configuration/index>.

## Logging

ASP.NET Core supports a Logging API that works with a variety of logging providers. Built-in providers support sending logs to one or more destinations. Third-party logging frameworks can be used.

For more information, see <xref:fundamentals/logging/index>.

## Error handling

ASP.NET Core has built-in scenarios for handling errors in apps, including a developer exception page, custom error pages, static status code pages, and startup exception handling.

For more information, see <xref:fundamentals/error-handling>.

## Routing

ASP.NET Core offers scenarios for routing of app requests to route handlers.

For more information, see <xref:fundamentals/routing>.

## Background tasks

Background tasks are implemented as *hosted services*. A hosted service is a class with background task logic that implements the <xref:Microsoft.Extensions.Hosting.IHostedService> interface.

For more information, see <xref:fundamentals/host/hosted-services>.

## Access HttpContext

`HttpContext` is automatically available when processing requests with Razor Pages and MVC. In circumstances where `HttpContext` isn't readily available, you can access the `HttpContext` through the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface and its default implementation, <xref:Microsoft.AspNetCore.Http.HttpContextAccessor>.

For more information, see <xref:fundamentals/httpcontext>.
