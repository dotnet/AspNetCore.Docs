

UserClaimsPrincipalFactory<TUser, TRole> Class
==============================================



.. contents:: 
   :local:



Summary
-------

Provides methods to create a claims principal for a given user.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.UserClaimsPrincipalFactory\<TUser, TRole>`








Syntax
------

.. code-block:: csharp

   public class UserClaimsPrincipalFactory<TUser, TRole> : IUserClaimsPrincipalFactory<TUser> where TUser : class where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/UserClaimsPrincipalFactory.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>.UserClaimsPrincipalFactory(Microsoft.AspNet.Identity.UserManager<TUser>, Microsoft.AspNet.Identity.RoleManager<TRole>, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Identity.IdentityOptions>)
    
        
    
        Initializes a new instance of the ClaimsIdentityFactory class.
    
        
        
        
        :param userManager: The  to retrieve user information from.
        
        :type userManager: Microsoft.AspNet.Identity.UserManager{{TUser}}
        
        
        :param roleManager: The  to retrieve a user's roles from.
        
        :type roleManager: Microsoft.AspNet.Identity.RoleManager{{TRole}}
        
        
        :param optionsAccessor: The configured .
        
        :type optionsAccessor: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Identity.IdentityOptions}
    
        
        .. code-block:: csharp
    
           public UserClaimsPrincipalFactory(UserManager<TUser> userManager, RoleManager<TRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>.CreateAsync(TUser)
    
        
    
        Creates a :any:`System.Security.Claims.ClaimsPrincipal` from an user asynchronously.
    
        
        
        
        :param user: The user to create a  from.
        
        :type user: {TUser}
        :rtype: System.Threading.Tasks.Task{System.Security.Claims.ClaimsPrincipal}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous creation operation, containing the created <see cref="T:System.Security.Claims.ClaimsPrincipal" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<ClaimsPrincipal> CreateAsync(TUser user)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>.Options
    
        
    
        Gets the :any:`Microsoft.AspNet.Identity.IdentityOptions` for this factory.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityOptions
    
        
        .. code-block:: csharp
    
           public IdentityOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>.RoleManager
    
        
    
        Gets the :any:`Microsoft.AspNet.Identity.RoleManager\`1` for this factory.
    
        
        :rtype: Microsoft.AspNet.Identity.RoleManager{{TRole}}
    
        
        .. code-block:: csharp
    
           public RoleManager<TRole> RoleManager { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.UserClaimsPrincipalFactory<TUser, TRole>.UserManager
    
        
    
        Gets the :any:`Microsoft.AspNet.Identity.UserManager\`1` for this factory.
    
        
        :rtype: Microsoft.AspNet.Identity.UserManager{{TUser}}
    
        
        .. code-block:: csharp
    
           public UserManager<TUser> UserManager { get; }
    

