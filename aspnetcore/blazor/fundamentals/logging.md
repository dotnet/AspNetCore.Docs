---
title: ASP.NET Core Blazor logging
author: guardrex
description: Learn about logging in Blazor apps, including configuration and how to write log messages from Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/22/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/logging
---
# ASP.NET Core Blazor logging

This article explains logging in Blazor apps, including configuration and how to write log messages from Razor components.

:::moniker range=">= aspnetcore-6.0"

## Configuration

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

At default log levels and without configuring additional logging providers:

* Blazor Server apps only log to the server-side .NET console in the `Development` environment at the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level or higher.
* Blazor WebAssembly apps only log to the client-side [browser developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console at the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level or higher.

When the app is configured in the project file to use implicit namespaces (`<ImplicitUsings>enable</ImplicitUsings>`), a `using` directive for <xref:Microsoft.Extensions.Logging> or any API in the <xref:Microsoft.Extensions.Logging.LoggerExtensions> class isn't required to support API [Visual Studio IntelliSense](/visualstudio/ide/using-intellisense) completions or building apps. If implicit namespaces aren't enabled, Razor components must explicitly define [`@using` directives](xref:mvc/views/razor#using) for logging namespaces that aren't imported via the `_Imports.razor` file.

## Log levels

Log levels in Blazor apps conform to ASP.NET Core app log levels, which are listed in the API documentation at <xref:Microsoft.Extensions.Logging.LogLevel>.

## Razor component logging

The following example:

* [Injects](xref:blazor/fundamentals/dependency-injection) an <xref:Microsoft.Extensions.Logging.ILogger> (`ILogger<Counter>`) object to create a logger. The log's *category* is the fully qualified name of the component's type, `Counter`.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Logging in Blazor WebAssembly apps

Not every feature of [ASP.NET Core logging](xref:fundamentals/logging/index) is supported in Blazor WebAssembly apps. For example, Blazor WebAssembly apps don't have access to the client's file system or network, so writing logs to the client's physical or network storage isn't possible. When using a third-party logging service designed to work with single-page apps (SPAs), follow the service's security guidance. Keep in mind that every piece of data, including keys or secrets stored in the Blazor WebAssembly app are ***insecure*** and can be easily discovered by malicious users.

Configure logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property. The <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging> property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so the extension methods of <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are supported.

To set the minimum logging level, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> on the host builder in `Program.cs` with the <xref:Microsoft.Extensions.Logging.LogLevel>. The following example sets the minimum log level to <xref:Microsoft.Extensions.Logging.LogLevel.Warning>:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

### Log category

[Log categories](xref:fundamentals/logging/index#log-category) are supported in Blazor WebAssembly apps.

The following example shows how to use log categories with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Pages/Counter.razor`) that injects an <xref:Microsoft.Extensions.Logging.ILoggerFactory> as `LoggerFactory`:

```csharp
var logger = LoggerFactory.CreateLogger("CustomCategory");
logger.LogWarning("Someone has clicked me!");
```

Developer tools console output:

> :::no-loc text="warn: CustomCategory[0]":::
> :::no-loc text="Someone has clicked me!":::

### Log event ID

[Log event ID](xref:fundamentals/logging/index#log-event-id) is supported in Blazor WebAssembly apps.

The following example shows how to use log event IDs with the `Counter` component of an app created from a Blazor project template.

`LogEvent.cs`:

```csharp
public class LogEvent
{
    public const int Event1 = 1000;
    public const int Event2 = 1001;
}
```

In the `IncrementCount` method of the app's `Counter` component (`Pages/Counter.razor`):

```csharp
logger.LogInformation(LogEvent.Event1, "Someone has clicked me!");
logger.LogWarning(LogEvent.Event2, "Someone has clicked me!");
```

Developer tools console output:

> :::no-loc text="info: BlazorSample.Pages.Counter[1000]":::
> :::no-loc text="Someone has clicked me!":::
>
> :::no-loc text="warn: BlazorSample.Pages.Counter[1001]":::
> :::no-loc text="Someone has clicked me!":::

### Log message template

[Log message templates](xref:fundamentals/logging/index#log-message-template) are supported in Blazor WebAssembly apps:

The following example shows how to use log message templates with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Pages/Counter.razor`):

```csharp
logger.LogInformation("Someone clicked me at {CurrentDT}!", DateTime.UtcNow);
```

Developer tools console output:

> :::no-loc text="info: BlazorSample.Pages.Counter[0]":::
> :::no-loc text="Someone clicked me at 04/21/2022 12:15:57!":::

### Log exception parameters

[Log exception parameters](xref:fundamentals/logging/index#log-exceptions) are supported in Blazor WebAssembly apps.

The following example shows how to use log exception parameters with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Pages/Counter.razor`):

```csharp
currentCount++;

try
{
    if (currentCount == 3)
    {
        currentCount = 4;
        throw new OperationCanceledException("Skip 3");
    }
}
catch (Exception ex)
{
    logger.LogWarning(ex, "Exception (currentCount: {Count})!", currentCount);
}
```

Developer tools console output:

> :::no-loc text="warn: BlazorSample.Pages.Counter[0]":::
> :::no-loc text="Exception (currentCount: 4)!":::
> :::no-loc text="System.OperationCanceledException: Skip 3":::
> :::no-loc text="at BlazorSample.Pages.Counter.IncrementCount() in C:\Users\Alaba\Desktop\BlazorSample\Pages\Counter.razor:line 28":::

### Filter function

[Filter functions](xref:fundamentals/logging/index#filter-function) are supported in Blazor WebAssembly apps.

The following example shows how to use a filter with the `Counter` component of an app created from a Blazor project template.

In `Program.cs`:

```csharp
builder.Logging.AddFilter((provider, category, logLevel) =>
    category.Equals("CustomCategory2") && logLevel == LogLevel.Information);
```

In the `IncrementCount` method of the app's `Counter` component (`Pages/Counter.razor`) that injects an <xref:Microsoft.Extensions.Logging.ILoggerFactory> as `LoggerFactory`:

```csharp
var logger1 = LoggerFactory.CreateLogger("CustomCategory1");
logger1.LogInformation("Someone has clicked me!");

var logger2 = LoggerFactory.CreateLogger("CustomCategory1");
logger2.LogWarning("Someone has clicked me!");

var logger3 = LoggerFactory.CreateLogger("CustomCategory2");
logger3.LogInformation("Someone has clicked me!");

var logger4 = LoggerFactory.CreateLogger("CustomCategory2");
logger4.LogWarning("Someone has clicked me!");
```

In the developer tools console output, the filter only permits logging for the `CustomCategory2` category and <xref:Microsoft.Extensions.Logging.LogLevel.Warning> log level message:

> :::no-loc text="info: CustomCategory2[0]":::
> :::no-loc text="Someone has clicked me!":::

The app can also configure log filtering for specific namespaces. For example, set the log level to <xref:Microsoft.Extensions.Logging.LogLevel.Trace> in `Program.cs`:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Trace);
```

Normally at the <xref:Microsoft.Extensions.Logging.LogLevel.Trace> log level, developer tools console output at the **Verbose** level includes <xref:Microsoft.AspNetCore.Components.RenderTree> logging messages, such as the following:

> :::no-loc text="dbug: Microsoft.AspNetCore.Components.RenderTree.Renderer[3]":::
> :::no-loc text="Rendering component 14 of type Microsoft.AspNetCore.Components.Web.HeadOutlet":::

In `Program.cs`, logging messages specific to <xref:Microsoft.AspNetCore.Components.RenderTree> can be disabled using ***either*** of the following approaches:

* ```csharp
  builder.Logging.AddFilter("Microsoft.AspNetCore.Components.RenderTree.*", LogLevel.None);
  ```

* ```csharp
  builder.Services.PostConfigure<LoggerFilterOptions>(options =>
      options.Rules.Add(
          new LoggerFilterRule(null, 
                               "Microsoft.AspNetCore.Components.RenderTree.*", 
                               LogLevel.None, 
                               null)
      ));
  ```

After ***either*** of the preceding filters is added to the app, the console output at the **Verbose** level doesn't show logging messages from the <xref:Microsoft.AspNetCore.Components.RenderTree> API.

### Custom logger provider

The example in this section demonstrates a custom logger provider for further customization.

Add a package reference to the app for the [`Microsoft.Extensions.Logging.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration) package.

[!INCLUDE[](~/includes/package-reference.md)]

Add the following custom logger configuration. The configuration establishes a `LogLevels` dictionary that sets a custom log format for three log levels: <xref:Microsoft.Extensions.Logging.LogLevel.Information>, <xref:Microsoft.Extensions.Logging.LogLevel.Warning>, and <xref:Microsoft.Extensions.Logging.LogLevel.Error>. A `LogFormat` [`enum`](/dotnet/csharp/language-reference/builtin-types/enum) is used to describe short (`LogFormat.Short`) and long (`LogFormat.Long`) formats.

`CustomLoggerConfiguration.cs`:

```csharp
using Microsoft.Extensions.Logging;

public class CustomLoggerConfiguration
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, LogFormat> LogLevels { get; set; } = 
        new()
        {
            [LogLevel.Information] = LogFormat.Short,
            [LogLevel.Warning] = LogFormat.Short,
            [LogLevel.Error] = LogFormat.Long
        };

    public enum LogFormat
    {
        Short,
        Long
    }
}
```

Add the following custom logger to the app. The `CustomLogger` outputs custom log formats based on the `logLevel` values defined in the preceding `CustomLoggerConfiguration` configuration.

```csharp
using Microsoft.Extensions.Logging;
using static CustomLoggerConfiguration;

public sealed class CustomLogger : ILogger
{
    private readonly string name;
    private readonly Func<CustomLoggerConfiguration> getCurrentConfig;

    public CustomLogger(
        string name,
        Func<CustomLoggerConfiguration> getCurrentConfig) =>
        (this.name, this.getCurrentConfig) = (name, getCurrentConfig);

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        getCurrentConfig().LogLevels.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        CustomLoggerConfiguration config = getCurrentConfig();

        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            switch (config.LogLevels[logLevel])
            {
                case LogFormat.Short:
                    Console.WriteLine($"{name}: {formatter(state, exception)}");
                    break;
                case LogFormat.Long:
                    Console.WriteLine($"[{eventId.Id, 2}: {logLevel, -12}] {name} - {formatter(state, exception)}");
                    break;
                default:
                    // No-op
                    break;
            }
        }
    }
}
```

Add the following custom logger provider to the app. `CustomLoggerProvider` adopts an [`Options`-based approach](xref:fundamentals/configuration/options) to configure the logger via built-in logging configuration features. For example, the app can set or change log formats via an `appsettings.json` file without requiring code changes to the custom logger, which is demonstrated at the end of this section.

`CustomLoggerProvider.cs`:

```csharp
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

[ProviderAlias("CustomLog")]
public sealed class CustomLoggerProvider : ILoggerProvider
{
    private readonly IDisposable onChangeToken;
    private CustomLoggerConfiguration config;
    private readonly ConcurrentDictionary<string, CustomLogger> loggers =
        new(StringComparer.OrdinalIgnoreCase);

    public CustomLoggerProvider(
        IOptionsMonitor<CustomLoggerConfiguration> config)
    {
        this.config = config.CurrentValue;
        onChangeToken = config.OnChange(updatedConfig => this.config = updatedConfig);
    }

    public ILogger CreateLogger(string categoryName) =>
        loggers.GetOrAdd(categoryName, name => new CustomLogger(name, GetCurrentConfig));

    private CustomLoggerConfiguration GetCurrentConfig() => config;

    public void Dispose()
    {
        loggers.Clear();
        onChangeToken.Dispose();
    }
}
```

Add the following custom logger extensions.

`CustomLoggerExtensions.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

public static class CustomLoggerExtensions
{
    public static ILoggingBuilder AddCustomLogger(
        this ILoggingBuilder builder)
    {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, CustomLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <CustomLoggerConfiguration, CustomLoggerProvider>(builder.Services);

        return builder;
    }
}
```

In `Program.cs` on the host builder, clear the existing provider by calling <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> and add the custom logging provider:

```csharp
builder.Logging.ClearProviders().AddCustomLogger();
```

In the following `Index` component:

* The debug message isn't logged.
* The information message is logged in the short format (`LogFormat.Short`).
* The warning message is logged in the short format (`LogFormat.Short`).
* The error message is logged in the long format  (`LogFormat.Long`).
* The trace message isn't logged.

`Pages/Index.razor`:

```razor
@page "/"
@using Microsoft.Extensions.Logging
@inject ILogger<Index> Logger

<p>
    <button @onclick="LogMessages">Log Messages</button>
</p>

@code{
    private void LogMessages()
    {
        Logger.LogDebug(1, "This is a debug message.");
        Logger.LogInformation(3, "This is an information message.");
        Logger.LogWarning(5, "This is a warning message.");
        Logger.LogError(7, "This is an error message.");
        Logger.LogTrace(5!, "This is a trace message.");
    }
}
```

The following output is seen in the browser's developer tools console when the **`Log Messages`** button is selected. The log entries reflect the appropriate formats applied by the custom logger:

> :::no-loc text="LoggingTest.Pages.Index: This is an information message.":::  
> :::no-loc text="LoggingTest.Pages.Index: This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

From a casual inspection of the preceding example, it's apparent that setting the log line formats via the dictionary in `CustomLoggerConfiguration` isn't strictly necessary. The line formats applied by the custom logger (`CustomLogger`) could have been applied by merely checking the `logLevel` in the `Log` method. The purpose of assigning the log format via configuration is that the developer can change the log format easily via app configuration, as the following example demonstrates.

In the `wwwroot` folder, add or update the `appsettings.json` file to include logging configuration. Set the log format to `Long` for all three log levels:

```json
{
  "Logging": {
    "CustomLog": {
      "LogLevels": {
        "Information": "Long",
        "Warning": "Long",
        "Error": "Long"
      }
    }
  }
}
```

In the preceding example, notice that the entry for the custom logger configuration is `CustomLog`, which was applied to the custom logger provider (`CustomLoggerProvider`) as an alias with `[ProviderAlias("CustomLog")]`. The logging configuration could have been applied with the name `CustomLoggerProvider` instead of `CustomLog`, but use of the alias `CustomLog` is more user friendly.

In `Program.cs` consume the logging configuration. Add the following code:

```csharp
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

The call to <xref:Microsoft.Extensions.Logging.Configuration.LoggingBuilderConfigurationExtensions.AddConfiguration%2A?displayProperty=nameWithType> can be placed either before or after adding the custom logger provider.

Run the app again. Select the the **`Log Messages`** button. Notice that the logging configuration is applied from the `appsettings.json` file. All three log entries are in the long (`LogFormat.Long`) format:

> :::no-loc text="[ 3: Information ] LoggingTest.Pages.Index - This is an information message.":::  
> :::no-loc text="[ 5: Warning     ] LoggingTest.Pages.Index - This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

### Log scopes

The Blazor WebAssembly developer tools console logger doesn't support [log scopes](xref:fundamentals/logging/index#log-scopes). However, you can build a [custom logger](#custom-logger-provider) to support log scopes in an app.

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not supported for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Additional resources

* <xref:fundamentals/logging/index>
* [`Loglevel` Enum (API documentation)](xref:Microsoft.Extensions.Logging.LogLevel)
* [Implement a custom logging provider in .NET](/dotnet/core/extensions/custom-logging-provider)
* Browser developer tools documentation:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

## Configuration

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Razor component logging

Loggers respect app startup configuration. For configuration information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example:

* [Injects](xref:blazor/fundamentals/dependency-injection) an <xref:Microsoft.Extensions.Logging.ILogger> (`ILogger<Counter>`) object to create a logger. The log's *category* is the fully qualified name of the component's type, `Counter`.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level.
* Doesn't require additional setup in the app in order to log to the browser's [developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

> [!NOTE]
> Guidance on popular browsers' developer tools can be found in the documentation of each browser maintainer:
>
> * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
> * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
> * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)

For more information, see <xref:fundamentals/logging/index>.

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Logging in Blazor WebAssembly apps

Not every feature of [ASP.NET Core logging](xref:fundamentals/logging/index) is supported in Blazor WebAssembly apps. For example, Blazor WebAssembly apps don't have access to the client's file system or network, so writing logs to the client's physical or network storage isn't possible. When using a third-party logging service designed to work with single-page apps (SPAs), follow the service's security guidance. Keep in mind that every piece of data, including keys or secrets stored in the Blazor WebAssembly app are ***insecure*** and can be easily discovered by malicious users.

Depending on the framework version and logging features, logging implementations may require adding the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.Extensions.Logging;
```

Configure logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property. The <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging> property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so the extension methods of <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are supported.

To set the minimum logging level, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> on the host builder in `Program.cs` with the <xref:Microsoft.Extensions.Logging.LogLevel>. The following example sets the minimum log level to <xref:Microsoft.Extensions.Logging.LogLevel.Warning>:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

### Custom logger provider in Blazor WebAssembly apps

The example in this section demonstrates a custom logger provider for further customization.

Add a package reference to the app for the [`Microsoft.Extensions.Logging.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration) package.

