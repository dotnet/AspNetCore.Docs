

DefaultAuthorizationService Class
=================================





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
    
        
    
        
        :type policyProvider: Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider
    
        
        :type handlers: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationHandler<Microsoft.AspNetCore.Authorization.IAuthorizationHandler>}
    
        
        :type logger: Microsoft.Extensions.Logging.ILogger<Microsoft.Extensions.Logging.ILogger`1>{Microsoft.AspNetCore.Authorization.DefaultAuthorizationService<Microsoft.AspNetCore.Authorization.DefaultAuthorizationService>}
    
        
        .. code-block:: csharp
    
            public DefaultAuthorizationService(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizationHandler> handlers, ILogger<DefaultAuthorizationService> logger)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>)
    
        
    
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :type resource: System.Object
    
        
        :type requirements: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{Microsoft.AspNetCore.Authorization.IAuthorizationRequirement<Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>}
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.DefaultAuthorizationService.AuthorizeAsync(System.Security.Claims.ClaimsPrincipal, System.Object, System.String)
    
        
    
        
        :type user: System.Security.Claims.ClaimsPrincipal
    
        
        :type resource: System.Object
    
        
        :type policyName: System.String
        :rtype: System.Threading.Tasks.Task<System.Threading.Tasks.Task`1>{System.Boolean<System.Boolean>}
    
        
        .. code-block:: csharp
    
            public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    

