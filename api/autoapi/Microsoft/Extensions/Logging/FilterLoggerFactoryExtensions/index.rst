

FilterLoggerFactoryExtensions Class
===================================






:any:`Microsoft.Extensions.Logging.ILoggerFactory` extension methods which provide a common way to filter log messages across all
registered :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging.Filter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions`








Syntax
------

.. code-block:: csharp

    public class FilterLoggerFactoryExtensions








.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.FilterLoggerFactoryExtensions.WithFilter(Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.Logging.IFilterLoggerSettings)
    
        
    
        
        Registers a wrapper logger which provides a common way to filter log messages across all registered 
        :any:`Microsoft.Extensions.Logging.ILoggerProvider`\s.
    
        
    
        
        :param loggerFactory: The logger factory.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param settings: The filter settings which get applied to all registered logger providers.
        
        :type settings: Microsoft.Extensions.Logging.IFilterLoggerSettings
        :rtype: Microsoft.Extensions.Logging.ILoggerFactory
        :return: 
            A wrapped :any:`Microsoft.Extensions.Logging.ILoggerFactory` which provides common filtering across all registered
             logger providers.
    
        
        .. code-block:: csharp
    
            public static ILoggerFactory WithFilter(this ILoggerFactory loggerFactory, IFilterLoggerSettings settings)
    

