

LoggerExtensions Class
======================



.. contents:: 
   :local:



Summary
-------

ILogger extension methods for common scenarios.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerExtensions`








Syntax
------

.. code-block:: csharp

   public class LoggerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/LoggerExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.LoggerExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.BeginScope(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats the message and creates a scope.
    
        
        
        
        :param logger: The  to create the scope in.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param messageFormat: Format string of the scope message.
        
        :type messageFormat: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
        :rtype: System.IDisposable
        :return: A disposable scope object. Can be null.
    
        
        .. code-block:: csharp
    
           public static IDisposable BeginScope(ILogger logger, string messageFormat, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, int eventId, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, int eventId, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes a critical log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogCritical(ILogger logger, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param data: The message to log.
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, int eventId, string data)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param data: The message to log.
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, string data)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes a debug log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogDebug(ILogger logger, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, int eventId, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, int eventId, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes an error log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogError(ILogger logger, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, int eventId, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes an informational log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogInformation(ILogger logger, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param data: The message to log.
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, int eventId, string data)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param data: The message to log.
        
        :type data: System.String
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, string data)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogVerbose(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes a verbose log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogVerbose(ILogger logger, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.Int32, Microsoft.Extensions.Logging.ILogValues, System.Exception)
    
        
    
        Formats the given :any:`Microsoft.Extensions.Logging.ILogValues` and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param state: The  to write.
        
        :type state: Microsoft.Extensions.Logging.ILogValues
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, int eventId, ILogValues state, Exception error = null)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String)
    
        
    
        Writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, int eventId, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, int eventId, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.Int32, System.String, System.Object[])
    
        
    
        Formats and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param eventId: The event id associated with the log.
        
        :type eventId: System.Int32
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, int eventId, string format, params object[] args)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.String)
    
        
    
        Writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, string message)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.String, System.Exception)
    
        
    
        Formats the given message and error and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param message: The message to log.
        
        :type message: System.String
        
        
        :param error: The exception to log.
        
        :type error: System.Exception
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, string message, Exception error)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger, System.String, System.Object[])
    
        
    
        Formats and writes a warning log message.
    
        
        
        
        :param logger: The  to write to.
        
        :type logger: Microsoft.Extensions.Logging.ILogger
        
        
        :param format: Format string of the log message.
        
        :type format: System.String
        
        
        :param args: An object array that contains zero or more objects to format.
        
        :type args: System.Object[]
    
        
        .. code-block:: csharp
    
           public static void LogWarning(ILogger logger, string format, params object[] args)
    

