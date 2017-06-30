---
title: Logging in ASP.NET Core 2.0
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 07/03/2017
ms.topic: article
ms.assetid: 
ms.prod: aspnet-core
uid: aspnetcore/fundamentals/logging2
---

# Logging in ASP.NET Core 2.0

By [Pavel Krymets](https://github.com/pakrym) and [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core 2.0 configures logging in the *Program.cs* file, while ASP.NET Core 1.x uses the *Startup.cs* file.

## Configuring Logging

The main change from version 1.x for a typical app is that instead of configuring logging in the `Configure` method, you use a new method and builder API when configuring services:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug();
```
Logging is now part of [dependency injection](xref:fundamentals/dependency-injection). Methods have been added to `WebHostBuilder` to allow configuration in *Program.cs* rather than *Startup.cs*:

<!-- Provide me with the working Program.cs and Startup.cs and I'll add them to GitHub and import the snippet. I'd prefer to import the entire Program.cs file
-->
```csharp
var builder = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                });
```

The preceding example uses `HostingContext` (provided by the `ConfigureLogging` extension method). Using `HostingContext` to configure logging in *Program.cs* has the following advantages:

* You have access to the configuration. Configuration is registered in *Program.cs*.
* *Startup.cs* no longer handles logging and configuation. *Startup.cs* is focused on configuring services and the middleware pipeline.

### WebHost

<!-- what does opinionated  mean?  ESL and machine translation won't be able to process that -->

`WebHost` is new for ASP.NET Core 2.0 and is used in the ASP.NET Core 2.0 templates. The default `WebHost` will configure logging in the same way as the previous sample. You don't need to add any extra code if your app:

* Needs only `Console` and `Debug` logging - And
* Uses a `Logging` configuration section to control things like `MinimumLogLevel` or filters.

To add additional `ILoggerProviders`, call `ConfigureLogging`, adding the providers that you need:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureLogging(logging => logging.AddEventLog())
    .Build();
```
The preceeding sample enables the default loggers (Console and Debug) and the EventLog provider (added explicitly).

## Configuring Filtering

ASP.NET Core 1.x filtering is provider specific. ASP.NET Core 2.0 changes the default `ILoggerFactory` to support filtering:

* You can filter log messages to all providers.
* You can bind filtering to `IConfiguration`. Binding filtering to `IConfiguration` allows you to control filtering from the configuration source you specify. See [Configuration](xref:fundamentals/configuration) for more information.

When configuring logging you can explicitly register filters in code:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug()
                   // Rule for all providers.
                .AddFilter("System", LogLevel.Information) 
                   // Rule only for debug provider.
                .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace) 
                 // Adds rules from IConfiguration, possibly overriding  
                 // default rules added above
                .AddConfiguration(configuration.GetSection("Logging"))); 
```

The following sample shows a configuration file for the `AddConfiguration` line in the preceding example:

```json
{
  "Logging": {
    "IncludeScopes": false,
    "Console": {
      "LogLevel": {
        "Default": "Warning"
      }
    }
  }
}
```

The following list shows the data available when filtering log messages:
- Provider type/alias
- Category name
- Minimum level
- Filter function

You can apply a filter function to a single provider or category.  You can apply a filter function globally for all providers and categories. When registering a global filter function you can access the provider, category, and LogLevel, to decide whether or not a message should be logged. For example:

```
ConfigureLogging(logBuilder =>
{
    logBuilder.AddFilter((provider, category, logLevel) =>
    {
        if(provider == "Micrososft.Extensions.Logging.EventSource" && 
           category == "TodoApi.Controllers.TodoController")
        {
            return false;
        }
        return true;
    });
})
```
The preceding function:

* Is executed for all log messages.
* Blocks log messages to the `EventSource` provider if the category is `TodoApi.Controllers.TodoController`. All other log messages are passed through the filter function.

## Replacing the LoggerFactory

The default `LoggerFactory` for ASP.NET Core 2.0 provides the following:

* Accesses providers from dependency-injection.
* `LoggerFilterOptions` to filter messages.

<!- Can you say something to tie the above with the replacing `ILoggerFactory`  below?
Maybe something like, if you implement your own logger factory, you may want to make it DI friendly and provider a filter mechanism.  -->
You can replace the default `LoggerFactory` by replacing the `ILoggerFactory` service in DI:

```csharp
ConfigureServices(collection => collection.AddSingleton<ILoggerFactory>(myFactory))
```

## Filtering Algorithm

When creating an `ILogger` to write logs, the framework selects a single rule per provider to apply to the `ILogger`. All messages written to the `ILogger` are filtered based on these rules. The most specific rule for each provider and category pair from the available filter is selected. 

The following algorithm is used to select a rule for a given provider and category:

1. Select rules that match provider or its alias, if none found - select all rules with an empty provider.
1. From result of 1 select rules with longest matching category prefix, if none found - select all rules without category specified.
1. If multiple rules are selected take the **last** rule.
1. If no rules selected use `MinimumLevel` for a level.

NOTE: Filter function is only invoked when message level matches rule minimum level.

## Provider Authoring

If you are writing your own `ILoggerProvider` you can take advantage that the loggers are  available by DI. You can access registered services in your constructor.
