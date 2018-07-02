---
title: Identity model customization
author: ajcvickers
description: This article describes how to customize the underlying Entity Framework Core data model for ASP.NET Core Identity.
monikerRange: '>= aspnetcore-2.1'
ms.author: avickers
ms.date: 04/12/2018
uid: security/authentication/customize_identity_model
---
# Identity model customization

By [Arthur Vickers](https://github.com/ajcvickers)

ASP.NET Core Identity provides a framework for managing and storing user accounts in ASP.NET Core applications. Identity is added to your project when "Individual User Accounts" is selected as the authentication mechanism. By default, Identity makes use of an Entity Framework (EF) Core data model. This article describes how to customize the Identity model.

<a name="identity-migrations"></a>

## Identity and EF Core Migrations

Before examining the model, it's useful to understand how Identity works with [EF Core Migrations](/ef/core/managing-schemas/migrations/) to create and update a database. At the top level, the process is:

1. Define or update a [data model in code](/ef/core/modeling/).
1. Add a migration to translate this model into changes that can be applied to the database.
1. Check that the migration correctly represents your intentions.
1. Apply the migration to update the database to be in sync with the model.
1. Repeat steps 1-4 to further refine the model and keep the database in sync.

Migrations are added and applied using:

* The [Package Manager Console](/ef/core/miscellaneous/cli/powershell) (PMC) if you are using Visual Studio.
* The [dotnet commands](/ef/core/miscellaneous/cli/dotnet) on the command line.
* Selecting the migrations link on the error page when the application is run.

ASP.NET Core has a development-time error page handler that can be used to apply migrations when the application is run. For production applications, it is often more appropriate to generate SQL scripts from the migrations and deploy these to the database as part of a controlled application and database deployment.

When a new application using Identity is created, steps 1 and 2 above have already been completed. That is, the initial data model already exists, and the initial migration has been added to the project. The initial migration still needs to be applied to the database. The initial migration can be done by running the Update-Database (PMC), the dotnet ef database update (.NET Core CLI) command, or by using the error page when the application is run.

The preceding steps need to be repeated as changes are made to the model.

<a name="identity-model"></a>

## The Identity model

### Entity types

The Identity model consists of seven entity types:

* `User` - represents the user
* `Role` - represents a role
* `UserClaim` - represents a claim that a user possess
* `UserToken` - represents an authentication token for a user
* `UserLogin` - associates a user with a login
* `RoleClaim` - represents a claim that is granted to all users within a role
* `UserRole` - join entity that associates users and roles

### Entity type relationships

These entity types are related to each other in the following ways:

* Each `User` can have many `UserClaims`
* Each `User` can have many `UserLogins`
* Each `User` can have many `UserTokens`
* Each `Role` can have many associated `RoleClaims`
* Each `User` can have many associated `Roles`, and each `Role` can be associated with many Users
  * This is a many-to-many relationship, which requires a join table in the database. The join table is represented by the `UserRole` entity.

### Default model configuration

Identity defines a variety of "context classes" which inherit from [DbContext](/dotnet/api/microsoft.entityframeworkcore.dbcontext) to configure and use the model. This configuration is done using the [EF Core Code First Fluent API](/ef/core/modeling/) in the [OnModelCreating](/dotnet/api/microsoft.entityframeworkcore.dbcontext.onmodelcreating#Microsoft_EntityFrameworkCore_DbContext_OnModelCreating_Microsoft_EntityFrameworkCore_ModelBuilder_) method of the context class. The default configuration is:

```CSharp
builder.Entity<TUser>(b =>
{
    // Primary key
    b.HasKey(u => u.Id);

    // Indexes for "normalized" username and email, to allow efficient lookups
    b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
    b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

    // Maps to the AspNetUsers table
    b.ToTable("AspNetUsers");

    // A concurrency token for use with the optimistic concurrency checking
    b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

    // Limit the size of columns to use efficient database types
    b.Property(u => u.UserName).HasMaxLength(256);
    b.Property(u => u.NormalizedUserName).HasMaxLength(256);
    b.Property(u => u.Email).HasMaxLength(256);
    b.Property(u => u.NormalizedEmail).HasMaxLength(256);

    // The relationships between User and other entity types
    // Note that these relationships are configured with no navigation properties

    // Each User can have many UserClaims
    b.HasMany<TUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

    // Each User can have many UserLogins
    b.HasMany<TUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

    // Each User can have many UserTokens
    b.HasMany<TUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

    // Each User can have many entries in the UserRole join table
    b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
});

builder.Entity<TUserClaim>(b =>
{
    // Primary key
    b.HasKey(uc => uc.Id);

    // Maps to the AspNetUserClaims table
    b.ToTable("AspNetUserClaims");
});

builder.Entity<TUserLogin>(b =>
{
    // Composite primary key consisting of the LoginProvider and the key to use
    // with that provider
    b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

    // Limit the size of the composite key columns due to common database restrictions
    b.Property(l => l.LoginProvider).HasMaxLength(128);
    b.Property(l => l.ProviderKey).HasMaxLength(128);

    // Maps to the AspNetUserLogins table
    b.ToTable("AspNetUserLogins");
});

builder.Entity<TUserToken>(b =>
{
    // Composite primary key consisting of the UserId, LoginProvider and Name
    b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

    // Limit the size of the composite key columns due to common database restrictions
    b.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
    b.Property(t => t.Name).HasMaxLength(maxKeyLength);

    // Maps to the AspNetUserTokens table
    b.ToTable("AspNetUserTokens");
});

builder.Entity<TRole>(b =>
{
    // Primary key
    b.HasKey(r => r.Id);

    // Index for "normalized" role name to allow efficient lookups
    b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

    // Maps to the AspNetRoles table
    b.ToTable("AspNetRoles");

    // A concurrency token for use with the optimistic concurrency checking
    b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

    // Limit the size of columns to use efficient database types
    b.Property(u => u.Name).HasMaxLength(256);
    b.Property(u => u.NormalizedName).HasMaxLength(256);

    // The relationships between Role and other entity types
    // Note that these relationships are configured with no navigation properties

    // Each Role can have many entries in the UserRole join table
    b.HasMany<TUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

    // Each Role can have many associated RoleClaims
    b.HasMany<TRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
});

builder.Entity<TRoleClaim>(b =>
{
    // Primary key
    b.HasKey(rc => rc.Id);

    // Maps to the AspNetRoleClaims table
    b.ToTable("AspNetRoleClaims");
});

builder.Entity<TUserRole>(b =>
{
    // Primary key
    b.HasKey(r => new { r.UserId, r.RoleId });

    // Maps to the AspNetUserRoles table
    b.ToTable("AspNetUserRoles");
});
```

### Model generic types

Identity defines default CLR types for each of the entity types listed above. These types are all prefixed with "Identity": `IdentityUser`, `IdentityRole`, `IdentityUserClaim`, `IdentityUserToken`, `IdentityUserLogin`, `IdentityRoleClaim`, and `IdentityUserRole`.

Rather than using these types directly, the types can be used as base classes for the application's own types. The `DbContext` classes defined by Identity are generic such that different CLR types can be used for one or more of the entity types in the model. These generic types also allow for the type of the User primary key to be changed.

When using Identity with support for roles, an [IdentityDbContext](/dotnet/api/microsoft.aspnetcore.identity.entityframeworkcore.identitydbcontext) class should be used:

```CSharp
// Uses all the built-in Identity types
// Uses `string` as the key type
public class IdentityDbContext
    : IdentityDbContext<IdentityUser, IdentityRole, string>
{
}

// Uses the built-in Identity types except with a custom User type
// Uses `string` as the key type
public class IdentityDbContext<TUser>
    : IdentityDbContext<TUser, IdentityRole, string>
        where TUser : IdentityUser
{
}

// Uses the built-in Identity types except with custom User and Role types
// The key type is defined by TKey
public class IdentityDbContext<TUser, TRole, TKey>
    : IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>>
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
{
}

// No built-in Identity types are used; all are specified by generic arguments
// The key type is defined by TKey
public abstract class IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    : IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
         where TUser : IdentityUser<TKey>
         where TRole : IdentityRole<TKey>
         where TKey : IEquatable<TKey>
         where TUserClaim : IdentityUserClaim<TKey>
         where TUserRole : IdentityUserRole<TKey>
         where TUserLogin : IdentityUserLogin<TKey>
         where TRoleClaim : IdentityRoleClaim<TKey>
         where TUserToken : IdentityUserToken<TKey>

```

It is also possible to use Identity without roles (only claims), in which case an `IdentityUserContext` class should be used:


```CSharp
// Uses the built-in non-role Identity types except with a custom User type
// Uses `string` as the key type
public class IdentityUserContext<TUser>
    : IdentityUserContext<TUser, string>
        where TUser : IdentityUser
{
}

// Uses the built-in non-role Identity types except with a custom User type
// The key type is defined by TKey
public class IdentityUserContext<TUser, TKey>
    : IdentityUserContext<TUser, TKey, IdentityUserClaim<TKey>, IdentityUserLogin<TKey>, IdentityUserToken<TKey>>
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
{
}

// No built-in Identity types are used; all are specified by generic arguments, with no roles
// The key type is defined by TKey
public abstract class IdentityUserContext<TUser, TKey, TUserClaim, TUserLogin, TUserToken>
    : DbContext
        where TUser : IdentityUser<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TUserToken : IdentityUserToken<TKey>
{
}
```

## Customizing the model

The starting point for customizing the model is to derive from the appropriate context type; see the preceding section. This context type is customarily called `ApplicationDbContext` and is created by the ASP.NET Core templates.

The context is used to configure the model in two ways:
* By supplying entity and key types for the generic type parameters.
* By overriding `OnModelCreating` to modify the mapping of these types.

When overriding `OnModelCreating`, `base.OnModelCreating` should be called first, the overriding configuration should be called next. EF Core generally has a last-one-wins policy for configuration. For example, if the `ToTable` for an entity type is called first with one table name and then again later with a different table name, then the table name in the second call is the one that is used.

### Using a custom User type

To use a custom User type, create the type and have it inherit from `IdentityUser`. It is customary to name this type `ApplicationUser`. This type will typically have additional properties not in the base type, otherwise there would be no value in creating it. For example:

```CSharp
public class ApplicationUser : IdentityUser
{
    public string CustomTag { get; set; }
}
```

Next use this type as a generic argument for the context:

```CSharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

Update `ConfigureServices` to use the new `ApplicationUser` class:

```CSharp
services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

There is no need to override `OnModelCreating` here because EF Core will map the `CustomTag` property by convention. However, the database will need to be updated to get a new `CustomTag` column. To do this, add a migration, and then update the database as described in  [Identity and EF Core Migrations](#identity-migrations).

### Changing the key type

Changing the type of a primary key (PK) column after the database has been created is problematic on many database systems. Changing the PK typically involves dropping and re-creating the table. Therefore, it is recommended that key types be specified in the initial migration such that the target key types are created when the database is created.

If the database has been created, then `Drop-Database` (PMC) or `dotnet ef database drop` (.NET Core CLI) can be used to delete it.

Once it is confirmed that the database doesn't exist,  remove the initial migration with `Remove-Migration` (PMC) or `dotnet ef migrations remove` (.NET Core CLI).

Update the `ApplicationDbContext` to use a different base class, specifying the new key type for `TKey`. For example, to use a `Guid` key:

```CSharp
public class ApplicationDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

Notice that the generic classes `IdentityUser<TKey>` and `IdentityRole<TKey>` must also be specified to use the new key type. `ConfigureServices` must be updated to use the generic user:

```CSharp
services.AddDefaultIdentity<IdentityUser<Guid>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

If a custom `ApplicationUser` is being used, update it to inherit from `IdentityUser<TKey>`. For example:

```CSharp
public class ApplicationUser : IdentityUser<Guid>
{
    public string CustomTag { get; set; }
}

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
```

```CSharp
services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

### Adding navigation properties

Changing the model configuration for relationships can be a more difficult than making other changes. Care must be taken to replace the existing relationships rather than create a new additional relationships. In particular, the changed relationship must specify the same foreign key property as the existing relationship. For example, the relationship between `Users` and `UserClaims` is by default specified as:

```CSharp
builder.Entity<TUser>(b =>
{
    // Each User can have many UserClaims
    b.HasMany<TUserClaim>()
     .WithOne()
     .HasForeignKey(uc => uc.UserId)
     .IsRequired();
});
```

The foreign key for this relationship is specified as the `UserClaim.UserId` property. `HasMany` and `WithOne` are called without arguments to create the relationship without navigation properties.

Add a navigation property to `ApplicationUser` that will allow associated `UserClaims` to be referenced from the user:

```CSharp
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
}
```

Note that the `TKey` for `IdentityUserClaim<TKey>` is type specified for the primary key of users--in this case `string` since we're using the defaults. It is **not** the primary key type for the `UserClaim` entity type.

Now that the navigation property exists it must be configured in `OnModelCreating`:

```CSharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();
        });
    }
}
```

Notice that relationship is configured exactly as it was before, only with a navigation property specified in the call to `HasMany`.

The navigation properties only exist in the EF model, not the database. Because the foreign key for the relationship has not changed, this kind of model change does not require the database to be updated. This can be checked by adding a migration after making the change: the `Up` and `Down` methods are empty.

### Adding all User navigation properties

Using the section above as guidance, here is an example that configures unidirectional navigation properties for all relationships on User:

```CSharp
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }
}
```

```CSharp
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });
    }
}
```

### Adding User and Role navigation properties

Using the section above as guidance, here is an example that configures navigation properties for all relationships on User and Role:

```CSharp
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}

