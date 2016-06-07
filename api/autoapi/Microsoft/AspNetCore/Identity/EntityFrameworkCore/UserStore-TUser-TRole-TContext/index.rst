

UserStore<TUser, TRole, TContext> Class
=======================================






Creates a new instance of a persistence store for the specified user and role types.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{{TUser},{TRole},{TContext},System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore\<TUser, TRole, TContext>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser, TRole, TContext> : UserStore<TUser, TRole, TContext, string>, IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserAuthenticationTokenStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<string>, new ()where TRole : IdentityRole<string>, new ()where TContext : DbContext








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser, TRole, TContext>.UserStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: TContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserStore(TContext context, IdentityErrorDescriber describer = null)
    

