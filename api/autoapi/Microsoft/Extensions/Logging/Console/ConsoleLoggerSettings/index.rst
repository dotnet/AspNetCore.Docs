

ConsoleLoggerSettings Class
===========================





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
* :dn:cls:`Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings`








Syntax
------

.. code-block:: csharp

    public class ConsoleLoggerSettings : IConsoleLoggerSettings








.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings.ChangeToken
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            public IChangeToken ChangeToken { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings.IncludeScopes
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool IncludeScopes { get; set; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings.Switches
    
        
        :rtype: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.String<System.String>, Microsoft.Extensions.Logging.LogLevel<Microsoft.Extensions.Logging.LogLevel>}
    
        
        .. code-block:: csharp
    
            public IDictionary<string, LogLevel> Switches { get; set; }
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings.Reload()
    
        
        :rtype: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    
        
        .. code-block:: csharp
    
            public IConsoleLoggerSettings Reload()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLoggerSettings.TryGetSwitch(System.String, out Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type name: System.String
    
        
        :type level: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool TryGetSwitch(string name, out LogLevel level)
    

