---
title: ASP.NET Core fundamentals
author: rick-anderson
description: This article provides a high-level overview of the foundational concepts to be understood when building ASP.NET Core applications.
keywords: ASP.NET Core,fundamentals,overview
ms.author: riande
manager: wpickett
ms.date: 08/18/2017
ms.topic: get-started-article
ms.assetid: a19b7836-63e4-44e8-8250-50d426dd1070
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/index
ms.custom: H1Hack27Feb2017
---

# ASP.NET Core fundamentals overview

An ASP.NET Core application is a console app that creates a web server in its `Main` method:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs)]

The `Main` method invokes `WebHost.CreateDefaultBuilder`, which follows the builder pattern to create a web application host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, a [Kestrel](xref:fundamentals/servers/kestrel) web server is automatically allocated. ASP.NET Core's web host will attempt to run on IIS, if it is available. Other web servers, such as [HTTP.sys](xref:fundamentals/servers/httpsys), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`IWebHostBuilder`, the return type of the `WebHost.CreateDefaultBuilder` invocation, provides many optional methods. Some of these methods include `UseHttpSys` for hosting the application in HTTP.sys, and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that will host the application and begin listening for HTTP requests.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

The `Main` method uses `WebHostBuilder`, which follows the builder pattern to create a web application host. The builder has methods that define the web server (for example, `UseKestrel`) and the startup class (`UseStartup`). In the preceding example, the [Kestrel](xref:fundamentals/servers/kestrel) web server is used. Other web servers, such as [WebListener](xref:fundamentals/servers/weblistener), can be used by invoking the appropriate extension method. `UseStartup` is explained further in the next section.

`WebHostBuilder` provides many optional methods, including `UseIISIntegration` for hosting in IIS and IIS Express, and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that will host the application and begin listening for HTTP requests.

---

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program2x.cs?highlight=10&range=6-17)]

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

---

The `Startup` class is where you define the request handling pipeline and where any services needed by the application are configured. The `Startup` class must be public and contain the following methods:

```csharp
public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
    }
}
```

* `ConfigureServices` defines the [Services](#services) used by your application (such as ASP.NET Core MVC, Entity Framework Core, Identity, etc.).

* `Configure` defines the [middleware](xref:fundamentals/middleware) in the request pipeline.

For more information, see [Application startup](xref:fundamentals/startup).

## Services

A service is a component that is intended for common consumption in an application. Services are made available through [dependency injection](xref:fundamentals/dependency-injection) (DI). ASP.NET Core includes a native inversion of control (IoC) container that supports [constructor injection](xref:mvc/controllers/dependency-injection#constructor-injection) by default. The native container can be replaced with your container of choice. In addition to its loose coupling benefit, DI makes services available throughout your application. For example, [logging](xref:fundamentals/logging) is available throughout your application.

For more information, see [Dependency injection](xref:fundamentals/dependency-injection).

## Middleware

In ASP.NET Core, you compose your request pipeline using [Middleware](xref:fundamentals/middleware). ASP.NET Core middleware performs asynchronous logic on an `HttpContext` and then either invokes the next middleware in the sequence or terminates the request directly. A middleware component called "XYZ" is added by invoking a `UseXYZ` extension method in the `Configure` method.

ASP.NET Core comes with a rich set of built-in middleware:

* [Static files](xref:fundamentals/static-files)

* [Routing](xref:fundamentals/routing)

* [Authentication](xref:security/authentication/index)

You can use any [OWIN](http://owin.org)-based middleware with ASP.NET Core, and you can write your own custom middleware.

For more information, see [Middleware](xref:fundamentals/middleware) and [Open Web Interface for .NET (OWIN)](xref:fundamentals/owin).

## Servers

The ASP.NET Core hosting model does not directly listen for requests; rather, it relies on an HTTP server implementation to forward the request to the application. The forwarded request is wrapped as a set of feature objects that you can access through interfaces. The application composes this set into an `HttpContext`. ASP.NET Core includes a managed, cross-platform web server, called [Kestrel](xref:fundamentals/servers/kestrel). Kestrel is typically run behind a production web server like [IIS](https://www.iis.net/) or [nginx](http://nginx.org).

For more information, see [Servers](xref:fundamentals/servers/index) and [Hosting](xref:fundamentals/hosting).

## Content root

The content root is the base path to any content used by the app, such as views, [Razor Pages](xref:mvc/razor-pages/index), and static assets. By default, the content root is the same as application base path for the executable hosting the application. An alternative location for content root is specified with `WebHostBuilder`.

## Web root

The web root of an application is the directory in the project containing public, static resources like CSS, JavaScript, and image files. By default, the static files middleware will only serve files from the web root directory and its sub-directories. See [working with static files](xref:fundamentals/static-files) for more info. The web root path defaults to */wwwroot*, but you can specify a different location using the `WebHostBuilder`.

## Configuration

ASP.NET Core uses a new configuration model for handling simple name-value pairs. The new configuration model is not based on `System.Configuration` or *web.config*; rather, it pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

For more information, see [Configuration](xref:fundamentals/configuration).

## Environments

Environments, like "Development" and "Production", are a first-class notion in ASP.NET Core and can be set using environment variables.

For more information, see [Working with Multiple Environments](xref:fundamentals/environments).

## .NET Core vs. .NET Framework runtime

An ASP.NET Core application can target the .NET Core or .NET Framework runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Additional information

See also the following topics:

- [Error Handling](xref:fundamentals/error-handling)
- [File Providers](xref:fundamentals/file-providers)
- [Globalization and localization](xref:fundamentals/localization)
- [Logging](xref:fundamentals/logging)
- [Managing Application State](xref:fundamentals/app-state)
