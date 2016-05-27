

EventLoggerFactoryExtensions Class
==================================






Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.EventLog

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.EventLoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

    public class EventLoggerFactoryExtensions








.. dn:class:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Adds an event logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\.Information or higher.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddEventLog(ILoggerFactory factory)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.EventLog.EventLogSettings)
    
        
    
        
        Adds an event logger. Use <em>settings</em> to enable logging for specific :any:`Microsoft.Extensions.Logging.LogLevel`\s.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param settings: The :any:`Microsoft.Extensions.Logging.EventLog.EventLogSettings`\.
        
        :type settings: Microsoft.Extensions.Logging.EventLog.EventLogSettings
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddEventLog(ILoggerFactory factory, EventLogSettings settings)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        Adds an event logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param minLevel: The minimum :any:`Microsoft.Extensions.Logging.LogLevel` to be logged
        
        :type minLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddEventLog(ILoggerFactory factory, LogLevel minLevel)
    

