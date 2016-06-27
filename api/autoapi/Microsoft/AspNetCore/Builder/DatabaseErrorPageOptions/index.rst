

DatabaseErrorPageOptions Class
==============================






Options for the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions`








Syntax
------

.. code-block:: csharp

    public class DatabaseErrorPageOptions








.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions.MigrationsEndPointPath
    
        
    
        
        Gets or sets the path that :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware` will listen
        for requests to execute migrations commands.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public virtual PathString MigrationsEndPointPath { get; set; }
    

