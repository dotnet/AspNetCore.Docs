

AuthorizationPolicyBuilder Class
================================






Used for building policies during application startup.


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

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder`\.
    
        
    
        
        :param policy: The :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` to build.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder(AuthorizationPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(System.String[])
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder`
    
        
    
        
        :param authenticationSchemes: An array of authentication schemes the policy should be evaluated against.
        
        :type authenticationSchemes: System.String<System.String>[]
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder(params string[] authenticationSchemes)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AddAuthenticationSchemes(System.String[])
    
        
    
        
        Adds the specified authentication <em>schemes</em> to the 
        :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthenticationSchemes` for this instance.
    
        
    
        
        :param schemes: The schemes to add.
        
        :type schemes: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder AddAuthenticationSchemes(params string[] schemes)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AddRequirements(Microsoft.AspNetCore.Authorization.IAuthorizationRequirement[])
    
        
    
        
        Adds the specified <em>requirements</em> to the 
        :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Requirements` for this instance.
    
        
    
        
        :param requirements: The authorization requirements to add.
        
        :type requirements: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder AddRequirements(params IAuthorizationRequirement[] requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Build()
    
        
    
        
        Builds a new :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` from the requirements 
        in this instance.
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :return: 
            A new :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` built from the requirements in this instance.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicy Build()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Combine(Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Combines the specified <em>policy</em> into the current instance.
    
        
    
        
        :param policy: The :any:`Microsoft.AspNetCore.Authorization.AuthorizationPolicy` to combine.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder Combine(AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, System.Boolean>)
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement` to the current instance.
    
        
    
        
        :param handler: The handler to evaluate during authorization.
        
        :type handler: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext>, System.Boolean<System.Boolean>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAssertion(Func<AuthorizationHandlerContext, bool> handler)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion(System.Func<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, System.Threading.Tasks.Task<System.Boolean>>)
    
        
    
        
        Adds an :any:`Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement` to the current instance.
    
        
    
        
        :param handler: The handler to evaluate during authorization.
        
        :type handler: System.Func<System.Func`2>{Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext<Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext>, System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAssertion(Func<AuthorizationHandlerContext, Task<bool>> handler)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser()
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement` to the current instance.
    
        
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireAuthenticatedUser()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param claimType: The claim type required, which no restrictions on claim value.
        
        :type claimType: System.String
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param claimType: The claim type required.
        
        :type claimType: System.String
    
        
        :param requiredValues: Values the claim must process one or more of for evaluation to succeed.
        
        :type requiredValues: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType, IEnumerable<string> requiredValues)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.String[])
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param claimType: The claim type required.
        
        :type claimType: System.String
    
        
        :param requiredValues: Values the claim must process one or more of for evaluation to succeed.
        
        :type requiredValues: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireClaim(string claimType, params string[] requiredValues)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param roles: The roles required.
        
        :type roles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireRole(IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole(System.String[])
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param roles: The roles required.
        
        :type roles: System.String<System.String>[]
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireRole(params string[] roles)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireUserName(System.String)
    
        
    
        
        Adds a :any:`Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement`
        to the current instance.
    
        
    
        
        :param userName: The user name the current user must possess.
        
        :type userName: System.String
        :rtype: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public AuthorizationPolicyBuilder RequireUserName(string userName)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AuthenticationSchemes
    
        
    
        
        Gets or sets a list authentication schemes the :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Requirements` 
        are evaluated against.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IList<string> AuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.Requirements
    
        
    
        
        Gets or sets a list of :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`\s which must succeed for
        this policy to be successful.
    
        
        :rtype: System.Collections.Generic.IList<System.Collections.Generic.IList`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IList<IAuthorizationRequirement> Requirements { get; set; }
    

