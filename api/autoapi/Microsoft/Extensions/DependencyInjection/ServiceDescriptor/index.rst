

ServiceDescriptor Class
=======================





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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor`








Syntax
------

.. code-block:: csharp

    [DebuggerDisplay("Lifetime = {Lifetime}, ServiceType = {ServiceType}, ImplementationType = {ImplementationType}")]
    public class ServiceDescriptor








.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor

Properties
----------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ImplementationFactory
    
        
        :rtype: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        .. code-block:: csharp
    
            public Func<IServiceProvider, object> ImplementationFactory
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ImplementationInstance
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object ImplementationInstance
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ImplementationType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ImplementationType
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Lifetime
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            public ServiceLifetime Lifetime
            {
                get;
            }
    
    .. dn:property:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceType
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
            public Type ServiceType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceDescriptor(System.Type, System.Func<System.IServiceProvider, System.Object>, Microsoft.Extensions.DependencyInjection.ServiceLifetime)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` with the specified <em>factory</em>.
    
        
    
        
        :param serviceType: The :any:`System.Type` of the service.
        
        :type serviceType: System.Type
    
        
        :param factory: A factory used for creating service instances.
        
        :type factory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        :param lifetime: The :any:`Microsoft.Extensions.DependencyInjection.ServiceLifetime` of the service.
        
        :type lifetime: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime lifetime)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceDescriptor(System.Type, System.Object)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` with the specified <em>instance</em>
        as a :dn:field:`Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton`\.
    
        
    
        
        :param serviceType: The :any:`System.Type` of the service.
        
        :type serviceType: System.Type
    
        
        :param instance: The instance implementing the service.
        
        :type instance: System.Object
    
        
        .. code-block:: csharp
    
            public ServiceDescriptor(Type serviceType, object instance)
    
    .. dn:constructor:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceDescriptor(System.Type, System.Type, Microsoft.Extensions.DependencyInjection.ServiceLifetime)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.Extensions.DependencyInjection.ServiceDescriptor` with the specified <em>implementationType</em>.
    
        
    
        
        :param serviceType: The :any:`System.Type` of the service.
        
        :type serviceType: System.Type
    
        
        :param implementationType: The :any:`System.Type` implementing the service.
        
        :type implementationType: System.Type
    
        
        :param lifetime: The :any:`Microsoft.Extensions.DependencyInjection.ServiceLifetime` of the service.
        
        :type lifetime: Microsoft.Extensions.DependencyInjection.ServiceLifetime
    
        
        .. code-block:: csharp
    
            public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Describe(System.Type, System.Func<System.IServiceProvider, System.Object>, Microsoft.Extensions.DependencyInjection.ServiceLifetime)
    
        
    
        
        :type serviceType: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
    
        
        :type lifetime: Microsoft.Extensions.DependencyInjection.ServiceLifetime
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Describe(Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Describe(System.Type, System.Type, Microsoft.Extensions.DependencyInjection.ServiceLifetime)
    
        
    
        
        :type serviceType: System.Type
    
        
        :type implementationType: System.Type
    
        
        :type lifetime: Microsoft.Extensions.DependencyInjection.ServiceLifetime
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Describe(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped(System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type service: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Scoped(Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped(System.Type, System.Type)
    
        
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Scoped(Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped<TService>(System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Scoped<TService>(Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped<TService, TImplementation>()
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Scoped<TService, TImplementation>()where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Scoped<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Scoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton(System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type serviceType: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton(System.Type, System.Object)
    
        
    
        
        :type serviceType: System.Type
    
        
        :type implementationInstance: System.Object
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton(Type serviceType, object implementationInstance)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton(System.Type, System.Type)
    
        
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton(Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton<TService>(System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton<TService>(Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton<TService>(TService)
    
        
    
        
        :type implementationInstance: TService
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton<TService>(TService implementationInstance)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton<TService, TImplementation>()
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton<TService, TImplementation>()where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Singleton<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Singleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient(System.Type, System.Func<System.IServiceProvider, System.Object>)
    
        
    
        
        :type service: System.Type
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, System.Object<System.Object>}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Transient(Type service, Func<IServiceProvider, object> implementationFactory)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient(System.Type, System.Type)
    
        
    
        
        :type service: System.Type
    
        
        :type implementationType: System.Type
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Transient(Type service, Type implementationType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient<TService>(System.Func<System.IServiceProvider, TService>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TService}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Transient<TService>(Func<IServiceProvider, TService> implementationFactory)where TService : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient<TService, TImplementation>()
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Transient<TService, TImplementation>()where TService : class where TImplementation : class, TService
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceDescriptor.Transient<TService, TImplementation>(System.Func<System.IServiceProvider, TImplementation>)
    
        
    
        
        :type implementationFactory: System.Func<System.Func`2>{System.IServiceProvider<System.IServiceProvider>, TImplementation}
        :rtype: Microsoft.Extensions.DependencyInjection.ServiceDescriptor
    
        
        .. code-block:: csharp
    
            public static ServiceDescriptor Transient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)where TService : class where TImplementation : class, TService
    

