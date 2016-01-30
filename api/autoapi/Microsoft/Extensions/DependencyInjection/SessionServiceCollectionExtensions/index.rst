

SessionServiceCollectionExtensions Class
========================================



.. contents:: 
   :local:



Summary
-------

Extension methods for adding session services to the DI container.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class SessionServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/session/blob/master/src/Microsoft.AspNet.Session/SessionServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds services required for application session state.
    
        
        
        
        :param services: The  to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSession(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Session.SessionOptions>)
    
        
    
        Adds services required for application session state.
    
        
        
        
        :param services: The  to add the services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configure: The session options to configure the middleware with.
        
        :type configure: System.Action{Microsoft.AspNet.Session.SessionOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The <see cref="T:Microsoft.Extensions.DependencyInjection.IServiceCollection" />.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddSession(IServiceCollection services, Action<SessionOptions> configure)
    

