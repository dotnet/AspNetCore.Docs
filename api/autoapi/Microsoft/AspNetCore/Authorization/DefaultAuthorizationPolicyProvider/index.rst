

DefaultAuthorizationPolicyProvider Class
========================================






The default implementation of a policy provider,
which provides a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` for a particular name.


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
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider`\.
    
        
    
        
        :param options: The options used to configure this instance.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authorization.AuthorizationOptions<Microsoft.AspNetCore.Authorization.AuthorizationOptions>}
    
        
        .. code-block:: csharp
    
            public DefaultAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider.GetDefaultPolicyAsync()
    
        
    
        
        Gets the default authorization policy.
    
        
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :return: The default authorization policy.
    
        
        .. code-block:: csharp
    
            public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider.GetPolicyAsync(System.String)
    
        
    
        
        Gets a :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` from the given <em>policyName</em>
    
        
    
        
        :param policyName: The policy name to retrieve.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :return: The named :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`\.
    
        
        .. code-block:: csharp
    
            public virtual Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    

