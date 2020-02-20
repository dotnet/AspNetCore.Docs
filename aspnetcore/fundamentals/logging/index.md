---
title: Logging in .NET Core and ASP.NET Core
author: rick-anderson
description: Learn how to use the logging framework provided by the Microsoft.Extensions.Logging NuGet package.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/05/2020
uid: fundamentals/logging/index
---
# Logging in .NET Core and ASP.NET Core

By [Tom Dykstra](https://github.com/tdykstra) and [Steve Smith](https://ardalis.com/)

.NET Core supports a logging API that works with a variety of built-in and third-party logging providers. This article shows how to use the logging API with built-in providers.

::: moniker range=">= aspnetcore-3.0"

Most of the code examples shown in this article are from ASP.NET Core apps. The logging-specific parts of these code snippets apply to any .NET Core app that uses the [Generic Host](xref:fundamentals/host/generic-host). For an example of how to use the Generic Host in a non-web console app, see the *Program.cs* file of the [Background Tasks sample app](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/host/hosted-services/samples) (<xref:fundamentals/host/hosted-services>).

Logging code for apps without Generic Host differs in the way [providers are added](#add-providers) and [loggers are created](#create-logs). Non-host code examples are shown in those sections of the article.

::: moniker-end

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/fundamentals/logging/index/samples) ([how to download](xref:index#how-to-download-a-sample))

## Add providers

A logging provider displays or stores logs. For example, the Console provider displays logs on the console, and the Azure Application Insights provider stores them in Azure Application Insights. Logs can be sent to multiple destinations by adding multiple providers.

::: moniker range=">= aspnetcore-3.0"

To add a provider in an app that uses Generic Host, call the provider's `Add{provider name}` extension method in *Program.cs*:

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_AddProvider&highlight=6)]

In a non-host console app, call the provider's `Add{provider name}` extension method while creating a `LoggerFactory`:

[!code-csharp[](index/samples/3.x/LoggingConsoleApp/Program.cs?name=snippet_LoggerFactory&highlight=1,7)]

`LoggerFactory` and `AddConsole` require a `using` statement for `Microsoft.Extensions.Logging`.

The default ASP.NET Core project templates call <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder%2A>, which adds the following logging providers:

* [Console](#console-provider)
* [Debug](#debug-provider)
* [EventSource](#event-source-provider)
* [EventLog](#windows-eventlog-provider) (only when running on Windows)

You can replace the default providers with your own choices. Call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A>, and add the providers you want.

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_AddProvider&highlight=5)]

::: moniker-end

::: moniker range="< aspnetcore-3.0 "

To add a provider, call the provider's `Add{provider name}` extension method in *Program.cs*:

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_ExpandDefault&highlight=18-20)]

The preceding code requires references to `Microsoft.Extensions.Logging` and `Microsoft.Extensions.Configuration`.

The default project template calls <xref:Microsoft.AspNetCore.WebHost.CreateDefaultBuilder%2A>, which adds the following logging providers:

* Console
* Debug
* EventSource (starting in ASP.NET Core 2.2)

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_TemplateCode&highlight=7)]

If you use `CreateDefaultBuilder`, you can replace the default providers with your own choices. Call <xref:Microsoft.Extensions.Logging.LoggingBuilderExtensions.ClearProviders%2A>, and add the providers you want.

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_LogFromMain&highlight=18-22)]

::: moniker-end

Learn more about [built-in logging providers](#built-in-logging-providers) and [third-party logging providers](#third-party-logging-providers) later in the article.

## Create logs

To create logs, use an <xref:Microsoft.Extensions.Logging.ILogger%601> object. In a web app or hosted service, get an `ILogger` from dependency injection (DI). In non-host console apps, use the `LoggerFactory` to create an `ILogger`.

The following ASP.NET Core example creates a logger with `TodoApiSample.Pages.AboutModel` as the category. The log *category* is a string that is associated with each log. The `ILogger<T>` instance provided by DI creates logs that have the fully qualified name of type `T` as the category. 

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Pages/About.cshtml.cs?name=snippet_LoggerDI&highlight=3,5,7)]

The following non-host console app example creates a logger with `LoggingConsoleApp.Program` as the category.

[!code-csharp[](index/samples/3.x/LoggingConsoleApp/Program.cs?name=snippet_LoggerFactory&highlight=10)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Pages/About.cshtml.cs?name=snippet_LoggerDI&highlight=3,5,7)]

::: moniker-end

In the following ASP.NET Core and console app examples, the logger is used to create logs with `Information` as the level. The Log *level* indicates the severity of the logged event. 

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Pages/About.cshtml.cs?name=snippet_CallLogMethods&highlight=4)]

[!code-csharp[](index/samples/3.x/LoggingConsoleApp/Program.cs?name=snippet_LoggerFactory&highlight=11)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Pages/About.cshtml.cs?name=snippet_CallLogMethods&highlight=4)]

::: moniker-end

