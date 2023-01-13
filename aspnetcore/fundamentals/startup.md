---
title: App startup in ASP.NET Core
author: rick-anderson
description: Learn how the Startup class in ASP.NET Core configures services and the app's request pipeline.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 12/05/2019
uid: fundamentals/startup
---
# App startup in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-7.0"

ASP.NET Core apps created with the web templates contain the application startup code in the `Program.cs` file.

The following app startup code supports:

* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet)]

Apps using [EventSource](/dotnet/api/system.diagnostics.tracing.eventsource) can measure the startup time to understand and optimize startup performance. The [`ServerReady`](https://source.dot.net/#Microsoft.AspNetCore.Hosting/Internal/HostingEventSource.cs,76) event in <xref:Microsoft.AspNetCore.Hosting?displayProperty=fullName> represents the point where the server is ready to respond to requests.

For more information on application startup, see <xref:fundamentals/index>.

## Extend Startup with startup filters

Use <xref:Microsoft.AspNetCore.Hosting.IStartupFilter>:

* To configure middleware at the beginning or end of an app's middleware pipeline without an explicit call to `Use{Middleware}`. Use `IStartupFilter` to add defaults to the beginning of the pipeline without explicitly registering the default middleware. `IStartupFilter` allows a different component to call `Use{Middleware}` on behalf of the app author.
* To create a pipeline of `Configure` methods. [IStartupFilter.Configure](xref:Microsoft.AspNetCore.Hosting.IStartupFilter.Configure%2A) can set a middleware to run before or after middleware added by libraries.

`IStartupFilter` implements <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A>, which receives and returns an `Action<IApplicationBuilder>`. An <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> defines a class to configure an app's request pipeline. For more information, see [Create a middleware pipeline with IApplicationBuilder](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` can add one or more middlewares in the request pipeline. The filters are invoked in the order they were added to the service container. Filters may add middleware before or after passing control to the next filter, thus they append to the beginning or end of the app pipeline.

The following example demonstrates how to register a middleware with `IStartupFilter`. The `RequestSetOptionsMiddleware` middleware sets an options value from a query string parameter:

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Middleware/RequestSetOptionsMiddleware.cs?name=snippet1)]

The `RequestSetOptionsMiddleware` is configured in the `RequestSetOptionsStartupFilter` class:

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Middleware/RequestSetOptionsStartupFilter.cs?name=snippet1?name=snippet1&highlight=7)]

The `IStartupFilter` is registered in the service container in <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices*>.

[!code-csharp[](~/fundamentals/startup/7/WebStartup/Program.cs?name=snippet&highlight=5-6)]

When a query string parameter for `option` is provided, the middleware processes the value assignment before the ASP.NET Core middleware renders the response:

[!code-cshtml[](~/aspnetcore/fundamentals/startup/7/WebStartup/Pages/Privacy.cshtml?name=snippet&highlight=5-6)]

Middleware execution order is set by the order of `IStartupFilter` registrations:

* Multiple `IStartupFilter` implementations may interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries may add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`:

  * Position the service registration before the library is added to the service container.
  * To invoke afterward, position the service registration after the library is added.

:::moniker-end

[!INCLUDE[](~/fundamentals/startup/includes/startup56.md)]