

IdentityBuilder Class
=====================



.. contents:: 
   :local:



Summary
-------

Helper functions for configuring identity services.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.IdentityBuilder`








Syntax
------

.. code-block:: csharp

   public class IdentityBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IdentityBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.IdentityBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.IdentityBuilder.IdentityBuilder(System.Type, System.Type, Microsoft.Extensions.DependencyInjection.IServiceCollection)
    
        
    
        Creates a new instance of :any:`Microsoft.AspNet.Identity.IdentityBuilder`\.
    
        
        
        
        :param user: The  to use for the users.
        
        :type user: System.Type
        
        
        :param role: The  to use for the roles.
        
        :type role: System.Type
        
        
        :param services: The  to attach to.
        
        :type services: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public IdentityBuilder(Type user, Type role, IServiceCollection services)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddDefaultTokenProviders()
    
        
    
        Adds the default token providers used to generate tokens for reset passwords, change email
        and change telephone number operations, and for two factor authentication token generation.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddDefaultTokenProviders()
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddErrorDescriber<TDescriber>()
    
        
    
        Adds an :any:`Microsoft.AspNet.Identity.IdentityErrorDescriber`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddErrorDescriber<TDescriber>()where TDescriber : IdentityErrorDescriber
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddPasswordValidator<T>()
    
        
    
        Adds an :any:`Microsoft.AspNet.Identity.IPasswordValidator\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddPasswordValidator<T>()where T : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddRoleManager<TRoleManager>()
    
        
    
        Adds a :any:`Microsoft.AspNet.Identity.RoleManager\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddRoleManager<TRoleManager>()where TRoleManager : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddRoleStore<T>()
    
        
    
        Adds a :any:`Microsoft.AspNet.Identity.IRoleStore\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddRoleStore<T>()where T : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddRoleValidator<T>()
    
        
    
        Adds an :any:`Microsoft.AspNet.Identity.IRoleValidator\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.RoleType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddRoleValidator<T>()where T : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddTokenProvider(System.String, System.Type)
    
        
    
        Adds a token provider for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.UserType`\.
    
        
        
        
        :param providerName: The name of the provider to add.
        
        :type providerName: System.String
        
        
        :param provider: The type of the  to add.
        
        :type provider: System.Type
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddTokenProvider(string providerName, Type provider)
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddTokenProvider<TProvider>(System.String)
    
        
    
        Adds a token provider.
    
        
        
        
        :param providerName: The name of the provider to add.
        
        :type providerName: System.String
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddTokenProvider<TProvider>(string providerName)where TProvider : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddUserManager<TUserManager>()
    
        
    
        Adds a :any:`Microsoft.AspNet.Identity.UserManager\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddUserManager<TUserManager>()where TUserManager : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddUserStore<T>()
    
        
    
        Adds an :any:`Microsoft.AspNet.Identity.IUserStore\`1` for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddUserStore<T>()where T : class
    
    .. dn:method:: Microsoft.AspNet.Identity.IdentityBuilder.AddUserValidator<T>()
    
        
    
        Adds an IUserValidator for the :dn:prop:`Microsoft.AspNet.Identity.IdentityBuilder.UserType`\.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityBuilder
        :return: The current <see cref="T:Microsoft.AspNet.Identity.IdentityBuilder" /> instance.
    
        
        .. code-block:: csharp
    
           public virtual IdentityBuilder AddUserValidator<T>()where T : class
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.IdentityBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityBuilder.RoleType
    
        
    
        Gets the :any:`System.Type` used for roles.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type RoleType { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityBuilder.Services
    
        
    
        Gets the :any:`Microsoft.Extensions.DependencyInjection.IServiceCollection` services are attached to.
    
        
        :rtype: Microsoft.Extensions.DependencyInjection.IServiceCollection
    
        
        .. code-block:: csharp
    
           public IServiceCollection Services { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityBuilder.UserType
    
        
    
        Gets the :any:`System.Type` used for users.
    
        
        :rtype: System.Type
    
        
        .. code-block:: csharp
    
           public Type UserType { get; }
    

