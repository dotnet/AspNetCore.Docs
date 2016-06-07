

IdentityBuilder Class
=====================






Helper functions for configuring identity services.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.IdentityBuilder`








Syntax
------

.. code-block:: csharp

    public class IdentityBuilder








.. dn:class:: Microsoft.AspNetCore.Identity.IdentityBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityBuilder.RoleType
    
        
    
        
        Gets the :any:`System.Type` used for roles.
    
        
        :rtype: System.Type
        :return: 
            The :any:`System.Type` used for roles.
    
        
        .. code-block:: csharp
    
            public Type RoleType
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityBuilder.Services
    
        
    
        
        Gets the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` services are attached to.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
        :return: 
            The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` services are attached to.
    
        
        .. code-block:: csharp
    
            public IServiceCollection Services
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityBuilder.UserType
    
        
    
        
        Gets the :any:`System.Type` used for users.
    
        
        :rtype: System.Type
        :return: 
            The :any:`System.Type` used for users.
    
        
        .. code-block:: csharp
    
            public Type UserType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.IdentityBuilder.IdentityBuilder(System.Type, System.Type, Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Identity.IdentityBuilder`\.
    
        
    
        
        :param user: The :any:`System.Type` to use for the users.
        
        :type user: System.Type
    
        
        :param role: The :any:`System.Type` to use for the roles.
        
        :type role: System.Type
    
        
        :param services: The :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` to attach to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
            public IdentityBuilder(Type user, Type role, IServiceCollection services)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddDefaultTokenProviders()
    
        
    
        
        Adds the default token providers used to generate tokens for reset passwords, change email
        and change telephone number operations, and for two factor authentication token generation.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddDefaultTokenProviders()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddErrorDescriber<TDescriber>()
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddErrorDescriber<TDescriber>()where TDescriber : IdentityErrorDescriber
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddPasswordValidator<T>()
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Identity.IPasswordValidator\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddPasswordValidator<T>()where T : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoleManager<TRoleManager>()
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddRoleManager<TRoleManager>()where TRoleManager : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoleStore<T>()
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Identity.IRoleStore\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddRoleStore<T>()where T : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddRoleValidator<T>()
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Identity.IRoleValidator\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddRoleValidator<T>()where T : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddTokenProvider(System.String, System.Type)
    
        
    
        
        Adds a token provider for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.UserType`\.
    
        
    
        
        :param providerName: The name of the provider to add.
        
        :type providerName: System.String
    
        
        :param provider: The type of the :any:`Microsoft.AspNetCore.Identity.IUserTwoFactorTokenProvider\`1` to add.
        
        :type provider: System.Type
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddTokenProvider(string providerName, Type provider)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddTokenProvider<TProvider>(System.String)
    
        
    
        
        Adds a token provider.
    
        
    
        
        :param providerName: The name of the provider to add.
        
        :type providerName: System.String
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddTokenProvider<TProvider>(string providerName)where TProvider : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddUserManager<TUserManager>()
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Identity.UserManager\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddUserManager<TUserManager>()where TUserManager : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddUserStore<T>()
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Identity.IUserStore\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddUserStore<T>()where T : class
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IdentityBuilder.AddUserValidator<T>()
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Identity.IUserValidator\`1` for the :dn:prop:`Microsoft.AspNetCore.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityBuilder
        :return: The current :any:`Microsoft.AspNetCore.Identity.IdentityBuilder` instance.
    
        
        .. code-block:: csharp
    
            public virtual IdentityBuilder AddUserValidator<T>()where T : class
    

