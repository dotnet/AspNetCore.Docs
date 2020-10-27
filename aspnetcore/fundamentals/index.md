---
title: ASP.NET Core fundamentals
author: rick-anderson
description: Learn the foundational concepts for building ASP.NET Core apps.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/30/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/index
---
# ASP.NET Core fundamentals

::: moniker range=">= aspnetcore-3.0"

This article provides an overview of key topics for understanding how to develop ASP.NET Core apps.

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
* Load configuration from *appsettings.json*, *appsettings.{Environment Name}.json*, environment variables, command line arguments, and other configuration sources.
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

ASP.NET Core provides a configuration framework that gets settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as *.json* files, *.xml* files, environment variables, and command-line arguments. Write custom configuration providers to support other sources.

By [default](xref:fundamentals/configuration/index#default), ASP.NET Core apps are configured to read from *appsettings.json*, environment variables, the command line, and more. When the app's configuration is loaded, values from environment variables override values from *appsettings.json*.

The preferred way to read related configuration values is using the [options pattern](xref:fundamentals/configuration/options). For more information, see [Bind hierarchical configuration data using the options pattern](xref:fundamentals/configuration/index#optpat).

For managing confidential configuration data such as passwords, ASP.NET Core provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

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

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation*>. For example:

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
  * Razor files (*.cshtml*, *.razor*)
  * Configuration files (*.json*, *.xml*)
  * Data files (*.db*)
* The [Web root](#web-root), typically the *wwwroot* folder.

During development, the content root defaults to the project's root directory. This directory is also the base path for both the app's content files and the [Web root](#web-root). Specify a different content root by setting its path when [building the host](#host). For more information, see [Content root](xref:fundamentals/host/generic-host#contentroot).

## Web root

The web root is the base path for public, static resource files, such as:

* Stylesheets (*.css*)
* JavaScript (*.js*)
* Images (*.png*, *.jpg*)

By default, static files are served only from the web root directory and its sub-directories. The web root path defaults to *{content root}/wwwroot*. Specify a different web root by setting its path when [building the host](#host). For more information, see [Web root](xref:fundamentals/host/generic-host#webroot).

Prevent publishing files in *wwwroot* with the [\<Content> project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in *wwwroot/local* and its sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

In Razor *.cshtml* files, tilde-slash (`~/`) points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/static-files>.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

This article is an overview of key topics for understanding how to develop ASP.NET Core apps.

## The Startup class

The `Startup` class is where:

* Services required by the app are configured.
* The request handling pipeline is defined.

*Services* are components that are used by the app. For example, a logging component is a service. Code to configure (or *register*) services is added to the `Startup.ConfigureServices` method.

The request handling pipeline is composed as a series of *middleware* components. For example, a middleware might handle requests for static files or redirect HTTP requests to HTTPS. Each middleware performs asynchronous operations on an `HttpContext` and then either invokes the next middleware in the pipeline or terminates the request. Code to configure the request handling pipeline is added to the `Startup.Configure` method.

Here's a sample `Startup` class:

[!code-csharp[](index/samples_snapshot/2.x/Startup.cs?highlight=3,12)]

For more information, see <xref:fundamentals/startup>.

## Dependency injection (services)

ASP.NET Core has a built-in dependency injection (DI) framework that makes configured services available to an app's classes. One way to get an instance of a service in a class is to create a constructor with a parameter of the required type. The parameter can be the service type or an interface. The DI system provides the service at runtime.

Here's a class that uses DI to get an Entity Framework Core context object. The highlighted line is an example of constructor injection:

[!code-csharp[](index/samples_snapshot/2.x/Index.cshtml.cs?highlight=5)]

While DI is built in, it's designed to let you plug in a third-party Inversion of Control (IoC) container if you prefer.

For more information, see <xref:fundamentals/dependency-injection>.

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs asynchronous operations on an `HttpContext` and then either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component is added to the pipeline by invoking its `Use...` extension method in the `Startup.Configure` method. For example, to enable rendering of static files, call `UseStaticFiles`.

The highlighted code in the following example configures the request handling pipeline:

[!code-csharp[](index/samples_snapshot/2.x/Startup.cs?highlight=14-16)]

ASP.NET Core includes a rich set of built-in middleware, and you can write custom middleware.

For more information, see <xref:fundamentals/middleware/index>.

## Host

An ASP.NET Core app builds a *host* on startup. The host is an object that encapsulates all of the app's resources, such as:

* An HTTP server implementation
* Middleware components
* Logging
* DI
* Configuration

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown.

Two hosts are available: the Web Host and the Generic Host. In ASP.NET Core 2.x, the Generic Host is only for non-web scenarios.

The code to create a host is in `Program.Main`:

[!code-csharp[](index/samples_snapshot/2.x/Program.cs)]

The `CreateDefaultBuilder` method configures a host with commonly used options, such as the following:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load configuration from *appsettings.json*, *appsettings.{Environment Name}.json*, environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug providers.

For more information, see <xref:fundamentals/host/web-host>.

### Non-web scenarios

The Generic Host allows other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an `HttpContext`.

::: moniker-end

::: moniker range="= aspnetcore-2.2"

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *IIS HTTP Server* is a server for windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

# [macOS](#tab/macos)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. Kestrel can be run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

# [Linux](#tab/linux)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. Kestrel can be run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

---

::: moniker-end

::: moniker range="< aspnetcore-2.2"

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

# [macOS](#tab/macos)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. Kestrel can be run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

# [Linux](#tab/linux)

ASP.NET Core provides the *Kestrel* cross-platform server implementation. Kestrel can be run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

---

::: moniker-end

::: moniker range="< aspnetcore-3.0"

For more information, see <xref:fundamentals/servers/index>.

## Configuration

ASP.NET Core provides a configuration framework that gets settings as name-value pairs from an ordered set of configuration providers. There are built-in configuration providers for a variety of sources, such as *.json* files, *.xml* files, environment variables, and command-line arguments. You can also write custom configuration providers.

For example, you could specify that configuration comes from *appsettings.json* and environment variables. Then when the value of *ConnectionString* is requested, the framework looks first in the *appsettings.json* file. If the value is found there but also in an environment variable, the value from the environment variable would take precedence.

For managing confidential configuration data such as passwords, ASP.NET Core provides a [Secret Manager tool](xref:security/app-secrets). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

For more information, see <xref:fundamentals/configuration/index>.

## Options

Where possible, ASP.NET Core follows the *options pattern* for storing and retrieving configuration values. The options pattern uses classes to represent groups of related settings.

For example, the following code sets WebSockets options:

[!code-csharp[](index/samples_snapshot/2.x/UseWebSockets.cs)]

For more information, see <xref:fundamentals/configuration/options>.

## Environments

Execution environments, such as *Development*, *Staging*, and *Production*, are a first-class notion in ASP.NET Core. You can specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an `IHostingEnvironment` implementation. The environment object is available anywhere in the app via DI.

The following sample code from the `Startup` class configures the app to provide detailed error information only when it runs in development:

[!code-csharp[](index/samples_snapshot/2.x/StartupConfigure.cs?highlight=3-6)]

For more information, see <xref:fundamentals/environments>.

## Logging

ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include the following:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights

Write logs from anywhere in an app's code by getting an `ILogger` object from DI and calling log methods.

Here's sample code that uses an `ILogger` object, with constructor injection and the logging method calls highlighted.

[!code-csharp[](index/samples_snapshot/2.x/TodoController.cs?highlight=5,13,17)]

The `ILogger` interface lets you pass any number of fields to the logging provider. The fields are commonly used to construct a message string, but the provider can also send them as separate fields to a data store. This feature makes it possible for logging providers to implement [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

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

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, a *github* client can be registered and configured to access GitHub. A default client can be registered for other purposes.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to the inbound middleware pipeline in ASP.NET Core. The pattern provides a mechanism to manage cross-cutting concerns around HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying `HttpClientHandler` instances to avoid common DNS problems that occur when manually managing `HttpClient` lifetimes.
* Adds a configurable logging experience (via `ILogger`) for all requests sent through clients created by the factory.

For more information, see <xref:fundamentals/http-requests>.

## Content root

The content root is the base path to the:

* Executable hosting the app (*.exe*).
* Compiled assemblies that make up the app (*.dll*).
* Non-code content files used by the app, such as:
  * Razor files (*.cshtml*, *.razor*)
  * Configuration files (*.json*, *.xml*)
  * Data files (*.db*)
* [Web root](#web-root), typically the published *wwwroot* folder.

During development:

* The content root defaults to the project's root directory.
* The project's root directory is used to create the:
  * Path to the app's non-code content files in the project's root directory.
  * [Web root](#web-root), typically the *wwwroot* folder in the project's root directory.

An alternative content root path can be specified when [building the host](#host). For more information, see <xref:fundamentals/host/web-host#content-root>.

## Web root

The web root is the base path to public, non-code, static resource files, such as:

* Stylesheets (*.css*)
* JavaScript (*.js*)
* Images (*.png*, *.jpg*)

Static files are only served by default from the web root directory (and sub-directories).

The web root path defaults to *{content root}/wwwroot*, but a different web root can be specified when [building the host](#host). For more information, see [Web root](xref:fundamentals/host/web-host#web-root).

Prevent publishing files in *wwwroot* with the [\<Content> project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in the *wwwroot/local* directory and sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

In Razor (*.cshtml*) files, the tilde-slash (`~/`) points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/static-files>.

::: moniker-end