public class ApplicationRole : IdentityRole
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}
```

```CSharp
public class ApplicationDbContext
    : IdentityDbContext<
        ApplicationUser, ApplicationRole, string,
        IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<ApplicationRole>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        });

    }
}
```

Notes:

* This example also includes the `UserRole` join entity, which is needed to navigate the many-to-many relationship from Users to Roles.
* Remember to change the types of the navigation properties to reflect that `ApplicationXxx` types are now being used instead of `IdentityXxx` types.
* Remember to use the `ApplicationXxx` in the generic `ApplicationContext` definition.

### Adding all navigation properties

Using the section above as guidance, here is an example that configures navigation properties for all relationships on all entity types:

```CSharp
public class ApplicationUser : IdentityUser
{
    public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
    public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
    public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
}

public class ApplicationRole : IdentityRole
{
    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
}

public class ApplicationUserRole : IdentityUserRole<string>
{
    public virtual ApplicationUser User { get; set; }
    public virtual ApplicationRole Role { get; set; }
}

public class ApplicationUserClaim : IdentityUserClaim<string>
{
    public virtual ApplicationUser User { get; set; }
}

public class ApplicationUserLogin : IdentityUserLogin<string>
{
    public virtual ApplicationUser User { get; set; }
}

public class ApplicationRoleClaim : IdentityRoleClaim<string>
{
    public virtual ApplicationRole Role { get; set; }
}

