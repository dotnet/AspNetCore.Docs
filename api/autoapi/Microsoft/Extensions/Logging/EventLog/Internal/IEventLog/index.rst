

IEventLog Interface
===================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.EventLog.Internal`
Assemblies
    * Microsoft.Extensions.Logging.EventLog

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IEventLog








.. dn:interface:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog

Properties
----------

.. dn:interface:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog.MaxMessageSize
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            int MaxMessageSize { get; }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.Internal.IEventLog.WriteEntry(System.String, System.Diagnostics.EventLogEntryType, System.Int32, System.Int16)
    
        
    
        
        :type message: System.String
    
        
        :type type: System.Diagnostics.EventLogEntryType
    
        
        :type eventID: System.Int32
    
        
        :type category: System.Int16
    
        
        .. code-block:: csharp
    
            void WriteEntry(string message, EventLogEntryType type, int eventID, short category)
    

