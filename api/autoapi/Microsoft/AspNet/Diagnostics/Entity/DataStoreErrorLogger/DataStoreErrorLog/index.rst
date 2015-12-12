

DataStoreErrorLog Class
=======================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog`








Syntax
------

.. code-block:: csharp

   public class DataStoreErrorLog





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Entity/DataStoreErrorLogger.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog

Methods
-------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog.SetError(System.Type, System.Exception)
    
        
        
        
        :type contextType: System.Type
        
        
        :type exception: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual void SetError(Type contextType, Exception exception)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog.ContextType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public virtual Type ContextType { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual Exception Exception { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DataStoreErrorLogger.DataStoreErrorLog.IsErrorLogged
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool IsErrorLogged { get; }
    

