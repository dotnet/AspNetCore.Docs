---
title: ASP.NET Core fundamentals overview
author: tdykstra
description: Learn the fundamental concepts for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/09/2022
uid: fundamentals/index
---
# ASP.NET Core fundamentals overview

:::moniker range=">= aspnetcore-6.0"

This article provides an overview of the fundamentals for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.

## Program.cs

ASP.NET Core apps created with the web templates contain the application startup code in the `Program.cs` file. The `Program.cs` file is where:

* Services required by the app are configured.
* The app's request handling pipeline is defined as a series of [middleware components](xref:fundamentals/middleware/index).

The following app startup code supports:

* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal web APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet)]

## Dependency injection (services)

ASP.NET Core includes [dependency injection (DI)](xref:fundamentals/dependency-injection) that makes configured services available throughout an app. Services are added to the DI container with [WebApplicationBuilder.Services](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services), `builder.Services` in the preceding code. When the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is instantiated, many [framework-provided services](xref:fundamentals/dependency-injection#framework-provided-services) are added. `builder` is a `WebApplicationBuilder` in the following code:

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet2&highlight=1)]

In the preceding highlighted code, `builder` has configuration, logging, and [many other services](xref:fundamentals/dependency-injection#framework-provided-services) added to the DI container.

The following code adds Razor Pages, MVC controllers with views, and a custom <xref:Microsoft.EntityFrameworkCore.DbContext> to the DI container:

[!code-csharp[](~/fundamentals/index/samples/6.0/RazorPagesMovie/Program.cs?name=snippet2&highlight=6-10)]

Services are typically resolved from DI using constructor injection. The DI framework provides an instance of this service at runtime.

The following code uses constructor injection to resolve the database context and logger from DI:

[!code-csharp[](~/fundamentals/index/samples/6.0/RazorPagesMovie/Pages/Movies/Index.cshtml.cs?name=snippet&highlight=3-10, 16-17)]

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs operations on an [`HttpContext`](xref:fundamentals/httpcontext) and either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component is added to the pipeline by invoking a `Use{Feature}` extension method. Middleware added to the app is highlighted in the following code:

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet&highlight=12-19)]

For more information, see <xref:fundamentals/middleware/index>.

## Host

On startup, an ASP.NET Core app builds a *host*. The host encapsulates all of the app's resources, such as:

* An HTTP server implementation
* Middleware components
* Logging
* Dependency injection (DI) services
* Configuration

There are three different hosts capable of running an ASP.NET Core app:

* [ASP.NET Core WebApplication](xref:fundamentals/minimal-apis/webapplication), also known as the [Minimal Host](xref:migration/50-to-60#new-hosting-model)
* [.NET Generic Host](xref:fundamentals/host/generic-host) combined with ASP.NET Core's <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A>
* [ASP.NET Core WebHost](xref:fundamentals/host/web-host)

The ASP.NET Core <xref:Microsoft.AspNetCore.Builder.WebApplication> and <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> types are recommended and used in all the ASP.NET Core templates. `WebApplication` behaves similarly to the .NET Generic Host and exposes many of the same interfaces but requires less callbacks to configure. The ASP.NET Core <xref:Microsoft.AspNetCore.WebHost> is available only for backward compatibility.

The following example instantiates a `WebApplication`:

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet2&highlight=7)]

The [WebApplicationBuilder.Build](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A) method configures a host with a set of default options, such as:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load [configuration](xref:fundamentals/configuration/index) from `appsettings.json`, environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug providers.

### Non-web scenarios

The Generic Host allows other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an `HttpContext`.

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *IIS HTTP Server* is a server for Windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

# [macOS](#tab/macos)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

# [Linux](#tab/linux)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

---

For more information, see <xref:fundamentals/servers/index>.

## Configuration

ASP.NET Core provides a [configuration](xref:fundamentals/configuration/index) framework that gets settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as `.json` files, `.xml` files, environment variables, and command-line arguments. Write custom configuration providers to support other sources.

By [default](xref:fundamentals/configuration/index#default), ASP.NET Core apps are configured to read from `appsettings.json`, environment variables, the command line, and more. When the app's configuration is loaded, values from environment variables override values from `appsettings.json`.

For managing confidential configuration data such as passwords, .NET Core provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

For more information, see <xref:fundamentals/configuration/index>.

## Environments

Execution environments, such as `Development`, `Staging`, and `Production`, are available in ASP.NET Core. Specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an `IWebHostEnvironment` implementation. This implementation is available anywhere in an app via dependency injection (DI).

The following example configures the exception handler and [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) middleware when ***not*** running in the `Development` environment:

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet&highlight=10-14)]

