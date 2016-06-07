

LocalizationServiceCollectionExtensions Class
=============================================






Extension methods for setting up localization services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Localization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class LocalizationServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds services required for application localization.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddLocalization(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.Extensions.Localization.LocalizationOptions>)
    
        
    
        
        Adds services required for application localization.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: 
            An :any:`System.Action\`1` to configure the :any:`Microsoft.Extensions.Localization.LocalizationOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.Extensions.Localization.LocalizationOptions<Microsoft.Extensions.Localization.LocalizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddLocalization(IServiceCollection services, Action<LocalizationOptions> setupAction)
    

