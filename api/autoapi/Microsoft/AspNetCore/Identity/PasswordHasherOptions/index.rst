

PasswordHasherOptions Class
===========================






Specifies options for password hashing.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.PasswordHasherOptions`








Syntax
------

.. code-block:: csharp

    public class PasswordHasherOptions








.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasherOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasherOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordHasherOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordHasherOptions.CompatibilityMode
    
        
    
        
        Gets or sets the compatibility mode used when hashing passwords.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordHasherCompatibilityMode
        :return: 
            The compatibility mode used when hashing passwords.
    
        
        .. code-block:: csharp
    
            public PasswordHasherCompatibilityMode CompatibilityMode
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordHasherOptions.IterationCount
    
        
    
        
        Gets or sets the number of iterations used when hashing passwords using PBKDF2.
    
        
        :rtype: System.Int32
        :return: 
            The number of iterations used when hashing passwords using PBKDF2.
    
        
        .. code-block:: csharp
    
            public int IterationCount
            {
                get;
                set;
            }
    

