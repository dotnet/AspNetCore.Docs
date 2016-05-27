

ConfigurationConsoleLoggerSettings Class
========================================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings`








Syntax
------

.. code-block:: csharp

    public class ConfigurationConsoleLoggerSettings : IConsoleLoggerSettings








.. dn:class:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings.ChangeToken
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken ChangeToken
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings.IncludeScopes
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IncludeScopes
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings.ConfigurationConsoleLoggerSettings(Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        :type configuration: Microsoft.Extensions.Configuration.IConfiguration
    
        
        .. code-block:: csharp
    
            public ConfigurationConsoleLoggerSettings(IConfiguration configuration)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings.Reload()
    
        
        :rtype: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    
        
        .. code-block:: csharp
    
            public IConsoleLoggerSettings Reload()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConfigurationConsoleLoggerSettings.TryGetSwitch(System.String, out Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type name: System.String
    
        
        :type level: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetSwitch(string name, out LogLevel level)
    

