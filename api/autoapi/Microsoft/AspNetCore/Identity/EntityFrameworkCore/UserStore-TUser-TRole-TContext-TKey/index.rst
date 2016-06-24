

UserStore<TUser, TRole, TContext, TKey> Class
=============================================






Represents a new instance of a persistence store for the specified user and role types.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity.EntityFrameworkCore`
Assemblies
    * Microsoft.AspNetCore.Identity.EntityFrameworkCore

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{{TUser},{TRole},{TContext},{TKey},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken{{TKey}}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore\<TUser, TRole, TContext, TKey>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser, TRole, TContext, TKey> : UserStore<TUser, TRole, TContext, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityUserToken<TKey>>, IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserAuthenticationTokenStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey> where TContext : DbContext where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`4
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.UserStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: TContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserStore(TContext context, IdentityErrorDescriber describer = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.CreateUserClaim(TUser, System.Security.Claims.Claim)
    
        
    
        
        :type user: TUser
    
        
        :type claim: System.Security.Claims.Claim
        :rtype: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim`1>{TKey}
    
        
        .. code-block:: csharp
    
            protected override IdentityUserClaim<TKey> CreateUserClaim(TUser user, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.CreateUserLogin(TUser, Microsoft.AspNetCore.Identity.UserLoginInfo)
    
        
    
        
        :type user: TUser
    
        
        :type login: Microsoft.AspNetCore.Identity.UserLoginInfo
        :rtype: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin`1>{TKey}
    
        
        .. code-block:: csharp
    
            protected override IdentityUserLogin<TKey> CreateUserLogin(TUser user, UserLoginInfo login)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.CreateUserRole(TUser, TRole)
    
        
    
        
        :type user: TUser
    
        
        :type role: TRole
        :rtype: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole`1>{TKey}
    
        
        .. code-block:: csharp
    
            protected override IdentityUserRole<TKey> CreateUserRole(TUser user, TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext, TKey>.CreateUserToken(TUser, System.String, System.String, System.String)
    
        
    
        
        :type user: TUser
    
        
        :type loginProvider: System.String
    
        
        :type name: System.String
    
        
        :type value: System.String
        :rtype: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken`1>{TKey}
    
        
        .. code-block:: csharp
    
            protected override IdentityUserToken<TKey> CreateUserToken(TUser user, string loginProvider, string name, string value)
    

