

WelcomePageExtensions Class
===========================



.. contents:: 
   :local:



Summary
-------

IApplicationBuilder extensions for the WelcomePageMiddleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.WelcomePageExtensions`








Syntax
------

.. code-block:: csharp

   public class WelcomePageExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/diagnostics/src/Microsoft.AspNet.Diagnostics/WelcomePage/WelcomePageExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.WelcomePageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.WelcomePageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds the WelcomePageMiddleware to the pipeline.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseWelcomePage(IApplicationBuilder builder)
    
    .. dn:method:: Microsoft.AspNet.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Diagnostics.WelcomePageOptions)
    
        
    
        Adds the WelcomePageMiddleware to the pipeline with the given options.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type options: Microsoft.AspNet.Diagnostics.WelcomePageOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseWelcomePage(IApplicationBuilder builder, WelcomePageOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Http.PathString)
    
        
    
        Adds the WelcomePageMiddleware to the pipeline with the given path.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type path: Microsoft.AspNet.Http.PathString
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseWelcomePage(IApplicationBuilder builder, PathString path)
    
    .. dn:method:: Microsoft.AspNet.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNet.Builder.IApplicationBuilder, System.String)
    
        
    
        Adds the WelcomePageMiddleware to the pipeline with the given path.
    
        
        
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type path: System.String
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseWelcomePage(IApplicationBuilder builder, string path)
    

