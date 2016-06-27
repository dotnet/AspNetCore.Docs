

AuthorizationHandler<TRequirement, TResource> Class
===================================================






Base class for authorization handlers that need to be called for specific requirement and
resource types.


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler\<TRequirement, TResource>`








Syntax
------

.. code-block:: csharp

    public abstract class AuthorizationHandler<TRequirement, TResource> : IAuthorizationHandler where TRequirement : IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler`2
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext)
    
        
    
        
        Makes a decision if authorization is allowed.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task HandleAsync(AuthorizationHandlerContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleRequirementAsync(Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext, TRequirement, TResource)
    
        
    
        
        Makes a decision if authorization is allowed based on a specific requirement and resource.
    
        
    
        
        :param context: The authorization context.
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext
    
        
        :param requirement: The requirement to evaluate.
        
        :type requirement: TRequirement
    
        
        :param resource: The resource to evaluate.
        
        :type resource: TResource
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected abstract Task HandleRequirementAsync(AuthorizationHandlerContext context, TRequirement requirement, TResource resource)
    

