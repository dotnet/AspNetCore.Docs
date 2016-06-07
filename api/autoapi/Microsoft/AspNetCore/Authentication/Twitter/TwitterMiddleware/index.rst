

TwitterMiddleware Class
=======================






ASP.NET Core middleware for authenticating users using Twitter.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.TwitterOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware`








Syntax
------

.. code-block:: csharp

    public class TwitterMiddleware : AuthenticationMiddleware<TwitterOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware.TwitterMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.TwitterOptions>)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware`
    
        
    
        
        :param next: The next middleware in the HTTP pipeline to invoke
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :param options: Configuration options for the middleware
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.TwitterOptions<Microsoft.AspNetCore.Builder.TwitterOptions>}
    
        
        .. code-block:: csharp
    
            public TwitterMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<TwitterOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.TwitterOptions<Microsoft.AspNetCore.Builder.TwitterOptions>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.TwitterOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<TwitterOptions> CreateHandler()
    

