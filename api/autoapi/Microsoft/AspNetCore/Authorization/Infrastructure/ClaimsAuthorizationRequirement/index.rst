

ClaimsAuthorizationRequirement Class
====================================






Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
which requires at least one instance of the specified claim type, and, if allowed values are specified, 
the claim value must be any of the allowed values.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class ClaimsAuthorizationRequirement : AuthorizationHandler<ClaimsAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimsAuthorizationRequirement(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`\.
    
        
    
        
        :param claimType: The claim type that must be present.
        
        :type claimType: System.String
    
        
        :param allowedValues: The optional list of claim values, which, if present, 
            the claim must match.
        
        :type allowedValues: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ClaimsAuthorizationRequirement(string claimType, IEnumerable<string> allowedValues)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.AllowedValues
    
        
    
        
        Gets the optional list of claim values, which, if present, 
        the claim must match.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> AllowedValues { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimType
    
        
    
        
        Gets the claim type that must be present.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClaimType { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement)
    
        
    
        
        Makes a decision if authorization is allowed based on the claims requirements specified.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ClaimsAuthorizationRequirement requirement)
    

