---
title: Application startup in ASP.NET Core
author: ardalis
description: Discover how the Startup class in ASP.NET Core configures services and the application's request pipeline. 
keywords: ASP.NET Core,Startup,Configure method,ConfigureServices method
ms.author: tdykstra
manager: wpickett
ms.date: 02/29/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/startup
---
# Application startup in ASP.NET Core

By [Steve Smith](https://ardalis.com), [Tom Dykstra](https://github.com/tdykstra), and [Luke Latham](https://github.com/guardrex)

The `Startup` class configures services and the application's request pipeline.

## The Startup class

ASP.NET Core apps require a `Startup` class, which is named `Startup` by convention. Specify the startup class name in the `Main` program's [WebHostBuilderExtensions](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.webhostbuilderextensions) [`UseStartup<TStartup>`](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.webhostbuilderextensions#Microsoft_AspNetCore_Hosting_WebHostBuilderExtensions_UseStartup__1_Microsoft_AspNetCore_Hosting_IWebHostBuilder_) method. See [Hosting](xref:fundamentals/hosting) to learn more about `WebHostBuilder`, which runs before `Startup`.

The app can define separate `Startup` classes for different environments, and the appropriate startup class is selected at runtime. If `startupAssembly` is specified in the [WebHost configuration](https://docs.microsoft.com/aspnet/core/fundamentals/hosting?tabs=aspnetcore2x#configuring-a-host) or options, hosting loads the specified startup assembly and searches for a `Startup` or `Startup[Environment]` type. The class whose name suffix matches the current environment is prioritized. If the app is run in the *Development* environment and includes both a `Startup` and a `StartupDevelopment` class, the `StartupDevelopment` class is used. See [FindStartupType](https://github.com/aspnet/Hosting/blob/rel/1.1.0/src/Microsoft.AspNetCore.Hosting/Internal/StartupLoader.cs) in `StartupLoader` and [Working with multiple environments](xref:fundamentals/environments#startup-conventions).

Alternatively, the app can define a fixed `Startup` class that's used regardless of the environment by calling `UseStartup<TStartup>`. This is the recommended approach.

The `Startup` class constructor can accept dependencies that are provided through [dependency injection](xref:fundamentals/dependency-injection). A common approach is to use `IHostingEnvironment` to set up [configuration](xref:fundamentals/configuration/index) sources.

The `Startup` class must include a `Configure` method and can optionally include a `ConfigureServices` method. `Configure` and `ConfigureServices` are called when the app starts. The class can also include [environment-specific versions of these methods](xref:fundamentals/environments#startup-conventions). `ConfigureServices`, if present, is called before `Configure`.

Learn about [handling exceptions during application startup](xref:fundamentals/error-handling#startup-exception-handling).

## The ConfigureServices method

The [ConfigureServices](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.hosting.startupbase#Microsoft_AspNetCore_Hosting_StartupBase_ConfigureServices_Microsoft_Extensions_DependencyInjection_IServiceCollection_) method is optional. If `ConfigureServices` is used, it's called before the `Configure` method by the web host. The web host may configure some services before `Startup` methods are called (see [hosting](xref:fundamentals/hosting)). By convention, [Configuration options](xref:fundamentals/configuration) are set in this method.

For features that require substantial setup, there are `Add[Service]` extension methods on [IServiceCollection](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.dependencyinjection.iservicecollection). The default website template configures the app to use services for Entity Framework, Identity, and MVC:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=4,7,11&start=40&end=55)]

Adding services to the services container makes them available within the app via [dependency injection](xref:fundamentals/dependency-injection).

## Services available in Startup

ASP.NET Core dependency injection provides services during an app's startup. These services can be requested by including the appropriate interface as a parameter on the `Startup` class's constructor or its `Configure` method. The `ConfigureServices` method only takes an `IServiceCollection` parameter (but any registered service can be retrieved from this collection, so additional parameters are not necessary).

Below are some of the services typically requested by `Startup` methods:

* In the constructor: `IHostingEnvironment`, `ILogger<Startup>`
* In `ConfigureServices`: `IServiceCollection`
* In `Configure`: `IApplicationBuilder`, `IHostingEnvironment`, `ILoggerFactory`

Any services added by the `WebHostBuilder` `ConfigureServices` method may be requested by the `Startup` class constructor or its `Configure` method. Use `WebHostBuilder` to provide any services needed by `Startup` methods.

## The Configure method

The `Configure` method is used to specify how the app responds to HTTP requests. The request pipeline is configured by adding [middleware](xref:fundamentals/middleware) components to an `IApplicationBuilder` instance that is provided by dependency injection.

The default website template uses several extension methods to configure the pipeline with support for [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, ASP.NET MVC, and Identity:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=8,9,10,14,17,19,21&start=58&end=84)]

Each `Use` extension method adds a [middleware](xref:fundamentals/middleware) component to the request pipeline. For instance, the `UseMvc` extension method adds the [routing](xref:fundamentals/routing) middleware to the request pipeline and configures [MVC](xref:mvc/overview) as the default handler.

For more information about how to use `IApplicationBuilder`, see [Middleware](xref:fundamentals/middleware).

Additional services, such as `IHostingEnvironment` and `ILoggerFactory`, may also be specified in the method signature. When specified, these services are [injected](xref:fundamentals/dependency-injection) if they're available.

## Startup filters

Use [IStartupFilter](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter) to configure middleware at the beginning or end of an app's [Configure](#the-configure-method) middleware pipeline.

`IStartupFilter` implements a single method, [Configure](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter.configure), which receives and returns an `Action<IApplicationBuilder>`. An [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) defines a class to configure an app's request pipeline. For more information, see [Creating a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware#creating-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implements one or more middlewares in the request pipeline. The middlewares are invoked in the order that the `IStartupFilter` implementations are added to the service container.

The [HostingStartupSample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/startup/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates how to register a middleware with `IHostingStartup`.

The sample app includes a middleware that sets an options value from a query string parameter:

[!code-csharp[Main](startup/sample/RequestSetOptionsMiddleware.cs?name=snippet1)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[Main](startup/sample/RequestSetOptionsStartupFilter.cs?name=snippet1&highlight=7)]

The `IStartupFilter` is registered in the service container in `ConfigureServices`:

[!code-csharp[Main](startup/sample/Startup.cs?name=snippet1&highlight=3)]

When the app is run and a query string parameter for `option` is provided, the middleware processes the value assignment before the MVC middleware renders the response:

![Browser window showing the rendered Index page. The value of Option is rendered as 'From Middleware' based on requesting the page with the query string parameter and value of option set to 'From Middleware'.](startup/_static/index.png)

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more `IStartupFilter` implementations that run before or after other middleware registered with `IStartupFilter` in the app. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`, position the service registration before the library is added to the service container. To invoke it afterward, position the service registration after the library is added.
* Middleware specified with `IStartupFilter` may short-circuit requests before higher priority middleware runs. Register the `IStartupFilter` for the short-circuited middleware earlier in the service registrations to ensure that it runs before short-circuiting can occur.

## Additional Resources

* [Working with Multiple Environments](xref:fundamentals/environments)
* [Middleware](xref:fundamentals/middleware)
* [Logging](xref:fundamentals/logging/index)
* [Configuration](xref:fundamentals/configuration/index)
