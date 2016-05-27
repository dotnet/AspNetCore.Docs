

ServiceProviderExtensions Class
===============================






Extension methods for getting services from an :any:`System.IServiceProvider`\.


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
* :dn:cls:`Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions`








Syntax
------

.. code-block:: csharp

    public class ServiceProviderExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetRequiredService(System.IServiceProvider, System.Type)
    
        
    
        
        Get service of type <em>serviceType</em> from the :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The :any:`System.IServiceProvider` to retrieve the service object from.
        
        :type provider: System.IServiceProvider
    
        
        :param serviceType: An object that specifies the type of service object to get.
        
        :type serviceType: System.Type
        :rtype: System.Object
        :return: A service object of type <em>serviceType</em>.
    
        
        .. code-block:: csharp
    
            public static object GetRequiredService(IServiceProvider provider, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetRequiredService<T>(System.IServiceProvider)
    
        
    
        
        Get service of type <em>T</em> from the :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The :any:`System.IServiceProvider` to retrieve the service object from.
        
        :type provider: System.IServiceProvider
        :rtype: T
        :return: A service object of type <em>T</em>.
    
        
        .. code-block:: csharp
    
            public static T GetRequiredService<T>(IServiceProvider provider)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetService<T>(System.IServiceProvider)
    
        
    
        
        Get service of type <em>T</em> from the :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The :any:`System.IServiceProvider` to retrieve the service object from.
        
        :type provider: System.IServiceProvider
        :rtype: T
        :return: A service object of type <em>T</em> or null if there is no such service.
    
        
        .. code-block:: csharp
    
            public static T GetService<T>(IServiceProvider provider)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetServices(System.IServiceProvider, System.Type)
    
        
    
        
        Get an enumeration of services of type <em>serviceType</em> from the :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The :any:`System.IServiceProvider` to retrieve the services from.
        
        :type provider: System.IServiceProvider
    
        
        :param serviceType: An object that specifies the type of service object to get.
        
        :type serviceType: System.Type
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.Object<System.Object>}
        :return: An enumeration of services of type <em>serviceType</em>.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<object> GetServices(IServiceProvider provider, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetServices<T>(System.IServiceProvider)
    
        
    
        
        Get an enumeration of services of type <em>T</em> from the :any:`System.IServiceProvider`\.
    
        
    
        
        :param provider: The :any:`System.IServiceProvider` to retrieve the services from.
        
        :type provider: System.IServiceProvider
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{T}
        :return: An enumeration of services of type <em>T</em>.
    
        
        .. code-block:: csharp
    
            public static IEnumerable<T> GetServices<T>(IServiceProvider provider)
    

