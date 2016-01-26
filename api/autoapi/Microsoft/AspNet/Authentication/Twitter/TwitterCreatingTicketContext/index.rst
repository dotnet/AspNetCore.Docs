

TwitterCreatingTicketContext Class
==================================



.. contents:: 
   :local:



Summary
-------

Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.





Inheritance Hierarchy
---------------------


* :dn:cls:`System.Object`
* :dn:cls:`Microsoft.AspNet.Authentication.BaseContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext`
* :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext`








Syntax
------

.. code-block:: csharp

   public class TwitterCreatingTicketContext : BaseTwitterContext





GitHub
------

`View on GitHub <https://github.com/aspnet/security/blob/master/src/Microsoft.AspNet.Authentication.Twitter/Events/TwitterCreatingTicketContext.cs>`_





.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext

Constructors
------------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:constructor:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.TwitterCreatingTicketContext(Microsoft.AspNet.Http.HttpContext, Microsoft.AspNet.Authentication.Twitter.TwitterOptions, System.String, System.String, System.String, System.String)
    
        
    
        Initializes a :any:`Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext`
    
        
        
        
        :param context: The HTTP environment
        
        :type context: Microsoft.AspNet.Http.HttpContext
        
        
        :type options: Microsoft.AspNet.Authentication.Twitter.TwitterOptions
        
        
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
    

Properties
----------

.. dn:class:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext
    :noindex:
    :hidden:

    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.AccessToken
    
        
    
        Gets the Twitter access token
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AccessToken { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.AccessTokenSecret
    
        
    
        Gets the Twitter access token secret
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string AccessTokenSecret { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.Principal
    
        
    
        Gets the :any:`System.Security.Claims.ClaimsPrincipal` representing the user
    
        
        :rtype: System.Security.Claims.ClaimsPrincipal
    
        
        .. code-block:: csharp
    
           public ClaimsPrincipal Principal { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.Properties
    
        
    
        Gets or sets a property bag for common authentication properties
    
        
        :rtype: Microsoft.AspNet.Http.Authentication.AuthenticationProperties
    
        
        .. code-block:: csharp
    
           public AuthenticationProperties Properties { get; set; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.ScreenName
    
        
    
        Gets the Twitter screen name
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string ScreenName { get; }
    
    .. dn:property:: Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext.UserId
    
        
    
        Gets the Twitter user ID
    
        
        :rtype: System.String
    
        
        .. code-block:: csharp
    
           public string UserId { get; }
    

