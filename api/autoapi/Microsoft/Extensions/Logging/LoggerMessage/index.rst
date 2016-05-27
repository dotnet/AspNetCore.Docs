

LoggerMessage Class
===================






Creates delegates which can be later cached to log messages in a performant way.


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
* :dn:cls:`Microsoft.Extensions.Logging.LoggerMessage`








Syntax
------

.. code-block:: csharp

    public class LoggerMessage








.. dn:class:: Microsoft.Extensions.Logging.LoggerMessage
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.LoggerMessage

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerMessage
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`2>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, Exception> Define(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope(System.String)
    
        
    
        
        Creates a delegate which can be invoked to create a log scope.
    
        
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func<System.Func`2>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, System.IDisposable<System.IDisposable>}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
            public static Func<ILogger, IDisposable> DefineScope(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1>(System.String)
    
        
    
        
        Creates a delegate which can be invoked to create a log scope.
    
        
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func<System.Func`3>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, System.IDisposable<System.IDisposable>}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
            public static Func<ILogger, T1, IDisposable> DefineScope<T1>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1, T2>(System.String)
    
        
    
        
        Creates a delegate which can be invoked to create a log scope.
    
        
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func<System.Func`4>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, System.IDisposable<System.IDisposable>}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
            public static Func<ILogger, T1, T2, IDisposable> DefineScope<T1, T2>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.DefineScope<T1, T2, T3>(System.String)
    
        
    
        
        Creates a delegate which can be invoked to create a log scope.
    
        
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Func<System.Func`5>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, T3, System.IDisposable<System.IDisposable>}
        :return: A delegate which when invoked creates a log scope.
    
        
        .. code-block:: csharp
    
            public static Func<ILogger, T1, T2, T3, IDisposable> DefineScope<T1, T2, T3>(string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`3>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, Exception> Define<T1>(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`4>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, T2, Exception> Define<T1, T2>(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2, T3>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`5>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, T3, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, T2, T3, Exception> Define<T1, T2, T3>(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2, T3, T4>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`6>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, T3, T4, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, T2, T3, T4, Exception> Define<T1, T2, T3, T4>(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2, T3, T4, T5>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`7>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, T3, T4, T5, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, T2, T3, T4, T5, Exception> Define<T1, T2, T3, T4, T5>(LogLevel logLevel, EventId eventId, string formatString)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerMessage.Define<T1, T2, T3, T4, T5, T6>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, System.String)
    
        
    
        
        Creates a delegate which can be invoked for logging a message.
    
        
    
        
        :param logLevel: The :any:`Microsoft.Extensions.Logging.LogLevel`
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: The event id
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param formatString: The named format string
        
        :type formatString: System.String
        :rtype: System.Action<System.Action`8>{Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger>, T1, T2, T3, T4, T5, T6, System.Exception<System.Exception>}
        :return: A delegate which when invoked creates a log message.
    
        
        .. code-block:: csharp
    
            public static Action<ILogger, T1, T2, T3, T4, T5, T6, Exception> Define<T1, T2, T3, T4, T5, T6>(LogLevel logLevel, EventId eventId, string formatString)
    

