

AuthorizationServiceExtensions Class
====================================






Extension methods for :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService`\.


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
    
        
    
        
        Checks if a user meets a specific authorization policy against the specified resource.
    
        
    
        
        :param service: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` providing authorization.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to evaluate the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param policy: The policy to evaluate.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether policy evaluation has succeeded or failed.
            This value is <returns>true</returns> when the user fulfills the policy, otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNetCore.Authorization.AuthorizationPolicy)
    
        
    
        
        Checks if a user meets a specific authorization policy against the specified resource.
    
        
    
        
        :param service: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` providing authorization.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to evaluate the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource to evaluate the policy against.
        
        :type resource: System.Object
    
        
        :param policy: The policy to evaluate.
        
        :type policy: Microsoft.AspNetCore.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether policy evaluation has succeeded or failed.
            This value is <returns>true</returns> when the user fulfills the policy, otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, object resource, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNetCore.Authorization.IAuthorizationRequirement)
    
        
    
        
        Checks if a user meets a specific requirement for the specified resource
    
        
    
        
        :param service: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` providing authorization.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to evaluate the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource to evaluate the policy against.
        
        :type resource: System.Object
    
        
        :param requirement: The requirement to evaluate the policy against.
        
        :type requirement: Microsoft.AspNetCore.Authorization.IAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether requirement evaluation has succeeded or failed.
            This value is <returns>true</returns> when the user fulfills the policy, otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, object resource, IAuthorizationRequirement requirement)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNetCore.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        
        Checks if a user meets a specific authorization policy against the specified resource.
    
        
    
        
        :param service: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService` providing authorization.
        
        :type service: Microsoft.AspNetCore.Authorization.IAuthorizationService
    
        
        :param user: The user to evaluate the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param policyName: The name of the policy to evaluate.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether policy evaluation has succeeded or failed.
            This value is <returns>true</returns> when the user fulfills the policy, otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public static Task<bool> AuthorizeAsync(this IAuthorizationService service, ClaimsPrincipal user, string policyName)
    

