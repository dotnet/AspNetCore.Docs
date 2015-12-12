

IdentityDbContext<TUser, TRole, TKey> Class
===========================================



.. contents:: 
   :local:



Summary
-------

Base class for the Entity Framework database context used for identity.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Data.Entity.DbContext`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext\<TUser, TRole, TKey>`








Syntax
------

.. code-block:: csharp

   public class IdentityDbContext<TUser, TRole, TKey> : DbContext, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey> where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/IdentityDbContext.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext()
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext` class.
    
        
    
        
        .. code-block:: csharp
    
           protected IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext(Microsoft.Data.Entity.Infrastructure.DbContextOptions)
    
        
    
        Initializes a new instance of :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext`\.
    
        
        
        
        :param options: The options to be used by a .
        
        :type options: Microsoft.Data.Entity.Infrastructure.DbContextOptions
    
        
        .. code-block:: csharp
    
           public IdentityDbContext(DbContextOptions options)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext(System.IServiceProvider)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext` class using an :any:`System.IServiceProvider`\.
    
        
        
        
        :param serviceProvider: The service provider to be used.
        
        :type serviceProvider: System.IServiceProvider
    
        
        .. code-block:: csharp
    
           public IdentityDbContext(IServiceProvider serviceProvider)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.IdentityDbContext(System.IServiceProvider, Microsoft.Data.Entity.Infrastructure.DbContextOptions)
    
        
    
        Initializes a new instance of the :any:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext` class using an :any:`System.IServiceProvider`\.
    
        
        
        
        :param serviceProvider: The service provider to be used.
        
        :type serviceProvider: System.IServiceProvider
        
        
        :param options: The options to be used by a .
        
        :type options: Microsoft.Data.Entity.Infrastructure.DbContextOptions
    
        
        .. code-block:: csharp
    
           public IdentityDbContext(IServiceProvider serviceProvider, DbContextOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.OnModelCreating(Microsoft.Data.Entity.ModelBuilder)
    
        
    
        Configures the schema needed for the identity framework.
    
        
        
        
        :param builder: The builder being used to construct the model for this context.
        
        :type builder: Microsoft.Data.Entity.ModelBuilder
    
        
        .. code-block:: csharp
    
           protected override void OnModelCreating(ModelBuilder builder)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.RoleClaims
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of role claims.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim{{TKey}}}
    
        
        .. code-block:: csharp
    
           public DbSet<IdentityRoleClaim<TKey>> RoleClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.Roles
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of roles.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{{TRole}}
    
        
        .. code-block:: csharp
    
           public DbSet<TRole> Roles { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.UserClaims
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of User claims.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim{{TKey}}}
    
        
        .. code-block:: csharp
    
           public DbSet<IdentityUserClaim<TKey>> UserClaims { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.UserLogins
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of User logins.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin{{TKey}}}
    
        
        .. code-block:: csharp
    
           public DbSet<IdentityUserLogin<TKey>> UserLogins { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.UserRoles
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of User roles.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole{{TKey}}}
    
        
        .. code-block:: csharp
    
           public DbSet<IdentityUserRole<TKey>> UserRoles { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser, TRole, TKey>.Users
    
        
    
        Gets or sets the :any:`Microsoft.Data.Entity.DbSet\`1` of Users.
    
        
        :rtype: Microsoft.Data.Entity.DbSet{{TUser}}
    
        
        .. code-block:: csharp
    
           public DbSet<TUser> Users { get; set; }
    

