---
title: App startup in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how ASP.NET Core apps start up and how to configure services and the app's request pipeline.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 09/08/2026
uid: fundamentals/startup
---
# App startup in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes how ASP.NET Core apps start up and how to configure services and the app's request pipeline.

For Blazor startup guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/startup>.

:::moniker range=">= aspnetcore-6.0"

## The `Program` file

ASP.NET Core apps initialize and configure startup in the app's `Program` file (`Program.cs`).

The first part of the `Program` file focuses on building the app. This phase utilizes <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> to initialize a new instance of the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> class with preconfigured defaults before the app is started:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Properties of the web app builder include:

* [`builder.Configuration`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Configuration): A collection of configuration providers for the app to compose. This is useful for adding new configuration sources and providers. The framework automatically chains multiple configuration sources together. If a setting exists in multiple places, the last setting is used. For more information, see <xref:fundamentals/configuration/index>.
* [`builder.Environment`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Environment): Provides information about the web hosting environment an app is running. For more information, see <xref:fundamentals/environments>.
* [`builder.Host`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Host): An <xref:Microsoft.Extensions.Hosting.IHostBuilder> for configuring host specific properties, but not building the host. For more information, see <xref:fundamentals/host/generic-host>.
* [`builder.Logging`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Logging): A collection of logging providers for the app to compose. For more information, see <xref:fundamentals/logging/index>.
* [`builder.Metrics`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Metrics) (.NET 8 or later): Allows enabling metrics and directing their output. For more information, see <xref:metrics/overview>.
* [`builder.Services`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services): A collection of dependency injection (DI) services for the app to compose for [Inversion of Control (IoC)](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion). This is useful for adding user provided or framework provided services. For more information, see <xref:fundamentals/dependency-injection>.
* [`builder.WebHost`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.WebHost): An <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> for configuring server specific properties, but not building.

The app is built by calling <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A?displayProperty=nameWithType>, which returns the built <xref:Microsoft.AspNetCore.Builder.WebApplication>:

```csharp
var app = builder.Build();
```

The next part of the `Program` file focuses on establishing the HTTP request handling pipeline as a series of [middleware components](xref:fundamentals/middleware/index) before that app is started. Each middleware performs operations on an [`HttpContext`](xref:fundamentals/httpcontext) and either invokes the next middleware in the pipeline or terminates the request. By convention, middleware components are added to the pipeline by invoking an extension method that starts with "`Use`." For more information, see <xref:fundamentals/middleware/index>.

The <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A> method runs the app and blocks the calling thread until the host is shut down:

```csharp
app.Run();
```

The configured and built app transitions to an active, running process:

1. The middleware pipeline is built.

   When [`builder.Build`](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A) is called, dependencies are resolved, but the actual processing pipeline isn't completely set. When [`app.Run`](xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A) executes, the framework finalizes the HTTP middleware pipeline. The declared middleware methods and endpoint mappings are compiled them into a single, high-performance execution delegate sequence. For more information, see <xref:fundamentals/middleware/index>.

2. The web server (Kestrel by default) is started.

   The host looks inside its dependency container, locates the registered server implementation (usually Kestrel), and triggers its startup cycle. Kestrel then: 
   
   * Looks up the defined hosting URLs and ports from `launchSettings.json`, environment variables, or CLI arguments.
   * Opens and allocates the physical network sockets on your machine.
   * Binds to those ports and begins listening for incoming traffic.

   For more information, see <xref:fundamentals/host/generic-host>, <xref:fundamentals/servers/index>, and <xref:fundamentals/servers/kestrel>.

3. Application started lifetime events are triggered.

   The <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> service fires its <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStarted> token. Any background workers (<xref:Microsoft.Extensions.Hosting.BackgroundService> or [hosted services](xref:fundamentals/host/hosted-services)), database seeders, or custom event listeners that are wired up to wait for app startup are triggered to start processing.

4. The main execution thread is blocked.

   <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A> (`app.Run()`) is intentionally *synchronous* to the main thread. It creates an active wait loop using an internal <xref:System.Threading.Tasks.TaskCompletionSource> or synchronization context. It pauses code execution, preventing the `Program` file from ending, which would otherwise terminate the app.

5. The app transitions to listening for requests.

   At this point, the command shell usually logs hosting diagnostics:

   ```text
   info: Microsoft.Hosting.Lifetime[14]
         Now listening on: https://localhost:7123
   info: Microsoft.Hosting.Lifetime[14]
         Now listening on: http://localhost:5123
   info: Microsoft.Hosting.Lifetime[0]
         Application started. Press Ctrl+C to shut down.
   ```

  The app remains in this state indefinitely, passing incoming web traffic down the middleware pipeline and sending responses.

When a shutdown is signaled, for example when <kbd>Ctrl</kbd>+<kbd>c</kbd> is detected in the command shell running the app or a container orchestration tool sends a SIGTERM event, <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A> unblocks and the following actions take place:

