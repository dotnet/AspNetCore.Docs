---
title: Logging in ASP.NET Core | Microsoft Docs
author: ardalis
description: Introduces the logging framework in ASP.NET Core. Includes a section for each built-in logging provider and links to some popular third-party providers.
keywords: ASP.NET Core, logging, logging providers, Microsoft.Extensions.Logging, ILogger, ILoggerFactory, LogLevel, WithFilter, TraceSource, EventLog, EventSource, scopes
ms.author: tdykstra
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: ac27ac68-d76a-4f8e-b8ab-ea045803e5f2
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/logging
ms.custom: H1Hack27Feb2017
---
# Introduction to Logging in ASP.NET Core

By [Steve Smith](http://ardalis.com) and [Tom Dykstra](https://github.com/tdykstra)

ASP.NET Core supports a logging API that works with a variety of logging providers. Built-in providers let you send logs to one or more destinations, and you can plug in a third-party logging framework. This article shows how to use the built-in logging API and providers in your code.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/logging/sample)

## How to add providers

A logging provider takes some action on logged data, such as display it on the console or store it in Azure blob storage. To use a provider, install its NuGet package and call the provider's extension method on an instance of `ILoggerFactory`, as shown in the following example.

[!code-csharp[](logging/sample/src/TodoApi/Startup.cs?name=snippet_AddConsoleAndDebug&highlight=3,5-7)]

ASP.NET Core [dependency injection](dependency-injection.md) (DI) provides the `ILoggerFactory` instance. The `AddConsole` and `AddDebug` extension methods are defined in the [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console/) and [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug/) packages. Each extension method calls the `ILoggerFactory.AddProvider` method, passing in an instance of the provider. 

> [!NOTE]
> The sample application for this article adds logging providers in the `Configure` method of the `Startup` class. If you want to get log output from code that executes earlier, add logging providers in the `Startup` class constructor instead. 

You'll find information about each [built-in logging provider](#built-in-logging-providers) and links to [third-party logging providers](#third-party-logging-providers) later in the article.

## How to create logs

To create logs, get an `ILogger` object from DI and store it in a field, then call logging methods on that logger object.

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_LoggerDI&highlight=4,7,10)]

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

This example requests `ILogger<TodoController>` from DI to specify the `TodoController` class as the *category* of logs that are created with the logger.  Categories are explained [later in this article](#log-category).

## Sample logging output

With the sample code shown above, you'll see logs in the console when you run from the command line, and in the Debug window when you run in Visual Studio in Debug mode. 

Here's an example of what you see in the console if you run the sample application from the command line and go to URL `http://localhost:5000/api/todo/0`:

```console
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[1]
      Request starting HTTP/1.1 GET http://localhost:5000/api/todo/invalidid
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[1]
      Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (invalidid) - ModelState is Valid
info: TodoApi.Controllers.TodoController[1002]
      Getting item invalidid
warn: TodoApi.Controllers.TodoController[4000]
      GetById(invalidid) NOT FOUND
info: Microsoft.AspNetCore.Mvc.StatusCodeResult[1]
      Executing HttpStatusCodeResult, setting HTTP status code 404
info: Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker[2]
      Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 243.2636ms
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[2]
      Request finished in 628.9188ms 404
```

Here's an example of what you see in the Debug window if you run the sample application from Visual Studio in debug mode and go to URL `http://localhost:55070/api/todo/0`:

```
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request starting HTTP/1.1 GET http://localhost:55070/api/todo/invalidid
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (invalidid) - ModelState is Valid
TodoApi.Controllers.TodoController:Information: Getting item invalidid
TodoApi.Controllers.TodoController:Warning: GetById(invalidid) NOT FOUND
Microsoft.AspNetCore.Mvc.StatusCodeResult:Information: Executing HttpStatusCodeResult, setting HTTP status code 404
Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 12.5003ms
Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request finished in 19.0913ms 404
```

From these examples you can see that ASP.NET Core itself and your application code are using the same logging API and the same logging providers.

The remainder of this article explains some details and options for logging.

## NuGet packages

The `ILogger` and `ILoggerFactory` interfaces are in [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions/), and default implementations for them are in [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging/).

## Log category

A *category* is specified with each log that you create. The category may be any string, but a convention is to use the fully qualified name of the class from which the logs are written.  For example: "TodoApi.Controllers.TodoController".

You specify the category when you create a logger object or request one from DI, and the category is automatically included with every log written by that logger. You can specify the category explicitly or you can use an extension method that derives the category from the type. To specify the category explicitly, call `CreateLogger` on an *ILoggerFactory* instance, as shown below.

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_CreateLogger&highlight=7,10)]

