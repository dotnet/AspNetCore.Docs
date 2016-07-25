

IdentityDbContext<TUser> Class
==============================






Base class for the Entity Framework database context used for identity.


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
* :dn:cls:`Microsoft.EntityFrameworkCore.DbContext`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{{TUser},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{{TUser},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole,System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext\<TUser>`








Syntax
------

.. code-block:: csharp

    public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string>, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser>.IdentityDbContext()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext` class.
    
        
    
        
        .. code-block:: csharp
    
            protected IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser>.IdentityDbContext(Microsoft.EntityFrameworkCore.DbContextOptions)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`\.
    
        
    
        
        :param options: The options to be used by a :any:`Microsoft.EntityFrameworkCore.DbContext`\.
        
        :type options: Microsoft.EntityFrameworkCore.DbContextOptions
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbContextOptions options)
    

