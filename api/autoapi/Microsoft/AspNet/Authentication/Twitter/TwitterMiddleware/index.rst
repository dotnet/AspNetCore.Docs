

TwitterMiddleware Class
=======================



.. contents:: 
   :local:



Summary
-------

ASP.NET middleware for authenticating users using Twitter





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.Twitter.TwitterOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware`








Syntax
------

.. code-block:: csharp

   public class TwitterMiddleware : AuthenticationMiddleware<TwitterOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/TwitterMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware.TwitterMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, Microsoft.AspNet.Authentication.Twitter.TwitterOptions)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware`
    
        
        
        
        :param next: The next middleware in the HTTP pipeline to invoke
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :param options: Configuration options for the middleware
        
        :type options: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
    
        
        .. code-block:: csharp
    
           public TwitterMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, TwitterOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.Twitter.TwitterOptions}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.Twitter.TwitterOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<TwitterOptions> CreateHandler()
    

