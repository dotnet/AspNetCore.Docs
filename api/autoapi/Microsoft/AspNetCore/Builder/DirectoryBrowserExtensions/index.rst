

DirectoryBrowserExtensions Class
================================






Extension methods for the DirectoryBrowserMiddleware


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
* :dn:cls:`Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions`








Syntax
------

.. code-block:: csharp

    public class DirectoryBrowserExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enable directory browsing on the current path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.DirectoryBrowserOptions)
    
        
    
        
        Enable directory browsing with the given options
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.DirectoryBrowserOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder app, DirectoryBrowserOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Enables directory browsing for the given request path
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder app, string requestPath)
    

