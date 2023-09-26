---
title: .NET Generic Host in ASP.NET Core
author: tdykstra
description: Use .NET Core Generic Host in ASP.NET Core apps.  Generic Host is responsible for app startup and lifetime management.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 09/05/2023
uid: fundamentals/host/generic-host
---
# .NET Generic Host in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

This article provides information on using the .NET Generic Host in ASP.NET Core.

The ASP.NET Core templates create a <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> and <xref:Microsoft.AspNetCore.Builder.WebApplication>, which provide a streamlined way to configure and run web applications without a `Startup` class. For more information on `WebApplicationBuilder` and `WebApplication`, see <xref:migration/50-to-60#new-hosting-model>.

For information on using the .NET Generic Host in console apps, see [.NET Generic Host](/dotnet/core/extensions/generic-host).

## Host definition

A *host* is an object that encapsulates an app's resources, such as:

* Dependency injection (DI)
* Logging
* Configuration
* `IHostedService` implementations

When a host starts, it calls <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A?displayProperty=nameWithType> on each implementation of <xref:Microsoft.Extensions.Hosting.IHostedService> registered in the service container's collection of hosted services. In a web app, one of the `IHostedService` implementations is a web service that starts an [HTTP server implementation](xref:fundamentals/index#servers).

Including all of the app's interdependent resources in one object enables control over app startup and graceful shutdown.

## Set up a host

The host is typically configured, built, and run by code in the `Program.cs`. The following code creates a host with an `IHostedService` implementation added to the DI container:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Program.cs" id="snippet_Host":::

For an HTTP workload, call <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> after <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_HostConfigureWebHostDefaults":::

## Default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method:

* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A>.
* Loads host configuration from:
  * Environment variables prefixed with `DOTNET_`.
  * Command-line arguments.
* Loads app configuration from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
  * Environment variables.
  * Command-line arguments.
* Adds the following [logging](xref:fundamentals/logging/index) providers:
  * Console
  * Debug
  * EventSource
  * EventLog (only when running on Windows)
