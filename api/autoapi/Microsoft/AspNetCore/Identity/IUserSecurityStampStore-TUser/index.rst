

IUserSecurityStampStore<TUser> Interface
========================================






Provides an abstraction for a store which stores a user's security stamp.


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

    public interface IUserSecurityStampStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IUserSecurityStampStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserSecurityStampStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IUserSecurityStampStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserSecurityStampStore<TUser>.GetSecurityStampAsync(TUser, System.Threading.CancellationToken)
    
        
    
        
        Get the security stamp for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be set.
        
        :type user: TUser
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.String<System.String>}
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation, containing the security stamp for the specified <em>user</em>.
    
        
        .. code-block:: csharp
    
            Task<string> GetSecurityStampAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IUserSecurityStampStore<TUser>.SetSecurityStampAsync(TUser, System.String, System.Threading.CancellationToken)
    
        
    
        
        Sets the provided security <em>stamp</em> for the specified <em>user</em>.
    
        
    
        
        :param user: The user whose security stamp should be set.
        
        :type user: TUser
    
        
        :param stamp: The security stamp to set.
        
        :type stamp: System.String
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The :any:`System.Threading.Tasks.Task` that represents the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task SetSecurityStampAsync(TUser user, string stamp, CancellationToken cancellationToken)
    

