

RedisCacheServicesExtensions Class
==================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up Redis distributed cache related services in an 
:any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.RedisCacheServicesExtensions`








Syntax
------

.. code-block:: csharp

   public class RedisCacheServicesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/caching/src/Microsoft.Extensions.Caching.Redis/RedisCacheServicesExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.RedisCacheServicesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.RedisCacheServicesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.RedisCacheServicesExtensions.AddRedisCache(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds Redis distributed caching services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddRedisCache(IServiceCollection services)
    

