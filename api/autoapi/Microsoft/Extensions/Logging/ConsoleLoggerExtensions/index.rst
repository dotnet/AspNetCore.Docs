

ConsoleLoggerExtensions Class
=============================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.ConsoleLoggerExtensions`








Syntax
------

.. code-block:: csharp

    public class ConsoleLoggerExtensions








.. dn:class:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Adds a console logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\.Information or higher.
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, IConfiguration configuration)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings)
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type settings: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, IConsoleLoggerSettings settings)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        Adds a console logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
    
        
        :param factory: The :any:`Microsoft.Extensions.Logging.ILoggerFactory` to use.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param minLevel: The minimum :any:`Microsoft.Extensions.Logging.LogLevel` to be logged
        
        :type minLevel: Microsoft.Extensions.Logging.LogLevel
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, LogLevel minLevel)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.LogLevel, System.Boolean)
    
        
    
        
        Adds a console logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\s of minLevel or higher.
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param minLevel: The minimum :any:`Microsoft.Extensions.Logging.LogLevel` to be logged
        
        :type minLevel: Microsoft.Extensions.Logging.LogLevel
    
        
        :param includeScopes: A value which indicates whether log scope information should be displayed
            in the output.
        
        :type includeScopes: System.Boolean
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, LogLevel minLevel, bool includeScopes)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, System.Boolean)
    
        
    
        
        Adds a console logger that is enabled for :any:`Microsoft.Extensions.Logging.LogLevel`\.Information or higher.
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param includeScopes: A value which indicates whether log scope information should be displayed
            in the output.
        
        :type includeScopes: System.Boolean
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, bool includeScopes)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, System.Func<System.String, Microsoft.Extensions.Logging.LogLevel, System.Boolean>)
    
        
    
        
        Adds a console logger that is enabled as defined by the filter function.
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type filter: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, Func<string, LogLevel, bool> filter)
    
    .. dn:method:: Microsoft.Extensions.Logging.ConsoleLoggerExtensions.AddConsole(Microsoft.Extensions.Logging.ILoggerFactory, System.Func<System.String, Microsoft.Extensions.Logging.LogLevel, System.Boolean>, System.Boolean)
    
        
    
        
        Adds a console logger that is enabled as defined by the filter function.
    
        
    
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type filter: System.Func<System.Func`3>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>, System.Boolean<System.Boolean>}
    
        
        :param includeScopes: A value which indicates whether log scope information should be displayed
            in the output.
        
        :type includeScopes: System.Boolean
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory AddConsole(this ILoggerFactory factory, Func<string, LogLevel, bool> filter, bool includeScopes)
    

