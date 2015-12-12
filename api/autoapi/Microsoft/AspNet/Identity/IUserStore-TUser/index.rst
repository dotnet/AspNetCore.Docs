

IUserStore<TUser> Interface
===========================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store which manages user accounts.











Syntax
------

.. code-block:: csharp

   public interface IUserStore<TUser> : IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.CreateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Creates the specified ``user`` in the user store.
    
        
        
        
        :param user: The user to create.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the creation operation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> CreateAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.DeleteAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Deletes the specified ``user`` from the user store.
    
        
        
        
        :param user: The user to delete.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the update operation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> DeleteAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.FindByIdAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Finds and returns a user, if any, who has the specified ``userId``.
    
        
        
        
        :param userId: The user ID to search for.
        
        :type userId: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID" /> if it exists.
    
        
        .. code-block:: csharp
    
           Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.FindByNameAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Finds and returns a user, if any, who has the specified normalized user name.
    
        
        
        
        :param normalizedUserName: The normalized user name to search for.
        
        :type normalizedUserName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user matching the specified <paramref name="userID" /> if it exists.
    
        
        .. code-block:: csharp
    
           Task<TUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.GetNormalizedUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the normalized user name for the specified ``user``.
    
        
        
        
        :param user: The user whose normalized name should be retrieved.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the normalized user name for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetNormalizedUserNameAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.GetUserIdAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the user identifier for the specified ``user``.
    
        
        
        
        :param user: The user whose identifier should be retrieved.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the identifier for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetUserIdAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.GetUserNameAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the user name for the specified ``user``.
    
        
        
        
        :param user: The user whose name should be retrieved.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the name for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetUserNameAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.SetNormalizedUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the given normalized name for the specified ``user``.
    
        
        
        
        :param user: The user whose name should be set.
        
        :type user: {TUser}
        
        
        :param normalizedName: The normalized name to set.
        
        :type normalizedName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetNormalizedUserNameAsync(TUser user, string normalizedName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.SetUserNameAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the given ``userName`` for the specified ``user``.
    
        
        
        
        :param user: The user whose name should be set.
        
        :type user: {TUser}
        
        
        :param userName: The user name to set.
        
        :type userName: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetUserNameAsync(TUser user, string userName, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserStore<TUser>.UpdateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Updates the specified ``user`` in the user store.
    
        
        
        
        :param user: The user to update.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{Microsoft.AspNet.Identity.IdentityResult}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the <see cref="T:Microsoft.AspNet.Identity.IdentityResult" /> of the update operation.
    
        
        .. code-block:: csharp
    
           Task<IdentityResult> UpdateAsync(TUser user, CancellationToken cancellationToken)
    

