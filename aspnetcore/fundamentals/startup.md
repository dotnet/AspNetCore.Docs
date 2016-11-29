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

By [Steve Smith](http://ardalis.com)

The `Startup` class configures the request pipeline that handles all requests made to the application.

## The Startup class

All ASP.NET applications require at least one `Startup` class. When an application starts, ASP.NET searches the primary assembly for a class named `Startup` (in any namespace). You can specify a different assembly to search using the *Hosting:Application* configuration key. It doesn't matter whether the class is defined as `public`; ASP.NET will still load it if it conforms to the naming convention. If there are multiple `Startup` classes, ASP.NET selects one based on its namespace (matching the project's root namespace first, otherwise using the class in the alphabetically first namespace).

You can define separate `Startup` classes for different environments, and the appropriate one will be selected at runtime. Learn more in [Working with multiple environments](environments.md#startup-conventions).

The `Startup` class constructor can accept dependencies that are provided through [dependency injection](dependency-injection.md). You can use `IHostingEnvironment` to set up [configuration](configuration.md) sources and `ILoggerFactory` to set up [logging](logging.md) providers. 

The `Startup` class must include a `Configure` method and can optionally include a `ConfigureServices` method, both of which are called when the application starts. The class can also include [environment-specific versions of these methods](environments.md#startup-conventions).

## The Configure method

The `Configure` method is used to specify how the ASP.NET application will respond to HTTP requests. The request pipeline is configured by adding [middleware](middleware.md) components to an `IApplicationBuilder` instance that is provided by dependency injection.

In the following example from the default web site template, several extension methods are used to configure the pipeline with support for [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, ASP.NET MVC, and Identity.

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=86)]

Each `Use` extension method adds a [middleware](middleware.md) component to the request pipeline. For instance, the `UseMvc` extension method adds the [routing](routing.md) middleware to the request pipeline and configures [MVC](../mvc/index.md) as the default handler.

For more information about how to use `IApplicationBuilder`, see [Middleware](middleware.md).

Additional services, like `IHostingEnvironment` and `ILoggerFactory` may also be specified in the method signature, in which case these services will be [injected](dependency-injection.md) if they are available. 

## The ConfigureServices method

The `Startup` class can include a `ConfigureServices` method. This is a public method on the `Startup` class that takes an `IServiceCollection` instance as a parameter and optionally returns an `IServiceProvider`. The `ConfigureServices` method is called before `Configure`. This is necessary because some features like ASP.NET MVC require certain services to be added in `ConfigureServices` before they can be wired up to the request pipeline.

For features that require substantial setup there are `Add[Something]` extension methods on `IServiceCollection`. This example from the default web site template configures the app to use services for Entity Framework, Identity, and MVC:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=4,7,11&start=40&end=55)]

Adding services to the services container makes them available within your application via [dependency injection](dependency-injection.md).

The `ConfigureServices` method is also where you should add configuration option classes that you would like to have available in your application. See the [Configuration](configuration.md) topic to learn more about configuring options.

## Services Available in Startup

ASP.NET Core provides certain application services and objects during an application's startup. You can request certain sets of these services by simply including the appropriate interface as a parameter on your `Startup` class's constructor or one of its `Configure` or `ConfigureServices` methods. The services available to each method in the `Startup` class are described below.

* **IApplicationBuilder**

  Used to build the application request pipeline. Available only to the `Configure` method in `Startup`. Learn more about [Middleware](middleware.md).

* **IHostingEnvironment**

  Provides the current `EnvironmentName`, `ContentRootPath`, `WebRootPath`, and web root file provider. Available to the `Startup` constructor and `Configure` method.

* **ILoggerFactory**

  Provides a mechanism for creating loggers and adding logging providers. Available to the `Startup` constructor and `Configure` method. Learn more about [Logging](logging.md).

* **IServiceCollection**

  The current set of services configured in the container. Available only to the `ConfigureServices` method, and used by that method to configure the services available to an application.

Looking at each method in the `Startup` class in the order in which they are called, the following services may be requested as parameters:

* In the constructor:  `IHostingEnvironment`, `ILoggerFactory`

* In the `ConfigureServices` method:  `IServiceCollection`

* In the `Configure` method:  `IApplicationBuilder`, `IHostingEnvironment`, `ILoggerFactory`

## Additional Resources

* [Working with Multiple Environments](environments.md)

* [Middleware](middleware.md)

* [Logging](logging.md)

* [Configuration](configuration.md)