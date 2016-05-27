

ServiceCollectionExtensions Class
=================================





Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection.Extensions`
Assemblies
    * Microsoft.Extensions.DependencyInjection.Abstractions

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class ServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        Adds the specified <em>descriptor</em> to the <em>collection</em>.
    
        
    
        
        :param collection: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptor: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\.
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to the current instance of :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Add(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        
        Adds a sequence of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` to the <em>collection</em>.
    
        
    
        
        :param collection: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptors: The :any:`System.Collections.Generic.IEnumerable\`1` of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\s to add.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to the current instance of :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Add(IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Replace(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        Removes the first service in :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` with the same service type
        as <em>descriptor</em> and adds <paramef name="descriptor"></paramef> to the collection.
    
        
    
        
        :param collection: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptor: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` to replace with.
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static IServiceCollection Replace(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAdd(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        Adds the specified <em>descriptor</em> to the <em>collection</em> if the
        service type hasn't been already registered.
    
        
    
        
        :param collection: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptor: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\.
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static void TryAdd(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAdd(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        
        Adds the specified <em>descriptors</em> to the <em>collection</em> if the
        service type hasn't been already registered.
    
        
    
        
        :param collection: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptors: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\s.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>}
    
        
        .. code-block:: csharp
    
            public static void TryAdd(IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        
        Adds a :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` if an existing descriptor with the same
        :dn:prop:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType` and an implementation that does not already exist
        in <em>services..</em>.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptor: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\.
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static void TryAddEnumerable(IServiceCollection services, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        
        Adds the specified :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\s if an existing descriptor with the same
        :dn:prop:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType` and an implementation that does not already exist
        in <em>services..</em>.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param descriptors: The :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\s.
        
        :type descriptors: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.Extensions.DependencyInjection.ServiceDescriptor<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>}
    
        
        .. code-block:: csharp
    
            public static void TryAddEnumerable(IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped(IServiceCollection collection, Type service)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped<TService>(IServiceCollection collection)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddScoped<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddScoped<TService, TImplementation>(IServiceCollection collection)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton(IServiceCollection collection, Type service)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton<TService>(IServiceCollection collection)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, TService)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type instance: TService
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton<TService>(IServiceCollection collection, TService instance)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddSingleton<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddSingleton<TService, TImplementation>(IServiceCollection collection)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient(IServiceCollection collection, Type service)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient(IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Type, System.Type)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient(IServiceCollection collection, Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient<TService>(IServiceCollection collection)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient<TService>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient<TService>(IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public static void TryAddTransient<TService, TImplementation>(IServiceCollection collection)where TService : class where TImplementation : class, TService
    

