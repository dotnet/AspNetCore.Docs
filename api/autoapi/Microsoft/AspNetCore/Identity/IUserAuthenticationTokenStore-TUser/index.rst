

IUserAuthenticationTokenStore<TUser> Interface
==============================================






Provides an abstraction to store a user's authentication tokens.


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

    public interface IUserAuthenticationTokenStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore<TUser>.GetTokenAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Returns the token value.
    
        
    
        
        :param user: The user.
        
        :type user: TUser
    
        
        :param loginProvider: The authentication provider for the token.
        
        :type loginProvider: System.String
    
        
        :param name: The name of the token.
        
        :type name: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task<string> GetTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore<TUser>.RemoveTokenAsync(TUser, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Deletes a token for a user.
    
        
    
        
        :param user: The user.
        
        :type user: TUser
    
        
        :param loginProvider: The authentication provider for the token.
        
        :type loginProvider: System.String
    
        
        :param name: The name of the token.
        
        :type name: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            Task RemoveTokenAsync(TUser user, string loginProvider, string name, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserAuthenticationTokenStore<TUser>.SetTokenAsync(TUser, System.String, System.String, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the token value for a particular user.
    
        
    
        
        :param user: The user.
        
        :type user: TUser
    
        
        :param loginProvider: The authentication provider for the token.
        
        :type loginProvider: System.String
    
        
        :param name: The name of the token.
        
        :type name: System.String
    
        
        :param value: The value of the token.
        
        :type value: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetTokenAsync(TUser user, string loginProvider, string name, string value, CancellationToken cancellationToken)
    

