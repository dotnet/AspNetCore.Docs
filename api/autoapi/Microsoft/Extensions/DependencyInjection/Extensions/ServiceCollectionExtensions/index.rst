

ServiceCollectionExtensions Class
=================================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/dependencyinjection/blob/master/src/Microsoft.Extensions.DependencyInjection.Abstractions/Extensions/ServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        Adds the specified ``descriptor`` to the ``collection``.
    
        
        
        
        :param collection: The .
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptor: The .
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to the current instance of <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection Add(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Add(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        Adds a sequence of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` to the ``collection``.
    
        
        
        
        :param collection: The .
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptors: The  of s to add.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.Extensions.DependencyInjection.ServiceDescriptor}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to the current instance of <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection Add(IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.Replace(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        Removes the first service in :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` with the same service type
        as ``descriptor`` and adds <paramef name="descriptor" /> to the collection.
    
        
        
        
        :param collection: The .
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptor: The  to replace with.
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static IServiceCollection Replace(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAdd(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        Adds the specified ``descriptor`` to the ``collection`` if the
        service type hasn't been already registered.
    
        
        
        
        :param collection: The .
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptor: The .
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
           public static void TryAdd(IServiceCollection collection, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAdd(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        Adds the specified ``descriptors`` to the ``collection`` if the
        service type hasn't been already registered.
    
        
        
        
        :param collection: The .
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptors: The s.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.Extensions.DependencyInjection.ServiceDescriptor}
    
        
        .. code-block:: csharp
    
           public static void TryAdd(IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection, Microsoft.Extensions.DependencyInjection.ServiceDescriptor)
    
        
    
        Adds a :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` if an existing descriptor with the same 
        :dn:prop:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType` and an implementation that does not already exist
        in ``services..``.
    
        
        
        
        :param services: The .
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptor: The .
        
        :type descriptor: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
           public static void TryAddEnumerable(IServiceCollection services, ServiceDescriptor descriptor)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddEnumerable(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Collections.Generic.IEnumerable<Microsoft.Extensions.DependencyInjection.ServiceDescriptor>)
    
        
    
        Adds the specified :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`\s if an existing descriptor with the same 
        :dn:prop:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType` and an implementation that does not already exist
        in ``services..``.
    
        
        
        
        :param services: The .
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param descriptors: The s.
        
        :type descriptors: System.Collections.Generic.IEnumerable{Microsoft.Extensions.DependencyInjection.ServiceDescriptor}
    
        
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
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
    
        
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
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
    
        
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
        
        
        :type implementationFactory: System.Func{System.IServiceProvider,System.Object}
    
        
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
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.Extensions.ServiceCollectionExtensions.TryAddTransient<TService, TImplementation>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
        
        
        :type collection: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public static void TryAddTransient<TService, TImplementation>(IServiceCollection collection)where TService : class where TImplementation : class, TService
    

