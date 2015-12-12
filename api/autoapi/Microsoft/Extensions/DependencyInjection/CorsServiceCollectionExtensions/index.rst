

CorsServiceCollectionExtensions Class
=====================================



.. contents:: 
   :local:



Summary
-------

The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` extensions for enabling CORS support.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class CorsServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/cors/src/Microsoft.AspNet.Cors/CorsServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Add services needed to support CORS to the given ``serviceCollection``.
    
        
        
        
        :param serviceCollection: The service collection to which CORS services are added.
        
        :type serviceCollection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The updated <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddCors(IServiceCollection serviceCollection)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.CorsServiceCollectionExtensions.AddCors(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Cors.Infrastructure.CorsOptions>)
    
        
    
        Add services needed to support CORS to the given ``serviceCollection``.
    
        
        
        
        :param serviceCollection: The service collection to which CORS services are added.
        
        :type serviceCollection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configure: A delegate which is run to configure the services.
        
        :type configure: System.Action{Microsoft.AspNet.Cors.Infrastructure.CorsOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The updated <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddCors(IServiceCollection serviceCollection, Action<CorsOptions> configure)
    

