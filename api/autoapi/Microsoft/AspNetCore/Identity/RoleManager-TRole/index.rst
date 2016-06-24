

RoleManager<TRole> Class
========================






Provides the APIs for managing roles in a persistence store.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.RoleManager\<TRole>`








Syntax
------

.. code-block:: csharp

    public class RoleManager<TRole> : IDisposable where TRole : class








.. dn:class:: Microsoft.AspNetCore.Identity.RoleManager`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.RoleManager<TRole>

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.RoleManager(Microsoft.AspNetCore.Identity.IRoleStore<TRole>, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Identity.IRoleValidator<TRole>>, Microsoft.AspNetCore.Identity.ILookupNormalizer, Microsoft.AspNetCore.Identity.IdentityErrorDescriber, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Identity.RoleManager<TRole>>, Microsoft.AspNetCore.Http.IHttpContextAccessor)
    
        
    
        
        Constructs a new instance of :any:`Microsoft.AspNetCore.Identity.RoleManager\`1`\.
    
        
    
        
        :param store: The persistence store the manager will operate over.
        
        :type store: Microsoft.AspNetCore.Identity.IRoleStore<Microsoft.AspNetCore.Identity.IRoleStore`1>{TRole}
    
        
        :param roleValidators: A collection of validators for roles.
        
        :type roleValidators: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Identity.IRoleValidator<Microsoft.AspNetCore.Identity.IRoleValidator`1>{TRole}}
    
        
        :param keyNormalizer: The normalizer to use when normalizing role names to keys.
        
        :type keyNormalizer: Microsoft.AspNetCore.Identity.ILookupNormalizer
    
        
        :param errors: The :any:`Microsoft.AspNetCore.Identity.IdentityErrorDescriber` used to provider error messages.
        
        :type errors: Microsoft.AspNetCore.Identity.IdentityErrorDescriber
    
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Identity.RoleManager<Microsoft.AspNetCore.Identity.RoleManager`1>{TRole}}
    
        
        :param contextAccessor: The accessor used to access the :any:`Microsoft.AspNetCore.Http.HttpContext`\.
        
        :type contextAccessor: Microsoft.AspNetCore.Http.IHttpContextAccessor
    
        
        .. code-block:: csharp
    
            public RoleManager(IRoleStore<TRole> store, IEnumerable<IRoleValidator<TRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<TRole>> logger, IHttpContextAccessor contextAccessor)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.AddClaimAsync(TRole, System.Security.Claims.Claim)
    
        
    
        
        Adds a claim to a role.
    
        
    
        
        :param role: The role to add the claim to.
        
        :type role: TRole
    
        
        :param claim: The claim to add.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> AddClaimAsync(TRole role, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.CreateAsync(TRole)
    
        
    
        
        Creates the specified <em>role</em> in the persistence store.
    
        
    
        
        :param role: The role to create.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> CreateAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.DeleteAsync(TRole)
    
        
    
        
        Deletes the specified <em>role</em>.
    
        
    
        
        :param role: The role to delete.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` for the delete.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> DeleteAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.Dispose()
    
        
    
        
        Releases all resources used by the role manager.
    
        
    
        
        .. code-block:: csharp
    
            public void Dispose()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.Dispose(System.Boolean)
    
        
    
        
        Releases the unmanaged resources used by the role manager and optionally releases the managed resources.
    
        
    
        
        :param disposing: true to release both managed and unmanaged resources; false to release only unmanaged resources.
        
        :type disposing: System.Boolean
    
        
        .. code-block:: csharp
    
            protected virtual void Dispose(bool disposing)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.FindByIdAsync(System.String)
    
        
    
        
        Finds the role associated with the specified <em>roleId</em> if any.
    
        
    
        
        :param roleId: The role ID whose role should be returned.
        
        :type roleId: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the role 
            associated with the specified <em>roleId</em>
    
        
        .. code-block:: csharp
    
            public virtual Task<TRole> FindByIdAsync(string roleId)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.FindByNameAsync(System.String)
    
        
    
        
        Finds the role associated with the specified <em>roleName</em> if any.
    
        
    
        
        :param roleName: The name of the role to be returned.
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the role 
            associated with the specified <em>roleName</em>
    
        
        .. code-block:: csharp
    
            public virtual Task<TRole> FindByNameAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.GetClaimsAsync(TRole)
    
        
    
        
        Gets a list of claims associated with the specified <em>role</em>.
    
        
    
        
        :param role: The role whose claims should be returned.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the list of :any:`System.Security.Claims.Claim`\s
            associated with the specified <em>role</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<IList<Claim>> GetClaimsAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.GetRoleIdAsync(TRole)
    
        
    
        
        Gets the ID of the specified <em>role</em>.
    
        
    
        
        :param role: The role whose ID should be retrieved.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the ID of the 
            specified <em>role</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetRoleIdAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.GetRoleNameAsync(TRole)
    
        
    
        
        Gets the name of the specified <em>role</em>.
    
        
    
        
        :param role: The role whose name should be retrieved.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the name of the 
            specified <em>role</em>.
    
        
        .. code-block:: csharp
    
            public virtual Task<string> GetRoleNameAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.NormalizeKey(System.String)
    
        
    
        
        Gets a normalized representation of the specified <em>key</em>.
    
        
    
        
        :param key: The value to normalize.
        
        :type key: System.String
        :rtype: System.String
        :return: A normalized representation of the specified <em>key</em>.
    
        
        .. code-block:: csharp
    
            public virtual string NormalizeKey(string key)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.RemoveClaimAsync(TRole, System.Security.Claims.Claim)
    
        
    
        
        Removes a claim from a role.
    
        
    
        
        :param role: The role to remove the claim from.
        
        :type role: TRole
    
        
        :param claim: The claim to remove.
        
        :type claim: System.Security.Claims.Claim
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.RoleExistsAsync(System.String)
    
        
    
        
        Gets a flag indicating whether the specified <em>roleName</em> exists.
    
        
    
        
        :param roleName: The role name whose existence should be checked.
        
        :type roleName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing true if the role name exists, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual Task<bool> RoleExistsAsync(string roleName)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.SetRoleNameAsync(TRole, System.String)
    
        
    
        
        Sets the name of the specified <em>role</em>.
    
        
    
        
        :param role: The role whose name should be set.
        
        :type role: TRole
    
        
        :param name: The name to set.
        
        :type name: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult`
            of the operation.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> SetRoleNameAsync(TRole role, string name)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.ThrowIfDisposed()
    
        
    
        
        .. code-block:: csharp
    
            protected void ThrowIfDisposed()
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.UpdateAsync(TRole)
    
        
    
        
        Updates the specified <em>role</em>.
    
        
    
        
        :param role: The role to updated.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` for the update.
    
        
        .. code-block:: csharp
    
            public virtual Task<IdentityResult> UpdateAsync(TRole role)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.UpdateNormalizedRoleNameAsync(TRole)
    
        
    
        
        Updates the normalized name for the specified <em>role</em>.
    
        
    
        
        :param role: The role whose normalized name needs to be updated.
        
        :type role: TRole
        :rtype: System.Threading.Tasks.Task
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            public virtual Task UpdateNormalizedRoleNameAsync(TRole role)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.RoleManager<TRole>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.Logger
    
        
    
        
        Gets the :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        :rtype: Microsoft.Extensions.Logging.ILogger
        :return: 
            The :any:`Microsoft.Extensions.Logging.ILogger` used to log messages from the manager.
    
        
        .. code-block:: csharp
    
            protected virtual ILogger Logger { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.Roles
    
        
    
        
        Gets an IQueryable collection of Roles if the persistence store is an :any:`Microsoft.AspNetCore.Identity.IQueryableRoleStore\`1`\,
        otherwise throws a :any:`System.NotSupportedException`\.
    
        
        :rtype: System.Linq.IQueryable<System.Linq.IQueryable`1>{TRole}
        :return: An IQueryable collection of Roles if the persistence store is an :any:`Microsoft.AspNetCore.Identity.IQueryableRoleStore\`1`\.
    
        
        .. code-block:: csharp
    
            public virtual IQueryable<TRole> Roles { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.Store
    
        
    
        
        Gets the persistence store this instance operates over.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IRoleStore<Microsoft.AspNetCore.Identity.IRoleStore`1>{TRole}
        :return: The persistence store this instance operates over.
    
        
        .. code-block:: csharp
    
            protected IRoleStore<TRole> Store { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.SupportsQueryableRoles
    
        
    
        
        Gets a flag indicating whether the underlying persistence store supports returning an :any:`System.Linq.IQueryable` collection of roles.
    
        
        :rtype: System.Boolean
        :return: 
            true if the underlying persistence store supports returning an :any:`System.Linq.IQueryable` collection of roles, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsQueryableRoles { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.RoleManager<TRole>.SupportsRoleClaims
    
        
    
        
        Gets a flag indicating whether the underlying persistence store supports :any:`System.Security.Claims.Claim`\s for roles.
    
        
        :rtype: System.Boolean
        :return: 
            true if the underlying persistence store supports :any:`System.Security.Claims.Claim`\s for roles, otherwise false.
    
        
        .. code-block:: csharp
    
            public virtual bool SupportsRoleClaims { get; }
    

