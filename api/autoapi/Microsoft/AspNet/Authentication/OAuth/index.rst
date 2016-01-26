

Microsoft.AspNet.Authentication.OAuth Namespace
===============================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/IOAuthEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthCreatingTicketContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthHandler-TOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthMiddleware-TOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthRedirectToAuthorizationContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OAuth/OAuthTokenResponse/index
   
   











.. dn:namespace:: Microsoft.AspNet.Authentication.OAuth


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthCreatingTicketContext`
        Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthEvents`
        Default :any:`Microsoft.AspNet.Authentication.OAuth.IOAuthEvents` implementation.


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthHandler\<TOptions>`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthMiddleware\<TOptions>`
        An ASP.NET middleware for authenticating users using OAuth services.


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthOptions`
        Configuration options for OAuthMiddleware\.


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthRedirectToAuthorizationContext`
        Context passed when a Challenge causes a redirect to authorize endpoint in the middleware.


    class :dn:cls:`Microsoft.AspNet.Authentication.OAuth.OAuthTokenResponse`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Authentication.OAuth.IOAuthEvents`
        Specifies callback methods which the OAuthMiddleware invokes to enable developer control over the authentication process.


