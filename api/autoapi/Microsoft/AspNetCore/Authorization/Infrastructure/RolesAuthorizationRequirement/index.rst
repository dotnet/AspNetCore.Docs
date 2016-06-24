

RolesAuthorizationRequirement Class
===================================






Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
which requires at least one role claim whose value must be any of the allowed roles.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class RolesAuthorizationRequirement : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.RolesAuthorizationRequirement(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        Creates a new instance of :any:`Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement`\.
    
        
    
        
        :param allowedRoles: A collection of allowed roles.
        
        :type allowedRoles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public RolesAuthorizationRequirement(IEnumerable<string> allowedRoles)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.AllowedRoles
    
        
    
        
        Gets the collection of allowed roles.
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> AllowedRoles { get; }
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement)
    
        
    
        
        Makes a decision if authorization is allowed based on a specific requirement.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
    

