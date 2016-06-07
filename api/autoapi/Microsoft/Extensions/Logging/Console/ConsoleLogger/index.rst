

ConsoleLogger Class
===================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.ConsoleLogger`








Syntax
------

.. code-block:: csharp

    public class ConsoleLogger : ILogger








.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogger
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogger

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogger.Console
    
        
        :rtype: Microsoft.Extensions.Logging.Console.Internal.IConsole
    
        
        .. code-block:: csharp
    
            public IConsole Console
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogger.Filter
    
        
        :rtype: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<string, LogLevel, bool> Filter
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogger.IncludeScopes
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IncludeScopes
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLogger.Name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string Name
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Console.ConsoleLogger.ConsoleLogger(System.String, System.Func<System.String, Microsoft.Extensions.Logging.LogLevel, System.Boolean>, System.Boolean)
    
        
    
        
        :type name: System.String
    
        
        :type filter: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
    
        
        :type includeScopes: System.Boolean
    
        
        .. code-block:: csharp
    
            public ConsoleLogger(string name, Func<string, LogLevel, bool> filter, bool includeScopes)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLogger.WriteMessage(Microsoft.Extensions.Logging.LogLevel, System.String, System.Int32, System.String)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type logName: System.String
    
        
        :type eventId: System.Int32
    
        
        :type message: System.String
    
        
        .. code-block:: csharp
    
            public virtual void WriteMessage(LogLevel logLevel, string logName, int eventId, string message)
    

