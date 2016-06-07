

CookieSecureOption Enum
=======================






Determines how the identity cookie's security property is set.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum CookieSecureOption








.. dn:enumeration:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption.Always
    
        
    
        
        CookieOptions.Secure is always marked true. Use this value when your login page and all subsequent pages
        requiring the authenticated identity are HTTPS. Local development will also need to be done with HTTPS urls.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption
    
        
        .. code-block:: csharp
    
            Always = 2
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption.Never
    
        
    
        
        CookieOptions.Secure is never marked true. Use this value when your login page is HTTPS, but other pages
        on the site which are HTTP also require authentication information. This setting is not recommended because
        the authentication information provided with an HTTP request may be observed and used by other computers
        on your local network or wireless connection.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption
    
        
        .. code-block:: csharp
    
            Never = 1
    
    .. dn:field:: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption.SameAsRequest
    
        
    
        
        If the URI that provides the cookie is HTTPS, then the cookie will only be returned to the server on 
        subsequent HTTPS requests. Otherwise if the URI that provides the cookie is HTTP, then the cookie will 
        be returned to the server on all HTTP and HTTPS requests. This is the default value because it ensures
        HTTPS for all authenticated requests on deployed servers, and also supports HTTP for localhost development 
        and for servers that do not have HTTPS support.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption
    
        
        .. code-block:: csharp
    
            SameAsRequest = 0
    

