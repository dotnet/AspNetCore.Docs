

IUserLoginStore<TUser> Interface
================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for storing information that maps external login information provided
by Microsoft Account, Facebook etc. to a user account.











Syntax
------

.. code-block:: csharp

   public interface IUserLoginStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserLoginStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>.AddLoginAsync(TUser, Microsoft.AspNet.Identity.UserLoginInfo, System.Threading.CancellationToken)
    
        
    
        Adds an external :any:`Microsoft.AspNet.Identity.UserLoginInfo` to the specified ``user``.
    
        
        
        
        :param user: The user to add the login to.
        
        :type user: {TUser}
        
        
        :param login: The external  to add to the specified .
        
        :type login: Microsoft.AspNet.Identity.UserLoginInfo
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>.FindByLoginAsync(System.String, System.String, System.Threading.CancellationToken)
    
        
    
        Retrieves the user associated with the specified login provider and login provider key..
    
        
        
        
        :param loginProvider: The login provider who provided the .
        
        :type loginProvider: System.String
        
        
        :param providerKey: The key provided by the  to identify a user.
        
        :type providerKey: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    
        
        .. code-block:: csharp
    
           Task<TUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>.GetLoginsAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Retrieves the associated logins for the specified <param ref="user" />.
    
        
        
        
        :param user: The user whose associated logins to retrieve.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{Microsoft.AspNet.Identity.UserLoginInfo}}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> for the asynchronous operation, containing a list of <see cref="T:Microsoft.AspNet.Identity.UserLoginInfo" /> for the specified <paramref name="user" />, if any.
    
        
        .. code-block:: csharp
    
           Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserLoginStore<TUser>.RemoveLoginAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        Attempts to remove the provided login information from the specified ``user``.
        and returns a flag indicating whether the removal succeed or not.
    
        
        
        
        :param user: The user to remove the login information from.
        
        :type user: {TUser}
        
        
        :param loginProvider: The login provide whose information should be removed.
        
        :type loginProvider: System.String
        
        
        :param providerKey: The key given by the external login provider for the specified user.
        
        :type providerKey: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that contains a flag the result of the asynchronous removing operation. The flag will be true if
            the login information was existed and removed, otherwise false.
    
        
        .. code-block:: csharp
    
           Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    

