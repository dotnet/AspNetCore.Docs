

GoogleMiddleware Class
======================






An ASP.NET Core middleware for authenticating users using Google OAuth 2.0.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Google`
Assemblies
    * Microsoft.AspNetCore.Authentication.Google

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.GoogleOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNetCore.Builder.GoogleOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware`








Syntax
------

.. code-block:: csharp

    public class GoogleMiddleware : OAuthMiddleware<GoogleOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware.GoogleMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.GoogleOptions>)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware`\.
    
        
    
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.GoogleOptions<Microsoft.AspNetCore.Builder.GoogleOptions>}
    
        
        .. code-block:: csharp
    
            public GoogleMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<GoogleOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Google.GoogleMiddleware.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.GoogleOptions<Microsoft.AspNetCore.Builder.GoogleOptions>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.GoogleOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<GoogleOptions> CreateHandler()
    

