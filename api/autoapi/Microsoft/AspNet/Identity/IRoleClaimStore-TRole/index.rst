

IRoleClaimStore<TRole> Interface
================================



.. contents:: 
   :local:



Summary
-------

Provides an abstraction for a store of role specific claims.











Syntax
------

.. code-block:: csharp

   public interface IRoleClaimStore<TRole> : IRoleStore<TRole>, IDisposable where TRole : class





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IRoleClaimStore.cs>`_





.. dn:interface:: Microsoft.AspNet.Identity.IRoleClaimStore<TRole>

Methods
-------

.. dn:interface:: Microsoft.AspNet.Identity.IRoleClaimStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Identity.IRoleClaimStore<TRole>.AddClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Add a new claim to a role as an asynchronous operation.
    
        
        
        
        :param role: The role to add a claim to.
        
        :type role: {TRole}
        
        
        :param claim: The  to add.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.IRoleClaimStore<TRole>.GetClaimsAsync(TRole, System.Threading.CancellationToken)
    
        
    
        Gets a list of :any:`System.Security.Claims.Claim`\s to be belonging to the specified ``role`` as an asynchronous operation.
    
        
        
        
        :param role: The role whose claims to retrieve.
        
        :type role: {TRole}
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task{System.Collections.Generic.IList{System.Security.Claims.Claim}}
        :return: A <see cref="T:System.Threading.Tasks.Task`1" /> that represents the result of the asynchronous query, a list of <see cref="T:System.Security.Claims.Claim" />s.
    
        
        .. code-block:: csharp
    
           Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNet.Identity.IRoleClaimStore<TRole>.RemoveClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        Remove a claim from a role as an asynchronous operation.
    
        
        
        
        :param role: The role to remove the claim from.
        
        :type role: {TRole}
        
        
        :param claim: The  to remove.
        
        :type claim: System.Security.Claims.Claim
        
        
        :param cancellationToken: The  used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
           Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    