[Levels](#log-level) and [categories](#log-category) are explained in more detail later in this article. 

::: moniker range=">= aspnetcore-3.0"

### Create logs in the Program class

To write logs in the `Program` class of an ASP.NET Core app, get an `ILogger` instance from DI after building the host:

[!code-csharp[](index/samples_snapshot/3.x/TodoApiSample/Program.cs?highlight=9,10)]

Logging during host construction isn't directly supported. However, a separate logger can be used. In the following example, a [Serilog](https://serilog.net/) logger is used to log in `CreateHostBuilder`. `AddSerilog` uses the static configuration specified in `Log.Logger`:

```csharp
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
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
    }
}
```

### Create logs in the Startup class

To write logs in the `Startup.Configure` method of an ASP.NET Core app, include an `ILogger` parameter in the method signature:

[!code-csharp[](index/samples/3.x/TodoApiSample/Startup.cs?name=snippet_Configure&highlight=1,5)]

Writing logs before completion of the DI container setup in the `Startup.ConfigureServices` method is not supported:

* Logger injection into the `Startup` constructor is not supported.
* Logger injection into the `Startup.ConfigureServices` method signature is not supported

The reason for this restriction is that logging depends on DI and on configuration, which in turns depends on DI. The DI container isn't set up until `ConfigureServices` finishes.

Constructor injection of a logger into `Startup` works in earlier versions of ASP.NET Core because a separate DI container is created for the Web Host. For information about why only one container is created for the Generic Host, see the [breaking change announcement](https://github.com/aspnet/Announcements/issues/353).

If you need to configure a service that depends on `ILogger<T>`, you can still do that by using constructor injection or by providing a factory method. The factory method approach is recommended only if there is no other option. For example, suppose you need to fill a property with a service from DI:

[!code-csharp[](index/samples/3.x/TodoApiSample/Startup.cs?name=snippet_ConfigureServices&highlight=6-10)]

The preceding highlighted code is a `Func` that runs the first time the DI container needs to construct an instance of `MyService`. You can access any of the registered services in this way.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

### Create logs in Startup

To write logs in the `Startup` class, include an `ILogger` parameter in the constructor signature:

[!code-csharp[](index/samples/2.x/TodoApiSample/Startup.cs?name=snippet_Startup&highlight=3,5,8,20,27)]

### Create logs in the Program class

To write logs in the `Program` class, get an `ILogger` instance from DI:

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_LogFromMain&highlight=9,10)]

Logging during host construction isn't directly supported. However, a separate logger can be used. In the following example, a [Serilog](https://serilog.net/) logger is used to log in `CreateWebHostBuilder`. `AddSerilog` uses the static configuration specified in `Log.Logger`:

```csharp
using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
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
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddMvc();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddConfiguration(builtConfig);
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddSerilog();
                })
                .UseStartup<Startup>();
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
    }
}
```

::: moniker-end

### No asynchronous logger methods

Logging should be so fast that it isn't worth the performance cost of asynchronous code. If your logging data store is slow, don't write to it directly. Consider writing the log messages to a fast store initially, then move them to the slow store later. For example, if you're logging to SQL Server, you don't want to do that directly in a `Log` method, since the `Log` methods are synchronous. Instead, synchronously add log messages to an in-memory queue and have a background worker pull the messages out of the queue to do the asynchronous work of pushing data to SQL Server. For more information, see [this](https://github.com/dotnet/AspNetCore.Docs/issues/11801) GitHub issue.

## Configuration

Logging provider configuration is provided by one or more configuration providers:

* File formats (INI, JSON, and XML).
* Command-line arguments.
* Environment variables.
* In-memory .NET objects.
* The unencrypted [Secret Manager](xref:security/app-secrets) storage.
* An encrypted user store, such as [Azure Key Vault](xref:security/key-vault-configuration).
* Custom providers (installed or created).

For example, logging configuration is commonly provided by the `Logging` section of app settings files. The following example shows the contents of a typical *appsettings.Development.json* file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    },
    "Console":
    {
      "IncludeScopes": true
    }
  }
}
```

The `Logging` property can have `LogLevel` and log provider properties (Console is shown).

The `LogLevel` property under `Logging` specifies the minimum [level](#log-level) to log for selected categories. In the example, `System` and `Microsoft` categories log at `Information` level, and all others log at `Debug` level.

Other properties under `Logging` specify logging providers. The example is for the Console provider. If a provider supports [log scopes](#log-scopes), `IncludeScopes` indicates whether they're enabled. A provider property (such as `Console` in the example) may also specify a `LogLevel` property. `LogLevel` under a provider specifies levels to log for that provider.

If levels are specified in `Logging.{providername}.LogLevel`, they override anything set in `Logging.LogLevel`.

The Logging API doesn't include a scenario to change log levels while an app is running. However, some configuration providers are capable of reloading configuration, which takes immediate effect on logging configuration. For example, the [File Configuration Provider](xref:fundamentals/configuration/index#file-configuration-provider), which is added by `CreateDefaultBuilder` to read settings files, reloads logging configuration by default. If configuration is changed in code while an app is running, the app can call [IConfigurationRoot.Reload](xref:Microsoft.Extensions.Configuration.IConfigurationRoot.Reload*) to update the app's logging configuration.

For information on implementing configuration providers, see <xref:fundamentals/configuration/index>.

## Sample logging output

With the sample code shown in the preceding section, logs appear in the console when the app is run from the command line. Here's an example of console output:

::: moniker range=">= aspnetcore-3.0"

```console
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/1.1 GET http://localhost:5000/api/todo/0
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 84.26180000000001ms 307
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 GET https://localhost:5001/api/todo/0
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'TodoApiSample.Controllers.TodoController.GetById (TodoApiSample)'
info: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[3]
      Route matched with {action = "GetById", controller = "Todo", page = ""}. Executing controller action with signature Microsoft.AspNetCore.Mvc.IActionResult GetById(System.String) on controller TodoApiSample.Controllers.TodoController (TodoApiSample).
info: TodoApiSample.Controllers.TodoController[1002]
      Getting item 0
warn: TodoApiSample.Controllers.TodoController[4000]
      GetById(0) NOT FOUND
info: Microsoft.AspNetCore.Mvc.StatusCodeResult[1]
      Executing HttpStatusCodeResult, setting HTTP status code 404
```

::: moniker-end

::: moniker range="< aspnetcore-3.0"

```console
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[1]
      Request starting HTTP/1.1 GET http://localhost:5000/api/todo/0
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[1]
      Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (0) - ModelState is Valid
info: TodoApi.Controllers.TodoController[1002]
      Getting item 0
warn: TodoApi.Controllers.TodoController[4000]
      GetById(0) NOT FOUND
