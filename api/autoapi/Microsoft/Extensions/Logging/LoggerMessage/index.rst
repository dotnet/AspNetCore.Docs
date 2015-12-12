

LoggerMessage Class
===================



.. contents:: 
   :local:



Summary
-------

Creates delegates which can be later cached to log messages in a performant way.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerMessage`








Syntax
------

.. code-block:: csharp

   public class LoggerMessage





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/LoggerMessage.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.LoggerMessage

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerMessage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope(System.String)
    
        
    
        Creates a delegate which can be invoked to create a log scope.
    
        
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func{Microsoft.Extensions.Logging.ILogger,System.IDisposable}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
           public static Func<ILogger, IDisposable> DefineScope(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1>(System.String)
    
        
    
        Creates a delegate which can be invoked to create a log scope.
    
        
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func{Microsoft.Extensions.Logging.ILogger,{T1},System.IDisposable}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
           public static Func<ILogger, T1, IDisposable> DefineScope<T1>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1, T2>(System.String)
    
        
    
        Creates a delegate which can be invoked to create a log scope.
    
        
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func{Microsoft.Extensions.Logging.ILogger,{T1},{T2},System.IDisposable}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
           public static Func<ILogger, T1, T2, IDisposable> DefineScope<T1, T2>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1, T2, T3>(System.String)
    
        
    
        Creates a delegate which can be invoked to create a log scope.
    
        
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func{Microsoft.Extensions.Logging.ILogger,{T1},{T2},{T3},System.IDisposable}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
           public static Func<ILogger, T1, T2, T3, IDisposable> DefineScope<T1, T2, T3>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1>(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.String)
    
        
    
        Creates a delegate which can be invoked for logging a message.
    
        
        
        
        :param logLevel: The
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :param eventId: The event id
        
        :type eventId: System.Int32
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action{Microsoft.Extensions.Logging.ILogger,{T1},System.Exception}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
           public static Action<ILogger, T1, Exception> Define<T1>(LogLevel logLevel, int eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2>(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.String)
    
        
    
        Creates a delegate which can be invoked for logging a message.
    
        
        
        
        :param logLevel: The
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :param eventId: The event id
        
        :type eventId: System.Int32
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action{Microsoft.Extensions.Logging.ILogger,{T1},{T2},System.Exception}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
           public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(LogLevel logLevel, int eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2, T3>(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.String)
    
        
    
        Creates a delegate which can be invoked for logging a message.
    
        
        
        
        :param logLevel: The
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :param eventId: The event id
        
        :type eventId: System.Int32
        
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action{Microsoft.Extensions.Logging.ILogger,{T1},{T2},{T3},System.Exception}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
           public static Action<ILogger, T1, T2, T3, Exception> Define<T1, T2, T3>(LogLevel logLevel, int eventId, string formatString)
    

