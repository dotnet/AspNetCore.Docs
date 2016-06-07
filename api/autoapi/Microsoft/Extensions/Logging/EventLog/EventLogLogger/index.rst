

EventLogLogger Class
====================






A logger that writes messages to Windows Event Log.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging.EventLog`
Assemblies
    * Microsoft.Extensions.Logging.EventLog

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.EventLogLogger`








Syntax
------

.. code-block:: csharp

    public class EventLogLogger : ILogger








.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.EventLog
    
        
        :rtype: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog
    
        
        .. code-block:: csharp
    
            public IEventLog EventLog
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.EventLogLogger(System.String)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.Logging.EventLog.EventLogLogger` class.
    
        
    
        
        :param name: The name of the logger.
        
        :type name: System.String
    
        
        .. code-block:: csharp
    
            public EventLogLogger(string name)
    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.EventLogLogger(System.String, Microsoft.Extensions.Logging.EventLog.EventLogSettings)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.Logging.EventLog.EventLogLogger` class.
    
        
    
        
        :param name: The name of the logger.
        
        :type name: System.String
    
        
        :param settings: The :any:`Microsoft.Extensions.Logging.EventLog.EventLogSettings`\.
        
        :type settings: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    
        
        .. code-block:: csharp
    
            public EventLogLogger(string name, EventLogSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.BeginScope<TState>(TState)
    
        
    
        
        :type state: TState
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
            public IDisposable BeginScope<TState>(TState state)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.Log<TState>(Microsoft.Extensions.Logging.LogLevel, Microsoft.Extensions.Logging.EventId, TState, System.Exception, System.Func<TState, System.Exception, System.String>)
    
        
    
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :type eventId: Microsoft.Extensions.Logging.EventId
    
        
        :type state: TState
    
        
        :type exception: System.Exception
    
        
        :type formatter: System.Func<System.Func`3>{TState, System.Exception<System.Exception>, System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    

