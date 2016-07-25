

DataStoreErrorLoggerProvider Class
==================================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider`








Syntax
------

.. code-block:: csharp

    public class DataStoreErrorLoggerProvider : ILoggerProvider, IDisposable








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider.CreateLogger(System.String)
    
        
    
        
        :type name: System.String
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
            public virtual ILogger CreateLogger(string name)
    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider.Dispose()
    
        
    
        
        .. code-block:: csharp
    
            public virtual void Dispose()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLoggerProvider.Logger
    
        
        :rtype: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger
    
        
        .. code-block:: csharp
    
            public virtual DataStoreErrorLogger Logger { get; }
    

