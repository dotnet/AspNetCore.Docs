

FileServerExtensions Class
==========================



.. contents:: 
   :local:



Summary
-------

Extension methods that combine all of the static file middleware components:
Default files, directory browsing, send file, and static files





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.FileServerExtensions`








Syntax
------

.. code-block:: csharp

   public class FileServerExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/FileServerExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.FileServerExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.FileServerExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enable all static file middleware (except directory browsing) for the current request path in the current directory.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFileServer(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.StaticFiles.FileServerOptions)
    
        
    
        Enable all static file middleware with the given options
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.StaticFiles.FileServerOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFileServer(IApplicationBuilder builder, FileServerOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNet.Builder.IApplicationBuilder, System.Boolean)
    
        
    
        Enable all static file middleware on for the current request path in the current directory.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param enableDirectoryBrowsing: Should directory browsing be enabled?
        
        :type enableDirectoryBrowsing: System.Boolean
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFileServer(IApplicationBuilder builder, bool enableDirectoryBrowsing)
    
    .. dn:method:: Microsoft.AspNet.Builder.FileServerExtensions.UseFileServer(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Enables all static file middleware (except directory browsing) for the given request path from the directory of the same name
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseFileServer(IApplicationBuilder builder, string requestPath)
    

