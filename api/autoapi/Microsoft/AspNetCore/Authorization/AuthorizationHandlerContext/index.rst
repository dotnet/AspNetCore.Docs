

AuthorizationHandlerContext Class
=================================






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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext`








Syntax
------

.. code-block:: csharp

    public class AuthorizationHandlerContext








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.AuthorizationHandlerContext(System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, System.Security.Claims.ClaimsPrincipal, System.Object)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext`\.
    
        
    
        
        :param requirements: A collection of all the :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` for the current authorization action.
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        :param user: A :any:`System.Security.Claims.ClaimsPrincipal` representing the current user.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: An optional resource to evaluate the <em>requirements</em> against.
        
        :type resource: System.Object
    
        
        .. code-block:: csharp
    
            public AuthorizationHandlerContext(IEnumerable<IAuthorizationRequirement> requirements, ClaimsPrincipal user, object resource)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Fail()
    
        
    
        
        Called to indicate :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.HasSucceeded` will
        never return true, even if all requirements are met.
    
        
    
        
        .. code-block:: csharp
    
            public void Fail()
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Succeed(Microsoft.AspNetCore.Authorization.IAuthorizationRequirement)
    
        
    
        
        Called to mark the specified <em>requirement</em> as being
        successfully evaluated.
    
        
    
        
        :param requirement: The requirement whose evaluation has succeeded.
        
        :type requirement: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            public void Succeed(IAuthorizationRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.HasFailed
    
        
    
        
        Flag indicating whether the current authorization processing has failed.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasFailed { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.HasSucceeded
    
        
    
        
        Flag indicating whether the current authorization processing has succeeded.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
            public bool HasSucceeded { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.PendingRequirements
    
        
    
        
        Gets the requirements that have not yet been marked as succeeded.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IAuthorizationRequirement> PendingRequirements { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Requirements
    
        
    
        
        The collection of all the :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement` for the current authorization action.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<IAuthorizationRequirement> Requirements { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Resource
    
        
    
        
        The optional resource to evaluate the :dn:prop:`Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.Requirements` against.
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
            public object Resource { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.User
    
        
    
        
        The :any:`System.Security.Claims.ClaimsPrincipal` representing the current user.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal User { get; }
    

