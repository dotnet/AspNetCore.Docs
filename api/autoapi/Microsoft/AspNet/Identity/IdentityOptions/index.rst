

IdentityOptions Class
=====================



.. contents:: 
   :local:



Summary
-------

Represents all the options you can use to configure the identity system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.IdentityOptions`








Syntax
------

.. code-block:: csharp

   public class IdentityOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/identity/blob/master/src/Microsoft.AspNet.Identity/IdentityOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.IdentityOptions

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.IdentityOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.ClaimsIdentity
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.ClaimsIdentityOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.ClaimsIdentityOptions
    
        
        .. code-block:: csharp
    
           public ClaimsIdentityOptions ClaimsIdentity { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.Cookies
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.IdentityCookieOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.IdentityCookieOptions
    
        
        .. code-block:: csharp
    
           public IdentityCookieOptions Cookies { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.Lockout
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.LockoutOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.LockoutOptions
    
        
        .. code-block:: csharp
    
           public LockoutOptions Lockout { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.Password
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.PasswordOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.PasswordOptions
    
        
        .. code-block:: csharp
    
           public PasswordOptions Password { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.SecurityStampValidationInterval
    
        
    
        Gets or sets the :any:`System.TimeSpan` after which security stamps are re-validated.
    
        
        :rtype: System.TimeSpan
    
        
        .. code-block:: csharp
    
           public TimeSpan SecurityStampValidationInterval { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.SignIn
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.SignInOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.SignInOptions
    
        
        .. code-block:: csharp
    
           public SignInOptions SignIn { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.Tokens
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.TokenOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.TokenOptions
    
        
        .. code-block:: csharp
    
           public TokenOptions Tokens { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityOptions.User
    
        
    
        Gets or sets the :any:`Microsoft.AspNet.Identity.UserOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNet.Identity.UserOptions
    
        
        .. code-block:: csharp
    
           public UserOptions User { get; set; }
    

