

ActivatorUtilities Class
========================






Helper code for the various activator services.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ActivatorUtilities`








Syntax
------

.. code-block:: csharp

    public class ActivatorUtilities








.. dn:class:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateFactory(System.Type, System.Type[])
    
        
    
        
        Create a delegate that will instantiate a type with constructor arguments provided directly
        and/or from an :any:`System.IServiceProvider`\.
    
        
    
        
        :param instanceType: The type to activate
        
        :type instanceType: System.Type
    
        
        :param argumentTypes: 
            The types of objects, in order, that will be passed to the returned function as its second parameter
        
        :type argumentTypes: System.Type<System.Type>[]
        :rtype: Microsoft.Extensions.DependencyInjection.ObjectFactory
        :return: 
            A factory that will instantiate instanceType using an :any:`System.IServiceProvider`
            and an argument array containing objects matching the types defined in argumentTypes
    
        
        .. code-block:: csharp
    
            public static ObjectFactory CreateFactory(Type instanceType, Type[] argumentTypes)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance(System.IServiceProvider, System.Type, System.Object[])
    
        
    
        
        Instantiate a type with constructor arguments provided directly and/or from an :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The service provider used to resolve dependencies
        
        :type provider: System.IServiceProvider
    
        
        :param instanceType: The type to activate
        
        :type instanceType: System.Type
    
        
        :param parameters: Constructor arguments not provided by the <em>provider</em>.
        
        :type parameters: System.Object<System.Object>[]
        :rtype: System.Object
        :return: An activated object of type instanceType
    
        
        .. code-block:: csharp
    
            public static object CreateInstance(IServiceProvider provider, Type instanceType, params object[] parameters)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities.CreateInstance<T>(System.IServiceProvider, System.Object[])
    
        
    
        
        Instantiate a type with constructor arguments provided directly and/or from an :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The service provider used to resolve dependencies
        
        :type provider: System.IServiceProvider
    
        
        :param parameters: Constructor arguments not provided by the <em>provider</em>.
        
        :type parameters: System.Object<System.Object>[]
        :rtype: T
        :return: An activated object of type T
    
        
        .. code-block:: csharp
    
            public static T CreateInstance<T>(IServiceProvider provider, params object[] parameters)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetServiceOrCreateInstance(System.IServiceProvider, System.Type)
    
        
    
        
        Retrieve an instance of the given type from the service provider. If one is not found then instantiate it directly.
    
        
    
        
        :param provider: The service provider
        
        :type provider: System.IServiceProvider
    
        
        :param type: The type of the service
        
        :type type: System.Type
        :rtype: System.Object
        :return: The resolved service or created instance
    
        
        .. code-block:: csharp
    
            public static object GetServiceOrCreateInstance(IServiceProvider provider, Type type)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetServiceOrCreateInstance<T>(System.IServiceProvider)
    
        
    
        
        Retrieve an instance of the given type from the service provider. If one is not found then instantiate it directly.
    
        
    
        
        :param provider: The service provider used to resolve dependencies
        
        :type provider: System.IServiceProvider
        :rtype: T
        :return: The resolved service or created instance
    
        
        .. code-block:: csharp
    
            public static T GetServiceOrCreateInstance<T>(IServiceProvider provider)
    

