

Microsoft.AspNet.Authentication.Twitter Namespace
=================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/AccessToken/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/BaseTwitterContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/ITwitterEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/RequestToken/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/RequestTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterCreatingTicketContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterDefaults/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Twitter/TwitterRedirectToAuthorizationEndpointContext/index
   
   











.. dn:namespace:: Microsoft.AspNet.Authentication.Twitter


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.AccessToken`
        The Twitter access token retrieved from the access token endpoint.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.BaseTwitterContext`
        Base class for other Twitter contexts.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.RequestToken`
        The Twitter request token obtained from the request token endpoint.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.RequestTokenSerializer`
        Serializes and deserializes Twitter request and access tokens so that they can be used by other application components.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterCreatingTicketContext`
        Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterDefaults`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterEvents`
        Default :any:`Microsoft.AspNet.Authentication.Twitter.ITwitterEvents` implementation.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware`
        ASP.NET middleware for authenticating users using Twitter


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterOptions`
        Options for the Twitter authentication middleware.


    class :dn:cls:`Microsoft.AspNet.Authentication.Twitter.TwitterRedirectToAuthorizationEndpointContext`
        The Context passed when a Challenge causes a redirect to authorize endpoint in the Twitter middleware.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Authentication.Twitter.ITwitterEvents`
        Specifies callback methods which the :any:`Microsoft.AspNet.Authentication.Twitter.TwitterMiddleware` invokes to enable developer control over the authentication process. /&gt;


