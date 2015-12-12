

DirectoryBrowserExtensions Class
================================



.. contents:: 
   :local:



Summary
-------

Extension methods for the DirectoryBrowserMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.DirectoryBrowserExtensions`








Syntax
------

.. code-block:: csharp

   public class DirectoryBrowserExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/staticfiles/src/Microsoft.AspNet.StaticFiles/DirectoryBrowserExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.DirectoryBrowserExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.DirectoryBrowserExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enable directory browsing on the current path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions)
    
        
    
        Enable directory browsing with the given options
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.StaticFiles.DirectoryBrowserOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder builder, DirectoryBrowserOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.DirectoryBrowserExtensions.UseDirectoryBrowser(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Enables directory browsing for the given request path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDirectoryBrowser(IApplicationBuilder builder, string requestPath)
    

