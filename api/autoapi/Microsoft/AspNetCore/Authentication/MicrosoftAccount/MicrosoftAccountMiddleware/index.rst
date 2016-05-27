

MicrosoftAccountMiddleware Class
================================






An ASP.NET Core middleware for authenticating users using the Microsoft Account service.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.MicrosoftAccount`
Assemblies
    * Microsoft.AspNetCore.Authentication.MicrosoftAccount

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.MicrosoftAccountOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNetCore.Builder.MicrosoftAccountOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware`








Syntax
------

.. code-block:: csharp

    public class MicrosoftAccountMiddleware : OAuthMiddleware<MicrosoftAccountOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware.MicrosoftAccountMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.MicrosoftAccountOptions>)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware`\.
    
        
    
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.MicrosoftAccountOptions<Microsoft.AspNetCore.Builder.MicrosoftAccountOptions>}
    
        
        .. code-block:: csharp
    
            public MicrosoftAccountMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<MicrosoftAccountOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.MicrosoftAccountOptions<Microsoft.AspNetCore.Builder.MicrosoftAccountOptions>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.MicrosoftAccountOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<MicrosoftAccountOptions> CreateHandler()
    

