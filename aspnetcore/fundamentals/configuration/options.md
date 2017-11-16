---
title: Options pattern in ASP.NET Core
author: guardrex
description: Discover how to use the options pattern to represent groups of related settings in ASP.NET Core apps.
ms.author: riande
manager: wpickett
ms.date: 11/15/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/configuration/options
---
# Options pattern in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

The options pattern uses options classes to represent groups of related settings. When configuration settings are isolated by feature into separate options classes, the app adheres to two important software engineering principles:

* The [Interface Segregation Principle (ISP)](http://deviq.com/interface-segregation-principle/): Features (classes) that depend on configuration settings depend only on the configuration settings that they use.
* [Separation of Concerns](http://deviq.com/separation-of-concerns/): Settings for different parts of the app aren't dependent or coupled to one another.

[View or download sample code](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Basic options configuration

Basic options configuration is demonstrated as Example \#1 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

An options class must be non-abstract with a public parameterless constructor. The following class, `MyOptions`, has two properties, `Option1` and `Option2`. Setting default values is optional, but the class constructor in the following example sets the default value of `Option1`. `Option2` has a default value set by initializing the property directly (*Models/MyOptions.cs*):

[!code-csharp[Main](options/sample/Models/MyOptions.cs?name=snippet1)]

The `MyOptions` class is added to the service container with [IConfigureOptions&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.iconfigureoptions-1) and bound to configuration (*Startup.cs*):

<!--[!code-csharp[Main](options/sample/Startup.cs?name=snippet1&highlight=16-17)]-->
[!code-csharp[Main](options/sample/Startup.cs?name=snippet_Example1)]

<!--The following [controller](xref:mvc/controllers/index) uses [constructor Dependency Injection](xref:fundamentals/dependency-injection#what-is-dependency-injection) on [`IOptions<TOptions>`](/dotnet/api/Microsoft.Extensions.Options.IOptions-1) to access settings (*Pages/Index.cshtml.cs*):-->
The following page model uses [constructor dependency injection](xref:fundamentals/dependency-injection#what-is-dependency-injection) with [IOptions&lt;TOptions&gt;](/dotnet/api/Microsoft.Extensions.Options.IOptions-1) to access the settings (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](options/sample/Controllers/HomeController.cs?name=snippet1)]-->
[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=9)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=2,8)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example1)]

The sample's *appsettings.json* file specifies values for `option1` and `option2`:

[!code-json[Main](options/sample/appsettings.json)]

When the app is run, the page model's `OnGet` method returns a string showing the option class values:

```html
option1 = value1_from_json, option2 = -1
```

## Configuring simple options with a delegate

Configuring simple options with a delegate is demonstrated as Example \#2 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

Use a delegate to set options values. The sample app uses the `MyOptionsWithDelegateConfig` class (*Models/MyOptionsWithDelegateConfig.cs*):

[!code-csharp[Main](options/sample/Models/MyOptionsWithDelegateConfig.cs?name=snippet1)]

In the following code, a second `IConfigureOptions<TOptions>` service is added to the service container. It uses a delegate to configure the binding with `MyOptionsWithDelegateConfig` (*Startup.cs*):

[!code-csharp[Main](options/sample/Startup.cs?name=snippet_Example2)]

*Index.cshtml.cs*:

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=10)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=3,9)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example2)]

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
## Sub-options configuration

Sub-options configuration is demonstrated as Example \#3 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

Apps should create options classes that pertain to specific feature groups (classes) in the app. Parts of the app that require configuration values should only have access to the configuration values that they use.

When binding options to configuration, each property in the options type is bound to a configuration key of the form `property[:sub-property:]`. For example, the `MyOptions.Option1` property is bound to the key `Option1`, which is read from the `option1` property in *appsettings.json*.

In the following code, a third `IConfigureOptions<TOptions>` service is added to the service container. It binds `MySubOptions` to the section `subsection` of the *appsettings.json* file (*Startup.cs*):

<!--[!code-csharp[Main](options/sample/Startup3.cs?name=snippet1&highlight=15-16)]-->
[!code-csharp[Main](options/sample/Startup.cs?name=snippet_Example3)]

The `GetSection` extension method requires the [Microsoft.Extensions.Options.ConfigurationExtensions](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions/) NuGet package. If the app already uses the [Microsoft.AspNetCore.All](https://www.nuget.org/packages/Microsoft.AspNetCore.All/) metapackage, the package is automatically included.

The sample's *appsettings.json* file defines a `subsection` member with keys for `suboption1` and `suboption2`:

[!code-json[Main](options/sample/appsettings.json?highlight=4-7)]

The `MySubOptions` class defines properties, `SubOption1` and `SubOption2`, to hold the sub-option values (*Models/MySubOptions.cs*):

[!code-csharp[Main](options/sample/Models/MySubOptions.cs?name=snippet1)]

The page model's `OnGet` method returns a string with the sub-option values (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](options/sample/Controllers/HomeController2.cs?name=snippet1)]-->
[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=11)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=4,10)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example3)]

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
## Options provided by a view model or with direct view injection

Options provided by a view model or with direct view injection is demonstrated as Example \#4 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

Options can also be supplied in a view model or by injecting `IOptions<TOptions>` directly into a view (*Pages/Index.cshtml.cs*):

