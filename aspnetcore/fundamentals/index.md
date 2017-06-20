---
title: ASP.NET Core fundamentals | Microsoft Docs
author: rick-anderson
description: Overview of fundamental concpepts in ASP.NET Core.
keywords: ASP.NET Core, fundamentals, overview
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: get-started-article
ms.assetid: a19b7836-63e4-44e8-8250-50d426dd1070
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/index
ms.custom: H1Hack27Feb2017
---

# ASP.NET Core fundamentals overview

An ASP.NET Core app is simply a console app that creates a web server in its `Main` method:

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

`Main` uses `WebHostBuilder`, which follows the builder pattern, to create a web application host. The builder has methods that define the web server (for example `UseKestrel`) and the startup class (`UseStartup`). In the example above, the [Kestrel](servers/kestrel.md) web server is used, but other web servers can be specified. We'll show more about `UseStartup` in the next section. `WebHostBuilder` provides many optional methods, including `UseIISIntegration` for hosting in IIS and IIS Express, and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` object that will host the app and start it listening for incoming HTTP requests.

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app.

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

The `Startup` class is where you define the request handling pipeline and where any services needed by the app are configured. The `Startup` class must be public and contain the following methods:

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IApplicationBuilder app)
    {
    }
}
```

* `ConfigureServices` defines the services (see [Services](#services) below) used by your app (such as the ASP.NET Core MVC framework, Entity Framework Core, Identity, etc.)

* `Configure` defines the [middleware](middleware.md) in the request pipeline

For more information, see [Application startup](startup.md).

## Services

A service is a component that is intended for common consumption in an application. Services are made available through dependency injection (DI). ASP.NET Core includes a simple built-in inversion of control (IoC) container that supports constructor injection by default. The built-in container can be easily replaced with your container of choice. In addition to its loose coupling benefit, DI makes services available throughout your app. For example, [logging](logging.md) is available throughout your app.

For more information, see [Dependency injection](dependency-injection.md) .

## Middleware

In ASP.NET Core you compose your request pipeline using [Middleware](middleware.md). ASP.NET Core middleware performs asynchronous logic on an `HttpContext` and then either invokes the next middleware in the sequence or terminates the request directly. You generally "Use" middleware by taking a dependency on a NuGet package and invoking a corresponding `UseXYZ` extension method on the `IApplicationBuilder` in the `Configure` method.

ASP.NET Core comes with a rich set of built-in middleware:

* [Static files](static-files.md)

* [Routing](routing.md)

* [Authentication](../security/authentication/index.md)

You can use any [OWIN](http://owin.org)-based middleware with ASP.NET Core, and you can write your own custom middleware.

For more information, see [Middleware](middleware.md) and [Open Web Interface for .NET (OWIN)](owin.md).

## Servers

The ASP.NET Core hosting model does not directly listen for requests; rather it relies on an HTTP server implementation to forward the request to the application. The forwarded request is wrapped as a set of feature interfaces that the application then composes into an `HttpContext`.  ASP.NET Core includes a managed cross-platform web server, called [Kestrel](servers/kestrel.md) that you would typically run behind a production web server like [IIS](https://iis.net) or [nginx](http://nginx.org).

For more information, see [Servers](servers/index.md) and [Hosting](hosting.md).

## Content root

The content root is the base path to any content used by the app, such as its views and web content. By default the content root is the same as application base path for the executable hosting the app; an alternative location can be specified with *WebHostBuilder*.

## Web root

The web root of your app is the directory in your project for public, static resources like css, js, and image files. The static files middleware will only serve files from the web root directory (and sub-directories) by default. The web root path defaults to *<content root>/wwwroot*, but you can specify a different location using the *WebHostBuilder*.

## Configuration

ASP.NET Core uses a new configuration model for handling simple name-value pairs. The new configuration model is not based on `System.Configuration` or *web.config*; rather, it pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

For more information, see [Configuration](configuration.md).

## Environments

Environments, like "Development" and "Production", are a first-class notion in ASP.NET Core and can  be set using environment variables.

For more information, see [Working with Multiple Environments](environments.md).

## .NET Core vs. .NET Framework runtime

An ASP.NET Core app can use the .NET Core or .NET Framework runtime. For more information, see [Choosing between .NET Core and .NET Framework](https://docs.microsoft.com/dotnet/articles/standard/choosing-core-framework-server).

## Additional information

See also the following topics:

- [Logging](logging.md)
- [Error Handling](error-handling.md)
- [Globalization and localization](localization.md)
- [File Providers](file-providers.md)
- [Managing Application State](app-state.md)
