---
title: Configuration in ASP.NET Core
author: rick-anderson
description: Use the Configuration API to configure an ASP.NET Core app by multiple methods.
keywords: ASP.NET Core,configuration,JSON,config,ini,XML,provider
ms.author: riande
manager: wpickett
ms.date: 11/01/2017
ms.topic: article
ms.assetid: b3a5984d-e172-42eb-8a48-547e4acb6806
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/configuration
---
# Configure an ASP.NET Core App

[Rick Anderson](https://twitter.com/RickAndMSFT), [Mark Michaelis](http://intellitect.com/author/mark-michaelis/), [Steve Smith](https://ardalis.com/), [Daniel Roth](https://github.com/danroth27), and [Luke Latham](https://github.com/guardrex)

The Configuration API provides a way to configure an ASP.NET Core web app based on a list of name-value pairs. Configuration is read at runtime from multiple sources. You can group these name-value pairs into a multi-level hierarchy. 

There are configuration providers for:

* File formats (INI, JSON, and XML)
* Command-line arguments
* Environment variables
* In-memory .NET objects
* An encrypted user store
* [Azure Key Vault](xref:security/key-vault-configuration)
* Custom providers (installed or created)
snapshot option1
Each configuration value maps to a string key. There's built-in binding support to deserialize settings into a custom [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object) object (a simple .NET class with properties).

[View or download sample code](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Simple configuration

The following console app uses the JSON configuration provider:

[!code-csharp[Main](configuration/sample/ConfigJson/Program.cs)]

The app reads and displays the following configuration settings:

[!code-json[Main](configuration/sample/ConfigJson/appsettings.json)]

Configuration consists of a hierarchical list of name-value pairs in which the nodes are separated by a colon. To retrieve a value, access the `Configuration` indexer with the corresponding item's key:

```csharp
Console.WriteLine($"option1 = {Configuration["subsection:suboption1"]}");
```

To work with arrays in JSON-formatted configuration sources, use an array index as part of the colon-separated string. The following example gets the name of the first item in the preceding `wizards` array:

```csharp
Console.Write($"{Configuration["wizards:0:Name"]}, ");
```

Name-value pairs written to the built-in `Configuration` providers are **not** persisted. However, you can create a custom provider that saves values. See [custom configuration provider](xref:fundamentals/configuration#custom-config-providers).

The preceding sample uses the configuration indexer to read values. To access configuration outside of `Startup`, use the *options pattern*. The *options pattern* is [described later in this article](xref:fundamentals/configuration#options).

It's typical to have different configuration settings for different environments, for example, development, testing, and production. The `CreateDefaultBuilder` extension method in an ASP.NET Core 2.x app (or using `AddJsonFile` and `AddEnvironmentVariables` directly in an ASP.NET Core 1.x app) adds configuration providers for reading JSON files and system configuration sources:

* *appsettings.json*
* *appsettings.\<EnvironmentName>.json*
* Environment variables

See [AddJsonFile](/dotnet/api/microsoft.extensions.configuration.jsonconfigurationextensions) for an explanation of the parameters. `reloadOnChange` is only supported in ASP.NET Core 1.1 and later. 

Configuration sources are read in the order that they're specified. In the code above, the environment variables are read last. Any configuration values set through the environment replace those set in the two previous providers.

The environment is typically set to `Development`, `Staging`, or `Production`. See [Working with multiple environments](xref:fundamentals/environments) for more information.

Configuration considerations:

* `IOptionsSnapshot` can reload configuration data when it changes. See [IOptionsSnapshot](#reloading-configuration-data-with-ioptionssnapshot-example-5) for more information.
* Configuration keys are case insensitive.
* Specify environment variables last so that the local environment can override settings in deployed configuration files.
* **Never** store passwords or other sensitive data in configuration provider code or in plain text configuration files. Don't use production secrets in your development or test environments. Instead, specify secrets outside of the project so that they can't be accidentally committed to your repository. Learn more about [working with multiple environments](xref:fundamentals/environments) and managing [safe storage of app secrets during development](xref:security/app-secrets).
* If a colon (`:`) can't be used in environment variables on your system, replace the colon (`:`) with a double-underscore (`__`).

## Options

The options pattern uses options classes to represent groups of related settings. When configuration settings are isolated by feature into separate options classes, the app adheres to two important software engineering principles:

* The [Interface Segregation Principle (ISP)](http://deviq.com/interface-segregation-principle/): Features (classes) that depend on configuration settings depend only on the configuration settings that they use.
* [Separation of Concerns](http://deviq.com/separation-of-concerns/): Settings for different parts of the app aren't dependent or coupled to one another.

### Basic options configuration (Example \#1)

An options class must be non-abstract with a public parameterless constructor. The following class, `MyOptions`, has two properties, `Option1` and `Option2`. Setting default values is optional, but the class constructor in the following example sets the default value of `Option1`. `Option2` has a default value set by initializing the property directly (*Models/MyOptions.cs*):

[!code-csharp[Main](configuration/sample/UsingOptions/Models/MyOptions.cs?name=snippet1)]

The `MyOptions` class is added to the service container with [IConfigureOptions&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.iconfigureoptions-1) and bound to configuration (*Startup.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Startup.cs?name=snippet1&highlight=16-17)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Startup.cs?name=snippet_Example1)]

<!--The following [controller](../mvc/controllers/index.md) uses [constructor Dependency Injection](xref:fundamentals/dependency-injection#what-is-dependency-injection) on [`IOptions<TOptions>`](/dotnet/api/Microsoft.Extensions.Options.IOptions-1) to access settings (*Pages/Index.cshtml.cs*):-->
The following page model uses [constructor dependency injection](xref:fundamentals/dependency-injection#what-is-dependency-injection) with [IOptions&lt;TOptions&gt;](/dotnet/api/Microsoft.Extensions.Options.IOptions-1) to access the settings (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Controllers/HomeController.cs?name=snippet1)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=1)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=2,8)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=1)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example1)]

The sample's *appsettings.json* file specifies values for `option1` and `option2`:

[!code-json[Main](configuration/sample/UsingOptions/appsettings.json)]

When the app is run, the page model's `OnGet` method returns a string showing the option class values:

```html
option1 = value1_from_json, option2 = -1
```

### Configuring simple options with a delegate (Example \#2)

Use a delegate to set options values. The sample app uses the `MyOptionsWithDelegateConfig` class (*Models/MyOptionsWithDelegateConfig.cs*):

[!code-csharp[Main](configuration/sample/UsingOptions/Models/MyOptionsWithDelegateConfig.cs?name=snippet1)]

In the following code, a second `IConfigureOptions<TOptions>` service is added to the service container. It uses a delegate to configure the binding with `MyOptionsWithDelegateConfig` (*Startup.cs*):

[!code-csharp[Main](configuration/sample/UsingOptions/Startup.cs?name=snippet_Example2)]

*Index.cshtml.cs*:

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=2)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=3,9)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=2)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example2)]

You can add multiple configuration providers. Configuration providers are available in NuGet packages. They're applied in order that they're registered.

Each call to [Configure&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.iconfigureoptions-1.configure) adds an `IConfigureOptions<TOptions>` service to the service container. In the preceding example, the values of `Option1` and `Option2` are both specified in *appsettings.json*, but the values of `Option1` and `Option2` are overridden by the configured delegate.

When more than one configuration service is enabled, the last configuration source specified *wins* and sets the configuration value. When the app is run, the page model's `OnGet` method returns a string showing the option class values:

```html
delegate_option1 = value1_configured_by_delgate, delegate_option2 = 500
```
<!-- HOLD
> [!NOTE]
> Configure the sample app to show overriding a configuration value with a delegate:
>
> Deactivate the `Startup` class in *Startup.cs*, *Starup3.cs*, and *Starup4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup2.cs*, which activates the `Startup` class in the *Startup2.cs* file.
-->
### Sub-options configuration (Example \#3)

Apps should create options classes that pertain to specific feature groups (classes) in the app. Parts of the app that require configuration values should only have access to the configuration values that they use.

When binding options to configuration, each property in the options type is bound to a configuration key of the form `property[:sub-property:]`. For example, the `MyOptions.Option1` property is bound to the key `Option1`, which is read from the `option1` property in *appsettings.json*.

In the following code, a third `IConfigureOptions<TOptions>` service is added to the service container. It binds `MySubOptions` to the section `subsection` of the *appsettings.json* file (*Startup.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Startup3.cs?name=snippet1&highlight=15-16)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Startup.cs?name=snippet_Example3)]

