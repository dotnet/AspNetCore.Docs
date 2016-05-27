

NullLogger<T> Class
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
* :dn:cls:`Microsoft.Extensions.Logging.Testing.NullLogger\<T>`








Syntax
------

.. code-block:: csharp

    public class NullLogger<T> : ILogger<T>, ILogger








.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger`1
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger<T>

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger<T>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger<T>.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger<T>.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Testing.NullLogger<T>.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

Fields
------

.. dn:class:: Microsoft.Extensions.Logging.Testing.NullLogger<T>
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.Extensions.Logging.Testing.NullLogger<T>.Instance
    
        
        :rtype: Microsoft.Extensions.Logging.Testing.NullLogger<Microsoft.Extensions.Logging.Testing.NullLogger`1>{T}
    
        
        .. code-block:: csharp
    
            public static readonly NullLogger<T> Instance
    

