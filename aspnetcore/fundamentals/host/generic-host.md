---
title: .NET Generic Host in ASP.NET Core
author: tdykstra
description: Use .NET Generic Host in ASP.NET Core apps. Generic Host is responsible for app startup and lifetime management.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 04/22/2026
uid: fundamentals/host/generic-host

# customer intent: As an ASP.NET developer, I want to explore the .NET Generic Host in ASP.NET Core, so I can configure startup and management for my web app.
---
# .NET Generic Host in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-6.0"

The ASP.NET Core templates create instances of <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and <xref:Microsoft.AspNetCore.Builder.WebApplication>. These objects provide a streamlined way to configure and run web applications without a `Startup` class. For more information on `WebApplicationBuilder` and `WebApplication`, see <xref:migration/50-to-60#new-hosting-model>.

:::moniker-end
:::moniker range="< aspnetcore-6.0"

The ASP.NET Core templates create a .NET Generic Host (<xref:Microsoft.Extensions.Hosting.HostBuilder>) instance.

:::moniker-end

This article provides information on using the .NET Generic Host in ASP.NET Core. For information on using the .NET Generic Host in console apps, see [.NET Generic Host](/dotnet/core/extensions/generic-host).

## Understand the role of the host

A *host* is an object that encapsulates an application's resources, such as:

* Dependency injection (DI)
* Logging
* Configuration
* `IHostedService` implementations

When a host starts, it calls the <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A> method on each <xref:Microsoft.Extensions.Hosting.IHostedService> instance registered in the service container's collection of hosted services. In a web app, one of the `IHostedService` implementations is a web service that starts an [HTTP server implementation](xref:fundamentals/index#servers).

By including all of the app's interdependent resources in a single object, the host enables control of application startup and graceful shutdown.

## Set up a host

The host is typically configured, built, and run by code in the _Program.cs_ file. 

:::moniker range=">= aspnetcore-6.0"

The following code creates a host with an `IHostedService` implementation added to the DI container:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Program.cs" id="snippet_Host":::

For an HTTP workload, call the <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method after the <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_HostConfigureWebHostDefaults":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

The `Main` method performs the following tasks:

* Calls a `CreateHostBuilder` method to create and configure a builder object.
* Calls the `Build` and `Run` methods on the builder object.

The ASP.NET Core web templates generate the following code to create a .NET Generic Host instance:

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

The following code creates a Generic Host by using non-HTTP workload. The `IHostedService` implementation is added to the DI container:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
               services.AddHostedService<Worker>();
            });
}
```

For an HTTP workload, the ASP.NET Core templates generate the same `Main` method, but the `CreateHostBuilder` method calls the `ConfigureWebHostDefaults` method:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

If the app uses Entity Framework Core, don't change the name or signature of the `CreateHostBuilder` method. The [Entity Framework Core tools](/ef/core/cli/) expect to find a `CreateHostBuilder` method that configures the host without running the app. For more information, see [Design-time DbContext Creation](/ef/core/cli/dbcontext-creation).

:::moniker-end

## Configure default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method performs the following tasks:

* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A>.

* Loads the host configuration from the following sources:
  * Environment variables prefixed with `DOTNET_`
  * Command-line arguments

* Loads the app configuration in the following order:
  * _appsettings.json_ file
  * _appsettings.{Environment}.json_ file
  * [User secrets](xref:security/app-secrets) (Loaded when the app runs in the `Development` environment by using the entry assembly.)
  * Environment variables
  * Command-line arguments

* Adds the following [logging](xref:fundamentals/logging/index) providers:
  * Console
  * Debug
  * EventSource
  * EventLog (only when running on Windows)

* Enables [scope validation](xref:fundamentals/dependency-injection#scope-validation) and [dependency validation](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) when the environment is `Development`.

The <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method performs the following tasks:

* Loads host configuration from environment variables prefixed with `ASPNETCORE_`.

* Sets [Kestrel](xref:fundamentals/servers/kestrel) server as the web server and configures it by using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.

* Adds [Host Filtering middleware](xref:fundamentals/servers/kestrel/host-filtering).

* Adds [Forwarded Headers middleware](xref:host-and-deploy/proxy-load-balancer#forwarded-headers) if the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` property is set to `true`.

