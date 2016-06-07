

IUserLockoutStore<TUser> Interface
==================================






Provides an abstraction for a storing information which can be used to implement account lockout, 
including access failures and lockout status


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

    public interface IUserLockoutStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLockoutStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.GetAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves the current failed access count for the specified <em>user</em>..
    
        
    
        
        :param user: The user whose failed access count should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the failed access count.
    
        
        .. code-block:: csharp
    
            Task<int> GetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.GetLockoutEnabledAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Retrieves a flag indicating whether user lockout can enabled for the specified user.
    
        
    
        
        :param user: The user whose ability to be locked out should be returned.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, true if a user can be locked out, otherwise false.
    
        
        .. code-block:: csharp
    
            Task<bool> GetLockoutEnabledAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.GetLockoutEndDateAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Gets the last :any:`System.DateTimeOffset` a user's last lockout expired, if any.
        Any time in the past should be indicates a user is not locked out.
    
        
    
        
        :param user: The user whose lockout date should be retrieved.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a :any:`System.DateTimeOffset` containing the last time
            a user's lockout expired, if any.
    
        
        .. code-block:: csharp
    
            Task<DateTimeOffset? > GetLockoutEndDateAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.IncrementAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Records that a failed access has occurred, incrementing the failed access count.
    
        
    
        
        :param user: The user whose cancellation count should be incremented.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Int32<System.Int32>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the incremented failed access count.
    
        
        .. code-block:: csharp
    
            Task<int> IncrementAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.ResetAccessFailedCountAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Resets a user's failed access count.
    
        
    
        
        :param user: The user whose failed access count should be reset.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task ResetAccessFailedCountAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.SetLockoutEnabledAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        
        Set the flag indicating if the specified <em>user</em> can be locked out..
    
        
    
        
        :param user: The user whose ability to be locked out should be set.
        
        :type user: TUser
    
        
        :param enabled: A flag indicating if lock out can be enabled for the specified <em>user</em>.
        
        :type enabled: System.Boolean
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetLockoutEnabledAsync(TUser user, bool enabled, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserLockoutStore<TUser>.SetLockoutEndDateAsync(TUser, System.Nullable<System.DateTimeOffset>, System.Threading.CancellationToken)
    
        
    
        
        Locks out a user until the specified end date has passed. Setting a end date in the past immediately unlocks a user.
    
        
    
        
        :param user: The user whose lockout date should be set.
        
        :type user: TUser
    
        
        :param lockoutEnd: The :any:`System.DateTimeOffset` after which the <em>user</em>'s lockout should end.
        
        :type lockoutEnd: System.Nullable<System.Nullable`1>{System.DateTimeOffset<System.DateTimeOffset>}
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetLockoutEndDateAsync(TUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
    

