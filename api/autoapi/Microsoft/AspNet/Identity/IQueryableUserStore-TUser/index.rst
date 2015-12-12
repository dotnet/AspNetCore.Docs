

IQueryableUserStore<TUser> Interface
====================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for querying roles in a User store.











Syntax
------

.. code-block:: csharp

   public interface IQueryableUserStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IQueryableUserStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IQueryableUserStore<TUser>

Properties
----------

.. dn:interface:: Microsoft.AspNet.Identity.IQueryableUserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IQueryableUserStore<TUser>.Users
    
        
    
        Returns an :any:`System.Linq.IQueryable\`1` collection of users.
    
        
        :rtype: System.Linq.IQueryable{{TUser}}
    
        
        .. code-block:: csharp
    
           IQueryable<TUser> Users { get; }
    

