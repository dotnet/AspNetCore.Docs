

IUserPasswordStore<TUser> Interface
===================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store containing users' password hashes..











Syntax
------

.. code-block:: csharp

   public interface IUserPasswordStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserPasswordStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserPasswordStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserPasswordStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPasswordStore<TUser>.GetPasswordHashAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the password hash for the specified ``user``.
    
        
        
        
        :param user: The user whose password hash to retrieve.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning the password hash for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetPasswordHashAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPasswordStore<TUser>.HasPasswordAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets a flag indicating whether the specified ``user`` has a password.
    
        
        
        
        :param user: The user to return a flag for, indicating whether they have a password or not.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the specified <paramref name="user" /> has a password
            otherwise false.
    
        
        .. code-block:: csharp
    
           Task<bool> HasPasswordAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPasswordStore<TUser>.SetPasswordHashAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the password hash for the specified ``user``.
    
        
        
        
        :param user: The user whose password hash to set.
        
        :type user: {TUser}
        
        
        :param passwordHash: The password hash to set.
        
        :type passwordHash: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetPasswordHashAsync(TUser user, string passwordHash, CancellationToken cancellationToken)
    