info: Microsoft.AspNetCore.Mvc.StatusCodeResult[1]
      Executing HttpStatusCodeResult, setting HTTP status code 404
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[2]
      Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 42.9286ms
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[2]
      Request finished in 148.889ms 404
```

::: moniker-end

The preceding logs were generated by making an HTTP Get request to the sample app at `http://localhost:5000/api/todo/0`.

Here's an example of the same logs as they appear in the Debug window when you run the sample app in Visual Studio:

::: moniker range=">= aspnetcore-3.0"

```console
Microsoft.AspNetCore.Hosting.Diagnostics: Information: Request starting HTTP/2.0 GET https://localhost:44328/api/todo/0  
Microsoft.AspNetCore.Routing.EndpointMiddleware: Information: Executing endpoint 'TodoApiSample.Controllers.TodoController.GetById (TodoApiSample)'
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker: Information: Route matched with {action = "GetById", controller = "Todo", page = ""}. Executing controller action with signature Microsoft.AspNetCore.Mvc.IActionResult GetById(System.String) on controller TodoApiSample.Controllers.TodoController (TodoApiSample).
TodoApiSample.Controllers.TodoController: Information: Getting item 0
TodoApiSample.Controllers.TodoController: Warning: GetById(0) NOT FOUND
Microsoft.AspNetCore.Mvc.StatusCodeResult: Information: Executing HttpStatusCodeResult, setting HTTP status code 404
Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker: Information: Executed action TodoApiSample.Controllers.TodoController.GetById (TodoApiSample) in 34.167ms
Microsoft.AspNetCore.Routing.EndpointMiddleware: Information: Executed endpoint 'TodoApiSample.Controllers.TodoController.GetById (TodoApiSample)'
Microsoft.AspNetCore.Hosting.Diagnostics: Information: Request finished in 98.41300000000001ms 404
```

The logs that are created by the `ILogger` calls shown in the preceding section begin with "TodoApiSample". The logs that begin with "Microsoft" categories are from ASP.NET Core framework code. ASP.NET Core and application code are using the same logging API and providers.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

```console
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request starting HTTP/1.1 GET http://localhost:53104/api/todo/0  
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (0) - ModelState is Valid
TodoApi.Controllers.TodoController:Information: Getting item 0
TodoApi.Controllers.TodoController:Warning: GetById(0) NOT FOUND
Microsoft.AspNetCore.Mvc.StatusCodeResult:Information: Executing HttpStatusCodeResult, setting HTTP status code 404
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 152.5657ms
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request finished in 316.3195ms 404
```

The logs that are created by the `ILogger` calls shown in the preceding section begin with "TodoApi". The logs that begin with "Microsoft" categories are from ASP.NET Core framework code. ASP.NET Core and application code are using the same logging API and providers.

::: moniker-end

The remainder of this article explains some details and options for logging.

## NuGet packages

The `ILogger` and `ILoggerFactory` interfaces are in [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/), and default implementations for them are in [Microsoft.Extensions.Logging](https://www.nuget.org/packages/microsoft.extensions.logging/).

## Log category

When an `ILogger` object is created, a *category* is specified for it. That category is included with each log message created by that instance of `ILogger`. The category may be any string, but the convention is to use the class name, such as "TodoApi.Controllers.TodoController".

Use `ILogger<T>` to get an `ILogger` instance that uses the fully qualified type name of `T` as the category:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_LoggerDI&highlight=7)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_LoggerDI&highlight=7)]

::: moniker-end

To explicitly specify the category, call `ILoggerFactory.CreateLogger`:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CreateLogger&highlight=7,10)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CreateLogger&highlight=7,10)]

::: moniker-end

`ILogger<T>` is equivalent to calling `CreateLogger` with the fully qualified type name of `T`.

## Log level

Every log specifies a <xref:Microsoft.Extensions.Logging.LogLevel> value. The log level indicates the severity or importance. For example, you might write an `Information` log when a method ends normally and a `Warning` log when a method returns a *404 Not Found* status code.

The following code creates `Information` and `Warning` logs:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

::: moniker-end

