

MvcApplicationBuilderExtensions Class
=====================================



.. contents:: 
   :local:



Summary
-------

Extension methods for :any:`Microsoft.AspNet.Builder.IApplicationBuilder` to add MVC to the request execution pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class MvcApplicationBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/Builder/MvcApplicationBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions.UseMvc(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds MVC to the :any:`Microsoft.AspNet.Builder.IApplicationBuilder` request execution pipeline.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMvc(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions.UseMvc(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Routing.IRouteBuilder>)
    
        
    
        Adds MVC to the :any:`Microsoft.AspNet.Builder.IApplicationBuilder` request execution pipeline.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureRoutes: A callback to configure MVC routes.
        
        :type configureRoutes: System.Action{Microsoft.AspNet.Routing.IRouteBuilder}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMvc(IApplicationBuilder app, Action<IRouteBuilder> configureRoutes)
    
    .. dn:method:: Microsoft.AspNet.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute(Microsoft.AspNet.Builder.IApplicationBuilder)
    
        
    
        Adds MVC to the :any:`Microsoft.AspNet.Builder.IApplicationBuilder` request execution pipeline
        with a default route named 'default' and the following template:
        '{controller=Home}/{action=Index}/{id?}'.
    
        
        
        
        :param app: The .
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseMvcWithDefaultRoute(IApplicationBuilder app)
    

