

IQueryableRoleStore<TRole> Interface
====================================






Provides an abstraction for querying roles in a Role store.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IQueryableRoleStore<TRole> : IRoleStore<TRole>, IDisposable where TRole : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableRoleStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableRoleStore<TRole>

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableRoleStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.IQueryableRoleStore<TRole>.Roles
    
        
    
        
        Returns an :any:`System.Linq.IQueryable\`1` collection of roles.
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TRole}
        :return: An :any:`System.Linq.IQueryable\`1` collection of roles.
    
        
        .. code-block:: csharp
    
            IQueryable<TRole> Roles { get; }
    