[!INCLUDE[](~/includes/package-reference.md)]

Add the following custom logger configuration. The configuration establishes a `LogLevels` dictionary that sets a custom log format for three log levels: <xref:Microsoft.Extensions.Logging.LogLevel.Information>, <xref:Microsoft.Extensions.Logging.LogLevel.Warning>, and <xref:Microsoft.Extensions.Logging.LogLevel.Error>. A `LogFormat` [`enum`](/dotnet/csharp/language-reference/builtin-types/enum) is used to describe short (`LogFormat.Short`) and long (`LogFormat.Long`) formats.

`CustomLoggerConfiguration.cs`:

```csharp
using Microsoft.Extensions.Logging;

public class CustomLoggerConfiguration
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, LogFormat> LogLevels { get; set; } = 
        new()
        {
            [LogLevel.Information] = LogFormat.Short,
            [LogLevel.Warning] = LogFormat.Short,
            [LogLevel.Error] = LogFormat.Long
        };

    public enum LogFormat
    {
        Short,
        Long
    }
}
```

Add the following custom logger to the app. The `CustomLogger` outputs custom log formats based on the `logLevel` values defined in the preceding `CustomLoggerConfiguration` configuration.

```csharp
using Microsoft.Extensions.Logging;
using static CustomLoggerConfiguration;

public sealed class CustomLogger : ILogger
{
    private readonly string name;
    private readonly Func<CustomLoggerConfiguration> getCurrentConfig;

    public CustomLogger(
        string name,
        Func<CustomLoggerConfiguration> getCurrentConfig) =>
        (this.name, this.getCurrentConfig) = (name, getCurrentConfig);

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        getCurrentConfig().LogLevels.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        CustomLoggerConfiguration config = getCurrentConfig();

        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            switch (config.LogLevels[logLevel])
            {
                case LogFormat.Short:
                    Console.WriteLine($"{name}: {formatter(state, exception)}");
                    break;
                case LogFormat.Long:
                    Console.WriteLine($"[{eventId.Id, 2}: {logLevel, -12}] {name} - {formatter(state, exception)}");
                    break;
                default:
                    // No-op
                    break;
            }
        }
    }
}
```

