

DefaultAuthorizationPolicyProvider Class
========================================






A type which can provide a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider`








Syntax
------

.. code-block:: csharp

    public class DefaultAuthorizationPolicyProvider : IAuthorizationPolicyProvider








.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider.DefaultAuthorizationPolicyProvider(Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>)
    
        
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authorization.AuthorizationOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider.GetPolicyAsync(System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` from the given <em>policyName</em>
    
        
    
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
    
        
        .. code-block:: csharp
    
            public virtual Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    

