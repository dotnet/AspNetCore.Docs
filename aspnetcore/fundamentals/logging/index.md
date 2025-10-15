---
title: Logging in .NET and ASP.NET Core
ai-usage: ai-assisted
author: tdykstra
description: Learn how to use the ASP.NET Core logging framework provided by the Microsoft.Extensions.Logging NuGet package.
monikerRange: '>= aspnetcore-3.1'
ms.author: tdykstra
ms.custom: mvc
ms.date: 10/01/2025
uid: fundamentals/logging/index
---
# Logging in .NET and ASP.NET Core

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes logging in ASP.NET Core apps. For general guidance on logging in .NET, see [Logging in C# and .NET](/dotnet/core/extensions/logging). For Blazor logging guidance, which adds to or supersedes this guidance, see <xref:blazor/fundamentals/logging>.

## Logging providers

ASP.NET Core supports high performance, structured logging via the <xref:Microsoft.Extensions.Logging.ILogger> API to help you monitor app behavior and diagnose problems. Logs are written to different destinations by configuring *logging providers*. A set of logging providers are built into the framework, and there are many third-party providers available. Multiple providers can be enabled in an app.

Most logging providers write log messages to a data storage system. For example, the Azure Application Insights logging provider stores logs in [Azure Application Insights](/azure/azure-monitor/app/app-insights-overview). One provider, the `Console` provider, only displays log messages. The `Console` provider is useful when running an app locally for monitoring and debugging in real time.

:::moniker range=">= aspnetcore-6.0"

Apps created from an ASP.NET Core web app project template call <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType> in the app's `Program` file, which adds the following default logging providers:

* [`Console`](#console)
* [`Debug`](#debug)
* [`EventSource`](#eventsource)
* [Windows `EventLog`](#windows-eventlog)

```csharp
var builder = WebApplication.CreateBuilder(args);
```

To override the default logging providers, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Logging%2A?displayProperty=nameWithType> and use logging provider extension methods to add logging providers. The following example only sets up the [`Console`](#console) logging provider:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
```

Alternatively, the preceding code can be written as follows with <xref:Microsoft.Extensions.Logging.ILoggingBuilder> of <xref:Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.ConfigureLogging%2A>:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Apps created from an ASP.NET Core web app project template call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A?displayProperty=nameWithType>, which adds the following default logging providers:

* [`Console`](#console)
* [`Debug`](#debug)
* [`EventSource`](#eventsource)
* [Windows `EventLog`](#windows-eventlog)

```csharp
Host.CreateDefaultBuilder(args)
```

To override the default logging providers, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> to remove all the <xref:Microsoft.Extensions.Logging.ILoggerProvider> instances from the <xref:Microsoft.Extensions.Logging.ILoggingBuilder> and use logging provider extension methods to add logging providers. The following example only sets up the [`Console`](#console) logging provider:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
```

:::moniker-end

Additional providers are covered in the [Built-in logging providers](#built-in-logging-providers) and [Third-party logging providers](#third-party-logging-providers) sections.

## Logging output

Logs created by the [default logging providers](#logging-providers) are displayed:

* In Visual Studio
  * In the **Debug** output window when debugging.
  * In the **ASP.NET Core Web Server** window.
* In the command shell when the app is run with the [`dotnet run`](/dotnet/core/tools/dotnet-run) command.

.NET in general and ASP.NET Core use the same logging API and providers. More information can be found in [Logging in C# and .NET](/dotnet/core/extensions/logging), which covers general logging scenarios for C# and .NET. This article focuses on ASP.NET Core app logging.

## Create log messages

To create log messages, use an <xref:Microsoft.Extensions.Logging.ILogger%601> object from [dependency injection (DI)](xref:fundamentals/dependency-injection).

The following examples:

* Create an <xref:Microsoft.Extensions.Logging.ILogger> that specifies a log *category* based on the fully qualified name of the type. The log category is a string that is associated with each log, which is useful for identifying, sorting, and filtering log messages. More information on [log categories](#log-category) is provided later in this article.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Information> level. The log *level* indicates the severity of the logged event. More information on [log levels](#log-level) is provided later in this article.

In the following counter page (`Counter` Razor component) in a Blazor app, an `ILogger<Counter>` is injected with the [`@inject` directive](xref:mvc/views/razor#inject). The logger instance (`Logger`) is used to log information when the `IncrementCount` method is called.

`Pages/Counter.razor`:

```razor
@page "/counter"
@inject ILogger<Counter> Logger

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        Logger.LogInformation("Someone incremented the counter!");

        currentCount++;
    }
}
```

:::moniker range="< aspnetcore-6.0"

> [!NOTE]
> In .NET 5 or earlier, an [`@using` directive](xref:mvc/views/razor#using) for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) logging API completions in Razor components.

:::moniker-end

Log message:

> :::no-loc text="BlazorSample.Components.Pages.Counter: Information: Someone incremented the counter!":::

The log category is `BlazorSample.Components.Pages.Counter`, and the log level (severity) is `Information`. The message is `Someone incremented the counter!`.

In the following Razor Pages privacy page class file, an `ILogger<PrivacyModel>` is injected into the class's constructor to log when the page is visited. Note in this example that the message is a *template* that takes the current UTC date and time (`DateTime.UtcNow`) and writes it into the log message. Log message templates are covered in the [Log message template](#log-message-template) section later in this article.

`Pages/Privacy.cshtml.cs`:

```csharp
public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
{
    public void OnGet() => logger.LogInformation("Privacy page visited at {DT}", 
        DateTime.UtcNow);
}
```

## Log message template

The log message template can contain placeholders for provided arguments. Use names for the placeholders, not numbers.

In the following examples, `{Id}` is an identifier placeholder for an item ID, and `id` is the identifier parameter.

```csharp
Logger.LogInformation(LogEvent.GetItem, "Getting item {Id}", id);
```

```csharp
Logger.LogWarning(LogEvent.GetItemNotFound, "Get({Id}) NOT FOUND", id);
```

The *order of the parameters*, not their placeholder names, determines which parameters are used to provide placeholder values in log messages. In the following code, the parameter names are out of sequence in the placeholders of the message template:

```csharp
var apples = 1;
var pears = 2;
var bananas = 3;

Logger.LogInformation("{Pears}, {Bananas}, {Apples}", apples, pears, bananas);
```

However, the parameters are assigned to the placeholders in the order: `apples`, `pears`, `bananas`. The log message reflects the *order of the parameters*:

```text
1, 2, 3
```

This approach allows logging providers to implement [semantic or structured logging](https://github.com/NLog/NLog/wiki/How-to-use-structured-logging). The arguments themselves are passed to the logging system, not just the formatted message template. This enables logging providers to store the parameter values as fields. For example, consider the following logger method:

```csharp
Logger.LogInformation("Getting item {Id} at {RequestTime}", id, DateTime.Now);
```

When logging to Azure Table Storage:

* Each Azure Table entity can have `ID` and `RequestTime` properties.
* Tables with properties simplify queries on logged data. For example, a query can find all logs within a particular `RequestTime` range without having to parse the time out of the text message.

## Log at app startup

:::moniker range=">= aspnetcore-6.0"

The following example calls <xref:Microsoft.AspNetCore.Builder.WebApplication.Logger%2A?displayProperty=nameWithType> in the `Program` file to log informational messages:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Logger.LogInformation("Adding Routes");

app.MapGet("/", () => "Hello World!");

app.Logger.LogInformation("Starting the app");

app.Run();
```

The following example calls <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole%2A> and logs at the `/Test` endpoint:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async (ILogger<Program> logger, HttpResponse response) =>
{
    logger.LogInformation("'Test' logging in the Program file");
    await response.WriteAsync("Testing");
});

app.Run();
```

The following example calls <xref:Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddSimpleConsole%2A>, disables color output with a [console formatter option](xref:Microsoft.Extensions.Logging.Console.SimpleConsoleFormatterOptions), and logs at the `/Test` endpoint:

```csharp
using Microsoft.Extensions.Logging.Console;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(
    option => option.ColorBehavior = LoggerColorBehavior.Disabled);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/Test", async (ILogger<Program> logger, HttpResponse response) =>
{
    logger.LogInformation("'Test' logging in the Program file");
    await response.WriteAsync("Testing");
});

app.Run();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The following code logs in `Program.Main` by obtaining an <xref:Microsoft.Extensions.Logging.ILogger> instance from DI after building the host:

```csharp
public static void Main(string[] args)
{
    var host = CreateHostBuilder(args).Build();

    var logger = host.Services.GetRequiredService<ILogger<Program>>();
    logger.LogInformation("Host created.");

    host.Run();
}
```

The following example shows how to inject an <xref:Microsoft.Extensions.Logging.ILogger> into `Startup.Configure`:

```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
{
    logger.LogInformation("'Startup'.Configure' logging");

    ...
}
```

Logger injection into the `Startup` constructor or into the `Startup.ConfigureServices` method isn't supported because logging depends on dependency injection (DI) and on configuration, which in turns depends on DI. The DI container isn't set up until `ConfigureServices` finishes executing.

For information on configuring a service that depends on <xref:Microsoft.Extensions.Logging.ILogger> or why constructor injection of a logger into `Startup` worked in earlier versions, see the [Configure a service that depends on `ILogger`](#configure-a-service-that-depends-on-ilogger) section.

:::moniker-end

## Configure logging

When an <xref:Microsoft.Extensions.Logging.ILogger> object is created, a *category* is specified. That category is included with each log message created by that instance of the logger.

The log level determines the level of detail for log messages at a default level for the app as a whole and for specific app assemblies. The log level can be set by any of the [configuration providers](xref:fundamentals/configuration/index).

### App settings

Logging configuration is commonly provided by the `Logging` section of `appsettings.{ENVIRONMENT}.json` files, where the `{ENVIRONMENT}` placeholder is the [environment](xref:fundamentals/environments). The following `appsettings.Development.json` file is generated by the ASP.NET Core web app templates:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

In the preceding JSON:

* The `"Default"` and `"Microsoft.AspNetCore"` categories are specified.
* The `"Microsoft.AspNetCore"` category applies to all categories that start with `"Microsoft.AspNetCore"`. For example, this setting applies to the `"Microsoft.AspNetCore.Routing.EndpointMiddleware"` category.
* The `"Microsoft.AspNetCore"` category logs at log level `Warning` and higher (more severe).
* A specific log provider isn't specified, so `LogLevel` applies to all the enabled logging providers except for the [Windows `EventLog`](#windows-eventlog).

The `Logging` property can have <xref:Microsoft.Extensions.Logging.LogLevel> and log provider properties. The `LogLevel` specifies the minimum [level](#log-level) to log for selected categories. In the preceding JSON, `Information` and `Warning` log levels are specified. `LogLevel`s indicate the severity of the log, which are shown in the following table with their corresponding `enum` values.

Log Level | Value
--- | :---:
`Trace` | 0
`Debug` | 1
`Information` | 2
`Warning` | 3
`Error` | 4
`Critical` | 5
`None` | 6

When a `LogLevel` is specified, logging is enabled for messages at the specified level and higher (more severe). In the preceding JSON, the `Default` category is logged for `Information` and higher. For example, `Information`, `Warning`, `Error`, and `Critical` messages are logged. If no `LogLevel` is specified, logging defaults to the `Information` level. For more information, see [Log levels](#log-level).

A provider property can specify a `LogLevel` property. `LogLevel` under a provider specifies levels to log for that provider, and overrides the non-provider log settings. Consider the following `appsettings.json` file:

```json
{
  "Logging": {
    "LogLevel": { // All providers, LogLevel applies to all the enabled providers.
      "Default": "Error", // Default logging, Error and higher.
      "Microsoft": "Warning" // All Microsoft* categories, Warning and higher.
    },
    "Debug": { // Debug provider.
      "LogLevel": {
        "Default": "Information", // Overrides preceding LogLevel:Default setting.
        "Microsoft.Hosting": "Trace" // Debug:Microsoft.Hosting category.
      }
    },
    "EventSource": { // EventSource provider
      "LogLevel": {
        "Default": "Warning" // All categories of EventSource provider.
      }
    }
  }
}
```

Settings in `Logging.{PROVIDER NAME}.LogLevel` override settings in `Logging.LogLevel`, where the `{PROVIDER NAME}` placeholder is the provider name. In the preceding JSON, the `Debug` provider's default log level is set to `Information`:

`Logging:Debug:LogLevel:Default:Information`

The preceding setting specifies the `Information` log level for every `Logging:Debug:` category except `Microsoft.Hosting`. When a specific category is listed, the specific category overrides the default category. In the preceding JSON, the `Logging:Debug:LogLevel` categories `"Microsoft.Hosting"` and `"Default"` override the settings in `Logging:LogLevel`.

The minimum log level can be specified for any of:

* Specific providers example: `Logging:EventSource:LogLevel:Default:Information`
* Specific categories example: `Logging:LogLevel:Microsoft:Warning`
* All providers and all categories: `Logging:LogLevel:Default:Warning`

Any logs below the minimum level are ***not***:

* Passed to the provider.
* Logged or displayed.

To suppress all logs, specify <xref:Microsoft.Extensions.Logging.LogLevel.None?displayProperty=nameWithType>. `LogLevel.None` has a value of 6, which is higher than `LogLevel.Critical` (5).

If a provider supports [log scopes](#log-scopes), `IncludeScopes` indicates whether they're enabled. For more information, see [log scopes](#log-scopes).

The following `appsettings.json` file contains all the providers enabled by default:

```json
{
  "Logging": {
    "LogLevel": { // No provider, LogLevel applies to all the enabled providers.
      "Default": "Error",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Warning"
    },
    "Debug": { // Debug provider.
      "LogLevel": {
        "Default": "Information" // Overrides preceding LogLevel:Default setting.
      }
    },
    "Console": {
      "IncludeScopes": true,
      "LogLevel": {
        "Microsoft.AspNetCore.Mvc.Razor.Internal": "Warning",
        "Microsoft.AspNetCore.Mvc.Razor.Razor": "Debug",
        "Microsoft.AspNetCore.Mvc.Razor": "Error",
        "Default": "Information"
      }
    },
    "EventSource": {
      "LogLevel": {
        "Microsoft": "Information"
      }
    },
    "EventLog": {
      "LogLevel": {
        "Microsoft": "Information"
      }
    },
    "AzureAppServicesFile": {
      "IncludeScopes": true,
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "AzureAppServicesBlob": {
      "IncludeScopes": true,
      "LogLevel": {
        "Microsoft": "Information"
      }
    },
    "ApplicationInsights": {
      "LogLevel": {
        "Default": "Information"
      }
    }
  }
}
```

In the preceding sample:

* The categories and levels aren't suggested values. The sample is provided to show all of the default providers.
* Settings in `Logging.{PROVIDER NAME}.LogLevel` override settings in `Logging.LogLevel`, where the `{PROVIDER NAME}` placeholder is the provider name. For example, the level in `Debug.LogLevel.Default` overrides the level in `LogLevel.Default`.
* Each default provider *alias* is used. Each provider defines an *alias* that can be used in configuration in place of the fully qualified type name. The built-in providers aliases are:
  * `Console`
  * `Debug`
  * `EventSource`
  * `EventLog`
  * `AzureAppServicesFile`
  * `AzureAppServicesBlob`
  * `ApplicationInsights`

### Command shell

Environment variables for logging configuration can be set via a command shell.

[!INCLUDE[](~/includes/environmentVarableColon.md)]

Set an environment variable with the [`set`](/windows-server/administration/windows-commands/set) command on Windows for the current command shell. In the following example, the environment key `Logging:LogLevel:Microsoft` is set to a value of `Information`. You can test the setting with any app created from an ASP.NET Core web app project template. 

```dotnetcli
set Logging__LogLevel__Microsoft=Information
```

Execute the [`dotnet run`](/dotnet/core/tools/dotnet-run) command in the project directory after executing the preceding `set` command:

```dotnetcli
dotnet run
```

The preceding environment variable:

* Is only set for apps launched from the current command shell.
* Isn't read by browsers launched by Visual Studio or Visual Studio Code.

Use the [`setx`](/windows-server/administration/windows-commands/setx) to persist the environment variable across command shell instances. The `/M` switch sets the variable in the system environment. If `/M` isn't used, a user environment variable is set.

```console
setx Logging__LogLevel__Microsoft Information /M
```

<!-- Dan, the following NOTE was already here. Are you OK with this?
     Seems like WE should cover whatever WE want to say
     on this subject, or we shouldn't cover this, leaving it up
     to their platform docs to address. -->

> [!NOTE]
> When configuring environment variables with names that contain `.` (periods) in macOS and Linux, consider the "Exporting a variable with a dot (.) in it" question on **Stack Exchange** and its corresponding [accepted answer](https://unix.stackexchange.com/a/93533).

### Configure Azure App Service

On [Azure App Service](https://azure.microsoft.com/services/app-service/), follow the guidance in [Configure an App Service app](/azure/app-service/configure-common?tabs=portal#configure-app-settings) to set logging environment variables.

For more information, see [Azure Apps: Override app configuration using the Azure portal](xref:host-and-deploy/azure-apps/index#override-app-configuration-using-the-azure-portal).

## Log category

When an <xref:Microsoft.Extensions.Logging.ILogger> object is created, a *category* is specified. The category is included with each log message created by that instance of the logger. The category string is arbitrary, but the convention is to use the fully qualified class name. The ASP.NET Core web apps use [`ILogger<T>`](xref:Microsoft.Extensions.Logging.ILogger) to create a logger instance that uses the fully qualified type name of `T` as the category.

Log messages with a category name that begins with "Microsoft" are from .NET. Typically, log messages that begin with the app's assembly name are from the app. Packages outside of .NET usually have a category based on an assembly name from the package. For a list of common log categories, see the [Common log categories](#common-log-categories) section.

In a Razor component of a Blazor app, where the type `T` is `Counter` for a counter page rendered by a `Counter` component (`Pages/Counter.razor`):

```razor
@inject ILogger<Counter> Logger
```

In a Razor Pages page class model, where the type `T` is `PrivacyModel` for a privacy page (`Pages/Privacy.cshtml.cs`):

```csharp
public class PrivacyModel(ILogger<PrivacyModel> logger) : PageModel
```

If further categorization is desired, the convention is to use a hierarchical name by appending a subcategory to the fully qualified class name using <xref:Microsoft.Extensions.Logging.ILoggerFactory.CreateLogger%2A?displayProperty=nameWithType>. This approach is useful for scoping log messages to component or class methods.

The following `Counter` component logs from the `IncrementByOne` method with the `BlazorSample.Components.Pages.Counter.IncrementByOne` category and from the `IncrementByTen` method with the `BlazorSample.Components.Pages.Privacy.IncrementByTen` category.

`Pages/Counter.razor`:

```razor
@page "/counter"
@inject ILogger<Counter> Logger

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementByOne">Click me (+1)</button>
<button class="btn btn-primary" @onclick="IncrementByTen">Click me (+10)</button>

@code {
    private int currentCount = 0;

    private void IncrementByOne()
    {
        var logger = Logger.CreateLogger($"{typeof(Counter)}.IncrementByOne");

        Logger.LogInformation("Someone incremented the counter!");

        currentCount++;
    }

    private void IncrementByTen()
    {
        var logger = Logger.CreateLogger($"{typeof(Counter)}.IncrementByTen");

        Logger.LogInformation("Someone incremented the counter!");

        currentCount += 10;
    }
}
```

Log messages:

> :::no-loc text="BlazorSample.Components.Pages.Counter.IncrementByOne: Information: Someone incremented the counter!":::  
> :::no-loc text="BlazorSample.Components.Pages.Counter.IncrementByTen: Information: Someone incremented the counter!":::

In a Razor Pages page class model that uses a custom category ("`CustomCategory`") for the entire page model:

<!-- Dan, do you want to go with primary ctor for this next example? -->

```csharp
public class PrivacyModel : PageModel
{
    private readonly ILogger _logger;

    public PrivacyModel(ILoggerFactory logger)
    {
        _logger = logger.CreateLogger($"{typeof(PrivacyModel)}.CustomCategory");
    }

    public void OnGet() =>
        _logger.LogInformation("Privacy page visited at {DT}"), DateTime.UtcNow);
}
```

## Log event ID

Each log message can specify an *event ID*. The following example creates a set of custom event IDs for use by an app. Notice how the IDs are in the 1,000 range for create, read, update, and delete (CRUD) operations, 3,000 for test logging, and in the 4,000 range for not found scenarios:

```csharp
public class LogEvent
{
    public const int GenerateItems      = 1000;
    public const int ListItems          = 1001;
    public const int GetItem            = 1002;
    public const int InsertItem         = 1003;
    public const int UpdateItem         = 1004;
    public const int DeleteItem         = 1005;

    public const int TestItem           = 3000;

    public const int GetItemNotFound    = 4000;
    public const int UpdateItemNotFound = 4001;
}
```

Used in Razor component code, where an `ILogger<T>` instance (`Logger`) is injected:

* The `LogEvent.GetItem` ID (`1002`) is used with the informational log message for retrieving an item by its identifier (`id`).
* The `LogEvent.GetItemNotFound` ID (`4000`) is used with the warning log message if the item isn't found.

```csharp
Logger.LogInformation(LogEvent.GetItem, "Getting item {Id}", id);

var todoItem = await TodoItemService.FindAsync(id);

if (todoItem == null)
{
    Logger.LogWarning(LogEvent.GetItemNotFound, "Get({Id}) NOT FOUND", id);

    return NotFound();
}
```

The logging provider may store the event ID in an ID (allows filtering on the ID), in the log message, or not at all. The [`Debug` provider](#debug) doesn't show event IDs. The console provider shows event IDs in brackets after the category:

```console
info: BlazorSample.Components.Pages.Items[1002]
      Getting item 1
warn: BlazorSample.Components.Pages.Items[4000]
      Get(1) NOT FOUND
```

## Log level

The following table describes the logging levels from lowest to highest severity, their corresponding `enum` values, and their convenience extension methods.

`LogLevel` | Value | Method | Description
--- | --- | --- | ---
<xref:Microsoft.Extensions.Logging.LogLevel.Trace> | 0 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace%2A> | Contain the most detailed messages. These messages may contain sensitive app data. These messages are disabled by default and should ***not*** be enabled in production.
<xref:Microsoft.Extensions.Logging.LogLevel.Debug> | 1 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug%2A> | For debugging and development. Use with caution in production due to the high volume of messages logged.
<xref:Microsoft.Extensions.Logging.LogLevel.Information> | 2 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A> | Tracks the general flow of the app.
<xref:Microsoft.Extensions.Logging.LogLevel.Warning> | 3 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> | For abnormal or unexpected events. Typically includes errors or conditions that don't cause the app to fail.
<xref:Microsoft.Extensions.Logging.LogLevel.Error> | 4 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A> | Typically used for unhandled errors and exceptions. These messages indicate a failure in the current operation or request, not an app-wide failure.
<xref:Microsoft.Extensions.Logging.LogLevel.Critical> | 5 | <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical%2A> | For failures that require immediate attention, such as data loss or out of disk space.
<xref:Microsoft.Extensions.Logging.LogLevel.None> | 6 | &mdash; | Specifies that a logging category shouldn't write messages.

The <xref:Microsoft.Extensions.Logging.LoggerExtensions.Log%2A> method's first parameter, <xref:Microsoft.Extensions.Logging.LogLevel>, indicates the severity of the log. Rather than calling `Log(LogLevel, ...)`, most developers call <xref:Microsoft.Extensions.Logging.LoggerExtensions> methods. For example, the following two logging calls are functionally equivalent and produce the same based on an injected `ILogger<T>` instance (`Logger`) in a Razor component:

```csharp
Logger.Log(LogLevel.Information, LogEvent.TestItem, routeInfo);

Logger.LogInformation(LogEvent.TestItem, routeInfo);
```

> [!NOTE]
> `LogEvent.TestItem` is a [log event ID](#log-event-id).

Log at an appropriate level to control how much log output is written to a particular storage medium:

* In production:
  * Logging at the <xref:Microsoft.Extensions.Logging.LogLevel.Trace>, <xref:Microsoft.Extensions.Logging.LogLevel.Debug>, or <xref:Microsoft.Extensions.Logging.LogLevel.Information> levels produces a high-volume of detailed log messages. To control costs and not exceed data storage limits, log at these levels to a high-volume, low-cost data store. Consider limiting these levels to specific categories.
  * Logging at <xref:Microsoft.Extensions.Logging.LogLevel.Warning> through <xref:Microsoft.Extensions.Logging.LogLevel.Critical> levels usually produces few log messages.
    * Costs and storage limits usually aren't a concern.
    * Few logs allow more flexibility in data store choices.
* In development:
  * We recommend the <xref:Microsoft.Extensions.Logging.LogLevel.Information> level (`"Default": "Information"`) for default logging and the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level for Microsoft ASP.NET Core assemblies (`"Microsoft.AspNetCore": "Warning"`).
  * Add <xref:Microsoft.Extensions.Logging.LogLevel.Trace> and <xref:Microsoft.Extensions.Logging.LogLevel.Debug>, or <xref:Microsoft.Extensions.Logging.LogLevel.Information> messages when troubleshooting. To limit output, only set these logging levels for the categories under investigation.

## Change log levels in a running app

The Logging API doesn't include support for changing log levels while an app is running. However, some configuration providers are capable of reloading configuration, which takes immediate effect on logging configuration. For example, the [File Configuration Provider](xref:fundamentals/configuration/index#file-configuration-provider), reloads logging configuration by default. If configuration is changed in code while an app is running, the app can call <xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Reload%2A?displayProperty=nameWithType> to update the app's logging configuration.

## How filtering rules are applied

When an <xref:Microsoft.Extensions.Logging.ILogger%601> object is created, the <xref:Microsoft.Extensions.Logging.ILoggerFactory> object selects a single rule per provider to apply to that logger. All messages written by an <xref:Microsoft.Extensions.Logging.ILogger> instance are filtered based on the selected rules. The most specific rule for each provider and category pair is selected from the available rules.

The following algorithm is used for each provider when an <xref:Microsoft.Extensions.Logging.ILogger> is created for a given category:

* Select all rules that match the provider or its alias. If no match is found, select all rules with an empty provider.
* From the result of the preceding step, select rules with longest matching category prefix. If no match is found, select all rules that don't specify a category.
* If multiple rules are selected, take the *last* one.
* If no rules are selected, use `MinimumLevel`.

## `ILogger` and `ILoggerFactory`

The <xref:Microsoft.Extensions.Logging.ILogger%601> and <xref:Microsoft.Extensions.Logging.ILoggerFactory> interfaces and implementations are included in the .NET SDK. They are also available in the following NuGet packages:  

* The interfaces are in the [`Microsoft.Extensions.Logging.Abstractions` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions).
* The default implementations are in the [`Microsoft.Extensions.Logging` NuGet package](https://www.nuget.org/packages/microsoft.extensions.logging).

## Log exceptions

The logger methods have overloads that take an exception parameter:

```csharp
try
{
   ...

   throw new Exception("Test exception");
}
catch (Exception ex)
{
    Logger.LogWarning(LogEvent.GetItemNotFound, ex, "Test exception at {DT}", 
        DateTime.UtcNow);
}
```

<!-- Dan, I'm not sure what this next remark means, 
     and I'm inclined to delete it. Do you want to 
     flesh it out if you know what it's trying to
     say, or should it get the AXE? -->

Exception logging is provider-specific.

### Default log level

If the default log level isn't explicitly set, the default log level is <xref:Microsoft.Extensions.Logging.LogLevel.Information>.

If the default log level isn't set in configuration, it can be set with <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType>. The following example sets the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level as the default logging level:

```csharp
var builder = WebApplication.CreateBuilder();

builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

We recommend setting the minimum default log level in configuration, not in C# code.

### Filter function

A filter function is invoked for all providers and categories that don't have rules assigned to them by configuration or code. The following example displays console logs when the category contains `Page` or `Microsoft` and the log level is <xref:Microsoft.Extensions.Logging.LogLevel.Information> or higher:

```csharp
var builder = WebApplication.CreateBuilder();

builder.Logging.AddFilter((provider, category, logLevel) =>
{
    if (provider is not null && category is not null)
    {
        return provider.Contains("ConsoleLoggerProvider")
            && (category.Contains("Page") || category.Contains("Microsoft"))
            && logLevel >= LogLevel.Information;
    }

    return false;
});
```

<!-- Dan, would insisting that the 'provider' and 'category' be non-null
     with the null-forgiving operator be safe for the preceding 
     example? It's cleaner not having to check, but I have a healthy
     fear of taking this approach generally ........
     
```csharp
var builder = WebApplication.CreateBuilder();

builder.Logging.AddFilter((provider, category, logLevel) =>
{
    return provider!.Contains("ConsoleLoggerProvider")
        && (category!.Contains("Page") || category!.Contains("Microsoft"))
        && logLevel >= LogLevel.Information;
});
```
     
-->

We recommend specifying log levels in configuration and not in code with filter functions.

## ASP.NET Core categories

The following table contains some of the logging categories used by ASP.NET Core.

| Category                              | Notes |
| ------------------------------------- | ----- |
| `Microsoft.AspNetCore`                | General ASP.NET Core diagnostics. |
| `Microsoft.AspNetCore.DataProtection` | Which data protection keys were considered, found, and used. |
| `Microsoft.AspNetCore.HostFiltering`  | Hosts allowed. |
| `Microsoft.AspNetCore.Hosting`        | How long HTTP requests took to complete and what time they started. Which hosting startup assemblies were loaded. |
| `Microsoft.AspNetCore.Mvc`            | MVC and Razor diagnostics. Model binding, filter execution, view compilation, and action selection. |
| `Microsoft.AspNetCore.Routing`        | Route matching information. |
| `Microsoft.AspNetCore.Server`         | Connection start, stop, and keep alive responses. HTTPS certificate information. |
| `Microsoft.AspNetCore.StaticFiles`    | Files served. |

To study more categories using the [`Console`](#console) logger, set `appsettings.Development.json` in a test app:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Trace",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```

> [!WARNING]
> Reset the logging configuration back to its prior levels in `appsettings.Development.json` after studying the [`Console`](#console) logger output.

For a list of Entity Framework categories, see [Simple Logging: Message categories (EF Core documentation)](/ef/core/logging-events-diagnostics/simple-logging#message-categories).

## Log scopes

A *scope* can group a set of logical operations. This grouping can be used to attach the same data to each log that's created as part of a set. For example, every log created as part of processing a transaction can include the transaction ID.

A scope:

* Is an <xref:System.IDisposable> type that's returned by the <xref:Microsoft.Extensions.Logging.ILogger.BeginScope%2A> method.
* Lasts until it's disposed.

The following providers support scopes:

* [`Console`](#console)
* [`AzureAppServicesFile` and `AzureAppServicesBlob`](xref:Microsoft.Extensions.Logging.AzureAppServices.BatchingLoggerOptions.IncludeScopes)

Use a scope by wrapping logger calls in a `using` block:

```csharp
public async Task<TodoItem> GetTodoItem(long id)
{
    TodoItem todoItem;
    var transactionId = Guid.NewGuid().ToString();

    using (Logger.BeginScope(new List<KeyValuePair<string, object>>
    {
        new KeyValuePair<string, object>("TransactionId", transactionId),
    }))
    {
        Logger.LogInformation(LogEvent.GetItem, "Getting item {Id}", id);

        todoItem = await TodoItemsService.FindAsync(id);

        if (todoItem == null)
        {
            Logger.LogWarning(LogEvent.GetItemNotFound, "Get({Id}) NOT FOUND", id);

            return NotFound();
        }
    }

    return todoItem;
}
```

## Built-in logging providers

ASP.NET Core includes the following logging providers:

* [`Console`](#console)
* [`Debug`](#debug)
* [`EventSource`](#eventsource)
* [Windows `EventLog`](#windows-eventlog)

The following logging providers are provided by Microsoft, but not as part of the .NET shared framework. They must be installed as an additional NuGet package added to the app.

* [`AzureAppServicesFile` and `AzureAppServicesBlob`](#azure-app-service)
* [`ApplicationInsights`](#azure-application-insights)

ASP.NET Core doesn't include a logging provider for writing logs to files. To write logs to files from an ASP.NET Core app, consider using a [third-party logging provider](#third-party-logging-providers).

For information on `stdout` and debug logging with the ASP.NET Core Module, see <xref:test/troubleshoot-azure-iis> and <xref:host-and-deploy/aspnet-core-module#log-creation-and-redirection>.

### `Console`

The `Console` provider logs output to the console. For more information on viewing `Console` logs in development, see the [Logging output](#logging-output) section.

### `Debug`

The `Debug` provider writes log output by using the <xref:System.Diagnostics.Debug?displayProperty=fullName> class. Calls to `System.Diagnostics.Debug.WriteLine` write to the `Debug` provider.

On Linux, the `Debug` provider log location is distribution-dependent and may be one of the following:

* `/var/log/message`
* `/var/log/syslog`

### `EventSource`

The `EventSource` provider writes to a cross-platform event source with the name `Microsoft-Extensions-Logging`. On Windows, the provider uses [ETW](/windows/win32/etw/event-tracing-portal).

#### `dotnet-trace` tooling

The [`dotnet-trace`](/dotnet/core/diagnostics/dotnet-trace) tool is a cross-platform CLI global tool that enables the collection of .NET traces of a running process. The tool collects <xref:Microsoft.Extensions.Logging.EventSource> provider data using a <xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource>.

For installation instructions, see [`dotnet-trace`](/dotnet/core/diagnostics/dotnet-trace).

Use the `dotnet-trace` tooling to collect a trace from an app:

1. Run the app with the `dotnet run` command.
1. Determine the process identifier (PID) of the .NET app:

    ```dotnetcli
    dotnet-trace ps
    ```

   Find the PID for the process that has the same name as the app's assembly.

1. Execute the `dotnet-trace` command.

   General command syntax:

   * `{PID}`: Process identifier
   * `{KEYWORD}`: Keyword
   * `{PROVIDER LEVEL}`: Provider level
   * `{LOGGER CATEGORY ...}`: Logger category
   * `{CATEGORY LEVEL ...}`: Category level

   ```dotnetcli
   dotnet-trace collect -p {PID} 
       --providers Microsoft-Extensions-Logging:{KEYWORD}:{PROVIDER LEVEL}
           :FilterSpecs=\"
               {LOGGER CATEGORY 1}:{CATEGORY LEVEL 1};
               {LOGGER CATEGORY 2}:{CATEGORY LEVEL 2};
               ...
               {LOGGER CATEGORY N}:{CATEGORY LEVEL N}\"
   ```

   When using a PowerShell command shell, enclose the `--providers` value in single quotes (`'`):

   ```powershell
   dotnet-trace collect -p {PID} 
       --providers 'Microsoft-Extensions-Logging:{KEYWORD}:{PROVIDER LEVEL}
           :FilterSpecs=\"
               {LOGGER CATEGORY 1}:{CATEGORY LEVEL 1};
               {LOGGER CATEGORY 2}:{CATEGORY LEVEL 2};
               ...
               {LOGGER CATEGORY N}:{CATEGORY LEVEL N}\"'
   ```

   On non-Windows platforms, add the `-f speedscope` option to change the format of the output trace file to `speedscope`.

   The following table defines the keyword (`{KEYWORD}` placeholder).

   | Keyword | Description |
   | :-----: | ----------- |
   | 1       | Log meta events about the `LoggingEventSource`. Doesn't log events from <xref:Microsoft.Extensions.Logging.ILogger>. |
   | 2       | Turns on the `Message` event when `ILogger.Log()` is called. Provides information in a programmatic (not formatted) way. |
   | 4       | Turns on the `FormatMessage` event when `ILogger.Log()` is called. Provides the formatted string version of the information. |
   | 8       | Turns on the `MessageJson` event when `ILogger.Log()` is called. Provides a JSON representation of the arguments. |

   The following table defines the provider levels.

   | Provider Level | Description     |
   | :------------: | --------------- |
   | 0              | `LogAlways`     |
   | 1              | `Critical`      |
   | 2              | `Error`         |
   | 3              | `Warning`       |
   | 4              | `Informational` |
   | 5              | `Verbose`       |

   The parsing for a category level can be either a string or a number, as indicated in the following table.

   | Category named value | Numeric value |
   | -------------------- | :-----------: |
   | `Trace`              | 0 |
   | `Debug`              | 1 |
   | `Information`        | 2 |
   | `Warning`            | 3 |
   | `Error`              | 4 |
   | `Critical`           | 5 |

   The provider level and category level:

   * Are in reverse order.
   * The string constants aren't all identical.

   If no `FilterSpecs` are specified, the `EventSourceLogger` implementation attempts to convert the provider level to a category level and applies it to all categories.

   | Provider Level     | Category Level   |
   | ------------------ | ---------------- |
   | `Verbose`(5)       | `Debug`(1)       |
   | `Informational`(4) | `Information`(2) |
   | `Warning`(3)       | `Warning`(3)     |
   | `Error`(2)         | `Error`(4)       |
   | `Critical`(1)      | `Critical`(5)    |

   If `FilterSpecs` are provided, any category that's included in the list uses the category level encoded there, all other categories are filtered out.

   The following examples assume:
   
   * An app is running and calling `Logger.LogDebug("12345")`.
   * The process ID (PID) is set via `set PID=12345`, where `12345` is the actual PID.
   
   Consider the following command:

   ```dotnetcli
   dotnet-trace collect -p %PID% --providers Microsoft-Extensions-Logging:4:5
   ```

   The preceding command:

   * Captures debug messages.
   * Doesn't apply a `FilterSpecs`.
   * Specifies level 5 which maps category <xref:Microsoft.Extensions.Logging.LogLevel.Debug>.

   Consider the following command:

   ```dotnetcli
   dotnet-trace collect -p %PID%  --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:5\"
   ```

   The preceding command:

   * Doesn't capture debug messages because the category level 5 is <xref:Microsoft.Extensions.Logging.LogLevel.Critical>.
   * Provides a `FilterSpecs`.

   The following command captures debug messages because category level 1 specifies <xref:Microsoft.Extensions.Logging.LogLevel.Debug>:

   ```dotnetcli
   dotnet-trace collect -p %PID%  --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:1\"
   ```

   The following command captures debug messages because category specifies <xref:Microsoft.Extensions.Logging.LogLevel.Debug>:

   ```dotnetcli
   dotnet-trace collect -p %PID%  --providers Microsoft-Extensions-Logging:4:5:\"FilterSpecs=*:Debug\"
   ```

   `FilterSpecs` entries for the logger category and category level represent additional log filtering conditions. Separate `FilterSpecs` entries with the `;` semicolon character.

   Example using a Windows command shell:

   ```dotnetcli
   dotnet-trace collect -p %PID% --providers Microsoft-Extensions-Logging:4:2:FilterSpecs=\"Microsoft.AspNetCore.Hosting*:4\"
   ```

   The preceding command activates:

   * The [`EventSource` provider](#eventsource) to produce formatted strings (`4`) for errors (`2`).
   * `Microsoft.AspNetCore.Hosting` logging at the <xref:Microsoft.Extensions.Logging.LogLevel.Information> logging level (`4`).

1. Stop the `dotnet-trace` tooling by pressing the <kbd>Enter</kbd> key or <kbd>Ctrl</kbd>+<kbd>C</kbd>.

   The trace is saved with the name `trace.nettrace` in the folder where the `dotnet-trace` command is executed.

1. Open the trace with [Perfview](#perfview). Open the `trace.nettrace` file and explore the trace events.

If the app doesn't build the host with <xref:Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder%2A?displayProperty=nameWithType>, add the [`EventSource` provider](#eventsource) to the app's logging configuration.

For more information, see:

* [Trace for performance analysis utility (`dotnet-trace`)](/dotnet/core/diagnostics/dotnet-trace) (.NET documentation)
* [Trace for performance analysis utility (`dotnet-trace`)](https://github.com/dotnet/diagnostics/blob/main/documentation/dotnet-trace-instructions.md) (`dotnet/diagnostics` GitHub repository documentation)
* <xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource>
* <xref:System.Diagnostics.Tracing.EventLevel>
* [Perfview](#perfview) for viewing `EventSource` traces

#### Perfview

Use the [PerfView utility](https://github.com/Microsoft/perfview) to collect and view logs. There are other tools for viewing ETW logs, but PerfView provides the best experience for working with the ETW events emitted by ASP.NET Core.

To configure PerfView for collecting events logged by this provider, add the string `*Microsoft-Extensions-Logging` to the **Additional Providers** list. Don't miss the `*` at the start of the string.

### Windows EventLog

The Windows `EventLog` provider sends log output to the Windows Event Log. Unlike the other providers, the `EventLog` provider doesn't inherit the default non-provider settings. If `EventLog` log settings aren't specified, they default to <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>.

To log events lower than <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>, explicitly set the log level. The following example sets the Event Log default log level to <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType>:

```json
"Logging": {
  "EventLog": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

<xref:Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog%2A> overloads can pass in <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings>. If `null` or not specified, the following default settings are used:

* `LogName`: "`Application`"
* `SourceName`: "`.NET Runtime`"
* `MachineName`: The local machine name is used.

The following code changes the `SourceName` from the default value of `".NET Runtime"` to "`CustomLogs`":

```csharp
var builder = WebApplication.CreateBuilder();

builder.Logging.AddEventLog(eventLogSettings =>
{
    eventLogSettings.SourceName = "CustomLogs";
});
```

When the app calls the <xref:Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog%2A> overload with <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings>, a new instance of <xref:Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider> is created with the provided settings. If there's already an <xref:Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider> instance registered, which is the case if the app doesn't call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> to remove all the <xref:Microsoft.Extensions.Logging.ILoggerProvider> instances, the new settings don't replace the existing ones. If you want to ensure that the <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings> are used, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> before calling <xref:Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog%2A>.

#### Azure App Service

The [`Microsoft.Extensions.Logging.AzureAppServices` provider NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices) writes logs to text files in an Azure App Service app's file system and to [blob storage](/azure/storage/blobs/storage-quickstart-blobs-dotnet#what-is-blob-storage) in an Azure Storage account. The provider only logs when the project runs in the Azure environment.

The provider package isn't included in the shared framework. To use the provider, add the provider package to the project.

To configure provider settings, use <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureFileLoggerOptions> and <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureBlobLoggerOptions>, as shown in the following example:

:::moniker range=">= aspnetcore-6.0"

```csharp
using Microsoft.Extensions.Logging.AzureAppServices;

var builder = WebApplication.CreateBuilder();

builder.Logging.AddAzureWebAppDiagnostics();

builder.Services.Configure<AzureFileLoggerOptions>(options =>
{
    options.FileName = "azure-diagnostics-";
    options.FileSizeLimit = 50 * 1024;
    options.RetainedFileCountLimit = 5;
});

builder.Services.Configure<AzureBlobLoggerOptions>(options =>
{
    options.BlobName = "log.txt";
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
public class Scopes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging => logging.AddAzureWebAppDiagnostics())
                .ConfigureServices(serviceCollection => serviceCollection
                    .Configure<AzureFileLoggerOptions>(options =>
                    {
                        options.FileName = "azure-diagnostics-";
                        options.FileSizeLimit = 50 * 1024;
                        options.RetainedFileCountLimit = 5;
                    })
                    .Configure<AzureBlobLoggerOptions>(options =>
                    {
                        options.BlobName = "log.txt";
                    }))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
```

:::moniker-end

When deployed to Azure App Service, the app uses the settings in the [App Service logs](/azure/app-service/troubleshoot-diagnostic-logs) section of the **App Service** page of the Azure portal. When the following settings are updated, the changes take effect immediately without requiring a restart or redeployment of the app.

* **Application Logging (Filesystem)**
* **Application Logging (Blob)**

The default location for log files is `D:\home\LogFiles\Application`. The default file size limit is 10 MB, and the default maximum number of files retained is two files.

#### Azure log streaming

Azure log streaming supports viewing log activity in real time from:

* The app server
* The web server
* Failed request tracing

To configure Azure log streaming:

* Navigate to the **App Service logs** page from the app's portal page.
* Set **Application Logging (Filesystem)** to **On**.
* Choose the log **Level**. This setting only applies to Azure log streaming.

Navigate to the **Log Stream** page to view logs. The logged messages are logged with the <xref:Microsoft.Extensions.Logging.ILogger> interface.

### Azure Application Insights

Application Insights is a service that monitors a web app and provides tools for querying and analyzing the telemetry data. If you use this provider, you can query and analyze your logs by using the Application Insights tools.

The [`Microsoft.Extensions.Logging.ApplicationInsights` provider NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Logging.ApplicationInsights) writes logs to [Azure Application Insights](/azure/azure-monitor/app/cloudservices). The logging provider is included as a dependency of the [`Microsoft.ApplicationInsights.AspNetCore` NuGet package](https://www.nuget.org/packages/Microsoft.ApplicationInsights.AspNetCore), which is the package that provides all available telemetry for ASP.NET Core. If you use the `Microsoft.ApplicationInsights.AspNetCore` NuGet package, you aren't required to install the `Microsoft.Extensions.Logging.ApplicationInsights` provider package.

> [!NOTE]
> The [`Microsoft.ApplicationInsights.Web` NuGet package](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Web) is for ASP.NET 4.x, not ASP.NET Core, and shouldn't be used in an ASP.NET Core app.

For more information, see the following resources:

* [Application Insights overview](/azure/application-insights/app-insights-overview)
* [Application Insights for ASP.NET Core applications](/azure/azure-monitor/app/asp-net-core): Start here if you want to implement the full range of Application Insights telemetry along with logging.
* [ApplicationInsightsLoggerProvider for .NET ILogger logs](/azure/azure-monitor/app/ilogger): Start here if you want to implement the logging provider without the rest of Application Insights telemetry.
* [Application Insights logging adapters](/azure/azure-monitor/app/asp-net-trace-logs)
* [Install, configure, and initialize the Application Insights SDK](/training/modules/instrument-web-app-code-with-application-insights) interactive tutorial.

## Third-party logging providers

Third-party logging frameworks that work with ASP.NET Core:

* [elmah.io](https://elmah.io/) ([GitHub repository](https://github.com/elmahio/Elmah.Io.Extensions.Logging))
* [Gelf](https://go2docs.graylog.org/5-0/getting_in_log_data/gelf.html) ([GitHub repository](https://github.com/mattwcole/gelf-extensions-logging))
* [JSNLog](https://jsnlog.com/) ([GitHub repository](https://github.com/mperdeck/jsnlog))
* [KissLog.net](https://kisslog.net/) ([GitHub repository](https://github.com/catalingavan/KissLog-net))
* [Log4Net](https://logging.apache.org/log4net/) ([GitHub repository](https://github.com/huorswords/Microsoft.Extensions.Logging.Log4Net.AspNetCore))
* [NLog](https://nlog-project.org/) ([GitHub repository](https://github.com/NLog/NLog.Extensions.Logging))
* [PLogger](https://www.nuget.org/packages/InvertedSoftware.PLogger.Core/) ([GitHub repository](https://github.com/invertedsoftware/InvertedSoftware.PLogger.Core))
* [Sentry](https://sentry.io/welcome/) ([GitHub repository](https://github.com/getsentry/sentry-dotnet))
* [Serilog](https://serilog.net/) ([GitHub repository](https://github.com/serilog/serilog-aspnetcore))
* [Stackdriver](https://cloud.google.com/dotnet/docs/stackdriver#logging) ([GitHub repository](https://github.com/googleapis/google-cloud-dotnet))

Some third-party frameworks can perform [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

Using a third-party framework is similar to using one of the built-in providers:

1. Add the provider's NuGet package to the project.
1. Call an <xref:Microsoft.Extensions.Logging.ILoggerFactory> extension method provided by the logging framework.

For more information, see the provider's documentation. Third-party logging providers aren't owned, maintained, or supported by Microsoft.

## Non-host console app logging

For logging in a console app without the Generic Host, see [Logging in C# and .NET](/dotnet/core/extensions/logging). For an additional example, see the [Background Tasks sample app](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/hosted-services/samples), which is covered by <xref:fundamentals/host/hosted-services>.

## No asynchronous logger methods

Logging should be so fast that it isn't worth the performance cost of asynchronous code. If a logging data store is slow, don't write to it directly. Consider writing the log messages to a fast store initially, then move the logs to the slower data store later. For example, don't write log messages directly to a SQL Server data store in a `Log` method because `Log` methods are synchronous. Instead, synchronously add log messages to an in-memory queue and have a background worker pull the messages out of the queue to push the data to SQL Server asynchronously. For more information, see [Guidance on how to log to a message queue for slow data stores (dotnet/AspNetCore.Docs #11801)](https://github.com/dotnet/AspNetCore.Docs/issues/11801).

## Apply log filter rules in code

The preferred approach for setting log filter rules is by [app configuration](xref:fundamentals/configuration/index).

The following example shows how to register filter rules in code by calling <xref:Microsoft.Extensions.Logging.FilterLoggingBuilderExtensions.AddFilter%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Logging%2A?displayProperty=nameWithType>:

```csharp
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

var builder = WebApplication.CreateBuilder();

builder.Logging.AddFilter("System", LogLevel.Debug);
builder.Logging.AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Information);
builder.Logging.AddFilter<ConsoleLoggerProvider>("Microsoft", LogLevel.Trace);
```

In the preceding example:

* The first filter specifies:
  * Log filtering rules for all providers because a specific provider isn't configured.
  * All categories starting with "`System`".
  * Log level <xref:Microsoft.Extensions.Logging.LogLevel.Debug> and higher. 

* The [`Debug` provider](#debug) (<xref:Microsoft.Extensions.Logging.Debug.DebugLoggerProvider>) specifies:
  * All categories starting with "`Microsoft`".
  * Log level <xref:Microsoft.Extensions.Logging.LogLevel.Information> and higher.

* The [`Console` provider](#console) (<xref:Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider>) specifies:
  * All categories starting with "`Microsoft`".
  * Log level <xref:Microsoft.Extensions.Logging.LogLevel.Trace> and higher.

:::moniker range=">= aspnetcore-5.0"

## Specify the trace context for logging scopes

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

The logging libraries implicitly create a scope object with <xref:Microsoft.Extensions.Logging.LoggerFactoryOptions.ActivityTrackingOptions>. The following fields indicate the options (<xref:Microsoft.Extensions.Logging.ActivityTrackingOptions>):

* `SpanId`
* `TraceId`
* `ParentId`
* `Baggage`
* `Tags`

`SpanId`, `TraceId`, `ParentId` are enabled by default.

In the following example, only the `SpanId` and `TraceId` are specified:

```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
});

builder.Logging.Configure(options =>
{
    options.ActivityTrackingOptions = 
        ActivityTrackingOptions.SpanId | ActivityTrackingOptions.TraceId;
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Automatically log scope with `SpanId`, `TraceId`, and `ParentId`

The logging libraries implicitly create a scope object with `SpanId`, `TraceId`, and `ParentId`. This behavior is configured via <xref:Microsoft.Extensions.Logging.LoggerFactoryOptions.ActivityTrackingOptions>.


The logging libraries implicitly create a scope object with <xref:Microsoft.Extensions.Logging.LoggerFactoryOptions.ActivityTrackingOptions>. The following fields indicate the options (<xref:Microsoft.Extensions.Logging.ActivityTrackingOptions>):

* `SpanId`
* `TraceId`
* `ParentId`

`SpanId`, `TraceId`, `ParentId` are enabled by default.

In the following example, only the `SpanId` and `TraceId` are specified:

```csharp
var loggerFactory = LoggerFactory.Create(logging =>
{
    logging.Configure(options =>
    {
        options.ActivityTrackingOptions = 
            ActivityTrackingOptions.SpanId | ActivityTrackingOptions.TraceId;
    }).AddSimpleConsole(options =>
    {
        options.IncludeScopes = true;
    });
});
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

If the [W3C Trace Context specification](https://www.w3.org/TR/trace-context/) `traceparent` http request header is set:

* The [`ParentId`](xref:Microsoft.Extensions.Logging.ActivityTrackingOptions) in the log scope shows the `parent-id` from in-bound `traceparent` header.
* The [`SpanId`](xref:Microsoft.Extensions.Logging.ActivityTrackingOptions) in the log scope shows the updated `parent-id` for the next out-bound step/span.

For more information, see [Mutating the traceparent Field](https://www.w3.org/TR/trace-context/#mutating-the-traceparent-field).

:::moniker-end

## Create a custom logger

To create a custom logger, see [Implement a custom logging provider in .NET](/dotnet/core/extensions/custom-logging-provider).

:::moniker range="< aspnetcore-6.0"

## Log during host construction

Logging during host construction isn't directly supported. However, a separate logger can be used. In the following example, a [Serilog](https://serilog.net/) logger is used to log in <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateHostBuilder%2A>. `AddSerilog` uses the static configuration specified in `Log.Logger`, which is provided by the [Serilog NuGet package](https://www.nuget.org/packages/serilog).

In the <xref:Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory%601.CreateHostBuilder%2A> method of the app's `Program` file:

```csharp
var builtConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args)
    .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(builtConfig["Logging:FilePath"])
    .CreateLogger();

try
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddRazorPages();
        })
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config.AddConfiguration(builtConfig);
        })
        .ConfigureLogging(logging =>
        {   
            logging.AddSerilog();
        })
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host builder error");

    throw;
}
finally
{
    Log.CloseAndFlush();
}
```

## Configure a service that depends on `ILogger`

Constructor injection of a logger into `Startup` works in earlier versions of ASP.NET Core because a separate DI container is created for the [Web Host](xref:fundamentals/host/web-host). For information about why only one container is created for the [Generic Host](xref:fundamentals/host/generic-host), see the [breaking change announcement](https://github.com/aspnet/Announcements/issues/353).

To configure a service that depends on <xref:Microsoft.Extensions.Logging.ILogger>, use constructor injection or provide a factory method. The factory method approach is recommended only if there's no other option. For example, consider a service that requires a logger instance provided by dependency injection (DI):

```csharp
services.AddSingleton<ILoggingService>((container) =>
{
    var logger = container.GetRequiredService<ILogger<LoggingService>>();
    return new LoggingService() { Logger = logger };
});
```

The preceding code is a <xref:System.Func%602> that runs the first time the DI container constructs an instance of `LoggerService`. Access any registered service using this pattern.

:::moniker-end

## Logging bug reports

File a logging bug report in the [`dotnet/runtime` GitHub repository issues](https://github.com/dotnet/runtime/issues).

## Common log categories

<!-- Dan, I merely tossed this in from Rick's issue with minor editing ...

     https://github.com/dotnet/AspNetCore.Docs/issues/33187
     
     I didn't want to spend time on it until I heard back from you 
     if we're going to place this section at all or have feedback 
     from you on how you want it covered if you'd prefer an 
     alternative format and/or the entries Rick drafted. -->

This section describes common log categories seen in ASP.NET Core app logs. The following isn't a comprehensive list.

`Microsoft.AspNetCore`: Logs from the ASP.NET Core framework components, such as hosting, routing, and middleware.

Authentication

* `Microsoft.AspNetCore.Authentication`: Logs from the authentication middleware and services, including authentication scheme handling.
* `Microsoft.AspNetCore.Authentication.Cookies`: Logs specific to cookie-based authentication.
* `Microsoft.AspNetCore.Authentication.JwtBearer`: Logs related to JWT Bearer token authentication.
* `Microsoft.AspNetCore.Authentication.OpenIdConnect`: Logs concerning OpenID Connect authentication processes.
* `Microsoft.AspNetCore.Authentication.OAuth`: Logs related to OAuth authentication and authorization flows.

Authorization

* `Microsoft.AspNetCore.Authorization`: Logs related to authorization operations, including policy evaluation and decision making.
* `Microsoft.AspNetCore.Authorization.DefaultAuthorizationService`: Logs about the default.

Configuration

* `Microsoft.Extensions.Configuration.Json`: Logs from classes that obtain configuration data from JSON files.
* `Microsoft.Extensions.Configuration.UserSecrets`: Logs related to loading user secrets configuration data.

CORS

* `Microsoft.AspNetCore.Cors`: Logs related to Cross-Origin Resource Sharing (CORS) middleware and policy evaluation.
* `Microsoft.AspNetCore.Cors.Infrastructure`: Logs concerning CORS policy configuration and enforcement.

Data Protection:

* `Microsoft.AspNetCore.DataProtection`: Logs from the data protection system, including key management, encryption operations, and which keys were considered, found, and used.
* `Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager`: Logs specific to the XML key manager, including key storage and retrieval.

Diagnostics

* `Microsoft.AspNetCore.Diagnostics`: Logs about diagnostics and error handling middleware, including exception handling and status code pages.
* `Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware`: Logs specific to developer exception page middleware processing.
* `Microsoft.AspNetCore.Diagnostics.ExceptionHandlerMiddleware`: Logs related to exception handling and error response generation.
* `Microsoft.AspNetCore.Diagnostics.StatusCodePageMiddleware`: Logs related to status code page middleware and response handling.

Host Filtering

* `Microsoft.AspNetCore.HostFiltering`: Hosts allowed and denied by the host filtering middleware.
* `Microsoft.AspNetCore.HostFiltering.HostFilteringMiddleware`: Logs related to the host filtering middleware, including allowed and denied hosts.
* `Microsoft.AspNetCore.HostFiltering.HostFilteringOptions`: Logs concerning options for the HostFiltering middleware.

Hosting

* `Microsoft.AspNetCore.Hosting.Lifetime`: Logs related to the lifecycle of the web host, including starting and stopping events.
* `Microsoft.AspNetCore.Hosting.Diagnostics`: Logs diagnostics information, such as application startup and shutdown.
* `Microsoft.AspNetCore.Hosting.RequestDelegate`: Logs related to the handling of HTTP requests by the application pipeline.
* `Microsoft.AspNetCore.Hosting.Internal.WebHost`: Internal logs from the web host, useful for debugging host-related issues.
* `Microsoft.AspNetCore.Hosting.Internal.HostedServiceExecutor`: Logs concerning the execution of hosted services by the web host.

HTTP

* `Microsoft.AspNetCore.Http.ConnectionLogging`: Related to HTTP connections, including connection establishment and termination.
* `Microsoft.AspNetCore.Http.DefaultHttpContext`: Logs related to the creation and usage of HttpContext instances.
* `Microsoft.AspNetCore.Http.Endpoints.EndpointMiddleware`: Logs about endpoint routing and middleware execution.
* `Microsoft.AspNetCore.Http.Response`: Logs related to HTTP response processing.

HTTPS

* `Microsoft.AspNetCore.HttpsPolicy`: Logs from HTTPS redirection middleware, policy enforcement and and HTTP Strict-Transport-Security (HSTS).
* `Microsoft.AspNetCore.HttpsPolicy.HstsMiddleware`: Logs specific to HTTP Strict-Transport-Security (HSTS) middleware processing.
* `Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware`: Logs related to HTTPS redirection middleware execution.
* `Microsoft.AspNetCore.HttpsPolicy.HstsOptions`: Logs concerning HSTS policy configuration and enforcement.

Identity

* `Microsoft.AspNetCore.Identity`: Logs from the ASP.NET Core Identity framework, including user management and identity operations.
* `Microsoft.AspNetCore.Identity.RoleManager`: Logs related to role management operations.
* `Microsoft.AspNetCore.Identity.UserManager`: Logs concerning user management activities and lifecycle events.

Kestrel

* `Microsoft.AspNetCore.Server.Kestrel`: Logs from the Kestrel web server, covering connection handling and request processing.
* `Microsoft.AspNetCore.Server.Kestrel.Core`: Logs related to core Kestrel operations, such as configuration and resource management.
* `Microsoft.AspNetCore.Server.Kestrel.Transport`: Logs specific to network transport layers used by Kestrel.

Logging

* `Microsoft.Extensions.Logging`: Logs from the logging extensions API.
* `Microsoft.Extensions.Logging.Console`: Logs specific to the Console logger.

MVC

* `Microsoft.AspNetCore.Mvc`: General logs from MVC framework components, including controller and action execution.
* `Microsoft.AspNetCore.Mvc.Infrastructure`: Logs related to the infrastructure and support services for MVC, such as model binding and action filters.
* `Microsoft.AspNetCore.Mvc.ModelBinding`: Logs concerning model binding operations and data validation.
* `Microsoft.AspNetCore.Mvc.Filters`: Logs about the execution of action filters and filter pipelines.
* `Microsoft.AspNetCore.Mvc.Razor`: Logs specific to Razor view rendering and compilation.
* `Microsoft.AspNetCore.Mvc.ViewFeatures`: Logs concerning view rendering and related features like view components and tag helpers.

Routing

* `Microsoft.AspNetCore.Routing.EndpointMiddleware`: Logs related to the routing of HTTP requests to endpoints.
* `Microsoft.AspNetCore.Routing.EndpointRoutingMiddleware`: Logs about the endpoint routing middleware handling requests.
* `Microsoft.AspNetCore.Routing.Matching.DataSourceDependentMatcher`: Logs concerning route matching and selection of endpoints.
* `Microsoft.AspNetCore.Routing.Matching.DfaMatcher`: Logs specific to the DFA (Deterministic Finite Automaton) routing matcher.

SignalR

* `Microsoft.AspNetCore.SignalR`: Logs from the SignalR framework, including hub connections and message handling.
* `Microsoft.AspNetCore.SignalR.Hub`: Logs specific to hub invocation and message dispatching.
* `Microsoft.AspNetCore.SignalR.Transports`: Logs related to transport mechanisms used by SignalR.

Static files

* `Microsoft.AspNetCore.StaticFiles`: Logs from the static files middleware, including file serving and cache operations.
* `Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware`: Logs related to static file middleware execution and file response handling.

## Additional resources

* <xref:blazor/fundamentals/logging>
* [Improving logging performance with source generators](https://andrewlock.net/exploring-dotnet-6-part-8-improving-logging-performance-with-source-generators/)
* [Behind `[LogProperties]` and the new telemetry logging source generator](https://andrewlock.net/behind-logproperties-and-the-new-telemetry-logging-source-generator/)
* [`Microsoft.Extensions.Logging` reference source (`dotnet/runtime`) GitHub repository](https://github.com/dotnet/runtime/tree/main/src/libraries/Microsoft.Extensions.Logging)
* [High performance logging](/dotnet/core/extensions/high-performance-logging)
* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/logging) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
