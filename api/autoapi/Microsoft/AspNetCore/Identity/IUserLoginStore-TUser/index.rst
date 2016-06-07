

IUserLoginStore<TUser> Interface
================================






Provides an abstraction for storing information that maps external login information provided
by Microsoft Account, Facebook etc. to a user account.


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

    public interface IUserLoginStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLoginStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>.AddLoginAsync(TUser, Microsoft.AspNetCore.Identity.UserLoginInfo, System.Threading.CancellationToken)
    
        
    
        
        Adds an external :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` to the specified <em>user</em>.
    
        
    
        
        :param user: The user to add the login to.
        
        :type user: TUser
    
        
        :param login: The external :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` to add to the specified <em>user</em>.
        
        :type login: Microsoft.AspNetCore.Identity.UserLoginInfo
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task AddLoginAsync(TUser user, UserLoginInfo login, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>.FindByLoginAsync(System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the user associated with the specified login provider and login provider key..
    
        
    
        
        :param loginProvider: The login provider who provided the <em>providerKey</em>.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key provided by the <em>loginProvider</em> to identify a user.
        
        :type providerKey: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{TUser}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing the user, if any which matched the specified login provider and key.
    
        
        .. code-block:: csharp
    
            Task<TUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>.GetLoginsAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the associated logins for the specified <param ref="user" />.
    
        
    
        
        :param user: The user whose associated logins to retrieve.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Identity.UserLoginInfo<Microsoft.AspNetCore.Identity.UserLoginInfo>}}
        :return: 
            The :any:`System.Threading.Tasks.Task` for the asynchronous operation, containing a list of :any:`Microsoft.AspNetCore.Identity.UserLoginInfo` for the specified <em>user</em>, if any.
    
        
        .. code-block:: csharp
    
            Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLoginStore<TUser>.RemoveLoginAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Attempts to remove the provided login information from the specified <em>user</em>.
        and returns a flag indicating whether the removal succeed or not.
    
        
    
        
        :param user: The user to remove the login information from.
        
        :type user: TUser
    
        
        :param loginProvider: The login provide whose information should be removed.
        
        :type loginProvider: System.String
    
        
        :param providerKey: The key given by the external login provider for the specified user.
        
        :type providerKey: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task RemoveLoginAsync(TUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
    