Add the following custom logger provider to the app. `CustomLoggerProvider` adopts an [`Options`-based approach](xref:fundamentals/configuration/options) to configure the logger via built-in logging configuration features. For example, the app can set or change log formats via an `appsettings.json` file without requiring code changes to the custom logger, which is demonstrated at the end of this section.

`CustomLoggerProvider.cs`:

```csharp
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

[ProviderAlias("CustomLog")]
public sealed class CustomLoggerProvider : ILoggerProvider
{
    private readonly IDisposable onChangeToken;
    private CustomLoggerConfiguration config;
    private readonly ConcurrentDictionary<string, CustomLogger> loggers =
        new(StringComparer.OrdinalIgnoreCase);

    public CustomLoggerProvider(
        IOptionsMonitor<CustomLoggerConfiguration> config)
    {
        this.config = config.CurrentValue;
        onChangeToken = config.OnChange(updatedConfig => this.config = updatedConfig);
    }

    public ILogger CreateLogger(string categoryName) =>
        loggers.GetOrAdd(categoryName, name => new CustomLogger(name, GetCurrentConfig));

    private CustomLoggerConfiguration GetCurrentConfig() => config;

    public void Dispose()
    {
        loggers.Clear();
        onChangeToken.Dispose();
    }
}
```

Add the following custom logger extensions.