Most of the time it will be easier to use  `ILogger<T>`, as in the following example.

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_LoggerDI&highlight=7,10)]

This is equivalent to calling `CreateLogger` with the fully qualified type name of `T`.

## Log level

Each time you write a log, you specify its [LogLevel](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.logging.loglevel). The log level indicates the degree of severity or importance.  For example, you might write an `Information` log when a method ends normally, a `Warning` log when a method returns a 404 return code, and an `Error` log when you catch an unexpected exception.

In the following code example, the names of the methods specify the log level, the first parameter is the [Log event ID](#log-event-id), and the remaining parameters construct a log message:

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

Log methods that include the level in the method name are [extension methods for ILogger](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.loggerextensions) that the *Microsoft.Extensions.Logging* package provides.  Behind the scenes these methods call a `Log` method that takes a `LogLevel` parameter. You can call the `Log` method directly rather than one of these extension methods, but the syntax is relatively complicated. For more information, see the [ILogger interface](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.ilogger) and the [logger extensions source code](https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/LoggerExtensions.cs).

ASP.NET Core defines the following [log levels](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.loglevel), ordered here from least to highest severity.

* Trace = 0

  For information that is valuable only to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment. *Disabled by default.* Example: `Credentials: {"User":"someuser", "Password":"P@ssword"}`

* Debug = 1

  For information that has short-term usefulness during development and debugging. Example: `Entering method Configure with flag set to true.`

* Information = 2

  For tracking the general flow of the application. These logs typically have some long-term value. Example: `Request received for path /api/todo`

* Warning = 3

  For abnormal or unexpected events in the application flow. These may include errors or other conditions that do not cause the application to stop, but which may need to be investigated. Handled exceptions are a common place to use the `Warning` log level. Example: `FileNotFoundException for file quotes.txt.`

* Error = 4

  For errors and exceptions that cannot be handled. These messages indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure. Example log message: `Cannot insert record due to duplicate key violation.`

* Critical = 5

  For failures that require immediate attention. Examples: data loss scenarios, out of disk space.

You can use the log level to control how much log output is written to a particular storage medium or display window. For example, in production you might want all logs of `Information` level and higher to go to a high-volume data store, and all logs of `Warning` level and higher to go to a high-value data store. During development you might normally direct only logs of `Warning` or higher severity to the console, but add `Debug` level when you need to investigate a problem. The [Log filtering](#log-filtering) section later in this article explains how to control which log levels a provider handles.

The ASP.NET Core framework writes `Debug` logs for framework events. Here's an example of what you see from the console provider if you run the sample application with the minimum log level set to `Debug` and go to URL `http://localhost:5000/api/todo/0`:

```console
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[1]
      Request starting HTTP/1.1 GET http://localhost:5000/api/todo/0
dbug: Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware[4]
      The request path /api/todo/0 does not match a supported file type
dbug: Microsoft.AspNetCore.Routing.Tree.TreeRouter[1]
      Request successfully matched the route with name 'GetTodo' and template 'api/Todo/{id}'.
dbug: Microsoft.AspNetCore.Mvc.Internal.ActionSelector[2]
      Action 'TodoApi.Controllers.TodoController.Update (TodoApi)' with id '6cada879-f7a8-4152-b244-7b41831791cc' did not match the constraint 'Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint'
dbug: Microsoft.AspNetCore.Mvc.Internal.ActionSelector[2]
      Action 'TodoApi.Controllers.TodoController.Delete (TodoApi)' with id '529c0e82-aea6-466c-bbe2-e77ded858853' did not match the constraint 'Microsoft.AspNetCore.Mvc.Internal.HttpMethodActionConstraint'
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
      Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 198.8402ms
info: Microsoft.AspNetCore.Hosting.Internal.WebHost[2]
      Request finished in 550.6837ms 404
dbug: Microsoft.AspNetCore.Server.Kestrel[9]
      Connection id "0HKV8M5ARIH5P" completed keep alive response.
```

## Log event ID

Each time you write a log, you can specify an *event ID*. The sample app does this by using a locally-defined `LoggingEvents` class:

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

[!code-csharp[](logging/sample/src/TodoApi/Core/LoggingEvents.cs?name=snippet_LoggingEvents)]

An event ID is an integer value that you can use to associate a set of logged events with one another. For instance, a log for adding an item to a shopping cart could be event ID 1000 and a log for completing a purchase could be event ID 1001.

In logging output, the event ID may be stored in a field or included in the text message, depending on the provider.  The Debug provider doesn't show event IDs, but the console provider shows them in brackets after the category:

```console
info: TodoApi.Controllers.TodoController[1002]
      Getting item invalidid
warn: TodoApi.Controllers.TodoController[4000]
      GetById(invalidid) NOT FOUND
```

## Log message format string

Each time you write a log, you provide a text message. The message string can contain named placeholders into which argument values are placed, as in the following example:

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_CallLogMethods&highlight=3,7)]

