

AuthorizationContext Class
==========================






Contains authorization information used by :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler`\.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationContext`








Syntax
------

.. code-block:: csharp

    public class AuthorizationContext








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.HasFailed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasFailed
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.HasSucceeded
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasSucceeded
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.PendingRequirements
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IAuthorizationRequirement> PendingRequirements
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.Requirements
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IAuthorizationRequirement> Requirements
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.Resource
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Resource
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationContext.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal User
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationContext.AuthorizationContext(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, System.Security.Claims.ClaimsPrincipal, System.Object)
    
        
    
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :type resource: System.Object
    
        
        .. code-block:: csharp
    
            public AuthorizationContext(IEnumerable<IAuthorizationRequirement> requirements, ClaimsPrincipal user, object resource)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationContext.Fail()
    
        
    
        
        .. code-block:: csharp
    
            public void Fail()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationContext.Succeed(Microsoft.AspNetCore.Authorization.IAuthorizationRequirement)
    
        
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            public void Succeed(IAuthorizationRequirement requirement)
    