`CustomLoggerExtensions.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

public static class CustomLoggerExtensions
{
    public static ILoggingBuilder AddCustomLogger(
        this ILoggingBuilder builder)
    {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, CustomLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <CustomLoggerConfiguration, CustomLoggerProvider>(builder.Services);

        return builder;
    }
}
```

In `Program.cs` on the host builder, clear the existing provider by calling <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> and add the custom logging provider:

```csharp
builder.Logging.ClearProviders().AddCustomLogger();
```

In the following `Index` component:

* The debug message isn't logged.
* The information message is logged in the short format (`LogFormat.Short`).
* The warning message is logged in the short format (`LogFormat.Short`).
* The error message is logged in the long format  (`LogFormat.Long`).
* The trace message isn't logged.

`Pages/Index.razor`:

```razor
@page "/"
@using Microsoft.Extensions.Logging
@inject ILogger<Index> Logger

<p>
    <button @onclick="LogMessages">Log Messages</button>
</p>

@code{
    private void LogMessages()
    {
        Logger.LogDebug(1, "This is a debug message.");
        Logger.LogInformation(3, "This is an information message.");
        Logger.LogWarning(5, "This is a warning message.");
        Logger.LogError(7, "This is an error message.");
        Logger.LogTrace(5!, "This is a trace message.");
    }
}
```

