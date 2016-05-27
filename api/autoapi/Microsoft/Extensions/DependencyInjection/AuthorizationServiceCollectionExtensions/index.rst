

AuthorizationServiceCollectionExtensions Class
==============================================






Extension methods for setting up authorization services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class AuthorizationServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds authorization services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\. 
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAuthorization(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Authorization.AuthorizationOptions>)
    
        
    
        
        Adds authorization services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\. 
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param configure: An action delegate to configure the provided :any:`Microsoft.AspNetCore.Authorization.AuthorizationOptions`\.
        
        :type configure: System.Action<System.Action`1>{Microsoft.AspNetCore.Authorization.AuthorizationOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAuthorization(IServiceCollection services, Action<AuthorizationOptions> configure)
    

