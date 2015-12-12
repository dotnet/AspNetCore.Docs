

CookieSigningInContext Class
============================



.. contents:: 
   :local:



Summary
-------

Context object passed to the ICookieAuthenticationEvents method SigningIn.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext`








Syntax
------

.. code-block:: csharp

   public class CookieSigningInContext : BaseCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieSigningInContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext.CookieSigningInContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions, System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, Microsoft.AspNet.Http.CookieOptions)
    
        
    
        Creates a new instance of the context object.
    
        
        
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The middleware options
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
        
        
        :param authenticationScheme: Initializes AuthenticationScheme property
        
        :type authenticationScheme: System.String
        
        
        :param principal: Initializes Principal property
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :param properties: Initializes Extra property
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :param cookieOptions: Initializes options for the authentication cookie.
        
        :type cookieOptions: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieSigningInContext(HttpContext context, CookieAuthenticationOptions options, string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties, CookieOptions cookieOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext.AuthenticationScheme
    
        
    
        The name of the AuthenticationScheme creating a cookie
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext.CookieOptions
    
        
    
        The options for creating the outgoing cookie.
        May be replace or altered during the SigningIn call.
    
        
        :rtype: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieOptions CookieOptions { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext.Principal
    
        
    
        Contains the claims about to be converted into the outgoing cookie.
        May be replaced or altered during the SigningIn call.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext.Properties
    
        
    
        Contains the extra data about to be contained in the outgoing cookie.
        May be replaced or altered during the SigningIn call.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    

