

Microsoft.AspNetCore.Authentication.OAuth Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/IOAuthEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthCreatingTicketContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthHandler-TOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthMiddleware-TOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthRedirectToAuthorizationContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OAuth/OAuthTokenResponse/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authentication.OAuth


    .. rubric:: Interfaces


    interface :dn:iface:`IOAuthEvents`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents

        
        Specifies callback methods which the :any:`Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\`1` invokes to enable developer control over the authentication process.


    .. rubric:: Classes


    class :dn:cls:`OAuthCreatingTicketContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthCreatingTicketContext

        
        Contains information about the login session as well as the user :any:`System.Security.Claims.ClaimsIdentity`\.


    class :dn:cls:`OAuthEvents`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthEvents

        
        Default :any:`Microsoft.AspNetCore.Authentication.OAuth.IOAuthEvents` implementation.


    class :dn:cls:`OAuthHandler\<TOptions>`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthHandler\<TOptions>

        


    class :dn:cls:`OAuthMiddleware\<TOptions>`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthMiddleware\<TOptions>

        
        An ASP.NET Core middleware for authenticating users using OAuth services.


    class :dn:cls:`OAuthRedirectToAuthorizationContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthRedirectToAuthorizationContext

        
        Context passed when a Challenge causes a redirect to authorize endpoint in the middleware.


    class :dn:cls:`OAuthTokenResponse`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OAuth.OAuthTokenResponse

        


