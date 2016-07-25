

AuthorizationPolicy Class
=========================






Represents a collection of authorization requirements and the scheme or 
schemes they are evaluated against, all of which must succeed
for authorization to succeed.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`








Syntax
------

.. code-block:: csharp

    public class AuthorizationPolicy








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.AuthorizationPolicy(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy`\.
    
        
    
        
        :param requirements: 
            The list of :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`\s which must succeed for
            this policy to be successful.
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        :param authenticationSchemes: 
            The authentication schemes the <em>requirements</em> are evaluated against.
        
        :type authenticationSchemes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.AuthenticationSchemes
    
        
    
        
        Gets a readonly list of the authentication schemes the :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Requirements` 
        are evaluated against.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<string> AuthenticationSchemes { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Requirements
    
        
    
        
        Gets a readonly list of :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`\s which must succeed for
        this policy to be successful.
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IAuthorizationRequirement> Requirements { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine(Microsoft.AspNetCore.Authorization.AuthorizationPolicy[])
    
        
    
        
        Combines the specified :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` into a single policy.
    
        
    
        
        :param policies: The authorization policies to combine.
        
        :type policies: Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :return: 
            A new :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` which represents the combination of the
            specified <em>policies</em>.
    
        
        .. code-block:: csharp
    
            public static AuthorizationPolicy Combine(params AuthorizationPolicy[] policies)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>)
    
        
    
        
        Combines the specified :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` into a single policy.
    
        
    
        
        :param policies: The authorization policies to combine.
        
        :type policies: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :return: 
            A new :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` which represents the combination of the
            specified <em>policies</em>.
    
        
        .. code-block:: csharp
    
            public static AuthorizationPolicy Combine(IEnumerable<AuthorizationPolicy> policies)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.CombineAsync(Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizeData>)
    
        
    
        
        Combines the :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` provided by the specified
        <em>policyProvider</em>.
    
        
    
        
        :param policyProvider: A :any:`Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider` which provides the policies to combine.
        
        :type policyProvider: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    
        
        :param authorizeData: A collection of authorization data used to apply authorization to a resource.
        
        :type authorizeData: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizeData<Microsoft.AspNetCore.Authorization.IAuthorizeData>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :return: 
            A new :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` which represents the combination of the
            authorization policies provided by the specified <em>policyProvider</em>.
    
        
        .. code-block:: csharp
    
            public static Task<AuthorizationPolicy> CombineAsync(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)
    

