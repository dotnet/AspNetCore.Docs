

TraceSourceLogger Class
=======================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.TraceSource`
Assemblies
    * Microsoft.Extensions.Logging.TraceSource

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger`








Syntax
------

.. code-block:: csharp

    public class TraceSourceLogger : ILogger








.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger.TraceSourceLogger(System.Diagnostics.TraceSource)
    
        
    
        
        :type traceSource: System.Diagnostics.TraceSource
    
        
        .. code-block:: csharp
    
            public TraceSourceLogger(TraceSource traceSource)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.TraceSource.TraceSourceLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

