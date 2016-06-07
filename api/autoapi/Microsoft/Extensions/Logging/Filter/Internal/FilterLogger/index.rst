

FilterLogger Class
==================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Filter.Internal`
Assemblies
    * Microsoft.Extensions.Logging.Filter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Filter.Internal.FilterLogger`








Syntax
------

.. code-block:: csharp

    public class FilterLogger : ILogger








.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger.FilterLogger(Microsoft.Extensions.Logging.ILogger, System.String, Microsoft.Extensions.Logging.IFilterLoggerSettings)
    
        
    
        
        :type innerLogger: Microsoft.Extensions.Logging.ILogger
    
        
        :type categoryName: System.String
    
        
        :type settings: Microsoft.Extensions.Logging.IFilterLoggerSettings
    
        
        .. code-block:: csharp
    
            public FilterLogger(ILogger innerLogger, string categoryName, IFilterLoggerSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Filter.Internal.FilterLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

