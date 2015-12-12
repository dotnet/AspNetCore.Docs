

IUserTwoFactorStore<TUser> Interface
====================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction to store a flag indicating whether a user has two factor authentication enabled.











Syntax
------

.. code-block:: csharp

   public interface IUserTwoFactorStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserTwoFactorStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserTwoFactorStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserTwoFactorStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserTwoFactorStore<TUser>.GetTwoFactorEnabledAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Returns a flag indicating whether the specified ``user`` has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing a flag indicating whether the specified ``user`` has two factor authentication enabled or not.
    
        
        .. code-block:: csharp
    
           Task<bool> GetTwoFactorEnabledAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserTwoFactorStore<TUser>.SetTwoFactorEnabledAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        Sets a flag indicating whether the specified ``user`` has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
        
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: {TUser}
        
        
        :param enabled: A flag indicating whether the specified  has two factor authentication enabled.
        
        :type enabled: System.Boolean
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetTwoFactorEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken)
    

