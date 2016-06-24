

IQueryableUserStore<TUser> Interface
====================================






Provides an abstraction for querying roles in a User store.


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

    public interface IQueryableUserStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableUserStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableUserStore<TUser>

Properties
----------

.. dn:interface:: Microsoft.AspNetCore.Identity.IQueryableUserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.IQueryableUserStore<TUser>.Users
    
        
    
        
        Returns an :any:`System.Linq.IQueryable\`1` collection of users.
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TUser}
        :return: An :any:`System.Linq.IQueryable\`1` collection of users.
    
        
        .. code-block:: csharp
    
            IQueryable<TUser> Users { get; }
    

