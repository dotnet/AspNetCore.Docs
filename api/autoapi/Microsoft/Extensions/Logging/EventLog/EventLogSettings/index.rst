

EventLogSettings Class
======================



.. contents:: 
   :local:



Summary
-------

Settings for :any:`Microsoft.Extensions.Logging.EventLog.EventLogLogger`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.EventLogSettings`








Syntax
------

.. code-block:: csharp

   public class EventLogSettings





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.EventLog/EventLogSettings.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogSettings

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.Filter
    
        
    
        The function used to filter events based on the log level.
    
        
        :rtype: System.Func{System.String,Microsoft.Extensions.Logging.LogLevel,System.Boolean}
    
        
        .. code-block:: csharp
    
           public Func<string, LogLevel, bool> Filter { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.LogName
    
        
    
        Name of the event log. If <c>null</c> or not specified, "Application" is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string LogName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.MachineName
    
        
    
        Name of the machine having the event log. If <c>null</c> or not specified, local machine is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string MachineName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.SourceName
    
        
    
        Name of the event log source. If <c>null</c> or not specified, "Application" is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SourceName { get; set; }
    