The order of placeholders, not their names, determines which parameters are used for them. For example, if you have the following code:

```csharp
string p1 = "parm1";
string p2 = "parm2";
_logger.LogInformation("Parameter values: {p2}, {p1}", p1, p2);
```

The resulting log message would look like this:

```
Parameter values: parm1, parm2
```

The logging framework does message formatting in this way to make it possible for logging providers to implement [semantic logging, also known as structured logging](http://programmers.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging). Because the arguments themselves are passed to the logging system, not just the formatted message string, logging providers can store the parameter values as fields in addition to the message string. For example, if you are directing your log output to Azure Table Storage, and your logger method call looks like this:

```csharp
_logger.LogInformation("Getting item {ID} at {RequestTime}", id, DateTime.Now);
```

Each Azure Table entity could have `ID` and `RequestTime` properties, which would simplify queries on log data. You could find all logs within a particular `RequestTime` range, without having to parse the time out of the text message.

## Logging exceptions

The logger methods have overloads that let you pass in an exception, as in the following example:

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_LogException&highlight=3)]

Different providers handle the exception information in different ways. Here's an example of Debug provider output from the code shown above.

```
TodoApi.Controllers.TodoController:Warning: GetById(036dd898-fb01-47e8-9a65-f92eb73cf924) NOT FOUND

System.Exception: Item not found exception.
 at TodoApi.Controllers.TodoController.GetById(String id) in C:\logging\sample\src\TodoApi\Controllers\TodoController.cs:line 226
```

## Log filtering

Some logging providers let you specify when logs should be written to a storage medium or ignored based on log level and category.

The `AddConsole` and `AddDebug` extension methods provide overloads that let you pass in filtering criteria. The following sample code causes the console provider to ignore logs below `Warning` level, while the Debug provider ignores logs that the framework creates.

[!code-csharp[](logging/sample/src/TodoApi/Startup.cs?name=snippet_AddConsoleAndDebugWithFilter&highlight=6-7)]

The `AddEventLog` method has an overload that takes an `EventLogSettings` instance, which may contain a filtering function in its `Filter` property. The TraceSource provider does not provide any of those overloads, since its logging level and other parameters are based on the  `SourceSwitch` and `TraceListener` it uses.

You can set filtering rules for all providers that are registered with an `ILoggerFactory` instance by using the `WithFilter` extension method. The example below limits framework logs (category begins with "Microsoft" or "System") to warnings while letting the app log at debug level.

[!code-csharp[](logging/sample/src/TodoApi/Startup.cs?name=snippet_FactoryFilter&highlight=6-11)]

If you want to use filtering to prevent all logs from being written for a particular category, you can specify `LogLevel.None` as the minimum log level for that category. The integer value of `LogLevel.None` is 6, which is higher than `LogLevel.Critical` (5).

The `WithFilter` extension method is provided by the [Microsoft.Extensions.Logging.Filter](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Filter) NuGet package. The method returns a new `ILoggerFactory` instance that will filter the log messages passed to all logger providers registered with it. It does not affect any other `ILoggerFactory` instances, including the original `ILoggerFactory` instance.

## Log scopes

You can group a set of logical operations within a *scope* in order to attach the same data to each log that is created as part of that set.  For example, you might want every log created as part of processing a transaction to include the transaction ID.

A scope is an `IDisposable` type that is returned by the `ILogger.BeginScope<TState>` method and lasts until it is disposed. You use a scope by wrapping your logger calls in a `using` block, as shown here:

[!code-csharp[](logging/sample/src/TodoApi/Controllers/TodoController.cs?name=snippet_Scopes&highlight=4-5,13)]

The following code enables scopes for the console provider:

[!code-csharp[](logging/sample/src/TodoApi/Startup.cs?name=snippet_Scopes&highlight=6)]

Each log message includes the scoped information:

```
info: TodoApi.Controllers.TodoController[1002]
      => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
      Getting item 0
warn: TodoApi.Controllers.TodoController[4000]
      => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
      GetById(0) NOT FOUND
```

## Built-in logging providers

ASP.NET Core ships the following providers:

