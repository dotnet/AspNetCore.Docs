

OptionsConfigurationServiceCollectionExtensions Class
=====================================================






Extension methods for adding configuration related options services to the DI container.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Options.ConfigurationExtensions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class OptionsConfigurationServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.Configuration.IConfiguration)
    
        
    
        
        Registers a configuration instance which TOptions will bind against.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param config: The configuration being bound.
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Configure<TOptions>(this IServiceCollection services, IConfiguration config)where TOptions : class
    

