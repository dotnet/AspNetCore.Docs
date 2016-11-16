---
title: Introduction to ASP.NET Core
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 1837c35d-2c24-493f-acf4-a07bf7db9bd9
ms.prod: aspnet-core
uid: intro
---
# Introduction to ASP.NET Core

By [Daniel Roth](https://github.com/danroth27), [Rick Anderson](https://twitter.com/RickAndMSFT) and [Shaun Luttin](https://twitter.com/dicshaunary)

ASP.NET Core is a significant redesign of ASP.NET. This topic introduces the new concepts in ASP.NET Core and explains how they help you develop modern web apps.

## What is ASP.NET Core?

ASP.NET Core is a new open-source and cross-platform framework for building modern cloud based internet connected applications, such as web apps, IoT apps and mobile backends. ASP.NET Core apps can run on [.NET Core](https://www.microsoft.com/net/core/platform) or on the full .NET Framework. It was architected to provide an optimized development framework for apps that are deployed to the cloud or run on-premises. It consists of modular components with minimal overhead, so you retain flexibility while constructing your solutions. You can develop and run your ASP.NET Core apps cross-platform on Windows, Mac and Linux. ASP.NET Core is open source at [GitHub](https://github.com/aspnet/home).

## Why build ASP.NET Core?

The first preview release of ASP.NET came out almost 15 years ago as part of the .NET Framework.  Since then millions of developers have used it to build and run great web apps, and over the years we have added and evolved many capabilities to it.

ASP.NET Core has a number of architectural changes that result in a much leaner and modular framework.  ASP.NET Core is no longer based on *System.Web.dll*. It is based on a set of granular and well factored [NuGet](http://www.nuget.org/) packages. This allows you to optimize your app to include just the NuGet packages you need. The benefits of a smaller app surface area include tighter security, reduced servicing, improved performance, and decreased costs in a pay-for-what-you-use model.

With ASP.NET Core you gain the following foundational improvements:

* A unified story for building web UI and web APIs

* Integration of [modern client-side frameworks](../client-side/index.md) and development workflows

* A cloud-ready environment-based [configuration system](../fundamentals/configuration.md)

* Built-in [dependency injection](../fundamentals/dependency-injection.md)

* New light-weight and modular HTTP request pipeline

* Ability to host on IIS or self-host in your own process

* Built on [.NET Core](https://microsoft.com/net/core), which supports true side-by-side app versioning

* Ships entirely as [NuGet](https://nuget.org)  packages

* New tooling that simplifies modern web development

* Build and run cross-platform ASP.NET apps on Windows, Mac and Linux

* Open source and community focused

## Application anatomy

An ASP.NET Core app is simply a console app that creates a web server in its `Main` method:

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs)]

`Main` uses `WebHostBuilder`, which follows the builder pattern, to create a web application host. The builder has methods that define the web server (for example `UseKestrel`) and the startup class (`UseStartup`). In the example above, the Kestrel web server is used, but other web servers can be specified. We'll show more about `UseStartup` in the next section. `WebHostBuilder` provides many optional methods including `UseIISIntegration` for hosting in IIS and IIS Express and `UseContentRoot` for specifying the root content directory. The `Build` and `Run` methods build the `IWebHost` that will host the app and start it listening for incoming HTTP requests.

## Startup

The `UseStartup` method on `WebHostBuilder` specifies the `Startup` class for your app.

[!code-csharp[Main](../getting-started/sample/aspnetcoreapp/Program.cs?highlight=7&range=6-17)]

The `Startup` class is where you define the request handling pipeline and where any services needed by the app are configured. The `Startup` class must be public and contain the following methods:

````csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IApplicationBuilder app)
    {
    }
}
````

* `ConfigureServices` defines the services (see [Services](#services) below) used by your app (such as the ASP.NET MVC Core framework, Entity Framework Core, Identity, etc.)

* `Configure` defines the [middleware](../fundamentals/middleware.md) in the request pipeline

* See [Application Startup](../fundamentals/startup.md) for more details

## Services

A service is a component that is intended for common consumption in an application. Services are made available through dependency injection. ASP.NET Core includes a simple built-in inversion of control (IoC) container that supports constructor injection by default, but can be easily replaced with your IoC container of choice. In addition to its loose coupling benefit, DI makes services available throughout your app. For example, [Logging](../fundamentals/logging.md) is available throughout your app. See [Dependency Injection](../fundamentals/dependency-injection.md) for more details.

## Middleware

In ASP.NET Core you compose your request pipeline using [Middleware](../fundamentals/middleware.md). ASP.NET Core middleware performs asynchronous logic on an `HttpContext` and then either invokes the next middleware in the sequence or terminates the request directly. You generally "Use" middleware by taking a dependency on a NuGet package and invoking a corresponding `UseXYZ` extension method on the `IApplicationBuilder` in the `Configure` method.

ASP.NET Core comes with a rich set of prebuilt middleware:

* [Static files](../fundamentals/static-files.md)

* [Routing](../fundamentals/routing.md)

* [Authentication](../security/authentication/index.md)

You can also author your own [custom middleware](../fundamentals/middleware.md).

You can use any [OWIN](http://owin.org)-based middleware with ASP.NET Core. See [Open Web Interface for .NET (OWIN)](../fundamentals/owin.md) for details.

## Servers

The ASP.NET Core hosting model does not directly listen for requests; rather it relies on an HTTP [server](../fundamentals/servers.md) implementation to forward the request to the application. The forwarded request is wrapped as a set of feature interfaces that the application then composes into an `HttpContext`.  ASP.NET Core includes a managed cross-platform web server, called [Kestrel](../fundamentals/servers.md#kestrel), that you would typically run behind a production web server like [IIS](https://iis.net) or [nginx](http://nginx.org).

<a name=content-root-lbl></a>

## Content root

The content root is the base path to any content used by the app, such as its views and web content. By default the content root is the same as application base path for the executable hosting the app; an alternative location can be specified with *WebHostBuilder*.

<a name=web-root-lbl></a>

## Web root

The web root of your app is the directory in your project for public, static resources like css, js, and image files. The static files middleware will only serve files from the web root directory (and sub-directories) by default. The web root path defaults to *<content root>/wwwroot*, but you can specify a different location using the *WebHostBuilder*.

## Configuration

ASP.NET Core uses a new configuration model for handling simple name-value pairs. The new configuration model is not based on `System.Configuration` or *web.config*; rather, it pulls from an ordered set of configuration providers. The built-in configuration providers support a variety of file formats (XML, JSON, INI) and environment variables to enable environment-based configuration. You can also write your own custom configuration providers.

See [Configuration](../fundamentals/configuration.md) for more information.

## Environments

Environments, like "Development" and "Production", are a first-class notion in ASP.NET Core and can  be set using environment variables. See [Working with Multiple Environments](../fundamentals/environments.md) for more information.

## Build web UI and web APIs using ASP.NET Core MVC

* You can create well-factored and testable web apps that follow the Model-View-Controller (MVC) pattern. See [MVC](../mvc/index.md) and [Testing](../testing/index.md).

* You can build HTTP services that support multiple formats and have full support for content negotiation. See [Formatting Response Data](../mvc/models/formatting.md)

* [Razor](http://www.asp.net/web-pages/overview/getting-started/introducing-razor-syntax-c) provides a productive language to create [Views](../mvc/views/index.md)

* [Tag Helpers](../mvc/views/tag-helpers/intro.md) enable server-side code to participate in creating and rendering HTML elements in Razor files

* You can create HTTP services with full support for content negotiation using custom or built-in formatters (JSON, XML)

* [Model Binding](../mvc/models/model-binding.md) automatically maps data from HTTP requests to action method parameters

* [Model Validation](../mvc/models/validation.md) automatically performs client and server side validation

## Client-side development

ASP.NET Core is designed to integrate seamlessly with a variety of client-side frameworks, including [AngularJS](../client-side/angular.md), [KnockoutJS](../client-side/knockout.md) and [Bootstrap](../client-side/bootstrap.md). See [Client-Side Development](../client-side/index.md) for more details.

## Next steps

* [Building your first ASP.NET Core MVC app with Visual Studio](../tutorials/first-mvc-app/index.md)

* [Your First ASP.NET Core Application on a Mac Using Visual Studio Code](../tutorials/your-first-mac-aspnet.md)

* [Building Your First Web API with ASP.NET Core MVC and Visual Studio](../tutorials/first-web-api.md)

* [Fundamentals](../fundamentals/index.md)
