.. _fundamentals-logging:

Logging
=======

By `Steve Smith`_ and `Tom Dykstra`_

ASP.NET Core has built-in support for a logging API that works with a variety of logging providers. You can use built-in providers to send logs to the Console, Visual Studio Debug window, Windows event log, or the .NET Framework TraceSource. You can also plug in a third-party logging framework, such as Elmah.Io, Loggr, NLog, or Serilog. This article shows how to use the built-in logging API and providers in your code.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/logging/sample>`__

How to write logs in application code
-------------------------------------

The built-in logging in ASP.NET Core is provided by several NuGet packages. The logging framework is in `Microsoft.Extensions.Logging`, and there's a separate package for each logging provider.  A logging provider is responsible for taking some action on logged data, such as displaying it on the console. The following sample *project.json* file installs NuGet packages for displaying logs on the console and in the Visual Studio Debug window.

.. literalinclude:: logging/sample/src/TodoApi/project.json
  :language: javascript
  :start-after: },
  :end-before: Logging.Filter
  :emphasize-lines: 6-8

To call logging methods from one of your classes, get a logger object from :doc:`dependency-injection` (DI) and store it in a field, as shown in this example.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_LoggerDI
  :end-before: endregion
  :emphasize-lines: 4,7,10

You can then create logs by calling methods named ``Log`` + the severity level of the log to write, as in this example.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7

At this point, your logging method calls will be successful, but you won't see log output anywhere until you configure at least one logging provider.

Configure logging providers in your ``Startup`` class. Include an ``ILoggerFactory`` parameter in the method signature of the ``Configure`` method, and DI provides an object that you call methods on to add and configure providers. To add a provider, you can call an ``AddProvider`` method and pass in a provider instance, but there's typically an extension method that simplifies the syntax. The following example adds the providers for sending log output to the console and to the Visual Studio Debug window.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_AddConsoleAndDebug
  :end-before: endregion
  :emphasize-lines: 3,5-7

``AddConsole`` and ``AddDebug`` are extension methods on ``ILoggerFactory``. They are provided by the `Microsoft.Extensions.Logging.Console` and `Microsoft.Extensions.Logging.Debug` NuGet packages.  The extension methods call the ``AddProvider`` method for you behind the scenes.

With the sample code shown here, you'll see logs in the console when you run from the command line, and in the Debug window when you run in Visual Studio in Debug mode. 

If you run the sample application from the command line (``dotnet run`` after navigating to the project folder) and go to URL ``http://localhost:5000/api/todo/0``, you see console output similar to the following example:

.. code-block:: none

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

If you run the sample application from Visual Studio in debug mode and go to URL ``http://localhost:55070/api/todo/0``, you see Debug window output similar to the following example:

.. code-block:: none

  Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request starting HTTP/1.1 GET http://localhost:55070/api/todo/invalidid  
  Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (invalidid) - ModelState is Valid
  TodoApi.Controllers.TodoController:Information: Getting item invalidid
  TodoApi.Controllers.TodoController:Warning: GetById(invalidid) NOT FOUND
  Microsoft.AspNetCore.Mvc.StatusCodeResult:Information: Executing HttpStatusCodeResult, setting HTTP status code 404
  Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 12.5003ms
  Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request finished in 19.0913ms 404 

From these examples you can see that ASP.NET Core itself and your application code are using the same logging API and the same logging providers. 

The remainder of this article explains some details and options for logging:

* `Log category`_
* `Log level`_
* `Log event ID`_
* `Log message format string`_
* `Logging exceptions`_
* `Log filtering`_
* `Log scopes`_
* `TraceSource logging`_
* `Third-party logging frameworks`_

Log category
------------

Included with each log is a field that is named *category*. The category may be any string but is often the fully qualified name of the class from which the logs are written.  For example: "TodoApi.Controllers.TodoController".

You specify the category when you create a logger object or request one from DI, and the category is automatically included with every log written by that logger. You can specify the category explicitly or you can use an extension method that derives the category from the type. To specify the category explicitly, request an `ILoggerFactory` object from DI and pass in the category to the ``CreateLogger`` method, as shown below.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CreateLogger
  :end-before: endregion
  :emphasize-lines: 7,10

As a shortcut, you can request from DI an instance of ``ILogger<T>``, as in the following example. This is equivalent to requesting an ``ILoggerFactory`` and calling ``CreateLogger`` with the fully qualified type name of ``T``.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_LoggerDI
  :end-before: endregion
  :emphasize-lines: 7,10

The category does not have to be a class name, but by convention it is a list delimited by periods (``.``). Some logging providers have filtering support that assumes this convention is in use. You'll see an example of that later, in the `Log filtering`_ section.

Log level
---------

Each time you write a log, you specify its `LogLevel <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Logging/LogLevel/index.html>`__. The log level indicates the degree of severity or importance.  For example, you might write an *Information* log when a method ends normally, a *Warning* log when a method returns a 404 return code, and an *Error* log when you catch an unexpected exception. 

In the following code example, the method names specify the log level:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7

Log methods that include the level in the method name are `extension methods that the Microsoft.Extensions.Logging package provides <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Logging/LoggerExtensions/index.html>`__.  Behind the scenes these methods call a ``Log`` method that takes a ``LogLevel`` parameter. You can call the ``Log`` method directly rather than one of the these extension methods, but the syntax is relatively complicated. For more information, see the `logger source code <https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging/Logger.cs>`__ and the `logger extensions source code <https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/LoggerExtensions.cs>`__. 

You can use the log level to control how much log output is written to a particular storage medium or display window. For example, you might want all logs of Information level and higher to go to cloud blob storage, and all logs of Warning level and higher to go to local file storage. 

You can also use the log level to set different levels of log verbosity at different times. For example, in production you could send logs of Information level and higher to cloud blob storage normally, but add Debug logs when you need to investigate a problem.

ASP.NET Core defines the following six log levels, ordered here from least to highest severity. 

* Trace = 0

  For information that is valuable only to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment. *Disabled by default.* Example log message: ``Credentials: {"User":"someuser", "Password":"P@ssword"}``

* Debug = 1

  For information have short-term usefulness during development and debugging. This is the default most verbose level of logging. Example log message: ``Entering method Configure with flag set to true.``

* Information = 2

  For tracking the general flow of the application. These logs typically have some long term value, as opposed to ``Debug`` level messages, which do not. Example log message: ``Request received for path /api/todo``

* Warning = 3

  For abnormal or unexpected events in the application flow. These may include errors or other conditions that do not cause the application to stop, but which may need to be investigated in the future. Handled exceptions are a common place to use the Warning log level. Example log messages: ``Login failed for IP 127.0.0.1.`` or ``FileNotFoundException for file quotes.txt.``

* Error = 4

  For unrecoverable application failures, such as exceptions that cannot be handled. These messages should indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure. Example log message: ``Cannot insert record due to duplicate key violation.``

* Critical = 5

  For unrecoverable application or system crashes, or catastrophic failures that require immediate attention. Examples: data loss scenarios, out of disk space.

The console logger prefixes each log with a four-character level identifier so that log messages are consistently aligned.

=============  =============
Log Level	   Prefix
=============  =============
Critical       crit
Error          fail
Warning        warn
Information    info
Debug          dbug
Trace          trce
=============  =============

Log event ID
------------

Each time you write a log, you can specify an *event ID*. The following example does this by using a locally-defined ``LoggingEvents`` enum:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7

.. literalinclude:: logging/sample/src/TodoApi/Core/LoggingEvents.cs
  :language: c#
  :start-after: snippet_LoggingEvents
  :end-before: endregion

An event ID is an integer value that you can use to associate a set of logged events with one another. For instance, you might associate adding an item to a shopping cart as event ID 1000 and completing a purchase as event ID 1001. This allows intelligent filtering and searching of logs that have been written to a storage medium.

You don't have to use an enum for the event ID parameter of the ``Log`` methods; you can use an integer value directly.

Depending on the provider and the destination storage medium, the event ID may be stored in a field or included in the text message.  The Debug provider doesn't show event IDs, but the Console provider shows them in brackets after the category:

.. code-block:: none

  info: TodoApi.Controllers.TodoController[1002]
        Getting item invalidid
  warn: TodoApi.Controllers.TodoController[4000]
        GetById(invalidid) NOT FOUND

If you want to see the event ID in logs, but the logging provider you're using doesn't automatically show it, you can include it in the message string.

Log message format string
-------------------------

Each time you write a log, you provide a text message and optionally a set of arguments that provide data to incorporate into the message. The message string can contain "holes" into which the argument values are placed, as in the example code that specifies a string with a placeholder for the ID and then provides the ID as an argument.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7

The order of placeholders, not their names, determines which parameters are used for them. For example, if you have the following code:

.. code-block:: c#

  string p1 = "parm1";
  string p2 = "parm2";
  _logger.LogInformation("Parameter values: {p2}, {p1}", p1, p2);

The resulting log message would look like this:

.. code-block:: none

  Parameter values: parm1, parm2

The logging framework does message formatting in this way to make it possible for logging providers to implement `semantic logging, also known as structured logging <http://programmers.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging>`__.  Because the arguments themselves are passed to the logging system, not just the formatted message string, logging providers can store the parameter values as fields in addition to the message string. For example, if you are directing your log output to Azure Table Storage, and your logger method call looks like this:

