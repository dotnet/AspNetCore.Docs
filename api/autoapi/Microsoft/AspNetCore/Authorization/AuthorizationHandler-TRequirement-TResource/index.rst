

AuthorizationHandler<TRequirement, TResource> Class
===================================================





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

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        .. code-block:: csharp
    
            public virtual void Handle(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, TRequirement, TResource)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: TRequirement
    
        
        :type resource: TResource
    
        
        .. code-block:: csharp
    
            protected abstract void Handle(AuthorizationContext context, TRequirement requirement, TResource resource)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task HandleAsync(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext, TRequirement, TResource)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: TRequirement
    
        
        :type resource: TResource
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected virtual Task HandleAsync(AuthorizationContext context, TRequirement requirement, TResource resource)
    

