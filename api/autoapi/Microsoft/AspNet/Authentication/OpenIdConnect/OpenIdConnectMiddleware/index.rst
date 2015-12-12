

OpenIdConnectMiddleware Class
=============================



.. contents:: 
   :local:



Summary
-------

ASP.NET middleware for obtaining identities using OpenIdConnect protocol.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectMiddleware : AuthenticationMiddleware<OpenIdConnectOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware.OpenIdConnectMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.AspNet.DataProtection.IDataProtectionProvider, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, System.IServiceProvider, Microsoft.Extensions.OptionsModel.IOptions<Microsoft.AspNet.Authentication.SharedAuthenticationOptions>, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions, Microsoft.Extensions.WebEncoders.IHtmlEncoder)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`
    
        
        
        
        :param next: The next middleware in the ASP.NET pipeline to invoke.
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :param dataProtectionProvider: provider for creating a data protector.
        
        :type dataProtectionProvider: Microsoft.AspNet.DataProtection.IDataProtectionProvider
        
        
        :param loggerFactory: factory for creating a .
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type services: System.IServiceProvider
        
        
        :type sharedOptions: Microsoft.Extensions.OptionsModel.IOptions{Microsoft.AspNet.Authentication.SharedAuthenticationOptions}
        
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
        
        
        :type htmlEncoder: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           public OpenIdConnectMiddleware(RequestDelegate next, IDataProtectionProvider dataProtectionProvider, ILoggerFactory loggerFactory, IUrlEncoder encoder, IServiceProvider services, IOptions<SharedAuthenticationOptions> sharedOptions, OpenIdConnectOptions options, IHtmlEncoder htmlEncoder)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware.CreateHandler()
    
        
    
        Provides the AuthenticationHandler object for processing authentication-related requests.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions}
        :return: An <see cref="!:AuthenticationHandler" /> configured with the <see cref="T:Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions" /> supplied to the constructor.
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<OpenIdConnectOptions> CreateHandler()
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware.Backchannel
    
        
        :rtype: System.Net.Http.HttpClient
    
        
        .. code-block:: csharp
    
           protected HttpClient Backchannel { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware.HtmlEncoder
    
        
        :rtype: Microsoft.Extensions.WebEncoders.IHtmlEncoder
    
        
        .. code-block:: csharp
    
           protected IHtmlEncoder HtmlEncoder { get; }
    

