

NameAuthorizationRequirement Class
==================================






Implements an :any:`Microsoft.AspNetCore.Authorization.IAuthorizationHandler` and :any:`Microsoft.AspNetCore.Authorization.IAuthorizationRequirement`
which requires the current user name must match the specified value.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class NameAuthorizationRequirement : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.NameAuthorizationRequirement(System.String)
    
        
    
        
        Constructs a new instance of :any:`Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement`\.
    
        
    
        
        :param requiredName: The required name that the current user must have.
        
        :type requiredName: System.String
    
        
        .. code-block:: csharp
    
            public NameAuthorizationRequirement(string requiredName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement)
    
        
    
        
        Makes a decision if authorization is allowed based on a specific requirement.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NameAuthorizationRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.RequiredName
    
        
    
        
        Gets the required name that the current user must have.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequiredName { get; }
    

