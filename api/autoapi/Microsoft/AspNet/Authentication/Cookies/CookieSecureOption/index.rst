

CookieSecureOption Enum
=======================



.. contents:: 
   :local:



Summary
-------

Determines how the identity cookie's security property is set.











Syntax
------

.. code-block:: csharp

   public enum CookieSecureOption





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/CookieSecureOption.cs>`_





.. dn:enumeration:: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption

Fields
------

.. dn:enumeration:: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption.Always
    
        
    
        CookieOptions.Secure is always marked true. Use this value when your login page and all subsequent pages
        requiring the authenticated identity are HTTPS. Local development will also need to be done with HTTPS urls.
    
        
    
        
        .. code-block:: csharp
    
           Always = 2
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption.Never
    
        
    
        CookieOptions.Secure is never marked true. Use this value when your login page is HTTPS, but other pages
        on the site which are HTTP also require authentication information. This setting is not recommended because
        the authentication information provided with an HTTP request may be observed and used by other computers
        on your local network or wireless connection.
    
        
    
        
        .. code-block:: csharp
    
           Never = 1
    
    .. dn:field:: Microsoft.AspNet.Authentication.Cookies.CookieSecureOption.SameAsRequest
    
        
    
        If the URI that provides the cookie is HTTPS, then the cookie will only be returned to the server on
        subsequent HTTPS requests. Otherwise if the URI that provides the cookie is HTTP, then the cookie will
        be returned to the server on all HTTP and HTTPS requests. This is the default value because it ensures
        HTTPS for all authenticated requests on deployed servers, and also supports HTTP for localhost development
        and for servers that do not have HTTPS support.
    
        
    
        
        .. code-block:: csharp
    
           SameAsRequest = 0
    

