.. _fundamentals-logging:

Logging
=======

By `Steve Smith`_ and `Tom Dykstra`_

ASP.NET Core has built-in support for a logging API that works with a variety of logging providers. You can use built-in providers to send logs to the Console, Visual Studio Debug window, Windows event log, or the .NET Framework TraceSource. You can also plug in a third-party logging framework, such as Elmah.Io, Loggr, NLog, or Serilog. This article shows how to use the built-in logging API and providers in your code.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/logging/sample>`__. The sample code is based on the :doc:`First Web API with ASP.NET Core MVC </tutorials/first-web-api>` sample. 

How to write logs in application code
-------------------------------------

The built-in logging in ASP.NET Core is provided by several NuGet packages. The logging framework is in `Microsoft.Extensions.Logging`, and there's a separate package for each logging provider.  A logging provider is responsible for taking some action on logged data, such as displaying it on the console. The sample app includes packages for displaying logs on the console (`Microsoft.Extensions.Logging.Console`) and in the Visual Studio Debug window (`Microsoft.Extensions.Logging.Debug`).

To call logging methods from one of your classes, get a logger object from :doc:`dependency-injection` (DI) and store it in a field, as shown in this example.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_LoggerDI
  :end-before: endregion
  :emphasize-lines: 4,7,10
  :dedent: 4

You can then create logs by calling methods named ``Log`` + the severity level of the log to write, as in this example.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7
  :dedent: 8

At this point, your logging method calls will be successful, but you won't see log output anywhere until you configure at least one logging provider.

Configure logging providers in your ``Startup`` class. Include an ``ILoggerFactory`` parameter in the method signature of the ``Configure`` method, and DI provides an object that you call methods on to add and configure providers. To add a provider, you can call an ``AddProvider`` method and pass in a provider instance, but there's typically an extension method that simplifies the syntax. The following example adds the providers for sending log output to the console and to the Visual Studio Debug window.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_AddConsoleAndDebug
  :end-before: endregion
  :emphasize-lines: 3,5-7
  :dedent: 8

``AddConsole`` and ``AddDebug`` are extension methods on ``ILoggerFactory``. They are provided by the `Microsoft.Extensions.Logging.Console` and `Microsoft.Extensions.Logging.Debug` NuGet packages.  The extension methods call the ``AddProvider`` method for you behind the scenes.

With the sample code shown above, you'll see logs in the console when you run from the command line, and in the Debug window when you run in Visual Studio in Debug mode. 

If you run the `sample application <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/logging/sample>`__ from the command line (``dotnet run``) and go to URL ``http://localhost:5000/api/todo/0``, you see console output similar to the following example:

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

If you run the `sample application <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/logging/sample>`__ from Visual Studio in debug mode and go to URL ``http://localhost:55070/api/todo/0``, you see Debug window output similar to the following example:

.. code-block:: none

  Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request starting HTTP/1.1 GET http://localhost:55070/api/todo/invalidid  
  Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executing action method TodoApi.Controllers.TodoController.GetById (TodoApi) with arguments (invalidid) - ModelState is Valid
  TodoApi.Controllers.TodoController:Information: Getting item invalidid
  TodoApi.Controllers.TodoController:Warning: GetById(invalidid) NOT FOUND
  Microsoft.AspNetCore.Mvc.StatusCodeResult:Information: Executing HttpStatusCodeResult, setting HTTP status code 404
  Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker:Information: Executed action TodoApi.Controllers.TodoController.GetById (TodoApi) in 12.5003ms
  Microsoft.AspNetCore.Hosting.Internal.WebHost:Information: Request finished in 19.0913ms 404 

From these examples you can see that ASP.NET Core itself and your application code are using the same logging API and the same logging providers. 

The remainder of this article explains some details and options for logging.

Log category
------------

Included with each log is a field that is named *category*. The category may be any string but a convention is to use the fully qualified name of the class from which the logs are written.  For example: "TodoApi.Controllers.TodoController".

You specify the category when you create a logger object or request one from DI, and the category is automatically included with every log written by that logger. You can specify the category explicitly or you can use an extension method that derives the category from the type. To specify the category explicitly, call ``CreateLogger`` on an `ILoggerFactory` instance, as shown below.

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CreateLogger
  :end-before: endregion
  :emphasize-lines: 7,10
  :dedent: 4

Most of the time it will be easier to use  ``ILogger<T>``, as in the following example. 

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_LoggerDI
  :end-before: endregion
  :emphasize-lines: 7,10
  :dedent: 4

This is equivalent to calling ``CreateLogger`` with the fully qualified type name of ``T``.

Log level
---------

Each time you write a log, you specify its `LogLevel <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Logging/LogLevel/index.html>`__. The log level indicates the degree of severity or importance.  For example, you might write an ``Information`` log when a method ends normally, a ``Warning`` log when a method returns a 404 return code, and an ``Error`` log when you catch an unexpected exception. 

In the following code example, the method names specify the log level:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7
  :dedent: 8

`Log methods <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Logging/LoggerExtensions/index.html>`__ that include the level in the method name are extension methods that the `Microsoft.Extensions.Logging` package provides.  Behind the scenes these methods call a ``Log`` method that takes a ``LogLevel`` parameter. You can call the ``Log`` method directly rather than one of the these extension methods, but the syntax is relatively complicated. For more information, see the `logger source code <https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging/Logger.cs>`__ and the `logger extensions source code <https://github.com/aspnet/Logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/LoggerExtensions.cs>`__. 

