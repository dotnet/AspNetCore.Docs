

IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> Class
======================================================================================================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext\<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>`








Syntax
------

.. code-block:: csharp

    public abstract class IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : DbContext, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser<TKey, TUserClaim, TUserRole, TUserLogin> where TRole : IdentityRole<TKey, TUserRole, TRoleClaim> where TKey : IEquatable<TKey> where TUserClaim : IdentityUserClaim<TKey> where TUserRole : IdentityUserRole<TKey> where TUserLogin : IdentityUserLogin<TKey> where TRoleClaim : IdentityRoleClaim<TKey> where TUserToken : IdentityUserToken<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`8
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.IdentityDbContext()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext` class.
    
        
    
        
        .. code-block:: csharp
    
            protected IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.IdentityDbContext(Microsoft.EntityFrameworkCore.DbContextOptions)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`\.
    
        
    
        
        :param options: The options to be used by a :any:`Microsoft.EntityFrameworkCore.DbContext`\.
        
        :type options: Microsoft.EntityFrameworkCore.DbContextOptions
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbContextOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)
    
        
    
        
        Configures the schema needed for the identity framework.
    
        
    
        
        :param builder: 
            The builder being used to construct the model for this context.
        
        :type builder: Microsoft.EntityFrameworkCore.ModelBuilder
    
        
        .. code-block:: csharp
    
            protected override void OnModelCreating(ModelBuilder builder)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.RoleClaims
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of role claims.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TRoleClaim}
    
        
        .. code-block:: csharp
    
            public DbSet<TRoleClaim> RoleClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.Roles
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of roles.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TRole}
    
        
        .. code-block:: csharp
    
            public DbSet<TRole> Roles { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.UserClaims
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User claims.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUserClaim}
    
        
        .. code-block:: csharp
    
            public DbSet<TUserClaim> UserClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.UserLogins
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User logins.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUserLogin}
    
        
        .. code-block:: csharp
    
            public DbSet<TUserLogin> UserLogins { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.UserRoles
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User roles.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUserRole}
    
        
        .. code-block:: csharp
    
            public DbSet<TUserRole> UserRoles { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.UserTokens
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User tokens.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUserToken}
    
        
        .. code-block:: csharp
    
            public DbSet<TUserToken> UserTokens { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>.Users
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of Users.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUser}
    
        
        .. code-block:: csharp
    
            public DbSet<TUser> Users { get; set; }
    

