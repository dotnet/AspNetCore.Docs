

RoleManager<TRole> Class
========================



.. contents:: 
   :local:



Summary
-------

Provides the APIs for managing roles in a persistence store.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.RoleManager\<TRole>`








Syntax
------

.. code-block:: csharp

   public class RoleManager<TRole> : IDisposable where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/RoleManager.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.RoleManager<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.RoleManager<TRole>.RoleManager(Microsoft.AspNet.Identity.IRoleStore<TRole>, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Identity.IRoleValidator<TRole>>, Microsoft.AspNet.Identity.ILookupNormalizer, Microsoft.AspNet.Identity.IdentityErrorDescriber, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNet.Identity.RoleManager<TRole>>, Microsoft.AspNet.Http.IHttpContextAccessor)
    
        
    
        Constructs a new instance of :any:`Microsoft.AspNet.Identity.RoleManager\`1`\.
    
        
        
        
        :param store: The persistence store the manager will operate over.
        
        :type store: Microsoft.AspNet.Identity.IRoleStore{{TRole}}
        
        
        :param roleValidators: A collection of validators for roles.
        
        :type roleValidators: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Identity.IRoleValidator{{TRole}}}
        
        
        :param keyNormalizer: The normalizer to use when normalizing role names to keys.
        
        :type keyNormalizer: Microsoft.AspNet.Identity.ILookupNormalizer
        
        
        :param errors: The  used to provider error messages.
        
        :type errors: Microsoft.AspNet.Identity.IdentityErrorDescriber
        
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger{Microsoft.AspNet.Identity.RoleManager`1}
        
        
        :param contextAccessor: The accessor used to access the .
        
        :type contextAccessor: Microsoft.AspNet.Http.IHttpContextAccessor
    
        
        .. code-block:: csharp
    
           public RoleManager(IRoleStore<TRole> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger, IHttpContextAccessor contextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.AddClaimAsync(TRole, System.Security.Claims.Claim)
    
        
    
        Adds a claim to a role.
    
        
        
        
        :param role: The role to add the claim to.
        
        :type role: {TRole}
        
        
        :param claim: The claim to add.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> AddClaimAsync(TRole role, Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.CreateAsync(TRole)
    
        
    
        Creates the specified ``role`` in the persistence store.
    
        
        
        
        :param role: The role to create.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> CreateAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.DeleteAsync(TRole)
    
        
    
        Deletes the specified ``role``.
    
        
        
        
        :param role: The role to delete.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> for the delete.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> DeleteAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.Dispose()
    
        
    
        Releases all resources used by the role manager.
    
        
    
        
        .. code-block:: csharp
    
           public void Dispose()
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.Dispose(System.Boolean)
    
        
    
        Releases the unmanaged resources used by the role manager and optionally releases the managed resources.
    
        
        
        
        :param disposing: true to release both managed and unmanaged resources; false to release only unmanaged resources.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
           protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.FindByIdAsync(System.String)
    
        
    
        Finds the role associated with the specified ``roleId`` if any.
    
        
        
        
        :param roleId: The role ID whose role should be returned.
        
        :type roleId: System.String
        :rtype: System.Threading.Tasks.Task{{TRole}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the role
            associated with the specified <paramref name="roleId" />
    
        
        .. code-block:: csharp
    
           public virtual Task<TRole> FindByIdAsync(string roleId)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.FindByNameAsync(System.String)
    
        
    
        Finds the role associated with the specified ``roleName`` if any.
    
        
        
        
        :param roleName: The name of the role to be returned.
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task{{TRole}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the role
            associated with the specified <paramref name="roleName" />
    
        
        .. code-block:: csharp
    
           public virtual Task<TRole> FindByNameAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.GetClaimsAsync(TRole)
    
        
    
        Gets a list of claims associated with the specified ``role``.
    
        
        
        
        :param role: The role whose claims should be returned.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.Security.Claims.Claim}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the list of <see cref="T:System.Security.Claims.Claim" />s
            associated with the specified <paramref name="role" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<IList<Claim>> GetClaimsAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.GetRoleIdAsync(TRole)
    
        
    
        Gets the ID of the specified ``role``.
    
        
        
        
        :param role: The role whose ID should be retrieved.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the ID of the
            specified <paramref name="role" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetRoleIdAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.GetRoleNameAsync(TRole)
    
        
    
        Gets the name of the specified ``role``.
    
        
        
        
        :param role: The role whose name should be retrieved.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the name of the
            specified <paramref name="role" />.
    
        
        .. code-block:: csharp
    
           public virtual Task<string> GetRoleNameAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.NormalizeKey(System.String)
    
        
    
        Gets a normalized representation of the specified ``key``.
    
        
        
        
        :param key: The value to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <paramref name="key" />.
    
        
        .. code-block:: csharp
    
           public virtual string NormalizeKey(string key)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.RemoveClaimAsync(TRole, System.Security.Claims.Claim)
    
        
    
        Removes a claim from a role.
    
        
        
        
        :param role: The role to remove the claim from.
        
        :type role: {TRole}
        
        
        :param claim: The claim to add.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.RoleExistsAsync(System.String)
    
        
    
        Gets a flag indicating whether the specified ``roleName`` exists.
    
        
        
        
        :param roleName: The role name whose existence should be checked.
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing true if the role name exists, otherwise false.
    
        
        .. code-block:: csharp
    
           public virtual Task<bool> RoleExistsAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.SetRoleNameAsync(TRole, System.String)
    
        
    
        Sets the name of the specified ``role``.
    
        
        
        
        :param role: The role whose name should be set.
        
        :type role: {TRole}
        
        
        :param name: The name to set.
        
        :type name: System.String
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" />
            of the operation.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> SetRoleNameAsync(TRole role, string name)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.UpdateAsync(TRole)
    
        
    
        Updates the specified ``role``.
    
        
        
        
        :param role: The role to updated.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> for the update.
    
        
        .. code-block:: csharp
    
           public virtual Task<IdentityResult> UpdateAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNet.Identity.RoleManager<TRole>.UpdateNormalizedRoleNameAsync(TRole)
    
        
    
        Updates the normalized name for the specified ``role``.
    
        
        
        
        :param role: The role whose normalized name needs to be updated.
        
        :type role: {TRole}
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           public virtual Task UpdateNormalizedRoleNameAsync(TRole role)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.RoleManager<TRole>.Logger
    
        
    
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
    
        
        .. code-block:: csharp
    
           protected virtual ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.RoleManager<TRole>.Roles
    
        
    
        Gets an IQueryable collection of Roles if the persistence store is an IQueryableRoleStore\,
        otherwise throws a :any:`System.NotSupportedException`\.
    
        
        :rtype: System.Linq.IQueryable{{TRole}}
    
        
        .. code-block:: csharp
    
           public virtual IQueryable<TRole> Roles { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.RoleManager<TRole>.Store
    
        
    
        Gets the persistence store this instance operates over.
    
        
        :rtype: Microsoft.AspNet.Identity.IRoleStore{{TRole}}
    
        
        .. code-block:: csharp
    
           protected IRoleStore<TRole> Store { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.RoleManager<TRole>.SupportsQueryableRoles
    
        
    
        Gets a flag indicating whether the underlying persistence store supports returning an :any:`System.Linq.IQueryable` collection of roles.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsQueryableRoles { get; }
    
    .. dn:property:: Microsoft.AspNet.Identity.RoleManager<TRole>.SupportsRoleClaims
    
        
    
        Gets a flag indicating whether the underlying persistence store supports :any:`System.Security.Claims.Claim`\s for roles.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public virtual bool SupportsRoleClaims { get; }
    

