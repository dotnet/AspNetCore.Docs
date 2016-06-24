

IdentityCookieOptions Class
===========================






Represents all the options you can use to configure the cookies middleware uesd by the identity system.


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
* :dn:cls:`Microsoft.AspNetCore.Identity.IdentityCookieOptions`








Syntax
------

.. code-block:: csharp

    public class IdentityCookieOptions








.. dn:class:: Microsoft.AspNetCore.Identity.IdentityCookieOptions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityCookieOptions

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityCookieOptions
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.IdentityCookieOptions()
    
        
    
        
        .. code-block:: csharp
    
            public IdentityCookieOptions()
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Identity.IdentityCookieOptions
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.ApplicationCookie
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationOptions ApplicationCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.ApplicationCookieAuthenticationScheme
    
        
    
        
        Gets the scheme used to identify application authentication cookies.
    
        
        :rtype: System.String
        :return: The scheme used to identify application authentication cookies.
    
        
        .. code-block:: csharp
    
            public string ApplicationCookieAuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.ExternalCookie
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationOptions ExternalCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.ExternalCookieAuthenticationScheme
    
        
    
        
        Gets the scheme used to identify external authentication cookies.
    
        
        :rtype: System.String
        :return: The scheme used to identify external authentication cookies.
    
        
        .. code-block:: csharp
    
            public string ExternalCookieAuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.TwoFactorRememberMeCookie
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationOptions TwoFactorRememberMeCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.TwoFactorRememberMeCookieAuthenticationScheme
    
        
    
        
        Gets the scheme used to identify Two Factor authentication cookies for saving the Remember Me state.
    
        
        :rtype: System.String
        :return: The scheme used to identify remember me application authentication cookies.
    
        
        .. code-block:: csharp
    
            public string TwoFactorRememberMeCookieAuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.TwoFactorUserIdCookie
    
        
        :rtype: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationOptions TwoFactorUserIdCookie { get; set; }
    
    .. dn:property:: Microsoft.AspNetCore.Identity.IdentityCookieOptions.TwoFactorUserIdCookieAuthenticationScheme
    
        
    
        
        Gets the scheme used to identify Two Factor authentication cookies for round tripping user identities.
    
        
        :rtype: System.String
        :return: The scheme used to identify user identity 2fa authentication cookies.
    
        
        .. code-block:: csharp
    
            public string TwoFactorUserIdCookieAuthenticationScheme { get; }
    

