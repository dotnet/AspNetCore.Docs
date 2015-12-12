

DenyAnonymousAuthorizationRequirement Class
===========================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler{Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

   public class DenyAnonymousAuthorizationRequirement : AuthorizationHandler<DenyAnonymousAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/Infrastructure/DenyAnonymousAuthorizationRequirement.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: Microsoft.AspNet.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    
        
        .. code-block:: csharp
    
           protected override void Handle(AuthorizationContext context, DenyAnonymousAuthorizationRequirement requirement)
    

