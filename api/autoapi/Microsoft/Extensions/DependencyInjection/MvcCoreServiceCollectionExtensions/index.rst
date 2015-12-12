

MvcCoreServiceCollectionExtensions Class
========================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/mvc/blob/master/src/Microsoft.AspNet.Mvc.Core/DependencyInjection/MvcCoreServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions.AddMvcCore(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddMvcCore(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.MvcCoreServiceCollectionExtensions.AddMvcCore(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Mvc.MvcOptions>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type setupAction: System.Action{Microsoft.AspNet.Mvc.MvcOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IMvcCoreBuilder
    
        
        .. code-block:: csharp
    
           public static IMvcCoreBuilder AddMvcCore(IServiceCollection services, Action<MvcOptions> setupAction)
    

