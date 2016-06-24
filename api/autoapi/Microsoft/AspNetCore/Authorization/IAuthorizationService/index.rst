

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
    
        
    
        
        :param user: The user to evaluate the requirements against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: 
            An optional resource the policy should be checked with.
            If a resource is not required for policy evaluation you may pass null as the value.
        
        :type resource: System.Object
    
        
        :param requirements: The requirements to evaluate.
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether authorization has succeeded.
            This value is <returns>true</returns> when the user fulfills the policy; otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
    
        
        Checks if a user meets a specific authorization policy
    
        
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: 
            An optional resource the policy should be checked with.
            If a resource is not required for policy evaluation you may pass null as the value.
        
        :type resource: System.Object
    
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether authorization has succeeded.
            Returns a flag indicating whether the user, and optional resource has fulfilled the policy.    
            <returns>true</returns> when the the policy has been fulfilled; otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

