

PasswordHasherCompatibilityMode Enum
====================================






Specifies the format used for hashing passwords.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Identity`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum PasswordHasherCompatibilityMode








.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV2
    
        
    
        
        Indicates hashing passwords in a way that is compatible with ASP.NET Identity versions 1 and 2.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode
    
        
        .. code-block:: csharp
    
            IdentityV2 = 0
    
    .. dn:field:: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode.IdentityV3
    
        
    
        
        Indicates hashing passwords in a way that is compatible with ASP.NET Identity version 3.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode
    
        
        .. code-block:: csharp
    
            IdentityV3 = 1
    

