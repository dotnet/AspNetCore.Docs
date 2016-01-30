

AuthorizationServiceExtensions Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationServiceExtensions`








Syntax
------

.. code-block:: csharp

   public class AuthorizationServiceExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authorization/AuthorizationServiceExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNet.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
    
        Checks if a user meets a specific authorization policy
    
        
        
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNet.Authorization.IAuthorizationService
        
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :param policy: The policy to check against a specific context.
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: <value>true</value> when the user fulfills the policy, <value>false</value> otherwise.
    
        
        .. code-block:: csharp
    
           public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNet.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNet.Authorization.AuthorizationPolicy)
    
        
    
        Checks if a user meets a specific authorization policy
    
        
        
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNet.Authorization.IAuthorizationService
        
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :param resource: The resource the policy should be checked with.
        
        :type resource: System.Object
        
        
        :param policy: The policy to check against a specific context.
        
        :type policy: Microsoft.AspNet.Authorization.AuthorizationPolicy
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: <value>true</value> when the user fulfills the policy, <value>false</value> otherwise.
    
        
        .. code-block:: csharp
    
           public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, object resource, AuthorizationPolicy policy)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNet.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.Object, Microsoft.AspNet.Authorization.IAuthorizationRequirement)
    
        
    
        Checks if a user meets a specific requirement for the specified resource
    
        
        
        
        :type service: Microsoft.AspNet.Authorization.IAuthorizationService
        
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :type resource: System.Object
        
        
        :type requirement: Microsoft.AspNet.Authorization.IAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, object resource, IAuthorizationRequirement requirement)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationServiceExtensions.AuthorizeAsync(Microsoft.AspNet.Authorization.IAuthorizationService, System.Security.Claims.ClaimsPrincipal, System.String)
    
        
    
        Checks if a user meets a specific authorization policy
    
        
        
        
        :param service: The authorization service.
        
        :type service: Microsoft.AspNet.Authorization.IAuthorizationService
        
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: <value>true</value> when the user fulfills the policy, <value>false</value> otherwise.
    
        
        .. code-block:: csharp
    
           public static Task<bool> AuthorizeAsync(IAuthorizationService service, ClaimsPrincipal user, string policyName)
    

