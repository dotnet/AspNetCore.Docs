

AuthorizationServiceExtensions Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions`








Syntax
------

.. code-block:: csharp

    public class AuthorizationServiceExtensions








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Checks if a user meets a specific authorization policy
    
        
    
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param policy: The policy to check against a specific context.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: <returns>true</returns> when the user fulfills the policy, <returns>false</returns> otherwise.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Checks if a user meets a specific authorization policy
    
        
    
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource the policy should be checked with.
        
        :type resource: System.Object
    
        
        :param policy: The policy to check against a specific context.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: <returns>true</returns> when the user fulfills the policy, <returns>false</returns> otherwise.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, object resource, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNetCore.Authorization.IAuthorizationRequirement)
    
        
    
        
        Checks if a user meets a specific requirement for the specified resource
    
        
    
        
        :param service: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService`\.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :type resource: System.Object
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, object resource, IAuthorizationRequirement requirement)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        
        Checks if a user meets a specific authorization policy
    
        
    
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: <returns>true</returns> when the user fulfills the policy, <returns>false</returns> otherwise.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, string policyName)
    

