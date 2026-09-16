---
title: ASP.NET Core fundamentals overview
ai-usage: ai-assisted
author: tdykstra
description: Learn the fundamental concepts for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 09/04/2026
uid: fundamentals/index
---
# ASP.NET Core fundamentals overview

[!INCLUDE[](~/includes/not-latest-version.md)]

This article provides an overview of the fundamentals for building ASP.NET Core apps, including dependency injection (DI), configuration, and middleware.

For Blazor fundamentals guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/index>.

:::moniker range=">= aspnetcore-6.0"

## The `Program` file

ASP.NET Core apps created from the framework's project templates contain startup code in the `Program` file (`Program.cs`). The `Program` file is where:

* Services required by the app are configured.
* The app's request handling pipeline is defined as a series of [middleware components](xref:fundamentals/middleware/index).

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

The following app startup code supports two app types:

* [Blazor Web Apps](xref:blazor/index)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program11.cs)]

> [!NOTE]
> With additional configuration in the `Program` file, ASP.NET Core apps can support [Razor Pages](xref:tutorials/razor-pages/razor-pages-start), [MVC](xref:tutorials/first-mvc-app/start-mvc), and [web API with controllers](xref:tutorials/first-web-api).

:::moniker-end

:::moniker range=">= aspnetcore-10.0 < aspnetcore-11.0"

The following app startup code supports two app types:

* [Blazor Web Apps](xref:blazor/index)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program10.cs)]

> [!NOTE]
> With additional configuration in the `Program` file, ASP.NET Core apps can support [Razor Pages](xref:tutorials/razor-pages/razor-pages-start), [MVC](xref:tutorials/first-mvc-app/start-mvc), and [web API with controllers](xref:tutorials/first-web-api).

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-10.0"

The following app startup code supports several app types:

* [Blazor Web Apps](xref:blazor/index)
* [Razor Pages](xref:tutorials/razor-pages/index)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Minimal APIs](xref:tutorials/min-web-api)
* [Web API with controllers](xref:tutorials/first-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program8.cs)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

The following app startup code supports:

* [Razor Pages](xref:tutorials/razor-pages/index)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Minimal APIs](xref:tutorials/min-web-api)
* [Web API with controllers](xref:tutorials/first-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program6.cs)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

## The `Startup` class

The `Startup` class (`Startup.cs`) is where:

* Services required by the app are configured in the `ConfigureServices` method.
* The app's request handling pipeline is defined in the `Configure` method as a series of [middleware components](xref:fundamentals/middleware/index).

The following app startup code supports:

* [Razor Pages](xref:tutorials/razor-pages/index)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Startup3.cs?highlight=3,12)]

:::moniker-end

For more information, see <xref:fundamentals/startup> and <xref:blazor/fundamentals/startup>.

## Dependency injection (services)

