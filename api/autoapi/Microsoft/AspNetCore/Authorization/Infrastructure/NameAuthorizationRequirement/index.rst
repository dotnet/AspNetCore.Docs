

NameAuthorizationRequirement Class
==================================






Requirement that ensures a specific Name


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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class NameAuthorizationRequirement : AuthorizationHandler<NameAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.RequiredName
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RequiredName
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.NameAuthorizationRequirement(System.String)
    
        
    
        
        :type requiredName: System.String
    
        
        .. code-block:: csharp
    
            public NameAuthorizationRequirement(string requiredName)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.NameAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            protected override void Handle(AuthorizationContext context, NameAuthorizationRequirement requirement)
    

