

IdentityDbContext<TUser, TRole, TKey> Class
===========================================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext\<TUser, TRole, TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityDbContext<TUser, TRole, TKey> : DbContext, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey> where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.RoleClaims
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of role claims.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public DbSet<IdentityRoleClaim<TKey>> RoleClaims
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.Roles
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of roles.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TRole}
    
        
        .. code-block:: csharp
    
            public DbSet<TRole> Roles
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.UserClaims
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User claims.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public DbSet<IdentityUserClaim<TKey>> UserClaims
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.UserLogins
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User logins.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public DbSet<IdentityUserLogin<TKey>> UserLogins
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.UserRoles
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User roles.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public DbSet<IdentityUserRole<TKey>> UserRoles
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.UserTokens
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of User tokens.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken`1>{TKey}}
    
        
        .. code-block:: csharp
    
            public DbSet<IdentityUserToken<TKey>> UserTokens
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.Users
    
        
    
        
        Gets or sets the :any:`Microsoft.EntityFrameworkCore.DbSet\`1` of Users.
    
        
        :rtype: Microsoft.EntityFrameworkCore.DbSet<Microsoft.EntityFrameworkCore.DbSet`1>{TUser}
    
        
        .. code-block:: csharp
    
            public DbSet<TUser> Users
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext()
    
        
    
        
        Initializes a new instance of the :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext` class.
    
        
    
        
        .. code-block:: csharp
    
            protected IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext(Microsoft.EntityFrameworkCore.DbContextOptions)
    
        
    
        
        Initializes a new instance of :any:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`\.
    
        
    
        
        :param options: The options to be used by a :any:`Microsoft.EntityFrameworkCore.DbContext`\.
        
        :type options: Microsoft.EntityFrameworkCore.DbContextOptions
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbContextOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)
    
        
    
        
        Configures the schema needed for the identity framework.
    
        
    
        
        :param builder: 
            The builder being used to construct the model for this context.
        
        :type builder: Microsoft.EntityFrameworkCore.ModelBuilder
    
        
        .. code-block:: csharp
    
            protected override void OnModelCreating(ModelBuilder builder)
    

