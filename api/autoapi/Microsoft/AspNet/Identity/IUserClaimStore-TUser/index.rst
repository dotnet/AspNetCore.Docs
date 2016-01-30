

IUserClaimStore<TUser> Interface
================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store of claims for a user.











Syntax
------

.. code-block:: csharp

   public interface IUserClaimStore<TUser> : IUserStore<TUser>, IDisposable where TUser : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IUserClaimStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>.AddClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>, System.Threading.CancellationToken)
    
        
    
        Add claims to a user as an asynchronous operation.
    
        
        
        
        :param user: The user to add the claim to.
        
        :type user: {TUser}
        
        
        :param claims: The collection of s to add.
        
        :type claims: System.Collections.Generic.IEnumerable{System.Security.Claims.Claim}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task AddClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>.GetClaimsAsync(TUser, System.Threading.CancellationToken)
    
        
    
        Gets a list of :any:`System.Security.Claims.Claim`\s to be belonging to the specified ``user`` as an asynchronous operation.
    
        
        
        
        :param user: The role whose claims to retrieve.
        
        :type user: {TUser}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.Security.Claims.Claim}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <see cref="T:System.Security.Claims.Claim" />s.
    
        
        .. code-block:: csharp
    
           Task<IList<Claim>> GetClaimsAsync(TUser user, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>.GetUsersForClaimAsync(System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Returns a list of users who contain the specified :any:`System.Security.Claims.Claim`\.
    
        
        
        
        :param claim: The claim to look for.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{{TUser}}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <typeparamref name="TUser" /> who
            contain the specified claim.
    
        
        .. code-block:: csharp
    
           Task<IList<TUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>.RemoveClaimsAsync(TUser, System.Collections.Generic.IEnumerable<System.Security.Claims.Claim>, System.Threading.CancellationToken)
    
        
    
        Removes the specified ``claims`` from the given ``user``.
    
        
        
        
        :param user: The user to remove the specified  from.
        
        :type user: {TUser}
        
        
        :param claims: A collection of s to remove.
        
        :type claims: System.Collections.Generic.IEnumerable{System.Security.Claims.Claim}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task RemoveClaimsAsync(TUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
    
    .. dn:method:: Microsoft.AspNet.Identity.IUserClaimStore<TUser>.ReplaceClaimAsync(TUser, System.Security.Claims.Claim, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Replaces the given ``claim`` on the specified ``user`` with the ``newClaim``
    
        
        
        
        :param user: The user to replace the claim on.
        
        :type user: {TUser}
        
        
        :param claim: The claim to replace.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param newClaim: The new claim to replace the existing  with.
        
        :type newClaim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task ReplaceClaimAsync(TUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
    

