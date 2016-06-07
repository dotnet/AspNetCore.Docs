

FacebookMiddleware Class
========================






An ASP.NET Core middleware for authenticating users using Facebook.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Facebook`
Assemblies
    * Microsoft.AspNetCore.Authentication.Facebook

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.FacebookOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNetCore.Builder.FacebookOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware`








Syntax
------

.. code-block:: csharp

    public class FacebookMiddleware : OAuthMiddleware<FacebookOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware.FacebookMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.FacebookOptions>)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware`\.
    
        
    
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.FacebookOptions<Microsoft.AspNetCore.Builder.FacebookOptions>}
    
        
        .. code-block:: csharp
    
            public FacebookMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<FacebookOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Facebook.FacebookMiddleware.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.FacebookOptions<Microsoft.AspNetCore.Builder.FacebookOptions>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.FacebookOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<FacebookOptions> CreateHandler()
    

