---
title: ASP.NET Core Web Host
author: tdykstra
description: Learn about Web Host in ASP.NET Core, which is responsible for app startup and lifetime management.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/22/2022
uid: fundamentals/host/web-host
---
# ASP.NET Core Web Host

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core apps configure and launch a *host*. The host is responsible for app startup and lifetime management. At a minimum, the host configures a server and a request processing pipeline. The host can also set up logging, dependency injection, and configuration.

This article covers the Web Host, which remains available only for backward compatibility. The ASP.NET Core templates create a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and <xref:Microsoft.AspNetCore.Builder.WebApplication>, which is recommended for web apps. For more information on `WebApplicationBuilder` and `WebApplication`, see <xref:migration/50-to-60#new-hosting-model>

## Set up a host

Create a host using an instance of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. This is typically performed in the app's entry point, the `Main` method in `Program.cs`. A typical app calls <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> to start setting up a host:

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

The code that calls `CreateDefaultBuilder` is in a method named `CreateWebHostBuilder`, which separates it from the code in `Main` that calls `Run` on the builder object. This separation is required if you use [Entity Framework Core tools](/ef/core/miscellaneous/cli/). The tools expect to find a `CreateWebHostBuilder` method that they can call at design time to configure the host without running the app. An alternative is to implement `IDesignTimeDbContextFactory`. For more information, see [Design-time DbContext Creation](/ef/core/miscellaneous/cli/dbcontext-creation).

`CreateDefaultBuilder` performs the following tasks:

* Configures [Kestrel](xref:fundamentals/servers/kestrel) server as the web server using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.
* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A?displayProperty=nameWithType>.
* Loads [host configuration](#host-configuration-values) from:
  * Environment variables prefixed with `ASPNETCORE_` (for example, `ASPNETCORE_ENVIRONMENT`).
  * Command-line arguments.
* Loads app configuration in the following order from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment using the entry assembly.
  * Environment variables.
  * Command-line arguments.
* Configures [logging](xref:fundamentals/logging/index) for console and debug output. Logging includes [log filtering](xref:fundamentals/logging/index#apply-log-filter-rules-in-code) rules specified in a Logging configuration section of an `appsettings.json` or `appsettings.{Environment}.json` file.
* When running behind IIS with the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), `CreateDefaultBuilder` enables [IIS Integration](xref:host-and-deploy/iis/index), which configures the app's base address and port. IIS Integration also configures the app to [capture startup errors](#capture-startup-errors). For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.
* Sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development. For more information, see [Scope validation](#scope-validation).

The configuration defined by `CreateDefaultBuilder` can be overridden and augmented by <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A>, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureLogging%2A>, and other methods and extension methods of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. A few examples follow:

* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A> is used to specify additional `IConfiguration` for the app. The following `ConfigureAppConfiguration` call adds a delegate to include app configuration in the `appsettings.xml` file. `ConfigureAppConfiguration` may be called multiple times. Note that this configuration doesn't apply to the host (for example, server URLs or environment). See the [Host configuration values](#host-configuration-values) section.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
        })
        ...
    ```

* The following `ConfigureLogging` call adds a delegate to configure the minimum logging level (<xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A>) to <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>. This setting overrides the settings in `appsettings.Development.json` (`LogLevel.Debug`) and `appsettings.Production.json` (`LogLevel.Error`) configured by `CreateDefaultBuilder`. `ConfigureLogging` may be called multiple times.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging => 
        {
            logging.SetMinimumLevel(LogLevel.Warning);
        })
        ...
    ```

* The following call to `ConfigureKestrel` overrides the default [Limits.MaxRequestBodySize](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize%2A) of 30,000,000 bytes established when Kestrel was configured by `CreateDefaultBuilder`:

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel((context, options) =>
        {
            options.Limits.MaxRequestBodySize = 20000000;
        });
    ```

The [content root](xref:fundamentals/index#content-root) determines where the host searches for content files, such as MVC view files. When the app is started from the project's root folder, the project's root folder is used as the content root. This is the default used in [Visual Studio](https://visualstudio.microsoft.com) and the [dotnet new templates](/dotnet/core/tools/dotnet-new).

For more information on app configuration, see <xref:fundamentals/configuration/index>.

> [!NOTE]
> As an alternative to using the static `CreateDefaultBuilder` method, creating a host from <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> is a supported approach with ASP.NET Core 2.x.

When setting up a host, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Configure%2A> and <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureServices%2A> methods can be provided. If a `Startup` class is specified, it must define a `Configure` method. For more information, see <xref:fundamentals/startup>. Multiple calls to `ConfigureServices` append to one another. Multiple calls to `Configure` or `UseStartup` on the `WebHostBuilder` replace previous settings.

## Host configuration values

<xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> relies on the following approaches to set the host configuration values:

* Host builder configuration, which includes environment variables with the format `ASPNETCORE_{configurationKey}`. For example, `ASPNETCORE_ENVIRONMENT`.
* Extensions such as <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseContentRoot%2A> and <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> (see the [Override configuration](#override-configuration) section).
* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.UseSetting%2A> and the associated key. When setting a value with `UseSetting`, the value is set as a string regardless of the type.

The host uses whichever option sets a value last. For more information, see [Override configuration](#override-configuration) in the next section.

### Application Key (Name)

The `IWebHostEnvironment.ApplicationName` property is automatically set when <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A> or <xref:Microsoft.AspNetCore.Hosting.IStartup.Configure%2A> is called during host construction. The value is set to the name of the assembly containing the app's entry point. To set the value explicitly, use the <xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.ApplicationKey?displayProperty=nameWithType>:

**Key**: applicationName  
**Type**: *string*  
**Default**: The name of the assembly containing the app's entry point.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_APPLICATIONNAME`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.ApplicationKey, "CustomApplicationName")
```

### Capture Startup Errors

This setting controls the capture of startup errors.

**Key**: captureStartupErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Set using**: `CaptureStartupErrors`  
**Environment variable**: `ASPNETCORE_CAPTURESTARTUPERRORS`

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

```csharp
WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(true)
```

### Content root

This setting determines where ASP.NET Core begins searching for content files.

**Key**: contentRoot  
**Type**: *string*  
**Default**: Defaults to the folder where the app assembly resides.  
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

### Detailed Errors

Determines if detailed errors should be captured.

**Key**: detailedErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_DETAILEDERRORS`

