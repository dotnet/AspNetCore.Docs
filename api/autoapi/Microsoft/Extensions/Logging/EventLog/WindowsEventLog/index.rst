

WindowsEventLog Class
=====================





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
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.WindowsEventLog`








Syntax
------

.. code-block:: csharp

    public class WindowsEventLog : IEventLog








.. dn:class:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog.DiagnosticsEventLog
    
        
        :rtype: System.Diagnostics.EventLog
    
        
        .. code-block:: csharp
    
            public EventLog DiagnosticsEventLog
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog.MaxMessageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int MaxMessageSize
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog.WindowsEventLog(System.String, System.String, System.String)
    
        
    
        
        :type logName: System.String
    
        
        :type machineName: System.String
    
        
        :type sourceName: System.String
    
        
        .. code-block:: csharp
    
            public WindowsEventLog(string logName, string machineName, string sourceName)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.WindowsEventLog.WriteEntry(System.String, System.Diagnostics.EventLogEntryType, System.Int32, System.Int16)
    
        
    
        
        :type message: System.String
    
        
        :type type: System.Diagnostics.EventLogEntryType
    
        
        :type eventID: System.Int32
    
        
        :type category: System.Int16
    
        
        .. code-block:: csharp
    
            public void WriteEntry(string message, EventLogEntryType type, int eventID, short category)
    

