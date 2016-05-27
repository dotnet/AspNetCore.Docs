

RoleStore<TRole, TContext> Class
================================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore{{TRole},{TContext},System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore\<TRole, TContext>`








Syntax
------

.. code-block:: csharp

    public class RoleStore<TRole, TContext> : RoleStore<TRole, TContext, string>, IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<string> where TContext : DbContext








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext>.RoleStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: TContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public RoleStore(TContext context, IdentityErrorDescriber describer = null)
    

