---
title: Options pattern in ASP.NET Core
author: tdykstra
description: Discover how to use the options pattern to represent groups of related settings in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 10/15/2025
uid: fundamentals/configuration/options
--- 
# Options pattern in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-7.0"

The options pattern uses classes to provide strongly typed access to groups of related settings. When [configuration settings](xref:fundamentals/configuration/index) are isolated by scenario into separate classes, the app adheres to two important software engineering principles:

* [Encapsulation](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#encapsulation):
  * Classes that depend on configuration settings depend only on the configuration settings that they use.
* [Separation of Concerns](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns):
  * Settings for different parts of the app aren't dependent or coupled to one another.

Options also provide a mechanism to validate configuration data. For more information, see the [Options validation](#options-validation) section.

This article provides information on the options pattern in ASP.NET Core. For information on using the options pattern in console apps, see [Options pattern in .NET](/dotnet/core/extensions/options).

<a name="optpat"></a>

## Bind hierarchical configuration

The preferred way to read related configuration values is using the [options pattern](xref:fundamentals/configuration/options). For example, to read the following configuration values:

```json
  "Position": {
    "Title": "Editor",
    "Name": "Joe Smith"
  }
```

Create the following `PositionOptions` class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Options/PositionOptions.cs?name=snippet)]

An options class:

* Must be non-abstract.
* Has public read-write properties of the type that have corresponding items in config are bound.
* Has its read-write properties bound to matching entries in configuration.
* Does ***not*** have its fields bound. In the preceding code, `Position` is not bound. The `Position` field is used so the string `"Position"` doesn't need to be hard coded in the app when binding the class to a configuration provider.

The following code:

* Calls [ConfigurationBinder.Bind](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind*) to bind the `PositionOptions` class to the `Position` section.
* Displays the `Position` configuration data.

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test22.cshtml.cs?name=snippet)]

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

[`ConfigurationBinder.Get<T>`](xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get*) binds and returns the specified type. `ConfigurationBinder.Get<T>` may be more convenient than using `ConfigurationBinder.Bind`. The following code shows how to use `ConfigurationBinder.Get<T>` with the `PositionOptions` class:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test21.cshtml.cs?name=snippet)]

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

Bind also allows the concretion of an abstract class. Consider the following code which uses the abstract class `SomethingWithAName`:

[!code-csharp[](~/fundamentals/configuration/index/samples/8.x/ConfigSample/Options/NameTitleOptions.cs)]

The following code displays the `NameTitleOptions` configuration values:

[!code-csharp[](~/fundamentals/configuration/index/samples/8.x/ConfigSample/Pages/Test33.cshtml.cs?name=snippet)]

Calls to `Bind` are less strict than calls to `Get<>`:

* `Bind` allows the concretion of an abstract.
* `Get<>` has to create an instance itself.

## The Options Pattern

