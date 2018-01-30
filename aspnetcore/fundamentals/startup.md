---
title: Application startup in ASP.NET Core
author: ardalis
description: Discover how the Startup class in ASP.NET Core configures services and the app's request pipeline.
manager: wpickett
ms.author: tdykstra
ms.custom: mvc
ms.date: 12/08/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: fundamentals/startup
---
# Application startup in ASP.NET Core

By [Steve Smith](https://ardalis.com), [Tom Dykstra](https://github.com/tdykstra), and [Luke Latham](https://github.com/guardrex)

The `Startup` class configures services and the app's request pipeline.

## The Startup class

ASP.NET Core apps use a `Startup` class, which is named `Startup` by convention. The `Startup` class:

* Can optionally include a [ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configureservices) method to configure the app's services.
* Must include a [Configure](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configure) method to create the app's request processing pipeline.

`ConfigureServices` and `Configure` are called by the runtime when the app starts:

[!code-csharp[Main](startup/snapshot_sample/Startup1.cs)]

Specify the `Startup` class with the [WebHostBuilderExtensions](/dotnet/api/Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions) [UseStartup&lt;TStartup&gt;](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderextensions.usestartup#Microsoft_AspNetCore_Hosting_WebHostBuilderExtensions_UseStartup__1_Microsoft_AspNetCore_Hosting_IWebHostBuilder_) method:

[!code-csharp[Main](../common/samples/WebApplication1DotNetCore2.0App/Program.cs?name=snippet_Main&highlight=10)]

The `Startup` class constructor accepts dependencies defined by the host. A common use of [dependency injection](xref:fundamentals/dependency-injection) into the `Startup` class is to inject:

* [IHostingEnvironment](/dotnet/api/Microsoft.AspNetCore.Hosting.IHostingEnvironment) to configure services by environment.
* [IConfiguration](/dotnet/api/microsoft.extensions.configuration.iconfiguration) to configure the app during startup.

[!code-csharp[Main](startup/snapshot_sample/Startup2.cs)]

An alternative to injecting `IHostingEnvironment` is to use a conventions-based approach. The app can define separate `Startup` classes for different environments (for example, `StartupDevelopment`), and the appropriate startup class is selected at runtime. The class whose name suffix matches the current environment is prioritized. If the app is run in the Development environment and includes both a `Startup` class and a `StartupDevelopment` class, the `StartupDevelopment` class is used. For more information, see [Working with multiple environments](xref:fundamentals/environments#startup-conventions).

To learn more about `WebHostBuilder`, see the [Hosting](xref:fundamentals/hosting) topic. For information on handling errors during startup, see [Startup exception handling](xref:fundamentals/error-handling#startup-exception-handling).

## The ConfigureServices method

The [ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configureservices) method is:

* Optional.
* Called by the web host before the `Configure` method to configure the app's services.
* Where [configuration options](xref:fundamentals/configuration/index) are set by convention.

Adding services to the service container makes them available within the app and in the `Configure` method. The services are resolved via [dependency injection](xref:fundamentals/dependency-injection) or from [IApplicationBuilder.ApplicationServices](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder.applicationservices).

The web host may configure some services before `Startup` methods are called. Details are available in the [Hosting](xref:fundamentals/hosting) topic. 

For features that require substantial setup, there are `Add[Service]` extension methods on [IServiceCollection](/dotnet/api/Microsoft.Extensions.DependencyInjection.IServiceCollection). A typical web app registers services for Entity Framework, Identity, and MVC:

[!code-csharp[Main](../common/samples/WebApplication1/Startup.cs?highlight=4,7,11&start=40&end=55)]

## Services available in Startup

The web host provides some services that are available to the `Startup` class constructor. The app adds additional services via `ConfigureServices`. Both the host and app services are then available in `Configure` and throughout the application.

## The Configure method

The [Configure](/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configure) method is used to specify how the app responds to HTTP requests. The request pipeline is configured by adding [middleware](xref:fundamentals/middleware/index) components to an [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) instance. `IApplicationBuilder` is available to the `Configure` method, but it isn't registered in the service container. Hosting creates an `IApplicationBuilder` and passes it directly to `Configure` ([reference source](https://github.com/aspnet/Hosting/blob/release/2.0.0/src/Microsoft.AspNetCore.Hosting/Internal/WebHost.cs#L179-L192)).

The [ASP.NET Core templates](/dotnet/core/tools/dotnet-new) configure the pipeline with support for a developer exception page, [BrowserLink](http://vswebessentials.com/features/browserlink), error pages, static files, and ASP.NET MVC:

[!code-csharp[Main](../common/samples/WebApplication1DotNetCore2.0App/Startup.cs?range=28-48&highlight=5,6,10,13,15)]

Each `Use` extension method adds a middleware component to the request pipeline. For instance, the `UseMvc` extension method adds the [routing middleware](xref:fundamentals/routing) to the request pipeline and configures [MVC](xref:mvc/overview) as the default handler.

Additional services, such as `IHostingEnvironment` and `ILoggerFactory`, may also be specified in the method signature. When specified, additional services are injected if they're available.

For more information on how to use `IApplicationBuilder`, see [Middleware](xref:fundamentals/middleware/index).

## Convenience methods

[ConfigureServices](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder.configureservices) and [Configure](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilderextensions.configure) convenience methods can be used instead of specifying a `Startup` class. Multiple calls to `ConfigureServices` append to one another. Multiple calls to `Configure` use the last method call.

[!code-csharp[Main](startup/snapshot_sample/Program.cs?highlight=18,22)]

## Startup filters

Use [IStartupFilter](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter) to configure middleware at the beginning or end of an app's [Configure](#the-configure-method) middleware pipeline. `IStartupFilter` is useful to ensure that a middleware runs before or after middleware added by libraries at the start or end of the app's request processing pipeline.

`IStartupFilter` implements a single method, [Configure](/dotnet/api/microsoft.aspnetcore.hosting.istartupfilter.configure), which receives and returns an `Action<IApplicationBuilder>`. An [IApplicationBuilder](/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder) defines a class to configure an app's request pipeline. For more information, see [Creating a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware/index#creating-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implements one or more middlewares in the request pipeline. The filters are invoked in the order they were added to the service container. Filters may add middleware before or after passing control to the next filter, thus they append to the beginning or end of the app pipeline.

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/startup/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates how to register a middleware with `IStartupFilter`. The sample app includes a middleware that sets an options value from a query string parameter:

[!code-csharp[Main](startup/sample/RequestSetOptionsMiddleware.cs?name=snippet1)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[Main](startup/sample/RequestSetOptionsStartupFilter.cs?name=snippet1&highlight=7)]

The `IStartupFilter` is registered in the service container in `ConfigureServices`:

[!code-csharp[Main](startup/sample/Startup.cs?name=snippet1&highlight=3)]

When a query string parameter for `option` is provided, the middleware processes the value assignment before the MVC middleware renders the response:

![Browser window showing the rendered Index page. The value of Option is rendered as 'From Middleware' based on requesting the page with the query string parameter and value of option set to 'From Middleware'.](startup/_static/index.png)

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`, position the service registration before the library is added to the service container. To invoke it afterward, position the service registration after the library is added.

## Additional resources

* [Hosting](xref:fundamentals/hosting)
* [Working with Multiple Environments](xref:fundamentals/environments)
* [Middleware](xref:fundamentals/middleware/index)
* [Logging](xref:fundamentals/logging/index)
* [Configuration](xref:fundamentals/configuration/index)
* [StartupLoader class: FindStartupType method (reference source)](https://github.com/aspnet/Hosting/blob/rel/2.0.0/src/Microsoft.AspNetCore.Hosting/Internal/StartupLoader.cs#L66-L116)
