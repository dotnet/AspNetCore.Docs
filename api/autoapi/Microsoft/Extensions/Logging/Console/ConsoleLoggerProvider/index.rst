

ConsoleLoggerProvider Class
===========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider`








Syntax
------

.. code-block:: csharp

   public class ConsoleLoggerProvider : ILoggerProvider, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Console/ConsoleLoggerProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider.ConsoleLoggerProvider(Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings)
    
        
        
        
        :type settings: Microsoft.Extensions.Logging.Console.IConsoleLoggerSettings
    
        
        .. code-block:: csharp
    
           public ConsoleLoggerProvider(IConsoleLoggerSettings settings)
    
    .. dn:constructor:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider.ConsoleLoggerProvider(System.Func<System.String, Microsoft.Extensions.Logging.LogLevel, System.Boolean>, System.Boolean)
    
        
        
        
        :type filter: System.Func{System.String,Microsoft.Extensions.Logging.LogLevel,System.Boolean}
        
        
        :type includeScopes: System.Boolean
    
        
        .. code-block:: csharp
    
           public ConsoleLoggerProvider(Func<string, LogLevel, bool> filter, bool includeScopes)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.Console.ConsoleLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

