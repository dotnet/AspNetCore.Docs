

CookieSigningOutContext Class
=============================



.. contents:: 
   :local:



Summary
-------

Context object passed to the ICookieAuthenticationEvents method SigningOut





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext`








Syntax
------

.. code-block:: csharp

   public class CookieSigningOutContext : BaseCookieContext





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/Events/CookieSigningOutContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext.CookieSigningOutContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions, Microsoft.AspNet.Http.CookieOptions)
    
        
        
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
        
        
        :type cookieOptions: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieSigningOutContext(HttpContext context, CookieAuthenticationOptions options, CookieOptions cookieOptions)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext.CookieOptions
    
        
    
        The options for creating the outgoing cookie.
        May be replace or altered during the SigningOut call.
    
        
        :rtype: Microsoft.AspNet.Http.CookieOptions
    
        
        .. code-block:: csharp
    
           public CookieOptions CookieOptions { get; set; }
    

