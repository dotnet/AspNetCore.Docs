---
uid: config-builder
title: Configuration Builders for ASP.NET
author: rick-anderson
description: Learn how to get configuration data from sources other than web.config
ms.author: riande
ms.date: 9/9/2018
ms.technology: aspnet
msc.type: content
---

# Configuration Builders for ASP.NET

Configuration Builders provide a mechanism for ASP.NET apps to get configuration values. 

Configuration Builders:

* Are a new feature of the .Net Framework, introduced in .Net 4.7.1.
* Are flexible.
* Provide a mechanism to get started reading configuration values.
* Address some of the basic needs of applications as they move into a container and cloud focused environment.

## Key/Value Configuration Builders

The most common usage of Configuration Builders is to provide a basic key/value replacement mechanism. Most of the configuration builders in this project are basic key/value builders. Applications can also use the Configuration Builder concept to construct complex configuration on the fly.

### Mode

The basic concept of these configuration builders is to draw on an external source of key/value information to populate parts of the configuration system that are key/value in nature. Specifically, the `appSettings` and `connectionStrings` sections receive special treatment from these key/value configuration builders. These builders can be set to run in three different modes:

* `Strict` - This is the default. In this mode, the configuration builder will only operate on well-known key/value-centric configuration sections. It will enumerate each key in the section, and if a matching key is found in the external source, it will replace the value in the resulting configuration section with the value from the	external source.
* `Greedy` - This mode is closely related to `Strict` mode, but instead of being limited to keys that already exist in the original configuration, the configuration builders will dump all key/value pairs from the external source into the resulting configuration section.
* `Expand` - This last mode operates on the raw xml before it gets parsed into a configuration section object. It can be thought of as a simple expansion of tokens in a string. Any part of the raw xml string that matches the pattern __`${token}`__ is a candidate for token expansion. If no corresponding value is found in the external source, then the token is left alone.

### Prefix handling

Because the .Net Framework configuration is complex and nested, and external key/value sources are by nature basic and flat, leveraging key prefixes can be useful. For example, if you want to inject both App Settings and Connection Strings into your configuration via environment variables, you could accomplish this in two ways. Use the `EnvironmentConfigBuilder` in the default `Strict` mode and make sure you have the appropriate key names already coded into your configuration file. __OR__ you could use two `EnvironmentConfigBuilder`s in `Greedy` mode with distinct prefixes so they can slurp up any setting or connection string you provide without needing to update the raw configuration file in advance. Like this:

```xml
<configBuilders>
  <builders>
    <add name="AS_Environment" mode="Greedy" prefix="AppSetting_" type="Microsoft.Configuration.ConfigurationBuilders.EnvironmentConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Environment" />
    <add name="CS_Environment" mode="Greedy" prefix="ConnStr_" type="Microsoft.Configuration.ConfigurationBuilders.EnvironmentConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Environment" />
  </builders>
</configBuilders>

<appSettings configBuilders="AS_Environment" />

<connectionStrings configBuilders="CS_Environment" />
```
This way the same flat key/value source can be used to populate configuration for two different sections.

### stripPrefix
A related setting that is common among all of these key/value builders is `stripPrefix`. The code above does a good job of separating app settings from connection
strings... but now all the keys in AppSettings start with "AppSetting_". Maybe this is fine for code you wrote. Chances are that prefix is better off stripped from the
key name before being inserted into AppSettings. `stripPrefix` is a simple boolean value, and accomplishes just that. Its default value is `false`.

### tokenPattern
The final setting that is shared between all KeyValueConfigBuilder-derived builders is `tokenPattern`. When describing the `Expand` behavior of these builders
above, it was mentioned that the raw xml is searched for tokens that look like __`${token}`__. This is done with a regular expression. `@"\$\{(\w+)\}"` to be exact.
The set of characters that matches `\w` is more strict than xml and many sources of configuration values allow, and some applications may need to allow more exotic characters
in their token names. Additionally there might be scenarios where the `${}` pattern is not acceptable.

`tokenPattern` allows developers to change the regex that is used for token matching. It is a simple string argument, and no validation is done to make sure it is
a well-formed non-dangerous regex - so use it wisely. The only real restriction is that is must contain a capture group. The entire regex must match the entire token,
and the first capture must be the token name to look up in the configuration source.

## Config Builders In This Project

### EnvironmentConfigBuilder