The `GetSection` extension method requires the [Microsoft.Extensions.Options.ConfigurationExtensions](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions/) NuGet package. If the app already uses the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) metapackage, the package is automatically included.

The sample's *appsettings.json* file defines a `subsection` member with keys for `suboption1` and `suboption2`:

[!code-json[Main](configuration/sample/UsingOptions/appsettings.json?highlight=4-7)]

The `MySubOptions` class defines properties, `SubOption1` and `SubOption2`, to hold the sub-option values (*Models/MySubOptions.cs*):

[!code-csharp[Main](configuration/sample/UsingOptions/Models/MySubOptions.cs?name=snippet1)]

The page model's `OnGet` method returns a string with the sub-option values (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Controllers/HomeController2.cs?name=snippet1)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=3)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=4,10)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=3)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example3)]

When the app is run, the `OnGet` method returns a string showing the sub-option class values:

```html
subOption1 = subvalue1_from_json, subOption2 = 200
```
<!-- HOLD
> [!NOTE]
> Configure the sample app to demonstrate the use of a sub-options class:
>
> To enable the `Startup` class in *Startup3.cs*, deactivate the `Startup` classes in *Startup.cs*, *Startup2.cs*, and *Startup4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup3.cs*, which activates the `Startup` class in the *Startup3.cs* file.
>
> To enable the Home controller in *HomeController2.cs*, deactivate the `HomeController` class in *HomeController.cs*, *HomeController3.cs*, *HomeController4.cs*, and *HomeController5.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *HomeController2.cs*, which activates the `HomeController` class in the *HomeController2.cs* file.
-->
### Options provided by a view model or with direct view injection (Example \#4)

