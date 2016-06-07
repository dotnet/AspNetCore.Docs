

RolesAuthorizationRequirement Class
===================================





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
* :dn:cls:`Microsoft.AspNetCore.Authorization.AuthorizationHandler{Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement}`
* :dn:cls:`Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement`








Syntax
------

.. code-block:: csharp

    public class RolesAuthorizationRequirement : AuthorizationHandler<RolesAuthorizationRequirement>, IAuthorizationHandler, IAuthorizationRequirement








.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.AllowedRoles
    
        
        :rtype: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public IEnumerable<string> AllowedRoles
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.RolesAuthorizationRequirement(System.Collections.Generic.IEnumerable<System.String>)
    
        
    
        
        :type allowedRoles: System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable`1>{System.String<System.String>}
    
        
        .. code-block:: csharp
    
            public RolesAuthorizationRequirement(IEnumerable<string> allowedRoles)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement.Handle(Microsoft.AspNetCore.Authorization.AuthorizationContext, Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement)
    
        
    
        
        :type context: Microsoft.AspNetCore.Authorization.AuthorizationContext
    
        
        :type requirement: Microsoft.AspNetCore.Authorization.Infrastructure.RolesAuthorizationRequirement
    
        
        .. code-block:: csharp
    
            protected override void Handle(AuthorizationContext context, RolesAuthorizationRequirement requirement)
    

