---
title: Configuration in ASP.NET Core
author: guardrex
description: Learn how to use the Configuration API to configure an ASP.NET Core app.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/24/2019
uid: fundamentals/configuration/index
---
# Configuration in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

App configuration in ASP.NET Core is based on key-value pairs established by *configuration providers*. Configuration providers read configuration data into key-value pairs from a variety of configuration sources:

* Azure Key Vault
* Azure App Configuration
* Command-line arguments
* Custom providers (installed or created)
* Directory files
* Environment variables
* In-memory .NET objects
* Settings files

::: moniker range=">= aspnetcore-3.0"

Configuration packages for common configuration provider scenarios ([Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)) are included implicitly by the framework.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

Configuration packages for common configuration provider scenarios ([Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)) are included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).

::: moniker-end

Code examples that follow and in the sample app use the <xref:Microsoft.Extensions.Configuration> namespace:

```csharp
using Microsoft.Extensions.Configuration;
```

The *options pattern* is an extension of the configuration concepts described in this topic. Options use classes to represent groups of related settings. For more information, see <xref:fundamentals/configuration/options>.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples) ([how to download](xref:index#how-to-download-a-sample))

## Host versus app configuration

Before the app is configured and started, a *host* is configured and launched. The host is responsible for app startup and lifetime management. Both the app and the host are configured using the configuration providers described in this topic. Host configuration key-value pairs are also included in the app's configuration. For more information on how the configuration providers are used when the host is built and how configuration sources affect host configuration, see <xref:fundamentals/index#host>.

## Default configuration

::: moniker range=">= aspnetcore-3.0"

Web apps based on the ASP.NET Core [dotnet new](/dotnet/core/tools/dotnet-new) templates call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder*> when building a host. `CreateDefaultBuilder` provides default configuration for the app in the following order:

The following applies to apps using the [Generic Host](xref:fundamentals/host/generic-host). For details on the default configuration when using the [Web Host](xref:fundamentals/host/web-host), see the [ASP.NET Core 2.2 version of this topic](/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2).

* Host configuration is provided from:
  * Environment variables prefixed with `DOTNET_` (for example, `DOTNET_ENVIRONMENT`) using the [Environment Variables Configuration Provider](#environment-variables-configuration-provider). The prefix (`DOTNET_`) is stripped when the configuration key-value pairs are loaded.
  * Command-line arguments using the [Command-line Configuration Provider](#command-line-configuration-provider).
* Web Host default configuration is established (`ConfigureWebHostDefaults`):
  * Kestrel is used as the web server and configured using the app's configuration providers.
  * Add Host Filtering Middleware.
  * Add Forwarded Headers Middleware if the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable is set to `true`.
  * Enable IIS integration.
* App configuration is provided from:
  * *appsettings.json* using the [File Configuration Provider](#file-configuration-provider).
  * *appsettings.{Environment}.json* using the [File Configuration Provider](#file-configuration-provider).
  * [Secret Manager](xref:security/app-secrets) when the app runs in the `Development` environment using the entry assembly.
  * Environment variables using the [Environment Variables Configuration Provider](#environment-variables-configuration-provider).
  * Command-line arguments using the [Command-line Configuration Provider](#command-line-configuration-provider).

::: moniker-end

::: moniker range="< aspnetcore-3.0"

Web apps based on the ASP.NET Core [dotnet new](/dotnet/core/tools/dotnet-new) templates call <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder*> when building a host. `CreateDefaultBuilder` provides default configuration for the app in the following order:

The following applies to apps using the [Web Host](xref:fundamentals/host/web-host). For details on the default configuration when using the [Generic Host](xref:fundamentals/host/generic-host), see the [latest version of this topic](xref:fundamentals/configuration/index).

* Host configuration is provided from:
  * Environment variables prefixed with `ASPNETCORE_` (for example, `ASPNETCORE_ENVIRONMENT`) using the [Environment Variables Configuration Provider](#environment-variables-configuration-provider). The prefix (`ASPNETCORE_`) is stripped when the configuration key-value pairs are loaded.
  * Command-line arguments using the [Command-line Configuration Provider](#command-line-configuration-provider).
* App configuration is provided from:
  * *appsettings.json* using the [File Configuration Provider](#file-configuration-provider).
  * *appsettings.{Environment}.json* using the [File Configuration Provider](#file-configuration-provider).
  * [Secret Manager](xref:security/app-secrets) when the app runs in the `Development` environment using the entry assembly.
  * Environment variables using the [Environment Variables Configuration Provider](#environment-variables-configuration-provider).
  * Command-line arguments using the [Command-line Configuration Provider](#command-line-configuration-provider).

::: moniker-end

## Security

Adopt the following practices to secure sensitive configuration data:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files.
* Don't use production secrets in development or test environments.
* Specify secrets outside of the project so that they can't be accidentally committed to a source code repository.

For more information, see the following topics:

* <xref:fundamentals/environments>
* <xref:security/app-secrets> &ndash; Includes advice on using environment variables to store sensitive data. The Secret Manager uses the File Configuration Provider to store user secrets in a JSON file on the local system. The File Configuration Provider is described later in this topic.

[Azure Key Vault](https://azure.microsoft.com/services/key-vault/) safely stores app secrets for ASP.NET Core apps. For more information, see <xref:security/key-vault-configuration>.

## Hierarchical configuration data

The Configuration API is capable of maintaining hierarchical configuration data by flattening the hierarchical data with the use of a delimiter in the configuration keys.

In the following JSON file, four keys exist in a structured hierarchy of two sections:

```json
{
  "section0": {
    "key0": "value",
    "key1": "value"
  },
  "section1": {
    "key0": "value",
    "key1": "value"
  }
}
```

When the file is read into configuration, unique keys are created to maintain the original hierarchical data structure of the configuration source. The sections and keys are flattened with the use of a colon (`:`) to maintain the original structure:

* section0:key0
* section0:key1
* section1:key0
* section1:key1

<xref:Microsoft.Extensions.Configuration.ConfigurationSection.GetSection*> and <xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren*> methods are available to isolate sections and children of a section in the configuration data. These methods are described later in [GetSection, GetChildren, and Exists](#getsection-getchildren-and-exists).

## Conventions

### Sources and providers

At app startup, configuration sources are read in the order that their configuration providers are specified.

Configuration providers that implement change detection have the ability to reload configuration when an underlying setting is changed. For example, the File Configuration Provider (described later in this topic) and the [Azure Key Vault Configuration Provider](xref:security/key-vault-configuration) implement change detection.

<xref:Microsoft.Extensions.Configuration.IConfiguration> is available in the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) container. <xref:Microsoft.Extensions.Configuration.IConfiguration> can be injected into a Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> to obtain configuration for the class:

```csharp
public class IndexModel : PageModel
{
    private readonly IConfiguration _config;

    public IndexModel(IConfiguration config)
    {
        _config = config;
    }

    // The _config local variable is used to obtain configuration 
    // throughout the class.
}
```

Configuration providers can't utilize DI, as it's not available when they're set up by the host.

### Keys

Configuration keys adopt the following conventions:

* Keys are case-insensitive. For example, `ConnectionString` and `connectionstring` are treated as equivalent keys.
* If a value for the same key is set by the same or different configuration providers, the last value set on the key is the value used.
* Hierarchical keys
  * Within the Configuration API, a colon separator (`:`) works on all platforms.
  * In environment variables, a colon separator may not work on all platforms. A double underscore (`__`) is supported by all platforms and is automatically converted into a colon.
  * In Azure Key Vault, hierarchical keys use `--` (two dashes) as a separator. You must provide code to replace the dashes with a colon when the secrets are loaded into the app's configuration.
* The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> supports binding arrays to objects using array indices in configuration keys. Array binding is described in the [Bind an array to a class](#bind-an-array-to-a-class) section.

### Values

Configuration values adopt the following conventions:

* Values are strings.
* Null values can't be stored in configuration or bound to objects.

## Providers

The following table shows the configuration providers available to ASP.NET Core apps.

| Provider | Provides configuration from&hellip; |
| -------- | ----------------------------------- |
| [Azure Key Vault Configuration Provider](xref:security/key-vault-configuration) (*Security* topics) | Azure Key Vault |
| [Azure App Configuration Provider](/azure/azure-app-configuration/quickstart-aspnet-core-app) (Azure documentation) | Azure App Configuration |
| [Command-line Configuration Provider](#command-line-configuration-provider) | Command-line parameters |
| [Custom configuration provider](#custom-configuration-provider) | Custom source |
| [Environment Variables Configuration Provider](#environment-variables-configuration-provider) | Environment variables |
| [File Configuration Provider](#file-configuration-provider) | Files (INI, JSON, XML) |
| [Key-per-file Configuration Provider](#key-per-file-configuration-provider) | Directory files |
| [Memory Configuration Provider](#memory-configuration-provider) | In-memory collections |
| [User secrets (Secret Manager)](xref:security/app-secrets) (*Security* topics) | File in the user profile directory |

Configuration sources are read in the order that their configuration providers are specified at startup. The configuration providers described in this topic are described in alphabetical order, not in the order that your code may arrange them. Order configuration providers in your code to suit your priorities for the underlying configuration sources.

A typical sequence of configuration providers is:

1. Files (*appsettings.json*, *appsettings.{Environment}.json*, where `{Environment}` is the app's current hosting environment)
1. [Azure Key Vault](xref:security/key-vault-configuration)
1. [User secrets (Secret Manager)](xref:security/app-secrets) (Development environment only)
1. Environment variables
1. Command-line arguments

A common practice is to position the Command-line Configuration Provider last in a series of providers to allow command-line arguments to override configuration set by the other providers.

The preceding sequence of providers is used when you initialize a new host builder with `CreateDefaultBuilder`. For more information, see the [Default configuration](#default-configuration) section.

::: moniker range=">= aspnetcore-3.0"

## Configure the host builder with ConfigureHostConfiguration

To configure the host builder, call <xref:Microsoft.Extensions.Hosting.HostBuilder.ConfigureHostConfiguration*> and supply the configuration. `ConfigureHostConfiguration` is used to initialize the <xref:Microsoft.Extensions.Hosting.IHostEnvironment> for use later in the build process. `ConfigureHostConfiguration` can be called multiple times with additive results.

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureHostConfiguration(config =>
        {
            var dict = new Dictionary<string, string>
            {
                {"MemoryCollectionKey1", "value1"},
                {"MemoryCollectionKey2", "value2"}
            };

            config.AddInMemoryCollection(dict);
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

::: moniker-end

::: moniker range="< aspnetcore-3.0"

## Configure the host builder with UseConfiguration

To configure the host builder, call <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration*> on the host builder with the configuration.

```csharp
public static IWebHostBuilder CreateWebHostBuilder(string[] args)
{
    var dict = new Dictionary<string, string>
    {
        {"MemoryCollectionKey1", "value1"},
        {"MemoryCollectionKey2", "value2"}
    };

    var config = new ConfigurationBuilder()
        .AddInMemoryCollection(dict)
        .Build();

    return WebHost.CreateDefaultBuilder(args)
        .UseConfiguration(config)
        .UseStartup<Startup>();
}
```

::: moniker-end

## ConfigureAppConfiguration

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration providers in addition to those added automatically by `CreateDefaultBuilder`:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=20)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=20)]

::: moniker-end

### Override previous configuration with command-line arguments

To provide app configuration that can be overridden with command-line arguments, call `AddCommandLine` last:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    // Call other providers here
    config.AddCommandLine(args);
})
```

### Consume configuration during app startup

Configuration supplied to the app in `ConfigureAppConfiguration` is available during the app's startup, including `Startup.ConfigureServices`. For more information, see the [Access configuration during startup](#access-configuration-during-startup) section.

## Command-line Configuration Provider

The <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs at runtime.

To activate command-line configuration, the <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine*> extension method is called on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

`AddCommandLine` is automatically called when `CreateDefaultBuilder(string [])` is called. For more information, see the [Default configuration](#default-configuration) section.

`CreateDefaultBuilder` also loads:

* Optional configuration from *appsettings.json* and *appsettings.{Environment}.json* files.
* [User secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
* Environment variables.

`CreateDefaultBuilder` adds the Command-line Configuration Provider last. Command-line arguments passed at runtime override configuration set by the other providers.

`CreateDefaultBuilder` acts when the host is constructed. Therefore, command-line configuration activated by `CreateDefaultBuilder` can affect how the host is configured.

For apps based on the ASP.NET Core templates, `AddCommandLine` has already been called by `CreateDefaultBuilder`. To add additional configuration providers and maintain the ability to override configuration from those providers with command-line arguments, call the app's additional providers in `ConfigureAppConfiguration` and call `AddCommandLine` last.

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    // Call other providers here
    config.AddCommandLine(args);
})
```

**Example**

The sample app takes advantage of the static convenience method `CreateDefaultBuilder` to build the host, which includes a call to <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine*>.

1. Open a command prompt in the project's directory.
1. Supply a command-line argument to the `dotnet run` command, `dotnet run CommandLineKey=CommandLineValue`.
1. After the app is running, open a browser to the app at `http://localhost:5000`.
1. Observe that the output contains the key-value pair for the configuration command-line argument provided to `dotnet run`.

### Arguments

The value must follow an equals sign (`=`), or the key must have a prefix (`--` or `/`) when the value follows a space. The value isn't required if an equals sign is used (for example, `CommandLineKey=`).

| Key prefix               | Example                                                |
| ------------------------ | ------------------------------------------------------ |
| No prefix                | `CommandLineKey1=value1`                               |
| Two dashes (`--`)        | `--CommandLineKey2=value2`, `--CommandLineKey2 value2` |
| Forward slash (`/`)      | `/CommandLineKey3=value3`, `/CommandLineKey3 value3`   |

Within the same command, don't mix command-line argument key-value pairs that use an equals sign with key-value pairs that use a space.

Example commands:

```dotnetcli
dotnet run CommandLineKey1=value1 --CommandLineKey2=value2 /CommandLineKey3=value3
dotnet run --CommandLineKey1 value1 /CommandLineKey2 value2
dotnet run CommandLineKey1= CommandLineKey2=value2
```

### Switch mappings

Switch mappings allow key name replacement logic. When you manually build configuration with a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>, you can provide a dictionary of switch replacements to the <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine*> method.

When the switch mappings dictionary is used, the dictionary is checked for a key that matches the key provided by a command-line argument. If the command-line key is found in the dictionary, the dictionary value (the key replacement) is passed back to set the key-value pair into the app's configuration. A switch mapping is required for any command-line key prefixed with a single dash (`-`).

Switch mappings dictionary key rules:

* Switches must start with a dash (`-`) or double-dash (`--`).
* The switch mappings dictionary must not contain duplicate keys.

Create a switch mappings dictionary. In the following example, two switch mappings are created:

```csharp
public static readonly Dictionary<string, string> _switchMappings = 
    new Dictionary<string, string>
    {
        { "-CLKey1", "CommandLineKey1" },
        { "-CLKey2", "CommandLineKey2" }
    };
```

When the host is built, call `AddCommandLine` with the switch mappings dictionary:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddCommandLine(args, _switchMappings);
})
```

For apps that use switch mappings, the call to `CreateDefaultBuilder` shouldn't pass arguments. The `CreateDefaultBuilder` method's `AddCommandLine` call doesn't include mapped switches, and there's no way to pass the switch mapping dictionary to `CreateDefaultBuilder`. The solution isn't to pass the arguments to `CreateDefaultBuilder` but instead to allow the `ConfigurationBuilder` method's `AddCommandLine` method to process both the arguments and the switch mapping dictionary.

After the switch mappings dictionary is created, it contains the data shown in the following table.

| Key       | Value             |
| --------- | ----------------- |
| `-CLKey1` | `CommandLineKey1` |
| `-CLKey2` | `CommandLineKey2` |

If the switch-mapped keys are used when starting the app, configuration receives the configuration value on the key supplied by the dictionary:

```dotnetcli
dotnet run -CLKey1=value1 -CLKey2=value2
```

After running the preceding command, configuration contains the values shown in the following table.

| Key               | Value    |
| ----------------- | -------- |
| `CommandLineKey1` | `value1` |
| `CommandLineKey2` | `value2` |

## Environment Variables Configuration Provider

The <xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider> loads configuration from environment variable key-value pairs at runtime.

To activate environment variables configuration, call the <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

[Azure App Service](https://azure.microsoft.com/services/app-service/) permits you to set environment variables in the Azure Portal that can override app configuration using the Environment Variables Configuration Provider. For more information, see [Azure Apps: Override app configuration using the Azure Portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal).

::: moniker range=">= aspnetcore-3.0"

`AddEnvironmentVariables` is used to load environment variables prefixed with `DOTNET_` for [host configuration](#host-versus-app-configuration) when a new host builder is initialized with the [Generic Host](xref:fundamentals/host/generic-host) and `CreateDefaultBuilder` is called. For more information, see the [Default configuration](#default-configuration) section.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

`AddEnvironmentVariables` is used to load environment variables prefixed with `ASPNETCORE_` for [host configuration](#host-versus-app-configuration) when a new host builder is initialized with the [Web Host](xref:fundamentals/host/web-host) and `CreateDefaultBuilder` is called. For more information, see the [Default configuration](#default-configuration) section.

::: moniker-end

`CreateDefaultBuilder` also loads:

* App configuration from unprefixed environment variables by calling `AddEnvironmentVariables` without a prefix.
* Optional configuration from *appsettings.json* and *appsettings.{Environment}.json* files.
* [User secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
* Command-line arguments.

The Environment Variables Configuration Provider is called after configuration is established from user secrets and *appsettings* files. Calling the provider in this position allows the environment variables read at runtime to override configuration set by user secrets and *appsettings* files.

If you need to provide app configuration from additional environment variables, call the app's additional providers in `ConfigureAppConfiguration` and call `AddEnvironmentVariables` with the prefix.

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    // Call additional providers here as needed.
    // Call AddEnvironmentVariables last if you need to allow
    // environment variables to override values from other 
    // providers.
    config.AddEnvironmentVariables(prefix: "PREFIX_");
})
}
```

**Example**

The sample app takes advantage of the static convenience method `CreateDefaultBuilder` to build the host, which includes a call to `AddEnvironmentVariables`.

1. Run the sample app. Open a browser to the app at `http://localhost:5000`.
1. Observe that the output contains the key-value pair for the environment variable `ENVIRONMENT`. The value reflects the environment in which the app is running, typically `Development` when running locally.

To keep the list of environment variables rendered by the app short, the app filters environment variables. See the sample app's *Pages/Index.cshtml.cs* file.

If you wish to expose all of the environment variables available to the app, change the `FilteredConfiguration` in *Pages/Index.cshtml.cs* to the following:

```csharp
FilteredConfiguration = _config.AsEnumerable();
```

### Prefixes

Environment variables loaded into the app's configuration are filtered when you supply a prefix to the `AddEnvironmentVariables` method. For example, to filter environment variables on the prefix `CUSTOM_`, supply the prefix to the configuration provider:

```csharp
var config = new ConfigurationBuilder()
    .AddEnvironmentVariables("CUSTOM_")
    .Build();
```

The prefix is stripped off when the configuration key-value pairs are created.

When the host builder is created, host configuration is provided by environment variables. For more information on the prefix used for these environment variables, see the [Default configuration](#default-configuration) section.

**Connection string prefixes**

The Configuration API has special processing rules for four connection string environment variables involved in configuring Azure connection strings for the app environment. Environment variables with the prefixes shown in the table are loaded into the app if no prefix is supplied to `AddEnvironmentVariables`.

| Connection string prefix | Provider |
| ------------------------ | -------- |
| `CUSTOMCONNSTR_` | Custom provider |
| `MYSQLCONNSTR_` | [MySQL](https://www.mysql.com/) |
| `SQLAZURECONNSTR_` | [Azure SQL Database](https://azure.microsoft.com/services/sql-database/) |
| `SQLCONNSTR_` | [SQL Server](https://www.microsoft.com/sql-server/) |

When an environment variable is discovered and loaded into configuration with any of the four prefixes shown in the table:

* The configuration key is created by removing the environment variable prefix and adding a configuration key section (`ConnectionStrings`).
* A new configuration key-value pair is created that represents the database connection provider (except for `CUSTOMCONNSTR_`, which has no stated provider).

| Environment variable key | Converted configuration key | Provider configuration entry                                                    |
| ------------------------ | --------------------------- | ------------------------------------------------------------------------------- |
| `CUSTOMCONNSTR_<KEY>`    | `ConnectionStrings:<KEY>`   | Configuration entry not created.                                                |
| `MYSQLCONNSTR_<KEY>`     | `ConnectionStrings:<KEY>`   | Key: `ConnectionStrings:<KEY>_ProviderName`:<br>Value: `MySql.Data.MySqlClient` |
| `SQLAZURECONNSTR_<KEY>`  | `ConnectionStrings:<KEY>`   | Key: `ConnectionStrings:<KEY>_ProviderName`:<br>Value: `System.Data.SqlClient`  |
| `SQLCONNSTR_<KEY>`       | `ConnectionStrings:<KEY>`   | Key: `ConnectionStrings:<KEY>_ProviderName`:<br>Value: `System.Data.SqlClient`  |

## File Configuration Provider

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> is the base class for loading configuration from the file system. The following configuration providers are dedicated to specific file types:

* [INI Configuration Provider](#ini-configuration-provider)
* [JSON Configuration Provider](#json-configuration-provider)
* [XML Configuration Provider](#xml-configuration-provider)

### INI Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> loads configuration from INI file key-value pairs at runtime.

To activate INI file configuration, call the <xref:Microsoft.Extensions.Configuration.IniConfigurationExtensions.AddIniFile*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

The colon can be used to as a section delimiter in INI file configuration.

Overloads permit specifying:

* Whether the file is optional.
* Whether the configuration is reloaded if the file changes.
* The <xref:Microsoft.Extensions.FileProviders.IFileProvider> used to access the file.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddIniFile(
        "config.ini", optional: true, reloadOnChange: true);
})
```

A generic example of an INI configuration file:

```ini
[section0]
key0=value
key1=value

[section1]
subsection:key=value

[section2:subsection0]
key=value

[section2:subsection1]
key=value
```

The previous configuration file loads the following keys with `value`:

* section0:key0
* section0:key1
* section1:subsection:key
* section2:subsection0:key
* section2:subsection1:key

### JSON Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration from JSON file key-value pairs during runtime.

To activate JSON file configuration, call the <xref:Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

Overloads permit specifying:

* Whether the file is optional.
* Whether the configuration is reloaded if the file changes.
* The <xref:Microsoft.Extensions.FileProviders.IFileProvider> used to access the file.

`AddJsonFile` is automatically called twice when you initialize a new host builder with `CreateDefaultBuilder`. The method is called to load configuration from:

* *appsettings.json* &ndash; This file is read first. The environment version of the file can override the values provided by the *appsettings.json* file.
* *appsettings.{Environment}.json* &ndash; The environment version of the file is loaded based on the [IHostingEnvironment.EnvironmentName](xref:Microsoft.Extensions.Hosting.IHostingEnvironment.EnvironmentName*).

For more information, see the [Default configuration](#default-configuration) section.

`CreateDefaultBuilder` also loads:

* Environment variables.
* [User secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
* Command-line arguments.

The JSON Configuration Provider is established first. Therefore, user secrets, environment variables, and command-line arguments override configuration set by the *appsettings* files.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration for files other than *appsettings.json* and *appsettings.{Environment}.json*:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile(
        "config.json", optional: true, reloadOnChange: true);
})
```

**Example**

The sample app takes advantage of the static convenience method `CreateDefaultBuilder` to build the host, which includes two calls to `AddJsonFile`. Configuration is loaded from *appsettings.json* and *appsettings.{Environment}.json*.

1. Run the sample app. Open a browser to the app at `http://localhost:5000`.
1. Observe that the output contains key-value pairs for the configuration shown in the table depending on the environment. Logging configuration keys use the colon (`:`) as a hierarchical separator.

| Key                        | Development Value | Production Value |
| -------------------------- | :---------------: | :--------------: |
| Logging:LogLevel:System    | Information       | Information      |
| Logging:LogLevel:Microsoft | Information       | Information      |
| Logging:LogLevel:Default   | Debug             | Error            |
| AllowedHosts               | *                 | *                |

### XML Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> loads configuration from XML file key-value pairs at runtime.

To activate XML file configuration, call the <xref:Microsoft.Extensions.Configuration.XmlConfigurationExtensions.AddXmlFile*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

Overloads permit specifying:

* Whether the file is optional.
* Whether the configuration is reloaded if the file changes.
* The <xref:Microsoft.Extensions.FileProviders.IFileProvider> used to access the file.

The root node of the configuration file is ignored when the configuration key-value pairs are created. Don't specify a Document Type Definition (DTD) or namespace in the file.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddXmlFile(
        "config.xml", optional: true, reloadOnChange: true);
})
```

XML configuration files can use distinct element names for repeating sections:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <section0>
    <key0>value</key0>
    <key1>value</key1>
  </section0>
  <section1>
    <key0>value</key0>
    <key1>value</key1>
  </section1>
</configuration>
```

The previous configuration file loads the following keys with `value`:

* section0:key0
* section0:key1
* section1:key0
* section1:key1

Repeating elements that use the same element name work if the `name` attribute is used to distinguish the elements:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <section name="section0">
    <key name="key0">value</key>
    <key name="key1">value</key>
  </section>
  <section name="section1">
    <key name="key0">value</key>
    <key name="key1">value</key>
  </section>
</configuration>
```

The previous configuration file loads the following keys with `value`:

* section:section0:key:key0
* section:section0:key:key1
* section:section1:key:key0
* section:section1:key:key1

Attributes can be used to supply values:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <key attribute="value" />
  <section>
    <key attribute="value" />
  </section>
</configuration>
```

The previous configuration file loads the following keys with `value`:

* key:attribute
* section:key:attribute

## Key-per-file Configuration Provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value contains the file's contents. The Key-per-file Configuration Provider is used in Docker hosting scenarios.

To activate key-per-file configuration, call the <xref:Microsoft.Extensions.Configuration.KeyPerFileConfigurationBuilderExtensions.AddKeyPerFile*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>. The `directoryPath` to the files must be an absolute path.

Overloads permit specifying:

* An `Action<KeyPerFileConfigurationSource>` delegate that configures the source.
* Whether the directory is optional and the path to the directory.

The double-underscore (`__`) is used as a configuration key delimiter in file names. For example, the file name `Logging__LogLevel__System` produces the configuration key `Logging:LogLevel:System`.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    var path = Path.Combine(
        Directory.GetCurrentDirectory(), "path/to/files");
    config.AddKeyPerFile(directoryPath: path, optional: true);
})
```

## Memory Configuration Provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

To activate in-memory collection configuration, call the <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection*> extension method on an instance of <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>.

The configuration provider can be initialized with an `IEnumerable<KeyValuePair<String,String>>`.

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration.

In the following example, a configuration dictionary is created:

```csharp
public static readonly Dictionary<string, string> _dict = 
    new Dictionary<string, string>
    {
        {"MemoryCollectionKey1", "value1"},
        {"MemoryCollectionKey2", "value2"}
    };
```

The dictionary is used with a call to `AddInMemoryCollection` to provide the configuration:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddInMemoryCollection(_dict);
})
```

## GetValue

[ConfigurationBinder.GetValue\<T>](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue*) extracts a single value from configuration with a specified key and converts it to the specified noncollection type. An overload accepts a default value.

The following example:

* Extracts the string value from configuration with the key `NumberKey`. If `NumberKey` isn't found in the configuration keys, the default value of `99` is used.
* Types the value as an `int`.
* Stores the value in the `NumberConfig` property for use by the page.

```csharp
public class IndexModel : PageModel
{
    public IndexModel(IConfiguration config)
    {
        _config = config;
    }

    public int NumberConfig { get; private set; }

    public void OnGet()
    {
        NumberConfig = _config.GetValue<int>("NumberKey", 99);
    }
}
```

## GetSection, GetChildren, and Exists

For the examples that follow, consider the following JSON file. Four keys are found across two sections, one of which includes a pair of subsections:

```json
{
  "section0": {
    "key0": "value",
    "key1": "value"
  },
  "section1": {
    "key0": "value",
    "key1": "value"
  },
  "section2": {
    "subsection0" : {
      "key0": "value",
      "key1": "value"
    },
    "subsection1" : {
      "key0": "value",
      "key1": "value"
    }
  }
}
```

When the file is read into configuration, the following unique hierarchical keys are created to hold the configuration values:

* section0:key0
* section0:key1
* section1:key0
* section1:key1
* section2:subsection0:key0
* section2:subsection0:key1
* section2:subsection1:key0
* section2:subsection1:key1

### GetSection

[IConfiguration.GetSection](xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection*) extracts a configuration subsection with the specified subsection key.

To return an <xref:Microsoft.Extensions.Configuration.IConfigurationSection> containing only the key-value pairs in `section1`, call `GetSection` and supply the section name:

```csharp
var configSection = _config.GetSection("section1");
```

The `configSection` doesn't have a value, only a key and a path.

Similarly, to obtain the values for keys in `section2:subsection0`, call `GetSection` and supply the section path:

```csharp
var configSection = _config.GetSection("section2:subsection0");
```

`GetSection` never returns `null`. If a matching section isn't found, an empty `IConfigurationSection` is returned.

When `GetSection` returns a matching section, <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Value> isn't populated. A <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Key> and <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Path> are returned when the section exists.

### GetChildren

A call to [IConfiguration.GetChildren](xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren*) on `section2` obtains an `IEnumerable<IConfigurationSection>` that includes:

* `subsection0`
* `subsection1`

```csharp
var configSection = _config.GetSection("section2");

var children = configSection.GetChildren();
```

### Exists

Use [ConfigurationExtensions.Exists](xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.Exists*) to determine if a configuration section exists:

```csharp
var sectionExists = _config.GetSection("section2:subsection2").Exists();
```

Given the example data, `sectionExists` is `false` because there isn't a `section2:subsection2` section in the configuration data.

## Bind to a class

Configuration can be bound to classes that represent groups of related settings using the *options pattern*. For more information, see <xref:fundamentals/configuration/options>.

Configuration values are returned as strings, but calling <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*> enables the construction of [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) objects.

The sample app contains a `Starship` model (*Models/Starship.cs*):

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/Starship.cs?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/Starship.cs?name=snippet1)]

::: moniker-end

The `starship` section of the *starship.json* file creates the configuration when the sample app uses the JSON Configuration Provider to load the configuration:

::: moniker range=">= aspnetcore-3.0"

[!code-json[](index/samples/3.x/ConfigurationSample/starship.json)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-json[](index/samples/2.x/ConfigurationSample/starship.json)]

::: moniker-end

The following configuration key-value pairs are created:

| Key                   | Value                                             |
| --------------------- | ------------------------------------------------- |
| starship:name         | USS Enterprise                                    |
| starship:registry     | NCC-1701                                          |
| starship:class        | Constitution                                      |
| starship:length       | 304.8                                             |
| starship:commissioned | False                                             |
| trademark             | Paramount Pictures Corp. https://www.paramount.com |

The sample app calls `GetSection` with the `starship` key. The `starship` key-value pairs are isolated. The `Bind` method is called on the subsection passing in an instance of the `Starship` class. After binding the instance values, the instance is assigned to a property for rendering:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_starship)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_starship)]

::: moniker-end

## Bind to an object graph

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*> is capable of binding an entire POCO object graph.

The sample contains a `TvShow` model whose object graph includes `Metadata` and `Actors` classes (*Models/TvShow.cs*):

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/TvShow.cs?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/TvShow.cs?name=snippet1)]

::: moniker-end

The sample app has a *tvshow.xml* file containing the configuration data:

::: moniker range=">= aspnetcore-3.0"

[!code-xml[](index/samples/3.x/ConfigurationSample/tvshow.xml)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-xml[](index/samples/2.x/ConfigurationSample/tvshow.xml)]

::: moniker-end

Configuration is bound to the entire `TvShow` object graph with the `Bind` method. The bound instance is assigned to a property for rendering:

```csharp
var tvShow = new TvShow();
_config.GetSection("tvshow").Bind(tvShow);
TvShow = tvShow;
```

[ConfigurationBinder.Get\<T>](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) binds and returns the specified type. `Get<T>` is more convenient than using `Bind`. The following code shows how to use `Get<T>` with the preceding example, which allows the bound instance to be directly assigned to the property used for rendering:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_tvshow)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_tvshow)]

::: moniker-end

## Bind an array to a class

*The sample app demonstrates the concepts explained in this section.*

The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*> supports binding arrays to objects using array indices in configuration keys. Any array format that exposes a numeric key segment (`:0:`, `:1:`, &hellip; `:{n}:`) is capable of array binding to a POCO class array.

> [!NOTE]
> Binding is provided by convention. Custom configuration providers aren't required to implement array binding.

**In-memory array processing**

Consider the configuration keys and values shown in the following table.

| Key             | Value  |
| :-------------: | :----: |
| array:entries:0 | value0 |
| array:entries:1 | value1 |
| array:entries:2 | value2 |
| array:entries:4 | value4 |
| array:entries:5 | value5 |

These keys and values are loaded in the sample app using the Memory Configuration Provider:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=5-12,22)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=5-12,22)]

::: moniker-end

The array skips a value for index &num;3. The configuration binder isn't capable of binding null values or creating null entries in bound objects, which becomes clear in a moment when the result of binding this array to an object is demonstrated.

In the sample app, a POCO class is available to hold the bound configuration data:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/ArrayExample.cs?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/ArrayExample.cs?name=snippet1)]

::: moniker-end

The configuration data is bound to the object:

```csharp
var arrayExample = new ArrayExample();
_config.GetSection("array").Bind(arrayExample);
```

[ConfigurationBinder.Get\<T>](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) syntax can also be used, which results in more compact code:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_array)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_array)]

::: moniker-end

The bound object, an instance of `ArrayExample`, receives the array data from configuration.

| `ArrayExample.Entries` Index | `ArrayExample.Entries` Value |
| :--------------------------: | :--------------------------: |
| 0                            | value0                       |
| 1                            | value1                       |
| 2                            | value2                       |
| 3                            | value4                       |
| 4                            | value5                       |

Index &num;3 in the bound object holds the configuration data for the `array:4` configuration key and its value of `value4`. When configuration data containing an array is bound, the array indices in the configuration keys are merely used to iterate the configuration data when creating the object. A null value can't be retained in configuration data, and a null-valued entry isn't created in a bound object when an array in configuration keys skip one or more indices.

The missing configuration item for index &num;3 can be supplied before binding to the `ArrayExample` instance by any configuration provider that produces the correct key-value pair in configuration. If the sample included an additional JSON Configuration Provider with the missing key-value pair, the `ArrayExample.Entries` matches the complete configuration array:

*missing_value.json*:

```json
{
  "array:entries:3": "value3"
}
```

In `ConfigureAppConfiguration`:

```csharp
config.AddJsonFile(
    "missing_value.json", optional: false, reloadOnChange: false);
```

The key-value pair shown in the table is loaded into configuration.

| Key             | Value  |
| :-------------: | :----: |
| array:entries:3 | value3 |

If the `ArrayExample` class instance is bound after the JSON Configuration Provider includes the entry for index &num;3, the `ArrayExample.Entries` array includes the value.

| `ArrayExample.Entries` Index | `ArrayExample.Entries` Value |
| :--------------------------: | :--------------------------: |
| 0                            | value0                       |
| 1                            | value1                       |
| 2                            | value2                       |
| 3                            | value3                       |
| 4                            | value4                       |
| 5                            | value5                       |

**JSON array processing**

If a JSON file contains an array, configuration keys are created for the array elements with a zero-based section index. In the following configuration file, `subsection` is an array:

::: moniker range=">= aspnetcore-3.0"

[!code-json[](index/samples/3.x/ConfigurationSample/json_array.json)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-json[](index/samples/2.x/ConfigurationSample/json_array.json)]

::: moniker-end

The JSON Configuration Provider reads the configuration data into the following key-value pairs:

| Key                     | Value  |
| ----------------------- | :----: |
| json_array:key          | valueA |
| json_array:subsection:0 | valueB |
| json_array:subsection:1 | valueC |
| json_array:subsection:2 | valueD |

In the sample app, the following POCO class is available to bind the configuration key-value pairs:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/JsonArrayExample.cs?name=snippet1)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/JsonArrayExample.cs?name=snippet1)]

