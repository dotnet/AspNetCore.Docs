

OptionsServiceCollectionExtensions Class
========================================





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
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddOptions(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure<TOptions>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<TOptions>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type configureOptions: System.Action<System.Action`1>{TOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Configure<TOptions>(IServiceCollection services, Action<TOptions> configureOptions)where TOptions : class
    