The following output is seen in the browser's developer tools console when the **`Log Messages`** button is selected. The log entries reflect the appropriate formats applied by the custom logger:

> :::no-loc text="LoggingTest.Pages.Index: This is an information message.":::  
> :::no-loc text="LoggingTest.Pages.Index: This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

From a casual inspection of the preceding example, it's apparent that setting the log line formats via the dictionary in `CustomLoggerConfiguration` isn't strictly necessary. The line formats applied by the custom logger (`CustomLogger`) could have been applied by merely checking the `logLevel` in the `Log` method. The purpose of assigning the log format via configuration is that the developer can change the log format easily via app configuration, as the following example demonstrates.

In the `wwwroot` folder, add or update the `appsettings.json` file to include logging configuration. Set the log format to `Long` for all three log levels:

```json
{
  "Logging": {
    "CustomLog": {
      "LogLevels": {
        "Information": "Long",
        "Warning": "Long",
        "Error": "Long"
      }
    }
  }
}
```

In the preceding example, notice that the entry for the custom logger configuration is `CustomLog`, which was applied to the custom logger provider (`CustomLoggerProvider`) as an alias with `[ProviderAlias("CustomLog")]`. The logging configuration could have been applied with the name `CustomLoggerProvider` instead of `CustomLog`, but use of the alias `CustomLog` is more user friendly.

