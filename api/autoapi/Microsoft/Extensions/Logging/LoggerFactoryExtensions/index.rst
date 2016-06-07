

LoggerFactoryExtensions Class
=============================






ILoggerFactory extension methods for common scenarios.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

    public class LoggerFactoryExtensions








.. dn:class:: Microsoft.Extensions.Logging.LoggerFactoryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.LoggerFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactoryExtensions.CreateLogger(Microsoft.Extensions.Logging.ILoggerFactory, System.Type)
    
        
    
        
        Creates a new ILogger instance using the full name of the given type.
    
        
    
        
        :param factory: The factory.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param type: The type.
        
        :type type: System.Type
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public static ILogger CreateLogger(ILoggerFactory factory, Type type)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactoryExtensions.CreateLogger<T>(Microsoft.Extensions.Logging.ILoggerFactory)
    
        
    
        
        Creates a new ILogger instance using the full name of the given type.
    
        
    
        
        :param factory: The factory.
        
        :type factory: Microsoft.Extensions.Logging.ILoggerFactory
        :rtype: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{T}
    
        
        .. code-block:: csharp
    
            public static ILogger<T> CreateLogger<T>(ILoggerFactory factory)
    

