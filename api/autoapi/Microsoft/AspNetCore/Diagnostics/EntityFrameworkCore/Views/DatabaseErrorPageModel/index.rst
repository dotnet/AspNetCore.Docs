

DatabaseErrorPageModel Class
============================





Namespace
    :dn:ns:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel`








Syntax
------

.. code-block:: csharp

    public class DatabaseErrorPageModel








.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.ContextType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public virtual Type ContextType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.DatabaseExists
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool DatabaseExists
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.Exception
    
        
        :rtype: System.Exception
    
        
        .. code-block:: csharp
    
            public virtual Exception Exception
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
            public virtual DatabaseErrorPageOptions Options
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.PendingMigrations
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public virtual IEnumerable<string> PendingMigrations
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.PendingModelChanges
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public virtual bool PendingModelChanges
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.Views.DatabaseErrorPageModel.DatabaseErrorPageModel(System.Type, System.Exception, System.Boolean, System.Boolean, System.Collections.Generic.IEnumerable<System.String>, Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions)
    
        
    
        
        :type contextType: System.Type
    
        
        :type exception: System.Exception
    
        
        :type databaseExists: System.Boolean
    
        
        :type pendingModelChanges: System.Boolean
    
        
        :type pendingMigrations: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        :type options: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions
    
        
        .. code-block:: csharp
    
            public DatabaseErrorPageModel(Type contextType, Exception exception, bool databaseExists, bool pendingModelChanges, IEnumerable<string> pendingMigrations, DatabaseErrorPageOptions options)
    

