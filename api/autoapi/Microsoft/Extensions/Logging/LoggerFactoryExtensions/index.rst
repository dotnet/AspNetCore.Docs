

LoggerFactoryExtensions Class
=============================



.. contents:: 
   :local:



Summary
-------

ILoggerFactory extension methods for common scenarios.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

   public class LoggerFactoryExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/logging/blob/master/src/Microsoft.Extensions.Logging.Abstractions/LoggerFactoryExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.LoggerFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactoryExtensions.CreateLogger<T>(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        Creates a new ILogger instance using the full name of the given type.
    
        
        
        
        :param factory: The factory.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public static ILogger CreateLogger<T>(ILoggerFactory factory)
    

