

IRoleStore<TRole> Interface
===========================






Provides an abstraction for a storage and management of roles.


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

    public interface IRoleStore<TRole> : IDisposable where TRole : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.CreateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Creates a new role in a store as an asynchronous operation.
    
        
    
        
        :param role: The role to create in the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> CreateAsync(TRole role, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.DeleteAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Deletes a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role to delete from the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> DeleteAsync(TRole role, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds the role who has the specified ID as an asynchronous operation.
    
        
    
        
        :param roleId: The role ID to look for.
        
        :type roleId: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: A :any:`System.Threading.Tasks.Task\`1` that result of the look up.
    
        
        .. code-block:: csharp
    
            Task<TRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds the role who has the specified normalized name as an asynchronous operation.
    
        
    
        
        :param normalizedRoleName: The normalized role name to look for.
        
        :type normalizedRoleName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TRole}
        :return: A :any:`System.Threading.Tasks.Task\`1` that result of the look up.
    
        
        .. code-block:: csharp
    
            Task<TRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.GetNormalizedRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Get a role's normalized name as an asynchronous operation.
    
        
    
        
        :param role: The role whose normalized name should be retrieved.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the name of the role.
    
        
        .. code-block:: csharp
    
            Task<string> GetNormalizedRoleNameAsync(TRole role, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.GetRoleIdAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Gets the ID for a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role whose ID should be returned.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the ID of the role.
    
        
        .. code-block:: csharp
    
            Task<string> GetRoleIdAsync(TRole role, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.GetRoleNameAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Gets the name of a role from the store as an asynchronous operation.
    
        
    
        
        :param role: The role whose name should be returned.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that contains the name of the role.
    
        
        .. code-block:: csharp
    
            Task<string> GetRoleNameAsync(TRole role, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.SetNormalizedRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        
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
    
            Task SetNormalizedRoleNameAsync(TRole role, string normalizedName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.SetRoleNameAsync(TRole, System.String, System.Threading.CancellationToken)
    
        
    
        
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
    
            Task SetRoleNameAsync(TRole role, string roleName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleStore<TRole>.UpdateAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
        Updates a role in a store as an asynchronous operation.
    
        
    
        
        :param role: The role to update in the store.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: A :any:`System.Threading.Tasks.Task\`1` that represents the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the asynchronous query.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> UpdateAsync(TRole role, CancellationToken cancellationToken)
    

