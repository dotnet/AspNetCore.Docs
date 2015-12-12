

AuthorizationContext Class
==========================



.. contents:: 
   :local:



Summary
-------

Contains authorization information used by :any:`Microsoft.AspNet.Authorization.IAuthorizationHandler`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationContext`








Syntax
------

.. code-block:: csharp

   public class AuthorizationContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/AuthorizationContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.AuthorizationContext.AuthorizationContext(System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizationRequirement>, System.Security.Claims.ClaimsPrincipal, System.Object)
    
        
        
        
        :type requirements: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
        
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :type resource: System.Object
    
        
        .. code-block:: csharp
    
           public AuthorizationContext(IEnumerable<IAuthorizationRequirement> requirements, ClaimsPrincipal user, object resource)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationContext.Fail()
    
        
    
        
        .. code-block:: csharp
    
           public void Fail()
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationContext.Succeed(Microsoft.AspNet.Authorization.IAuthorizationRequirement)
    
        
        
        
        :type requirement: Microsoft.AspNet.Authorization.IAuthorizationRequirement
    
        
        .. code-block:: csharp
    
           public void Succeed(IAuthorizationRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.HasFailed
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasFailed { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.HasSucceeded
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool HasSucceeded { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.PendingRequirements
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IAuthorizationRequirement> PendingRequirements { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.Requirements
    
        
        :rtype: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
    
        
        .. code-block:: csharp
    
           public IEnumerable<IAuthorizationRequirement> Requirements { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.Resource
    
        
        :rtype: System.Object
    
        
        .. code-block:: csharp
    
           public object Resource { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.AuthorizationContext.User
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal User { get; }
    