* Enables [scope validation](xref:fundamentals/dependency-injection#scope-validation) and [dependency validation](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) when the environment is Development.

The <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method:

* Loads host configuration from environment variables prefixed with `ASPNETCORE_`.
* Sets [Kestrel](xref:fundamentals/servers/kestrel) server as the web server and configures it using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.
* Adds [Host Filtering middleware](xref:fundamentals/servers/kestrel/host-filtering).
* Adds [Forwarded Headers middleware](xref:host-and-deploy/proxy-load-balancer#forwarded-headers) if `ASPNETCORE_FORWARDEDHEADERS_ENABLED` equals `true`.
* Enables IIS integration. For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.

The [Settings for all app types](#settings-for-all-app-types) and [Settings for web apps](#settings-for-web-apps) sections later in this article show how to override default builder settings.

## Framework-provided services

The following services are registered automatically:

* [IHostApplicationLifetime](#ihostapplicationlifetime)
* [IHostLifetime](#ihostlifetime)
* [IHostEnvironment / IWebHostEnvironment](#ihostenvironment)

For more information on framework-provided services, see <xref:fundamentals/dependency-injection#framework-provided-services>.

## IHostApplicationLifetime

Inject the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> (formerly `IApplicationLifetime`) service into any class to handle post-startup and graceful shutdown tasks. Three properties on the interface are cancellation tokens used to register app start and app stop event handler methods. The interface also includes a `StopApplication` method, which allows apps to request a graceful shutdown.

When performing a graceful shutdown, the host:

* Triggers the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A> event handlers, which allows the app to run logic before the shutdown process begins.
* Stops the server, which disables new connections. The server waits for requests on existing connections to complete, for as long as the [shutdown timeout](#shutdowntimeout) allows. The server sends the connection close header for further requests on existing connections.
* Triggers the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopped%2A> event handlers, which allows the app to run logic after the application has shutdown.

The following example is an `IHostedService` implementation that registers `IHostApplicationLifetime` event handlers:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Services/HostApplicationLifetimeEventsHostedService.cs" id="snippet_Class":::

## IHostLifetime

The <xref:Microsoft.Extensions.Hosting.IHostLifetime> implementation controls when the host starts and when it stops. The last implementation registered is used.

`Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` is the default `IHostLifetime` implementation. `ConsoleLifetime`:

* Listens for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM and calls <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A> to start the shutdown process.
* Unblocks extensions such as [RunAsync](#runasync) and [WaitForShutdownAsync](#waitforshutdownasync).

## IHostEnvironment

Inject the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> service into a class to get information about the following settings:

* [ApplicationName](#applicationname)
* [EnvironmentName](#environmentname)
* [ContentRootPath](#contentroot)

Web apps implement the `IWebHostEnvironment` interface, which inherits `IHostEnvironment` and adds the [WebRootPath](#webroot).

## Host configuration

Host configuration is used for the properties of the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> implementation.

Host configuration is available from <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> inside <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>. After `ConfigureAppConfiguration`, `HostBuilderContext.Configuration` is replaced with the app config.

To add host configuration, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> on `IHostBuilder`. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

The environment variable provider with prefix `DOTNET_` and command-line arguments are included by `CreateDefaultBuilder`. For web apps, the environment variable provider with prefix `ASPNETCORE_` is added. The prefix is removed when the environment variables are read. For example, the environment variable value for `ASPNETCORE_ENVIRONMENT` becomes the host configuration value for the `environment` key.

The following example creates host configuration:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ConfigureHostConfiguration":::

## App configuration

App configuration is created by calling <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> on `IHostBuilder`. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key. 

The configuration created by `ConfigureAppConfiguration` is available at <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see <xref:fundamentals/configuration/index>.

## Settings for all app types

This section lists host settings that apply to both HTTP and non-HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder. For more information, see the [Default builder settings](#default-builder-settings) section and [Configuration: Environment variables](xref:fundamentals/configuration/index#environment-variables).

<!-- In the following sections, two spaces at end of line are used to force line breaks in the rendered page. -->

### ApplicationName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName%2A?displayProperty=nameWithType> property is set from host configuration during host construction.

**Key**: `applicationName`  
**Type**: `string`  
**Default**: The name of the assembly that contains the app's entry point.  
**Environment variable**: `{PREFIX_}APPLICATIONNAME`

To set this value, use the environment variable. 

### ContentRoot

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath%2A?displayProperty=nameWithType> property determines where the host begins searching for content files. If the path doesn't exist, the host fails to start.

**Key**: `contentRoot`  
**Type**: `string`  
**Default**: The folder where the app assembly resides.  
**Environment variable**: `{PREFIX_}CONTENTROOT`

To set this value, use the environment variable or call `UseContentRoot` on `IHostBuilder`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_UseContentRoot":::

For more information, see:

* [Fundamentals: Content root](xref:fundamentals/index#content-root)
* [WebRoot](#webroot)

### EnvironmentName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName%2A?displayProperty=nameWithType> property can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case-sensitive.

**Key**: `environment`  
**Type**: `string`  
**Default**: `Production`  
**Environment variable**: `{PREFIX_}ENVIRONMENT`

To set this value, use the environment variable or call `UseEnvironment` on `IHostBuilder`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_UseEnvironment":::

### ShutdownTimeout

<xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout%2A?displayProperty=nameWithType> sets the timeout for <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>. The default value is five seconds.  During the timeout period, the host:

* Triggers <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require more time to stop, increase the timeout.

**Key**: `shutdownTimeoutSeconds`  
**Type**: `int`  
**Default**: 5 seconds  
**Environment variable**: `{PREFIX_}SHUTDOWNTIMEOUTSECONDS`

To set this value, use the environment variable or configure `HostOptions`. The following example sets the timeout to 20 seconds:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ShutdownTimeout":::

### Disable app configuration reload on change

By [default](xref:fundamentals/configuration/index#default), `appsettings.json` and `appsettings.{Environment}.json` are reloaded when the file changes. To disable this reload behavior in ASP.NET Core 5.0 or later, set the `hostBuilder:reloadConfigOnChange` key to `false`.

**Key**: `hostBuilder:reloadConfigOnChange`  
**Type**: `bool` (`true` or `false`)  
**Default**: `true`  
**Command-line argument**: `hostBuilder:reloadConfigOnChange`  
**Environment variable**: `{PREFIX_}hostBuilder:reloadConfigOnChange`

> [!WARNING]
> The colon (`:`) separator doesn't work with environment variable hierarchical keys on all platforms. For more information, see [Environment variables](xref:fundamentals/configuration/index#environment-variables).

## Settings for web apps

Some host settings apply only to HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder.

Extension methods on `IWebHostBuilder` are available for these settings. Code samples that show how to call the extension methods assume `webBuilder` is an instance of `IWebHostBuilder`, as in the following example:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_ConfigureWebHostDefaults":::

### CaptureStartupErrors

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

**Key**: `captureStartupErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Environment variable**: `{PREFIX_}CAPTURESTARTUPERRORS`

To set this value, use configuration or call `CaptureStartupErrors`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderCaptureStartupErrors":::

### DetailedErrors

When enabled, or when the environment is `Development`, the app captures detailed errors.

**Key**: `detailedErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}DETAILEDERRORS`

To set this value, use configuration or call `UseSetting`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderDetailedErrors":::

### HostingStartupAssemblies

A semicolon-delimited string of hosting startup assemblies to load on startup. Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

**Key**: `hostingStartupAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHostingStartupAssemblies":::

### HostingStartupExcludeAssemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: `hostingStartupExcludeAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPEXCLUDEASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHostingStartupExcludeAssemblies":::

### HTTPS_Port

The HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: `https_port`  
**Type**: `string`  
**Default**: A default value isn't set.  
**Environment variable**: `{PREFIX_}HTTPS_PORT`

To set this value, use configuration or call `UseSetting`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderHttpsPort":::

### PreferHostingUrls

Indicates whether the host should listen on the URLs configured with the `IWebHostBuilder` instead of those URLs configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `true`  
**Environment variable**: `{PREFIX_}PREFERHOSTINGURLS`

To set this value, use the environment variable or call `PreferHostingUrls`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderPreferHostingUrls":::

### PreventHostingStartup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: `preventHostingStartup`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}PREVENTHOSTINGSTARTUP`

To set this value, use the environment variable or call `UseSetting` :

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderPreventHostingStartup":::

### StartupAssembly

The assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: `string`  
**Default**: The app's assembly  
**Environment variable**: `{PREFIX_}STARTUPASSEMBLY`

To set this value, use the environment variable or call `UseStartup`. `UseStartup` can take an assembly name (`string`) or a type (`TStartup`). If multiple `UseStartup` methods are called, the last one takes precedence.

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseStartup":::
:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseStartupGeneric":::

### SuppressStatusMessages

When enabled, suppresses hosting startup status messages.

**Key**: `suppressStatusMessages`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}SUPPRESSSTATUSMESSAGES`

To set this value, use configuration or call `UseSetting`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderSuppressStatusMessages":::

### URLs

A semicolon-delimited list of IP addresses or host addresses with ports and protocols that the server should listen on for requests. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

**Key**: `urls`  
**Type**: `string`  
**Default**: `http://localhost:5000` and `https://localhost:5001`  
**Environment variable**: `{PREFIX_}URLS`

To set this value, use the environment variable or call `UseUrls`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseUrls":::

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### WebRoot

The [IWebHostEnvironment.WebRootPath](xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath) property determines the relative path to the app's static assets. If the path doesn't exist, a no-op file provider is used.  

**Key**: `webroot`  
**Type**: `string`  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist.  
**Environment variable**: `{PREFIX_}WEBROOT`

To set this value, use the environment variable or call `UseWebRoot` on `IWebHostBuilder`:

:::code language="csharp" source="generic-host/samples/6.x/GenericHostSample/Snippets/Program.cs" id="snippet_WebHostBuilderUseWebRoot":::

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [ContentRoot](#contentroot)

## Manage the host lifetime

Call methods on the built <xref:Microsoft.Extensions.Hosting.IHost> implementation to start and stop the app. These methods affect all  <xref:Microsoft.Extensions.Hosting.IHostedService> implementations that are registered in the service container.

The difference between `Run*` and `Start*` methods is that `Run*` methods wait for the host to complete before returning, whereas `Start*` methods return immediately. The `Run*` methods are typically used in console apps, whereas the `Start*` methods are typically used in long-running services.

### Run

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> runs the app and blocks the calling thread until the host is shut down.

### RunAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> runs the app and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered.

### RunConsoleAsync

<xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.RunConsoleAsync%2A> enables console support, builds and starts the host, and waits for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM to shut down.

### Start

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Start%2A> starts the host synchronously.

### StartAsync

<xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> starts the host and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered. 

<xref:Microsoft.Extensions.Hosting.IHostLifetime.WaitForStartAsync%2A> is called at the start of `StartAsync`, which waits until it's complete before continuing. This method can be used to delay startup until signaled by an external event.

### StopAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.StopAsync%2A> attempts to stop the host within the provided timeout.

### WaitForShutdown

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A> blocks the calling thread until shutdown is triggered by the IHostLifetime, such as via <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM.

### WaitForShutdownAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync%2A> returns a <xref:System.Threading.Tasks.Task> that completes when shutdown is triggered via the given token and calls <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

The ASP.NET Core templates create a .NET Core Generic Host (<xref:Microsoft.Extensions.Hosting.HostBuilder>).

This article provides information on using .NET Generic Host in ASP.NET Core. For information on using .NET Generic Host in console apps, see [.NET Generic Host](/dotnet/core/extensions/generic-host).

## Host definition

A *host* is an object that encapsulates an app's resources, such as:

* Dependency injection (DI)
* Logging
* Configuration
* `IHostedService` implementations

When a host starts, it calls <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A?displayProperty=nameWithType> on each implementation of <xref:Microsoft.Extensions.Hosting.IHostedService> registered in the service container's collection of hosted services. In a web app, one of the `IHostedService` implementations is a web service that starts an [HTTP server implementation](xref:fundamentals/index#servers).

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown.

## Set up a host

The host is typically configured, built, and run by code in the `Program` class. The `Main` method:

* Calls a `CreateHostBuilder` method to create and configure a builder object.
* Calls `Build` and `Run` methods on the builder object.

The ASP.NET Core web templates generate the following code to create a host:

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

The following code creates a non-HTTP workload with an `IHostedService` implementation added to the DI container.

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

For an HTTP workload, the `Main` method is the same but `CreateHostBuilder` calls `ConfigureWebHostDefaults`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

If the app uses Entity Framework Core, don't change the name or signature of the `CreateHostBuilder` method. The [Entity Framework Core tools](/ef/core/miscellaneous/cli/) expect to find a `CreateHostBuilder` method that configures the host without running the app. For more information, see [Design-time DbContext Creation](/ef/core/miscellaneous/cli/dbcontext-creation).

## Default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method:

* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A>.
* Loads host configuration from:
  * Environment variables prefixed with `DOTNET_`.
  * Command-line arguments.
* Loads app configuration from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
  * Environment variables.
  * Command-line arguments.
* Adds the following [logging](xref:fundamentals/logging/index) providers:
  * Console
  * Debug
  * EventSource
  * EventLog (only when running on Windows)
* Enables [scope validation](xref:fundamentals/dependency-injection#scope-validation) and [dependency validation](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) when the environment is Development.

The <xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A> method:

* Loads host configuration from environment variables prefixed with `ASPNETCORE_`.
* Sets [Kestrel](xref:fundamentals/servers/kestrel) server as the web server and configures it using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel/options>.
* Adds [Host Filtering middleware](xref:fundamentals/servers/kestrel/host-filtering).
* Adds [Forwarded Headers middleware](xref:host-and-deploy/proxy-load-balancer#forwarded-headers) if `ASPNETCORE_FORWARDEDHEADERS_ENABLED` equals `true`.
* Enables IIS integration. For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.

The [Settings for all app types](#settings-for-all-app-types) and [Settings for web apps](#settings-for-web-apps) sections later in this article show how to override default builder settings.

## Framework-provided services

The following services are registered automatically:

* [IHostApplicationLifetime](#ihostapplicationlifetime)
* [IHostLifetime](#ihostlifetime)
* [IHostEnvironment / IWebHostEnvironment](#ihostenvironment)

For more information on framework-provided services, see <xref:fundamentals/dependency-injection#framework-provided-services>.

## IHostApplicationLifetime

Inject the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> (formerly `IApplicationLifetime`) service into any class to handle post-startup and graceful shutdown tasks. Three properties on the interface are cancellation tokens used to register app start and app stop event handler methods. The interface also includes a `StopApplication` method.

The following example is an `IHostedService` implementation that registers `IHostApplicationLifetime` events:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/LifetimeEventsHostedService.cs" id="snippet_LifetimeEvents":::

## IHostLifetime

The <xref:Microsoft.Extensions.Hosting.IHostLifetime> implementation controls when the host starts and when it stops. The last implementation registered is used.

`Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` is the default `IHostLifetime` implementation. `ConsoleLifetime`:

* Listens for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM and calls <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A> to start the shutdown process.
* Unblocks extensions such as [RunAsync](#runasync) and [WaitForShutdownAsync](#waitforshutdownasync).

## IHostEnvironment

Inject the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> service into a class to get information about the following settings:

* [ApplicationName](#applicationname)
* [EnvironmentName](#environmentname)
* [ContentRootPath](#contentroot)

Web apps implement the `IWebHostEnvironment` interface, which inherits `IHostEnvironment` and adds the [WebRootPath](#webroot).

## Host configuration

Host configuration is used for the properties of the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> implementation.

Host configuration is available from <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> inside <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>. After `ConfigureAppConfiguration`, `HostBuilderContext.Configuration` is replaced with the app config.

To add host configuration, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> on `IHostBuilder`. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

The environment variable provider with prefix `DOTNET_` and command-line arguments are included by `CreateDefaultBuilder`. For web apps, the environment variable provider with prefix `ASPNETCORE_` is added. The prefix is removed when the environment variables are read. For example, the environment variable value for `ASPNETCORE_ENVIRONMENT` becomes the host configuration value for the `environment` key.

The following example creates host configuration:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostConfig":::

## App configuration

App configuration is created by calling <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> on `IHostBuilder`. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key. 

The configuration created by `ConfigureAppConfiguration` is available at <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see <xref:fundamentals/configuration/index>.

## Settings for all app types

This section lists host settings that apply to both HTTP and non-HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder. For more information, see the [Default builder settings](#default-builder-settings) section and [Configuration: Environment variables](xref:fundamentals/configuration/index#environment-variables).

<!-- In the following sections, two spaces at end of line are used to force line breaks in the rendered page. -->

### ApplicationName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName%2A?displayProperty=nameWithType> property is set from host configuration during host construction.

**Key**: `applicationName`  
**Type**: `string`  
**Default**: The name of the assembly that contains the app's entry point.  
**Environment variable**: `{PREFIX_}APPLICATIONNAME`

To set this value, use the environment variable. 

### ContentRoot

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath%2A?displayProperty=nameWithType> property determines where the host begins searching for content files. If the path doesn't exist, the host fails to start.

**Key**: `contentRoot`  
**Type**: `string`  
**Default**: The folder where the app assembly resides.  
**Environment variable**: `{PREFIX_}CONTENTROOT`

To set this value, use the environment variable or call `UseContentRoot` on `IHostBuilder`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseContentRoot("c:\\content-root")
    //...
```

For more information, see:

* [Fundamentals: Content root](xref:fundamentals/index#content-root)
* [WebRoot](#webroot)

### EnvironmentName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName%2A?displayProperty=nameWithType> property can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case-sensitive.

**Key**: `environment`  
**Type**: `string`  
**Default**: `Production`  
**Environment variable**: `{PREFIX_}ENVIRONMENT`

To set this value, use the environment variable or call `UseEnvironment` on `IHostBuilder`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseEnvironment("Development")
    //...
```

### ShutdownTimeout

<xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout%2A?displayProperty=nameWithType> sets the timeout for <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>. The default value is five seconds.  During the timeout period, the host:

* Triggers <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require more time to stop, increase the timeout.

**Key**: `shutdownTimeoutSeconds`  
**Type**: `int`  
**Default**: 5 seconds  
**Environment variable**: `{PREFIX_}SHUTDOWNTIMEOUTSECONDS`

To set this value, use the environment variable or configure `HostOptions`. The following example sets the timeout to 20 seconds:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostOptions":::

### Disable app configuration reload on change

By [default](xref:fundamentals/configuration/index#default), `appsettings.json` and `appsettings.{Environment}.json` are reloaded when the file changes. To disable this reload behavior in ASP.NET Core 5.0 or later, set the `hostBuilder:reloadConfigOnChange` key to `false`.

**Key**: `hostBuilder:reloadConfigOnChange`  
**Type**: `bool` (`true` or `false`)  
**Default**: `true`  
**Command-line argument**: `hostBuilder:reloadConfigOnChange`  
**Environment variable**: `{PREFIX_}hostBuilder:reloadConfigOnChange`

> [!WARNING]
> The colon (`:`) separator doesn't work with environment variable hierarchical keys on all platforms. For more information, see [Environment variables](xref:fundamentals/configuration/index#environment-variables).

## Settings for web apps

Some host settings apply only to HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following list of settings as the `{PREFIX_}` placeholder.

Extension methods on `IWebHostBuilder` are available for these settings. Code samples that show how to call the extension methods assume `webBuilder` is an instance of `IWebHostBuilder`, as in the following example:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.CaptureStartupErrors(true);
            webBuilder.UseStartup<Startup>();
        });
```

### CaptureStartupErrors

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

**Key**: `captureStartupErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Environment variable**: `{PREFIX_}CAPTURESTARTUPERRORS`

To set this value, use configuration or call `CaptureStartupErrors`:

```csharp
webBuilder.CaptureStartupErrors(true);
```

### DetailedErrors

When enabled, or when the environment is `Development`, the app captures detailed errors.

**Key**: `detailedErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}DETAILEDERRORS`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
```

### HostingStartupAssemblies

A semicolon-delimited string of hosting startup assemblies to load on startup. Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

**Key**: `hostingStartupAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2");
```

### HostingStartupExcludeAssemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: `hostingStartupExcludeAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPEXCLUDEASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2");
```

### HTTPS_Port

The HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: `https_port`  
**Type**: `string`  
**Default**: A default value isn't set.  
**Environment variable**: `{PREFIX_}HTTPS_PORT`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting("https_port", "8080");
```

### PreferHostingUrls

Indicates whether the host should listen on the URLs configured with the `IWebHostBuilder` instead of those URLs configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `true`  
**Environment variable**: `{PREFIX_}PREFERHOSTINGURLS`

To set this value, use the environment variable or call `PreferHostingUrls`:

```csharp
webBuilder.PreferHostingUrls(false);
```

### PreventHostingStartup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: `preventHostingStartup`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}PREVENTHOSTINGSTARTUP`

To set this value, use the environment variable or call `UseSetting` :

```csharp
webBuilder.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true");
```

### StartupAssembly

The assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: `string`  
**Default**: The app's assembly  
**Environment variable**: `{PREFIX_}STARTUPASSEMBLY`

To set this value, use the environment variable or call `UseStartup`. `UseStartup` can take an assembly name (`string`) or a type (`TStartup`). If multiple `UseStartup` methods are called, the last one takes precedence.

```csharp
webBuilder.UseStartup("StartupAssemblyName");
```

```csharp
webBuilder.UseStartup<Startup>();
```

### SuppressStatusMessages

When enabled, suppresses hosting startup status messages.

**Key**: `suppressStatusMessages`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}SUPPRESSSTATUSMESSAGES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "true");
```

### URLs

A semicolon-delimited list of IP addresses or host addresses with ports and protocols that the server should listen on for requests. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

**Key**: `urls`  
**Type**: `string`  
**Default**: `http://localhost:5000` and `https://localhost:5001`  
**Environment variable**: `{PREFIX_}URLS`

To set this value, use the environment variable or call `UseUrls`:

```csharp
webBuilder.UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002");
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel/endpoints>.

### WebRoot

The [IWebHostEnvironment.WebRootPath](xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath) property determines the relative path to the app's static assets. If the path doesn't exist, a no-op file provider is used.  

**Key**: `webroot`  
**Type**: `string`  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist.  
**Environment variable**: `{PREFIX_}WEBROOT`

To set this value, use the environment variable or call `UseWebRoot` on `IWebHostBuilder`:

```csharp
webBuilder.UseWebRoot("public");
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [ContentRoot](#contentroot)

## Manage the host lifetime

Call methods on the built <xref:Microsoft.Extensions.Hosting.IHost> implementation to start and stop the app. These methods affect all  <xref:Microsoft.Extensions.Hosting.IHostedService> implementations that are registered in the service container.

The difference between `Run*` and `Start*` methods is that `Run*` methods wait for the host to complete before returning, whereas `Start*` methods return immediately. The `Run*` methods are typically used in console apps, whereas the `Start*` methods are typically used in long-running services.

### Run

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> runs the app and blocks the calling thread until the host is shut down.

### RunAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> runs the app and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered.

### RunConsoleAsync

<xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.RunConsoleAsync%2A> enables console support, builds and starts the host, and waits for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM to shut down.

### Start

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Start%2A> starts the host synchronously.

### StartAsync

<xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> starts the host and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered. 

<xref:Microsoft.Extensions.Hosting.IHostLifetime.WaitForStartAsync%2A> is called at the start of `StartAsync`, which waits until it's complete before continuing. This method can be used to delay startup until signaled by an external event.

### StopAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.StopAsync%2A> attempts to stop the host within the provided timeout.

### WaitForShutdown

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A> blocks the calling thread until shutdown is triggered by the IHostLifetime, such as via <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM.

### WaitForShutdownAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync%2A> returns a <xref:System.Threading.Tasks.Task> that completes when shutdown is triggered via the given token and calls <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>.

### External control

Direct control of the host lifetime can be achieved using methods that can be called externally:

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

:::moniker range="< aspnetcore-5.0"

The ASP.NET Core templates create a .NET Core Generic Host (<xref:Microsoft.Extensions.Hosting.HostBuilder>).

This article provides information on using .NET Generic Host in ASP.NET Core. For information on using .NET Generic Host in console apps, see [.NET Generic Host](/dotnet/core/extensions/generic-host).

## Host definition

A *host* is an object that encapsulates an app's resources, such as:

* Dependency injection (DI)
* Logging
* Configuration
* `IHostedService` implementations

When a host starts, it calls <xref:Microsoft.Extensions.Hosting.IHostedService.StartAsync%2A?displayProperty=nameWithType> on each implementation of <xref:Microsoft.Extensions.Hosting.IHostedService> registered in the service container's collection of hosted services. In a web app, one of the `IHostedService` implementations is a web service that starts an [HTTP server implementation](xref:fundamentals/index#servers).

The main reason for including all of the app's interdependent resources in one object is lifetime management: control over app startup and graceful shutdown.

## Set up a host

The host is typically configured, built, and run by code in the `Program` class. The `Main` method:

* Calls a `CreateHostBuilder` method to create and configure a builder object.
* Calls `Build` and `Run` methods on the builder object.

The ASP.NET Core web templates generate the following code to create a Generic Host:

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

The following code creates a Generic Host using non-HTTP workload. The `IHostedService` implementation is added to the DI container:

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

For an HTTP workload, the `Main` method is the same but `CreateHostBuilder` calls `ConfigureWebHostDefaults`:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

The preceding code is generated by the ASP.NET Core templates.

If the app uses Entity Framework Core, don't change the name or signature of the `CreateHostBuilder` method. The [Entity Framework Core tools](/ef/core/miscellaneous/cli/) expect to find a `CreateHostBuilder` method that configures the host without running the app. For more information, see [Design-time DbContext Creation](/ef/core/miscellaneous/cli/dbcontext-creation).

## Default builder settings

The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method:

* Sets the [content root](xref:fundamentals/index#content-root) to the path returned by <xref:System.IO.Directory.GetCurrentDirectory%2A>.
* Loads host configuration from:
  * Environment variables prefixed with `DOTNET_`.
  * Command-line arguments.
* Loads app configuration from:
  * `appsettings.json`.
  * `appsettings.{Environment}.json`.
  * [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
  * Environment variables.
  * Command-line arguments.
* Adds the following [logging](xref:fundamentals/logging/index) providers:
  * Console
  * Debug
  * EventSource
  * EventLog (only when running on Windows)
* Enables [scope validation](xref:fundamentals/dependency-injection#scope-validation) and [dependency validation](xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild) when the environment is Development.

The `ConfigureWebHostDefaults` method:

* Loads host configuration from environment variables prefixed with `ASPNETCORE_`.
* Sets [Kestrel](xref:fundamentals/servers/kestrel) server as the web server and configures it using the app's hosting configuration providers. For the Kestrel server's default options, see <xref:fundamentals/servers/kestrel#kestrel-options>.
* Adds [Host Filtering middleware](xref:fundamentals/servers/kestrel#host-filtering).
* Adds [Forwarded Headers middleware](xref:host-and-deploy/proxy-load-balancer#forwarded-headers) if `ASPNETCORE_FORWARDEDHEADERS_ENABLED` equals `true`.
* Enables IIS integration. For the IIS default options, see <xref:host-and-deploy/iis/index#iis-options>.

The [Settings for all app types](#settings-for-all-app-types) and [Settings for web apps](#settings-for-web-apps) sections later in this article show how to override default builder settings.

## Framework-provided services

The following services are registered automatically:

* [IHostApplicationLifetime](#ihostapplicationlifetime)
* [IHostLifetime](#ihostlifetime)
* [IHostEnvironment / IWebHostEnvironment](#ihostenvironment)

For more information on framework-provided services, see <xref:fundamentals/dependency-injection#framework-provided-services>.

## IHostApplicationLifetime

Inject the <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime> (formerly `IApplicationLifetime`) service into any class to handle post-startup and graceful shutdown tasks. Three properties on the interface are cancellation tokens used to register app start and app stop event handler methods. The interface also includes a `StopApplication` method.

The following example is an `IHostedService` implementation that registers `IHostApplicationLifetime` events:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/LifetimeEventsHostedService.cs" id="snippet_LifetimeEvents":::

## IHostLifetime

The <xref:Microsoft.Extensions.Hosting.IHostLifetime> implementation controls when the host starts and when it stops. The last implementation registered is used.

`Microsoft.Extensions.Hosting.Internal.ConsoleLifetime` is the default `IHostLifetime` implementation. `ConsoleLifetime`:

* Listens for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM and calls <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.StopApplication%2A> to start the shutdown process.
* Unblocks extensions such as [RunAsync](#runasync) and [WaitForShutdownAsync](#waitforshutdownasync).

## IHostEnvironment

Inject the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> service into a class to get information about the following settings:

* [ApplicationName](#applicationname)
* [EnvironmentName](#environmentname)
* [ContentRootPath](#contentroot)

Web apps implement the `IWebHostEnvironment` interface, which inherits `IHostEnvironment` and adds the [WebRootPath](#webroot).

## Host configuration

Host configuration is used for the properties of the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> implementation.

Host configuration is available from <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> inside <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>. After `ConfigureAppConfiguration`, `HostBuilderContext.Configuration` is replaced with the app config.

To add host configuration, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration%2A> on `IHostBuilder`. `ConfigureHostConfiguration` can be called multiple times with additive results. The host uses whichever option sets a value last on a given key.

The environment variable provider with prefix `DOTNET_` and command-line arguments are included by `CreateDefaultBuilder`. For web apps, the environment variable provider with prefix `ASPNETCORE_` is added. The prefix is removed when the environment variables are read. For example, the environment variable value for `ASPNETCORE_ENVIRONMENT` becomes the host configuration value for the `environment` key.

The following example creates host configuration:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostConfig":::

## App configuration

App configuration is created by calling <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A> on `IHostBuilder`. `ConfigureAppConfiguration` can be called multiple times with additive results. The app uses whichever option sets a value last on a given key. 

The configuration created by `ConfigureAppConfiguration` is available at <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> for subsequent operations and as a service from DI. The host configuration is also added to the app configuration.

For more information, see [Configuration in ASP.NET Core](xref:fundamentals/configuration/index).

## Settings for all app types

This section lists host settings that apply to both HTTP and non-HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix, which appear in the following configuration for the `{PREFIX_}` placeholder.

<!-- In the following sections, two spaces at end of line are used to force line breaks in the rendered page. -->

### ApplicationName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ApplicationName%2A?displayProperty=nameWithType> property is set from host configuration during host construction.

**Key**: `applicationName`  
**Type**: `string`  
**Default**: The name of the assembly that contains the app's entry point.  
**Environment variable**: `{PREFIX_}APPLICATIONNAME`

To set this value, use the environment variable. 

### ContentRoot

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.ContentRootPath%2A?displayProperty=nameWithType> property determines where the host begins searching for content files. If the path doesn't exist, the host fails to start.

**Key**: `contentRoot`  
**Type**: `string`  
**Default**: The folder where the app assembly resides.  
**Environment variable**: `{PREFIX_}CONTENTROOT`

To set this value, use the environment variable or call `UseContentRoot` on `IHostBuilder`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseContentRoot("c:\\content-root")
    //...
```

For more information, see:

* [Fundamentals: Content root](xref:fundamentals/index#content-root)
* [WebRoot](#webroot)

### EnvironmentName

The <xref:Microsoft.Extensions.Hosting.IHostEnvironment.EnvironmentName%2A?displayProperty=nameWithType> property can be set to any value. Framework-defined values include `Development`, `Staging`, and `Production`. Values aren't case-sensitive.

**Key**: `environment`  
**Type**: `string`  
**Default**: `Production`  
**Environment variable**: `{PREFIX_}ENVIRONMENT`

To set this value, use the environment variable or call `UseEnvironment` on `IHostBuilder`:

```csharp
Host.CreateDefaultBuilder(args)
    .UseEnvironment("Development")
    //...
```

### ShutdownTimeout

<xref:Microsoft.Extensions.Hosting.HostOptions.ShutdownTimeout%2A?displayProperty=nameWithType> sets the timeout for <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>. The default value is five seconds.  During the timeout period, the host:

* Triggers <xref:Microsoft.Extensions.Hosting.IHostApplicationLifetime.ApplicationStopping%2A?displayProperty=nameWithType>.
* Attempts to stop hosted services, logging errors for services that fail to stop.

If the timeout period expires before all of the hosted services stop, any remaining active services are stopped when the app shuts down. The services stop even if they haven't finished processing. If services require more time to stop, increase the timeout.

**Key**: `shutdownTimeoutSeconds`  
**Type**: `int`  
**Default**: 5 seconds  
**Environment variable**: `{PREFIX_}SHUTDOWNTIMEOUTSECONDS`

To set this value, use the environment variable or configure `HostOptions`. The following example sets the timeout to 20 seconds:

:::code language="csharp" source="generic-host/samples-snapshot/3.x/Program.cs" id="snippet_HostOptions":::

## Settings for web apps

Some host settings apply only to HTTP workloads. By default, environment variables used to configure these settings can have a `DOTNET_` or `ASPNETCORE_` prefix.

Extension methods on `IWebHostBuilder` are available for these settings. Code samples that show how to call the extension methods assume `webBuilder` is an instance of `IWebHostBuilder`, as in the following example:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.CaptureStartupErrors(true);
            webBuilder.UseStartup<Startup>();
        });
```

### CaptureStartupErrors

When `false`, errors during startup result in the host exiting. When `true`, the host captures exceptions during startup and attempts to start the server.

**Key**: `captureStartupErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: Defaults to `false` unless the app runs with Kestrel behind IIS, where the default is `true`.  
**Environment variable**: `{PREFIX_}CAPTURESTARTUPERRORS`

To set this value, use configuration or call `CaptureStartupErrors`:

```csharp
webBuilder.CaptureStartupErrors(true);
```

### DetailedErrors

When enabled, or when the environment is `Development`, the app captures detailed errors.

**Key**: `detailedErrors`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}DETAILEDERRORS`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
```

### HostingStartupAssemblies

A semicolon-delimited string of hosting startup assemblies to load on startup. Although the configuration value defaults to an empty string, the hosting startup assemblies always include the app's assembly. When hosting startup assemblies are provided, they're added to the app's assembly for loading when the app builds its common services during startup.

**Key**: `hostingStartupAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupAssembliesKey, "assembly1;assembly2");
```

### HostingStartupExcludeAssemblies

A semicolon-delimited string of hosting startup assemblies to exclude on startup.

**Key**: `hostingStartupExcludeAssemblies`  
**Type**: `string`  
**Default**: Empty string  
**Environment variable**: `{PREFIX_}HOSTINGSTARTUPEXCLUDEASSEMBLIES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.HostingStartupExcludeAssembliesKey, "assembly1;assembly2");
```

### HTTPS_Port

The HTTPS redirect port. Used in [enforcing HTTPS](xref:security/enforcing-ssl).

**Key**: `https_port`  
**Type**: `string`  
**Default**: A default value isn't set.  
**Environment variable**: `{PREFIX_}HTTPS_PORT`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting("https_port", "8080");
```

### PreferHostingUrls

Indicates whether the host should listen on the URLs configured with the `IWebHostBuilder` instead of those URLs configured with the `IServer` implementation.

**Key**: `preferHostingUrls`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `true`  
**Environment variable**: `{PREFIX_}PREFERHOSTINGURLS`

To set this value, use the environment variable or call `PreferHostingUrls`:

```csharp
webBuilder.PreferHostingUrls(false);
```

### PreventHostingStartup

Prevents the automatic loading of hosting startup assemblies, including hosting startup assemblies configured by the app's assembly. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

**Key**: `preventHostingStartup`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}PREVENTHOSTINGSTARTUP`

To set this value, use the environment variable or call `UseSetting` :

```csharp
webBuilder.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true");
```

### StartupAssembly

The assembly to search for the `Startup` class.

**Key**: `startupAssembly`  
**Type**: `string`  
**Default**: The app's assembly  
**Environment variable**: `{PREFIX_}STARTUPASSEMBLY`

To set this value, use the environment variable or call `UseStartup`. `UseStartup` can take an assembly name (`string`) or a type (`TStartup`). If multiple `UseStartup` methods are called, the last one takes precedence.

```csharp
webBuilder.UseStartup("StartupAssemblyName");
```

```csharp
webBuilder.UseStartup<Startup>();
```

### SuppressStatusMessages

When enabled, suppresses hosting startup status messages.

**Key**: `suppressStatusMessages`  
**Type**: `bool` (`true`/`1` or `false`/`0`)  
**Default**: `false`  
**Environment variable**: `{PREFIX_}SUPPRESSSTATUSMESSAGES`

To set this value, use configuration or call `UseSetting`:

```csharp
webBuilder.UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "true");
```

### URLs

A semicolon-delimited list of IP addresses or host addresses with ports and protocols that the server should listen on for requests. For example, `http://localhost:123`. Use "\*" to indicate that the server should listen for requests on any IP address or hostname using the specified port and protocol (for example, `http://*:5000`). The protocol (`http://` or `https://`) must be included with each URL. Supported formats vary among servers.

**Key**: `urls`  
**Type**: `string`  
**Default**: `http://localhost:5000` and `https://localhost:5001`  
**Environment variable**: `{PREFIX_}URLS`

To set this value, use the environment variable or call `UseUrls`:

```csharp
webBuilder.UseUrls("http://*:5000;http://localhost:5001;https://hostname:5002");
```

Kestrel has its own endpoint configuration API. For more information, see <xref:fundamentals/servers/kestrel#endpoint-configuration>.

### WebRoot

The [IWebHostEnvironment.WebRootPath](xref:Microsoft.AspNetCore.Hosting.IWebHostEnvironment.WebRootPath) property determines the relative path to the app's static assets. If the path doesn't exist, a no-op file provider is used.  

**Key**: `webroot`  
**Type**: `string`  
**Default**: The default is `wwwroot`. The path to *{content root}/wwwroot* must exist.  
**Environment variable**: `{PREFIX_}WEBROOT`

To set this value, use the environment variable or call `UseWebRoot` on `IWebHostBuilder`:

```csharp
webBuilder.UseWebRoot("public");
```

For more information, see:

* [Fundamentals: Web root](xref:fundamentals/index#web-root)
* [ContentRoot](#contentroot)

## Manage the host lifetime

Call methods on the built <xref:Microsoft.Extensions.Hosting.IHost> implementation to start and stop the app. These methods affect all  <xref:Microsoft.Extensions.Hosting.IHostedService> implementations that are registered in the service container.

The difference between `Run*` and `Start*` methods is that `Run*` methods wait for the host to complete before returning, whereas `Start*` methods return immediately. The `Run*` methods are typically used in console apps, whereas the `Start*` methods are typically used in long-running services.

### Run

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Run%2A> runs the app and blocks the calling thread until the host is shut down.

### RunAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.RunAsync%2A> runs the app and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered.

### RunConsoleAsync

<xref:Microsoft.Extensions.Hosting.HostingHostBuilderExtensions.RunConsoleAsync%2A> enables console support, builds and starts the host, and waits for <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM to shut down.

### Start

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.Start%2A> starts the host synchronously.

### StartAsync

<xref:Microsoft.Extensions.Hosting.IHost.StartAsync%2A> starts the host and returns a <xref:System.Threading.Tasks.Task> that completes when the cancellation token or shutdown is triggered. 

<xref:Microsoft.Extensions.Hosting.IHostLifetime.WaitForStartAsync%2A> is called at the start of `StartAsync`, which waits until it's complete before continuing. This method can be used to delay startup until signaled by an external event.

### StopAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.StopAsync%2A> attempts to stop the host within the provided timeout.

### WaitForShutdown

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdown%2A> blocks the calling thread until shutdown is triggered by the IHostLifetime, such as via <kbd>Ctrl</kbd>+<kbd>C</kbd>/SIGINT (Windows), <kbd>⌘</kbd>+<kbd>C</kbd> (macOS), or SIGTERM.

### WaitForShutdownAsync

<xref:Microsoft.Extensions.Hosting.HostingAbstractionsHostExtensions.WaitForShutdownAsync%2A> returns a <xref:System.Threading.Tasks.Task> that completes when shutdown is triggered via the given token and calls <xref:Microsoft.Extensions.Hosting.IHost.StopAsync%2A>.

### External control

Direct control of the host lifetime can be achieved using methods that can be called externally:

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

## Additional resources

* <xref:fundamentals/host/hosted-services>
* GitHub link to [Generic Host source](https://github.com/dotnet/runtime/blob/main/src/libraries/Microsoft.Extensions.Hosting/src/Host.cs)
  [!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]
