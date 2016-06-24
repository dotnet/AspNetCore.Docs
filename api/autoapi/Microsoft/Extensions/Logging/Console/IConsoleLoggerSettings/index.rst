

IConsoleLoggerSettings Interface
================================





Namespace
    :dn:ns:`Microsoft.Extensions.Logging.Console`
Assemblies
    * Microsoft.Extensions.Logging.Console

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IConsoleLoggerSettings








.. dn:interface:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings

Properties
----------

.. dn:interface:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings.ChangeToken
    
        
        :rtype: Microsoft.Extensions.Primitives.IChangeToken
    
        
        .. code-block:: csharp
    
            IChangeToken ChangeToken { get; }
    
    .. dn:property:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings.IncludeScopes
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool IncludeScopes { get; }
    

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings.Reload()
    
        
        :rtype: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    
        
        .. code-block:: csharp
    
            IConsoleLoggerSettings Reload()
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings.TryGetSwitch(System.String, out Microsoft.Extensions.Logging.LogLevel)
    
        
    
        
        :type name: System.String
    
        
        :type level: Microsoft.Extensions.Logging.LogLevel
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            bool TryGetSwitch(string name, out LogLevel level)
    

