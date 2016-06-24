

UserStore Class
===============






Represents a new instance of a persistence store for users, using the default implementation
of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser\`1` with a string as a primary key.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,Microsoft.EntityFrameworkCore.DbContext,System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,Microsoft.EntityFrameworkCore.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore`








Syntax
------

.. code-block:: csharp

    public class UserStore : UserStore<IdentityUser<string>>, IUserLoginStore<IdentityUser<string>>, IUserRoleStore<IdentityUser<string>>, IUserClaimStore<IdentityUser<string>>, IUserPasswordStore<IdentityUser<string>>, IUserSecurityStampStore<IdentityUser<string>>, IUserEmailStore<IdentityUser<string>>, IUserLockoutStore<IdentityUser<string>>, IUserPhoneNumberStore<IdentityUser<string>>, IQueryableUserStore<IdentityUser<string>>, IUserTwoFactorStore<IdentityUser<string>>, IUserAuthenticationTokenStore<IdentityUser<string>>, IUserStore<IdentityUser<string>>, IDisposable








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore.UserStore(Microsoft.EntityFrameworkCore.DbContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: Microsoft.EntityFrameworkCore.DbContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public UserStore(DbContext context, IdentityErrorDescriber describer = null)
    

