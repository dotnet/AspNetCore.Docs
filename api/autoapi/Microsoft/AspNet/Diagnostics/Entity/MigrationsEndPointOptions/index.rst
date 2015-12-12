

MigrationsEndPointOptions Class
===============================



.. contents:: 
   :local:



Summary
-------

Options for the :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions`








Syntax
------

.. code-block:: csharp

   public class MigrationsEndPointOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics.Entity/MigrationsEndPointOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions

Fields
------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions.DefaultPath
    
        
    
        The default value for :dn:prop:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions.Path`\.
    
        
    
        
        .. code-block:: csharp
    
           public static PathString DefaultPath
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointOptions.Path
    
        
    
        Gets or sets the path that the :any:`Microsoft.AspNet.Diagnostics.Entity.MigrationsEndPointMiddleware` will listen
        for requests to execute migrations commands.
    
        
        :rtype: Microsoft.AspNet.Http.PathString
    
        
        .. code-block:: csharp
    
           public virtual PathString Path { get; set; }
    

