

IdentityDbContext<TUser> Class
==============================



.. contents:: 
   :local:



Summary
-------

Base class for the Entity Framework database context used for identity.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.Data.Entity.DbContext`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext{{TUser},Microsoft.AspNet.Identity.EntityFramework.IdentityRole,System.String}`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext\<TUser>`








Syntax
------

.. code-block:: csharp

   public class IdentityDbContext<TUser> : IdentityDbContext<TUser, IdentityRole, string>, IDisposable, IInfrastructure<IServiceProvider> where TUser : IdentityUser





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity.EntityFramework/IdentityDbContext.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.IdentityDbContext<TUser>

