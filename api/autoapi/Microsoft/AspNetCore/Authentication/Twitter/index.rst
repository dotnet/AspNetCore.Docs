

Microsoft.AspNetCore.Authentication.Twitter Namespace
=====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/AccessToken/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/BaseTwitterContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/ITwitterEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/RequestToken/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/RequestTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/TwitterCreatingTicketContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/TwitterDefaults/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/TwitterEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/TwitterMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Twitter/TwitterRedirectToAuthorizationEndpointContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authentication.Twitter


    .. rubric:: Interfaces


    interface :dn:iface:`ITwitterEvents`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents

        
        Specifies callback methods which the :any:`Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware` invokes to enable developer control over the authentication process. />


    .. rubric:: Classes


    class :dn:cls:`AccessToken`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.AccessToken

        
        The Twitter access token retrieved from the access token endpoint.


    class :dn:cls:`BaseTwitterContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.BaseTwitterContext

        
        Base class for other Twitter contexts.


    class :dn:cls:`RequestToken`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.RequestToken

        
        The Twitter request token obtained from the request token endpoint.


    class :dn:cls:`RequestTokenSerializer`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.RequestTokenSerializer

        
        Serializes and deserializes Twitter request and access tokens so that they can be used by other application components.


    class :dn:cls:`TwitterCreatingTicketContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.TwitterCreatingTicketContext

        
        Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


    class :dn:cls:`TwitterDefaults`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.TwitterDefaults

        


    class :dn:cls:`TwitterEvents`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.TwitterEvents

        
        Default :any:`Microsoft.AspNetCore.Authentication.Twitter.ITwitterEvents` implementation.


    class :dn:cls:`TwitterMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.TwitterMiddleware

        
        ASP.NET Core middleware for authenticating users using Twitter.


    class :dn:cls:`TwitterRedirectToAuthorizationEndpointContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext

        
        The Context passed when a Challenge causes a redirect to authorize endpoint in the Twitter middleware.