Options can also be supplied in a view model or by injecting `IOptions<TOptions>` directly into a view (*Pages/Index.cshtml.cs*):

<!--[!code-cshtml[Main](configuration/sample/UsingOptions/Views/Home/Index.cshtml?highlight=3-4,16-17,20-21)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=1)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=2,8)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=4)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example4)]

For direct injection, inject `IOptions<MyOptions>` with an `@inject` directive:

[!code-cshtml[Main](configuration/sample/UsingOptions/Pages/Index.cshtml?range=1-10&highlight=5)]

When the app is run, the option values are shown in the rendered page:

![Options values Option1: value1_from_json and Option2: -1 are loaded from the model and by injection into the view.](configuration/_static/view.png)
<!-- HOLD
> [!NOTE]
> Configure the sample app to show options provided by the view model or by direct injection into the view:
>
> To enable the `Startup` class in *Startup.cs*, deactivate the `Startup` classes in *Startup2.cs*, *Startup3.cs*, and *Startup4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup.cs*, which activates the `Startup` class in the *Startup.cs* file.
>
> To enable the Home controller in *HomeController3.cs*, deactivate the `HomeController` class in *HomeController.cs*, *HomeController2.cs*, *HomeController4.cs*, and *HomeController5.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *HomeController3.cs*, which activates the `HomeController` class in the *HomeController3.cs* file.
-->
### Reloading configuration data with IOptionsSnapshot (Example \#5)

*Requires ASP.NET Core 1.1 or later.*

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[IOptionsSnapshot](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1) supports reloading configuration data with minimal processing overhead when the configuration file changes. Using `IOptionsSnapshot` with `reloadOnChange: true` set for a configuration file provider, options are bound to `IConfiguration` and reloaded per request and cached for the lifetime of the request.

# [ASP.NET Core 1.1](#tab/aspnetcore11)

[IOptionsSnapshot](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1) supports reloading configuration data with minimal processing overhead when the configuration file changes. Using `IOptionsSnapshot` with `reloadOnChange: true` set for a configuration file provider, options are bound to `IConfiguration` and reloaded when the configuration file is changed.

---