public class ApplicationUserToken : IdentityUserToken<string>
{
    public virtual ApplicationUser User { get; set; }
}
```

```CSharp
public class ApplicationDbContext
    : IdentityDbContext<
        ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>(b =>
        {
            // Each User can have many UserClaims
            b.HasMany(e => e.Claims)
                .WithOne(e => e.User)
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            b.HasMany(e => e.Logins)
                .WithOne(e => e.User)
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            b.HasMany(e => e.Tokens)
                .WithOne(e => e.User)
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        });

        modelBuilder.Entity<ApplicationRole>(b =>
        {
            // Each Role can have many entries in the UserRole join table
            b.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            // Each Role can have many associated RoleClaims
            b.HasMany(e => e.RoleClaims)
                .WithOne(e => e.Role)
                .HasForeignKey(rc => rc.RoleId)
                .IsRequired();
        });

    }
}
```

### Using composite keys

The preceding sections demonstrated changing the type of key used in the Identity model. Changing the Identity key model to use composite keys is not supported or recommended. Using a composite key with Identity would involve changing how the Identity manager code interacts with the model, which is an unsupported customization and beyond the scope of this document.

### Changing table/column names and facets

To change the names of tables and columns, call `base.OnModelCreating`, and then add configuration to override any of the defaults. For example, to change the name of all the identity tables:

```CSharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<IdentityUser>(b =>
    {
        b.ToTable("MyUsers");
    });

    modelBuilder.Entity<IdentityUserClaim<string>>(b =>
    {
        b.ToTable("MyUserClaims");
    });

    modelBuilder.Entity<IdentityUserLogin<string>>(b =>
    {
        b.ToTable("MyUserLogins");
    });

    modelBuilder.Entity<IdentityUserToken<string>>(b =>
    {
        b.ToTable("MyUserTokens");
    });

    modelBuilder.Entity<IdentityRole>(b =>
    {
        b.ToTable("MyRoles");
    });

    modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
    {
        b.ToTable("MyRoleClaims");
    });

    modelBuilder.Entity<IdentityUserRole<string>>(b =>
    {
        b.ToTable("MyUserRoles");
    });
}
```

Note that these examples use the default Identity types. If you are using an application type, such as `ApplicationUser` then configure that type instead of the default type.

Here is an example that changes some column names:

```CSharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<IdentityUser>(b =>
    {
        b.Property(e => e.Email).HasColumnName("EMail");
    });

    modelBuilder.Entity<IdentityUserClaim<string>>(b =>
    {
        b.Property(e => e.ClaimType).HasColumnName("CType");
        b.Property(e => e.ClaimValue).HasColumnName("CValue");
    });
}
```

Some types of database columns can be configured with certain _facets_ such as the maximum string length allowed. Here is an example that sets column max lengths for several string properties in the model:

```CSharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<IdentityUser>(b =>
    {
        b.Property(u => u.UserName).HasMaxLength(128);
        b.Property(u => u.NormalizedUserName).HasMaxLength(128);
        b.Property(u => u.Email).HasMaxLength(128);
        b.Property(u => u.NormalizedEmail).HasMaxLength(128);
    });

    modelBuilder.Entity<IdentityUserToken<string>>(b =>
    {
        b.Property(t => t.LoginProvider).HasMaxLength(128);
        b.Property(t => t.Name).HasMaxLength(128);
    });
}
```

### Mapping to a different schema

Schemas can behave differently in different database providers, but for SQL Server, the default is to create all tables in the "dbo" schema. This can be changed to instead create the tables in a different schema. For example:

```CSharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.HasDefaultSchema("notdbo");
}
```

### Lazy loading

In this section support for lazy-loading proxies in the Identity model is added. Lazy-loading is useful since it allows navigation properties to be used without first ensuring they are loaded.

Entity types can be made suitable for lazy-loading in several ways, as described in the [EF Core documentation](/ef/core/querying/related-data#lazy-loading). For simplicity, we will use lazy-loading proxies, which requires:

* Installation of the [Microsoft.EntityFrameworkCore.Proxies](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/) package.
* A call to `.UseLazyLoadingProxies()` inside `AddDbContext`.
* Public entity types with public virtual navigation properties.

Here is an example of calling `.UseLazyLoadingProxies()`:

```CSharp
services
    .AddDbContext<ApplicationDbContext>(
        b => b.UseSqlServer(connectionString)
            .UseLazyLoadingProxies())
    .AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
```

Refer back to the examples above for adding navigation properties to the entity types.
