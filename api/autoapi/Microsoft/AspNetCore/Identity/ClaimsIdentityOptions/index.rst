

ClaimsIdentityOptions Class
===========================






Options used to configure the claim types used for well known claims.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Identity.ClaimsIdentityOptions`








Syntax
------

.. code-block:: csharp

    public class ClaimsIdentityOptions








.. dn:class:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.RoleClaimType
    
        
    
        
        Gets or sets the ClaimType used for a Role claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RoleClaimType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.SecurityStampClaimType
    
        
    
        
        Gets or sets the ClaimType used for the security stamp claim..
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string SecurityStampClaimType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserIdClaimType
    
        
    
        
        Gets or sets the ClaimType used for the user identifier claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UserIdClaimType
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions.UserNameClaimType
    
        
    
        
        Gets or sets the ClaimType used for the user name claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UserNameClaimType
            {
                get;
                set;
            }
    

