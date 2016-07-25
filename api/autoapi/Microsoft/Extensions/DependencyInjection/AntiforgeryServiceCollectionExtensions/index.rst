

AntiforgeryServiceCollectionExtensions Class
============================================






Extension methods for setting up antiforgery services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Antiforgery

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class AntiforgeryServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions.AddAntiforgery(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds antiforgery services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAntiforgery(this IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AntiforgeryServiceCollectionExtensions.AddAntiforgery(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>)
    
        
    
        
        Adds antiforgery services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions<Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAntiforgery(this IServiceCollection services, Action<AntiforgeryOptions> setupAction)
    

