

NameAuthorizationRequirement Class
==================================



.. contents:: 
   :local:



Summary
-------

Requirement that ensures a specific Name





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler{Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

   public class NameAuthorizationRequirement : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/Infrastructure/NameAuthorizationRequirement.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement.NameAuthorizationRequirement(System.String)
    
        
        
        
        :type requiredName: System.String
    
        
        .. code-block:: csharp
    
           public NameAuthorizationRequirement(string requiredName)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement
    
        
        .. code-block:: csharp
    
           protected override void Handle(AuthorizationContext context, NameAuthorizationRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.Infrastructure.NameAuthorizationRequirement.RequiredName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RequiredName { get; }
    

