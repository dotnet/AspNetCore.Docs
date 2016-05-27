

ILogger Interface
=================






Represents a type used to perform logging.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ILogger








.. dn:interface:: Microsoft.Extensions.Logging.ILogger
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.ILogger

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.BeginScope<TState>(TState)
    
        
    
        
        Begins a logical operation scope.
    
        
    
        
        :param state: The identifier for the scope.
        
        :type state: TState
        :rtype: System.IDisposable
        :return: An IDisposable that ends the logical operation scope on dispose.
    
        
        .. code-block:: csharp
    
            IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        Checks if the given <em>logLevel</em> is enabled.
    
        
    
        
        :param logLevel: level to be checked.
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
        :return: <code>true</code> if enabled.
    
        
        .. code-block:: csharp
    
            bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        Writes a log entry.
    
        
    
        
        :param logLevel: Entry will be written on this level.
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param eventId: Id of the event.
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :param state: The entry to be written. Can be also an object.
        
        :type state: TState
    
        
        :param exception: The exception related to this entry.
        
        :type exception: System.Exception
    
        
        :param formatter: Function to create a <code>string</code> message of the <em>state</em> and <em>exception</em>.
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

