

LoggerExtensions Class
======================






ILogger extension methods for common scenarios.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerExtensions`








Syntax
------

.. code-block:: csharp

    public class LoggerExtensions








.. dn:class:: Microsoft.Extensions.Logging.LoggerExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.LoggerExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.BeginScope(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats the message and creates a scope.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to create the scope in.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param messageFormat: Format string of the scope message.
        
        :type messageFormat: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
        :rtype: System.IDisposable
        :return: A disposable scope object. Can be null.
    
        
        .. code-block:: csharp
    
            public static IDisposable BeginScope(this ILogger logger, string messageFormat, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes a critical log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogCritical(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes a critical log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogCritical(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes a critical log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogCritical(this ILogger logger, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes a debug log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogDebug(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes a debug log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogDebug(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes a debug log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogDebug(this ILogger logger, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes an error log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogError(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes an error log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogError(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes an error log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogError(this ILogger logger, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes an informational log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogInformation(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes an informational log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogInformation(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes an informational log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogInformation(this ILogger logger, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes a trace log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogTrace(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes a trace log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogTrace(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes a trace log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogTrace(this ILogger logger, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.Exception, System.String, System.Object[])
    
        
    
        
        Formats and writes a warning log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param exception: The exception to log.
        
        :type exception: System.Exception
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogWarning(this ILogger logger, EventId eventId, Exception exception, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.EventId, System.String, System.Object[])
    
        
    
        
        Formats and writes a warning log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param eventId: The event id associated with the log.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogWarning(this ILogger logger, EventId eventId, string message, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        
        Formats and writes a warning log message.
    
        
    
        
        :param logger: The :any:`Microsoft.Extensions.Logging.ILogger` to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
    
        
        :param message: Format string of the log message.
        
        :type message: System.String
    
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object<System.Object>[]
    
        
        .. code-block:: csharp
    
            public static void LogWarning(this ILogger logger, string message, params object[] args)
    