::: moniker-end

After binding, `JsonArrayExample.Key` holds the value `valueA`. The subsection values are stored in the POCO array property, `Subsection`.

| `JsonArrayExample.Subsection` Index | `JsonArrayExample.Subsection` Value |
| :---------------------------------: | :---------------------------------: |
| 0                                   | valueB                              |
| 1                                   | valueC                              |
| 2                                   | valueD                              |

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF)](/ef/core/).

The provider has the following characteristics:

* The EF in-memory database is used for demonstration purposes. To use a database that requires a connection string, implement a secondary `ConfigurationBuilder` to supply the connection string from another configuration provider.
* The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
* Reload-on-change isn't implemented, so updating the database after the app starts has no effect on the app's configuration.

Define an `EFConfigurationValue` entity for storing configuration values in the database.

::: moniker range=">= aspnetcore-3.0"

*Models/EFConfigurationValue.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/EFConfigurationValue.cs?name=snippet1)]

Add an `EFConfigurationContext` to store and access the configured values.

*EFConfigurationProvider/EFConfigurationContext.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationContext.cs?name=snippet1)]

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

*EFConfigurationProvider/EFConfigurationSource.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationSource.cs?name=snippet1)]

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty.

*EFConfigurationProvider/EFConfigurationProvider.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationProvider.cs?name=snippet1)]

