

CookieSecurePolicy Enum
=======================






Determines how cookie security properties are set.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Http`
Assemblies
    * Microsoft.AspNetCore.Http.Abstractions

----

.. contents::
   :local:









Syntax
------

.. code-block:: csharp

    public enum CookieSecurePolicy








.. dn:enumeration:: Microsoft.AspNetCore.Http.CookieSecurePolicy
    :hidden:

.. dn:enumeration:: Microsoft.AspNetCore.Http.CookieSecurePolicy

Fields
------

.. dn:enumeration:: Microsoft.AspNetCore.Http.CookieSecurePolicy
    :noindex:
    :hidden:

    
    .. dn:field:: Microsoft.AspNetCore.Http.CookieSecurePolicy.Always
    
        
    
        
        Secure is always marked true. Use this value when your login page and all subsequent pages
        requiring the authenticated identity are HTTPS. Local development will also need to be done with HTTPS urls.
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieSecurePolicy
    
        
        .. code-block:: csharp
    
            Always = 1
    
    .. dn:field:: Microsoft.AspNetCore.Http.CookieSecurePolicy.None
    
        
    
        
        Secure is not marked true. Use this value when your login page is HTTPS, but other pages
        on the site which are HTTP also require authentication information. This setting is not recommended because
        the authentication information provided with an HTTP request may be observed and used by other computers
        on your local network or wireless connection.
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieSecurePolicy
    
        
        .. code-block:: csharp
    
            None = 2
    
    .. dn:field:: Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest
    
        
    
        
        If the URI that provides the cookie is HTTPS, then the cookie will only be returned to the server on 
        subsequent HTTPS requests. Otherwise if the URI that provides the cookie is HTTP, then the cookie will 
        be returned to the server on all HTTP and HTTPS requests. This is the default value because it ensures
        HTTPS for all authenticated requests on deployed servers, and also supports HTTP for localhost development 
        and for servers that do not have HTTPS support.
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieSecurePolicy
    
        
        .. code-block:: csharp
    
            SameAsRequest = 0
    

