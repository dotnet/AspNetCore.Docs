

UserClaimsPrincipalFactory<TUser, TRole> Class
==============================================






Provides methods to create a claims principal for a given user.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory\<TUser, TRole>`








Syntax
------

.. code-block:: csharp

    public class UserClaimsPrincipalFactory<TUser, TRole> : IUserClaimsPrincipalFactory<TUser> where TUser : class where TRole : class








.. dn:class:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>.UserClaimsPrincipalFactory(Microsoft.AspNetCore.Identity.UserManager<TUser>, Microsoft.AspNetCore.Identity.RoleManager<TRole>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.IdentityOptions>)
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory\`2` class.
    
        
    
        
        :param userManager: The :any:`Microsoft.AspNetCore.Identity.UserManager\`1` to retrieve user information from.
        
        :type userManager: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
    
        
        :param roleManager: The :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` to retrieve a user's roles from.
        
        :type roleManager: Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.RoleManager`1>{TRole}
    
        
        :param optionsAccessor: The configured :any:`Microsoft.AspNetCore.Builder.IdentityOptions`\.
        
        :type optionsAccessor: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.IdentityOptions<Microsoft.AspNetCore.Builder.IdentityOptions>}
    
        
        .. code-block:: csharp
    
            public UserClaimsPrincipalFactory(UserManager<TUser> userManager, RoleManager<TRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>.CreateAsync(TUser)
    
        
    
        
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` from an user asynchronously.
    
        
    
        
        :param user: The user to create a :any:`System.Security.Claims.ClaimsPrincipal` from.
        
        :type user: TUser
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Security.Claims.ClaimsPrincipal<System.Security.Claims.ClaimsPrincipal>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous creation operation, containing the created :any:`System.Security.Claims.ClaimsPrincipal`\.
    
        
        .. code-block:: csharp
    
            public virtual Task<ClaimsPrincipal> CreateAsync(TUser user)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>.Options
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Builder.IdentityOptions` for this factory.
    
        
        :rtype: Microsoft.AspNetCore.Builder.IdentityOptions
        :return: 
            The current :any:`Microsoft.AspNetCore.Builder.IdentityOptions` for this factory instance.
    
        
        .. code-block:: csharp
    
            public IdentityOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>.RoleManager
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` for this factory.
    
        
        :rtype: Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.RoleManager`1>{TRole}
        :return: 
            The current :any:`Microsoft.AspNetCore.Identity.RoleManager\`1` for this factory instance.
    
        
        .. code-block:: csharp
    
            public RoleManager<TRole> RoleManager { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory<TUser, TRole>.UserManager
    
        
    
        
        Gets the :any:`Microsoft.AspNetCore.Identity.UserManager\`1` for this factory.
    
        
        :rtype: Microsoft.AspNetCore.Identity.UserManager<Microsoft.AspNetCore.Identity.UserManager`1>{TUser}
        :return: 
            The current :any:`Microsoft.AspNetCore.Identity.UserManager\`1` for this factory instance.
    
        
        .. code-block:: csharp
    
            public UserManager<TUser> UserManager { get; }
    

