

RoutingServices Class
=====================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.RoutingServices`








Syntax
------

.. code-block:: csharp

   public class RoutingServices





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/routing/src/Microsoft.AspNet.Routing/RoutingServices.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.RoutingServices

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.RoutingServices
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RoutingServices.AddRouting(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddRouting(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RoutingServices.AddRouting(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Routing.RouteOptions>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type configureOptions: System.Action{Microsoft.AspNet.Routing.RouteOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddRouting(IServiceCollection services, Action<RouteOptions> configureOptions)
    