In `Program.cs` consume the logging configuration. Add the following code:

```csharp
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

The call to <xref:Microsoft.Extensions.Logging.Configuration.LoggingBuilderConfigurationExtensions.AddConfiguration%2A?displayProperty=nameWithType> can be placed either before or after adding the custom logger provider.

Run the app again. Select the the **`Log Messages`** button. Notice that the logging configuration is applied from the `appsettings.json` file. All three log entries are in the long (`LogFormat.Long`) format:

> :::no-loc text="[ 3: Information ] LoggingTest.Pages.Index - This is an information message.":::  
> :::no-loc text="[ 5: Warning     ] LoggingTest.Pages.Index - This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not supported for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Additional resources

* <xref:fundamentals/logging/index>
* [Implement a custom logging provider in .NET](/dotnet/core/extensions/custom-logging-provider)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

## Configuration

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Razor component logging

Loggers respect app startup configuration. For configuration information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example:

* [Injects](xref:blazor/fundamentals/dependency-injection) an <xref:Microsoft.Extensions.Logging.ILogger> (`ILogger<Counter>`) object to create a logger. The log's *category* is the fully qualified name of the component's type, `Counter`.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level.
* Doesn't require additional setup in the app in order to log to the browser's [developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

> [!NOTE]
> Guidance on popular browsers' developer tools can be found in the documentation of each browser maintainer:
>
> * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
> * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
> * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)

For more information, see <xref:fundamentals/logging/index>.

## Logging in Blazor Server apps

For general ASP.NET Core logging guidance that pertains to Blazor Server, see <xref:fundamentals/logging/index>.

## Logging in Blazor WebAssembly apps

Not every feature of [ASP.NET Core logging](xref:fundamentals/logging/index) is supported in Blazor WebAssembly apps. For example, Blazor WebAssembly apps don't have access to the client's file system or network, so writing logs to the client's physical or network storage isn't possible. When using a third-party logging service designed to work with single-page apps (SPAs), follow the service's security guidance. Keep in mind that every piece of data, including keys or secrets stored in the Blazor WebAssembly app are ***insecure*** and can be easily discovered by malicious users.

Depending on the framework version and logging features, logging implementations may require adding the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.Extensions.Logging;
```

