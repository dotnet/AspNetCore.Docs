

DebugLoggerFactoryExtensions Class
==================================






Extension methods for the :any:`Microsoft.Extensions.Logging.ILoggerFactory` class.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Debug

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

    public class DebugLoggerFactoryExtensions








.. dn:class:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Adds a debug logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\.Information or higher.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddDebug(ILoggerFactory factory)
    
    .. dn:method:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        Adds a debug logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param minLevel: The minimum :any:`Microsoft.Extensions.Logging.LogLevel` to be logged
        
        :type minLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddDebug(ILoggerFactory factory, LogLevel minLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug(Microsoft.Extensions.Logging.ILoggerFactory, System.Func<System.String, Microsoft.Extensions.Logging.LogLevel, System.Boolean>)
    
        
    
        
        Adds a debug logger that is enabled as defined by the filter function.
    
        
    
        
        :param factory: The extension method argument.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param filter: The function used to filter events based on the log level.
        
        :type filter: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddDebug(ILoggerFactory factory, Func<string, LogLevel, bool> filter)
    

