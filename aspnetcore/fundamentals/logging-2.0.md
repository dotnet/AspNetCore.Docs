# Introduction to Logging changes in ASP.NET Core 2.0

In ASP.NET Core 2.0 we made some changes to the way that you configure logging in your application.

## Configuring Logging

The main change for a typical application is that instead of configuring logging in your `Startup.cs` Configure method like you would in version 1.x, you will now use a new method and builder API when configuring services like this:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug();
```

In addition to now being part of the DI system, we have added methods on `WebHostBuilder` in your `Program.cs` to allow you to configure logging there instead of in your `Startup.cs`:

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

A big advantage shown in this example is using the `HostingContext` provided to the `ConfigureLogging` extension method. This allows easy access to the configuration that is also registered in `Program.cs`. This leaves your `Startup.cs` more focused on configuring services and your middleware pipeline with less other concerns (namely logging and configuration).

### WebHost
`WebHost` is new for ASP.NET Core 2.0 and is used in the ASP.NET Core 2.0 templates. The default `WebHost` will configure logging in the same way as the previous sample.  If you only need `Console` and `Debug` logging and  use a `Logging` configuration section to control things like MinimumLogLevel or filters, then you don't need to add any extra code. If you want to add additional `ILoggerProviders` then you call `ConfigureLogging`, adding the providers that you need:

```csharp
WebHost.CreateDefaultBuilder(args)
    .UseStartup<Startup>()
    .ConfigureLoggin(logging => logging.AddEventLog())
    .Build();
```
In the previous sample you have all the default loggers (Console and Debug) as well as the EventLog provider that you are adding.

## Configuring Filtering

In ASP.NET Core 1.x there are ways to do filtering, but they are either not very intuitive or are limited to specific log providers. In 2.0 we have changed the default `ILoggerFactory` to support filtering, meaning that you can filter log messages to all providers, and allow binding the filtering to `IConfiguration` allowing you to control it from whatever configuration sources you choose, such as a file.

To begin with, when configuring logging you can explicitly register filters in code:

```csharp
services.AddLogging(builder => builder
                .AddConsole()
                .AddDebug()
                .AddFilter("System", LogLevel.Information) // Rule for all providers
                .AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace) // Rule only for debug provider
                .AddConfiguration(configuration.GetSection("Logging"))); // Would add rules from IConfiguration, overriding default rules added above
```

For the `AddConfiguration` line in the above example you could have a configuration file like the following:

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

The data you have available when filtering log messages is:
- Provider type/alias
- Category name
- Minimum level
- Filter function

You can apply a filter function to a specific provider or category as well as globally for all providers and categories. When registering a global filter function you can get access to the provider, category, and LogLevel to decide whether or not a messages should be logged. For example:

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
The above function will be executed for all log messages, and will not send any log messages to the EventSource provider if the category is TodoApi.Controllers.TodoController. All other log messages will be allowed through the filter function.

## Advanced Topics

## Replacing the LoggerFactory

Getting providers from DI and using LoggerFilterOptions to filter messages are both features of the default LoggerFactory provided by Microsoft. If you want to replace the factory you can do so by replacing the `ILoggerFactory` service in DI:

```csharp
ConfigureServices(collection => collection.AddSingleton<ILoggerFactory>(myFactory))
```

## Filtering Algorithm

When creating an `ILogger` to write logs to, we select a single rule per provider to apply to this logger. All messages written to the `ILogger` are filtered based on these rules. We select the most specific rule possible for each provider and category pair from the available filter.

The following algorithm is used to select a rule for a given provider and category:

1. Select rules that match provider or its alias, if none found - select all rules with an empty provider.
2. From result of 1 select rules with longest matching category prefix, if none found - select all rules without category specified.
3. If multiple rules got selected take **last** one
4. If no rules selected use MinimumLevel for a level

NOTE: Filter function is only invoked when message level matches rule minimum level

## Provider Authoring

If you are writing your own `ILoggerProvider` then you can take advantage of the fact that they are now in DI by accepting any registered services in your constructor.
