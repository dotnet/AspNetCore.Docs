

AuthorizationServiceCollectionExtensions Class
==============================================



.. contents:: 
   :local:



Summary
-------

Extension methods for setting up authorization services in an :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class AuthorizationServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authorization/AuthorizationServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds authorization services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddAuthorization(IServiceCollection services)
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Authorization.AuthorizationOptions>)
    
        
    
        Adds authorization services to the specified :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection`\.
    
        
        
        
        :param services: The  to add services to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param configure: An action delegate to configure the provided .
        
        :type configure: System.Action{Microsoft.AspNet.Authorization.AuthorizationOptions}
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IServiceCollection AddAuthorization(IServiceCollection services, Action<AuthorizationOptions> configure)
    

