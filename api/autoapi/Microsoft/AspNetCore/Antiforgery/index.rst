

Microsoft.AspNetCore.Antiforgery Namespace
==========================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/AntiforgeryOptions/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/AntiforgeryTokenSet/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/AntiforgeryValidationException/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/IAntiforgery/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/IAntiforgeryAdditionalDataProvider/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Antiforgery


    .. rubric:: Interfaces


    interface :dn:iface:`IAntiforgery`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.IAntiforgery

        
        Provides access to the antiforgery system, which provides protection against
        Cross-site Request Forgery (XSRF, also called CSRF) attacks.


    interface :dn:iface:`IAntiforgeryAdditionalDataProvider`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider

        
        Allows providing or validating additional custom data for antiforgery tokens.
        For example, the developer could use this to supply a nonce when the token is
        generated, then he could validate the nonce when the token is validated.


    .. rubric:: Classes


    class :dn:cls:`AntiforgeryOptions`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.AntiforgeryOptions

        
        Provides programmatic configuration for the antiforgery token system.


    class :dn:cls:`AntiforgeryTokenSet`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.AntiforgeryTokenSet

        
        The antiforgery token pair (cookie and request token) for a request.


    class :dn:cls:`AntiforgeryValidationException`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.AntiforgeryValidationException

        
        The :any:`System.Exception` that is thrown when the antiforgery token validation fails.


