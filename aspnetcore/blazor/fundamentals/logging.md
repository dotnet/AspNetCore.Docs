---
title: ASP.NET Core Blazor logging
author: guardrex
description: Learn about Blazor app logging, including configuration and how to write log messages from Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 08/01/2023
uid: blazor/fundamentals/logging
---
# ASP.NET Core Blazor logging

[!INCLUDE[](~/includes/not-latest-version.md)]

<!--
    NOTE: The console output block quotes in this topic use a double-space 
    at the ends of lines to generate a bare return in block quote output.
-->

This article explains Blazor app logging, including configuration and how to write log messages from Razor components.

[!INCLUDE[](~/blazor/includes/location-client-and-server-net31-or-later.md)]

## Configuration

Logging configuration can be loaded from app settings files. For more information, see <xref:blazor/fundamentals/configuration#logging-configuration>.

At default log levels and without configuring additional logging providers:

* On the server, logging only occurs to the server-side .NET console in the `Development` environment at the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level or higher.
* On the client, logging only occurs to the client-side [browser developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console at the <xref:Microsoft.Extensions.Logging.LogLevel.Information?displayProperty=nameWithType> level or higher.

:::moniker range=">= aspnetcore-6.0"

When the app is configured in the project file to use implicit namespaces (`<ImplicitUsings>enable</ImplicitUsings>`), a `using` directive for <xref:Microsoft.Extensions.Logging> or any API in the <xref:Microsoft.Extensions.Logging.LoggerExtensions> class isn't required to support API [Visual Studio IntelliSense](/visualstudio/ide/using-intellisense) completions or building apps. If implicit namespaces aren't enabled, Razor components must explicitly define [`@using` directives](xref:mvc/views/razor#using) for logging namespaces that aren't imported via the `_Imports.razor` file.

:::moniker-end

## Log levels

Log levels conform to ASP.NET Core app log levels, which are listed in the API documentation at <xref:Microsoft.Extensions.Logging.LogLevel>.

## Razor component logging

:::moniker range="< aspnetcore-6.0"

The `using` directive for <xref:Microsoft.Extensions.Logging> is required to support [IntelliSense](/visualstudio/ide/using-intellisense) completions for APIs, such as <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> and <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>.

:::moniker-end

The following example:

* [Injects](xref:blazor/fundamentals/dependency-injection) an <xref:Microsoft.Extensions.Logging.ILogger> (`ILogger<Counter1>`) object to create a logger. The log's *category* is the fully qualified name of the component's type, `Counter`.
* Calls <xref:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning%2A> to log at the <xref:Microsoft.Extensions.Logging.LogLevel.Warning> level.

`Counter1.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor" highlight="2,15":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor" highlight="2,15":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter1.razor" highlight="3,16":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter1.razor" highlight="3,16":::

:::moniker-end

The following example demonstrates logging with an <xref:Microsoft.Extensions.Logging.ILoggerFactory> in components.

`Counter2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor" highlight="2,15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor" highlight="2,15-16":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/logging/Counter2.razor" highlight="3,16-17":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/logging/Counter2.razor" highlight="3,16-17":::

:::moniker-end


## Server-side logging

For general ASP.NET Core logging guidance, see <xref:fundamentals/logging/index>.

## Client-side logging

Not every feature of [ASP.NET Core logging](xref:fundamentals/logging/index) is supported client-side. For example, client-side components don't have access to the client's file system or network, so writing logs to the client's physical or network storage isn't possible. When using a third-party logging service designed to work with single-page apps (SPAs), follow the service's security guidance. Keep in mind that every piece of data, including keys or secrets stored client-side are ***insecure*** and can be easily discovered by malicious users.

:::moniker range="< aspnetcore-6.0"

Depending on the framework version and logging features, logging implementations may require adding the namespace for <xref:Microsoft.Extensions.Logging?displayProperty=fullName> to the `Program` file:

```csharp
using Microsoft.Extensions.Logging;
```

:::moniker-end

Configure logging in client-side apps with the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging?displayProperty=nameWithType> property. The <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.Logging> property is of type <xref:Microsoft.Extensions.Logging.ILoggingBuilder>, so the extension methods of <xref:Microsoft.Extensions.Logging.ILoggingBuilder> are supported.

To set the minimum logging level, call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> on the host builder in the `Program` file with the <xref:Microsoft.Extensions.Logging.LogLevel>. The following example sets the minimum log level to <xref:Microsoft.Extensions.Logging.LogLevel.Warning>:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Warning);
```

:::moniker range=">= aspnetcore-6.0"

## Log in the client-side `Program` file

Logging is supported in client-side apps after the <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder> is built using the framework's internal console logger provider ([`WebAssemblyConsoleLoggerProvider` (reference source)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/WebAssembly/WebAssembly/src/Services/WebAssemblyConsoleLoggerProvider.cs)).

In the `Program` file:

```csharp
var host = builder.Build();

var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Logged after the app is built in the Program file.");

await host.RunAsync();
```

Developer tools console output:

> :::no-loc text="info: Program[0]":::  
> :::no-loc text="Logged after the app is built in the Program file.":::

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

## Client-side log category

[Log categories](xref:fundamentals/logging/index#log-category) are supported.

The following example shows how to use log categories with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Counter.razor`) that injects an <xref:Microsoft.Extensions.Logging.ILoggerFactory> as `LoggerFactory`:

