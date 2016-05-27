

IUserTwoFactorStore<TUser> Interface
====================================






Provides an abstraction to store a flag indicating whether a user has two factor authentication enabled.


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

    public interface IUserTwoFactorStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserTwoFactorStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserTwoFactorStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserTwoFactorStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserTwoFactorStore<TUser>.GetTwoFactorEnabledAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Returns a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing a flag indicating whether the specified 
            <em>user</em> has two factor authentication enabled or not.
    
        
        .. code-block:: csharp
    
            Task<bool> GetTwoFactorEnabledAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserTwoFactorStore<TUser>.SetTwoFactorEnabledAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Sets a flag indicating whether the specified <em>user</em> has two factor authentication enabled or not,
        as an asynchronous operation.
    
        
    
        
        :param user: The user whose two factor authentication enabled status should be set.
        
        :type user: TUser
    
        
        :param enabled: A flag indicating whether the specified <em>user</em> has two factor authentication enabled.
        
        :type enabled: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetTwoFactorEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken)
    

