

IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim> Class
==========================================================================================





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
* :dn:cls:`System.Data.Entity.DbContext`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{{TUser},{TRole},{TKey},{TUserLogin},{TUserRole},{TUserClaim}}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext\<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>`








Syntax
------

.. code-block:: csharp

    public class IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim> : IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>, IDisposable, IObjectContextAdapter where TUser : IdentityUser<TKey, TUserLogin, TUserRole, TUserClaim> where TRole : IdentityRole<TKey, TUserRole> where TUserLogin : IdentityUserLogin<TKey> where TUserRole : IdentityUserRole<TKey> where TUserClaim : IdentityUserClaim<TKey> where TRoleClaim : IdentityRoleClaim<TKey>








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext`7
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext()
    
        
    
        
        .. code-block:: csharp
    
            public IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext(System.Data.Common.DbConnection, System.Boolean)
    
        
    
        
        :type existingConnection: System.Data.Common.DbConnection
    
        
        :type contextOwnsConnection: System.Boolean
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbConnection existingConnection, bool contextOwnsConnection)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext(System.Data.Common.DbConnection, System.Data.Entity.Infrastructure.DbCompiledModel, System.Boolean)
    
        
    
        
        :type existingConnection: System.Data.Common.DbConnection
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        :type contextOwnsConnection: System.Boolean
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext(System.Data.Entity.Infrastructure.DbCompiledModel)
    
        
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbCompiledModel model)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext(System.String)
    
        
    
        
        :type nameOrConnectionString: System.String
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(string nameOrConnectionString)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.IdentityDbContext(System.String, System.Data.Entity.Infrastructure.DbCompiledModel)
    
        
    
        
        :type nameOrConnectionString: System.String
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(string nameOrConnectionString, DbCompiledModel model)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.OnModelCreating(System.Data.Entity.DbModelBuilder)
    
        
    
        
        :type modelBuilder: System.Data.Entity.DbModelBuilder
    
        
        .. code-block:: csharp
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
    
    .. dn:method:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry, System.Collections.Generic.IDictionary<System.Object, System.Object>)
    
        
    
        
        :type entityEntry: System.Data.Entity.Infrastructure.DbEntityEntry
    
        
        :type items: System.Collections.Generic.IDictionary<System.Collections.Generic.IDictionary`2>{System.Object<System.Object>, System.Object<System.Object>}
        :rtype: System.Data.Entity.Validation.DbEntityValidationResult
    
        
        .. code-block:: csharp
    
            protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TRoleClaim>.RoleClaims
    
        
        :rtype: System.Data.Entity.IDbSet<System.Data.Entity.IDbSet`1>{TRoleClaim}
    
        
        .. code-block:: csharp
    
            public virtual IDbSet<TRoleClaim> RoleClaims { get; set; }
    

