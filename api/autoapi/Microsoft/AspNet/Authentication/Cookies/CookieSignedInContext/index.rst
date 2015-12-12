

CookieSignedInContext Class
===========================



.. contents:: 
   :local:



Summary
-------

Context object passed to the ICookieAuthenticationEvents method SignedIn.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext`








Syntax
------

.. code-block:: csharp

   public class CookieSignedInContext : BaseCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieSignedInContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext.CookieSignedInContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions, System.String, System.Security.Claims.ClaimsPrincipal, Microsoft.AspNet.Http.Authentication.AuthenticationProperties)
    
        
    
        Creates a new instance of the context object.
    
        
        
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The middleware options
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
        
        
        :param authenticationScheme: Initializes AuthenticationScheme property
        
        :type authenticationScheme: System.String
        
        
        :param principal: Initializes Principal property
        
        :type principal: System.Security.Claims.ClaimsPrincipal
        
        
        :param properties: Initializes Properties property
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public CookieSignedInContext(HttpContext context, CookieAuthenticationOptions options, string authenticationScheme, ClaimsPrincipal principal, AuthenticationProperties properties)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext.AuthenticationScheme
    
        
    
        The name of the AuthenticationScheme creating a cookie
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AuthenticationScheme { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext.Principal
    
        
    
        Contains the claims that were converted into the outgoing cookie.
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext.Properties
    
        
    
        Contains the extra data that was contained in the outgoing cookie.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; }
    

