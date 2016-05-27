

AuthorizationPolicy Class
=========================





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

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.AuthenticationSchemes
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<string> AuthenticationSchemes
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Requirements
    
        
        :rtype: System.Collections.Generic.IReadOnlyList<System.Collections.Generic.IReadOnlyList`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IReadOnlyList<IAuthorizationRequirement> Requirements
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.AuthorizationPolicy(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        :type authenticationSchemes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy(IEnumerable<IAuthorizationRequirement> requirements, IEnumerable<string> authenticationSchemes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine(Microsoft.AspNetCore.Authorization.AuthorizationOptions, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizeData>)
    
        
    
        
        :type options: Microsoft.AspNetCore.Authorization.AuthorizationOptions
    
        
        :type attributes: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizeData<Microsoft.AspNetCore.Authorization.IAuthorizeData>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public static AuthorizationPolicy Combine(AuthorizationOptions options, IEnumerable<IAuthorizeData> attributes)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine(Microsoft.AspNetCore.Authorization.AuthorizationPolicy[])
    
        
    
        
        :type policies: Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public static AuthorizationPolicy Combine(params AuthorizationPolicy[] policies)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>)
    
        
    
        
        :type policies: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.AuthorizationPolicy<Microsoft.AspNetCore.Authorization.AuthorizationPolicy>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public static AuthorizationPolicy Combine(IEnumerable<AuthorizationPolicy> policies)
    

