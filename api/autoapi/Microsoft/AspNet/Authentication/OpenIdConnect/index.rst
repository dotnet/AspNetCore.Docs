

Microsoft.AspNet.Authentication.OpenIdConnect Namespace
=======================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/AuthenticationFailedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/AuthenticationValidatedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/AuthorizationCodeReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/AuthorizationResponseReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/BaseOpenIdConnectContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/IOpenIdConnectEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/MessageReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectDefaults/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectHandler/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/OpenIdConnectRedirectBehavior/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/RedirectContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/TokenResponseReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/OpenIdConnect/UserInformationReceivedContext/index
   
   











.. dn:namespace:: Microsoft.AspNet.Authentication.OpenIdConnect


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationFailedContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthenticationValidatedContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext`
        This Context can be used to be informed when an 'AuthorizationCode' is received over the OpenIdConnect protocol.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.AuthorizationResponseReceivedContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.BaseOpenIdConnectContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.MessageReceivedContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectDefaults`
        Default values related to OpenIdConnect authentication middleware


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectEvents`
        Specifies events which the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectHandler`
        A per-request authentication handler for the OpenIdConnectAuthenticationMiddleware.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`
        ASP.NET middleware for obtaining identities using OpenIdConnect protocol.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`
        Configuration options for :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectOptions`


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext`
        When a user configures the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware` to be notified prior to redirecting to an IdentityProvider
        an instance of :any:`Microsoft.AspNet.Authentication.OpenIdConnect.RedirectContext` is passed to the 'RedirectToAuthenticationEndpoint' or 'RedirectToEndSessionEndpoint' events.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.TokenResponseReceivedContext`
        This Context can be used to be informed when an 'AuthorizationCode' is redeemed for tokens at the token endpoint.


    class :dn:cls:`Microsoft.AspNet.Authentication.OpenIdConnect.UserInformationReceivedContext`
        


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Authentication.OpenIdConnect.IOpenIdConnectEvents`
        Specifies events which the :any:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior`
        Lists the different authentication methods used to
        redirect the user agent to the identity provider.