.. code-block:: c#

  _logger.LogInformation("Getting item {ID} at {RequestTime}", id, DateTime.Now);

Each Azure Table entity could have ``ID`` and ``RequestTime`` properties and you could write a query to find all logs within a particular ``RequestTime`` range, without having to parse the time out of the text message.

Logging exceptions
------------------

The logger methods that you call to create a log have overloads that let you pass in an exception, as in the following example:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_LogException
  :end-before: snippet_LogException
  :emphasize-lines: 3
  :dedent: 12

Different providers handle the exception information in different ways. Here's an example of what the Debug provider shows as a result of the code shown above.

.. code-block:: none

  TodoApi.Controllers.TodoController:Warning: GetById(036dd898-fb01-47e8-9a65-f92eb73cf924) NOT FOUND

  System.Exception: Item not found exception.
   at TodoApi.Controllers.TodoController.GetById(String id) in C:\logging\sample\src\TodoApi\Controllers\TodoController.cs:line 226

Log filtering
-------------

Some logging providers let you specify when logs should be written or ignored based on log level and category.  For example, on the console you might want to see only logs of Warning level and higher, while in the Debug window you want Information level and higher.  Or you might want to see Information and higher for framework-written logs (category begins with "Microsoft" or "System") and Debug or higher for application logs (category begins with "TodoAPI" for this article's sample app).

The ``AddConsole`` and ``AddDebug`` extension methods provide overloads that let you pass in a minimum log level, or a function that specifies log levels. The following sample code causes the console to ignore logs below Warning level, while the Debug window ignores logs that the framework creates but includes application-created logs of Trace level and above. 

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_AddConsoleAndDebugWithFilter
  :end-before: endregion
  :emphasize-lines: 6-7

The event log logger provides a similar overload that takes an ``EventLogSettings`` instance as argument, which may contain a filtering function in its ``Filter`` property. The TraceSource logger does not provide any of those overloads, since its logging level and other parameters are based on the  ``SourceSwitch`` and ``TraceListener`` it uses.

An ``ILoggerFactory`` instance can optionally be configured with custom ``FilterLoggerSettings``. The example below limits system and Microsoft built-in logging to warnings while allowing the app to log at debug level by default.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_FactoryFilter
  :end-before: endregion
  :emphasize-lines: 6-11

If you want to use filtering to prevent all logs from being written for a particular category, you can specify ``LogLevel.None`` for that category. The integer value of ``LogLevel.None`` is 6, which is higher than ``LogLevel.Critical`` (5), so if you make this the minimum log level for a category or a provider, no logs will be written.

The ``WithFilter`` extension method is provided by the `Microsoft.Extensions.Logging.Filter` NuGet package. The method returns a new ``ILoggerFactory`` instance that will filter the log messages passed to all logger providers registered with it. It does not affect any other ``ILoggerFactory`` instances, including the original ``ILoggerFactory`` instance.

To see more detailed logging from the ASP.NET Core framework code, you can adjust the `LogLevel` specified to your logging provider to something more verbose, like `Debug` or `Trace`. For example, if you modify the `AddConsole` call in the `Configure` method to specify a minimum level of `LogLevel.Trace`, the result is much more framework-level detail about each request.  Here's an example:

.. code-block:: none

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

Log scopes
----------

You can group a set of logical operations within a *scope* in order to attach the same data to each log that is created as part of that set.  For example, you might want every log created as part of processing a transaction to include the transaction ID.

Scopes are not required, are not supported by all providers, and should be used sparingly. They're best used for operations that have a distinct beginning and end, such as a transaction involving multiple resources.

A scope is an ``IDisposable`` type returned by calling the ``ILogger.BeginScope<TState>`` method, which lasts from the moment it is created until it is disposed. You use a scope by wrapping your logger calls in a ``using`` block, as shown here:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_Scopes
  :end-before: snippet_Scopes
  :emphasize-lines: 4-5,13
  :dedent: 8

The Console logging provider supports scopes. To use them, you pass in an ``includeScopes`` parameter to the ``AddConsole`` extension method, as shown here:

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_Scopes
  :end-before: endregion
  :emphasize-lines: 6
  :dedent: 8

Each log message shown on the console includes the specified additional information:

.. code-block:: none

  info: TodoApi.Controllers.TodoController[1002]
        => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => This message is attached to all logs written within the using block
        Getting item 0
  warn: TodoApi.Controllers.TodoController[4000]
        => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => This message is attached to all logs written within the using block
        GetById(0) NOT FOUND 

TraceSource Logging
-------------------

Applications that run on the full .NET Framework can use the `System.Diagnostics.TraceSource <https://msdn.microsoft.com/library/system.diagnostics.tracesource.aspx>`_ libraries and providers. ``TraceSource`` allows you to route messages to a variety of `listeners <https://msdn.microsoft.com/library/4y5y10s7.aspx>`__, including the `EventLogTraceListener <https://msdn.microsoft.com/library/system.diagnostics.eventlogtracelistener.aspx>`__ and the `EventProviderTraceListener <https://msdn.microsoft.com/library/system.diagnostics.eventing.eventprovidertracelistener.aspx>`__ for `ETW tracing <https://msdn.microsoft.com/library/ms751538.aspx>`__.

To use ``TraceSource``, add the ``Microsoft.Extensions.Logging.TraceSource`` package to your project, along with any specific trace source packages you'll be using, such as ``TextWriterTraceListener`` in the sample application that goes with this article.

The following example demonstrates how to configure a ``TraceSourceLogger`` instance for an application, with a listener that processes only ``Warning`` or higher priority messages. Each call to ``AddTraceSource`` takes a ``TraceListener``. The code shown configures a ``TextWriterTraceListener`` to write to the console window.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_TraceSource
  :end-before: endregion
  :emphasize-lines: 8-12
  :dedent: 8

The ``sourceSwitch`` is configured to use ``SourceLevels.Warning``, so only ``Warning`` (or higher) log messages are picked up by the ``TraceListener`` instance.

To see a log displayed by the ``TextWriterTraceListener``, run the app from the command line and navigate to ``http://localhost:5000/api/Todo/0``. You see output similar to the following:

.. code-block:: none

  Now listening on: http://localhost:5000
  Application started. Press Ctrl+C to shut down.
  TodoApi.Controllers.TodoController Warning: 4000 : GetById(0) NOT FOUND

There are many other ``TraceSource`` listeners available, and the ``TextWriterTraceListener`` can be configured to use any ``TextWriter`` instance, making this a very flexible option for logging.

Third-party logging frameworks
------------------------------

Here are some third-party logging frameworks that work with ASP.NET Core: 

 * `elmah.io <https://github.com/elmahio/Elmah.Io.Extensions.Logging>`_ - provider for the Elmah.Io service
 * `Loggr <https://github.com/imobile3/Loggr.Extensions.Logging>`_ - provider for the Loggr service
 * `NLog <https://github.com/NLog/NLog.Extensions.Logging>`_ - provider for the NLog library
 * `Serilog <https://github.com/serilog/serilog-framework-logging>`_ - provider for the Serilog library

Some third-party frameworks can do `semantic logging, also known as structured logging <http://programmers.stackexchange.com/questions/312197/benefits-of-structured-logging-vs-basic-logging>`__.  

To use a third-party framework, the process is typically similar to what you've seen for built-in providers: add the appropriate NuGet package to your project and call an extension method on ``ILoggerFactory``. For more information, see each framework's documentation.  

You can create your own custom providers as well, to support other logging frameworks or your own internal logging requirements.

Logging Recommendations
-----------------------

Here are some recommendations you may find helpful when implementing logging in your ASP.NET Core applications.

1. Log using the appropriate ``LogLevel``. This will allow you to consume and route logging output appropriately based on the importance of the messages.

2. Log information that will enable errors to be identified quickly. Avoid logging irrelevant or redundant information.

3. Keep log messages concise without sacrificing important information.

4. Although loggers will not log if disabled, consider adding code guards around logging methods to prevent extra method calls and log message setup overhead, especially within loops and performance-critical methods.

5. Name your loggers with a distinct prefix so they can easily be filtered or disabled. Use the ``CreateLogger<T>`` extension to create loggers named with the full name of the class.

6. Use Scopes sparingly, and only for actions with a bounded start and end. For example, the framework provides a scope around MVC actions. Avoid nesting many scopes within one another.

7. Application logging code should be related to the business concerns of the application. Increase the logging verbosity to reveal additional framework-related logs, rather than calling logger methods yourself for framework events.

Summary
----------

This article has introduced the ASP.NET Core built-in logging API and providers. You can use the same logging API with third-party logging frameworks.
