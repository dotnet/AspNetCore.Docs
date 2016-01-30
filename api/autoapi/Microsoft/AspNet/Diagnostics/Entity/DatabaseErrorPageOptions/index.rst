

DatabaseErrorPageOptions Class
==============================



.. contents:: 
   :local:



Summary
-------

Options for the :any:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions`








Syntax
------

.. code-block:: csharp

   public class DatabaseErrorPageOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/diagnostics/blob/master/src/Microsoft.AspNet.Diagnostics.Entity/DatabaseErrorPageOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions.EnableMigrationCommands
    
        
    
        Gets or sets a value indicating whether the error page will allow the execution of
        migrations related commands when they may help solve the current error.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool EnableMigrationCommands { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions.ListMigrations
    
        
    
        Gets or sets a value indicating whether the names of pending migrations are listed
        on the error page.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ListMigrations { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions.MigrationsEndPointPath
    
        
    
        Gets or sets the path that :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware` will listen
        for requests to execute migrations commands. The middleware is only registered if 
        :dn:prop:`Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions.EnableMigrationCommands` is set to true.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public virtual PathString MigrationsEndPointPath { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.DatabaseErrorPageOptions.ShowExceptionDetails
    
        
    
        Gets or sets a value indicating whether details about the exception that occurred
        are displayed on the error page.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool ShowExceptionDetails { get; set; }
    

