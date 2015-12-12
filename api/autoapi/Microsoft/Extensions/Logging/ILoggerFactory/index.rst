

ILoggerFactory Interface
========================



.. contents:: 
   :local:



Summary
-------

Represents a type used to configure the logging system and create instances of :any:`Microsoft.Extensions.Logging.ILogger` from
the registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.











Syntax
------

.. code-block:: csharp

   public interface ILoggerFactory : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.Abstractions/ILoggerFactory.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
    
        Adds an :any:`Microsoft.Extensions.Logging.ILoggerProvider` to the logging system.
    
        
        
        
        :param provider: The .
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
           void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILoggerFactory.CreateLogger(System.String)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Logging.ILogger` instance.
    
        
        
        
        :param categoryName: The category name for messages produced by the logger.
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
        :return: The <see cref="T:Microsoft.Extensions.Logging.ILogger" />.
    
        
        .. code-block:: csharp
    
           ILogger CreateLogger(string categoryName)
    

Properties
----------

.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.ILoggerFactory.MinimumLevel
    
        
    
        The minimum level of log messages sent to loggers.
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           LogLevel MinimumLevel { get; set; }
    

