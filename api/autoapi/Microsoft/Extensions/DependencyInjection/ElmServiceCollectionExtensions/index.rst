

ElmServiceCollectionExtensions Class
====================================






Extension methods for setting up Elm services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Diagnostics.Elm

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class ElmServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions.AddElm(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds error logging middleware services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddElm(this IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ElmServiceCollectionExtensions.AddElm(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>)
    
        
    
        
        Adds error logging middleware services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An :any:`System.Action\`1` to configure the provided :any:`Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions<Microsoft.AspNetCore.Diagnostics.Elm.ElmOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddElm(this IServiceCollection services, Action<ElmOptions> setupAction)
    

