---
title: ASP.NET Core Blazor logging
author: guardrex
description: Learn about logging in Blazor apps, including log level configuration and how to write log messages from Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/03/2022
no-loc: ["Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/fundamentals/logging
---
# ASP.NET Core Blazor logging

:::moniker range=">= aspnetcore-6.0"

## Configuration

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

## Razor component logging

Loggers respect app startup configuration. For configuration information, see <xref:#Logging configuration>.

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

The following example:

* [Injects](xref:blazor/fundamentals/dependency-injection) an <xref:Microsoft.Extensions.Logging.ILogger> (`ILogger<Counter>`) object to create a logger. The log's *category* is the fully qualified name of the component's type, `Counter`.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level.
* Doesn't require any additional setup in the app in order to log to the browser's [developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor?highlight=3,16)]

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor?highlight=3,16-17)]

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

Not every feature of [ASP.NET Core logging](xref:fundamentals/logging/index) is available in a Blazor WebAssembly app. For example, Blazor WebAssembly apps don't have access to the client's file system or network, so writing logs to the client's physical or network storage isn't possible. When using a third-party logging service designed to work with single-page apps (SPAs), follow the service's security guidance. Keep in mind that every piece of data, including keys or secrets stored in the Blazor WebAssembly app are ***insecure*** and can be easily discovered by malicious users.

Depending on the framework version and logging features, logging implementations may require adding the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to `Program.cs`:

```csharp
using Microsoft.Extensions.Logging;
```

Configure logging in Blazor WebAssembly apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property. The `Logging` property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so all of the extension methods available on <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are available on `Logging`.

To set the minimum logging level, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> on the host builder in `Program.cs` with the <xref:Microsoft.Extensions.Logging.LogLevel>. The following example sets the minimum log level to <xref:Microsoft.Extensions.Logging.LogLevel.Warning>:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

### Custom logger provider in Blazor WebAssembly apps

The example in this section demonstrates a custom logger provider for further customization.

Add a package reference to the app for the [`Microsoft.Extensions.Logging.Configuration`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Configuration) package.

[!INCLUDE[](~/includes/package-reference.md)]

Add the following custom logger configuration. The configuration establishes a `LogLevels` dictionary that matches a custom log format for three log levels: <xref:Microsoft.Extensions.Logging.LogLevel.Information>, <xref:Microsoft.Extensions.Logging.LogLevel.Warning>, and <xref:Microsoft.Extensions.Logging.LogLevel.Error>.

`CustomLoggerConfiguration.cs`:

```csharp
using Microsoft.Extensions.Logging;

public class CustomLoggerConfiguration
{
    public int EventId { get; set; }

    public Dictionary<LogLevel, int> LogLevels { get; set; } = new()
    {
        [LogLevel.Information] = 1,
        [LogLevel.Warning] = 2,
        [LogLevel.Error] = 3
    };
}
```

The `LogLevels` dictionary is used later by the custom logger to provide log formats for each log level. An integer value (1, 2, or 3) represents the format for a log level. Setting integer values for the log levels permits logging configuration, for example via an `appsettings.json` file, to set or change log formats without requiring code changes to the custom logger.

Add the following custom logger to the app. The `CustomLogger` outputs custom log formats based on the `logLevel` values defined in the preceding `CustomLoggerConfiguration` configuration.

```csharp
using Microsoft.Extensions.Logging;

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
                case 1:
                    Console.WriteLine($"[{eventId.Id, 2}: {logLevel, -12}] {name} - {formatter(state, exception)}");
                    break;
                case 2:
                    Console.WriteLine($"{name}: {formatter(state, exception)}");
                    break;
                case 3:
                    Console.WriteLine($"{logLevel, -12}:{eventId.Id, 2}:{formatter(state, exception)}:{name}");
                    break;
                default:
                    // No-op
                    break;
            }
        }
    }
}
```

Add the following custom logger provider to the app.

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
* The information message is logged in format `1`.
* The warning message is logged in format `2`.
* The error message is logged in format `3`.
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

> [ 3: Information ] LoggingTest.Pages.Index - This is an information message.
> LoggingTest.Pages.Index: This is a warning message.
> Error       : 7:This is an error message.:LoggingTest.Pages.Index

From a casual inspection of the preceding example, it's apparent that setting the log line formats via the dictionary in `CustomLoggerConfiguration` isn't strictly necessary. The line formats applied by the custom logger (`CustomLogger`) could have been applied by merely checking the `logLevel` in the `Log` method. The value of assigning the log format via configuration is that one can change the log format easily via app configuration using the preceding approach.

In the `wwwroot` folder, add or update the `appsettings.json` file to include logging configuration. Set the log format to `3` for the three log levels:

```json
{
  "Logging": {
    "CustomLog": {
      "LogLevels": {
        "Information": 3,
        "Warning": 3,
        "Error": 3
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

Run the app again. Select the the **`Log Messages`** button and notice that the logging configuration is applied. All of the log entries are in log format `3`:

> Information : 3:This is an information message.:LoggingTest.Pages.Index
> Warning     : 5:This is a warning message.:LoggingTest.Pages.Index
> Error       : 7:This is an error message.:LoggingTest.Pages.Index

## Hosted Blazor WebAssembly logging

A hosted Blazor WebAssembly app that [prerenders its content](xref:blazor/components/prerendering-and-integration) executes [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR .NET client logging

Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not available for direct use in developer code.

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

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"



:::moniker-end

:::moniker range="< aspnetcore-5.0"



:::moniker-end
