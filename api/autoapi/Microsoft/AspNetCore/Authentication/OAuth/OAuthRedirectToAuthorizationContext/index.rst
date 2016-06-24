

OAuthRedirectToAuthorizationContext Class
=========================================






Context passed when a Challenge causes a redirect to authorize endpoint in the middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.OAuth`
Assemblies
    * Microsoft.AspNetCore.Authentication.OAuth

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext`








Syntax
------

.. code-block:: csharp

    public class OAuthRedirectToAuthorizationContext : BaseContext








.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext.OAuthRedirectToAuthorizationContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.OAuthOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        Creates a new context object.
    
        
    
        
        :param context: The HTTP request context.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The :any:`Microsoft.AspNetCore.Builder.OAuthOptions`\.
        
        :type options: Microsoft.AspNetCore.Builder.OAuthOptions
    
        
        :param properties: The authentication properties of the challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param redirectUri: The initial redirect URI.
        
        :type redirectUri: System.String
    
        
        .. code-block:: csharp
    
            public OAuthRedirectToAuthorizationContext(HttpContext context, OAuthOptions options, AuthenticationProperties properties, string redirectUri)
    

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext.Options
    
        
        :rtype: Microsoft.AspNetCore.Builder.OAuthOptions
    
        
        .. code-block:: csharp
    
            public OAuthOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext.Properties
    
        
    
        
        Gets the authentication properties of the challenge.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties { get; }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext.RedirectUri
    
        
    
        
        Gets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RedirectUri { get; }
    

