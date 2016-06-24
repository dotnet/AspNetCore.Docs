

EventLogSettings Class
======================






Settings for :any:`Microsoft.Extensions.Logging.EventLog.EventLogLogger`\.


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
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.EventLogSettings`








Syntax
------

.. code-block:: csharp

    public class EventLogSettings








.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogSettings

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.EventLog
    
        
    
        
        For unit testing purposes only.
    
        
        :rtype: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog
    
        
        .. code-block:: csharp
    
            public IEventLog EventLog { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.Filter
    
        
    
        
        The function used to filter events based on the log level.
    
        
        :rtype: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Func<string, LogLevel, bool> Filter { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.LogName
    
        
    
        
        Name of the event log. If <code>null</code> or not specified, "Application" is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string LogName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.MachineName
    
        
    
        
        Name of the machine having the event log. If <code>null</code> or not specified, local machine is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string MachineName { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.EventLogSettings.SourceName
    
        
    
        
        Name of the event log source. If <code>null</code> or not specified, "Application" is the default.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SourceName { get; set; }
    

