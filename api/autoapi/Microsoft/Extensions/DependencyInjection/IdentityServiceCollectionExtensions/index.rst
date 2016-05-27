

IdentityServiceCollectionExtensions Class
=========================================






Contains extension methods to :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` for configuring identity services.


Namespace
    :dn:ns:`Microsoft.Extensions.DependencyInjection`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions`








Syntax
------

.. code-block:: csharp

    public class IdentityServiceCollectionExtensions








.. dn:class:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions
    :hidden:

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
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` for creating and configuring the identity system.
    
        
        .. code-block:: csharp
    
            public static IdentityBuilder AddIdentity<TUser, TRole>(IServiceCollection services)where TUser : class where TRole : class
    
    .. dn:method:: Microsoft.Extensions.DependencyInjection.IdentityServiceCollectionExtensions.AddIdentity<TUser, TRole>(Microsoft.Extensions.DependencyInjection.IServiceCollection, System.Action<Microsoft.AspNetCore.Builder.IdentityOptions>)
    
        
    
        
        Adds and configures the identity system for the specified User and Role types.
    
        
    
        
        :param services: The services available in the application.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        :param setupAction: An action to configure the :any:`Microsoft.AspNetCore.Builder.IdentityOptions`\.
        
        :type setupAction: System.Action<System.Action`1>{Microsoft.AspNetCore.Builder.IdentityOptions<Microsoft.AspNetCore.Builder.IdentityOptions>}
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: An :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` for creating and configuring the identity system.
    
        
        .. code-block:: csharp
    
            public static IdentityBuilder AddIdentity<TUser, TRole>(IServiceCollection services, Action<IdentityOptions> setupAction)where TUser : class where TRole : class
    

