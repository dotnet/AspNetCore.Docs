

DefaultFilesExtensions Class
============================






Extension methods for the DefaultFilesMiddleware


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
* :dn:cls:`Microsoft.AspNetCore.Builder.DefaultFilesExtensions`








Syntax
------

.. code-block:: csharp

    public class DefaultFilesExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enables default file mapping on the current path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.DefaultFilesOptions)
    
        
    
        
        Enables default file mapping with the given options
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.DefaultFilesOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder app, DefaultFilesOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Enables default file mapping for the given request path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder app, string requestPath)
    

