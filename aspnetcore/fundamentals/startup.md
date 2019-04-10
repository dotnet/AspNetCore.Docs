---
title: App startup in ASP.NET Core
author: tdykstra
description: Learn how the Startup class in ASP.NET Core configures services and the app's request pipeline.
monikerRange: '>= aspnetcore-2.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/17/2019
uid: fundamentals/startup
---
# App startup in ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra), [Luke Latham](https://github.com/guardrex), and [Steve Smith](https://ardalis.com)

The `Startup` class configures services and the app's request pipeline.

## The Startup class

ASP.NET Core apps use a `Startup` class, which is named `Startup` by convention. The `Startup` class:

* Optionally includes a <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices*> method to configure the app's *services*. A service is a reusable component that provides app functionality. Services are configured&mdash;also described as *registered*&mdash;in `ConfigureServices` and consumed across the app via [dependency injection (DI)](xref:fundamentals/dependency-injection) or <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices*>.
* Includes a <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure*> method to create the app's request processing pipeline.

`ConfigureServices` and `Configure` are called by the runtime when the app starts:

[!code-csharp[](startup/sample_snapshot/Startup1.cs?highlight=4,10)]

The `Startup` class is specified to the app when the app's [host](xref:fundamentals/index#host) is built. The app's host is built when `Build` is called on the host builder in the `Program` class. The `Startup` class is usually specified by calling the [WebHostBuilderExtensions.UseStartup\<TStartup>](xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup*) method on the host builder:

[!code-csharp[](startup/sample_snapshot/Program3.cs?name=snippet_Program&highlight=10)]

The host provides services that are available to the `Startup` class constructor. The app adds additional services via `ConfigureServices`. Both the host and app services are then available in `Configure` and throughout the app.

A common use of [dependency injection](xref:fundamentals/dependency-injection) into the `Startup` class is to inject:

* <xref:Microsoft.AspNetCore.Hosting.IHostingEnvironment> to configure services by environment.
* <xref:Microsoft.Extensions.Configuration.IConfiguration> to read configuration.
* <xref:Microsoft.Extensions.Logging.ILoggerFactory> to create a logger in `Startup.ConfigureServices`.

[!code-csharp[](startup/sample_snapshot/Startup2.cs?highlight=7-8)]

