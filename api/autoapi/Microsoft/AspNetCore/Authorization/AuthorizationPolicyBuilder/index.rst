

AuthorizationPolicyBuilder Class
================================





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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder`








Syntax
------

.. code-block:: csharp

    public class AuthorizationPolicyBuilder








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthenticationSchemes
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AuthenticationSchemes
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Requirements
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IList<IAuthorizationRequirement> Requirements
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder(AuthorizationPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(System.String[])
    
        
    
        
        :type authenticationSchemes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder(params string[] authenticationSchemes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AddAuthenticationSchemes(System.String[])
    
        
    
        
        :type schemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder AddAuthenticationSchemes(params string[] schemes)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AddRequirements(Microsoft.AspNetCore.Authorization.IAuthorizationRequirement[])
    
        
    
        
        :type requirements: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder AddRequirements(params IAuthorizationRequirement[] requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Build()
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy Build()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Combine(Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder Combine(AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationContext, System.Boolean>)
    
        
    
        
        Requires that this Function returns true
    
        
    
        
        :param assert: Function that must return true
        
        :type assert: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationContext<Microsoft.AspNetCore.Authorization.AuthorizationContext>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAssertion(Func<AuthorizationContext, bool> assert)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationContext, System.Threading.Tasks.Task<System.Boolean>>)
    
        
    
        
        Requires that this Function returns true
    
        
    
        
        :param assert: Function that must return true
        
        :type assert: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationContext<Microsoft.AspNetCore.Authorization.AuthorizationContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAssertion(Func<AuthorizationContext, Task<bool>> assert)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser()
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAuthenticatedUser()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String)
    
        
    
        
        :type claimType: System.String
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type claimType: System.String
    
        
        :type requiredValues: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType, IEnumerable<string> requiredValues)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.String[])
    
        
    
        
        :type claimType: System.String
    
        
        :type requiredValues: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType, params string[] requiredValues)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type roles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireRole(IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole(System.String[])
    
        
    
        
        :type roles: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireRole(params string[] roles)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireUserName(System.String)
    
        
    
        
        :type userName: System.String
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireUserName(string userName)
    