```xml
<add name="Environment"
    [mode|prefix|stripPrefix|tokenPattern]
    type="Microsoft.Configuration.ConfigurationBuilders.EnvironmentConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Environment" />
```
This is the simplest of the configuration builders. It draws its values from Environment, and it does not have any additional configuration options.
  * __NOTE:__ In a Windows container environment, variables set at run time are only injected into the EntryPoint process environment. 
  Applications that run as a service or a non-EntryPoint process will not pick up these variables unless they are otherwise injected through some mechanism in the container. For [IIS](https://github.com/Microsoft/iis-docker/pull/41)/[ASP.Net](https://github.com/Microsoft/aspnet-docker)-based
  containers, the current version of [ServiceMonitor.exe](https://github.com/Microsoft/iis-docker/pull/41) handles this in the *DefaultAppPool*  only. Other Windows-based container variants may need to develop their own injection mechanism for non-EntryPoint processes.

### UserSecretsConfigBuilder

```xml
<add name="UserSecrets"
    [mode|prefix|stripPrefix|tokenPattern]
    (userSecretsId="12345678-90AB-CDEF-1234-567890" | userSecretsFile="~\secrets.file")
    [optional="true"]
    type="Microsoft.Configuration.ConfigurationBuilders.UserSecretsConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.UserSecrets" />
```

To enable a feature similar to .Net Core's user secrets you can use this configuration builder. Microsoft is adding better secrets management in future releases
of Visual Studio, and this configuration builder will be a part of that plan. Web Applications are the initial target for this work in Visual Studio, but this
configuration builder can be used in any full-framework project if you specify your own secrets file. (Or define the 'UserSecretsId' property in your
project file and create the raw secrets file in the correct location for reading.) In order to keep external dependencies out of the picture, the
actual secret file will be xml formatted - though this should be considered an implementation detail, and the format should not be relied upon.
(If you need to share a secrets.json file with Core projects, you could consider using the `SimpleJsonConfigBuilder` below... but as with this
builder, the json format for Core secrets is technically an implementation detail subject to change as well.)

There are three additional configuration attributes for this configuration builder:
  * `userSecretsId` - This is the preferred method for identifying an xml secrets file. It works similar to .Net Core, which uses a 'UserSecretsId' project
  property to store this identifier. (The string does not have to be a Guid. Just unique. The VS "Manage User Secrets" experience produces a Guid.) With this
  attribute, the `UserSecretsConfigBuilder` will look in a well-known local location (%APPDATA%\Microsoft\UserSecrets\&lt;userSecretsId&gt;\secrets.xml in
  Windows environments) for a secrets file belonging to this identifier.
  * `userSecretsFile` - An optional attribute specifying the file containing the secrets. The '~' character can be used at the start to reference the app root.
  One of this attribute or the 'userSecretsId' attribute is required. If both are specified, 'userSecretsFile' takes precedence.
  * `optional` - A simple boolean to avoid throwing exceptions if the secrets file cannot be found. The default is `true`.

The next Visual Studio update will include "Manage User Secrets..." support for WebForms projects. When using this feature, Visual Studio will create an
empty secrets file outside of the solution folder and allow editing the raw content to add/remove secrets. This is similar to the .Net Core experience,
and currently exposes the format of the file - which as mentioned above - should be considered an implementation detail. A non-empty secrets file would look like this:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<root>
  <secrets ver="1.0">
    <secret name="secretFoo" value="valueBar" />
  </secrets>
</root>
```

### AzureKeyVaultConfigBuilder
```xml
<add name="AzureKeyVault"
    [mode|prefix|stripPrefix|tokenPattern]
    (vaultName="MyVaultName" |
     uri="https://MyVaultName.vault.azure.net")
    [connectionString="connection string"]
    [version="secrets version"]
    [preloadSecretNames="true"]
    type="Microsoft.Configuration.ConfigurationBuilders.AzureKeyVaultConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Azure" />
```

If your secrets are kept in Azure Key Vault, then this configuration builder is for you. There are three additional attributes for this configuration builder. The `vaultName` is required. The other attributes allow you some manual control about which vault to connect to, but are only necessary if the application is not running in an environment that works magically with `Microsoft.Azure.Services.AppAuthentication`. The Azure Services Authentication library is used to automatically pick up connection information from the execution environment if possible, but you can override that feature by providing a connection string instead.
  * `vaultName` - This is a required attribute. It specifies the name of the vault in your Azure subscription from which to read key/value pairs.
  * `connectionString` - A connection string usable by [AzureServiceTokenProvider](https://docs.microsoft.com/en-us/azure/key-vault/service-to-service-authentication#connection-string-support)
  * `uri` - Connect to other Key Vault providers with this attribute. If not specified, Azure is the assumed Vault provider. If the uri _is_specified, then `vaultName` is no longer a required parameter.
  * `version` - Azure Key Vault provides a versioning feature for secrets. If this is specified, the builder will only retrieve secrets matching this version.
  * `preloadSecretNames` - By default, this builder will query __all__ the key names in the key vault when it is initialized. If this is a concern, set
  this attribute to 'false', and secrets will be retrieved one at a time. This could also be useful if the vault allows "Get" access but not
  "List" access. (NOTE: Disabling preload is incompatible with Greedy mode.)

### KeyPerFileConfigBuilder

```xml
<add name="KeyPerFile"
    [mode|prefix|stripPrefix|tokenPattern]
	(directoryPath="PathToSourceDirectory")
    [ignorePrefix="ignore."]
    [keyDelimiter=":"]
    [optional="false"]
    type="Microsoft.Configuration.ConfigurationBuilders.KeyPerFileConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.KeyPerFile" />
```
This is a simple configuration builder that uses a directory's files as a source of values. A file's name is the key, and the contents are the value. This
configuration builder can be useful when running in an orchestrated container environment, as systems like Docker Swarm and Kubernetes provide 'secrets' to
their orchestrated windows containers in this key-per-file manner.
  * `directoryPath` - This is a required attribute. It specifies a path to the source directory to look in for values. Docker for Windows secrets
  are stored in the 'C:\ProgramData\Docker\secrets' directory by default.
  * `ignorePrefix` - Files that start with this prefix will be excluded. Defaults to "ignore.".
  * `keyDelimiter` - If specified, the configuration builder will traverse multiple levels of the directory, building key names up with this delimiter. If
  this value is left `null` however, the configuration builder only looks at the top level of the directory. `null` is the default.
  * `optional` - Specifies whether the configuration builder should cause errors if the source directory doesn't exist. The default is `false`.

### SimpleJsonConfigBuilder

```xml
<add name="SimpleJson"
    [mode|prefix|stripPrefix|tokenPattern]
    jsonFile="~\config.json"
    [optional="true"]
    [jsonMode="(Flat|Sectional)"]
    type="Microsoft.Configuration.ConfigurationBuilders.SimpleJsonConfigBuilder, Microsoft.Configuration.ConfigurationBuilders.Json" />
```

Because .Net Core projects can rely heavily on json files for configuration, it makes some sense to allow those same files to be used in full-framework
configuration as well. You can imagine that the hierarchical nature of json might enable some fantastic capabilities for building complex configuration sections.
But this configuration builder is meant to be a simple mapping from a flat key/value source into specific key/value areas of full-framework configuration. Thus its name
begins with 'Simple.' Think of the backing json file as a simple dictionary, rather than a complex hierarchical object.

(A multi-level hierarchical file can be used. This provider will simply 'flatten' the depth by appending the property name at each level using ':' as a delimiter.)

There are three additional attributes that can be used to configure this builder:
  * `jsonFile` - A required attribute specifying the json file to draw from. The '~' character can be used at the start to reference the app root.
  * `optional` - A simple boolean to avoid throwing exceptions if the json file cannot be found. The default is `true`.
  * `jsonMode` - `[Flat|Sectional]`. 'Flat' is the default.
    - This attribute requires a little more explanation. It says above to think of the json file as a single flat key/value source. This is the usual that applies to other key/value configuration builders like `EnvironmentConfigBuilder` and `AzureKeyVaultConfigBuilder` because those sources provide no other option. If the `SimpleJsonConfigBuilder` is configured in 'Sectional' mode, then the json file is conceptually divided just at the top level into multiple simple dictionaries. Each one of those dictionaries will only be applied to the configuration section that matches the top-level property name attached to them. For example:
```json
    {
        "appSettings" : {
            "setting1" : "value1",
            "setting2" : "value2",
            "complex" : {
                "setting1" : "complex:value1",
                "setting2" : "complex:value2",
            }
        },

        "connectionStrings" : {
            "mySpecialConnectionString" : "Dont_check_connection_information_into_source_control"
        }
    }
```

## Implementing More Key/Value Config Builders

If you don't see a configuration builder here that suits your needs, you can write your own. Referencing the `Basic` NuGet package for this project will get you the base upon which
all of these builders inherit. Most of the heavy-ish lifting and consistent behavior across key/value configuration builders comes from this base. Take a look at the code for more
detail, but in many cases implementing a custom key/value configuration builder in this same vein is as simple as inheriting the base, and implementing two simple methods.
```CSharp
using Microsoft.Configuration.ConfigurationBuilders;

public class CustomConfigBuilder : KeyValueConfigBuilder
{
    public override string GetValue(string key)
    {
        // Key lookup should be case-insensitive, because most key/value collections in .Net config sections are as well.
        return "Value for given key, or null.";
    }

    public override ICollection<KeyValuePair<string, string>> GetAllValues(string prefix)
    {
        // Populate the return collection a little more smartly. ;)
        return new Dictionary<string, string>() { { "one", "1" }, { "two", "2" } };
    }
}
```

## How to contribute

## Blog Posts
[Announcing .NET 4.7.1 Tools for the Cloud](https://blogs.msdn.microsoft.com/webdev/2017/11/17/announcing-net-4-7-1-tools-for-the-cloud/)  
[.Net Framework 4.7.1 ASP.NET and Configuration features](https://blogs.msdn.microsoft.com/dotnet/2017/09/13/net-framework-4-7-1-asp-net-and-configuration-features/)  
[Modern Configuration for ASP.NET 4.7.1 with ConfigurationBuilders](http://jeffreyfritz.com/2017/11/modern-configuration-for-asp-net-4-7-1-with-configurationbuilders/)  
[Service-to-service authentication to Azure Key Vault using .NET](https://docs.microsoft.com/en-us/azure/key-vault/service-to-service-authentication#connection-string-support)  
