

UserStore Class
===============



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for users, using the default implementation
of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityUser\`1` with a string as a primary key.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.String},Microsoft.AspNet.Identity.EntityFramework.IdentityRole,Microsoft.Data.Entity.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.String},Microsoft.AspNet.Identity.EntityFramework.IdentityRole,Microsoft.Data.Entity.DbContext}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore{Microsoft.AspNet.Identity.EntityFramework.IdentityUser{System.String}}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.UserStore`








Syntax
------

.. code-block:: csharp

   public class UserStore : UserStore<IdentityUser<string>>, IUserLoginStore<IdentityUser<string>>, IUserRoleStore<IdentityUser<string>>, IUserClaimStore<IdentityUser<string>>, IUserPasswordStore<IdentityUser<string>>, IUserSecurityStampStore<IdentityUser<string>>, IUserEmailStore<IdentityUser<string>>, IUserLockoutStore<IdentityUser<string>>, IUserPhoneNumberStore<IdentityUser<string>>, IQueryableUserStore<IdentityUser<string>>, IUserTwoFactorStore<IdentityUser<string>>, IUserStore<IdentityUser<string>>, IDisposable





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/UserStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.UserStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.UserStore.UserStore(Microsoft.Data.Entity.DbContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: Microsoft.Data.Entity.DbContext
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public UserStore(DbContext context, IdentityErrorDescriber describer = null)
    