An `AddEFConfiguration` extension method permits adding the configuration source to a `ConfigurationBuilder`.

*Extensions/EntityFrameworkExtensions.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Extensions/EntityFrameworkExtensions.cs?name=snippet1)]

The following code shows how to use the custom `EFConfigurationProvider` in *Program.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=29-30)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

*Models/EFConfigurationValue.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/EFConfigurationValue.cs?name=snippet1)]

Add an `EFConfigurationContext` to store and access the configured values.

*EFConfigurationProvider/EFConfigurationContext.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationContext.cs?name=snippet1)]

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

*EFConfigurationProvider/EFConfigurationSource.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationSource.cs?name=snippet1)]

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty.

*EFConfigurationProvider/EFConfigurationProvider.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationProvider.cs?name=snippet1)]

An `AddEFConfiguration` extension method permits adding the configuration source to a `ConfigurationBuilder`.

*Extensions/EntityFrameworkExtensions.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Extensions/EntityFrameworkExtensions.cs?name=snippet1)]

The following code shows how to use the custom `EFConfigurationProvider` in *Program.cs*:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=29-30)]

::: moniker-end

## Access configuration during startup

Inject `IConfiguration` into the `Startup` constructor to access configuration values in `Startup.ConfigureServices`. To access configuration in `Startup.Configure`, either inject `IConfiguration` directly into the method or use the instance from the constructor:

