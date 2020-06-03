---
title: Configuration in ASP.NET Core
author: rick-anderson
description: Learn how to use the Configuration API to configure an ASP.NET Core app.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 3/29/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/configuration/index
---
# Configuration in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Kirk Larkin](https://twitter.com/serpent5)

::: moniker range=">= aspnetcore-3.0"

Configuration in ASP.NET Core is performed using one or more [configuration providers](#cp). Configuration providers read configuration data from key-value pairs using a variety of configuration sources:

* Settings files, such as *appsettings.json*
* Environment variables
* Azure Key Vault
* Azure App Configuration
* Command-line arguments
* Custom providers, installed or created
* Directory files
* In-memory .NET objects

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples) ([how to download](xref:index#how-to-download-a-sample))

<a name="default"></a>

## Default configuration

ASP.NET Core web apps created with [dotnet new](/dotnet/core/tools/dotnet-new) or Visual Studio generate the following code:

[!code-csharp[](index/samples/3.x/ConfigSample/Program.cs?name=snippet&highlight=9)]

 <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder*> provides default configuration for the app in the following order:

1. [ChainedConfigurationProvider](xref:Microsoft.Extensions.Configuration.ChainedConfigurationSource) :  Adds an existing `IConfiguration` as a source. In the default configuration case, adds the [host](#hvac) configuration and setting it as the first source for the _app_ configuration.
1. [appsettings.json](#appsettingsjson) using the [JSON configuration provider](#file-configuration-provider).
1. *appsettings.*`Environment`*.json* using the [JSON configuration provider](#file-configuration-provider). For example, *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json*.
1. [App secrets](xref:security/app-secrets) when the app runs in the `Development` environment.
1. Environment variables using the [Environment Variables configuration provider](#evcp).
1. Command-line arguments using the [Command-line configuration provider](#command-line).

Configuration providers that are added later override previous key settings. For example, if `MyKey` is set in both *appsettings.json* and the environment, the environment value is used. Using the default configuration providers, the  [Command-line configuration provider](#command-line-configuration-provider) overrides all other providers.

For more information on `CreateDefaultBuilder`, see [Default builder settings](xref:fundamentals/host/generic-host#default-builder-settings).

The following code displays the enabled configuration providers in the order they were added:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Index2.cshtml.cs?name=snippet)]

### appsettings.json

Consider the following *appsettings.json* file:

[!code-json[](index/samples/3.x/ConfigSample/appsettings.json)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays several of the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

The default <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration in the following order:

1. *appsettings.json*
1. *appsettings.*`Environment`*.json* : For example, the *appsettings*.***Production***.*json* and *appsettings*.***Development***.*json* files. The environment version of the file is loaded based on the [IHostingEnvironment.EnvironmentName](xref:Microsoft.Extensions.Hosting.IHostingEnvironment.EnvironmentName*). For more information, see <xref:fundamentals/environments>.

*appsettings*.`Environment`.*json* values override keys in *appsettings.json*. For example, by default:

* In development, *appsettings*.***Development***.*json* configuration overwrites values found in *appsettings.json*.
* In production, *appsettings*.***Production***.*json* configuration overwrites values found in *appsettings.json*. For example, when deploying the app to Azure.

<a name="optpat"></a>

### Bind hierarchical configuration data using the options pattern

[!INCLUDE[](~/includes/bind.md)]

Using the [default](#default) configuration, the *appsettings.json* and *appsettings.*`Environment`*.json* files are enabled with [reloadOnChange: true](https://github.com/dotnet/extensions/blob/release/3.1/src/Hosting/Hosting/src/Host.cs#L74-L75). Changes made to the *appsettings.json* and *appsettings.*`Environment`*.json* file ***after*** the app starts are read by the [JSON configuration provider](#jcp).

See [JSON configuration provider](#jcp) in this document for information on adding additional JSON configuration files.

<a name="security"></a>

## Security and secret manager

Configuration data guidelines:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. The [Secret manager](xref:security/app-secrets) can be used to store secrets in development.
* Don't use production secrets in development or test environments.
* Specify secrets outside of the project so that they can't be accidentally committed to a source code repository.

By [default](#default), [Secret manager](xref:security/app-secrets) reads configuration settings after *appsettings.json* and *appsettings.*`Environment`*.json*.

For more information on storing passwords or other sensitive data:

* <xref:fundamentals/environments>
* <xref:security/app-secrets>:  Includes advice on using environment variables to store sensitive data. The Secret Manager uses the [File configuration provider](#fcp) to store user secrets in a JSON file on the local system.

[Azure Key Vault](https://azure.microsoft.com/services/key-vault/) safely stores app secrets for ASP.NET Core apps. For more information, see <xref:security/key-vault-configuration>.

<a name="evcp"></a>

## Environment variables

Using the [default](#default) configuration, the <xref:Microsoft.Extensions.Configuration.EnvironmentVariables.EnvironmentVariablesConfigurationProvider> loads configuration from environment variable key-value pairs after reading *appsettings.json*, *appsettings.*`Environment`*.json*, and [Secret manager](xref:security/app-secrets). Therefore, key values read from the environment override values read from *appsettings.json*, *appsettings.*`Environment`*.json*, and Secret manager.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

The following `set` commands:

* Set the environment keys and values of the [preceding example](#appsettingsjson) on Windows.
* Test the settings when using the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample). The `dotnet run` command must be run in the project directory.

```dotnetcli
set MyKey="My key from Environment"
set Position__Title=Environment_Editor
set Position__Name=Environment_Rick
dotnet run
```

The preceding environment settings:

* Are only set in processes launched from the command window they were set in.
* Won't be read by browsers launched with Visual Studio.

The following [setx](/windows-server/administration/windows-commands/setx) commands can be used to set the environment keys and values on Windows. Unlike `set`, `setx` settings are persisted. `/M` sets the variable in the system environment. If the `/M` switch isn't used, a user environment variable is set.

```cmd
setx MyKey "My key from setx Environment" /M
setx Position__Title Setx_Environment_Editor /M
setx Position__Name Environment_Rick /M
```

To test that the preceding commands override *appsettings.json* and *appsettings.*`Environment`*.json*:

* With Visual Studio: Exit and restart Visual Studio.
* With the CLI: Start a new command window and enter `dotnet run`.

Call <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables*> with a string to specify a prefix for environment variables:

[!code-csharp[](~/fundamentals/configuration/index/samples/3.x/ConfigSample/Program.cs?name=snippet4&highlight=12)]

In the preceding code:

* `config.AddEnvironmentVariables(prefix: "MyCustomPrefix_")` is added after the [default configuration providers](#default). For an example of ordering the configuration providers, see [JSON configuration provider](#jcp).
* Environment variables set with the `MyCustomPrefix_` prefix override the [default configuration providers](#default). This includes environment variables without the prefix.

The prefix is stripped off when the configuration key-value pairs are read.

The following commands test the custom prefix:

```dotnetcli
set MyCustomPrefix_MyKey="My key with MyCustomPrefix_ Environment"
set MyCustomPrefix_Position__Title=Editor_with_customPrefix
set MyCustomPrefix_Position__Name=Environment_Rick_cp
dotnet run
```

The [default configuration](#default) loads environment variables and command line arguments prefixed with `DOTNET_` and `ASPNETCORE_`. The `DOTNET_` and `ASPNETCORE_` prefixes are used by ASP.NET Core for [host and app configuration](xref:fundamentals/host/generic-host#host-configuration), but not for user configuration. For more information on host and app configuration, see [.NET Generic Host](xref:fundamentals/host/generic-host).

On [Azure App Service](https://azure.microsoft.com/services/app-service/), select **New application setting** on the **Settings > Configuration** page. Azure App Service application settings are:

* Encrypted at rest and transmitted over an encrypted channel.
* Exposed as environment variables.

For more information, see [Azure Apps: Override app configuration using the Azure Portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal).

See [Connection string prefixes](#constr) for information on Azure database connection strings.

<a name="clcp"></a>

## Command-line

Using the [default](#default) configuration, the <xref:Microsoft.Extensions.Configuration.CommandLine.CommandLineConfigurationProvider> loads configuration from command-line argument key-value pairs after the following configuration sources:

* *appsettings.json* and *appsettings*.`Environment`.*json* files.
* [App secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
* Environment variables.

By [default](#default), configuration values set on the command-line override configuration values set with all the other configuration providers.

### Command-line arguments

The following command sets keys and values using `=`:

```dotnetcli
dotnet run MyKey="My key from command line" Position:Title=Cmd Position:Name=Cmd_Rick
```

The following command sets keys and values using `/`:

```dotnetcli
dotnet run /MyKey "Using /" /Position:Title=Cmd_ /Position:Name=Cmd_Rick
```

The following command sets keys and values using `--`:

```dotnetcli
dotnet run --MyKey "Using --" --Position:Title=Cmd-- --Position:Name=Cmd--Rick
```

The key value:

* Must follow `=`, or the key must have a prefix of `--` or `/` when the value follows a space.
* Isn't required if `=` is used. For example, `MySetting=`.

Within the same command, don't mix command-line argument key-value pairs that use `=` with key-value pairs that use a space.

### Switch mappings

Switch mappings allow **key** name replacement logic. Provide a dictionary of switch replacements to the <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine*> method.

When the switch mappings dictionary is used, the dictionary is checked for a key that matches the key provided by a command-line argument. If the command-line key is found in the dictionary, the dictionary value is passed back to set the key-value pair into the app's configuration. A switch mapping is required for any command-line key prefixed with a single dash (`-`).

Switch mappings dictionary key rules:

* Switches must start with `-` or `--`.
* The switch mappings dictionary must not contain duplicate keys.

To use a switch mappings dictionary, pass it into the call to `AddCommandLine`:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramSwitch.cs?name=snippet&highlight=10-18,23)]

The following code shows the key values for the replaced keys:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test3.cshtml.cs?name=snippet)]

Run the following command to test the key replacement:

```dotnetcli
dotnet run -k1=value1 -k2 value2 --alt3=value2 /alt4=value3 --alt5 value5 /alt6 value6
```

Note: Currently, `=` cannot be used to set key-replacement values with a single dash `-`. See [this GitHub issue](https://github.com/dotnet/extensions/issues/3059).

The following command works to test key replacement:

```dotnetcli
dotnet run -k1 value1 -k2 value2 --alt3=value2 /alt4=value3 --alt5 value5 /alt6 value6
```

For apps that use switch mappings, the call to `CreateDefaultBuilder` shouldn't pass arguments. The `CreateDefaultBuilder` method's `AddCommandLine` call doesn't include mapped switches, and there's no way to pass the switch-mapping dictionary to `CreateDefaultBuilder`. The solution isn't to pass the arguments to `CreateDefaultBuilder` but instead to allow the `ConfigurationBuilder` method's `AddCommandLine` method to process both the arguments and the switch-mapping dictionary.

## Hierarchical configuration data

The Configuration API reads hierarchical configuration data by flattening the hierarchical data with the use of a delimiter in the configuration keys.

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following  *appsettings.json* file:

[!code-json[](index/samples/3.x/ConfigSample/appsettings.json)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays several of the configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

The preferred way to read hierarchical configuration data is using the options pattern. For more information, see [Bind hierarchical configuration data](#optpat) in this document.

<xref:Microsoft.Extensions.Configuration.ConfigurationSection.GetSection*> and <xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren*> methods are available to isolate sections and children of a section in the configuration data. These methods are described later in [GetSection, GetChildren, and Exists](#getsection).

<!--
[Azure Key Vault configuration provider](xref:security/key-vault-configuration) implement change detection.
-->

## Configuration keys and values

Configuration keys:

* Are case-insensitive. For example, `ConnectionString` and `connectionstring` are treated as equivalent keys.
* If a key and value is set in more than one configuration providers, the value from the last provider added is used. For more information, see [Default configuration](#default).
* Hierarchical keys
  * Within the Configuration API, a colon separator (`:`) works on all platforms.
  * In environment variables, a colon separator may not work on all platforms. A double underscore, `__`, is supported by all platforms and is automatically converted into a colon `:`.
  * In Azure Key Vault, hierarchical keys use `--` as a separator. The [Azure Key Vault configuration provider](xref:security/key-vault-configuration) automatically replaces `--` with a `:` when the secrets are loaded into the app's configuration.
* The <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> supports binding arrays to objects using array indices in configuration keys. Array binding is described in the [Bind an array to a class](#boa) section.

Configuration values:

* Are strings.
* Null values can't be stored in configuration or bound to objects.

<a name="cp"></a>

## Configuration providers

The following table shows the configuration providers available to ASP.NET Core apps.

| Provider | Provides configuration from |
| -------- | ----------------------------------- |
| [Azure Key Vault configuration provider](xref:security/key-vault-configuration) | Azure Key Vault |
| [Azure App configuration provider](/azure/azure-app-configuration/quickstart-aspnet-core-app) | Azure App Configuration |
| [Command-line configuration provider](#clcp) | Command-line parameters |
| [Custom configuration provider](#custom-configuration-provider) | Custom source |
| [Environment Variables configuration provider](#evcp) | Environment variables |
| [File configuration provider](#file-configuration-provider) | INI, JSON, and XML files |
| [Key-per-file configuration provider](#key-per-file-configuration-provider) | Directory files |
| [Memory configuration provider](#memory-configuration-provider) | In-memory collections |
| [Secret Manager](xref:security/app-secrets)  | File in the user profile directory |

Configuration sources are read in the order that their configuration providers are specified. Order configuration providers in code to suit the priorities for the underlying configuration sources that the app requires.

A typical sequence of configuration providers is:

1. *appsettings.json*
1. *appsettings*.`Environment`.*json*
1. [Secret Manager](xref:security/app-secrets)
1. Environment variables using the [Environment Variables configuration provider](#evcp).
1. Command-line arguments using the [Command-line configuration provider](#command-line-configuration-provider).

A common practice is to add the Command-line configuration provider last in a series of providers to allow command-line arguments to override configuration set by the other providers.

The preceding sequence of providers is used in the [default configuration](#default).

<a name="constr"></a>

### Connection string prefixes

The Configuration API has special processing rules for four connection string environment variables. These connection strings are involved in configuring Azure connection strings for the app environment. Environment variables with the prefixes shown in the table are loaded into the app with the [default configuration](#default) or when no prefix is supplied to `AddEnvironmentVariables`.

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
| `CUSTOMCONNSTR_{KEY} `   | `ConnectionStrings:{KEY}`   | Configuration entry not created.                                                |
| `MYSQLCONNSTR_{KEY}`     | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `MySql.Data.MySqlClient` |
| `SQLAZURECONNSTR_{KEY}`  | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |
| `SQLCONNSTR_{KEY}`       | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |

<a name="jcp"></a>

### JSON configuration provider

The <xref:Microsoft.Extensions.Configuration.Json.JsonConfigurationProvider> loads configuration from JSON file key-value pairs.

Overloads can specify:

* Whether the file is optional.
* Whether the configuration is reloaded if the file changes.

Consider the following code:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSON.cs?name=snippet&highlight=12-14)]

The preceding code:

* Configures the JSON configuration provider to load the *MyConfig.json* file with the following options:
  * `optional: true`: The file is optional.
  * `reloadOnChange: true` : The file is reloaded when changes are saved.
* Reads the [default configuration providers](#default) before the *MyConfig.json* file. Settings in the *MyConfig.json* file override setting in the default configuration providers, including the [Environment variables configuration provider](#evcp) and the [Command-line configuration provider](#clcp).

You typically ***don't*** want a custom JSON file overriding values set in the [Environment variables configuration provider](#evcp) and the [Command-line configuration provider](#clcp).

The following code clears all the configuration providers and adds several configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSON2.cs?name=snippet)]

In the preceding code, settings in the *MyConfig.json* and  *MyConfig*.`Environment`.*json* files:

* Override settings in the *appsettings.json* and *appsettings*.`Environment`.*json* files.
* Are overridden by settings in the [Environment variables configuration provider](#evcp) and the [Command-line configuration provider](#clcp).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following  *MyConfig.json* file:

[!code-json[](index/samples/3.x/ConfigSample/MyConfig.json)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays several of the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

<a name="fcp"></a>

## File configuration provider

<xref:Microsoft.Extensions.Configuration.FileConfigurationProvider> is the base class for loading configuration from the file system. The following configuration providers derive from `FileConfigurationProvider`:

* [INI configuration provider](#ini-configuration-provider)
* [JSON configuration provider](#jcp)
* [XML configuration provider](#xml-configuration-provider)

### INI configuration provider

The <xref:Microsoft.Extensions.Configuration.Ini.IniConfigurationProvider> loads configuration from INI file key-value pairs at runtime.

The following code clears all the configuration providers and adds several configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramINI.cs?name=snippet&highlight=10-30)]

In the preceding code, settings in the *MyIniConfig.ini* and  *MyIniConfig*.`Environment`.*ini* files are overridden by settings in the:

* [Environment variables configuration provider](#evcp)
* [Command-line configuration provider](#clcp).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following *MyIniConfig.ini* file:

[!code-ini[](index/samples/3.x/ConfigSample/MyIniConfig.ini)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays several of the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

### XML configuration provider

The <xref:Microsoft.Extensions.Configuration.Xml.XmlConfigurationProvider> loads configuration from XML file key-value pairs at runtime.

The following code clears all the configuration providers and adds several configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramXML.cs?name=snippet)]

In the preceding code, settings in the *MyXMLFile.xml* and  *MyXMLFile*.`Environment`.*xml* files are overridden by settings in the:

* [Environment variables configuration provider](#evcp)
* [Command-line configuration provider](#clcp).

The [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) contains the following *MyXMLFile.xml* file:

[!code-xml[](index/samples/3.x/ConfigSample/MyXMLFile.xml)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays several of the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

Repeating elements that use the same element name work if the `name` attribute is used to distinguish the elements:

[!code-xml[](index/samples/3.x/ConfigSample/MyXMLFile3.xml)]

The following code reads the previous configuration file and displays the keys and values:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/XML/Index.cshtml.cs?name=snippet)]

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

## Key-per-file configuration provider

The <xref:Microsoft.Extensions.Configuration.KeyPerFile.KeyPerFileConfigurationProvider> uses a directory's files as configuration key-value pairs. The key is the file name. The value contains the file's contents. The Key-per-file configuration provider is used in Docker hosting scenarios.

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

<a name="mcp"></a>

## Memory configuration provider

The <xref:Microsoft.Extensions.Configuration.Memory.MemoryConfigurationProvider> uses an in-memory collection as configuration key-value pairs.

The following code adds a memory collection to the configuration system:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet6)]

The following code from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample) displays the preceding configurations settings:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Test.cshtml.cs?name=snippet)]

In the preceding code, `config.AddInMemoryCollection(Dict)` is added after the [default configuration providers](#default). For an example of ordering the configuration providers, see [JSON configuration provider](#jcp).

See [Bind an array](#boa) for another example using `MemoryConfigurationProvider`.

## GetValue

[`ConfigurationBinder.GetValue<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue*) extracts a single value from configuration with a specified key and converts it to the specified type:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/TestNum.cshtml.cs?name=snippet)]

In the preceding code,  if `NumberKey` isn't found in the configuration, the default value of `99` is used.

## GetSection, GetChildren, and Exists

For the examples that follow, consider the following *MySubsection.json* file:

[!code-json[](index/samples/3.x/ConfigSample/MySubsection.json)]

The following code adds *MySubsection.json* to the configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSONsection.cs?name=snippet)]

### GetSection

[IConfiguration.GetSection](xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection*) returns a configuration subsection with the specified subsection key.

The following code returns values for `section1`:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/TestSection.cshtml.cs?name=snippet)]

The following code returns values for `section2:subsection0`:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/TestSection2.cshtml.cs?name=snippet)]

`GetSection` never returns `null`. If a matching section isn't found, an empty `IConfigurationSection` is returned.

When `GetSection` returns a matching section, <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Value> isn't populated. A <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Key> and <xref:Microsoft.Extensions.Configuration.IConfigurationSection.Path> are returned when the section exists.

### GetChildren and Exists

The following code calls [IConfiguration.GetChildren](xref:Microsoft.Extensions.Configuration.IConfiguration.GetChildren*) and returns values for `section2:subsection0`:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/TestSection4.cshtml.cs?name=snippet)]

The preceding code calls [ConfigurationExtensions.Exists](xref:Microsoft.Extensions.Configuration.ConfigurationExtensions.Exists*) to verify the  section exists:

 <a name="boa"></a>

## Bind an array

The [ConfigurationBinder.Bind](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*) supports binding arrays to objects using array indices in configuration keys. Any array format that exposes a numeric key segment is capable of array binding to a [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) class array.

Consider *MyArray.json* from the [sample download](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples/3.x/ConfigSample):

[!code-json[](index/samples/3.x/ConfigSample/MyArray.json)]

The following code adds *MyArray.json* to the configuration providers:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramJSONarray.cs?name=snippet)]

The following code reads the configuration and displays the values:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

The preceding code returns the following output:

```text
Index: 0  Value: value00
Index: 1  Value: value10
Index: 2  Value: value20
Index: 3  Value: value40
Index: 4  Value: value50
```

In the preceding output, Index 3 has value `value40`, corresponding to `"4": "value40",` in *MyArray.json*. The bound array indices are continuous and not bound to the configuration key index. The configuration binder isn't capable of binding null values or creating null entries in bound objects

The  following code loads the `array:entries` configuration with the <xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection*> extension method:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet)]

The following code reads the configuration in the `arrayDict` `Dictionary` and displays the values:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

The preceding code returns the following output:

```text
Index: 0  Value: value0
Index: 1  Value: value1
Index: 2  Value: value2
Index: 3  Value: value4
Index: 4  Value: value5
```

Index &num;3 in the bound object holds the configuration data for the `array:4` configuration key and its value of `value4`. When configuration data containing an array is bound, the array indices in the configuration keys are used to iterate the configuration data when creating the object. A null value can't be retained in configuration data, and a null-valued entry isn't created in a bound object when an array in configuration keys skip one or more indices.

The missing configuration item for index &num;3 can be supplied before binding to the `ArrayExample` instance by any configuration provider that reads the index &num;3 key/value pair. Consider the following *Value3.json* file from the sample download:

[!code-json[](index/samples/3.x/ConfigSample/Value3.json)]

The following code includes configuration for *Value3.json* and the `arrayDict` `Dictionary`:

[!code-csharp[](index/samples/3.x/ConfigSample/ProgramArray.cs?name=snippet2)]

The following code reads the preceding configuration and displays the values:

[!code-csharp[](index/samples/3.x/ConfigSample/Pages/Array.cshtml.cs?name=snippet)]

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

## Custom configuration provider

The sample app demonstrates how to create a basic configuration provider that reads configuration key-value pairs from a database using [Entity Framework (EF)](/ef/core/).

The provider has the following characteristics:

* The EF in-memory database is used for demonstration purposes. To use a database that requires a connection string, implement a secondary `ConfigurationBuilder` to supply the connection string from another configuration provider.
* The provider reads a database table into configuration at startup. The provider doesn't query the database on a per-key basis.
* Reload-on-change isn't implemented, so updating the database after the app starts has no effect on the app's configuration.

Define an `EFConfigurationValue` entity for storing configuration values in the database.

*Models/EFConfigurationValue.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Models/EFConfigurationValue.cs?name=snippet1)]

Add an `EFConfigurationContext` to store and access the configured values.

*EFConfigurationProvider/EFConfigurationContext.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationContext.cs?name=snippet1)]

Create a class that implements <xref:Microsoft.Extensions.Configuration.IConfigurationSource>.

*EFConfigurationProvider/EFConfigurationSource.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationSource.cs?name=snippet1)]

Create the custom configuration provider by inheriting from <xref:Microsoft.Extensions.Configuration.ConfigurationProvider>. The configuration provider initializes the database when it's empty. Since [configuration keys are case-insensitive](#keys), the dictionary used to initialize the database is created with the case-insensitive comparer ([StringComparer.OrdinalIgnoreCase](xref:System.StringComparer.OrdinalIgnoreCase)).

*EFConfigurationProvider/EFConfigurationProvider.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/EFConfigurationProvider/EFConfigurationProvider.cs?name=snippet1)]

An `AddEFConfiguration` extension method permits adding the configuration source to a `ConfigurationBuilder`.

*Extensions/EntityFrameworkExtensions.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Extensions/EntityFrameworkExtensions.cs?name=snippet1)]

The following code shows how to use the custom `EFConfigurationProvider` in *Program.cs*:

[!code-csharp[](index/samples/3.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=29-30)]

<a name="acs"></a>

## Access configuration in Startup

The following code displays configuration data in `Startup` methods:

[!code-csharp[](index/samples/3.x/ConfigSample/StartupKey.cs?name=snippet&highlight=13,18)]

For an example of accessing configuration using startup convenience methods, see [App startup: Convenience methods](xref:fundamentals/startup#convenience-methods).

## Access configuration in Razor Pages

The following code displays configuration data in a Razor Page:

[!code-cshtml[](index/samples/3.x/ConfigSample/Pages/Test5.cshtml)]

In the following code, `MyOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure*> and bound to configuration:

[!code-csharp[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Startup3.cs?name=snippet_Example2)]

The following markup uses the [`@inject`](xref:mvc/views/razor#inject) Razor directive to resolve and display the options values:

[!code-cshtml[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Pages/Test3.cshtml)]

## Access configuration in a MVC view file

The following code displays configuration data in a MVC view:

[!code-cshtml[](index/samples/3.x/ConfigSample/Views/Home2/Index.cshtml)]

## Configure options with a delegate

Options configured in a delegate override values set in the configuration providers.

Configuring options with a delegate is demonstrated as Example 2 in the sample app.

In the following code, an <xref:Microsoft.Extensions.Options.IConfigureOptions%601> service is added to the service container. It uses a delegate to configure values for `MyOptions`:

[!code-csharp[](~/fundamentals/configuration/options/samples/3.x/OptionsSample/Startup2.cs?name=snippet_Example2)]

The following code displays the options values:

[!code-csharp[](options/samples/3.x/OptionsSample/Pages/Test2.cshtml.cs?name=snippet)]

In the preceding example, the values of `Option1` and `Option2` are specified in *appsettings.json* and then overridden by the configured delegate.

<a name="hvac"></a>

## Host versus app configuration

Before the app is configured and started, a *host* is configured and launched. The host is responsible for app startup and lifetime management. Both the app and the host are configured using the configuration providers described in this topic. Host configuration key-value pairs are also included in the app's configuration. For more information on how the configuration providers are used when the host is built and how configuration sources affect host configuration, see <xref:fundamentals/index#host>.

<a name="dhc"></a>

## Default host configuration

For details on the default configuration when using the [Web Host](xref:fundamentals/host/web-host), see the [ASP.NET Core 2.2 version of this topic](/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2).

* Host configuration is provided from:
  * Environment variables prefixed with `DOTNET_` (for example, `DOTNET_ENVIRONMENT`) using the [Environment Variables configuration provider](#environment-variables-configuration-provider). The prefix (`DOTNET_`) is stripped when the configuration key-value pairs are loaded.
  * Command-line arguments using the [Command-line configuration provider](#command-line-configuration-provider).
* Web Host default configuration is established (`ConfigureWebHostDefaults`):
  * Kestrel is used as the web server and configured using the app's configuration providers.
  * Add Host Filtering Middleware.
  * Add Forwarded Headers Middleware if the `ASPNETCORE_FORWARDEDHEADERS_ENABLED` environment variable is set to `true`.
  * Enable IIS integration.

## Other configuration

This topic only pertains to *app configuration*. Other aspects of running and hosting ASP.NET Core apps are configured using configuration files not covered in this topic:

* *launch.json*/*launchSettings.json* are tooling configuration files for the Development environment, described:
  * In <xref:fundamentals/environments#development>.
  * Across the documentation set where the files are used to configure ASP.NET Core apps for Development scenarios.
* *web.config* is a server configuration file, described in the following topics:
  * <xref:host-and-deploy/iis/index>
  * <xref:host-and-deploy/aspnet-core-module>

For more information on migrating app configuration from earlier versions of ASP.NET, see <xref:migration/proper-to-2x/index#store-configurations>.

## Add configuration from an external assembly

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For more information, see <xref:fundamentals/configuration/platform-specific-configuration>.

## Additional resources

* [Configuration source code](https://github.com/dotnet/extensions/tree/master/src/Configuration)
* <xref:fundamentals/configuration/options>

::: moniker-end

::: moniker range="< aspnetcore-3.0"

App configuration in ASP.NET Core is based on key-value pairs established by *configuration providers*. Configuration providers read configuration data into key-value pairs from a variety of configuration sources:

* Azure Key Vault
* Azure App Configuration
* Command-line arguments
* Custom providers (installed or created)
* Directory files
* Environment variables
* In-memory .NET objects
* Settings files

Configuration packages for common configuration provider scenarios ([Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)) are included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app).

Code examples that follow and in the sample app use the <xref:Microsoft.Extensions.Configuration> namespace:

```csharp
using Microsoft.Extensions.Configuration;
```

The *options pattern* is an extension of the configuration concepts described in this topic. Options use classes to represent groups of related settings. For more information, see <xref:fundamentals/configuration/options>.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/configuration/index/samples) ([how to download](xref:index#how-to-download-a-sample))

## Host versus app configuration

Before the app is configured and started, a *host* is configured and launched. The host is responsible for app startup and lifetime management. Both the app and the host are configured using the configuration providers described in this topic. Host configuration key-value pairs are also included in the app's configuration. For more information on how the configuration providers are used when the host is built and how configuration sources affect host configuration, see <xref:fundamentals/index#host>.

## Other configuration

This topic only pertains to *app configuration*. Other aspects of running and hosting ASP.NET Core apps are configured using configuration files not covered in this topic:

* *launch.json*/*launchSettings.json* are tooling configuration files for the Development environment, described:
  * In <xref:fundamentals/environments#development>.
  * Across the documentation set where the files are used to configure ASP.NET Core apps for Development scenarios.
* *web.config* is a server configuration file, described in the following topics:
  * <xref:host-and-deploy/iis/index>
  * <xref:host-and-deploy/aspnet-core-module>

For more information on migrating app configuration from earlier versions of ASP.NET, see <xref:migration/proper-to-2x/index#store-configurations>.

## Default configuration

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

## Security

Adopt the following practices to secure sensitive configuration data:

* Never store passwords or other sensitive data in configuration provider code or in plain text configuration files.
* Don't use production secrets in development or test environments.
* Specify secrets outside of the project so that they can't be accidentally committed to a source code repository.

For more information, see the following topics:

* <xref:fundamentals/environments>
* <xref:security/app-secrets>: Includes advice on using environment variables to store sensitive data. The Secret Manager uses the File Configuration Provider to store user secrets in a JSON file on the local system. The File Configuration Provider is described later in this topic.

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

<xref:Microsoft.Extensions.Configuration.IConfiguration> is available in the app's [dependency injection (DI)](xref:fundamentals/dependency-injection) container. <xref:Microsoft.Extensions.Configuration.IConfiguration> can be injected into a Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> or MVC <xref:Microsoft.AspNetCore.Mvc.Controller> to obtain configuration for the class.

In the following examples, the `_config` field is used to access configuration values:

```csharp
public class IndexModel : PageModel
{
    private readonly IConfiguration _config;

    public IndexModel(IConfiguration config)
    {
        _config = config;
    }
}
```

```csharp
public class HomeController : Controller
{
    private readonly IConfiguration _config;

    public HomeController(IConfiguration config)
    {
        _config = config;
    }
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
  * In Azure Key Vault, hierarchical keys use `--` (two dashes) as a separator. Write code to replace the dashes with a colon when the secrets are loaded into the app's configuration.
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

Configuration sources are read in the order that their configuration providers are specified at startup. The configuration providers described in this topic are described in alphabetical order, not in the order that the code arranges them. Order configuration providers in code to suit the priorities for the underlying configuration sources that the app requires.

A typical sequence of configuration providers is:

1. Files (*appsettings.json*, *appsettings.{Environment}.json*, where `{Environment}` is the app's current hosting environment)
1. [Azure Key Vault](xref:security/key-vault-configuration)
1. [User secrets (Secret Manager)](xref:security/app-secrets) (Development environment only)
1. Environment variables
1. Command-line arguments

A common practice is to position the Command-line Configuration Provider last in a series of providers to allow command-line arguments to override configuration set by the other providers.

The preceding sequence of providers is used when a new host builder is initialized with `CreateDefaultBuilder`. For more information, see the [Default configuration](#default-configuration) section.

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

## ConfigureAppConfiguration

Call `ConfigureAppConfiguration` when building the host to specify the app's configuration providers in addition to those added automatically by `CreateDefaultBuilder`:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=20)]

### Override previous configuration with command-line arguments

To provide app configuration that can be overridden with command-line arguments, call `AddCommandLine` last:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    // Call other providers here
    config.AddCommandLine(args);
})
```

### Remove providers added by CreateDefaultBuilder

To remove the providers added by `CreateDefaultBuilder`, call [Clear](/dotnet/api/system.collections.generic.icollection-1.clear) on the [IConfigurationBuilder.Sources](xref:Microsoft.Extensions.Configuration.IConfigurationBuilder.Sources) first:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.Sources.Clear();
    // Add providers here
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

Switch mappings allow key name replacement logic. When manually building configuration with a <xref:Microsoft.Extensions.Configuration.ConfigurationBuilder>, provide a dictionary of switch replacements to the <xref:Microsoft.Extensions.Configuration.CommandLineConfigurationExtensions.AddCommandLine*> method.

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

[Azure App Service](https://azure.microsoft.com/services/app-service/) permits setting environment variables in the Azure Portal that can override app configuration using the Environment Variables Configuration Provider. For more information, see [Azure Apps: Override app configuration using the Azure Portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal).

`AddEnvironmentVariables` is used to load environment variables prefixed with `ASPNETCORE_` for [host configuration](#host-versus-app-configuration) when a new host builder is initialized with the [Web Host](xref:fundamentals/host/web-host) and `CreateDefaultBuilder` is called. For more information, see the [Default configuration](#default-configuration) section.

`CreateDefaultBuilder` also loads:

* App configuration from unprefixed environment variables by calling `AddEnvironmentVariables` without a prefix.
* Optional configuration from *appsettings.json* and *appsettings.{Environment}.json* files.
* [User secrets (Secret Manager)](xref:security/app-secrets) in the Development environment.
* Command-line arguments.

The Environment Variables Configuration Provider is called after configuration is established from user secrets and *appsettings* files. Calling the provider in this position allows the environment variables read at runtime to override configuration set by user secrets and *appsettings* files.

To provide app configuration from additional environment variables, call the app's additional providers in `ConfigureAppConfiguration` and call `AddEnvironmentVariables` with the prefix:

```csharp
.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddEnvironmentVariables(prefix: "PREFIX_");
})
```

Call `AddEnvironmentVariables` last to allow environment variables with the given prefix to override values from other providers.

**Example**

The sample app takes advantage of the static convenience method `CreateDefaultBuilder` to build the host, which includes a call to `AddEnvironmentVariables`.

1. Run the sample app. Open a browser to the app at `http://localhost:5000`.
1. Observe that the output contains the key-value pair for the environment variable `ENVIRONMENT`. The value reflects the environment in which the app is running, typically `Development` when running locally.

To keep the list of environment variables rendered by the app short, the app filters environment variables. See the sample app's *Pages/Index.cshtml.cs* file.

To expose all of the environment variables available to the app, change the `FilteredConfiguration` in *Pages/Index.cshtml.cs* to the following:

```csharp
FilteredConfiguration = _config.AsEnumerable();
```

### Prefixes

Environment variables loaded into the app's configuration are filtered when supplying a prefix to the `AddEnvironmentVariables` method. For example, to filter environment variables on the prefix `CUSTOM_`, supply the prefix to the configuration provider:

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
| `CUSTOMCONNSTR_{KEY} `   | `ConnectionStrings:{KEY}`   | Configuration entry not created.                                                |
| `MYSQLCONNSTR_{KEY}`     | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `MySql.Data.MySqlClient` |
| `SQLAZURECONNSTR_{KEY}`  | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |
| `SQLCONNSTR_{KEY}`       | `ConnectionStrings:{KEY}`   | Key: `ConnectionStrings:{KEY}_ProviderName`:<br>Value: `System.Data.SqlClient`  |

**Example**

A custom connection string environment variable is created on the server:

* Name: `CUSTOMCONNSTR_ReleaseDB`
* Value: `Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True`

If `IConfiguration` is injected and assigned to a field named `_config`, read the value:

```csharp
_config["ConnectionStrings:ReleaseDB"]
```

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

`AddJsonFile` is automatically called twice when a new host builder is initialized with `CreateDefaultBuilder`. The method is called to load configuration from:

* *appsettings.json*: This file is read first. The environment version of the file can override the values provided by the *appsettings.json* file.
* *appsettings.{Environment}.json*: The environment version of the file is loaded based on the [IHostingEnvironment.EnvironmentName](xref:Microsoft.Extensions.Hosting.IHostingEnvironment.EnvironmentName*).

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

The sample app takes advantage of the static convenience method `CreateDefaultBuilder` to build the host, which includes two calls to `AddJsonFile`:

* The first call to `AddJsonFile` loads configuration from *appsettings.json*:

  [!code-json[](index/samples/2.x/ConfigurationSample/appsettings.json)]

* The second call to `AddJsonFile` loads configuration from *appsettings.{Environment}.json*. For *appsettings.Development.json* in the sample app, the following file is loaded:

  [!code-json[](index/samples/2.x/ConfigurationSample/appsettings.Development.json)]

1. Run the sample app. Open a browser to the app at `http://localhost:5000`.
1. The output contains key-value pairs for the configuration based on the app's environment. The log level for the key `Logging:LogLevel:Default` is `Debug` when running the app in the Development environment.
1. Run the sample app again in the Production environment:
   1. Open the *Properties/launchSettings.json* file.
   1. In the `ConfigurationSample` profile, change the value of the `ASPNETCORE_ENVIRONMENT` environment variable to `Production`.
   1. Save the file and run the app with `dotnet run` in a command shell.
1. The settings in the *appsettings.Development.json* no longer override the settings in *appsettings.json*. The log level for the key `Logging:LogLevel:Default` is `Warning`.

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

[`ConfigurationBinder.GetValue<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.GetValue*) extracts a single value from configuration with a specified key and converts it to the specified noncollection type. An overload accepts a default value.

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

## Bind to an object graph

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*> is capable of binding an entire POCO object graph. As with binding a simple object, only public read/write properties are bound.

The sample contains a `TvShow` model whose object graph includes `Metadata` and `Actors` classes (*Models/TvShow.cs*):

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/TvShow.cs?name=snippet1)]

The sample app has a *tvshow.xml* file containing the configuration data:

[!code-xml[](index/samples/2.x/ConfigurationSample/tvshow.xml)]

Configuration is bound to the entire `TvShow` object graph with the `Bind` method. The bound instance is assigned to a property for rendering:

```csharp
var tvShow = new TvShow();
_config.GetSection("tvshow").Bind(tvShow);
TvShow = tvShow;
```

[`ConfigurationBinder.Get<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) binds and returns the specified type. `Get<T>` is more convenient than using `Bind`. The following code shows how to use `Get<T>` with the preceding example:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_tvshow)]

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

[!code-csharp[](index/samples/2.x/ConfigurationSample/Program.cs?name=snippet_Program&highlight=5-12,22)]

The array skips a value for index &num;3. The configuration binder isn't capable of binding null values or creating null entries in bound objects, which becomes clear in a moment when the result of binding this array to an object is demonstrated.

In the sample app, a POCO class is available to hold the bound configuration data:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/ArrayExample.cs?name=snippet1)]

The configuration data is bound to the object:

```csharp
var arrayExample = new ArrayExample();
_config.GetSection("array").Bind(arrayExample);
```

[`ConfigurationBinder.Get<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) syntax can also be used, which results in more compact code:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Pages/Index.cshtml.cs?name=snippet_array)]

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

[!code-json[](index/samples/2.x/ConfigurationSample/json_array.json)]

The JSON Configuration Provider reads the configuration data into the following key-value pairs:

| Key                     | Value  |
| ----------------------- | :----: |
| json_array:key          | valueA |
| json_array:subsection:0 | valueB |
| json_array:subsection:1 | valueC |
| json_array:subsection:2 | valueD |

In the sample app, the following POCO class is available to bind the configuration key-value pairs:

[!code-csharp[](index/samples/2.x/ConfigurationSample/Models/JsonArrayExample.cs?name=snippet1)]

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

::: moniker-end
