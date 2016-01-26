

IUserPhoneNumberStore<TUser> Interface
======================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store containing users' telephone numbers.











Syntax
------

.. code-block:: csharp

   public interface IUserPhoneNumberStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IUserPhoneNumberStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>.GetPhoneNumberAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the telephone number, if any, for the specified ``user``.
    
        
        
        
        :param user: The user whose telephone number should be retrieved.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the user's telephone number, if any.
    
        
        .. code-block:: csharp
    
           Task<string> GetPhoneNumberAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>.GetPhoneNumberConfirmedAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets a flag indicating whether the specified ``user``'s telephone number has been confirmed.
    
        
        
        
        :param user: The user to return a flag for, indicating whether their telephone number is confirmed.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, returning true if the specified <paramref name="user" /> has a confirmed
            telephone number otherwise false.
    
        
        .. code-block:: csharp
    
           Task<bool> GetPhoneNumberConfirmedAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>.SetPhoneNumberAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the telephone number for the specified ``user``.
    
        
        
        
        :param user: The user whose telephone number should be set.
        
        :type user: {TUser}
        
        
        :param phoneNumber: The telephone number to set.
        
        :type phoneNumber: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetPhoneNumberAsync(TUser user, string phoneNumber, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserPhoneNumberStore<TUser>.SetPhoneNumberConfirmedAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        Sets a flag indicating if the specified ``user``'s phone number has been confirmed..
    
        
        
        
        :param user: The user whose telephone number confirmation status should be set.
        
        :type user: {TUser}
        
        
        :param confirmed: A flag indicating whether the user's telephone number has been confirmed.
        
        :type confirmed: System.Boolean
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
    

