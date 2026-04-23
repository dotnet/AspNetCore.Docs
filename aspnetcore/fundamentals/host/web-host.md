---
title: ASP.NET Core Web Host
author: tdykstra
description: Learn about Web Host in ASP.NET Core, which is responsible for app startup and lifetime management.
ms.author: tdykstra
ms.custom: mvc
ms.date: 04/22/2026
uid: fundamentals/host/web-host

# customer intent: As an ASP.NET developer, I want to explore the Web Host in ASP.NET Core, so I can configure startup and management for my web app.
---
# ASP.NET Core Web Host

[!INCLUDE[](~/includes/not-latest-version.md)]

ASP.NET Core apps configure and launch a *host*. The host is responsible for app startup and lifetime management. At a minimum, the host configures a server and a request processing pipeline. The host can also set up logging, dependency injection, and configuration.

This article covers the Web Host, which remains available only for backward compatibility. The ASP.NET Core templates create a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and <xref:Microsoft.AspNetCore.Builder.WebApplication>, which is recommended for web apps. For more information on `WebApplicationBuilder` and `WebApplication`, see <xref:migration/50-to-60#new-hosting-model>.

## Set up a host

Create a host by using an instance of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. This task is typically performed in the app's entry point, the `Main` method in the _Program.cs_ file. A typical app calls the <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> method to start setting up a host:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
}
```

The code that calls `CreateDefaultBuilder` is in a method named `CreateWebHostBuilder`, which separates it from the code in `Main` that calls the `Run` method on the builder object. The separation is required if you use [Entity Framework Core tools](/ef/core/cli/). The tools expect to find a `CreateWebHostBuilder` method that they can call at design time to configure the host without running the app. An alternative is to create an instance of `IDesignTimeDBContextfactory`. For more information, see [Design-time DbContext Creation](/ef/core/cli/dbcontext-creation).

The `CreateDefaultBuilder` method performs the following tasks:

* Configures [Kestrel](xref:fundamentals/servers/kestrel) server as the web server by using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.

* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A>.

* Loads the [host configuration](#set-web-host-configuration-values) from the following sources:
  * Environment variables prefixed with `ASPNETCORE_` (for example, `ASPNETCORE_ENVIRONMENT`)
  * Command-line arguments

* Loads the app configuration in the following order:
  * _appsettings.json_ file
  * _appsettings.{Environment}.json_ file
  * [User secrets](xref:security/app-secrets) (Loaded when the app runs in the `Development` environment by using the entry assembly.)
  * Environment variables
  * Command-line arguments

* Configures [logging](xref:fundamentals/logging/index) for console and debug output. Logging includes [log filtering](xref:fundamentals/logging/index#apply-log-filter-rules-in-code) rules specified in a Logging configuration section of an _appsettings.json_ or _appsettings.{Environment}.json_ file.

* When the application runs behind IIS with the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), `CreateDefaultBuilder` enables [IIS Integration](xref:host-and-deploy/iis/index), which configures the application base address and port. IIS Integration also configures the app to [capture startup errors](#capture-startup-errors). For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.

* Sets the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A> property to `true`, if the application environment is `Development`. For more information, see [Configure scope validation](#configure-scope-validation).

The [content root](xref:fundamentals/index#content-root) determines where the host searches for content files, such as MVC view files. When the app launches from the project root folder, that folder is used as the content root. This behavior is the default for [Visual Studio](https://visualstudio.microsoft.com) and the [dotnet new templates](/dotnet/core/tools/dotnet-new).

For more information on app configuration, see <xref:fundamentals/configuration/index>.

> [!NOTE]
> As an alternative to using the static `CreateDefaultBuilder` method, you can create a host from <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> with ASP.NET Core 2.x.

When you set up a host, you can use the <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Configure%2A> and <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureServices%2A> methods. If a `Startup` class is specified, it must define a `Configure` method. For more information, see <xref:fundamentals/startup>. Multiple calls to `ConfigureServices` append each other. Multiple calls to `Configure` or `UseStartup` on the `WebHostBuilder` instance replace any previous settings.

### Methods for overriding the configuration

You can override and augment the configuration defined by `CreateDefaultBuilder`. Use the <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A> and <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureLogging%2A> methods, and other methods and extension methods of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>.

Here are some examples:

* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A> is used to specify other `IConfiguration` properties for the app. The following call to the `ConfigureAppConfiguration` method adds a delegate to include app configuration in the _appsettings.xml_ file. `ConfigureAppConfiguration` can be called multiple times. This configuration doesn't apply to the host (for example, server URLs or environment). For more information, see the [Host configuration values](#set-web-host-configuration-values) section.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
        })
        ...
    ```