In the preceding code, the first parameter is the [Log event ID](#log-event-id). The second parameter is a message template with placeholders for argument values provided by the remaining method parameters. The method parameters are explained in the [message template section](#log-message-template) later in this article.

Log methods that include the level in the method name (for example, `LogInformation` and `LogWarning`) are [extension methods for ILogger](xref:Microsoft.Extensions.Logging.LoggerExtensions). These methods call a `Log` method that takes a `LogLevel` parameter. You can call the `Log` method directly rather than one of these extension methods, but the syntax is relatively complicated. For more information, see <xref:Microsoft.Extensions.Logging.ILogger> and the [logger extensions source code](https://github.com/dotnet/extensions/blob/release/2.2/src/Logging/Logging.Abstractions/src/LoggerExtensions.cs).

ASP.NET Core defines the following log levels, ordered here from lowest to highest severity.

* Trace = 0

  For information that's typically valuable only for debugging. These messages may contain sensitive application data and so shouldn't be enabled in a production environment. *Disabled by default.*

* Debug = 1

  For information that may be useful in development and debugging. Example: `Entering method Configure with flag set to true.` Enable `Debug` level logs in production only when troubleshooting, due to the high volume of logs.

* Information = 2

  For tracking the general flow of the app. These logs typically have some long-term value. Example: `Request received for path /api/todo`

* Warning = 3

  For abnormal or unexpected events in the app flow. These may include errors or other conditions that don't cause the app to stop but might need to be investigated. Handled exceptions are a common place to use the `Warning` log level. Example: `FileNotFoundException for file quotes.txt.`

* Error = 4

  For errors and exceptions that cannot be handled. These messages indicate a failure in the current activity or operation (such as the current HTTP request), not an app-wide failure. Example log message: `Cannot insert record due to duplicate key violation.`

* Critical = 5

  For failures that require immediate attention. Examples: data loss scenarios, out of disk space.

Use the log level to control how much log output is written to a particular storage medium or display window. For example:

* In production:
  * Logging at the `Trace` through `Information` levels produces a high-volume of detailed log messages. To control costs and not exceed data storage limits, log `Trace` through `Information` level messages to a high-volume, low-cost data store.
  * Logging at `Warning` through `Critical` levels typically produces fewer, smaller log messages. Therefore, costs and storage limits usually aren't a concern, which results in greater flexibility of data store choice.
* During development:
  * Log `Warning` through `Critical` messages to the console.
  * Add `Trace` through `Information` messages when troubleshooting.

The [Log filtering](#log-filtering) section later in this article explains how to control which log levels a provider handles.

ASP.NET Core writes logs for framework events. The log examples earlier in this article excluded logs below `Information` level, so no `Debug` or `Trace` level logs were created. Here's an example of console logs produced by running the sample app configured to show `Debug` logs:

::: moniker range=">= aspnetcore-3.0"

```console
info: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[3]
      Route matched with {action = "GetById", controller = "Todo", page = ""}. Executing controller action with signature Microsoft.AspNetCore.Mvc.IActionResult GetById(System.String) on controller TodoApiSample.Controllers.TodoController (TodoApiSample).
dbug: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[1]
      Execution plan of authorization filters (in the following order): None
dbug: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[1]
      Execution plan of resource filters (in the following order): Microsoft.AspNetCore.Mvc.ViewFeatures.Filters.SaveTempDataFilter
dbug: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[1]
      Execution plan of action filters (in the following order): Microsoft.AspNetCore.Mvc.Filters.ControllerActionFilter (Order: -2147483648), Microsoft.AspNetCore.Mvc.ModelBinding.UnsupportedContentTypeFilter (Order: -3000)
dbug: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[1]
      Execution plan of exception filters (in the following order): None
dbug: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[1]
      Execution plan of result filters (in the following order): Microsoft.AspNetCore.Mvc.ViewFeatures.Filters.SaveTempDataFilter
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder[22]
      Attempting to bind parameter 'id' of type 'System.String' ...
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder[44]
      Attempting to bind parameter 'id' of type 'System.String' using the name 'id' in request data ...
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.Binders.SimpleTypeModelBinder[45]
      Done attempting to bind parameter 'id' of type 'System.String'.
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder[23]
      Done attempting to bind parameter 'id' of type 'System.String'.
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder[26]
      Attempting to validate the bound parameter 'id' of type 'System.String' ...
dbug: Microsoft.AspNetCore.Mvc.ModelBinding.ParameterBinder[27]
      Done attempting to validate the bound parameter 'id' of type 'System.String'.
info: TodoApiSample.Controllers.TodoController[1002]
      Getting item 0
warn: TodoApiSample.Controllers.TodoController[4000]
      GetById(0) NOT FOUND
info: Microsoft.AspNetCore.Mvc.StatusCodeResult[1]
      Executing HttpStatusCodeResult, setting HTTP status code 404
info: Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker[2]
      Executed action TodoApiSample.Controllers.TodoController.GetById (TodoApiSample) in 32.690400000000004ms
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'TodoApiSample.Controllers.TodoController.GetById (TodoApiSample)'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 176.9103ms 404
```

::: moniker-end

::: moniker range="< aspnetcore-3.0"

```console
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[1]
      Request starting HTTP/1.1 GET http://localhost:62555/api/todo/0
dbug: Microsoft.AspNetCore.Routing.Tree.TreeRouter[1]
      Request successfully matched the route with name 'GetTodo' and template 'api/Todo/{id}'.
dbug: Microsoft.AspNetCore.Mvc.Internal.ActionSelector[2]
      Action 'TodoApi.Controllers.TodoController.Update (TodoApi)' with id '089d59b6-92ec-472d-b552-cc613dfd625d' did not match the constraint 'Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint'
dbug: Microsoft.AspNetCore.Mvc.Internal.ActionSelector[2]
      Action 'TodoApi.Controllers.TodoController.Delete (TodoApi)' with id 'f3476abe-4bd9-4ad3-9261-3ead09607366' did not match the constraint 'Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint'
dbug: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[1]
      Executing action TodoApi.Controllers.TodoController.GetById (TodoApi)
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[1]
      Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (0) - ModelState is Valid
info: TodoApi.Controllers.TodoController[1002]
      Getting item 0
warn: TodoApi.Controllers.TodoController[4000]
      GetById(0) NOT FOUND
dbug: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[2]
      Executed action method TodoApi.Controllers.TodoController.GetById (TodoApi), returned result Microsoft.AspNetCore.Mvc.NotFoundResult.
info: Microsoft.AspNetCore.Mvc.StatusCodeResult[1]
      Executing HttpStatusCodeResult, setting HTTP status code 404
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[2]
      Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 0.8788ms
dbug: Microsoft.AspNetCore.Server.Kestrel[9]
      Connection id "0HL6L7NEFF2QD" completed keep alive response.
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[2]
      Request finished in 2.7286ms 404
```

::: moniker-end

## Log event ID

Each log can specify an *event ID*. The sample app does this by using a locally defined `LoggingEvents` class:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

[!code-csharp[](index/samples/3.x/TodoApiSample/Core/LoggingEvents.cs?name=snippet_LoggingEvents)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

[!code-csharp[](index/samples/2.x/TodoApiSample/Core/LoggingEvents.cs?name=snippet_LoggingEvents)]

::: moniker-end

An event ID associates a set of events. For example, all logs related to displaying a list of items on a page might be 1001.

The logging provider may store the event ID in an ID field, in the logging message, or not at all. The Debug provider doesn't show event IDs. The console provider shows event IDs in brackets after the category:

```console
info: TodoApi.Controllers.TodoController[1002]
      Getting item invalidid
warn: TodoApi.Controllers.TodoController[4000]
      GetById(invalidid) NOT FOUND
```

## Log message template

Each log specifies a message template. The message template can contain placeholders for which arguments are provided. Use names for the placeholders, not numbers.

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

::: moniker-end

The order of placeholders, not their names, determines which parameters are used to provide their values. In the following code, notice that the parameter names are out of sequence in the message template:

```csharp
string p1 = "parm1";
string p2 = "parm2";
_logger.LogInformation("Parameter values: {p2}, {p1}", p1, p2);
```

This code creates a log message with the parameter values in sequence:

```text
Parameter values: parm1, parm2
```

The logging framework works this way so that logging providers can implement [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging). The arguments themselves are passed to the logging system, not just the formatted message template. This information enables logging providers to store the parameter values as fields. For example, suppose logger method calls look like this:

```csharp
_logger.LogInformation("Getting item {Id} at {RequestTime}", id, DateTime.Now);
```

If you're sending the logs to Azure Table Storage, each Azure Table entity can have `ID` and `RequestTime` properties, which simplifies queries on log data. A query can find all logs within a particular `RequestTime` range without parsing the time out of the text message.

## Logging exceptions

The logger methods have overloads that let you pass in an exception, as in the following example:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_LogException&highlight=3)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_LogException&highlight=3)]

::: moniker-end

Different providers handle the exception information in different ways. Here's an example of Debug provider output from the code shown above.

```text
TodoApiSample.Controllers.TodoController: Warning: GetById(55) NOT FOUND

System.Exception: Item not found exception.
   at TodoApiSample.Controllers.TodoController.GetById(String id) in C:\TodoApiSample\Controllers\TodoController.cs:line 226
```

## Log filtering

You can specify a minimum log level for a specific provider and category or for all providers or all categories. Any logs below the minimum level aren't passed to that provider, so they don't get displayed or stored.

To suppress all logs, specify `LogLevel.None` as the minimum log level. The integer value of `LogLevel.None` is 6, which is higher than `LogLevel.Critical` (5).

### Create filter rules in configuration

The project template code calls `CreateDefaultBuilder` to set up logging for the Console, Debug, and EventSource (ASP.NET Core 2.2 or later) providers. The `CreateDefaultBuilder` method sets up logging to look for configuration in a `Logging` section, as explained [earlier in this article](#configuration).

The configuration data specifies minimum log levels by provider and category, as in the following example:

::: moniker range=">= aspnetcore-3.0"

[!code-json[](index/samples/3.x/TodoApiSample/appsettings.json)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-json[](index/samples/2.x/TodoApiSample/appsettings.json)]

::: moniker-end

This JSON creates six filter rules: one for the Debug provider, four for the Console provider, and one for all providers. A single rule is chosen for each provider when an `ILogger` object is created.

### Filter rules in code

The following example shows how to register filter rules in code:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_FilterInCode&highlight=2-3)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_FilterInCode&highlight=4-5)]

