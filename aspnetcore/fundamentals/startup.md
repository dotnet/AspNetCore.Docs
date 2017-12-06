---
title: Application startup in ASP.NET Core
author: ardalis
description: Discover how the Startup class in ASP.NET Core configures services and the app's request pipeline. 
keywords: ASP.NET Core,Startup,Configure method,ConfigureServices method
ms.author: tdykstra
manager: wpickett
ms.date: 12/05/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/startup
---
# Application startup in ASP.NET Core

By [Steve Smith](https://ardalis.com), [Tom Dykstra](https://github.com/tdykstra), and [Luke Latham](https://github.com/guardrex)

The `Startup` class configures services and the app's request pipeline.

## The Startup class

ASP.NET Core apps require a `Startup` class, which is named `Startup` by convention. Specify the startup class with the [WebHostBuilderExtensions](/dotnet/api/Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions) [UseStartup<TStartup>](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderextensions.usestartup#Microsoft_AspNetCore_Hosting_WebHostBuilderExtensions_UseStartup__1_Microsoft_AspNetCore_Hosting_IWebHostBuilder_) method.

The `Startup` class:

* Must include a [Configure](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configure) method to create the app's request processing pipeline.
* Can optionally include a [ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configureservices) method to configure the app's services.

`Configure` and `ConfigureServices` are called when the app starts. These methods are described in more detail later in this topic.

The app can define separate `Startup` classes for different environments (for example, `StartupDevelopment` and `StartupProduction`), and the appropriate startup class is selected at runtime. The class whose name suffix matches the current environment is prioritized. If the app is run in the Development environment and includes both a `Startup` class and a `StartupDevelopment` class, the `StartupDevelopment` class is used. See [Working with multiple environments](xref:fundamentals/environments#startup-conventions) for more information.

The `Startup` class constructor can accept dependencies that are provided through [dependency injection (DI)](xref:fundamentals/dependency-injection). A common use of DI with the `Startup` class is to inject [IHostingEnvironment](/dotnet/api/Microsoft.AspNetCore.Hosting.IHostingEnvironment) to set up [configuration sources](xref:fundamentals/configuration/index). See [Hosting: IHostingEnvironment interface](xref:fundamentals/hosting?tabs=aspnetcore2x#ihostingenvironment-interface) for an example.

To learn more about `WebHostBuilder`, see the [Hosting](xref:fundamentals/hosting) topic. For information on handling errors during startup, see [Startup exception handling](xref:fundamentals/error-handling#startup-exception-handling).

## The ConfigureServices method

The [ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configureservices) method, which is optional, is called by the web host before the `Configure` method to configure the app's services. The web host may configure some services before `Startup` methods are called (details are provided in the [Hosting](xref:fundamentals/hosting) topic). By convention, [Configuration options](xref:fundamentals/configuration/index) are set in the `ConfigureServices` method. Adding services to the service container makes them available within the app via [dependency injection](xref:fundamentals/dependency-injection).

For features that require substantial setup, there are `Add[Service]` extension methods on [IServiceCollection](/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection). A typical web app registers services for Entity Framework, Identity, and MVC:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=4,7,11&start=40&end=55)]

## Services available in Startup

ASP.NET Core [dependency injection](xref:fundamentals/dependency-injection) provides services during an app's startup. These services are requested by including the appropriate interface as a parameter on the `Startup` class's constructor or its `Configure` method. The `ConfigureServices` method only takes an `IServiceCollection` parameter. Any registered service can be retrieved from this collection, so additional parameters aren't necessary.

Some of the services typically requested by `Startup` methods:

* In the constructor: `IHostingEnvironment`, `ILogger<Startup>`
* In `ConfigureServices`: `IServiceCollection`
* In `Configure`: `IApplicationBuilder`, `IHostingEnvironment`, `ILoggerFactory`

## The Configure method

The [Configure](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configure) method is used to specify how the app responds to HTTP requests. The request pipeline is configured by adding [middleware](xref:fundamentals/middleware) components to an [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) instance that's provided by [dependency injection](xref:fundamentals/dependency-injection).

A typical web app configures the pipeline with support for [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, ASP.NET MVC, and Identity:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

Each `Use` extension method adds a middleware component to the request pipeline. For instance, the `UseMvc` extension method adds the [routing middleware](xref:fundamentals/routing) to the request pipeline and configures [MVC](xref:mvc/overview) as the default handler.

Additional services, such as `IHostingEnvironment` and `ILoggerFactory`, may also be specified in the method signature. When specified, additional services are injected if they're available.

For more information on how to use `IApplicationBuilder`, see [Middleware](xref:fundamentals/middleware).

## Startup filters

Use [IStartupFilter](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter) to configure middleware at the beginning or end of an app's [Configure](#the-configure-method) middleware pipeline.

`IStartupFilter` implements a single method, [Configure](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter.configure), which receives and returns an `Action<IApplicationBuilder>`. An [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) defines a class to configure an app's request pipeline. For more information, see [Creating a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware#creating-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implements one or more middlewares in the request pipeline. The middlewares are invoked in the order that the `IStartupFilter` implementations are added to the service container.

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/startup/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates how to register a middleware with `IStartupFilter`. The sample app includes a middleware that sets an options value from a query string parameter:

[!code-csharp[Main](startup/sample/RequestSetOptionsMiddleware.cs?name=snippet1)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[Main](startup/sample/RequestSetOptionsStartupFilter.cs?name=snippet1&highlight=7)]

The `IStartupFilter` is registered in the service container in `ConfigureServices`:

[!code-csharp[Main](startup/sample/Startup.cs?name=snippet1&highlight=3)]

When the app is run and a query string parameter for `option` is provided, the middleware processes the value assignment before the MVC middleware renders the response:

![Browser window showing the rendered Index page. The value of Option is rendered as 'From Middleware' based on requesting the page with the query string parameter and value of option set to 'From Middleware'.](startup/_static/index.png)

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`, position the service registration before the library is added to the service container. To invoke it afterward, position the service registration after the library is added.
* Middleware specified with `IStartupFilter` may short-circuit requests before higher priority middleware runs. Register the `IStartupFilter` for the short-circuited middleware earlier in the service registrations to ensure that it runs before short-circuiting can occur.

## Additional Resources

* [Hosting](xref:fundamentals/hosting)
* [Working with Multiple Environments](xref:fundamentals/environments)
* [Middleware](xref:fundamentals/middleware)
* [Logging](xref:fundamentals/logging/index)
* [Configuration](xref:fundamentals/configuration/index)
* [StartupLoader class: FindStartupType method (reference source)](https://github.com/aspnet/Hosting/blob/rel/2.0.0/src/Microsoft.AspNetCore.Hosting/Internal/StartupLoader.cs#L66-L116))