The following example demonstrates how a new `IOptionsSnapshot` is created after *appsettings.json* changes (*Pages/Index.cshtml.cs*). Multiple requests to the server return constant values provided by the *appsettings.json* file until the file is changed and configuration reloads.

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Controllers/HomeController4.cs?name=snippet1&highlight=5)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=4)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=5,11)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=5)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example5)]
<!-- HOLD
> [!NOTE]
> Configure the sample app to show `IOptionsSnapshot` behavior:
>
> Enable the `Startup` class in *Startup.cs*. Deactivate the `Startup` classes in *Startup2.cs*, *Startup3.cs*, and *Startup4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup.cs*, which activates the `Startup` class in the *Startup.cs* file.
>
> To enable the Home controller in *HomeController4.cs*, deactivate the `HomeController` class in *HomeController.cs*, *HomeController2.cs*, *HomeController3.cs*, and *HomeController5.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *HomeController4.cs*, which activates the `HomeController` class in the *HomeController4.cs* file.
-->
The following image shows the initial `option1` and `option2` values loaded from the *appsettings.json* file:

```html
snapshot option1 = value1_from_json, snapshot option2 = -1
```

Change the values in the *appsettings.json* file to `value1_from_json UPDATED` and `200`. Save the *appsettings.json* file. Refresh the browser to see that the options values are updated:

```html
snapshot option1 = value1_from_json UPDATED, snapshot option2 = 200
```

### Named options support with IConfigureNamedOptions (Example \#6)

*Requires ASP.NET Core 2.0 or later.*

*Named options* support allows the app to distinguish between named options configurations. In the sample app, named options are declared with the [ConfigureNamedOptions&lt;TOptions&gt;.Configure](/dotnet/api/microsoft.extensions.options.configurenamedoptions-1.configure) method (*Startup.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Startup4.cs?name=snippet1&highlight=9,14-17)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Startup.cs?name=snippet_Example6)]

The sample app accesses the named options with [IOptionsSnapshot&lt;TOptions&gt;.Get](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1.get) (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](configuration/sample/UsingOptions/Controllers/HomeController5.cs?name=snippet1&highlight=8-9)]-->
[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet2&highlight=6,12-13)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet3&highlight=6)]

[!code-csharp[Main](configuration/sample/UsingOptions/Pages/Index.cshtml.cs?name=snippet_Example6)]

Running the sample app, the named options are returned:

```html
named_options_1: option1 = value1_from_json, option2 = -1
named_options_2: option1 = named_options_2_value1_from_action, option2 = 5
```

`named_options_1` values are provided from configuration, which are loaded from the *appsettings.json* file. `named_options_2` values are provided by the `named_options_2` delegate in `ConfigureServices` for `Option1` and the default value for `Option2` provided by the `MyOptions` class.
<!-- HOLD
> [!NOTE]
> Configure the sample app to show named options behavior:
>
> Enable the `Startup4` class in *Startup4.cs*. Deactivate the `Startup` classes in *Startup.cs*, *Startup2.cs*, and *Startup3.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup4.cs*, which activates the `Startup` class in the *Startup4.cs* file.
>
> To enable the Home controller in *HomeController5.cs*, deactivate the `HomeController` class in *HomeController.cs*, *HomeController2.cs*, *HomeController3.cs*, and *HomeController4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *HomeController5.cs*, which activates the `HomeController` class in the *HomeController5.cs* file.
-->
Configure all named options instances with the [OptionsServiceCollectionExtensions.ConfigureAll](/dotnet/api/microsoft.extensions.dependencyinjection.optionsservicecollectionextensions.configureall) method. The following code configures `Option1` for all named configuration instances with a common value. Add the following code manually to the `Configure` method of *Startup.cs*:

```csharp
services.ConfigureAll<MyOptions>(myOptions => 
{
    myOptions.Option1 = "ConfigureAll replacement value";
});
```

Running the sample app after adding the code produces the following result:

```html
named_options_1: option1 = ConfigureAll replacement value, option2 = -1
named_options_2: option1 = ConfigureAll replacement value, option2 = 5
```

### Configuring options after configuration with IPostConfigureOptions

*Requires ASP.NET Core 2.0 or later.*

Set post configuration with [IPostConfigureOptions&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ipostconfigureoptions-1) to run after all [IConfigureOptions&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.iconfigureoptions-1) configuration occurs:

