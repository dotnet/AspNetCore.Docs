

UserStore<TUser, TRole, TContext> Class
=======================================



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for the specified user and role types.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{{TUser},{TRole},{TContext},System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore\<TUser, TRole, TContext>`








Syntax
------

.. code-block:: csharp

   public class UserStore<TUser, TRole, TContext> : UserStore<TUser, TRole, TContext, string>, IUserLoginStore<TUser>, IUserRoleStore<TUser>, IUserClaimStore<TUser>, IUserPasswordStore<TUser>, IUserSecurityStampStore<TUser>, IUserEmailStore<TUser>, IUserLockoutStore<TUser>, IUserPhoneNumberStore<TUser>, IQueryableUserStore<TUser>, IUserTwoFactorStore<TUser>, IUserStore<TUser>, IDisposable where TUser : IdentityUser<string>, new ()where TRole : IdentityRole<string>, new ()where TContext : DbContext





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/UserStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser, TRole, TContext>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser, TRole, TContext>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.UserStore<TUser, TRole, TContext>.UserStore(TContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: {TContext}
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public UserStore(TContext context, IdentityErrorDescriber describer = null)
    

