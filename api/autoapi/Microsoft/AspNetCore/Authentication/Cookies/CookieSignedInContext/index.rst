

CookieSignedInContext Class
===========================






Context object passed to the ICookieAuthenticationEvents method SignedIn.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext`








Syntax
------

.. code-block:: csharp

    public class CookieSignedInContext : BaseCookieContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext.CookieSignedInContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.CookieAuthenticationOptions, System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties)
    
        
    
        
        Creates a new instance of the context object.
    
        
    
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The middleware options
        
        :type options: Microsoft.AspNetCore.Builder.CookieAuthenticationOptions
    
        
        :param authenticationScheme: Initializes AuthenticationScheme property
        
        :type authenticationScheme: System.String
    
        
        :param principal: Initializes Principal property
        
        :type principal: System.Security.Claims.ClaimsPrincipal
    
        
        :param properties: Initializes Properties property
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public CookieSignedInContext(HttpContext context, CookieAuthenticationOptions options, string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext.AuthenticationScheme
    
        
    
        
        The name of the AuthenticationScheme creating a cookie
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext.Principal
    
        
    
        
        Contains the claims that were converted into the outgoing cookie.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext.Properties
    
        
    
        
        Contains the extra data that was contained in the outgoing cookie.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    

