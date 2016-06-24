

IAuthorizationPolicyProvider Interface
======================================






A type which can provide a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthorizationPolicyProvider








.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync()
    
        
    
        
        Gets the default authorization policy.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :return: The default authorization policy.
    
        
        .. code-block:: csharp
    
            Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetPolicyAsync(System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` from the given <em>policyName</em>
    
        
    
        
        :param policyName: The policy name to retrieve.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :return: The named :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`\.
    
        
        .. code-block:: csharp
    
            Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    

