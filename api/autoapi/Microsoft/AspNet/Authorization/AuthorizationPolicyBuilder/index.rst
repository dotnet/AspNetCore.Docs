

AuthorizationPolicyBuilder Class
================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder`








Syntax
------

.. code-block:: csharp

   public class AuthorizationPolicyBuilder





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authorization/AuthorizationPolicyBuilder.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
        
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder(AuthorizationPolicy policy)
    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.AuthorizationPolicyBuilder(System.String[])
    
        
        
        
        :type authenticationSchemes: System.String[]
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder(params string[] authenticationSchemes)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.AddAuthenticationSchemes(System.String[])
    
        
        
        
        :type schemes: System.String[]
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder AddAuthenticationSchemes(params string[] schemes)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.AddRequirements(Microsoft.AspNet.Authorization.IAuthorizationRequirement[])
    
        
        
        
        :type requirements: Microsoft.AspNet.Authorization.IAuthorizationRequirement[]
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder AddRequirements(params IAuthorizationRequirement[] requirements)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.Build()
    
        
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicy
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicy Build()
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.Combine(Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
        
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder Combine(AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser()
    
        
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireAuthenticatedUser()
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String)
    
        
        
        
        :type claimType: System.String
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireClaim(string claimType)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type claimType: System.String
        
        
        :type requiredValues: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireClaim(string claimType, IEnumerable<string> requiredValues)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireClaim(System.String, System.String[])
    
        
        
        
        :type claimType: System.String
        
        
        :type requiredValues: System.String[]
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireClaim(string claimType, params string[] requiredValues)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireDelegate(System.Action<Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement>)
    
        
        
        
        :type handler: System.Action{Microsoft.AspNet.Authorization.AuthorizationContext,Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement}
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireDelegate(Action<AuthorizationContext, DelegateRequirement> handler)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireRole(System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type roles: System.Collections.Generic.IEnumerable{System.String}
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireRole(IEnumerable<string> roles)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireRole(System.String[])
    
        
        
        
        :type roles: System.String[]
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireRole(params string[] roles)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.RequireUserName(System.String)
    
        
        
        
        :type userName: System.String
        :rtype: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    
        
        .. code-block:: csharp
    
           public AuthorizationPolicyBuilder RequireUserName(string userName)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.AuthenticationSchemes
    
        
        :rtype: System.Collections.Generic.IList{System.String}
    
        
        .. code-block:: csharp
    
           public IList<string> AuthenticationSchemes { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationPolicyBuilder.Requirements
    
        
        :rtype: System.Collections.Generic.IList{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
    
        
        .. code-block:: csharp
    
           public IList<IAuthorizationRequirement> Requirements { get; set; }
    

