

AuthorizationHandler<TRequirement, TResource> Class
===================================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler\<TRequirement, TResource>`








Syntax
------

.. code-block:: csharp

   public abstract class AuthorizationHandler<TRequirement, TResource> : IAuthorizationHandler where TRequirement : IAuthorizationRequirement where TResource : class





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/AuthorizationHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>.Handle(Microsoft.AspNet.Authorization.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
    
        
        .. code-block:: csharp
    
           public virtual void Handle(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, TRequirement, TResource)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: {TRequirement}
        
        
        :type resource: {TResource}
    
        
        .. code-block:: csharp
    
           protected abstract void Handle(AuthorizationContext context, TRequirement requirement, TResource resource)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleAsync(Microsoft.AspNet.Authorization.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task HandleAsync(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement, TResource>.HandleAsync(Microsoft.AspNet.Authorization.AuthorizationContext, TRequirement, TResource)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: {TRequirement}
        
        
        :type resource: {TResource}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task HandleAsync(AuthorizationContext context, TRequirement requirement, TResource resource)
    

