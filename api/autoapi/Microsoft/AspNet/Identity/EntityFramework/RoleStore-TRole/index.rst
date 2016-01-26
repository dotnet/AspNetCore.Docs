

RoleStore<TRole> Class
======================



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for roles.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.RoleStore{{TRole},Microsoft.Data.Entity.DbContext,System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.RoleStore\<TRole>`








Syntax
------

.. code-block:: csharp

   public class RoleStore<TRole> : RoleStore<TRole, DbContext, string>, IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<string>





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/RoleStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole>.RoleStore(Microsoft.Data.Entity.DbContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: Microsoft.Data.Entity.DbContext
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public RoleStore(DbContext context, IdentityErrorDescriber describer = null)
    

