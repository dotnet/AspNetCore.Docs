

RoutingBuilderExtensions Class
==============================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding the :any:`Microsoft.AspNet.Builder.RouterMiddleware` middleware to an :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.RoutingBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class RoutingBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/BuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.RoutingBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.RoutingBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.RoutingBuilderExtensions.UseRouter(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Routing.IRouter)
    
        
    
        Adds a :any:`Microsoft.AspNet.Builder.RouterMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder` with the specified :any:`Microsoft.AspNet.Routing.IRouter`\.
    
        
        
        
        :param builder: The  to add the middleware to.
        
        :type builder: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param router: The  to use for routing requests.
        
        :type router: Microsoft.AspNet.Routing.IRouter
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseRouter(IApplicationBuilder builder, IRouter router)
    

