

IdentityCookieOptions Class
===========================



.. contents:: 
   :local:



Summary
-------

Represents all the options you can use to configure the cookies middleware uesd by the identity system.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Identity.IdentityCookieOptions`








Syntax
------

.. code-block:: csharp

   public class IdentityCookieOptions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/identity/src/Microsoft.AspNet.Identity/IdentityCookieOptions.cs>`_





.. dn:class:: Microsoft.AspNet.Identity.IdentityCookieOptions

Constructors
------------

.. dn:class:: Microsoft.AspNet.Identity.IdentityCookieOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Identity.IdentityCookieOptions.IdentityCookieOptions()
    
        
    
        
        .. code-block:: csharp
    
           public IdentityCookieOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Identity.IdentityCookieOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.ApplicationCookie
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions ApplicationCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.ApplicationCookieAuthenticationScheme
    
        
    
        Gets or sets the scheme used to identify application authentication cookies.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ApplicationCookieAuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.ApplicationCookieAuthenticationType
    
        
    
        Gets or sets the authentication type used when constructing an ClaimsIdentity from an application cookie.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public static string ApplicationCookieAuthenticationType { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.ExternalCookie
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions ExternalCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.ExternalCookieAuthenticationScheme
    
        
    
        Gets or sets the scheme used to identify external authentication cookies.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ExternalCookieAuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.TwoFactorRememberMeCookie
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions TwoFactorRememberMeCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.TwoFactorRememberMeCookieAuthenticationScheme
    
        
    
        Gets or sets the scheme used to identify Two Factor authentication cookies for saving the Remember Me state.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TwoFactorRememberMeCookieAuthenticationScheme { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.TwoFactorUserIdCookie
    
        
        :rtype: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationOptions TwoFactorUserIdCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Identity.IdentityCookieOptions.TwoFactorUserIdCookieAuthenticationScheme
    
        
    
        Gets or sets the scheme used to identify Two Factor authentication cookies for round tripping user identities.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string TwoFactorUserIdCookieAuthenticationScheme { get; set; }
    

