

RoleStore<TRole, TContext, TKey> Class
======================================






Creates a new instance of a persistence store for roles.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore{{TRole},{TContext},{TKey},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{{TKey}},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim{{TKey}}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore\<TRole, TContext, TKey>`








Syntax
------

.. code-block:: csharp

    public class RoleStore<TRole, TContext, TKey> : RoleStore<TRole, TContext, TKey, IdentityUserRole<TKey>, IdentityRoleClaim<TKey>>, IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<TKey> where TContext : DbContext where TKey : IEquatable<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore`3
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey>.RoleStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: TContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public RoleStore(TContext context, IdentityErrorDescriber describer = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey>.CreateRoleClaim(TRole, System.Security.Claims.Claim)
    
        
    
        
        :type role: TRole
    
        
        :type claim: System.Security.Claims.Claim
        :rtype: Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim`1>{TKey}
    
        
        .. code-block:: csharp
    
            protected override IdentityRoleClaim<TKey> CreateRoleClaim(TRole role, Claim claim)
    

