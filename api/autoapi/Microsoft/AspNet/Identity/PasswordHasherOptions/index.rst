

PasswordHasherOptions Class
===========================



.. contents:: 
   :local:



Summary
-------

Specifies options for password hashing.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.PasswordHasherOptions`








Syntax
------

.. code-block:: csharp

   public class PasswordHasherOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/PasswordHasherOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.PasswordHasherOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.PasswordHasherOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordHasherOptions.CompatibilityMode
    
        
    
        Gets or sets the compatibility mode used when hashing passwords.
    
        
        :rtype: Microsoft.AspNet.Identity.PasswordHasherCompatibilityMode
    
        
        .. code-block:: csharp
    
           public PasswordHasherCompatibilityMode CompatibilityMode { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordHasherOptions.IterationCount
    
        
    
        Gets or sets the number of iterations used when hashing passwords using PBKDF2.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int IterationCount { get; set; }
    

