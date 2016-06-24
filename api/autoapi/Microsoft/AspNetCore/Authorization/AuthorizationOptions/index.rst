

AuthorizationOptions Class
==========================






Provides programmatic configuration used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider`\.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationOptions`








Syntax
------

.. code-block:: csharp

    public class AuthorizationOptions








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationOptions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationOptions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy(System.String, Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Add an authorization policy with the provided name.
    
        
    
        
        :param name: The name of the policy.
        
        :type name: System.String
    
        
        :param policy: The authorization policy.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public void AddPolicy(string name, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy(System.String, System.Action<Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder>)
    
        
    
        
        Add a policy that is built from a delegate with the provided name.
    
        
    
        
        :param name: The name of the policy.
        
        :type name: System.String
    
        
        :param configurePolicy: The delegate that will be used to build the policy.
        
        :type configurePolicy: System.Action<System.Action`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder<Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder>}
    
        
        .. code-block:: csharp
    
            public void AddPolicy(string name, Action<AuthorizationPolicyBuilder> configurePolicy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationOptions.GetPolicy(System.String)
    
        
    
        
        Returns the policy for the specified name, or null if a policy with the name does not exist.
    
        
    
        
        :param name: The name of the policy to return.
        
        :type name: System.String
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :return: The policy for the specified name, or null if a policy with the name does not exist.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy GetPolicy(string name)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationOptions.DefaultPolicy
    
        
    
        
        Gets or sets the default authorization policy.
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy DefaultPolicy { get; set; }
    

