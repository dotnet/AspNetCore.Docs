

MigrationsEndPointExtensions Class
==================================






:any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` extension methods for the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.MigrationsEndPointMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions`








Syntax
------

.. code-block:: csharp

    public class MigrationsEndPointExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions.UseMigrationsEndPoint(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Processes requests to execute migrations operations. The middleware will listen for requests made to :dn:field:`Microsoft.AspNetCore.Builder.MigrationsEndPointOptions.DefaultPath`\.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to register the middleware with.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The same :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMigrationsEndPoint(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MigrationsEndPointExtensions.UseMigrationsEndPoint(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.MigrationsEndPointOptions)
    
        
    
        
        Processes requests to execute migrations operations. The middleware will listen for requests to the path configured in <em>options</em>.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to register the middleware with.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: An action to set the options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.MigrationsEndPointOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The same :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMigrationsEndPoint(IApplicationBuilder app, MigrationsEndPointOptions options)
    

