

UserStore<TUser> Class
======================






Creates a new instance of a persistence store for the specified user type.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{{TUser},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,Microsoft.EntityFrameworkCore.DbContext,System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{{TUser},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,Microsoft.EntityFrameworkCore.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore\<TUser>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser> : UserStore<TUser, IdentityRole, DbContext, string>, IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserAuthenticationTokenStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<string>, new ()








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore<TUser>.UserStore(Microsoft.EntityFrameworkCore.DbContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: Microsoft.EntityFrameworkCore.DbContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserStore(DbContext context, IdentityErrorDescriber describer = null)
    

