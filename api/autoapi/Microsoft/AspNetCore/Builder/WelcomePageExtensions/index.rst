

WelcomePageExtensions Class
===========================






IApplicationBuilder extensions for the WelcomePageMiddleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Diagnostics

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.WelcomePageExtensions`








Syntax
------

.. code-block:: csharp

    public class WelcomePageExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.WelcomePageExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the WelcomePageMiddleware to the pipeline.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseWelcomePage(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.WelcomePageOptions)
    
        
    
        
        Adds the WelcomePageMiddleware to the pipeline with the given options.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type options: Microsoft.AspNetCore.Builder.WelcomePageOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseWelcomePage(this IApplicationBuilder app, WelcomePageOptions options)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Http.PathString)
    
        
    
        
        Adds the WelcomePageMiddleware to the pipeline with the given path.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type path: Microsoft.AspNetCore.Http.PathString
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseWelcomePage(this IApplicationBuilder app, PathString path)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.WelcomePageExtensions.UseWelcomePage(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.String)
    
        
    
        
        Adds the WelcomePageMiddleware to the pipeline with the given path.
    
        
    
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :type path: System.String
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseWelcomePage(this IApplicationBuilder app, string path)
    

