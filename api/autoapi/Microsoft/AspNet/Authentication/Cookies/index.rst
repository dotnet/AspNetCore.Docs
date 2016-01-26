

Microsoft.AspNet.Authentication.Cookies Namespace
=================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/BaseCookieContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/ChunkingCookieManager/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieAuthenticationDefaults/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieAuthenticationEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieAuthenticationMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieAuthenticationOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieRedirectContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieSecureOption/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieSignedInContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieSigningInContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieSigningOutContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/CookieValidatePrincipalContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/ICookieAuthenticationEvents/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/ICookieManager/index
   
   
   
   /autoapi/Microsoft/AspNet/Authentication/Cookies/ITicketStore/index
   
   











.. dn:namespace:: Microsoft.AspNet.Authentication.Cookies


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.BaseCookieContext`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.ChunkingCookieManager`
        This handles cookies that are limited by per cookie length. It breaks down long cookies for responses, and reassembles them
        from requests.


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationDefaults`
        Default values related to cookie-based authentication middleware


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationEvents`
        This default implementation of the ICookieAuthenticationEvents may be used if the
        application only needs to override a few of the interface methods. This may be used as a base class
        or may be instantiated directly.


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware`
        


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationOptions`
        Contains the options used by the CookiesAuthenticationMiddleware


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieRedirectContext`
        Context passed when a Challenge, SignIn, or SignOut causes a redirect in the cookie middleware


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSignedInContext`
        Context object passed to the ICookieAuthenticationEvents method SignedIn.


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSigningInContext`
        Context object passed to the ICookieAuthenticationEvents method SigningIn.


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieSigningOutContext`
        Context object passed to the ICookieAuthenticationEvents method SigningOut


    class :dn:cls:`Microsoft.AspNet.Authentication.Cookies.CookieValidatePrincipalContext`
        Context object passed to the ICookieAuthenticationProvider method ValidatePrincipal.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Authentication.Cookies.ICookieAuthenticationEvents`
        Specifies callback methods which the :any:`Microsoft.AspNet.Authentication.Cookies.CookieAuthenticationMiddleware` invokes to enable developer control over the authentication process. /&gt;


    interface :dn:iface:`Microsoft.AspNet.Authentication.Cookies.ICookieManager`
        This is used by the CookieAuthenticationMiddleware to process request and response cookies.
        It is abstracted from the normal cookie APIs to allow for complex operations like chunking.


    interface :dn:iface:`Microsoft.AspNet.Authentication.Cookies.ITicketStore`
        This provides an abstract storage mechanic to preserve identity information on the server
        while only sending a simple identifier key to the client. This is most commonly used to mitigate
        issues with serializing large identities into cookies.


    .. rubric:: Enumerations


    enum :dn:enum:`Microsoft.AspNet.Authentication.Cookies.CookieSecureOption`
        Determines how the identity cookie's security property is set.


