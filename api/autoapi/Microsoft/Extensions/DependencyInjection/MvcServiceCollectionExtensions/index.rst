

MvcServiceCollectionExtensions Class
====================================






Extension methods for setting up MVC services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Mvc

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class MvcServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: An :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` that can be used to further configure the MVC services.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddMvc(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcServiceCollectionExtensions.AddMvc(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Mvc.MvcOptions>)
    
        
    
        
        Adds MVC services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.Mvc.MvcOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Mvc.MvcOptions<Microsoft.AspNetCore.Mvc.MvcOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcBuilder
        :return: An :any:`Microsoft.Extensions.DependencyInjection.IMvcBuilder` that can be used to further configure the MVC services.
    
        
        .. code-block:: csharp
    
            public static IMvcBuilder AddMvc(IServiceCollection services, Action<MvcOptions> setupAction)
    

