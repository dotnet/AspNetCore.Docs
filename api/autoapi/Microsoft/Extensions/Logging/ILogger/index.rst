

ILogger Interface
=================



.. contents:: 
   :local:



Summary
-------

Represents a type used to perform logging.











Syntax
------

.. code-block:: csharp

   public interface ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/ILogger.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.ILogger

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.BeginScopeImpl(System.Object)
    
        
    
        Begins a logical operation scope.
    
        
        
        
        :param state: The identifier for the scope.
        
        :type state: System.Object
        :rtype: System.IDisposable
        :return: An IDisposable that ends the logical operation scope on dispose.
    
        
        .. code-block:: csharp
    
           IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        Checks if the given LogLevel is enabled.
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
    
        Aggregates most logging patterns to a single method.
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

