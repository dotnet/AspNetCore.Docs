

TestLogger Class
================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Testing`
Assemblies
    * Microsoft.Extensions.Logging.Testing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Testing.TestLogger`








Syntax
------

.. code-block:: csharp

    public class TestLogger : ILogger








.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Testing.TestLogger.TestLogger(System.String, Microsoft.Extensions.Logging.Testing.TestSink, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type sink: Microsoft.Extensions.Logging.Testing.TestSink
    
        
        :type enabled: System.Boolean
    
        
        .. code-block:: csharp
    
            public TestLogger(string name, TestSink sink, bool enabled)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Testing.TestLogger.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name { get; set; }
    

