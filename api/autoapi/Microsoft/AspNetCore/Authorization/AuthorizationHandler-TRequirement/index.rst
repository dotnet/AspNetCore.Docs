

AuthorizationHandler<TRequirement> Class
========================================





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

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        .. code-block:: csharp
    
            public void Handle(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, TRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: TRequirement
    
        
        .. code-block:: csharp
    
            protected abstract void Handle(AuthorizationContext context, TRequirement requirement)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            public virtual Task HandleAsync(AuthorizationContext context)
    
    .. dn:method:: Microsoft.AspNetCore.Authorization.AuthorizationHandler<TRequirement>.HandleAsync(Microsoft.AspNetCore.Authorization.AuthorizationContext, TRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: TRequirement
        :rtype: System.Threading.Tasks.Task
    
        
        .. code-block:: csharp
    
            protected virtual Task HandleAsync(AuthorizationContext context, TRequirement requirement)
    

