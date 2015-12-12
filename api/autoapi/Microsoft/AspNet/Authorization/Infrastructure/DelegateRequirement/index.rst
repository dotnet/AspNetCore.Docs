

DelegateRequirement Class
=========================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler{Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement}`
* :dn:cls:`Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement`








Syntax
------

.. code-block:: csharp

   public class DelegateRequirement : AuthorizationHandler<DelegateRequirement>, IAuthorizationHandler, IAuthorizationRequirement





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/Infrastructure/DelegateRequirement.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement.DelegateRequirement(System.Action<Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement>)
    
        
        
        
        :type handleMe: System.Action{Microsoft.AspNet.Authorization.AuthorizationContext,Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement}
    
        
        .. code-block:: csharp
    
           public DelegateRequirement(Action<AuthorizationContext, DelegateRequirement> handleMe)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement
    
        
        .. code-block:: csharp
    
           protected override void Handle(AuthorizationContext context, DelegateRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement.Handler
    
        
        :rtype: System.Action{Microsoft.AspNet.Authorization.AuthorizationContext,Microsoft.AspNet.Authorization.Infrastructure.DelegateRequirement}
    
        
        .. code-block:: csharp
    
           public Action<AuthorizationContext, DelegateRequirement> Handler { get; }
    