When enabled (or when the <a href="#environment">Environment</a> is set to `Development`), the app captures detailed exceptions.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
```

### Environment

Sets the app's environment.

**Key**: environment  
**Type**: *string*  
**Default**: Production  
**Set using**: `UseEnvironment`  
**Environment variable**: `ASPNETCORE_ENVIRONMENT`

The environment can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case sensitive. By default, the *Environment* is read from the `ASPNETCORE_ENVIRONMENT` environment variable. When using [Visual Studio](https://visualstudio.microsoft.com), environment variables may be set in the `launchSettings.json` file. For more information, see <xref:fundamentals/environments>.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseEnvironment(EnvironmentName.Development)
```

### Hosting Startup Assemblies

Sets the app's hosting startup assemblies.

**Key**: hostingStartupAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`

A semicolon-delimited string of hosting startup assemblies to load on startup.

Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2")
```

### HTTPS Port

Set the HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: https_port  
**Type**: *string*  
**Default**: A default value isn't set.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HTTPS_PORT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("https_port", "8080")
```

### Hosting Startup Exclude Assemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: hostingStartupExcludeAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2")
```

### Prefer Hosting URLs

Indicates whether the host should listen on the URLs configured with the `WebHostBuilder` instead of those configured with the `IServer` implementation.

**Key**: preferHostingUrls  
**Type**: *bool* (`true` or `1`)  
**Default**: true  
**Set using**: `PreferHostingUrls`  
**Environment variable**: `ASPNETCORE_PREFERHOSTINGURLS`

```csharp
WebHost.CreateDefaultBuilder(args)
    .PreferHostingUrls(false)
```

### Prevent Hosting Startup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: preventHostingStartup  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_PREVENTHOSTINGSTARTUP`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
```

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: urls  
**Type**: *string*  
**Default**: http://localhost:5000  
**Set using**: `UseUrls`  
**Environment variable**: `ASPNETCORE_URLS`

Set to a semicolon-separated (;) list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### Shutdown Timeout

Specifies the amount of time to wait for Web Host to shut down.

**Key**: shutdownTimeoutSeconds  
**Type**: *int*  
**Default**: 5  
**Set using**: `UseShutdownTimeout`  
**Environment variable**: `ASPNETCORE_SHUTDOWNTIMEOUTSECONDS`

Although the key accepts an *int* with `UseSetting` (for example, `.UseSetting(WebHostDefaults.ShutdownTimeoutKey, "10")`), the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseShutdownTimeout%2A> extension method takes a <xref:System.TimeSpan>.

During the timeout period, hosting:

* Triggers <xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging any errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require additional time to stop, increase the timeout.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseShutdownTimeout(TimeSpan.FromSeconds(10))
```

### Startup Assembly

Determines the assembly to search for the `Startup` class.

**Key**: startupAssembly  
**Type**: *string*  
**Default**: The app's assembly  
**Set using**: `UseStartup`  
**Environment variable**: `ASPNETCORE_STARTUPASSEMBLY`

The assembly by name (`string`) or type (`TStartup`) can be referenced. If multiple `UseStartup` methods are called, the last one takes precedence.

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