1. <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping> tokens are triggered, which allows the app to run logic before the shutdown process begins.
2. The Kestrel server is shut down, which disables new connections. The server waits for requests on existing connections to complete for as long as the shutdown timeout allows. The server sends the connection close header for further requests on existing connections.
3. <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopped%2A> event handlers are triggered, which allows the app to run logic after the app has shutdown.
4. Console execution gracefully exits with an exit code of 0.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The `Startup` class configures services and the app's request pipeline.

## The `Startup` class

ASP.NET Core apps use a `Startup` class, which is named `Startup` by convention. The `Startup` class:

* Optionally includes a <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A> method to configure the app's *services*. A service is a reusable component that provides app functionality. Services are *registered* in `ConfigureServices` and consumed across the app via [dependency injection (DI)](xref:fundamentals/dependency-injection) or <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices%2A>.
* Includes a <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> method to create the app's request processing pipeline.

`ConfigureServices` and `Configure` are called by the ASP.NET Core runtime when the app starts:

[!code-csharp[](~/fundamentals/startup/3.0_samples/StartupFilterSample/Startup.cs?name=snippet)]

The preceding example is for [Razor Pages](xref:razor-pages/index); MVC startup code is similar.

The `Startup` class is specified when the app's [host](xref:fundamentals/index#host) is built. The `Startup` class is typically specified by calling <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A?displayName=nameWithType> on the host builder:

[!code-csharp[](~/fundamentals/startup/3.0_samples/Program3.cs?name=snippet_Program&highlight=12)]

The host provides services that are available to the `Startup` class constructor. The app adds additional services via `ConfigureServices`. Both the host and app services are available in `Configure` and throughout the app.

Only the following service types can be injected into the `Startup` constructor when using the [Generic Host](xref:fundamentals/host/generic-host) (<xref:Microsoft.Extensions.Hosting.IHostBuilder>):

* <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment>
* <xref:Microsoft.Extensions.Hosting.IHostEnvironment>
* <xref:Microsoft.Extensions.Configuration.IConfiguration>

[!code-csharp[](~/fundamentals/startup/3.0_samples/StartupFilterSample/StartUp2.cs?name=snippet)]

Most services aren't available until the `Configure` method is called.

## Multiple `Startup` classes

