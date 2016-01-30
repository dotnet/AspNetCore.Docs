

DefaultFilesExtensions Class
============================



.. contents:: 
   :local:



Summary
-------

Extension methods for the DefaultFilesMiddleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.DefaultFilesExtensions`








Syntax
------

.. code-block:: csharp

   public class DefaultFilesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/staticfiles/blob/master/src/Microsoft.AspNet.StaticFiles/DefaultFilesExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.DefaultFilesExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.DefaultFilesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Enables default file mapping on the current path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.StaticFiles.DefaultFilesOptions)
    
        
    
        Enables default file mapping with the given options
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.StaticFiles.DefaultFilesOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder builder, DefaultFilesOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.DefaultFilesExtensions.UseDefaultFiles(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Enables default file mapping for the given request path
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param requestPath: The relative request path.
        
        :type requestPath: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseDefaultFiles(IApplicationBuilder builder, string requestPath)
    

