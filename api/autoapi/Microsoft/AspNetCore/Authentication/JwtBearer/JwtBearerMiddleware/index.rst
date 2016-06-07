

JwtBearerMiddleware Class
=========================






Bearer authentication middleware component which is added to an HTTP pipeline. This class is not
created by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication
extension method.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.JwtBearer`
Assemblies
    * Microsoft.AspNetCore.Authentication.JwtBearer

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.AuthenticationMiddleware{Microsoft.AspNetCore.Builder.JwtBearerOptions}`
* :dn:cls:`Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware`








Syntax
------

.. code-block:: csharp

    public class JwtBearerMiddleware : AuthenticationMiddleware<JwtBearerOptions>








.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware.JwtBearerMiddleware(Microsoft.AspNetCore.Http.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, System.Text.Encodings.Web.UrlEncoder, Microsoft.Extensions.Options.IOptions<Microsoft.AspNetCore.Builder.JwtBearerOptions>)
    
        
    
        
        Bearer authentication component which is added to an HTTP pipeline. This constructor is not
        called by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication 
        extension method.
    
        
    
        
        :type next: Microsoft.AspNetCore.Http.RequestDelegate
    
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
    
        
        :type encoder: System.Text.Encodings.Web.UrlEncoder
    
        
        :type options: Microsoft.Extensions.Options.IOptions<Microsoft.Extensions.Options.IOptions`1>{Microsoft.AspNetCore.Builder.JwtBearerOptions<Microsoft.AspNetCore.Builder.JwtBearerOptions>}
    
        
        .. code-block:: csharp
    
            public JwtBearerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, UrlEncoder encoder, IOptions<JwtBearerOptions> options)
    

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerMiddleware.CreateHandler()
    
        
    
        
        Called by the AuthenticationMiddleware base class to create a per-request handler. 
    
        
        :rtype: Microsoft.AspNetCore.Authentication.AuthenticationHandler<Microsoft.AspNetCore.Authentication.AuthenticationHandler`1>{Microsoft.AspNetCore.Builder.JwtBearerOptions<Microsoft.AspNetCore.Builder.JwtBearerOptions>}
        :return: A new instance of the request handler
    
        
        .. code-block:: csharp
    
            protected override AuthenticationHandler<JwtBearerOptions> CreateHandler()
    

