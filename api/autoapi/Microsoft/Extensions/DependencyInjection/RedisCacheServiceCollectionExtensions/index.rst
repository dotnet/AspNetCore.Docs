

RedisCacheServiceCollectionExtensions Class
===========================================






Extension methods for setting up Redis distributed cache related services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Caching.Redis

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.RedisCacheServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class RedisCacheServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.RedisCacheServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.RedisCacheServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.RedisCacheServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RedisCacheServiceCollectionExtensions.AddDistributedRedisCache(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>)
    
        
    
        
        Adds Redis distributed caching services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided 
            :any:`Microsoft.Extensions.Caching.Redis.RedisCacheOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Caching.Redis.RedisCacheOptions<Microsoft.Extensions.Caching.Redis.RedisCacheOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddDistributedRedisCache(IServiceCollection services, Action<RedisCacheOptions> setupAction)
    