**Key**: webroot  
**Type**: *string*  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist. If the path doesn't exist, a no-op file provider is used.  
**Set using**: `UseWebRoot`  
**Environment variable**: `ASPNETCORE_WEBROOT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseWebRoot("public")
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [Content root](#content-root)

## Override configuration

Use [Configuration](xref:fundamentals/configuration/index) to configure Web Host. In the following example, host configuration is optionally specified in a `hostsettings.json` file. Any configuration loaded from the `hostsettings.json` file may be overridden by command-line arguments. The built configuration (in `config`) is used to configure the host with <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A>. `IWebHostBuilder` configuration is added to the app's configuration, but the converse isn't true&mdash;`ConfigureAppConfiguration` doesn't affect the `IWebHostBuilder` configuration.

Overriding the configuration provided by `UseUrls` with `hostsettings.json` config first, command-line argument config second:

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

`hostsettings.json`:

```json
{
    urls: "http://*:5005"
}
```

> [!NOTE]
> <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> only copies keys from the provided `IConfiguration` to the host builder configuration. Therefore, setting `reloadOnChange: true` for JSON, INI, and XML settings files has no effect.

To specify the host run on a particular URL, the desired value can be passed in from a command prompt when executing [dotnet run](/dotnet/core/tools/dotnet-run). The command-line argument overrides the `urls` value from the `hostsettings.json` file, and the server listens on port 8080:

```dotnetcli
dotnet run --urls "http://*:8080"
```

## Manage the host

**Run**

The `Run` method starts the web app and blocks the calling thread until the host is shut down:

```csharp
host.Run();
```

**Start**

Run the host in a non-blocking manner by calling its `Start` method:

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

The app can initialize and start a new host using the pre-configured defaults of `CreateDefaultBuilder` using a static convenience method. These methods start the server without console output and with <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.WaitForShutdown%2A> wait for a break (Ctrl-C/SIGINT or SIGTERM):

**Start(RequestDelegate app)**

Start with a `RequestDelegate`:

```csharp
using (var host = WebHost.Start(app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, RequestDelegate app)**

Start with a URL and `RequestDelegate`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Produces the same result as **Start(RequestDelegate app)**, except the app responds on `http://localhost:8080`.

**Start(Action\<IRouteBuilder> routeBuilder)**

Use an instance of `IRouteBuilder` ([Microsoft.AspNetCore.Routing](https://www.nuget.org/packages/Microsoft.AspNetCore.Routing/)) to use routing middleware:

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
| `http://localhost:5000/throw/ooops!` | Throws an exception with string "ooops!" |
| `http://localhost:5000/throw` | Throws an exception with string "Uh oh!" |
| `http://localhost:5000/Sante/Kevin` | Sante, Kevin! |
| `http://localhost:5000` | Hello World! |

`WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, Action\<IRouteBuilder> routeBuilder)**

Use a URL and an instance of `IRouteBuilder`:

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

Produces the same result as **Start(Action\<IRouteBuilder> routeBuilder)**, except the app responds at `http://localhost:8080`.

**StartWith(Action\<IApplicationBuilder> app)**

Provide a delegate to configure an `IApplicationBuilder`:

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

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**StartWith(string url, Action\<IApplicationBuilder> app)**

Provide a URL and a delegate to configure an `IApplicationBuilder`:

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

Produces the same result as **StartWith(Action\<IApplicationBuilder> app)**, except the app responds on `http://localhost:8080`.

## IWebHostEnvironment interface

The `IWebHostEnvironment` interface provides information about the app's web hosting environment. Use [constructor injection](xref:fundamentals/dependency-injection) to obtain the `IWebHostEnvironment` in order to use its properties and extension methods:

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

A [convention-based approach](xref:fundamentals/environments#environment-based-startup-class-and-methods) can be used to configure the app at startup based on the environment. Alternatively, inject the `IWebHostEnvironment` into the `Startup` constructor for use in `ConfigureServices`:

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
> In addition to the `IsDevelopment` extension method, `IWebHostEnvironment` offers `IsStaging`, `IsProduction`, and `IsEnvironment(string environmentName)` methods. For more information, see <xref:fundamentals/environments>.

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

## IHostApplicationLifetime interface

`IHostApplicationLifetime` allows for post-startup and shutdown activities. Three properties on the interface are cancellation tokens used to register `Action` methods that define startup and shutdown events.

| Cancellation Token | Triggered when&#8230; |
|--|--|
| `ApplicationStarted` | The host has fully started. |
| `ApplicationStopped` | The host is completing a graceful shutdown. All requests should be processed. Shutdown blocks until this event completes. |
| `ApplicationStopping` | The host is performing a graceful shutdown. Requests may still be processing. Shutdown blocks until this event completes. |

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

`StopApplication` requests termination of the app. The following class uses `StopApplication` to gracefully shut down an app when the class's `Shutdown` method is called:

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

## Scope validation

<xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development.

When `ValidateScopes` is set to `true`, the default service provider performs checks to verify that:

* Scoped services aren't directly or indirectly resolved from the root service provider.
* Scoped services aren't directly or indirectly injected into singletons.

The root service provider is created when <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> is called. The root service provider's lifetime corresponds to the app/server's lifetime when the provider starts with the app and is disposed when the app shuts down.

Scoped services are disposed by the container that created them. If a scoped service is created in the root container, the service's lifetime is effectively promoted to singleton because it's only disposed by the root container when app/server is shut down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

To always validate scopes, including in the Production environment, configure the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions> with <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A> on the host builder:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) => {
        options.ValidateScopes = true;
    })
```

## Additional resources

* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/linux-apache>
* <xref:host-and-deploy/windows-service>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

ASP.NET Core apps configure and launch a *host*. The host is responsible for app startup and lifetime management. At a minimum, the host configures a server and a request processing pipeline. The host can also set up logging, dependency injection, and configuration.

This article covers the Web Host, which remains available only for backward compatibility. The ASP.NET Core templates create a [.NET Generic Host](xref:fundamentals/host/generic-host), which is recommended for all app types.

## Set up a host

Create a host using an instance of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. This is typically performed in the app's entry point, the `Main` method.

In the project templates, `Main` is located in `Program.cs`. A typical app calls <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> to start setting up a host:

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

The code that calls `CreateDefaultBuilder` is in a method named `CreateWebHostBuilder`, which separates it from the code in `Main` that calls `Run` on the builder object. This separation is required if you use [Entity Framework Core tools](/ef/core/miscellaneous/cli/). The tools expect to find a `CreateWebHostBuilder` method that they can call at design time to configure the host without running the app. An alternative is to implement `IDesignTimeDbContextFactory`. For more information, see [Design-time DbContext Creation](/ef/core/miscellaneous/cli/dbcontext-creation).

`CreateDefaultBuilder` performs the following tasks:

* Configures [Kestrel](xref:fundamentals/servers/kestrel) server as the web server using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.
* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A?displayProperty=nameWithType>.
* Loads [host configuration](#host-configuration-values) from:
  * Environment variables prefixed with `ASPNETCORE_` (for example, `ASPNETCORE_ENVIRONMENT`).
  * Command-line arguments.
* Loads app configuration in the following order from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment using the entry assembly.
  * Environment variables.
  * Command-line arguments.
* Configures [logging](xref:fundamentals/logging/index) for console and debug output. Logging includes [log filtering](xref:fundamentals/logging/index#apply-log-filter-rules-in-code) rules specified in a Logging configuration section of an `appsettings.json` or `appsettings.{Environment}.json` file.
* When running behind IIS with the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), `CreateDefaultBuilder` enables [IIS Integration](xref:host-and-deploy/iis/index), which configures the app's base address and port. IIS Integration also configures the app to [capture startup errors](#capture-startup-errors). For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.
* Sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development. For more information, see [Scope validation](#scope-validation).

The configuration defined by `CreateDefaultBuilder` can be overridden and augmented by <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A>, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureLogging%2A>, and other methods and extension methods of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. A few examples follow:

* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A> is used to specify additional `IConfiguration` for the app. The following `ConfigureAppConfiguration` call adds a delegate to include app configuration in the `appsettings.xml` file. `ConfigureAppConfiguration` may be called multiple times. Note that this configuration doesn't apply to the host (for example, server URLs or environment). See the [Host configuration values](#host-configuration-values) section.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
        })
        ...
    ```

* The following `ConfigureLogging` call adds a delegate to configure the minimum logging level (<xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A>) to <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>. This setting overrides the settings in `appsettings.Development.json` (`LogLevel.Debug`) and `appsettings.Production.json` (`LogLevel.Error`) configured by `CreateDefaultBuilder`. `ConfigureLogging` may be called multiple times.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging => 
        {
            logging.SetMinimumLevel(LogLevel.Warning);
        })
        ...
    ```

* The following call to `ConfigureKestrel` overrides the default [Limits.MaxRequestBodySize](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize%2A) of 30,000,000 bytes established when Kestrel was configured by `CreateDefaultBuilder`:

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel((context, options) =>
        {
            options.Limits.MaxRequestBodySize = 20000000;
        });
    ```

The [content root](xref:fundamentals/index#content-root) determines where the host searches for content files, such as MVC view files. When the app is started from the project's root folder, the project's root folder is used as the content root. This is the default used in [Visual Studio](https://visualstudio.microsoft.com) and the [dotnet new templates](/dotnet/core/tools/dotnet-new).

For more information on app configuration, see <xref:fundamentals/configuration/index>.

> [!NOTE]
> As an alternative to using the static `CreateDefaultBuilder` method, creating a host from <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> is a supported approach with ASP.NET Core 2.x.

When setting up a host, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Configure%2A> and <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureServices%2A> methods can be provided. If a `Startup` class is specified, it must define a `Configure` method. For more information, see <xref:fundamentals/startup>. Multiple calls to `ConfigureServices` append to one another. Multiple calls to `Configure` or `UseStartup` on the `WebHostBuilder` replace previous settings.

## Host configuration values

<xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> relies on the following approaches to set the host configuration values:

* Host builder configuration, which includes environment variables with the format `ASPNETCORE_{configurationKey}`. For example, `ASPNETCORE_ENVIRONMENT`.
* Extensions such as <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseContentRoot%2A> and <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> (see the [Override configuration](#override-configuration) section).
* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.UseSetting%2A> and the associated key. When setting a value with `UseSetting`, the value is set as a string regardless of the type.

The host uses whichever option sets a value last. For more information, see [Override configuration](#override-configuration) in the next section.

### Application Key (Name)

The `IWebHostEnvironment.ApplicationName` property is automatically set when <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A> or <xref:Microsoft.AspNetCore.Hosting.IStartup.Configure%2A> is called during host construction. The value is set to the name of the assembly containing the app's entry point. To set the value explicitly, use the <xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.ApplicationKey?displayProperty=nameWithType>:

**Key**: applicationName  
**Type**: *string*  
**Default**: The name of the assembly containing the app's entry point.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_APPLICATIONNAME`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.ApplicationKey, "CustomApplicationName")
```

### Capture Startup Errors

This setting controls the capture of startup errors.

**Key**: captureStartupErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Set using**: `CaptureStartupErrors`  
**Environment variable**: `ASPNETCORE_CAPTURESTARTUPERRORS`

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

```csharp
WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(true)
```

### Content root

This setting determines where ASP.NET Core begins searching for content files.

**Key**: contentRoot  
**Type**: *string*  
**Default**: Defaults to the folder where the app assembly resides.  
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

### Detailed Errors

Determines if detailed errors should be captured.

**Key**: detailedErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_DETAILEDERRORS`

When enabled (or when the <a href="#environment">Environment</a> is set to `Development`), the app captures detailed exceptions.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
```

### Environment

Sets the app's environment.

**Key**: environment  
**Type**: *string*  
**Default**: Production  
**Set using**: `UseEnvironment`  
**Environment variable**: `ASPNETCORE_ENVIRONMENT`

The environment can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case sensitive. By default, the *Environment* is read from the `ASPNETCORE_ENVIRONMENT` environment variable. When using [Visual Studio](https://visualstudio.microsoft.com), environment variables may be set in the `launchSettings.json` file. For more information, see <xref:fundamentals/environments>.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseEnvironment(EnvironmentName.Development)
```

### Hosting Startup Assemblies

Sets the app's hosting startup assemblies.

**Key**: hostingStartupAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`

A semicolon-delimited string of hosting startup assemblies to load on startup.

Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2")
```

### HTTPS Port

Set the HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: https_port  
**Type**: *string*  
**Default**: A default value isn't set.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HTTPS_PORT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("https_port", "8080")
```

### Hosting Startup Exclude Assemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: hostingStartupExcludeAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2")
```

### Prefer Hosting URLs

Indicates whether the host should listen on the URLs configured with the `WebHostBuilder` instead of those configured with the `IServer` implementation.

**Key**: preferHostingUrls  
**Type**: *bool* (`true` or `1`)  
**Default**: true  
**Set using**: `PreferHostingUrls`  
**Environment variable**: `ASPNETCORE_PREFERHOSTINGURLS`

```csharp
WebHost.CreateDefaultBuilder(args)
    .PreferHostingUrls(false)
```

### Prevent Hosting Startup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: preventHostingStartup  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_PREVENTHOSTINGSTARTUP`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
```

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: urls  
**Type**: *string*  
**Default**: http://localhost:5000  
**Set using**: `UseUrls`  
**Environment variable**: `ASPNETCORE_URLS`

Set to a semicolon-separated (;) list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### Shutdown Timeout

Specifies the amount of time to wait for Web Host to shut down.

**Key**: shutdownTimeoutSeconds  
**Type**: *int*  
**Default**: 5  
**Set using**: `UseShutdownTimeout`  
**Environment variable**: `ASPNETCORE_SHUTDOWNTIMEOUTSECONDS`

Although the key accepts an *int* with `UseSetting` (for example, `.UseSetting(WebHostDefaults.ShutdownTimeoutKey, "10")`), the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseShutdownTimeout%2A> extension method takes a <xref:System.TimeSpan>.

During the timeout period, hosting:

* Triggers <xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging any errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require additional time to stop, increase the timeout.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseShutdownTimeout(TimeSpan.FromSeconds(10))
```

### Startup Assembly

Determines the assembly to search for the `Startup` class.

**Key**: startupAssembly  
**Type**: *string*  
**Default**: The app's assembly  
**Set using**: `UseStartup`  
**Environment variable**: `ASPNETCORE_STARTUPASSEMBLY`

The assembly by name (`string`) or type (`TStartup`) can be referenced. If multiple `UseStartup` methods are called, the last one takes precedence.

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

**Key**: webroot  
**Type**: *string*  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist. If the path doesn't exist, a no-op file provider is used.  
**Set using**: `UseWebRoot`  
**Environment variable**: `ASPNETCORE_WEBROOT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseWebRoot("public")
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [Content root](#content-root)

## Override configuration

Use [Configuration](xref:fundamentals/configuration/index) to configure Web Host. In the following example, host configuration is optionally specified in a `hostsettings.json` file. Any configuration loaded from the `hostsettings.json` file may be overridden by command-line arguments. The built configuration (in `config`) is used to configure the host with <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A>. `IWebHostBuilder` configuration is added to the app's configuration, but the converse isn't true&mdash;`ConfigureAppConfiguration` doesn't affect the `IWebHostBuilder` configuration.

Overriding the configuration provided by `UseUrls` with `hostsettings.json` config first, command-line argument config second:

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

`hostsettings.json`:

```json
{
    urls: "http://*:5005"
}
```

> [!NOTE]
> <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> only copies keys from the provided `IConfiguration` to the host builder configuration. Therefore, setting `reloadOnChange: true` for JSON, INI, and XML settings files has no effect.

To specify the host run on a particular URL, the desired value can be passed in from a command prompt when executing [dotnet run](/dotnet/core/tools/dotnet-run). The command-line argument overrides the `urls` value from the `hostsettings.json` file, and the server listens on port 8080:

```dotnetcli
dotnet run --urls "http://*:8080"
```

## Manage the host

**Run**

The `Run` method starts the web app and blocks the calling thread until the host is shut down:

```csharp
host.Run();
```

**Start**

Run the host in a non-blocking manner by calling its `Start` method:

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

The app can initialize and start a new host using the pre-configured defaults of `CreateDefaultBuilder` using a static convenience method. These methods start the server without console output and with <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.WaitForShutdown%2A> wait for a break (Ctrl-C/SIGINT or SIGTERM):

**Start(RequestDelegate app)**

Start with a `RequestDelegate`:

```csharp
using (var host = WebHost.Start(app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, RequestDelegate app)**

Start with a URL and `RequestDelegate`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Produces the same result as **Start(RequestDelegate app)**, except the app responds on `http://localhost:8080`.

**Start(Action\<IRouteBuilder> routeBuilder)**

Use an instance of `IRouteBuilder` ([Microsoft.AspNetCore.Routing](https://www.nuget.org/packages/Microsoft.AspNetCore.Routing/)) to use routing middleware:

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
| `http://localhost:5000/throw/ooops!` | Throws an exception with string "ooops!" |
| `http://localhost:5000/throw` | Throws an exception with string "Uh oh!" |
| `http://localhost:5000/Sante/Kevin` | Sante, Kevin! |
| `http://localhost:5000` | Hello World! |

`WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, Action\<IRouteBuilder> routeBuilder)**

Use a URL and an instance of `IRouteBuilder`:

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

Produces the same result as **Start(Action\<IRouteBuilder> routeBuilder)**, except the app responds at `http://localhost:8080`.

**StartWith(Action\<IApplicationBuilder> app)**

Provide a delegate to configure an `IApplicationBuilder`:

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

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**StartWith(string url, Action\<IApplicationBuilder> app)**

Provide a URL and a delegate to configure an `IApplicationBuilder`:

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

Produces the same result as **StartWith(Action\<IApplicationBuilder> app)**, except the app responds on `http://localhost:8080`.

## IWebHostEnvironment interface

The `IWebHostEnvironment` interface provides information about the app's web hosting environment. Use [constructor injection](xref:fundamentals/dependency-injection) to obtain the `IWebHostEnvironment` in order to use its properties and extension methods:

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

A [convention-based approach](xref:fundamentals/environments#environment-based-startup-class-and-methods) can be used to configure the app at startup based on the environment. Alternatively, inject the `IWebHostEnvironment` into the `Startup` constructor for use in `ConfigureServices`:

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
> In addition to the `IsDevelopment` extension method, `IWebHostEnvironment` offers `IsStaging`, `IsProduction`, and `IsEnvironment(string environmentName)` methods. For more information, see <xref:fundamentals/environments>.

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

## IHostApplicationLifetime interface

`IHostApplicationLifetime` allows for post-startup and shutdown activities. Three properties on the interface are cancellation tokens used to register `Action` methods that define startup and shutdown events.

| Cancellation Token | Triggered when&#8230; |
|--|--|
| `ApplicationStarted` | The host has fully started. |
| `ApplicationStopped` | The host is completing a graceful shutdown. All requests should be processed. Shutdown blocks until this event completes. |
| `ApplicationStopping` | The host is performing a graceful shutdown. Requests may still be processing. Shutdown blocks until this event completes. |

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

`StopApplication` requests termination of the app. The following class uses `StopApplication` to gracefully shut down an app when the class's `Shutdown` method is called:

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

## Scope validation

<xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development.

When `ValidateScopes` is set to `true`, the default service provider performs checks to verify that:

* Scoped services aren't directly or indirectly resolved from the root service provider.
* Scoped services aren't directly or indirectly injected into singletons.

The root service provider is created when <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> is called. The root service provider's lifetime corresponds to the app/server's lifetime when the provider starts with the app and is disposed when the app shuts down.

Scoped services are disposed by the container that created them. If a scoped service is created in the root container, the service's lifetime is effectively promoted to singleton because it's only disposed by the root container when app/server is shut down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

To always validate scopes, including in the Production environment, configure the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions> with <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A> on the host builder:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) => {
        options.ValidateScopes = true;
    })
```

## Additional resources

* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/linux-apache>
* <xref:host-and-deploy/windows-service>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

ASP.NET Core apps configure and launch a *host*. The host is responsible for app startup and lifetime management. At a minimum, the host configures a server and a request processing pipeline. The host can also set up logging, dependency injection, and configuration.

This article covers the Web Host, which remains available only for backward compatibility. The ASP.NET Core templates create a [.NET Generic Host](xref:fundamentals/host/generic-host), which is recommended for all app types.

## Set up a host

Create a host using an instance of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. This is typically performed in the app's entry point, the `Main` method.

In the project templates, `Main` is located in `Program.cs`. A typical app calls <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> to start setting up a host:

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

The code that calls `CreateDefaultBuilder` is in a method named `CreateWebHostBuilder`, which separates it from the code in `Main` that calls `Run` on the builder object. This separation is required if you use [Entity Framework Core tools](/ef/core/miscellaneous/cli/). The tools expect to find a `CreateWebHostBuilder` method that they can call at design time to configure the host without running the app. An alternative is to implement `IDesignTimeDbContextFactory`. For more information, see [Design-time DbContext Creation](/ef/core/miscellaneous/cli/dbcontext-creation).

`CreateDefaultBuilder` performs the following tasks:

* Configures [Kestrel](xref:fundamentals/servers/kestrel) server as the web server using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel#kestrel-options>.
* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A?displayProperty=nameWithType>.
* Loads [host configuration](#host-configuration-values) from:
  * Environment variables prefixed with `ASPNETCORE_` (for example, `ASPNETCORE_ENVIRONMENT`).
  * Command-line arguments.
* Loads app configuration in the following order from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment using the entry assembly.
  * Environment variables.
  * Command-line arguments.
* Configures [logging](xref:fundamentals/logging/index) for console and debug output. Logging includes [log filtering](xref:fundamentals/logging/index#apply-log-filter-rules-in-code) rules specified in a Logging configuration section of an `appsettings.json` or `appsettings.{Environment}.json` file.
* When running behind IIS with the [ASP.NET Core Module](xref:host-and-deploy/aspnet-core-module), `CreateDefaultBuilder` enables [IIS Integration](xref:host-and-deploy/iis/index), which configures the app's base address and port. IIS Integration also configures the app to [capture startup errors](#capture-startup-errors). For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.
* Sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development. For more information, see [Scope validation](#scope-validation).

The configuration defined by `CreateDefaultBuilder` can be overridden and augmented by <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A>, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureLogging%2A>, and other methods and extension methods of <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder>. A few examples follow:

* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureAppConfiguration%2A> is used to specify additional `IConfiguration` for the app. The following `ConfigureAppConfiguration` call adds a delegate to include app configuration in the `appsettings.xml` file. `ConfigureAppConfiguration` may be called multiple times. Note that this configuration doesn't apply to the host (for example, server URLs or environment). See the [Host configuration values](#host-configuration-values) section.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddXmlFile("appsettings.xml", optional: true, reloadOnChange: true);
        })
        ...
    ```

* The following `ConfigureLogging` call adds a delegate to configure the minimum logging level (<xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A>) to <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>. This setting overrides the settings in `appsettings.Development.json` (`LogLevel.Debug`) and `appsettings.Production.json` (`LogLevel.Error`) configured by `CreateDefaultBuilder`. `ConfigureLogging` may be called multiple times.

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureLogging(logging => 
        {
            logging.SetMinimumLevel(LogLevel.Warning);
        })
        ...
    ```

* The following call to `ConfigureKestrel` overrides the default [Limits.MaxRequestBodySize](xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerLimits.MaxRequestBodySize%2A) of 30,000,000 bytes established when Kestrel was configured by `CreateDefaultBuilder`:

    ```csharp
    WebHost.CreateDefaultBuilder(args)
        .ConfigureKestrel((context, options) =>
        {
            options.Limits.MaxRequestBodySize = 20000000;
        });
    ```

The [content root](xref:fundamentals/index#content-root) determines where the host searches for content files, such as MVC view files. When the app is started from the project's root folder, the project's root folder is used as the content root. This is the default used in [Visual Studio](https://visualstudio.microsoft.com) and the [dotnet new templates](/dotnet/core/tools/dotnet-new).

For more information on app configuration, see <xref:fundamentals/configuration/index>.

> [!NOTE]
> As an alternative to using the static `CreateDefaultBuilder` method, creating a host from <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> is a supported approach with ASP.NET Core 2.x.

When setting up a host, <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.Configure%2A> and <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureServices%2A> methods can be provided. If a `Startup` class is specified, it must define a `Configure` method. For more information, see <xref:fundamentals/startup>. Multiple calls to `ConfigureServices` append to one another. Multiple calls to `Configure` or `UseStartup` on the `WebHostBuilder` replace previous settings.

## Host configuration values

<xref:Microsoft.AspNetCore.Hosting.WebHostBuilder> relies on the following approaches to set the host configuration values:

* Host builder configuration, which includes environment variables with the format `ASPNETCORE_{configurationKey}`. For example, `ASPNETCORE_ENVIRONMENT`.
* Extensions such as <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseContentRoot%2A> and <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> (see the [Override configuration](#override-configuration) section).
* <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.UseSetting%2A> and the associated key. When setting a value with `UseSetting`, the value is set as a string regardless of the type.

The host uses whichever option sets a value last. For more information, see [Override configuration](#override-configuration) in the next section.

### Application Key (Name)

The `IWebHostEnvironment.ApplicationName` property is automatically set when <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseStartup%2A> or <xref:Microsoft.AspNetCore.Hosting.IStartup.Configure%2A> is called during host construction. The value is set to the name of the assembly containing the app's entry point. To set the value explicitly, use the <xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.ApplicationKey?displayProperty=nameWithType>:

**Key**: applicationName  
**Type**: *string*  
**Default**: The name of the assembly containing the app's entry point.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_APPLICATIONNAME`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.ApplicationKey, "CustomApplicationName")
```

### Capture Startup Errors

This setting controls the capture of startup errors.

**Key**: captureStartupErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Set using**: `CaptureStartupErrors`  
**Environment variable**: `ASPNETCORE_CAPTURESTARTUPERRORS`

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

```csharp
WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(true)
```

### Content root

This setting determines where ASP.NET Core begins searching for content files.

**Key**: contentRoot  
**Type**: *string*  
**Default**: Defaults to the folder where the app assembly resides.  
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

### Detailed Errors

Determines if detailed errors should be captured.

**Key**: detailedErrors  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_DETAILEDERRORS`

When enabled (or when the <a href="#environment">Environment</a> is set to `Development`), the app captures detailed exceptions.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
```

### Environment

Sets the app's environment.

**Key**: environment  
**Type**: *string*  
**Default**: Production  
**Set using**: `UseEnvironment`  
**Environment variable**: `ASPNETCORE_ENVIRONMENT`

The environment can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case sensitive. By default, the *Environment* is read from the `ASPNETCORE_ENVIRONMENT` environment variable. When using [Visual Studio](https://visualstudio.microsoft.com), environment variables may be set in the `launchSettings.json` file. For more information, see <xref:fundamentals/environments>.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseEnvironment(EnvironmentName.Development)
```

### Hosting Startup Assemblies

Sets the app's hosting startup assemblies.

**Key**: hostingStartupAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`

A semicolon-delimited string of hosting startup assemblies to load on startup.

Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2")
```

### HTTPS Port

Set the HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: https_port  
**Type**: *string*  
**Default**: A default value isn't set.  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HTTPS_PORT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("https_port", "8080")
```

### Hosting Startup Exclude Assemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: hostingStartupExcludeAssemblies  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2")
```

### Prefer Hosting URLs

Indicates whether the host should listen on the URLs configured with the `WebHostBuilder` instead of those configured with the `IServer` implementation.

**Key**: preferHostingUrls  
**Type**: *bool* (`true` or `1`)  
**Default**: true  
**Set using**: `PreferHostingUrls`  
**Environment variable**: `ASPNETCORE_PREFERHOSTINGURLS`

```csharp
WebHost.CreateDefaultBuilder(args)
    .PreferHostingUrls(false)
```

### Prevent Hosting Startup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: preventHostingStartup  
**Type**: *bool* (`true` or `1`)  
**Default**: false  
**Set using**: `UseSetting`  
**Environment variable**: `ASPNETCORE_PREVENTHOSTINGSTARTUP`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
```

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: urls  
**Type**: *string*  
**Default**: http://localhost:5000  
**Set using**: `UseUrls`  
**Environment variable**: `ASPNETCORE_URLS`

Set to a semicolon-separated (;) list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel#endpoint-configuration>.

### Shutdown Timeout

Specifies the amount of time to wait for Web Host to shut down.

**Key**: shutdownTimeoutSeconds  
**Type**: *int*  
**Default**: 5  
**Set using**: `UseShutdownTimeout`  
**Environment variable**: `ASPNETCORE_SHUTDOWNTIMEOUTSECONDS`

Although the key accepts an *int* with `UseSetting` (for example, `.UseSetting(WebHostDefaults.ShutdownTimeoutKey, "10")`), the <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseShutdownTimeout%2A> extension method takes a <xref:System.TimeSpan>.

During the timeout period, hosting:

* Triggers <xref:Microsoft.AspNetCore.Hosting.IApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging any errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require additional time to stop, increase the timeout.

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseShutdownTimeout(TimeSpan.FromSeconds(10))
```

### Startup Assembly

Determines the assembly to search for the `Startup` class.

**Key**: startupAssembly  
**Type**: *string*  
**Default**: The app's assembly  
**Set using**: `UseStartup`  
**Environment variable**: `ASPNETCORE_STARTUPASSEMBLY`

The assembly by name (`string`) or type (`TStartup`) can be referenced. If multiple `UseStartup` methods are called, the last one takes precedence.

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

**Key**: webroot  
**Type**: *string*  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist. If the path doesn't exist, a no-op file provider is used.  
**Set using**: `UseWebRoot`  
**Environment variable**: `ASPNETCORE_WEBROOT`

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseWebRoot("public")
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [Content root](#content-root)

## Override configuration

Use [Configuration](xref:fundamentals/configuration/index) to configure Web Host. In the following example, host configuration is optionally specified in a `hostsettings.json` file. Any configuration loaded from the `hostsettings.json` file may be overridden by command-line arguments. The built configuration (in `config`) is used to configure the host with <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A>. `IWebHostBuilder` configuration is added to the app's configuration, but the converse isn't true&mdash;`ConfigureAppConfiguration` doesn't affect the `IWebHostBuilder` configuration.

Overriding the configuration provided by `UseUrls` with `hostsettings.json` config first, command-line argument config second:

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

`hostsettings.json`:

```json
{
    urls: "http://*:5005"
}
```

> [!NOTE]
> <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration%2A> only copies keys from the provided `IConfiguration` to the host builder configuration. Therefore, setting `reloadOnChange: true` for JSON, INI, and XML settings files has no effect.

To specify the host run on a particular URL, the desired value can be passed in from a command prompt when executing [dotnet run](/dotnet/core/tools/dotnet-run). The command-line argument overrides the `urls` value from the `hostsettings.json` file, and the server listens on port 8080:

```dotnetcli
dotnet run --urls "http://*:8080"
```

## Manage the host

**Run**

The `Run` method starts the web app and blocks the calling thread until the host is shut down:

```csharp
host.Run();
```

**Start**

Run the host in a non-blocking manner by calling its `Start` method:

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

The app can initialize and start a new host using the pre-configured defaults of `CreateDefaultBuilder` using a static convenience method. These methods start the server without console output and with <xref:Microsoft.AspNetCore.Hosting.WebHostExtensions.WaitForShutdown%2A> wait for a break (Ctrl-C/SIGINT or SIGTERM):

**Start(RequestDelegate app)**

Start with a `RequestDelegate`:

```csharp
using (var host = WebHost.Start(app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, RequestDelegate app)**

Start with a URL and `RequestDelegate`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", app => app.Response.WriteAsync("Hello, World!")))
{
    Console.WriteLine("Use Ctrl-C to shutdown the host...");
    host.WaitForShutdown();
}
```

Produces the same result as **Start(RequestDelegate app)**, except the app responds on `http://localhost:8080`.

**Start(Action\<IRouteBuilder> routeBuilder)**

Use an instance of `IRouteBuilder` ([Microsoft.AspNetCore.Routing](https://www.nuget.org/packages/Microsoft.AspNetCore.Routing/)) to use routing middleware:

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
| `http://localhost:5000/throw/ooops!` | Throws an exception with string "ooops!" |
| `http://localhost:5000/throw` | Throws an exception with string "Uh oh!" |
| `http://localhost:5000/Sante/Kevin` | Sante, Kevin! |
| `http://localhost:5000` | Hello World! |

`WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**Start(string url, Action\<IRouteBuilder> routeBuilder)**

Use a URL and an instance of `IRouteBuilder`:

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

Produces the same result as **Start(Action\<IRouteBuilder> routeBuilder)**, except the app responds at `http://localhost:8080`.

**StartWith(Action\<IApplicationBuilder> app)**

Provide a delegate to configure an `IApplicationBuilder`:

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

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" `WaitForShutdown` blocks until a break (Ctrl-C/SIGINT or SIGTERM) is issued. The app displays the `Console.WriteLine` message and waits for a keypress to exit.

**StartWith(string url, Action\<IApplicationBuilder> app)**

Provide a URL and a delegate to configure an `IApplicationBuilder`:

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

Produces the same result as **StartWith(Action\<IApplicationBuilder> app)**, except the app responds on `http://localhost:8080`.

## IWebHostEnvironment interface

The `IWebHostEnvironment` interface provides information about the app's web hosting environment. Use [constructor injection](xref:fundamentals/dependency-injection) to obtain the `IWebHostEnvironment` in order to use its properties and extension methods:

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

A [convention-based approach](xref:fundamentals/environments#environment-based-startup-class-and-methods) can be used to configure the app at startup based on the environment. Alternatively, inject the `IWebHostEnvironment` into the `Startup` constructor for use in `ConfigureServices`:

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
> In addition to the `IsDevelopment` extension method, `IWebHostEnvironment` offers `IsStaging`, `IsProduction`, and `IsEnvironment(string environmentName)` methods. For more information, see <xref:fundamentals/environments>.

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

## IHostApplicationLifetime interface

`IHostApplicationLifetime` allows for post-startup and shutdown activities. Three properties on the interface are cancellation tokens used to register `Action` methods that define startup and shutdown events.

| Cancellation Token | Triggered when&#8230; |
|--|--|
| `ApplicationStarted` | The host has fully started. |
| `ApplicationStopped` | The host is completing a graceful shutdown. All requests should be processed. Shutdown blocks until this event completes. |
| `ApplicationStopping` | The host is performing a graceful shutdown. Requests may still be processing. Shutdown blocks until this event completes. |

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

`StopApplication` requests termination of the app. The following class uses `StopApplication` to gracefully shut down an app when the class's `Shutdown` method is called:

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

## Scope validation

<xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> sets <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes%2A?displayProperty=nameWithType> to `true` if the app's environment is Development.

When `ValidateScopes` is set to `true`, the default service provider performs checks to verify that:

* Scoped services aren't directly or indirectly resolved from the root service provider.
* Scoped services aren't directly or indirectly injected into singletons.

The root service provider is created when <xref:Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider%2A> is called. The root service provider's lifetime corresponds to the app/server's lifetime when the provider starts with the app and is disposed when the app shuts down.

Scoped services are disposed by the container that created them. If a scoped service is created in the root container, the service's lifetime is effectively promoted to singleton because it's only disposed by the root container when app/server is shut down. Validating service scopes catches these situations when `BuildServiceProvider` is called.

To always validate scopes, including in the Production environment, configure the <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions> with <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.UseDefaultServiceProvider%2A> on the host builder:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) => {
        options.ValidateScopes = true;
    })
```

## Additional resources

* <xref:host-and-deploy/iis/index>
* <xref:host-and-deploy/linux-nginx>
* <xref:host-and-deploy/linux-apache>
* <xref:host-and-deploy/windows-service>

:::moniker-end