For more information, see <xref:fundamentals/environments>.

## Logging

ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>. For example:

[!code-csharp[](~/fundamentals/index/samples/6.0/RazorPagesMovie/Pages/Movies/Index.cshtml.cs?name=snippet&highlight=3-10, 16-17)]

For more information, see <xref:fundamentals/logging/index>.

## Routing

A *route* is a URL pattern that is mapped to a handler. The handler is typically a Razor page, an action method in an MVC controller, or a middleware. ASP.NET Core routing gives you control over the URLs used by your app.

The following code, generated by the ASP.NET Core web application template, calls <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>:

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet4&highlight=17)]

For more information, see <xref:fundamentals/routing>.

## Error handling

ASP.NET Core has built-in features for handling errors, such as:

* A developer exception page
* Custom error pages
* Static status code pages
* Startup exception handling

For more information, see <xref:fundamentals/error-handling>.

## Make HTTP requests

An implementation of `IHttpClientFactory` is available for creating `HttpClient` instances. The factory:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, register and configure a *github* client for accessing GitHub. Register and configure a default client for other purposes.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying `HttpClientHandler` instances to avoid common DNS problems that occur when managing `HttpClient` lifetimes manually.
* Adds a configurable logging experience via <xref:Microsoft.Extensions.Logging.ILogger> for all requests sent through clients created by the factory.

For more information, see <xref:fundamentals/http-requests>.

## Content root

The content root is the base path for:

* The executable hosting the app (*.exe*).
* Compiled assemblies that make up the app (*.dll*).
* Content files used by the app, such as:
  * Razor files (`.cshtml`, `.razor`)
  * Configuration files (`.json`, `.xml`)
  * Data files (`.db`)
