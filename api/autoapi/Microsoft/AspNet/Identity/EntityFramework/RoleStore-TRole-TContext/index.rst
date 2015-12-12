

RoleStore<TRole, TContext> Class
================================



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for roles.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.RoleStore{{TRole},{TContext},System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.RoleStore\<TRole, TContext>`








Syntax
------

.. code-block:: csharp

   public class RoleStore<TRole, TContext> : RoleStore<TRole, TContext, string>, IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<string> where TContext : DbContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/RoleStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext>.RoleStore(TContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: {TContext}
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public RoleStore(TContext context, IdentityErrorDescriber describer = null)
    

