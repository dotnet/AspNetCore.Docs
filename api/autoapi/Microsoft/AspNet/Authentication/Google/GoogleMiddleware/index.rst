

GoogleMiddleware Class
======================



.. contents:: 
   :local:



Summary
-------

An ASP.NET middleware for authenticating users using Google OAuth 2.0.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.Google.GoogleOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNet.Authentication.Google.GoogleOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.Google.GoogleMiddleware`








Syntax
------

.. code-block:: csharp

   public class GoogleMiddleware : OAuthMiddleware<GoogleOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Google/GoogleMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Google.GoogleMiddleware.GoogleMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, Microsoft.AspNet.Authentication.Google.GoogleOptions)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.Google.GoogleMiddleware`\.
    
        
        
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Google.GoogleOptions
    
        
        .. code-block:: csharp
    
           public GoogleMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, GoogleOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Google.GoogleMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Google.GoogleMiddleware.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.Google.GoogleOptions}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.Google.GoogleOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<GoogleOptions> CreateHandler()
    

