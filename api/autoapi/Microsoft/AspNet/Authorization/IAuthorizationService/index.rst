

IAuthorizationService Interface
===============================



.. contents:: 
   :local:



Summary
-------

Checks policy based permissions for a user











Syntax
------

.. code-block:: csharp

   public interface IAuthorizationService





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/IAuthorizationService.cs>`_





.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizationService

Methods
-------

.. dn:interface:: Microsoft.AspNet.Authorization.IAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.IAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNet.Authorization.IAuthorizationRequirement>)
    
        
    
        Checks if a user meets a specific set of requirements for the specified resource
    
        
        
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :type resource: System.Object
        
        
        :type requirements: System.Collections.Generic.IEnumerable{Microsoft.AspNet.Authorization.IAuthorizationRequirement}
        :rtype: System.Threading.Tasks.Task{System.Boolean}
    
        
        .. code-block:: csharp
    
           Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNet.Authorization.IAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
    
        Checks if a user meets a specific authorization policy
    
        
        
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
        
        
        :param resource: The resource the policy should be checked with.
        
        :type resource: System.Object
        
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task{System.Boolean}
        :return: <value>true</value> when the user fulfills the policy, <value>false</value> otherwise.
    
        
        .. code-block:: csharp
    
           Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

