

MemoryCacheServicesExtensions Class
===================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up memory cache related services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MemoryCacheServicesExtensions`








Syntax
------

.. code-block:: csharp

   public class MemoryCacheServicesExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/caching/blob/master/src/Microsoft.Extensions.Caching.Memory/MemoryCacheServicesExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MemoryCacheServicesExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MemoryCacheServicesExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MemoryCacheServicesExtensions.AddCaching(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds memory caching services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddCaching(IServiceCollection services)
    

