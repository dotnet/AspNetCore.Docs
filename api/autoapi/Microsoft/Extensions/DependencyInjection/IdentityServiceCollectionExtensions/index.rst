

IdentityServiceCollectionExtensions Class
=========================================



.. contents:: 
   :local:



Summary
-------

Contains extension methods to :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` for configuring identity services.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

   public class IdentityServiceCollectionExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IdentityServiceCollectionExtensions.cs>`_





.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions

Methods
-------

.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity<TUser, TRole>(Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Adds the default identity system configuration for the specified User and Role types.
    
        
        
        
        :param services: The services available in the application.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> for creating and configuring the identity system.
    
        
        .. code-block:: csharp
    
           public static IdentityBuilder AddIdentity<TUser, TRole>(IServiceCollection services)where TUser : class where TRole : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity<TUser, TRole>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNet.Identity.IdentityOptions>)
    
        
    
        Adds and configures the identity system for the specified User and Role types.
    
        
        
        
        :param services: The services available in the application.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
        
        
        :param setupAction: An action to configure the .
        
        :type setupAction: System.Action{Microsoft.AspNet.Identity.IdentityOptions}
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: An <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> for creating and configuring the identity system.
    
        
        .. code-block:: csharp
    
           public static IdentityBuilder AddIdentity<TUser, TRole>(IServiceCollection services, Action<IdentityOptions> setupAction)where TUser : class where TRole : class
    