You can use the log level to control how much log output is written to a particular storage medium or display window. You might want all logs of ``Information`` level and higher to go to a high-volume data store, and all logs of ``Warning`` level and higher to go to a high-value data store. 

You can change the logging level depending on your needs at different times. For example, you might normally log at ``Information`` level but add Debug level when you need to investigate a problem.

ASP.NET Core defines the following six log levels, ordered here from least to highest severity. 

* Trace = 0

  For information that is valuable only to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment. *Disabled by default.* Example log message: ``Credentials: {"User":"someuser", "Password":"P@ssword"}``

* Debug = 1

  For information that has short-term usefulness during development and debugging. This is the default level for verbose logging. Example log message: ``Entering method Configure with flag set to true.``

* Information = 2

  For tracking the general flow of the application. These logs typically have some long term value. Example log message: ``Request received for path /api/todo``

* Warning = 3

  For abnormal or unexpected events in the application flow. These may include errors or other conditions that do not cause the application to stop, but which may need to be investigated. Handled exceptions are a common place to use the ``Warning`` log level. Example log messages: ``Login failed for IP 127.0.0.1.`` or ``FileNotFoundException for file quotes.txt.``

* Error = 4

  For errors and exceptions that cannot be handled. These messages should indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure. Example log message: ``Cannot insert record due to duplicate key violation.``

* Critical = 5

  For failures that require immediate attention. Examples: data loss scenarios, out of disk space.

Log event ID
------------

Each time you write a log, you can specify an *event ID*. The sample app does this by using a locally-defined ``LoggingEvents`` class:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7
  :dedent: 8

.. literalinclude:: logging/sample/src/TodoApi/Core/LoggingEvents.cs
  :language: c#
  :start-after: snippet_LoggingEvents
  :end-before: endregion
  :dedent: 4

An event ID is an integer value that you can use to associate a set of logged events with one another. For instance, you might associate adding an item to a shopping cart as event ID 1000 and completing a purchase as event ID 1001.

Depending on the provider and the destination storage medium, the event ID may be stored in a field or included in the text message.  The Debug provider doesn't show event IDs, but the Console provider shows them in brackets after the category:

.. code-block:: none

  info: TodoApi.Controllers.TodoController[1002]
        Getting item invalidid
  warn: TodoApi.Controllers.TodoController[4000]
        GetById(invalidid) NOT FOUND

Log message format string
-------------------------

Each time you write a log, you provide a text message. The message string can contain named placeholders into which argument values are placed, as in the following example:

.. literalinclude:: logging/sample/src/TodoApi/Controllers/TodoController.cs
  :language: c#
  :start-after: snippet_CallLogMethods
  :end-before: endregion
  :emphasize-lines: 3,7
  :dedent: 8

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

Each Azure Table entity could have ``ID`` and ``RequestTime`` properties, which would simplifying querying log data. You could find all logs within a particular ``RequestTime`` range, without having to parse the time out of the text message.

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