* Enables IIS integration. For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.

For information on how to override default builder settings, see [Configure settings for all app types](#configure-settings-for-all-app-types) and [Configure settings for web apps](#configure-settings-for-web-apps) later in this article.

## Framework-provided services

The .NET Generic Host automatically registers the following services:

* [IHostApplicationLifetime](#ihostapplicationlifetime)
* [IHostLifetime](#ihostlifetime)
* [IHostEnvironment / IWebHostEnvironment](#ihostenvironment-iwebhostenvironment)

For more information on framework-provided services, see <xref:fundamentals/dependency-injection#framework-provided-services>.

### IHostApplicationLifetime

Inject the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> (formerly `IApplicationLifetime`) service into any class for handling post-startup and graceful shutdown tasks. Three properties on the interface are cancellation tokens used for registering app start and app stop event handler methods. The interface also includes a `StopApplication` method, which allows apps to request a graceful shutdown.

When performing a graceful shutdown, the host:

* Triggers the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A> event handlers, which allows the app to run logic before the shutdown process begins.

* Stops the server, which disables new connections. The server waits for requests on existing connections to complete, for as long as the [shutdown timeout](#shutdown-timeout) allows. The server sends the connection close header for further requests on existing connections.

* Triggers the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopped%2A> event handlers, which allows the app to run logic after the application has shutdown.

The following example is an `IHostedService` implementation that registers `IHostApplicationLifetime` event handlers:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Services/HostApplicationLifetimeEventsHostedService.cs" id="snippet_Class":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples-snapshot/3.x/LifetimeEventsHostedService.cs" id="snippet_LifetimeEvents":::

:::moniker-end

### IHostLifetime

The <xref:Microsoft.Extensions.Hosting.IHostLifetime> implementation controls when the host starts and when it stops. The last implementation registered is used.

`Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` is the default `IHostLifetime` implementation.

The `ConsoleLifetime` method performs the following tasks:

* Listens for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>Ctrl</kbd>+<kbd>C</kbd> (macOS), or SIGTERM and calls <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A>, which starts the shutdown process.

* Unblocks extensions, such as by running the [RunAsync](#runasync) and [WaitForShutdownAsync](#waitforshutdownasync) methods.

### IHostEnvironment (IWebHostEnvironment)

Inject the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> service into a class to get information about the following settings:

* [ApplicationName](#application-name)
* [EnvironmentName](#environment-name)
* [ContentRootPath](#content-root)

Web apps implement the `IWebHostEnvironment` interface, which inherits `IHostEnvironment` and adds the [WebRootPath](#web-root).

## Set up host configuration

Host configuration is used for the properties of the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> implementation.

Host configuration is available from the <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A> property inside the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> method. After `ConfigureAppConfiguration`, `HostBuilderContext.Configuration` is replaced with the app config.

To add host configuration, call the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> method on the `IHostBuilder` instance. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

`CreateDefaultBuilder` includes the environment variable provider with the prefix `DOTNET_` and command-line arguments. For web apps, the environment variable provider with prefix `ASPNETCORE_` is added. The prefix is removed when the environment variables are read. For example, the environment variable value for `ASPNETCORE_ENVIRONMENT` becomes the host configuration value for the `environment` key.

The following example creates host configuration:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ConfigureHostConfiguration":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostConfig":::

:::moniker-end

## Create the app configuration

App configuration is created by calling the <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> method on the `IHostBuilder` instance. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key. 

The configuration created by `ConfigureAppConfiguration` is available in the <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A> property for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see <xref:fundamentals/configuration/index>.

## Configure settings for all app types

This section lists host settings that apply to both HTTP and non-HTTP workloads.

By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder.

For more information, see [Configure default builder settings](#configure-default-builder-settings) and [Configuration: Environment variables](xref:fundamentals/configuration/index#environment-variables-configuration-provider).

<!-- In the following sections, two spaces at end of line are used to force line breaks in the rendered page. -->

### Application name

Defines the name of the assembly that contains the entry point for the application.

**Key**: `applicationName`  
**Type**: *string*  
**Default**: The name of the assembly that has the app entry point.  
**Set using**: Environment variable  
**Environment variable**: `{PREFIX_}APPLICATIONNAME`

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName%2A> property is set from the host configuration during host construction.

### Content root

Determines where the host begins the search for content files.

**Key**: `contentRoot`  
**Type**: *string*  
**Default**: The folder where the app assembly resides.  
**Set using**: Environment variable or `UseContentRoot` on `IHostBuilder`  
**Environment variable**: `{PREFIX_}CONTENTROOT`

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath%2A> property identifies where the host begins searching. If the path doesn't exist, the host fails to start.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_UseContentRoot":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .UseContentRoot("c:\\content-root")
    //...
```

:::moniker-end

For more information, see:

* [Fundamentals: Content root](xref:fundamentals/index#content-root)
* [Web root](#web-root)

### Environment name

Provides a name for the environment.

**Key**: `environment`  
**Type**: *string*  
**Default**: `Production`  
**Set using**: Environment variable or call `UseEnvironment` on `IHostBuilder`  
**Environment variable**: `{PREFIX_}ENVIRONMENT`

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName%2A> property can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case-sensitive.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_UseEnvironment":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .UseEnvironment("Development")
    //...
```

:::moniker-end

### Shutdown timeout

Specifies the amount of time to wait for the host to shut down.

**Key**: `shutdownTimeoutSeconds`  
**Type**: *int*  
**Default**: 30 seconds (In .NET 5.0 and earlier, the default is 5 seconds.)  
**Set using**: Environment variable or `HostOptions`  
**Environment variable**: `{PREFIX_}SHUTDOWNTIMEOUTSECONDS`

The <xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout%2A> property sets the timeout for <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>. The default value is 30 seconds.

During the timeout period, the host:

* Triggers <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A>.
* Attempts to stop hosted services, logging errors for services that fail to stop.

If the timeout period expires before all hosted services stop, any remaining active services stop when the app shuts down. The services stop even if they're still processing. If services require more time to stop, increase the timeout.

:::moniker range=">= aspnetcore-6.0"

The following example sets the timeout to 20 seconds:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ShutdownTimeout":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostOptions":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

### Reload config on change

Reloads the  _appsettings.json_ and _appsettings.{Environment}.json_ files when the files change. This behavior is by default, as described in [Default app configuration sources](xref:fundamentals/configuration/index#default-app-configuration-sources). 

**Key**: `hostBuilder:reloadConfigOnChange`  
**Type**: *bool* (`true` or `false`)  
**Default**: `true`  
**Set using**: Command-line argument `hostBuilder:reloadConfigOnChange`  
**Environment variable**: `{PREFIX_}hostBuilder:reloadConfigOnChange`

In .NET 5 and later, you can disable the reload behavior by setting the `hostBuilder:reloadConfigOnChange` argument to `false`.

> [!WARNING]
> The colon (`:`) separator doesn't work with environment variable hierarchical keys on all platforms. For more information, see [Environment variables](xref:fundamentals/configuration/index#environment-variables-configuration-provider).

:::moniker-end

## Configure settings for web apps

Some host settings apply only to HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder.

Extension methods on `IWebHostBuilder` are available for these settings. Code samples that show how to call the extension methods assume `webBuilder` is an instance of `IWebHostBuilder`, as in the following example:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ConfigureWebHostDefaults":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.CaptureStartupErrors(true);
            webBuilder.UseStartup<Startup>();
        });
```

:::moniker-end

### Capture startup errors

Controls the capture of startup errors.

**Key**: `captureStartupErrors`  
**Type**: *bool* (`true`/`1` or `false`/`0`)  
**Default**: `false`. If the app runs with Kestrel behind IIS, the default is `true`.  
**Set using**: Configuration or `CaptureStartupErrors`  
**Environment variable**: `{PREFIX_}CAPTURESTARTUPERRORS`

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderCaptureStartupErrors":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.CaptureStartupErrors(true);
```

:::moniker-end

### Detailed errors

Determines whether to capture detailed errors.

**Key**: `detailedErrors`  
**Type**: *bool* (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Set using**: Configuration or `UseSetting`  
**Environment variable**: `{PREFIX_}DETAILEDERRORS`

When enabled, or when the environment is set to `Development`, the app captures detailed errors.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderDetailedErrors":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
```

:::moniker-end

### Hosting startup assemblies

Provides a semicolon-delimited string of hosting startup assemblies to load on startup.

**Key**: `hostingStartupAssemblies`  
**Type**: *string*  
**Default**: Empty string  
**Set using**: `UseSetting`  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPASSEMBLIES`

Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHostingStartupAssemblies":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2");
```

:::moniker-end

### Hosting startup exclude assemblies

Provides a semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: `hostingStartupExcludeAssemblies`  
**Type**: *string*  
**Default**: Empty string  
**Set using**: Configuration or `UseSetting`  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPEXCLUDEASSEMBLIES`

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHostingStartupExcludeAssemblies":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2");
```

:::moniker-end

### HTTPS port

Sets the HTTPS port for redirection if you get a non-HTTPS connection.

**Key**: `https_port`  
**Type**: *string*  
**Default**: No default.  
**Set using**: Configuration or `UseSetting`  
**Environment variable**: `{PREFIX_}HTTPS_PORT`

This setting is used in [enforcing HTTPS](xref:security/enforcing-ssl). This setting doesn't cause the server to listen on the specified port. That is, it's possible to accidentally redirect requests to an unused port.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHttpsPort":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting("https_port", "8080");
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

### HTTPS ports

Specifies the possible ports to listen on for HTTPS connections.

**Key**: `https_ports`  
**Type**: *string*  
**Default**: No default.  
**Set using**: Configuration or `UseSetting`  
**Environment variable**: `{PREFIX_}HTTPS_PORTS`

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHttpsPorts":::

:::moniker-end


### Prefer hosting URLs

Indicates whether the host should listen on the URLs configured with the `IWebHostBuilder` instead of URLs configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: *bool* (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Set using**: Environment variable or `PreferHostingUrls`  
**Environment variable**: `{PREFIX_}PREFERHOSTINGURLS`

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderPreferHostingUrls":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.PreferHostingUrls(true);
```

:::moniker-end

### Prevent hosting startup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: `preventHostingStartup`  
**Type**: *bool* (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Set using**: Environment variable or `UseSetting`  
**Environment variable**: `{PREFIX_}PREVENTHOSTINGSTARTUP`

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderPreventHostingStartup":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true");
```

:::moniker-end

### Startup assembly

Specifies the assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: *string*  
**Default**: The application assembly.   
**Set using**: Environment variable or `UseStartup`  
**Environment variable**: `{PREFIX_}STARTUPASSEMBLY`

You can reference the assembly by name (`string`) or type (`TStartup`). If multiple `UseStartup` methods are called, the last call takes precedence.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseStartup":::

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseStartupGeneric":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseStartup("StartupAssemblyName");
```

```csharp
webBuilder.UseStartup<Startup>();
```

:::moniker-end

### Suppress status messages

Indicates whether to suppress hosting startup status messages.

**Key**: `suppressStatusMessages`  
**Type**: *bool* (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Set using**: Configuration or `UseSetting`  
**Environment variable**: `{PREFIX_}SUPPRESSSTATUSMESSAGES`

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderSuppressStatusMessages":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "true");
```

:::moniker-end

### Server URLs

Indicates the IP addresses or host addresses with ports and protocols that the server should listen on for requests.

**Key**: `urls`  
**Type**: *string*  
**Default**: `http://localhost:5000` and `https://localhost:5001`  
**Set using**: Environment variable or `UseUrls`  
**Environment variable**: `{PREFIX_}URLS`

Set to a semicolon-separated `;` list of URL prefixes to which the server should respond. For example, `http://localhost:123`. Use a wildcard asterisk `*` to indicate that the server should listen for requests on any IP address or hostname by using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseUrls":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002");
```

:::moniker-end

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### Web root

Sets the relative path to the app's static assets.

**Key**: `webroot`  
**Type**: *string*  
**Default**: `wwwroot`   
**Set using**: Environment variable or `UseWebRoot` on `IWebHostBuilder`  
**Environment variable**: `{PREFIX_}WEBROOT`

The <xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath> property determines the relative path to the app's static assets.  

The path to `{content root}/wwwroot` must exist. If the path doesn't exist, a no-op file provider is used.

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseWebRoot":::

:::moniker-end
:::moniker range="< aspnetcore-6.0"

```csharp
webBuilder.UseWebRoot("public");
```

:::moniker-end

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [Content root](#content-root)

## Manage the host lifetime

To start and stop the application, call methods on the <xref:Microsoft.Extensions.Hosting.IHost> implementation. The methods affect all <xref:Microsoft.Extensions.Hosting.IHostedService> implementations registered in the service container.

The difference between the `Run*` and `Start*` methods is that `Run*` methods wait for the host to complete before returning, whereas `Start*` methods return immediately. The `Run*` methods are typically used in console apps, whereas the `Start*` methods are typically used in long-running services.

### Run

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> method runs the app and blocks the calling thread until the host is shut down. 

### RunAsync

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> method runs the app and returns a <xref:System.Threading.Tasks.Task> object that completes when the cancellation token or shutdown is triggered.

### RunConsoleAsync

The <xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.RunConsoleAsync%2A> method enables console support, builds and starts the host, and waits for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>Ctrl</kbd>+<kbd>C</kbd> (macOS), or SIGTERM to shut down.

### Start

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Start%2A> method launches the host synchronously.

### StartAsync

The <xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> method starts the host and returns a <xref:System.Threading.Tasks.Task> object that completes when the cancellation token or shutdown is triggered. 

The <xref:Microsoft.Extensions.Hosting.IHostLifetime.WaitForStartAsync%2A> method is called at the start of `StartAsync`, which waits until it's complete before continuing. This method can be used to delay startup until signaled by an external event.

### StopAsync

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.StopAsync%2A> method attempts to stop the host within the provided timeout.

### WaitForShutdown

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A> method blocks the calling thread until the IHostLifetime implementation triggers shutdown via <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>Ctrl</kbd>+<kbd>C</kbd> (macOS), or SIGTERM.

### WaitForShutdownAsync

The <xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync%2A> method returns a <xref:System.Threading.Tasks.Task> object that completes when shutdown is triggered via the given token, and then it calls the <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A> method.

:::moniker range="< aspnetcore-6.0"

### Control host lifetime

You can exercise direct control of the host lifetime by calling the following methods externally:

```csharp
public class Program
{
    private IHost _host;

    public Program()
    {
        _host = new HostBuilder()
            .Build();
    }

    public async Task StartAsync()
    {
        _host.StartAsync();
    }

    public async Task StopAsync()
    {
        using (_host)
        {
            await _host.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}
```

:::moniker-end

## Related content

* <xref:fundamentals/host/hosted-services>
* [Generic Host source on GitHub](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Hosting/src/Host.cs)

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
