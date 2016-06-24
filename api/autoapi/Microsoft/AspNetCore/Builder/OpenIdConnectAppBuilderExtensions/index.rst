

OpenIdConnectAppBuilderExtensions Class
=======================================






Extension methods to add OpenID Connect authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.OpenIdConnect

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class OpenIdConnectAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions.UseOpenIdConnectAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables OpenID Connect authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseOpenIdConnectAuthentication(this IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OpenIdConnectAppBuilderExtensions.UseOpenIdConnectAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.OpenIdConnectOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables OpenID Connect authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.OpenIdConnectOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.OpenIdConnectOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseOpenIdConnectAuthentication(this IApplicationBuilder app, OpenIdConnectOptions options)
    

