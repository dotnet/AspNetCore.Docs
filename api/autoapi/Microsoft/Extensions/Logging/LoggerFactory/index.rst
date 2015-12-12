

LoggerFactory Class
===================



.. contents:: 
   :local:



Summary
-------

Summary description for LoggerFactory





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerFactory`








Syntax
------

.. code-block:: csharp

   public class LoggerFactory : ILoggerFactory, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging/LoggerFactory.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.LoggerFactory

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.LoggerFactory
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactory.AddProvider(Microsoft.Extensions.Logging.ILoggerProvider)
    
        
        
        
        :type provider: Microsoft.Extensions.Logging.ILoggerProvider
    
        
        .. code-block:: csharp
    
           public void AddProvider(ILoggerProvider provider)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactory.CreateLogger(System.String)
    
        
        
        
        :type categoryName: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string categoryName)
    
    .. dn:method:: Microsoft.Extensions.Logging.LoggerFactory.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.Extensions.Logging.LoggerFactory
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.Logging.LoggerFactory.MinimumLevel
    
        
        :rtype: Microsoft.Extensions.Logging.LogLevel
    
        
        .. code-block:: csharp
    
           public LogLevel MinimumLevel { get; set; }
    

