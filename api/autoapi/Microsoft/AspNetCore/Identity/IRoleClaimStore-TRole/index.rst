

IRoleClaimStore<TRole> Interface
================================






Provides an abstraction for a store of role specific claims.


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

    public interface IRoleClaimStore<TRole> : IRoleStore<TRole>, IDisposable where TRole : class








.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleClaimStore`1
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleClaimStore<TRole>

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Identity.IRoleClaimStore<TRole>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleClaimStore<TRole>.AddClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Add a new claim to a role as an asynchronous operation.
    
        
    
        
        :param role: The role to add a claim to.
        
        :type role: TRole
    
        
        :param claim: The :any:`System.Security.Claims.Claim` to add.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task AddClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleClaimStore<TRole>.GetClaimsAsync(TRole, System.Threading.CancellationToken)
    
        
    
        
         Gets a list of :any:`System.Security.Claims.Claim`\s to be belonging to the specified <em>role</em> as an asynchronous operation.
    
        
    
        
        :param role: The role whose claims to retrieve.
        
        :type role: TRole
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.Security.Claims.Claim<System.Security.Claims.Claim>}}
        :return: 
            A :any:`System.Threading.Tasks.Task\`1` that represents the result of the asynchronous query, a list of :any:`System.Security.Claims.Claim`\s.
    
        
        .. code-block:: csharp
    
            Task<IList<Claim>> GetClaimsAsync(TRole role, CancellationToken cancellationToken = null)
    
    .. dn:method:: Microsoft.AspNetCore.Identity.IRoleClaimStore<TRole>.RemoveClaimAsync(TRole, System.Security.Claims.Claim, System.Threading.CancellationToken)
    
        
    
        
        Remove a claim from a role as an asynchronous operation.
    
        
    
        
        :param role: The role to remove the claim from.
        
        :type role: TRole
    
        
        :param claim: The :any:`System.Security.Claims.Claim` to remove.
        
        :type claim: System.Security.Claims.Claim
    
        
        :param cancellationToken: The :any:`System.Threading.CancellationToken` used to propagate notifications that the operation should be canceled.
        
        :type cancellationToken: System.Threading.CancellationToken
        :rtype: System.Threading.Tasks.Task
        :return: The task object representing the asynchronous operation.
    
        
        .. code-block:: csharp
    
            Task RemoveClaimAsync(TRole role, Claim claim, CancellationToken cancellationToken = null)
    

