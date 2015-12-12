

RoleStore<TRole, TContext, TKey> Class
======================================



.. contents:: 
   :local:



Summary
-------

Creates a new instance of a persistence store for roles.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.EntityFramework.RoleStore\<TRole, TContext, TKey>`








Syntax
------

.. code-block:: csharp

   public class RoleStore<TRole, TContext, TKey> : IQueryableRoleStore<TRole>, IRoleClaimStore<TRole>, IRoleStore<TRole>, IDisposable where TRole : IdentityRole<TKey> where TContext : DbContext where TKey : IEquatable<TKey>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity.EntityFramework/RoleStore.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.RoleStore(TContext, Microsoft.AspNet.Identity.IdentityErrorDescriber)
    
        
        
        
        :type context: {TContext}
        
        
        :type describer: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public RoleStore(TContext context, IdentityErrorDescriber describer = null)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.AddClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Adds the ``claim`` given to the specified ``role``.
    
        
        
        
        :param role: The role to add the claim to.
        
        :type role: {TRole}
        
        
        :param claim: The claim to add to the role.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.ConvertIdFromString(System.String)
    
        
    
        Converts the provided ``id`` to a strongly typed key object.
    
        
        
        
        :param id: The id to convert.
        
        :type id: System.String
        :rtype: {TKey}
        :return: An instance of <typeparamref name="TKey" /> representing the provided <paramref name="id" />.
    
        
        .. code-block:: csharp
    
           public virtual TKey ConvertIdFromString(string id)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.ConvertIdToString(TKey)
    
        
    
        Converts the provided ``id`` to its string representation.
    
        
        
        
        :param id: The id to convert.
        
        :type id: {TKey}
        :rtype: System.String
        :return: An <see cref="T:System.String" /> representation of the provided <paramref name="id" />.
    
        
        .. code-block:: csharp
    
           public virtual string ConvertIdToString(TKey id)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.CreateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Creates a new role in a store as an asynchronous operation.
    
        
        
        
        :param role: The role to create in the store.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the asynchronous query.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.DeleteAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Deletes a role from the store as an asynchronous operation.
    
        
        
        
        :param role: The role to delete from the store.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the asynchronous query.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.Dispose()
    
        
    
        Dispose the stores
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Finds the role who has the specified ID as an asynchronous operation.
    
        
        
        
        :type id: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TRole}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that result of the look up.
    
        
        .. code-block:: csharp
    
           public virtual Task<TRole> FindByIdAsync(string id, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Finds the role who has the specified normalized name as an asynchronous operation.
    
        
        
        
        :type normalizedName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TRole}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that result of the look up.
    
        
        .. code-block:: csharp
    
           public virtual Task<TRole> FindByNameAsync(string normalizedName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.GetClaimsAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Get the claims associated with the specified ``role`` as an asynchronous operation.
    
        
        
        
        :param role: The role whose claims should be retrieved.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.Security.Claims.Claim}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that contains the claims granted to a role.
    
        
        .. code-block:: csharp
    
           public Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.GetNormalizedRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Get a role's normalized name as an asynchronous operation.
    
        
        
        
        :param role: The role whose normalized name should be retrieved.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that contains the name of the role.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.GetRoleIdAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Gets the ID for a role from the store as an asynchronous operation.
    
        
        
        
        :param role: The role whose ID should be returned.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that contains the ID of the role.
    
        
        .. code-block:: csharp
    
           public Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.GetRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Gets the name of a role from the store as an asynchronous operation.
    
        
        
        
        :param role: The role whose name should be returned.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that contains the name of the role.
    
        
        .. code-block:: csharp
    
           public Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.RemoveClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Removes the ``claim`` given from the specified ``role``.
    
        
        
        
        :param role: The role to remove the claim from.
        
        :type role: {TRole}
        
        
        :param claim: The claim to remove from the role.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.SetNormalizedRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        Set a role's normalized name as an asynchronous operation.
    
        
        
        
        :param role: The role whose normalized name should be set.
        
        :type role: {TRole}
        
        
        :param normalizedName: The normalized name to set
        
        :type normalizedName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.SetRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the name of a role in the store as an asynchronous operation.
    
        
        
        
        :param role: The role whose name should be set.
        
        :type role: {TRole}
        
        
        :param roleName: The name of the role.
        
        :type roleName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.UpdateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Updates a role in a store as an asynchronous operation.
    
        
        
        
        :param role: The role to update in the store.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the asynchronous query.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken = null)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.AutoSaveChanges
    
        
    
        Gets or sets a flag indicating if changes should be persisted after CreateAsync, UpdateAsync and DeleteAsync are called.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool AutoSaveChanges { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.Context
    
        
    
        Gets the database context for this store.
    
        
        :rtype: {TContext}
    
        
        .. code-block:: csharp
    
           public TContext Context { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.ErrorDescriber
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.IdentityErrorDescriber` for any error that occurred with the current operation.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityErrorDescriber
    
        
        .. code-block:: csharp
    
           public IdentityErrorDescriber ErrorDescriber { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.EntityFramework.RoleStore<TRole, TContext, TKey>.Roles
    
        
    
        A navigation property for the roles the store contains.
    
        
        :rtype: System.Linq.IQueryable{{TRole}}
    
        
        .. code-block:: csharp
    
           public virtual IQueryable<TRole> Roles { get; }
    

