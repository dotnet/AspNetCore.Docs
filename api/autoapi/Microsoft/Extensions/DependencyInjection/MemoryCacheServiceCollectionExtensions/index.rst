

MemoryCacheServiceCollectionExtensions Class
============================================






Extension methods for setting up memory cache related services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Caching.Memory

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class MemoryCacheServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddDistributedMemoryCache(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a default implementation of :any:`Microsoft.Extensions.Caching.Distributed.IDistributedCache` that stores items in memory
        to the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\. Frameworks that require a distributed cache to work
        can safely add this dependency as part of their dependency list to ensure that there is at least
        one implementation available.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddDistributedMemoryCache(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a non distributed in memory implementation of :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` to the
        :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddMemoryCache(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MemoryCacheServiceCollectionExtensions.AddMemoryCache(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>)
    
        
    
        
        Adds a non distributed in memory implementation of :any:`Microsoft.Extensions.Caching.Memory.IMemoryCache` to the
        :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: 
            The :any:`System.Action\`1` to configure the provided :any:`Microsoft.Extensions.Caching.Memory.MemoryCacheOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Caching.Memory.MemoryCacheOptions<Microsoft.Extensions.Caching.Memory.MemoryCacheOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddMemoryCache(IServiceCollection services, Action<MemoryCacheOptions> setupAction)
    

