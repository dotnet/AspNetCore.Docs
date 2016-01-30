

EventLoggerFactoryExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.EventLoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

   public class EventLoggerFactoryExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.EventLog/EventLoggerFactoryExtensions.cs>`_





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
    
        
    
        Adds an event logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
        
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :param settings: The .
        
        :type settings: Microsoft.Extensions.Logging.EventLog.EventLogSettings
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public static ILoggerFactory AddEventLog(ILoggerFactory factory, EventLogSettings settings)
    
    .. dn:method:: Microsoft.Extensions.Logging.EventLoggerFactoryExtensions.AddEventLog(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.LogLevel)
    
        
    
        Adds an event logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
        
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :param minLevel: The minimum  to be logged
        
        :type minLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
           public static ILoggerFactory AddEventLog(ILoggerFactory factory, LogLevel minLevel)
    

