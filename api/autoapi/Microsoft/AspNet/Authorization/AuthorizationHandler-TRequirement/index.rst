

AuthorizationHandler<TRequirement> Class
========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler\<TRequirement>`








Syntax
------

.. code-block:: csharp

   public abstract class AuthorizationHandler<TRequirement> : IAuthorizationHandler where TRequirement : IAuthorizationRequirement





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/AuthorizationHandler.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>.Handle(Microsoft.AspNet.Authorization.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
    
        
        .. code-block:: csharp
    
           public void Handle(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, TRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: {TRequirement}
    
        
        .. code-block:: csharp
    
           protected abstract void Handle(AuthorizationContext context, TRequirement requirement)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>.HandleAsync(Microsoft.AspNet.Authorization.AuthorizationContext)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           public virtual Task HandleAsync(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNet.Authorization.AuthorizationHandler<TRequirement>.HandleAsync(Microsoft.AspNet.Authorization.AuthorizationContext, TRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: {TRequirement}
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
           protected virtual Task HandleAsync(AuthorizationContext context, TRequirement requirement)
    