An alternative approach when using the ***options pattern*** is to bind the `Position` section and add it to the [dependency injection service container](xref:fundamentals/dependency-injection). In the following code, `PositionOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure*> and bound to configuration:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Program.cs?name=snippet)]

Using the preceding code, the following code reads the position options:

[!code-csharp[](~/fundamentals/configuration/index/samples/6.x/ConfigSample/Pages/Test2.cshtml.cs?name=snippet)]

In the preceding code, changes to the JSON configuration file after the app has started are ***not*** read. To read changes after the app has started, use [IOptionsSnapshot](xref:fundamentals/configuration/options#ios).

<a name="oi"></a>

## Options interfaces

<xref:Microsoft.Extensions.Options.IOptions%601>:

* Does ***not*** support:
  * Reading of configuration data after the app has started.
  * [Named options](#named)
* Is registered as a [Singleton](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).

<xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Is useful in scenarios where options should be recomputed on every request. For more information, see [Use IOptionsSnapshot to read updated data](#ios).
* Is registered as [Scoped](/dotnet/core/extensions/dependency-injection#scoped) and therefore can't be injected into a Singleton service.
* Supports [named options](#named)

<xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

* Is used to retrieve options and manage options notifications for `TOptions` instances.
* Is registered as a [Singleton](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).
* Supports:
  * Change notifications
  * [named options](#named)
  * [Reloadable configuration](#ios)
  * Selective options invalidation (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601>)
  
[Post-configuration](#options-post-configuration) scenarios enable setting or changing options after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs.

<xref:Microsoft.Extensions.Options.IOptionsFactory%601> is responsible for creating new options instances. It has a single <xref:Microsoft.Extensions.Options.IOptionsFactory%601.Create%2A> method. The default implementation takes all registered <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601> and runs all the configurations first, followed by the post-configuration. It distinguishes between <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and only calls the appropriate interface.

<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> is used by <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> to cache `TOptions` instances. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> invalidates options instances in the monitor so that the value is recomputed (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryRemove%2A>). Values can be manually introduced with <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryAdd%2A>. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.Clear%2A> method is used when all named instances should be recreated on demand.

<a name="ios"></a>

## Use IOptionsSnapshot to read updated data

Using <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Options are computed once per request when accessed and cached for the lifetime of the request.
* May incur a significant performance penalty because it's a [Scoped service](/dotnet/core/extensions/dependency-injection#scoped) and is recomputed per request. For more information, see [this GitHub issue](https://github.com/dotnet/runtime/issues/53793) and [Improve the performance of configuration binding](https://github.com/dotnet/runtime/issues/36130).
* Changes to the configuration are read after the app starts when using configuration providers that support reading updated configuration values.

The difference between `IOptionsMonitor` and `IOptionsSnapshot` is that:

* `IOptionsMonitor` is a [Singleton service](/dotnet/core/extensions/dependency-injection#singleton) that retrieves current option values at any time, which is especially useful in singleton dependencies.
* `IOptionsSnapshot` is a [Scoped service](/dotnet/core/extensions/dependency-injection#scoped) and provides a snapshot of the options at the time the `IOptionsSnapshot<T>` object is constructed. Options snapshots are designed for use with transient and scoped dependencies.

The following code uses <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>.

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/Pages/TestSnap.cshtml.cs" id="snippet":::

The following code registers a configuration instance which `MyOptions` binds against:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/program.cs" id="snippet":::

In the preceding code, changes to the JSON configuration file after the app has started are read.

## IOptionsMonitor

The following code registers a configuration instance which `MyOptions` binds against.

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/program.cs" id="snippet":::

The following example uses <xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/Pages/TestMonitor.cshtml.cs" id="snippet":::

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

<a name="named"></a>

## Specify a custom key name for a configuration property using `ConfigurationKeyName`

By default, the property names of the options class are used as the key name in the configuration source. If the property name is `Title`, the key name in the configuration is `Title` as well.

When the names differentiate, you can use the [`ConfigurationKeyName` attribute](xref:Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute) to specify the key name in the configuration source. Using this technique, you can map a property in the configuration to one in your code with a different name. 

This is useful when the property name in the configuration source isn't a valid C# identifier or when you want to use a different name in your code.

For example, consider the following options class:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/Models/PositionOptionsWithConfigurationKeyName.cs" id="snippet":::

The `Title` and `Name` class properties are bound to the `position-title` and `position-name` from the following `appsettings.json` file:

:::code language="json" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/appsettings.KN.json":::

## Named options support using IConfigureNamedOptions

Named options:

* Are useful when multiple configuration sections bind to the same properties.
* Are case sensitive.

Consider the following `appsettings.json` file:

:::code language="json" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/appsettings.NO.json":::

Rather than creating two classes to bind `TopItem:Month` and `TopItem:Year`, the following class is used for each section:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/Models/TopItemSettings.cs":::

The following code configures the named options:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/program.cs" id="snippet_om":::

The following code displays the named options:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/Pages/TestNO.cshtml.cs" id="snippet":::

All options are named instances. <xref:Microsoft.Extensions.Options.IConfigureOptions%601> instances are treated as targeting the `Options.DefaultName` instance, which is `string.Empty`. <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> also implements <xref:Microsoft.Extensions.Options.IConfigureOptions%601>. The default implementation of the <xref:Microsoft.Extensions.Options.IOptionsFactory%601> has logic to use each appropriately. The `null` named option is used to target all of the named instances instead of a specific named instance. <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.ConfigureAll%2A> and <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> use this convention.

## OptionsBuilder API

<xref:Microsoft.Extensions.Options.OptionsBuilder%601> is used to configure `TOptions` instances. `OptionsBuilder` streamlines creating named options as it's only a single parameter to the initial `AddOptions<TOptions>(string optionsName)` call instead of appearing in all of the subsequent calls. Options validation and the `ConfigureOptions` overloads that accept service dependencies are only available via `OptionsBuilder`.

`OptionsBuilder` is used in the [Options validation](#val) section.

See [Use AddOptions to configure custom repository](xref:security/data-protection/using-data-protection#add-opt) for information adding a custom repository.

## Use DI services to configure options

Services can be accessed from dependency injection while configuring options in two ways:

* Pass a configuration delegate to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> on <xref:Microsoft.Extensions.Options.OptionsBuilder%601>. `OptionsBuilder<TOptions>` provides overloads of <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> that allow use of up to five services to configure options:

  ```csharp
  builder.Services.AddOptions<MyOptions>("optionalName")
      .Configure<Service1, Service2, Service3, Service4, Service5>(
          (o, s, s2, s3, s4, s5) => 
              o.Property = DoSomethingWith(s, s2, s3, s4, s5));
  ```

* Create a type that implements <xref:Microsoft.Extensions.Options.IConfigureOptions%601> or <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and register the type as a service.

We recommend passing a configuration delegate to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>, since creating a service is more complex. Creating a type is equivalent to what the framework does when calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>. Calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> registers a transient generic <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601>, which has a constructor that accepts the generic service types specified. 

<a name="val"></a>

## Options validation

Options validation enables option values to be validated.

Consider the following `appsettings.json` file:

:::code language="json" source="~/fundamentals/configuration/options/samples/3.x/OptionsValidationSample/appsettings.Dev2.json":::

The following class is used to bind to the `"MyConfig"` configuration section and applies a couple of `DataAnnotations` rules:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/3.x/OptionsValidationSample/Configuration/MyConfigOptions.cs" id="snippet":::

The following code:

* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%2A> to get an <xref:Microsoft.Extensions.Options.OptionsBuilder%601> that binds to the `MyConfigOptions` class.
* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> to enable validation using `DataAnnotations`.

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Program.cs" id="snippet":::

The `ValidateDataAnnotations` extension method is defined in the [Microsoft.Extensions.Options.DataAnnotations](https://www.nuget.org/packages/Microsoft.Extensions.Options.DataAnnotations) NuGet package. For web apps that use the `Microsoft.NET.Sdk.Web` SDK, this package is referenced implicitly from the shared framework.

The following code displays the configuration values or the validation errors:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Controllers/HomeController.cs" id="snippet":::

The following code applies a more complex validation rule using a delegate:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Program.cs" id="snippet_mc":::

### `IValidateOptions<TOptions>` and `IValidatableObject`

The following class implements <xref:Microsoft.Extensions.Options.IValidateOptions%601>:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Configuration/MyConfigValidation.cs" id="snippet":::

`IValidateOptions` enables moving the validation code out of `Program.cs` and into a class.

Using the preceding code, validation is enabled in `Program.cs` with the following code:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Program.cs" id="snippet_xm":::

Options validation also supports <xref:System.ComponentModel.DataAnnotations.IValidatableObject>. To perform class-level validation of a class within the class itself:

* Implement the `IValidatableObject` interface and its <xref:System.ComponentModel.DataAnnotations.IValidatableObject.Validate%2A> method within the class.
* Call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> in `Program.cs`.

### `ValidateOnStart`

Options validation runs the first time a `TOption` instance is created. That means, for instance, when first 
access to [`IOptionsSnapshot<TOptions>.Value`](xref:Microsoft.Extensions.Options.IOptionsSnapshot%601) occurs in a request pipeline or when 
[`IOptionsMonitor<TOptions>.Get(string)`](xref:Microsoft.Extensions.Options.OptionsMonitor`1.Get(System.String)) is called on settings present. After settings are reloaded, validation runs again. The ASP.NET Core runtime uses <xref:Microsoft.Extensions.Options.OptionsCache%601> to cache the options instance once it is created.

To run options validation eagerly, when the app starts, call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.ValidateOnStart``1(Microsoft.Extensions.Options.OptionsBuilder{``0})>in `Program.cs`:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Snippets/Program.cs" id="snippet_ValidateOnStart" highlight="4":::

## Options post-configuration

Set post-configuration with <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601>. Post-configuration runs after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Program.cs" id="snippet_p1" highlight="10-99":::

<xref:Microsoft.Extensions.Options.IPostConfigureOptions%601.PostConfigure%2A> is available to post-configure named options:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/program.cs" id="snippet_nmo" highlight="10-14":::

Use <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> to post-configure all configuration instances:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsValidationSample/Program.cs" id="snippet_p3" highlight="10-99":::

## Access options in `Program.cs`

To access <xref:Microsoft.Extensions.Options.IOptions%601> or <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> in `Program.cs`, call <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>:

:::code language="csharp" source="~/fundamentals/configuration/options/samples/6.x/OptionsSample/program.cs" id="snippet_grs":::

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/configuration/options/samples) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

:::moniker-end

[!INCLUDE[](~/fundamentals/configuration/options/includes/options6.md)]