ASP.NET Core features built-in [dependency injection (DI)](xref:fundamentals/dependency-injection) that makes configured services available throughout an app for [Inversion of Control (IoC)](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#dependency-inversion). 

:::moniker range=">= aspnetcore-6.0"

When the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is instantiated by calling <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType>, [framework-provided services](xref:fundamentals/dependency-injection#framework-provided-services) are automatically added, such as services for configuration and logging:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

Additional services are added to the DI container with <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services?displayProperty=nameWithType>. The following example registers [Blazor](xref:blazor/index) services:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
builder.Services.AddServerSideBlazor();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

The DI framework provides instances of requested services at run time. In Blazor apps, services are often resolved from DI at run time using the [`@inject`](xref:mvc/views/razor#inject) directive in a [Razor component](xref:blazor/components/index) file (`.razor`). In the following example, the component uses the <xref:Microsoft.AspNetCore.Components.NavigationManager> abstraction to get an instance of the navigation manager, which is used for querying and managing URI navigation, to navigate the user to a page of products at `/products` when the button is selected:

```razor
@inject NavigationManager Navigation

<button @onclick="NavigateToProductList">
    Products
</button>

@code {
    private void NavigateToProductList()
    {
        Navigation.NavigateTo("/products");
    }
}
```

Another way to resolve a service from DI is using constructor injection. In the following example, the [primary constructor (C# 12 or later)](/dotnet/csharp/whats-new/tutorials/primary-constructors) takes parameters of the types `AppDbContext` and `ILogger<OrderProcessor>` and resolves them at run time into the `context` and `logger` variables (the instances of the database and logging abstractions). The database context instance is used to process all of the orders where the `IsProcessed` field is `false` in the database, and each processed order is logged as information with its order ID (`OrderId`) using the logger instance:

```csharp
public class OrderProcessor(AppDbContext context, ILogger<OrderProcessor> logger)
{
    public async Task ProcessPendingOrdersAsync()
    {
        var orders = await context.Orders
            .Where(o => !o.IsProcessed)
            .ToListAsync();

        foreach (var order in orders)
        {
            order.IsProcessed = true;
            logger.LogInformation("Processed order ID {OrderId}.", order.Id);
        }

        await context.SaveChangesAsync();
    }
}
```

You can also inject dependencies directly into the lambda parameters of [Minimal API](xref:tutorials/min-web-api) endpoints. In the following example, a list of todo items is returned from the `/todos` endpoint. A logger instance for `ILogger<Program>` logs information, and the database instance for `AppDbContext` is used to obtain the list of todo items from the database to in the response:

```csharp
app.MapGet("/todos", async (AppDbContext context, ILogger<Program> logger) =>
{
    logger.LogInformation("Fetching todos using inline handler injection.");
    var todos = await context.Todos.ToListAsync();

    return Results.Ok(todos);
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

When the <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=nameWithType> is called in the `Program` file, a new instance of the <xref:Microsoft.Extensions.Hosting.HostBuilder> class is automatically initialized with [framework-provided services](xref:fundamentals/dependency-injection#framework-provided-services), such as services for configuration and logging:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

Additional services are added to the DI container's service collection (<xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>) in the `Startup.ConfigureServices` method (`Startup.cs`). The following example registers MVC and Razor Pages services:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddRazorPages();
}
```

Services are typically resolved from DI using constructor injection. With constructor injection, a class declares a constructor parameter of either the required type or an interface. The DI framework provides an instance of the service at runtime.

:::moniker-end

If the built-in DI container doesn't meet your needs, a third-party IoC container can be used instead.

For more information, see <xref:fundamentals/dependency-injection> and <xref:blazor/fundamentals/dependency-injection>.

## Environments

Execution environments are available in ASP.NET Core, such as:

* `Development`: When the app is in local development.
* `Staging`: When the app is staged for deployment.
* `Production`: When the live app is running for users.

Specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable on the host where the app is running. ASP.NET Core reads the environment variable at app startup and stores the value to control code execution around the app.

:::moniker range=">= aspnetcore-6.0"

Developer code can check for a given environment. In the following `Program` file example, the code in the execution block only runs when the app isn't running in the `Development` environment:

```csharp
if (!app.Environment.IsDevelopment())
{
    ...
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (!env.IsDevelopment())
    {
        ...
    }

    ...
}
```

:::moniker-end

For more information, see <xref:fundamentals/environments> and <xref:blazor/fundamentals/environments>.

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs operations on an [`HttpContext`](xref:fundamentals/httpcontext) and either invokes the next middleware in the pipeline or terminates the request.

By convention, middleware components are added to the pipeline by invoking an extension method that starts with "`Use`." In the following example representing part of a request processing pipeline, middleware for exception handling (<xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>), [HTTP Strict Transport Security (HSTS) protocol](xref:security/enforcing-ssl#http-strict-transport-security-hsts-protocol) (<xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>), and HTTPS redirection (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>) are called. Two of the middlewares are only triggered when the app isn't under local development in the `Development` environment, such as when the app is staged for deployment (the `Staging` environment) or in production (the `Production` environment):

:::moniker range=">= aspnetcore-6.0"

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
if (env.IsDevelopment())
{
    ...
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
```

:::moniker-end

ASP.NET Core includes a rich set of built-in middleware. You can also create custom middleware components to meet an app's special request processing specifications. For more information, see <xref:fundamentals/middleware/index>.

## Host

On startup, an ASP.NET Core app builds a *host*. The host encapsulates all of the app's resources, such as:

* An HTTP server implementation
* Middleware components
* Logging
* Dependency injection (DI) services
* Configuration

:::moniker range=">= aspnetcore-6.0"

There are three different hosts capable of running an ASP.NET Core app:

* [ASP.NET Core WebApplication](xref:fundamentals/minimal-apis/webapplication) (also known as the [Minimal Host](xref:migration/50-to-60#new-hosting-model))
* [.NET Generic Host](xref:fundamentals/host/generic-host)
* [ASP.NET Core WebHost](xref:fundamentals/host/web-host)

The ASP.NET Core <xref:Microsoft.AspNetCore.Builder.WebApplication> and <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> types are recommended and are used in all of the ASP.NET Core project templates. `WebApplication` behaves similarly to the .NET Generic Host and exposes many of the same interfaces but requires fewer callbacks to configure. The ASP.NET Core <xref:Microsoft.AspNetCore.WebHost> is only available for backward compatibility.

The following example instantiates a <xref:Microsoft.AspNetCore.Builder.WebApplication> and assigns it to a variable named `app`:

```csharp
var builder = WebApplication.CreateBuilder(args);

...

var app = builder.Build();
```

The <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A?displayProperty=nameWithType> method configures a host with a set of default options, such as:

* Using [Kestrel](#servers) as the web server and enabling IIS integration.
* Loading [configuration](xref:fundamentals/configuration/index) from app settings files (for example, `appsettings.json`), environment variables, command line arguments, and other configuration sources.
* Setting up logging and directing logging output to the console and debug logging providers.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

There are two hosts: 

* [.NET Generic Host](xref:fundamentals/host/generic-host)
* [ASP.NET Core WebHost](xref:fundamentals/host/web-host)

The .NET Generic Host is recommended. The ASP.NET Core Web Host is only available for backwards compatibility.

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> and <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> methods in the following example configure a host with a set of default options, such as:

* Using [Kestrel](#servers) as the web server and enabling IIS integration.
* Loading [configuration](xref:fundamentals/configuration/index) from app settings files (for example, `appsettings.json`), environment variables, command line arguments, and other configuration sources.
* Setting up logging and directing logging output to the console and debug logging providers.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

:::moniker-end

For more information, see the following resources:

* <xref:fundamentals/host/generic-host> (*Recommended*)
* <xref:fundamentals/host/web-host> (*For backwards compatibility*)

### Non-web scenarios

The [Generic Host](xref:fundamentals/host/generic-host) enables other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an <xref:Microsoft.AspNetCore.Http.HttpContext>.

For more information, see <xref:fundamentals/servers/index>.

### Windows

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *IIS HTTP Server* is a server for Windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

### macOS and Linux

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

## Configuration

ASP.NET Core provides a [configuration](xref:fundamentals/configuration/index) framework that obtains settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as JSON files (`.json`), XML files (`.xml`), environment variables, and command-line arguments. You can create custom configuration providers to support other sources.

By default, ASP.NET Core apps are configured to read from app settings files (for example, `appsettings.json`), environment variables, and the command line.

When the app's configuration is loaded, values from environment variables override values from app settings files. The [Options API](xref:fundamentals/configuration/options) is available for reading related configuration values.

For managing confidential configuration data such as passwords in the `Development` environment, .NET provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend using [Azure Key Vault](https://azure.microsoft.com/products/key-vault). 

For more information, see the following resources:

* <xref:fundamentals/configuration/index>
* <xref:blazor/fundamentals/configuration>
* [Azure Key Vault (ASP.NET Core documentation)](xref:security/key-vault-configuration)

## Logging

ASP.NET Core supports a logging API that works with a variety of logging providers:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights
* Third-party providers

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>. A logger object and a console provider for the logger object are stored in the DI container automatically when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method is called.

The following example shows how to obtain a logging instance from DI and use it in a `Weather` component (`Weather.razor`) of a Blazor app that reports weather data:

```razor
@inject ILogger<Weather> Logger

...

@code {
    protected override async Task OnInitializedAsync()
    {
        Logger.LogInformation("OnInitializedAsync method called!");

        ...
    }
}
```

For more information, including routing guidance for Razor Pages and MVC apps, see <xref:fundamentals/logging/index> and <xref:blazor/fundamentals/logging>.

## Routing

Routing in ASP.NET Core is a mechanism that maps incoming requests to specific endpoints in an app. It enables you to define URL patterns that correspond to different components, such as Razor components, Razor pages, MVC controller actions, or middleware.

The <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> method adds routing middleware to the request pipeline. This middleware processes the routing information and determines the appropriate endpoint for each request. In apps using the [Minimal Host](#host), `UseRouting` isn't explicitly called in developer code unless you want to change middleware processing order.

For more information, see the following resources:

* <xref:fundamentals/routing>
* <xref:blazor/fundamentals/routing>
* <xref:blazor/fundamentals/navigation>

## Handle errors

ASP.NET Core has built-in features for handling errors, such as:

* A developer exception page
* Custom error pages
* Static status code pages
* Startup exception handling

For more information, see <xref:fundamentals/error-handling> and <xref:blazor/fundamentals/handle-errors>.

## Make HTTP requests

An implementation of <xref:System.Net.Http.IHttpClientFactory> is available for creating <xref:System.Net.Http.HttpClient> instances. The factory:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, rely on a default client for most of the app's data requests with a web API and register a different configured client for accessing GitHub.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying <xref:System.Net.Http.HttpClientHandler> instances to avoid common DNS problems that occur when managing `HttpClient` lifetimes manually.
* Adds a configurable logging experience via <xref:Microsoft.Extensions.Logging.ILogger> for all requests sent through clients created by the factory.

For more information, see <xref:fundamentals/http-requests> and <xref:blazor/call-web-api>.

## Content root

The content root is the base path for:

* The executable hosting the app (`.exe`).
* Compiled assemblies that make up the app (`.dll`).
* Content files used by the app, such as Razor files (`.cshtml`, `.razor`), configuration files (`.json`, `.xml`), and data files (`.db`).
* The [web root](#web-root), which is typically the `wwwroot` folder.

During development, the content root defaults to the project's root directory. This directory is also the base path for both the app's content files and the [web root](#web-root). Specify a different content root by setting its path when building the [host](#host).

For more information, see <xref:fundamentals/host/generic-host#contentroot> and <xref:fundamentals/static-files>.

## Web root

The web root is the base path for public, static resource files, such as stylesheets, JavaScript files, and images.

By default, static files are only served from the web root directory and its sub-directories. The web root path defaults to `{CONTENT ROOT}/wwwroot`, where the `{CONTENT ROOT}` placeholder is the content root. Specify a different web root by setting its path when [building the host](#host). You can also prevent publishing files in `wwwroot` with the [`<Content>` project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the app's project file.

In Razor `.cshtml` files, `~/` points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/host/generic-host#webroot> and <xref:fundamentals/static-files>.

## How to download a sample

Many of the articles and tutorials include links to sample code.

1. [Download the ASP.NET repository zip file](https://codeload.github.com/dotnet/AspNetCore.Docs/zip/main).
1. Unzip the `AspNetCore.Docs-main.zip` file.
1. To access an article's sample app in the unzipped repository, use the URL in the article's sample link to help you navigate to the sample's folder. Usually, an article's sample link appears at the top of the article with the link text *View or download sample code*. 

To obtain a single sample app and only its last commit, use [`git sparse-checkout`](https://git-scm.com/docs/git-sparse-checkout).

In the following example for the [Blazor samples GitHub repository](https://github.com/dotnet/blazor-samples), the `git sparse-checkout set` command specifies the path to the sample folder:

* Replace the `{VERSION FOLDER}` placeholder with the version folder.
* Replace the `{SAMPLE FOLDER}` placeholder with the sample folder.

In a command shell, navigate to the folder where you would like to clone the sample. Execute the following commands in the command shell passing the version/sample folder path to the `git sparse-checkout set` command:

```cli
git clone --depth 1 --filter=blob:none https://github.com/dotnet/blazor-samples.git --sparse
cd blazor-samples
git sparse-checkout init --cone
git sparse-checkout set {VERSION FOLDER}/{SAMPLE FOLDER}
```

The following [PowerShell](/powershell/) example obtains the 10.0 Blazor Web App sample and places it in the user's documents folder using PowerShell's `~/documents` path for the change directory (`cd`) command:

```powershell
cd "~/documents"
git clone --depth 1 --filter=blob:none https://github.com/dotnet/blazor-samples.git --sparse
cd blazor-samples
git sparse-checkout init --cone
git sparse-checkout set 10.0/BlazorSample_BlazorWebApp
```

## Preprocessor directives in sample code

To demonstrate multiple scenarios, sample apps use the `#define` and `#if-#else/#elif-#endif` preprocessor directives to selectively compile and run different sections of sample code. For those samples that make use of this approach, set the `#define` directive at the top of the C# files to define the symbol associated with the scenario that you want to run. Some samples require defining the symbol at the top of multiple files in order to run a scenario.

For example, the following `#define` symbol list indicates that four scenarios are available (one scenario per symbol). The current sample configuration runs the `TemplateCode` scenario:

```csharp
#define TemplateCode // or LogFromMain or ExpandDefault or FilterInCode
```

To change the sample to run the `ExpandDefault` scenario, define the `ExpandDefault` symbol and leave the remaining symbols commented-out:

```csharp
#define ExpandDefault // TemplateCode or LogFromMain or FilterInCode
```

For more information on using [C# preprocessor directives](/dotnet/csharp/language-reference/preprocessor-directives/) to selectively compile sections of code, see [#define (C# Reference)](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-define) and [#if (C# Reference)](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-if).

## Regions in sample code

Some sample apps contain sections of code surrounded by [#region](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-region) and [#endregion](/dotnet/csharp/language-reference/preprocessor-directives/preprocessor-endregion) C# directives. The documentation build system injects these regions into the rendered documentation topics.  

Region names usually contain the word "snippet." The following example shows a region named `snippet_WebHostDefaults`:

```csharp
#region snippet_WebHostDefaults
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    });
#endregion
```

The preceding C# code snippet is referenced in the topic's markdown file with the following line:

```md
[!code-csharp[](sample/SampleApp/Program.cs?name=snippet_WebHostDefaults)]
```

You may safely ignore or remove the `#region` and `#endregion` directives that surround the code. Don't alter the code within these directives if you plan to run the sample scenarios described in the topic.

For more information, see [Contribute to the ASP.NET documentation: Code snippets](https://github.com/dotnet/AspNetCore.Docs/blob/main/CONTRIBUTING.md#code-snippets).

## Document Object Model (DOM)

References to the *Document Object Model* throughout this documentation set use the abbreviation *DOM*.

For more information, see [Introduction to the DOM (MDN documentation)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) and [Level 1 Document Object Model Specification (W3C)](https://www.w3.org/TR/WD-DOM/).

## Byte multiples

.NET byte sizes use metric prefixes for non-decimal multiples of bytes based on powers of 1024.

Name (abbreviation) | Size | Example
--- | --- | ---
Kilobyte (KB) | 1,024 bytes | 1 KB = 1,024 bytes
Megabyte (MB) | 1,024<sup>2</sup> bytes | 1 MB = 1,048,576 bytes
Gigabyte (GB) | 1,024<sup>3</sup> bytes | 1 GB = 1,073,741,824 bytes

## Support requests

Only documentation-related issues are appropriate for the `dotnet/AspNetCore.Docs` repository. ***For product support, don't open a documentation issue.*** Seek assistance through one or more of the following support channels:

* [Stack Overflow for ASP.NET Core (tagged: `asp.net-core`)](https://stackoverflow.com/questions/tagged/asp.net-core)
* [Stack Overflow for Blazor (tagged: `blazor`)](https://stackoverflow.com/questions/tagged/blazor)
* [General ASP.NET Core Slack Team](https://join.slack.com/t/aspnetcore/shared_invite/zt-1mv5487zb-EOZxJ1iqb0A0ajowEbxByQ)
* [Blazor Gitter](https://gitter.im/aspnet/Blazor)

For a potential bug in the framework or product feedback, open an issue for the ASP.NET Core product unit at [`dotnet/aspnetcore` issues](https://github.com/dotnet/aspnetcore/issues). Bug reports usually require the following:

* **Clear explanation of the problem**: Follow the instructions in the GitHub issue template provided by the product unit when opening the issue.
* **Minimal repro project**: Place a project on GitHub for the product unit engineers to download and run. Cross-link the project into the issue's opening comment.

For a potential problem with an article, open a documentation issue. To open a documentation issue, use the **Open a documentation issue** feedback link at the bottom of the article. Metadata added to your issue provides tracking data and automatically pings the author of the article. If the subject was discussed with the product unit prior to opening the documentation issue, place a cross-link to the engineering issue in the documentation issue's opening comment.

GitHub issues for Blazor documentation are automatically marked for triage on the [`Blazor.Docs` project (`dotnet/AspNetCore.Docs` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs/projects/35). Please wait a short while for a response, especially over weekends and holidays. Usually, documentation authors respond within 24 hours on weekdays.

For problems or feedback on Visual Studio, use the [**Report a Problem**](/visualstudio/ide/how-to-report-a-problem-with-visual-studio) or [**Suggest a Feature**](/visualstudio/ide/suggest-a-feature) gestures from within Visual Studio, which open internal issues for Visual Studio. For more information, see [Visual Studio Feedback](https://developercommunity.visualstudio.com/home).

For problems with Visual Studio Code, ask for support on community support forums. For bug reports and product feedback, open an issue on the [`microsoft/vscode` GitHub repo](https://github.com/microsoft/vscode/issues).

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* Tutorials
  * <xref:blazor/tutorials/build-a-blazor-app>
  * <xref:blazor/tutorials/movie-database-app/index>
  * <xref:tutorials/min-web-api>
* <xref:blazor/fundamentals/index>

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* Tutorials
  * <xref:blazor/tutorials/build-a-blazor-app>
  * <xref:tutorials/min-web-api>
* <xref:blazor/fundamentals/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Tutorials
  * <xref:blazor/tutorials/build-a-blazor-app>
  * <xref:tutorials/razor-pages/index>
  * <xref:tutorials/first-mvc-app/start-mvc>
  * <xref:tutorials/first-web-api>
* <xref:blazor/fundamentals/index>

:::moniker-end
