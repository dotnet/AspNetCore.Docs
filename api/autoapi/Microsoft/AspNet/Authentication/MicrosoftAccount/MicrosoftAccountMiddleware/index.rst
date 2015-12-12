

MicrosoftAccountMiddleware Class
================================



.. contents:: 
   :local:



Summary
-------

An ASP.NET middleware for authenticating users using the Microsoft Account service.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware{Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware`








Syntax
------

.. code-block:: csharp

   public class MicrosoftAccountMiddleware : OAuthMiddleware<MicrosoftAccountOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.MicrosoftAccount/MicrosoftAccountMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware.MicrosoftAccountMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions)
    
        
    
        Initializes a new :any:`Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware`\.
    
        
        
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions
    
        
        .. code-block:: csharp
    
           public MicrosoftAccountMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, MicrosoftAccountOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountMiddleware.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.MicrosoftAccount.MicrosoftAccountOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<MicrosoftAccountOptions> CreateHandler()
    

