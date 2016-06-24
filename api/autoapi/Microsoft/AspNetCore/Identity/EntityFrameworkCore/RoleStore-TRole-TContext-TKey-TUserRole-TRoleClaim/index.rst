

RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim> Class
=============================================================






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
* :dn:cls:`Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore\<TRole, TContext, TKey, TUserRole, TRoleClaim>`








Syntax
------

.. code-block:: csharp

    public abstract class RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim> : IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<TKey, TUserRole, TRoleClaim> where TContext : DbContext where TKey : IEquatable<TKey> where TUserRole : IdentityUserRole<TKey> where TRoleClaim : IdentityRoleClaim<TKey>








.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore`5
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.RoleStore(TContext, Microsoft.AspNetCore.Identity.IdentityErrorDescriber)
    
        
    
        
        :type context: TContext
    
        
        :type describer: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public RoleStore(TContext context, IdentityErrorDescriber describer = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.AddClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Adds the <em>claim</em> given to the specified <em>role</em>.
    
        
    
        
        :param role: The role to add the claim to.
        
        :type role: TRole
    
        
        :param claim: The claim to add to the role.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.ConvertIdFromString(System.String)
    
        
    
        
        Converts the provided <em>id</em> to a strongly typed key object.
    
        
    
        
        :param id: The id to convert.
        
        :type id: System.String
        :rtype: TKey
        :return: An instance of <em>TKey</em> representing the provided <em>id</em>.
    
        
        .. code-block:: csharp
    
            public virtual TKey ConvertIdFromString(string id)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.ConvertIdToString(TKey)
    
        
    
        
        Converts the provided <em>id</em> to its string representation.
    
        
    
        
        :param id: The id to convert.
        
        :type id: TKey
        :rtype: System.String
        :return: An :any:`System.String` representation of the provided <em>id</em>.
    
        
        .. code-block:: csharp
    
            public virtual string ConvertIdToString(TKey id)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.CreateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Creates a new role in a store as an asynchronous operation.
    
        
    
        
        :param role: The role to create in the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.CreateRoleClaim(TRole, System.Security.Claims.Claim)
    
        
    
        
        Creates a entity representing a role claim.
    
        
    
        
        :type role: TRole
    
        
        :type claim: System.Security.Claims.Claim
        :rtype: TRoleClaim
    
        
        .. code-block:: csharp
    
            protected abstract TRoleClaim CreateRoleClaim(TRole role, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.DeleteAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Deletes a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role to delete from the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.Dispose()
    
        
    
        
        Dispose the stores
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds the role who has the specified ID as an asynchronous operation.
    
        
    
        
        :param id: The role ID to look for.
        
        :type id: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: A :any:`System.Threading.Tasks.Task\`1` that result of the look up.
    
        
        .. code-block:: csharp
    
            public virtual Task<TRole> FindByIdAsync(string id, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds the role who has the specified normalized name as an asynchronous operation.
    
        
    
        
        :param normalizedName: The normalized role name to look for.
        
        :type normalizedName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: A :any:`System.Threading.Tasks.Task\`1` that result of the look up.
    
        
        .. code-block:: csharp
    
            public virtual Task<TRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.GetClaimsAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Get the claims associated with the specified <em>role</em> as an asynchronous operation.
    
        
    
        
        :param role: The role whose claims should be retrieved.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the claims granted to a role.
    
        
        .. code-block:: csharp
    
            public Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.GetNormalizedRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Get a role's normalized name as an asynchronous operation.
    
        
    
        
        :param role: The role whose normalized name should be retrieved.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the name of the role.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.GetRoleIdAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Gets the ID for a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role whose ID should be returned.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the ID of the role.
    
        
        .. code-block:: csharp
    
            public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.GetRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Gets the name of a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role whose name should be returned.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the name of the role.
    
        
        .. code-block:: csharp
    
            public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.RemoveClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Removes the <em>claim</em> given from the specified <em>role</em>.
    
        
    
        
        :param role: The role to remove the claim from.
        
        :type role: TRole
    
        
        :param claim: The claim to remove from the role.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.SetNormalizedRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        
        Set a role's normalized name as an asynchronous operation.
    
        
    
        
        :param role: The role whose normalized name should be set.
        
        :type role: TRole
    
        
        :param normalizedName: The normalized name to set
        
        :type normalizedName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.SetRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the name of a role in the store as an asynchronous operation.
    
        
    
        
        :param role: The role whose name should be set.
        
        :type role: TRole
    
        
        :param roleName: The name of the role.
        
        :type roleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.ThrowIfDisposed()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowIfDisposed()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.UpdateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Updates a role in a store as an asynchronous operation.
    
        
    
        
        :param role: The role to update in the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.AutoSaveChanges
    
        
    
        
        Gets or sets a flag indicating if changes should be persisted after CreateAsync, UpdateAsync and DeleteAsync are called.
    
        
        :rtype: System.Boolean
        :return: 
            True if changes should be automatically persisted, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool AutoSaveChanges { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.Context
    
        
    
        
        Gets the database context for this store.
    
        
        :rtype: TContext
    
        
        .. code-block:: csharp
    
            public TContext Context { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.ErrorDescriber
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` for any error that occurred with the current operation.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
            public IdentityErrorDescriber ErrorDescriber { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.EntityFrameworkCore.RoleStore<TRole, TContext, TKey, TUserRole, TRoleClaim>.Roles
    
        
    
        
        A navigation property for the roles the store contains.
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TRole}
    
        
        .. code-block:: csharp
    
            public virtual IQueryable<TRole> Roles { get; }
    

