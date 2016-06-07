

DataStoreErrorLog Class
=======================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog`








Syntax
------

.. code-block:: csharp

    public class DataStoreErrorLog








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog.ContextType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public virtual Type ContextType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog.IsErrorLogged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool IsErrorLogged
            {
                get;
            }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DataStoreErrorLogger.DataStoreErrorLog.SetError(System.Type, System.Exception)
    
        
    
        
        :type contextType: System.Type
    
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual void SetError(Type contextType, Exception exception)
    