Configure logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property. The <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging> property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so the extension methods of <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are supported.

To set the minimum logging level, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> on the host builder in `Program.cs` with the <xref:Microsoft.Extensions.Logging.LogLevel>. The following example sets the minimum log level to <xref:Microsoft.Extensions.Logging.LogLevel.Warning>:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

### Custom logger provider in Blazor WebAssembly apps

The example in this section demonstrates a custom logger provider for further customization.

Add a package reference to the app for the [`Microsoft.Extensions.Logging.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration) package.

[!INCLUDE[](~/includes/package-reference.md)]

Add the following custom logger configuration. The configuration establishes a `LogLevels` dictionary that sets a custom log format for three log levels: <xref:Microsoft.Extensions.Logging.LogLevel.Information>, <xref:Microsoft.Extensions.Logging.LogLevel.Warning>, and <xref:Microsoft.Extensions.Logging.LogLevel.Error>. A `LogFormat` [`enum`](/dotnet/csharp/language-reference/builtin-types/enum) is used to describe short (`LogFormat.Short`) and long (`LogFormat.Long`) formats.

`CustomLoggerConfiguration.cs`:

```csharp
using Microsoft.Extensions.Logging;

public class CustomLoggerConfiguration
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, LogFormat> LogLevels { get; set; } = 
        new()
        {
            [LogLevel.Information] = LogFormat.Short,
            [LogLevel.Warning] = LogFormat.Short,
            [LogLevel.Error] = LogFormat.Long
        };

    public enum LogFormat
    {
        Short,
        Long
    }
}
```

Add the following custom logger to the app. The `CustomLogger` outputs custom log formats based on the `logLevel` values defined in the preceding `CustomLoggerConfiguration` configuration.

```csharp
using Microsoft.Extensions.Logging;
using static CustomLoggerConfiguration;

public sealed class CustomLogger : ILogger
{
    private readonly string name;
    private readonly Func<CustomLoggerConfiguration> getCurrentConfig;

    public CustomLogger(
        string name,
        Func<CustomLoggerConfiguration> getCurrentConfig) =>
        (this.name, this.getCurrentConfig) = (name, getCurrentConfig);

    public IDisposable BeginScope<TState>(TState state) => default!;

    public bool IsEnabled(LogLevel logLevel) =>
        getCurrentConfig().LogLevels.ContainsKey(logLevel);

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel))
        {
            return;
        }

        CustomLoggerConfiguration config = getCurrentConfig();

        if (config.EventId == 0 || config.EventId == eventId.Id)
        {
            switch (config.LogLevels[logLevel])
            {
                case LogFormat.Short:
                    Console.WriteLine($"{name}: {formatter(state, exception)}");
                    break;
                case LogFormat.Long:
                    Console.WriteLine($"[{eventId.Id, 2}: {logLevel, -12}] {name} - {formatter(state, exception)}");
                    break;
                default:
                    // No-op
                    break;
            }
        }
    }
}
```

Add the following custom logger provider to the app. `CustomLoggerProvider` adopts an [`Options`-based approach](xref:fundamentals/configuration/options) to configure the logger via built-in logging configuration features. For example, the app can set or change log formats via an `appsettings.json` file without requiring code changes to the custom logger, which is demonstrated at the end of this section.

`CustomLoggerProvider.cs`:

```csharp
using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

[ProviderAlias("CustomLog")]
public sealed class CustomLoggerProvider : ILoggerProvider
{
    private readonly IDisposable onChangeToken;
    private CustomLoggerConfiguration config;
    private readonly ConcurrentDictionary<string, CustomLogger> loggers =
        new(StringComparer.OrdinalIgnoreCase);

    public CustomLoggerProvider(
        IOptionsMonitor<CustomLoggerConfiguration> config)
    {
        this.config = config.CurrentValue;
        onChangeToken = config.OnChange(updatedConfig => this.config = updatedConfig);
    }

    public ILogger CreateLogger(string categoryName) =>
        loggers.GetOrAdd(categoryName, name => new CustomLogger(name, GetCurrentConfig));

    private CustomLoggerConfiguration GetCurrentConfig() => config;

