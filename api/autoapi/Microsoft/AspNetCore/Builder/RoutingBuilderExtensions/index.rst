

RoutingBuilderExtensions Class
==============================






Extension methods for adding the :any:`Microsoft.AspNetCore.Builder.RouterMiddleware` middleware to an :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.RoutingBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class RoutingBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.RoutingBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.RoutingBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.RoutingBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.RoutingBuilderExtensions.UseRouter(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Routing.IRouter)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Builder.RouterMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` with the specified :any:`Microsoft.AspNetCore.Routing.IRouter`\.
    
        
    
        
        :param builder: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type builder: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param router: The :any:`Microsoft.AspNetCore.Routing.IRouter` to use for routing requests.
        
        :type router: Microsoft.AspNetCore.Routing.IRouter
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseRouter(this IApplicationBuilder builder, IRouter router)
    

