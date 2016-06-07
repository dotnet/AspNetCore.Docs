

IdentityOptions Class
=====================






Represents all the options you can use to configure the identity system.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Identity

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.IdentityOptions`








Syntax
------

.. code-block:: csharp

    public class IdentityOptions








.. dn:class:: Microsoft.AspNetCore.Builder.IdentityOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.IdentityOptions

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Builder.IdentityOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.ClaimsIdentity
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.ClaimsIdentityOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.ClaimsIdentityOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.ClaimsIdentityOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public ClaimsIdentityOptions ClaimsIdentity
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.Cookies
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.IdentityCookieOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.IdentityCookieOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.IdentityCookieOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public IdentityCookieOptions Cookies
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.Lockout
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.LockoutOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.LockoutOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.LockoutOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public LockoutOptions Lockout
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.Password
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.PasswordOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.PasswordOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.PasswordOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public PasswordOptions Password
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.SecurityStampValidationInterval
    
        
    
        
        Gets or sets the :any:`System.TimeSpan` after which security stamps are re-validated.
    
        
        :rtype: System.TimeSpan
        :return: 
            The :any:`System.TimeSpan` after which security stamps are re-validated.
    
        
        .. code-block:: csharp
    
            public TimeSpan SecurityStampValidationInterval
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.SignIn
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.SignInOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.SignInOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.SignInOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public SignInOptions SignIn
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.Tokens
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.TokenOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.TokenOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.TokenOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public TokenOptions Tokens
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Builder.IdentityOptions.User
    
        
    
        
        Gets or sets the :any:`Microsoft.AspNetCore.Identity.UserOptions` for the identity system.
    
        
        :rtype: Microsoft.AspNetCore.Identity.UserOptions
        :return: 
            The :any:`Microsoft.AspNetCore.Identity.UserOptions` for the identity system.
    
        
        .. code-block:: csharp
    
            public UserOptions User
            {
                get;
                set;
            }
    

