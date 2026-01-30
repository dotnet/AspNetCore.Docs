---
title: Options pattern in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Discover how to use the options pattern to represent groups of related settings in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/29/2026
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

The examples in this article rely on a general understanding of injecting services into classes. For more information, see <xref:fundamentals/dependency-injection>. Examples are based on Blazor's Razor components. For more information, see <xref:blazor/index>. To see Razor Pages examples, see the [7.0 version of this article](?view=aspnetcore-7.0).

## How to use the options pattern

Consider the following JSON configuration data available to the app via any of the [configuration providers](xref:fundamentals/configuration/index#configuration-providers), which includes related data for an employee's name and title in an organization's position:

```json
"Position": {
  "Name": "Joe Smith",
  "Title": "Editor"
}
```

The following `PositionOptions` options class:

* Is a [POCO](https://wikipedia.org/wiki/Plain_Old_CLR_Object), a simple .NET class with properties. An options class must not be an abstract class.
* Has public read-write properties that match corresponding entries in the configuration data.
* Does ***not*** have its field (`Position`) bound. The `Position` field is used to avoid hardcoding the string `"Position"` in the app when binding the class to a configuration provider.

```csharp
public class PositionOptions
{
    public const string Position = "Position";

    public string? Name { get; set; }
    public string? Title { get; set; }
}
```

The following example:

* Calls <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind%2A?displayProperty=nameWithType> to bind the `PositionOptions` class to the `Position` section.
* Displays the `Position` configuration data.

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`BasicOptions.razor`:

```razor
@page "/basic-options"
@inject IConfiguration Config

Name: @positionOptions?.Name<br>
Title: @positionOptions?.Title

@code {
    private PositionOptions? positionOptions;

    protected override void OnInitialized()
    {
        positionOptions = new PositionOptions();
        Config.GetSection(PositionOptions.Position).Bind(positionOptions);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class BasicOptionsModel(IConfiguration configuration) : PageModel
{
    public ContentResult OnGet()
    {
        var positionOptions = new PositionOptions();
        configuration.GetSection(PositionOptions.Position).Bind(positionOptions);

        return Content(
            $"Name: {positionOptions.Name}\n" +
            $"Title: {positionOptions.Title}");
    }
}
```

:::moniker-end

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%2A?displayProperty=nameWithType> binds and returns the specified type. `ConfigurationBinder.Get<T>` may be more convenient than using `ConfigurationBinder.Bind`. The following code shows how to use `ConfigurationBinder.Get<T>` with the `PositionOptions` class:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`GetOptions.razor`:

```razor
@page "/get-options"
@inject IConfiguration Config

Name: @positionOptions?.Name<br>
Title: @positionOptions?.Title

@code {
    private PositionOptions? positionOptions;

    protected override void OnInitialized() =>
        positionOptions = Config.GetSection(PositionOptions.Position)
            .Get<PositionOptions>();
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class GetOptionsModel(IConfiguration configuration) : PageModel
{
    private PositionOptions? positionOptions;

    public ContentResult OnGet()
    {
        positionOptions = configuration.GetSection(PositionOptions.Position)
            .Get<PositionOptions>();

        return Content(
            $"Name: {positionOptions?.Name}\n" +
            $"Title: {positionOptions?.Title}");
    }
}
```

:::moniker-end

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

::: moniker range=">= aspnetcore-7.0"

<!-- Confirm that this only works >=7.0 -->

Bind also allows the concretion of an abstract class. Consider the following code which uses the abstract class `SomethingWithAName`:

```csharp
public abstract class SomethingWithAName
{
    public abstract string? Name { get; set; }
}

public class NameTitleOptions(int age) : SomethingWithAName
{
    public const string NameTitle = "NameTitle";

    public override string? Name { get; set; }
    public string? Title { get; set; }
    public int Age { get; set; } = age;
}
```

JSON configuration:

```json
"NameTitle": {
  "Name": "Sally Jones",
  "Title": "Writer"
}
```

The following code displays the `NameTitleOptions` configuration values:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`AbstractClassOptions.razor`:

```razor
@page "/abstract-class-options"
@inject IConfiguration Config

Name: @nameTitleOptions?.Name<br>
Title: @nameTitleOptions?.Title<br>
Age: @nameTitleOptions?.Age

@code {
    private NameTitleOptions? nameTitleOptions;

    protected override void OnInitialized()
    {
        nameTitleOptions = new NameTitleOptions(22);
        Config.GetSection(NameTitleOptions.NameTitle).Bind(nameTitleOptions);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class AbstractClassOptionsModel(IConfiguration configuration) : PageModel
{
    public ContentResult OnGet()
    {
        var nameTitleOptions = new NameTitleOptions(22);
        configuration.GetSection(NameTitleOptions.NameTitle).Bind(nameTitleOptions);

        return Content(
            $"Name: {nameTitleOptions.Name}\n" +
            $"Title: {nameTitleOptions.Title}\n" +
            $"Age: {nameTitleOptions.Age}");
    }
}
```

:::moniker-end

Calls to `Bind` are less strict than calls to `Get<T>`:

* `Bind` allows the concretion of an abstract class.
* `Get<T>` must create an instance itself.

:::moniker-end

## The Options Pattern

An alternative options pattern approach is to bind configuration and add the options to the [dependency injection service container](xref:fundamentals/dependency-injection). In the following code where services are registered for dependency injection, `PositionOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure*> and bound to configuration.

JSON configuration:

```json
"Position": {
  "Name": "Joe Smith",
  "Title": "Editor"
}
```

`PositionOptions` class:

```csharp
public class PositionOptions
{
    public const string Position = "Position";

    public string? Name { get; set; }
    public string? Title { get; set; }
}
```

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.Configure<PositionOptions>(
    builder.Configuration.GetSection(PositionOptions.Position));
```

::: moniker-end

Using the preceding code, the following code reads the position options:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`DIOptions.razor`:

```razor
@page "/di-options"
@using Microsoft.Extensions.Options
@inject IOptions<PositionOptions> Options

Name: @Options.Value.Name<br>
Title: @Options.Value.Title
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class DIOptionsModel(IOptions<PositionOptions> options) : PageModel
{
    public ContentResult OnGet()
    {
        return Content(
            $"Name: {options.Value.Name}\n" +
            $"Title: {options.Value.Title}");
    }
}
```

:::moniker-end

In the preceding code, changes to the JSON configuration file after the app has started are ***not*** read. To read changes after the app has started, use [`IOptionsSnapshot`](xref:fundamentals/configuration/options#use-ioptionssnapshot-to-read-updated-data-in-scoped-services).

## Options interfaces

<xref:Microsoft.Extensions.Options.IOptions%601>:

* Does ***not*** support:
  * Reading of configuration data after the app has started.
  * [Named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname).
* Is registered as a [Singleton](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).

<xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Is useful in scenarios where options should be recomputed on every request. For more information, see [Use IOptionsSnapshot to read updated data](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services).
* Is registered as a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and therefore can't be injected into a Singleton service.
* Supports [named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname).

<xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

* Is used to retrieve options and manage options notifications for `TOptions` instances.
* Is registered as a [Singleton](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).
* Supports:
  * Change notifications
  * [named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname)
  * [Reloadable configuration](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services)
  * Selective options invalidation (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601>)
  
[Post-configuration](#options-post-configuration) scenarios enable setting or changing options after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs.

<xref:Microsoft.Extensions.Options.IOptionsFactory%601> is responsible for creating new options instances. It has a single <xref:Microsoft.Extensions.Options.IOptionsFactory%601.Create%2A> method. The default implementation takes all registered <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601> and runs all the configurations first, followed by the post-configuration. It distinguishes between <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and only calls the appropriate interface.

<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> is used by <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> to cache `TOptions` instances. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> invalidates options instances in the monitor so that the value is recomputed (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryRemove%2A>). Values can be manually introduced with <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryAdd%2A>. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.Clear%2A> method is used when all named instances should be recreated on demand.

## Use `IOptionsSnapshot` to read updated data in scoped services

Using <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Options are computed once per request when accessed and cached for the lifetime of the request.
* May incur a significant performance penalty because it's a [Scoped service](/dotnet/core/extensions/dependency-injection#scoped) and is recomputed per request. For more information, see [this GitHub issue](https://github.com/dotnet/runtime/issues/53793) and [Improve the performance of configuration binding](https://github.com/dotnet/runtime/issues/36130).
* Changes to the configuration are read after the app starts when using configuration providers that support reading updated configuration values.

The difference between [`IOptionsMonitor`](#use-ioptionsmoniter-to-read-updated-data-in-singleton-services) and <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is that:

* <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) that retrieves current option values at any time, which is especially useful in singleton dependencies.
* <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and provides a snapshot of the options at the time the `IOptionsSnapshot<T>` object is constructed. Options snapshots are designed for use with transient and scoped dependencies.

The following example uses <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>.

JSON configuration:

```json
"MyOptions": {
  "Option1": "Option1_Value",
  "Option2": "Option2_Value"
}
```

`MyOptions` class:

```csharp
public class MyOptions
{
    public string? Option1 { get; set; }
    public string? Option2 { get; set; }
}
```

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`SnapshotOptions.razor`:

```razor
@page "/snapshot"
@using Microsoft.Extensions.Options
@inject IOptionsSnapshot<MyOptions> Snapshot

Option1: @Snapshot.Value.Option1<br>
Option2: @Snapshot.Value.Option2
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class SnapshotOptionsModel(IOptionsSnapshot<MyOptions> snapshotOptions) 
    : PageModel
{
    public ContentResult OnGet()
    {
        return Content(
            $"Option1: {snapshotOptions.Value.Option1}\n" +
            $"Option2: {snapshotOptions.Value.Option2}");
    }
}
```

:::moniker-end

Where services are registered for dependency injection, the following code registers a configuration instance which `MyOptions` binds against:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<MyOptions>(
    builder.Configuration.GetSection("MyOptions"));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.Configure<MyOptions>(
    builder.Configuration.GetSection("MyOptions"));
```

::: moniker-end

In the preceding code, changes to the JSON configuration file after the app has started are read.

## Use `IOptionsMoniter` to read updated data in singleton services

<xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is used to retrieve options and manage options notifications for `TOptions` instances.

The difference between <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> and [`IOptionsSnapshot`](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services) is that:

* <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) that retrieves current option values at any time, which is especially useful in singleton dependencies.
* <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and provides a snapshot of the options at the time the `IOptionsSnapshot<T>` object is constructed. Options snapshots are designed for use with transient and scoped dependencies.

JSON configuration:

```json
"MyOptions": {
  "Option1": "Option1_Value",
  "Option2": "Option2_Value"
}
```

`MyOptions` class:

```csharp
public class MyOptions
{
    public string? Option1 { get; set; }
    public string? Option2 { get; set; }
}
```

Where services are registered for dependency injection, the following code registers a configuration instance which `MyOptions` binds against.

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<MyOptions>(
    builder.Configuration.GetSection("MyOptions"));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.Configure<MyOptions>(
    builder.Configuration.GetSection("MyOptions"));
```

::: moniker-end

The following example uses <xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`MonitorOptions.razor`:

```razor
@page "/monitor-options"
@using Microsoft.Extensions.Options
@inject IOptionsMonitor<MyOptions> OptionsDelegate

Option1: @OptionsDelegate.CurrentValue.Option1<br>
Option2: @OptionsDelegate.CurrentValue.Option2
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class MonitorOptionsModel(IOptionsMonitor<MyOptions> optionsDelegate) 
    : PageModel
{
    public ContentResult OnGet()
    {
        return Content(
            $"Option1: {optionsDelegate.CurrentValue.Option1}\n" +
            $"Option2: {optionsDelegate.CurrentValue.Option2}");
    }
}
```

:::moniker-end

In the preceding code, by default, changes to the JSON configuration file after the app has started are read.

:::moniker range=">= aspnetcore-7.0"

## Specify a custom key name for a configuration property using `ConfigurationKeyName`

By default, the property names of the options class are used as the key name in the configuration source. If the property name is `Title`, the key name in the configuration is `Title` as well.

When the names differentiate, you can use the [`ConfigurationKeyName` attribute](xref:Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute) to specify the key name in the configuration source. Using this technique, you can map a property in the configuration to one in your code with a different name. 

This is useful when the property name in the configuration source isn't a valid C# identifier or when you want to use a different name in your code.

For example, consider the following options class:

```csharp
public class PositionKeyName
{
    public const string Position = "PositionKeyName";

    [ConfigurationKeyName("PositionName")]
    public string? Name { get; set; }

    [ConfigurationKeyName("PositionTitle")]
    public string? Title { get; set; }
}
```

The `Title` and `Name` class properties are bound to the `PositionTitle` and `PositionName` from the following JSON configuration:

```json
"PositionKeyName": {
  "PositionName": "Carlos Diego",
  "PositionTitle": "Director"
}
```

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`PositionKeyNameOptions.razor`:

```razor
@page "/position-key-name-options"
@inject IConfiguration Config

Name: @positionOptions?.Name<br>
Title: @positionOptions?.Title

@code {
    private PositionKeyName? positionOptions;

    protected override void OnInitialized() =>
        positionOptions = Config.GetSection(PositionKeyName.Position)
            .Get<PositionKeyName>();
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class PositionKeyNameOptionsModel(IConfiguration configuration) : PageModel
{
    private PositionKeyName? positionOptions;

    public ContentResult OnGet()
    {
        positionOptions = configuration.GetSection(PositionKeyName.Position)
            .Get<PositionKeyName>();

        return Content(
            $"Name: {positionOptions?.Name}\n" +
            $"Title: {positionOptions?.Title}");
    }
}
```

:::moniker-end

## Named options support using `IConfigureNamedOptions`

Named options:

* Are useful when multiple configuration sections bind to the same properties.
* Are case sensitive.

Consider the following JSON configuration:

```json
"TopItem": {
  "Month": {
    "Name": "Green Widget",
    "Model": "GW46"
  },
  "Year": {
    "Name": "Orange Gadget",
    "Model": "OG35"
  }
}
```

Rather than creating two classes to bind `TopItem:Month` and `TopItem:Year`, the following class is used for each section:

```csharp
public class TopItemSettings
{
    public const string Month = "Month";
    public const string Year = "Year";

    public string? Name { get; set; }
    public string? Model { get; set; }
}
```

The following code configures the named options:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));
```

:::moniker-end

The following code displays the named options:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`NamedOptions.razor`:

```razor
@page "/named-options"
@using Microsoft.Extensions.Options
@inject IOptionsSnapshot<TopItemSettings> NamedOptionsAccessor

<b>Month:</b> Name: @monthTopItem?.Name Model: @monthTopItem?.Model
<br>
<b>Year:</b> Name: @yearTopItem?.Name Model: @yearTopItem?.Model

@code {
    private TopItemSettings? monthTopItem;
    private TopItemSettings? yearTopItem;

    protected override void OnInitialized()
    {
        monthTopItem = NamedOptionsAccessor.Get(TopItemSettings.Month);
        yearTopItem = NamedOptionsAccessor.Get(TopItemSettings.Year);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class NamedOptionsModel(
    IOptionsSnapshot<TopItemSettings> namedOptionsAccessor) : PageModel
{
    public ContentResult OnGet()
    {
        var monthTopItem = namedOptionsAccessor.Get(TopItemSettings.Month);
        var yearTopItem = namedOptionsAccessor.Get(TopItemSettings.Year);

        return Content(
            $"Month:Name {monthTopItem.Name}\n" +
            $"Month:Model {monthTopItem.Model}\n" +
            $"Year:Name {yearTopItem.Name}\n" +
            $"Year:Model {yearTopItem.Model}");
    }
}
```

:::moniker-end

All options are named instances. <xref:Microsoft.Extensions.Options.IConfigureOptions%601> instances are treated as targeting the `Options.DefaultName` instance, which is `string.Empty`. <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> also implements <xref:Microsoft.Extensions.Options.IConfigureOptions%601>. The default implementation of the <xref:Microsoft.Extensions.Options.IOptionsFactory%601> has logic to use each appropriately. The `null` named option is used to target all of the named instances instead of a specific named instance. <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.ConfigureAll%2A> and <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> use this convention.

## `OptionsBuilder` API

<xref:Microsoft.Extensions.Options.OptionsBuilder%601> is used to configure `TOptions` instances. `OptionsBuilder` streamlines creating named options as it's only a single parameter to the initial `AddOptions<TOptions>(string optionsName)` call instead of appearing in all of the subsequent calls. Options validation and the `ConfigureOptions` overloads that accept service dependencies are only available via `OptionsBuilder`.

`OptionsBuilder` is demonstrated in the [Options validation](#options-validation) section.

For information adding a custom repository, see <xref:security/data-protection/using-data-protection#add-opt>.

## Use DI services to configure options

Services can be accessed from dependency injection while configuring options in two ways:

* [Configuration delegate](#configuration-delegate-approach)
* [Configuration options service](#configuration-options-service-approach)

### Configuration delegate approach

Where services are registered for dependency injection, pass a configuration delegate to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> on <xref:Microsoft.Extensions.Options.OptionsBuilder%601>. `OptionsBuilder<TOptions>` provides overloads of <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> that allow use of up to five services to configure options:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddOptions<MyOptions>("optionalName")
    .Configure<Service1, Service2, Service3, Service4, Service5>(
        (o, s, s2, s3, s4, s5) => 
            o.Property = DoSomethingWith(s, s2, s3, s4, s5));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<MyOptions>("optionalName")
    .Configure<Service1, Service2, Service3, Service4, Service5>(
        (o, s, s2, s3, s4, s5) => 
            o.Property = DoSomethingWith(s, s2, s3, s4, s5));
```

::: moniker-end

### Configuration options service approach

Create a type that implements <xref:Microsoft.Extensions.Options.IConfigureOptions%601> or <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and register the type as a service.

We recommend passing a configuration delegate to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>, since creating a service is more complex. Creating a type is equivalent to what the framework does when calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>. Calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> registers a transient generic <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601>, which has a constructor that accepts the generic service types specified. 

## Options validation

Options validation enables option values to be validated.

Consider the following `appsettings.json` file:

```json
"MyConfig": {
  "Key1": "My Key One",
  "Key2": 10,
  "Key3": 32
}
```

The following class is used to bind to the `"MyConfig"` configuration section and applies a couple of `DataAnnotations` rules:

```csharp
public class MyConfigOptions
{
    public const string MyConfig = "MyConfig";

    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
    public string? Key1 { get; set; }

    [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Key2 { get; set; }
    public int Key3 { get; set; }
}
```

Where services are registered for dependency injection, the following code:

* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%2A> to get an <xref:Microsoft.Extensions.Options.OptionsBuilder%601> that binds to the `MyConfigOptions` class.
* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> to enable validation using `DataAnnotations`.

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddOptions<MyConfigOptions>()
    .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
    .ValidateDataAnnotations();
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<MyConfigOptions>()
    .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
    .ValidateDataAnnotations();
```

::: moniker-end

The `ValidateDataAnnotations` extension method is defined in the [`Microsoft.Extensions.Options.DataAnnotations` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Options.DataAnnotations). For web apps that use the `Microsoft.NET.Sdk.Web` SDK, this package is referenced implicitly from the shared framework.

The following code displays the configuration values or the validation errors:

<!-- Razor component -->

:::moniker range=">= aspnetcore-8.0"

`OptionsValidation.razor`:

```razor
@page "/options-validation"
@inject IOptions<MyConfigOptions> Config
@inject ILogger<OptionsValidation> Logger

<b>msg:</b> @msg
<b>Year:</b> Name: yearTopItem?.Name Model: yearTopItem?.Model

@code {
    private string? msg;

    protected override void OnInitialized()
    {
        try
        {
            var configValue = Config.Value;
        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                Logger.LogError(failure);
            }
        }

        try
        {
            msg = 
                $"Key1: {Config.Value.Key1}\n" +
                $"Key2: {Config.Value.Key2}\n" +
                $"Key3: {Config.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            msg = optValEx.Message;
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

<!-- NEW VERSION -->

```csharp
public class OptionsValidationModel(IOptions<MyConfigOptions> config,
        ILogger<HomeController> logger) : PageModel
{
    public TestValidationModel
    {
        try
        {
            var configValue = config.Value;
        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                this.logger.LogError(failure);
            }
        }
    }

    public ContentResult OnGet()
    {
        string msg;

        try
        {
            msg = 
                $"Key1: {config.Value.Key1}\n" +
                $"Key2: {config.Value.Key2}\n" +
                $"Key3: {config.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            return Content(optValEx.Message);
        }

        return Content(msg);
    }
}
```

<!-- OLD VERSION -->

```csharp
public class OptionsValidationModel : PageModel
{
    private readonly ILogger<HomeController> logger;
    private readonly IOptions<MyConfigOptions> config;

    public TestValidationModel(IOptions<MyConfigOptions> config,
        ILogger<HomeController> logger)
    {
        this.config = config;
        this.logger = logger;

        try
        {
            var configValue = this.config.Value;

        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                this.logger.LogError(failure);
            }
        }
    }

    public ContentResult OnGet()
    {
        string msg;

        try
        {
            msg = 
                $"Key1: {config.Value.Key1}\n" +
                $"Key2: {config.Value.Key2}\n" +
                $"Key3: {config.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            return Content(optValEx.Message);
        }

        return Content(msg);
    }
}
```

:::moniker-end

Where services are registered for dependency injection, the following code applies a more complex validation rule using a delegate:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddOptions<MyConfigOptions>()
        .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
        .ValidateDataAnnotations()
    .Validate(config =>
    {
        if (config.Key2 != 0)
        {
            return config.Key3 > config.Key2;
        }

        return true;
    }, "Key3 must be > than Key2.");   // Failure message.
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<MyConfigOptions>()
        .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
        .ValidateDataAnnotations()
    .Validate(config =>
    {
        if (config.Key2 != 0)
        {
            return config.Key3 > config.Key2;
        }

        return true;
    }, "Key3 must be > than Key2.");   // Failure message.
```

::: moniker-end

### `IValidateOptions<TOptions>` and `IValidatableObject`

The following class implements <xref:Microsoft.Extensions.Options.IValidateOptions%601>:

```csharp
public class MyConfigValidation : IValidateOptions<MyConfigOptions>
{
    public MyConfigOptions config { get; private set; }

    public  MyConfigValidation(IConfiguration config)
    {
        this.config = config.GetSection(MyConfigOptions.MyConfig)
            .Get<MyConfigOptions>();
    }

    public ValidateOptionsResult Validate(string name, MyConfigOptions options)
    {
        string? vor = null;
        var rx = new Regex(@"^[a-zA-Z''-'\s]{1,40}$");
        var match = rx.Match(options.Key1!);

        if (string.IsNullOrEmpty(match.Value))
        {
            vor = $"{options.Key1} doesn't match RegEx\n";
        }

        if ( options.Key2 < 0 || options.Key2 > 1000)
        {
            vor = $"{options.Key2} doesn't match Range 0 - 1000\n";
        }

        if (config.Key2 != default)
        {
            if(config.Key3 <= config.Key2)
            {
                vor +=  "Key3 must be > than Key2.";
            }
        }

        if (vor != null)
        {
            return ValidateOptionsResult.Fail(vor);
        }

        return ValidateOptionsResult.Success;
    }
}
```

`IValidateOptions` enables moving the validation code out of `Program.cs` and into a class.

Where services are registered for dependency injection and using the preceding code, validation is enabled in `Program.cs` with the following code:

::: moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.Extensions.Options;

...

builder.Services.Configure<MyConfigOptions>(
    builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.AddSingleton<IValidateOptions<MyConfigOptions>, 
    MyConfigValidation>();
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
using Microsoft.Extensions.Options;

...

services.Configure<MyConfigOptions>(
    builder.Configuration.GetSection(MyConfigOptions.MyConfig));

services.AddSingleton<IValidateOptions<MyConfigOptions>, 
    MyConfigValidation>();
```

::: moniker-end

Options validation also supports <xref:System.ComponentModel.DataAnnotations.IValidatableObject>. To perform class-level validation of a class within the class itself:

* Implement the `IValidatableObject` interface and its <xref:System.ComponentModel.DataAnnotations.IValidatableObject.Validate%2A> method within the class.
* Call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> in `Program.cs`.

::: moniker range=">= aspnetcore-6.0"

### `ValidateOnStart`

Options validation runs the first time a `TOption` instance is created. That means, for instance, when first 
access to [`IOptionsSnapshot<TOptions>.Value`](xref:Microsoft.Extensions.Options.IOptionsSnapshot%601) occurs in a request pipeline or when 
[`IOptionsMonitor<TOptions>.Get(string)`](xref:Microsoft.Extensions.Options.OptionsMonitor`1.Get(System.String)) is called on settings present. After settings are reloaded, validation runs again. The ASP.NET Core runtime uses <xref:Microsoft.Extensions.Options.OptionsCache%601> to cache the options instance once it is created.

To run options validation eagerly, when the app starts, call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.ValidateOnStart``1(Microsoft.Extensions.Options.OptionsBuilder{``0})>in `Program.cs`:

```csharp
builder.Services.AddOptions<MyConfigOptions>()
    .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig))
    .ValidateDataAnnotations()
    .ValidateOnStart();
```

:::moniker-end

## Options post-configuration

::: moniker range=">= aspnetcore-6.0"

Where services are registered for dependency injection, set post-configuration with <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601>. Post-configuration runs after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs:

```csharp
builder.Services.AddOptions<MyConfigOptions>()
    .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.PostConfigure<MyConfigOptions>(myOptions =>
{
    myOptions.Key1 = "post_configured_key1_value";
});
```

Where services are registered for dependency injection, <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601.PostConfigure%2A> is available to post-configure named options:

```csharp
builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));

builder.Services.PostConfigure<TopItemSettings>("Month", myOptions =>
{
    myOptions.Name = "post_configured_name_value";
    myOptions.Model = "post_configured_model_value";
});
```

Where services are registered for dependency injection, use <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> to post-configure all configuration instances:

```csharp
builder.Services.AddOptions<MyConfigOptions>()
    .Bind(builder.Configuration.GetSection(MyConfigOptions.MyConfig));

builder.Services.PostConfigureAll<MyConfigOptions>(myOptions =>
{
    myOptions.Key1 = "post_configured_key1_value";
});
```

:::moniker-end

::: moniker range="< aspnetcore-6.0"

Where services are registered for dependency injection, set post-configuration with <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601>. Post-configuration runs after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs:

```csharp
services.PostConfigure<MyOptions>(myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

Where services are registered for dependency injection, <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601.PostConfigure%2A> is available to post-configure named options:

```csharp
services.PostConfigure<MyOptions>("named_options_1", myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

Where services are registered for dependency injection, use <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> to post-configure all configuration instances:

```csharp
services.PostConfigureAll<MyOptions>(myOptions =>
{
    myOptions.Option1 = "post_configured_option1_value";
});
```

:::moniker-end

## Access options in the request processing pipeline

::: moniker range=">= aspnetcore-6.0"

To access <xref:Microsoft.Extensions.Options.IOptions%601> or <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> in the request processing pipeline, call <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>:

```csharp
var option1 = app.Services.GetRequiredService<IOptionsMonitor<MyOptions>>()
    .CurrentValue.Option1;
```

:::moniker-end

::: moniker range="< aspnetcore-6.0"

<xref:Microsoft.Extensions.Options.IOptions%601> and <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> can be used in `Startup.Configure`, since services are built before the `Configure` method executes.

Inject `IOptionsMonitor<T>` into the `Startup.Configure` method. In the following example, the options class is `MyOptions`:

```csharp
public void Configure(IApplicationBuilder app, 
    IOptionsMonitor<MyOptions> optionsAccessor)
```

Access the options in the request processing pipeline of `Startup.Configure`:

```csharp
var option1 = optionsAccessor.CurrentValue.Option1;
```

Don't use <xref:Microsoft.Extensions.Options.IOptions%601> or <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> in `Startup.ConfigureServices`. An inconsistent options state may exist due to the ordering of service registrations.

:::moniker-end

## Additional resources

[View or download sample code (Razor Pages)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/configuration) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