<!--[!code-cshtml[Main](options/sample/Views/Home/Index.cshtml?highlight=3-4,16-17,20-21)]-->
[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=9)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=2,8)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example4)]

For direct injection, inject `IOptions<MyOptions>` with an `@inject` directive:

[!code-cshtml[Main](options/sample/Pages/Index.cshtml?range=1-10&highlight=5)]

When the app is run, the option values are shown in the rendered page:

![Options values Option1: value1_from_json and Option2: -1 are loaded from the model and by injection into the view.](options/_static/view.png)
<!-- HOLD
> [!NOTE]
> Configure the sample app to show options provided by the view model or by direct injection into the view:
>
> To enable the `Startup` class in *Startup.cs*, deactivate the `Startup` classes in *Startup2.cs*, *Startup3.cs*, and *Startup4.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *Startup.cs*, which activates the `Startup` class in the *Startup.cs* file.
>
> To enable the Home controller in *HomeController3.cs*, deactivate the `HomeController` class in *HomeController.cs*, *HomeController2.cs*, *HomeController4.cs*, and *HomeController5.cs* by commenting out the `#define UseMe` line with a pair of forward slashes (`//#define UseMe`). Un-comment the line `//#define UseMe` to `#define UseMe` in *HomeController3.cs*, which activates the `HomeController` class in the *HomeController3.cs* file.
-->
## Reloading configuration data with IOptionsSnapshot

Reloading configuration data with `IOptionsSnapshot` is demonstrated as Example \#5 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

*Requires ASP.NET Core 1.1 or later.*

# [ASP.NET Core 2.x](#tab/aspnetcore2x)

[IOptionsSnapshot](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1) supports reloading configuration data with minimal processing overhead when the configuration file changes. Using `IOptionsSnapshot` with `reloadOnChange: true` set for a configuration file provider, options are bound to `IConfiguration` and reloaded per request and cached for the lifetime of the request.

# [ASP.NET Core 1.1](#tab/aspnetcore11)

[IOptionsSnapshot](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1) supports reloading configuration data with minimal processing overhead when the configuration file changes. Using `IOptionsSnapshot` with `reloadOnChange: true` set for a configuration file provider, options are bound to `IConfiguration` and reloaded when the configuration file is changed.

---

The following example demonstrates how a new `IOptionsSnapshot` is created after *appsettings.json* changes (*Pages/Index.cshtml.cs*). Multiple requests to the server return constant values provided by the *appsettings.json* file until the file is changed and configuration reloads.

<!--[!code-csharp[Main](options/sample/Controllers/HomeController4.cs?name=snippet1&highlight=5)]-->
[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=12)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=5,11)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example5)]
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

## Named options support with IConfigureNamedOptions

Named options support with `IConfigureNamedOptions` is demonstrated as Example \#6 in the [sample app](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/options/sample).

*Requires ASP.NET Core 2.0 or later.*

*Named options* support allows the app to distinguish between named options configurations. In the sample app, named options are declared with the [ConfigureNamedOptions&lt;TOptions&gt;.Configure](/dotnet/api/microsoft.extensions.options.configurenamedoptions-1.configure) method (*Startup.cs*):

<!--[!code-csharp[Main](options/sample/Startup4.cs?name=snippet1&highlight=9,14-17)]-->
[!code-csharp[Main](options/sample/Startup.cs?name=snippet_Example6)]

The sample app accesses the named options with [IOptionsSnapshot&lt;TOptions&gt;.Get](/dotnet/api/microsoft.extensions.options.ioptionssnapshot-1.get) (*Pages/Index.cshtml.cs*):

<!--[!code-csharp[Main](options/sample/Controllers/HomeController5.cs?name=snippet1&highlight=8-9)]-->
[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?range=13-14)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet2&highlight=6,12-13)]

[!code-csharp[Main](options/sample/Pages/Index.cshtml.cs?name=snippet_Example6)]

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

## Configuring options after configuration with IPostConfigureOptions

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

## Options factory, monitoring, and cache

New in ASP.NET Core 2.0, [IOptionsFactory&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ioptionsfactory-1) is responsible for creating new options instances. It has a single [Create](/dotnet/api/microsoft.extensions.options.ioptionsfactory-1.create) method. The default implementation takes all registered `IConfigureOptions` and `IPostConfigureOptions` and runs all the configures first, followed by the post-configures. It distinguishes between `IConfigureNamedOptions` and `IConfigureOptions` and only calls the appropriate interface.

[IOptionsMonitor](/dotnet/api/microsoft.extensions.options.ioptionsmonitor-1) is used for notifications when `TOptions` instances change. `IOptionsMonitor` supports reloadable options, change notifications, and `IPostConfigureOptions`.

New in ASP.NET Core 2.0, [IOptionsMonitorCache&lt;TOptions&gt;](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1) is used by `IOptionsMonitor` to cache `TOptions` instances. The `IOptionsMonitorCache` invalidates options instances in the monitor so that the value is recomputed ([TryRemove](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.tryremove)). Values can be manually introduced as well with [TryAdd](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.tryadd). The [Clear](/dotnet/api/microsoft.extensions.options.ioptionsmonitorcache-1.clear) method is used when all named instances should be recreated on demand.

## See also

* [Configuration](xref:fundamentals/configuration/index)