```csharp
public class Startup
{
    private readonly IConfiguration _config;

    public Startup(IConfiguration config)
    {
        _config = config;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var value = _config["key"];
    }

    public void Configure(IApplicationBuilder app, IConfiguration config)
    {
        var value = config["key"];
    }
}
```

For an example of accessing configuration using startup convenience methods, see [App startup: Convenience methods](xref:fundamentals/startup#convenience-methods).

## Access configuration in a Razor Pages page or MVC view

To access configuration settings in a Razor Pages page or an MVC view, add a [using directive](xref:mvc/views/razor#using) ([C# reference: using directive](/dotnet/csharp/language-reference/keywords/using-directive)) for the [Microsoft.Extensions.Configuration namespace](xref:Microsoft.Extensions.Configuration) and inject <xref:Microsoft.Extensions.Configuration.IConfiguration> into the page or view.

In a Razor Pages page:

```cshtml
@page
@model IndexModel
@using Microsoft.Extensions.Configuration
@inject IConfiguration Configuration

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Index Page</title>
</head>
<body>
    <h1>Access configuration in a Razor Pages page</h1>
    <p>Configuration value for 'key': @Configuration["key"]</p>
</body>
</html>
```

In an MVC view:

```cshtml
@using Microsoft.Extensions.Configuration
@inject IConfiguration Configuration

<!DOCTYPE html>
<html lang="en">
<head>
    <title>Index View</title>
</head>
<body>
    <h1>Access configuration in an MVC view</h1>
    <p>Configuration value for 'key': @Configuration["key"]</p>
</body>
</html>
```

## Add configuration from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

## Additional resources

* <xref:fundamentals/configuration/options>