* The following `ConfigureLogging` call adds a delegate to configure the minimum logging level (<xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A>) to <xref:Microsoft.Extensions.Logging.LogLevel#microsoft-extensions-logging-loglevel-warning>. This setting overrides the settings in the _appsettings.Development.json_ file (`LogLevel.Debug`) and _appsettings.Production.json_ file (`LogLevel.Error`) configured by the `CreateDefaultBuilder` method. `ConfigureLogging` can be called multiple times.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging => 
        {
            logging.SetMinimumLevel(LogLevel.Warning);
        })
        ...
    ```

* The following call to `ConfigureKestrel` overrides the default [Limits.MaxRequestBodySize](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize%2A) of 30,000,000 bytes established when Kestrel is configured with the `CreateDefaultBuilder` method:

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel((context, options) =>
        {
            options.Limits.MaxRequestBodySize = 20000000;
        });
    ```

## Set Web Host configuration values

The <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> instance relies on the following approaches to set the host configuration values:

* The host builder configuration, which includes environment variables that use the format `ASPNETCORE_{configurationKey}`. For example, `ASPNETCORE_ENVIRONMENT`.

* Extensions, such as <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseContentRoot%2A> and <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A>. For more information, see [Override the Web Host configuration](#override-the-web-host-configuration).

* The <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.UseSetting%2A> method and the associated key. When you set a value with `UseSetting`, the value is set as a string, regardless of the type.

The host uses whichever option sets a value last. For more information, see [Override the Web Host configuration](#override-the-web-host-configuration).

<!-- In the following sections, two spaces at end of line are used to force line breaks in the rendered page. -->

### Application name

Defines the name of the assembly that contains the entry point for the application.

**Key**: `applicationName`  
**Type**: *string*  
**Default**: The name of the assembly that has the app entry point.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_APPLICATIONNAME`

The `IWebHostEnvironment.ApplicationName` property is automatically set when the <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A> or <xref:Microsoft.AspNetCore.Hosting.IStartup.Configure%2A> method is called during host construction. To set the value explicitly, use the <xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.ApplicationKey> field.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.ApplicationKey, "CustomApplicationName")
```

### Capture startup errors

Controls the capture of startup errors.

**Key**: `captureStartupErrors`  
**Type**: *bool* (`true` or `1`)  
**Default**: `false`. If the app runs with Kestrel behind IIS, the default is `true`.  
**Set using**: `CaptureStartupErrors`  
**Environment variable**: `ASPNETCORE_CAPTURESTARTUPERRORS`

When set to `false`, errors during startup result in the host exiting. When set to `true`, the host captures exceptions during startup and attempts to start the server.

```csharp
WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(true)
```

### Content root

Determines where ASP.NET Core begins searching for content files.

**Key**: `contentRoot`  
**Type**: *string*  
**Default**: The folder that contains the app assembly.  
**Set using**: `UseContentRoot`  
**Environment variable**: `ASPNETCORE_CONTENTROOT`

The content root is also used as the base path for the [web root](xref:fundamentals/index#web-root). If the content root path doesn't exist, the host fails to start.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseContentRoot("c:\\<content-root>")
```

For more information, see:

* [Fundamentals: Content root](xref:fundamentals/index#content-root)
* [Web root](#web-root)

### Detailed errors

Determines whether to capture detailed errors.

**Key**: `detailedErrors`  
**Type**: *bool* (`true` or `1`)  
**Default**: `false`  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_DETAILEDERRORS`

When enabled (or when the <a href="#environment">Environment</a> value is set to `Development`), the app captures detailed exceptions.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
```

### Environment

Sets the application environment.

**Key**: `environment`  
**Type**: *string*  
**Default**: `Production`  
**Set using**: `UseEnvironment`  
**Environment variable**: `ASPNETCORE_ENVIRONMENT`

The environment can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case sensitive.

By default, the *Environment* is read from the `ASPNETCORE_ENVIRONMENT` environment variable. When you use [Visual Studio](https://visualstudio.microsoft.com), environment variables can be set in the _launchSettings.json_ file. For more information, see <xref:fundamentals/environments>.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseEnvironment(EnvironmentName.Development)
```

### Hosting startup assemblies

Provides a semicolon-delimited string of hosting startup assemblies to load on startup.

**Key**: `hostingStartupAssemblies`  
**Type**: *string*  
**Default**: An empty string.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`

Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2")
```

### HTTPS port

Sets the HTTPS port for redirection if you get a non-HTTPS connection.

**Key**: `https_port`  
**Type**: *string*  
**Default**: No default.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HTTPS_PORT`

This setting is used in [enforcing HTTPS](xref:security/enforcing-ssl). This setting doesn't cause the server to listen on the specified port. That is, it's possible to accidentally redirect requests to an unused port.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("https_port", "8080")
```

### Hosting startup exclude assemblies

Provides a semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: `hostingStartupExcludeAssemblies`  
**Type**: *string*  
**Default**: An empty string.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2")
```

### Prefer hosting URLs

Indicates whether the host should listen on the URLs configured with the `WebHostBuilder` instead of the URLs configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: *bool* (`true` or `1`)  
**Default**: `false`  
**Set using**: `PreferHostingUrls`  
**Environment variable**: `ASPNETCORE_PREFERHOSTINGURLS`

```csharp
WebHost.CreateDefaultBuilder(args)
    .PreferHostingUrls(true)
```

### Prevent hosting startup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: `preventHostingStartup`  
**Type**: *bool* (`true` or `1`)  
**Default**: `false`  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_PREVENTHOSTINGSTARTUP`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
```

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: `urls`  
**Type**: *string*  
**Default**: `http://localhost:5000`  
**Set using**: `UseUrls`  
**Environment variable**: `ASPNETCORE_URLS`

Set to a semicolon-separated `;` list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use a wildcard asterisk `*` to indicate that the server should listen for requests on any IP address or hostname by using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### Shutdown timeout

Specifies the amount of time to wait for the Web Host to shut down.

**Key**: `shutdownTimeoutSeconds`  
**Type**: *int*  
**Default**: 5 seconds  
**Set using**: `UseShutdownTimeout`  
**Environment variable**: `ASPNETCORE_SHUTDOWNTIMEOUTSECONDS`

Although the key accepts an *int* with `UseSetting` (for example, `.UseSetting(WebHostDefaults.ShutdownTimeoutKey, "10")`), the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseShutdownTimeout%2A> extension method takes a <xref:System.TimeSpan> parameter.

During the timeout period, the Web Host:

* Triggers <xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopping%2A>.
* Attempts to stop hosted services, logging any errors for services that fail to stop.

If the timeout period expires before all hosted services stop, any remaining active services stop when the app shuts down. The services stop even if they're still processing. If services require more time to stop, increase the timeout.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseShutdownTimeout(TimeSpan.FromSeconds(10))
```

### Startup assembly

Specifies the assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: *string*  
**Default**: The application assembly.  
**Set using**: `UseStartup`  
**Environment variable**: `ASPNETCORE_STARTUPASSEMBLY`

You can reference the assembly by name (`string`) or type (`TStartup`). If multiple `UseStartup` methods are called, the last call takes precedence.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup("StartupAssemblyName")
```

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<TStartup>()
```

### Web root

Sets the relative path to the app's static assets.

**Key**: `webroot`  
**Type**: *string*  
**Default**: `wwwroot`  
**Set using**: `UseWebRoot`  
**Environment variable**: `ASPNETCORE_WEBROOT`

The path to `{content root}/wwwroot` must exist. If the path doesn't exist, a no-op file provider is used.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseWebRoot("public")
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [Content root](#content-root)

## Override the Web Host configuration

Use application [configuration in ASP.NET Core](xref:fundamentals/configuration/index) to configure the Web Host.

In the following example, host configuration is optionally specified in a _hostsettings.json_ file. Command-line arguments can override any configuration loaded from the _hostsettings.json_ file. The built configuration (in config) is used to configure the host with the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> method. `IWebHostBuilder` configuration is added to the application configuration, but the converse isn't true. The `ConfigureAppConfiguration` method doesn't affect the `IWebHostBuilder` configuration.

Overriding the configuration provided by `UseUrls` with the _hostsettings.json_ config followed by the command-line argument config:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hostsettings.json", optional: true)
            .AddCommandLine(args)
            .Build();

        return WebHost.CreateDefaultBuilder(args)
            .UseUrls("http://*:5000")
            .UseConfiguration(config)
            .Configure(app =>
            {
                app.Run(context => 
                    context.Response.WriteAsync("Hello, World!"));
            });
    }
}
```

The _hostsettings.json_ file contents:

```json
{
    urls: "http://*:5005"
}
```

> [!NOTE]
> The <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> method only copies keys from the provided `IConfiguration` to the host builder configuration. Therefore, setting the `reloadOnChange: true` property for JSON, INI, and XML settings files have no effect.

To specify the host run on a particular URL, the desired value can be passed in from a command prompt when executing [dotnet run](/dotnet/core/tools/dotnet-run). The command-line argument overrides the `urls` value from the _hostsettings.json_ file, and the server listens on port 8080:

```dotnetcli
dotnet run --urls "http://*:8080"
```

## Manage the Web Host

To manage the Web Host, you use the following methods.

### Run

The `Run` method starts the web app and blocks the calling thread until the host is shut down:

```csharp
host.Run();
```

### Start

Run the host in a nonblocking manner by calling its `Start` method:

```csharp
using (host)
{
    host.Start();
    Console.ReadLine();
}
```

If a list of URLs is passed to the `Start` method, it listens on the URLs specified:

```csharp
var urls = new List<string>()
{
    "http://*:5000",
    "http://localhost:5001"
};

var host = new WebHostBuilder()
    .UseKestrel()
    .UseStartup<Startup>()
    .Start(urls.ToArray());

using (host)
{
    Console.ReadLine();
}
```

The app can initialize and start a new host with the preconfigured defaults of the `CreateDefaultBuilder` method by using a static convenience method. These methods start the server without console output and use the <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.WaitForShutdown%2A> method, which waits for a break (<kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows)/SIGINT (Windows), <kbd>Ctrl</kbd>+<kbd>C</kbd> (macOS), or SIGTERM).

### Start(RequestDelegate app)

Run the host with a `RequestDelegate`:

```csharp
using (var host = WebHost.Start(app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Make a request in the browser to the `http://localhost:5000` URL to receive the response "Hello World!" The `WaitForShutdown` method blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

### Start(string url, RequestDelegate app)

Run the host with a URL and a `RequestDelegate`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Produces the same result as **Start(RequestDelegate app)**, except the app responds on the `http://localhost:8080` URL.

### Start(Action\<IRouteBuilder> routeBuilder)

Run the host by starting with an instance of `IRouteBuilder` ([Microsoft.AspNetCore.Routing](https://www.nuget.org/packages/Microsoft.AspNetCore.Routing/)), which uses routing middleware:

```csharp
using (var host = WebHost.Start(router => router
    .MapGet("hello/{name}", (req, res, data) => 
        res.WriteAsync($"Hello, {data.Values["name"]}!"))
    .MapGet("buenosdias/{name}", (req, res, data) => 
        res.WriteAsync($"Buenos dias, {data.Values["name"]}!"))
    .MapGet("throw/{message?}", (req, res, data) => 
        throw new Exception((string)data.Values["message"] ?? "Uh oh!"))
    .MapGet("{greeting}/{name}", (req, res, data) => 
        res.WriteAsync($"{data.Values["greeting"]}, {data.Values["name"]}!"))
    .MapGet("", (req, res, data) => res.WriteAsync("Hello, World!"))))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Use the following browser requests with the example:

| Request | Response |
|--|--|
| `http://localhost:5000/hello/Martin` | Hello, Martin! |
| `http://localhost:5000/buenosdias/Catrina` | Buenos dias, Catrina! |
| `http://localhost:5000/throw/ooops!` | Throws an exception with string "oops!" |
| `http://localhost:5000/throw` | Throws an exception with string "Uh oh!" |
| `http://localhost:5000/Sante/Kevin` | Sante, Kevin! |
| `http://localhost:5000` | Hello World! |

The `WaitForShutdown` method blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

### Start(string url, Action\<IRouteBuilder> routeBuilder)

Run the host by starting with a URL and an instance of `IRouteBuilder`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", router => router
    .MapGet("hello/{name}", (req, res, data) => 
        res.WriteAsync($"Hello, {data.Values["name"]}!"))
    .MapGet("buenosdias/{name}", (req, res, data) => 
        res.WriteAsync($"Buenos dias, {data.Values["name"]}!"))
    .MapGet("throw/{message?}", (req, res, data) => 
        throw new Exception((string)data.Values["message"] ?? "Uh oh!"))
    .MapGet("{greeting}/{name}", (req, res, data) => 
        res.WriteAsync($"{data.Values["greeting"]}, {data.Values["name"]}!"))
    .MapGet("", (req, res, data) => res.WriteAsync("Hello, World!"))))
{
    Console.WriteLine("Use Ctrl-C to shut down the host...");
    host.WaitForShutdown();
}
```

Produces the same result as [Start(Action\<IRouteBuilder> routeBuilder)](#startactioniroutebuilder-routebuilder), except the app responds on the `http://localhost:8080` URL.

### StartWith(Action\<IApplicationBuilder> app)

Run the host by starting with a delegate that configures an `IApplicationBuilder`:

```csharp
using (var host = WebHost.StartWith(app => 
    app.Use(next => 
    {
        return async context => 
        {
            await context.Response.WriteAsync("Hello World!");
        };
    })))
{
    Console.WriteLine("Use Ctrl-C to shut down the host...");
    host.WaitForShutdown();
}
```

Make a request in the browser to the `http://localhost:5000` URL to receive the response "Hello World!" The `WaitForShutdown` method blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

### StartWith(string url, Action\<IApplicationBuilder> app)

Run the host by starting with a URL and a delegate that configures an `IApplicationBuilder`:

```csharp
using (var host = WebHost.StartWith("http://localhost:8080", app => 
    app.Use(next => 
    {
        return async context => 
        {
            await context.Response.WriteAsync("Hello World!");
        };
    })))
{
    Console.WriteLine("Use Ctrl-C to shut down the host...");
    host.WaitForShutdown();
}
```

Produces the same result as [StartWith(Action\<IApplicationBuilder> app)](#startwithactioniapplicationbuilder-app), except the app responds on the `http://localhost:8080` URL.

## Use the IWebHostEnvironment interface

The `IWebHostEnvironment` interface provides information about the app's web hosting environment. Use [constructor injection](xref:fundamentals/dependency-injection) to obtain the `IWebHostEnvironment` instance, and then access its properties and extension methods:

```csharp
public class CustomFileReader
{
    private readonly IWebHostEnvironment _env;

    public CustomFileReader(IWebHostEnvironment env)
    {
        _env = env;
    }

    public string ReadFile(string filePath)
    {
        var fileProvider = _env.WebRootFileProvider;
        // Process the file here
    }
}
```

A [convention-based approach](xref:fundamentals/environments#environment-based-startup-class-and-methods) can be used to configure the app at startup based on the environment. Alternatively, inject the `IWebHostEnvironment` instance into the `Startup` constructor for use in the `ConfigureServices` method:

```csharp
public class Startup
{
    public Startup(IWebHostEnvironment env)
    {
        HostingEnvironment = env;
    }

    public IWebHostEnvironment HostingEnvironment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        if (HostingEnvironment.IsDevelopment())
        {
            // Development configuration
        }
        else
        {
            // Staging/Production configuration
        }

        var contentRootPath = HostingEnvironment.ContentRootPath;
    }
}
```

> [!NOTE]
> In addition to the `IsDevelopment` extension method, `IWebHostEnvironment` offers the `IsStaging`, `IsProduction`, and `IsEnvironment(string environmentName)` methods. For more information, see <xref:fundamentals/environments>.

The `IWebHostEnvironment` service can also be injected directly into the `Configure` method for setting up the processing pipeline:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        // In Development, use the Developer Exception Page
        app.UseDeveloperExceptionPage();
    }
    else
    {
        // In Staging/Production, route exceptions to /error
        app.UseExceptionHandler("/error");
    }

    var contentRootPath = env.ContentRootPath;
}
```

`IWebHostEnvironment` can be injected into the `Invoke` method when creating custom [middleware](xref:fundamentals/middleware/write):

```csharp
public async Task Invoke(HttpContext context, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        // Configure middleware for Development
    }
    else
    {
        // Configure middleware for Staging/Production
    }

    var contentRootPath = env.ContentRootPath;
}
```

## Use the IHostApplicationLifetime interface

`IHostApplicationLifetime` allows for post-startup and shutdown activities. Three properties on the interface are cancellation tokens used to register `Action` methods that define startup and shutdown events.

| Cancellation token | Trigger |
|--|--|
| `ApplicationStarted`  | The host is fully started. |
| `ApplicationStopped`  | The host is completing a graceful shutdown. All requests are expected to process. Shutdown blocks until this event completes. |
| `ApplicationStopping` | The host is performing a graceful shutdown. Requests might still be in process. Shutdown blocks until this event completes. |

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app, IHostApplicationLifetime appLifetime)
    {
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);

        Console.CancelKeyPress += (sender, eventArgs) =>
        {
            appLifetime.StopApplication();
            // Don't terminate the process immediately, wait for the Main thread to exit gracefully.
            eventArgs.Cancel = true;
        };
    }

    private void OnStarted()
    {
        // Perform post-startup activities here
    }

    private void OnStopping()
    {
        // Perform on-stopping activities here
    }

    private void OnStopped()
    {
        // Perform post-stopped activities here
    }
}
```

The `StopApplication` method requests termination of the app. The following class uses `StopApplication` to gracefully shut down an app when the class's `Shutdown` method is called:

```csharp
public class MyClass
{
    private readonly IHostApplicationLifetime _appLifetime;

    public MyClass(IHostApplicationLifetime appLifetime)
    {
        _appLifetime = appLifetime;
    }

    public void Shutdown()
    {
        _appLifetime.StopApplication();
    }
}
```

## Configure scope validation

The <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> method sets the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A> property to `true` if the app's environment is `Development`.

When `ValidateScopes` is set to `true`, the default service provider performs checks to verify:

* Scoped services aren't directly or indirectly resolved from the root service provider.
* Scoped services aren't directly or indirectly injected into singletons.

The root service provider is created when the <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> method is called. The root service provider's lifetime corresponds to the app/server's lifetime when the provider starts with the app and is disposed when the app shuts down.

The container that created the scoped services also disposes the services. If a scoped service is created in the root container, the service's lifetime is effectively promoted to singleton. The root container disposes the service only when the app/server is shut down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

To always validate scopes, including in the `Production` environment, configure the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions> object with the <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A> method on the host builder:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) => {
        options.ValidateScopes = true;
    })
```

## Related content

* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/windows-service>