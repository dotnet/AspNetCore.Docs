

MigrationsEndPointOptions Class
===============================






Options for the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.MigrationsEndPointOptions`








Syntax
------

.. code-block:: csharp

    public class MigrationsEndPointOptions








.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions.Path
    
        
    
        
        Gets or sets the path that the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware` will listen
        for requests to execute migrations commands.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public virtual PathString Path
            {
                get;
                set;
            }
    

Fields
------

.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions.DefaultPath
    
        
    
        
        The default value for :dn:prop:`Microsoft.AspNetCore.Builder.MigrationsEndPointOptions.Path`\.
    
        
        :rtype: Microsoft.AspNetCore.Http.PathString
    
        
        .. code-block:: csharp
    
            public static PathString DefaultPath
    

