

ILoggerFactory Interface
========================






Represents a type used to configure the logging system and create instances of :any:`Microsoft.Extensions.Logging.ILogger` from
the registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface ILoggerFactory : IDisposable








.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory
    :hidden:

.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
    
        
        Adds an :any:`Microsoft.Extensions.Logging.ILoggerProvider` to the logging system.
    
        
    
        
        :param provider: The :any:`Microsoft.Extensions.Logging.ILoggerProvider`\.
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
            void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.ILoggerFactory.CreateLogger(System.String)
    
        
    
        
        Creates a new :any:`Microsoft.Extensions.Logging.ILogger` instance.
    
        
    
        
        :param categoryName: The category name for messages produced by the logger.
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
        :return: The :any:`Microsoft.Extensions.Logging.ILogger`\.
    
        
        .. code-block:: csharp
    
            ILogger CreateLogger(string categoryName)
    

