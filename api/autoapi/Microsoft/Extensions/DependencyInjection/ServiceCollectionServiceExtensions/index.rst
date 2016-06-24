

ServiceCollectionServiceExtensions Class
========================================






Extension methods for adding services to an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions`








Syntax
------

.. code-block:: csharp

    public class ServiceCollectionServiceExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        Adds a scoped service of the type specified in <em>serviceType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register and the implementation to use.
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        Adds a scoped service of the type specified in <em>serviceType</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        Adds a scoped service of the type specified in <em>serviceType</em> with an
        implementation of the type specified in <em>implementationType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationType: The implementation type of the service.
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a scoped service of the type specified in <em>TService</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped<TService>(this IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        Adds a scoped service of the type specified in <em>TService</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a scoped service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddScoped<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        Adds a scoped service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> using the
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        Adds a singleton service of the type specified in <em>serviceType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register and the implementation to use.
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        Adds a singleton service of the type specified in <em>serviceType</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Object)
    
        
    
        
        Adds a singleton service of the type specified in <em>serviceType</em> with an
        instance specified in <em>implementationInstance</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationInstance: The instance of the service.
        
        :type implementationInstance: System.Object
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, object implementationInstance)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        Adds a singleton service of the type specified in <em>serviceType</em> with an
        implementation of the type specified in <em>implementationType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationType: The implementation type of the service.
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a singleton service of the type specified in <em>TService</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton<TService>(this IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        Adds a singleton service of the type specified in <em>TService</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, TService)
    
        
    
        
        Adds a singleton service of the type specified in <em>TService</em> with an
        instance specified in <em>implementationInstance</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationInstance: The instance of the service.
        
        :type implementationInstance: TService
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, TService implementationInstance)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a singleton service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddSingleton<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        Adds a singleton service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> using the
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        Adds a transient service of the type specified in <em>serviceType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register and the implementation to use.
        
        :type serviceType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        Adds a transient service of the type specified in <em>serviceType</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        Adds a transient service of the type specified in <em>serviceType</em> with an
        implementation of the type specified in <em>implementationType</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param serviceType: The type of the service to register.
        
        :type serviceType: System.Type
    
        
        :param implementationType: The implementation type of the service.
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a transient service of the type specified in <em>TService</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient<TService>(this IServiceCollection services)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        Adds a transient service of the type specified in <em>TService</em> with a
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds a transient service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceCollectionServiceExtensions.AddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        Adds a transient service of the type specified in <em>TService</em> with an
        implementation type specified in <em>TImplementation</em> using the
        factory specified in <em>implementationFactory</em> to the
        specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the service to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param implementationFactory: The factory that creates the service.
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    

