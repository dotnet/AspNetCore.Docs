

ILoggerProvider Interface
=========================



.. contents:: 
   :local:



Summary
-------

Represents a type that can create instances of :any:`Microsoft.Extensions.Logging.ILogger`\.











Syntax
------

.. code-block:: csharp

   public interface ILoggerProvider : IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/ILoggerProvider.cs>`_





.. dn:interface:: Microsoft.Extensions.Logging.ILoggerProvider

Methods
-------

.. dn:interface:: Microsoft.Extensions.Logging.ILoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.ILoggerProvider.CreateLogger(System.String)
    
        
    
        Creates a new :any:`Microsoft.Extensions.Logging.ILogger` instance.
    
        
        
        
        :param categoryName: The category name for messages produced by the logger.
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           ILogger CreateLogger(string categoryName)
    