When the app defines separate `Startup` classes for different environments (for example, `StartupDevelopment`), the appropriate `Startup` class is selected at runtime. The class whose name suffix matches the current environment is prioritized. If the app is run in the `Development` environment and includes both a `Startup` class and a `StartupDevelopment` class, the `StartupDevelopment` class is used. For more information, see [Use multiple environments](xref:fundamentals/environments#environment-based-startup-class-and-methods).

For more information on the host, see <xref:fundamentals/index#host>. For information on handling errors during startup, see <xref:fundamentals/error-handling#startup-exception-handling>.

## The `ConfigureServices` method

The optional <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A> method is:

* Called by the host before the `Configure` method to configure the app's services.
* Where [configuration options](xref:fundamentals/configuration/index) are set by convention.

The host may configure some services before `Startup` methods are called. For more information, see <xref:fundamentals/index#host>.

For features that require substantial setup, there are `Add{Service}` extension methods on <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. For example, **Add**DbContext, **Add**DefaultIdentity, **Add**EntityFrameworkStores, and **Add**RazorPages:

[!code-csharp[](~/fundamentals/startup/3.0_samples/StartupFilterSample/StartupIdentity.cs?name=snippet)]

Adding services to the service container makes them available within the app and in the `Configure` method. The services are resolved via [dependency injection](xref:fundamentals/dependency-injection) or from <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.ApplicationServices%2A>.

## The `Configure` method

The <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> method is used to specify how the app responds to HTTP requests. The request pipeline is configured by adding [middleware](xref:fundamentals/middleware/index) components to an <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> instance. `IApplicationBuilder` is available to the `Configure` method, but it isn't registered in the service container. Hosting creates an `IApplicationBuilder` and passes it directly to `Configure`.

The [ASP.NET Core templates](/dotnet/core/tools/dotnet-new) configure the pipeline with support for:

* [Developer Exception Page](xref:fundamentals/error-handling#developer-exception-page)
* [Exception handler](xref:fundamentals/error-handling#exception-handler-page)
* [HTTP Strict Transport Security (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-hsts-protocol)
* [HTTPS redirection](xref:security/enforcing-ssl)
* [Static files](xref:fundamentals/static-files)
* ASP.NET Core [MVC](xref:mvc/overview) and [Razor Pages](xref:razor-pages/index)

[!code-csharp[](~/fundamentals/startup/3.0_samples/StartupFilterSample/Startup.cs?name=snippet)]

The preceding sample is for [Razor Pages](xref:razor-pages/index); the MVC version is similar.

Each `Use` extension method adds one or more middleware components to the request pipeline. For instance, <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> configures [middleware](xref:fundamentals/middleware/index) to serve [static files](xref:fundamentals/static-files).

Each middleware component in the request pipeline is responsible for invoking the next component in the pipeline or short-circuiting the chain, if appropriate.

Additional services, such as `IWebHostEnvironment`, `ILoggerFactory`, or anything defined in `ConfigureServices`, can be specified in the `Configure` method signature. These services are injected if they're available.

For more information on how to use `IApplicationBuilder` and the order of middleware processing, see <xref:fundamentals/middleware/index>.

## Configure services without a `Startup` class

To configure services and the request processing pipeline without using a `Startup` class, call `ConfigureServices` and `Configure` convenience methods on the host builder. Multiple calls to `ConfigureServices` append to one another. If multiple `Configure` method calls exist, the last `Configure` call is used.

[!code-csharp[](~/fundamentals/startup/3.0_samples/StartupFilterSample/Program1.cs?name=snippet)]

:::moniker-end

## Startup filters

While an app typically creates an explicit middleware execution pipeline in its `Program` file, a startup filter (<xref:Microsoft.AspNetCore.Hosting.IStartupFilter>) is useful for:

* Creating a shared library/NuGet package that loads a custom middleware automatically without requiring the app to explicitly call `app.Use{MIDDLEWARE}`, where the `{MIDDLEWARE}` placeholder represents the custom middleware name (for example, `app.UseImageProcessingMiddleware`).
* Guaranteeing a piece of middleware executes before or after other middleware, regardless of how a developer modifies the app's `Program` file.

An `IStartupFilter` implementation provides a <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> method that receives and returns an `Action<IApplicationBuilder>`. An <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder> defines a class to configure an app's request pipeline. For more information, see [Create a middleware pipeline with `IApplicationBuilder`](xref:fundamentals/middleware/index#create-a-middleware-pipeline-with-iapplicationbuilder).

Each `IStartupFilter` implementation can add one or more middlewares in the request pipeline. The filters are invoked in the order they're added to the service container. Filters can add middleware before or after passing control to the next filter, thus they append to the beginning or end of the pipeline.

The following example demonstrates how to register a middleware with <xref:Microsoft.AspNetCore.Hosting.IStartupFilter>. The `RequestSetOptionsMiddleware` middleware sets an options value from a query string parameter.

`CustomResponseHeaderFilter.cs`:

```csharp
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

public class CustomResponseHeaderFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return builder =>
        {
            // 1. Add middleware that runs BEFORE subsequent middlewares
            builder.Use(async (context, nextMiddleware) =>
            {
                context.Response.Headers.Append("X-Custom-Header", "VALUE");
                await nextMiddleware();
            });

            // 2. Call the rest of the application's configuration pipeline
            next(builder);

            // 3. (Optional) Add middleware that runs AFTER the rest of the pipeline
        };
    }
}
```

:::moniker range=">= aspnetcore-6.0"

The startup filter implementation is registered in the `Program` file:

```csharp
builder.Services.AddTransient<IStartupFilter, CustomResponseHeaderFilter>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The startup filter implementation is registered in the service container in `Startup.ConfigureServices`:

```csharp
services.AddTransient<IStartupFilter, CustomResponseHeaderFilter>();
```

:::moniker-end

Middleware execution order is set by the order of startup filter registrations:

* Multiple `IStartupFilter` implementations might interact with the same objects. If ordering is important, order their `IStartupFilter` service registrations to match the order that their middlewares should run.
* Libraries can add middleware with one or more `IStartupFilter` implementations that run before or after other app middleware registered with `IStartupFilter`. To invoke an `IStartupFilter` middleware before a middleware added by a library's `IStartupFilter`:
  * Position the service registration before the library is added to the service container.
  * To invoke afterward, position the service registration after the library is added.

You can't extend the ASP.NET Core app when you override `Configure`. For more information, see [WebApplicationFactory Client returns NotFound for all requests with Overriding Configure method (`dotnet/aspnetcore` #45372)](https://github.com/dotnet/aspnetcore/issues/45372).

## Add configuration at startup from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Program` file or `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

## The `Startup` class (`ConfigureServices` and `Configure` methods)

*Although supported in modern ASP.NET Core apps, using a `Startup` class isn't recommended for apps targeting .NET 6 or later. For more information, see <xref:migration/50-to-60#new-hosting-model>.*

For information on using the <xref:Microsoft.AspNetCore.Hosting.StartupBase.ConfigureServices%2A> and <xref:Microsoft.AspNetCore.Hosting.StartupBase.Configure%2A> methods with the minimal hosting model, see the following:

* [Use a `Startup` class with the minimal hosting model](xref:migration/50-to-60#use-a-startup-class-with-the-new-minimal-hosting-model)
* [The `Startup` class (.NET 5 version of this article)](?view=aspnetcore-5.0&preserve-view=true#the-startup-class)

:::moniker range=">= aspnetcore-7.0"

## Measure startup performance

Apps using the <xref:System.Diagnostics.Tracing.EventSource> logging provider can measure the startup time to understand and optimize startup performance. For more information, see <xref:fundamentals/logging/index#eventsource>.

:::moniker-end
