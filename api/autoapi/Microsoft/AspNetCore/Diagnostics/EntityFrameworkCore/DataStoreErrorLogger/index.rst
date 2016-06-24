

DataStoreErrorLogger Class
==========================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger`








Syntax
------

.. code-block:: csharp

    public class DataStoreErrorLogger : ILogger








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public virtual IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.StartLoggingForCurrentCallContext()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void StartLoggingForCurrentCallContext()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.LastError
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog
    
        
        .. code-block:: csharp
    
            public virtual DataStoreErrorLogger.DataStoreErrorLog LastError { get; }
    

