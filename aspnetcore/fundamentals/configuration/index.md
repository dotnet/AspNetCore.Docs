---
title: Configuration in ASP.NET Core
author: tdykstra
description: Learn how to use the Configuration API to configure app settings in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 10/20/2025
uid: fundamentals/configuration/index
---
# Configuration in ASP.NET Core

<!-- DOC AUTHOR NOTE

includes/bind6.md and includes/bind7.md are being retained
at the moment for comparison for work on this article
on https://github.com/dotnet/AspNetCore.Docs/issues/36220.
Those two files will be deleted when working #36220.
The include/bind6.md file is being removed here in favor
of cross-linking the Options article, which is what IMO
should've been done in the first place.

Although the sample apps, which aren't Blazor-based, were
moved to the ASP.NET Core samples repo, I can't remove them
from the doc set until the Options article is also overhauled,
which will take place on another PR later.

-->

[!INCLUDE[](~/includes/not-latest-version.md)]

App configuration in ASP.NET Core is performed using one or more [configuration providers](#configuration-providers). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

* Settings files, such as `appsettings.json`
* Environment variables, including Azure App configuration
* Azure Key Vault
* Command-line arguments
* Custom providers, installed or created
* In-memory .NET objects

This article provides information on configuration in ASP.NET Core. For information on using configuration in non-ASP.NET Core apps, see [.NET Configuration](/dotnet/core/extensions/configuration).

For additional Blazor configuration guidance, which adds to or supersedes the guidance, see <xref:blazor/fundamentals/configuration>.

[!INCLUDE[](~/includes/managed-identities-conn-strings.md)]

> [!NOTE]
> Examples in this article use *primary constructors*, available in C# 12 (.NET 8) or later. For more information, see [Declare primary constructors for classes and structs (C# documentation tutorial)](/dotnet/csharp/whats-new/tutorials/primary-constructors) and [Primary constructors (C# Guide)](/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors).

## Read configuration values

Configuration is typically read by resolving the <xref:Microsoft.Extensions.Configuration.IConfiguration> service (<xref:Microsoft.Extensions.Configuration?displayProperty=fullName> namespace) and using the key of configuration key-value pairs to obtain a configuration value.

The following Razor component code shows how a configuration value, a technical contact email address, is obtained from configuration by the key `TechnicalContactEmail`.

```razor
@inject IConfiguration Config

Technical Contact: @Config["TechnicalContactEmail"]
```

## App and host configuration

ASP.NET Core apps configure and launch a *host*. The host is responsible for app startup and lifetime management. Host configuration key-value pairs are included in the app's configuration. Although you can perform some app configuration with host configuration providers, we only recommend performing configuration that's necessary for the host in host configuration.

App configuration is the highest priority. For more information on how the configuration providers are used when the host is built and how configuration sources affect host configuration, see <xref:fundamentals/index#host>.

## Default app configuration sources

:::moniker range=">= aspnetcore-6.0"

ASP.NET Core web apps call <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> to initialize a new instance of the <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> class with preconfigured defaults:

```csharp
var builder = WebApplication.CreateBuilder(args);
```

For more information, see <xref:fundamentals/host/generic-host#default-builder-settings>.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Apps created from an ASP.NET Core web app project template call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=nameWithType> to initialize a new instance of the <xref:Microsoft.Extensions.Hosting.HostBuilder> class with preconfigured defaults:

```csharp
Host.CreateDefaultBuilder(args)
```

:::moniker-end

Default app configuration is loaded in the following order, from highest to lowest priority:

1. Command-line arguments using the [Command-line Configuration Provider](#command-line).
1. Environment variables ***not*** prefixed by `ASPNETCORE_` or `DOTNET_` using the [Environment Variables Configuration Provider](#non-prefixed-environment-variables).
1. [User secrets](xref:security/app-secrets) when the app runs in the `Development` environment using the [File Configuration Provider](#file-configuration-provider).
1. [Environmental app settings file configuration](#app-settings-file-configuration-appsettingsjson-appsettingsenvironmentjson) via `appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's [environment](xref:fundamentals/environments), using the [JSON Configuration Provider](#json-configuration-provider). For example, `appsettings.Production.json` is used in production, and `appsettings.Development.json` is used during development.
1. [General app settings file configuration](#app-settings-file-configuration-appsettingsjson-appsettingsenvironmentjson) via `appsettings.json` using the [JSON Configuration Provider](#json-configuration-provider).
1. Fallback [host configuration](#default-host-configuration-sources).

:::moniker range=">= aspnetcore-6.0"

> [!NOTE]
> We don't recommend calling <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A> more than once solely for the purpose of obtaining configuration values at runtime. We recommend using a <xref:Microsoft.Extensions.Configuration.ConfigurationManager> (for example: `builder.Configuration`, <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Configuration%2A?displayProperty=nameWithType>) or using a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> from the appropriate configuration source.

:::moniker-end

To permit command-line arguments to control settings such as the environment name, which is important for determining which environment-based app settings file to load, the [Command-line Configuration Provider](#command-line) is used twice as a configuration source, at the start and end of configuration. Because the provider is used at the end, it has the highest priority.

When a configuration value is set in host and app configuration, the app configuration is used.

## Default host configuration sources

:::moniker range=">= aspnetcore-6.0"

Default host configuration sources from highest to lowest priority when applied to the web app's configuration (<xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder>):

1. Command-line arguments using the [Command-line Configuration Provider](#command-line).
1. `DOTNET_`-prefixed environment variables using the [Environment Variables Configuration Provider](xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider).
1. `ASPNETCORE_`-prefixed environment variables using the [Environment Variables Configuration Provider](xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider).

Default host configuration sources from highest to lowest priority applied to either the [Generic Host](xref:fundamentals/host/generic-host) or [Web Host](xref:fundamentals/host/web-host):

1. `ASPNETCORE_`-prefixed environment variables using the [Environment Variables Configuration Provider](xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider).
1.  Command-line arguments using the [Command-line Configuration Provider](#command-line).
1. `DOTNET_`-prefixed environment variables using the [Environment Variables Configuration Provider](xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider).

For more information on host configuration, see the following resources:

* [Generic Host](xref:fundamentals/host/generic-host): Recommended for ASP.NET Core apps targeting .NET 6 or later that adopt the [minimal hosting model](xref:migration/50-to-60#new-hosting-model).
* [Web Host](xref:fundamentals/host/web-host): Required for ASP.NET Core apps that target releases prior to .NET 6 and only maintained by the framework for backward compatibility in .NET 6 or later.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Default host configuration sources from highest to lowest priority for the [Web Host](xref:fundamentals/host/web-host):

* Host configuration
  * Environment variables prefixed with `DOTNET_` (for example, `DOTNET_ENVIRONMENT`) using the [Environment Variables Configuration Provider](xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider). The prefix (`DOTNET_`) is stripped when the configuration key-value pairs are loaded.
  * Command-line arguments using the [Command-line Configuration Provider](#command-line).
* Web Host default configuration (<xref:Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults%2A>)
  * Kestrel is used as the web server and configured using the app's configuration providers.
  * Add [Host Filtering Middleware](xref:fundamentals/servers/kestrel/host-filtering).
  * Add [Forwarded Headers Middleware](xref:host-and-deploy/proxy-load-balancer#forwarded-headers) if the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable is set to `true`.
  * Enable IIS integration.

:::moniker-end

## Host variables

The following variables are set early in host builder initialization and can't be influenced by app configuration:

* [Application name](xref:fundamentals/minimal-apis#change-the-content-root-application-name-and-environment).
* [Environment name](xref:fundamentals/environments).
* [Content root](xref:fundamentals/index#content-root).
* [Web root](xref:fundamentals/index#web-root).
* Whether to scan for [hosting startup assemblies](xref:fundamentals/configuration/platform-specific-configuration) and which assemblies to scan for.
* Variables read by app and library code from <xref:Microsoft.Extensions.Hosting.HostBuilderContext.Configuration%2A?displayProperty=nameWithType> in <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureAppConfiguration%2A?displayProperty=nameWithType> callbacks.

Other host settings are read from app configuration instead of host configuration.

`URLS` is one of the many common host settings that isn't bootstrapped by host configuration. `URLS` is read later from app configuration. Host configuration is a fallback for app configuration, so host configuration can be used to set `URLS`, but the value is overridden by any configuration source that sets `URLS` in app configuration, such as app settings files (`appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the environment name, or `appsettings.json`).

For more information, see [Change the content root, app name, and environment](xref:migration/50-to-60-samples#change-the-content-root-app-name-and-environment) and [Change the content root, app name, and environment by environment variables or command line](xref:migration/50-to-60-samples#change-the-content-root-app-name-and-environment-by-environment-variables-or-command-line).

## Security and user secrets

Configuration data guidelines:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. The [Secret Manager](xref:security/app-secrets) tool can be used to store secrets in development.
* Don't use production secrets in development or test environments.
* Specify secrets outside of the project so that they can't be accidentally committed to a source code repository.
* Production apps should use the most secure authentication flow available. For more information, see [Secure authentication flows](xref:security/index#secure-authentication-flows).

The User Secrets file configuration source of the [default configuration sources](#default-app-configuration-sources) is registered after the JSON configuration sources for app settings files. Therefore, user secrets keys take precedence over keys in `appsettings.json` and `appsettings.{ENVIRONMENT}.json`.

For more information on storing passwords or other sensitive data:

* <xref:fundamentals/environments>
* <xref:security/app-secrets>: Includes advice on using environment variables to store sensitive data. The Secret Manager tool uses the [File Configuration Provider](#file-configuration-provider) to store user secrets in a JSON file on the local system.
* [Azure Key Vault](https://azure.microsoft.com/services/key-vault/) safely stores app secrets for ASP.NET Core apps. For more information, see <xref:security/key-vault-configuration>.

## Access configuration with Dependency Injection (DI)

Configuration can be injected into services using [Dependency Injection (DI)](xref:fundamentals/dependency-injection) by resolving the <xref:Microsoft.Extensions.Configuration.IConfiguration> service. In the following example, the configuration value stored for the configuration key represented by the `{KEY}` placeholder is assigned to `value`. If the key isn't found, `null` is assigned to `value`:

```csharp
public class CustomService(IConfiguration config)
{
    public void CustomMethod()
    {
        var value = config["{KEY}"];
    }
}
```

## Access configuration in the `Program` file

The following code accesses configuration in the `Program` file using <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Configuration%2A?displayProperty=nameWithType> (`builder.Configuration`):

```csharp
var defaultConnectionString = 
   builder.Configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
```

After the app is built (after the line `var app = builder.Build();`), use <xref:Microsoft.AspNetCore.Builder.WebApplication.Configuration%2A?displayProperty=nameWithType> (`app.Configuration`):

```csharp
var defaultLogLevel = app.Configuration.GetValue<string>("Logging:LogLevel:Default");
```

## Access configuration in the `Startup` class

<!-- Dan, do you want to drop this section, or would
     you prefer that I version it out in 6.0 or later
     content?
-->

*This section generally applies to ASP.NET Core apps prior to the release of .NET 6.*

The following code displays configuration data in `Startup` methods:

```csharp
public class Startup
{
    public Startup(IConfiguration config)
    {
        Config = config;
    }

    public IConfiguration Config { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = Config["ConnectionStrings.DefaultConnection"]}");

        ...
    }

    public void Configure(...)
    {
        var defaultLogLevel = Config["Logging:LogLevel:Default"]}");

        ...
    }
}
```

## Display configuration settings on startup for debugging

The following code displays the app's configuration key-value pairs at app startup.

::: moniker range=">= aspnetcore-6.0"

After the app is built in the `Program` file (after the line `var app = builder.Build();`), place the following code, which includes a compiler directive for the DEBUG configuration:

```csharp
#if DEBUG
foreach (var c in app.Configuration.AsEnumerable())
{
    Console.WriteLine($"CONFIG: Key: {c.Key} Value: {c.Value}");
}
#endif
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

In the app's `Startup` class constructor, inject <xref:Microsoft.Extensions.Configuration.IConfiguration>, `config` in the following example, to write the configuration key-value pairs to the console. The following example includes a compiler directive for the DEBUG configuration:

```csharp
#if DEBUG
foreach (var c in config.AsEnumerable())
{
    Console.WriteLine($"CONFIG: Key: {c.Key} Value: {c.Value}");
}
#endif
```

::: moniker-end

## Configuration keys and values

Configuration keys:

* Are case-insensitive. For example, `ConnectionString` and `connectionstring` are treated as equivalent keys.
* If a key and value is set by more than one configuration provider, the value from the last provider added is used. For more information, see [Default configuration](#default-app-configuration-sources).
* Hierarchical keys
  * Within the Configuration API, a colon separator (`:`) works on all platforms.
  * In environment variables, a colon separator doesn't work on all platforms. A double underscore (`__`) is supported by all platforms and is automatically converted into a colon (`:`) when the configuration is read by the app.
  * In Azure Key Vault, hierarchical keys use double dashes (`--`) as a separator. The [Azure Key Vault Configuration Provider](xref:security/key-vault-configuration) automatically replaces the double dashes (`--`) with a colon (`:`) when the secrets are loaded into the app's configuration.
* The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> supports binding arrays to objects using array indices in configuration keys. Array binding is described in the [Bind an array](#bind-an-array) section.

Configuration values are strings. Null values can't be stored in configuration or bound to objects.

## How hierarchical configuration data is organized

The Configuration API reads hierarchical configuration data by flattening the hierarchical data with the use of a delimiter in the configuration keys, which are usually colons (`:`). Double underscores (`__`) are usually used with environment variable configuration for cross-platform support.

Consider the following hierarchical configuration data:

* :::no-loc text="ConnectionStrings":::
  * :::no-loc text="DefaultConnection (Value = ":::no-loc text="Data Source=LocalSqlServer\\MSSQLDev;":::")
* :::no-loc text="Logging":::
  * :::no-loc text="LogLevel":::
    * :::no-loc text="Default"::: (Value = :::no-loc text="Information":::)
    * :::no-loc text="Microsoft"::: (Value = :::no-loc text="Warning":::)
    * :::no-loc text="Microsoft.Hosting.Lifetime"::: (Value = :::no-loc text="Information":::)
* :::no-loc text="AllowedHosts"::: (Value = *)

The following table displays the keys used to recover the values in the preceding configuration data. The delimiter isn't required for :::no-loc text="AllowedHosts":::.

Key (colon delimiter) | Key (double-underscore delimiter)
--- | ---
ConnectionStrings:DefaultConnection | ConnectionStrings__DefaultConnection
Logging:LogLevel:Default | Logging__LogLevel__Default
Logging:LogLevel:Microsoft | Logging__LogLevel__Microsoft
Logging:LogLevel:Microsoft.Hosting.Lifetime | Logging__LogLevel__Microsoft.Hosting.Lifetime
AllowedHosts | AllowedHosts

> [!NOTE]
> In complex app configuration scenarios, we recommend grouping and reading related hierarchical configuration data using the [Options pattern](xref:fundamentals/configuration/options).

<xref:Microsoft.Extensions.Configuration.ConfigurationSection.GetSection%2A> and <xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren%2A> methods are available to isolate sections and children of a section in the configuration data. These methods are described in the [`GetSection`, `GetChildren`, and `Exists`](#getsection-getchildren-and-exists) section later in this article.

When the element structure includes an array, the array index should be treated as an additional element name in the path. Consider the following hierarchical configuration data as an array.

:::no-loc text="MainObject"::: (an array):

* First item in the array
  * :::no-loc text="Object0":::
  * :::no-loc text="Object1":::
    * :::no-loc text="SubObject0":::
    * :::no-loc text="SubObject1":::
* Second item in the array
  * :::no-loc text="Object0":::
  * :::no-loc text="Object1":::
    * :::no-loc text="SubObject0":::
    * :::no-loc text="SubObject1":::

Keys with colon separators:

* :::no-loc text="MainObject:0:Object0":::
* :::no-loc text="MainObject:0:Object1:SubObject0":::
* :::no-loc text="MainObject:0:Object1:SubObject1":::
* :::no-loc text="MainObject:1:Object0":::
* :::no-loc text="MainObject:1:Object1:SubObject0":::
* :::no-loc text="MainObject:1:Object1:SubObject1":::

Keys with underscore separators, which is recommended for cross-platform compatibility when configuration is provided by environment variables:

* :::no-loc text="MainObject__0__Object0":::
* :::no-loc text="MainObject__0__Object1:SubObject0":::
* :::no-loc text="MainObject__0__Object1:SubObject1":::
* :::no-loc text="MainObject__1__Object0":::
* :::no-loc text="MainObject__1__Object1:SubObject0":::
* :::no-loc text="MainObject__1__Object1:SubObject1":::

## Configuration providers

The following table shows the configuration providers available to ASP.NET Core apps.

Provider | Provides configuration from&hellip;
--- | ---
[Azure Key Vault Configuration Provider](xref:security/key-vault-configuration) | Azure Key Vault
[Azure App Configuration Provider](/azure/azure-app-configuration/quickstart-aspnet-core-app) | Azure App Configuration
[Command-line Configuration Provider](#command-line) | Command-line parameters
[Custom configuration provider](#custom-configuration-provider) | Custom source
[Environment Variables Configuration Provider](#environment-variables-configuration-provider) | Environment variables
[File Configuration Provider](#file-configuration-provider) | INI, JSON, and XML files
[Key-per-file Configuration Provider](#key-per-file-configuration-provider) | Directory files
[Memory Configuration Provider](#memory-configuration-provider) | In-memory collections
[User secrets](xref:security/app-secrets) | File in the user profile directory

Configuration sources are read in the order that their configuration providers are specified. Order configuration providers in code to suit the priorities for the underlying configuration sources that the app requires.

A typical sequence of configuration providers is:

1. General app settings via `appsettings.json`.
1. Environmental app settings via `appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's environment (examples: `Development`, `Production`).
1. [User secrets](xref:security/app-secrets).
1. Environment variables using the [Environment Variables Configuration Provider](#non-prefixed-environment-variables).
1. Command-line arguments using the [Command-line Configuration Provider](#command-line).

A common practice is to add the Command-line Configuration Provider last in a series of providers to allow command-line arguments to override configuration set by the other providers.

The preceding sequence of providers is used in the [default configuration](#default-app-configuration-sources).

To inspect the app's configuration providers, [inject](xref:fundamentals/dependency-injection) <xref:Microsoft.Extensions.Configuration.IConfiguration>, cast it to <xref:Microsoft.Extensions.Configuration.IConfigurationRoot>, and read the <xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Providers%2A> property.

In the following `ConfigurationProviders` Razor component displays the enabled configuration providers in the order that they're added to the app.

`Pages/ConfigurationProviders.razor`:

```razor
@page "/configuration-providers"
@inject IConfiguration Config

<h1>Configuration Providers</h1>

@if (ConfigRoot is not null)
{
    <ul>
        @foreach (var provider in ConfigRoot.Providers)
        {
            <li>@provider</li>
        }
    </ul>
}

@code {
    private IConfigurationRoot? ConfigRoot;

    protected override void OnInitialized()
    {
        ConfigRoot = (IConfigurationRoot)Config;
    }
}
```

The preceding Razor component produces the following output, where the `{APP NAMESPACE}` placeholder is the app's namespace:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="MemoryConfigurationProvider":::  
> :::no-loc text="EnvironmentVariablesConfigurationProvider Prefix: 'ASPNETCORE_'":::  
> :::no-loc text="MemoryConfigurationProvider":::  
> :::no-loc text="EnvironmentVariablesConfigurationProvider Prefix: 'DOTNET_'":::  
> :::no-loc text="JsonConfigurationProvider for 'appsettings.json' (Optional)":::  
> :::no-loc text="JsonConfigurationProvider for 'appsettings.Development.json' (Optional)":::  
> :::no-loc text="JsonConfigurationProvider for '{APP NAMESPACE}.settings.json' (Optional)":::  
> :::no-loc text="JsonConfigurationProvider for '{APP NAMESPACE}.settings.Development.json' (Optional)":::  
> :::no-loc text="EnvironmentVariablesConfigurationProvider":::  
> :::no-loc text="Microsoft.Extensions.Configuration.ChainedConfigurationProvider":::

In the [Default app configuration sources](#default-app-configuration-sources) section earlier in this article, configuration sources are listed from highest to lowest priority. The preceding `ConfigurationProviders` component displays the sources *in the order that the app reads them*. For example, the [JSON Configuration Provider](#json-configuration-provider) for the non-environmental app settings file (`appsettings.json`) is earlier in the preceding list because it's added before the provider for the Development environment app settings file (`appsettings.Development.json`). The configuration providers are executed from the top of the list to the bottom of the list. For a matching configuration key between the two app settings JSON Configuration Providers, the last setting takes precedence, which is the value from `appsettings.Development.json`.

## App settings file configuration (`appsettings.json`, `appsettings.{ENVIRONMENT}.json`)

Read configuration loaded from app settings files using the [JSON Configuration Provider](#json-configuration-provider).

Consider the following `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=LocalSqlServer\\MSSQLDev;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

[Inject](xref:fundamentals/dependency-injection) an instance of <xref:Microsoft.Extensions.Configuration.IConfiguration> to read configuration values.

The following `AppSettingsConfiguration` Razor component reads the default database connection string and default logging level configuration. <xref:Microsoft.Extensions.Configuration.IConfiguration> is injected at the top of the component and used to read configuration values. A colon (`:`) separator is used in string-typed configuration keys to locate the appropriate JSON properties. For example, the JSON structure for the default connection string (`DefaultConnection`) object is nested under the connection strings (`ConnectionStrings`) object, so the string notation to access the default connection string uses a colon to separate `DefaultConnection` and `ConnectionStrings` in the order that the objects appear in the app settings file: `ConnectionStrings:DefaultConnection`.

`Pages/AppSettingsConfiguration.razor`:

```razor
@page "/app-settings-configuration"
@inject IConfiguration Config

<h1>App Settings Configuration</h1>

<ul>
    <li>Default Connection String: @Config["ConnectionStrings:DefaultConnection"]
    <li>Default Log Level: @Config["Logging:LogLevel:Default"]
</ul>
```

The same approach is taken in a Razor Pages page model:

```cshtml
using Microsoft.Extensions.Configuration;

...

public class AppSettingsPageModel(IConfiguration config) : PageModel
{
    public ContentResult OnGet()
    {
        var defaultConnectionString = config["ConnectionStrings:DefaultConnection"];
        var defaultLogLevel = config["Logging:LogLevel:Default"];

        return Content(
            $"Default Connection String: {defaultConnectionString}\n" +
            $"Default Log Level: {defaultLogLevel}");
    }
}
```

When the JSON object structure includes an array, the array index should be treated as an additional element name in the path.

`appsettings.json`:

```json
{
  "MainObject": [
    {
      "Object1": "...",
      "Object2": {
        "SubObject1": "...",
        "SubObject2": "..."
      }
    },
    {
      "Object1": "...",
      "Object2": {
        "SubObject1": "...",
        "SubObject2": "..."
      }
    }
  ]
}
```

To display the values in a Razor component:

```razor
@if (Config is not null)
{
    <ul>
        <li>@Config["MainObject:0:Object1"]</li>
        <li>@Config["MainObject:0:Object2:SubObject1"]</li>
        <li>@Config["MainObject:0:Object2:SubObject2"]</li>
        <li>@Config["MainObject:1:Object1"]</li>
        <li>@Config["MainObject:1:Object2:SubObject1"]</li>
        <li>@Config["MainObject:1:Object2:SubObject2"]</li>
    </ul>
}
```

The default <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> instances load configuration in the following order:

1. `appsettings.json`
1. `appsettings.{ENVIRONMENT}.json`, where the `{ENVIRONMENT}` placeholder is the app's [environment](xref:fundamentals/environments) (examples: `appsettings.Production.json`, `appsettings.Development.json`). The environment version of the file is loaded based on the <xref:Microsoft.Extensions.Hosting.IHostingEnvironment.EnvironmentName%2A?displayProperty=nameWithType>.

`appsettings.{ENVIRONMENT}.json` values override keys in `appsettings.json`.

By default:

* In the Development environment, `appsettings.Development.json` configuration overwrites values found in `appsettings.json`.
* In the Production environment, `appsettings.Production.json` configuration overwrites values found in `appsettings.json`.

The preceding example only reads strings and doesn't support a default value. If a configuration value must be guaranteed with a default value, see the [Extract a single value from configuration with type conversion (`GetValue`)](#extract-a-single-value-from-configuration-with-type-conversion-getvalue) section.

Using the [default app configuration sources](#default-app-configuration-sources), the `appsettings.json` and `appsettings.{ENVIRONMENT}.json` files are enabled with [`reloadOnChange` set to `true`](#json-configuration-provider), which means that changes made to either the `appsettings.json` or `appsettings.{ENVIRONMENT}.json` files after the app starts take effect immediately after the file is saved.

Comments in `appsettings.json` and `appsettings.{ENVIRONMENT}.json` files are supported using JavaScript or [C# style comments](/dotnet/csharp/language-reference/tokens/comments). Some integrated development environments (IDEs) display errors when editing a JSON file that contains comments because the [official JSON specification (RFC 7159)](https://datatracker.ietf.org/doc/html/rfc7159) makes no allowance for comments in JSON files. You can generally ignore comment errors and warnings, but you can also usually disable warnings or errors with a setting in the IDE. In Visual Studio Code, for example, add the following to the `settings.json` file to disable the errors:

```json
"files.associations": {
  "appsettings*.json": "jsonc"
}
```

The preceding setting indicates to VS Code that app settings files, including environmental-based files, are associated with the [JSONC ("JSON with Comments") file format](https://jsonc.org/), which supports comments.

For other IDEs, check the IDE's documentation and product support channels to determine how to silence errors or warnings about comments in JSON files.

## Bind hierarchical configuration data using the options pattern

In complex app configuration scenarios, it's best to group and read related hierarchical configuration data using the [options pattern](xref:fundamentals/configuration/options).

## Environment Variables Configuration Provider

The [default Environment Variables Configuration Provider](#default-app-configuration-sources) (<xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider>) loads configuration from environment variables that aren't prefixed with `ASPNETCORE_` or `DOTNET_`. For more information on `ASPNETCORE_` and `DOTNET_` environment variables, see the [Default host configuration sources](#default-host-configuration-sources) section and [`DOTNET_` environment variables (.NET Core documentation)](/dotnet/core/tools/dotnet-environment-variables).

Using the default Environment Variables Configuration Provider, the app loads configuration from environment variable key-value pairs after reading `appsettings.json`, `appsettings.{ENVIRONMENT}.json`, and [user secrets](xref:security/app-secrets). Therefore, key values read from the environment override values read from `appsettings.json`, `appsettings.{ENVIRONMENT}.json`, and user secrets.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

For guidance on setting environment variables in a command shell on Windows or in a cross-platform PowerShell command shell, see the following resources:

* [set (environment variable)](/windows-server/administration/windows-commands/set_1)
* [setx](/windows-server/administration/windows-commands/setx)
* [about_Environment_Variables (PowerShell documentation)](/powershell/module/microsoft.powershell.core/about/about_environment_variables)

### Custom prefix for environment variables

::: moniker range=">= aspnetcore-6.0"

You can add a configuration provider for custom-prefixed environment variables. In the `Program` file, call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables%2A> with a string to specify a prefix after <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> is called. The provider is added after the [default configuration providers](#default-app-configuration-sources), thus the added provider has a higher priority, including over environment variables of the same name without the prefix.

In the following example, environment variables are added with the `CustomPrefix_` prefix:

```csharp
builder.Configuration.AddEnvironmentVariables(prefix: "CustomPrefix_");
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

You can add a configuration provider for custom-prefixed environment variables. In the `Program` file, call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables%2A> with a string to specify a prefix on the <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> of <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureAppConfiguration%2A>. The provider is added after the [default configuration providers](#default-app-configuration-sources), thus the added provider has a higher priority, including over environment variables of the same name without the prefix.

In the following example, environment variables are added with the `CustomPrefix_` prefix:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        })
    .ConfigureAppConfiguration(config =>
    { 
        config.AddEnvironmentVariables("CustomPrefix_");
    });
```

::: moniker-end

The prefix is stripped off when the configuration key-value pairs are read.

### Launch settings override environment variable settings

Environment variables set in `launchSettings.json` override those set in the system environment. For example, the ASP.NET Core web templates generate a `launchSettings.json` file that sets the endpoint configuration to:

```json
"applicationUrl": "https://localhost:5001;http://localhost:5000"
```

Configuring the `applicationUrl` sets the `ASPNETCORE_URLS` environment variable and overrides values set in the environment.

### Escape environment variables on Linux

On Linux, the value of URL environment variables must be escaped so `systemd` can parse it. In the following example, the Linux tool `systemd-escape` is used to yield `http:--localhost:5001` from `http://localhost:5001`:
 
```console
groot@terminus:~$ systemd-escape http://localhost:5001
http:--localhost:5001
```

### Azure App Service app settings (environment variables)

For [Azure App Service](https://azure.microsoft.com/services/app-service/) app settings (environment variable) guidance, see the following resources:

* [Configure an App Service app (Azure documentation)](/azure/app-service/configure-common)
* [Azure database connection string prefixes](#connection-string-prefixes)

### Connection string prefixes

The Configuration API has special processing rules for four connection string environment variables. These connection strings are involved in configuring Azure connection strings for the app environment. Environment variables with the prefixes shown in the following table are loaded into the app with the [default configuration](#default-app-configuration-sources) or when no prefix is supplied to <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables%2A>.

Connection string prefix | Provider
--- | ---
`CUSTOMCONNSTR_` | Custom provider
`MYSQLCONNSTR_` | [MySQL](https://www.mysql.com/)
`SQLAZURECONNSTR_` | [Azure SQL Database](https://azure.microsoft.com/services/sql-database/)
`SQLCONNSTR_` | [SQL Server](https://www.microsoft.com/sql-server/)

When an environment variable is discovered and loaded into configuration with any of the four prefixes shown in the preceding table:

* The configuration key is created by removing the environment variable prefix and adding a configuration key section (`ConnectionStrings`).
* A new configuration key-value pair is created that represents the database connection provider, except for `CUSTOMCONNSTR_`, which has no stated provider.

Environment variable key | Converted configuration key | Provider configuration entry
 --- | --- | ---
`CUSTOMCONNSTR_{KEY}` | `ConnectionStrings:{KEY}` | Configuration entry not created.
`MYSQLCONNSTR_{KEY}` | `ConnectionStrings:{KEY}` | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `MySql.Data.MySqlClient`
`SQLAZURECONNSTR_{KEY}` | `ConnectionStrings:{KEY}` | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`
`SQLCONNSTR_{KEY}` | `ConnectionStrings:{KEY}` | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`

## Command-line

Using the [default configuration sources](#default-app-configuration-sources), the <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs after the following configuration sources:

* `appsettings.json` and `appsettings.{ENVIRONMENT}.json` files.
* [App secrets](xref:security/app-secrets) in the Development environment.
* Environment variables.

By default, configuration values set on the command-line override configuration values set by all of the other configuration providers.

### Command-line arguments

The following [`dotnet run`](/dotnet/core/tools/dotnet-run) command sets keys and values using equals signs (`=`):

```dotnetcli
dotnet run ConnectionStrings:DefaultConnection="Data Source=LocalSqlServer\\MSSQLDev;" Logging:LogLevel:Default=Information
```

The following command sets keys and values using forward slashes (`/`):

```dotnetcli
dotnet run /ConnectionStrings:DefaultConnection "Data Source=LocalSqlServer\\MSSQLDev;" /Logging:LogLevel:Default Information
```

The following command sets keys and values using double dashes (`--`):

```dotnetcli
dotnet run --ConnectionStrings:DefaultConnection "Data Source=LocalSqlServer\\MSSQLDev;" --Logging:LogLevel:Default Information
```

Argument conventions:

* The key value must follow the equals sign (`=`), or the key must have a prefix of a double dash (`--`) or forward slash (`/`) when the value follows a space.
* Not assigning a value after an equals sign (`=`) results in assigning an empty string for the configuration setting. For example, specifying `ConnectionStrings:DefaultConnection=` is valid and results in assigning an empty string to the default connection string.
* Within the same command, don't mix argument key-value pairs separated by an equals sign (`=`) with key-value pairs separated by a space.

### Switch mappings

Switch mappings allow *key* name replacement logic via a dictionary of switch replacements passed to the <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> method.

When the switch mappings dictionary is used, the dictionary is checked for a key that matches the key provided by a command-line argument. If the command-line key is found in the dictionary, the dictionary value is passed back to set the key-value pair into the app's configuration. A switch mapping is required for any command-line key prefixed with a single dash (`-`).

Switch mappings dictionary key rules:

* Switches must start with a single dash (`-`) or double dash (`--`).
* The switch mappings dictionary must not contain duplicate keys.

In the following example, a switch mapping dictionary (`switchMappings`) is passed to <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> in the app's `Program` file:

::: moniker range=">= aspnetcore-6.0"

```csharp
var switchMappings = 
    new Dictionary<string, string>(){ { "-k1", "key1" }, { "-k2", "key2" } };

builder.Configuration.AddCommandLine(args, switchMappings);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
.ConfigureAppConfiguration(config =>
{ 
    var switchMappings =
        new Dictionary<string, string>() { { "-k1", "key1" }, { "-k2", "key2" } };

    config.AddCommandLine(args, switchMappings);
});
```

::: moniker-end

The following [`dotnet run`](/dotnet/core/tools/dotnet-run) commands demonstrate key replacement (`value1` into `key1` and `value2` into `key2`):

* `dotnet run -k1 value1 -k2 value2`
* `dotnet run --k1=value1 --k2=value2`
* `dotnet run --k1 value1 --k2 value2`
* `dotnet run /k1=value1 /k2=value2`
* `dotnet run /k1 value1 /k2 value2`

::: moniker range=">= aspnetcore-6.0"

For apps that use switch mappings, the call to <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> shouldn't pass arguments. The <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> method's <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> call doesn't include mapped switches, and there's no way to pass the switch-mapping dictionary to <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>. The solution isn't to pass the arguments to <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A> but instead to allow the <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> method's <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> method to process both the arguments and the switch-mapping dictionary.

::: moniker-end

::: moniker range="< aspnetcore-6.0"

For apps that use switch mappings, the call to <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> shouldn't pass arguments. The <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> method's <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> call doesn't include mapped switches, and there's no way to pass the switch-mapping dictionary to <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>. The solution isn't to pass the arguments to <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A> but instead to allow the <xref:Microsoft.Extensions.Configuration.IConfigurationBuilder> method's <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine%2A> method to process both the arguments and the switch-mapping dictionary.

::: moniker-end

## Set environment and command-line arguments with Visual Studio

Environment and command-line arguments can be set in Visual Studio from the launch profiles dialog:

* In Solution Explorer, right click the project and select **Properties**.
* Select the **Debug > General** tab and select **Open debug launch profiles UI**.

## File Configuration Provider

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> is the base class for loading configuration from the file system. The following configuration providers derive from `FileConfigurationProvider`:

* [INI Configuration Provider](#ini-configuration-provider)
* [JSON Configuration Provider](#json-configuration-provider)
* [XML Configuration Provider](#xml-configuration-provider)

### INI Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> loads configuration from INI file key-value pairs. The following example demonstrates how to use the provider. Overloads can specify whether the file is optional and if the configuration is reloaded on file changes.

`IniConfig.ini`:

```ini
[ConnectionStrings]
DefaultConnection="Data Source=LocalSqlServer\\MSSQLDev;"

[Logging:LogLevel]
Default=Debug
Microsoft=Debug
```

`IniConfig.Production.ini`:

```ini
[ConnectionStrings]
DefaultConnection="Data Source=LocalSqlServer\\MSSQLProd;"

[Logging:LogLevel]
Default=Information
Microsoft=Warning
```

Load the configuration by calling <xref:Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile%2A>. The following example creates a configuration source for each of the preceding files. The non-environmental file reloads configuration if the file is changed (`reloadOnChange` parameter, default: `false`). The environmental version of the file specifies that the file is optional (`optional` parameter, default: `false`). If you want to specify reloading the file on change (`reloadOnChange: true`), then you must also specify whether or not the file is optional (`optional`).

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Configuration
    .AddIniFile("IniConfig.ini", optional: false, reloadOnChange: true);
    .AddIniFile($"IniConfig.{builder.Environment.EnvironmentName}.ini", optional: true);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
.ConfigureAppConfiguration(config =>
{ 
    config
        .AddIniFile("IniConfig.ini", optional:false, reloadOnChange: true)
        .AddIniFile("IniConfig.Production.ini", optional: true);
});
```

::: moniker-end

### JSON Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration from JSON file key-value pairs. The following example demonstrates how to use the provider. Overloads can specify whether the file is optional and if the configuration is reloaded on file changes.

Call <xref:Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile%2A> with the file path (or file name if the file is at the root of the app). The following makes the file optional (`optional` parameter, default: `false`) and specifies that the configuration is reloaded if the file is changed (`reloadOnChange` parameter, default: `false`). If you want to specify reloading the file on change (`reloadOnChange: true`), then you must also specify whether or not the file is optional (`optional`).

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Configuration.AddJsonFile("config.json", optional: true, reloadOnChange: true);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
.ConfigureAppConfiguration(config =>
{ 
    config.AddJsonFile("config.json", optional: true, reloadOnChange: true);
});
```

::: moniker-end

### XML Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> loads configuration from XML file key-value pairs. The following example demonstrates how to use the provider. Overloads can specify whether the file is optional and if the configuration is reloaded on file changes.

`XmlFile.xml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <ConnectionStrings>
    <DefaultConnection>Data Source=LocalSqlServer\\MSSQLDev;</DefaultConnectionString>
  </ConnectionStrings>
  <Logging>
    <LogLevel>
      <Default>Debug</Default>
      <Microsoft>Debug</Microsoft>
    </LogLevel>
  </Logging>
</configuration>
```

`XmlFile.Production.xml`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <ConnectionStrings>
    <DefaultConnectionString>Data Source=LocalSqlServer\\MSSQLProd;</DefaultConnectionString>
  </ConnectionStrings>
  <Logging>
    <LogLevel>
      <Default>Information</Default>
      <Microsoft>Warning</Microsoft>
    </LogLevel>
  </Logging>
</configuration>
```

Load the configuration by calling <xref:Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile%2A>. The following example creates a configuration source for each of the preceding files. The non-environmental file reloads configuration if the file is changed (`reloadOnChange` parameter, default: `false`). The environmental version of the file specifies that the file is optional (`optional` parameter, default: `false`). If you want to specify reloading the file on change (`reloadOnChange: true`), then you must also specify whether or not the file is optional (`optional`).

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Configuration
    .AddXmlFile("XmlFile.xml", optional: false, reloadOnChange: true);
    .AddXmlFile($"XmlFile.{builder.Environment.EnvironmentName}.xml", optional: true);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
.ConfigureAppConfiguration(config =>
{ 
    config
        .AddXmlFile("XmlFile.xml", optional:false, reloadOnChange: true)
        .AddXmlFile("XmlFile.Production.xml", optional: true);
});
```

::: moniker-end

Repeating elements that use the same element name work if the `name` attribute is used to distinguish the elements:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <section name="section0">
    <key name="key0">value 00</key>
    <key name="key1">value 01</key>
  </section>
  <section name="section1">
    <key name="key0">value 10</key>
    <key name="key1">value 11</key>
  </section>
</configuration>
```

```csharp
var value_00 = Config["section:section0:key:key0"];
var value_01 = Config["section:section0:key:key1"];
var value_10 = Config["section:section1:key:key0"];
var value_11 = Config["section:section1:key:key1"];
```

Attributes that supply values are supported:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <key attribute="value" />
  <section>
    <key attribute="value" />
  </section>
</configuration>
```

The previous configuration loads the following keys with `value`:

* `key:attribute`
* `section:key:attribute`

## Key-per-file Configuration Provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value contains the file's contents. The Key-per-file Configuration Provider is used in Docker hosting scenarios.

To activate key-per-file configuration, call the <xref:Microsoft.Extensions.Configuration.KeyPerFileConfigurationBuilderExtensions.AddKeyPerFile%2A> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>. The `directoryPath` to the files must be an absolute path.

Overloads permit specifying:

* An `Action<KeyPerFileConfigurationSource>` delegate that configures the source.
* Whether the directory is optional and the path to the directory.

The double-underscore (`__`) is used as a configuration key delimiter in file names. For example, the file name `Logging__LogLevel__System` produces the configuration key `Logging:LogLevel:System`.

::: moniker range=">= aspnetcore-6.0"

```csharp
var path = Path.Combine(Directory.GetCurrentDirectory(), "path/to/files");
builder.Configuration.AddKeyPerFile(directoryPath: path, optional: true);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    var path = Path.Combine(
        Directory.GetCurrentDirectory(), "path/to/files");
    config.AddKeyPerFile(directoryPath: path, optional: true);
})
```

::: moniker-end

## Memory Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

The following code adds a memory collection to the configuration system:

::: moniker range=">= aspnetcore-6.0"

```csharp
var configSettings = new Dictionary<string, string>
{
    { "ConnectionStrings:DefaultConnection", "Data Source=LocalSqlServer\\MSSQLDev;" },
    { "Logging:LogLevel:Default", "Information" }
};

builder.Configuration.AddInMemoryCollection(configSettings);
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>();
    })
    .ConfigureAppConfiguration(config =>
    { 
        var configSettings = new Dictionary<string, string>
        {
            { "ConnectionStrings:DefaultConnection", "Data Source=LocalSqlServer\\MSSQLDev;" },
            { "Logging:LogLevel:Default", "Information" }
        };

        config.AddInMemoryCollection(configSettings);
    });
```

::: moniker-end

For an additional example that uses a <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider>, see the [Bind an array](#bind-an-array) section.

## Kestrel endpoint configuration

Kestrel-specific endpoint configuration overrides all [cross-server](xref:fundamentals/servers/index) endpoint configurations. Cross-server endpoint configurations include:

* [`UseUrls`](xref:fundamentals/host/web-host#server-urls).
* `--urls` on the [command line](xref:fundamentals/configuration/index#command-line).
* The `ASPNETCORE_URLS` [environment variable](xref:fundamentals/configuration/index#environment-variables).

Consider the following Kestrel configuration section in an `appsettings.json` file:

```json
"Kestrel": {
  "Endpoints": {
    "Https": {
      "Url": "https://localhost:9999"
    }
  }
},
```

The app is launched on the command line with [`dotnet run`](/dotnet/core/tools/dotnet-run) and the following cross-server endpoint configuration:

```dotnetcli
dotnet run --urls="https://localhost:7777"
```

Kestrel binds to the endpoint configured specifically for Kestrel in the `appsettings.json` file (`https://localhost:9999`) and not the cross-server endpoint configuration passed to the `dotnet run` command (`https://localhost:7777`).

However, consider the Kestrel-specific endpoint configured as an environment variable:

* Key: `Kestrel__Endpoints__Https__Url`
* Value: `https://localhost:8888`

In the preceding environment variable, "`Https`" is the name of the Kestrel-specific endpoint. The preceding app settings configuration also defines a Kestrel-specific endpoint named `Https`. Per the [default host configuration providers](#default-host-configuration), environment variables read by the [Environment Variables Configuration Provider](#non-prefixed-environment-variables) are read after `appsettings.{ENVIRONMENT}.json`. Therefore, the preceding environment variable (`Kestrel__Endpoints__Https__Url`) is used for the `Https` endpoint.

## Extract a single value from configuration with type conversion (`GetValue`)

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue%2A?displayProperty=nameWithType> extracts a single value from configuration with a specified key and converts it to the specified type:

```csharp
var number = Config.GetValue<int>("NumberKey", 99);
```

In the preceding code:

* `Config` is an injected <xref:Microsoft.Extensions.Configuration.IConfiguration>.
* If `NumberKey` isn't found in the configuration, the default value of `99` is used.

## Work with sections and child  (`GetSection`), get a section's children (`GetChildren`), and determine if a section exists (`Exists`)

For the examples that follow, consider the following `subsection.json` file:

```json
{
  "section0": {
    "key0": "value00",
    "key1": "value01"
  },
  "section1": {
    "key0": "value10",
    "key1": "value11"
  },
  "section2": {
    "subsection0": {
      "key0": "value200",
      "key1": "value201"
    },
    "subsection1": {
      "key0": "value210",
      "key1": "value211"
    }
  }
}
```

A configuration provider is added for `subsection.json` by calling [`AddJsonFile`](#json-configuration-provider).

### `GetSection`

<xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A?displayProperty=nameWithType> returns a configuration subsection with the specified subsection key.

The following code returns values for `section1`, where `Config` is an injected <xref:Microsoft.Extensions.Configuration.IConfiguration>:

```csharp
var subsection = Config.GetSection("section1");
var value1 = subsection["key0"];
var value2 = subsection["key1"];
```

The following code returns values for `section2:subsection0`, where `Config` is an injected <xref:Microsoft.Extensions.Configuration.IConfiguration>:

```csharp
var subsection = Config.GetSection("section2:subsection0");
var value1 = subsection["key0"];
var value2 = subsection["key1"];
```

<xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A> never returns `null`. If a matching section isn't found, an empty <xref:Microsoft.Extensions.Configuration.IConfigurationSection> is returned.

When <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A> returns a matching section, <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Value> isn't populated. A <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Key> and <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Path> are returned when the section exists.

### `GetChildren` and `Exists`

The following code calls:

* <xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.Exists%2A?displayProperty=nameWithType> to verify that `section2` exists.
* <xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren%2A?displayProperty=nameWithType> and returns values for the subsections of `section2`.

```csharp
var section = Config.GetSection("section2");

if (!section.Exists())
{
    throw new Exception("section2 doesn't exist!");
}

var children = section.GetChildren();

foreach (var subSection in children)
{
    int i = 0;
    var key1 = subSection.Key + ":key" + i++.ToString();
    var key2 = subSection.Key + ":key" + i.ToString();
    Console.WriteLine($"{key1} value: {section[key1]}");
    Console.WriteLine($"{key2} value: {section[key2]}");
}
```

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> no-loc text="subsection0:key0 value: value200":::  
> no-loc text="subsection0:key1 value: value201":::  
> no-loc text="subsection1:key0 value: value210":::  
> no-loc text="subsection1:key1 value: value211":::

## Bind an array

The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A?displayProperty=nameWithType> supports binding arrays to objects using array indices in configuration keys. Any array format that exposes a numeric key segment is capable of array binding to a [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) class array.

`array.json`:

```json
{
  "array": {
    "entries": {
      "0": "value00",
      "1": "value10",
      "2": "value20",
      "4": "value40",
      "5": "value50"
    }
  }
}
```

A configuration provider is added for `array.json` by calling [`AddJsonFile`](#json-configuration-provider).

The following code reads the configuration values:

`ArrayExample.cs`:

```csharp
public class ArrayExample
{
    public string[]? Entries { get; set; } 
}
```

```csharp
var array = Config.GetSection("array").Get<ArrayExample>();

if (array is null)
{
    throw new ArgumentNullException(nameof(array));
}

string output = String.Empty;

for (int j = 0; j < array.Entries?.Length; j++)
{
    Console.WriteLine($"Index: {j} Value: {array.Entries[j]}");
}
```

Output:

```console
Index: 0 Value: value00
Index: 1 Value: value10
Index: 2 Value: value20
Index: 3 Value: value40
Index: 4 Value: value50
```

In the preceding output, Index 3 has value `value40`, corresponding to `"4": "value40",` in `array.json`. The bound array indices are continuous and not bound to the configuration key index. The configuration binder isn't capable of binding `null` values or creating `null` entries in bound objects.

:::moniker range="< aspnetcore-6.0"

<!-- Dan, IDK why the following array binding coverage
     was dropped out at 6.0. Let me know if you want me 
     to see if I can find out. However, I wonder if we 
     should even bother keeping this coverage at all. 
     Do you want to keep it? If so, I'll edit it on a 
     future commit here. I'm just going to skip it for
     now on the chance that you tell me to give it the
     axe.
-->

The  following code loads the `array:entries` configuration with the <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection%2A> extension method:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var arrayDict = new Dictionary<string, string>
        {
            {"array:entries:0", "value0"},
            {"array:entries:1", "value1"},
            {"array:entries:2", "value2"},
            //              3   Skipped
            {"array:entries:4", "value4"},
            {"array:entries:5", "value5"}
        };

        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddInMemoryCollection(arrayDict);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
```

The following code reads the configuration in the `arrayDict` `Dictionary` and displays the values:

```csharp
public class ArrayModel : PageModel
{
    private readonly IConfiguration Config;
    public ArrayExample _array { get; private set; }

    public ArrayModel(IConfiguration config)
    {
        Config = config;
    }

    public ContentResult OnGet()
    {
        _array = Config.GetSection("array").Get<ArrayExample>();
        string s = null;

        for (int j = 0; j < _array.Entries.Length; j++)
        {
            s += $"Index: {j}  Value:  {_array.Entries[j]} \n";
        }

        return Content(s);
    }
}
```

The preceding code returns the following output:

```text
Index: 0  Value: value0
Index: 1  Value: value1
Index: 2  Value: value2
Index: 3  Value: value4
Index: 4  Value: value5
```

Index &num;3 in the bound object holds the configuration data for the `array:4` configuration key and its value of `value4`. When configuration data containing an array is bound, the array indices in the configuration keys are used to iterate the configuration data when creating the object. A null value can't be retained in configuration data, and a null-valued entry isn't created in a bound object when an array in configuration keys skip one or more indices.

The missing configuration item for index &num;3 can be supplied before binding to the `ArrayExample` instance by any configuration provider that reads the index &num;3 key/value pair. Consider the following `Value3.json` file from the sample download:

```json
{
  "array:entries:3": "value3"
}
```

The following code includes configuration for `Value3.json` and the `arrayDict` `Dictionary`:

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var arrayDict = new Dictionary<string, string>
        {
            {"array:entries:0", "value0"},
            {"array:entries:1", "value1"},
            {"array:entries:2", "value2"},
            //              3   Skipped
            {"array:entries:4", "value4"},
            {"array:entries:5", "value5"}
        };

        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddInMemoryCollection(arrayDict);
                config.AddJsonFile("Value3.json",
                                    optional: false, reloadOnChange: false);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
```

The following code reads the preceding configuration and displays the values:

```csharp
public class ArrayModel : PageModel
{
    private readonly IConfiguration Config;
    public ArrayExample _array { get; private set; }

    public ArrayModel(IConfiguration config)
    {
        Config = config;
    }

    public ContentResult OnGet()
    {
        _array = Config.GetSection("array").Get<ArrayExample>();
        string s = null;

        for (int j = 0; j < _array.Entries.Length; j++)
        {
            s += $"Index: {j}  Value:  {_array.Entries[j]} \n";
        }

        return Content(s);
    }
}
```

The preceding code returns the following output:

```text
Index: 0  Value: value0
Index: 1  Value: value1
Index: 2  Value: value2
Index: 3  Value: value3
Index: 4  Value: value4
Index: 5  Value: value5
```

Custom configuration providers aren't required to implement array binding.

:::moniker-end

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF)](/ef/core/).

The provider has the following characteristics:

* The EF in-memory database is used for demonstration purposes. To use a database that requires a connection string, implement a secondary <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder> to supply the connection string from another configuration provider.
* The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
* Reload-on-change isn't implemented, so updating the database after the app starts has no effect on the app's configuration.

Define an `EFConfigurationValue` entity for storing configuration values in the database.

`Models/EFConfigurationValue.cs`:

```csharp
public class EFConfigurationValue
{
    public string Id { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}
```

Add an `EFConfigurationContext` to store and access the configured values.

`EFConfigurationProvider/EFConfigurationContext.cs`:

::: moniker range=">= aspnetcore-6.0"

```csharp
public class EFConfigurationContext : DbContext
{
    public EFConfigurationContext(
        DbContextOptions<EFConfigurationContext> options) : base(options)
    {
    }

    public DbSet<EFConfigurationValue> Values => Set<EFConfigurationValue>();
}
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
// using Microsoft.EntityFrameworkCore;

public class EFConfigurationContext : DbContext
{
    public EFConfigurationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<EFConfigurationValue> Values { get; set; }
}
```

::: moniker-end

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

`EFConfigurationProvider/EFConfigurationSource.cs`:

::: moniker range="< aspnetcore-6.0"

> [!NOTE]
> The example requires the following `using` statements:
>
> ```csharp
> using Microsoft.EntityFrameworkCore;
> using Microsoft.Extensions.Configuration;
> ```

::: moniker-end

```csharp
public class EFConfigurationSource : IConfigurationSource
{
    private readonly Action<DbContextOptionsBuilder> _optionsAction;

    public EFConfigurationSource(Action<DbContextOptionsBuilder> optionsAction) => 
        _optionsAction = optionsAction;

    public IConfigurationProvider Build(IConfigurationBuilder builder) => 
        new EFConfigurationProvider(_optionsAction);
}
```

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty. Since configuration keys are case-insensitive, the dictionary used to initialize the database is created with the case-insensitive comparer, <xref:System.StringComparer.OrdinalIgnoreCase%2A?displayProperty=nameWithType>.

`EFConfigurationProvider/EFConfigurationProvider.cs`:

::: moniker range=">= aspnetcore-6.0"

```csharp
public class EFConfigurationProvider : ConfigurationProvider
{
    public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
    {
        OptionsAction = optionsAction;
    }

    Action<DbContextOptionsBuilder> OptionsAction { get; }

    public override void Load()
    {
        var builder = new DbContextOptionsBuilder<EFConfigurationContext>();

        OptionsAction(builder);

        using (var dbContext = new EFConfigurationContext(builder.Options))
        {
            if (dbContext == null || dbContext.Values == null)
            {
                throw new Exception("Null DB context");
            }
            dbContext.Database.EnsureCreated();

            Data = !dbContext.Values.Any()
                ? CreateAndSaveDefaultValues(dbContext)
                : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
        }
    }

    private static IDictionary<string, string> CreateAndSaveDefaultValues(
        EFConfigurationContext dbContext)
    {
        // Quotes (c)2005 Universal Pictures: Serenity
        // https://www.uphe.com/movies/serenity-2005
        var configValues =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                    { "quote1", "I aim to misbehave." },
                    { "quote2", "I swallowed a bug." },
                    { "quote3", "You can't stop the signal, Mal." }
            };

        if (dbContext == null || dbContext.Values == null)
        {
            throw new Exception("Null DB context");
        }

        dbContext.Values.AddRange(configValues
            .Select(kvp => new EFConfigurationValue
            {
                Id = kvp.Key,
                Value = kvp.Value
            })
            .ToArray());

        dbContext.SaveChanges();

        return configValues;
    }
}
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;

public class EFConfigurationProvider : ConfigurationProvider
{
    public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
    {
        OptionsAction = optionsAction;
    }

    Action<DbContextOptionsBuilder> OptionsAction { get; }

    public override void Load()
    {
        var builder = new DbContextOptionsBuilder<EFConfigurationContext>();

        OptionsAction(builder);

        using (var dbContext = new EFConfigurationContext(builder.Options))
        {
            dbContext.Database.EnsureCreated();

            Data = !dbContext.Values.Any()
                ? CreateAndSaveDefaultValues(dbContext)
                : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
        }
    }

    private static IDictionary<string, string> CreateAndSaveDefaultValues(
        EFConfigurationContext dbContext)
    {
        // Quotes (c)2005 Universal Pictures: Serenity
        // https://www.uphe.com/movies/serenity-2005
        var configValues = 
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "quote1", "I aim to misbehave." },
                { "quote2", "I swallowed a bug." },
                { "quote3", "You can't stop the signal, Mal." }
            };

        dbContext.Values.AddRange(configValues
            .Select(kvp => new EFConfigurationValue 
                {
                    Id = kvp.Key,
                    Value = kvp.Value
                })
            .ToArray());

        dbContext.SaveChanges();

        return configValues;
    }
}
```

::: moniker-end

An `AddEFConfiguration` extension method permits adding the configuration source to a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

`Extensions/EntityFrameworkExtensions.cs`:

::: moniker range="< aspnetcore-6.0"

> [!NOTE]
> The example requires the following `using` statements:
>
> ```csharp
> using Microsoft.EntityFrameworkCore;
> using Microsoft.Extensions.Configuration;
> ```

::: moniker-end

```csharp
public static class EntityFrameworkExtensions
{
    public static IConfigurationBuilder AddEFConfiguration(
               this IConfigurationBuilder builder,
               Action<DbContextOptionsBuilder> optionsAction)
    {
        return builder.Add(new EFConfigurationSource(optionsAction));
    }
}
```

The following code shows how to use the custom `EFConfigurationProvider` in the app's `Program` file:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Configuration.AddEFConfiguration(
    opt => opt.UseInMemoryDatabase("InMemoryDb"));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddEFConfiguration(
                options => options.UseInMemoryDatabase("InMemoryDb"));
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

::: moniker-end

For an example of accessing configuration using startup convenience methods, see [App startup: Convenience methods](xref:fundamentals/startup#convenience-methods).

## Other configuration

This topic only pertains to *app configuration*. Other aspects of running and hosting ASP.NET Core apps are configured using configuration files not covered by this article:

* Launch settings files (`launch.json`/`launchSettings.json`) are tooling configuration files for the Development environment. For more information, see <xref:fundamentals/environments#development>.
* `web.config` is a server configuration file for [Internet Information Services (IIS)](https://www.iis.net/). For more information, see <xref:host-and-deploy/iis/index> and <xref:host-and-deploy/aspnet-core-module>.

For more information on migrating app configuration from earlier versions of ASP.NET, see <xref:migration/fx-to-core/examples/configuration>.

## Add configuration from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

:::moniker range=">= aspnetcore-8.0"

## Configuration-binding source generator

The [Configuration-binding source generator](/dotnet/core/whats-new/dotnet-8/runtime#configuration-binding-source-generator) provides AOT and trim-friendly configuration. For more information, see [Configuration-binding source generator](/dotnet/core/whats-new/dotnet-8/runtime#configuration-binding-source-generator).

:::moniker-end

## Additional resources

* <xref:blazor/fundamentals/configuration>
* [Configuration source code](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Configuration)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/configuration) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
* <xref:fundamentals/configuration/options>
