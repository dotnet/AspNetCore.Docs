

PasswordOptions Class
=====================






Specifies options for password requirements.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.PasswordOptions`








Syntax
------

.. code-block:: csharp

    public class PasswordOptions








.. dn:class:: Microsoft.AspNetCore.Identity.PasswordOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.PasswordOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordOptions.RequireDigit
    
        
    
        
        Gets or sets a flag indicating if passwords must contain a digit.
    
        
        :rtype: System.Boolean
        :return: True if passwords must contain a digit.
    
        
        .. code-block:: csharp
    
            public bool RequireDigit { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordOptions.RequireLowercase
    
        
    
        
        Gets or sets a flag indicating if passwords must contain a lower case ASCII character.
    
        
        :rtype: System.Boolean
        :return: True if passwords must contain a lower case ASCII character.
    
        
        .. code-block:: csharp
    
            public bool RequireLowercase { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordOptions.RequireNonAlphanumeric
    
        
    
        
        Gets or sets a flag indicating if passwords must contain a non-alphanumeric character.
    
        
        :rtype: System.Boolean
        :return: True if passwords must contain a non-alphanumeric character, otherwise false.
    
        
        .. code-block:: csharp
    
            public bool RequireNonAlphanumeric { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordOptions.RequireUppercase
    
        
    
        
        Gets or sets a flag indicating if passwords must contain a upper case ASCII character.
    
        
        :rtype: System.Boolean
        :return: True if passwords must contain a upper case ASCII character.
    
        
        .. code-block:: csharp
    
            public bool RequireUppercase { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.PasswordOptions.RequiredLength
    
        
    
        
        Gets or sets the minimum length a password must be.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
            public int RequiredLength { get; set; }
    

