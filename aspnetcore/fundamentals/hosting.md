---
title: Hosting in ASP.NET Core
author: ardalis
description: Learn about the web host in ASP.NET Core, which is responsible for app startup and lifetime management.
keywords: ASP.NET Core,web host,IWebHost,WebHostBuilder
ms.author: riande
manager: wpickett
ms.date: 08/27/2017
ms.topic: article
ms.assetid: 4e45311d-8d56-46e2-b99d-6f65b648a277
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/hosting
ms.custom: H1Hack27Feb2017
---
# Hosting in ASP.NET Core

By [Steve Smith](http://ardalis.com)

ASP.NET Core apps configure and launch a *host*, which is responsible for app startup and lifetime management. At a minimum, the host configures a server and a request processing pipeline.

## Setting up a host

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Create a host using an instance of `IWebHost`. This is typically performed in your app's entry point, the `Main` method, which in the project templates is located in *Program.cs*. A typical *Program.cs*, shown below, calls `CreateDefaultbuilder` to build the host:

[!code-csharp[Main](../common/samples/WebApplication1DotNetCore2.0App/Program.cs?name=snippet_Main&highlight=5,8-11)]

`CreateDefaultbuilder` performs the following tasks:

* Configures [Kestrel](servers/kestrel.md) as the web server.
* Sets the content root to [Directory.GetCurrentDirectory](/dotnet/api/system.io.directory.getcurrentdirectory?view=netcore-2.0).
* Loads configuration from:
  * *appsettings.json*.
  * *appsettings.{Environment}.json*.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
  * Environment variables.
  * Command-line arguments.
* Configures [logging](xref:fundamentals/logging) for console and debug output with [log filtering](xref:fundamentals/logging#log-filtering) rules specified in a Logging configuration section of an *appsettings.json* or *appsettings.{Environment}.json* file.
* Enables IIS integration by configuring the base path and port the server should listen on when using the [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module). The module creates a reverse-proxy between Kestrel and IIS. Also configures the app to [capture startup errors](#capture-startup-errors).
* Enables the [developer exception page](xref:fundamentals/error-handling#the-developer-exception-page) when the app runs in the `Development` environment.

The *content root* determines where the host searches for content files, such as MVC View files. The default content root is `Directory.GetCurrentDirectory`. This results in using the web project's root folder as the content root when the app is started from the root folder (for example, calling `dotnet run` from the web project folder). This is the default used in Visual Studio and the `dotnet new` templates.

See [Configuration in ASP.NET Core](xref:fundamentals/configuration) for more information on app configuration.

> [!NOTE]
> As an alternative to using the static `WebHost` API, creating a host as a `WebHostBuilder` is a supported approach with ASP.NET Core 2.x. See the ASP.NET Core 1.x tab for more information.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Create a host using an instance of `WebHostBuilder`. This is typically performed in your app's entry point, the `Main` method, which in the project templates is located in *Program.cs*. The *Program.cs*, shown below, demonstrates how to use a `WebHostBuilder` to build the host:

[!code-csharp[Main](../common/samples/WebApplication1/Program.cs?highlight=14-21)]

`WebHostBuilder` requires a [server that implements IServer](servers/index.md). The built-in servers are [Kestrel](servers/kestrel.md) and [HTTP.sys](servers/httpsys.md). In this example, the `UseKestrel` extension method specifies the Kestrel server.

The *content root* determines where the host searches for content files, such as MVC View files. The default content root supplied to `UseContentRoot` is [Directory.GetCurrentDirectory](/dotnet/api/system.io.directory.getcurrentdirectory?view=netcore-1.1). This results in using the web project's root folder as the content root when the app is started from the root folder (for example, calling `dotnet run` from the web project folder). This is the default used in Visual Studio and the `dotnet new` templates.

To use IIS as a reverse proxy, call [UseIISIntegration](/aspnet/core/api/microsoft.aspnetcore.hosting.webhostbuilderiisextensions) as part of building the host. `UseIISIntegration` doesn't configure a *server*, like `UseKestrel` does. `UseIISIntegration` configures the base path and port the server should listen on when using the [ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module) to create a reverse-proxy between Kestrel and IIS. To use IIS with ASP.NET Core, you must specify both `UseKestrel` and `UseIISIntegration`. For more information, see [Introduction to ASP.NET Core Module](xref:fundamentals/servers/aspnet-core-module) and [ASP.NET Core Module configuration reference](xref:hosting/aspnet-core-module).

A minimal implementation that configures a host (and an ASP.NET Core app) includes specifying a server and configuration of the app's request pipeline:

```csharp
var host = new WebHostBuilder()
    .UseKestrel()
    .Configure(app =>
    {
        app.Run(async (context) => await context.Response.WriteAsync("Hi!"));
    })
    .Build();

host.Run();
```

---

When setting up a host, you can provide `Configure` and `ConfigureServices` methods. If you specify a `Startup` class, it must define `Configure` and `ConfigureServices` methods. For more information, see [Application Startup in ASP.NET Core](startup.md). Multiple calls to `ConfigureServices` append to one another. Multiple calls to `Configure` or `UseStartup` replace previous settings.

## Host configuration values

`WebHostBuilder` provides methods for setting most of the available configuration values for the host, which can also be set directly with `UseSetting` and the associated key.

### Capture Startup Errors

This setting controls the capture of startup errors.

**Key**: `captureStartupErrors`  
**Type**: `bool` (`true` or `1`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Set using**: `CaptureStartupErrors`

When `false`, errors during startup result in the host exiting. When `true`, the host captures any exceptions from the `Startup` class and attempts to start the server. It displays an error page for every request. The error page is either generic or detailed based on the [Detailed Errors setting](#detailed-errors).

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .CaptureStartupErrors(true)
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .CaptureStartupErrors(true)
    ...
```

---

### Content Root

This setting determines where ASP.NET Core begins searching for content files, such as MVC Views. 

**Key**: `contentRoot`  
**Type**: `string`  
**Default**: Defaults to the folder where the app assembly resides.  
**Set using**: `UseContentRoot`

The content root is also used as the base path for the [Web Root setting](#web-root). If the path doesn't exist, the host fails to start.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseContentRoot("c:\\mywebsite")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseContentRoot("c:\\mywebsite")
    ...
```

---

### Detailed Errors

Determines if detailed errors should be captured.

**Key**: `detailedErrors`  
**Type**: `bool` (`true` or `1`)  
**Default**: `false`  
**Set using**: `UseSetting`

When `true` (or when the *Environment* is set to `Development`), the app displays details of startup exceptions, instead of a generic error page.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("detailedErrors", "true")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseSetting("detailedErrors", "true")
    ...
```

---

When *Detailed Errors* is set to `false` and [Capture Startup Errors](#capture-startup-errors) is `true`, a generic error page is displayed in response to every request to the server.

![Generic error page](hosting/_static/generic-error-page.png)

When *Detailed Errors* is set to `true` and [Capture Startup Errors](#capture-startup-errors) is `true`, a detailed error page is displayed in response to every request to the server.

![Detailed error page](hosting/_static/detailed-error-page.png)

### Environment

Sets the app's environment.

**Key**: `environment`  
**Type**: `string`  
**Default**: `Production`  
**Set using**: `UseEnvironment`

You can set the *Environment* to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case sensitive. By default, the *Environment* is read from the `ASPNETCORE_ENVIRONMENT` environment variable. When using Visual Studio, environment variables may be set in the *launchSettings.json* file. For more information, see [Working with Multiple Environments](environments.md).

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseEnvironment("Development")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseEnvironment("Development")
    ...
```

---

### Hosting Startup Assemblies

Sets the app's hosting startup assemblies.

**Key**: `hostingStartupAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Set using**: `UseSetting`

A semicolon-delimited string of hosting startup assemblies to load on startup.

Although the configuration value defaults to an empty string, the hosting startup assemblies always includes the app's assembly. When you provide hosting startup assemblies, they're added to the app's assembly for loading when the app builds its common services during startup.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("hostingStartupAssemblies", "assembly1;assembly2")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseSetting("hostingStartupAssemblies", "assembly1;assembly2")
    ...
```

---

### Prefer Hosting URLs

Indicates whether the host should listen on the URLs configured with the `WebHostBuilder` instead of those configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: `bool` (`true` or `1`)  
**Default**: `true`  
**Set using**: `UseSetting`

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("preferHostingUrls", "false")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseSetting("preferHostingUrls", "false")
    ...
```

---

### Prevent Hosting Startup

Prevents the automatic loading of hosting startup assemblies, including the app's assembly.

**Key**: `preventHostingStartup`  
**Type**: `bool` (`true` or `1`)  
**Default**: `false`  
**Set using**: `UseSetting`

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("preventHostingStartup", "true")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseSetting("preventHostingStartup", "true")
    ...
```

---

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: `urls`  
**Type**: `string`  
**Default**: `http://localhost:5000`  
**Set using**: `UseUrls`

Set to a semicolon-separated (;) list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary between servers.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
    ...
```

Kestrel has its own endpoint configuration API. For more information, see [Kestrel web server implementation in ASP.NET Core](xref:fundamentals/servers/kestrel?tabs=aspnetcore2x#endpoint-configuration).

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002")
    ...
```

---

### Shutdown Timeout

Specifies the amount of time to wait for the web host to shutdown.

**Key**: `shutdownTimeoutSeconds`  
**Type**: `int` (converted to a `TimeSpan` internally)  
**Default**: `5`  
**Set using**: `UseSetting`

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("shutdownTimeoutSeconds", "10")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseSetting("shutdownTimeoutSeconds", "10")
    ...
```

---

### Startup Assembly

Determines the assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: `string`  
**Default**: The app's assembly  
**Set using**: `UseStartup`

You can reference the assembly by name (`string`) or type (`TStartup`). If multiple `UseStartup` methods are called, the last one takes precedence.

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup("StartupAssemblyName")
    ...
```

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup(<TStartup>)
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseStartup("StartupAssemblyName")
    ...
```

```csharp
var host = new WebHostBuilder()
    .UseStartup(<TStartup>)
    ...
```

---

### Web Root

Sets the relative path to the app's static assets.

**Key**: `webroot`  
**Type**: `string`  
**Default**: If not specified, the default is `(Content Root)/wwwroot`, if the path exists. If the path doesn't exist, then a non-operational file provider is used.  
**Set using**: `UseWebRoot`

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseWebRoot("public")
    ...
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var host = new WebHostBuilder()
    .UseWebRoot("public")
    ...
```

---

## Overriding configuration

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

When you use `CreateDefaultBuilder` to build a host, you automatically enable configuration for *appsettings.json*, *appsettings.{Environment}.json*, [user secrets](xref:security/app-secrets) (in `Development`), environment variables, and command-line arguments. If you wish to add additional configuration sources, such as optional configuration stored in a *hosting.json* file, you can build additional configuration with `UseConfiguration`.

```json
{
    urls: "http://*:5005"
}
```

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hosting.json", optional: true)
            .AddCommandLine(args)
            .Build();

        return WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
            .Configure(app =>
            {
                app.Run(async context => 
                    await context.Response.WriteAsync("Hello, World!"));
            })
            .Build();
    }
}
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Use [Configuration](configuration.md) to configure the host. In the following example, host configuration is optionally specified in a *hosting.json* file. Any configuration loaded from the *hosting.json* file may be overridden by command-line arguments. The built configuration is used to configure the host with `UseConfiguration`.

```json
{
    urls: "http://*:5005"
}
```

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hosting.json", optional: true)
            .AddCommandLine(args)
            .Build();

        var host = new WebHostBuilder()
            .UseConfiguration(config)
            .UseKestrel()
            .Configure(app =>
            {
                app.Run(async context => 
                    await context.Response.WriteAsync("Hello, World!"));
            })
            .Build();

        host.Run();
    }
}
```

---

> [!NOTE]
> The `UseConfiguration` extension method isn't currently capable of parsing a configuration section returned by `GetSection` (for example, `.UseConfiguration(Configuration.GetSection("section"))`. The `GetSection` method filters the configuration keys to the section requested but leaves the section name on the keys (for example, `section:urls`, `section:environment`). The `UseConfiguration` method expects the keys to match the `WebHostBuilder` keys (for example, `urls`, `environment`). The presence of the section name on the keys prevents the section's values from configuring the host. This issue will be addressed in an upcoming release. For more information and workarounds, see [Passing configuration section into WebHostBuilder.UseConfiguration uses full keys](https://github.com/aspnet/Hosting/issues/839).

To specify the host run on a particular URL, you could pass in the desired value from a command prompt when executing `dotnet run`. Using the example code above, the command-line argument overrides the `urls` value from the *hosting.json* file. The server listens on port 8080.

```console
dotnet run --urls "http://*:8080"
```

## Starting the host

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

**Run**

The `Run` method starts the web app and blocks the calling thread until the host is shutdown:

```csharp
host.Run();
```

**Start**

You can run the host in a non-blocking manner by calling its `Start` method:

```csharp
using (host)
{
    host.Start();
    Console.ReadLine();
}
```

If you pass a list of URLs to the `Start` method, it listens on the URLs specified:

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

You can initialize and start a new host using the pre-configured defaults of `CreateDefaultbuilder` using a static convenience method. These methods start the server without console output and wait for a break (Ctrl-c/SIGINT or SIGTERM):

**Start(RequestDelegate app)**

Start with a `RequestDelegate`:

```csharp
using (var host = WebHost.Start(app => app.Response.WriteAsync("Hello, World!")))
{
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" Issuing a break (Ctrl-c/SIGINT or SIGTERM) in the console window bypasses the `WaitForShutdown`. The app displays the message and waits for a keypress to exit.

**Start(string url, RequestDelegate app)**

Start with a URL and `RequestDelegate`:

```csharp
using (var host = WebHost.Start("http://localhost:8080", app => app.Response.WriteAsync("Hello, World!")))
{
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Produces the same result as **Start(RequestDelegate app)**, except the app responds on `http://localhost:8080`.

**Start(Action<IRouteBuilder> routeBuilder)**

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
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Use the following browser requests with the example:

| Request                                    | Response                                 |
| ------------------------------------------ | ---------------------------------------- |
| `http://localhost:5000/hello/Martin`       | Hello, Martin!                           |
| `http://localhost:5000/buenosdias/Catrina` | Buenos dias, Catrina!                    |
| `http://localhost:5000/throw/ooops!`       | Throws an exception with string "ooops!" |
| `http://localhost:5000/throw`              | Throws an exception with string "Uh oh!" |
| `http://localhost:5000/Sante/Kevin`        | Sante, Kevin!                            |
| `http://localhost:5000`                    | Hello World!                             |

Issuing a break (Ctrl-c/SIGINT or SIGTERM) in the console window bypasses the `WaitForShutdown`. The app displays the message and waits for a keypress to exit.

**Start(string url, Action<IRouteBuilder> routeBuilder)**

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
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Produces the same result as **Start(Action<IRouteBuilder> routeBuilder)**, except the app responds at `http://localhost:8080`.

**StartWith(Action<IApplicationBuilder> app)**

Provide a middleware delegate with `Use`:

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
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Make a request in the browser to `http://localhost:5000` to receive the response "Hello World!" Issuing a break (Ctrl-c/SIGINT or SIGTERM) in the console window bypasses the `WaitForShutdown`. The app displays the message and waits for a keypress to exit.

**StartWith(string url, Action<IApplicationBuilder> app)**

Provide a URL and middleware delegate with `Use`:

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
    host.WaitForShutdown();

    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
```

Produces the same result as **StartWith(Action<IApplicationBuilder> app)**, except the app responds on `http://localhost:8080`.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

**Run**

The `Run` method starts the web app and blocks the calling thread until the host is shutdown:

```csharp
host.Run();
```

**Start**

You can run the host in a non-blocking manner by calling its `Start` method:

```csharp
using (host)
{
    host.Start();
    Console.ReadLine();
}
```

If you pass a list of URLs to the `Start` method, it listens on the URLs specified:


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

---

## Ordering importance

Some of the `WebHostBuilder` settings are first read from environment variables, if set. These environment variables use the format `ASPNETCORE_{configurationKey}`. For example to set the URLs that the server listens on by default, you set `ASPNETCORE_URLS`.

You can override any of these environment variable values by specifying configuration (using `UseConfiguration`) or by setting the value explicitly (using `UseUrls` for instance). The host uses whichever option sets the value last. If you want to programmatically set the default URL to one value but allow it to be overridden with configuration, you can use command-line configuration after setting the URL:

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

```csharp
public static IWebHost BuildWebHost(string[] args)
{
    var config = new ConfigurationBuilder()
        .AddCommandLine(args)
        .Build();

    return WebHost.CreateDefaultBuilder(args)
        .UseUrls("http://*:5005") // default URL sets port 5005
        .UseConfiguration(config) // override from command line
        .Configure(app =>
        {
            app.Run(async context => 
                await context.Response.WriteAsync("Hello, World!"));
        })
        .Build();
}
```

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

```csharp
var config = new ConfigurationBuilder()
    .AddCommandLine(args)
    .Build();

var host = new WebHostBuilder()
    .UseUrls("http://*:5005") // default URL sets port 5005
    .UseConfiguration(config) // override from command line
    .UseKestrel()
    .Configure(app =>
    {
        app.Run(async context => 
            await context.Response.WriteAsync("Hello, World!"));
    })
    .Build();
```

---

## IHostingEnvironment interface

The [IHostingEnvironment interface](/aspnet/core/api/microsoft.aspnetcore.hosting.ihostingenvironment) provides information about the app's web hosting environment. You can use constructor injection to obtain the `IHostingEnvironment` in order to use its properties and extension methods:

```csharp
public class CustomFileReader
{
    private readonly IHostingEnvironment _env;

    public CustomFileReader(IHostingEnvironment env)
    {
        _env = env;
    }

    public string ReadFile(string fileName)
    {
        var filename = Path.Combine(_env.WebRootPath, fileName);
    }
}
```

You can use a [convention-based approach](xref:fundamentals/environments#startup-conventions) to configure your app at startup based on the environment. Alternatively, you can inject the `IHostingEnvironment` into the `Startup` constructor for use in `ConfigureServices`:

```csharp
public class Startup
{
    public Startup(IHostingEnvironment env)
    {
        HostingEnvironment = env;
    }

    public IHostingEnvironment HostingEnvironment { get; }

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
> In addition to the `IsDevelopment` extension method, `IHostingEnvironment` offers `IsStaging`, `IsProduction`, and `IsEnvironment(string environmentName)` methods. See [Working with multiple environments](xref:fundamentals/environments) for details.

The `IHostingEnvironment` service can also be injected directly into the `Configure` method for setting up your processing pipeline:

```csharp
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        // In Development, use the developer exception page
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

You can inject `IHostingEnvironment` into the `Invoke` method when creating custom middleware:

```csharp
public async Task Invoke(HttpContext context, IHostingEnvironment env)
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

## IApplicationLifetime interface

The [IApplicationLifetime interface](/aspnet/core/api/microsoft.aspnetcore.hosting.iapplicationlifetime) allows you to perform post-startup and shutdown activities. Three properties on the interface are cancellation tokens that you can register with `Action` methods to define startup and shutdown events. There's also a `StopApplication` method.

| Cancellation Token    | Triggered when&#8230; |
| --------------------- | --------------------- |
| `ApplicationStarted`  | The host has fully started. |
| `ApplicationStopping` | The host is performing a graceful shutdown. Requests may still be processing. Shutdown blocks until this event completes. |
| `ApplicationStopped`  | The host is completing a graceful shutdown. All requests should be completely processed. Shutdown blocks until this event completes. |

| Method            | Action                                        |
| ----------------- | --------------------------------------------- |
| `StopApplication` | Requests termination the current application. |

```csharp
public class Startup 
{
    public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime) 
    {
        appLifetime.ApplicationStarted.Register(OnStarted);
        appLifetime.ApplicationStopping.Register(OnStopping);
        appLifetime.ApplicationStopped.Register(OnStopped);

        var stopApp = true;

        if (stopApp)
        {
            appLifetime.StopApplication();
        }
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

## Troubleshooting System.ArgumentException

**Applies to ASP.NET Core 2.0 Only**

If you build the host by injecting `IStartup` directly into the dependency injection container rather than calling `UseStartup` or `Configure`, you may encounter the following error: `Unhandled Exception: System.ArgumentException: A valid non-empty application name must be provided.`

This occurs because the name of the application (the dependency context assembly name) is required but unknown when the host is built. If you manually inject `IStartup` into the dependency injection container, add the following call to your `WebHostBuilder`:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseSetting("applicationName", "<DependencyContextAssemblyName>")
    ...
```

Alternatively, add a dummy `Configure` to your `WebHostBuilder`:

```csharp
WebHost.CreateDefaultBuilder(args)
    .Configure(_ => { })
    ...
```

**NOTE**: This is only required with the ASP.NET Core 2.0 release and only when you don't call `UseStartup` or `Configure`.

For more information, see [Announcements: Microsoft.Extensions.PlatformAbstractions has been removed (comment)](https://github.com/aspnet/Announcements/issues/237#issuecomment-323786938) and the [StartupInjection sample](https://github.com/aspnet/Hosting/blob/8377d226f1e6e1a97dabdb6769a845eeccc829ed/samples/SampleStartups/StartupInjection.cs).

## Additional resources

* [Publish to Windows using IIS](../publishing/iis.md)
* [Publish to Linux using Nginx](../publishing/linuxproduction.md)
* [Publish to Linux using Apache](../publishing/apache-proxy.md)
* [Host in a Windows Service](xref:hosting/windows-service)
