

IQueryableRoleStore<TRole> Interface
====================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for querying roles in a Role store.











Syntax
------

.. code-block:: csharp

   public interface IQueryableRoleStore<TRole> : IRoleStore<TRole>, IDisposable where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IQueryableRoleStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IQueryableRoleStore<TRole>

Properties
----------

.. dn:interface:: Microsoft.AspNet.Identity.IQueryableRoleStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IQueryableRoleStore<TRole>.Roles
    
        
    
        Returns an :any:`System.Linq.IQueryable\`1` collection of roles.
    
        
        :rtype: System.Linq.IQueryable{{TRole}}
    
        
        .. code-block:: csharp
    
           IQueryable<TRole> Roles { get; }
    

