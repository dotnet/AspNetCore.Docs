

JwtBearerMiddleware Class
=========================



.. contents:: 
   :local:



Summary
-------

Bearer authentication middleware component which is added to an HTTP pipeline. This class is not
created by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication
extension method.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.AuthenticationMiddleware{Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions}`
* :dn:cls:`Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware`








Syntax
------

.. code-block:: csharp

   public class JwtBearerMiddleware : AuthenticationMiddleware<JwtBearerOptions>





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.JwtBearer/JwtBearerMiddleware.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware.JwtBearerMiddleware(Microsoft.AspNet.Builder.RequestDelegate, Microsoft.Extensions.Logging.ILoggerFactory, Microsoft.Extensions.WebEncoders.IUrlEncoder, Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions)
    
        
    
        Bearer authentication component which is added to an HTTP pipeline. This constructor is not
        called by application code directly, instead it is added by calling the the IAppBuilder UseJwtBearerAuthentication
        extension method.
    
        
        
        
        :type next: Microsoft.AspNet.Builder.RequestDelegate
        
        
        :type loggerFactory: Microsoft.Extensions.Logging.ILoggerFactory
        
        
        :type encoder: Microsoft.Extensions.WebEncoders.IUrlEncoder
        
        
        :type options: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions
    
        
        .. code-block:: csharp
    
           public JwtBearerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IUrlEncoder encoder, JwtBearerOptions options)
    

Methods
-------

.. dn:class:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Authentication.JwtBearer.JwtBearerMiddleware.CreateHandler()
    
        
    
        Called by the AuthenticationMiddleware base class to create a per-request handler.
    
        
        :rtype: Microsoft.AspNet.Authentication.AuthenticationHandler{Microsoft.AspNet.Authentication.JwtBearer.JwtBearerOptions}
        :return: A new instance of the request handler
    
        
        .. code-block:: csharp
    
           protected override AuthenticationHandler<JwtBearerOptions> CreateHandler()
    

