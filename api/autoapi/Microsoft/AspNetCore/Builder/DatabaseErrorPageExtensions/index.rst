

DatabaseErrorPageExtensions Class
=================================






:any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` extension methods for the :any:`Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore.DatabaseErrorPageMiddleware`\.


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
* :dn:cls:`Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions`








Syntax
------

.. code-block:: csharp

    public class DatabaseErrorPageExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to register the middleware with.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The same :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDatabaseErrorPage(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions)
    
        
    
        
        Captures synchronous and asynchronous database related exceptions from the pipeline that may be resolved using Entity Framework
        migrations. When these exceptions occur an HTML response with details of possible actions to resolve the issue is generated.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to register the middleware with.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.DatabaseErrorPageOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: The same :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` instance so that multiple calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDatabaseErrorPage(IApplicationBuilder app, DatabaseErrorPageOptions options)
    