    public void Dispose()
    {
        loggers.Clear();
        onChangeToken.Dispose();
    }
}
```

Add the following custom logger extensions.

`CustomLoggerExtensions.cs`:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;

public static class CustomLoggerExtensions
{
    public static ILoggingBuilder AddCustomLogger(
        this ILoggingBuilder builder)
    {
        builder.AddConfiguration();

        builder.Services.TryAddEnumerable(
            ServiceDescriptor.Singleton<ILoggerProvider, CustomLoggerProvider>());

        LoggerProviderOptions.RegisterProviderOptions
            <CustomLoggerConfiguration, CustomLoggerProvider>(builder.Services);

        return builder;
    }
}
```

In `Program.cs` on the host builder, clear the existing provider by calling <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> and add the custom logging provider:

```csharp
builder.Logging.ClearProviders().AddCustomLogger();
```

In the following `Index` component:

* The debug message isn't logged.
* The information message is logged in the short format (`LogFormat.Short`).
* The warning message is logged in the short format (`LogFormat.Short`).
* The error message is logged in the long format  (`LogFormat.Long`).
* The trace message isn't logged.

`Pages/Index.razor`:

```razor
@page "/"
@using Microsoft.Extensions.Logging
@inject ILogger<Index> Logger

<p>
    <button @onclick="LogMessages">Log Messages</button>
</p>

@code{
    private void LogMessages()
    {
        Logger.LogDebug(1, "This is a debug message.");
        Logger.LogInformation(3, "This is an information message.");
        Logger.LogWarning(5, "This is a warning message.");
        Logger.LogError(7, "This is an error message.");
        Logger.LogTrace(5!, "This is a trace message.");
    }
}
```

The following output is seen in the browser's developer tools console when the **`Log Messages`** button is selected. The log entries reflect the appropriate formats applied by the custom logger:

> :::no-loc text="LoggingTest.Pages.Index: This is an information message.":::  
> :::no-loc text="LoggingTest.Pages.Index: This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

From a casual inspection of the preceding example, it's apparent that setting the log line formats via the dictionary in `CustomLoggerConfiguration` isn't strictly necessary. The line formats applied by the custom logger (`CustomLogger`) could have been applied by merely checking the `logLevel` in the `Log` method. The purpose of assigning the log format via configuration is that the developer can change the log format easily via app configuration, as the following example demonstrates.

In the `wwwroot` folder, add or update the `appsettings.json` file to include logging configuration. Set the log format to `Long` for all three log levels:

```json
{
  "Logging": {
    "CustomLog": {
      "LogLevels": {
        "Information": "Long",
        "Warning": "Long",
        "Error": "Long"
      }
    }
  }
}
```

In the preceding example, notice that the entry for the custom logger configuration is `CustomLog`, which was applied to the custom logger provider (`CustomLoggerProvider`) as an alias with `[ProviderAlias("CustomLog")]`. The logging configuration could have been applied with the name `CustomLoggerProvider` instead of `CustomLog`, but use of the alias `CustomLog` is more user friendly.

In `Program.cs` consume the logging configuration. Add the following code:

```csharp
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

The call to <xref:Microsoft.Extensions.Logging.Configuration.LoggingBuilderConfigurationExtensions.AddConfiguration%2A?displayProperty=nameWithType> can be placed either before or after adding the custom logger provider.

Run the app again. Select the the **`Log Messages`** button. Notice that the logging configuration is applied from the `appsettings.json` file. All three log entries are in the long (`LogFormat.Long`) format:

> :::no-loc text="[ 3: Information ] LoggingTest.Pages.Index - This is an information message.":::  
> :::no-loc text="[ 5: Warning     ] LoggingTest.Pages.Index - This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.Index - This is an error message.":::

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not supported for direct use in developer code.

Add the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> and inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> into the component:

```razor
@using Microsoft.Extensions.Logging
@inject ILoggerProvider LoggerProvider
```

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType>:

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl(NavigationManager.ToAbsoluteUri("/chathub"))
    .ConfigureLogging(logging => logging.AddProvider(LoggerProvider))
    .Build();
```

## Additional resources

* <xref:fundamentals/logging/index>
* [Implement a custom logging provider in .NET](/dotnet/core/extensions/custom-logging-provider)

:::moniker-end
