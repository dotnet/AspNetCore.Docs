

TestLogger<T> Class
===================





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
* :dn:cls:`Microsoft.Extensions.Logging.Testing.TestLogger\<T>`








Syntax
------

.. code-block:: csharp

    public class TestLogger<T> : ILogger








.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger<T>

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger<T>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Testing.TestLogger<T>.TestLogger(Microsoft.Extensions.Logging.Testing.TestLoggerFactory)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.Testing.TestLoggerFactory
    
        
        .. code-block:: csharp
    
            public TestLogger(TestLoggerFactory factory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.TestLogger<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger<T>.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger<T>.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.TestLogger<T>.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