::: moniker-end

The second `AddFilter` specifies the Debug provider by using its type name. The first `AddFilter` applies to all providers because it doesn't specify a provider type.

### How filtering rules are applied

The configuration data and the `AddFilter` code shown in the preceding examples create the rules shown in the following table. The first six come from the configuration example and the last two come from the code example.

| Number | Provider      | Categories that begin with ...          | Minimum log level |
| :----: | ------------- | --------------------------------------- | ----------------- |
| 1      | Debug         | All categories                          | Information       |
| 2      | Console       | Microsoft.AspNetCore.Mvc.Razor.Internal | Warning           |
| 3      | Console       | Microsoft.AspNetCore.Mvc.Razor.Razor    | Debug             |
| 4      | Console       | Microsoft.AspNetCore.Mvc.Razor          | Error             |
| 5      | Console       | All categories                          | Information       |
| 6      | All providers | All categories                          | Debug             |
| 7      | All providers | System                                  | Debug             |
| 8      | Debug         | Microsoft                               | Trace             |

When an `ILogger` object is created, the `ILoggerFactory` object selects a single rule per provider to apply to that logger. All messages written by an `ILogger` instance are filtered based on the selected rules. The most specific rule possible for each provider and category pair is selected from the available rules.

The following algorithm is used for each provider when an `ILogger` is created for a given category:

* Select all rules that match the provider or its alias. If no match is found, select all rules with an empty provider.
* From the result of the preceding step, select rules with longest matching category prefix. If no match is found, select all rules that don't specify a category.
* If multiple rules are selected, take the **last** one.
* If no rules are selected, use `MinimumLevel`.

With the preceding list of rules, suppose you create an `ILogger` object for category "Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine":

* For the Debug provider, rules 1, 6, and 8 apply. Rule 8 is most specific, so that's the one selected.
* For the Console provider, rules 3, 4, 5, and 6 apply. Rule 3 is most specific.

The resulting `ILogger` instance sends logs of `Trace` level and above to the Debug provider. Logs of `Debug` level and above are sent to the Console provider.

### Provider aliases

Each provider defines an *alias* that can be used in configuration in place of the fully qualified type name.  For the built-in providers, use the following aliases:

* Console
* Debug
* EventSource
* EventLog
* TraceSource
* AzureAppServicesFile
* AzureAppServicesBlob
* ApplicationInsights

### Default minimum level

There's a minimum level setting that takes effect only if no rules from configuration or code apply for a given provider and category. The following example shows how to set the minimum level:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_MinLevel&highlight=3)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_MinLevel&highlight=3)]

::: moniker-end

If you don't explicitly set the minimum level, the default value is `Information`, which means that `Trace` and `Debug` logs are ignored.

### Filter functions

A filter function is invoked for all providers and categories that don't have rules assigned to them by configuration or code. Code in the function has access to the provider type, category, and log level. For example:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_FilterFunction&highlight=3-11)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_FilterFunction&highlight=5-13)]

