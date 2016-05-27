

RoutingServiceCollectionExtensions Class
========================================






Contains extension methods to :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Routing

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class RoutingServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions.AddRouting(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds services required for routing requests.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddRouting(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions.AddRouting(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Routing.RouteOptions>)
    
        
    
        
        Adds services required for routing requests.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param configureOptions: The routing options to configure the middleware with.
        
        :type configureOptions: System.Action<System.Action`1>{Microsoft.AspNetCore.Routing.RouteOptions<Microsoft.AspNetCore.Routing.RouteOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddRouting(IServiceCollection services, Action<RouteOptions> configureOptions)
    