```csharp
services.PostConfigure<MyOptions>(myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

[PostConfigure&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ipostconfigureoptions-1.postconfigure) is available to post-configure named options:

```csharp
services.PostConfigure<MyOptions>("named_options_1", myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

Use [PostConfigureAll&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.dependencyinjection.optionsservicecollectionextensions.postconfigureall) to post-configure all named configuration instances:

```csharp
services.PostConfigureAll<MyOptions>("named_options_1", myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

### Options factory, monitoring, and cache

New in ASP.NET Core 2.0, [IOptionsFactory&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ioptionsfactory-1) is responsible for creating new options instances. It has a single [Create](/dotnet/api/microsoft.extensions.options.ioptionsfactory-1.create) method. The default implementation takes all registered `IConfigureOptions` and `IPostConfigureOptions` and runs all the configures first, followed by the post-configures. It distinguishes between `IConfigureNamedOptions` and `IConfigureOptions` and only calls the appropriate interface.

[IOptionsMonitor](/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1) is used for notifications when `TOptions` instances change. `IOptionsMonitor` supports reloadable options, change notifications, and `IPostConfigureOptions`.

New in ASP.NET Core 2.0, [IOptionsMonitorCache&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1) is used by `IOptionsMonitor` to cache `TOptions` instances. The `IOptionsMonitorCache` invalidates options instances in the monitor so that the value is recomputed ([TryRemove](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.tryremove)). Values can be manually introduced as well with [TryAdd](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.tryadd). The [Clear](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.clear) method is used when all named instances should be recreated on demand.

## In-memory provider and binding to a POCO class

The following sample shows how to use the in-memory provider and bind to a class:

[!code-csharp[Main](configuration/sample/InMemory/Program.cs)]

Configuration values are returned as strings, but binding enables the construction of objects. Binding allows you to retrieve POCO objects or even entire object graphs. The following sample shows how to bind to `MyWindow` and use the options pattern with a ASP.NET Core MVC app:

[!code-csharp[Main](configuration/sample/WebConfigBind/MyWindow.cs)]

[!code-json[Main](configuration/sample/WebConfigBind/appsettings.json)]

Bind the custom class in `ConfigureServices` when building the host:

[!code-csharp[Main](configuration/sample/WebConfigBind/Program.cs?name=snippet1&highlight=3-4)]

Display the settings from the `HomeController`:

[!code-csharp[Main](configuration/sample/WebConfigBind/Controllers/HomeController.cs)]

### GetValue

The following sample demonstrates the [GetValue&lt;T&gt;](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.configurationbinder#Microsoft_Extensions_Configuration_ConfigurationBinder_GetValue_Microsoft_Extensions_Configuration_IConfiguration_System_Type_System_String_System_Object_) extension method:

[!code-csharp[Main](configuration/sample/InMemoryGetValue/Program.cs?highlight=27-29)]

The ConfigurationBinder's `GetValue<T>` method allows you to specify a default value (80 in the sample). `GetValue<T>` is for simple scenarios and does not bind to entire sections. `GetValue<T>` gets scalar values from `GetSection(key).Value` converted to a specific type.

## Bind to an object graph

You can recursively bind to each object in a class. Consider the following `AppOptions` class:

[!code-csharp[Main](configuration/sample/ObjectGraph/AppOptions.cs)]

The following sample binds to the `AppOptions` class:

[!code-csharp[Main](configuration/sample/ObjectGraph/Program.cs?highlight=15-16)]

**ASP.NET Core 1.1** and higher can use  `Get<T>`, which works with entire sections. `Get<T>` can be more convenient than using `Bind`. The following code shows how to use `Get<T>` with the sample above:

```csharp
var appConfig = config.GetSection("App").Get<AppOptions>();
```

Using the following *appsettings.json* file:

[!code-json[Main](configuration/sample/ObjectGraph/appsettings.json)]

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

    var options = new AppOptions();
    config.GetSection("App").Bind(options);

    Assert.Equal("Rick", options.Profile.Machine);
    Assert.Equal(11, options.Window.Height);
    Assert.Equal(11, options.Window.Width);
    Assert.Equal("connectionstring", options.Connection.Value);
}
```

<a name="custom-config-providers"></a>

## Create an Entity Framework custom provider

In this section, a basic configuration provider that reads name-value pairs from a database using EF is created. 

Define a `ConfigurationValue` entity for storing configuration values in the database:

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/ConfigurationValue.cs)]

