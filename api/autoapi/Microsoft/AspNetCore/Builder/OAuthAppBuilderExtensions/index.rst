

OAuthAppBuilderExtensions Class
===============================






Extension methods to add OAuth 2.0 authentication capabilities to an HTTP application pipeline.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Builder`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions`








Syntax
------

.. code-block:: csharp

    public class OAuthAppBuilderExtensions








.. dn:class:: Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions

Methods
-------

.. dn:class:: Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions
    :noindex:
    :hidden:

    
    .. dn:method:: Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions.UseOAuthAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables OAuth 2.0 authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseOAuthAuthentication(IApplicationBuilder app)
    
    .. dn:method:: Microsoft.AspNetCore.Builder.OAuthAppBuilderExtensions.UseOAuthAuthentication(Microsoft.AspNetCore.Builder.IApplicationBuilder, Microsoft.AspNetCore.Builder.OAuthOptions)
    
        
    
        
        Adds the :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1` middleware to the specified :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder`\, which enables OAuth 2.0 authentication capabilities.
    
        
    
        
        :param app: The :any:`Microsoft.AspNetCore.Builder.IApplicationBuilder` to add the middleware to.
        
        :type app: Microsoft.AspNetCore.Builder.IApplicationBuilder
    
        
        :param options: A :any:`Microsoft.AspNetCore.Builder.OAuthOptions` that specifies options for the middleware.
        
        :type options: Microsoft.AspNetCore.Builder.OAuthOptions
        :rtype: Microsoft.AspNetCore.Builder.IApplicationBuilder
        :return: A reference to this instance after the operation has completed.
    
        
        .. code-block:: csharp
    
            public static IApplicationBuilder UseOAuthAuthentication(IApplicationBuilder app, OAuthOptions options)
    

