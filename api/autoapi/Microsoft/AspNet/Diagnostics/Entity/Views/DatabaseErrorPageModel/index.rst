

DatabaseErrorPageModel Class
============================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel`








Syntax
------

.. code-block:: csharp

   public class DatabaseErrorPageModel





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Entity/Views/DatabaseErrorPageModel.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel

Constructors
------------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.DatabaseErrorPageModel(System.Type, System.Exception, System.Boolean, System.Boolean, System.Collections.Generic.IEnumerable<System.String>, Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions)
    
        
        
        
        :type contextType: System.Type
        
        
        :type exception: System.Exception
        
        
        :type databaseExists: System.Boolean
        
        
        :type pendingModelChanges: System.Boolean
        
        
        :type pendingMigrations: System.Collections.Generic.IEnumerable{System.String}
        
        
        :type options: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
           public DatabaseErrorPageModel(Type contextType, Exception exception, bool databaseExists, bool pendingModelChanges, IEnumerable<string> pendingMigrations, DatabaseErrorPageOptions options)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.ContextType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public virtual Type ContextType { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.DatabaseExists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool DatabaseExists { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
           public virtual Exception Exception { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.Options
    
        
        :rtype: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
           public virtual DatabaseErrorPageOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.PendingMigrations
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public virtual IEnumerable<string> PendingMigrations { get; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.Views.DatabaseErrorPageModel.PendingModelChanges
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool PendingModelChanges { get; }
    

