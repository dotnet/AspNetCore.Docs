

IAuthorizationService Interface
===============================






Checks policy based permissions for a user


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public interface IAuthorizationService








.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationService
    :hidden:

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationService

Methods
-------

.. dn:interface:: Microsoft.AspNetCore.Authorization.IAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>)
    
        
    
        
        Checks if a user meets a specific set of requirements for the specified resource
    
        
    
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :type resource: System.Object
    
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
    
        
        Checks if a user meets a specific authorization policy
    
        
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource the policy should be checked with.
        
        :type resource: System.Object
    
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: <returns>true</returns> when the user fulfills the policy, <returns>false</returns> otherwise.
    
        
        .. code-block:: csharp
    
            Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

