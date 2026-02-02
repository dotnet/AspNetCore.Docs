---
title: Options pattern in ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Discover how to use the options pattern to represent groups of related settings in ASP.NET Core apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 02/02/2026
uid: fundamentals/configuration/options
--- 
# Options pattern in ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

The options pattern uses classes to provide strongly typed access to groups of related settings. When [configuration settings](xref:fundamentals/configuration/index) are isolated by scenario into separate classes, the app adheres to two important software engineering principles:

* [Encapsulation](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#encapsulation): Classes that depend on configuration settings depend only on the configuration settings that they use.
* [Separation of Concerns](/dotnet/standard/modern-web-apps-azure-architecture/architectural-principles#separation-of-concerns): Settings for different parts of the app aren't dependent or coupled to one another.

Options also provide a mechanism to validate configuration data, which is described in the [Options validation](#options-validation) section.

This article provides information on the options pattern in ASP.NET Core. For information on using the options pattern in console apps, see [Options pattern in .NET](/dotnet/core/extensions/options).

The examples in this article rely on a general understanding of injecting services into classes. For more information, see <xref:fundamentals/dependency-injection>. Examples are based on [Blazor's Razor components](xref:blazor/index). To see Razor Pages examples, see the [7.0 version of this article](?view=aspnetcore-7.0&preserve-view=true). The examples in the .NET 8 or later versions of this article use [primary constructors](/dotnet/csharp/whats-new/tutorials/primary-constructors) ([Primary constructors (C# Guide)](/dotnet/csharp/programming-guide/classes-and-structs/instance-constructors#primary-constructors)) and [nullable reference types (NRTs) with .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis).

:::moniker range="< aspnetcore-8.0"

Page models of Razor Pages examples in several article sections rely on API in the <xref:Microsoft.Extensions.Options?displayName=fullName> namespace and require a `using` statement, which isn't shown by the code examples. Recent releases of Visual Studio add the namespace automatically. When not using Visual Studio, add the `using` statement to the page model file:

```csharp
using Microsoft.Extensions.Options;
```

:::moniker-end

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
public class BasicOptionsModel : PageModel
{
    private readonly IConfiguration _config;

    public BasicOptionsModel(IConfiguration config)
    {
        _config = config;
    }

    public ContentResult OnGet()
    {
        var positionOptions = new PositionOptions();
        _config.GetSection(PositionOptions.Position).Bind(positionOptions);

        return Content(
            $"Name: {positionOptions.Name}\n" +
            $"Title: {positionOptions.Title}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Joe Smith":::  
> :::no-loc text="Title: Editor":::

Changes to the JSON configuration file after the app has started are read. To demonstrate the behavior, change one or both configuration values in the app settings file and reload the page without restarting the app.

<xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%2A?displayProperty=nameWithType> binds and returns the specified type. `ConfigurationBinder.Get<T>` may be more convenient than using `ConfigurationBinder.Bind`. The following code shows how to use `ConfigurationBinder.Get<T>` with the `PositionOptions` class:

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
public class GetOptionsModel : PageModel
{
    private readonly IConfiguration _config;

    public GetOptionsModel(IConfiguration config)
    {
        _config = config;
    }

    public ContentResult OnGet()
    {
        var positionOptions = _config.GetSection(PositionOptions.Position)
            .Get<PositionOptions>();

        return Content(
            $"Name: {positionOptions?.Name}\n" +
            $"Title: {positionOptions?.Title}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Joe Smith":::  
> :::no-loc text="Title: Editor":::

Changes to the JSON configuration file after the app has started are read. To demonstrate the behavior, change one or both configuration values in the app settings file and reload the page without restarting the app.

Bind also allows the concretion of an abstract class. Consider the following code which uses the abstract class `AbstractClassWithName`:

```csharp
public abstract class AbstractClassWithName
{
    public abstract string? Name { get; set; }
}

public class NameTitleOptions(int age) : AbstractClassWithName
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
public class AbstractClassOptionsModel : PageModel
{
    private readonly IConfiguration _config;

    public AbstractClassOptionsModel(IConfiguration config)
    {
        _config = config;
    }

    public ContentResult OnGet()
    {
        var nameTitleOptions = new NameTitleOptions(22);
        _config.GetSection(NameTitleOptions.NameTitle).Bind(nameTitleOptions);

        return Content(
            $"Name: {nameTitleOptions.Name}\n" +
            $"Title: {nameTitleOptions.Title}\n" +
            $"Age: {nameTitleOptions.Age}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Sally Jones":::  
> :::no-loc text="Title: Writer":::  
> :::no-loc text="Age: 22":::

Calls to `Bind` are less strict than calls to `Get<T>`:

* `Bind` allows the concretion of an abstract class.
* `Get<T>` must create an instance itself.

## Bind options to the dependency injection service container

In the following example, `PositionOptions` is added to the service container with <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure%2A> and bound to configuration.

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
public class DIOptionsModel : PageModel
{
    private readonly IOptions<PositionOptions> _options;

    public DIOptionsModel(IOptions<PositionOptions> options)
    {
        _options = options;
    }
    
    public ContentResult OnGet()
    {
        return Content(
            $"Name: {_options.Value.Name}\n" +
            $"Title: {_options.Value.Title}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Joe Smith":::  
> :::no-loc text="Title: Editor":::

For the preceding code, changes to the JSON configuration file after the app has started are ***not*** read. To read changes after the app has started, use [`IOptionsSnapshot`](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services).

## Options interfaces

<xref:Microsoft.Extensions.Options.IOptions%601>:

* Does ***not*** support:
  * Reading of configuration data after the app has started.
  * [Named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname).
* Is registered as a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).

<xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Is useful in scenarios where options should be recomputed on every request. For more information, see the [Use IOptionsSnapshot to read updated data](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services) section.
* Is registered as a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and therefore can't be injected into a singleton service.
* Supports [named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname).

<xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

* Is used to retrieve options and manage options notifications for `TOptions` instances.
* Is registered as a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) and can be injected into any [service lifetime](/dotnet/core/extensions/dependency-injection#service-lifetimes).
* Supports:
  * Change notifications
  * [Named options](#specify-a-custom-key-name-for-a-configuration-property-using-configurationkeyname)
  * [Reloadable configuration](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services)
  * Selective options invalidation (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601>)
  
[Post-configuration](#options-post-configuration) scenarios enable setting or changing options after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs.

<xref:Microsoft.Extensions.Options.IOptionsFactory%601> is responsible for creating new options instances. It has a single <xref:Microsoft.Extensions.Options.IOptionsFactory%601.Create%2A> method. The default implementation takes all registered <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601> and runs all the configurations first, followed by the post-configuration. It distinguishes between <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and <xref:Microsoft.Extensions.Options.IConfigureOptions%601> and only calls the appropriate interface.

<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> is used by <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> to cache `TOptions` instances. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601> invalidates options instances in the monitor so that the value is recomputed (<xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryRemove%2A>). Values can be manually introduced with <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.TryAdd%2A>. The <xref:Microsoft.Extensions.Options.IOptionsMonitorCache%601.Clear%2A> method is used when all named instances should be recreated on demand.

## Use `IOptionsSnapshot` to read updated data in scoped services

Using <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>:

* Options are computed once per request when accessed and cached for the lifetime of the request.
* May incur a significant performance penalty because it's a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and is recomputed per request. For more information, see [this GitHub issue](https://github.com/dotnet/runtime/issues/53793) and [Improve the performance of configuration binding](https://github.com/dotnet/runtime/issues/36130).
* Changes to the configuration are read after the app starts when using configuration providers that support reading updated configuration values.

The difference between [`IOptionsMonitor`](#use-ioptionsmoniter-to-read-updated-data-in-singleton-services) and <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is that:

* <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) that retrieves current option values at any time, which is especially useful in singleton dependencies.
* <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and provides a snapshot of the options at the time the `IOptionsSnapshot<T>` object is constructed. Options snapshots are designed for use with transient and scoped dependencies.

The following example uses <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601>.

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

:::moniker range=">= aspnetcore-8.0"

`SnapshotOptions.razor`:

```razor
@page "/snapshot-options"
@using Microsoft.Extensions.Options
@inject IOptionsSnapshot<PositionOptions> Options

Name: @Options.Value.Name<br>
Title: @Options.Value.Title
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class SnapshotOptionsModel : PageModel
{
    private readonly IOptionsSnapshot<PositionOptions> _options;

    public SnapshotOptionsModel(IOptionsSnapshot<PositionOptions> options)
    {
        _options = options;
    }

    public ContentResult OnGet()
    {
        return Content(
            $"Name: {_options.Value.Name}\n" +
            $"Title: {_options.Value.Title}");
    }
}
```

:::moniker-end

Where services are registered for dependency injection, the following code registers a configuration instance which `PositionOptions` binds against:

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

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Joe Smith":::  
> :::no-loc text="Title: Editor":::

Changes to the JSON configuration file after the app has started are read. To demonstrate the behavior, change one or both configuration values in the app settings file and reload the page without restarting the app.

## Use `IOptionsMonitor` to read updated data in singleton services

<xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is used to retrieve options and manage options notifications for `TOptions` instances.

The difference between <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> and [`IOptionsSnapshot`](#use-ioptionssnapshot-to-read-updated-data-in-scoped-services) is that:

* <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> is a [singleton service](/dotnet/core/extensions/dependency-injection#singleton) that retrieves current option values at any time, which is especially useful in singleton dependencies.
* <xref:Microsoft.Extensions.Options.IOptionsSnapshot%601> is a [scoped service](/dotnet/core/extensions/dependency-injection#scoped) and provides a snapshot of the options at the time the `IOptionsSnapshot<T>` object is constructed. Options snapshots are designed for use with transient and scoped dependencies.

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

Where services are registered for dependency injection, the following code registers a configuration instance which `PositionOptions` binds against:

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

The following example uses <xref:Microsoft.Extensions.Options.IOptionsMonitor%601>:

:::moniker range=">= aspnetcore-8.0"

`MonitorOptions.razor`:

```razor
@page "/monitor-options"
@using Microsoft.Extensions.Options
@inject IOptionsMonitor<PositionOptions> Options

Name: @Options.CurrentValue.Name<br>
Title: @Options.CurrentValue.Title
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class MonitorOptionsModel : PageModel
{
    private readonly IOptionsMonitor<PositionOptions> _options;

    public MonitorOptionsModel(IOptionsMonitor<PositionOptions> options)
    {
        _options = options;
    }

    public ContentResult OnGet()
    {
        return Content(
            $"Name: {_options.CurrentValue.Name}\n" +
            $"Title: {_options.CurrentValue.Title}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Joe Smith":::  
> :::no-loc text="Title: Editor":::

Changes to the JSON configuration file after the app has started are read. To demonstrate the behavior, change one or both configuration values in the app settings file and reload the page without restarting the app.

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

The `Name` and `Title` class properties are bound to the `PositionName` and `PositionTitle` from the following JSON configuration:

```json
"PositionKeyName": {
  "PositionName": "Carlos Diego",
  "PositionTitle": "Director"
}
```

:::moniker-end

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

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```csharp
public class PositionKeyNameModel : PageModel
{
    private readonly IConfiguration _config;

    public PositionKeyNameModel(IConfiguration config)
    {
        _config = config;
    }

    public ContentResult OnGet()
    {
        var positionOptions = _config.GetSection(PositionKeyName.Position)
            .Get<PositionKeyName>();

        return Content(
            $"Name: {positionOptions?.Name}\n" +
            $"Title: {positionOptions?.Title}");
    }
}
```

:::moniker-end

Output:

<!-- DOC AUTHOR NOTE

The following block quote uses two spaces at the ends of lines (except the
last line) to create returns in the rendered content. Don't remove the two 
spaces at the ends of the lines when editing the following content.

-->

> :::no-loc text="Name: Carlos Diego":::  
> :::no-loc text="Title: Director":::

Changes to the JSON configuration file after the app has started are read. To demonstrate the behavior, change one or both configuration values in the app settings file and reload the page without restarting the app.

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

:::moniker range=">= aspnetcore-8.0"

`NamedOptions.razor`:

```razor
@page "/named-options"
@using Microsoft.Extensions.Options
@inject IOptionsSnapshot<TopItemSettings> Options

Month: Name: @monthTopItem?.Name Model: @monthTopItem?.Model<br>
Year: Name: @yearTopItem?.Name Model: @yearTopItem?.Model

@code {
    private TopItemSettings? monthTopItem;
    private TopItemSettings? yearTopItem;

    protected override void OnInitialized()
    {
        monthTopItem = Options.Get(TopItemSettings.Month);
        yearTopItem = Options.Get(TopItemSettings.Year);
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class NamedOptionsModel : PageModel
{
    private readonly IOptionsSnapshot<TopItemSettings> _options;

    public NamedOptionsModel(IOptionsSnapshot<TopItemSettings> options)
    {
        _options = options;
    }

    public ContentResult OnGet()
    {
        var monthTopItem = _options.Get(TopItemSettings.Month);
        var yearTopItem = _options.Get(TopItemSettings.Year);

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
builder.Services.AddOptions<PositionOptions>("optionalName")
    .Configure<Service1, Service2, Service3, Service4, Service5>(
        (o, s, s2, s3, s4, s5) => 
            o.Property = DoSomethingWith(s, s2, s3, s4, s5));
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<PositionOptions>("optionalName")
    .Configure<Service1, Service2, Service3, Service4, Service5>(
        (o, s, s2, s3, s4, s5) => 
            o.Property = DoSomethingWith(s, s2, s3, s4, s5));
```

::: moniker-end

### Configuration options service approach

Create a type that implements <xref:Microsoft.Extensions.Options.IConfigureOptions%601> or <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601> and register the type as a service.

We recommend passing a configuration delegate to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>, since creating a service is more complex. Creating a type is equivalent to what the framework does when calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>. Calling <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A> registers a transient generic <xref:Microsoft.Extensions.Options.IConfigureNamedOptions%601>, which has a constructor that accepts the generic service types specified. 

## Options validation

Options validation enables the validation of option values.

Consider the following `appsettings.json` file:

```json
"KeyOptions": {
  "Key1": "Key One",
  "Key2": 10,
  "Key3": 32
}
```

The following class is used to bind to the `"KeyOptions"` configuration section and applies two data annotations rules, which include a regular expression and range requirement:

```csharp
public class KeyOptions
{
    public const string Key = "KeyOptions";

    [RegularExpression(@"^[a-zA-Z\s]{1,40}$")]
    public string? Key1 { get; set; }

    [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
    public int Key2 { get; set; }
    public int Key3 { get; set; }
}
```

Where services are registered for dependency injection, the following code:

* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%2A> to get an <xref:Microsoft.Extensions.Options.OptionsBuilder%601> that binds to the `KeyOptions` class.
* Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> to enable validation.

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key))
    .ValidateDataAnnotations();
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key))
    .ValidateDataAnnotations();
```

::: moniker-end

The <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> extension method is defined in the [`Microsoft.Extensions.Options.DataAnnotations` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Options.DataAnnotations). For web apps that use the `Microsoft.NET.Sdk.Web` SDK, this package is referenced implicitly from the [shared framework](xref:fundamentals/metapackage-app).

:::moniker range=">= aspnetcore-8.0"

> [!NOTE]
> For demonstration purposes, the following example uses a <xref:Microsoft.AspNetCore.Components.MarkupString> to format raw HTML. Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided. For more information, see <xref:blazor/components/index#raw-html>.

`OptionsValidation.razor`:

```razor
@page "/options-validation"
@inject IOptionsSnapshot<KeyOptions> Options
@inject ILogger<OptionsValidation> Logger

@if (message is not null)
{
    @((MarkupString)message)
}

@code {
    private string? message;

    protected override void OnInitialized()
    {
        try
        {
            var configValue = Options.Value;
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
            message = 
                $"Key1: {Options.Value.Key1}<br>" +
                $"Key2: {Options.Value.Key2}<br>" +
                $"Key3: {Options.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            message = optValEx.Message;
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class OptionsValidationModel : PageModel
{
    private readonly IOptionsSnapshot<KeyOptions>? _options;

    public OptionsValidationModel(IOptionsSnapshot<KeyOptions> options,
        ILogger<OptionsValidationModel> logger)
    {
        _options = options;

        try
        {
            var configValue = _options?.Value;
        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                logger?.LogError("Validation: {Failure}", failure);
            }
        }
    }

    public ContentResult OnGet()
    {
        string message;

        try
        {
            message =
                $"Key1: {_options?.Value.Key1}\n" +
                $"Key2: {_options?.Value.Key2}\n" +
                $"Key3: {_options?.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            return Content(optValEx.Message);
        }

        return Content(message);
    }
}
```

:::moniker-end

The preceding code displays the configuration values or validation errors:

* Use the code with the preceding app settings configuration to demonstrate no validation errors.
* Change the configuration in the app settings file in one or more ways that violate the data annotations rules. Reload the options validation page to see the rule violations.

In the following example, the page content indicates that the value of `Key2` is out of range:

> :::no-loc text="DataAnnotation validation failed for 'KeyOptions' members: 'Key2' with the error: 'Value for Key2 must be between 0 and 1000.'.":::

Where services are registered for dependency injection, the following code applies a more complex validation rule using a delegate:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddOptions<KeyOptions>()
        .Bind(builder.Configuration.GetSection(KeyOptions.Key))
        .ValidateDataAnnotations()
    .Validate(options =>
    {
        return options.Key3 > options.Key2;
    }, "Key3 must be > than Key2");
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.AddOptions<KeyOptions>()
        .Bind(builder.Configuration.GetSection(KeyOptions.Key))
        .ValidateDataAnnotations()
    .Validate(options =>
    {
        return options.Key3 > options.Key2;
    }, "Key3 must be > than Key2");
```

::: moniker-end

To demonstrate a validation failure with the preceding example, make the `Key3` value smaller than the `Key2` value in the app settings file and reload the page.

Output:

> :::no-loc text="Key3 must be > than Key2":::

### Validate options in a dedicated class with `IValidateOptions<TOptions>`

Implement <xref:Microsoft.Extensions.Options.IValidateOptions%601> to validate options without the need to maintain validation rules with data annotations or in the app's `Program` file.

In the following example, the data annotations rules and options delegate validation of the preceding examples is moved to a validation class. The Options model class (`KeyOptions2`) doesn't contain data annotations.

`KeyOptions2.cs`:

```csharp
public class KeyOptions2
{
    public const string Key = "KeyOptions";

    public string? Key1 { get; set; }
    public int Key2 { get; set; }
    public int Key3 { get; set; }
}
```

::: moniker range=">= aspnetcore-8.0"

```csharp
public class KeyOptionsValidation : IValidateOptions<KeyOptions2>
{
    public ValidateOptionsResult Validate(string? name, KeyOptions2 options)
    {
        if (options == null)
        {
            return ValidateOptionsResult.Fail("KeyOptions not found.");
        }

        StringBuilder? validationResult = new();
        var rx = new Regex(@"^[a-zA-Z\s]{1,40}$");
        var match = rx.Match(options.Key1!);

        if (string.IsNullOrEmpty(match.Value))
        {
            validationResult.Append($"{options.Key1} doesn't match RegEx<br>");
        }

        if (options.Key2 < 0 || options.Key2 > 1000)
        {
            validationResult.Append($"{options.Key2} doesn't match Range 0 - 1000<br>");
        }

        if (options.Key3 < options.Key2)
        {
            validationResult.Append("Key3 must be > than Key2<br>");
        }

        if (validationResult.Length > 0)
        {
            return ValidateOptionsResult.Fail(validationResult.ToString());
        }

        return ValidateOptionsResult.Success;
    }
}
```

:::moniker-end

::: moniker range="< aspnetcore-8.0"

```csharp
public class KeyOptionsValidation : IValidateOptions<KeyOptions2>
{
    public ValidateOptionsResult Validate(string? name, KeyOptions2 options)
    {
        if (options == null)
        {
            return ValidateOptionsResult.Fail("KeyOptions not found");
        }

        StringBuilder? validationResult = new();
        var rx = new Regex(@"^[a-zA-Z\s]{1,40}$");
        var match = rx.Match(options.Key1!);

        if (string.IsNullOrEmpty(match.Value))
        {
            validationResult.Append($"{options.Key1} doesn't match RegEx\n");
        }

        if (options.Key2 < 0 || options.Key2 > 1000)
        {
            validationResult.Append($"{options.Key2} doesn't match Range 0 - 1000\n");
        }

        if (options.Key3 < options.Key2)
        {
            validationResult.Append("Key3 must be > than Key2\n");
        }

        if (validationResult.Length > 0)
        {
            return ValidateOptionsResult.Fail(validationResult.ToString());
        }

        return ValidateOptionsResult.Success;
    }
}
```

:::moniker-end

Where services are registered for dependency injection and using the preceding code, validation is enabled in `Program.cs` with the following code:

::: moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.Configure<KeyOptions2>(
    builder.Configuration.GetSection(KeyOptions2.Key));

builder.Services.AddSingleton<IValidateOptions<KeyOptions2>, 
    KeyOptionsValidation>();
```

::: moniker-end

::: moniker range="< aspnetcore-6.0"

```csharp
services.Configure<KeyOptions>(
    builder.Configuration.GetSection(KeyOptions2.Key));

services.AddSingleton<IValidateOptions<KeyOptions2>, 
    KeyOptionsValidation>();
```

::: moniker-end

`OptionsValidation2.razor`:

```razor
@page "/options-validation-2"
@inject IOptionsSnapshot<KeyOptions2> Options
@inject ILogger<OptionsValidation> Logger

@if (message is not null)
{
    @((MarkupString)message)
}

@code {
    private string? message;

    protected override void OnInitialized()
    {
        try
        {
            var configValue = Options.Value;
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
            message = 
                $"Key1: {Options.Value.Key1}<br>" +
                $"Key2: {Options.Value.Key2}<br>" +
                $"Key3: {Options.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            message = optValEx.Message;
        }
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```csharp
public class OptionsValidationModel : PageModel
{
    private readonly IOptionsSnapshot<KeyOptions2>? _options;

    public OptionsValidationModel(IOptionsSnapshot<KeyOptions2> options,
        ILogger<OptionsValidationModel> logger)
    {
        _options = options;

        try
        {
            var configValue = _options?.Value;
        }
        catch (OptionsValidationException ex)
        {
            foreach (var failure in ex.Failures)
            {
                logger?.LogError("Validation: {Failure}", failure);
            }
        }
    }

    public ContentResult OnGet()
    {
        string message;

        try
        {
            message =
                $"Key1: {_options?.Value.Key1}\n" +
                $"Key2: {_options?.Value.Key2}\n" +
                $"Key3: {_options?.Value.Key3}";
        }
        catch (OptionsValidationException optValEx)
        {
            return Content(optValEx.Message);
        }

        return Content(message);
    }
}
```

## Class-level validation with `IValidatableObject`

Options validation supports <xref:System.ComponentModel.DataAnnotations.IValidatableObject> to perform class-level validation of a class within a class:

* Implement the <xref:System.ComponentModel.DataAnnotations.IValidatableObject> interface and its <xref:System.ComponentModel.DataAnnotations.IValidatableObject.Validate%2A> method within the class.
* Call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderDataAnnotationsExtensions.ValidateDataAnnotations%2A> in the `Program` file.

::: moniker range=">= aspnetcore-6.0"

### Run options validation when the app starts with `ValidateOnStart`

Options validation runs the first time a `TOption` instance is created. That means, for instance, when first 
access to [`IOptionsSnapshot<TOptions>.Value`](xref:Microsoft.Extensions.Options.IOptionsSnapshot%601) occurs in a request pipeline or when 
[`IOptionsMonitor<TOptions>.Get(string)`](xref:Microsoft.Extensions.Options.OptionsMonitor`1.Get(System.String)) is called on settings present. After settings are reloaded, validation runs again. The ASP.NET Core runtime uses <xref:Microsoft.Extensions.Options.OptionsCache%601> to cache the options instance once it is created.

To run options validation when the app starts, call <xref:Microsoft.Extensions.DependencyInjection.OptionsBuilderExtensions.ValidateOnStart%2A> in the `Program` file:

```csharp
builder.Services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key))
    .ValidateDataAnnotations()
    .ValidateOnStart();
```

:::moniker-end

## Options post-configuration

::: moniker range=">= aspnetcore-6.0"

Where services are registered for dependency injection, set post-configuration with <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601>. Post-configuration runs after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs:

```csharp
builder.Services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key));

builder.Services.PostConfigure<KeyOptions>(options =>
{
    options.Key1 = "Post configured Key1 value";
});
```

Where services are registered for dependency injection, <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601.PostConfigure%2A> is available to post-configure named options:

```csharp
builder.Services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
builder.Services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));

builder.Services.PostConfigure<TopItemSettings>("Month", options =>
{
    options.Name = "Post configured Name";
    options.Model = "Post configured Value";
});
```

Where services are registered for dependency injection, use <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> to post-configure all configuration instances:

```csharp
builder.Services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key));

builder.Services.PostConfigureAll<KeyOptions>(options =>
{
    options.Key1 = "Post configured Key1 value";
});
```

:::moniker-end

::: moniker range="< aspnetcore-6.0"

Where services are registered for dependency injection, set post-configuration with <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601>. Post-configuration runs after all <xref:Microsoft.Extensions.Options.IConfigureOptions%601> configuration occurs:

```csharp
services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key));

services.PostConfigure<KeyOptions>(options =>
{
    options.Key1 = "Post configured Key1 value";
});
```

Where services are registered for dependency injection, <xref:Microsoft.Extensions.Options.IPostConfigureOptions%601.PostConfigure%2A> is available to post-configure named options:

```csharp
services.Configure<TopItemSettings>(TopItemSettings.Month,
    builder.Configuration.GetSection("TopItem:Month"));
services.Configure<TopItemSettings>(TopItemSettings.Year,
    builder.Configuration.GetSection("TopItem:Year"));

services.PostConfigure<TopItemSettings>("Month", options =>
{
    options.Name = "Post configured Name value";
    options.Model = "Post configured Model value";
});
```

Where services are registered for dependency injection, use <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigureAll%2A> to post-configure all configuration instances:

```csharp
services.AddOptions<KeyOptions>()
    .Bind(builder.Configuration.GetSection(KeyOptions.Key));

services.PostConfigureAll<KeyOptions>(options =>
{
    options.Key1 = "Post configured Key1 value";
});
```

:::moniker-end

## Access options in the request processing pipeline

::: moniker range=">= aspnetcore-6.0"

To access <xref:Microsoft.Extensions.Options.IOptions%601> or <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> in the request processing pipeline, call <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplication.Services%2A?displayProperty=nameWithType>:

```csharp
var name = app.Services.GetRequiredService<IOptionsMonitor<PositionOptions>>()
    .CurrentValue.Name;
```

:::moniker-end

::: moniker range="< aspnetcore-6.0"

<xref:Microsoft.Extensions.Options.IOptions%601> and <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> can be used in `Startup.Configure`, since services are built before the `Configure` method executes.

Inject `IOptionsMonitor<T>` into the `Startup.Configure` method. In the following example, the options class is `MyOptions`:

```csharp
public void Configure(IApplicationBuilder app, 
    IOptionsMonitor<PositionOptions> options)
```

Access the options in the request processing pipeline of `Startup.Configure`:

```csharp
var name = options.CurrentValue.Name;
```

Don't use <xref:Microsoft.Extensions.Options.IOptions%601> or <xref:Microsoft.Extensions.Options.IOptionsMonitor%601> in `Startup.ConfigureServices`. An inconsistent options state may exist due to the ordering of service registrations.

:::moniker-end

## Additional resources

[View or download sample code (Razor Pages)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/configuration) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
