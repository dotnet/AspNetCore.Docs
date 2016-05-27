

OAuthMiddleware<TOptions> Class
===============================






An ASP.NET Core middleware for authenticating users using OAuth services.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{{TOptions}}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\<TOptions>`








Syntax
------

.. code-block:: csharp

    public class OAuthMiddleware<TOptions> : AuthenticationMiddleware<TOptions> where TOptions : OAuthOptions, new ()








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware`1
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            protected HttpClient Backchannel
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>.OAuthMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<TOptions>)
    
        
    
        
        Initializes a new :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1`\.
    
        
    
        
        :param next: The next middleware in the HTTP pipeline to invoke.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :param encoder: The :any:`System.Text.Encodings.Web.UrlEncoder`\.
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :param sharedOptions: The :any:`Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions` configuration options for this middleware.
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :param options: Configuration options for the middleware.
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{TOptions}
    
        
        .. code-block:: csharp
    
            public OAuthMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<TOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware<TOptions>.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{TOptions}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.OAuthOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<TOptions> CreateHandler()
    

