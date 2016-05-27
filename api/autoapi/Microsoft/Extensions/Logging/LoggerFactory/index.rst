

LoggerFactory Class
===================






Summary description for LoggerFactory


Namespace
    :dn:ns:`Microsoft.Extensions.Logging`
Assemblies
    * Microsoft.Extensions.Logging

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.LoggerFactory`








Syntax
------

.. code-block:: csharp

    public class LoggerFactory : ILoggerFactory, IDisposable








.. dn:class:: Microsoft.Extensions.Logging.LoggerFactory
    :hidden:

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
    

