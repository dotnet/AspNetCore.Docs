

FacebookMiddleware Class
========================



.. contents:: 
   :local:



Summary
-------

An ASP.NET middleware for authenticating users using Facebook.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.Facebook.FacebookOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNet.Authentication.Facebook.FacebookOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware`








Syntax
------

.. code-block:: csharp

   public class FacebookMiddleware : OAuthMiddleware<FacebookOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.Facebook/FacebookMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware.FacebookMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, Microsoft.AspNet.Authentication.Facebook.FacebookOptions)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware`\.
    
        
        
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.Facebook.FacebookOptions
    
        
        .. code-block:: csharp
    
           public FacebookMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, FacebookOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Facebook.FacebookMiddleware.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.Facebook.FacebookOptions}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.Facebook.FacebookOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<FacebookOptions> CreateHandler()
    

