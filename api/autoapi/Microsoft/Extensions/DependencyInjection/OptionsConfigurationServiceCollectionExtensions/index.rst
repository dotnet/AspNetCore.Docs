

OptionsConfigurationServiceCollectionExtensions Class
=====================================================





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
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Configure<TOptions>(IServiceCollection services, IConfiguration config)where TOptions : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.Configuration.IConfiguration, System.Boolean)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
    
        
        :type trackConfigChanges: System.Boolean
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Configure<TOptions>(IServiceCollection services, IConfiguration config, bool trackConfigChanges)where TOptions : class
    

