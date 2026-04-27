---
title: App startup in ASP.NET Core
author: wadepickett
description: Learn how the Startup class in ASP.NET Core configures services and the app's request pipeline.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 04/24/2026
uid: fundamentals/startup

# customer intent: As an ASP.NET developer, I want to explore the Startup class in ASP.NET Core, so I can configure services and the request pipeline for my apps.
---
# App startup in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-7.0"

ASP.NET Core apps created with the web templates contain the application startup code in the _Program.cs_ file.

For Blazor startup guidance, which adds to or supersedes the guidance in this article, see [ASP.NET Core Blazor startup](xref:blazor/fundamentals/startup).

The following app startup code supports several app types:

* [Blazor Web Apps](xref:blazor/index#build-a-full-stack-web-app-with-blazor)
* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/startup/9.0_samples/WebAll/Program.cs?name=snippet)]

Apps that use the <xref:System.Diagnostics.Tracing.EventSource> can measure the startup time to understand and optimize startup performance. The <!--keep-->[ServerReady](https://source.dot.net/#Microsoft.AspNetCore.Hosting/Internal/HostingEventSource.cs,76) event in the <xref:Microsoft.AspNetCore.Hosting?displayProperty=fullName> represents the point where the server is ready to respond to requests.

<a name="IStartupFilter"></a>

## Extend Startup with startup filters

Use <xref:Microsoft.AspNetCore.Hosting.IStartupFilter>:

* To configure middleware at the beginning or end of an app's middleware pipeline without an explicit call to `Use{Middleware}`. Use `IStartupFilter` to add defaults to the beginning of the pipeline without explicitly registering the default middleware. `IStartupFilter` allows a different component to call `Use{Middleware}` on behalf of the app author.

* To create a pipeline of `Configure` methods. [IStartupFilter.Configure](xref:Microsoft.AspNetCore.Hosting.IStartupFilter.Configure%2A) can set a middleware to run before or after middleware added by libraries.

An `IStartupFilter` implementation provides a <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> method that receives and returns an Action\<IApplicationBuilder>. An <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> defines a class to configure an app's request pipeline. For more information, see [Create a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implementation can add one or more middlewares in the request pipeline. The filters are invoked in the order they were added to the service container. Filters can add middleware before or after passing control to the next filter, thus they append to the beginning or end of the app pipeline.

The following example demonstrates how to register a middleware with `IStartupFilter`. The `RequestSetOptionsMiddleware` middleware sets an options value from a query string parameter:

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Middleware/RequestSetOptionsMiddleware.cs?name=snippet1)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Middleware/RequestSetOptionsStartupFilter.cs?name=snippet1&highlight=7)]

The `IStartupFilter` implementation is registered in the _Program.cs_ file:

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Program.cs?highlight=6-7)]

When a query string parameter for `option` is provided, the middleware processes the value assignment before the ASP.NET Core middleware renders the response:

[!code-cshtml[](~/fundamentals/startup/7/WebStartup/Pages/Privacy.cshtml?highlight=9)]

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations might interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.

* Libraries can add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`:

  * Position the service registration before the library is added to the service container.

  * To invoke afterward, position the service registration after the library is added.

You can't extend the ASP.NET Core app when you override `Configure`. For more information, see [GitHub /dotnet/aspnetcore/issues #45372](https://github.com/dotnet/aspnetcore/issues/45372).

## Add configuration at startup from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the application _Program.cs_ file. For more information, see [Use hosting startup assemblies in ASP.NET Core](xref:fundamentals/configuration/platform-specific-configuration).

## Startup, ConfigureServices, and Configure

For information on using the <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A> and <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> methods with the minimal hosting model, see:

* [Use Startup with the minimal hosting model](xref:migration/50-to-60#smhm)
* [The Startup Class (.NET 5 version of this article)](?view=aspnetcore-5.0&preserve-view=true#the-startup-class):
  * [The ConfigureServices method](?view=aspnetcore-5.0&preserve-view=true#the-configureservices-method)
  * [The Configure method](?view=aspnetcore-5.0&preserve-view=true#the-configure-method)

## Related content

- [ASP.NET Core fundamentals overview](./index.md)
- [Configuration in ASP.NET Core](./configuration/index.md)

:::moniker-end

[!INCLUDE[](~/fundamentals/startup/includes/startup56.md)]
