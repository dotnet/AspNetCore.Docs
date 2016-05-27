

TwitterRedirectToAuthorizationEndpointContext Class
===================================================






The Context passed when a Challenge causes a redirect to authorize endpoint in the Twitter middleware.


Namespace
    :dn:ns:`Microsoft.AspNetCore.Authentication.Twitter`
Assemblies
    * Microsoft.AspNetCore.Authentication.Twitter

----

.. contents::
   :local:



Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNetCore.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext`
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext`








Syntax
------

.. code-block:: csharp

    public class TwitterRedirectToAuthorizationEndpointContext : BaseTwitterContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.Properties
    
        
    
        
        Gets the authentication properties of the challenge.
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.RedirectUri
    
        
    
        
        Gets the URI used for the redirect operation.
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string RedirectUri
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext.TwitterRedirectToAuthorizationEndpointContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.TwitterOptions, Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties, System.String)
    
        
    
        
        Creates a new context object.
    
        
    
        
        :param context: The HTTP request context.
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The Twitter middleware options.
        
        :type options: Microsoft.AspNetCore.Builder.TwitterOptions
    
        
        :param properties: The authentication properties of the challenge.
        
        :type properties: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        :param redirectUri: The initial redirect URI.
        
        :type redirectUri: System.String
    
        
        .. code-block:: csharp
    
            public TwitterRedirectToAuthorizationEndpointContext(HttpContext context, TwitterOptions options, AuthenticationProperties properties, string redirectUri)
    

