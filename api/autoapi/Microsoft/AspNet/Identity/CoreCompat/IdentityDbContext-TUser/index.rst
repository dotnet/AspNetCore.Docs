

IdentityDbContext<TUser> Class
==============================





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
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{{TUser},Microsoft.AspNet.Identity.CoreCompat.IdentityRole,System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext{{TUser},Microsoft.AspNet.Identity.CoreCompat.IdentityRole,System.String,Microsoft.AspNet.Identity.CoreCompat.IdentityUserLogin,Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole,Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim,Microsoft.AspNet.Identity.CoreCompat.IdentityRoleClaim}`
* :dn:cls:`Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext\<TUser>`








Syntax
------

.. code-block:: csharp

    public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim, IdentityRoleClaim>, IDisposable, IObjectContextAdapter where TUser : IdentityUser








.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext`1
    :hidden:

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext()
    
        
    
        
        .. code-block:: csharp
    
            public IdentityDbContext()
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext(System.Data.Common.DbConnection, System.Boolean)
    
        
    
        
        :type existingConnection: System.Data.Common.DbConnection
    
        
        :type contextOwnsConnection: System.Boolean
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbConnection existingConnection, bool contextOwnsConnection)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext(System.Data.Common.DbConnection, System.Data.Entity.Infrastructure.DbCompiledModel, System.Boolean)
    
        
    
        
        :type existingConnection: System.Data.Common.DbConnection
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        :type contextOwnsConnection: System.Boolean
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbConnection existingConnection, DbCompiledModel model, bool contextOwnsConnection)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext(System.Data.Entity.Infrastructure.DbCompiledModel)
    
        
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(DbCompiledModel model)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext(System.String)
    
        
    
        
        :type nameOrConnectionString: System.String
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(string nameOrConnectionString)
    
    .. dn:constructor:: Microsoft.AspNet.Identity.CoreCompat.IdentityDbContext<TUser>.IdentityDbContext(System.String, System.Data.Entity.Infrastructure.DbCompiledModel)
    
        
    
        
        :type nameOrConnectionString: System.String
    
        
        :type model: System.Data.Entity.Infrastructure.DbCompiledModel
    
        
        .. code-block:: csharp
    
            public IdentityDbContext(string nameOrConnectionString, DbCompiledModel model)
    

