

StaticFileExtensions Class
==========================






Extension methods for the StaticFileMiddleware


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.StaticFiles

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.StaticFileExtensions`








Syntax
------

.. code-block:: csharp

    public class StaticFileExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.StaticFileExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enables static file serving for the current request path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStaticFiles(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.StaticFileOptions)
    
        
    
        
        Enables static file serving with the given options
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.StaticFileOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStaticFiles(this IApplicationBuilder app, StaticFileOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Enables static file serving for the given request path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseStaticFiles(this IApplicationBuilder app, string requestPath)
    

