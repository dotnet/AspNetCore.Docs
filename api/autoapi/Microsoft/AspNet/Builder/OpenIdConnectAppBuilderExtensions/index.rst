

OpenIdConnectAppBuilderExtensions Class
=======================================



.. contents:: 
   :local:



Summary
-------

Extension methods to add OpenID Connect authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.OpenIdConnectAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class OpenIdConnectAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OpenIdConnect/OpenIdConnectAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.OpenIdConnectAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.OpenIdConnectAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.OpenIdConnectAppBuilderExtensions.UseOpenIdConnectAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables OpenID Connect authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: An  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseOpenIdConnectAuthentication(IApplicationBuilder app, OpenIdConnectOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.OpenIdConnectAppBuilderExtensions.UseOpenIdConnectAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables OpenID Connect authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseOpenIdConnectAuthentication(IApplicationBuilder app, Action<OpenIdConnectOptions> configureOptions)
    

