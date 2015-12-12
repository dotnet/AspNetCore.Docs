

OAuthAppBuilderExtensions Class
===============================



.. contents:: 
   :local:



Summary
-------

Extension methods to add OAuth 2.0 authentication capabilities to an HTTP application pipeline.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Builder.OAuthAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

   public class OAuthAppBuilderExtensions





GitHub
------

`View on GitHub <https://github.com/aspnet/apidocs/blob/master/aspnet/security/src/Microsoft.AspNet.Authentication.OAuth/OAuthAppBuilderExtensions.cs>`_





.. dn:class:: Microsoft.AspNet.Builder.OAuthAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNet.Builder.OAuthAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNet.Builder.OAuthAppBuilderExtensions.UseOAuthAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, Microsoft.AspNet.Authentication.OAuth.OAuthOptions)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware\`1` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables OAuth 2.0 authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param options: A  that specifies options for the middleware.
        
        :type options: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseOAuthAuthentication(IApplicationBuilder app, OAuthOptions options)
    
    .. dn:method:: Microsoft.AspNet.Builder.OAuthAppBuilderExtensions.UseOAuthAuthentication(Microsoft.AspNet.Builder.IApplicationBuilder, System.Action<Microsoft.AspNet.Authentication.OAuth.OAuthOptions>)
    
        
    
        Adds the :any:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware\`1` middleware to the specified :any:`Microsoft.AspNet.Builder.IApplicationBuilder`\, which enables OAuth 2.0 authentication capabilities.
    
        
        
        
        :param app: The  to add the middleware to.
        
        :type app: Microsoft.AspNet.Builder.IApplicationBuilder
        
        
        :param configureOptions: An action delegate to configure the provided .
        
        :type configureOptions: System.Action{Microsoft.AspNet.Authentication.OAuth.OAuthOptions}
        :rtype: Microsoft.AspNet.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
           public static IApplicationBuilder UseOAuthAuthentication(IApplicationBuilder app, Action<OAuthOptions> configureOptions)
    

