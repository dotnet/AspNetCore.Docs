---
title: Configuration in ASP.NET Core
author: rick-anderson
description: Use the Configuration API to configure an ASP.NET Core app by multiple methods.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 11/01/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/configuration/index
---
# Configure an ASP.NET Core App

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Mark Michaelis](http://intellitect.com/author/mark-michaelis/), [Steve Smith](https://ardalis.com/), [Daniel Roth](https://github.com/danroth27), and [Luke Latham](https://github.com/guardrex)

The Configuration API provides a way to configure an ASP.NET Core web app based on a list of name-value pairs. Configuration is read at runtime from multiple sources. You can group these name-value pairs into a multi-level hierarchy. 

There are configuration providers for:

* File formats (INI, JSON, and XML)
* Command-line arguments
* Environment variables
* In-memory .NET objects
* An encrypted user store
* [Azure Key Vault](xref:security/key-vault-configuration)
* Custom providers (installed or created)

Each configuration value maps to a string key. There's built-in binding support to deserialize settings into a custom [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) object (a simple .NET class with properties).

The options pattern uses options classes to represent groups of related settings. For more information on using the options pattern, see the [Options](xref:fundamentals/configuration/options) topic.

[View or download sample code](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/index/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## JSON configuration

The following console app uses the JSON configuration provider:

[!code-csharp[Main](index/sample/ConfigJson/Program.cs)]

The app reads and displays the following configuration settings:

[!code-json[Main](index/sample/ConfigJson/appsettings.json)]

Configuration consists of a hierarchical list of name-value pairs in which the nodes are separated by a colon. To retrieve a value, access the `Configuration` indexer with the corresponding item's key:

```csharp
Console.WriteLine($"option1 = {Configuration["subsection:suboption1"]}");
```

To work with arrays in JSON-formatted configuration sources, use an array index as part of the colon-separated string. The following example gets the name of the first item in the preceding `wizards` array:

```csharp
Console.Write($"{Configuration["wizards:0:Name"]}, ");
```

Name-value pairs written to the built-in `Configuration` providers are **not** persisted. However, you can create a custom provider that saves values. See [custom configuration provider](xref:fundamentals/configuration/index#custom-config-providers).

The preceding sample uses the configuration indexer to read values. To access configuration outside of `Startup`, use the *options pattern*. For more information, see the [Options](xref:fundamentals/configuration/options) topic.

It's typical to have different configuration settings for different environments, for example, development, testing, and production. The `CreateDefaultBuilder` extension method in an ASP.NET Core 2.x app (or using `AddJsonFile` and `AddEnvironmentVariables` directly in an ASP.NET Core 1.x app) adds configuration providers for reading JSON files and system configuration sources:

* *appsettings.json*
* *appsettings.\<EnvironmentName>.json*
* Environment variables

See [AddJsonFile](/dotnet/api/microsoft.extensions.configuration.jsonconfigurationextensions) for an explanation of the parameters. `reloadOnChange` is only supported in ASP.NET Core 1.1 and later. 

Configuration sources are read in the order that they're specified. In the code above, the environment variables are read last. Any configuration values set through the environment replace those set in the two previous providers.

The environment is typically set to `Development`, `Staging`, or `Production`. See [Working with multiple environments](xref:fundamentals/environments) for more information.

Configuration considerations:

* `IOptionsSnapshot` can reload configuration data when it changes. See [IOptionsSnapshot](xref:fundamentals/configuration/options#reloading-configuration-data-with-ioptionssnapshot) for more information.
* Configuration keys are case insensitive.
* Specify environment variables last so that the local environment can override settings in deployed configuration files.
* **Never** store passwords or other sensitive data in configuration provider code or in plain text configuration files. Don't use production secrets in your development or test environments. Instead, specify secrets outside of the project so that they can't be accidentally committed to your repository. Learn more about [working with multiple environments](xref:fundamentals/environments) and managing [safe storage of app secrets during development](xref:security/app-secrets).
* If a colon (`:`) can't be used in environment variables on your system, replace the colon (`:`) with a double-underscore (`__`).

## In-memory provider and binding to a POCO class

The following sample shows how to use the in-memory provider and bind to a class:

[!code-csharp[Main](index/sample/InMemory/Program.cs)]

Configuration values are returned as strings, but binding enables the construction of objects. Binding allows you to retrieve POCO objects or even entire object graphs.

### GetValue

The following sample demonstrates the [GetValue&lt;T&gt;](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.configurationbinder#Microsoft_Extensions_Configuration_ConfigurationBinder_GetValue_Microsoft_Extensions_Configuration_IConfiguration_System_Type_System_String_System_Object_) extension method:

[!code-csharp[Main](index/sample/InMemoryGetValue/Program.cs?highlight=27-29)]

The ConfigurationBinder's `GetValue<T>` method allows you to specify a default value (80 in the sample). `GetValue<T>` is for simple scenarios and does not bind to entire sections. `GetValue<T>` gets scalar values from `GetSection(key).Value` converted to a specific type.

## Bind to an object graph

You can recursively bind to each object in a class. Consider the following `AppSettings` class:

[!code-csharp[Main](index/sample/ObjectGraph/AppSettings.cs)]

The following sample binds to the `AppSettings` class:

[!code-csharp[Main](index/sample/ObjectGraph/Program.cs?highlight=15-16)]

**ASP.NET Core 1.1** and higher can use  `Get<T>`, which works with entire sections. `Get<T>` can be more convenient than using `Bind`. The following code shows how to use `Get<T>` with the sample above:

```csharp
var appConfig = config.GetSection("App").Get<AppSettings>();
```

Using the following *appsettings.json* file:

[!code-json[Main](index/sample/ObjectGraph/appsettings.json)]

The program displays `Height 11`.

The following code can be used to unit test the configuration:

```csharp
[Fact]
public void CanBindObjectTree()
{
    var dict = new Dictionary<string, string>
        {
            {"App:Profile:Machine", "Rick"},
            {"App:Connection:Value", "connectionstring"},
            {"App:Window:Height", "11"},
            {"App:Window:Width", "11"}
        };
    var builder = new ConfigurationBuilder();
    builder.AddInMemoryCollection(dict);
    var config = builder.Build();

    var settings = new AppSettings();
    config.GetSection("App").Bind(settings);

    Assert.Equal("Rick", settings.Profile.Machine);
    Assert.Equal(11, settings.Window.Height);
    Assert.Equal(11, settings.Window.Width);
    Assert.Equal("connectionstring", settings.Connection.Value);
}
```

<a name="custom-config-providers"></a>

## Create an Entity Framework custom provider

In this section, a basic configuration provider that reads name-value pairs from a database using EF is created. 

Define a `ConfigurationValue` entity for storing configuration values in the database:

[!code-csharp[Main](index/sample/CustomConfigurationProvider/ConfigurationValue.cs)]

Add a `ConfigurationContext` to store and access the configured values:

[!code-csharp[Main](index/sample/CustomConfigurationProvider/ConfigurationContext.cs?name=snippet1)]

Create an class that implements [IConfigurationSource](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.iconfigurationsource):

[!code-csharp[Main](index/sample/CustomConfigurationProvider/EntityFrameworkConfigurationSource.cs?highlight=7)]

Create the custom configuration provider by inheriting from [ConfigurationProvider](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.configurationprovider).  The configuration provider initializes the database when it's empty:

[!code-csharp[Main](index/sample/CustomConfigurationProvider/EntityFrameworkConfigurationProvider.cs?highlight=9,18-31,38-39)]

The highlighted values from the database ("value_from_ef_1" and "value_from_ef_2") are displayed when the sample is run.

You can add an `EFConfigSource` extension method for adding the configuration source:

[!code-csharp[Main](index/sample/CustomConfigurationProvider/EntityFrameworkExtensions.cs?highlight=12)]

The following code shows how to use the custom `EFConfigProvider`:

[!code-csharp[Main](index/sample/CustomConfigurationProvider/Program.cs?highlight=21-26)]

Note the sample adds the custom `EFConfigProvider` after the JSON provider, so any settings from the database will override settings from the *appsettings.json* file.

Using the following *appsettings.json* file:

[!code-json[Main](index/sample/CustomConfigurationProvider/appsettings.json)]

The following is displayed:

```console
key1=value_from_ef_1
key2=value_from_ef_2
key3=value_from_json_3
```

## CommandLine configuration provider

The [CommandLine configuration provider](/aspnet/core/api/microsoft.extensions.configuration.commandline.commandlineconfigurationprovider) receives command-line argument key-value pairs for configuration at runtime.

[View or download the CommandLine configuration sample](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/index/sample/CommandLine)

### Setup and use the CommandLine configuration provider

# [Basic Configuration](#tab/basicconfiguration)

To activate command-line configuration, call the `AddCommandLine` extension method on an instance of [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder):

[!code-csharp[Main](index/sample_snapshot//CommandLine/Program.cs?highlight=18,21)]

Running the code, the following output is displayed:

```console
MachineName: MairaPC
Left: 1980
```

Passing argument key-value pairs on the command line changes the values of `Profile:MachineName` and `App:MainWindow:Left`:

```console
dotnet run Profile:MachineName=BartPC App:MainWindow:Left=1979
```

The console window displays:

```console
MachineName: BartPC
Left: 1979
```

To override configuration provided by other configuration providers with command-line configuration, call `AddCommandLine` last on `ConfigurationBuilder`:

[!code-csharp[Main](index/sample_snapshot//CommandLine/Program2.cs?range=11-16&highlight=1,5)]

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Typical ASP.NET Core 2.x apps use the static convenience method `CreateDefaultBuilder` to build the host:

[!code-csharp[Main](index/sample_snapshot//Program.cs?highlight=12)]

`CreateDefaultBuilder` loads optional configuration from *appsettings.json*, *appsettings.{Environment}.json*, [user secrets](xref:security/app-secrets) (in the `Development` environment), environment variables, and command-line arguments. The CommandLine configuration provider is called last. Calling the provider last allows the command-line arguments passed at runtime to override configuration set by the other configuration providers called earlier.

Note that for *appsettings* files that `reloadOnChange` is enabled. Command-line arguments are overridden if a matching configuration value in an *appsettings* file is changed after the app starts.

> [!NOTE]
> As an alternative to using the `CreateDefaultBuilder` method, creating a host using [WebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilder) and manually building configuration with [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder) is supported in ASP.NET Core 2.x. See the ASP.NET Core 1.x tab for more information.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Create a [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder) and call the `AddCommandLine` method to use the CommandLine configuration provider. Calling the provider last allows the command-line arguments passed at runtime to override configuration set by the other configuration providers called earlier. Apply the configuration to [WebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilder) with the `UseConfiguration` method:

[!code-csharp[Main](index/sample_snapshot//CommandLine/Program2.cs?highlight=11,15,19)]

---

### Arguments

Arguments passed on the command line must conform to one of two formats shown in the following table.

| Argument format                                                     | Example        |
| ------------------------------------------------------------------- | :------------: |
| Single argument: a key-value pair separated by an equals sign (`=`) | `key1=value`   |
| Sequence of two arguments: a key-value pair separated by a space    | `/key1 value1` |

**Single argument**

The value must follow an equals sign (`=`). The value can be null (for example, `mykey=`).

The key may have a prefix.

| Key prefix               | Example         |
| ------------------------ | :-------------: |
| No prefix                | `key1=value1`   |
| Single dash (`-`)&#8224; | `-key2=value2`  |
| Two dashes (`--`)        | `--key3=value3` |
| Forward slash (`/`)      | `/key4=value4`  |

&#8224;A key with a single dash prefix (`-`) must be provided in [switch mappings](#switch-mappings), described below.

Example command:

```console
dotnet run key1=value1 -key2=value2 --key3=value3 /key4=value4
```

Note: If `-key1` isn't present in the [switch mappings](#switch-mappings) given to the configuration provider, a `FormatException` is thrown.

**Sequence of two arguments**

The value can't be null and must follow the key separated by a space.

The key must have a prefix.

| Key prefix               | Example         |
| ------------------------ | :-------------: |
| Single dash (`-`)&#8224; | `-key1 value1`  |
| Two dashes (`--`)        | `--key2 value2` |
| Forward slash (`/`)      | `/key3 value3`  |

&#8224;A key with a single dash prefix (`-`) must be provided in [switch mappings](#switch-mappings), described below.

Example command:

```console
dotnet run -key1 value1 --key2 value2 /key3 value3
```

Note: If `-key1` isn't present in the [switch mappings](#switch-mappings) given to the configuration provider, a `FormatException` is thrown.

### Duplicate keys

If duplicate keys are provided, the last key-value pair is used.

### Switch mappings

When manually building configuration with `ConfigurationBuilder`, you can optionally provide a switch mappings dictionary to the `AddCommandLine` method. Switch mappings allow you to provide key name replacement logic.

When the switch mappings dictionary is used, the dictionary is checked for a key that matches the key provided by a command-line argument. If the command-line key is found in the dictionary, the dictionary value (the key replacement) is passed back to set the configuration. A switch mapping is required for any command-line key prefixed with a single dash (`-`).

Switch mappings dictionary key rules:

* Switches must start with a dash (`-`) or double-dash (`--`).
* The switch mappings dictionary must not contain duplicate keys.

In the following example, the `GetSwitchMappings` method allows your command-line arguments to use a single dash (`-`) key prefix and avoid leading subkey prefixes.

[!code-csharp[Main](index/sample/CommandLine/Program.cs?highlight=10-19,32)]

Without providing command-line arguments, the dictionary provided to `AddInMemoryCollection` sets the configuration values. Run the app with the following command:

```console
dotnet run
```

The console window displays:

```console
MachineName: RickPC
Left: 1980
```

Use the following to pass in configuration settings:

```console
dotnet run /Profile:MachineName=DahliaPC /App:MainWindow:Left=1984
```

The console window displays:

```console
MachineName: DahliaPC
Left: 1984
```

After the switch mappings dictionary is created, it contains the data shown in the following table.

| Key            | Value                 |
| -------------- | --------------------- |
| `-MachineName` | `Profile:MachineName` |
| `-Left`        | `App:MainWindow:Left` |

To demonstrate key switching using the dictionary, run the following command:

```console
dotnet run -MachineName=ChadPC -Left=1988
```

The command-line keys are swapped. The console window displays the configuration values for `Profile:MachineName` and `App:MainWindow:Left`:

```console
MachineName: ChadPC
Left: 1988
```

## The web.config file

A *web.config* file is required when you host the app in IIS or IIS-Express. *web.config* turns on the AspNetCoreModule in IIS to launch your app. Settings in *web.config* enable the AspNetCoreModule in IIS to launch your app and configure other IIS settings and modules. If you are using Visual Studio and delete *web.config*, Visual Studio will create a new one.

## Additional notes

* Dependency Injection (DI) is not set up until after `ConfigureServices` is invoked.
* The configuration system is not DI aware.
* `IConfiguration` has two specializations:
  * `IConfigurationRoot`  Used for the root node. Can trigger a reload.
  * `IConfigurationSection`  Represents a section of configuration values. The `GetSection` and `GetChildren` methods return an `IConfigurationSection`.

## Additional resources

* [Options](xref:fundamentals/configuration/options)
* [Working with Multiple Environments](xref:fundamentals/environments)
* [Safe storage of app secrets during development](xref:security/app-secrets)
* [Hosting in ASP.NET Core](xref:fundamentals/hosting)
* [Dependency Injection](xref:fundamentals/dependency-injection)
* [Azure Key Vault configuration provider](xref:security/key-vault-configuration)
