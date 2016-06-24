

UserStore<TUser> Class
======================





Namespace
    :dn:ns:`Microsoft.AspNet.Identity.CoreCompat`
Assemblies
    * Microsoft.AspNet.Identity.AspNetCoreCompat

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{{TUser},Microsoft.AspNet.Identity.CoreCompat.IdentityRole,System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.UserStore{{TUser},Microsoft.AspNet.Identity.CoreCompat.IdentityRole,System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.UserStore\<TUser>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser> : UserStore<TUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>, IUserLoginStore<TUser, string>, IUserClaimStore<TUser, string>, IUserRoleStore<TUser, string>, IUserPasswordStore<TUser, string>, IUserSecurityStampStore<TUser, string>, IQueryableUserStore<TUser, string>, IUserEmailStore<TUser, string>, IUserPhoneNumberStore<TUser, string>, IUserTwoFactorStore<TUser, string>, IUserLockoutStore<TUser, string>, IUserStore<TUser>, IUserStore<TUser, string>, IDisposable where TUser : IdentityUser








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore`1
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser>.UserStore()
    
        
    
        
            Default constuctor which uses a new instance of a default EntityyDbContext
    
        
    
        
        .. code-block:: csharp
    
            public UserStore()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser>.UserStore(System.Data.Entity.DbContext)
    
        
    
        
            Constructor
    
        
    
        
        :type context: System.Data.Entity.DbContext
    
        
        .. code-block:: csharp
    
            public UserStore(DbContext context)
    

