

PasswordOptions Class
=====================



.. contents:: 
   :local:



Summary
-------

Specifies options for password requirements.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.PasswordOptions`








Syntax
------

.. code-block:: csharp

   public class PasswordOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/PasswordOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.PasswordOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.PasswordOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordOptions.RequireDigit
    
        
    
        Gets or sets a flag indicating if passwords must contain a digit.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireDigit { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordOptions.RequireLowercase
    
        
    
        Gets or sets a flag indicating if passwords must contain a lower case ASCII character.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireLowercase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordOptions.RequireNonLetterOrDigit
    
        
    
        Gets or sets a flag indicating if passwords must contain a digit or other non-alphabetical character.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireNonLetterOrDigit { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordOptions.RequireUppercase
    
        
    
        Gets or sets a flag indicating if passwords must contain a upper case ASCII character.
    
        
        :rtype: System.Boolean
    
        
        .. code-block:: csharp
    
           public bool RequireUppercase { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.PasswordOptions.RequiredLength
    
        
    
        Gets or sets the minimum length a password must be.
    
        
        :rtype: System.Int32
    
        
        .. code-block:: csharp
    
           public int RequiredLength { get; set; }
    

