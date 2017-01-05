---
title: Application Startup | Microsoft Docs
author: ardalis
description: Explains the Startup class in ASP.NET Core.
keywords: ASP.NET Core, Startup, Configure method, ConfigureServices method
ms.author: tdykstra
manager: wpickett
ms.date: 11/29/2016
ms.topic: article
ms.assetid: 6538df00-4ec2-45e4-811a-d7ce2ee608ed
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/startup
---
# Application Startup

By [Steve Smith](http://ardalis.com) and [Tom Dykstra](https://github.com/tdykstra/)

The `Startup` class configures the request pipeline that handles all requests made to the application.

## The Startup class

All ASP.NET applications require at least one `Startup` class. When an application starts, ASP.NET searches the primary assembly for a class named `Startup` (in any namespace). You can specify a different assembly to search using the *Hosting:Application* configuration key. The class doesn't have to be `public`. If there are multiple `Startup` classes, ASP.NET looks for one in the project's root namespace, otherwise it chooses one in the alphabetically first namespace.

You can define separate `Startup` classes for different environments, and the appropriate one will be selected at runtime. Learn more in [Working with multiple environments](environments.md#startup-conventions).

The `Startup` class constructor can accept dependencies that are provided through [dependency injection](dependency-injection.md). You can use `IHostingEnvironment` to set up [configuration](configuration.md) sources and `ILoggerFactory` to set up [logging](logging.md) providers. 

The `Startup` class must include a `Configure` method and can optionally include a `ConfigureServices` method, both of which are called when the application starts. The class can also include [environment-specific versions of these methods](environments.md#startup-conventions).

Learn about [handling exceptions during application startup](error-handling.md#startup-exception-handling).

## The Configure method

The `Configure` method is used to specify how the ASP.NET application will respond to HTTP requests. The request pipeline is configured by adding [middleware](middleware.md) components to an `IApplicationBuilder` instance that is provided by dependency injection.

In the following example from the default web site template, several extension methods are used to configure the pipeline with support for [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, ASP.NET MVC, and Identity.

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

Each `Use` extension method adds a [middleware](middleware.md) component to the request pipeline. For instance, the `UseMvc` extension method adds the [routing](routing.md) middleware to the request pipeline and configures [MVC](../mvc/index.md) as the default handler.

For more information about how to use `IApplicationBuilder`, see [Middleware](middleware.md).

Additional services, like `IHostingEnvironment` and `ILoggerFactory` may also be specified in the method signature, in which case these services will be [injected](dependency-injection.md) if they are available. 

## The ConfigureServices method

The `Startup` class can include a `ConfigureServices` method that takes an `IServiceCollection` parameter and optionally returns an `IServiceProvider`. The `ConfigureServices` method is called before `Configure`, as some features must be added before they can be wired up to the request pipeline.

For features that require substantial setup there are `Add[Something]` extension methods on `IServiceCollection`. This example from the default web site template configures the app to use services for Entity Framework, Identity, and MVC:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=4,7,11&start=40&end=55)]

Adding services to the services container makes them available within your application via [dependency injection](dependency-injection.md).

The `ConfigureServices` method is also where you should add configuration option classes. Learn more in [Configuration](configuration.md).

## Services Available in Startup

ASP.NET Core dependency injection provides application services during an application's startup. You can request these services by including the appropriate interface as a parameter on your `Startup` class's constructor or one of its `Configure` or `ConfigureServices` methods. 

Looking at each method in the `Startup` class in the order in which they are called, the following services may be requested as parameters:

* In the constructor:  `IHostingEnvironment`, `ILoggerFactory`

* In the `ConfigureServices` method:  `IServiceCollection`

* In the `Configure` method:  `IApplicationBuilder`, `IHostingEnvironment`, `ILoggerFactory`

## Additional Resources

* [Working with Multiple Environments](environments.md)
* [Middleware](middleware.md)
* [Logging](logging.md)
* [Configuration](configuration.md)
