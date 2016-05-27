

Microsoft.AspNetCore.Antiforgery.Internal Namespace
===================================================







.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/AntiforgeryFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/AntiforgeryOptionsSetup/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/AntiforgerySerializationContext/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/AntiforgerySerializationContextPooledObjectPolicy/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/AntiforgeryToken/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/BinaryBlob/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultAntiforgery/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultAntiforgeryAdditionalDataProvider/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultAntiforgeryTokenGenerator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultAntiforgeryTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultAntiforgeryTokenStore/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/DefaultClaimUidExtractor/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/IAntiforgeryFeature/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/IAntiforgeryTokenGenerator/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/IAntiforgeryTokenSerializer/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/IAntiforgeryTokenStore/index
   
   
   
   /autoapi/Microsoft/AspNetCore/Antiforgery/Internal/IClaimUidExtractor/index
   
   






.. toctree::
   :hidden:
   :maxdepth: 2

   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   








.. dn:namespace:: Microsoft.AspNetCore.Antiforgery.Internal


    .. rubric:: Classes


    class :dn:cls:`AntiforgeryFeature`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryFeature

        
        Used to hold per-request state.


    class :dn:cls:`AntiforgeryOptionsSetup`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryOptionsSetup

        


    class :dn:cls:`AntiforgerySerializationContext`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContext

        


    class :dn:cls:`AntiforgerySerializationContextPooledObjectPolicy`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.AntiforgerySerializationContextPooledObjectPolicy

        


    class :dn:cls:`AntiforgeryToken`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.AntiforgeryToken

        


    class :dn:cls:`BinaryBlob`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.BinaryBlob

        


    class :dn:cls:`DefaultAntiforgery`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgery

        
        Provides access to the antiforgery system, which provides protection against
        Cross-site Request Forgery (XSRF, also called CSRF) attacks.


    class :dn:cls:`DefaultAntiforgeryAdditionalDataProvider`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryAdditionalDataProvider

        
        A default :any:`Microsoft.AspNetCore.Antiforgery.IAntiforgeryAdditionalDataProvider` implementation.


    class :dn:cls:`DefaultAntiforgeryTokenGenerator`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenGenerator

        


    class :dn:cls:`DefaultAntiforgeryTokenSerializer`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenSerializer

        


    class :dn:cls:`DefaultAntiforgeryTokenStore`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultAntiforgeryTokenStore

        


    class :dn:cls:`DefaultClaimUidExtractor`
        .. object: type=class name=Microsoft.AspNetCore.Antiforgery.Internal.DefaultClaimUidExtractor

        
        Default implementation of :any:`Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor`\.


    .. rubric:: Interfaces


    interface :dn:iface:`IAntiforgeryFeature`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryFeature

        


    interface :dn:iface:`IAntiforgeryTokenGenerator`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenGenerator

        
        Generates and validates antiforgery tokens.


    interface :dn:iface:`IAntiforgeryTokenSerializer`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenSerializer

        


    interface :dn:iface:`IAntiforgeryTokenStore`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.Internal.IAntiforgeryTokenStore

        


    interface :dn:iface:`IClaimUidExtractor`
        .. object: type=interface name=Microsoft.AspNetCore.Antiforgery.Internal.IClaimUidExtractor

        
        This interface can extract unique identifers for a :any:`System.Security.Claims.ClaimsPrincipal`\.


