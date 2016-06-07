

AuthenticationServiceCollectionExtensions Class
===============================================






Extension methods for setting up authentication services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Authentication

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class AuthenticationServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions
    :hidden:

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Adds authentication services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\. 
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAuthentication(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>)
    
        
    
        
        Adds authentication services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\. 
    
        
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param configureOptions: An action delegate to configure the provided :any:`Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions`\.
        
        :type configureOptions: System.Action<System.Action`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` so that additional calls can be chained.
    
        
        .. code-block:: csharp
    
            public static IServiceCollection AddAuthentication(IServiceCollection services, Action<SharedAuthenticationOptions> configureOptions)
    

