

CookieSigningOutContext Class
=============================






Context object passed to the ICookieAuthenticationEvents method SigningOut    


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Cookies`
Assemblies
    * Microsoft.AspNetCore.Authentication.Cookies

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext`








Syntax
------

.. code-block:: csharp

    public class CookieSigningOutContext : BaseCookieContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext.CookieOptions
    
        
    
        
        The options for creating the outgoing cookie.
        May be replace or altered during the SigningOut call.
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieOptions CookieOptions
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext.Properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext.CookieSigningOutContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        
    
        
    
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :type cookieOptions: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieSigningOutContext(HttpContext context, CookieAuthenticationOptions options, AuthenticationProperties properties, CookieOptions cookieOptions)
    

