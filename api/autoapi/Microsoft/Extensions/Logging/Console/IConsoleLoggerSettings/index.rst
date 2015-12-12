

IConsoleLoggerSettings Interface
================================



.. contents:: 
   :local:













Syntax
------

.. code-block:: csharp

   public interface IConsoleLoggerSettings





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Console/IConsoleLoggerSettings.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings

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
    

