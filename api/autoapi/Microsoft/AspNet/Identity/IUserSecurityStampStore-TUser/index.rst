

IUserSecurityStampStore<TUser> Interface
========================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store which stores a user's security stamp.











Syntax
------

.. code-block:: csharp

   public interface IUserSecurityStampStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IUserSecurityStampStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserSecurityStampStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserSecurityStampStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserSecurityStampStore<TUser>.GetSecurityStampAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Get the security stamp for the specified ``user``.
    
        
        
        
        :param user: The user whose security stamp should be set.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.String}
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation, containing the security stamp for the specified <paramref name="user" />.
    
        
        .. code-block:: csharp
    
           Task<string> GetSecurityStampAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserSecurityStampStore<TUser>.SetSecurityStampAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        Sets the provided security ``stamp`` for the specified ``user``.
    
        
        
        
        :param user: The user whose security stamp should be set.
        
        :type user: {TUser}
        
        
        :param stamp: The security stamp to set.
        
        :type stamp: System.String
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task SetSecurityStampAsync(TUser user, string stamp, CancellationToken cancellationToken)
    

