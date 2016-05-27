

TwitterCreatingTicketContext Class
==================================






Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


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
* :dn:cls:`Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext`








Syntax
------

.. code-block:: csharp

    public class TwitterCreatingTicketContext : BaseTwitterContext








.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext
    :hidden:

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext

Properties
----------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.AccessToken
    
        
    
        
        Gets the Twitter access token
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AccessToken
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.AccessTokenSecret
    
        
    
        
        Gets the Twitter access token secret
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string AccessTokenSecret
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.Principal
    
        
    
        
        Gets the :any:`System.Security.Claims.ClaimsPrincipal` representing the user
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
            public ClaimsPrincipal Principal
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.Properties
    
        
    
        
        Gets or sets a property bag for common authentication properties
    
        
        :rtype: Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
            public AuthenticationProperties Properties
            {
                get;
                set;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.ScreenName
    
        
    
        
        Gets the Twitter screen name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string ScreenName
            {
                get;
            }
    
    .. dn:property:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.UserId
    
        
    
        
        Gets the Twitter user ID
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
            public string UserId
            {
                get;
            }
    

Constructors
------------

.. dn:class:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext.TwitterCreatingTicketContext(Microsoft.AspNetCore.Http.HttpContext, Microsoft.AspNetCore.Builder.TwitterOptions, System.String, System.String, System.String, System.String)
    
        
    
        
        Initializes a :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext`
    
        
    
        
        :param context: The HTTP environment
        
        :type context: Microsoft.AspNetCore.Http.HttpContext
    
        
        :param options: The options for Twitter
        
        :type options: Microsoft.AspNetCore.Builder.TwitterOptions
    
        
        :param userId: Twitter user ID
        
        :type userId: System.String
    
        
        :param screenName: Twitter screen name
        
        :type screenName: System.String
    
        
        :param accessToken: Twitter access token
        
        :type accessToken: System.String
    
        
        :param accessTokenSecret: Twitter access token secret
        
        :type accessTokenSecret: System.String
    
        
        .. code-block:: csharp
    
            public TwitterCreatingTicketContext(HttpContext context, TwitterOptions options, string userId, string screenName, string accessToken, string accessTokenSecret)
    

