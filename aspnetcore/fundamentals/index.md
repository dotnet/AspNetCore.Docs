---
title: ASP.NET Core fundamentals overview
author: tdykstra
description: Learn the fundamental concepts for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 08/01/2024
uid: fundamentals/index
---
# ASP.NET Core fundamentals overview

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-9.0"

This article provides an overview of the fundamentals for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.

For Blazor fundamentals guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/index>.

## Program.cs

ASP.NET Core apps created with the web templates contain the application startup code in the `Program.cs` file. The `Program.cs` file is where:

* Services required by the app are configured.
* The app's request handling pipeline is defined as a series of [middleware components](xref:fundamentals/middleware/index).

The following app startup code supports several app types:

* [Blazor Web Apps](xref:blazor/index)
* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal web APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/startup/9.0_samples/WebAll/Program.cs?name=snippet)]

## Dependency injection (services)

ASP.NET Core features built-in [dependency injection (DI)](xref:fundamentals/dependency-injection) that makes configured services available throughout an app. Services are added to the DI container with [WebApplicationBuilder.Services](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services), `builder.Services` in the preceding code. When the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is instantiated, many [framework-provided services](xref:fundamentals/dependency-injection#framework-provided-services) are added automatically. `builder` is a `WebApplicationBuilder` in the following code:

:::code language="csharp" source="~/fundamentals/startup/6.0_samples/WebAll/Program.cs" id="snippet2":::

In the preceding code, `CreateBuilder` adds configuration, logging, and [many other services](xref:fundamentals/dependency-injection#framework-provided-services) to the DI container. The DI framework provides an instance of a requested service at run time.

The following code adds a custom <xref:Microsoft.EntityFrameworkCore.DbContext> and Blazor components to the DI container:

:::code language="csharp" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Program.cs" id="snippet_services" highlight="2-4,11-12":::

In Blazor Web Apps, services are often resolved from DI at run time by using the `@inject` directive in a Razor component, as shown in the following example:

:::code language="razor" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Components/Pages/MoviePages/Index.razor" highlight ="8,44,48":::

In the preceding code:

* The `@inject` directive is used.
* The service is resolved in the `OnInitialized` method and assigned to the `context` variable.
* The `context` service creates the `FilteredMovie` list.

Another way to resolve a service from DI is by using constructor injection. The following Razor Pages code uses constructor injection to resolve the database context and a logger from DI:

 :::code language="csharp" source="~/fundamentals/index/samples/6.0/RazorPagesMovie/Pages/Movies/Index.cshtml.cs" id="snippet":::

In the preceding code, the `IndexModel` constructor takes a parameter of type `RazorPagesMovieContext`, which is resolved at run time into the `_context` variable. The context object is used to create a list of movies in the `OnGetAsync` method.

For more information, see <xref:blazor/fundamentals/dependency-injection> and <xref:fundamentals/dependency-injection>.

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs operations on an [`HttpContext`](xref:fundamentals/httpcontext) and either invokes the next middleware in the pipeline or terminates the request.

By convention, a middleware component is added to the pipeline by invoking a `Use{Feature}` extension method. The use of methods named `Use{Feature}` to add middleware to an app is illustrated in the following code:

:::code language="csharp" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Program.cs" id="snippet_middleware" highlight="26-28,30,32":::

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

The ASP.NET Core <xref:Microsoft.AspNetCore.Builder.WebApplication> and <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> types are recommended and are used in all the ASP.NET Core templates. `WebApplication` behaves similarly to the .NET Generic Host and exposes many of the same interfaces but requires fewer callbacks to configure. The ASP.NET Core <xref:Microsoft.AspNetCore.WebHost> is available only for backward compatibility.

The following example instantiates a `WebApplication` and assigns it to a variable named `app`:

:::code language="csharp" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Program.cs" id="snippet_services" highlight="1,14":::

The [WebApplicationBuilder.Build](xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A) method configures a host with a set of default options, such as:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load [configuration](xref:fundamentals/configuration/index) from `appsettings.json`, environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug providers.

### Non-web scenarios

The Generic Host enables other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an <xref:Microsoft.AspNetCore.Http.HttpContext>.

# [Windows](#tab/windows)

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 and later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
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

For managing confidential configuration data such as passwords in the development environment, .NET Core provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

For more information, see <xref:fundamentals/configuration/index>.

## Environments

Execution environments, such as `Development`, `Staging`, and `Production`, are available in ASP.NET Core. Specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable. ASP.NET Core reads that environment variable at app startup and stores the value in an `IWebHostEnvironment` implementation. This implementation is available anywhere in an app via dependency injection (DI).

The following example configures the exception handler and [HTTP Strict Transport Security Protocol (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) middleware when ***not*** running in the `Development` environment:

:::code language="csharp" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Program.cs" id="snippet_environments" highlight="1":::

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

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>. The following example shows how to get and use a logger in a `.razor` file for a page in a Blazor Web App. A logger object and a console provider for it are stored in the DI container automatically when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A> method is called in `Program.cs`.

:::code language="csharp" source="~/fundamentals/index/samples/9.0/BlazorWebAppMovies/Components/Pages/Weather.razor" highlight="3,49-51":::

For more information, see <xref:fundamentals/logging/index>.

## Routing

Routing in ASP.NET Core is a mechanism that maps incoming requests to specific endpoints in an application. It enables you to define URL patterns that correspond to different components, such as Blazor components, Razor pages, MVC controller actions, or middleware.

The <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting(Microsoft.AspNetCore.Builder.IApplicationBuilder)> method adds routing middleware to the request pipeline. This middleware processes the routing information and determines the appropriate endpoint for each request. You don't have to explicitly call `UseRouting` unless you want to change the order in which middleware is processed.

For more information, see <xref:fundamentals/routing> and <xref:blazor/fundamentals/routing>.

## Error handling

ASP.NET Core has built-in features for handling errors, such as:

* A developer exception page
* Custom error pages
* Static status code pages
* Startup exception handling

For more information, see <xref:fundamentals/error-handling>.

## Make HTTP requests

An implementation of <xref:System.Net.Http.IHttpClientFactory> is available for creating <xref:System.Net.Http.HttpClient> instances. The factory:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, register and configure a *github* client for accessing GitHub. Register and configure a default client for other purposes.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying <xref:System.Net.Http.HttpClientHandler> instances to avoid common DNS problems that occur when managing `HttpClient` lifetimes manually.
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

* <xref:blazor/fundamentals/index>

:::moniker-end

[!INCLUDE[](~/fundamentals/index/includes/index3-7.md)]
[!INCLUDE[](~/fundamentals/index/includes/index8.md)]
