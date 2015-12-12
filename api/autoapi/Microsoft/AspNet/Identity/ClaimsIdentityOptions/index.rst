

ClaimsIdentityOptions Class
===========================



.. contents:: 
   :local:



Summary
-------

Options used to configure the claim types used for well known claims.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.ClaimsIdentityOptions`








Syntax
------

.. code-block:: csharp

   public class ClaimsIdentityOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/ClaimsIdentityOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.ClaimsIdentityOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.ClaimsIdentityOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.ClaimsIdentityOptions.RoleClaimType
    
        
    
        Gets or sets the ClaimType used for a Role claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RoleClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.ClaimsIdentityOptions.SecurityStampClaimType
    
        
    
        Gets or sets the ClaimType used for the security stamp claim..
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string SecurityStampClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.ClaimsIdentityOptions.UserIdClaimType
    
        
    
        Gets or sets the ClaimType used for the user identifier claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UserIdClaimType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.ClaimsIdentityOptions.UserNameClaimType
    
        
    
        Gets or sets the ClaimType used for the user name claim.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UserNameClaimType { get; set; }
    

