

UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> Class
======================================================================





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
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{{TUser},{TRole},{TKey},{TUserLogin},{TUserRole},{TUserClaim}}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.UserStore\<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>`








Syntax
------

.. code-block:: csharp

    public class UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim> : UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>, IUserLoginStore<TUser, TKey>, IUserClaimStore<TUser, TKey>, IUserRoleStore<TUser, TKey>, IUserPasswordStore<TUser, TKey>, IUserSecurityStampStore<TUser, TKey>, IQueryableUserStore<TUser, TKey>, IUserEmailStore<TUser, TKey>, IUserPhoneNumberStore<TUser, TKey>, IUserTwoFactorStore<TUser, TKey>, IUserLockoutStore<TUser, TKey>, IUserStore<TUser, TKey>, IDisposable where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> where TRole : IdentityRole<TKey, TUserRole> where TKey : IEquatable<TKey> where TUserLogin : IdentityUserLogin<TKey>, new ()where TUserRole : IdentityUserRole<TKey>, new ()where TUserClaim : IdentityUserClaim<TKey>, new ()








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore`6
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>.UserStore(System.Data.Entity.DbContext)
    
        
    
        
            Constructor
    
        
    
        
        :type context: System.Data.Entity.DbContext
    
        
        .. code-block:: csharp
    
            public UserStore(DbContext context)
    

