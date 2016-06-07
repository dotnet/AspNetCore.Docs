

EventLogLoggerProvider Class
============================






The provider for the :any:`Microsoft.Extensions.Logging.EventLog.EventLogLogger`\.


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
* :dn:cls:`Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider`








Syntax
------

.. code-block:: csharp

    public class EventLogLoggerProvider : ILoggerProvider, IDisposable








.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider.EventLogLoggerProvider()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider` class.
    
        
    
        
        .. code-block:: csharp
    
            public EventLogLoggerProvider()
    
    .. dn:constructor:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider.EventLogLoggerProvider(Microsoft.Extensions.Logging.EventLog.EventLogSettings)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider` class.
    
        
    
        
        :param settings: The :any:`Microsoft.Extensions.Logging.EventLog.EventLogSettings`\.
        
        :type settings: Microsoft.Extensions.Logging.EventLog.EventLogSettings
    
        
        .. code-block:: csharp
    
            public EventLogLoggerProvider(EventLogSettings settings)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider.CreateLogger(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLog.EventLogLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    

