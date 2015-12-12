

DataStoreErrorLoggerProvider Class
==================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider`








Syntax
------

.. code-block:: csharp

   public class DataStoreErrorLoggerProvider : ILoggerProvider, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Entity/DataStoreErrorLoggerProvider.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider.CreateLogger(System.String)
    
        
        
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           public virtual ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
           public virtual void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLoggerProvider.Logger
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger
    
        
        .. code-block:: csharp
    
           public virtual DataStoreErrorLogger Logger { get; }
    

