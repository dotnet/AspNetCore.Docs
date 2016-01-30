

PasswordHasherCompatibilityMode Enum
====================================



.. contents:: 
   :local:



Summary
-------

Specifies the format used for hashing passwords.











Syntax
------

.. code-block:: csharp

   public enum PasswordHasherCompatibilityMode





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/PasswordHasherCompatibilityMode.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Identity.PasswordHasherCompatibilityMode

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Identity.PasswordHasherCompatibilityMode
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Identity.PasswordHasherCompatibilityMode.IdentityV2
    
        
    
        Indicates hashing passwords in a way that is compatible with ASP.NET Identity versions 1 and 2.
    
        
    
        
        .. code-block:: csharp
    
           IdentityV2 = 0
    
    .. dn:field:: Microsoft.AspNet.Identity.PasswordHasherCompatibilityMode.IdentityV3
    
        
    
        Indicates hashing passwords in a way that is compatible with ASP.NET Identity version 3.
    
        
    
        
        .. code-block:: csharp
    
           IdentityV3 = 1
    

