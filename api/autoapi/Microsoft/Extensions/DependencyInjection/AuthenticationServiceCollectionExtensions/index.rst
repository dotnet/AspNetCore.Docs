

AuthenticationServiceCollectionExtensions Class
===============================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up authentication services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class AuthenticationServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication/AuthenticationServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds authentication services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddAuthentication(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthenticationServiceCollectionExtensions.AddAuthentication(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>)
    
        
    
        Adds authentication services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddAuthentication(IServiceCollection services, Action<SharedAuthenticationOptions> configureOptions)
    

