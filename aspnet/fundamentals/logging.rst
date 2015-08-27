Logging
=======

By `Steve Smith`_

ASP.NET 5 has built-in support for logging, and allows developers to easily leverage their preferred logging framework's functionality as well. Implementing logging in your application requires a minimal amount of setup code. Once this is in place, logging can be added wherever it is desired.

In this article:
	- `Implementing Logging in your Application`_
	- `Configuring Logging in your Application`_
	
`View or download sample from GitHub <https://github.com/aspnet/Home/tree/dev/samples>`_.

Implementing Logging in your Application
----------------------------------------

Adding logging to your application is done by requesting either an ``ILoggerFactory`` or an ``ILogger<T>`` via :doc:`dependency-injection`. If an ``ILoggerFactory`` is requested, a logger must be created using its ``CreateLogger`` method. The following example shows how to do this within the ``Configure`` method in the ``Startup`` class:

.. literalinclude:: logging/sample/src/LoggingSample/Startup.cs
	:language: c#
	:linenos:
	:lines: 15-25
	:dedent: 8
	:emphasize-lines: 2,7-8

When a logger is created, a category name or source must be provided. By convention this is string is hierarchical, with categories separated by dot (``.``) characters. Some logging providers have filtering support that leverages this convention, making it easier to locate logging output of interest. In the above example, the logging is configured to use the built-in `ConsoleLogger <https://github.com/aspnet/Logging/blob/1.0.0-beta6/src/Microsoft.Framework.Logging.Console/ConsoleLogger.cs>`_ (see `Configuring Logging in your Application`_ below). To see the console logger in action, run the sample application using the ``web`` command, and make a request to configured URL (``localhost:5000``). You should see output similar to the following:

.. image:: logging/_static/console-logger-output.png

You may see more than one log statement per web request you make in your browser, since most browsers will make multiple requests (i.e. for the favicon file) when attempting to load a page. Note that the console logger displayed the log level (``info`` in the image above) followed by the category (``[LoggingSample.Startup]``), and then the message that was logged.

Logging Verbosity Levels
^^^^^^^^^^^^^^^^^^^^^^^^

When adding logging statements to your application, you must specify a `LogLevel <https://github.com/aspnet/Logging/blob/1.0.0-beta6/src/Microsoft.Framework.Logging.Abstractions/LogLevel.cs>`_. The LogLevel allows you to control the verbosity of the logging output from your application, as well as the ability to pipe different kinds of log messages to different loggers. For example, you may wish to log debug messages to a local file, but log errors to the machine's event log or a database.

ASP.NET 5 defines six levels of logging verbosity:

Debug
	Used for the most detailed log messages, typically only valuable to a developer debugging an issue. These messages may contain sensitive application data and so should not be enabled in a production environment. *Disabled by default.* Example: ``Credentials: {"User":"someuser", "Password":"P@ssword"}``
	
Verbose
	These messages have short-term usefulness during development. They contain information that may be useful for debugging, but have no long-term value. This is the default most verbose level of logging. Example: ``Entering method Configure with flag set to true``

Information
	These messages are used to track the general flow of the application. These logs should have some long term value, as opposed to ``Verbose`` level messages, which do not. Example: ``Request received for path /foo``

Warning
	The Warning level should be used for abnormal or unexpected events in the application flow. These may include errors or other conditions that do not cause the application to stop, but which may need to be investigated in the future. Handled exceptions are a common place to use the Warning log level. Examples: ``Login failed for IP 127.0.0.1`` or ``FileNotFoundException for file foo.txt``

Error
	An error should be logged when the current flow of the application must stop due to some failure, such as an exception that cannot be handled or recovered from. These messages should indicate a failure in the current activity or operation (such as the current HTTP request), not an application-wide failure. Example: ``Cannot insert record due to duplicate key violation``

Critical
	A critical log level should be reserved for unrecoverable application or system crashes, or catastrophic failure that requires immediate attention. Examples: data loss scenarios, stack overflows, out of disk space


Configuring Logging in your Application
----------------------------------------



Summary
-------

Summarize logging here.

