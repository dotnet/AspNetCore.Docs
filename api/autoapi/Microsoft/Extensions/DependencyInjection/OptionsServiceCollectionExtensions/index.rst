

OptionsServiceCollectionExtensions Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class OptionsServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/options/src/Microsoft.Extensions.OptionsModel/OptionsServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddOptions(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.ConfigureOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Object)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type configureInstance: System.Object
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection ConfigureOptions(IServiceCollection services, object configureInstance)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.ConfigureOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type configureType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection ConfigureOptions(IServiceCollection services, Type configureType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.ConfigureOptions<TSetup>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection ConfigureOptions<TSetup>(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.Configuration.IConfiguration)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type config: Microsoft.Extensions.Configuration.IConfiguration
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection Configure<TOptions>(IServiceCollection services, IConfiguration config)where TOptions : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<TOptions>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type setupAction: System.Action{{TOptions}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection Configure<TOptions>(IServiceCollection services, Action<TOptions> setupAction)where TOptions : class
    

