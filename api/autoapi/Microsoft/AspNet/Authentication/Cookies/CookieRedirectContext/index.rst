

CookieRedirectContext Class
===========================



.. contents:: 
   :local:



Summary
-------

Context passed when a Challenge, SignIn, or SignOut causes a redirect in the cookie middleware





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext`








Syntax
------

.. code-block:: csharp

   public class CookieRedirectContext : BaseCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieRedirectContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext.CookieRedirectContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions, System.String)
    
        
    
        Creates a new context object.
    
        
        
        
        :param context: The HTTP request context
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The cookie middleware options
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
        
        
        :param redirectUri: The initial redirect URI
        
        :type redirectUri: System.String
    
        
        .. code-block:: csharp
    
           public CookieRedirectContext(HttpContext context, CookieAuthenticationOptions options, string redirectUri)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext.RedirectUri
    
        
    
        Gets or Sets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RedirectUri { get; set; }
    

