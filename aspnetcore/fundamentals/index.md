---
title: ASP.NET Core fundamentals overview
ai-usage: ai-assisted
author: tdykstra
description: Learn the fundamental concepts for building ASP.NET Core apps, including dependency injection (DI), configuration, middleware, and more.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.date: 09/03/2026
uid: fundamentals/index
---
# ASP.NET Core fundamentals overview

[!INCLUDE[](~/includes/not-latest-version.md)]

This article provides an overview of the fundamentals for building ASP.NET Core apps, including dependency injection (DI), configuration, and middleware.

For Blazor fundamentals guidance, which adds to or supersedes the guidance in this article, see <xref:blazor/fundamentals/index>.

:::moniker range=">= aspnetcore-6.0"

## The `Program` file

ASP.NET Core apps created with the web templates contain the application startup code in the `Program` file (`Program.cs`). The `Program` file is where:

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

:::moniker range=">= aspnetcore-8.0 < aspnetcore-11.0"

The following app startup code supports several app types:

* [Blazor Web Apps](xref:blazor/index)
* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program8.cs)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

The following app startup code supports:

* [Razor Pages](xref:tutorials/razor-pages/razor-pages-start)
* [MVC controllers with views](xref:tutorials/first-mvc-app/start-mvc)
* [Web API with controllers](xref:tutorials/first-web-api)
* [Minimal APIs](xref:tutorials/min-web-api)

[!code-csharp[](~/fundamentals/index/snapshot/Program6.cs)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

## The `Startup` class

The `Startup` class (`Startup.cs`) is where:

* Services required by the app are configured in the `ConfigureServices` method.
* The app's request handling pipeline is defined in the `Configure` method as a series of middleware components.

[!code-csharp[](~/fundamentals/index/snapshot/Startup3.cs?highlight=3,12)]

:::moniker-end

For more information, see the following resources:

* <xref:fundamentals/startup>
* <xref:blazor/fundamentals/startup>

## Dependency injection (services)

<!-- DOC REVIEWER NOTE: I recommend that we simplify this and knock out
                        the Razor Pages content for >=6.0. Devs can get
                        details on DI in the DI articles. All this has 
                        to do is provide a brief overview with a few
                        examples, and the examples can be inlined for
                        simplicity in maintaining this article going 
                        forward.
-->

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core features built-in [dependency injection (DI)](xref:fundamentals/dependency-injection) that makes configured services available throughout an app. Services are added to the DI container with <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services?displayProperty=nameWithType>, `builder.Services` in the following code. 

When the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> is instantiated by <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType>, many [framework-provided services](xref:fundamentals/dependency-injection#framework-provided-services) are added automatically, such as services for configuration and logging:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

The following example registers Blazor services and an <xref:Microsoft.EntityFrameworkCore.IDbContextFactory%601> in the service collection to create instances of the <xref:Microsoft.EntityFrameworkCore.DbContext> type `BlazorWebAppMoviesContext`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext") 
        ?? throw new InvalidOperationException("Connection string not found.")));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContextFactory<BlazorWebAppMoviesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MoviesContext") 
        ?? throw new InvalidOperationException("Connection string not found.")));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

The DI framework provides instances of requested services at run time. In Blazor apps, services are often resolved from DI at run time using the [`@inject`](xref:mvc/views/razor#inject) directive in a Razor component. Blazor apps use the <xref:Microsoft.AspNetCore.Components.NavigationManager> service for querying and managing URI navigation. The service can be injected into a Razor component and used as a property of the component's class. In the following example, the code is only using the <xref:Microsoft.AspNetCore.Components.NavigationManager> abstraction to navigate the user when the button is selected:

```razor
@inject NavigationManager Navigation

<button @onclick="NavigateToCounter">
    Go to Counter
</button>

@code {
    private void NavigateToCounter()
    {
        Navigation.NavigateTo("/counter");
    }
}
```

Another way to resolve a service from DI is using constructor injection. In the following example, the [primary constructor (C# 12 or later)](/dotnet/csharp/whats-new/tutorials/primary-constructors) takes parameters of the types `AppDbContext` and `ILogger<Program>` and resolves them at run time into the `db` and `logger` variables:

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

You can also inject dependencies directly into the lambda parameters of Minimal API endpoints:

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

ASP.NET Core includes a built-in dependency injection (DI) framework that makes configured services available throughout an app. For example, a logging component is a service.

Code to configure (or *register*) services is added to the `Startup.ConfigureServices` method. For example:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<RazorPagesMovieContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("RazorPagesMovieContext")));

    services.AddControllersWithViews();
    services.AddRazorPages();
}
```

Services are typically resolved from DI using constructor injection. With constructor injection, a class declares a constructor parameter of either the required type or an interface. The DI framework provides an instance of this service at runtime.

If the built-in Inversion of Control (IoC) container doesn't meet all of an app's needs, a third-party IoC container can be used instead.

:::moniker-end

For more information, see the following resources:

* <xref:fundamentals/dependency-injection>
* <xref:blazor/fundamentals/dependency-injection>

## Middleware

The request handling pipeline is composed as a series of middleware components. Each component performs operations on an [`HttpContext`](xref:fundamentals/httpcontext) and either invokes the next middleware in the pipeline or terminates the request.

:::moniker range=">= aspnetcore-6.0"

By convention, a middleware component is added to the pipeline by invoking a `Use{Feature}` extension method. The use of methods named `Use{Feature}` to add middleware to an app is illustrated in the following code:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

[!code-csharp[](~/fundamentals/startup/6.0_samples/WebAll/Program.cs?name=snippet&highlight=12-19)]

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By convention, a middleware component is added to the pipeline by invoking a `Use...` extension method in the `Startup.Configure` method. For example, to enable rendering of static files, call `UseStaticFiles`. The following example configures a request handling pipeline:

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapDefaultControllerRoute();
        endpoints.MapRazorPages();
    });
}
```

