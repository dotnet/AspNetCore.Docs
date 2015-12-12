

UserStore<TUser> Class
======================



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for the specified user type.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{{TUser},Microsoft.AspNet.Identity.EntityFramework.IdentityRole,Microsoft.Data.Entity.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{{TUser},Microsoft.AspNet.Identity.EntityFramework.IdentityRole,Microsoft.Data.Entity.DbContext}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore\<TUser>`








Syntax
------

.. code-block:: csharp

   public class UserStore<TUser> : UserStore<TUser, IdentityRole, DbContext>, IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<string>, new ()





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/UserStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser>.UserStore(Microsoft.Data.Entity.DbContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: Microsoft.Data.Entity.DbContext
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public UserStore(DbContext context, IdentityErrorDescriber describer = null)
    