An alternative to injecting `IHostingEnvironment` is to use a conventions-based approach. When the app defines separate `Startup` classes for different environments (for example, `StartupDevelopment`), the appropriate `Startup` class is selected at runtime. The class whose name suffix matches the current environment is prioritized. If the app is run in the Development environment and includes both a `Startup` class and a `StartupDevelopment` class, the `StartupDevelopment` class is used. For more information, see [Use multiple environments](xref:fundamentals/environments#environment-based-startup-class-and-methods).

To learn more about the host, see [The host](xref:fundamentals/index#host). For information on handling errors during startup, see [Startup exception handling](xref:fundamentals/error-handling#startup-exception-handling).

## The ConfigureServices method

The <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices*> method is:

* Optional.
* Called by the host before the `Configure` method to configure the app's services.
* Where [configuration options](xref:fundamentals/configuration/index) are set by convention.

The typical pattern is to call all the `Add{Service}` methods and then call all of the `services.Configure{Service}` methods. For example, see [Configure Identity services](xref:security/authentication/identity#pw).

The host may configure some services before `Startup` methods are called. For more information, see [The host](xref:fundamentals/index#host).

For features that require substantial setup, there are `Add{Service}` extension methods on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. A typical ASP.NET Core app registers services for Entity Framework, Identity, and MVC:

[!code-csharp[](startup/sample_snapshot/Startup3.cs)]

Adding services to the service container makes them available within the app and in the `Configure` method. The services are resolved via [dependency injection](xref:fundamentals/dependency-injection) or from <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices*>.

See [SetCompatibilityVersion](xref:mvc/compatibility-version) for more information on `SetCompatibilityVersion`.

## The Configure method

The <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure*> method is used to specify how the app responds to HTTP requests. The request pipeline is configured by adding [middleware](xref:fundamentals/middleware/index) components to an <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> instance. `IApplicationBuilder` is available to the `Configure` method, but it isn't registered in the service container. Hosting creates an `IApplicationBuilder` and passes it directly to `Configure`.

The [ASP.NET Core templates](/dotnet/core/tools/dotnet-new) configure the pipeline with support for:

* [Developer Exception Page](xref:fundamentals/error-handling#developer-exception-page)
* [Exception handler](xref:fundamentals/error-handling#exception-handler-page)
* [HTTP Strict Transport Security (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts)
* [HTTPS redirection](xref:security/enforcing-ssl)
* [Static files](xref:fundamentals/static-files)
* [General Data Protection Regulation (GDPR)](xref:security/gdpr)
* ASP.NET Core [MVC](xref:mvc/overview) and [Razor Pages](xref:razor-pages/index)

[!code-csharp[](startup/sample_snapshot/Startup4.cs)]

Each `Use` extension method adds one or more middleware components to the request pipeline. For instance, the `UseMvc` extension method adds [Routing Middleware](xref:fundamentals/routing) to the request pipeline and configures [MVC](xref:mvc/overview) as the default handler.

Each middleware component in the request pipeline is responsible for invoking the next component in the pipeline or short-circuiting the chain, if appropriate. If short-circuiting doesn't occur along the middleware chain, each middleware has a second chance to process the request before it's sent to the client.

Additional services, such as `IHostingEnvironment` and `ILoggerFactory`, may also be specified in the `Configure` method signature. When specified, additional services are injected if they're available.

For more information on how to use `IApplicationBuilder` and the order of middleware processing, see <xref:fundamentals/middleware/index>.

## Convenience methods

To configure services and the request processing pipeline without using a `Startup` class, call `ConfigureServices` and `Configure` convenience methods on the host builder. Multiple calls to `ConfigureServices` append to one another. If multiple `Configure` method calls exist, the last `Configure` call is used.

[!code-csharp[](startup/sample_snapshot/Program1.cs?highlight=16,20)]

## Extend Startup with startup filters

Use <xref:Microsoft.AspNetCore.Hosting.IStartupFilter> to configure middleware at the beginning or end of an app's [Configure](#the-configure-method) middleware pipeline. `IStartupFilter` is useful to ensure that a middleware runs before or after middleware added by libraries at the start or end of the app's request processing pipeline.

`IStartupFilter` implements a single method, <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure*>, which receives and returns an `Action<IApplicationBuilder>`. An <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> defines a class to configure an app's request pipeline. For more information, see [Create a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implements one or more middlewares in the request pipeline. The filters are invoked in the order they were added to the service container. Filters may add middleware before or after passing control to the next filter, thus they append to the beginning or end of the app pipeline.

The following example demonstrates how to register a middleware with `IStartupFilter`.

The `RequestSetOptionsMiddleware` middleware sets an options value from a query string parameter:

[!code-csharp[](startup/sample_snapshot/RequestSetOptionsMiddleware.cs?name=snippet1&highlight=21)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[](startup/sample_snapshot/RequestSetOptionsStartupFilter.cs?name=snippet1&highlight=7)]

The `IStartupFilter` is registered in the service container in <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices*> and augments `Startup` from outside of the `Startup` class:

[!code-csharp[](startup/sample_snapshot/Program2.cs?name=snippet1&highlight=4-5)]

When a query string parameter for `option` is provided, the middleware processes the value assignment before the MVC middleware renders the response:

![Browser window showing the rendered Index page. The value of Option is rendered as 'From Middleware' based on requesting the page with the query string parameter and value of option set to 'From Middleware'.](startup/_static/index.png)

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`, position the service registration before the library is added to the service container. To invoke it afterward, position the service registration after the library is added.

## Add configuration at startup from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

## Additional resources

* [The host](xref:fundamentals/index#host)
* <xref:fundamentals/environments>
* <xref:fundamentals/middleware/index>
* <xref:fundamentals/logging/index>
* <xref:fundamentals/configuration/index>
