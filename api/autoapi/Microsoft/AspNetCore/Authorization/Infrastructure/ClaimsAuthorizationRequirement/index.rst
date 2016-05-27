

ClaimsAuthorizationRequirement Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class ClaimsAuthorizationRequirement : AuthorizationHandler<ClaimsAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.AllowedValues
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> AllowedValues
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimType
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ClaimType
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.ClaimsAuthorizationRequirement(System.String, System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type claimType: System.String
    
        
        :type allowedValues: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public ClaimsAuthorizationRequirement(string claimType, IEnumerable<string> allowedValues)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.ClaimsAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            protected override void Handle(AuthorizationContext context, ClaimsAuthorizationRequirement requirement)
    

