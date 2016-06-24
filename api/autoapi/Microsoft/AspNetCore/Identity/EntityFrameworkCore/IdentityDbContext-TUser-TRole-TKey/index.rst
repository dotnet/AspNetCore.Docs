

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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext{{TUser},{TRole},{TKey},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken{{TKey}}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext\<TUser, TRole, TKey>`








Syntax
------

.. code-block:: csharp

    public class IdentityDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey, IdentityUserClaim<TKey>, IdentityUserRole<TKey>, IdentityUserLogin<TKey>, IdentityRoleClaim<TKey>, IdentityUserToken<TKey>>, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser<TKey> where TRole : IdentityRole<TKey> where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext<TUser, TRole, TKey>

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
    

