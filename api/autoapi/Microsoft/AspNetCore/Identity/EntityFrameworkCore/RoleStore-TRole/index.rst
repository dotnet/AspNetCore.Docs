

RoleStore<TRole> Class
======================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore{{TRole},Microsoft.EntityFrameworkCore.DbContext,System.String,Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole{System.String},Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim{System.String}}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore{{TRole},Microsoft.EntityFrameworkCore.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore\<TRole>`








Syntax
------

.. code-block:: csharp

    public class RoleStore<TRole> : RoleStore<TRole, DbContext, string>, IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<string>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole>.RoleStore(Microsoft.EntityFrameworkCore.DbContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: Microsoft.EntityFrameworkCore.DbContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public RoleStore(DbContext context, IdentityErrorDescriber describer = null)
    

