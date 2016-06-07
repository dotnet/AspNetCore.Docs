

IUserPasswordStore<TUser> Interface
===================================






Provides an abstraction for a store containing users' password hashes..


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

    public interface IUserPasswordStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserPasswordStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>.GetPasswordHashAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the password hash for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose password hash to retrieve.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning the password hash for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>.HasPasswordAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets a flag indicating whether the specified <em>user</em> has a password.
    
        
    
        
        :param user: The user to return a flag for, indicating whether they have a password or not.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, returning true if the specified <em>user</em> has a password
            otherwise false.
    
        
        .. code-block:: csharp
    
            Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserPasswordStore<TUser>.SetPasswordHashAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the password hash for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose password hash to set.
        
        :type user: TUser
    
        
        :param passwordHash: The password hash to set.
        
        :type passwordHash: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
    

