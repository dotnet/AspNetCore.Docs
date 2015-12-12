

JwtBearerAppBuilderExtensions Class
===================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add OpenIdConnect Bearer authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.JwtBearerAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class JwtBearerAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.JwtBearer/JwtBearerAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.JwtBearerAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.JwtBearerAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.JwtBearerAppBuilderExtensions.UseJwtBearerAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Bearer token processing capabilities.
        This middleware understands appropriately
        formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode
        is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        any time to obtain the claims from the request's bearer token.
        See also http://tools.ietf.org/html/rfc6749
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseJwtBearerAuthentication(IApplicationBuilder app, JwtBearerOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.JwtBearerAppBuilderExtensions.UseJwtBearerAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables Bearer token processing capabilities.
        This middleware understands appropriately
        formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode
        is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        any time to obtain the claims from the request's bearer token.
        See also http://tools.ietf.org/html/rfc6749
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseJwtBearerAuthentication(IApplicationBuilder app, Action<JwtBearerOptions> configureOptions)
    

