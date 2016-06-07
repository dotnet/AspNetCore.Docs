

ElmLogger Class
===============





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.Elm`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger`








Syntax
------

.. code-block:: csharp

    public class ElmLogger : ILogger








.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger.ElmLogger(System.String, Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions, Microsoft.AspNetCore.Diagnostics.Elm.ElmStore)
    
        
    
        
        :type name: System.String
    
        
        :type options: Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions
    
        
        :type store: Microsoft.AspNetCore.Diagnostics.Elm.ElmStore
    
        
        .. code-block:: csharp
    
            public ElmLogger(string name, ElmOptions options, ElmStore store)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.Elm.ElmLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