::: moniker-end

## System categories and levels

Here are some categories used by ASP.NET Core and Entity Framework Core, with notes about what logs to expect from them:

| Category                            | Notes |
| ----------------------------------- | ----- |
| Microsoft.AspNetCore                | General ASP.NET Core diagnostics. |
| Microsoft.AspNetCore.DataProtection | Which keys were considered, found, and used. |
| Microsoft.AspNetCore.HostFiltering  | Hosts allowed. |
| Microsoft.AspNetCore.Hosting        | How long HTTP requests took to complete and what time they started. Which hosting startup assemblies were loaded. |
| Microsoft.AspNetCore.Mvc            | MVC and Razor diagnostics. Model binding, filter execution, view compilation, action selection. |
| Microsoft.AspNetCore.Routing        | Route matching information. |
| Microsoft.AspNetCore.Server         | Connection start, stop, and keep alive responses. HTTPS certificate information. |
| Microsoft.AspNetCore.StaticFiles    | Files served. |
| Microsoft.EntityFrameworkCore       | General Entity Framework Core diagnostics. Database activity and configuration, change detection, migrations. |

## Log scopes

 A *scope* can group a set of logical operations. This grouping can be used to attach the same data to each log that's created as part of a set. For example, every log created as part of processing a transaction can include the transaction ID.

A scope is an `IDisposable` type that's returned by the <xref:Microsoft.Extensions.Logging.ILogger.BeginScope*> method and lasts until it's disposed. Use a scope by wrapping logger calls in a `using` block:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_Scopes&highlight=4-5,13)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Controllers/TodoController.cs?name=snippet_Scopes&highlight=4-5,13)]

::: moniker-end

The following code enables scopes for the console provider:

*Program.cs*:

::: moniker range=">= aspnetcore-3.0"

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_Scopes&highlight=6)]

::: moniker-end

::: moniker range="< aspnetcore-3.0"

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_Scopes&highlight=4)]

::: moniker-end

