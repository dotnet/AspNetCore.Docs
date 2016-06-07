

CookieAuthenticationMiddleware Class
====================================





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
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.CookieAuthenticationOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware`








Syntax
------

.. code-block:: csharp

    public class CookieAuthenticationMiddleware : AuthenticationMiddleware<CookieAuthenticationOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware.CookieAuthenticationMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>)
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type urlEncoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.CookieAuthenticationOptions<Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>}
    
        
        .. code-block:: csharp
    
            public CookieAuthenticationMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder urlEncoder, IOptions<CookieAuthenticationOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware.CreateHandler()
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.CookieAuthenticationOptions<Microsoft.AspNetCore.Builder.CookieAuthenticationOptions>}
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<CookieAuthenticationOptions> CreateHandler()
    

