

OpenIdConnectMiddleware Class
=============================






ASP.NET Core middleware for obtaining identities using OpenIdConnect protocol.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OpenIdConnect`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectMiddleware : AuthenticationMiddleware<OpenIdConnectOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
            protected HttpClient Backchannel
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware.HtmlEncoder
    
        
        :rtype: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            protected HtmlEncoder HtmlEncoder
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware.OpenIdConnectMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.AspNetCore.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, System.IServiceProvider, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.OpenIdConnectOptions>, System.Text.Encodings.Web.HtmlEncoder)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`
    
        
    
        
        :param next: The next middleware in the middleware pipeline to invoke.
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :param dataProtectionProvider:  provider for creating a data protector.
        
        :type dataProtectionProvider: Microsoft.AspNetCore.DataProtection.IDataProtectionProvider
    
        
        :param loggerFactory: factory for creating a :any:`Microsoft.Extensions.Logging.ILogger`\.
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type services: System.IServiceProvider
    
        
        :type sharedOptions: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions<Microsoft.AspNetCore.Authentication.SharedAuthenticationOptions>}
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.OpenIdConnectOptions<Microsoft.AspNetCore.Builder.OpenIdConnectOptions>}
    
        
        :param htmlEncoder: The :dn:prop:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware.HtmlEncoder`\.
        
        :type htmlEncoder: System.Text.Encodings.Web.HtmlEncoder
    
        
        .. code-block:: csharp
    
            public OpenIdConnectMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, UrlEncoder encoder, IServiceProvider services, IOptions<SharedAuthenticationOptions> sharedOptions, IOptions<OpenIdConnectOptions> options, HtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware.CreateHandler()
    
        
    
        
        Provides the :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.OpenIdConnectOptions<Microsoft.AspNetCore.Builder.OpenIdConnectOptions>}
        :return: An :any:`Microsoft.AspNetCore.Authentication.AuthenticationHandler\`1` configured with the :any:`Microsoft.AspNetCore.Builder.OpenIdConnectOptions` supplied to the constructor.
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<OpenIdConnectOptions> CreateHandler()
    

