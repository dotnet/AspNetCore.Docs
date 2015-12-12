

NLogLoggerProvider Class
========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.Logging.NLog.NLogLoggerProvider`








Syntax
------

.. code-block:: csharp

   public class NLogLoggerProvider : ILoggerProvider, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/logging/src/Microsoft.Extensions.Logging.NLog/NLogLoggerProvider.cs>`_





.. dn:class:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider

Constructors
------------

.. dn:class:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider.NLogLoggerProvider(NLog.LogFactory)
    
        
        
        
        :type logFactory: NLog.LogFactory
    
        
        .. code-block:: csharp
    
           public NLogLoggerProvider(LogFactory logFactory)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.Extensions.Logging.NLog.NLogLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    

