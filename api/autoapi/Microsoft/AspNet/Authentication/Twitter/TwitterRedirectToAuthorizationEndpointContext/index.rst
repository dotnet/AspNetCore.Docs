

TwitterRedirectToAuthorizationEndpointContext Class
===================================================



.. contents:: 
   :local:



Summary
-------

The Context passed when a Challenge causes a redirect to authorize endpoint in the Twitter middleware.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext`








Syntax
------

.. code-block:: csharp

   public class TwitterRedirectToAuthorizationEndpointContext : BaseTwitterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/Events/TwitterRedirectToAuthorizationEndpointContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.TwitterRedirectToAuthorizationEndpointContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Twitter.TwitterOptions, Microsoft.AspNet.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        Creates a new context object.
    
        
        
        
        :param context: The HTTP request context.
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :param options: The Twitter middleware options.
        
        :type options: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
        
        
        :param properties: The authentication properties of the challenge.
        
        :type properties: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
        
        
        :param redirectUri: The initial redirect URI.
        
        :type redirectUri: System.String
    
        
        .. code-block:: csharp
    
           public TwitterRedirectToAuthorizationEndpointContext(HttpContext context, TwitterOptions options, AuthenticationProperties properties, string redirectUri)
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.Properties
    
        
    
        Gets the authentication properties of the challenge.
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.RedirectUri
    
        
    
        Gets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string RedirectUri { get; }
    