```csharp
var logger = LoggerFactory.CreateLogger("CustomCategory");
logger.LogWarning("Someone has clicked me!");
```

Developer tools console output:

> :::no-loc text="warn: CustomCategory[0]":::  
> :::no-loc text="Someone has clicked me!":::

## Client-side log event ID

[Log event ID](xref:fundamentals/logging/index#log-event-id) is supported.

The following example shows how to use log event IDs with the `Counter` component of an app created from a Blazor project template.

`LogEvent.cs`:

```csharp
public class LogEvent
{
    public const int Event1 = 1000;
    public const int Event2 = 1001;
}
```

In the `IncrementCount` method of the app's `Counter` component (`Counter.razor`):

```csharp
logger.LogInformation(LogEvent.Event1, "Someone has clicked me!");
logger.LogWarning(LogEvent.Event2, "Someone has clicked me!");
```

Developer tools console output:

> :::no-loc text="info: BlazorSample.Pages.Counter[1000]":::  
> :::no-loc text="Someone has clicked me!":::  
> :::no-loc text="warn: BlazorSample.Pages.Counter[1001]":::  
> :::no-loc text="Someone has clicked me!":::

## Client-side log message template

[Log message templates](xref:fundamentals/logging/index#log-message-template) are supported:

The following example shows how to use log message templates with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Counter.razor`):

```csharp
logger.LogInformation("Someone clicked me at {CurrentDT}!", DateTime.UtcNow);
```

Developer tools console output:

> :::no-loc text="info: BlazorSample.Pages.Counter[0]":::  
> :::no-loc text="Someone clicked me at 04/21/2022 12:15:57!":::

## Client-side log exception parameters

[Log exception parameters](xref:fundamentals/logging/index#log-exceptions) are supported.

The following example shows how to use log exception parameters with the `Counter` component of an app created from a Blazor project template.

In the `IncrementCount` method of the app's `Counter` component (`Counter.razor`):

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

## Client-side filter function

[Filter functions](xref:fundamentals/logging/index#filter-function) are supported.

The following example shows how to use a filter with the `Counter` component of an app created from a Blazor project template.

In the `Program` file:

```csharp
builder.Logging.AddFilter((provider, category, logLevel) =>
    category.Equals("CustomCategory2") && logLevel == LogLevel.Information);
```

In the `IncrementCount` method of the app's `Counter` component (`Counter.razor`) that injects an <xref:Microsoft.Extensions.Logging.ILoggerFactory> as `LoggerFactory`:

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

In the developer tools console output, the filter only permits logging for the `CustomCategory2` category and <xref:Microsoft.Extensions.Logging.LogLevel.Information> log level message:

> :::no-loc text="info: CustomCategory2[0]":::  
> :::no-loc text="Someone has clicked me!":::

The app can also configure log filtering for specific namespaces. For example, set the log level to <xref:Microsoft.Extensions.Logging.LogLevel.Trace> in the `Program` file:

```csharp
builder.Logging.SetMinimumLevel(LogLevel.Trace);
```

Normally at the <xref:Microsoft.Extensions.Logging.LogLevel.Trace> log level, developer tools console output at the **Verbose** level includes <xref:Microsoft.AspNetCore.Components.RenderTree> logging messages, such as the following:

> :::no-loc text="dbug: Microsoft.AspNetCore.Components.RenderTree.Renderer[3]":::  
> :::no-loc text="Rendering component 14 of type Microsoft.AspNetCore.Components.Web.HeadOutlet":::

In the `Program` file, logging messages specific to <xref:Microsoft.AspNetCore.Components.RenderTree> can be disabled using ***either*** of the following approaches:

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

:::moniker-end

## Client-side custom logger provider

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

In the `Program` file on the host builder, clear the existing provider by calling <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A> and add the custom logging provider:

```csharp
builder.Logging.ClearProviders().AddCustomLogger();
```

In the following `CustomLoggerExample` component:

* The debug message isn't logged.
* The information message is logged in the short format (`LogFormat.Short`).
* The warning message is logged in the short format (`LogFormat.Short`).
* The error message is logged in the long format  (`LogFormat.Long`).
* The trace message isn't logged.

`CustomLoggerExample.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/custom-logger-example"
@rendermode RenderMode.InteractiveWebAssembly
@using Microsoft.Extensions.Logging
@inject ILogger<CustomLoggerExample> Logger

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

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/custom-logger-example"
@using Microsoft.Extensions.Logging
@inject ILogger<CustomLoggerExample> Logger

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

:::moniker-end

The following output is seen in the browser's developer tools console when the **`Log Messages`** button is selected. The log entries reflect the appropriate formats applied by the custom logger (the client app is named `LoggingTest`):

> :::no-loc text="LoggingTest.Pages.CustomLoggerExample: This is an information message.":::  
> :::no-loc text="LoggingTest.Pages.CustomLoggerExample: This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.CustomLoggerExample - This is an error message.":::

From a casual inspection of the preceding example, it's apparent that setting the log line formats via the dictionary in `CustomLoggerConfiguration` isn't strictly necessary. The line formats applied by the custom logger (`CustomLogger`) could have been applied by merely checking the `logLevel` in the `Log` method. The purpose of assigning the log format via configuration is that the developer can change the log format easily via app configuration, as the following example demonstrates.

In the client-side app, add or update the `appsettings.json` file to include logging configuration. Set the log format to `Long` for all three log levels:

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

In the `Program` file, consume the logging configuration. Add the following code:

```csharp
builder.Logging.AddConfiguration(
    builder.Configuration.GetSection("Logging"));
```

The call to <xref:Microsoft.Extensions.Logging.Configuration.LoggingBuilderConfigurationExtensions.AddConfiguration%2A?displayProperty=nameWithType> can be placed either before or after adding the custom logger provider.

Run the app again. Select the **`Log Messages`** button. Notice that the logging configuration is applied from the `appsettings.json` file. All three log entries are in the long (`LogFormat.Long`) format (the client app is named `LoggingTest`):

> :::no-loc text="[ 3: Information ] LoggingTest.Pages.CustomLoggerExample - This is an information message.":::  
> :::no-loc text="[ 5: Warning     ] LoggingTest.Pages.CustomLoggerExample - This is a warning message.":::  
> :::no-loc text="[ 7: Error       ] LoggingTest.Pages.CustomLoggerExample - This is an error message.":::

:::moniker range=">= aspnetcore-6.0"

## Client-side log scopes

The developer tools console logger doesn't support [log scopes](xref:fundamentals/logging/index#log-scopes). However, a [custom logger](#client-side-custom-logger-provider) can support log scopes. For an unsupported example that you can further develop to suit your needs, see the `BlazorWebAssemblyScopesLogger` sample app in the [`dotnet/blazor-samples` GitHub repository](https://github.com/dotnet/blazor-samples).

The sample app uses standard ASP.NET Core `BeginScope` logging syntax to indicate scopes for logged messages. The `Logger` service in the following example is an `ILogger<CustomLoggerExample>`, which is injected into the app's `CustomLoggerExample` component (`CustomLoggerExample.razor`).

```csharp
using (Logger.BeginScope("L1"))
{
    Logger.LogInformation(3, "INFO: ONE scope.");
}

using (Logger.BeginScope("L1"))
{
    using (Logger.BeginScope("L2"))
    {
        Logger.LogInformation(3, "INFO: TWO scopes.");
    }
}

using (Logger.BeginScope("L1"))
{
    using (Logger.BeginScope("L2"))
    {
        using (Logger.BeginScope("L3"))
        {
            Logger.LogInformation(3, "INFO: THREE scopes.");
        }
    }
}
```

Output:

> :::no-loc text="[ 3: Information ] {CLASS} - INFO: ONE scope. => L1 blazor.webassembly.js:1:35542":::  
> :::no-loc text="[ 3: Information ] {CLASS} - INFO: TWO scopes. => L1 => L2 blazor.webassembly.js:1:35542":::  
> :::no-loc text="[ 3: Information ] {CLASS} - INFO: THREE scopes. => L1 => L2 => L3":::

The `{CLASS}` placeholder in the preceding example is `BlazorWebAssemblyScopesLogger.Pages.CustomLoggerExample`.

:::moniker-end

## Prerendered component logging

Prerendered components execute [component initialization code twice](xref:blazor/components/lifecycle#component-initialization-oninitializedasync). Logging takes place server-side on the first execution of initialization code and client-side on the second execution of initialization code. Depending on the goal of logging during initialization, check logs server-side, client-side, or both.

## SignalR client logging with the SignalR client builder

*This section applies to server-side apps.*

In Blazor script start configuration, pass in the `configureSignalR` configuration object that calls `configureLogging` with the log level.

For the `configureLogging` log level value, pass the argument as either the string or integer log level shown in the following table.

| <xref:Microsoft.Extensions.Logging.LogLevel>             | String setting | Integer setting |
| -------------------------------------------------------- | :------------: | :-------------: |
| <xref:Microsoft.Extensions.Logging.LogLevel.Trace>       | `trace`        | 0               |
| <xref:Microsoft.Extensions.Logging.LogLevel.Debug>       | `debug`        | 1               |
| <xref:Microsoft.Extensions.Logging.LogLevel.Information> | `information`  | 2               |
| <xref:Microsoft.Extensions.Logging.LogLevel.Warning>     | `warning`      | 3               |
| <xref:Microsoft.Extensions.Logging.LogLevel.Error>       | `error`        | 4               |
| <xref:Microsoft.Extensions.Logging.LogLevel.Critical>    | `critical`     | 5               |
| <xref:Microsoft.Extensions.Logging.LogLevel.None>        | `none`         | 6               |

Example 1: Set the <xref:Microsoft.Extensions.Logging.LogLevel.Information> log level with a string value.

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      configureSignalR: function (builder) {
        builder.configureLogging("information");
      }
    }
  });
