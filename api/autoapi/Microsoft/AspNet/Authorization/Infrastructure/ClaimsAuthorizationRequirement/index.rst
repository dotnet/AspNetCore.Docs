

ClaimsAuthorizationRequirement Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authorization.AuthorizationHandler{Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

   public class ClaimsAuthorizationRequirement : AuthorizationHandler<ClaimsAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authorization/Infrastructure/ClaimsAuthorizationRequirement.cs>`_





.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimsAuthorizationRequirement(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
        
        
        :type claimType: System.String
        
        
        :type allowedValues: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public ClaimsAuthorizationRequirement(string claimType, IEnumerable<string> allowedValues)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement.Handle(Microsoft.AspNet.Authorization.AuthorizationContext, Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement)
    
        
        
        
        :type context: Microsoft.AspNet.Authorization.AuthorizationContext
        
        
        :type requirement: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    
        
        .. code-block:: csharp
    
           protected override void Handle(AuthorizationContext context, ClaimsAuthorizationRequirement requirement)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement.AllowedValues
    
        
        :rtype: System.Collections.Generic.IEnumerable{System.String}
    
        
        .. code-block:: csharp
    
           public IEnumerable<string> AllowedValues { get; }
    
    .. dn:property:: Microsoft.AspNet.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ClaimType { get; }
    