Some logging providers let you specify when logs should be written to storage or ignored based on log level and category.  For example, on the console you might want to see only logs of ``Warning`` level and higher, while in the Debug window you want ``Information`` level and higher.  Or you might want to see Debug level only for application logs (category begins with "TodoAPI" for this article's sample app).

The ``AddConsole`` and ``AddDebug`` extension methods provide overloads that let you pass in filtering criteria. The following sample code causes the console to ignore logs below ``Warning`` level, while the Debug window ignores logs that the framework creates. 

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_AddConsoleAndDebugWithFilter
  :end-before: endregion
  :emphasize-lines: 6-7
  :dedent: 8

The event log logger provides a similar overload that takes an ``EventLogSettings`` instance as argument, which may contain a filtering function in its ``Filter`` property. The TraceSource logger does not provide any of those overloads, since its logging level and other parameters are based on the  ``SourceSwitch`` and ``TraceListener`` it uses.

An ``ILoggerFactory`` instance can optionally be configured with custom ``FilterLoggerSettings``. The example below limits framework logs (category begins with "Microsoft" or "System") to warnings while allowing the app to log at debug level.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_FactoryFilter
  :end-before: endregion
  :emphasize-lines: 6-11
  :dedent: 8

If you want to use filtering to prevent all logs from being written for a particular category, you can specify ``LogLevel.None`` for that category. The integer value of ``LogLevel.None`` is 6, which is higher than ``LogLevel.Critical`` (5), so if you make this the minimum log level for a category or a provider, no logs will be written.

The ``WithFilter`` extension method is provided by the `Microsoft.Extensions.Logging.Filter` NuGet package. The method returns a new ``ILoggerFactory`` instance that will filter the log messages passed to all logger providers registered with it. It does not affect any other ``ILoggerFactory`` instances, including the original ``ILoggerFactory`` instance.

To see more detailed logging from the ASP.NET Core framework code, set the log level to ``Debug`` or ``Trace``. Here's an example of what you get from the Console provider:

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

The following code enables scopes for the console provider:

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_Scopes
  :end-before: endregion
  :emphasize-lines: 6
  :dedent: 8

Each log message includes the scoped information:

.. code-block:: none

  info: TodoApi.Controllers.TodoController[1002]
        => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
        Getting item 0
  warn: TodoApi.Controllers.TodoController[4000]
        => RequestId:0HKV9C49II9CK RequestPath:/api/todo/0 => TodoApi.Controllers.TodoController.GetById (TodoApi) => Message attached to logs created in the using block
        GetById(0) NOT FOUND 

TraceSource Logging
-------------------

Applications that run on the .NET Framework (rather than .NET Core) can use the `System.Diagnostics.TraceSource <https://msdn.microsoft.com/library/system.diagnostics.tracesource.aspx>`_ libraries and providers. ``TraceSource`` allows you to route messages to a variety of `listeners <https://msdn.microsoft.com/library/4y5y10s7.aspx>`__, including the `EventLogTraceListener <https://msdn.microsoft.com/library/system.diagnostics.eventlogtracelistener.aspx>`__ and the `EventProviderTraceListener <https://msdn.microsoft.com/library/system.diagnostics.eventing.eventprovidertracelistener.aspx>`__ for `ETW tracing <https://msdn.microsoft.com/library/ms751538.aspx>`__.

``TraceSource`` logging requires the ``Microsoft.Extensions.Logging.TraceSource`` package and a package for each listener. The sample app for this article uses the ``TextWriterTraceListener``.

The following example configures a ``TraceSource`` provider that logs ``Warning`` and higher messages to the console window.

.. literalinclude:: logging/sample/src/TodoApi/Startup.cs
  :language: c#
  :start-after: snippet_TraceSource
  :end-before: endregion
  :emphasize-lines: 8-12
  :dedent: 8

Run the sample app with the ``TraceSource`` code enabled, and navigate to ``http://localhost:5000/api/Todo/0``. You'll see output similar to the following:

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

Using a third-party framework is similar to using one of the built-in providers. You add a NuGet package to your project and call an extension method on ``ILoggerFactory``. For more information, see each framework's documentation.  

You can create your own custom providers as well, to support other logging frameworks or your own internal logging requirements.