</script>
```

Blazor Server:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.configureLogging("information");
    }
  });
</script>
```

In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

Example 2: Set the <xref:Microsoft.Extensions.Logging.LogLevel.Information> log level with an integer value.

:::moniker range=">= aspnetcore-8.0"

Blazor Web App:

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    circuit: {
      configureSignalR: function (builder) {
        builder.configureLogging("information");
      }
    }
  });
</script>
```

Blazor Server:

:::moniker-end

```html
<script src="{BLAZOR SCRIPT}" autostart="false"></script>
<script>
  Blazor.start({
    configureSignalR: function (builder) {
      builder.configureLogging(2);
    }
  });
</script>
```

In the preceding example, the `{BLAZOR SCRIPT}` placeholder is the Blazor script path and file name. For the location of the script, see <xref:blazor/project-structure#location-of-the-blazor-script>.

For more information on Blazor startup (`Blazor.start()`), see <xref:blazor/fundamentals/startup>.

## SignalR client logging with app configuration

Set up app settings configuration as described in <xref:blazor/fundamentals/configuration#logging-configuration>. Place app settings files in `wwwroot` that contain a `Logging:LogLevel:HubConnection` app setting.

> [!NOTE]
> As an alternative to using app settings, you can pass the <xref:Microsoft.Extensions.Logging.LogLevel> as the argument to <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.SetMinimumLevel%2A?displayProperty=nameWithType> when the hub connection is created in a Razor component. However, accidentally deploying the app to a production hosting environment with verbose logging may result in a performance penalty. We recommend using app settings to set the log level.

Provide a `Logging:LogLevel:HubConnection` app setting in the default `appsettings.json` file and in the `Development` environment app settings file. Use a typical less-verbose log level for the default, such as <xref:Microsoft.Extensions.Logging.LogLevel.Warning?displayProperty=nameWithType>. The default app settings value is what is used in `Staging` and `Production` environments if no app settings files for those environments are present. Use a verbose log level in the `Development` environment app settings file, such as <xref:Microsoft.Extensions.Logging.LogLevel.Trace?displayProperty=nameWithType>.

`wwwroot/appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "HubConnection": "Warning"
    }
  }
}
```

`wwwroot/appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "HubConnection": "Trace"
    }
  }
}
```

> [!IMPORTANT]
> Configuration in the preceding app settings files is only used by the app if the guidance in <xref:blazor/fundamentals/configuration#logging-configuration> is followed.

At the top of the Razor component file (`.razor`):

* Inject an <xref:Microsoft.Extensions.Logging.ILoggerProvider> to add a `WebAssemblyConsoleLogger` to the logging providers passed to <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilder>. Unlike a traditional <xref:Microsoft.Extensions.Logging.Console.ConsoleLogger>, `WebAssemblyConsoleLogger` is a wrapper around browser-specific logging APIs (for example, `console.log`). Use of `WebAssemblyConsoleLogger` makes logging possible within Mono inside a browser context.
* Inject an `IConfiguration` to read the `Logging:LogLevel:HubConnection` app setting.

> [!NOTE]
> `WebAssemblyConsoleLogger` is [internal](/dotnet/csharp/language-reference/keywords/internal) and not supported for direct use in developer code.

```csharp
@inject ILoggerProvider LoggerProvider
@inject IConfiguration Config
```

> [!NOTE]
> The following example is based on the demonstration in the [SignalR with Blazor tutorial](xref:blazor/tutorials/signalr-blazor). Consult the tutorial for further details.

In the component's [`OnInitializedAsync` method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), use <xref:Microsoft.AspNetCore.SignalR.Client.HubConnectionBuilderExtensions.ConfigureLogging%2A?displayProperty=nameWithType> to add the logging provider and set the minimum log level from configuration:

```csharp
protected override async Task OnInitializedAsync()
{
    hubConnection = new HubConnectionBuilder()
        .WithUrl(Navigation.ToAbsoluteUri("/chathub"))
        .ConfigureLogging(builder => 
        {
            builder.AddProvider(LoggerProvider);
            builder.SetMinimumLevel(
                Config.GetValue<LogLevel>("Logging:LogLevel:HubConnection"));
        })
        .Build();

    hubConnection.On<string, string>("ReceiveMessage", (user, message) => ...

    await hubConnection.StartAsync();
}
```

> [!NOTE]
> In the preceding example, `Navigation` is an injected <xref:Microsoft.AspNetCore.Components.NavigationManager>.

For more information on setting the app's environment, see <xref:blazor/fundamentals/environments>.

:::moniker range=">= aspnetcore-7.0"

## Client-side authentication logging

Log Blazor authentication messages at the <xref:Microsoft.Extensions.Logging.LogLevel.Debug?displayProperty=nameWithType> or <xref:Microsoft.Extensions.Logging.LogLevel.Trace?displayProperty=nameWithType> logging levels with a logging configuration in app settings or by using a log filter for <xref:Microsoft.AspNetCore.Components.WebAssembly.Authentication?displayProperty=fullName> in the `Program` file.

Use ***either*** of the following approaches:

* In an app settings file (for example, `wwwroot/appsettings.Development.json`):

  ```json
  "Logging": {
    "LogLevel": {
      "Microsoft.AspNetCore.Components.WebAssembly.Authentication": "Debug"
    }
  }
  ```

  For more information on how to configure a client-side app to read app settings files, see <xref:blazor/fundamentals/configuration#logging-configuration>.

* Using a log filter, the following example:

  * Activates logging for the `Debug` build configuration using a [C# preprocessor directive](/dotnet/csharp/language-reference/preprocessor-directives).
  * Logs Blazor authentication messages at the <xref:Microsoft.Extensions.Logging.LogLevel.Debug> log level.

  ```csharp
  #if DEBUG
      builder.Logging.AddFilter(
          "Microsoft.AspNetCore.Components.WebAssembly.Authentication", 
          LogLevel.Debug);
  #endif
  ```

> [!NOTE]
> Razor components rendered on the client only log to the client-side [browser developer tools](https://developer.mozilla.org/docs/Glossary/Developer_Tools) console.

:::moniker-end

## Additional resources

* <xref:fundamentals/logging/index>
* [`Loglevel` Enum (API documentation)](xref:Microsoft.Extensions.Logging.LogLevel)
* [Implement a custom logging provider in .NET](/dotnet/core/extensions/custom-logging-provider)
* Browser developer tools documentation:
  * [Chrome DevTools](https://developer.chrome.com/docs/devtools/)
  * [Firefox Developer Tools](https://developer.mozilla.org/docs/Tools)
  * [Microsoft Edge Developer Tools overview](/microsoft-edge/devtools-guide-chromium/)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
