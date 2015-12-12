

Microsoft.AspNet.Antiforgery Namespace
======================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNet/Antiforgery/AntiforgeryContext/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/AntiforgeryOptions/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/AntiforgeryOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/AntiforgeryToken/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/AntiforgeryTokenSet/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/BinaryBlob/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgery/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgeryAdditionalDataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgeryContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgeryTokenGenerator/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgeryTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultAntiforgeryTokenStore/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/DefaultClaimUidExtractor/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgery/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgeryAdditionalDataProvider/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgeryContextAccessor/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgeryTokenGenerator/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgeryTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IAntiforgeryTokenStore/index
   
   
   
   /autoapi/Microsoft/AspNet/Antiforgery/IClaimUidExtractor/index
   
   











.. dn:namespace:: Microsoft.AspNet.Antiforgery


    .. rubric:: Classes


    class :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryContext`
        Used as a per request state.


    class :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryOptions`
        Provides programmatic configuration for the antiforgery token system.


    class :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryOptionsSetup`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryToken`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.AntiforgeryTokenSet`
        The antiforgery token pair (cookie and form token) for a request.


    class :dn:cls:`Microsoft.AspNet.Antiforgery.BinaryBlob`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgery`
        Provides access to the antiforgery system, which provides protection against
        Cross-site Request Forgery (XSRF, also called CSRF) attacks.


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryAdditionalDataProvider`
        A default :any:`Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider` implementation.


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryContextAccessor`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenGenerator`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenSerializer`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultAntiforgeryTokenStore`
        


    class :dn:cls:`Microsoft.AspNet.Antiforgery.DefaultClaimUidExtractor`
        Default implementation of :any:`Microsoft.AspNet.Antiforgery.IClaimUidExtractor`\.


    .. rubric:: Interfaces


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgery`
        Provides access to the antiforgery system, which provides protection against
        Cross-site Request Forgery (XSRF, also called CSRF) attacks.


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgeryAdditionalDataProvider`
        Allows providing or validating additional custom data for antiforgery tokens.
        For example, the developer could use this to supply a nonce when the token is
        generated, then he could validate the nonce when the token is validated.


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgeryContextAccessor`
        


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgeryTokenGenerator`
        Generates and validates antiforgery tokens.


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgeryTokenSerializer`
        


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IAntiforgeryTokenStore`
        


    interface :dn:iface:`Microsoft.AspNet.Antiforgery.IClaimUidExtractor`
        This interface can extract unique identifers for a claims-based identity.


