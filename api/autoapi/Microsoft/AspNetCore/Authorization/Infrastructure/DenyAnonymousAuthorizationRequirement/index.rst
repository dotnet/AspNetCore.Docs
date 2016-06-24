

DenyAnonymousAuthorizationRequirement Class
===========================================






Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
which requires the current user must be authenticated.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authorization.Infrastructure`
Assemblies
    * Microsoft.AspNetCore.Authorization

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class DenyAnonymousAuthorizationRequirement : AuthorizationHandler<DenyAnonymousAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement)
    
        
    
        
        Makes a decision if authorization is allowed based on a specific requirement.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, DenyAnonymousAuthorizationRequirement requirement)
    

