

SessionServiceCollectionExtensions Class
========================================






Extension methods for adding session services to the DI container.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Session

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class SessionServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds services required for application session state.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSession(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Builder.SessionOptions>)
    
        
    
        
        Adds services required for application session state.
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param configure: The session options to configure the middleware with.
        
        :type configure: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.SessionOptions<Microsoft.AspNetCore.Builder.SessionOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddSession(IServiceCollection services, Action<SessionOptions> configure)
    