* The [Web root](#web-root), typically the *wwwroot* folder.

During development, the content root defaults to the project's root directory. This directory is also the base path for both the app's content files and the [Web root](#web-root). Specify a different content root by setting its path when [building the host](#host). For more information, see [Content root](xref:fundamentals/host/generic-host#contentroot).

## Web root

The web root is the base path for public, static resource files, such as:

* Stylesheets (`.css`)
* JavaScript (`.js`)
* Images (`.png`, `.jpg`)

By default, static files are served only from the web root directory and its sub-directories. The web root path defaults to *{content root}/wwwroot*. Specify a different web root by setting its path when [building the host](#host). For more information, see [Web root](xref:fundamentals/host/generic-host#webroot).

Prevent publishing files in *wwwroot* with the [\<Content> project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in *wwwroot/local* and its sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

In Razor `.cshtml` files, `~/` points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/static-files>.

## Additional resources

* [WebApplicationBuilder source code](https://github.com/dotnet/aspnetcore/blob/v6.0.1/src/DefaultBuilder/src/WebApplicationBuilder.cs)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

This article provides an overview of the fundamentals for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.

## The Startup class

The `Startup` class is where:

* Services required by the app are configured.
* The app's request handling pipeline is defined, as a series of middleware components.

Here's a sample `Startup` class:

[!code-csharp[](index/samples_snapshot/3.x/Startup.cs?highlight=3,12)]

For more information, see <xref:fundamentals/startup>.

## Dependency injection (services)

ASP.NET Core includes a built-in dependency injection (DI) framework that makes configured services available throughout an app. For example, a logging component is a service.

Code to configure (or *register*) services is added to the `Startup.ConfigureServices` method. For example:

[!code-csharp[](index/samples_snapshot/3.x/ConfigureServices.cs)]

Services are typically resolved from DI using constructor injection. With constructor injection, a class declares a constructor parameter of either the required type or an interface. The DI framework provides an instance of this service at runtime.

The following example uses constructor injection to resolve a `RazorPagesMovieContext` from DI:

[!code-csharp[](index/samples_snapshot/3.x/Index.cshtml.cs?highlight=5)]

If the built-in Inversion of Control (IoC) container doesn't meet all of an app's needs, a third-party IoC container can be used instead.

For more information, see <xref:fundamentals/dependency-injection>.

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs operations on an `HttpContext` and either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component is added to the pipeline by invoking a `Use...` extension method in the `Startup.Configure` method. For example, to enable rendering of static files, call `UseStaticFiles`.

The following example configures a request handling pipeline:

[!code-csharp[](index/samples_snapshot/3.x/Configure.cs)]

ASP.NET Core includes a rich set of built-in middleware. Custom middleware components can also be written.

For more information, see <xref:fundamentals/middleware/index>.

## Host

On startup, an ASP.NET Core app builds a *host*. The host encapsulates all of the app's resources, such as:

* An HTTP server implementation
* Middleware components
* Logging
* Dependency injection (DI) services
* Configuration

There are two different hosts: 

* .NET Generic Host
* ASP.NET Core Web Host

The .NET Generic Host is recommended. The ASP.NET Core Web Host is available only for backwards compatibility.

The following example creates a .NET Generic Host:

[!code-csharp[](index/samples_snapshot/3.x/Program.cs)]

The `CreateDefaultBuilder` and `ConfigureWebHostDefaults` methods configure a host with a set of default options, such as:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load configuration from `appsettings.json`, `appsettings.{Environment}.json`, environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug providers.

For more information, see <xref:fundamentals/host/generic-host>.

### Non-web scenarios

The Generic Host allows other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an `HttpContext`.

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *IIS HTTP Server* is a server for Windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

# [macOS](#tab/macos)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

# [Linux](#tab/linux)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

---

For more information, see <xref:fundamentals/servers/index>.

## Configuration

ASP.NET Core provides a configuration framework that gets settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as `.json` files, `.xml` files, environment variables, and command-line arguments. Write custom configuration providers to support other sources.

By [default](xref:fundamentals/configuration/index#default), ASP.NET Core apps are configured to read from `appsettings.json`, environment variables, the command line, and more. When the app's configuration is loaded, values from environment variables override values from `appsettings.json`.

The preferred way to read related configuration values is using the [options pattern](xref:fundamentals/configuration/options). For more information, see [Bind hierarchical configuration data using the options pattern](xref:fundamentals/configuration/index#optpat).

For managing confidential configuration data such as passwords, .NET Core provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

For more information, see <xref:fundamentals/configuration/index>.

## Environments

Execution environments, such as `Development`, `Staging`, and `Production`, are a first-class notion in ASP.NET Core. Specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an `IWebHostEnvironment` implementation. This implementation is available anywhere in an app via dependency injection (DI).

The following example configures the app to provide detailed error information when running in the `Development` environment:

[!code-csharp[](index/samples_snapshot/3.x/StartupConfigure.cs?highlight=3-6)]

For more information, see <xref:fundamentals/environments>.

## Logging

ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>. For example:

[!code-csharp[](index/samples_snapshot/3.x/TodoController.cs?highlight=5,13,19)]

Logging methods such as `LogInformation` support any number of fields. These fields are commonly used to construct a message `string`, but some logging providers send these to a data store as separate fields. This feature makes it possible for logging providers to implement [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

For more information, see <xref:fundamentals/logging/index>.

## Routing

A *route* is a URL pattern that is mapped to a handler. The handler is typically a Razor page, an action method in an MVC controller, or a middleware. ASP.NET Core routing gives you control over the URLs used by your app.

For more information, see <xref:fundamentals/routing>.

## Error handling

ASP.NET Core has built-in features for handling errors, such as:

* A developer exception page
* Custom error pages
* Static status code pages
* Startup exception handling

For more information, see <xref:fundamentals/error-handling>.

## Make HTTP requests

An implementation of `IHttpClientFactory` is available for creating `HttpClient` instances. The factory:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, register and configure a *github* client for accessing GitHub. Register and configure a default client for other purposes.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying `HttpClientHandler` instances to avoid common DNS problems that occur when managing `HttpClient` lifetimes manually.
* Adds a configurable logging experience via <xref:Microsoft.Extensions.Logging.ILogger> for all requests sent through clients created by the factory.

For more information, see <xref:fundamentals/http-requests>.

## Content root

The content root is the base path for:

* The executable hosting the app (*.exe*).
* Compiled assemblies that make up the app (*.dll*).
* Content files used by the app, such as:
  * Razor files (`.cshtml`, `.razor`)
  * Configuration files (`.json`, `.xml`)
  * Data files (`.db`)
* The [Web root](#web-root), typically the *wwwroot* folder.

During development, the content root defaults to the project's root directory. This directory is also the base path for both the app's content files and the [Web root](#web-root). Specify a different content root by setting its path when [building the host](#host). For more information, see [Content root](xref:fundamentals/host/generic-host#contentroot).

## Web root

The web root is the base path for public, static resource files, such as:

* Stylesheets (`.css`)
* JavaScript (`.js`)
* Images (`.png`, `.jpg`)

By default, static files are served only from the web root directory and its sub-directories. The web root path defaults to *{content root}/wwwroot*. Specify a different web root by setting its path when [building the host](#host). For more information, see [Web root](xref:fundamentals/host/generic-host#webroot).

Prevent publishing files in *wwwroot* with the [\<Content> project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in *wwwroot/local* and its sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

In Razor `.cshtml` files, tilde-slash (`~/`) points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/static-files>.

:::moniker-end
