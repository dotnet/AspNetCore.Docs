

OptionsServiceCollectionExtensions Class
========================================






Extension methods for adding options services to the DI container.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.Options

----

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








.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds services required for using options.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddOptions(this IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<TOptions>)
    
        
    
        
        Registers an action used to configure a particular type of options.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param configureOptions: The action used to configure the options.
        
        :type configureOptions: System.Action<System.Action`1>{TOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Configure<TOptions>(this IServiceCollection services, Action<TOptions> configureOptions)where TOptions : class
    

