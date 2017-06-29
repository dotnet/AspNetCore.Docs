# Logging changes in ASP.NET Core 2.0

ASP.NET Core 2.0 changes to the way that you configure logging in your application.

## Configuring Logging

The main change from version 1.x for a typical app is that instead of configuring logging in the  `Configure` method (in *Startup.cs*), you use a new method and builder API when configuring services:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug();
```
Logging is now part of [dependency injection](xref:fundamentals/dependency-injection). Methods have beed added to `WebHostBuilder` to allow configuration in *Program.cs* rather than *Startup.cs*:

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

An advantage shown in the preceding example is using the `HostingContext` provided to the `ConfigureLogging` extension method. This allows access to the configuration that is also registered in *Program.cs*. This leaves *Startup.cs* focused on configuring services and the middleware pipeline with less concerns (namely logging and configuration).

### WebHost

`WebHost` is new for ASP.NET Core 2.0 and is used in the ASP.NET Core 2.0 templates. The default `WebHost` will configure logging in the same way as the previous sample.  If you only need `Console` and `Debug` logging and  use a `Logging` configuration section to control things like `MinimumLogLevel` or filters, then you don't need to add any extra code. If you want to add additional `ILoggerProviders` then you call `ConfigureLogging`, adding the providers that you need:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureLoggin(logging => logging.AddEventLog())
    .Build();
```
The sample above enables all the default loggers (Console and Debug) the EventLog provider (added explicitly).

## Configuring Filtering

ASP.NET Core 1.x filtering is provider specific. ASP.NET Core 2.0 changes the default `ILoggerFactory` to support filtering:

* You can filter log messages to all providers.
* You can bind filtering to `IConfiguration`. Binding filtering to `IConfiguration`   allows you to control filtering from the configuration source you specify. See [Configuration](xref:fundamentals/configuration) for more information.

When configuring logging you can explicitly register filters in code:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug()
                   // Rule for all providers.
                .AddFilter("System", LogLevel.Information) 
                   // Rule only for debug provider.
                .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace) 
                 // Adds rules from IConfiguration, overriding default rules 
                 // added above
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
        if(provider == "Micrososft.Extensions.Logging.EventSource" && category == "TodoApi.Controllers.TodoController")
        {
            return false;
        }
        return true;
    });
})
```
The preceding function:

*  Is executed for all log messages.
*  Blocks log messages to the `EventSource` provider if the category is `TodoApi.Controllers.TodoController`. All other log messages are passed through the filter function.

## Advanced Topics

<!-- Need something here and possibly make the following ### -->

## Replacing the LoggerFactory

Getting providers from DI and using `LoggerFilterOptions` to filter messages are both features of the default `LoggerFactory` provided by the ASP.NET Core 2.0 framework. If you want to replace the factory you can do so by replacing the `ILoggerFactory` service in DI:

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

If you are writing your own `ILoggerProvider` then you can take advantage of the fact that they are now in DI by accepting any registered services in your constructor.
