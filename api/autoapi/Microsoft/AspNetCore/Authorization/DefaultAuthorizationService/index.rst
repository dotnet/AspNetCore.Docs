

DefaultAuthorizationService Class
=================================






The default implementation of an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationService`\.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.DefaultAuthorizationService`








Syntax
------

.. code-block:: csharp

    public class DefaultAuthorizationService : IAuthorizationService








.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService.DefaultAuthorizationService(Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationHandler>, Microsoft.Extensions.Logging.ILogger<Microsoft.AspNetCore.Authorization.DefaultAuthorizationService>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.DefaultAuthorizationService`\.
    
        
    
        
        :param policyProvider: The :any:`Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider` used to provide policies.
        
        :type policyProvider: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    
        
        :param handlers: The handlers used to fulfill :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`\s.
        
        :type handlers: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationHandler<Microsoft.AspNetCore.Authorization.IAuthorizationHandler>}
    
        
        :param logger: The logger used to log messages, warnings and errors.
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Authorization.DefaultAuthorizationService<Microsoft.AspNetCore.Authorization.DefaultAuthorizationService>}
    
        
        .. code-block:: csharp
    
            public DefaultAuthorizationService(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizationHandler> handlers, ILogger<DefaultAuthorizationService> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>)
    
        
    
        
        Checks if a user meets a specific set of requirements for the specified resource.
    
        
    
        
        :param user: The user to evaluate the requirements against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource to evaluate the requirements against.
        
        :type resource: System.Object
    
        
        :param requirements: The requirements to evaluate.
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether authorization has succeded.
            This value is <returns>true</returns> when the user fulfills the policy otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
    
        
        Checks if a user meets a specific authorization policy.
    
        
    
        
        :param user: The user to check the policy against.
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :param resource: The resource the policy should be checked with.
        
        :type resource: System.Object
    
        
        :param policyName: The name of the policy to check against a specific context.
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
        :return: 
            A flag indicating whether authorization has succeded.
            This value is <returns>true</returns> when the user fulfills the policy otherwise <returns>false</returns>.
    
        
        .. code-block:: csharp
    
            public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

