

IUserStore<TUser> Interface
===========================






Provides an abstraction for a store which manages user accounts.


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

    public interface IUserStore<TUser> : IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.CreateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Creates the specified <em>user</em> in the user store.
    
        
    
        
        :param user: The user to create.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the creation operation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.DeleteAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Deletes the specified <em>user</em> from the user store.
    
        
    
        
        :param user: The user to delete.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the update operation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds and returns a user, if any, who has the specified <em>userId</em>.
    
        
    
        
        :param userId: The user ID to search for.
        
        :type userId: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>userId</em> if it exists.
    
        
        .. code-block:: csharp
    
            Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        
        Finds and returns a user, if any, who has the specified normalized user name.
    
        
    
        
        :param normalizedUserName: The normalized user name to search for.
        
        :type normalizedUserName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the user matching the specified <em>normalizedUserName</em> if it exists.
    
        
        .. code-block:: csharp
    
            Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.GetNormalizedUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the normalized user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose normalized name should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the normalized user name for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.GetUserIdAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the user identifier for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose identifier should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the identifier for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.GetUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the user name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the name for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.SetNormalizedUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the given normalized name for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be set.
        
        :type user: TUser
    
        
        :param normalizedName: The normalized name to set.
        
        :type normalizedName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.SetUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the given <em>userName</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose name should be set.
        
        :type user: TUser
    
        
        :param userName: The user name to set.
        
        :type userName: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserStore<TUser>.UpdateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Updates the specified <em>user</em> in the user store.
    
        
    
        
        :param user: The user to update.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Identity.IdentityResult<Microsoft.AspNetCore.Identity.IdentityResult>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the :any:`Microsoft.AspNetCore.Identity.IdentityResult` of the update operation.
    
        
        .. code-block:: csharp
    
            Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
    

