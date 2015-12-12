

IUserEmailStore<TUser> Interface
================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for the storage and management of user email addresses.











Syntax
------

.. code-block:: csharp

   public interface IUserEmailStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IUserEmailStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.FindByEmailAsync(System.String, System.Threading.CancellationToken)
    
        
    
        Gets the user, if any, associated with the specified, normalized email address.
    
        
        
        
        :param normalizedEmail: The normalized email address to return the user for.
        
        :type normalizedEmail: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{{TUser}}
        :return: The task object containing the results of the asynchronous lookup operation, the user if any associated with the specified normalized email address.
    
        
        .. code-block:: csharp
    
           Task<TUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.GetEmailAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets the email address for the specified ``user``.
    
        
        
        
        :param user: The user whose email should be returned.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The task object containing the results of the asynchronous operation, the email address for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetEmailAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.GetEmailConfirmedAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets a flag indicating whether the email address for the specified ``user`` has been verified, true if the email address is verified otherwise
        false.
    
        
        
        
        :param user: The user whose email confirmation status should be returned.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: The task object containing the results of the asynchronous operation, a flag indicating whether the email address for the specified <paramref name="user" />
            has been confirmed or not.
    
        
        .. code-block:: csharp
    
           Task<bool> GetEmailConfirmedAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.GetNormalizedEmailAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Returns the normalized email for the specified ``user``.
    
        
        
        
        :param user: The user whose email address to retrieve.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The task object containing the results of the asynchronous lookup operation, the normalized email address if any associated with the specified user.
    
        
        .. code-block:: csharp
    
           Task<string> GetNormalizedEmailAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.SetEmailAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the ``email`` address for a ``user``.
    
        
        
        
        :param user: The user whose email should be set.
        
        :type user: {TUser}
        
        
        :param email: The email to set.
        
        :type email: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetEmailAsync(TUser user, string email, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.SetEmailConfirmedAsync(TUser, System.Boolean, System.Threading.CancellationToken)
    
        
    
        Sets the flag indicating whether the specified ``user``'s email address has been confirmed or not.
    
        
        
        
        :param user: The user whose email confirmation status should be set.
        
        :type user: {TUser}
        
        
        :param confirmed: A flag indicating if the email address has been confirmed, true if the address is confirmed otherwise false.
        
        :type confirmed: System.Boolean
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetEmailConfirmedAsync(TUser user, bool confirmed, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserEmailStore<TUser>.SetNormalizedEmailAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the normalized email for the specified ``user``.
    
        
        
        
        :param user: The user whose email address to set.
        
        :type user: {TUser}
        
        
        :param normalizedEmail: The normalized email to set for the specified .
        
        :type normalizedEmail: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetNormalizedEmailAsync(TUser user, string normalizedEmail, CancellationToken cancellationToken)
    

