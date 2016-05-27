

Microsoft.AspNetCore.Authentication.Cookies Namespace
=====================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/BaseCookieContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/ChunkingCookieManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieAuthenticationDefaults/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieAuthenticationEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieAuthenticationMiddleware/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieRedirectContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieSecureOption/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieSignedInContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieSigningInContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieSigningOutContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/CookieValidatePrincipalContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/ICookieAuthenticationEvents/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/ICookieManager/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Authentication/Cookies/ITicketStore/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Authentication.Cookies


    .. rubric:: Classes


    class :dn:cls:`BaseCookieContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.BaseCookieContext

        


    class :dn:cls:`ChunkingCookieManager`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.ChunkingCookieManager

        
        This handles cookies that are limited by per cookie length. It breaks down long cookies for responses, and reassembles them
        from requests.


    class :dn:cls:`CookieAuthenticationDefaults`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults

        
        Default values related to cookie-based authentication middleware


    class :dn:cls:`CookieAuthenticationEvents`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents

        
        This default implementation of the ICookieAuthenticationEvents may be used if the 
        application only needs to override a few of the interface methods. This may be used as a base class
        or may be instantiated directly.


    class :dn:cls:`CookieAuthenticationMiddleware`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware

        


    class :dn:cls:`CookieRedirectContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieRedirectContext

        
        Context passed when a Challenge, SignIn, or SignOut causes a redirect in the cookie middleware 


    class :dn:cls:`CookieSignedInContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieSignedInContext

        
        Context object passed to the ICookieAuthenticationEvents method SignedIn.


    class :dn:cls:`CookieSigningInContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieSigningInContext

        
        Context object passed to the ICookieAuthenticationEvents method SigningIn.


    class :dn:cls:`CookieSigningOutContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieSigningOutContext

        
        Context object passed to the ICookieAuthenticationEvents method SigningOut    


    class :dn:cls:`CookieValidatePrincipalContext`
        .. object: type=class name=Microsoft.AspNetCore.Authentication.Cookies.CookieValidatePrincipalContext

        
        Context object passed to the ICookieAuthenticationProvider method ValidatePrincipal.


    .. rubric:: Enumerations


    enum :dn:enum:`CookieSecureOption`
        .. object: type=enum name=Microsoft.AspNetCore.Authentication.Cookies.CookieSecureOption

        
        Determines how the identity cookie's security property is set.


    .. rubric:: Interfaces


    interface :dn:iface:`ICookieAuthenticationEvents`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.Cookies.ICookieAuthenticationEvents

        
        Specifies callback methods which the :any:`Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationMiddleware` invokes to enable developer control over the authentication process. />


    interface :dn:iface:`ICookieManager`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.Cookies.ICookieManager

        
        This is used by the CookieAuthenticationMiddleware to process request and response cookies.
        It is abstracted from the normal cookie APIs to allow for complex operations like chunking.


    interface :dn:iface:`ITicketStore`
        .. object: type=interface name=Microsoft.AspNetCore.Authentication.Cookies.ITicketStore

        
        This provides an abstract storage mechanic to preserve identity information on the server
        while only sending a simple identifier key to the client. This is most commonly used to mitigate
        issues with serializing large identities into cookies.


