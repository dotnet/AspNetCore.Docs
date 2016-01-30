

StaticFileExtensions Class
==========================



.. contents:: 
   :local:



Summary
-------

Extension methods for the StaticFileMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.StaticFileExtensions`








Syntax
------

.. code-block:: csharp

   public class StaticFileExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/StaticFileExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.StaticFileExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.StaticFileExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enables static file serving for the current request path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseStaticFiles(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.StaticFiles.StaticFileOptions)
    
        
    
        Enables static file serving with the given options
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.StaticFiles.StaticFileOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseStaticFiles(IApplicationBuilder builder, StaticFileOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.StaticFileExtensions.UseStaticFiles(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Enables static file serving for the given request path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseStaticFiles(IApplicationBuilder builder, string requestPath)
    