* [Console](#console)
* [Debug](#debug)
* [EventSource](#eventsource)
* [EventLog](#eventlog)
* [TraceSource](#tracesource)
* [Azure App Service](#appservice)

<a id="console"></a>
### The console provider

The [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) provider package sends log output to the console. 

```csharp
loggerFactory.AddConsole()
```

[AddConsole overloads](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.consoleloggerextensions) let you pass in an a minimum log level, a filter function, and a boolean that indicates whether scopes are supported.  Another option is to pass in an `IConfiguration` object, which can specify scopes support and logging levels. 

If you are considering the console provider for use in production, be aware that it has a significant impact on performance.

When you create a new project in Visual Studio, the `AddConsole` method looks like this:

```csharp
loggerFactory.AddConsole(Configuration.GetSection("Logging"));
```

This code refers to the `Logging` section of the *appSettings.json* file:

[!code-json[](logging/sample/src/TodoApi/appsettings.json)]

The settings shown limit framework logs to warnings while allowing the app to log at debug level, as explained in the [Log filtering](#log-filtering) section. For more information, see [Configuration](configuration.md).

<a id="debug"></a>
### The Debug provider

The [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) provider package writes log output by using the [System.Diagnostics.Debug](https://docs.microsoft.com/dotnet/core/api/system.diagnostics.debug#System_Diagnostics_Debug) class.

```csharp
loggerFactory.AddDebug()
```

[AddDebug overloads](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.debugloggerfactoryextensions) let you pass in a minimum log level or a filter function.

<a id="eventsource"></a>
### The EventSource provider

For apps that target ASP.NET Core 1.1.0 or higher, the [Microsoft.Extensions.Logging.EventSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventSource) provider package can implement event tracing. On Windows, it uses [ETW](https://msdn.microsoft.com/library/windows/desktop/bb968803). The provider is cross-platform, but there are no event collection and display tools yet for Linux or macOS. 

```csharp
loggerFactory.AddEventSourceLogger()
```

The best way to collect and view logs is to use the [PerfView utility](https://www.microsoft.com/en-us/download/details.aspx?id=28567). There are other tools for viewing ETW logs, but PerfView provides the best experience for working with the ETW events emitted by ASP.NET. 

To configure PerfView for collecting events logged by this provider, add the string `*Microsoft-Extensions-Logging` to the **Additional Providers** list. (Don't miss the asterisk at the start of the string.)

![Perfview Additional Providers](logging/_static/perfview-additional-providers.png)

Capturing events on Nano Server requires some additional setup:

* Connect PowerShell remoting to the Nano Server:

  ```powershell
  Enter-PSSession [name]
  ```

* Create an ETW session:

  ```powershell
  New-EtwTraceSession -Name "MyAppTrace" -LocalFilePath C:\trace.etl
  ```

* Add ETW providers for [CLR](https://msdn.microsoft.com/library/ff357718), ASP.NET Core, and others as needed. The ASP.NET Core provider GUID is `3ac73b97-af73-50e9-0822-5da4367920d0`. 

  ```powershell
  Add-EtwTraceProvider -Guid "{e13c0d23-ccbc-4e12-931b-d9cc2eee27e4}" -SessionName MyAppTrace
  Add-EtwTraceProvider -Guid "{3ac73b97-af73-50e9-0822-5da4367920d0}" -SessionName MyAppTrace
  ```

* Run the site and do whatever actions you want tracing information for.

* Stop the tracing session when you're finished:

  ```powershell
  Stop-EtwTraceSession -Name "MyAppTrace"
  ```

The resulting *C:\trace.etl* file can be analyzed with PerfView as on other editions of Windows.

<a id="eventlog"></a>
### The Windows EventLog provider

The [Microsoft.Extensions.Logging.EventLog](https://www.nuget.org/packages/Microsoft.Extensions.Logging.EventLog) provider package sends log output to the Windows Event Log.

```csharp
loggerFactory.AddEventLog()
```

[AddEventLog overloads](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.eventloggerfactoryextensions) let you pass in `EventLogSettings` or a minimum log level.

<a id="tracesource"></a>
### The TraceSource provider

The [Microsoft.Extensions.Logging.TraceSource](https://www.nuget.org/packages/Microsoft.Extensions.Logging.TraceSource) provider package uses the [System.Diagnostics.TraceSource](https://msdn.microsoft.com/library/system.diagnostics.tracesource.aspx) libraries and providers.

```csharp
loggerFactory.AddTraceSource(sourceSwitchName);
```

[AddTraceSource overloads](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.logging.tracesourcefactoryextensions) let you pass in a source switch and a trace listener.

To use this provider, an application has to run on the .NET Framework (rather than .NET Core). The provider lets you route messages to a variety of [listeners](https://msdn.microsoft.com/library/4y5y10s7), such as the [TextWriterTraceListener](https://msdn.microsoft.com/library/system.diagnostics.textwritertracelistener) used in the sample application.

The following example configures a `TraceSource` provider that logs `Warning` and higher messages to the console window.

[!code-csharp[](logging/sample/src/TodoApi/Startup.cs?name=snippet_TraceSource&highlight=8-12)]

<a id="appservice"></a>
### The Azure App Service provider

The [Microsoft.Extensions.Logging.AzureAppServices](https://www.nuget.org/packages/Microsoft.Extensions.Logging.AzureAppServices) provider package writes logs to text files in an Azure App Service app's file system and to [blob storage](https://azure.microsoft.com/en-us/documentation/articles/storage-dotnet-how-to-use-blobs/#what-is-blob-storage) in an Azure Storage account. The provider is available only for apps that target ASP.NET Core 1.1.0 or higher. 

```csharp
loggerFactory.AddAzureWebAppDiagnostics();
```

An `AddAzureWebAppDiagnostics` overload lets you pass in [AzureAppServicesDiagnosticsSettings](https://github.com/aspnet/Logging/blob/c7d0b1b88668ff4ef8a86ea7d2ebb5ca7f88d3e0/src/Microsoft.Extensions.Logging.AzureAppServices/AzureAppServicesDiagnosticsSettings.cs), with which you can override default settings such as the logging output template, blob name, and file size limit. (*Output template* is a message format string that is applied to all logs, on top of the one that you provide when you call an `ILogger` method.)  

When you deploy to an App Service app, your application honors the settings in the [Diagnostic Logs](https://azure.microsoft.com/en-us/documentation/articles/web-sites-enable-diagnostic-log/#enablediag) section of the **App Service** blade of the Azure portal. When you change those settings, the changes take effect immediately without requiring that you restart the app or redeploy code to it. 

![Azure logging settings](logging/_static/azure-logging-settings.png)

The default location for log files is in the *D:\\home\\LogFiles\\Application* folder, and the default file name is *diagnostics-yyyymmdd.txt*. The default file size limit is 10 MB and the default maximum number of files retained is 2. The default blob name is *{app-name}{timestamp}/yyyy/mm/dd/hh/{guid}-applicationLog.txt*. For more information about default behavior, see [AzureAppServicesDiagnosticsSettings](https://github.com/aspnet/Logging/blob/c7d0b1b88668ff4ef8a86ea7d2ebb5ca7f88d3e0/src/Microsoft.Extensions.Logging.AzureAppServices/AzureAppServicesDiagnosticsSettings.cs).

The provider only works when your project runs in the Azure environment.  It has no effect when you run locally -- it does not write to local files or local development storage for blobs.

> [!NOTE]
> If you don't need to change the provider default settings, there's an alternative way to set up App Service logging in your application. Install [Microsoft.AspNetCore.AzureAppServicesIntegration](https://www.nuget.org/packages/Microsoft.AspNetCore.AzureAppServicesIntegration/) (which includes the logging package as a dependency), and call its extension method on `WebHostBuilder` in your `Main` method.
>
> ```csharp
> var host = new WebHostBuilder()
>     .UseKestrel()    
>     .UseAzureAppServices()    
>     .UseStartup<Startup>()    
>     .Build();
> ```
>
>  Behind the scenes, `UseAzureAppServices` calls `UseIISIntegration` and the logging provider extension method `AddAzureWebAppDiagnostics`.

## Third-party logging providers

Here are some third-party logging frameworks that work with ASP.NET Core:

   * [elmah.io](https://github.com/elmahio/Elmah.Io.Extensions.Logging) - provider for the Elmah.Io service

   * [Loggr](https://github.com/imobile3/Loggr.Extensions.Logging) - provider for the Loggr service

   * [NLog](https://github.com/NLog/NLog.Extensions.Logging) - provider for the NLog library

   * [Serilog](https://github.com/serilog/serilog-framework-logging) - provider for the Serilog library

Some third-party frameworks can do [semantic logging, also known as structured logging](http://programmers.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging).

Using a third-party framework is similar to using one of the built-in providers: add a NuGet package to your project and call an extension method on `ILoggerFactory`. For more information, see each framework's documentation.

You can create your own custom providers as well, to support other logging frameworks or your own logging requirements.
