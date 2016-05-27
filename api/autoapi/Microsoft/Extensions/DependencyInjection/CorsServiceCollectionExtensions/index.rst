

CorsServiceCollectionExtensions Class
=====================================






Extension methods for setting up cross-origin resource sharing services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Cors

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class CorsServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds cross-origin resource sharing services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddCors(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>)
    
        
    
        
        Adds cross-origin resource sharing services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddCors(IServiceCollection services, Action<CorsOptions> setupAction)
    