Add a `ConfigurationContext` to store and access the configured values:

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/ConfigurationContext.cs?name=snippet1)]

Create a class that implements [IConfigurationSource](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.iconfigurationsource):

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/EntityFrameworkConfigurationSource.cs?highlight=7)]

Create the custom configuration provider by inheriting from [ConfigurationProvider](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.configurationprovider).  The configuration provider initializes the database when it's empty:

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/EntityFrameworkConfigurationProvider.cs?highlight=9,18-31,38-39)]

The highlighted values from the database ("value_from_ef_1" and "value_from_ef_2") are displayed when the sample is run.

You can add an `EFConfigSource` extension method for adding the configuration source:

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/EntityFrameworkExtensions.cs?highlight=12)]

The following code shows how to use the custom `EFConfigProvider`:

[!code-csharp[Main](configuration/sample/CustomConfigurationProvider/Program.cs?highlight=21-26)]

Note the sample adds the custom `EFConfigProvider` after the JSON provider, so any settings from the database will override settings from the *appsettings.json* file.

Using the following *appsettings.json* file:

[!code-json[Main](configuration/sample/CustomConfigurationProvider/appsettings.json)]

The following is displayed:

```console
key1=value_from_ef_1
key2=value_from_ef_2
key3=value_from_json_3
```

## CommandLine configuration provider

The [CommandLine configuration provider](/aspnet/core/api/microsoft.extensions.configuration.commandline.commandlineconfigurationprovider) receives command-line argument key-value pairs for configuration at runtime.

[View or download the CommandLine configuration sample](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/sample/CommandLine)

### Setup and use the CommandLine configuration provider

# [Basic Configuration](#tab/basicconfiguration)

To activate command-line configuration, call the `AddCommandLine` extension method on an instance of [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder):

[!code-csharp[Main](configuration/sample_snapshot/CommandLine/Program.cs?highlight=18,21)]

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

[!code-csharp[Main](configuration/sample_snapshot/CommandLine/Program2.cs?range=11-16&highlight=1,5)]

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

Typical ASP.NET Core 2.x apps use the static convenience method `CreateDefaultBuilder` to build the host:

[!code-csharp[Main](configuration/sample_snapshot/Program.cs?highlight=12)]

`CreateDefaultBuilder` loads optional configuration from *appsettings.json*, *appsettings.{Environment}.json*, [user secrets](xref:security/app-secrets) (in the `Development` environment), environment variables, and command-line arguments. The CommandLine configuration provider is called last. Calling the provider last allows the command-line arguments passed at runtime to override configuration set by the other configuration providers called earlier.

Note that for *appsettings* files that `reloadOnChange` is enabled. Command-line arguments are overridden if a matching configuration value in an *appsettings* file is changed after the app starts.

> [!NOTE]
> As an alternative to using the `CreateDefaultBuilder` method, creating a host using [WebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilder) and manually building configuration with [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder) is supported in ASP.NET Core 2.x. See the ASP.NET Core 1.x tab for more information.

# [ASP.NET Core 1.x](#tab/aspnetcore1x)

Create a [ConfigurationBuilder](/api/microsoft.extensions.configuration.configurationbuilder) and call the `AddCommandLine` method to use the CommandLine configuration provider. Calling the provider last allows the command-line arguments passed at runtime to override configuration set by the other configuration providers called earlier. Apply the configuration to [WebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.webhostbuilder) with the `UseConfiguration` method:

[!code-csharp[Main](configuration/sample_snapshot/CommandLine/Program2.cs?highlight=11,15,19)]

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

[!code-csharp[Main](configuration/sample/CommandLine/Program.cs?highlight=10-19,32)]

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

* [Working with Multiple Environments](environments.md)
* [Safe storage of app secrets during development](../security/app-secrets.md)
* [Hosting in ASP.NET Core](xref:fundamentals/hosting)
* [Dependency Injection](dependency-injection.md)
* [Azure Key Vault configuration provider](xref:security/key-vault-configuration)
