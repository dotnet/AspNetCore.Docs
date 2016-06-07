

CookieSigningInContext Class
============================






Context object passed to the ICookieAuthenticationEvents method SigningIn.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext`








Syntax
------

.. code-block:: csharp

    public class CookieSigningInContext : BaseCookieContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext.AuthenticationScheme
    
        
    
        
        The name of the AuthenticationScheme creating a cookie
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext.CookieOptions
    
        
    
        
        The options for creating the outgoing cookie.
        May be replace or altered during the SigningIn call.
    
        
        :rtype: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieOptions CookieOptions
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext.Principal
    
        
    
        
        Contains the claims about to be converted into the outgoing cookie.
        May be replaced or altered during the SigningIn call.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext.Properties
    
        
    
        
        Contains the extra data about to be contained in the outgoing cookie.
        May be replaced or altered during the SigningIn call.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext.CookieSigningInContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions, System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, Microsoft.AspNetCore.Http.CookieOptions)
    
        
    
        
        Creates a new instance of the context object.
    
        
    
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The middleware options
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        :param authenticationScheme: Initializes AuthenticationScheme property
        
        :type authenticationScheme: System.String
    
        
        :param principal: Initializes Principal property
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param properties: Initializes Extra property
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param cookieOptions: Initializes options for the authentication cookie.
        
        :type cookieOptions: Microsoft.AspNetCore.Http.CookieOptions
    
        
        .. code-block:: csharp
    
            public CookieSigningInContext(HttpContext context, CookieAuthenticationOptions options, string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties, CookieOptions cookieOptions)
    

