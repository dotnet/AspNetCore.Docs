

MvcApplicationBuilderExtensions Class
=====================================






Extension methods for :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add MVC to the request execution pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcApplicationBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds MVC to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` request execution pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMvc(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc(Microsoft.AspNetCore.Builder.IApplicationBuilder, System.Action<Microsoft.AspNetCore.Routing.IRouteBuilder>)
    
        
    
        
        Adds MVC to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` request execution pipeline.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param configureRoutes: A callback to configure MVC routes.
        
        :type configureRoutes: System.Action<System.Action`1>{Microsoft.AspNetCore.Routing.IRouteBuilder<Microsoft.AspNetCore.Routing.IRouteBuilder>}
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMvc(IApplicationBuilder app, Action<IRouteBuilder> configureRoutes)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds MVC to the :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` request execution pipeline
        with a default route named 'default' and the following template:
        '{controller=Home}/{action=Index}/{id?}'.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseMvcWithDefaultRoute(IApplicationBuilder app)
    

