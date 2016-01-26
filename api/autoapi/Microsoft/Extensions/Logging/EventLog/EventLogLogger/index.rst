

EventLogLogger Class
====================



.. contents:: 
   :local:



Summary
-------

A logger that writes messages to Windows Event Log.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.EventLogLogger`








Syntax
------

.. code-block:: csharp

   public class EventLogLogger : ILogger





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.EventLog/EventLogLogger.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger

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
        
        
        :param settings: The .
        
        :type settings: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    
        
        .. code-block:: csharp
    
           public EventLogLogger(string name, EventLogSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLogger
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.BeginScopeImpl(System.Object)
    
        
        
        
        :type state: System.Object
        :rtype: System.IDisposable
    
        
        .. code-block:: csharp
    
           public IDisposable BeginScopeImpl(object state)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.IsEnabled(Microsoft.Extensions.Logging.LogLevel)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool IsEnabled(LogLevel logLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLogger.Log(Microsoft.Extensions.Logging.LogLevel, System.Int32, System.Object, System.Exception, System.Func<System.Object, System.Exception, System.String>)
    
        
        
        
        :type logLevel: Microsoft.Extensions.Logging.LogLevel
        
        
        :type eventId: System.Int32
        
        
        :type state: System.Object
        
        
        :type exception: System.Exception
        
        
        :type formatter: System.Func{System.Object,System.Exception,System.String}
    
        
        .. code-block:: csharp
    
           public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
    

