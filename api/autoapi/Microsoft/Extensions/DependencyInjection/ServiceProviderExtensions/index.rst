

ServiceProviderExtensions Class
===============================



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





GitHub
------

`View on GitHub <https://github.com/aspnet/dependencyinjection/blob/master/src/Microsoft.Extensions.DependencyInjection.Abstractions/ServiceProviderExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetRequiredService(System.IServiceProvider, System.Type)
    
        
    
        Get service of type ``serviceType`` from the :any:`System.IServiceProvider`\.
    
        
        
        
        :param provider: The  to retrieve the service object from.
        
        :type provider: System.IServiceProvider
        
        
        :param serviceType: An object that specifies the type of service object to get.
        
        :type serviceType: System.Type
        :rtype: System.Object
        :return: A service object of type <paramref name="serviceType" />.
    
        
        .. code-block:: csharp
    
           public static object GetRequiredService(IServiceProvider provider, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetRequiredService<T>(System.IServiceProvider)
    
        
    
        Get service of type ``T`` from the :any:`System.IServiceProvider`\.
    
        
        
        
        :param provider: The  to retrieve the service object from.
        
        :type provider: System.IServiceProvider
        :rtype: {T}
        :return: A service object of type <typeparamref name="T" />.
    
        
        .. code-block:: csharp
    
           public static T GetRequiredService<T>(IServiceProvider provider)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetService<T>(System.IServiceProvider)
    
        
    
        Get service of type ``T`` from the :any:`System.IServiceProvider`\.
    
        
        
        
        :param provider: The  to retrieve the service object from.
        
        :type provider: System.IServiceProvider
        :rtype: {T}
        :return: A service object of type <typeparamref name="T" /> or null if there is no such service.
    
        
        .. code-block:: csharp
    
           public static T GetService<T>(IServiceProvider provider)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetServices(System.IServiceProvider, System.Type)
    
        
    
        Get an enumeration of services of type ``serviceType`` from the :any:`System.IServiceProvider`\.
    
        
        
        
        :param provider: The  to retrieve the services from.
        
        :type provider: System.IServiceProvider
        
        
        :param serviceType: An object that specifies the type of service object to get.
        
        :type serviceType: System.Type
        :rtype: System.Collections.Generic.IEnumerable{System.Object}
        :return: An enumeration of services of type <paramref name="serviceType" />.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<object> GetServices(IServiceProvider provider, Type serviceType)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.ServiceProviderExtensions.GetServices<T>(System.IServiceProvider)
    
        
    
        Get an enumeration of services of type ``T`` from the :any:`System.IServiceProvider`\.
    
        
        
        
        :param provider: The  to retrieve the services from.
        
        :type provider: System.IServiceProvider
        :rtype: System.Collections.Generic.IEnumerable{{T}}
        :return: An enumeration of services of type <typeparamref name="T" />.
    
        
        .. code-block:: csharp
    
           public static IEnumerable<T> GetServices<T>(IServiceProvider provider)
    