ASP.NET Core includes a rich set of built-in middleware. Custom middleware components can also be written.

:::moniker-end

For more information, see <xref:fundamentals/middleware/index>.

## Host

On startup, an ASP.NET Core app builds a *host*. The host encapsulates all of the app's resources, such as:

* An HTTP server implementation
* Middleware components
* Logging
* Dependency injection (DI) services
* Configuration

:::moniker range=">= aspnetcore-6.0"

There are three different hosts capable of running an ASP.NET Core app:

* [ASP.NET Core WebApplication](xref:fundamentals/minimal-apis/webapplication), also known as the [Minimal Host](xref:migration/50-to-60#new-hosting-model).
* [.NET Generic Host](xref:fundamentals/host/generic-host) combined with ASP.NET Core's <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A>.
* [ASP.NET Core WebHost](xref:fundamentals/host/web-host).

The ASP.NET Core <xref:Microsoft.AspNetCore.Builder.WebApplication> and <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> types are recommended and are used in all the ASP.NET Core templates. `WebApplication` behaves similarly to the .NET Generic Host and exposes many of the same interfaces but requires fewer callbacks to configure. The ASP.NET Core <xref:Microsoft.AspNetCore.WebHost> is only available for backward compatibility.

The following example instantiates a <xref:Microsoft.AspNetCore.Builder.WebApplication> and assigns it to a variable named `app`:

```csharp
var builder = WebApplication.CreateBuilder(args);

...

var app = builder.Build();
```

The <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build%2A?displayProperty=nameWithType> method configures a host with a set of default options, such as:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load [configuration](xref:fundamentals/configuration/index) from app settings files (for example, `appsettings.json`), environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug logging providers.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

There are two different hosts: 

* .NET Generic Host
* ASP.NET Core Web Host

The .NET Generic Host is recommended. The ASP.NET Core Web Host is only available for backwards compatibility.

The following example creates a .NET Generic Host:

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

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> and <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> methods configure a host with a set of default options, such as:

* Use [Kestrel](#servers) as the web server and enable IIS integration.
* Load configuration from app settings files (for example, `appsettings.json`), environment variables, command line arguments, and other configuration sources.
* Send logging output to the console and debug providers.

:::moniker-end

For more information, see the following resources:

* <xref:fundamentals/host/generic-host> (*Recommended*)
* <xref:fundamentals/host/web-host> (*For backwards compatibility*)

### Non-web scenarios

The Generic Host enables other types of apps to use cross-cutting framework extensions, such as logging, dependency injection (DI), configuration, and app lifetime management. For more information, see <xref:fundamentals/host/generic-host> and <xref:fundamentals/host/hosted-services>.

## Servers

An ASP.NET Core app uses an HTTP server implementation to listen for HTTP requests. The server surfaces requests to the app as a set of [request features](xref:fundamentals/request-features) composed into an <xref:Microsoft.AspNetCore.Http.HttpContext>.

For more information, see <xref:fundamentals/servers/index>.

### Windows

ASP.NET Core provides the following server implementations:

* *Kestrel* is a cross-platform web server. Kestrel is often run in a reverse proxy configuration using [IIS](https://www.iis.net/). In ASP.NET Core 2.0 or later, Kestrel can be run as a public-facing edge server exposed directly to the Internet.
* *IIS HTTP Server* is a server for Windows that uses IIS. With this server, the ASP.NET Core app and IIS run in the same process.
* *HTTP.sys* is a server for Windows that isn't used with IIS.

### macOS

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

### Linux

ASP.NET Core provides the *Kestrel* cross-platform server implementation. In ASP.NET Core 2.0 or later, Kestrel can run as a public-facing edge server exposed directly to the Internet. Kestrel is often run in a reverse proxy configuration with [Nginx](https://nginx.org) or [Apache](https://httpd.apache.org/).

## Configuration

ASP.NET Core provides a [configuration](xref:fundamentals/configuration/index) framework that gets settings as name-value pairs from an ordered set of configuration providers. Built-in configuration providers are available for a variety of sources, such as `.json` files, `.xml` files, environment variables, and command-line arguments. Write custom configuration providers to support other sources.

By [default](xref:fundamentals/configuration/index#default-app-configuration-sources), ASP.NET Core apps are configured to read from `appsettings.json`, environment variables, the command line, and more. When the app's configuration is loaded, values from environment variables override values from `appsettings.json`.

The preferred way to read related configuration values is using the [options pattern](xref:fundamentals/configuration/options).

For managing confidential configuration data such as passwords in the `Development` environment, .NET provides the [Secret Manager](xref:security/app-secrets#secret-manager). For production secrets, we recommend [Azure Key Vault](xref:security/key-vault-configuration).

For more information, see the following resources:

* <xref:fundamentals/configuration/index>
* <xref:blazor/fundamentals/configuration>

## Environments

Execution environments, such as `Development`, `Staging`, and `Production`, are available in ASP.NET Core. Specify the environment an app is running in by setting the `ASPNETCORE_ENVIRONMENT` environment variable. ASP.NET Core reads that environment variable at app startup and stores the value to control code execution around the app.

The following example configures the exception handler and [HTTP Strict Transport Security (HSTS) protocol](xref:security/enforcing-ssl#http-strict-transport-security-hsts-protocol) middleware when ***not*** running in the `Development` environment:

:::moniker range=">= aspnetcore-6.0"

```csharp
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    ...
}
```

:::moniker-end

For more information, see the following resources:

* <xref:fundamentals/environments>
* <xref:blazor/fundamentals/environments>

## Logging

ASP.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. Available providers include:

* Console
* Debug
* Event Tracing on Windows
* Windows Event Log
* TraceSource
* Azure App Service
* Azure Application Insights

To create logs, resolve an <xref:Microsoft.Extensions.Logging.ILogger%601> service from dependency injection (DI) and call logging methods such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>. A logger object and a console provider for it are stored in the DI container automatically when the <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> method is called.

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

For more information, including routing guidance for Razor Pages and MVC apps, see the following resources:

* <xref:fundamentals/logging/index>
* <xref:blazor/fundamentals/logging>

## Routing

Routing in ASP.NET Core is a mechanism that maps incoming requests to specific endpoints in an application. It enables you to define URL patterns that correspond to different components, such as Razor components, Razor pages, MVC controller actions, or middleware.

The <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> method adds routing middleware to the request pipeline. This middleware processes the routing information and determines the appropriate endpoint for each request. Since the release of .NET 9, `UseRouting` isn't explicitly called in developer code unless you want to change the order in which middleware is processed.

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

For more information, see the following resources:

* <xref:fundamentals/error-handling>
* <xref:blazor/fundamentals/handle-errors>

## Make HTTP requests

An implementation of <xref:System.Net.Http.IHttpClientFactory> is available for creating <xref:System.Net.Http.HttpClient> instances. The factory:

* Provides a central location for naming and configuring logical `HttpClient` instances. For example, rely on a default client for most of the app's data requests with a web API and register a different configured client for accessing GitHub.
* Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to ASP.NET Core's inbound middleware pipeline. The pattern provides a mechanism to manage cross-cutting concerns for HTTP requests, including caching, error handling, serialization, and logging.
* Integrates with *Polly*, a popular third-party library for transient fault handling.
* Manages the pooling and lifetime of underlying <xref:System.Net.Http.HttpClientHandler> instances to avoid common DNS problems that occur when managing `HttpClient` lifetimes manually.
* Adds a configurable logging experience via <xref:Microsoft.Extensions.Logging.ILogger> for all requests sent through clients created by the factory.

For more information, see the following resources:

* <xref:fundamentals/http-requests>
* <xref:blazor/call-web-api>

## Content root

The content root is the base path for:

* The executable hosting the app (*.exe*).
* Compiled assemblies that make up the app (*.dll*).
* Content files used by the app, such as:
  * Razor files (`.cshtml`, `.razor`)
  * Configuration files (`.json`, `.xml`)
  * Data files (`.db`)
* The [Web root](#web-root), typically the `wwwroot` folder.

During development, the content root defaults to the project's root directory. This directory is also the base path for both the app's content files and the [web root](#web-root). Specify a different content root by setting its path when [building the host](#host). For more information, see [Content root](xref:fundamentals/host/generic-host#contentroot).

For more information, see <xref:fundamentals/static-files>.

## Web root

The web root is the base path for public, static resource files, such as:

* Stylesheets (`.css`)
* JavaScript (`.js`)
* Images (`.png`, `.jpg`)

By default, static files are served only from the web root directory and its sub-directories. The web root path defaults to `{CONTENT ROOT}/wwwroot`, where the `{CONTENT ROOT}` placeholder is the content root. Specify a different web root by setting its path when [building the host](#host). For more information, see [Web root](xref:fundamentals/host/generic-host#webroot).

Prevent publishing files in `wwwroot` with the [`<Content>` project item](/visualstudio/msbuild/common-msbuild-project-items#content) in the project file. The following example prevents publishing content in `wwwroot/local` and its sub-directories:

```xml
<ItemGroup>
  <Content Update="wwwroot\local\**\*.*" CopyToPublishDirectory="Never" />
</ItemGroup>
```

In Razor `.cshtml` files, `~/` points to the web root. A path beginning with `~/` is referred to as a *virtual path*.

For more information, see <xref:fundamentals/static-files>.

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

## Additional resources

<xref:blazor/fundamentals/index>


