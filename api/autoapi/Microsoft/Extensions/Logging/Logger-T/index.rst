

Logger<T> Class
===============






Delegates to a new :any:`Microsoft.Extensions.Logging.ILogger` instance using the full name of the given type, created by the
provided :any:`Microsoft.Extensions.Logging.ILoggerFactory`\.


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
* :dn:cls:`Microsoft.Extensions.Logging.Logger\<T>`








Syntax
------

.. code-block:: csharp

    public class Logger<T> : ILogger<T>, ILogger








.. dn:class:: Microsoft.Extensions.Logging.Logger`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Logger<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Logger<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Logger<T>.Logger(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Logging.Logger\`1`\.
    
        
    
        
        :param factory: The factory.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public Logger(ILoggerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Logger<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            IDisposable ILogger.BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool ILogger.IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Logger<T>.Microsoft.Extensions.Logging.ILogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            void ILogger.Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

