

DenyAnonymousAuthorizationRequirement Class
===========================================





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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class DenyAnonymousAuthorizationRequirement : AuthorizationHandler<DenyAnonymousAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.DenyAnonymousAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            protected override void Handle(AuthorizationContext context, DenyAnonymousAuthorizationRequirement requirement)
    

