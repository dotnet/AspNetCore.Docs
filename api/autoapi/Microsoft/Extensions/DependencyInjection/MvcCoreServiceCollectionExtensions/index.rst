

MvcCoreServiceCollectionExtensions Class
========================================






Extension methods for setting up essential MVC services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc.Core

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcCoreServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions.AddMvcCore(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds essential MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: An :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` that can be used to further configure the MVC services.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddMvcCore(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions.AddMvcCore(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Adds essential MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
        :return: An :any:`Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder` that can be used to further configure the MVC services.
    
        
        .. code-block:: csharp
    
            public static IMvcCoreBuilder AddMvcCore(IServiceCollection services, Action<MvcOptions> setupAction)
    

