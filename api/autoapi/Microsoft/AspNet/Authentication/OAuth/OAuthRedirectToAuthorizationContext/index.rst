

OAuthRedirectToAuthorizationContext Class
=========================================



.. contents:: 
   :local:



Summary
-------

Context passed when a Challenge causes a redirect to authorize endpoint in the middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext`








Syntax
------

.. code-block:: csharp

   public class OAuthRedirectToAuthorizationContext : BaseContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.OAuth/Events/OAuthRedirectToAuthorizationContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext.OAuthRedirectToAuthorizationContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.OAuth.OAuthOptions, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        Creates a new context object.
    
        
        
        
        :param context: The HTTP request context.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
        
        
        :param properties: The authentication properties of the challenge.
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :param redirectUri: The initial redirect URI.
        
        :type redirectUri: System.String
    
        
        .. code-block:: csharp
    
           public OAuthRedirectToAuthorizationContext(HttpContext context, OAuthOptions options, AuthenticationProperties properties, string redirectUri)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext.Options
    
        
        :rtype: Microsoft.AspNet.Authentication.OAuth.OAuthOptions
    
        
        .. code-block:: csharp
    
           public OAuthOptions Options { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext.Properties
    
        
    
        Gets the authentication properties of the challenge.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext.RedirectUri
    
        
    
        Gets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RedirectUri { get; }
    

