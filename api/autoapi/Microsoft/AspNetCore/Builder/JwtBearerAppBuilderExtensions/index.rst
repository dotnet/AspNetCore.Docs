

JwtBearerAppBuilderExtensions Class
===================================






Extension methods to add OpenIdConnect Bearer authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class JwtBearerAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions.UseJwtBearerAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Bearer token processing capabilities.
        This middleware understands appropriately
        formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode 
        is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        any time to obtain the claims from the request's bearer token.
        See also http://tools.ietf.org/html/rfc6749
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseJwtBearerAuthentication(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.JwtBearerAppBuilderExtensions.UseJwtBearerAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.JwtBearerOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables Bearer token processing capabilities.
        This middleware understands appropriately
        formatted and secured tokens which appear in the request header. If the Options.AuthenticationMode is Active, the
        claims within the bearer token are added to the current request's IPrincipal User. If the Options.AuthenticationMode 
        is Passive, then the current request is not modified, but IAuthenticationManager AuthenticateAsync may be used at
        any time to obtain the claims from the request's bearer token.
        See also http://tools.ietf.org/html/rfc6749
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A  :any:`Microsoft.AspNetCore.Builder.JwtBearerOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.JwtBearerOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseJwtBearerAuthentication(IApplicationBuilder app, JwtBearerOptions options)
    

