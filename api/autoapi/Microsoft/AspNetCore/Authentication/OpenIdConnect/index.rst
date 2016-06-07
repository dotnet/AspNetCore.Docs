

Microsoft.AspNetCore.Authentication.OpenIdConnect Namespace
===========================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/AuthenticationFailedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/AuthorizationCodeReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/BaseOpenIdConnectContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/IOpenIdConnectEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/MessageReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/OpenIdConnectDefaults/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/OpenIdConnectEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/OpenIdConnectHandler/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/OpenIdConnectMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/OpenIdConnectRedirectBehavior/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/RedirectContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/TokenResponseReceivedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/TokenValidatedContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/OpenIdConnect/UserInformationReceivedContext/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authentication.OpenIdConnect


    .. rubric:: Classes


    class :dn:cls:`AuthenticationFailedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthenticationFailedContext

        


    class :dn:cls:`AuthorizationCodeReceivedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.AuthorizationCodeReceivedContext

        
        This Context can be used to be informed when an 'AuthorizationCode' is received over the OpenIdConnect protocol.


    class :dn:cls:`BaseOpenIdConnectContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.BaseOpenIdConnectContext

        


    class :dn:cls:`MessageReceivedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.MessageReceivedContext

        


    class :dn:cls:`OpenIdConnectDefaults`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectDefaults

        
        Default values related to OpenIdConnect authentication middleware


    class :dn:cls:`OpenIdConnectEvents`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectEvents

        
        Specifies events which the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


    class :dn:cls:`OpenIdConnectHandler`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectHandler

        
        A per-request authentication handler for the OpenIdConnectAuthenticationMiddleware.


    class :dn:cls:`OpenIdConnectMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware

        
        ASP.NET Core middleware for obtaining identities using OpenIdConnect protocol.


    class :dn:cls:`RedirectContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext

        
        When a user configures the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware` to be notified prior to redirecting to an IdentityProvider
        an instance of :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.RedirectContext` is passed to the 'RedirectToAuthenticationEndpoint' or 'RedirectToEndSessionEndpoint' events.


    class :dn:cls:`TokenResponseReceivedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenResponseReceivedContext

        
        This Context can be used to be informed when an 'AuthorizationCode' is redeemed for tokens at the token endpoint.


    class :dn:cls:`TokenValidatedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.TokenValidatedContext

        


    class :dn:cls:`UserInformationReceivedContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.OpenIdConnect.UserInformationReceivedContext

        


    .. rubric:: Enumerations


    enum :dn:enum:`OpenIdConnectRedirectBehavior`
        .. object: type=enum name=Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectRedirectBehavior

        
        Lists the different authentication methods used to
        redirect the user agent to the identity provider.


    .. rubric:: Interfaces


    interface :dn:iface:`IOpenIdConnectEvents`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.OpenIdConnect.IOpenIdConnectEvents

        
        Specifies events which the :any:`Microsoft.AspNetCore.Authentication.OpenIdConnect.OpenIdConnectMiddleware`\invokes to enable developer control over the authentication process.


