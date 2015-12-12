

ServiceCollectionExtensions Class
=================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class ServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/dependencyinjection/blob/master/src/Microsoft.Extensions.DependencyInjection.Abstractions/ServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddInstance(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Object)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationInstance: System.Object
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddInstance(IServiceCollection collection, Type service, object implementationInstance)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddInstance<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, TService)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationInstance: {TService}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddInstance<TService>(IServiceCollection services, TService implementationInstance)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped(IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped<TService>(IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TService}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped<TService, TImplementation>(IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddScoped<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TImplementation}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddScoped<TService, TImplementation>(IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton(IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton<TService>(IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TService}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton<TService, TImplementation>(IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddSingleton<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TImplementation}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSingleton<TService, TImplementation>(IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient(IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type service: System.Type
        
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient<TService>(IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TService}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient<TService, TImplementation>(IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions.AddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
        
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,{TImplementation}}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddTransient<TService, TImplementation>(IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    

