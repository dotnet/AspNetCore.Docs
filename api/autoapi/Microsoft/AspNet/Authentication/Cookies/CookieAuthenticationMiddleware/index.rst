

CookieAuthenticationMiddleware Class
====================================



.. contents:: 
   :local:







Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware`








Syntax
------

.. code-block:: csharp

   public class CookieAuthenticationMiddleware : AuthenticationMiddleware<CookieAuthenticationOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Cookies/CookieAuthenticationMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware.CookieAuthenticationMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions)
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type urlEncoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type options: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions
    
        
        .. code-block:: csharp
    
           public CookieAuthenticationMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder urlEncoder, CookieAuthenticationOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware.CreateHandler()
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions}
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<CookieAuthenticationOptions> CreateHandler()
    