> [!NOTE]
> Configuring the `IncludeScopes` console logger option is required to enable scope-based logging.
>
> For information on configuration, see the [Configuration](#configuration) section.

Each log message includes the scoped information:

```
info: TodoApiSample.Controllers.TodoController[1002]
      => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApiSample.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
      Getting item 0
warn: TodoApiSample.Controllers.TodoController[4000]
      => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApiSample.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
      GetById(0) NOT FOUND
```

## Built-in logging providers

ASP.NET Core ships the following providers:

* [Console](#console-provider)
* [Debug](#debug-provider)
* [EventSource](#event-source-provider)
* [EventLog](#windows-eventlog-provider)
* [TraceSource](#tracesource-provider)
* [AzureAppServicesFile](#azure-app-service-provider)
* [AzureAppServicesBlob](#azure-app-service-provider)
* [ApplicationInsights](#azure-application-insights-trace-logging)

For information on stdout and debug logging with the ASP.NET Core Module, see <xref:test/troubleshoot-azure-iis> and <xref:host-and-deploy/aspnet-core-module#log-creation-and-redirection>.

### Console provider

The [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) provider package sends log output to the console. 

```csharp
logging.AddConsole();
```

To see console logging output, open a command prompt in the project folder and run the following command:

```dotnetcli
dotnet run
```

### Debug provider

The [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) provider package writes log output by using the [System.Diagnostics.Debug](/dotnet/api/system.diagnostics.debug) class (`Debug.WriteLine` method calls).

On Linux, this provider writes logs to */var/log/message*.

```csharp
logging.AddDebug();
```

### Event Source provider

The [Microsoft.Extensions.Logging.EventSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventSource) provider package writes to an Event Source cross-platform with the name `Microsoft-Extensions-Logging`. On Windows, the provider uses [ETW](https://msdn.microsoft.com/library/windows/desktop/bb968803).

```csharp
logging.AddEventSourceLogger();
```

The Event Source provider is added automatically when `CreateDefaultBuilder` is called to build the host.

::: moniker range=">= aspnetcore-3.0"

#### dotnet trace tooling

The [dotnet-trace](/dotnet/core/diagnostics/dotnet-trace) tool is a cross-platform CLI global tool that enables the collection of .NET Core traces of a running process. The tool collects <xref:Microsoft.Extensions.Logging.EventSource> provider data using a <xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource>.

Install the dotnet trace tooling with the following command:

```dotnetcli
dotnet tool install --global dotnet-trace
```

Use the dotnet trace tooling to collect a trace from an app:

1. If the app doesn't build the host with `CreateDefaultBuilder`, add the [Event Source provider](#event-source-provider) to the app's logging configuration.

1. Run the app with the `dotnet run` command.

1. Determine the process identifier (PID) of the .NET Core app:

   * On Windows, use one of the following approaches:
     * Task Manager (Ctrl+Alt+Del)
     * [tasklist command](/windows-server/administration/windows-commands/tasklist)
     * [Get-Process Powershell command](/powershell/module/microsoft.powershell.management/get-process)
   * On Linux, use the [pidof command](https://refspecs.linuxfoundation.org/LSB_5.0.0/LSB-Core-generic/LSB-Core-generic/pidof.html).

   Find the PID for the process that has the same name as the app's assembly.

1. Execute the `dotnet trace` command.

   General command syntax:

   ```dotnetcli
   dotnet trace collect -p {PID} 
       --providers Microsoft-Extensions-Logging:{Keyword}:{Event Level}
           :FilterSpecs=\"
               {Logger Category 1}:{Event Level 1};
               {Logger Category 2}:{Event Level 2};
               ...
               {Logger Category N}:{Event Level N}\"
   ```

   When using a PowerShell command shell, enclose the `--providers` value in single quotes (`'`):

   ```dotnetcli
   dotnet trace collect -p {PID} 
       --providers 'Microsoft-Extensions-Logging:{Keyword}:{Event Level}
           :FilterSpecs=\"
               {Logger Category 1}:{Event Level 1};
               {Logger Category 2}:{Event Level 2};
               ...
               {Logger Category N}:{Event Level N}\"'
   ```

   On non-Windows platforms, add the `-f speedscope` option to change the format of the output trace file to `speedscope`.

   | Keyword | Description |
   | :-----: | ----------- |
   | 1       | Log meta events about the `LoggingEventSource`. Doesn't log events from `ILogger`). |
   | 2       | Turns on the `Message` event when `ILogger.Log()` is called. Provides information in a programmatic (not formatted) way. |
   | 4       | Turns on the `FormatMessage` event when `ILogger.Log()` is called. Provides the formatted string version of the information. |
   | 8       | Turns on the `MessageJson` event when `ILogger.Log()` is called. Provides a JSON representation of the arguments. |

   | Event Level | Description     |
   | :---------: | --------------- |
   | 0           | `LogAlways`     |
   | 1           | `Critical`      |
   | 2           | `Error`         |
   | 3           | `Warning`       |
   | 4           | `Informational` |
   | 5           | `Verbose`       |

   `FilterSpecs` entries for `{Logger Category}` and `{Event Level}` represent additional log filtering conditions. Separate `FilterSpecs` entries with a semicolon (`;`).

   Example using a Windows command shell (**no** single quotes around the `--providers` value):

   ```dotnetcli
   dotnet trace collect -p {PID} --providers Microsoft-Extensions-Logging:4:2:FilterSpecs=\"Microsoft.AspNetCore.Hosting*:4\"
   ```

   The preceding command activates:

   * The Event Source logger to produce formatted strings (`4`) for errors (`2`).
   * `Microsoft.AspNetCore.Hosting` logging at the `Informational` logging level (`4`).

1. Stop the dotnet trace tooling by pressing the Enter key or Ctrl+C.

   The trace is saved with the name *trace.nettrace* in the folder where the `dotnet trace` command is executed.

1. Open the trace with [Perfview](#perfview). Open the *trace.nettrace* file and explore the trace events.

For more information, see:

* [Trace for performance analysis utility (dotnet-trace)](/dotnet/core/diagnostics/dotnet-trace) (.NET Core documentation)
* [Trace for performance analysis utility (dotnet-trace)](https://github.com/dotnet/diagnostics/blob/master/documentation/dotnet-trace-instructions.md) (dotnet/diagnostics GitHub repository documentation)
* [LoggingEventSource Class](xref:Microsoft.Extensions.Logging.EventSource.LoggingEventSource) (.NET API Browser)
* <xref:System.Diagnostics.Tracing.EventLevel>
* [LoggingEventSource reference source (3.0)](https://github.com/dotnet/extensions/blob/release/3.0/src/Logging/Logging.EventSource/src/LoggingEventSource.cs) &ndash; To obtain reference source for a different version, change the branch to `release/{Version}`, where `{Version}` is the version of ASP.NET Core desired.
* [Perfview](#perfview) &ndash; Useful for viewing Event Source traces.

#### Perfview

::: moniker-end

Use the [PerfView utility](https://github.com/Microsoft/perfview) to collect and view logs. There are other tools for viewing ETW logs, but PerfView provides the best experience for working with the ETW events emitted by ASP.NET Core.

To configure PerfView for collecting events logged by this provider, add the string `*Microsoft-Extensions-Logging` to the **Additional Providers** list. (Don't miss the asterisk at the start of the string.)

![Perfview Additional Providers](index/_static/perfview-additional-providers.png)

### Windows EventLog provider

The [Microsoft.Extensions.Logging.EventLog](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog) provider package sends log output to the Windows Event Log.

```csharp
logging.AddEventLog();
```

[AddEventLog overloads](xref:Microsoft.Extensions.Logging.EventLoggerFactoryExtensions) let you pass in <xref:Microsoft.Extensions.Logging.EventLog.EventLogSettings>. If `null` or not specified, the following default settings are used:

* `LogName` &ndash; "Application"
* `SourceName` &ndash; ".NET Runtime"
* `MachineName` &ndash; local machine

Events are logged for [Warning level and higher](#log-level). To log events lower than `Warning`, explicitly set the log level. For example, add the following to the *appsettings.json* file:

```json
"EventLog": {
  "LogLevel": {
    "Default": "Information"
  }
}
```

### TraceSource provider

The [Microsoft.Extensions.Logging.TraceSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.TraceSource) provider package uses the <xref:System.Diagnostics.TraceSource> libraries and providers.

```csharp
logging.AddTraceSource(sourceSwitchName);
```

[AddTraceSource overloads](xref:Microsoft.Extensions.Logging.TraceSourceFactoryExtensions) let you pass in a source switch and a trace listener.

To use this provider, an app has to run on the .NET Framework (rather than .NET Core). The provider can route messages to a variety of [listeners](/dotnet/framework/debug-trace-profile/trace-listeners), such as the <xref:System.Diagnostics.TextWriterTraceListener> used in the sample app.

### Azure App Service provider

The [Microsoft.Extensions.Logging.AzureAppServices](https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices) provider package writes logs to text files in an Azure App Service app's file system and to [blob storage](https://azure.microsoft.com/documentation/articles/storage-dotnet-how-to-use-blobs/#what-is-blob-storage) in an Azure Storage account.

```csharp
logging.AddAzureWebAppDiagnostics();
```

::: moniker range=">= aspnetcore-3.0"

The provider package isn't included in the shared framework. To use the provider, add the provider package to the project.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

The provider package isn't included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app). When targeting .NET Framework or referencing the `Microsoft.AspNetCore.App` metapackage, add the provider package to the project. 

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

To configure provider settings, use <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureFileLoggerOptions> and <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureBlobLoggerOptions>, as shown in the following example:

[!code-csharp[](index/samples/3.x/TodoApiSample/Program.cs?name=snippet_AzLogOptions&highlight=17-28)]

::: moniker-end

::: moniker range="= aspnetcore-2.2"

To configure provider settings, use <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureFileLoggerOptions> and <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureBlobLoggerOptions>, as shown in the following example:

[!code-csharp[](index/samples/2.x/TodoApiSample/Program.cs?name=snippet_AzLogOptions&highlight=19-27)]

::: moniker-end

::: moniker range="= aspnetcore-2.1"

An <xref:Microsoft.Extensions.Logging.AzureAppServicesLoggerFactoryExtensions.AddAzureWebAppDiagnostics*> overload lets you pass in <xref:Microsoft.Extensions.Logging.AzureAppServices.AzureAppServicesDiagnosticsSettings>. The settings object can override default settings, such as the logging output template, blob name, and file size limit. (*Output template* is a message template that's applied to all logs in addition to what's provided with an `ILogger` method call.)

::: moniker-end

When you deploy to an App Service app, the application honors the settings in the [App Service logs](/azure/app-service/web-sites-enable-diagnostic-log/#enablediag) section of the **App Service** page of the Azure portal. When the following settings are updated, the changes take effect immediately without requiring a restart or redeployment of the app.

* **Application Logging (Filesystem)**
* **Application Logging (Blob)**

The default location for log files is in the *D:\\home\\LogFiles\\Application* folder, and the default file name is *diagnostics-yyyymmdd.txt*. The default file size limit is 10 MB, and the default maximum number of files retained is 2. The default blob name is *{app-name}{timestamp}/yyyy/mm/dd/hh/{guid}-applicationLog.txt*.

The provider only works when the project runs in the Azure environment. It has no effect when the project is run locally&mdash;it doesn't write to local files or local development storage for blobs.

#### Azure log streaming

Azure log streaming lets you view log activity in real time from:

* The app server
* The web server
* Failed request tracing

To configure Azure log streaming:

* Navigate to the **App Service logs** page from your app's portal page.
* Set **Application Logging (Filesystem)** to **On**.
* Choose the log **Level**. This setting only applies to Azure log streaming, not other logging providers in the app.

Navigate to the **Log Stream** page to view app messages. They're logged by the app through the `ILogger` interface.

### Azure Application Insights trace logging

The [Microsoft.Extensions.Logging.ApplicationInsights](https://www.nuget.org/packages/Microsoft.Extensions.Logging.ApplicationInsights) provider package writes logs to Azure Application Insights. Application Insights is a service that monitors a web app and provides tools for querying and analyzing the telemetry data. If you use this provider, you can query and analyze your logs by using the Application Insights tools.

The logging provider is included as a dependency of [Microsoft.ApplicationInsights.AspNetCore](https://www.nuget.org/packages/Microsoft.ApplicationInsights.AspNetCore), which is the package that provides all available telemetry for ASP.NET Core. If you use this package, you don't have to install the provider package.

Don't use the [Microsoft.ApplicationInsights.Web](https://www.nuget.org/packages/Microsoft.ApplicationInsights.Web) package&mdash;that's for ASP.NET 4.x.

For more information, see the following resources:

* [Application Insights overview](/azure/application-insights/app-insights-overview)
* [Application Insights for ASP.NET Core applications](/azure/azure-monitor/app/asp-net-core) - Start here if you want to implement the full range of Application Insights telemetry along with logging.
* [ApplicationInsightsLoggerProvider for .NET Core ILogger logs](/azure/azure-monitor/app/ilogger) - Start here if you want to implement the logging provider without the rest of Application Insights telemetry.
* [Application Insights logging adapters](https://docs.microsoft.com/azure/azure-monitor/app/asp-net-trace-logs).
* [Install, configure, and initialize the Application Insights SDK](/learn/modules/instrument-web-app-code-with-application-insights) - Interactive tutorial on the Microsoft Learn site.

## Third-party logging providers

Third-party logging frameworks that work with ASP.NET Core:

* [elmah.io](https://elmah.io/) ([GitHub repo](https://github.com/elmahio/Elmah.Io.Extensions.Logging))
* [Gelf](https://docs.graylog.org/en/2.3/pages/gelf.html) ([GitHub repo](https://github.com/mattwcole/gelf-extensions-logging))
* [JSNLog](https://jsnlog.com/) ([GitHub repo](https://github.com/mperdeck/jsnlog))
* [KissLog.net](https://kisslog.net/) ([GitHub repo](https://github.com/catalingavan/KissLog-net))
* [Log4Net](https://logging.apache.org/log4net/) ([GitHub repo](https://github.com/huorswords/Microsoft.Extensions.Logging.Log4Net.AspNetCore))
* [Loggr](https://loggr.net/) ([GitHub repo](https://github.com/imobile3/Loggr.Extensions.Logging))
* [NLog](https://nlog-project.org/) ([GitHub repo](https://github.com/NLog/NLog.Extensions.Logging))
* [Sentry](https://sentry.io/welcome/) ([GitHub repo](https://github.com/getsentry/sentry-dotnet))
* [Serilog](https://serilog.net/) ([GitHub repo](https://github.com/serilog/serilog-aspnetcore))
* [Stackdriver](https://cloud.google.com/dotnet/docs/stackdriver#logging) ([Github repo](https://github.com/googleapis/google-cloud-dotnet))

Some third-party frameworks can perform [semantic logging, also known as structured logging](https://softwareengineering.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

Using a third-party framework is similar to using one of the built-in providers:

1. Add a NuGet package to your project.
1. Call an `ILoggerFactory` extension method provided by the logging framework.

For more information, see each provider's documentation. Third-party logging providers aren't supported by Microsoft.

## Additional resources

* <xref:fundamentals/logging/loggermessage>
