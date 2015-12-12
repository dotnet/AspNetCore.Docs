

OAuthMiddleware<TOptions> Class
===============================



.. contents:: 
   :local:



Summary
-------

An ASP.NET middleware for authenticating users using OAuth services.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{{TOptions}}`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware\<TOptions>`








Syntax
------

.. code-block:: csharp

   public class OAuthMiddleware<TOptions> : AuthenticationMiddleware<TOptions> where TOptions : OAuthOptions, new ()





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OAuth/OAuthMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>.OAuthMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, TOptions)
    
        
    
        Initializes a new OAuthAuthenticationMiddleware\.
    
        
        
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :param options: Configuration options for the middleware.
        
        :type options: {TOptions}
    
        
        .. code-block:: csharp
    
           public OAuthMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, TOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{{TOptions}}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.OAuth.OAuthOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<TOptions> CreateHandler()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware<TOptions>.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           protected HttpClient Backchannel { get; }
    

