

AuthorizationHandler<TRequirement> Class
========================================






Base class for authorization handlers that need to be called for a specific requirement type.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement>`








Syntax
------

.. code-block:: csharp

    public abstract class AuthorizationHandler<TRequirement> : IAuthorizationHandler where TRequirement : IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext)
    
        
    
        
        Makes a decision if authorization is allowed.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task HandleAsync(AuthorizationHandlerContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, TRequirement)
    
        
    
        
        Makes a decision if authorization is allowed based on a specific requirement.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: TRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected abstract Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement)
    

