

FileServerExtensions Class
==========================






Extension methods that combine all of the static file middleware components:
Default files, directory browsing, send file, and static files


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
* :dn:cls:`Microsoft.AspNetCore.Builder.FileServerExtensions`








Syntax
------

.. code-block:: csharp

    public class FileServerExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.FileServerExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.FileServerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.FileServerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Enable all static file middleware (except directory browsing) for the current request path in the current directory.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFileServer(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.FileServerOptions)
    
        
    
        
        Enable all static file middleware with the given options
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.FileServerOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFileServer(this IApplicationBuilder app, FileServerOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Boolean)
    
        
    
        
        Enable all static file middleware on for the current request path in the current directory.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param enableDirectoryBrowsing: Should directory browsing be enabled?
        
        :type enableDirectoryBrowsing: System.Boolean
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFileServer(this IApplicationBuilder app, bool enableDirectoryBrowsing)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Enables all static file middleware (except directory browsing) for the given request path from the directory of the same name
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseFileServer(this IApplicationBuilder app, string requestPath)
    

